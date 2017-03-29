using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


namespace JpegRename
{
    public partial class AboutDlg : Form
    {
        public AboutDlg()
        {
            InitializeComponent();
            string mailAddStr = string.Empty;
            string webAddStr = string.Empty;
            try
            {
                this.mLblVersion.Text = GlobalDefine.VER_STR + " " + GlobalDefine.BUILT_STR;
                this.mLblCopyright.Text = GlobalDefine.COPY_RIGHT_STR;

                mailAddStr = GlobalDefine.EMAIL_ADDR_STR;
                this.mLLblMail.Text = mailAddStr;
                this.mLLblMail.Links.Add(0, mailAddStr.Length, mailAddStr);

                webAddStr = GlobalDefine.WEB_ADDR_STR;
                this.mLLblWeb.Text = webAddStr;
                this.mLLblWeb.Links.Add(0, webAddStr.Length, webAddStr);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return;
            }
        }

        private void mLLblMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string target = string.Empty;
            try
            {
                target = e.Link.LinkData as string;
                if (null != target)
                {
                    Process.Start("mailto:" + target);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return;
            }
        }

        private void mLLblWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string target = string.Empty;
            try
            {
                target = e.Link.LinkData as string;
                if (null != target && target.StartsWith("www"))
                {
                    Process.Start(target);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return;
            }
        }
    }
}