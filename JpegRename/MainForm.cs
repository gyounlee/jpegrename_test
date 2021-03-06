using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Collections;
using ExifExtractLib;


namespace JpegRename
{
    public partial class MainForm : Form
    {
        #region ENUM Define
        public enum JOBTYPE
        {
            JOBTYPE_SINGLE = 0,
            JOBTYPE_MULTI,
        }

        public enum TIMEZONETYPE
        {
            TIMEZONE_SEOULTOTORONTO,
            TIMEZONE_SEOULTOTORONTODST,
            TIMEZONE_TORONTOTOSEOUL,
            TIMEZONE_TORONTODSTTOSEOUL,
            TIMEZONE_CUSTOM,
        }
        
        #endregion ENUM Define

        #region Private Members
        private string mConfigFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\JpegRename.cfg";
        private string mCurrentFileFullName = string.Empty;
        private string mCurrentFileName = string.Empty;
        private string mCurrentFileNameExt = string.Empty;
        private JOBTYPE mJobType = JOBTYPE.JOBTYPE_SINGLE;
        private TIMEZONETYPE mTimeZoneType = TIMEZONETYPE.TIMEZONE_CUSTOM;
        private bool mAllowShow = true;
        #endregion Private Members

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
            this.mLblChangedName.Text = string.Empty;
            this.mLblTotalFile.Text = string.Empty;
            this.mLblCompleteFile.Text = string.Empty;
            this.mRBtnMulti.Checked = false;
            this.mRBtnSingle.Checked = true;
            this.mPanelMulti.Visible = false;
            this.mRBtnCustom.Checked = true;
            this.mCBoxGab.SelectedItem = "0";

            string initPath = this.GetLatestFolder();
            LogFile.WriteLog(GlobalDefine.LOGDIR + GlobalDefine.FILENAME, "기본폴더 : " + initPath);
            mTextFolder.Text = initPath;
            this.DisplayFile(mTextFolder.Text);
        }
        #endregion Constructor

        #region Private Methods
        //private void GetImageInformation()
        //{
        //    Image image = new Bitmap("C:\\dennis\\0509\\050901-133200.JPG");
        //    PropertyItem[] propItems = image.PropertyItems;
        //    foreach( PropertyItem propitem in propItems)
        //    {
        //        //if (propitem.Id.ToString("x") == "132")
        //        //{
        //        //    System.Diagnostics.Debug.WriteLine("ID : " + propitem.Id.ToString("x") + " Type : " + propitem.Type +
        //        //        " Len : " + propitem.Len + " Value : " + System.Text.Encoding.ASCII.GetString(propitem.Value));
        //        //}
        //        if (propitem.Type == 2)
        //        {
        //            System.Diagnostics.Debug.WriteLine("ID : " + propitem.Id.ToString("x") + " Type : " + propitem.Type +
        //                    " Len : " + propitem.Len + " Value : " + System.Text.Encoding.ASCII.GetString(propitem.Value));
        //        }
        //        else
        //        {
        //            System.Diagnostics.Debug.WriteLine("ID : " + propitem.Id.ToString("x") + " Type : " + propitem.Type +
        //                    " Len : " + propitem.Len + " Value : ");
        //        }
        //    }
        //}

