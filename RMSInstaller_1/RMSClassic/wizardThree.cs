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
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Management.Instrumentation;
using System.IO;
using System.Security.AccessControl;
using System.Xml.Serialization;
using TaskScheduler;
using System.Net;
using Microsoft.Win32;
using COMAdmin;
using Microsoft.VisualBasic;
using System.Security;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Runtime.InteropServices;
using System.Reflection;
using RMSMercuryUtility;

namespace RMSInstaller
{
    public partial class wizardThree : Form
    {
        public wizardThree()
        {
            InitializeComponent();
        }

        private void SetupEnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !setupWizard.Instance.wizardExit(this.DialogResult);
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            setupWizard.Instance.fromPageName = "wizardThree";
            setupWizard.Instance.wizardPrev();
        }

        private void btInstall_Click(object sender, EventArgs e)
        {
            setupWizard.Instance.binstallStarted = true;
            this.currentSelections.Visible = false;
            this.currentInstallation.Visible = false;
            this.btBack.Visible = false;
            this.btCancel.Visible = false;
            this.btInstall.Visible = false;
            this.label1.Visible = false;
            this.progressMessage.Visible = true;
            this.progressBar1.Visible = true;
            this.label2.Visible = true;
            startInstall();
        }

        private void wizardThree_Load(object sender, EventArgs e)
        {
            
            currentSelections.Text = "";
            if (setupWizard.Instance.binstallStarted)
            {
                foreach (String S in setupWizard.Instance.CurrentSelections)
                {
                    currentInstallation.Text += S.ToString();
                    currentInstallation.Text += "\r\n";
                    //installLogWrite(S + "\r\n");
                }
            }
            else
            {
                foreach (String S in setupWizard.Instance.CurrentSelections)
                {
                    currentSelections.Text += S.ToString();
                    currentSelections.Text += "\r\n";
                    //installLogWrite(S + "\r\n");
                }
            }
            setupWizard.Instance.strRMSShare = setupWizard.Instance.driveName + setupWizard.Instance.strRMSShareDir;
            setupWizard.Instance.strSWShare = setupWizard.Instance.driveName + setupWizard.Instance.strSWShareDir;
            setupWizard.Instance.strRMSv50Share = setupWizard.Instance.driveName + setupWizard.Instance.strRMSv50ShareDir;
            setupWizard.Instance.strRMSWMDLLsShare = setupWizard.Instance.driveName + setupWizard.Instance.strRMSWMDLLsShareDir;
            setupWizard.Instance.strRMSTools = setupWizard.Instance.driveName + setupWizard.Instance.strRMSToolsDir;
            setupWizard.Instance.installFileName = setupWizard.Instance.strRMSv50Share + setupWizard.Instance.installFile;
            setupWizard.Instance.errorFileName = setupWizard.Instance.strRMSv50Share + setupWizard.Instance.errorFile;
        }

