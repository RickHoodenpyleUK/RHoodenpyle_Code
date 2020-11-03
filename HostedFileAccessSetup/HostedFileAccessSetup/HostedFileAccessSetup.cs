using System;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Management;
using System.Management.Instrumentation;
using System.IO;
using System.Security.AccessControl;
using System.Xml.Serialization;
using System.Net;
using Microsoft.Win32;
using Microsoft.VisualBasic;
using System.Security;
using System.Runtime.InteropServices;
using System.Reflection;

namespace HostedFileAccessSetup
{
    public partial class HostedFileAccessSetup : Form
    {
        public HostedFileAccessSetup()
        {
            InitializeComponent();
        }
        public string userName = "";
        public string userPass = "";
        public string groupName = "";
        public string RMSInstallLocation = "";
        public string drive = "";
        private void SetupFileAccessBut_Click(object sender, EventArgs e)
        {
            try
            {
                userName = subUser(vpnUsernameTextBox.Text.ToUpper(),"VPN") + "FA";
                groupName = subUser(vpnUsernameTextBox.Text.ToUpper(), "RMS") + "FAGRP";
                userPass = vpnPassTextBox.Text;
                DriveInfo[] allDrives = DriveInfo.GetDrives();
                foreach (DriveInfo d in allDrives)
                {
                    if (d.IsReady && d.DriveType == DriveType.Fixed && Directory.Exists(d + "RMSInc"))
                    {
                        drive = d.Name;
                    }
                }
                RMSInstallLocation = drive + @"RMSInc";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string cmd = "NET";
                string args = " LOCALGROUP " + groupName + " /ADD";
                fStartInfo(cmd, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string cmd = "NET";
                string args = " USER " + userName + " " + userPass + " /ADD /ACTIVE:Yes /FULLNAME:\"" + userName + "File Access User\" /PASSWORDCHG:NO /LOGONPASSWORDCHG:NO";
                fStartInfo(cmd, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string cmd = "NET";
                string args = " LOCALGROUP " + groupName + " " + userName + " /ADD";
                fStartInfo(cmd, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string cmd = "WMIC";
                string args = " USERACCOUNT WHERE \"Name='" + userName + "'\" SET PasswordExpires=FALSE";
                fStartInfo(cmd, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string cmd = "ICACLS";
                string args = " " + RMSInstallLocation + "\\ /deny " + groupName + ":(OI)(CI)F";
                fStartInfo(cmd, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
            try
            {
                string cmd = "NET";
                string args = @" SHARE InterfaceFiles=" + RMSInstallLocation + "\\Interface Files /GRANT:" + groupName + ",FULL";
                fStartInfo(cmd, args);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string cmd = "ICACLS";
                string args = " " + RMSInstallLocation + "\\Interface Files /grant " + groupName + ":(OI)(CI)M /T /C /Q";
                fStartInfo(cmd, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string cmd = "NET";
                string args = @" SHARE CustomizedReports=" + RMSInstallLocation + "\\RMS\\AllReports\\CustomizedReports /GRANT:" + groupName + ",FULL";
                fStartInfo(cmd, args);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string cmd = "ICACLS";
                string args = " " + RMSInstallLocation + "\\RMS\\AllReports\\CustomizedReports /grant " + groupName + ":(OI)(CI)M /T /C /Q";
                fStartInfo(cmd, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string cmd = "NET";
                string args = " SHARE Letters=" + RMSInstallLocation + "\\RMS\\Letters /GRANT:" + groupName + ",FULL";
                fStartInfo(cmd, args);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string cmd = "ICACLS";
                string args = " " + RMSInstallLocation + "\\RMS\\Letters /grant " + groupName + ":(OI)(CI)M /T /C /Q";
                fStartInfo(cmd, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string cmd = "NET";
                string args = " SHARE RMSImages=" + RMSInstallLocation + "\\RMS\\images /GRANT:" + groupName + ",FULL";
                fStartInfo(cmd, args);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string cmd = "ICACLS";
                string args = " " + RMSInstallLocation + "\\RMS\\images /grant " + groupName + ":(OI)(CI)M /T /C /Q";
                fStartInfo(cmd, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string cmd = "NET";
                string args = " SHARE RMSLogos=" + RMSInstallLocation + "\\RMS\\logos /GRANT:" + groupName + ",FULL";
                fStartInfo(cmd, args);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string cmd = "ICACLS";
                string args = " " + RMSInstallLocation + "\\RMS\\logos /grant " + groupName + ":(OI)(CI)M /T /C /Q";
                fStartInfo(cmd, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string cmd = "NET";
                string args = " SHARE SWImages=" + RMSInstallLocation + "\\RMSStud\\WebModule-Student\\images /GRANT:" + groupName + ",FULL";
                fStartInfo(cmd, args);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string cmd = "ICACLS";
                string args = " " + RMSInstallLocation + "\\RMSStud\\WebModule-Student\\images /grant " + groupName + ":(OI)(CI)M /T /C /Q";
                fStartInfo(cmd, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string cmd = "NET";
                string args = " SHARE JudicialSupplementalReports=" + RMSInstallLocation + "\\RMS\\Judicial\\SupplementalReports /GRANT:" + groupName + ",FULL";
                fStartInfo(cmd, args);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string cmd = "ICACLS";
                string args = " " + RMSInstallLocation + "\\RMS\\Judicial\\SupplementalReports /grant " + groupName + ":(OI)(CI)M /T /C /Q";
                fStartInfo(cmd, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string cmd = "NET";
                string args = " SHARE SWAutoEmails=" + RMSInstallLocation + "\\RMSStud\\WebModule-Student\\AutoEmails /GRANT:" + groupName + ",FULL";
                fStartInfo(cmd, args);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string cmd = "ICACLS";
                string args = " " + RMSInstallLocation + "\\RMSStud\\WebModule-Student\\AutoEmails /grant " + groupName + ":(OI)(CI)M /T /C /Q";
                fStartInfo(cmd, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("The " + userName + " user and group " + groupName + " were created, the user was added to the group and the group was given access to select shares.");
            Environment.Exit(0);
        }
        public static string subUser(string s,string i)
        {
            int l = s.IndexOf(i);
            if (l > 0)
            {
                return s.Substring(0, l);
            }
            return "";

        }
        public void fStartInfo(string cmd, string args)
        {
            try
            {
                string strCMD = cmd;
                string strArg = args;
                ProcessStartInfo startInfo = new ProcessStartInfo(strCMD, strArg);
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                Process proc = new Process();
                proc.StartInfo = startInfo;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