        private void DisplayFile(string fullpath)
        {
            if (Directory.Exists(fullpath))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(fullpath);

                // Get *.jpg Image
                FileInfo[] fileInfo = dirInfo.GetFiles("*.jpg");
                for (int i = 0; i < fileInfo.Length; i++)
                {
                    this.mListBoxFile.Items.Add(fileInfo[i].Name);
                }

                // Get *.jpeg Image
                fileInfo = dirInfo.GetFiles("*.jpeg");
                for (int i = 0; i < fileInfo.Length; i++)
                {
                    this.mListBoxFile.Items.Add(fileInfo[i].Name);
                }

                // Get *.bmp Image
                fileInfo = dirInfo.GetFiles("*.bmp");
                for (int i = 0; i < fileInfo.Length; i++)
                {
                    this.mListBoxFile.Items.Add(fileInfo[i].Name);
                }
            }
        }

        private void ShowImage(string filePath)
        {
            if (mAllowShow == true)
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                this.mPBoxImage.Image = Image.FromStream(fs);
                fs.Close();
            }
        }

        private void GetTakenPictureTime(string filePath)
        {
            string strTakenDate = ExifExtrat.GetExifDTOrig(filePath);
            FileInfo fInfo = new FileInfo(filePath);
            if (strTakenDate == null || strTakenDate == "0000:00:00 00:00:00\0")
            {
                this.mTextTakenDate.Text = "해당 정보가 없습니다.";
            }
            else
            {
                DateTime takenDate = DateTime.ParseExact(strTakenDate.Trim(new char[] { '\0' }), "yyyy:MM:dd HH:mm:ss", null);
                switch (this.mTimeZoneType)
                {
                    case TIMEZONETYPE.TIMEZONE_SEOULTOTORONTO:
                        {
                            takenDate = takenDate.AddHours(-14);
                            break;
                        }
                    case TIMEZONETYPE.TIMEZONE_SEOULTOTORONTODST:
                        {
                            takenDate = takenDate.AddHours(-13);
                            break;
                        }
                    case TIMEZONETYPE.TIMEZONE_TORONTODSTTOSEOUL:
                        {
                            takenDate = takenDate.AddHours(+13);
                            break;
                        }
                    case TIMEZONETYPE.TIMEZONE_TORONTOTOSEOUL:
                        {
                            takenDate = takenDate.AddHours(+14);
                            break;
                        }
                    case TIMEZONETYPE.TIMEZONE_CUSTOM:
                        {
                            int gab = int.Parse(this.mCBoxGab.SelectedItem.ToString());
                            takenDate = takenDate.AddHours(gab);
                            break;
                        }

                }
                this.mTextTakenDate.Text = takenDate.ToString("yyyyMMdd_HHmmss");
            }
            this.ShowChangedFileName();
        }

        private void ShowChangedFileName()
        {
            if (this.mTextTakenDate.Text == "해당 정보가 없습니다.")
            {
                this.mLblChangedName.Text = this.mTextPrefix.Text.Trim() + this.mCurrentFileName +
                    this.mTextPostfix.Text.Trim() + this.mCurrentFileNameExt;
            }
            else
            {
                this.mLblChangedName.Text = this.mTextPrefix.Text.Trim() + this.mTextTakenDate.Text.Trim() +
                    this.mTextPostfix.Text.Trim() + this.mCurrentFileNameExt;
            }
        }

        // Load the Configuration file to get the latest folder
        private string GetLatestFolder()
        {
            string strResult = String.Empty;

            if(File.Exists(mConfigFile))
            {
                StreamReader sr = new StreamReader(mConfigFile);
                string line = String.Empty;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    if (line != String.Empty)
                    {
                        string[] tokens = line.Split('|');
                        if (tokens.Length == 2 && tokens[0].ToLower() == "recentfolder")
                        {
                            strResult = tokens[1];
                        }
                    }
                }
                sr.Close();
            }
            return strResult;
        }

        // Save the latest working folder
        private void SaveLatestFolder(string strFolder)
        {
            if (File.Exists(mConfigFile))
            {
                File.Delete(mConfigFile);
            }

            StreamWriter sw = new StreamWriter(mConfigFile, true);
            if (sw == null)
            {
                Console.WriteLine("cannot open the Config.");
                return;
            }

            sw.WriteLine("RecentFolder|" + strFolder);
            sw.Close();
        }

        #endregion Private Methods

        #region Event Handlers

        #region Menu Events
        private void mMenuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion Menu Events

        private void mBtnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fDlg = new FolderBrowserDialog();
            if (mTextFolder.Text != string.Empty)
            {
                fDlg.SelectedPath = mTextFolder.Text;
            }
            if (fDlg.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                this.mListBoxFile.Items.Clear();
                this.mTextFolder.Text = fDlg.SelectedPath;
                this.DisplayFile(fDlg.SelectedPath);
                this.Cursor = Cursors.Default;
            }
            else
            {
                fDlg.Dispose();
            }
        }

        private void mListBoxFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.mJobType == JOBTYPE.JOBTYPE_SINGLE)
            {
                if (mListBoxFile.SelectedIndex < 0)
                    return;
                string filePath = string.Empty;
                filePath = this.mTextFolder.Text + "\\" + (string)mListBoxFile.Items[mListBoxFile.SelectedIndex];
                this.mCurrentFileFullName = filePath;
                FileInfo fInfo = new FileInfo(filePath);
                this.mCurrentFileNameExt = fInfo.Extension.ToUpper();
                this.mCurrentFileName = fInfo.Name.Substring(0, fInfo.Name.Length - fInfo.Extension.Length);
                this.ShowImage(filePath);
                this.GetTakenPictureTime(filePath);
            }
            else
            {
                if (this.mListBoxFile.SelectedIndices.Count == 0)
                {
                    this.mCurrentFileFullName = string.Empty;
                    this.mCurrentFileNameExt = string.Empty;
                    this.mCurrentFileName = string.Empty;
                    this.mPBoxImage.Image = null;
                    this.mTextTakenDate.Text = string.Empty;
                    this.mLblChangedName.Text = string.Empty;
                    this.mLblTotalFile.Text = this.mListBoxFile.SelectedIndices.Count.ToString();
                    this.mLblCompleteFile.Text = "0";
                }
                else
                {
                    if (this.mAllowShow == true)
                    {
                        string filePath = string.Empty;
                        filePath = this.mTextFolder.Text + "\\" + (string)mListBoxFile.Items[mListBoxFile.SelectedIndices[0]];
                        this.mCurrentFileFullName = filePath;
                        FileInfo fInfo = new FileInfo(filePath);
                        this.mCurrentFileNameExt = fInfo.Extension.ToUpper();
                        this.mCurrentFileName = fInfo.Name.Substring(0, fInfo.Name.Length - fInfo.Extension.Length);
                        this.ShowImage(filePath);
                        this.GetTakenPictureTime(filePath);
                        this.mLblTotalFile.Text = this.mListBoxFile.SelectedIndices.Count.ToString();
                        this.mLblCompleteFile.Text = "0";
                    }
                }
            }
        }

        private void mBtnConfirm_Click(object sender, EventArgs e)
        {
            if (this.mListBoxFile.SelectedIndices.Count == 0)
            {
                MessageBox.Show("변환할 파일을 선택하세요.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.mJobType == JOBTYPE.JOBTYPE_SINGLE)
            {
                if (this.mCheckBoxCapital.Checked == true)
                {
                    try
                    {
                        FileInfo fInfo = new FileInfo(mCurrentFileFullName);
                        string extention = fInfo.Extension.ToUpper();
                        string changedName = fInfo.Name.Substring(0, fInfo.Name.Length - fInfo.Extension.Length);
                        this.mLblChangedName.Text = changedName + extention;
                        string destPath = this.mTextFolder.Text + "\\" + changedName + extention;
                        File.Move(this.mCurrentFileFullName, destPath);
                        string logMessage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " || " +
                                    this.mCurrentFileFullName + " || " + destPath;
                        LogFile.WriteLog(GlobalDefine.LOGDIR + GlobalDefine.FILENAME, logMessage);
                        this.mListBoxFile.Items[this.mListBoxFile.SelectedIndex] = this.mLblChangedName.Text;
                        this.mCurrentFileFullName = destPath;
                        this.ShowImage(destPath);
                        this.mListBoxFile.SelectionMode = SelectionMode.MultiExtended;
                        this.mListBoxFile.SelectionMode = SelectionMode.One;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    string destPath = this.mTextFolder.Text + "\\" + this.mLblChangedName.Text;
                    try
                    {
                        if (File.Exists(destPath) == true)
                        {
                            if (MessageBox.Show("같은 이름을 가진 파일이 존재합니다.\n_<n> 접미사를 추가하여 파일을 변경하고자 하면 yes를 " +
                                "그냥 skip 하려면 no를 누르세요", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                int dupNum = 1;
                                string dupFileName = string.Empty;
                                while (File.Exists(destPath) == true)
                                {
                                    dupFileName = this.mLblChangedName.Text.Substring(0, this.mLblChangedName.Text.Length - this.mCurrentFileNameExt.Length);
                                    dupFileName = dupFileName + "_" + dupNum.ToString() + this.mCurrentFileNameExt;
                                    destPath = this.mTextFolder.Text + "\\" + dupFileName;
                                    dupNum++;
                                }
                                File.Move(this.mCurrentFileFullName, destPath);
                                string logMessage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " || " +
                                    this.mCurrentFileFullName + " || " + destPath;
                                LogFile.WriteLog(GlobalDefine.LOGDIR + GlobalDefine.FILENAME, logMessage);
                                this.mListBoxFile.Items[this.mListBoxFile.SelectedIndex] = dupFileName;
                                this.mCurrentFileFullName = destPath;
                                this.ShowImage(destPath);
                            }
                        }
                        else
                        {
                            File.Move(this.mCurrentFileFullName, destPath);
                            string logMessage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " || " +
                                    this.mCurrentFileFullName + " || " + destPath;
                            LogFile.WriteLog(GlobalDefine.LOGDIR + GlobalDefine.FILENAME, logMessage);
                            this.mListBoxFile.Items[this.mListBoxFile.SelectedIndex] = this.mLblChangedName.Text;
                            this.mCurrentFileFullName = destPath;
                            this.ShowImage(destPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                    }
                }
            }
            else
            {
                string filePath = string.Empty;
                int count = this.mListBoxFile.SelectedIndices.Count;
                int completeCount = 0;
                this.mPBarStatus.Maximum = count;
                this.mPBarStatus.Minimum = 0;
                this.mPBarStatus.Value = 0;
                ArrayList itemArray = new ArrayList();
                for (int i = 0; i < count; i++)
                {
                    itemArray.Add(mListBoxFile.SelectedIndices[i]);
                }
                
                try
                {
                    this.mAllowShow = false;
                    for (int i = 0; i < count; i++)
                    {
                        filePath = this.mTextFolder.Text + "\\" + (string)mListBoxFile.Items[(int)itemArray[i]];
                        this.mCurrentFileFullName = filePath;
                        FileInfo fInfo = new FileInfo(filePath);
                        this.mCurrentFileNameExt = fInfo.Extension.ToUpper();
                        this.mCurrentFileName = fInfo.Name.Substring(0, fInfo.Name.Length - fInfo.Extension.Length);
                        this.ShowImage(filePath);
                        this.GetTakenPictureTime(filePath);

                        if (this.mCheckBoxCapital.Checked == true)
                        {
                            try
                            {
                                FileInfo fInfo1 = new FileInfo(mCurrentFileFullName);
                                string extention = fInfo1.Extension.ToUpper();
                                string changedName = fInfo1.Name.Substring(0, fInfo1.Name.Length - fInfo1.Extension.Length);
                                string destPath = this.mTextFolder.Text + "\\" + changedName + extention;
                                File.Move(this.mCurrentFileFullName, destPath);
                                string logMessage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " || " +
                                    this.mCurrentFileFullName + " || " + destPath;
                                LogFile.WriteLog(GlobalDefine.LOGDIR + GlobalDefine.FILENAME, logMessage);
                                this.mListBoxFile.Items[(int)itemArray[i]] = changedName + extention;
                                this.mCurrentFileFullName = destPath;
                                this.ShowImage(destPath);

                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine(ex.ToString());
                            }
                        }
                        else
                        {
                            string destPath = this.mTextFolder.Text + "\\" + this.mLblChangedName.Text;
                            if (File.Exists(destPath) == true)
                            {
                                if (MessageBox.Show("같은 이름을 가진 파일이 존재합니다.\n_<n> 접미사를 추가하여 파일을 변경하고자 하면 yes를 " +
                                    "그냥 skip 하려면 no를 누르세요", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                {
                                    int dupNum = 1;
                                    string dupFileName = string.Empty;
                                    while (File.Exists(destPath) == true)
                                    {
                                        dupFileName = this.mLblChangedName.Text.Substring(0, this.mLblChangedName.Text.Length - this.mCurrentFileNameExt.Length);
                                        dupFileName = dupFileName + "_" + dupNum.ToString() + this.mCurrentFileNameExt;
                                        destPath = this.mTextFolder.Text + "\\" + dupFileName;
                                        dupNum++;
                                    }
                                    File.Move(this.mCurrentFileFullName, destPath);
                                    string logMessage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " || " +
                                        this.mCurrentFileFullName + " || " + destPath;
                                    LogFile.WriteLog(GlobalDefine.LOGDIR + GlobalDefine.FILENAME, logMessage);
                                    this.mListBoxFile.Items[(int)itemArray[i]] = dupFileName;
                                    this.mCurrentFileFullName = destPath;
                                    this.ShowImage(destPath);
                                }
                            }
                            else
                            {
                                File.Move(this.mCurrentFileFullName, destPath);
                                string logMessage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " || " +
                                    this.mCurrentFileFullName + " || " + destPath;
                                LogFile.WriteLog(GlobalDefine.LOGDIR + GlobalDefine.FILENAME, logMessage);
                                this.mListBoxFile.Items[(int)itemArray[i]] = this.mLblChangedName.Text;
                                this.mCurrentFileFullName = destPath;
                                this.ShowImage(destPath);
                            }
                        }
                        completeCount++;
                        this.mLblCompleteFile.Text = completeCount.ToString();
                        this.mPBarStatus.Value = completeCount;
                        // Update the UI (2013/10/14)
                        Application.DoEvents();
                    }
                    mListBoxFile.SelectedIndices.Clear();
                    this.mListBoxFile.SelectionMode = SelectionMode.One;
                    this.mListBoxFile.SelectionMode = SelectionMode.MultiExtended;
                    for (int i = 0; i < count; i++)
                    {
                        mListBoxFile.SelectedIndices.Add((int)itemArray[i]);
                    }
                    this.mAllowShow = true;
                    
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    this.mAllowShow = true;
                }
            }
        }


        private void mBtnPrevious_Click(object sender, EventArgs e)
        {
            if (this.mJobType == JOBTYPE.JOBTYPE_SINGLE)
            {
                if (this.mListBoxFile.SelectedIndex < 0)
                {
                    this.mListBoxFile.SelectedIndex = 0;
                    return;
                }
                if (this.mListBoxFile.SelectedIndex == 0)
                    return;
                this.mListBoxFile.SelectedIndex = this.mListBoxFile.SelectedIndex - 1;
            }
        }

        private void mBtnNext_Click(object sender, EventArgs e)
        {
            if (this.mJobType == JOBTYPE.JOBTYPE_SINGLE)
            {
                if (this.mListBoxFile.SelectedIndex < 0)
                {
                    this.mListBoxFile.SelectedIndex = 0;
                    return;
                }
                if (this.mListBoxFile.SelectedIndex == this.mListBoxFile.Items.Count - 1)
                    return;
                this.mListBoxFile.SelectedIndex = this.mListBoxFile.SelectedIndex + 1;
            }
        }

        private void mTextPrefix_TextChanged(object sender, EventArgs e)
        {
            this.ShowChangedFileName();
        }

        private void mTextPostfix_TextChanged(object sender, EventArgs e)
        {
            this.ShowChangedFileName();
        }

        private void mRBtnSingle_CheckedChanged(object sender, EventArgs e)
        {
            this.mPanelMulti.Visible = false;
            this.mJobType = JOBTYPE.JOBTYPE_SINGLE;
            this.mListBoxFile.SelectionMode = SelectionMode.One;
        }

        private void mRBtnMulti_CheckedChanged(object sender, EventArgs e)
        {
            this.mPanelMulti.Visible = true;
            this.mLblTotalFile.Text = "0";
            this.mLblCompleteFile.Text = "0";
            this.mJobType = JOBTYPE.JOBTYPE_MULTI;
            this.mListBoxFile.SelectionMode = SelectionMode.MultiExtended;
        }

        private void mRBtnST_CheckedChanged(object sender, EventArgs e)
        {
            this.mTimeZoneType = TIMEZONETYPE.TIMEZONE_SEOULTOTORONTO;
            this.mCBoxGab.Enabled = false;
            if (mListBoxFile.SelectedIndices.Count != 0)
            {
                string filePath = this.mTextFolder.Text + "\\" + (string)mListBoxFile.Items[mListBoxFile.SelectedIndices[0]];
                this.GetTakenPictureTime(filePath);
            }
        }

        private void mRBtnTS_CheckedChanged(object sender, EventArgs e)
        {
            this.mTimeZoneType = TIMEZONETYPE.TIMEZONE_TORONTOTOSEOUL;
            this.mCBoxGab.Enabled = false;
            if (mListBoxFile.SelectedIndices.Count != 0)
            {
                string filePath = this.mTextFolder.Text + "\\" + (string)mListBoxFile.Items[mListBoxFile.SelectedIndices[0]];
                this.GetTakenPictureTime(filePath);
            }
        }

        private void mRBtnSTDST_CheckedChanged(object sender, EventArgs e)
        {
            this.mTimeZoneType = TIMEZONETYPE.TIMEZONE_SEOULTOTORONTODST;
            this.mCBoxGab.Enabled = false;
            if (mListBoxFile.SelectedIndices.Count != 0)
            {
                string filePath = this.mTextFolder.Text + "\\" + (string)mListBoxFile.Items[mListBoxFile.SelectedIndices[0]];
                this.GetTakenPictureTime(filePath);
            }
        }

        private void mRBtnTDSTS_CheckedChanged(object sender, EventArgs e)
        {
            this.mTimeZoneType = TIMEZONETYPE.TIMEZONE_TORONTODSTTOSEOUL;
            this.mCBoxGab.Enabled = false;
            if (mListBoxFile.SelectedIndices.Count != 0)
            {
                string filePath = this.mTextFolder.Text + "\\" + (string)mListBoxFile.Items[mListBoxFile.SelectedIndices[0]];
                this.GetTakenPictureTime(filePath);
            }
        }

        private void mRBtnCustom_CheckedChanged(object sender, EventArgs e)
        {
            this.mTimeZoneType = TIMEZONETYPE.TIMEZONE_CUSTOM;
            this.mCBoxGab.Enabled = true;
            if (mListBoxFile.SelectedIndices.Count != 0)
            {
                string filePath = this.mTextFolder.Text + "\\" + (string)mListBoxFile.Items[mListBoxFile.SelectedIndices[0]];
                this.GetTakenPictureTime(filePath);
            }
        }

        private void mCBoxGab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mListBoxFile.SelectedIndices.Count != 0)
            {
                string filePath = this.mTextFolder.Text + "\\" + (string)mListBoxFile.Items[mListBoxFile.SelectedIndices[0]];
                this.GetTakenPictureTime(filePath);
            }
        }

        private void mMenuAbout_Click(object sender, EventArgs e)
        {
            AboutDlg dlg = new AboutDlg();
            dlg.ShowDialog();
            dlg.Close();
        }

        private void mCheckBoxCapital_CheckedChanged(object sender, EventArgs e)
        {

        }
        

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLatestFolder(mTextFolder.Text);
        }

        #endregion Event Handlers
    }
}