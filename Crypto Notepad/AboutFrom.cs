﻿using JCS;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Crypto_Notepad
{
    public partial class AboutFrom : Form
    {
        private Random rnd = new Random();
        public AboutFrom()
        {
            InitializeComponent();
        }

        #region Methods     
        private void GetDebugInfo() 
        {
            Version vrs = new Version(Application.ProductVersion);
            StringBuilder sb = new StringBuilder(string.Empty);
            sb.AppendLine("App version = " + vrs);
            sb.AppendLine(string.Format("OS name = {0}", OSVersionInfo.Name + " " + OSVersionInfo.ServicePack));
            sb.AppendLine(string.Format("OS version = {0}", OSVersionInfo.VersionString));
            sb.AppendLine(".Net Framework = " + Methods.GetDotNetVersion());
            Clipboard.SetText(sb.ToString());
            aboutToolTip.Show("Copied", appVersionLabel, 210, 1, 1000);
        }
        #endregion


        #region Event Handlers
        private void AboutWindow_Load(object sender, EventArgs e)
        {
            Version vrs = new Version(Application.ProductVersion);
            appVersionLabel.Text = string.Format(PublicVar.appName + " {0}.{1}.{2}", vrs.Major, vrs.Minor, vrs.Build);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void RandomColorTimer_Tick(object sender, EventArgs e)
        {
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            appVersionLabel.ForeColor = randomColor;
        }

        private void AppVersionLabel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                GetDebugInfo();
            }
        }

        private void AppInfoRichTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void AppVersionLabel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                GetDebugInfo();
            }

            if (e.Button == MouseButtons.Right)
            {
                if (randomColorTimer.Enabled)
                {
                    randomColorTimer.Stop();
                }
                else
                {
                    randomColorTimer.Start();
                }
            }
        }
        #endregion


    }
}
