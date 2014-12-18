using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NppPluginNET;

namespace CustomFileMerge
{
    class Main
    {
        #region " Fields "
        internal const string PluginName = "CustomFileMerge";
        static frmMyDlg frmMyDlg = null;
        #endregion

        #region " StartUp/CleanUp "
        internal static void CommandMenuInit()
        {
            PluginBase.SetCommand(0, "Show files for merge", ShowFiles4Merge, new ShortcutKey(false, false, false, Keys.None));
        }

        internal static void PluginCleanUp()
        {
            if (frmMyDlg != null)
            {
                frmMyDlg.Close();
                frmMyDlg.Dispose();
            }
        }
        #endregion

        #region " Main functions "
        
        private static int GetCurrentView(IntPtr currentScintilla)
        {
            return (currentScintilla == PluginBase.nppData._scintillaMainHandle) ? (int)NppMsg.PRIMARY_VIEW : (int)NppMsg.SECOND_VIEW;
        }

        internal static int GetFileCount(IntPtr currentScintilla)
        {
            int currentView = GetCurrentView(currentScintilla);
            return (int) Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETNBOPENFILES, 0, currentView);
        }

        internal static void PrepareList(Object list)
        {
            if (!(list is ListView))
            {
                MessageBox.Show("Программа выполнила невыполнимое, допустила недопустимое!");
                return;
            }

            ((ListView)list).Items.Clear();

            int fileCount = -1;
            IntPtr currentScintilla = PluginBase.GetCurrentScintilla();

            fileCount = Main.GetFileCount(currentScintilla);

            ClikeStringArray _names = new ClikeStringArray(fileCount, Win32.MAX_PATH);
            Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETOPENFILENAMES, _names.NativePointer, fileCount);

            ListViewItem lvi = null;
            for (int i = 0; i < fileCount; i++)
            {
                lvi = new ListViewItem();
                lvi.Checked = true;
                lvi.Text = _names.ManagedStringsUnicode[i];

                ((ListView)list).Items.Add(lvi);
            }
            ((ListView)list).Refresh();
        }

        internal static void MakeNewDocument(Object list, String delimiter, bool IncludeFileName)
        {
            ListView ls = list as ListView;

            if (ls == null) return;

            // Откроем новый документ
            Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_MENUCOMMAND, 0, NppMenuCmd.IDM_FILE_NEW);

            int currentDocIndex = 0;
            IntPtr currentScintilla = PluginBase.GetCurrentScintilla();
            Win32.SendMessage(currentScintilla, SciMsg.SCI_SETCODEPAGE, 0, 65001);

            int currentView = GetCurrentView(currentScintilla) - 1;
            currentDocIndex = (int) Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETCURRENTDOCINDEX, 0, currentView);

            int currentPosition = 0;

            for (int i = 0; i < ls.CheckedItems.Count; i++)
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder fileName = new StringBuilder(Win32.MAX_PATH);

                sb.Append(delimiter + " ");

                Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_SWITCHTOFILE, 0, ls.CheckedItems[i].Text);
                //Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_ACTIVATEDOC, currentView, i);
                Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETFILENAME, 0, fileName);

                if (IncludeFileName)
                {
                    sb.Append(fileName.ToString());
                }
                sb.AppendLine();

                currentPosition = (int) Win32.SendMessage(currentScintilla, SciMsg.SCI_GETCURRENTPOS, 0, 0);
                Win32.SendMessage(currentScintilla, SciMsg.SCI_SELECTALL, 0, 0);
                Win32.SendMessage(currentScintilla, SciMsg.SCI_COPY, 0, 0);
                Win32.SendMessage(currentScintilla, SciMsg.SCI_SETSEL, -1, currentPosition);

                Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_ACTIVATEDOC, currentView, currentDocIndex);
                Win32.SendMessage(currentScintilla, SciMsg.SCI_ADDTEXT, (int) sb.Length, sb);
                Win32.SendMessage(currentScintilla, SciMsg.SCI_PASTE, 0, 0);

                sb = null;
                fileName = null;
            }
        }

        internal static void ShowFiles4Merge()
        {
            if (frmMyDlg == null)
            {
                frmMyDlg = new frmMyDlg();
                Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_MODELESSDIALOG, frmMyDlg.Handle, (int)NppMsg.MODELESSDIALOGADD);
                frmMyDlg.Show();
            }
            else
            {
                frmMyDlg.Activate();
                frmMyDlg.Show();
            }
         }

        #endregion
    }
}