        private void startInstall()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 43;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            progressBar1.PerformStep();
            ///Set Security and Group Policy Prerequisites
            try
            {
                RegistryKey enableLUAKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", true);
                enableLUAKey.SetValue("EnableLUA", "1", RegistryValueKind.DWord);
                enableLUAKey.Close();
                RegistryKey disableForceUnloadReg = Registry.LocalMachine.OpenSubKey(@"Software\Policies\Microsoft\Windows\", true);
                disableForceUnloadReg.CreateSubKey("System");
                disableForceUnloadReg.SetValue("DisableForceUnload", "1", RegistryValueKind.DWord);
                disableForceUnloadReg.Close();
                int countPrinters = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows NT\").GetSubKeyNames().Where(s => s.StartsWith("Printers")).Count();
                if (countPrinters == 0 )
                {
                    RegistryKey pS = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                    RegistryKey printSettings = pS.CreateSubKey("Printers\\");
                    printSettings.SetValue("Immortal", "1", RegistryValueKind.DWord);
                    printSettings.SetValue("ServerThread", "1", RegistryValueKind.DWord);
                    printSettings.SetValue("PublishedPrinters", "1", RegistryValueKind.DWord);
                    printSettings.SetValue("RegisterSpoolerRemoteRpcEndPoint", "1", RegistryValueKind.DWord);
                    printSettings.SetValue("VerifyPublishedState", "60", RegistryValueKind.DWord);
                    printSettings.Close();
                }
                else
                {
                    RegistryKey printSettings = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\Printers\\", true);
                    printSettings.SetValue("Immortal", "1", RegistryValueKind.DWord);
                    printSettings.SetValue("ServerThread", "1", RegistryValueKind.DWord);
                    printSettings.SetValue("PublishedPrinters", "1", RegistryValueKind.DWord);
                    printSettings.SetValue("RegisterSpoolerRemoteRpcEndPoint", "1", RegistryValueKind.DWord);
                    printSettings.SetValue("VerifyPublishedState", "60", RegistryValueKind.DWord);
                    string strPruneDownLevel = printSettings.GetValue("PruneDownlevel").ToString();
                    if (strPruneDownLevel != "")
                    {
                        printSettings.DeleteValue("PruneDownlevel");
                    }
                    string strPruningInterval = printSettings.GetValue("PruningInterval").ToString();
                    if (strPruningInterval != "")
                    {
                        printSettings.DeleteValue("PruningInterval");
                    }
                    string strPruningPriority = printSettings.GetValue("PruningPriority").ToString();
                    if (strPruningPriority != "")
                    {
                        printSettings.DeleteValue("PruningPriority");
                    }
                    string strPruningRetries = printSettings.GetValue("PruningRetries").ToString();
                    if (strPruningRetries != "")
                    {
                        printSettings.DeleteValue("PruningRetries");
                    }
                    string strPruningRetryLog = printSettings.GetValue("PruningRetryLog").ToString();
                    if (strPruningRetryLog != "")
                    {
                        printSettings.DeleteValue("PruningRetryLog");
                    }
                    printSettings.Close();
                }
                installLogWrite("Finished adding Security and Group policies (163): ");
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(165): ");
                errorLogWrite(ex.Message + "(165): ");
            }
            ///get the Inetpub Location
            installLogWrite("Getting the Inetpub folder path(170): ");
            bgWorker(3);
            try
            {
                //int countInetpub = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\InetStp\").GetSubKeyNames().Where(s => s.StartsWith("PathWWWRoot")).Count();
                RegistryKey rkIL = Registry.LocalMachine;
                RegistryKey rk1IL = rkIL.OpenSubKey(@"SOFTWARE\Microsoft\InetStp\", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                setupWizard.Instance.strInetpubLocation = rk1IL.GetValue("PathWWWRoot").ToString();
                setupWizard.Instance.strInetpubLocation = setupWizard.Instance.strInetpubLocation.Replace(@"%systemDrive%",Path.GetPathRoot(Environment.GetEnvironmentVariable("windir")));
                setupWizard.Instance.strInetpubLocation = setupWizard.Instance.strInetpubLocation.Replace(@"\wwwroot", "");
                if (setupWizard.Instance.strInetpubLocation != "")
                {
                    setupWizard.Instance.checkPreIIS = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Object reference not set to an instance of an object"))
                {
                    installLogWrite(ex.Message + "(186): ");
                }
                else
                {
                    installLogWrite(ex.Message + "(186): ");
                    errorLogWrite(ex.Message + "(186): ");
                }
            }
            progressBar1.PerformStep();
            installLogWrite("Began installtion(199) at: ");
            if (setupWizard.Instance.checkPreIIS)
            {
                string cmdBind = setupWizard.Instance.strAPPCMD;
                string rmsCMD = " list site /xml";
                string lineRMS = "RMSBindings " + rmsCMD + "(204)";
                rmsBind(cmdBind, rmsCMD, lineRMS);
                MessageBox.Show("The RMS website will be setup to run on port: " + setupWizard.Instance.rmsBinding.ToString());
                MessageBox.Show("The SW website will be setup to run on port: " + setupWizard.Instance.swBinding.ToString());
            }
            if (setupWizard.Instance.bOracle)
            {
                if (setupWizard.Instance.strOracleVersion == "11.2.0.3.0")
                {
                    try
                    {
                        string args = @" " + setupWizard.Instance.strOracleHomes + @"\bin\OraOLEDB11.dll";
                        string cmd = setupWizard.Instance.strRegSvr;
                        string line = "Registering The Oracle Driver for the 11.2.0.3.0 issue (248)";
                        fStartInfo(cmd, args, line);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("warning"))
                        {
                            installLogWrite(ex.Message + "(220): ");
                        }
                        else
                        {
                            installLogWrite(ex.Message + "(220): ");
                            errorLogWrite(ex.Message + "(220): ");
                        }
                    }
                }
            }
            bgWorker(1);
            progressBar1.PerformStep();
            installLogWrite("Installing the roles and features(236): ");
            bgWorker(4);
            // Clear textbox and start displaying installation progress
            currentSelections.Clear();
            try
            {
                Runspace runspace = RunspaceFactory.CreateRunspace();
                runspace.Open();
                PowerShell ps = PowerShell.Create();
                ps.Runspace = runspace;
                ps.AddCommand("Get-Process").AddArgument("wmi*");
                Pipeline pipeline = runspace.CreatePipeline();
                try
                {
                    pipeline.Commands.AddScript("Import-Module ServerManager; Add-WindowsFeature Application-Server");
                    pipeline.Commands.AddScript("Get-Windowsfeature > " + setupWizard.Instance.strRMSv50Share + "\\RolesAndFeaturesBefore.txt");
                    pipeline.Commands.AddScript("Add-Windowsfeature AS-NET-Framework");
                    pipeline.Commands.AddScript("Add-Windowsfeature AS-Web-Support");
                    pipeline.Commands.AddScript("Add-Windowsfeature AS-Ent-Services");
                    pipeline.Commands.AddScript("Add-Windowsfeature AS-TCP-Port-Sharing");
                    pipeline.Commands.AddScript("Add-Windowsfeature AS-WAS-Support");
                    pipeline.Commands.AddScript("Add-Windowsfeature AS-HTTP-Activation");
                    pipeline.Commands.AddScript("Add-Windowsfeature AS-Dist-Transaction");
                    pipeline.Commands.AddScript("Add-Windowsfeature AS-Incoming-Trans");
                    pipeline.Commands.AddScript("Add-Windowsfeature File-Services");
                    pipeline.Commands.AddScript("Add-Windowsfeature FS-FileServer");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Server");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-WebServer");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Common-Http");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Static-Content");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Default-Doc");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Dir-Browsing");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Http-Errors");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Http-Redirect");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-App-Dev");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Asp-Net");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Net-Ext");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-ASP");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-ISAPI-Ext");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-ISAPI-Filter");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Health");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Http-Logging");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Log-Libraries");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Request-Monitor");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Http-Tracing");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-ODBC-Logging");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Security");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Basic-Auth");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Windows-Auth");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Digest-Auth");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Client-Auth");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Cert-Auth");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Url-Auth");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Filtering");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-IP-Security");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Performance");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Stat-Compression");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Dyn-Compression");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Mgmt-Tools");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Mgmt-Console");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Scripting-Tools");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Mgmt-Compat");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Metabase");
                    pipeline.Commands.AddScript("Add-Windowsfeature Web-Lgcy-Mgmt-Console");
                    pipeline.Commands.AddScript("Add-Windowsfeature NET-Framework");
                    pipeline.Commands.AddScript("Add-Windowsfeature NET-Framework-Core");
                    pipeline.Commands.AddScript("Add-Windowsfeature NET-Win-CFAC");
                    pipeline.Commands.AddScript("Add-Windowsfeature NET-HTTP-Activation");
                    pipeline.Commands.AddScript("Add-Windowsfeature SMTP-Server");
                    pipeline.Commands.AddScript("Add-Windowsfeature WAS");
                    pipeline.Commands.AddScript("Add-Windowsfeature WAS-Process-Model");
                    pipeline.Commands.AddScript("Add-Windowsfeature WAS-NET-Environment");
                    pipeline.Commands.AddScript("Add-Windowsfeature WAS-Config-APIs");
                    pipeline.Commands.AddScript("Get-Windowsfeature > " + setupWizard.Instance.strRMSv50Share + "\\RolesAndFeaturesAfter.txt");
                    pipeline.Invoke();
                    runspace.Close();
                    installLogWrite("Finished Installing Windows Roles and Features(312): ");
                    if (File.Exists(setupWizard.Instance.strRMSv50Share + "\\RolesAndFeaturesBefore.txt") && File.Exists(setupWizard.Instance.strRMSv50Share + "\\RolesAndFeaturesAfter.txt"))
                    {
                        string features1 = File.ReadAllText(setupWizard.Instance.strRMSv50Share + "\\RolesAndFeaturesBefore.txt");
                        string features2 = File.ReadAllText(setupWizard.Instance.strRMSv50Share + "\\RolesAndFeaturesAfter.txt");
                        installLogWrite("\r\n\r\n\r\n Roles and Features Before(317) ---------------------------------->\r\n" + features1 + "\r\n\r\n\r\n Roles and Features After ---------------------------------->\r\n" + features2);
                        File.Delete(setupWizard.Instance.strRMSv50Share + "\\RolesAndFeaturesBefore.txt");
                        File.Delete(setupWizard.Instance.strRMSv50Share + "\\RolesAndFeaturesAfter.txt");
                    }
                }
                catch (Exception ex)
                {
                    installLogWrite(ex.Message + "(322): ");
                    errorLogWrite(ex.Message + "(322): ");
                }
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + ": ");
                errorLogWrite(ex.Message + "(328): ");
            }
            ///Get inetpulocation
            try
            {
                RegistryKey rkIL = Registry.LocalMachine;
                RegistryKey rk1IL = rkIL.OpenSubKey(@"SOFTWARE\Microsoft\InetStp\", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                setupWizard.Instance.strInetpubLocation = rk1IL.GetValue("PathWWWRoot").ToString();
                setupWizard.Instance.strInetpubLocation = setupWizard.Instance.strInetpubLocation.Replace(@"%systemDrive%", Path.GetPathRoot(Environment.GetEnvironmentVariable("windir")));
                setupWizard.Instance.strInetpubLocation = setupWizard.Instance.strInetpubLocation.Replace(@"\wwwroot", "");
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(342): ");
                errorLogWrite(ex.Message + "(342): ");
            }
            ///Copying of system32 files
            progressBar1.PerformStep();
            installLogWrite("Copying the system32 files(349): ");
            bgWorker(5);
            try
            {
                string oldDir = setupWizard.Instance.strRMSTools + @"\SystemFiles\system32";
                string newDir = setupWizard.Instance.strRMSv50Share + @"\RMSDLLs\64bit\";
                DirectoryCopier.CopyDirectory(oldDir, newDir);
                installLogWrite("Finished copying the system files(356): ");
            }

            catch (Exception ex)
            {
                installLogWrite(ex.Message  + "(359): ");
                errorLogWrite(ex.Message + "(359): ");
            }
            ///Registering RMSMercuryUtility.dll
            progressBar1.PerformStep();
            installLogWrite("Registering RMSMercuryUtility.dll(366): ");
            bgWorker(6);
            try
            {
                string args = @" " + setupWizard.Instance.strRMSv50Share + @"\RMSDLLs\64bit\RMSMercuryUtility.dll /tlb /codebase";
                string cmd = setupWizard.Instance.strRegasmV4;
                string line = "Registering RMSMercuryUtility.dll(372)";
                fStartInfo(cmd, args, line);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("warning"))
                {
                    installLogWrite(ex.Message + "(375): ");
                }
                else
                {
                    installLogWrite(ex.Message + "(375): ");
                    errorLogWrite(ex.Message + "(375): ");
                }
            }
            ///Copy the INETPUB Files
            progressBar1.PerformStep();
            installLogWrite("Copying the Inetpub Files(389): ");
            bgWorker(7);
            try
            {
                progressMessage.Text = "Copying the Inetpub folders";
                string oldDir = setupWizard.Instance.strRMSTools + @"\Inetpub-AdminScripts";
                string newDir = setupWizard.Instance.strInetpubLocation + @"\AdminScripts";
                DirectoryCopier.CopyDirectory(oldDir, newDir);
                installLogWrite("Finished copying the Inetpub-AdminScripts(397): ");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("already exists"))
                {
                    installLogWrite(ex.Message + "(399): ");
                }
                else
                {
                    installLogWrite(ex.Message + "(399): ");
                    errorLogWrite(ex.Message + "(399): ");
                }

            }
            ///Copy the sysWoW64 files
            progressBar1.PerformStep();
            installLogWrite("Copying the sysWoW64 files(414): ");
            bgWorker(8);
            try
            {
                string oldDir = setupWizard.Instance.strRMSTools + @"\SystemFiles\sysWOW64";
                string newDir = Environment.GetEnvironmentVariable("windir") + @"\sysWOW64";
                DirectoryCopier.CopyDirectory(oldDir, newDir);
                installLogWrite("Finished copying the syswow64 files(421): ");
            }

            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(424): ");
                errorLogWrite(ex.Message + "(424): ");
            }
            ///Copy the Copy_files_to_dataset_file to the RMSXML\Dataset folder
            progressBar1.PerformStep();
            installLogWrite(@"RMSXML\Copying the Copy_files_to_dataset_file to the RMSXML\" + setupWizard.Instance.strODataName + " folder(431): ");
            bgWorker(9);
            try
            {
                System.IO.Directory.CreateDirectory(setupWizard.Instance.strRMSShare + @"\RMSXML\" + setupWizard.Instance.strODataName);
                string oldDir = setupWizard.Instance.strRMSShare + @"\RMSXML\Copy_files_to_dataset_file";
                string newDir = setupWizard.Instance.strRMSShare + @"\RMSXML\" + setupWizard.Instance.strODataName;
                DirectoryCopier.CopyDirectory(oldDir, newDir);
                installLogWrite(@"Finished copying the RMSXML\Copy_files_to_dataset_file folder to RMSXML\" + setupWizard.Instance.strODataName + "(439): ");
            }

            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(442): ");
                errorLogWrite(ex.Message + "(442): ");
            }
            ///Copy the Copy_files_to_dataset_file to the RMSXML\Dataset folder    
            installLogWrite(@"WebConfigXML\BaseXML to the RMSXML\" + setupWizard.Instance.strODataName + " folder(448): ");
            progressBar1.PerformStep();
            bgWorker(10);
            try
            {
                System.IO.Directory.CreateDirectory(setupWizard.Instance.strRMSShare + @"\WebConfigXML\" + setupWizard.Instance.strODataName);
                string oldDir = setupWizard.Instance.strRMSShare + @"\WebConfigXML\BaseXML";
                string newDir = setupWizard.Instance.strRMSShare + @"\WebConfigXML\" + setupWizard.Instance.strODataName;
                DirectoryCopier.CopyDirectory(oldDir, newDir);
                installLogWrite(@"Finished copying the \WebConfigXML\BaseXML folder to RMSXML\" + setupWizard.Instance.strODataName + "(457): ");
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(459): ");
                errorLogWrite(ex.Message + "(459): ");
            }
            ///Create the RMS Share 
            progressBar1.PerformStep();
            installLogWrite(@"Create the RMS Share(466): ");
            bgWorker(11); 
            try
            {
                string cmd = "NET";
                string args = @" SHARE " + setupWizard.Instance.strRMSName + "=" + setupWizard.Instance.strRMSShare + " /grant:" + setupWizard.Instance.strRMSIISUser + ",FULL /grant:" + setupWizard.Instance.strRMSCOMUser + ",FULL /grant:Everyone,READ";
                string line = "Create the RMS Share(472)";
                fStartInfo(cmd, args, line);
                
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message  + "(476): ");
                errorLogWrite(ex.Message + "(476): ");
            }
            ///Create the RMSStud Share
            progressBar1.PerformStep();
            installLogWrite(@"Create the RMSStud Share(483): ");
            bgWorker(12);
            try
            {
                string cmd = "NET";
                string args = @" SHARE " + setupWizard.Instance.strSWName + "=" + setupWizard.Instance.strSWShare + " /grant:" + setupWizard.Instance.strRMSIISUser + ",FULL /grant:" + setupWizard.Instance.strRMSCOMUser + ",FULL /grant:Everyone,READ";
                string line = "Create the RMSStud Share(489)";
                fStartInfo(cmd, args, line);
                
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message  + "(493): ");
                errorLogWrite(ex.Message + "(493): ");
            }
            ///Create RMSv50 Share    
            progressBar1.PerformStep();
            installLogWrite(@"Create the RMSv5.0 Share(500): ");
            bgWorker(13);
            try
            {
                string cmd = "NET";
                string args = @" SHARE " + setupWizard.Instance.strRMSv50Name + "=" + setupWizard.Instance.strRMSv50Share + " /grant:" + setupWizard.Instance.strRMSIISUser + ",FULL /grant:" + setupWizard.Instance.strRMSCOMUser + ",FULL /grant:Everyone,READ";
                string line = "Create the RMSv5.0 Share(506)";
                fStartInfo(cmd, args, line);
                
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message  + "(510): ");
                errorLogWrite(ex.Message + "(510): ");
            }
            ///Create RMSWMDLLs Share
            progressBar1.PerformStep();
            installLogWrite(@"Create the RMSWMDLLs Share(517): ");
            bgWorker(14); 
            try
            {
                string cmd = "NET";
                string args = @" SHARE " + setupWizard.Instance.strRMSWMDLLsName + "=" + setupWizard.Instance.strRMSWMDLLsShare + " /grant:" + setupWizard.Instance.strRMSIISUser + ",FULL /grant:" + setupWizard.Instance.strRMSCOMUser + ",FULL /grant:Everyone,READ";
                string line = "Create the RMSWMDLLs Share(523)";
                fStartInfo(cmd, args, line);
                
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(527): ");
                errorLogWrite(ex.Message + "(527): ");
            }
            ///RMS File Permissions RMS Folder Read and Execute for RMSIIS
            progressBar1.PerformStep();
            installLogWrite(@"Setup RMS Folder Read and Execute for RMSIIS(534): ");
            bgWorker(15);
            try
            {
                string cmd = "ICACLS";
                string args = @" " + setupWizard.Instance.strRMSShare + " /grant " + setupWizard.Instance.strRMSIISUser + ":(OI)(CI)RX /T /C /Q";
                string line = "Setup RMS Folder Read and Execute for RMSIIS(540)";
                fStartInfo(cmd, args, line);
                
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(544): ");
                errorLogWrite(ex.Message + "(544): ");
            }
            ///RMS Folder FULL for RMSCOM    
            progressBar1.PerformStep();
            installLogWrite(@"Setup RMS Folder Full for RMSCOM(551): ");
            bgWorker(16);
            try
            {
                string cmd = "ICACLS";
                string args = @" " + setupWizard.Instance.strRMSShare + " /grant " + setupWizard.Instance.strRMSCOMUser + ":(OI)(CI)F /T /C /Q";
                string line = "Setup RMS Folder Full for RMSCOM(557)";
                fStartInfo(cmd, args, line);
                
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(561): ");
                errorLogWrite(ex.Message + "(561): ");
            }
            ///RMS Folder FULL for RMSCOM    
            progressBar1.PerformStep();
            installLogWrite(@"Setup RMS Folder Full for RMSCOM(568): ");
            bgWorker(16);
            try
            {
                string cmd = "ICACLS";
                string args = @" " + setupWizard.Instance.strDotNetTempPath + " /grant " + setupWizard.Instance.strRMSIISUser + ":(OI)(CI)M /T /C /Q";
                string line = "Setup RMSIIS to have write permissions to the ASPDOTNet temp folder(574)";
                fStartInfo(cmd, args, line);
                
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(578): ");
                errorLogWrite(ex.Message + "(578): ");
            }
            
            ///RMSStud File Permissions RMSStud Folder Read and Execute for RMSIIS
            progressBar1.PerformStep();
            installLogWrite(@"Setup RMSStud Folder Read and Execute for RMSIIS(586): ");
            bgWorker(17); 
            try
            {
                string cmd = "ICACLS";
                string args = @" " + setupWizard.Instance.strSWShare + " /grant " + setupWizard.Instance.strRMSIISUser + ":(OI)(CI)RX /T /C /Q";
                string line = "Setup RMSStud Folder Read and Execute for RMSIIS(592)";
                fStartInfo(cmd, args, line);
                
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(596): ");
                errorLogWrite(ex.Message + "(596): ");
            }
            ///RMSStud Folder FULL for RMSCOM
            progressBar1.PerformStep();
            installLogWrite(@"Setup RMSStud Folder FULL for RMSCOM(603): ");
            bgWorker(18); 
            try
            {
                string cmd = "ICACLS";
                string args = @" " + setupWizard.Instance.strSWShare + " /grant " + setupWizard.Instance.strRMSCOMUser + ":(OI)(CI)F /T /C /Q";
                string line = "Setup RMSStud Folder FULL for RMSCOM(609)";
                fStartInfo(cmd, args, line);
                
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(613): ");
                errorLogWrite(ex.Message + "(613): ");
            }
            ///RMSv50 File Permissions RMSv50 Folder Read and Execute for RMSIIS
            progressBar1.PerformStep();
            installLogWrite(@"Setup RMSv50 Folder Read and Execute for RMSIIS(620): ");
            bgWorker(19);
            try
            {
                string cmd = "ICACLS";
                string args = @" " + setupWizard.Instance.strRMSv50Share + " /grant " + setupWizard.Instance.strRMSIISUser + ":(OI)(CI)RX /T /C /Q";
                string line = "Setup RMSv50 Folder Read and Execute for RMSIIS(626)";
                fStartInfo(cmd, args, line);
                
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(630): ");
                errorLogWrite(ex.Message + "(630): ");
            }
            ///RMSv50 Folder FULL for RMSCOM
            progressBar1.PerformStep();
            installLogWrite(@"Setup RMSv50 Folder FULL for RMSCOM(637): ");
            bgWorker(20);
            try
            {
                string cmd = "ICACLS";
                string args = @" " + setupWizard.Instance.strRMSv50Share + " /grant " + setupWizard.Instance.strRMSCOMUser + ":(OI)(CI)F /T /C /Q";
                string line = "Setup RMSv50 Folder FULL for RMSCOM(643)";
                fStartInfo(cmd, args, line);
                
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(647): ");
                errorLogWrite(ex.Message + "(647): ");
            }
            ///RMSWMDLLs File Permissions RMSWMDLLs Folder Read and Execute for RMSIIS
            progressBar1.PerformStep();
            installLogWrite(@"Setup RMSWMDLLs Folder Read and Execute for RMSIIS(654): ");
            bgWorker(21);
            try
            {
                string cmd = "ICACLS";
                string args = @" " + setupWizard.Instance.strRMSWMDLLsShare + " /grant " + setupWizard.Instance.strRMSIISUser + ":(OI)(CI)RX /T /C /Q";
                string line = "Setup RMSWMDLLs Folder Read and Execute for RMSIIS(660)";
                fStartInfo(cmd, args, line);
                
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(664): ");
                errorLogWrite(ex.Message + "(664): ");
            }
            ///RMSWMDLLs Folder FULL for RMSCOM
            progressBar1.PerformStep();
            installLogWrite(@"Setup RMSWMDLLs Folder FULL for RMSCOM(671): ");
            bgWorker(22);
            try
            {
                string cmd = "ICACLS";
                string args = @" " + setupWizard.Instance.strRMSWMDLLsShare + " /grant " + setupWizard.Instance.strRMSCOMUser + ":(OI)(CI)F /T /C /Q";
                string line = "Setup RMSWMDLLs Folder FULL for RMSCOM(677)";
                fStartInfo(cmd, args, line);
                
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(681): ");
                errorLogWrite(ex.Message + "(681): ");
            }
            ///Inetpub File Permissions Inetpub File Permissions
            progressBar1.PerformStep();
            installLogWrite(@"Setup Inetpub Folder Permissions for RMSIIS(688): ");
            bgWorker(23);
            try
            {
                string cmd = "ICACLS";
                string args = @" " + setupWizard.Instance.strInetpubLocation + @"\mailroot /grant " + setupWizard.Instance.strRMSIISUser + ":(OI)(CI)M /T /C /Q";
                string line = "Setup Inetpub Folder Permissions for RMSIIS(694)";
                fStartInfo(cmd, args, line);
                
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(698): ");
                errorLogWrite(ex.Message + "(698): ");
            }
            ///Inetpub Folder FULL for RMSCOM
            installLogWrite(@"Setup Inetpub Folder Permissions for RMSCOM(704): ");
            try
            {
                string cmd = "ICACLS";
                string args = @" " + setupWizard.Instance.strInetpubLocation + @"\mailroot /grant " + setupWizard.Instance.strRMSCOMUser + ":(OI)(CI)M /T /C /Q";
                string line = "Setup Inetpub Folder Permissions for RMSCOM(709)";
                fStartInfo(cmd, args, line);
                
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(713): ");
                errorLogWrite(ex.Message + "(713): ");
            }
            ///Inetpub Folder Modify for RMSCOM
            installLogWrite(@"Setup Inetpub Folder Permissions for builtin\iis_iusrs(719): ");
            try
            {
                string cmd = "ICACLS";
                string args = @" " + setupWizard.Instance.strInetpubLocation + @"\mailroot /grant builtin\\iis_iusrs:(OI)(CI)M /T /C /Q";
                string line = @"Setup Inetpub Folder Permissions for builtin\iis_iusrs(724)";
                fStartInfo(cmd, args, line);
                
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(728): ");
                errorLogWrite(ex.Message + "(728): ");
            }
            ///Add Modify Permissions to HTC and XML files.
            ///RMS Folders Needing Modify for RMSIIS
            progressBar1.PerformStep();
            installLogWrite(@"Setup Modify permissions to htc and xml files for RMSIIS(736): ");
            bgWorker(24);
            List<string> modPermsDir = new List<string>();
            modPermsDir.Add(setupWizard.Instance.strRMSShare + @"\RMSCONFIGXML");
            modPermsDir.Add(setupWizard.Instance.strRMSShare + @"\RMSErrorDump");
            modPermsDir.Add(setupWizard.Instance.strRMSShare + @"\RMSUsers");
            modPermsDir.Add(setupWizard.Instance.strRMSShare + @"\RMSXML");
            modPermsDir.Add(setupWizard.Instance.strRMSShare + @"\WebConfigXML");
            //SW Folders Needing Modify for RMSIIS
            modPermsDir.Add(setupWizard.Instance.strSWShare + @"\WebModule-Student\Reusable");
            modPermsDir.Add(setupWizard.Instance.strSWShare + @"\WebModule-Student\RMSErrorDump");
            modPermsDir.Add(setupWizard.Instance.strSWShare + @"\WebModule-Student\RMSUsers");
            modPermsDir.Add(setupWizard.Instance.strSWShare + @"\WebModule-Student\RMSXML");
            List<string> modPermsFile = new List<string>();
            modPermsFile.Add(setupWizard.Instance.strRMSShare + @"\*.htc");
            modPermsFile.Add(setupWizard.Instance.strRMSShare + @"\Includes\*.htc");
            modPermsFile.Add(setupWizard.Instance.strRMSShare + @"\Accounts\Includes\*.xml");
            modPermsFile.Add(setupWizard.Instance.strRMSShare + @"\Admin\Includes\*.xml");
            modPermsFile.Add(setupWizard.Instance.strRMSShare + @"\Application\Includes\*.xml");
            modPermsFile.Add(setupWizard.Instance.strRMSShare + @"\Conference\Includes\*.xml");
            modPermsFile.Add(setupWizard.Instance.strRMSShare + @"\Incidents\Includes\*.xml");
            modPermsFile.Add(setupWizard.Instance.strRMSShare + @"\Interfaces\Includes\*.xml");
            modPermsFile.Add(setupWizard.Instance.strRMSShare + @"\Judicial\Includes\*.xml");
            modPermsFile.Add(setupWizard.Instance.strRMSShare + @"\Mailmerge\Includes\*.xml");
            modPermsFile.Add(setupWizard.Instance.strRMSShare + @"\Profiles\Includes\*.xml");
            modPermsFile.Add(setupWizard.Instance.strRMSShare + @"\Properties\Includes\*.xml");
            modPermsFile.Add(setupWizard.Instance.strRMSShare + @"\Property_Apps\Includes\*.xml");
            modPermsFile.Add(setupWizard.Instance.strRMSShare + @"\Reusable\Includes\*.xml");
            modPermsFile.Add(setupWizard.Instance.strRMSShare + @"\Rooms\Includes\*.xml");

            foreach (string element in modPermsDir)
            {
                try
                {
                    string cmd = "ICACLS";
                    string args = @" " + element + " /grant " + setupWizard.Instance.strRMSIISUser + ":(OI)(CI)M /T /C /Q";
                    string line = "Setup Modify permissions to " + element + " for " + setupWizard.Instance.strRMSIISUser + "(772)";
                    fStartInfo(cmd, args, line);
                }
                catch (Exception ex)
                {
                    installLogWrite(ex.Message + "(775): ");
                    errorLogWrite(ex.Message + "(775): ");
                }
            }
            foreach (string element in modPermsFile)
            {
                try
                {
                    string cmd = "ICACLS";
                    string args = @" " + element + " /grant " + setupWizard.Instance.strRMSIISUser + ":M /C /Q";
                    string line = "Setup Modify permissions to " + element + " for " + setupWizard.Instance.strRMSIISUser + "(787)";
                    fStartInfo(cmd, args, line);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("The system cannot find the file specified."))
                    {
                        installLogWrite(ex.Message + "(790): ");
                    }
                    else
                    {
                        installLogWrite(ex.Message + "(790): ");
                        errorLogWrite(ex.Message + "(790): ");
                    }
                    
                }
            }
            
            ///Register the DLLs
            progressBar1.PerformStep();
            installLogWrite(@"Register all DLLs(807): ");
            bgWorker(25);
            try
            {
                string[] rmsv50DLLs = Directory.GetFiles(setupWizard.Instance.strRMSv50Share + @"\RMSDLLs", "*.dll");
                string[] rmswmDLLs = Directory.GetFiles(setupWizard.Instance.strRMSWMDLLsShare + @"\", "*.dll");
                List<string> sysFilesList = new List<string>();
                sysFilesList.Add(@"\https62.ocx");
                sysFilesList.Add(@"\ipports62.ocx");
                sysFilesList.Add(@"\ldaps62.ocx");
                sysFilesList.Add(@"\ftps62.ocx");
                sysFilesList.Add(@"\XpdfPrint.dll");
                sysFilesList.Add(@"\cdosys.dll");
                sysFilesList.Add(@"\comdlg32.ocx");
                sysFilesList.Add(@"\mscal.ocx");
                sysFilesList.Add(@"\tabctl32.ocx");
                sysFilesList.Add(@"\MSDATGRD.OCX");
                foreach (string element in rmsv50DLLs)
                {
                    string cmd = setupWizard.Instance.strRegSvr;
                    string args = @" /s " + element;
                    string line = "DLLRegister RMSv50(828)";
                    fStartInfo(cmd, args, line);
                    
                }
                foreach (string element in rmswmDLLs)
                {
                    string cmd = setupWizard.Instance.strRegSvr;
                    string args = @" /s " + element;
                    string line = "DLLRegister RMSWMDLLs(836)";
                    fStartInfo(cmd, args, line);
                    
                }
                foreach (string element in sysFilesList)
                {
                    string cmd = setupWizard.Instance.strRegSvr;
                    string args = @" /s " + Environment.GetEnvironmentVariable("windir") + @"\sysWOW64" + element;
                    string line = "DLLRegister SysWOW64(844)";
                    fStartInfo(cmd, args, line);
                    
                }
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(849): ");
                errorLogWrite(ex.Message + "(849): ");
            }

            ///Setting Launch and Activation Permissions on COM+ Services
            progressBar1.PerformStep();
            installLogWrite("Setting Launch and Activation Permissions on COM+ Services(857): ");
            bgWorker(26);
            try
            {
                List<string> dcomList = new List<string>();
                dcomList.Add(@" -ma set " + setupWizard.Instance.strRMSIISUser + " permit level:l,r");
                dcomList.Add(@" -ml set " + setupWizard.Instance.strRMSIISUser + " permit level:l,r,ll,la,rl,ra");
                dcomList.Add(@" -da set " + setupWizard.Instance.strRMSIISUser + " permit level:l,r");
                dcomList.Add(@" -dl set " + setupWizard.Instance.strRMSIISUser + " permit level:l,r,ll,la,rl,ra");
                dcomList.Add(@" -ma set " + setupWizard.Instance.strRMSCOMUser + " permit level:l,r");
                dcomList.Add(@" -ml set " + setupWizard.Instance.strRMSCOMUser + " permit level:l,r,ll,la,rl,ra");
                dcomList.Add(@" -da set " + setupWizard.Instance.strRMSCOMUser + " permit level:l,r");
                dcomList.Add(@" -dl set " + setupWizard.Instance.strRMSCOMUser + " permit level:l,r,ll,la,rl,ra");
                foreach (string element in dcomList)
                {
                    string cmd = setupWizard.Instance.strRMSTools + @"\dcomperm.exe";
                    string args = element;
                    string line = "Setting Launch and Activation Permissions on COM+ Services(874)";
                    fStartInfo(cmd, args, line);
                    
                }
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(879): ");
                errorLogWrite(ex.Message + "(879): ");
            }
            ///Adjusting DTC Security
            progressBar1.PerformStep();
            installLogWrite("Adjusting DTC Security(886): ");
            bgWorker(27);
            try
            {
                string rootKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\MSDTC\Security\";
                List<string> keyList = new List<string>();
                keyList.Add("LuTransactions");
                keyList.Add("NetworkDtcAccess");
                keyList.Add("NetworkDtcAccessAdmin");
                keyList.Add("NetworkDtcAccessClients");
                keyList.Add("NetworkDtcAccessInbound");
                keyList.Add("NetworkDtcAccessOutbound");
                keyList.Add("NetworkDtcAccessTransactions");
                keyList.Add("XaTransactions");
                foreach (string element in keyList)
                {
                    try
                    {
                        Registry.SetValue(rootKey, element, 1);
                    }
                    catch (Exception ex)
                    {
                        installLogWrite(ex.Message + "(906): ");
                        errorLogWrite(ex.Message + "(906): ");
                    }
                }
                Registry.SetValue(rootKey.Replace(@"Security\", ""), "AllowOnlySecureRpcCalls", 0);
                Registry.SetValue(rootKey.Replace(@"Security\", ""), "FallbackToUnsecureRPCIfNecessary", 0);
                Registry.SetValue(rootKey.Replace(@"Security\", ""), "TurnOffRpcSecurity", 1);
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(916): ");
                errorLogWrite(ex.Message + "(916): ");
            }
            ///Building the COM+ Object VBScript
            progressBar1.PerformStep();
            installLogWrite("Building the COM+ Object VBScript(923): ");
            bgWorker(28);
            string lines1 = "Dim catalog\r\nDim applications\r\nDim application\r\nDim application2\r\nSet catalog = CreateObject(\"COMAdmin.COMAdminCatalog\")\r\nSet applications = catalog.GetCollection(\"Applications\")\r\nCall applications.Populate\r\nSet application = applications.Add()\r\napplication.Value(\"ID\") = \"{da2d72e3-f402-4f98-a415-66d21dafc0a9}\"\r\napplication.Value(\"Name\") = \"RMS\"\r\napplication.Value(\"Activation\") = 1\r\napplication.Value(\"ApplicationAccessChecksEnabled\") = 0\r\napplication.Value(\"Description\") = \"RMS\"\r\napplication.Value(\"Identity\") = \"" + setupWizard.Instance.strRMSCOMUser + "\"\r\napplication.Value(\"Password\") = \"" + setupWizard.Instance.strRMSCOMPass + "\"\r\napplication.Value(\"RunForever\") = True\r\nCall applications.SaveChanges";
            string[] rmsv50DLLs2 = Directory.GetFiles(setupWizard.Instance.strRMSv50Share + @"\RMSDLLs", "*.dll");
            List<string> rmsv50DLLs3 = new List<string>();
            foreach (string element in rmsv50DLLs2)
            {
                rmsv50DLLs3.Add("\r\ncatalog.InstallComponent \"RMS\", \"" + element + "\",\"\",\"\"");
            }
            string lines2 = "\r\nDim roles\r\nSet roles = applications.GetCollection(\"Roles\", \"{da2d72e3-f402-4f98-a415-66d21dafc0a9}\")\r\nDim role\r\nSet role = roles.Add\r\nrole.Value(\"Name\") = \"CreatorOwner\"\r\nroles.SaveChanges\r\nDim users\r\nSet users = roles.GetCollection(\"UsersInRole\", role.Key)\r\nDim user\r\nSet user = users.Add\r\nuser.Value(\"User\") = \"" + setupWizard.Instance.strRMSCOMUser + "\"\r\nusers.SaveChanges\r\nSet application = Nothing\r\n";
            string lines3 = "Set application = applications.Add()\r\napplication.Value(\"ID\") = \"{da2d72e3-f402-4f98-a415-76d21dafc0a9}\"\r\napplication.Value(\"Name\") = \"WM\"\r\napplication.Value(\"Activation\") = 1\r\napplication.Value(\"ApplicationAccessChecksEnabled\") = 0\r\napplication.Value(\"Description\") = \"WM\"\r\napplication.Value(\"Identity\") = \"" + setupWizard.Instance.strRMSCOMUser + "\"\r\napplication.Value(\"Password\") = \"" + setupWizard.Instance.strRMSCOMPass + "\"\r\napplication.Value(\"RunForever\") = True\r\nCall applications.SaveChanges";
            string[] rmsWMDLLs2 = Directory.GetFiles(setupWizard.Instance.strRMSWMDLLsShare, "*.dll");
            List<string> rmsWMDLLs3 = new List<string>();
            foreach (string element in rmsWMDLLs2)
            {
                rmsWMDLLs3.Add("\r\ncatalog.InstallComponent \"WM\", \"" + element + "\",\"\",\"\"");
            }
            string lines4 = "\r\nSet roles = applications.GetCollection(\"Roles\", \"{da2d72e3-f402-4f98-a415-76d21dafc0a9}\")\r\nSet role = roles.Add\r\nrole.Value(\"Name\") = \"CreatorOwner\"\r\nroles.SaveChanges\r\nSet users = roles.GetCollection(\"UsersInRole\", role.Key)\r\nSet user = users.Add\r\nuser.Value(\"User\") = \"" + setupWizard.Instance.strRMSCOMUser + "\"\r\nusers.SaveChanges\r\nSet comps = applications.GetCollection(\"Components\", \"{da2d72e3-f402-4f98-a415-66d21dafc0a9}\")\r\ncomps.Populate\r\nFor Each comp In comps\r\ncomp.Value(\"IISIntrinsics\") = true\r\ncomps.SaveChanges\r\nNext\r\nSet comps = applications.GetCollection(\"Components\", \"{da2d72e3-f402-4f98-a415-76d21dafc0a9}\")\r\ncomps.Populate\r\nFor Each comp In comps\r\ncomp.Value(\"IISIntrinsics\") = true\r\ncomps.SaveChanges\r\nNext\r\nSet comps = applications.GetCollection(\"Components\", \"{da2d72e3-f402-4f98-a415-66d21dafc0a9}\")\r\ncomps.Populate\r\nFor Each comp In comps\r\nif comp.key = \"{F0F9F62F-5634-41C2-8636-95929AE23384}\" then\r\ncomp.Value(\"MustRunInDefaultContext\") = True\r\ncomps.SaveChanges\r\nExit For\r\nEnd If\r\nNext";
            string lines = lines1 + string.Join(String.Empty, rmsv50DLLs3.ToArray()) + lines2 + lines3 + string.Join(String.Empty, rmsWMDLLs3.ToArray()) + lines4;
            try
            {
                string args = setupWizard.Instance.strRMSv50Share + @"\coms.vbs";
                System.IO.StreamWriter file = new System.IO.StreamWriter(args);
                file.WriteLine(lines);
                file.Close();
                string cmd = "CSCRIPT";
                string line = "Building the COM+ Object VBScript(949)";
                fStartInfo(cmd, args, line);
                
                File.Delete(args);
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(954): ");
                errorLogWrite(ex.Message + "(954): ");
            }
            ///Encrypt DB Username and Password
            progressBar1.PerformStep();
            installLogWrite("Encrypt DB Username and Password(961): ");
            bgWorker(29);
            try
            {
                RMSMercuryUtility.RMSEncryption encryptor = new RMSEncryption();
                setupWizard.Instance.strEncryptedUser = encryptor.encrypt(setupWizard.Instance.strOPowerName);
                setupWizard.Instance.strEncryptedPass = encryptor.encrypt(setupWizard.Instance.strOPowerPass);
                setupWizard.Instance.strRMSIISEncPass = encryptor.encrypt(setupWizard.Instance.strRMSIISPass);
                setupWizard.Instance.strRMSCOMEncPass = encryptor.encrypt(setupWizard.Instance.strRMSCOMPass);
                installLogWrite("Encrypted DB Username(970): " + setupWizard.Instance.strEncryptedUser  + " - ");
                installLogWrite("Encrypted DB Password(971): " + setupWizard.Instance.strEncryptedPass + " - ");
                installLogWrite("Encrypted RMSIIS Password(972): " + setupWizard.Instance.strRMSIISEncPass + " - ");
                installLogWrite("Encrypted RMSCOM Password(973): " + setupWizard.Instance.strRMSCOMEncPass + " - ");
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(975): ");
                errorLogWrite(ex.Message + "(975): ");
            }
            ///Set BackConnectionHostNames, OptionalNames, and DisableStrictNameChecking in Registry
            progressBar1.PerformStep();
            installLogWrite("Set BackConnectionHostNames, OptionalNames, and DisableStrictNameChecking in Registry(982): ");
            bgWorker(30);
            try
            {
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk1 = rk.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Lsa\\MSV1_0\\", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                RegistryKey rk2 = rk.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\lanmanserver\\parameters", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                try
                {
                    rk1.SetValue("BackConnectionHostNames", new string[] { setupWizard.Instance.serverName + "." + setupWizard.Instance.domainName2 }, RegistryValueKind.MultiString);
                    rk2.SetValue("OptionalNames", new string[] { setupWizard.Instance.serverName + "." + setupWizard.Instance.domainName2 }, RegistryValueKind.MultiString);
                    rk2.SetValue("DisableStrictNameChecking", 1, RegistryValueKind.DWord);
                }
                catch (Exception ex)
                {
                    installLogWrite(ex.Message + "(995): ");
                    errorLogWrite(ex.Message + "(995): ");
                }
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(1001): ");
                errorLogWrite(ex.Message + "(1001): ");
            }
            ///Registering PayFlowDotNet file
            progressBar1.PerformStep();
            installLogWrite("Registering PayFlowDotNet file(1008): ");
            bgWorker(31);
            try
            {
                string cmd = setupWizard.Instance.strRegasmV2;
                string args = @" " + setupWizard.Instance.strPayFlowDotNet;
                string line = "Registering PayFlowDotNet file(1014)";
                fStartInfo(cmd, args, line);
                
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(1018): ");
                errorLogWrite(ex.Message + "(1018): ");
            }
            ///Add Metabase Permissions
            progressBar1.PerformStep();
            installLogWrite("Add Metabase Permissions(1025): ");
            bgWorker(32);
            try
            {
                List<string> metaUsersList = new List<string>();
                metaUsersList.Add(setupWizard.Instance.strRMSIISUser);
                metaUsersList.Add(setupWizard.Instance.strRMSCOMUser);
                metaUsersList.Add(@"Builtin\IIS_IUSRS");
                foreach (string element in metaUsersList)
                {
                    string cmd = "CSCRIPT";
                    string args = " /s " + setupWizard.Instance.strInetpubLocation + @"\adminscripts\adadd.vbs " + element;
                    string line = "Add Metabase Permissions(1037)";
                    fStartInfo(cmd, args, line);
                    
                }
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(1042): ");
                errorLogWrite(ex.Message + "(1042): ");
            }
            ///Set Asp Script errors to be sent to the browser
            progressBar1.PerformStep();
            installLogWrite("Set Asp Script errors to be sent to the browser(1049): ");
            bgWorker(33);
            try
            {
                string cmd = "CSCRIPT";
                string args = " /s " + setupWizard.Instance.strInetpubLocation + @"\adminscripts\adsutil.vbs set w3svc/AspScriptErrorSentToBrowser true";
                string line = "Set Asp Script errors to be sent to the browser(1055)";
                fStartInfo(cmd, args, line);
                
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(1059): ");
                errorLogWrite(ex.Message + "(1059): ");
            }
            ///ASP Max Request Entity Allowed
            progressBar1.PerformStep();
            installLogWrite("Set ASP Max Request Entity Allowed(1066): ");
            bgWorker(34);
            try
            {
                string cmd = setupWizard.Instance.strAPPCMD;
                string args = @" set config -section:asp -limits.maxRequestEntityAllowed:1073741824";
                string line = "Set ASP Max Request Entity Allowed(1072)";
                fStartInfo(cmd, args, line);
                
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(1076): ");
                errorLogWrite(ex.Message + "(1076): ");
            }
            ///Create RMS and RMSStud App Pools
            progressBar1.PerformStep();
            installLogWrite("Create RMS and RMSStud App Pools(1083): ");
            bgWorker(35);
            try
            {
                string cmd = setupWizard.Instance.strAPPCMD;
                List<string> appPoolArgs = new List<string>();
                appPoolArgs.Add(@" add apppool /name:" + setupWizard.Instance.strRMSName + @" /managedRuntimeVersion: /managedPipelineMode:Classic /autoStart:true /enable32BitAppOnWin64:true /processModel.identityType:NetworkService /failure.rapidFailProtection:false");
                appPoolArgs.Add(@" add apppool /name:" + setupWizard.Instance.strSWName + @" /managedRuntimeVersion: /managedPipelineMode:Classic /autoStart:true /enable32BitAppOnWin64:true /processModel.identityType:NetworkService /failure.rapidFailProtection:false");
                if (setupWizard.Instance.checkAS)
                {
                    appPoolArgs.Add(@" add apppool /name:AlertService /managedRuntimeVersion:v2.0 /managedPipelineMode:Integrated /autoStart:true /enable32BitAppOnWin64:true /processModel.identityType:NetworkService /failure.rapidFailProtection:false");
                }
                if (setupWizard.Instance.checkASW)
                {
                    appPoolArgs.Add(@" add apppool /name:AccessibleStudentWeb /managedRuntimeVersion:v2.0 /managedPipelineMode:Integrated /autoStart:true /enable32BitAppOnWin64:true /processModel.identityType:NetworkService /failure.rapidFailProtection:false");
                }
                if (setupWizard.Instance.checkPG)
                {
                    appPoolArgs.Add(@" add apppool /name:PaymentProcessing /managedRuntimeVersion:v2.0 /managedPipelineMode:Integrated /autoStart:true /enable32BitAppOnWin64:true /processModel.identityType:NetworkService /failure.rapidFailProtection:false");
                }
                if (setupWizard.Instance.checkWS)
                {
                    appPoolArgs.Add(@" add apppool /name:RMSWebServices /managedRuntimeVersion:v2.0 /managedPipelineMode:Integrated /autoStart:true /enable32BitAppOnWin64:true /processModel.identityType:NetworkService /failure.rapidFailProtection:false");
                }
                foreach (string element in appPoolArgs)
                {
                    string line = "Create the " + element.Replace(" add apppool /name:", "").Replace(" /managedRuntimeVersion: /managedPipelineMode:Classic /autoStart:true /enable32BitAppOnWin64:true /processModel.identityType:NetworkService /failure.rapidFailProtection:false", "") + " App Pools(1109)";
                    fStartInfo(cmd, element, line);
                }
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(1113): ");
                errorLogWrite(ex.Message + "(1113): ");
            }
            /// Create RMS and RMSStud Websites
            progressBar1.PerformStep();
            installLogWrite("Create RMS and RMSStud Websites(1120): ");
            bgWorker(36);
            try
            {
                string cmd = setupWizard.Instance.strAPPCMD;
                List<string> webSiteArgs = new List<string>();
                if (!setupWizard.Instance.checkPreIIS)
                {
                    webSiteArgs.Add(" delete site \"Default Web Site\"");
                }
                webSiteArgs.Add(" add site /name:" + setupWizard.Instance.strRMSName + " /bindings:http/*:" + setupWizard.Instance.rmsBinding + ": /physicalPath:" + setupWizard.Instance.strRMSShare + " /virtualDirectoryDefaults.userName:" + setupWizard.Instance.strRMSIISUser + " /virtualDirectoryDefaults.password:" + setupWizard.Instance.strRMSIISPass + " /applicationDefaults.applicationPool:" + setupWizard.Instance.strRMSName);
                webSiteArgs.Add(" set config \"" + setupWizard.Instance.strRMSName + "\" -section:system.webServer/security/authentication/anonymousAuthentication /enabled:\"True\" /userName:\"" + setupWizard.Instance.strRMSIISUser + "\" /password:\"" + setupWizard.Instance.strRMSIISPass + "\" /commit:apphost");
                webSiteArgs.Add(" set config \"" + setupWizard.Instance.strRMSName + "\" -section:defaultDocument /-files.[value='Login.asp']");
                webSiteArgs.Add(" set config \"" + setupWizard.Instance.strRMSName + "\" -section:defaultDocument /-files.[value='Default.asp']");
                webSiteArgs.Add(" set config \"" + setupWizard.Instance.strRMSName + "\" -section:defaultDocument /-files.[value='Default.htm']");
                webSiteArgs.Add(" set config \"" + setupWizard.Instance.strRMSName + "\" -section:defaultDocument /-files.[value='index.htm']");
                webSiteArgs.Add(" set config \"" + setupWizard.Instance.strRMSName + "\" -section:defaultDocument /-files.[value='index.html']");
                webSiteArgs.Add(" set config \"" + setupWizard.Instance.strRMSName + "\" -section:defaultDocument /-files.[value='iisstart.htm']");
                webSiteArgs.Add(" set config \"" + setupWizard.Instance.strRMSName + "\" -section:defaultDocument /-files.[value='default.aspx']");
                webSiteArgs.Add(" set config \"" + setupWizard.Instance.strRMSName + "\" -section:defaultDocument /+files.[value='Login.asp'] /commit:apphost");
                webSiteArgs.Add(" add site /name:" + setupWizard.Instance.strSWName + " /bindings:http/*:" + setupWizard.Instance.swBinding + ": /physicalPath:" + setupWizard.Instance.strSWShare + "\\WebModule-Student /virtualDirectoryDefaults.userName:" + setupWizard.Instance.strRMSIISUser + " /virtualDirectoryDefaults.password:" + setupWizard.Instance.strRMSIISPass + " /applicationDefaults.applicationPool:" + setupWizard.Instance.strSWName);
                webSiteArgs.Add(" set config \"" + setupWizard.Instance.strSWName + "\" -section:system.webServer/security/authentication/anonymousAuthentication /enabled:\"True\" /userName:\"" + setupWizard.Instance.strRMSIISUser + "\" /password:\"" + setupWizard.Instance.strRMSIISPass + "\" /commit:apphost");
                webSiteArgs.Add(" set config \"" + setupWizard.Instance.strSWName + "\" -section:defaultDocument /-files.[value='Index.asp']");
                webSiteArgs.Add(" set config \"" + setupWizard.Instance.strSWName + "\" -section:defaultDocument /-files.[value='Default.asp']");
                webSiteArgs.Add(" set config \"" + setupWizard.Instance.strSWName + "\" -section:defaultDocument /-files.[value='Default.htm']");
                webSiteArgs.Add(" set config \"" + setupWizard.Instance.strSWName + "\" -section:defaultDocument /-files.[value='index.htm']");
                webSiteArgs.Add(" set config \"" + setupWizard.Instance.strSWName + "\" -section:defaultDocument /-files.[value='index.html']");
                webSiteArgs.Add(" set config \"" + setupWizard.Instance.strSWName + "\" -section:defaultDocument /-files.[value='iisstart.htm']");
                webSiteArgs.Add(" set config \"" + setupWizard.Instance.strSWName + "\" -section:defaultDocument /-files.[value='default.aspx']");
                webSiteArgs.Add(" set config \"" + setupWizard.Instance.strSWName + "\" -section:defaultDocument /+files.[value='Index.asp']");
                if (setupWizard.Instance.checkWS)
                {
                    try
                    {
                        Directory.CreateDirectory(setupWizard.Instance.driveName + @"RmsInc\RMSWebServices");
                        webSiteArgs.Add(" add site /name:RMSWebServices /bindings:http/*:293: /physicalPath:" + setupWizard.Instance.driveName + "RMSInc\\RMSWebServices /applicationDefaults.applicationPool:RMSWebServices /commit:apphost");
                        webSiteArgs.Add(" set config RMSWebServices -section:system.webServer/security/authentication/anonymousAuthentication /enabled:False /commit:apphost");
                        webSiteArgs.Add(" set config RMSWebServices -section:system.webServer/security/authentication/basicAuthentication /enabled:True /commit:apphost");
                        webSiteArgs.Add(" set config RMSWebServices -section:handlers /accessPolicy:Read,Script,Execute /commit:apphost");
                        webSiteArgs.Add(" set config RMSWebServices -section:defaultDocument /-files.[value='Index.asp']");
                        webSiteArgs.Add(" set config RMSWebServices -section:defaultDocument /-files.[value='Default.asp']");
                        webSiteArgs.Add(" set config RMSWebServices -section:defaultDocument /-files.[value='Default.htm']");
                        webSiteArgs.Add(" set config RMSWebServices -section:defaultDocument /-files.[value='index.htm']");
                        webSiteArgs.Add(" set config RMSWebServices -section:defaultDocument /-files.[value='index.html']");
                        webSiteArgs.Add(" set config RMSWebServices -section:defaultDocument /-files.[value='iisstart.htm']");
                        webSiteArgs.Add(" set config RMSWebServices -section:defaultDocument /-files.[value='default.aspx']");
                        webSiteArgs.Add(" set config RMSWebServices -section:defaultDocument /+files.[value='Default.aspx']");
                        string cmd2 = "NET";
                        string args = @" SHARE RMSWebServices=" + setupWizard.Instance.driveName + @"RmsInc\RMSWebServices /grant:" + setupWizard.Instance.strRMSIISUser + ",FULL /grant:" + setupWizard.Instance.strRMSCOMUser + ",FULL /grant:Everyone,READ";
                        string line2 = "Create the RMSStud Share(1169)";
                        fStartInfo(cmd2, args, line2);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("Cannot find requested collection element."))
                        {
                            installLogWrite(ex.Message + "(1172): ");
                        }
                        else
                        {
                            installLogWrite(ex.Message + "(1172): ");
                            errorLogWrite(ex.Message + "(1172): ");
                        }
                    }
                }
                
                foreach (string element in webSiteArgs)
                {
                    try
                    {
                        string line = "IISConfig " + element + "(1190)";
                        fStartInfo(cmd, element, line);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("Cannot find requested collection element."))
                        {
                            installLogWrite(ex.Message + "(1193): ");
                        }
                        else
                        {
                            installLogWrite(ex.Message + "(1193): ");
                            errorLogWrite(ex.Message + "(1193): ");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(1207): ");
                errorLogWrite(ex.Message + "(1207): ");
            }
            ///Disable Handler Mappings
            progressBar1.PerformStep();
            installLogWrite("Disable Handler Mappings(1214): ");
            bgWorker(37);
            try
            {
                string cmd = setupWizard.Instance.strAPPCMD;
                List<string> handlerMapArgs = new List<string>();
                handlerMapArgs.Add(" set config \"" + setupWizard.Instance.strRMSName + "/RMSConfigXML\" /section:handlers /-[name='ASPClassic']");
                handlerMapArgs.Add(" set config \"" + setupWizard.Instance.strRMSName + "/RMSErrorDump\" /section:handlers /-[name='ASPClassic']");
                handlerMapArgs.Add(" set config \"" + setupWizard.Instance.strRMSName + "/RMSUsers\" /section:handlers /-[name='ASPClassic']");
                handlerMapArgs.Add(" set config \"" + setupWizard.Instance.strRMSName + "/RMSXML\" /section:handlers /-[name='ASPClassic']");
                handlerMapArgs.Add(" set config \"" + setupWizard.Instance.strRMSName + "/WebConfigXML\" /section:handlers /-[name='ASPClassic']");
                handlerMapArgs.Add(" set config \"" + setupWizard.Instance.strSWName + "/RMSErrorDump\" /section:handlers /-[name='ASPClassic']");
                handlerMapArgs.Add(" set config \"" + setupWizard.Instance.strSWName + "/RMSUsers\" /section:handlers /-[name='ASPClassic']");
                handlerMapArgs.Add(" set config \"" + setupWizard.Instance.strSWName + "/RMSXML\" /section:handlers /-[name='ASPClassic']");
                foreach (string element in handlerMapArgs)
                {
                    try
                    {
                        string line = "HandlerMappings " + element + "(1232)";
                        fStartInfo(cmd, element, line);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("Cannot find requested collection element."))
                        {
                            installLogWrite(ex.Message + "(1235): ");
                        }
                        else
                        {
                            installLogWrite(ex.Message + "(1235): ");
                            errorLogWrite(ex.Message + "(1235): ");
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("message:Cannot find requested collection element."))
                {
                    installLogWrite(ex.Message + "(1254): ");
                }
                else
                {
                    installLogWrite(ex.Message + "(1254): ");
                    errorLogWrite(ex.Message + "(1254): ");
                }
            }
            ///Set HTTP Header Response to NoCache for ModuleReports and PDF Folders in AllReports
            progressBar1.PerformStep();
            installLogWrite("Set HTTP Header Response to NoCache for ModuleReports and PDF Folders in AllReports(1264): ");
            bgWorker(38);
            try
            {
                string cmd = setupWizard.Instance.strAPPCMD;
                List<string> httpHeadArgs = new List<string>();
                httpHeadArgs.Add(" set config \"" + setupWizard.Instance.strRMSName + "/AllReports/ReportFiles/ModuleReports\" /section:staticContent /clientCache.cacheControlMode:DisableCache");
                httpHeadArgs.Add(" set config \"" + setupWizard.Instance.strRMSName + "/AllReports/ReportFiles/PDF\" /section:staticContent /clientCache.cacheControlMode:DisableCache");
                foreach (string element in httpHeadArgs)
                {
                    string line = "HTTPHeaders " + element + "(1274)";
                    fStartInfo(cmd, element, line);
                }
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(1278): ");
                errorLogWrite(ex.Message + "(1278): ");
            }
            ///If Oracle is checked, Add NTFS Permissions to the Oracle Home Folder
            if (setupWizard.Instance.bOracle)
            {
                progressBar1.PerformStep();
                installLogWrite("Database is Oracle, now adding NTFS Permissions to the Oracle Home Folder(1287): ");
                bgWorker(39);
                try
                {
                    string cmd = "ICACLS";
                    List<string> oraHomeUsers = new List<string>();
                    oraHomeUsers.Add(setupWizard.Instance.strRMSIISUser);
                    oraHomeUsers.Add(setupWizard.Instance.strRMSCOMUser);
                    oraHomeUsers.Add(@"Builtin\IIS_IUSRS");
                    foreach (string element in oraHomeUsers)
                    {
                        string args = @" " + setupWizard.Instance.strOracleHomes + " /grant " + element + ":(OI)(CI)F /T /C /Q";
                        MessageBox.Show(args);
                        string line = "NTFS Permissions to the Oracle Home Folde(1300)";
                        fStartInfo(cmd, args, line);
                    }
                }
                catch (Exception ex)
                {
                    installLogWrite(ex.Message + "(1304): ");
                    errorLogWrite(ex.Message + "(1304): ");
                }
            }
            ///Setup the ODBC for RMSReports************************************************************************
            progressBar1.PerformStep();
            installLogWrite("Setup the ODBC for RMSReports(1312): ");
            bgWorker(40);
            try
            {
                if (setupWizard.Instance.bOracle)
                {
                    RegistryKey rk = Registry.LocalMachine;
                    RegistryKey rk1 = rk.OpenSubKey("SOFTWARE\\Wow6432Node\\ODBC\\ODBCINST.INI\\", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);

                    string[] rk1array = rk1.GetSubKeyNames();
                    foreach (String s in rk1array)
                    {
                        if (s.StartsWith("Oracle"))
                        {
                            try
                            {
                                string OraKey = s;
                                RegistryKey rk2 = rk1.OpenSubKey(OraKey, RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                                string DriverPath = rk2.GetValue("Driver").ToString();
                                string DataSourceName = "RMSReports";
                                string Description = "RMSReports";
                                string UserID = setupWizard.Instance.strOPowerName;
                                string DBServerConnection = setupWizard.Instance.strDatabaseServer;
                                RegistryKey rk3 = rk.OpenSubKey("SOFTWARE\\Wow6432Node\\ODBC\\ODBC.INI\\", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                                RegistryKey rk4 = rk.CreateSubKey("SOFTWARE\\Wow6432Node\\ODBC\\ODBC.INI\\" + DataSourceName + "\\");
                                rk4.SetValue("Driver", DriverPath, RegistryValueKind.String);
                                rk4.SetValue("DisableRULEHint", "T", RegistryValueKind.String);
                                rk4.SetValue("Attributes", "W", RegistryValueKind.String);
                                rk4.SetValue("FetchBufferSize", "64000", RegistryValueKind.String);
                                rk4.SetValue("NumericSetting", "NLS", RegistryValueKind.String);
                                rk4.SetValue("ForceWCHAR", "F", RegistryValueKind.String);
                                rk4.SetValue("FailoverDelay", "10", RegistryValueKind.String);
                                rk4.SetValue("FailoverRetryCount", "10", RegistryValueKind.String);
                                rk4.SetValue("MetadataIdDefault", "F", RegistryValueKind.String);
                                rk4.SetValue("BindAsFLOAT", "F", RegistryValueKind.String);
                                rk4.SetValue("BindAsDATE", "F", RegistryValueKind.String);
                                rk4.SetValue("CloseCursor", "F", RegistryValueKind.String);
                                rk4.SetValue("EXECSchemaOpt", "", RegistryValueKind.String);
                                rk4.SetValue("EXECSyntax", "F", RegistryValueKind.String);
                                rk4.SetValue("Application Attributes", "T", RegistryValueKind.String);
                                rk4.SetValue("ResultSets", "T", RegistryValueKind.String);
                                rk4.SetValue("QueryTimeout", "T", RegistryValueKind.String);
                                rk4.SetValue("CacheBufferSize", "20", RegistryValueKind.String);
                                rk4.SetValue("StatementCache", "F", RegistryValueKind.String);
                                rk4.SetValue("Failover", "T", RegistryValueKind.String);
                                rk4.SetValue("Lobs", "T", RegistryValueKind.String);
                                rk4.SetValue("DisableMTS", "T", RegistryValueKind.String);
                                rk4.SetValue("DisableDPM", "F", RegistryValueKind.String);
                                rk4.SetValue("BatchAutocommitMode", "IfAllSuccessful", RegistryValueKind.String);
                                rk4.SetValue("Description", Description, RegistryValueKind.String);
                                rk4.SetValue("ServerName", DBServerConnection, RegistryValueKind.String);
                                rk4.SetValue("Password", "", RegistryValueKind.String);
                                rk4.SetValue("UserID", UserID, RegistryValueKind.String);
                                rk4.SetValue("DSN", DataSourceName, RegistryValueKind.String);
                                RegistryKey rk5 = rk.CreateSubKey("SOFTWARE\\Wow6432Node\\ODBC\\ODBC.INI\\ODBC Data Sources\\");
                                RegistryKey rk6 = rk.OpenSubKey("SOFTWARE\\Wow6432Node\\ODBC\\ODBC.INI\\ODBC Data Sources\\", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                                rk6.SetValue("RMSReports", OraKey, RegistryValueKind.String);
                            }
                            catch (Exception ex)
                            {
                                installLogWrite(ex.Message + "(1370): ");
                                errorLogWrite(ex.Message + "(1370): ");
                            }
                        }
                    }
                }
                else
                {
                    RegistryKey sk = Registry.LocalMachine;
                    RegistryKey sk1 = sk.OpenSubKey("SOFTWARE\\Wow6432Node\\ODBC\\ODBCINST.INI\\", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);

                    string[] sk1array = sk1.GetSubKeyNames();
                    foreach (String k in sk1array)
                    {
                        if (k.Equals("SQL Server"))
                        {
                            try
                            {
                                string SQLKey = k;
                                RegistryKey sk2 = sk1.OpenSubKey(SQLKey, RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                                string DriverPath = sk2.GetValue("Driver").ToString();
                                string DataSourceName = "RMSReports";
                                string Description = "RMSReports";
                                string DatabaseName = setupWizard.Instance.strODataName;
                                string LastUser = setupWizard.Instance.strOPowerName;
                                string DBServerConnection = setupWizard.Instance.strDatabaseServer;
                                RegistryKey sk3 = sk.OpenSubKey("SOFTWARE\\Wow6432Node\\ODBC\\ODBC.INI\\", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                                RegistryKey sk4 = sk.CreateSubKey("SOFTWARE\\Wow6432Node\\ODBC\\ODBC.INI\\" + DataSourceName + "\\");
                                sk4.SetValue("DataBase", DatabaseName, RegistryValueKind.String);
                                sk4.SetValue("Description", Description, RegistryValueKind.String);
                                sk4.SetValue("LastUser", LastUser, RegistryValueKind.String);
                                sk4.SetValue("Server", DBServerConnection, RegistryValueKind.String);
                                sk4.SetValue("Driver", DriverPath, RegistryValueKind.String);
                                RegistryKey sk5 = sk.CreateSubKey("SOFTWARE\\Wow6432Node\\ODBC\\ODBC.INI\\ODBC Data Sources\\");
                                RegistryKey sk6 = sk.OpenSubKey("SOFTWARE\\Wow6432Node\\ODBC\\ODBC.INI\\ODBC Data Sources\\", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                                sk6.SetValue("RMSReports", SQLKey, RegistryValueKind.String);
                            }
                            catch (Exception ex)
                            {
                                installLogWrite(ex.Message + "(1409): ");
                                errorLogWrite(ex.Message + "(1409): ");
                            }
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(1420): ");
                errorLogWrite(ex.Message + "(1420): ");
            }
            ///Create RMSDaemon Task
            progressBar1.PerformStep();
            installLogWrite("Create and start the RMSDaemon Task(1427): ");
            bgWorker(41);
            try
            {
                string strRMSDaemonExePath = setupWizard.Instance.strRMSv50Share + @"\RMSDLLs\RMSDaemon.exe";
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                settings.Encoding = new UTF8Encoding();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                settings.CloseOutput = false;

                // Create the XmlWriter object and write some content.
                //MemoryStream strm = new MemoryStream();
                //XmlWriter RMSDAEMON_XML_WRITER = XmlWriter.Create(strm, settings);
                String siteMapNamespace = "http://schemas.microsoft.com/windows/2004/02/mit/task";
                XmlWriter RMSDAEMON_XML_WRITER = XmlWriter.Create(setupWizard.Instance.strRMSv50Share + @"\RMSDaemon.xml", settings);
                //RMSDAEMON_XML_WRITER.WriteStartDocument();
                RMSDAEMON_XML_WRITER.WriteStartElement("Task", siteMapNamespace);
                RMSDAEMON_XML_WRITER.WriteAttributeString("version", "1.2");
                //Registration Information
                RMSDAEMON_XML_WRITER.WriteStartElement("RegistrationInfo");
                RMSDAEMON_XML_WRITER.WriteElementString("Author", setupWizard.Instance.strRMSCOMUser);
                RMSDAEMON_XML_WRITER.WriteElementString("Description", "RMSDaemon");
                RMSDAEMON_XML_WRITER.WriteEndElement();
                //Triggers
                RMSDAEMON_XML_WRITER.WriteStartElement("Triggers");
                RMSDAEMON_XML_WRITER.WriteStartElement("BootTrigger");
                RMSDAEMON_XML_WRITER.WriteElementString("Enabled", "true");
                RMSDAEMON_XML_WRITER.WriteEndElement();
                RMSDAEMON_XML_WRITER.WriteEndElement();
                //Principals
                RMSDAEMON_XML_WRITER.WriteStartElement("Principals");
                RMSDAEMON_XML_WRITER.WriteStartElement("Principal");
                RMSDAEMON_XML_WRITER.WriteAttributeString("id", "Author");
                RMSDAEMON_XML_WRITER.WriteElementString("UserId", setupWizard.Instance.strRMSCOMUser);
                RMSDAEMON_XML_WRITER.WriteElementString("LogonType", "Password");
                RMSDAEMON_XML_WRITER.WriteElementString("RunLevel", "HighestAvailable");
                RMSDAEMON_XML_WRITER.WriteEndElement();
                RMSDAEMON_XML_WRITER.WriteEndElement();
                //Settings
                RMSDAEMON_XML_WRITER.WriteStartElement("Settings");
                RMSDAEMON_XML_WRITER.WriteElementString("MultipleInstancesPolicy", "IgnoreNew");
                RMSDAEMON_XML_WRITER.WriteElementString("DisallowStartIfOnBatteries", "false");
                RMSDAEMON_XML_WRITER.WriteElementString("StopIfGoingOnBatteries", "false");
                RMSDAEMON_XML_WRITER.WriteElementString("AllowHardTerminate", "false");
                RMSDAEMON_XML_WRITER.WriteElementString("StartWhenAvailable", "false");
                RMSDAEMON_XML_WRITER.WriteElementString("RunOnlyIfNetworkAvailable", "false");
                RMSDAEMON_XML_WRITER.WriteStartElement("IdleSettings");
                RMSDAEMON_XML_WRITER.WriteElementString("StopOnIdleEnd", "false");
                RMSDAEMON_XML_WRITER.WriteElementString("RestartOnIdle", "false");
                RMSDAEMON_XML_WRITER.WriteEndElement();
                RMSDAEMON_XML_WRITER.WriteElementString("AllowStartOnDemand", "true");
                RMSDAEMON_XML_WRITER.WriteElementString("Enabled", "true");
                RMSDAEMON_XML_WRITER.WriteElementString("Hidden", "false");
                RMSDAEMON_XML_WRITER.WriteElementString("RunOnlyIfIdle", "false");
                RMSDAEMON_XML_WRITER.WriteElementString("WakeToRun", "false");
                RMSDAEMON_XML_WRITER.WriteElementString("ExecutionTimeLimit", "PT0S");
                RMSDAEMON_XML_WRITER.WriteElementString("Priority", "7");
                RMSDAEMON_XML_WRITER.WriteEndElement();
                //Actions
                RMSDAEMON_XML_WRITER.WriteStartElement("Actions");
                RMSDAEMON_XML_WRITER.WriteAttributeString("Context", "Author");
                RMSDAEMON_XML_WRITER.WriteStartElement("Exec");
                RMSDAEMON_XML_WRITER.WriteElementString("Command", strRMSDaemonExePath);
                RMSDAEMON_XML_WRITER.WriteEndElement();
                RMSDAEMON_XML_WRITER.WriteEndElement();
                RMSDAEMON_XML_WRITER.WriteEndElement();
                //RMSDAEMON_XML_WRITER.WriteEndDocument();
                RMSDAEMON_XML_WRITER.Flush();
                RMSDAEMON_XML_WRITER.Close();
                try
                {
                    string cmd = "schtasks.exe";
                    List<string> schTasksArgs = new List<string>();
                    schTasksArgs.Add(@" /Create /S " + setupWizard.Instance.serverName + " /RU " + setupWizard.Instance.strRMSCOMUser + " /RP " + setupWizard.Instance.strRMSCOMPass + " /TN RMSDaemon /XML " + setupWizard.Instance.strRMSv50Share + @"\RMSDaemon.xml");
                    schTasksArgs.Add(@" /Run /TN RMSDaemon");
                    foreach (string element in schTasksArgs)
                    {
                        string line = "RMSDaemon Scheduled Task(1505)";
                        fStartInfo(cmd, element, line);
                    }
                    File.Delete(setupWizard.Instance.strRMSv50Share + @"\RMSDaemon.xml");
                }
                catch (Exception ex)
                {
                    installLogWrite(ex.Message + "(1510): ");
                    errorLogWrite(ex.Message + "(1510): ");
                }
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(1516): ");
                errorLogWrite(ex.Message + "(1516): ");
            }
            ///Create Config XML 
            progressBar1.PerformStep();
            installLogWrite("Create Config XML(1523): ");
            bgWorker(42);
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                settings.Encoding = new UTF8Encoding();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                settings.CloseOutput = false;
                XmlWriter Config_XML_WRITER = XmlWriter.Create(setupWizard.Instance.strRMSv50Share + @"\RMSDLLs\Config\Config.xml", settings);
                //User_DB_XML_WRITER.WriteStartDocument();
                Config_XML_WRITER.WriteStartElement("AppServerName");
                Config_XML_WRITER.WriteElementString("FolderName", "RMS");
                Config_XML_WRITER.WriteElementString("ServerName", setupWizard.Instance.serverName);
                Config_XML_WRITER.WriteElementString("DomainName", setupWizard.Instance.domainName2);
                Config_XML_WRITER.WriteElementString("GroupName", "");
                Config_XML_WRITER.WriteElementString("EMailID", setupWizard.Instance.strSchoolEmail);
                Config_XML_WRITER.WriteElementString("RequiredNTAuthentication", "No");
                Config_XML_WRITER.WriteElementString("DBUserName", setupWizard.Instance.strEncryptedUser);
                Config_XML_WRITER.WriteElementString("DBPassword", setupWizard.Instance.strEncryptedPass);
                Config_XML_WRITER.WriteElementString("RequiredExtAuthentication", "No");
                Config_XML_WRITER.WriteElementString("AuthenticationServerIPAddress", "");
                Config_XML_WRITER.WriteElementString("AuthenticationServerOS", "");
                Config_XML_WRITER.WriteElementString("AuthenticationServerDirectory", "");
                Config_XML_WRITER.WriteElementString("AuthenticationType", "");
                Config_XML_WRITER.WriteElementString("PortalURL", "");
                //Server Names
                Config_XML_WRITER.WriteStartElement("ServerNames");
                Config_XML_WRITER.WriteAttributeString("IntegrationAttribute", "");
                Config_XML_WRITER.WriteAttributeString("FirewallPW", "");
                Config_XML_WRITER.WriteAttributeString("FirewallUser", "");
                Config_XML_WRITER.WriteAttributeString("FirewallPort", "");
                Config_XML_WRITER.WriteAttributeString("FirewallHost", "");
                Config_XML_WRITER.WriteAttributeString("FirewallType", "");
                Config_XML_WRITER.WriteAttributeString("SSLAcceptServerCert", "");
                Config_XML_WRITER.WriteAttributeString("SSLCertEncoded", "");
                Config_XML_WRITER.WriteAttributeString("SSLCertStorePW", "");
                Config_XML_WRITER.WriteAttributeString("SSLCertSubj", "");
                Config_XML_WRITER.WriteAttributeString("SSLCertStore", "");
                Config_XML_WRITER.WriteAttributeString("SSLCretStoreType", "");
                Config_XML_WRITER.WriteAttributeString("SSLMode", "");
                Config_XML_WRITER.WriteAttributeString("BindPW", "");
                Config_XML_WRITER.WriteAttributeString("BindUser", "");
                Config_XML_WRITER.WriteAttributeString("DereferenceAliases", "");
                Config_XML_WRITER.WriteAttributeString("SearchString", "");
                Config_XML_WRITER.WriteAttributeString("ParentDN", "");
                Config_XML_WRITER.WriteAttributeString("Name", "");
                Config_XML_WRITER.WriteEndElement();
                //Software Key Information
                Config_XML_WRITER.WriteStartElement("SoftwareKeyInformation");
                Config_XML_WRITER.WriteElementString("SoftwareKey", setupWizard.Instance.strSoftwareKey);
                Config_XML_WRITER.WriteElementString("ClientID", setupWizard.Instance.strClientID);
                Config_XML_WRITER.WriteElementString("BedSpaces", setupWizard.Instance.strNumberBeds);
                Config_XML_WRITER.WriteEndElement();
                //End Element and Document
                Config_XML_WRITER.WriteEndElement();
                //User_DB_XML_WRITER.WriteEndDocument();
                Config_XML_WRITER.Flush();
                Config_XML_WRITER.Close();
                progressBar1.PerformStep();
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(1584): ");
                errorLogWrite(ex.Message + "(1584): ");
            }
            ///Create User_DB XML
            if (setupWizard.Instance.bExistingYes)
            {
                try
                {
                    progressBar1.PerformStep();
                    installLogWrite("Create User_DB XML(1595): ");
                    bgWorker(43);
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.OmitXmlDeclaration = true;
                    settings.Encoding = new UTF8Encoding();
                    settings.ConformanceLevel = ConformanceLevel.Fragment;
                    settings.CloseOutput = false;

                    XmlWriter User_DB_XML_WRITER = XmlWriter.Create(setupWizard.Instance.strRMSShare + @"\rmsxml\user_db.xml", settings);
                    //User_DB_XML_WRITER.WriteStartDocument();
                    User_DB_XML_WRITER.WriteStartElement("user");
                    User_DB_XML_WRITER.WriteStartElement("dataset");
                    if (setupWizard.Instance.bOracle)
                    {
                        User_DB_XML_WRITER.WriteElementString("dbtype", "Oracle10g");
                    }
                    else
                    {
                        User_DB_XML_WRITER.WriteElementString("dbtype", "SqlServer2000");
                    }
                    User_DB_XML_WRITER.WriteElementString("dbserver", setupWizard.Instance.strDatabaseServer);
                    User_DB_XML_WRITER.WriteElementString("database", setupWizard.Instance.strOLoginName);
                    User_DB_XML_WRITER.WriteEndElement();
                    User_DB_XML_WRITER.WriteEndElement();
                    //User_DB_XML_WRITER.WriteEndDocument();
                    User_DB_XML_WRITER.Flush();
                    User_DB_XML_WRITER.Close();
                }
                catch (Exception ex)
                {
                    installLogWrite(ex.Message + "(1623): ");
                    errorLogWrite(ex.Message + "(1623): ");
                }
                ///create the rms_db.xml
                try
                {
                    progressBar1.PerformStep();
                    installLogWrite("Create rms_db XML(1632): ");
                    bgWorker(44);
                    string cmd = setupWizard.Instance.strAPPCMD;
                    string args = " set config \"RMS/RMSXML/rms_db.xml\" /section:system.webserver/security/authorization /-\"[accessType='Allow',users='*']\" /commitpath:\"RMS/RMSXML\"";
                    string line = "Set IIS Authorization rms_db.xml(1636)";
                    fStartInfo(cmd, args, line);
                }
                catch (Exception ex)
                {
                    installLogWrite(ex.Message + "(1639): ");
                    errorLogWrite(ex.Message + "(1639): ");
                }
                ///create the usersdata.xml
                try
                {
                    progressBar1.PerformStep();
                    installLogWrite("Create usersdata XML(1648): ");
                    bgWorker(45);
                    XmlWriterSettings settings2 = new XmlWriterSettings();
                    settings2.OmitXmlDeclaration = true;
                    settings2.Encoding = new UTF8Encoding();
                    settings2.ConformanceLevel = ConformanceLevel.Fragment;
                    settings2.CloseOutput = false;
                    XmlWriter UsersData_XML_WRITER = XmlWriter.Create(setupWizard.Instance.strRMSShare + @"\rmsusers\usersData.xml", settings2);
                    UsersData_XML_WRITER.WriteStartElement("users");
                    UsersData_XML_WRITER.WriteStartElement("user");
                    UsersData_XML_WRITER.WriteAttributeString("encId", "");
                    UsersData_XML_WRITER.WriteAttributeString("name", "Owner50RMS");
                    UsersData_XML_WRITER.WriteAttributeString("id", "1");
                    UsersData_XML_WRITER.WriteAttributeString("password", "DB3DA8B64E8633B2");
                    UsersData_XML_WRITER.WriteAttributeString("Status", "1");
                    UsersData_XML_WRITER.WriteAttributeString("emailId", "Owner50RMS@rms.com");
                    UsersData_XML_WRITER.WriteAttributeString("schoolID", "1");
                    UsersData_XML_WRITER.WriteAttributeString("loggedinstatus", "false");
                    UsersData_XML_WRITER.WriteAttributeString("sid", "");
                    UsersData_XML_WRITER.WriteAttributeString("accessedtime", "");
                    UsersData_XML_WRITER.WriteEndElement();
                    UsersData_XML_WRITER.WriteEndElement();
                    UsersData_XML_WRITER.Flush();
                    UsersData_XML_WRITER.Close();
                    string cmd = setupWizard.Instance.strAPPCMD;
                    string args = " set config \"RMS/RMSUsers/usersData.xml\" /section:system.webserver/security/authorization /-\"[accessType='Allow',users='*']\" /commitpath:\"RMS/RMSUsers\"";
                    string line = "Set IIS Authorization usersData.xml(1666)";
                    fStartInfo(cmd, args, line);
                }
                catch (Exception ex)
                {
                    installLogWrite(ex.Message + "(1677): ");
                    errorLogWrite(ex.Message + "(1677): ");
                }
                ///Create the user_Owner50RMS.xml
                try
                {
                    progressBar1.PerformStep();
                    installLogWrite("Create user_Owner50RMS XML(1686): ");
                    bgWorker(46);
                    XmlWriterSettings settings3 = new XmlWriterSettings();
                    settings3.OmitXmlDeclaration = true;
                    settings3.Encoding = new UTF8Encoding();
                    settings3.ConformanceLevel = ConformanceLevel.Fragment;
                    settings3.CloseOutput = false;
                    XmlWriter Users_XML_WRITER = XmlWriter.Create(setupWizard.Instance.strRMSShare + @"\rmsusers\user_Owner50RMS.xml", settings3);
                    Users_XML_WRITER.WriteStartElement("User");
                    Users_XML_WRITER.WriteAttributeString("id", "Owner50RMS");
                    Users_XML_WRITER.WriteElementString("strSQL", "");
                    Users_XML_WRITER.WriteStartElement("ApplicationPeriod");
                    Users_XML_WRITER.WriteAttributeString("Desc", "");
                    Users_XML_WRITER.WriteEndElement();
                    Users_XML_WRITER.WriteElementString("FirstName", "");
                    Users_XML_WRITER.WriteElementString("LastName", "");
                    Users_XML_WRITER.WriteElementString("SQL", "");
                    Users_XML_WRITER.WriteElementString("SortOrder", "");
                    Users_XML_WRITER.WriteElementString("showstatus", "");

                    Users_XML_WRITER.WriteStartElement("Rooms");
                    Users_XML_WRITER.WriteElementString("SearchType", "");
                    Users_XML_WRITER.WriteElementString("showType", "");
                    Users_XML_WRITER.WriteElementString("Community", "");
                    Users_XML_WRITER.WriteElementString("Building", "");
                    Users_XML_WRITER.WriteElementString("Floor", "");
                    Users_XML_WRITER.WriteElementString("Section", "");
                    Users_XML_WRITER.WriteElementString("BedSpace", "");
                    Users_XML_WRITER.WriteElementString("RoomType", "");
                    Users_XML_WRITER.WriteElementString("Use1", "");
                    Users_XML_WRITER.WriteElementString("Use2", "");
                    Users_XML_WRITER.WriteElementString("Grid", "");
                    Users_XML_WRITER.WriteElementString("SortOrder", "");
                    Users_XML_WRITER.WriteElementString("StartDate", "");
                    Users_XML_WRITER.WriteElementString("EndDate", "");
                    Users_XML_WRITER.WriteElementString("From", "");
                    Users_XML_WRITER.WriteElementString("RoomNo", "");
                    Users_XML_WRITER.WriteEndElement();

                    Users_XML_WRITER.WriteStartElement("People");
                    Users_XML_WRITER.WriteElementString("SearchType", "");
                    Users_XML_WRITER.WriteElementString("PersonType", "");
                    Users_XML_WRITER.WriteElementString("FirstName", "");
                    Users_XML_WRITER.WriteElementString("LastName", "");
                    Users_XML_WRITER.WriteElementString("SQL", "");
                    Users_XML_WRITER.WriteElementString("SortOrder", "");
                    Users_XML_WRITER.WriteEndElement();

                    Users_XML_WRITER.WriteStartElement("Incidents");
                    Users_XML_WRITER.WriteElementString("SearchType", "");
                    Users_XML_WRITER.WriteElementString("IncShow", "");
                    Users_XML_WRITER.WriteElementString("IncType", "");
                    Users_XML_WRITER.WriteElementString("Date", "");
                    Users_XML_WRITER.WriteElementString("Involved", "");
                    Users_XML_WRITER.WriteElementString("Actions", "");
                    Users_XML_WRITER.WriteElementString("SQL", "");
                    Users_XML_WRITER.WriteElementString("SortOrder", "");
                    Users_XML_WRITER.WriteEndElement();

                    Users_XML_WRITER.WriteStartElement("MailMerge");
                    Users_XML_WRITER.WriteStartElement("SearchCriteria");
                    Users_XML_WRITER.WriteElementString("SearchType", "");
                    Users_XML_WRITER.WriteElementString("LetterID", "");
                    Users_XML_WRITER.WriteElementString("LetterType", "");
                    Users_XML_WRITER.WriteElementString("ApplicationType", "");
                    Users_XML_WRITER.WriteElementString("Type", "");
                    Users_XML_WRITER.WriteElementString("LetterName", "");
                    Users_XML_WRITER.WriteElementString("CreatedBy", "");
                    Users_XML_WRITER.WriteElementString("CreatedDate", "");
                    Users_XML_WRITER.WriteElementString("LastPrintedDate", "");
                    Users_XML_WRITER.WriteElementString("LastEmailedDate", "");
                    Users_XML_WRITER.WriteStartElement("SortOrder");
                    Users_XML_WRITER.WriteElementString("Sort1", "");
                    Users_XML_WRITER.WriteElementString("Sort2", "");
                    Users_XML_WRITER.WriteElementString("Sort3", "");
                    Users_XML_WRITER.WriteElementString("Sort4", "");
                    Users_XML_WRITER.WriteElementString("Sort5", "");
                    Users_XML_WRITER.WriteElementString("Opt1", "");
                    Users_XML_WRITER.WriteElementString("Opt2", "");
                    Users_XML_WRITER.WriteElementString("Opt3", "");
                    Users_XML_WRITER.WriteElementString("Opt4", "");
                    Users_XML_WRITER.WriteElementString("Opt5", "");
                    Users_XML_WRITER.WriteEndElement();
                    Users_XML_WRITER.WriteEndElement();
                    Users_XML_WRITER.WriteEndElement();

                    Users_XML_WRITER.WriteStartElement("Accounting");
                    Users_XML_WRITER.WriteStartElement("SearchCriteria");
                    Users_XML_WRITER.WriteElementString("PerType", "");
                    Users_XML_WRITER.WriteElementString("SearchType", "");
                    Users_XML_WRITER.WriteElementString("RmsId", "");
                    Users_XML_WRITER.WriteElementString("UnivId", "");
                    Users_XML_WRITER.WriteElementString("SsnNo", "");
                    Users_XML_WRITER.WriteElementString("ApplNo", "");
                    Users_XML_WRITER.WriteElementString("WhereClause", "");
                    Users_XML_WRITER.WriteElementString("FromClause", "");
                    Users_XML_WRITER.WriteElementString("FirstName", "");
                    Users_XML_WRITER.WriteElementString("LastName", "");
                    Users_XML_WRITER.WriteStartElement("SortOrder");
                    Users_XML_WRITER.WriteElementString("Sort1", "");
                    Users_XML_WRITER.WriteElementString("Sort2", "");
                    Users_XML_WRITER.WriteElementString("Sort3", "");
                    Users_XML_WRITER.WriteElementString("Sort4", "");
                    Users_XML_WRITER.WriteElementString("Sort5", "");
                    Users_XML_WRITER.WriteElementString("Opt1", "");
                    Users_XML_WRITER.WriteElementString("Opt2", "");
                    Users_XML_WRITER.WriteElementString("Opt3", "");
                    Users_XML_WRITER.WriteElementString("Opt4", "");
                    Users_XML_WRITER.WriteElementString("Opt5", "");
                    Users_XML_WRITER.WriteEndElement();
                    Users_XML_WRITER.WriteEndElement();
                    Users_XML_WRITER.WriteEndElement();

                    Users_XML_WRITER.WriteStartElement("LedgerView");
                    Users_XML_WRITER.WriteStartElement("SearchCriteria");
                    Users_XML_WRITER.WriteElementString("SearchType", "");
                    Users_XML_WRITER.WriteElementString("TxId", "");
                    Users_XML_WRITER.WriteElementString("InVoiceNo", "");
                    Users_XML_WRITER.WriteElementString("RmsId", "");
                    Users_XML_WRITER.WriteElementString("UnivId", "");
                    Users_XML_WRITER.WriteElementString("SsnNo", "");
                    Users_XML_WRITER.WriteElementString("WhereClause", "");
                    Users_XML_WRITER.WriteElementString("refundWhereClause", "");
                    Users_XML_WRITER.WriteElementString("SearchChar", "");
                    Users_XML_WRITER.WriteElementString("SortOrder", "");
                    Users_XML_WRITER.WriteEndElement();
                    Users_XML_WRITER.WriteEndElement();
                    Users_XML_WRITER.WriteStartElement("Printers");
                    Users_XML_WRITER.WriteElementString("Full", "");
                    Users_XML_WRITER.WriteElementString("Receipts", "");
                    Users_XML_WRITER.WriteElementString("Labels", "");
                    Users_XML_WRITER.WriteEndElement();
                    Users_XML_WRITER.WriteStartElement("dataset");
                    if (setupWizard.Instance.bOracle)
                    {
                        Users_XML_WRITER.WriteElementString("dbtype", "Oracle10g");
                    }
                    else
                    {
                        Users_XML_WRITER.WriteElementString("dbtype", "SqlServer2000");
                    }
                    Users_XML_WRITER.WriteElementString("dbserver", setupWizard.Instance.strDatabaseServer);
                    Users_XML_WRITER.WriteElementString("database", setupWizard.Instance.strODataName);
                    Users_XML_WRITER.WriteElementString("dataset", setupWizard.Instance.strODataName);
                    Users_XML_WRITER.WriteElementString("mr_database", "MyRMS");
                    Users_XML_WRITER.WriteEndElement();
                    Users_XML_WRITER.WriteElementString("SwipeCardReadAutoOpen", "");

                    Users_XML_WRITER.WriteStartElement("Error");
                    Users_XML_WRITER.WriteElementString("ErrorNumber", "");
                    Users_XML_WRITER.WriteElementString("ErrorLineNumber", "");
                    Users_XML_WRITER.WriteElementString("ErrorMessage", "");
                    Users_XML_WRITER.WriteElementString("MethodName", "");
                    Users_XML_WRITER.WriteElementString("FunctionName", "");
                    Users_XML_WRITER.WriteElementString("UserName", "");
                    Users_XML_WRITER.WriteElementString("ErrorTime", "");
                    Users_XML_WRITER.WriteStartElement("Variable");
                    Users_XML_WRITER.WriteElementString("conn", "");
                    Users_XML_WRITER.WriteElementString("Desc", "");
                    Users_XML_WRITER.WriteEndElement();
                    Users_XML_WRITER.WriteEndElement();

                    Users_XML_WRITER.WriteElementString("tempLogout", "");
                    Users_XML_WRITER.WriteEndElement();
                    Users_XML_WRITER.Flush();
                    Users_XML_WRITER.Close();
                }
                catch (Exception ex)
                {
                    installLogWrite(ex.Message + "(1853): ");
                    errorLogWrite(ex.Message + "(1853): ");
                }
            }
            ///Create Webconnection XML
            try
            {
                progressBar1.PerformStep();
                installLogWrite("Create Webconnection XML(1863): ");
                bgWorker(47);
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                settings.Encoding = new UTF8Encoding();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                settings.CloseOutput = false;
                XmlWriter Webconnection_XML_WRITER = XmlWriter.Create(setupWizard.Instance.strSWShare + @"\WebModule-Student\rmsxml\webconnection.xml", settings);
                //Webconnection_XML_WRITER.WriteStartDocument();
                Webconnection_XML_WRITER.WriteStartElement("webconnection");
                Webconnection_XML_WRITER.WriteStartElement("connection");
                Webconnection_XML_WRITER.WriteAttributeString("module", "student");
                if (setupWizard.Instance.bOracle)
                {
                    Webconnection_XML_WRITER.WriteAttributeString("dbtype", "Oracle10g");
                }
                else
                {
                    Webconnection_XML_WRITER.WriteAttributeString("dbtype", "SqlServer2000");
                }
                Webconnection_XML_WRITER.WriteAttributeString("servername", setupWizard.Instance.strDatabaseServer);
                Webconnection_XML_WRITER.WriteAttributeString("database", setupWizard.Instance.strODataName);
                Webconnection_XML_WRITER.WriteAttributeString("driver", "");
                Webconnection_XML_WRITER.WriteAttributeString("username", setupWizard.Instance.strOPowerName);
                Webconnection_XML_WRITER.WriteAttributeString("password", setupWizard.Instance.strEncryptedPass);
                Webconnection_XML_WRITER.WriteAttributeString("mr_database", setupWizard.Instance.strMyrmsSchema);
                Webconnection_XML_WRITER.WriteAttributeString("school_id", "1");
                Webconnection_XML_WRITER.WriteAttributeString("Local_URL", setupWizard.Instance.strLocalURL);
                if (setupWizard.Instance.strWebURL.ToString() == "Empty")
                {
                    Webconnection_XML_WRITER.WriteAttributeString("Web_URL", "");
                }
                else
                {
                    Webconnection_XML_WRITER.WriteAttributeString("Web_URL", setupWizard.Instance.strWebURL);
                }
                Webconnection_XML_WRITER.WriteAttributeString("SSLCertStore", "");
                Webconnection_XML_WRITER.WriteAttributeString("SSLCertStoreType", "");
                Webconnection_XML_WRITER.WriteAttributeString("SSLCertStorePassword", "");
                Webconnection_XML_WRITER.WriteAttributeString("SSLCertSubject", "");
                Webconnection_XML_WRITER.WriteAttributeString("SSLAcceptServerCert", "");
                Webconnection_XML_WRITER.WriteEndElement();
                Webconnection_XML_WRITER.WriteStartElement("connection");
                Webconnection_XML_WRITER.WriteAttributeString("module", "conference");
                if (setupWizard.Instance.bOracle)
                {
                    Webconnection_XML_WRITER.WriteAttributeString("dbtype", "Oracle10g");
                }
                else
                {
                    Webconnection_XML_WRITER.WriteAttributeString("dbtype", "SqlServer2000");
                }
                Webconnection_XML_WRITER.WriteAttributeString("servername", setupWizard.Instance.strDatabaseServer);
                Webconnection_XML_WRITER.WriteAttributeString("database", setupWizard.Instance.strODataName);
                Webconnection_XML_WRITER.WriteAttributeString("driver", "");
                Webconnection_XML_WRITER.WriteAttributeString("username", setupWizard.Instance.strOPowerName);
                Webconnection_XML_WRITER.WriteAttributeString("password", setupWizard.Instance.strEncryptedPass);
                Webconnection_XML_WRITER.WriteEndElement();
                Webconnection_XML_WRITER.WriteEndElement();
                //Webconnection_XML_WRITER.WriteEndDocument();
                Webconnection_XML_WRITER.Flush();
                Webconnection_XML_WRITER.Close();
                string cmd = setupWizard.Instance.strAPPCMD;
                string args = " set config \"RMSStud/RMSXML/Webconnection.xml\" /section:system.webserver/security/authorization /-\"[accessType='Allow',users='*']\" /commitpath:\"RMSStud/RMSXML\"";
                string line = "Set IIS Authorization webconnection.xml(1676)";
                fStartInfo(cmd, args, line);
                progressBar1.PerformStep();
                setupWizard.Instance.progIndicate = setupWizard.Instance.progIndicate + 1;
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(1932): ");
                errorLogWrite(ex.Message + "(1932): ");
            }
            ///Call streams.exe to remove stream information from files. 
            try
            {
                progressBar1.PerformStep();
                installLogWrite("Begin removing streams information from files.(1941): ");
                string cmd = setupWizard.Instance.strRMSTools + @"\streams.exe";
                string args = @" -accepteula -s -d " + setupWizard.Instance.driveName + @"\RMSInc";
                string line = "Call streams.exe to remove stream information from files(1944)";
                fStartInfo(cmd, args, line);
                progressBar1.PerformStep();
                bgWorker(48);
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(1949): ");
                errorLogWrite(ex.Message + "(1949): ");
            }
            if (setupWizard.Instance.checkASW)
            {
                try
                {
                    string cmd = "msiexec";
                    string args = @" /i " + setupWizard.Instance.driveName + @"RMSInc\AddOnModuleSetupApplications\AccessibleSW\AccessibleStudentWebSetup.msi /norestart";
                    string line = "Installing Accessible Student Web(1960)";
                    runInstallers(cmd, args, line);
                }
                catch (Exception ex)
                {
                    installLogWrite(ex.Message + "(1963)");
                    errorLogWrite(ex.Message + "(1963)");
                }
            }
            else { }

            if (setupWizard.Instance.checkAS)
            {
                try
                {
                    Directory.CreateDirectory(setupWizard.Instance.driveName + @"RMSInc\AlertService");
                    Directory.CreateDirectory(setupWizard.Instance.driveName + @"RMSInc\AlertService\ErrorLog");
                    string cmd = "msiexec";
                    string args = @" /i " + setupWizard.Instance.driveName + @"RMSInc\AddOnModuleSetupApplications\AlertService\RMSAlertServiceSetup.msi /norestart";
                    string line = "Installing Alert Services(1978)";
                    runInstallers(cmd, args, line);
                }
                catch (Exception ex)
                {
                    installLogWrite(ex.Message + "(1981)");
                    errorLogWrite(ex.Message + "(1981)");
                }
            }
            else { }

            if (setupWizard.Instance.checkPG)
            {
                try
                {
                    string cmd = "msiexec";
                    string args = @" /i " + setupWizard.Instance.driveName + @"RMSInc\AddOnModuleSetupApplications\PaymentProcessing\PaymentProcessingSetup.msi /norestart";
                    string line = "Installing Payment Processing(1995)";
                    runInstallers(cmd, args, line);
                }
                catch (Exception ex)
                {
                    installLogWrite(ex.Message + "(1999)");
                    errorLogWrite(ex.Message + "(1999)");
                }
            }
            else { }
            if (setupWizard.Instance.checkWS)
            {
                try
                {
                    string cmd = "msiexec";
                    string args = @" /i " + setupWizard.Instance.driveName + @"RMSInc\AddOnModuleSetupApplications\WebServices\RMSWebServicesSetup.msi /norestart";
                    string line = "Installing Web Services(2012)";
                    runInstallers(cmd, args, line);
                }
                catch (Exception ex)
                {
                    installLogWrite(ex.Message + "(2015)");
                    errorLogWrite(ex.Message + "(2015)");
                }
            }
            else { }

            if (setupWizard.Instance.checkPG)
            {
                try
                {
                    
                    if (setupWizard.Instance.bAuthorizeNet)
                    {
                        File.Copy(setupWizard.Instance.driveName + @"RMSInc\AddOnModuleSetupApplications\PaymentProcessing\GatewayDLLs\AuthorizeNet.dll", setupWizard.Instance.strSWShare + @"\WebModule-Student\PaymentProcessing\Bin\AuthorizeNet.dll");
                    }
                    if (setupWizard.Instance.bBarclayCard)
                    {
                        File.Copy(setupWizard.Instance.driveName + @"RMSInc\AddOnModuleSetupApplications\PaymentProcessing\GatewayDLLs\Barclaycard.dll", setupWizard.Instance.strSWShare + @"\WebModule-Student\PaymentProcessing\Bin\Barclaycard.dll");
                    }
                    if (setupWizard.Instance.bBucksNet)
                    {
                        File.Copy(setupWizard.Instance.driveName + @"RMSInc\AddOnModuleSetupApplications\PaymentProcessing\GatewayDLLs\BucksNet.dll", setupWizard.Instance.strSWShare + @"\WebModule-Student\PaymentProcessing\Bin\BucksNet.dll");
                    }
                    if (setupWizard.Instance.bCashNet)
                    {
                        File.Copy(setupWizard.Instance.driveName + @"RMSInc\AddOnModuleSetupApplications\PaymentProcessing\GatewayDLLs\CashNET.dll", setupWizard.Instance.strSWShare + @"\WebModule-Student\PaymentProcessing\Bin\CashNET.dll");
                    }
                    if (setupWizard.Instance.bCyberSource)
                    {
                        File.Copy(setupWizard.Instance.driveName + @"RMSInc\AddOnModuleSetupApplications\PaymentProcessing\GatewayDLLs\CyberSource.dll", setupWizard.Instance.strSWShare + @"\WebModule-Student\PaymentProcessing\Bin\CyberSource.dll");
                    }
                    if (setupWizard.Instance.bElavon)
                    {
                        File.Copy(setupWizard.Instance.driveName + @"RMSInc\AddOnModuleSetupApplications\PaymentProcessing\GatewayDLLs\Elavon.dll", setupWizard.Instance.strSWShare + @"\WebModule-Student\PaymentProcessing\Bin\Elavon.dll");
                    }
                    if (setupWizard.Instance.bMoneris)
                    {
                        File.Copy(setupWizard.Instance.driveName + @"RMSInc\AddOnModuleSetupApplications\PaymentProcessing\GatewayDLLs\Moneris.dll", setupWizard.Instance.strSWShare + @"\WebModule-Student\PaymentProcessing\Bin\Moneris.dll");
                    }
                    if (setupWizard.Instance.bMonerisCA)
                    {
                        File.Copy(setupWizard.Instance.driveName + @"RMSInc\AddOnModuleSetupApplications\PaymentProcessing\GatewayDLLs\MonerisCA.dll", setupWizard.Instance.strSWShare + @"\WebModule-Student\PaymentProcessing\Bin\MonerisCA.dll");
                    }
                    if (setupWizard.Instance.bNelNet)
                    {
                        File.Copy(setupWizard.Instance.driveName + @"RMSInc\AddOnModuleSetupApplications\PaymentProcessing\GatewayDLLs\NelNet.dll", setupWizard.Instance.strSWShare + @"\WebModule-Student\PaymentProcessing\Bin\NelNet.dll");
                    }
                    if (setupWizard.Instance.bPayPal)
                    {
                        File.Copy(setupWizard.Instance.driveName + @"RMSInc\AddOnModuleSetupApplications\PaymentProcessing\GatewayDLLs\PayPal.dll", setupWizard.Instance.strSWShare + @"\WebModule-Student\PaymentProcessing\Bin\PayPal.dll");
                    }
                    if (setupWizard.Instance.bRealex)
                    {
                        File.Copy(setupWizard.Instance.driveName + @"RMSInc\AddOnModuleSetupApplications\PaymentProcessing\GatewayDLLs\Realex.dll", setupWizard.Instance.strSWShare + @"\WebModule-Student\PaymentProcessing\Bin\Realex.dll");
                    }
                    if (setupWizard.Instance.bSallieMae)
                    {
                        File.Copy(setupWizard.Instance.driveName + @"RMSInc\AddOnModuleSetupApplications\PaymentProcessing\GatewayDLLs\SallieMae.dll", setupWizard.Instance.strSWShare + @"\WebModule-Student\PaymentProcessing\Bin\SallieMae.dll");
                    }
                    if (setupWizard.Instance.bTouchNetLink)
                    {
                        File.Copy(setupWizard.Instance.driveName + @"RMSInc\AddOnModuleSetupApplications\PaymentProcessing\GatewayDLLs\TouchNetTLink.dll", setupWizard.Instance.strSWShare + @"\WebModule-Student\PaymentProcessing\Bin\TouchNetTLink.dll");
                    }
                    if (setupWizard.Instance.bWPM)
                    {
                        File.Copy(setupWizard.Instance.driveName + @"RMSInc\AddOnModuleSetupApplications\PaymentProcessing\GatewayDLLs\WPM.dll", setupWizard.Instance.strSWShare + @"\WebModule-Student\PaymentProcessing\Bin\WPM.dll");
                    }
                    File.Copy(setupWizard.Instance.strSWShare + @"\WebModule-Student\RMSXML\Webconnection.xml", setupWizard.Instance.strSWShare + @"\WebModule-Student\PaymentProcessing\RMSXML\Webconnection.xml");
                    File.Copy(setupWizard.Instance.strSWShare + @"\WebModule-Student\RMSXML\WMTabledetails - ORACLE.xml", setupWizard.Instance.strSWShare + @"\WebModule-Student\PaymentProcessing\RMSXML\WMTabledetails - ORACLE.xml");
                    File.Copy(setupWizard.Instance.strSWShare + @"\WebModule-Student\RMSXML\Webconnection.xml", setupWizard.Instance.strSWShare + @"\WebModule-Student\PaymentProcessing\RMSXML\WMTabledetails - SQL.xml");
                }
                catch (Exception ex)
                {
                    installLogWrite(ex.Message + "(2088)");
                    errorLogWrite(ex.Message + "(2088)");
                }
            }
            else { }
            if (setupWizard.Instance.checkAS)
            {
                try
                {
                    File.Copy(setupWizard.Instance.strRMSv50Share + @"\RMSDLLs\Config\Config.XML", setupWizard.Instance.driveName + @"\RMSInc\AlertService\RMSXML\Config.XML");
                    File.Copy(setupWizard.Instance.strSWShare + @"\WebModule-Student\RMSXML\Webconnection.XML", setupWizard.Instance.driveName + @"\RMSInc\AlertService\RMSXML\Webconnection.XML");
                    try
                    {
                        XDocument webConModify = XDocument.Load(setupWizard.Instance.driveName + @"\RMSInc\AlertService\RMSXML\Webconnection.xml");
                        var query = from c in webConModify.Elements("webconnection").Elements("connection")
                                    select c;
                        foreach (XElement connection in query)
                        {
                            if (connection.Attribute("module").Value == "student")
                            {
                                connection.SetAttributeValue("module","RMSAlerts");
                            }
                        }
                        webConModify.Save(setupWizard.Instance.driveName + @"RMSInc\AlertService\RMSXML\Webconnection.xml");
                    }
                    catch (Exception ex)
                    {
                        installLogWrite(ex.Message + "(2115)");
                        errorLogWrite(ex.Message + "(2115)");
                    }
                }
                catch (Exception ex)
                {
                    installLogWrite(ex.Message + "(2121)");
                    errorLogWrite(ex.Message + "(2121)");
                }
                

            }
            else { }
            if (setupWizard.Instance.checkWS)
            {
                try
                {
                    string cmd3 = "ICACLS";
                    string args2 = @" " + setupWizard.Instance.driveName + @"RMSInc\RMSWebServices\ErrorLog /grant EVERYONE:(OI)(CI)F /T /C /Q";
                    string line3 = "Create the RMSStud Share(2136)";
                    fStartInfo(cmd3, args2, line3);
                    File.Copy(setupWizard.Instance.strRMSv50Share + @"\RMSDLLs\Config\Config.XML", setupWizard.Instance.driveName + @"\RMSInc\RMSWebServices\RMSXML\Config.XML");
                    File.Copy(setupWizard.Instance.strSWShare + @"\WebModule-Student\RMSXML\Webconnection.XML", setupWizard.Instance.driveName + @"\RMSInc\RMSWebServices\RMSXML\Webconnection.XML");
                    File.Copy(setupWizard.Instance.strSWShare + @"\WebModule-Student\RMSXML\WebConfig.XML", setupWizard.Instance.driveName + @"\RMSInc\RMSWebServices\RMSXML\WebConfig.XML");
                    File.Copy(setupWizard.Instance.strSWShare + @"\WebModule-Student\RMSXML\WMTabledetails - ORACLE.xml", setupWizard.Instance.driveName + @"\RMSInc\RMSWebServices\RMSXML\WMTabledetails - ORACLE.xml");
                    File.Copy(setupWizard.Instance.strSWShare + @"\WebModule-Student\RMSXML\WMTabledetails - SQL.xml", setupWizard.Instance.driveName + @"\RMSInc\RMSWebServices\RMSXML\WMTabledetails - SQL.xml");
                    
                }
                catch (Exception ex)
                {
                    installLogWrite(ex.Message + "(2145)");
                    errorLogWrite(ex.Message + "(2145)");
                }


            }
            else { }
            ///Get Log data into one file 
            try
            {
                progressBar1.PerformStep();
                installLogWrite("Installation Finished(2158): ");
                bgWorker(49);
            }
            catch (Exception ex)
            {
                installLogWrite(ex.Message + "(2161): ");
                errorLogWrite(ex.Message + "(2161): ");
            }

            
            ///Finish Install
            setupWizard.Instance.wizardNext();
        }
        public class DirectoryCopier
        {
            public static void CopyDirectory(string originalDirectory, string newDirectory)
            {
                MoveDirectory(originalDirectory, newDirectory);
            }

            public static void MoveDirectory(string originalDirectory, string newDirectory)
            {
                //Ensure new directory exists
                if (!Directory.Exists(newDirectory))
                    Directory.CreateDirectory(newDirectory);

                DirectoryInfo oldDir = new DirectoryInfo(originalDirectory);

                //Copy files
                foreach (FileInfo file in oldDir.GetFiles())
                {
                    string oldPath = file.FullName;
                    string newPath = newDirectory + "\\" + file.Name;
                    File.Copy(oldPath, newPath);
                }

                foreach (DirectoryInfo dir in oldDir.GetDirectories())
                {
                    string oldPath = dir.FullName;
                    string newPath = newDirectory + "\\" + dir.Name;
                    MoveDirectory(oldPath, newPath);
                }
            }
        }

        private void InstallationProgress(string installMessage)
        {
            currentSelections.Text = installMessage;
            setupWizard.Instance.installerResult += installMessage;
            setupWizard.Instance.installerResult += "\r\n";
            setupWizard.Instance.CurrentSelections.Add(installMessage);
            //installLogWrite(installMessage);
        }

        public void fStartInfo(string cmd, string args, string line)
        {
            string strCMD = cmd;
            string strArg = args;
            string result = "";
            string error = "";
            int exitResult = -1;
            string lineNu = line;
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
            if (line.Contains("DLLRegister"))
            {
                exitResult = proc.ExitCode;
                switch (exitResult)
                    {
                        case 0:
                            result = "DLL " + strArg.Replace(" /s ","") + " was successfully registered.";
                            error = "";
                            break;
                        case 1:
                            error = "Bad arguments to RegSvr32";
                            result = "";
                            break;
                        case 2:
                            error = "OLE initilization failed for " + strArg.Replace(" /s ", "");
                            result = "";
                            break;
                        case 3:
                            error = "Failed to load the module " + strArg.Replace(" /s ", "") + ", you may need to check for problems with dependencies.";
                            result = "";
                            break;
                        case 4:
                            error = "Can't find DllUnregisterServer entry point in the file " + strArg.Replace(" /s ", "") + ", maybe it's not a .DLL or .OCX?";
                            result = "";
                            break;
                        case 5:
                            error = "The assembly " + strArg.Replace(" /s ", "") + " was loaded, but the call to DllRegisterServer failed.";
                            result = "";
                            break;
                        default:
                            error = "Something went wrong, with Exit Code";
                            result = "";
                            break;
                    }
            }
            
            result = result.Replace("\r\n", " ");
            result = result.Replace("\t", " ");
            result = line + " / Message: " + result;
            
            if (error != "")
            {
                if (error.Contains("warning") || error.Contains("The system cannot find the file specified.") || error.Contains("Cannot find requested collection element."))
                {
                    error = error.Replace("\r\n", " ");
                    error = error.Replace("\t", " ");
                    error = line + " / Message: " + error;
                    installLogWrite(error);
                }
                else
                {
                    installLogWrite(error);
                    errorLogWrite(error);
                }                
            }
            if (result.Contains("ERROR"))
            {
                if (result.Contains("warning") || result.Contains("The system cannot find the file specified.") || result.Contains("Cannot find requested collection element."))
                {
                    installLogWrite(result);
                }
                else
                {
                    installLogWrite(result);
                    errorLogWrite(result);
                }
            }
            else if (result != "" && !result.Contains("ERROR") && error == "")
            {
                installLogWrite(result);
            }
        }
        public void rmsBind(string cmd, string args, string line)
        {
            string strCMD = cmd;
            string strArg = args;
            string result = "";
            string lineNu = line;
            ProcessStartInfo startInfo = new ProcessStartInfo(strCMD, strArg);
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            Process proc = new Process();
            proc.StartInfo = startInfo;
            proc.Start();
            result = proc.StandardOutput.ReadToEnd();
            checkPort(result,8080,"RMS");
            checkPort(result,80,"SW");
            }

        public void checkPort(string iisResult,int Port, string Type)
        {
            int Port2 = Port;
            if (iisResult.Contains(":" + Port2.ToString() + ":"))
            {
                Port2++;
                checkPort(iisResult, Port2,Type);
            }
            else
            {
                if (Type == "RMS")
                {
                    setupWizard.Instance.rmsBinding = Port2;
                }
                else if (Type == "SW") 
                {
                    setupWizard.Instance.swBinding = Port2;
                }
             }      
        }

        public void runInstallers(string cmd, string args, string line)
        {
            string strCMD = cmd;
            string strArg = args;
            string result = "";
            string lineNu = line;
            ProcessStartInfo startInfo = new ProcessStartInfo(strCMD, strArg);
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            Process proc = new Process();
            proc.StartInfo = startInfo;
            proc.Start();
            proc.WaitForExit();
            result = proc.StandardOutput.ReadToEnd();
            string error = proc.StandardError.ReadToEnd();
        }

        public void installLogWrite(string logMsg)
        {
            StreamWriter sw = File.AppendText(setupWizard.Instance.installFileName);
            try
            {
                string logLine = DateTime.Now + ": " + logMsg;
                sw.WriteLine(logLine);
                InstallationProgress(logLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": ");
            }
            finally
            {
                sw.Close();
            }
        }
        public void errorLogWrite(string errorMsg)
        {
            StreamWriter sw2 = File.AppendText(setupWizard.Instance.errorFileName);
            try
            {
                string logLine2 = DateTime.Now + ": " + errorMsg;
                sw2.WriteLine(logLine2);
                InstallationProgress(logLine2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": ");
            }
            finally
            {
                sw2.Close();
            }
        }
        public void bgWorker(int progindicator)
        {
            int intprogindicator = progindicator;
            if (intprogindicator == 1)
            {
                this.progressMessage.Refresh();
                this.progressMessage.Text = "Beginning Installation";
            }
            else if (intprogindicator == 2)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Obtaining Domain and Server names.";
            }
            else if (intprogindicator == 3)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Obtaining inetpub folder path.";
            }
            else if (intprogindicator == 4)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Installing roles and features.";
            }
            else if (intprogindicator == 5)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Copying of system32 files.";
            }
            else if (intprogindicator == 6)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Registering RMSMercuryUtility.dll.";
            }
            else if (intprogindicator == 7)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Copy the INETPUB Files.";
            }
            else if (intprogindicator == 8)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Copy the sysWoW64 files.";
            }
            else if (intprogindicator == 9)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = @"Copy the Copy_files_to_dataset_file to the RMSXML\Dataset folder";
            }
            else if (intprogindicator == 10)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = @"Copy the WebConfiXML\BASE files to \Dataset folder";
            }
            else if (intprogindicator == 11)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Create the RMS Share";
            }
            else if (intprogindicator == 12)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Create the RMSStud Share";
            }
            else if (intprogindicator == 13)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Create RMSv50 Share";
            }
            else if (intprogindicator == 14)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Create RMSWMDLLs Share";
            }
            else if (intprogindicator == 15)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "RMS Folder Read and Execute for RMSIIS";
            }
            else if (intprogindicator == 16)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "RMS Folder FULL for RMSCOM";
            }
            else if (intprogindicator == 17)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "RMSStud Folder Read and Execute for RMSIIS";
            }
            else if (intprogindicator == 18)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "RMSStud Folder FULL for RMSCOM";
            }
            else if (intprogindicator == 19)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "RMSv50 Folder Read and Execute for RMSIIS";
            }
            else if (intprogindicator == 20)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "RMSv50 Folder FULL for RMSCOM";
            }
            else if (intprogindicator == 21)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "RMSWMDLLs Folder Read and Execute for RMSIIS";
            }
            else if (intprogindicator == 22)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "RMSWMDLLs Folder FULL for RMSCOM";
            }
            else if (intprogindicator == 23)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Inetpub Modify Permissions for RMSIIS, RMSCOM, IIS_IUSRS";
            }
            else if (intprogindicator == 24)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Add Modify Permissions to HTC and XML files";
            }
            else if (intprogindicator == 25)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Register the DLLs";
            }
            else if (intprogindicator == 26)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Setting Launch and Activation Permissions on COM+ Services";
            }
            else if (intprogindicator == 27)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Adjusting DTC Security";
            }
            else if (intprogindicator == 28)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Building the COM+ Object VBScript";
            }
            else if (intprogindicator == 29)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Encrypt DB Username and Password";
            }
            else if (intprogindicator == 30)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Set BackConnectionHostNames, OptionalNames, and DisableStrictNameChecking in Registry";
            }
            else if (intprogindicator == 31)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Registering PayFlowDotNet file";
            }
            else if (intprogindicator == 32)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Add Metabase Permissions";
            }
            else if (intprogindicator == 33)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Set Asp Script errors to be sent to the browser";
            }
            else if (intprogindicator == 34)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "ASP Max Request Entity Allowed";
            }
            else if (intprogindicator == 35)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Create RMS and RMSStud App Pools";
            }
            else if (intprogindicator == 36)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Create RMS and RMSStud Websites";
            }
            else if (intprogindicator == 37)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Disable Handler Mappings";
            }
            else if (intprogindicator == 38)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Set HTTP Header Response to NoCache for ModuleReports and PDF Folders in AllReports";
            }
            else if (intprogindicator == 39)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "If Oracle is checked, Add NTFS Permissions to the Oracle Home Folder";
            }
            else if (intprogindicator == 40)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Setup the ODBC for RMSReports";
            }
            else if (intprogindicator == 41)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Create RMSDaemon Task";
            }
            else if (intprogindicator == 42)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Create Config XML";
            }
            else if (intprogindicator == 43)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Create User_DB XML";
            }
            else if (intprogindicator == 44)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Create the rms_db.xml";
            }
            else if (intprogindicator == 45)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Create the usersdata.xml";
            }
            else if (intprogindicator == 46)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Create the user_Owner50RMS.xml";
            }
            else if (intprogindicator == 47)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Create Webconnection XML";
            }
            else if (intprogindicator == 48)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Removing streams information from files.";
            }
            else if (intprogindicator == 49)
            {
                this.progressMessage.Refresh();
                progressMessage.Text = "Get Log data into one file";
            }
        }
    }
}
