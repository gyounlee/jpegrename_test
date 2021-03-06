namespace JpegRename
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mMainMenu = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mMenuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mBtnNext = new System.Windows.Forms.Button();
            this.mBtnPrevious = new System.Windows.Forms.Button();
            this.mPBoxImage = new System.Windows.Forms.PictureBox();
            this.mListBoxFile = new System.Windows.Forms.ListBox();
            this.mBtnBrowse = new System.Windows.Forms.Button();
            this.mTextFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mCheckBoxCapital = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.mCBoxGab = new System.Windows.Forms.ComboBox();
            this.mRBtnCustom = new System.Windows.Forms.RadioButton();
            this.mRBtnTDSTS = new System.Windows.Forms.RadioButton();
            this.mRBtnTS = new System.Windows.Forms.RadioButton();
            this.mRBtnSTDST = new System.Windows.Forms.RadioButton();
            this.mRBtnST = new System.Windows.Forms.RadioButton();
            this.mPanelMulti = new System.Windows.Forms.Panel();
            this.mLblCompleteFile = new System.Windows.Forms.Label();
            this.mLblTotalFile = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mPBarStatus = new System.Windows.Forms.ProgressBar();
            this.mBtnConfirm = new System.Windows.Forms.Button();
            this.mLblChangedName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mTextPostfix = new System.Windows.Forms.TextBox();
            this.mTextTakenDate = new System.Windows.Forms.TextBox();
            this.mTextPrefix = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.mRBtnMulti = new System.Windows.Forms.RadioButton();
            this.mRBtnSingle = new System.Windows.Forms.RadioButton();
            this.mMainMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mPBoxImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.mPanelMulti.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mMainMenu
            // 
            this.mMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.mMenuAbout});
            this.mMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mMainMenu.Name = "mMainMenu";
            this.mMainMenu.Size = new System.Drawing.Size(828, 24);
            this.mMainMenu.TabIndex = 0;
            this.mMainMenu.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mMenuFileExit});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // mMenuFileExit
            // 
            this.mMenuFileExit.Name = "mMenuFileExit";
            this.mMenuFileExit.Size = new System.Drawing.Size(149, 22);
            this.mMenuFileExit.Text = "프로그램 종료";
            this.mMenuFileExit.Click += new System.EventHandler(this.mMenuFileExit_Click);
            // 
            // mMenuAbout
            // 
            this.mMenuAbout.Name = "mMenuAbout";
            this.mMenuAbout.Size = new System.Drawing.Size(52, 20);
            this.mMenuAbout.Text = "About";
            this.mMenuAbout.Click += new System.EventHandler(this.mMenuAbout_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mBtnNext);
            this.groupBox1.Controls.Add(this.mBtnPrevious);
            this.groupBox1.Controls.Add(this.mPBoxImage);
            this.groupBox1.Controls.Add(this.mListBoxFile);
            this.groupBox1.Controls.Add(this.mBtnBrowse);
            this.groupBox1.Controls.Add(this.mTextFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 537);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "사진파일";
            // 
            // mBtnNext
            // 
            this.mBtnNext.Location = new System.Drawing.Point(79, 248);
            this.mBtnNext.Name = "mBtnNext";
            this.mBtnNext.Size = new System.Drawing.Size(50, 24);
            this.mBtnNext.TabIndex = 6;
            this.mBtnNext.Text = "다음";
            this.mBtnNext.UseVisualStyleBackColor = true;
            this.mBtnNext.Click += new System.EventHandler(this.mBtnNext_Click);
            // 
            // mBtnPrevious
            // 
            this.mBtnPrevious.Location = new System.Drawing.Point(21, 248);
            this.mBtnPrevious.Name = "mBtnPrevious";
            this.mBtnPrevious.Size = new System.Drawing.Size(50, 24);
            this.mBtnPrevious.TabIndex = 5;
            this.mBtnPrevious.Text = "이전";
            this.mBtnPrevious.UseVisualStyleBackColor = true;
            this.mBtnPrevious.Click += new System.EventHandler(this.mBtnPrevious_Click);
            // 
            // mPBoxImage
            // 
            this.mPBoxImage.Location = new System.Drawing.Point(26, 289);
            this.mPBoxImage.Name = "mPBoxImage";
            this.mPBoxImage.Size = new System.Drawing.Size(295, 232);
            this.mPBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mPBoxImage.TabIndex = 4;
            this.mPBoxImage.TabStop = false;
            // 
            // mListBoxFile
            // 
            this.mListBoxFile.FormattingEnabled = true;
            this.mListBoxFile.Location = new System.Drawing.Point(21, 70);
            this.mListBoxFile.Name = "mListBoxFile";
            this.mListBoxFile.Size = new System.Drawing.Size(301, 173);
            this.mListBoxFile.TabIndex = 3;
            this.mListBoxFile.SelectedIndexChanged += new System.EventHandler(this.mListBoxFile_SelectedIndexChanged);
            // 
            // mBtnBrowse
            // 
            this.mBtnBrowse.Image = ((System.Drawing.Image)(resources.GetObject("mBtnBrowse.Image")));
            this.mBtnBrowse.Location = new System.Drawing.Point(297, 33);
            this.mBtnBrowse.Name = "mBtnBrowse";
            this.mBtnBrowse.Size = new System.Drawing.Size(31, 23);
            this.mBtnBrowse.TabIndex = 2;
            this.mBtnBrowse.UseVisualStyleBackColor = true;
            this.mBtnBrowse.Click += new System.EventHandler(this.mBtnBrowse_Click);
            // 
            // mTextFolder
            // 
            this.mTextFolder.Location = new System.Drawing.Point(79, 35);
            this.mTextFolder.Name = "mTextFolder";
            this.mTextFolder.ReadOnly = true;
            this.mTextFolder.Size = new System.Drawing.Size(212, 20);
            this.mTextFolder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "폴더선택";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mCheckBoxCapital);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.mPanelMulti);
            this.groupBox2.Controls.Add(this.mBtnConfirm);
            this.groupBox2.Controls.Add(this.mLblChangedName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.mTextPostfix);
            this.groupBox2.Controls.Add(this.mTextTakenDate);
            this.groupBox2.Controls.Add(this.mTextPrefix);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(391, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 478);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "이름변경";
            // 
            // mCheckBoxCapital
            // 
            this.mCheckBoxCapital.AutoSize = true;
            this.mCheckBoxCapital.Location = new System.Drawing.Point(21, 23);
            this.mCheckBoxCapital.Name = "mCheckBoxCapital";
            this.mCheckBoxCapital.Size = new System.Drawing.Size(113, 17);
            this.mCheckBoxCapital.TabIndex = 12;
            this.mCheckBoxCapital.Text = "확장자 대문자로";
            this.mCheckBoxCapital.UseVisualStyleBackColor = true;
            this.mCheckBoxCapital.CheckedChanged += new System.EventHandler(this.mCheckBoxCapital_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.mCBoxGab);
            this.groupBox4.Controls.Add(this.mRBtnCustom);
            this.groupBox4.Controls.Add(this.mRBtnTDSTS);
            this.groupBox4.Controls.Add(this.mRBtnTS);
            this.groupBox4.Controls.Add(this.mRBtnSTDST);
            this.groupBox4.Controls.Add(this.mRBtnST);
            this.groupBox4.Location = new System.Drawing.Point(15, 182);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(359, 106);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "시간변경";
            // 
            // mCBoxGab
            // 
            this.mCBoxGab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mCBoxGab.FormattingEnabled = true;
            this.mCBoxGab.Items.AddRange(new object[] {
            "+23",
            "+22",
            "+21",
            "+20",
            "+19",
            "+18",
            "+17",
            "+16",
            "+15",
            "+14",
            "+13",
            "+12",
            "+11",
            "+10",
            "+9",
            "+8",
            "+7",
            "+6",
            "+5",
            "+4",
            "+3",
            "+2",
            "+1",
            "0",
            "-1",
            "-2",
            "-3",
            "-4",
            "-5",
            "-6",
            "-7",
            "-8",
            "-9",
            "-10",
            "-11",
            "-12",
            "-13",
            "-14",
            "-15",
            "-16",
            "-17",
            "-18",
            "-19",
            "-20",
            "-21",
            "-22",
            "-23"});
            this.mCBoxGab.Location = new System.Drawing.Point(102, 71);
            this.mCBoxGab.Name = "mCBoxGab";
            this.mCBoxGab.Size = new System.Drawing.Size(58, 21);
            this.mCBoxGab.TabIndex = 5;
            this.mCBoxGab.SelectedIndexChanged += new System.EventHandler(this.mCBoxGab_SelectedIndexChanged);
            // 
            // mRBtnCustom
            // 
            this.mRBtnCustom.AutoSize = true;
            this.mRBtnCustom.Location = new System.Drawing.Point(11, 72);
            this.mRBtnCustom.Name = "mRBtnCustom";
            this.mRBtnCustom.Size = new System.Drawing.Size(85, 17);
            this.mRBtnCustom.TabIndex = 4;
            this.mRBtnCustom.TabStop = true;
            this.mRBtnCustom.Text = "사용자지정";
            this.mRBtnCustom.UseVisualStyleBackColor = true;
            this.mRBtnCustom.CheckedChanged += new System.EventHandler(this.mRBtnCustom_CheckedChanged);
            // 
            // mRBtnTDSTS
            // 
            this.mRBtnTDSTS.AutoSize = true;
            this.mRBtnTDSTS.Location = new System.Drawing.Point(160, 49);
            this.mRBtnTDSTS.Name = "mRBtnTDSTS";
            this.mRBtnTDSTS.Size = new System.Drawing.Size(128, 17);
            this.mRBtnTDSTS.TabIndex = 3;
            this.mRBtnTDSTS.TabStop = true;
            this.mRBtnTDSTS.Text = "토론토(DST) -> 서울";
            this.mRBtnTDSTS.UseVisualStyleBackColor = true;
            this.mRBtnTDSTS.CheckedChanged += new System.EventHandler(this.mRBtnTDSTS_CheckedChanged);
            // 
            // mRBtnTS
            // 
            this.mRBtnTS.AutoSize = true;
            this.mRBtnTS.Location = new System.Drawing.Point(160, 26);
            this.mRBtnTS.Name = "mRBtnTS";
            this.mRBtnTS.Size = new System.Drawing.Size(100, 17);
            this.mRBtnTS.TabIndex = 2;
            this.mRBtnTS.TabStop = true;
            this.mRBtnTS.Text = "토론토 -> 서울";
            this.mRBtnTS.UseVisualStyleBackColor = true;
            this.mRBtnTS.CheckedChanged += new System.EventHandler(this.mRBtnTS_CheckedChanged);
            // 
            // mRBtnSTDST
            // 
            this.mRBtnSTDST.AutoSize = true;
            this.mRBtnSTDST.Location = new System.Drawing.Point(11, 49);
            this.mRBtnSTDST.Name = "mRBtnSTDST";
            this.mRBtnSTDST.Size = new System.Drawing.Size(128, 17);
            this.mRBtnSTDST.TabIndex = 1;
            this.mRBtnSTDST.TabStop = true;
            this.mRBtnSTDST.Text = "서울 -> 토론토(DST)";
            this.mRBtnSTDST.UseVisualStyleBackColor = true;
            this.mRBtnSTDST.CheckedChanged += new System.EventHandler(this.mRBtnSTDST_CheckedChanged);
            // 
            // mRBtnST
            // 
            this.mRBtnST.AutoSize = true;
            this.mRBtnST.Location = new System.Drawing.Point(11, 26);
            this.mRBtnST.Name = "mRBtnST";
            this.mRBtnST.Size = new System.Drawing.Size(100, 17);
            this.mRBtnST.TabIndex = 0;
            this.mRBtnST.TabStop = true;
            this.mRBtnST.Text = "서울 -> 토론토";
            this.mRBtnST.UseVisualStyleBackColor = true;
            this.mRBtnST.CheckedChanged += new System.EventHandler(this.mRBtnST_CheckedChanged);
            // 
            // mPanelMulti
            // 
            this.mPanelMulti.Controls.Add(this.mLblCompleteFile);
            this.mPanelMulti.Controls.Add(this.mLblTotalFile);
            this.mPanelMulti.Controls.Add(this.label7);
            this.mPanelMulti.Controls.Add(this.label6);
            this.mPanelMulti.Controls.Add(this.mPBarStatus);
            this.mPanelMulti.Location = new System.Drawing.Point(10, 330);
            this.mPanelMulti.Name = "mPanelMulti";
            this.mPanelMulti.Size = new System.Drawing.Size(362, 132);
            this.mPanelMulti.TabIndex = 10;
            // 
            // mLblCompleteFile
            // 
            this.mLblCompleteFile.AutoSize = true;
            this.mLblCompleteFile.Location = new System.Drawing.Point(141, 91);
            this.mLblCompleteFile.Name = "mLblCompleteFile";
            this.mLblCompleteFile.Size = new System.Drawing.Size(79, 13);
            this.mLblCompleteFile.TabIndex = 13;
            this.mLblCompleteFile.Text = "총변환할파일";
            // 
            // mLblTotalFile
            // 
            this.mLblTotalFile.AutoSize = true;
            this.mLblTotalFile.Location = new System.Drawing.Point(141, 67);
            this.mLblTotalFile.Name = "mLblTotalFile";
            this.mLblTotalFile.Size = new System.Drawing.Size(79, 13);
            this.mLblTotalFile.TabIndex = 12;
            this.mLblTotalFile.Text = "총변환할파일";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "완료된파일";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "총변환할파일";
            // 
            // mPBarStatus
            // 
            this.mPBarStatus.Location = new System.Drawing.Point(27, 26);
            this.mPBarStatus.Name = "mPBarStatus";
            this.mPBarStatus.Size = new System.Drawing.Size(309, 23);
            this.mPBarStatus.TabIndex = 9;
            // 
            // mBtnConfirm
            // 
            this.mBtnConfirm.Location = new System.Drawing.Point(15, 297);
            this.mBtnConfirm.Name = "mBtnConfirm";
            this.mBtnConfirm.Size = new System.Drawing.Size(75, 23);
            this.mBtnConfirm.TabIndex = 8;
            this.mBtnConfirm.Text = "변경";
            this.mBtnConfirm.UseVisualStyleBackColor = true;
            this.mBtnConfirm.Click += new System.EventHandler(this.mBtnConfirm_Click);
            // 
            // mLblChangedName
            // 
            this.mLblChangedName.AutoSize = true;
            this.mLblChangedName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mLblChangedName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mLblChangedName.Location = new System.Drawing.Point(28, 155);
            this.mLblChangedName.Name = "mLblChangedName";
            this.mLblChangedName.Size = new System.Drawing.Size(37, 15);
            this.mLblChangedName.TabIndex = 7;
            this.mLblChangedName.Text = "label6";
            this.mLblChangedName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "변경될 파일이름";
            // 
            // mTextPostfix
            // 
            this.mTextPostfix.Location = new System.Drawing.Point(81, 98);
            this.mTextPostfix.Name = "mTextPostfix";
            this.mTextPostfix.Size = new System.Drawing.Size(204, 20);
            this.mTextPostfix.TabIndex = 5;
            this.mTextPostfix.TextChanged += new System.EventHandler(this.mTextPostfix_TextChanged);
            // 
            // mTextTakenDate
            // 
            this.mTextTakenDate.Location = new System.Drawing.Point(81, 72);
            this.mTextTakenDate.Name = "mTextTakenDate";
            this.mTextTakenDate.ReadOnly = true;
            this.mTextTakenDate.Size = new System.Drawing.Size(204, 20);
            this.mTextTakenDate.TabIndex = 4;
            // 
            // mTextPrefix
            // 
            this.mTextPrefix.Location = new System.Drawing.Point(81, 46);
            this.mTextPrefix.Name = "mTextPrefix";
            this.mTextPrefix.Size = new System.Drawing.Size(204, 20);
            this.mTextPrefix.TabIndex = 3;
            this.mTextPrefix.TextChanged += new System.EventHandler(this.mTextPrefix_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "접미어";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "촬영일자";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "접두어";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.mRBtnMulti);
            this.groupBox3.Controls.Add(this.mRBtnSingle);
            this.groupBox3.Location = new System.Drawing.Point(392, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(381, 51);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "작업옵션";
            // 
            // mRBtnMulti
            // 
            this.mRBtnMulti.AutoSize = true;
            this.mRBtnMulti.Location = new System.Drawing.Point(201, 19);
            this.mRBtnMulti.Name = "mRBtnMulti";
            this.mRBtnMulti.Size = new System.Drawing.Size(73, 17);
            this.mRBtnMulti.TabIndex = 1;
            this.mRBtnMulti.TabStop = true;
            this.mRBtnMulti.Text = "복수파일";
            this.mRBtnMulti.UseVisualStyleBackColor = true;
            this.mRBtnMulti.CheckedChanged += new System.EventHandler(this.mRBtnMulti_CheckedChanged);
            // 
            // mRBtnSingle
            // 
            this.mRBtnSingle.AutoSize = true;
            this.mRBtnSingle.Location = new System.Drawing.Point(90, 19);
            this.mRBtnSingle.Name = "mRBtnSingle";
            this.mRBtnSingle.Size = new System.Drawing.Size(73, 17);
            this.mRBtnSingle.TabIndex = 0;
            this.mRBtnSingle.TabStop = true;
            this.mRBtnSingle.Text = "단일파일";
            this.mRBtnSingle.UseVisualStyleBackColor = true;
            this.mRBtnSingle.CheckedChanged += new System.EventHandler(this.mRBtnSingle_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 592);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mMainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mMainMenu;
            this.Name = "MainForm";
            this.Text = "사진파일 이름변경 툴";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.mMainMenu.ResumeLayout(false);
            this.mMainMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mPBoxImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.mPanelMulti.ResumeLayout(false);
            this.mPanelMulti.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mMainMenu;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mMenuFileExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mTextFolder;
        private System.Windows.Forms.Button mBtnBrowse;
        private System.Windows.Forms.ListBox mListBoxFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label mLblChangedName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox mTextPostfix;
        private System.Windows.Forms.TextBox mTextTakenDate;
        private System.Windows.Forms.TextBox mTextPrefix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button mBtnNext;
        private System.Windows.Forms.Button mBtnPrevious;
        private System.Windows.Forms.PictureBox mPBoxImage;
        private System.Windows.Forms.Button mBtnConfirm;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton mRBtnMulti;
        private System.Windows.Forms.RadioButton mRBtnSingle;
        private System.Windows.Forms.Panel mPanelMulti;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar mPBarStatus;
        private System.Windows.Forms.Label mLblCompleteFile;
        private System.Windows.Forms.Label mLblTotalFile;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton mRBtnTDSTS;
        private System.Windows.Forms.RadioButton mRBtnTS;
        private System.Windows.Forms.RadioButton mRBtnSTDST;
        private System.Windows.Forms.RadioButton mRBtnST;
        private System.Windows.Forms.ComboBox mCBoxGab;
        private System.Windows.Forms.RadioButton mRBtnCustom;
        private System.Windows.Forms.ToolStripMenuItem mMenuAbout;
        private System.Windows.Forms.CheckBox mCheckBoxCapital;
    }
}

