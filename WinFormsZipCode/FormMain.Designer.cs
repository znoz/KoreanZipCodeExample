namespace WinFormsZipCode
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            toolStrip1 = new ToolStrip();
            labelKeyword = new ToolStripLabel();
            textBoxKeyword = new ToolStripTextBox();
            toolStripSeparator1 = new ToolStripSeparator();
            labelPage = new ToolStripLabel();
            comboBoxPage = new ToolStripComboBox();
            toolStripSeparator2 = new ToolStripSeparator();
            labelPageSize = new ToolStripLabel();
            comboBoxPageSize = new ToolStripComboBox();
            toolStripSeparator3 = new ToolStripSeparator();
            buttonSearch = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            labelMessage = new ToolStripStatusLabel();
            dataGridViewAddress = new DataGridView();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAddress).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { labelKeyword, textBoxKeyword, toolStripSeparator1, labelPage, comboBoxPage, toolStripSeparator2, labelPageSize, comboBoxPageSize, toolStripSeparator3, buttonSearch });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // labelKeyword
            // 
            labelKeyword.Name = "labelKeyword";
            labelKeyword.Size = new Size(90, 22);
            labelKeyword.Text = "지번/도로명(&K):";
            // 
            // textBoxKeyword
            // 
            textBoxKeyword.Name = "textBoxKeyword";
            textBoxKeyword.Size = new Size(100, 25);
            textBoxKeyword.KeyPress += textBoxKeyword_KeyPress;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // labelPage
            // 
            labelPage.Name = "labelPage";
            labelPage.Size = new Size(89, 22);
            labelPage.Text = "현재 페이지(&P):";
            // 
            // comboBoxPage
            // 
            comboBoxPage.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPage.Name = "comboBoxPage";
            comboBoxPage.Size = new Size(75, 25);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // labelPageSize
            // 
            labelPageSize.Name = "labelPageSize";
            labelPageSize.Size = new Size(78, 22);
            labelPageSize.Text = "출력 개수(&C):";
            // 
            // comboBoxPageSize
            // 
            comboBoxPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPageSize.Name = "comboBoxPageSize";
            comboBoxPageSize.Size = new Size(75, 25);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // buttonSearch
            // 
            buttonSearch.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buttonSearch.ImageTransparentColor = Color.Magenta;
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(50, 22);
            buttonSearch.Text = "검색(&S)";
            buttonSearch.Click += buttonSearch_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { labelMessage });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // labelMessage
            // 
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(121, 17);
            labelMessage.Text = "toolStripStatusLabel1";
            // 
            // dataGridViewAddress
            // 
            dataGridViewAddress.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewAddress.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAddress.Dock = DockStyle.Fill;
            dataGridViewAddress.Location = new Point(0, 25);
            dataGridViewAddress.Name = "dataGridViewAddress";
            dataGridViewAddress.ReadOnly = true;
            dataGridViewAddress.Size = new Size(800, 403);
            dataGridViewAddress.TabIndex = 2;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewAddress);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Name = "FormMain";
            Text = "공공 API 우편번호 조회 예제";
            Load += FormMain_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAddress).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripLabel labelKeyword;
        private ToolStripTextBox textBoxKeyword;
        private ToolStripButton buttonSearch;
        private StatusStrip statusStrip1;
        private DataGridView dataGridViewAddress;
        private ToolStripStatusLabel labelMessage;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripComboBox comboBoxPage;
        private ToolStripLabel labelPage;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel labelPageSize;
        private ToolStripComboBox comboBoxPageSize;
        private ToolStripSeparator toolStripSeparator3;
    }
}
