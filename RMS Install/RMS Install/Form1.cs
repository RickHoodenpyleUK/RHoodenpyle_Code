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





namespace RMS_Install
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fixedDrives();
            
        }
        
        public void Install_But_Click(object sender, EventArgs e)
        {
            logTextBox.Text = "";
            ProcessTextBox.Text = "";
            string installFileName = folderBrowserDialog5.SelectedPath;
            installFileName = installFileName + "\\InstallLogFile.log";
            StringBuilder LOG_TEXT = new StringBuilder();
            serverName.Text = Environment.MachineName.ToString();
            string DLL1 = "accounting.dll";
            string DLL2 = "applications.dll";
            string DLL3 = "CleanUpSchedule.dll";
            string DLL4 = "Common_Accounts.dll";
            string DLL5 = "Conference.dll";
            string DLL6 = "craxdrt.dll";
            string DLL7 = "C_Accommodation.dll";
            string DLL8 = "C_Accounts.dll";
            string DLL9 = "C_BkgScheduler.dll";
            string DLL10 = "C_BreakItem.dll";
            string DLL11 = "C_Conference.dll";
            string DLL12 = "C_Equipment.dll";
            string DLL13 = "C_Facility.dll";
            string DLL14 = "C_GlobalFunctions.dll";
            string DLL15 = "C_Menu.dll";
            string DLL16 = "C_MigrateConferee.dll";
            string DLL17 = "C_Miscellaneous.dll";
            string DLL18 = "C_People.dll";
            string DLL19 = "C_Quote.dll";
            string DLL20 = "C_RMSACCOUNTING.dll";
            string DLL21 = "C_RMSAdmin.dll";
            string DLL22 = "C_RMSAdmPermission.dll";
            string DLL23 = "C_RMSApplication.dll";
            string DLL24 = "C_RMSIncident.dll";
            string DLL25 = "C_RMSInterface.dll";
            string DLL26 = "C_RMSMailMerge.dll";
            string DLL27 = "C_RMSRooms.dll";
            string DLL28 = "C_RMSWaitList.dll";
            string DLL29 = "Data.dll";
            string DLL30 = "E_Accounts.dll";
            string DLL31 = "E_GlobalFunction.dll";
            string DLL32 = "E_RMSACCOUNTING.dll";
            string DLL33 = "E_RMSAdmin.dll";
            string DLL34 = "E_RMSAdmPermission.dll";
            string DLL35 = "E_RMSApplication.dll";
            string DLL36 = "E_RMSIncident.dll";
            string DLL37 = "E_RMSInterface.dll";
            string DLL38 = "E_RMSMailMerge.dll";
            string DLL39 = "E_RMSPeople.dll";
            string DLL40 = "E_RMSRooms.dll";
            string DLL41 = "E_RMSWaitList.dll";
            string DLL42 = "Judicial_Admin.dll";
            string DLL43 = "PDPREP32.dll";
            string DLL44 = "Print.dll";
            string DLL45 = "Profile.dll";
            string DLL46 = "Property.dll";
            string DLL47 = "RMSAdmin.dll";
            string DLL48 = "RMSConnection.dll";
            string DLL49 = "RMSErrorHandler.dll";
            string DLL50 = "RMSJudicial.dll";
            string DLL51 = "RMSLogErr.dll";
            string DLL52 = "RMSProperty.dll";
            string DLL53 = "RMSUtility.dll";
            string DLL54 = "RMSWalkAbout.dll";
            string DLL55 = "RMSXMLCache.dll";
            string DLL56 = "RMS_E_Admin.dll";
            string DLL57 = "RoomManagement.dll";
            string DLL58 = "SoftKeyValidator.dll";
            string DLL59 = "SWSA.dll";
            string DLL60 = "Tools.dll";
            string DLL61 = "tskschd.dll";
            string DLL62 = "workflow.dll";

            string WMDLL1 = "C_RMSWebModule.dll";
            string WMDLL2 = "C_WMAccounts.dll";
            string WMDLL3 = "E_RMSWebModule.dll";
            string WMDLL4 = "E_WMAccounts.dll";
            string WMDLL5 = "RMSWMEncryption.dll";
            string WMDLL6 = "RMSWMErrorHandler.dll";
            string WMDLL7 = "RMSWMLogErr.dll";
            string WMDLL8 = "RMSWMXMLCache.dll";
            string WMDLL9 = "RMS_WebConnection.dll";
            string WMDLL10 = "SWSA.dll";
            string WMDLL11 = "WMCommon_Accounts.dll";
            string WMDLL12 = "C_SWSISPolling.dll";
            string WMDLL13 = "E_SWSISPolling.dll";
            string WMDLL14 = "SWLogErr.dll";
            string WMDLL15 = "SWSISConnection.dll";

            string sDLL1 = "https62.ocx";
            string sDLL2 = "ipports62.ocx";
            string sDLL3 = "ldaps62.ocx";
            string sDLL4 = "ftps62.ocx";
            string sDLL5 = "XpdfPrint.dll";
            string sDLL6 = "cdosys.dll";
            string sDLL7 = "comdlg32.ocx";
            string sDLL8 = "mscal.ocx";
            string sDLL9 = "tabctl32.ocx";
            string sDLL10 = "MSDATGRD.OCX";

            string rd1 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL1;
            string rd2 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL2;
            string rd3 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL3;
            string rd4 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL4;
            string rd5 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL5;
            string rd6 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL6;
            string rd7 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL7;
            string rd8 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL8;
            string rd9 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL9;
            string rd10 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL10;
            string rd11 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL11;
            string rd12 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL12;
            string rd13 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL13;
            string rd14 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL14;
            string rd15 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL15;
            string rd16 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL16;
            string rd17 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL17;
            string rd18 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL18;
            string rd19 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL19;
            string rd20 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL20;
            string rd21 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL21;
            string rd22 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL22;
            string rd23 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL23;
            string rd24 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL24;
            string rd25 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL25;
            string rd26 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL26;
            string rd27 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL27;
            string rd28 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL28;
            string rd29 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL29;
            string rd30 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL30;
            string rd31 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL31;
            string rd32 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL32;
            string rd33 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL33;
            string rd34 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL34;
            string rd35 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL35;
            string rd36 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL36;
            string rd37 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL37;
            string rd38 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL38;
            string rd39 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL39;
            string rd40 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL40;
            string rd41 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL41;
            string rd42 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL42;
            string rd43 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL43;
            string rd44 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL44;
            string rd45 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL45;
            string rd46 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL46;
            string rd47 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL47;
            string rd48 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL48;
            string rd49 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL49;
            string rd50 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL50;
            string rd51 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL51;
            string rd52 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL52;
            string rd53 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL53;
            string rd54 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL54;
            string rd55 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL55;
            string rd56 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL56;
            string rd57 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL57;
            string rd58 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL58;
            string rd59 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL59;
            string rd60 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL60;
            string rd61 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL61;
            string rd62 = @" " + RMSv50Share.Text + "\\RMSDLLs\\" + DLL62;

            string w1 = @" " + RMSWMDLLsShare.Text + "\\" + WMDLL1;
            string w2 = @" " + RMSWMDLLsShare.Text + "\\" + WMDLL2;
            string w3 = @" " + RMSWMDLLsShare.Text + "\\" + WMDLL3;
            string w4 = @" " + RMSWMDLLsShare.Text + "\\" + WMDLL4;
            string w5 = @" " + RMSWMDLLsShare.Text + "\\" + WMDLL5;
            string w6 = @" " + RMSWMDLLsShare.Text + "\\" + WMDLL6;
            string w7 = @" " + RMSWMDLLsShare.Text + "\\" + WMDLL7;
            string w8 = @" " + RMSWMDLLsShare.Text + "\\" + WMDLL8;
            string w9 = @" " + RMSWMDLLsShare.Text + "\\" + WMDLL9;
            string w10 = @" " + RMSWMDLLsShare.Text + "\\" + WMDLL10;
            string w11 = @" " + RMSWMDLLsShare.Text + "\\" + WMDLL11;
            string w12 = @" " + RMSWMDLLsShare.Text + "\\" + WMDLL12;
            string w13 = @" " + RMSWMDLLsShare.Text + "\\" + WMDLL13;
            string w14 = @" " + RMSWMDLLsShare.Text + "\\" + WMDLL14;
            string w15 = @" " + RMSWMDLLsShare.Text + "\\" + WMDLL15;

            string s1 = @" C:\\Windows\\syswow64\\" + sDLL1;
            string s2 = @" C:\\Windows\\syswow64\\" + sDLL2;
            string s3 = @" C:\\Windows\\syswow64\\" + sDLL3;
            string s4 = @" C:\\Windows\\syswow64\\" + sDLL4;
            string s5 = @" C:\\Windows\\syswow64\\" + sDLL5;
            string s6 = @" C:\\Windows\\syswow64\\" + sDLL6;
            string s7 = @" C:\\Windows\\syswow64\\" + sDLL7;
            string s8 = @" C:\\Windows\\syswow64\\" + sDLL8;
            string s9 = @" C:\\Windows\\syswow64\\" + sDLL9;
            string s10 = @" C:\\Windows\\syswow64\\" + sDLL10;
            //Adding Roles and Features
            

            if (RMSv50Share.Text != "")
            {
                try
                {

                    string oldDir = RMSTools.Text + @"\SystemFiles\system32";
                    string newDir = RMSv50Share.Text + @"\RMSDLLs\64bit\";
                    DirectoryCopier.CopyDirectory(oldDir, newDir);
                    LOG_TEXT.Append("Finished copying the system files");
                    LOG_TEXT.AppendLine("");
                    //System.Console.Read();
                }

                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");

                }
                try
                {
                    string lines = @" " + RMSv50Share.Text + @"\RMSDLLs\64bit\RMSMercuryUtility.dll /tlb /codebase";
                    LOG_TEXT.Append("Registering RMSMercuryUtility.dll using Regasm.");
                    LOG_TEXT.AppendLine("");

                    string strCScript = Environment.GetEnvironmentVariable("windir") + @"\Microsoft.NET\Framework\v4.0.30319\regasm.exe";

                    ProcessStartInfo regasmRMSM = new ProcessStartInfo(strCScript, lines);
                    regasmRMSM.RedirectStandardOutput = true;
                    regasmRMSM.RedirectStandardInput = true;
                    regasmRMSM.UseShellExecute = false;
                    regasmRMSM.CreateNoWindow = true;
                    Process regasmRMSMProc = new Process();
                    regasmRMSMProc.StartInfo = regasmRMSM;
                    regasmRMSMProc.Start();
                    string resultregasmRMSM = regasmRMSMProc.StandardOutput.ReadToEnd();
                    LOG_TEXT.Append(resultregasmRMSM);
                    LOG_TEXT.AppendLine("");

                    //File.Delete(filePath);
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");

                }
                
            }
            else
            {
                
            }
            if (RMSTools.Text == "")
            {

            }
            else
            {
                try
                {

                    string oldDir = RMSTools.Text + @"\Inetpub-AdminScripts";
                    string newDir = InetpubLocation.Text + @"\AdminScripts";
                    DirectoryCopier.CopyDirectory(oldDir, newDir);
                    LOG_TEXT.Append("Finished copying the Inetpub-AdminScripts");
                    LOG_TEXT.AppendLine("");
                    //System.Console.Read();
                }

                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");

                }
                try
                {

                    string oldDir = RMSTools.Text + @"\SystemFiles\sysWOW64";
                    string newDir = Environment.GetEnvironmentVariable("windir") + @"\sysWOW64";
                    DirectoryCopier.CopyDirectory(oldDir, newDir);
                    LOG_TEXT.Append("Finished copying the syswow64 files");
                    LOG_TEXT.AppendLine("");
                    //System.Console.Read();
                }

                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");

                }
                
            }
            if (RMSShare.Text == "")
            {

            }
            else
            {
                try
                {
                    System.IO.Directory.CreateDirectory(RMSShare.Text + "\\RMSXML\\" + RMSREALUser.Text);
                    string oldDir = RMSShare.Text + @"\RMSXML\Copy_files_to_dataset_file";
                    string newDir = RMSShare.Text + @"\RMSXML\" + RMSREALUser.Text;
                    DirectoryCopier.CopyDirectory(oldDir, newDir);
                    LOG_TEXT.Append("Finished copying the RMSXML\\Copy_files_to_dataset_file folder to RMSXML\\" + RMSREALUser.Text);
                    LOG_TEXT.AppendLine("");
                    //System.Console.Read();
                }

                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");

                }
                try
                {
                    System.IO.Directory.CreateDirectory(RMSShare.Text + "\\WebConfigXML\\" + RMSREALUser.Text);
                    string oldDir = RMSShare.Text + @"\WebConfigXML\BaseXML";
                    string newDir = RMSShare.Text + @"\WebConfigXML\" + RMSREALUser.Text;
                    DirectoryCopier.CopyDirectory(oldDir, newDir);
                    LOG_TEXT.Append(@"Finished copying the \WebConfigXML\BaseXML folder to RMSXML\" + RMSREALUser.Text);
                    LOG_TEXT.AppendLine("");
                    //System.Console.Read();


                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");

                }
            }
            if (checkBox1.Checked == true)
                {
                    
                Runspace runspace = RunspaceFactory.CreateRunspace();
                runspace.Open();
                PowerShell ps = PowerShell.Create();
                ps.Runspace = runspace;
                ps.AddCommand("Get-Process").AddArgument("wmi*");
                Pipeline pipeline = runspace.CreatePipeline();
                try
                {
                    ProcessTextBox.Text = ProcessTextBox.Text + "Processing...............................!";
                    ProcessTextBox.Text = ProcessTextBox.Text + "Install File will be " + installFileName;
                    ProcessTextBox.Text = ProcessTextBox.Text + "Install roles and features..............";
                    LOG_TEXT.Append("Installing Windows Roles and Features!");
                    LOG_TEXT.AppendLine("");
                    
                    pipeline.Commands.AddScript("Import-Module ServerManager; Add-WindowsFeature Application-Server");
                    pipeline.Commands.AddScript("Get-Windowsfeature > " + RMSv50Share.Text + "\\RolesAndFeaturesBefore.txt");
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
                    pipeline.Commands.AddScript("Get-Windowsfeature > " + RMSv50Share.Text + "\\RolesAndFeaturesAfter.txt");
                    pipeline.Invoke();
                    runspace.Close();
                    LOG_TEXT.Append("Finished Installing Windows Roles and Features!");
                    LOG_TEXT.AppendLine("");

                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");

                } 
            }
            else if (checkBox1.Checked == false)
            {
                    LOG_TEXT.Append("Install Roles and Features checkbox was not checked.");
                    LOG_TEXT.AppendLine("");

            }
            ProcessTextBox.Text = ProcessTextBox.Text + "Creating Shares................";
            if (checkBox3.Checked == true)
            {
                
                string strCMD = "NET";
                //RMS Share Creation
                if (RMSShare.Text != "" && RMSShareName.Text != "")
                {
                    try
                    {
                        LOG_TEXT.Append("Creating the RMS Share.");
                        LOG_TEXT.AppendLine("");

                        string d = @" SHARE " + RMSShareName.Text + "=" + RMSShare.Text + " /grant:" + RMSIISUser.Text + ",FULL /grant:" + RMSCOMUser.Text + ",FULL /grant:Everyone,READ";
                        ProcessStartInfo COMSPEC = new ProcessStartInfo(strCMD, d);
                        COMSPEC.RedirectStandardOutput = true;
                        COMSPEC.UseShellExecute = false;
                        COMSPEC.CreateNoWindow = true;
                        Process proc = new Process();
                        proc.StartInfo = COMSPEC;
                        proc.Start();
                        string result = proc.StandardOutput.ReadToEnd();
                        // Display the command output.
                        LOG_TEXT.Append(result);
                        LOG_TEXT.AppendLine("");

                    }
                    catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");

                    }
                }
                else if (RMSShare.Text == "" && RMSShareName.Text != "")
                {
                    LOG_TEXT.Append("RMS Share Path is not set.");
                    LOG_TEXT.AppendLine("");

                }
                else if (RMSShare.Text != "" && RMSShareName.Text == "")
                {
                    LOG_TEXT.Append("RMS Share Name is not set.");
                    LOG_TEXT.AppendLine("");

                }
                else if (RMSShare.Text == "" && RMSShareName.Text == "")
                {
                    LOG_TEXT.Append("Neither the RMS Share Path or RMS Share Name are set.");
                    LOG_TEXT.AppendLine("");

                }
                //RMSStud Share Creation
                if (SWShare.Text != "" && SWShareName.Text != "")
                {
                    try
                    {
                        LOG_TEXT.Append("Creating the Student Web Share.");
                        LOG_TEXT.AppendLine("");

                        string d = @" SHARE " + SWShareName.Text + "=" + SWShare.Text + " /grant:" + RMSIISUser.Text + ",FULL /grant:" + RMSCOMUser.Text + ",FULL /grant:Everyone,READ";
                        ProcessStartInfo COMSPEC = new ProcessStartInfo(strCMD, d);
                        COMSPEC.RedirectStandardOutput = true;
                        COMSPEC.UseShellExecute = false;
                        COMSPEC.CreateNoWindow = true;
                        Process proc = new Process();
                        proc.StartInfo = COMSPEC;
                        proc.Start();
                        string result = proc.StandardOutput.ReadToEnd();
                        // Display the command output.
                        LOG_TEXT.Append(result);
                        LOG_TEXT.AppendLine("");

                    }
                    catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");

                    }
                }
                else if (SWShare.Text == "" && SWShareName.Text != "")
                {
                    LOG_TEXT.Append("Student Web Share Path is not set.");
                    LOG_TEXT.AppendLine("");

                }
                else if (SWShare.Text != "" && SWShareName.Text == "")
                {
                    LOG_TEXT.Append("Student Web Share Name is not set.");
                    LOG_TEXT.AppendLine("");

                }
                else if (SWShare.Text == "" && SWShareName.Text == "")
                {
                    LOG_TEXT.Append("Neither the Student Web Share Path or Student Web Share Name are set.");
                    LOG_TEXT.AppendLine("");

                }
                //RMSv50 Share Creation
                if (RMSv50Share.Text != "" && RMSv50ShareName.Text != "")
                {
                    try
                    {
                        LOG_TEXT.Append("Creating the RMSv50 Share.");
                        LOG_TEXT.AppendLine("");

                        string d = @" SHARE " + RMSv50ShareName.Text + "=" + RMSv50Share.Text + " /grant:" + RMSIISUser.Text + ",FULL /grant:" + RMSCOMUser.Text + ",FULL /grant:Everyone,READ";
                        ProcessStartInfo COMSPEC = new ProcessStartInfo(strCMD, d);
                        COMSPEC.RedirectStandardOutput = true;
                        COMSPEC.UseShellExecute = false;
                        COMSPEC.CreateNoWindow = true;
                        Process proc = new Process();
                        proc.StartInfo = COMSPEC;
                        proc.Start();
                        string result = proc.StandardOutput.ReadToEnd();
                        // Display the command output.
                        LOG_TEXT.Append(result);
                        LOG_TEXT.AppendLine("");

                    }
                    catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");
 
                    }
                }
                else if (RMSv50Share.Text == "" && RMSv50ShareName.Text != "")
                {
                    LOG_TEXT.Append("RMSv50 Share Path is not set.");
                    LOG_TEXT.AppendLine("");

                }
                else if (RMSv50Share.Text != "" && RMSv50ShareName.Text == "")
                {
                    LOG_TEXT.Append("RMSv50 Share Name is not set.");
                    LOG_TEXT.AppendLine("");

                }
                else if (RMSv50Share.Text == "" && RMSv50ShareName.Text == "")
                {
                    LOG_TEXT.Append("Neither the RMSv50 Share Path or RMSv50 Share Name are set.");
                    LOG_TEXT.AppendLine("");

                }
                //RMSWMDLLs Share Creation
                if (RMSWMDLLsShare.Text != "" && RMSWMDLLShareName.Text != "")
                {
                    try
                    {
                        LOG_TEXT.Append("Creating the RMSWMDLLs Share.");
                        LOG_TEXT.AppendLine("");
                        
                        string d = @" SHARE " + RMSWMDLLShareName.Text + "=" + RMSWMDLLsShare.Text + " /grant:" + RMSIISUser.Text + ",FULL /grant:" + RMSCOMUser.Text + ",FULL /grant:Everyone,READ";
                        ProcessStartInfo COMSPEC = new ProcessStartInfo(strCMD, d);
                        COMSPEC.RedirectStandardOutput = true;
                        COMSPEC.UseShellExecute = false;
                        COMSPEC.CreateNoWindow = true;
                        Process proc = new Process();
                        proc.StartInfo = COMSPEC;
                        proc.Start();
                        string result = proc.StandardOutput.ReadToEnd();
                        // Display the command output.
                        LOG_TEXT.Append(result);
                        LOG_TEXT.AppendLine("");
                        
                    }
                    catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");
                        
                    }
                }
                else if (RMSWMDLLsShare.Text == "" && RMSWMDLLShareName.Text != "")
                {
                    LOG_TEXT.Append("RMSWMDLLs Share Path is not set.");
                    LOG_TEXT.AppendLine("");
                    
                }
                else if (RMSWMDLLsShare.Text != "" && RMSWMDLLShareName.Text == "")
                {
                    LOG_TEXT.Append("RMSWMDLLs Share Name is not set.");
                    LOG_TEXT.AppendLine("");
                    
                }
                else if (RMSWMDLLsShare.Text == "" && RMSWMDLLShareName.Text == "")
                    LOG_TEXT.AppendLine("");
                
                {
                    LOG_TEXT.Append("Neither the RMSWMDLLs Share Path or RMSWMDLLs Share Name are set.");
                    LOG_TEXT.AppendLine("");
                    
                }
            }
            else if (checkBox3.Checked == false)
            {
                LOG_TEXT.Append("Create Shares checkbox was not checked.");
                LOG_TEXT.AppendLine("");
                
            }
            //File Security
            ProcessTextBox.Text = ProcessTextBox.Text + "Altering File Security............";
            if (checkBox4.Checked == true)
            {
                
                string strCMD = "ICACLS";
                try //RMS File Permissions
                {
                    LOG_TEXT.Append("Setting up the Read and Execute File Permissions for " + RMSIISUser.Text + " on the " + RMSShare.Text + " Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    //RMS Folder Read and Execute for RMSIIS
                    string d = @" " + RMSShare.Text + " /grant " + RMSIISUser.Text + ":(OI)(CI)RX /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                try
                {
                    LOG_TEXT.Append("Setting up the Full File Permissions for " + RMSCOMUser.Text + " on the " + RMSShare.Text + " Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    //RMS Folder FULL for RMSCOM
                    string d = @" " + RMSShare.Text + " /grant " + RMSCOMUser.Text + ":(OI)(CI)F /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                try //RMSStud File Permissions
                {
                    LOG_TEXT.Append("Setting up the Read and Execute File Permissions for " + RMSIISUser.Text + " on the " + SWShare.Text + " Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    //RMSStud Folder Read and Execute for RMSIIS
                    string d = @" " + SWShare.Text + " /grant " + RMSIISUser.Text + ":(OI)(CI)RX /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                try
                {
                    LOG_TEXT.Append("Setting up the Full File Permissions for " + RMSCOMUser.Text + " on the " + SWShare.Text + " Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    //RMSStud Folder FULL for RMSCOM
                    string d = @" " + SWShare.Text + " /grant " + RMSCOMUser.Text + ":(OI)(CI)F /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                
                try //RMSv50 File Permissions
                {
                    LOG_TEXT.Append("Setting up the Read and Execute File Permissions for " + RMSIISUser.Text + " on the " + RMSv50Share.Text + " Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    //RMSv50 Folder Read and Execute for RMSIIS
                    string d = @" " + RMSv50Share.Text + " /grant " + RMSIISUser.Text + ":(OI)(CI)RX /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                try
                {
                    LOG_TEXT.Append("Setting up the Full File Permissions for " + RMSCOMUser.Text + " on the " + RMSv50Share.Text + " Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    //RMSv50 Folder FULL for RMSCOM
                    string d = @" " + RMSv50Share.Text + " /grant " + RMSCOMUser.Text + ":(OI)(CI)F /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                try //RMSWMDLLs File Permissions
                {
                    LOG_TEXT.Append("Setting up the Read and Execute File Permissions for " + RMSIISUser.Text + " on the " + RMSWMDLLsShare.Text + " Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    //RMSWMDLLs Folder Read and Execute for RMSIIS
                    string d = @" " + RMSWMDLLsShare.Text + " /grant " + RMSIISUser.Text + ":(OI)(CI)RX /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                try
                {
                    LOG_TEXT.Append("Setting up the Full File Permissions for " + RMSCOMUser.Text + " on the " + RMSWMDLLsShare.Text + " Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    //RMSWMDLLs Folder FULL for RMSCOM
                    string d = @" " + RMSWMDLLsShare.Text + " /grant " + RMSCOMUser.Text + ":(OI)(CI)F /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                try //Inetpub File Permissions
                {
                    LOG_TEXT.Append("Setting up the Modify File Permissions for " + RMSIISUser.Text + " on the " + InetpubLocation.Text + " Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    //Inetpub Folder Read and Execute for RMSIIS
                    string d = @" " + InetpubLocation.Text + " /grant " + RMSIISUser.Text + ":(OI)(CI)M /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                try
                {
                    LOG_TEXT.Append("Setting up the Modify File Permissions for " + RMSCOMUser.Text + " on the " + InetpubLocation.Text + " Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    //Inetpub Folder FULL for RMSCOM
                    string d = @" " + InetpubLocation.Text + " /grant " + RMSCOMUser.Text + ":(OI)(CI)M /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                try
                {
                    LOG_TEXT.Append("Setting up the Modify File Permissions for builtin\\iis_iusrs group on the " + InetpubLocation.Text + " Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    //Inetpub Folder Modify for RMSCOM
                    string d = @" " + InetpubLocation.Text + " /grant builtin\\iis_iusrs:(OI)(CI)M /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
            }
            else if (checkBox4.Checked == false)
            {
                LOG_TEXT.Append("Modify NTFS Permissions checkbox was not checked.");
                LOG_TEXT.AppendLine("");
                
            }
            //Add Modify Permissions to HTC and XML files.
            ProcessTextBox.Text = ProcessTextBox.Text + "Modifying Permissions to HTC and XML files............";
            if (checkBox5.Checked == true)
            {
                
                //RMS Folders Needing Modify for RMSIIS
                string HTCFilePerms1 = RMSShare.Text + "\\*.htc";
                string HTCFilePerms2 = RMSShare.Text + "\\Includes\\*.htc";
                string RMSCONFIGXMLPerms = RMSShare.Text + "\\RMSCONFIGXML";
                string RMSErrorDumpPerms = RMSShare.Text + "\\RMSErrorDump";
                string RMSUsersPerms = RMSShare.Text + "\\RMSUsers";
                string RMSXMLPerms = RMSShare.Text + "\\RMSXML";
                string WebConfigXMLPerms = RMSShare.Text + "\\WebConfigXML";
                //SW Folders Needing Modify for RMSIIS
                string SWReusablePerms = SWShare.Text + "\\WebModule-Student\\Reusable";
                string SWRMSErrorDumpPerms = SWShare.Text + "\\WebModule-Student\\RMSErrorDump";
                string SWUsersPerms = SWShare.Text + "\\WebModule-Student\\RMSUsers";
                string SWXMLPerms = SWShare.Text + "\\WebModule-Student\\RMSXML";
                string strCMD = "ICACLS";
                try
                {
                    LOG_TEXT.Append("Setting up the Modify File Permissions for the " + RMSIISUser.Text + " on the HTC Files.");
                    LOG_TEXT.AppendLine("");
                    
                    //HTC Files Modify for RMSIIS
                    string d = @" " + HTCFilePerms1 + " /grant " + RMSIISUser.Text + ":(OI)(CI)M /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                    //HTC Files Modify for RMSIIS
                    string d2 = @" " + HTCFilePerms2 + " /grant " + RMSIISUser.Text + ":(OI)(CI)M /T /C";
                    ProcessStartInfo ICACLS2 = new ProcessStartInfo(strCMD, d2);
                    ICACLS2.RedirectStandardOutput = true;
                    ICACLS2.UseShellExecute = false;
                    ICACLS2.CreateNoWindow = true;
                    Process proc2 = new Process();
                    proc2.StartInfo = ICACLS2;
                    proc2.Start();
                    string result2 = proc2.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result2);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                try
                {
                    LOG_TEXT.Append("Setting up the Modify File Permissions for the " + RMSIISUser.Text + " on the RMSCONFIGXML Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    //RMSCONFIGXMLPerms Files Modify for RMSIIS
                    string d = @" " + RMSCONFIGXMLPerms + " /grant " + RMSIISUser.Text + ":(OI)(CI)M /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                try
                {
                    LOG_TEXT.Append("Setting up the Modify File Permissions for the " + RMSIISUser.Text + " on the RMSErrorDump Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    //RMSErrorDumpPerms Files Modify for RMSIIS
                    string d = @" " + RMSErrorDumpPerms + " /grant " + RMSIISUser.Text + ":(OI)(CI)M /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                try
                {
                    LOG_TEXT.Append("Setting up the Modify File Permissions for the " + RMSIISUser.Text + " on the RMSUsers Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    //RMSUsersPerms Files Modify for RMSIIS
                    string d = @" " + RMSUsersPerms + " /grant " + RMSIISUser.Text + ":(OI)(CI)M /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                try
                {
                    LOG_TEXT.Append("Setting up the Modify File Permissions for the " + RMSIISUser.Text + " on the RMSXML Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    //RMSXMLPerms Files Modify for RMSIIS
                    string d = @" " + RMSXMLPerms + " /grant " + RMSIISUser.Text + ":(OI)(CI)M /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                try
                {
                    LOG_TEXT.Append("Setting up the Modify File Permissions for the " + RMSIISUser.Text + " on the WebConfigXML Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    //WebConfigXMLPerms Files Modify for RMSIIS
                    string d = @" " + WebConfigXMLPerms + " /grant " + RMSIISUser.Text + ":(OI)(CI)M /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                try
                {
                    LOG_TEXT.Append("Setting up the Modify File Permissions for the " + RMSIISUser.Text + " on the SW-Reusable Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    //SWReusablePerms Files Modify for RMSIIS
                    string d = @" " + SWReusablePerms + " /grant " + RMSIISUser.Text + ":(OI)(CI)M /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                try
                {
                    LOG_TEXT.Append("Setting up the Modify File Permissions for the " + RMSIISUser.Text + " on the SW-RMSErrorDump Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    //SWRMSErrorDumpPerms Files Modify for RMSIIS
                    string d = @" " + SWRMSErrorDumpPerms + " /grant " + RMSIISUser.Text + ":(OI)(CI)M /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                try
                {
                    LOG_TEXT.Append("Setting up the Modify File Permissions for the " + RMSIISUser.Text + " on the SW-Users Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    //SWUsersPerms Files Modify for RMSIIS
                    string d = @" " + SWUsersPerms + " /grant " + RMSIISUser.Text + ":(OI)(CI)M /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                try
                {
                    LOG_TEXT.Append("Setting up the Modify File Permissions for the " + RMSIISUser.Text + " on the SW-RMSXML Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    //SWXMLPerms Files Modify for RMSIIS
                    string d = @" " + SWXMLPerms + " /grant " + RMSIISUser.Text + ":(OI)(CI)M /T /C";
                    ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                    ICACLS.RedirectStandardOutput = true;
                    ICACLS.UseShellExecute = false;
                    ICACLS.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = ICACLS;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
            }
            else if (checkBox5.Checked == false)
            {
                LOG_TEXT.Append("Modify permissions to HTC and XML files checkbox was not checked.");
                LOG_TEXT.AppendLine("");
                
            }
                       
            
            //Create COM Objects
            ProcessTextBox.Text = ProcessTextBox.Text + "Creating COM+ Objects............";
            if (checkBox9.Checked == true)
            {
                
                try
                {
                    string strRegSvrPath = openFileDialog1.FileName;
                    strRegSvrPath = strRegSvrPath.Replace("\"", "\\");
                    string strCMD = strRegSvrPath;
                    try
                    {
                        LOG_TEXT.Append("Registering RMS, WM and System DLLs.");
                        LOG_TEXT.AppendLine("");
                        
                        string com = @" /s " + rd1 + " " + rd2 + " " + rd3 + " " + rd4 + " " + rd5 + " " + rd6 + " " + rd7 + " " + rd8 + " " + rd9 + " " + rd10 + " " + rd11 + " " + rd12 + " " + rd13 + " " + rd14 + " " + rd15 + " " + rd16 + " " + rd17 + " " + rd18 + " " + rd19 + " " + rd20 + " " + rd21 + " " + rd22 + " " + rd23 + " " + rd24 + " " + rd25 + " " + rd26 + " " + rd27 + " " + rd28 + " " + rd29 + " " + rd30 + " " + rd31 + " " + rd32 + " " + rd33 + " " + rd34 + " " + rd35 + " " + rd36 + " " + rd37 + " " + rd38 + " " + rd39 + " " + rd40 + " " + rd41 + " " + rd42 + " " + rd43 + " " + rd44 + " " + rd45 + " " + rd46 + " " + rd47 + " " + rd48 + " " + rd49 + " " + rd50 + " " + rd51 + " " + rd52 + " " + rd53 + " " + rd54 + " " + rd55 + " " + rd56 + " " + rd57 + " " + rd58 + " " + rd59 + " " + rd60 + " " + rd61 + " " + rd62 + " " + w1 + " " + w2 + " " + w3 + " " + w4 + " " + w5 + " " + w6 + " " + w7 + " " + w8 + " " + w9 + " " + w10 + " " + w11 + " " + w12 + " " + w13 + " " + w14 + " " + w15 + " " + s1 + " " + s2 + " " + s3 + " " + s4 + " " + s5 + " " + s6 + " " + s7 + " " + s8 + " " + s9 + " " + s10;
                        ProcessStartInfo DLLReg = new ProcessStartInfo(strCMD, com);
                        DLLReg.RedirectStandardOutput = true;
                        DLLReg.RedirectStandardInput = true;
                        DLLReg.UseShellExecute = false;
                        DLLReg.CreateNoWindow = true;
                        Process procDLL = new Process();
                        procDLL.StartInfo = DLLReg;
                        procDLL.Start();
                        LOG_TEXT.Append("All RMS, WM and System DLLs Registered successfully!");
                        LOG_TEXT.AppendLine("");
                        
                    }
                    catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");
                        
                    }
                    string strRMSTools = folderBrowserDialog2.SelectedPath;
                    strRMSTools = strRMSTools.Replace("\"", "\\");
                    string strDECOMPERMS = strRMSTools + "\\dcomperm.exe";
                    string c1 = @" -ma set " + RMSIISUser.Text + " permit level:l,r";
                    string c2 = @" -ml set " + RMSIISUser.Text + " permit level:l,r,ll,la,rl,ra";
                    string c3 = @" -da set " + RMSIISUser.Text + " permit level:l,r";
                    string c4 = @" -dl set " + RMSIISUser.Text + " permit level:l,r,ll,la,rl,ra";
                    string c5 = @" -ma set " + RMSCOMUser.Text + " permit level:l,r";
                    string c6 = @" -ml set " + RMSCOMUser.Text + " permit level:l,r,ll,la,rl,ra";
                    string c7 = @" -da set " + RMSCOMUser.Text + " permit level:l,r";
                    string c8 = @" -dl set " + RMSCOMUser.Text + " permit level:l,r,ll,la,rl,ra";
                    LOG_TEXT.Append("Altering the COM+ Permissions.");
                    LOG_TEXT.AppendLine("");
                    
                    try
                    {
                        ProcessStartInfo ComPems = new ProcessStartInfo(strDECOMPERMS, c1);
                        ComPems.RedirectStandardOutput = true;
                        ComPems.RedirectStandardInput = true;
                        ComPems.UseShellExecute = false;
                        ComPems.CreateNoWindow = true;
                        Process procComPems = new Process();
                        procComPems.StartInfo = ComPems;
                        procComPems.Start();
                        string result = procComPems.StandardOutput.ReadToEnd();
                        // Display the command output.
                        LOG_TEXT.Append(result);
                        LOG_TEXT.AppendLine("");
                        
                    }
                    catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");
                        
                    }
                    try
                    {
                        ProcessStartInfo ComPems = new ProcessStartInfo(strDECOMPERMS, c2);
                        ComPems.RedirectStandardOutput = true;
                        ComPems.RedirectStandardInput = true;
                        ComPems.UseShellExecute = false;
                        ComPems.CreateNoWindow = true;
                        Process procComPems = new Process();
                        procComPems.StartInfo = ComPems;
                        procComPems.Start();
                        string result = procComPems.StandardOutput.ReadToEnd();
                        // Display the command output.
                        LOG_TEXT.Append(result);
                        LOG_TEXT.AppendLine("");
                        
                    }
                    catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");
                        
                    }
                    try
                    {
                        ProcessStartInfo ComPems = new ProcessStartInfo(strDECOMPERMS, c3);
                        ComPems.RedirectStandardOutput = true;
                        ComPems.RedirectStandardInput = true;
                        ComPems.UseShellExecute = false;
                        ComPems.CreateNoWindow = true;
                        Process procComPems = new Process();
                        procComPems.StartInfo = ComPems;
                        procComPems.Start();
                        string result = procComPems.StandardOutput.ReadToEnd();
                        // Display the command output.
                        LOG_TEXT.Append(result);
                        LOG_TEXT.AppendLine("");
                        
                    }
                    catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");
                        
                    }
                    try
                    {
                        ProcessStartInfo ComPems = new ProcessStartInfo(strDECOMPERMS, c4);
                        ComPems.RedirectStandardOutput = true;
                        ComPems.RedirectStandardInput = true;
                        ComPems.UseShellExecute = false;
                        ComPems.CreateNoWindow = true;
                        Process procComPems = new Process();
                        procComPems.StartInfo = ComPems;
                        procComPems.Start();
                        string result = procComPems.StandardOutput.ReadToEnd();
                        // Display the command output.
                        LOG_TEXT.Append(result);
                        LOG_TEXT.AppendLine("");
                        
                    }
                    catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");
                        
                    }
                    try
                    {
                        ProcessStartInfo ComPems = new ProcessStartInfo(strDECOMPERMS, c5);
                        ComPems.RedirectStandardOutput = true;
                        ComPems.RedirectStandardInput = true;
                        ComPems.UseShellExecute = false;
                        ComPems.CreateNoWindow = true;
                        Process procComPems = new Process();
                        procComPems.StartInfo = ComPems;
                        procComPems.Start();
                        string result = procComPems.StandardOutput.ReadToEnd();
                        LOG_TEXT.Append(result);
                        LOG_TEXT.AppendLine("");
                        
                    }
                    catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");
                        
                    }
                    try
                    {
                        ProcessStartInfo ComPems = new ProcessStartInfo(strDECOMPERMS, c6);
                        ComPems.RedirectStandardOutput = true;
                        ComPems.RedirectStandardInput = true;
                        ComPems.UseShellExecute = false;
                        ComPems.CreateNoWindow = true;
                        Process procComPems = new Process();
                        procComPems.StartInfo = ComPems;
                        procComPems.Start();
                        string result = procComPems.StandardOutput.ReadToEnd();
                        LOG_TEXT.Append(result);
                        LOG_TEXT.AppendLine("");
                        
                    }
                    catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");
                        
                    }
                    try
                    {
                        ProcessStartInfo ComPems = new ProcessStartInfo(strDECOMPERMS, c7);
                        ComPems.RedirectStandardOutput = true;
                        ComPems.RedirectStandardInput = true;
                        ComPems.UseShellExecute = false;
                        ComPems.CreateNoWindow = true;
                        Process procComPems = new Process();
                        procComPems.StartInfo = ComPems;
                        procComPems.Start();
                        string result = procComPems.StandardOutput.ReadToEnd();
                        LOG_TEXT.Append(result);
                        LOG_TEXT.AppendLine("");
                        
                    }
                    catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");
                        
                    }
                    try
                    {
                        ProcessStartInfo ComPems = new ProcessStartInfo(strDECOMPERMS, c8);
                        ComPems.RedirectStandardOutput = true;
                        ComPems.RedirectStandardInput = true;
                        ComPems.UseShellExecute = false;
                        ComPems.CreateNoWindow = true;
                        Process procComPems = new Process();
                        procComPems.StartInfo = ComPems;
                        procComPems.Start();
                        string result = procComPems.StandardOutput.ReadToEnd();
                        LOG_TEXT.Append(result);
                        LOG_TEXT.AppendLine("");
                        
                    }
                    catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");
                        
                    }
                    string rootKey = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\MSDTC\\Security\\";
                    string keyName1 = "LuTransactions";
                    string keyName2 = "NetworkDtcAccess";
                    string keyName3 = "NetworkDtcAccessAdmin";
                    string keyName4 = "NetworkDtcAccessClients";
                    string keyName5 = "NetworkDtcAccessInbound";
                    string keyName6 = "NetworkDtcAccessOutbound";
                    string keyName7 = "NetworkDtcAccessTransactions";
                    LOG_TEXT.Append("Adjusting DTC Security.");
                    LOG_TEXT.AppendLine("");
                    
                    try
                    {
                        Registry.SetValue(rootKey, keyName1, 1);
                        Registry.SetValue(rootKey, keyName2, 1);
                        Registry.SetValue(rootKey, keyName3, 1);
                        Registry.SetValue(rootKey, keyName4, 1);
                        Registry.SetValue(rootKey, keyName5, 1);
                        Registry.SetValue(rootKey, keyName6, 1);
                        Registry.SetValue(rootKey, keyName7, 1);
                        LOG_TEXT.Append("Finished Adjusting DTC Security.");
                        LOG_TEXT.AppendLine("");
                        
                    }
                    catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");
                        
                    }
                    if (checkBox34.Checked == true)
                    {
                        
                    }
                    string strRMSv50 = folderBrowserDialog5.SelectedPath;
                    strRMSv50 = strRMSv50.Replace("\"", "\\");
                    string strRMSWMDLLs = folderBrowserDialog6.SelectedPath;
                    strRMSWMDLLs = strRMSWMDLLs.Replace("\"", "\\");

                    string filePath = strRMSv50 + "\\coms.vbs";
                    if (checkBox34.Checked == true)
                    {
                        string lines = "Dim catalog\r\nDim applications\r\nDim application\r\nDim application2\r\nSet catalog = CreateObject(\"COMAdmin.COMAdminCatalog\")\r\nSet applications = catalog.GetCollection(\"Applications\")\r\nCall applications.Populate\r\nSet application = applications.Add()\r\napplication.Value(\"ID\") = \"{da2d72e3-f402-4f98-a415-66d21dafc0a9}\"\r\napplication.Value(\"Name\") = \"RMS\"\r\napplication.Value(\"Activation\") = 1\r\napplication.Value(\"ApplicationAccessChecksEnabled\") = 0\r\napplication.Value(\"Description\") = \"RMS\"\r\napplication.Value(\"Identity\") = \"" + RMSCOMUser.Text + "\"\r\napplication.Value(\"Password\") = \"" + RMSCOMPass.Text + "\"\r\napplication.Value(\"RunForever\") = True\r\nCall applications.SaveChanges\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL1 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL2 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL3 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL4 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL5 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL6 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL7 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL8 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL9 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL10 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL11 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL12 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL13 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL14 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL15 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL16 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL17 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL18 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL19 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL20 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL21 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL22 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL23 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL24 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL25 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL26 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL27 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL28 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL29 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL30 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL31 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL32 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL33 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL34 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL35 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL36 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL37 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL38 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL39 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL40 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL41 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL42 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL43 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL44 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL45 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL46 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL47 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL48 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL49 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL50 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL51 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL52 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL53 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL54 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL55 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL56 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL57 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL58 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL59 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL60 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL61 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL62 + "\",\"\",\"\"\r\nDim roles\r\nSet roles = applications.GetCollection(\"Roles\", \"{da2d72e3-f402-4f98-a415-66d21dafc0a9}\")\r\nDim role\r\nSet role = roles.Add\r\nrole.Value(\"Name\") = \"CreatorOwner\"\r\nroles.SaveChanges\r\nDim users\r\nSet users = roles.GetCollection(\"UsersInRole\", role.Key)\r\nDim user\r\nSet user = users.Add\r\nuser.Value(\"User\") = \"" + RMSCOMUser.Text + "\"\r\nusers.SaveChanges\r\nSet application = Nothing\r\nSet application = applications.Add()\r\napplication.Value(\"ID\") = \"{da2d72e3-f402-4f98-a415-76d21dafc0a9}\"\r\napplication.Value(\"Name\") = \"WM\"\r\napplication.Value(\"Activation\") = 1\r\napplication.Value(\"ApplicationAccessChecksEnabled\") = 0\r\napplication.Value(\"Description\") = \"WM\"\r\napplication.Value(\"Identity\") = \"" + RMSCOMUser.Text + "\"\r\napplication.Value(\"Password\") = \"" + RMSCOMPass.Text + "\"\r\napplication.Value(\"RunForever\") = True\r\nCall applications.SaveChanges\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL1 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL2 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL3 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL4 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL5 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL6 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL7 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL8 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL9 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL10 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL11 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL12 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL13 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL14 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL15 + "\",\"\",\"\"\r\nSet roles = applications.GetCollection(\"Roles\", \"{da2d72e3-f402-4f98-a415-76d21dafc0a9}\")\r\nSet role = roles.Add\r\nrole.Value(\"Name\") = \"CreatorOwner\"\r\nroles.SaveChanges\r\nSet users = roles.GetCollection(\"UsersInRole\", role.Key)\r\nSet user = users.Add\r\nuser.Value(\"User\") = \"" + RMSCOMUser.Text + "\"\r\nusers.SaveChanges\r\nSet comps = applications.GetCollection(\"Components\", \"{da2d72e3-f402-4f98-a415-66d21dafc0a9}\")\r\ncomps.Populate\r\nFor Each comp In comps\r\ncomp.Value(\"IISIntrinsics\") = true\r\ncomps.SaveChanges\r\nNext\r\nSet comps = applications.GetCollection(\"Components\", \"{da2d72e3-f402-4f98-a415-76d21dafc0a9}\")\r\ncomps.Populate\r\nFor Each comp In comps\r\ncomp.Value(\"IISIntrinsics\") = true\r\ncomps.SaveChanges\r\nNext\r\nSet comps = applications.GetCollection(\"Components\", \"{da2d72e3-f402-4f98-a415-66d21dafc0a9}\")\r\ncomps.Populate\r\nFor Each comp In comps\r\nif comp.key = \"{F0F9F62F-5634-41C2-8636-95929AE23384}\" then\r\ncomp.Value(\"MustRunInDefaultContext\") = True\r\ncomps.SaveChanges\r\nExit For\r\nEnd If\r\nNext";
                        try
                        {
                            LOG_TEXT.Append("Creating the COM+ Objects");
                            LOG_TEXT.AppendLine("");
                            
                            System.IO.StreamWriter file = new System.IO.StreamWriter(filePath);
                            file.WriteLine(lines);
                            file.Close();
                            string strCScript = "CSCRIPT";
                            ProcessStartInfo buildCOMs = new ProcessStartInfo(strCScript, filePath);
                            buildCOMs.RedirectStandardOutput = true;
                            buildCOMs.RedirectStandardInput = true;
                            buildCOMs.UseShellExecute = false;
                            buildCOMs.CreateNoWindow = true;
                            Process buildCOMsProc = new Process();
                            buildCOMsProc.StartInfo = buildCOMs;
                            buildCOMsProc.Start();
                            string resultComPerms = buildCOMsProc.StandardOutput.ReadToEnd();
                            //MessageBox.Show(result);
                            File.Delete(filePath);
                            LOG_TEXT.Append("Finished Creating the COM+ Objects");
                            LOG_TEXT.AppendLine("");
                            
                        }
                        catch (Exception ex)
                        {
                            LOG_TEXT.Append(ex.Message);
                            LOG_TEXT.AppendLine("");
                        }
                    }
                    else
                    {
                        string lines = "Dim catalog\r\nDim applications\r\nDim application\r\nDim application2\r\nSet catalog = CreateObject(\"COMAdmin.COMAdminCatalog\")\r\nSet applications = catalog.GetCollection(\"Applications\")\r\nCall applications.Populate\r\nSet application = applications.Add()\r\napplication.Value(\"ID\") = \"{da2d72e3-f402-4f98-a415-66d21dafc0a9}\"\r\napplication.Value(\"Name\") = \"RMS\"\r\napplication.Value(\"Activation\") = 1\r\napplication.Value(\"ApplicationAccessChecksEnabled\") = 0\r\napplication.Value(\"Description\") = \"RMS\"\r\napplication.Value(\"Identity\") = \"" + RMSCOMUser.Text + "\"\r\napplication.Value(\"Password\") = \"" + RMSCOMPass.Text + "\"\r\napplication.Value(\"RunForever\") = True\r\nCall applications.SaveChanges\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL1 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL2 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL3 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL4 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL5 + "\",\"\",\"\"\r\nREM catalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL6 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL7 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL8 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL9 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL10 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL11 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL12 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL13 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL14 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL15 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL16 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL17 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL18 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL19 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL20 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL21 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL22 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL23 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL24 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL25 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL26 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL27 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL28 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL29 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL30 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL31 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL32 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL33 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL34 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL35 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL36 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL37 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL38 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL39 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL40 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL41 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL42 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL43 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL44 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL45 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL46 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL47 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL48 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL49 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL50 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL51 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL52 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL53 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL54 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL55 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL56 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL57 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL58 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL59 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL60 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL61 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"RMS\", \"" + RMSv50Share.Text + "\\RMSDLLs\\" + DLL62 + "\",\"\",\"\"\r\nDim roles\r\nSet roles = applications.GetCollection(\"Roles\", \"{da2d72e3-f402-4f98-a415-66d21dafc0a9}\")\r\nDim role\r\nSet role = roles.Add\r\nrole.Value(\"Name\") = \"CreatorOwner\"\r\nroles.SaveChanges\r\nDim users\r\nSet users = roles.GetCollection(\"UsersInRole\", role.Key)\r\nDim user\r\nSet user = users.Add\r\nuser.Value(\"User\") = \"" + RMSCOMUser.Text + "\"\r\nusers.SaveChanges\r\nSet application = Nothing\r\nSet application = applications.Add()\r\napplication.Value(\"ID\") = \"{da2d72e3-f402-4f98-a415-76d21dafc0a9}\"\r\napplication.Value(\"Name\") = \"WM\"\r\napplication.Value(\"Activation\") = 1\r\napplication.Value(\"ApplicationAccessChecksEnabled\") = 0\r\napplication.Value(\"Description\") = \"WM\"\r\napplication.Value(\"Identity\") = \"" + RMSCOMUser.Text + "\"\r\napplication.Value(\"Password\") = \"" + RMSCOMPass.Text + "\"\r\napplication.Value(\"RunForever\") = True\r\nCall applications.SaveChanges\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL1 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL2 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL3 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL4 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL5 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL6 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL7 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL8 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL9 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL10 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL11 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL12 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL13 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL14 + "\",\"\",\"\"\r\ncatalog.InstallComponent \"WM\", \"" + strRMSWMDLLs + "\\" + WMDLL15 + "\",\"\",\"\"\r\nSet roles = applications.GetCollection(\"Roles\", \"{da2d72e3-f402-4f98-a415-76d21dafc0a9}\")\r\nSet role = roles.Add\r\nrole.Value(\"Name\") = \"CreatorOwner\"\r\nroles.SaveChanges\r\nSet users = roles.GetCollection(\"UsersInRole\", role.Key)\r\nSet user = users.Add\r\nuser.Value(\"User\") = \"" + RMSCOMUser.Text + "\"\r\nusers.SaveChanges\r\nSet comps = applications.GetCollection(\"Components\", \"{da2d72e3-f402-4f98-a415-66d21dafc0a9}\")\r\ncomps.Populate\r\nFor Each comp In comps\r\ncomp.Value(\"IISIntrinsics\") = true\r\ncomps.SaveChanges\r\nNext\r\nSet comps = applications.GetCollection(\"Components\", \"{da2d72e3-f402-4f98-a415-76d21dafc0a9}\")\r\ncomps.Populate\r\nFor Each comp In comps\r\ncomp.Value(\"IISIntrinsics\") = true\r\ncomps.SaveChanges\r\nNext\r\nSet comps = applications.GetCollection(\"Components\", \"{da2d72e3-f402-4f98-a415-66d21dafc0a9}\")\r\ncomps.Populate\r\nFor Each comp In comps\r\nif comp.key = \"{F0F9F62F-5634-41C2-8636-95929AE23384}\" then\r\ncomp.Value(\"MustRunInDefaultContext\") = True\r\ncomps.SaveChanges\r\nExit For\r\nEnd If\r\nNext";
                        try
                        {
                            LOG_TEXT.Append("Creating the COM+ Objects");
                            LOG_TEXT.AppendLine("");
                            
                            System.IO.StreamWriter file = new System.IO.StreamWriter(filePath);
                            file.WriteLine(lines);
                            file.Close();
                            string strCScript = "CSCRIPT";
                            ProcessStartInfo buildCOMs = new ProcessStartInfo(strCScript, filePath);
                            buildCOMs.RedirectStandardOutput = true;
                            buildCOMs.RedirectStandardInput = true;
                            buildCOMs.UseShellExecute = false;
                            buildCOMs.CreateNoWindow = true;
                            Process buildCOMsProc = new Process();
                            buildCOMsProc.StartInfo = buildCOMs;
                            buildCOMsProc.Start();
                            string resultComPerms = buildCOMsProc.StandardOutput.ReadToEnd();
                            //MessageBox.Show(result);
                            File.Delete(filePath);
                            LOG_TEXT.Append("Finished Creating the COM+ Objects");
                            LOG_TEXT.AppendLine("");
                            
                        }
                        catch (Exception ex)
                        {
                            LOG_TEXT.Append(ex.Message);
                            LOG_TEXT.AppendLine("");
                            
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
            }
            else if (checkBox9.Checked == false)
            {
                LOG_TEXT.Append("Create and Setup COM Objects checkbox was not checked.");
                LOG_TEXT.AppendLine("");
                
            }
            //Set BackConnectionHostNames, OptionalNames, and DisableStrictNameChecking in Registry
            ProcessTextBox.Text = ProcessTextBox.Text + "Setting BackConnectionHostNames, OptionalNames, and DisableStrictNameChecking............";
            if (checkBox14.Checked == true)
            {
                
                    RegistryKey rk = Registry.LocalMachine;
                    RegistryKey rk1 = rk.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Lsa\\MSV1_0\\", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                    RegistryKey rk2 = rk.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\lanmanserver\\parameters", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                    LOG_TEXT.Append("Setting BackConnectionHostNames, OptionalNames, and DisableStrictNameChecking in Registry.");
                    LOG_TEXT.AppendLine("");
                    
                    try
                    {
                        rk1.SetValue("BackConnectionHostNames", new string [] {BackConHostName.Text}, RegistryValueKind.MultiString);
                        rk2.SetValue("OptionalNames", new string [] {BackConHostName.Text}, RegistryValueKind.MultiString);
                        rk2.SetValue("DisableStrictNameChecking", 1, RegistryValueKind.DWord);
                        LOG_TEXT.Append("Finished Setting BackConnectionHostNames, OptionalNames, and DisableStrictNameChecking in Registry.");
                        LOG_TEXT.AppendLine("");
                        
                    }
                    catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");
                        
                    }
            }
            else if (checkBox14.Checked == false)
            {
                LOG_TEXT.Append("Set BackConnectionHostNames, OptionalNames, and DisableStrictNameChecking in Registry checkbox was not checked.");
                LOG_TEXT.AppendLine("");
                
            }
            //Register Payflow dotNet.dll using Regasm
            ProcessTextBox.Text = ProcessTextBox.Text + "Registering PayflowdotNet.dll............";
            if (checkBox15.Checked == true)
            {
                
                    try
                    {
                        string strSysWow = openFileDialog1.FileName;
                        strSysWow = strSysWow.Replace("regsvr32.exe", "Payflow_dotNET.dll");
                        string lines = @" " + strSysWow;
                        LOG_TEXT.Append("Registering Payflow dotNet.dll using Regasm.");
                        LOG_TEXT.AppendLine("");

                        string strCScript = @"C:\windows\Microsoft.NET\Framework\v2.0.50727\regasm.exe";

                        ProcessStartInfo regasmPay = new ProcessStartInfo(strCScript, lines);
                        regasmPay.RedirectStandardOutput = true;
                        regasmPay.RedirectStandardInput = true;
                        regasmPay.UseShellExecute = false;
                        regasmPay.CreateNoWindow = true;
                        Process regasmPayProc = new Process();
                        regasmPayProc.StartInfo = regasmPay;
                        regasmPayProc.Start();
                        string resultregasmPay = regasmPayProc.StandardOutput.ReadToEnd();
                        LOG_TEXT.Append(resultregasmPay);
                        LOG_TEXT.AppendLine("");
                        
                        //File.Delete(filePath);
                    }
                    catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");
                        
                    }
                }
            else if (checkBox15.Checked == false)
            {
                LOG_TEXT.Append("Register Payflow dotNet.dll using Regasm checkbox was not checked.");
                LOG_TEXT.AppendLine("");
                
            }
            //Add Metabase Permissions
            ProcessTextBox.Text = ProcessTextBox.Text + "Adding Metabase Permissions............";
            if (checkBox16.Checked == true)
            {
                try
                {
                    
                    LOG_TEXT.Append("Adding Metabase permissions for the " + RMSIISUser.Text + " user." );
                    LOG_TEXT.AppendLine("");
                    
                    string strCMD1 = "CSCRIPT";
                    string strDLL1 = " /s " + InetpubLocation.Text + "\\adminscripts\\adadd.vbs " + RMSIISUser.Text;
                    ProcessStartInfo MetaPerm1 = new ProcessStartInfo(strCMD1, strDLL1);
                    MetaPerm1.RedirectStandardOutput = true;
                    MetaPerm1.RedirectStandardInput = true;
                    MetaPerm1.UseShellExecute = false;
                    MetaPerm1.CreateNoWindow = true;
                    Process MetaPermProc1 = new Process();
                    MetaPermProc1.StartInfo = MetaPerm1;
                    MetaPermProc1.Start();
                    string result = MetaPermProc1.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                    LOG_TEXT.Append("Adding Metabase permissions for the " + RMSCOMUser.Text + " user.");
                    LOG_TEXT.AppendLine("");
                    
                    string strCMD2 = "CSCRIPT";
                    string strDLL2 = " /s " + InetpubLocation.Text + "\\adminscripts\\adadd.vbs " + RMSCOMUser.Text;
                    ProcessStartInfo MetaPerm2 = new ProcessStartInfo(strCMD2, strDLL2);
                    MetaPerm2.RedirectStandardOutput = true;
                    MetaPerm2.RedirectStandardInput = true;
                    MetaPerm2.UseShellExecute = false;
                    MetaPerm2.CreateNoWindow = true;
                    Process MetaPermProc2 = new Process();
                    MetaPermProc2.StartInfo = MetaPerm2;
                    MetaPermProc2.Start();
                    string result2 = MetaPermProc2.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result2);
                    LOG_TEXT.AppendLine("");
                    
                    LOG_TEXT.Append("Adding Metabase permissions for the Builtin\\IIS_IUSRS group.");
                    LOG_TEXT.AppendLine("");
                    
                    string strCMD3 = "CSCRIPT";
                    string strDLL3 = " /s " + InetpubLocation.Text + "\\adminscripts\\adadd.vbs Builtin\\IIS_IUSRS";
                    ProcessStartInfo MetaPerm3 = new ProcessStartInfo(strCMD3, strDLL3);
                    MetaPerm3.RedirectStandardOutput = true;
                    MetaPerm3.RedirectStandardInput = true;
                    MetaPerm3.UseShellExecute = false;
                    MetaPerm3.CreateNoWindow = true;
                    Process MetaPermProc3 = new Process();
                    MetaPermProc3.StartInfo = MetaPerm3;
                    MetaPermProc3.Start();
                    string result3 = MetaPermProc3.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result3);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
            }
            else if (checkBox16.Checked == false)
            {
                LOG_TEXT.Append("Add Metabase Permissions checkbox was not checked.");
                LOG_TEXT.AppendLine("");
                
            }
            //Set Asp Script errors to be sent to the browser
            ProcessTextBox.Text = ProcessTextBox.Text + "Set ASP Sciprt errors to be sent to the browser............";
            if (checkBox17.Checked == true)
            {
                
                try
                {
                    LOG_TEXT.Append("Set Asp Script errors to be sent to the browser.");
                    LOG_TEXT.AppendLine("");
                    
                    string strCMD = "CSCRIPT";
                    string strDLL = " /s " + InetpubLocation.Text + "\\adminscripts\\adsutil.vbs set w3svc/AspScriptErrorSentToBrowser true";
                    ProcessStartInfo ScriptErr = new ProcessStartInfo(strCMD, strDLL);
                    ScriptErr.RedirectStandardOutput = true;
                    ScriptErr.RedirectStandardInput = true;
                    ScriptErr.UseShellExecute = false;
                    ScriptErr.CreateNoWindow = true;
                    Process ScriptErrProc = new Process();
                    ScriptErrProc.StartInfo = ScriptErr;
                    ScriptErrProc.Start();
                    string result = ScriptErrProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
            }
            else if (checkBox17.Checked == false)
            {
                LOG_TEXT.Append("Set Asp Script errors to be sent to the browser checkbox was not checked.");
                LOG_TEXT.AppendLine("");
                
            }
            //ASP Max Request Entity Allowed
            ProcessTextBox.Text = ProcessTextBox.Text + "Setting the ASP Max Request Entity allowed............";
            if (checkBox18.Checked == true)
            {
                
                try
                {
                LOG_TEXT.Append("Set Max Request Entity Allowed.");
                LOG_TEXT.AppendLine("");
                
                string strRegSvrPath = openFileDialog1.FileName;
                strRegSvrPath = strRegSvrPath.Replace("\\regsvr32.exe", "\\inetsrv\\appcmd");
                strRegSvrPath = strRegSvrPath.Replace("\"", "\\");
                string strCMD = strRegSvrPath;
                string strCMD1 = "set config -section:asp -limits.maxRequestEntityAllowed:1073741824";
                ProcessStartInfo ASPMax = new ProcessStartInfo(strCMD, strCMD1);
                ASPMax.RedirectStandardOutput = true;
                ASPMax.RedirectStandardInput = true;
                ASPMax.UseShellExecute = false;
                ASPMax.CreateNoWindow = true;
                Process ASPMaxProc = new Process();
                ASPMaxProc.StartInfo = ASPMax;
                ASPMaxProc.Start();
                string resultASPMax = ASPMaxProc.StandardOutput.ReadToEnd();
                // Display the command output.
                LOG_TEXT.Append(resultASPMax);
                LOG_TEXT.AppendLine("");
                
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
            }
            else if (checkBox18.Checked == false)
            {
                LOG_TEXT.Append("ASP Max Request Entity Allowed checkbox was not checked.");
                LOG_TEXT.AppendLine("");
                
            }
            //Create RMS and RMSStud App Pools
            ProcessTextBox.Text = ProcessTextBox.Text + "Creating the RMS and RMSStud App pools............";
            if (checkBox19.Checked == true)
            {
                
                string strRegSvrPath = openFileDialog1.FileName;
                strRegSvrPath = strRegSvrPath.Replace("\\regsvr32.exe", "\\inetsrv\\appcmd");
                strRegSvrPath = strRegSvrPath.Replace("\"", "\\");
                string strCMD = strRegSvrPath;
                try
                {
                    LOG_TEXT.Append("Creating " + RMSAppPoolName.Text + " app pool.");
                    LOG_TEXT.AppendLine("");
                    
                string strCMD1 = "add apppool /name:" + RMSAppPoolName.Text + " /managedRuntimeVersion: /managedPipelineMode:Classic /autoStart:true /enable32BitAppOnWin64:true /processModel.identityType:NetworkService /failure.rapidFailProtection:false";
                ProcessStartInfo RMSApp = new ProcessStartInfo(strCMD, strCMD1);
                RMSApp.RedirectStandardOutput = true;
                RMSApp.RedirectStandardInput = true;
                RMSApp.UseShellExecute = false;
                RMSApp.CreateNoWindow = true;
                Process RMSAppProc = new Process();
                RMSAppProc.StartInfo = RMSApp;
                RMSAppProc.Start();
                string resultRMSApp = RMSAppProc.StandardOutput.ReadToEnd();
                // Display the command output.
                LOG_TEXT.Append(resultRMSApp);
                LOG_TEXT.AppendLine("");
                
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                try
                {
                    LOG_TEXT.Append("Creating " + SWAppPoolName.Text + " app pool.");
                    LOG_TEXT.AppendLine("");
                    
                    string strCMD1 = "add apppool /name:" + SWAppPoolName.Text + " /managedRuntimeVersion: /managedPipelineMode:Classic /autoStart:true /enable32BitAppOnWin64:true /processModel.identityType:NetworkService /failure.rapidFailProtection:false";
                    ProcessStartInfo SWApp = new ProcessStartInfo(strCMD, strCMD1);
                    SWApp.RedirectStandardOutput = true;
                    SWApp.RedirectStandardInput = true;
                    SWApp.UseShellExecute = false;
                    SWApp.CreateNoWindow = true;
                    Process SWAppProc = new Process();
                    SWAppProc.StartInfo = SWApp;
                    SWAppProc.Start();
                    string resultSWApp = SWAppProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultSWApp);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
            }
            else if (checkBox19.Checked == false)
            {
                LOG_TEXT.Append("Create RMS and RMSStud App Pools checkbox was not checked.");
                LOG_TEXT.AppendLine("");
                
            }
            //Create RMS and RMSStud Websites
            ProcessTextBox.Text = ProcessTextBox.Text + "Creating the RMS and RMSStud Websites............";
            if (checkBox20.Checked == true)
            {
                
                string strRegSvrPath = openFileDialog1.FileName;
                strRegSvrPath = strRegSvrPath.Replace("\\regsvr32.exe", "\\inetsrv\\appcmd");
                strRegSvrPath = strRegSvrPath.Replace("\"", "\\");
                string strCMD = strRegSvrPath;

                try
                {
                    string strdelDefSite = " delete site \"Default Web Site\"";
                    string strCMD1 = " add site /name:" + RMSSiteName.Text + " /id:5 /bindings:http/*:" + RMSPort.Text + ": /physicalPath:" + RMSShare.Text + " /virtualDirectoryDefaults.userName:" + RMSIISUser.Text + " /virtualDirectoryDefaults.password:" + RMSIISPass.Text + " /applicationDefaults.applicationPool:" + RMSAppPoolName.Text;
                    string strCMD2 = " set config \"" + RMSSiteName.Text + "\" -section:system.webServer/security/authentication/anonymousAuthentication /enabled:\"True\" /userName:\"" + RMSIISUser.Text + "\" /password:\"" + RMSIISPass.Text + "\" /commit:apphost";
                    string strCMD3a = " set config \"" + RMSSiteName.Text + "\" -section:defaultDocument /-files.[value='Login.asp']";
                    string strCMD3b = " set config \"" + RMSSiteName.Text + "\" -section:defaultDocument /-files.[value='Default.asp']";
                    string strCMD3c = " set config \"" + RMSSiteName.Text + "\" -section:defaultDocument /-files.[value='Default.htm']";
                    string strCMD3d = " set config \"" + RMSSiteName.Text + "\" -section:defaultDocument /-files.[value='index.htm']";
                    string strCMD3e = " set config \"" + RMSSiteName.Text + "\" -section:defaultDocument /-files.[value='index.html']";
                    string strCMD3f = " set config \"" + RMSSiteName.Text + "\" -section:defaultDocument /-files.[value='iisstart.htm']";
                    string strCMD3g = " set config \"" + RMSSiteName.Text + "\" -section:defaultDocument /-files.[value='default.aspx']";
                    string strCMD4 = " set config \"" + RMSSiteName.Text + "\" -section:defaultDocument /+files.[value='Login.asp'] /commit:apphost";
                    string strCMD5 = " add site /name:" + SWSiteName.Text + " /id:6 /bindings:http/*:" + SWPort.Text + ": /physicalPath:" + SWShare.Text + "\\WebModule-Student /virtualDirectoryDefaults.userName:" + RMSIISUser.Text + " /virtualDirectoryDefaults.password:" + RMSIISPass.Text + " /applicationDefaults.applicationPool:" + SWAppPoolName.Text;
                    string strCMD6 = " set config \"" + SWSiteName.Text + "\" -section:system.webServer/security/authentication/anonymousAuthentication /enabled:\"True\" /userName:\"" + RMSIISUser.Text + "\" /password:\"" + RMSIISPass.Text + "\" /commit:apphost";
                    string strCMD7a = " set config \"" + SWSiteName.Text + "\" -section:defaultDocument /-files.[value='Login.asp']";
                    string strCMD7b = " set config \"" + SWSiteName.Text + "\" -section:defaultDocument /-files.[value='Default.asp']";
                    string strCMD7c = " set config \"" + SWSiteName.Text + "\" -section:defaultDocument /-files.[value='Default.htm']";
                    string strCMD7d = " set config \"" + SWSiteName.Text + "\" -section:defaultDocument /-files.[value='index.htm']";
                    string strCMD7e = " set config \"" + SWSiteName.Text + "\" -section:defaultDocument /-files.[value='index.html']";
                    string strCMD7f = " set config \"" + SWSiteName.Text + "\" -section:defaultDocument /-files.[value='iisstart.htm']";
                    string strCMD7g = " set config \"" + SWSiteName.Text + "\" -section:defaultDocument /-files.[value='default.aspx']";
                    string strCMD8 = " set config \"" + SWSiteName.Text + "\" -section:defaultDocument /+files.[value='Index.asp']";

                    //MessageBox.Show(strCMD + strCMD1);
                    LOG_TEXT.Append("Deleting the Default Website.");
                    LOG_TEXT.AppendLine("");
                    ProcessStartInfo DefSite = new ProcessStartInfo(strCMD, strdelDefSite);
                    DefSite.RedirectStandardOutput = true;
                    DefSite.RedirectStandardInput = true;
                    DefSite.UseShellExecute = false;
                    DefSite.CreateNoWindow = true;
                    Process DefSiteProc = new Process();
                    DefSiteProc.StartInfo = DefSite;
                    DefSiteProc.Start();
                    string resultDefSite = DefSiteProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultDefSite);
                    LOG_TEXT.AppendLine("");
                    
                    //MessageBox.Show(strCMD + strCMD1);
                    LOG_TEXT.Append("Creating " + RMSSiteName.Text + " Website.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RMSSite = new ProcessStartInfo(strCMD, strCMD1);
                    RMSSite.RedirectStandardOutput = true;
                    RMSSite.RedirectStandardInput = true;
                    RMSSite.UseShellExecute = false;
                    RMSSite.CreateNoWindow = true;
                    Process RMSSiteProc = new Process();
                    RMSSiteProc.StartInfo = RMSSite;
                    RMSSiteProc.Start();
                    string resultRMSSite = RMSSiteProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRMSSite);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Setting the " + RMSIISUser.Text + " as the Anonymous User for the RMS Website.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo SetRMSAnon = new ProcessStartInfo(strCMD, strCMD2);
                    SetRMSAnon.RedirectStandardOutput = true;
                    SetRMSAnon.RedirectStandardInput = true;
                    SetRMSAnon.UseShellExecute = false;
                    SetRMSAnon.CreateNoWindow = true;
                    Process SetRMSAnonProc = new Process();
                    SetRMSAnonProc.StartInfo = SetRMSAnon;
                    SetRMSAnonProc.Start();
                    string resultSetRMSAnon = SetRMSAnonProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultSetRMSAnon);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the Login.asp as the RMS default webpage if it already exists.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemRMSDefAPage = new ProcessStartInfo(strCMD, strCMD3a);
                    RemRMSDefAPage.RedirectStandardOutput = true;
                    RemRMSDefAPage.RedirectStandardInput = true;
                    RemRMSDefAPage.UseShellExecute = false;
                    RemRMSDefAPage.CreateNoWindow = true;
                    Process RemRMSDefAPageProc = new Process();
                    RemRMSDefAPageProc.StartInfo = RemRMSDefAPage;
                    RemRMSDefAPageProc.Start();
                    string resultRemRMSDefAPage = RemRMSDefAPageProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemRMSDefAPage);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the Default.asp as the RMS default webpage if it exists.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemRMSDefBPage = new ProcessStartInfo(strCMD, strCMD3b);
                    RemRMSDefBPage.RedirectStandardOutput = true;
                    RemRMSDefBPage.RedirectStandardInput = true;
                    RemRMSDefBPage.UseShellExecute = false;
                    RemRMSDefBPage.CreateNoWindow = true;
                    Process RemRMSDefBPageProc = new Process();
                    RemRMSDefBPageProc.StartInfo = RemRMSDefBPage;
                    RemRMSDefBPageProc.Start();
                    string resultRemRMSDefBPage = RemRMSDefBPageProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemRMSDefBPage);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the Default.htm as the RMS default webpage if it exists.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemRMSDefCPage = new ProcessStartInfo(strCMD, strCMD3c);
                    RemRMSDefCPage.RedirectStandardOutput = true;
                    RemRMSDefCPage.RedirectStandardInput = true;
                    RemRMSDefCPage.UseShellExecute = false;
                    RemRMSDefCPage.CreateNoWindow = true;
                    Process RemRMSDefCPageProc = new Process();
                    RemRMSDefCPageProc.StartInfo = RemRMSDefCPage;
                    RemRMSDefCPageProc.Start();
                    string resultRemRMSDefCPage = RemRMSDefCPageProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemRMSDefCPage);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the index.htm as the RMS default webpage if it exists.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemRMSDefDPage = new ProcessStartInfo(strCMD, strCMD3d);
                    RemRMSDefDPage.RedirectStandardOutput = true;
                    RemRMSDefDPage.RedirectStandardInput = true;
                    RemRMSDefDPage.UseShellExecute = false;
                    RemRMSDefDPage.CreateNoWindow = true;
                    Process RemRMSDefDPageProc = new Process();
                    RemRMSDefDPageProc.StartInfo = RemRMSDefDPage;
                    RemRMSDefDPageProc.Start();
                    string resultRemRMSDefDPage = RemRMSDefDPageProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemRMSDefDPage);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the index.html as the RMS default webpage if it exists.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemRMSDefEPage = new ProcessStartInfo(strCMD, strCMD3e);
                    RemRMSDefEPage.RedirectStandardOutput = true;
                    RemRMSDefEPage.RedirectStandardInput = true;
                    RemRMSDefEPage.UseShellExecute = false;
                    RemRMSDefEPage.CreateNoWindow = true;
                    Process RemRMSDefEPageProc = new Process();
                    RemRMSDefEPageProc.StartInfo = RemRMSDefEPage;
                    RemRMSDefEPageProc.Start();
                    string resultRemRMSDefEPage = RemRMSDefEPageProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemRMSDefEPage);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the iisstart.htm as the RMS default webpage if it exists.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemRMSDefFPage = new ProcessStartInfo(strCMD, strCMD3f);
                    RemRMSDefFPage.RedirectStandardOutput = true;
                    RemRMSDefFPage.RedirectStandardInput = true;
                    RemRMSDefFPage.UseShellExecute = false;
                    RemRMSDefFPage.CreateNoWindow = true;
                    Process RemRMSDefFPageProc = new Process();
                    RemRMSDefFPageProc.StartInfo = RemRMSDefFPage;
                    RemRMSDefFPageProc.Start();
                    string resultRemRMSDefFPage = RemRMSDefFPageProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemRMSDefFPage);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the default.aspx as the RMS default webpage if it exists.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemRMSDefGPage = new ProcessStartInfo(strCMD, strCMD3g);
                    RemRMSDefGPage.RedirectStandardOutput = true;
                    RemRMSDefGPage.RedirectStandardInput = true;
                    RemRMSDefGPage.UseShellExecute = false;
                    RemRMSDefGPage.CreateNoWindow = true;
                    Process RemRMSDefGPageProc = new Process();
                    RemRMSDefGPageProc.StartInfo = RemRMSDefGPage;
                    RemRMSDefGPageProc.Start();
                    string resultRemRMSDefGPage = RemRMSDefGPageProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemRMSDefGPage);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Adding the Login.asp as the only RMS default webpage.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo SetRMSDefPage = new ProcessStartInfo(strCMD, strCMD4);
                    SetRMSDefPage.RedirectStandardOutput = true;
                    SetRMSDefPage.RedirectStandardInput = true;
                    SetRMSDefPage.UseShellExecute = false;
                    SetRMSDefPage.CreateNoWindow = true;
                    Process SetRMSDefPageProc = new Process();
                    SetRMSDefPageProc.StartInfo = SetRMSDefPage;
                    SetRMSDefPageProc.Start();
                    string resultSetRMSDefPage = SetRMSDefPageProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultSetRMSDefPage);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Creating " + SWSiteName.Text + " Website.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo SWSite = new ProcessStartInfo(strCMD, strCMD5);
                    SWSite.RedirectStandardOutput = true;
                    SWSite.RedirectStandardInput = true;
                    SWSite.UseShellExecute = false;
                    SWSite.CreateNoWindow = true;
                    Process SWSiteProc = new Process();
                    SWSiteProc.StartInfo = SWSite;
                    SWSiteProc.Start();
                    string resultSWSite = SWSiteProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultSWSite);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Setting the " + RMSIISUser.Text + " as the Anonymous User for the RMS Website.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo SetSWAnon = new ProcessStartInfo(strCMD, strCMD6);
                    SetSWAnon.RedirectStandardOutput = true;
                    SetSWAnon.RedirectStandardInput = true;
                    SetSWAnon.UseShellExecute = false;
                    SetSWAnon.CreateNoWindow = true;
                    Process SetSWAnonProc = new Process();
                    SetSWAnonProc.StartInfo = SetSWAnon;
                    SetSWAnonProc.Start();
                    string resultSetSWAnon = SetSWAnonProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultSetSWAnon);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the Index.asp as the default SW webpage if it already exists.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemSWDefAPage = new ProcessStartInfo(strCMD, strCMD7a);
                    RemSWDefAPage.RedirectStandardOutput = true;
                    RemSWDefAPage.RedirectStandardInput = true;
                    RemSWDefAPage.UseShellExecute = false;
                    RemSWDefAPage.CreateNoWindow = true;
                    Process RemSWDefAPageProc = new Process();
                    RemSWDefAPageProc.StartInfo = RemSWDefAPage;
                    RemSWDefAPageProc.Start();
                    string resultRemSWDefAPage = RemSWDefAPageProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemSWDefAPage);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the Default.asp as the default SW webpage if it exists.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemSWDefBPage = new ProcessStartInfo(strCMD, strCMD7b);
                    RemSWDefBPage.RedirectStandardOutput = true;
                    RemSWDefBPage.RedirectStandardInput = true;
                    RemSWDefBPage.UseShellExecute = false;
                    RemSWDefBPage.CreateNoWindow = true;
                    Process RemSWDefBPageProc = new Process();
                    RemSWDefBPageProc.StartInfo = RemSWDefBPage;
                    RemSWDefBPageProc.Start();
                    string resultRemSWDefBPage = RemSWDefBPageProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemSWDefBPage);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the Default.htm as the default SW webpage if it exists.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemSWDefCPage = new ProcessStartInfo(strCMD, strCMD7c);
                    RemSWDefCPage.RedirectStandardOutput = true;
                    RemSWDefCPage.RedirectStandardInput = true;
                    RemSWDefCPage.UseShellExecute = false;
                    RemSWDefCPage.CreateNoWindow = true;
                    Process RemSWDefCPageProc = new Process();
                    RemSWDefCPageProc.StartInfo = RemSWDefCPage;
                    RemSWDefCPageProc.Start();
                    string resultRemSWDefCPage = RemSWDefCPageProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemSWDefCPage);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the index.htm as the default SW webpage if it exists.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemSWDefDPage = new ProcessStartInfo(strCMD, strCMD7d);
                    RemSWDefDPage.RedirectStandardOutput = true;
                    RemSWDefDPage.RedirectStandardInput = true;
                    RemSWDefDPage.UseShellExecute = false;
                    RemSWDefDPage.CreateNoWindow = true;
                    Process RemSWDefDPageProc = new Process();
                    RemSWDefDPageProc.StartInfo = RemSWDefDPage;
                    RemSWDefDPageProc.Start();
                    string resultRemSWDefDPage = RemSWDefDPageProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemSWDefDPage);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the index.html as the default SW webpage if it exists.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemSWDefEPage = new ProcessStartInfo(strCMD, strCMD7e);
                    RemSWDefEPage.RedirectStandardOutput = true;
                    RemSWDefEPage.RedirectStandardInput = true;
                    RemSWDefEPage.UseShellExecute = false;
                    RemSWDefEPage.CreateNoWindow = true;
                    Process RemSWDefEPageProc = new Process();
                    RemSWDefEPageProc.StartInfo = RemSWDefEPage;
                    RemSWDefEPageProc.Start();
                    string resultRemSWDefEPage = RemSWDefEPageProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemSWDefEPage);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the iisstart.htm as the default SW webpage if it exists.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemSWDefFPage = new ProcessStartInfo(strCMD, strCMD7f);
                    RemSWDefFPage.RedirectStandardOutput = true;
                    RemSWDefFPage.RedirectStandardInput = true;
                    RemSWDefFPage.UseShellExecute = false;
                    RemSWDefFPage.CreateNoWindow = true;
                    Process RemSWDefFPageProc = new Process();
                    RemSWDefFPageProc.StartInfo = RemSWDefFPage;
                    RemSWDefFPageProc.Start();
                    string resultRemSWDefFPage = RemSWDefFPageProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemSWDefFPage);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the default.aspx as the default SW webpage if it exists.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemSWDefGPage = new ProcessStartInfo(strCMD, strCMD7g);
                    RemSWDefGPage.RedirectStandardOutput = true;
                    RemSWDefGPage.RedirectStandardInput = true;
                    RemSWDefGPage.UseShellExecute = false;
                    RemSWDefGPage.CreateNoWindow = true;
                    Process RemSWDefGPageProc = new Process();
                    RemSWDefGPageProc.StartInfo = RemSWDefGPage;
                    RemSWDefGPageProc.Start();
                    string resultRemSWDefGPage = RemSWDefGPageProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemSWDefGPage);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Adding the Index.asp as the only RMS default webpage.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo SetSWDefPage = new ProcessStartInfo(strCMD, strCMD8);
                    SetSWDefPage.RedirectStandardOutput = true;
                    SetSWDefPage.RedirectStandardInput = true;
                    SetSWDefPage.UseShellExecute = false;
                    SetSWDefPage.CreateNoWindow = true;
                    Process SetSWDefPageProc = new Process();
                    SetSWDefPageProc.StartInfo = SetSWDefPage;
                    SetSWDefPageProc.Start();
                    string resultSetSWDefPage = SetSWDefPageProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultSetSWDefPage);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
            }
            else if (checkBox20.Checked == false)
            {
                LOG_TEXT.Append("Create RMS and RMSStud Websites checkbox was not checked.");
                LOG_TEXT.AppendLine("");
                
            }
            //Disable Handler Mappings
            ProcessTextBox.Text = ProcessTextBox.Text + "Disabling Handler mappings............";
            if (checkBox21.Checked == true)
            {
                
                string strRegSvrPath = openFileDialog1.FileName;
                strRegSvrPath = strRegSvrPath.Replace("\\regsvr32.exe", "\\inetsrv\\appcmd");
                strRegSvrPath = strRegSvrPath.Replace("\"", "\\");
                string strCMD = strRegSvrPath;
                try
                {
                    string strCMD9a = " set config \"" + RMSSiteName.Text + "/RMSConfigXML\" /section:handlers /-[name='ASPClassic']";
                    string strCMD9b = " set config \"" + RMSSiteName.Text + "/RMSErrorDump\" /section:handlers /-[name='ASPClassic']";
                    string strCMD9c = " set config \"" + RMSSiteName.Text + "/RMSUsers\" /section:handlers /-[name='ASPClassic']";
                    string strCMD9d = " set config \"" + RMSSiteName.Text + "/RMSXML\" /section:handlers /-[name='ASPClassic']";
                    string strCMD9e = " set config \"" + RMSSiteName.Text + "/WebConfigXML\" /section:handlers /-[name='ASPClassic']";
                    string strCMD9f = " set config \"" + SWSiteName.Text + "/RMSErrorDump\" /section:handlers /-[name='ASPClassic']";
                    string strCMD9g = " set config \"" + SWSiteName.Text + "/RMSUsers\" /section:handlers /-[name='ASPClassic']";
                    string strCMD9h = " set config \"" + SWSiteName.Text + "/RMSXML\" /section:handlers /-[name='ASPClassic']";
                    LOG_TEXT.Append("Removing the ClassicASP Handler Mapping from the RMS-RMSCONFIGXML Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemHMa = new ProcessStartInfo(strCMD, strCMD9a);
                    RemHMa.RedirectStandardOutput = true;
                    RemHMa.RedirectStandardInput = true;
                    RemHMa.UseShellExecute = false;
                    RemHMa.CreateNoWindow = true;
                    Process RemHMaProc = new Process();
                    RemHMaProc.StartInfo = RemHMa;
                    RemHMaProc.Start();
                    string resultRemHMa = RemHMaProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemHMa);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the ClassicASP Handler Mapping from the RMS-RMSErrorDump Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemHMb = new ProcessStartInfo(strCMD, strCMD9b);
                    RemHMb.RedirectStandardOutput = true;
                    RemHMb.RedirectStandardInput = true;
                    RemHMb.UseShellExecute = false;
                    RemHMb.CreateNoWindow = true;
                    Process RemHMbProc = new Process();
                    RemHMbProc.StartInfo = RemHMb;
                    RemHMbProc.Start();
                    string resultRemHMb = RemHMbProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemHMb);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the ClassicASP Handler Mapping from the RMS-RMSUsers Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemHMc = new ProcessStartInfo(strCMD, strCMD9c);
                    RemHMc.RedirectStandardOutput = true;
                    RemHMc.RedirectStandardInput = true;
                    RemHMc.UseShellExecute = false;
                    RemHMc.CreateNoWindow = true;
                    Process RemHMcProc = new Process();
                    RemHMcProc.StartInfo = RemHMc;
                    RemHMcProc.Start();
                    string resultRemHMc = RemHMcProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemHMc);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the ClassicASP Handler Mapping from the RMS-RMSXML Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemHMd = new ProcessStartInfo(strCMD, strCMD9d);
                    RemHMd.RedirectStandardOutput = true;
                    RemHMd.RedirectStandardInput = true;
                    RemHMd.UseShellExecute = false;
                    RemHMd.CreateNoWindow = true;
                    Process RemHMdProc = new Process();
                    RemHMdProc.StartInfo = RemHMd;
                    RemHMdProc.Start();
                    string resultRemHMd = RemHMdProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemHMd);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the ClassicASP Handler Mapping from the RMS-WebConfigXML Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemHMe = new ProcessStartInfo(strCMD, strCMD9e);
                    RemHMe.RedirectStandardOutput = true;
                    RemHMe.RedirectStandardInput = true;
                    RemHMe.UseShellExecute = false;
                    RemHMe.CreateNoWindow = true;
                    Process RemHMeProc = new Process();
                    RemHMeProc.StartInfo = RemHMe;
                    RemHMeProc.Start();
                    string resultRemHMe = RemHMeProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemHMe);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the ClassicASP Handler Mapping from the SW-RMSErrorDump Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemHMf = new ProcessStartInfo(strCMD, strCMD9f);
                    RemHMf.RedirectStandardOutput = true;
                    RemHMf.RedirectStandardInput = true;
                    RemHMf.UseShellExecute = false;
                    RemHMf.CreateNoWindow = true;
                    Process RemHMfProc = new Process();
                    RemHMfProc.StartInfo = RemHMf;
                    RemHMfProc.Start();
                    string resultRemHMf = RemHMfProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemHMf);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the ClassicASP Handler Mapping from the SW-RMSUsers Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemHMg = new ProcessStartInfo(strCMD, strCMD9g);
                    RemHMg.RedirectStandardOutput = true;
                    RemHMg.RedirectStandardInput = true;
                    RemHMg.UseShellExecute = false;
                    RemHMg.CreateNoWindow = true;
                    Process RemHMgProc = new Process();
                    RemHMgProc.StartInfo = RemHMg;
                    RemHMgProc.Start();
                    string resultRemHMg = RemHMgProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemHMg);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Removing the ClassicASP Handler Mapping from the SW-RMSXML Folder.");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo RemHMh = new ProcessStartInfo(strCMD, strCMD9h);
                    RemHMh.RedirectStandardOutput = true;
                    RemHMh.RedirectStandardInput = true;
                    RemHMh.UseShellExecute = false;
                    RemHMh.CreateNoWindow = true;
                    Process RemHMhProc = new Process();
                    RemHMhProc.StartInfo = RemHMh;
                    RemHMhProc.Start();
                    string resultRemHMh = RemHMhProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultRemHMh);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
            }
            else if (checkBox21.Checked == false)
            {
                LOG_TEXT.Append("Disable Handler Mappings checkbox was not checked.");
                LOG_TEXT.AppendLine("");
                
            }
            //Set HTTP Header Response to NoCache for ModuleReports and PDF Folders in AllReports
            ProcessTextBox.Text = ProcessTextBox.Text + "Setting the HTTP Header Responses............";
            if (checkBox22.Checked == true)
            {
                
                string strRegSvrPath = openFileDialog1.FileName;
                strRegSvrPath = strRegSvrPath.Replace("\\regsvr32.exe", "\\inetsrv\\appcmd");
                strRegSvrPath = strRegSvrPath.Replace("\"", "\\");
                string strCMD = strRegSvrPath;
                try
                {
                    string strCMD10a = " set config \"" + RMSSiteName.Text + "/AllReports/ReportFiles/ModuleReports\" /section:staticContent /clientCache.cacheControlMode:DisableCache";
                    string strCMD10b = " set config \"" + RMSSiteName.Text + "/AllReports/ReportFiles/PDF\" /section:staticContent /clientCache.cacheControlMode:DisableCache";
                    LOG_TEXT.Append("Set HTTP Header Response to NoCache for ModuleReports Folder in AllReports");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo ReportNoCacheA = new ProcessStartInfo(strCMD, strCMD10a);
                    ReportNoCacheA.RedirectStandardOutput = true;
                    ReportNoCacheA.RedirectStandardInput = true;
                    ReportNoCacheA.UseShellExecute = false;
                    ReportNoCacheA.CreateNoWindow = true;
                    Process ReportNoCacheAProc = new Process();
                    ReportNoCacheAProc.StartInfo = ReportNoCacheA;
                    ReportNoCacheAProc.Start();
                    string resultReportNoCacheA = ReportNoCacheAProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultReportNoCacheA);
                    LOG_TEXT.AppendLine("");
                    

                    LOG_TEXT.Append("Set HTTP Header Response to NoCache for PDF Folder in AllReports");
                    LOG_TEXT.AppendLine("");
                    
                    ProcessStartInfo ReportNoCacheB = new ProcessStartInfo(strCMD, strCMD10a);
                    ReportNoCacheB.RedirectStandardOutput = true;
                    ReportNoCacheB.RedirectStandardInput = true;
                    ReportNoCacheB.UseShellExecute = false;
                    ReportNoCacheB.CreateNoWindow = true;
                    Process ReportNoCacheBProc = new Process();
                    ReportNoCacheBProc.StartInfo = ReportNoCacheB;
                    ReportNoCacheBProc.Start();
                    string resultReportNoCacheB = ReportNoCacheBProc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(resultReportNoCacheB);
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
            }
            else if (checkBox22.Checked == false)
            {
                LOG_TEXT.Append("Set HTTP Header Response to NoCache for ModuleReports and PDF Folders in AllReports checkbox was not checked.");
                LOG_TEXT.AppendLine("");
                
            }
            //Database Oracle?
            ProcessTextBox.Text = ProcessTextBox.Text + "Database has been set to Oracle............";
            if (checkBox23.Checked == true)
            {
               
                //If Oracle Set the NTFS Permissions on Oracle Homes
                if (checkBox24.Checked == true)
                {
                    ProcessTextBox.Text = ProcessTextBox.Text + "Setting the NTFS Permissions to the Oracle Folder............";
                    string strORAFOLDER = folderBrowserDialog8.SelectedPath;
                    strORAFOLDER = strORAFOLDER.Replace("\"", "\\");
                    string strORAFOLDER2 = strORAFOLDER + "\\*";
                    string strCMD = "ICACLS.exe";
                    try
                    {
                        LOG_TEXT.Append("Give Modify Permissions to the builtin\\iis_iusrs on the Oracle Folder.");
                        LOG_TEXT.AppendLine("");
                        
                        string d = @" " + strORAFOLDER + " /grant builtin\\iis_iusrs:(OI)(CI)M /T /C";
                        ProcessStartInfo ICACLS = new ProcessStartInfo(strCMD, d);
                        ICACLS.RedirectStandardOutput = true;
                        ICACLS.UseShellExecute = false;
                        ICACLS.CreateNoWindow = true;
                        Process proc = new Process();
                        proc.StartInfo = ICACLS;
                        proc.Start();
                        string result = proc.StandardOutput.ReadToEnd();
                        // Display the command output.
                        LOG_TEXT.Append(result);
                        LOG_TEXT.AppendLine("");
                        

                        LOG_TEXT.Append("Give Read Permissions to the " + RMSCOMUser.Text + " user on the Oracle Folder.");
                        LOG_TEXT.AppendLine("");
                        
                        string d2 = @" " + strORAFOLDER + " /grant " + RMSCOMUser.Text + ":(OI)(CI)R /T /C";
                        ProcessStartInfo ICACLS2 = new ProcessStartInfo(strCMD, d2);
                        ICACLS2.RedirectStandardOutput = true;
                        ICACLS2.UseShellExecute = false;
                        ICACLS2.CreateNoWindow = true;
                        Process proc2 = new Process();
                        proc2.StartInfo = ICACLS2;
                        proc2.Start();
                        string result2 = proc.StandardOutput.ReadToEnd();
                        // Display the command output.
                        LOG_TEXT.Append(result2);
                        LOG_TEXT.AppendLine("");
                        

                        LOG_TEXT.Append("Give Read Permissions to the " + RMSIISUser.Text + " user on the Oracle Folder.");
                        LOG_TEXT.AppendLine("");
                        
                        string d3 = @" " + strORAFOLDER + " /grant " + RMSIISUser.Text + ":(OI)(CI)R /T /C";
                        ProcessStartInfo ICACLS3 = new ProcessStartInfo(strCMD, d3);
                        ICACLS3.RedirectStandardOutput = true;
                        ICACLS3.UseShellExecute = false;
                        ICACLS3.CreateNoWindow = true;
                        Process proc3 = new Process();
                        proc3.StartInfo = ICACLS3;
                        proc3.Start();
                        string result3 = proc3.StandardOutput.ReadToEnd();
                        // Display the command output.
                        LOG_TEXT.Append(result3);
                        LOG_TEXT.AppendLine("");
                        
                    }
                    catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");
                        
                    }
                }
                else if (checkBox24.Checked == false)
                {
                    LOG_TEXT.Append("If Oracle Set the NTFS Permissions on Oracle Homes checkbox was not checked.");
                    LOG_TEXT.AppendLine("");
                    
                }
            }
            else if (checkBox23.Checked == false)
            {
                LOG_TEXT.Append("Database Oracle checkbox was not checked, so database is set to SQL");
                LOG_TEXT.AppendLine("");
                
            }
            //Setup the ODBC for RMSReports
            ProcessTextBox.Text = ProcessTextBox.Text + "Creating the ODBC for RMSReports............";
            if (checkBox25.Checked == true)
            {
               
                if (checkBox23.Checked == true)
                {
                    LOG_TEXT.Append("Database is set to Oracle - now creating the RMSReports ODBC.");
                    LOG_TEXT.AppendLine("");
                    
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
                                string UserID = dbUser.Text;
                                string DBServerConnection = dbServer.Text;
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
                                LOG_TEXT.Append("Finished creating the Oracle RMSReports ODBC.");
                                LOG_TEXT.AppendLine("");
                                
                            }
                            catch (Exception ex)
                            {
                                LOG_TEXT.Append(ex.Message);
                                LOG_TEXT.AppendLine("");
                                
                            }

                        }
                    }
                }
                else if (checkBox23.Checked == false)
                {
                    try
                    {
                        LOG_TEXT.Append("Database is set to SQL - now creating the RMSReports ODBC.");
                        LOG_TEXT.AppendLine("");
                        
                        RegistryKey rk = Registry.LocalMachine;
                        RegistryKey rk1 = rk.OpenSubKey("SOFTWARE\\Wow6432Node\\ODBC\\ODBCINST.INI\\", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);

                        string[] rk1array = rk1.GetSubKeyNames();
                        foreach (String s in rk1array)
                        {
                            if (s.Equals("SQL Server"))
                            {
                                try
                                {
                                    string SQLKey = s;
                                    RegistryKey rk2 = rk1.OpenSubKey(SQLKey, RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                                    string DriverPath = rk2.GetValue("Driver").ToString();
                                    string DataSourceName = "RMSReports";
                                    string Description = "RMSReports";
                                    string DatabaseName = RMSREALUser.Text;
                                    string LastUser = dbUser.Text;
                                    string DBServerConnection = dbServer.Text;
                                    RegistryKey rk3 = rk.OpenSubKey("SOFTWARE\\Wow6432Node\\ODBC\\ODBC.INI\\", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                                    RegistryKey rk4 = rk.CreateSubKey("SOFTWARE\\Wow6432Node\\ODBC\\ODBC.INI\\" + DataSourceName + "\\");
                                    rk4.SetValue("DataBase", DatabaseName, RegistryValueKind.String);
                                    rk4.SetValue("Description", Description, RegistryValueKind.String);
                                    rk4.SetValue("LastUser", LastUser, RegistryValueKind.String);
                                    rk4.SetValue("Server", DBServerConnection, RegistryValueKind.String);
                                    rk4.SetValue("Driver", DriverPath, RegistryValueKind.String);
                                    RegistryKey rk5 = rk.CreateSubKey("SOFTWARE\\Wow6432Node\\ODBC\\ODBC.INI\\ODBC Data Sources\\"); 
                                    RegistryKey rk6 = rk.OpenSubKey("SOFTWARE\\Wow6432Node\\ODBC\\ODBC.INI\\ODBC Data Sources\\", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                                    rk6.SetValue("RMSReports", SQLKey, RegistryValueKind.String);
                                    LOG_TEXT.Append("Finished creating the SQL RMSReports ODBC.");
                                    LOG_TEXT.AppendLine("");
                                    
                                }
                                catch (Exception ex)
                                {
                                    LOG_TEXT.Append(ex.Message);
                                    LOG_TEXT.AppendLine("");
                                    
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");
                        
                    }

                }
            }
            else if (checkBox25.Checked == false)
            {
                LOG_TEXT.Append("Setup the ODBC for RMSReports checkbox was not checked, so ODBC was not setup");
                LOG_TEXT.AppendLine("");
            }
            //Create RMSDaemon Task
            ProcessTextBox.Text = ProcessTextBox.Text + "Creating the RMSDaemon Task............";
            if (checkBox26.Checked == true)
            {
                
                try
                {
                    LOG_TEXT.Append("Creating the RMSDAEMON.XML File");
                    LOG_TEXT.AppendLine("");
                    
                    string strRMSV50SHARE = folderBrowserDialog5.SelectedPath;
                    strRMSV50SHARE = strRMSV50SHARE.Replace("\\", "\\");
                    string strRMSDaemonExePath = strRMSV50SHARE + "\\RMSDLLs\\RMSDaemon.exe";
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.OmitXmlDeclaration = true;
                    settings.Encoding = new UTF8Encoding();
                    settings.ConformanceLevel = ConformanceLevel.Fragment;
                    settings.CloseOutput = false;

                    // Create the XmlWriter object and write some content.
                    //MemoryStream strm = new MemoryStream();
                    //XmlWriter RMSDAEMON_XML_WRITER = XmlWriter.Create(strm, settings);
                    String siteMapNamespace = "http://schemas.microsoft.com/windows/2004/02/mit/task";
                    XmlWriter RMSDAEMON_XML_WRITER = XmlWriter.Create(strRMSV50SHARE + "\\RMSDaemon.xml",settings);
                    //RMSDAEMON_XML_WRITER.WriteStartDocument();
                    RMSDAEMON_XML_WRITER.WriteStartElement("Task", siteMapNamespace);
                    RMSDAEMON_XML_WRITER.WriteAttributeString("version", "1.2");
                    //Registration Information
                    RMSDAEMON_XML_WRITER.WriteStartElement("RegistrationInfo");
                    RMSDAEMON_XML_WRITER.WriteElementString("Author", RMSCOMUser.Text);
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
                    RMSDAEMON_XML_WRITER.WriteElementString("UserId", RMSCOMUser.Text);
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
                    LOG_TEXT.Append("Finished Creatung the RMSDAEMON.XMK File");
                    LOG_TEXT.AppendLine("");
                    
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
                try
                {
                    LOG_TEXT.Append("Creating the RMSDAEMON Task from the RMSDAEMON.XML File");
                    LOG_TEXT.AppendLine("");
                    
                    string strRMSV50SHARE = folderBrowserDialog5.SelectedPath;
                    strRMSV50SHARE = strRMSV50SHARE.Replace("\"", "\\");
                    strRMSV50SHARE = strRMSV50SHARE + "\\RMSDaemon.xml";
                    string strCMD = "schtasks.exe";
                    string d = @"/Create /S " + serverName.Text + " /RU " + RMSCOMUser.Text + " /RP " + RMSCOMPass.Text + " /TN RMSDaemon /XML " + strRMSV50SHARE;
                    string d2 = @"/Run /TN RMSDaemon";
                    ProcessStartInfo SchTask = new ProcessStartInfo(strCMD, d);
                    SchTask.RedirectStandardOutput = true; 
                    SchTask.UseShellExecute = false;
                    SchTask.CreateNoWindow = true;
                    Process proc = new Process();
                    proc.StartInfo = SchTask;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result);
                    LOG_TEXT.AppendLine("");
                    

                    ProcessStartInfo SchTask2 = new ProcessStartInfo(strCMD, d2);
                    SchTask2.RedirectStandardOutput = true;
                    SchTask2.UseShellExecute = false;
                    SchTask2.CreateNoWindow = true;
                    Process proc2 = new Process();
                    proc2.StartInfo = SchTask2;
                    proc2.Start();
                    string result2 = proc2.StandardOutput.ReadToEnd();
                    // Display the command output.
                    LOG_TEXT.Append(result2);
                    LOG_TEXT.AppendLine("");
                    
                    File.Delete(strRMSV50SHARE);
                    LOG_TEXT.Append("RMSDAEMON.XML File has been deleted");
                    LOG_TEXT.AppendLine("");
                    
                }                     
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");
                    
                }
            }
            else if (checkBox26.Checked == false)
            {
                LOG_TEXT.Append("Create RMSDaemon Task checkbox was not checked, so RMSDaemon was not setup");
                LOG_TEXT.AppendLine("");
                
            }
            //Create Config XML
            ProcessTextBox.Text = ProcessTextBox.Text + "Creating the Config XML............";
            if (checkBox27.Checked == true)
            {
                
                
                try
                {
                    LOG_TEXT.Append("Creating the Config.XML file.");
                    LOG_TEXT.AppendLine("");
                    
                        XmlWriterSettings settings = new XmlWriterSettings();
                        settings.OmitXmlDeclaration = true;
                        settings.Encoding = new UTF8Encoding();
                        settings.ConformanceLevel = ConformanceLevel.Fragment;
                        settings.CloseOutput = false;    
                        string strRMSV50SHARE = folderBrowserDialog5.SelectedPath;
                        strRMSV50SHARE = strRMSV50SHARE.Replace("\"", "\\");
                        XmlWriter User_DB_XML_WRITER = XmlWriter.Create(strRMSV50SHARE + "\\RMSDLLs\\Config\\Config.xml",settings);
                        //User_DB_XML_WRITER.WriteStartDocument();
                        User_DB_XML_WRITER.WriteStartElement("AppServerName");
                        User_DB_XML_WRITER.WriteElementString("FolderName", folderName.Text);
                        User_DB_XML_WRITER.WriteElementString("ServerName", serverName.Text);
                        User_DB_XML_WRITER.WriteElementString("DomainName", domainName.Text);
                        User_DB_XML_WRITER.WriteElementString("GroupName", groupName.Text);
                        User_DB_XML_WRITER.WriteElementString("EMailID", EMailID.Text);
                        if (checkBox30.Checked == true)
                        {
                            User_DB_XML_WRITER.WriteElementString("RequiredNTAuthentication", "Yes");
                        }
                        else
                        {
                            User_DB_XML_WRITER.WriteElementString("RequiredNTAuthentication", "No");
                        }
                        User_DB_XML_WRITER.WriteElementString("DBUserName", encryptedUser.Text);
                        User_DB_XML_WRITER.WriteElementString("DBPassword", encryptedPass.Text);
                        if (checkBox31.Checked == true)
                        {
                            User_DB_XML_WRITER.WriteElementString("RequiredExtAuthentication", "Yes");
                        }
                        else
                        {
                            User_DB_XML_WRITER.WriteElementString("RequiredExtAuthentication", "No");
                        }
                        User_DB_XML_WRITER.WriteElementString("AuthenticationServerIPAddress", AuthenticationServerIPAddress.Text);
                        User_DB_XML_WRITER.WriteElementString("AuthenticationServerOS", AuthenticationServerOS.Text);
                        User_DB_XML_WRITER.WriteElementString("AuthenticationServerDirectory", AuthenticationServerDirectory.Text);
                        if (checkBox32.Checked == true)
                        {
                            User_DB_XML_WRITER.WriteElementString("AuthenticationType", "Portal");
                        }
                        else if (checkBox33.Checked == true)
                        {
                            User_DB_XML_WRITER.WriteElementString("AuthenticationType", "LDAP");
                        }
                        else
                        {
                            User_DB_XML_WRITER.WriteElementString("AuthenticationType", "");
                        }
                        User_DB_XML_WRITER.WriteElementString("PortalURL", portalURL.Text);
                        //Server Names
                        User_DB_XML_WRITER.WriteStartElement("ServerNames");
                        User_DB_XML_WRITER.WriteAttributeString("IntegrationAttribute", IntegrationAttribute.Text);
                        User_DB_XML_WRITER.WriteAttributeString("FirewallPW", FirewallPW.Text);
                        User_DB_XML_WRITER.WriteAttributeString("FirewallUser", FirewallUser.Text);
                        User_DB_XML_WRITER.WriteAttributeString("FirewallPort", FirewallPort.Text);
                        User_DB_XML_WRITER.WriteAttributeString("FirewallHost", FirewallHost.Text);
                        User_DB_XML_WRITER.WriteAttributeString("FirewallType", FirewallType.Text);
                        User_DB_XML_WRITER.WriteAttributeString("SSLAcceptServerCert", SSLAcceptServerCert.Text);
                        User_DB_XML_WRITER.WriteAttributeString("SSLCertEncoded", SSLcertEncoded.Text);
                        User_DB_XML_WRITER.WriteAttributeString("SSLCertStorePW", SSLCertStorePW.Text);
                        User_DB_XML_WRITER.WriteAttributeString("SSLCertSubj", SSLCertSubj.Text);
                        User_DB_XML_WRITER.WriteAttributeString("SSLCertStore", SSLCertStore.Text);
                        User_DB_XML_WRITER.WriteAttributeString("SSLCretStoreType", SSLCertStoreType.Text);
                        User_DB_XML_WRITER.WriteAttributeString("SSLMode", SSLMode.Text);
                        User_DB_XML_WRITER.WriteAttributeString("BindPW", BindPW.Text);
                        User_DB_XML_WRITER.WriteAttributeString("BindUser", BindUser.Text);
                        User_DB_XML_WRITER.WriteAttributeString("DereferenceAliases", DereferenceAliases.Text);
                        User_DB_XML_WRITER.WriteAttributeString("SearchString", SearchString.Text);
                        User_DB_XML_WRITER.WriteAttributeString("ParentDN", parentDN.Text);
                        User_DB_XML_WRITER.WriteAttributeString("Name", LDAPSname.Text);
                        User_DB_XML_WRITER.WriteEndElement();
                        //Software Key Information
                        User_DB_XML_WRITER.WriteStartElement("SoftwareKeyInformation");
                        User_DB_XML_WRITER.WriteElementString("SoftwareKey", SoftwareKey.Text);
                        User_DB_XML_WRITER.WriteElementString("ClientID", ClientID.Text);
                        User_DB_XML_WRITER.WriteElementString("BedSpaces", BedSpaces.Text);
                        User_DB_XML_WRITER.WriteEndElement();
                        //End Element and Document
                        User_DB_XML_WRITER.WriteEndElement();
                        //User_DB_XML_WRITER.WriteEndDocument();
                        User_DB_XML_WRITER.Flush();
                        User_DB_XML_WRITER.Close();
                        LOG_TEXT.Append("Finished Creating the Config.XML file.");
                        LOG_TEXT.AppendLine("");
                        
                    }
                    catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");
                        
                    }
            }
            else if (checkBox27.Checked == false)
            {
                LOG_TEXT.Append("Create Config XML checkbox was not checked, so the Config XML was not created");
                LOG_TEXT.AppendLine("");
                
            }
            //Create User_DB XML
            ProcessTextBox.Text = ProcessTextBox.Text + "Creating the User_DB XML............";
            if (checkBox28.Checked == true)
            {
                string strRMSSHARE = folderBrowserDialog3.SelectedPath;
                strRMSSHARE = strRMSSHARE.Replace("\"", "\\");
                    try
                    {
                        LOG_TEXT.Append("Creating the user_DB.xml file");
                        LOG_TEXT.AppendLine("");
                        
                        XmlWriterSettings settings = new XmlWriterSettings();
                        settings.OmitXmlDeclaration = true;
                        settings.Encoding = new UTF8Encoding();
                        settings.ConformanceLevel = ConformanceLevel.Fragment;
                        settings.CloseOutput = false;
                        
                        XmlWriter User_DB_XML_WRITER = XmlWriter.Create(strRMSSHARE + "\\rmsxml\\user_db.xml",settings);
                        //User_DB_XML_WRITER.WriteStartDocument();
                        User_DB_XML_WRITER.WriteStartElement("user");
                        User_DB_XML_WRITER.WriteStartElement("dataset");
                        if (checkBox23.Checked == true)
                        {
                            User_DB_XML_WRITER.WriteElementString("dbtype", "Oracle10g");
                        }
                        else
                        {
                            User_DB_XML_WRITER.WriteElementString("dbtype", "SqlServer2000");
                        }
                        User_DB_XML_WRITER.WriteElementString("dbserver", dbServer.Text);
                        User_DB_XML_WRITER.WriteElementString("database", RMSLOGINUser.Text);
                        User_DB_XML_WRITER.WriteEndElement();
                        User_DB_XML_WRITER.WriteEndElement();
                        //User_DB_XML_WRITER.WriteEndDocument();
                        User_DB_XML_WRITER.Flush();
                        User_DB_XML_WRITER.Close();
                        LOG_TEXT.Append("Finished Creating the user_DB.xml file");
                        LOG_TEXT.AppendLine("");
                    }
                catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");
                        
                    }
                
            }                
            else if (checkBox28.Checked == false)
            {
                LOG_TEXT.Append("Create User_DB XML checkbox was not checked, so the User_DB XML was not created");
                LOG_TEXT.AppendLine("");
                
            }
            //Create the Usersdata.xml
            if (checkBox35.Checked == true)
            {
                try
                {
                    string strRMSSHARE = folderBrowserDialog3.SelectedPath;
                    strRMSSHARE = strRMSSHARE.Replace("\"", "\\");
                    XmlWriterSettings settings2 = new XmlWriterSettings();
                    settings2.OmitXmlDeclaration = true;
                    settings2.Encoding = new UTF8Encoding();
                    settings2.ConformanceLevel = ConformanceLevel.Fragment;
                    settings2.CloseOutput = false;
                    XmlWriter UsersData_XML_WRITER = XmlWriter.Create(strRMSSHARE + "\\rmsusers\\usersData.xml", settings2);
                    UsersData_XML_WRITER.WriteStartElement("users");
                    UsersData_XML_WRITER.WriteStartElement("user");
                    UsersData_XML_WRITER.WriteAttributeString("encId", "");
                    UsersData_XML_WRITER.WriteAttributeString("name", dbUser.Text);
                    UsersData_XML_WRITER.WriteAttributeString("id", "1");
                    UsersData_XML_WRITER.WriteAttributeString("password", "DB3DA8B64E8633B2");
                    UsersData_XML_WRITER.WriteAttributeString("Status", "1");
                    UsersData_XML_WRITER.WriteAttributeString("emailId", "Owner50RMS@rms.com");
                    UsersData_XML_WRITER.WriteAttributeString("schoolID", school_id.Text);
                    UsersData_XML_WRITER.WriteAttributeString("loggedinstatus", "false");
                    UsersData_XML_WRITER.WriteAttributeString("sid", "");
                    UsersData_XML_WRITER.WriteAttributeString("accessedtime", "");
                    UsersData_XML_WRITER.WriteEndElement();
                    UsersData_XML_WRITER.WriteEndElement();
                    UsersData_XML_WRITER.Flush();
                    UsersData_XML_WRITER.Close();
                    LOG_TEXT.Append("Finished Creating the userdata.xml file");
                    LOG_TEXT.AppendLine("");
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");

                }
            }
            else if (checkBox35.Checked == false)
            {
                LOG_TEXT.Append("Create Usersdata XML checkbox was not checked, so the Usersdata XML was not created");
                LOG_TEXT.AppendLine("");

            }
            if (checkBox36.Checked == true)
            {
                try
                {
                    string strRMSSHARE = folderBrowserDialog3.SelectedPath;
                    strRMSSHARE = strRMSSHARE.Replace("\"", "\\");
                    XmlWriterSettings settings3 = new XmlWriterSettings();
                    settings3.OmitXmlDeclaration = true;
                    settings3.Encoding = new UTF8Encoding();
                    settings3.ConformanceLevel = ConformanceLevel.Fragment;
                    settings3.CloseOutput = false;
                    XmlWriter Users_XML_WRITER = XmlWriter.Create(strRMSSHARE + "\\rmsusers\\user_Owner50RMS.xml", settings3);
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
                    if (checkBox23.Checked == true)
                    {
                        Users_XML_WRITER.WriteElementString("dbtype", "Oracle10g");
                    }
                    else
                    {
                        Users_XML_WRITER.WriteElementString("dbtype", "SqlServer2000");
                    }
                    Users_XML_WRITER.WriteElementString("dbserver", dbServer.Text);
                    Users_XML_WRITER.WriteElementString("database", RMSREALUser.Text);
                    Users_XML_WRITER.WriteElementString("dataset", RMSREALUser.Text);
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
                    LOG_TEXT.Append("Finished Creating the users_Owner50RMS.xml file");
                    LOG_TEXT.AppendLine("");
                }
                catch (Exception ex)
                {
                    LOG_TEXT.Append(ex.Message);
                    LOG_TEXT.AppendLine("");

                }
            }
            else if (checkBox36.Checked == false)
            {
                LOG_TEXT.Append("Create User_Owner50RMS XML checkbox was not checked, so the User_Owner50RMS XML was not created");
                LOG_TEXT.AppendLine("");

            }
            
            //Create Webconnection XML
            ProcessTextBox.Text = ProcessTextBox.Text + "Creating the Webconnection XML............";
            if (checkBox29.Checked == true)
            {
                
                try
                {
                    LOG_TEXT.Append("Creating the webconnection.xml file.");
                    LOG_TEXT.AppendLine("");
                    
                        XmlWriterSettings settings = new XmlWriterSettings();
                        settings.OmitXmlDeclaration = true;
                        settings.Encoding = new UTF8Encoding();
                        settings.ConformanceLevel = ConformanceLevel.Fragment;
                        settings.CloseOutput = false;    
                        string strSWSHARE = folderBrowserDialog4.SelectedPath;
                        strSWSHARE = strSWSHARE.Replace("\"", "\\");
                        XmlWriter Webconnection_XML_WRITER = XmlWriter.Create(strSWSHARE + "\\WebModule-Student\\rmsxml\\webconnection.xml",settings);
                        //Webconnection_XML_WRITER.WriteStartDocument();
                        Webconnection_XML_WRITER.WriteStartElement("webconnection");
                        Webconnection_XML_WRITER.WriteStartElement("connection");
                        Webconnection_XML_WRITER.WriteAttributeString("module", "student");
                        if (checkBox23.Checked == true)
                        {
                            Webconnection_XML_WRITER.WriteAttributeString("dbtype", "Oracle10g");
                        }
                        if (checkBox23.Checked == false)
                        {
                            Webconnection_XML_WRITER.WriteAttributeString("dbtype", "SqlServer2000");
                        }
                        Webconnection_XML_WRITER.WriteAttributeString("servername", dbServer.Text);
                        Webconnection_XML_WRITER.WriteAttributeString("database", RMSREALUser.Text);
                        Webconnection_XML_WRITER.WriteAttributeString("driver", "");
                        Webconnection_XML_WRITER.WriteAttributeString("username", dbUser.Text);
                        Webconnection_XML_WRITER.WriteAttributeString("password", encryptedPass.Text);
                        Webconnection_XML_WRITER.WriteAttributeString("mr_database", mr_database.Text);
                        Webconnection_XML_WRITER.WriteAttributeString("school_id", school_id.Text);
                        Webconnection_XML_WRITER.WriteAttributeString("Local_URL", Local_URL.Text);
                        Webconnection_XML_WRITER.WriteAttributeString("Web_URL", Web_URL.Text);
                        Webconnection_XML_WRITER.WriteAttributeString("SSLCertStore", SWSSLCertStore.Text);
                        Webconnection_XML_WRITER.WriteAttributeString("SSLCertStoreType", SWSSLCertStoreType.Text);
                        Webconnection_XML_WRITER.WriteAttributeString("SSLCertStorePassword", SWSSLCertStorePassword.Text);
                        Webconnection_XML_WRITER.WriteAttributeString("SSLCertSubject", SWSSLCertSubject.Text);
                        Webconnection_XML_WRITER.WriteAttributeString("SSLAcceptServerCert", SWSSLAcceptServerCert.Text);
                        Webconnection_XML_WRITER.WriteEndElement();
                        Webconnection_XML_WRITER.WriteStartElement("connection");
                        Webconnection_XML_WRITER.WriteAttributeString("module", "conference");
                        if (checkBox23.Checked == true)
                        {
                            Webconnection_XML_WRITER.WriteAttributeString("dbtype", "Oracle10g");
                        }
                        if (checkBox23.Checked == false)
                        {
                            Webconnection_XML_WRITER.WriteAttributeString("dbtype", "SqlServer2000");
                        }
                        Webconnection_XML_WRITER.WriteAttributeString("servername", dbServer.Text);
                        Webconnection_XML_WRITER.WriteAttributeString("database", RMSREALUser.Text);
                        Webconnection_XML_WRITER.WriteAttributeString("driver", "");
                        Webconnection_XML_WRITER.WriteAttributeString("username", dbUser.Text);
                        Webconnection_XML_WRITER.WriteAttributeString("password", encryptedPass.Text);
                        Webconnection_XML_WRITER.WriteEndElement();
                        Webconnection_XML_WRITER.WriteEndElement();
                        //Webconnection_XML_WRITER.WriteEndDocument();
                        Webconnection_XML_WRITER.Flush();
                        Webconnection_XML_WRITER.Close();
                        LOG_TEXT.Append("Finished Creating the webconnection.xml file.");
                        LOG_TEXT.AppendLine("");
                        
                    }
                    catch (Exception ex)
                    {
                        LOG_TEXT.Append(ex.Message);
                        LOG_TEXT.AppendLine("");
                        
                    }
            }
            else if (checkBox29.Checked == false)
            {
                LOG_TEXT.Append("Create Webconnection XML checkbox was not checked, so the Webconnection XML was not created");
                LOG_TEXT.AppendLine("");
                
            }
            LOG_TEXT.Append("The install file has completed.");
            LOG_TEXT.AppendLine("");
            ProcessTextBox.Text = ProcessTextBox.Text + "The install file has been completed............";
            logTextBox.Text = LOG_TEXT.ToString();
            
            if (File.Exists(RMSv50Share.Text + "\\RolesAndFeaturesBefore.txt") && File.Exists(RMSv50Share.Text + "\\RolesAndFeaturesAfter.txt"))
            {
                string features1 = File.ReadAllText(RMSv50Share.Text + "\\RolesAndFeaturesBefore.txt");
                string features2 = File.ReadAllText(RMSv50Share.Text + "\\RolesAndFeaturesAfter.txt");
                File.WriteAllText(installFileName, features1 + features2 + logTextBox.Text);
                File.Delete(RMSv50Share.Text + "\\RolesAndFeaturesBefore.txt");
                File.Delete(RMSv50Share.Text + "\\RolesAndFeaturesAfter.txt");
            }
            else
            {
                File.WriteAllText(installFileName, LOG_TEXT.ToString());
            }
            

        }
        public class DirectoryCopier
        {
        public static void CopyDirectory(string originalDirectory, string newDirectory)
        {
            MoveDirectory(originalDirectory, newDirectory);
        }

        private static void MoveDirectory(string originalDirectory, string newDirectory)
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

            foreach(DirectoryInfo dir in oldDir.GetDirectories())
            {
                string oldPath = dir.FullName;
                string newPath = newDirectory + "\\" + dir.Name;
                MoveDirectory(oldPath, newPath);
            }
        }
    }
        
        public void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.RegSrvPath.Text = openFileDialog1.FileName;

            }
        }
        public void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                this.RMSTools.Text = folderBrowserDialog2.SelectedPath;

            }
        }
        public void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog3.ShowDialog() == DialogResult.OK)
            {
                this.RMSShare.Text = folderBrowserDialog3.SelectedPath;
            }
        }
        public void button4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog4.ShowDialog() == DialogResult.OK)
            {
                this.SWShare.Text = folderBrowserDialog4.SelectedPath;

            }
        }
        public void button5_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog5.ShowDialog() == DialogResult.OK)
            {
                this.RMSv50Share.Text = folderBrowserDialog5.SelectedPath;

            }
        }
        public void button6_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog6.ShowDialog() == DialogResult.OK)
            {
                this.RMSWMDLLsShare.Text = folderBrowserDialog6.SelectedPath;

            }
        }
        public void button7_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog7.ShowDialog() == DialogResult.OK)
            {
                this.InetpubLocation.Text = folderBrowserDialog7.SelectedPath;

            }
        }
        public void button8_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog8.ShowDialog() == DialogResult.OK)
            {
                this.OraHomeLocation.Text = folderBrowserDialog8.SelectedPath;

            }
        }
        public static void AddFileSecurity(string FileName, string Account, FileSystemRights Rights, AccessControlType ControlType)
        {
            FileInfo fInfo = new FileInfo(FileName);
            FileSecurity fSecurity = fInfo.GetAccessControl();
            fSecurity.AddAccessRule(new FileSystemAccessRule(Account,
                                                            Rights,
                                                            ControlType));
            fInfo.SetAccessControl(fSecurity);

        }

        private void folderName_TextChanged(object sender, EventArgs e)
        {
            string domainName =System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
            string hostName = Dns.GetHostName();
            string fqdn = "";
            if (!hostName.Contains(domainName))
                fqdn = hostName + "." + domainName;
            else
                fqdn = hostName;

            this.serverName.Text = hostName;
            this.domainName.Text = domainName;
        }

        public void fixedDrives()
        {
            List<string> fixedDriveList = new List<string>();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady && d.DriveType == DriveType.Fixed)
                {
                    fixedDriveList.Add(d.Name); // This is the drive you want...
                }
            }
            this.comboBox1.DataSource = fixedDriveList;
            //this.comboBox1.DisplayMember = "Name";
            //this.comboBox1.ValueMember = "Name";
            //return fixedDriveList;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strDriveLetter = (string)comboBox1.SelectedItem;
            
        }

        private bool validateUser(string User, string Password)
        {
            string strDomain;
            string strUser;
            string strPassword;
            bool noDomain;
            // determine if there is a "\" in the User string, if not Domain is localhost
            noDomain = true;
            strDomain = "rms";
            strUser = User;
            strPassword = Password;

            if (noDomain)
            {
                PrincipalContext pc = new PrincipalContext(ContextType.Machine, null);
                bool isValid = pc.ValidateCredentials(strUser, strPassword);
                return isValid;
            }
            else
            {
                PrincipalContext pc = new PrincipalContext(ContextType.Domain, strDomain);
                bool isValid = pc.ValidateCredentials(strUser, strPassword);
                return isValid;
            }
        }

        public void button9_Click(object sender, EventArgs e)
        {
            if (RMSIISUser.Text != "" && RMSIISPass.Text != "")
            {
                bool isValid =validateUser(RMSIISUser.Text, RMSIISPass.Text);
                MessageBox.Show(isValid.ToString());
            }
        }
    }
}
