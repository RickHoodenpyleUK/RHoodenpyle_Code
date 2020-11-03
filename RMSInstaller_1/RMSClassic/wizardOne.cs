using System;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Management;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Management.Instrumentation;
using System.IO;
using System.Security.AccessControl;
using System.Xml.Serialization;
using TaskScheduler;
using System.Diagnostics;
using System.Net;
using Microsoft.Win32;
using COMAdmin;
using Microsoft.VisualBasic;
using System.Security;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace RMSInstaller
{
    public partial class wizardOne : Form
    {

        string rmsBuild;
        string installDrive;
        public wizardOne()
        {
            InitializeComponent();
         }


        private void SetupEnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !setupWizard.Instance.wizardExit(this.DialogResult);
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            setupWizard.Instance.wizardPrev();
        }

        private void btNext_Click(object sender, EventArgs e)
        {

            setupWizard.Instance.driveName = fixedDrives();
            setupWizard.Instance.CurrentSelections.Add("RMS will be installed in: "+setupWizard.Instance.driveName+"\\RMSInc");
            setupWizard.Instance.buildInfo = buildVersionInfo(setupWizard.Instance.driveName);
            setupWizard.Instance.CurrentSelections.Add("RMS Version for install is: " + setupWizard.Instance.buildInfo);
            if (!Directory.Exists(@"C:\Program Files (x86)\Business Objects\BusinessObjects Enterprise 11"))
            {
                MessageBox.Show("Crystal was not installed. Please install Crystal before restarting the RMS Installer.");
                Environment.Exit(0);
            }
            /*
            if (setupWizard.Instance.driveName == "")
            {
                MessageBox.Show("RMSInc doesn't exist on this server. Please copy the RMSInc folder onto this server before runnning this installer.");
                
            }
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\InetStp\", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                string pathWWWRoot = rk.GetValue("PathWWWRoot").ToString();
            }
            catch (Exception ex)
            {
                setupWizard.Instance.pathAbsentError = ex.Message;
            }
            if (setupWizard.Instance.pathAbsentError != "")
            {
                MessageBox.Show("IIS must be installed. Please install IIS before running this setup file.");
                setupWizard.Instance.wizardExit(this.DialogResult);
            }
             */
            bool Check = setupWizard.Instance.checkTextBox(wizardOne.ActiveForm);
            if (Check == false)
            {
                MessageBox.Show(setupWizard.Instance.strFormCheck);
            }
            else if (Check == true)
            {
                if (oracle.Checked)
                {
                    setupWizard.Instance.CurrentSelections.Add("Database type is: Oracle");
                    setupWizard.Instance.bOracle = true;
                }
                else
                {
                    setupWizard.Instance.CurrentSelections.Add("Database type is: MS SQL");
                    setupWizard.Instance.bMssql = true;
                }

                if (rmsBuild == "6.0.001")
                {
                    setupWizard.Instance.CurrentSelections.Add("RMS Version for install is: RMS v6.0.001");
                    setupWizard.Instance.bRmsVersion6 = true;
                }
                else
                {
                    setupWizard.Instance.CurrentSelections.Add("RMS Version for install is: RMS v5.3.009");
                    setupWizard.Instance.bRmsVersion5 = true;
                }

                if (existingYes.Checked)
                {
                    setupWizard.Instance.CurrentSelections.Add("Is there an existing database: Yes");
                    setupWizard.Instance.bExistingYes = true;
                }
                else
                {
                    setupWizard.Instance.CurrentSelections.Add("Is there an existing database: No");
                    setupWizard.Instance.bExistingNo = true;
                }

                setupWizard.Instance.CurrentSelections.Add("Database server name is: " + databaseServer.Text);
                setupWizard.Instance.strDatabaseServer = databaseServer.Text;
                setupWizard.Instance.CurrentSelections.Add("Power username is: " + oPowerName.Text);
                setupWizard.Instance.strOPowerName = oPowerName.Text;
                setupWizard.Instance.CurrentSelections.Add("Power user password is: ******");
                setupWizard.Instance.strOPowerPass = oPowerPass.Text;
                setupWizard.Instance.CurrentSelections.Add("Login database name is: " + oLoginName.Text);
                setupWizard.Instance.strOLoginName = oLoginName.Text;
                setupWizard.Instance.CurrentSelections.Add("Real database name is: " + oDataName.Text);
                setupWizard.Instance.strODataName = oDataName.Text;
                setupWizard.Instance.CurrentSelections.Add("MyRMS database name is: " + myrmsSchema.Text); 
                setupWizard.Instance.strMyrmsSchema = myrmsSchema.Text;
                setupWizard.Instance.wizardNext();
            }
        }

        public string fixedDrives()
        {
            string drive = "";
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady && d.DriveType == DriveType.Fixed && Directory.Exists(d + "RMSInc"))
                {
                    drive = d.Name;
                }
            }
            return drive;
        }
        public string buildVersionInfo(string drive)
        {
            string filePath = drive + @"RMSInc\RMS\Includes\toolTipAdmin.htc";
            string search = "tooltip2.innerHTML='<DIV>Build# ";
            string buildInfo = "";
            List<string> readLines = new List<string>();
                StreamReader streamReader = new StreamReader(filePath, Encoding.Default);
                while (!streamReader.EndOfStream)
                {
                    readLines.Add(streamReader.ReadLine());
                }
                streamReader.Close();
                streamReader.Dispose();
                
                foreach (string l in readLines)
                {
                    if (l.Contains(search))
                    {
                        buildInfo = l.Replace(search, "");
                        buildInfo = buildInfo.Replace("</DIV>'", "");
                        buildInfo = buildInfo.Trim();
                    }
                }
        return buildInfo;
        }

        public bool preReq()
        {

            // Check if RMSInc folder exists on system
            bool passed = true;
            string drive = "";


            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady && d.DriveType == DriveType.Fixed && Directory.Exists(d + "RMSInc"))
                {
                    drive = d.Name;
                }
            }

            if (drive == "")
            {
                MessageBox.Show("RMSInc doesn't exist on this server.\r\nPlease copy the RMSInc folder onto this server before runnning this installer.");
                passed = false;
                //this.Close();
            }
            else
            {
                // Check if tooltipadmin.htc file exists (used to determine which version of RMS is being installed)
                string filePath = drive + @"RMSInc\RMS\Includes\toolTipAdmin.htc";
                FileInfo rmsFile = new FileInfo(filePath);
                if (!rmsFile.Exists)
                {
                    MessageBox.Show("Cannot find: " + filePath + "\r\nPlease make sure all the RMS files are included with this installation.");
                    passed = false;
                    //this.Close();
                }
            }
            if (!Directory.Exists(@"C:\Program Files (x86)\Business Objects\BusinessObjects Enterprise 11"))
            {
                string message = "Crystal Installer has not been run.\r\nDo you want to start the installer now?";
                string caption = "Crystal Installer Search";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.No)
                {
                    passed = false;
                }
                else
                {
                    string cmd = "msiexec";
                    string args = @" /i " + drive + @"RMSInc\Tools\Crystal\Crystal-Installer11.msi";
                    fStartInfo(cmd, args);
                }
            }
            if (passed == false)
            {
                Environment.Exit(0);
                //this.Close();
            }
            return passed;
        }

        public void driveComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void wizardOne_Load(object sender, EventArgs e)
        {
            if (preReq())
            {
                installDrive = fixedDrives();
                rmsBuild = buildVersionInfo(installDrive);
                this.installationDrive.Text = installDrive;
                this.rmsVersion.Text = rmsBuild;
            }
            databaseServer.Text = "";
            oPowerName.Text = "";
            oPowerPass.Text = "";
            oLoginName.Text = "";
            oDataName.Text = "";
            myrmsSchema.Text = "";
            existingYes.Checked = false;
            existingNo.Checked = true;
            oracle.Checked = false;
            mssql.Checked = true;
        }

        private void oracle_CheckedChanged(object sender, EventArgs e)
        {
            if (oracle.Checked)
            {
                int countOracle = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node").GetSubKeyNames().Where(s => s.StartsWith("ORACLE")).Count();
                int countOracle2 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node").GetSubKeyNames().Where(s => s.StartsWith("oracle")).Count();
                if (countOracle < 1 && countOracle2 < 1)
                {
                    MessageBox.Show("Oracle 32 bit Clients is not installed on this server. Please install the Oracle 32bit client before installing");
                    Environment.Exit(0);
                    //this.Close();
                }
                else if (countOracle > 0 && countOracle2 < 1)
                {
                    string[] keys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\ORACLE").GetSubKeyNames();
                    int count = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\ORACLE").GetSubKeyNames().Where(s => s.StartsWith("KEY")).Count();
                    if (count > 1)
                    {
                        MessageBox.Show("There are " + count.ToString() + " Oracle 32 bit Clients installed on this server. Please correct this before installing");
                        Environment.Exit(0);
                        //this.Close();
                    }
                    else if (count == 1)
                    {
                        foreach (string s in keys)
                        {
                            if (s.StartsWith("KEY"))
                            {
                                setupWizard.Instance.strOracleHomes = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\ORACLE\" + s).GetValue("ORACLE_HOME").ToString();
                                RegistryKey inst_Loc = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\ORACLE\", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                                setupWizard.Instance.strInst_Loc = inst_Loc.GetValue("inst_loc").ToString();
                                setupWizard.Instance.strInst_Loc = setupWizard.Instance.strInst_Loc + @"\ContentsXML\";
                                setupWizard.Instance.strOracleDriver = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\ORACLE\" + s).GetValue("ORACLE_HOME_NAME").ToString();
                                setupWizard.Instance.CurrentSelections.Add("Oracle Home folder is: ");
                                setupWizard.Instance.CurrentSelections.Add(setupWizard.Instance.strOracleHomes);
                                setupWizard.Instance.CurrentSelections.Add("Oracle Driver is: ");
                                setupWizard.Instance.CurrentSelections.Add(setupWizard.Instance.strOracleDriver);
                                XmlDocument doc = new XmlDocument();
                                doc.Load(setupWizard.Instance.strInst_Loc + "inventory.xml");
                                XmlNode node = doc.SelectSingleNode("INVENTORY/VERSION_INFO/SAVED_WITH/text()");
                                setupWizard.Instance.strOracleVersion = (node.Value);
                            }
                        }
                    }
                }
                else if (countOracle < 1 && countOracle2 > 0)
                {
                    string[] keys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\oracle").GetSubKeyNames();
                    int count = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\oracle").GetSubKeyNames().Where(s => s.StartsWith("KEY")).Count();
                    if (count > 1)
                    {
                        MessageBox.Show("There are " + count.ToString() + " Oracle 32 bit Clients installed on this server. Please correct this before installing");
                        Environment.Exit(0);
                        //this.Close();
                    }
                    else if (count == 1)
                    {
                        foreach (string s in keys)
                        {
                            if (s.StartsWith("KEY"))
                            {
                                setupWizard.Instance.strOracleHomes = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\oracle\" + s).GetValue("ORACLE_HOME").ToString();
                                setupWizard.Instance.strOracleDriver = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\oracle\" + s).GetValue("ORACLE_HOME_NAME").ToString();
                                RegistryKey inst_Loc = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\oracle\", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                                setupWizard.Instance.strInst_Loc = inst_Loc.GetValue("inst_loc").ToString();
                                setupWizard.Instance.strInst_Loc = setupWizard.Instance.strInst_Loc + @"\ContentsXML\";
                                setupWizard.Instance.CurrentSelections.Add("Oracle Home folder is: ");
                                setupWizard.Instance.CurrentSelections.Add(setupWizard.Instance.strOracleHomes);
                                setupWizard.Instance.CurrentSelections.Add("Oracle Driver is: ");
                                setupWizard.Instance.CurrentSelections.Add(setupWizard.Instance.strOracleDriver);
                                XmlDocument doc = new XmlDocument();
                                doc.Load(setupWizard.Instance.strInst_Loc + "inventory.xml");
                                XmlNode node = doc.SelectSingleNode("INVENTORY/VERSION_INFO/SAVED_WITH/text()");
                                setupWizard.Instance.strOracleVersion = (node.Value);
                            }
                        }
                    }
                }
            }
                
       }
        public void fStartInfo(string cmd, string args)
        {
            string strCMD = cmd;
            string strArg = args;
            string result = "";
            string error = "";
            ProcessStartInfo startInfo = new ProcessStartInfo(strCMD, strArg);
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            Process proc = new Process();
            proc.StartInfo = startInfo;
            proc.Start();
            result = proc.StandardOutput.ReadToEnd();
            error = proc.StandardError.ReadToEnd();
            result = result.Replace("\r\n", " ");
            result = result.Replace("\t", " ");
        }
        private void mssql_CheckedChanged(object sender, EventArgs e)
        {
            if (mssql.Checked)
            {

            }
        }
    }
}
