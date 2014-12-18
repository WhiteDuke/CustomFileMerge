namespace CustomFileMerge
{
    partial class frmMyDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mergeList = new System.Windows.Forms.ListView();
            this.pathHeader = new System.Windows.Forms.ColumnHeader();
            this.btnMerge = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labelDelimiter = new System.Windows.Forms.Label();
            this.txtDelimiter = new System.Windows.Forms.TextBox();
            this.chkInclude = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // mergeList
            // 
            this.mergeList.AllowDrop = true;
            this.mergeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mergeList.CheckBoxes = true;
            this.mergeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pathHeader});
            this.mergeList.Location = new System.Drawing.Point(12, 12);
            this.mergeList.Name = "mergeList";
            this.mergeList.Size = new System.Drawing.Size(600, 333);
            this.mergeList.TabIndex = 0;
            this.mergeList.UseCompatibleStateImageBehavior = false;
            this.mergeList.View = System.Windows.Forms.View.Details;
            this.mergeList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.mergeList_ItemChecked);
            this.mergeList.DragEnter += new System.Windows.Forms.DragEventHandler(this.mergeList_DragEnter);
            // 
            // pathHeader
            // 
            this.pathHeader.Text = "Путь";
            this.pathHeader.Width = 580;
            // 
            // btnMerge
            // 
            this.btnMerge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMerge.Location = new System.Drawing.Point(456, 351);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 23);
            this.btnMerge.TabIndex = 1;
            this.btnMerge.Text = "&Выполнить";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(537, 351);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelDelimiter
            // 
            this.labelDelimiter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDelimiter.AutoSize = true;
            this.labelDelimiter.Location = new System.Drawing.Point(13, 356);
            this.labelDelimiter.Name = "labelDelimiter";
            this.labelDelimiter.Size = new System.Drawing.Size(117, 13);
            this.labelDelimiter.TabIndex = 3;
            this.labelDelimiter.Text = "Разделитель файлов:";
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDelimiter.Location = new System.Drawing.Point(136, 352);
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(100, 20);
            this.txtDelimiter.TabIndex = 4;
            this.txtDelimiter.Text = "--";
            // 
            // chkInclude
            // 
            this.chkInclude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkInclude.AutoSize = true;
            this.chkInclude.Checked = true;
            this.chkInclude.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInclude.Location = new System.Drawing.Point(242, 354);
            this.chkInclude.Name = "chkInclude";
            this.chkInclude.Size = new System.Drawing.Size(133, 17);
            this.chkInclude.TabIndex = 5;
            this.chkInclude.Text = "Включать имя файла";
            this.chkInclude.UseVisualStyleBackColor = true;
            // 
            // frmMyDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 386);
            this.Controls.Add(this.chkInclude);
            this.Controls.Add(this.txtDelimiter);
            this.Controls.Add(this.labelDelimiter);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.mergeList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(640, 420);
            this.Name = "frmMyDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор файлов для объединения";
            this.Load += new System.EventHandler(this.frmMyDlg_Load);
            this.Activated += new System.EventHandler(this.frmMyDlg_Activated);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmMyDlg_KeyPress);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMyDlg_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView mergeList;
        private System.Windows.Forms.ColumnHeader pathHeader;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelDelimiter;
        private System.Windows.Forms.TextBox txtDelimiter;
        private System.Windows.Forms.CheckBox chkInclude;

    }
}