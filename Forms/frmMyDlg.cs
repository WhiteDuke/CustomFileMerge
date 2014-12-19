using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using NppPluginNET;

namespace CustomFileMerge
{
    public partial class frmMyDlg : Form
    {
        public frmMyDlg()
        {
            InitializeComponent();
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            Main.MakeNewDocument(this.mergeList, this.txtDelimiter.Text, this.chkInclude.Checked);
            this.Close();
        }

        private void frmMyDlg_Load(object sender, EventArgs e)
        {
            Main.PrepareList(this.mergeList);            
            Version versionInfo = Assembly.GetExecutingAssembly().GetName().Version;
            String versionStr = String.Format("{0}.{1}.{2}.{3}", versionInfo.Major.ToString(), 
            versionInfo.Minor.ToString(), versionInfo.Build.ToString(), versionInfo.Revision.ToString());
            this.Text = this.Text + " {" + String.Format("Версия {0}", versionStr) + "}";
        }

        private void frmMyDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void frmMyDlg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Escape)
            {
                e.Handled = true;
                this.Hide();
            }
        }

        private void frmMyDlg_Activated(object sender, EventArgs e)
        {
            Main.PrepareList(this.mergeList);            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mergeList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListView s = sender as ListView;

            if (s.CheckedItems.Count <= 1)
            {
                btnMerge.Enabled = false;
            }
            else
            {
                btnMerge.Enabled = true;
            }
        }
    }
}
