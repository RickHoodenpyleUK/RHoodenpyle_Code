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

    /// <summary>
    /// Wizard application controller.
    /// </summary>
    public sealed class setupWizard
    {
        #region Singelton pattern
        /// <summary>
        /// Singelton instance
        /// </summary>
        static readonly setupWizard instance = new setupWizard();

        /// <summary>
        /// Constructors
        /// </summary>
        static setupWizard() { }
        setupWizard() { }

        /// <summary>
        /// Accesor for singelton instance
        /// </summary>
        public static setupWizard Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Aviable forms (tag property is optional, but it can be usefull in future)
        /// </summary>
        private Dictionary<int, Form> forms = new Dictionary<int, Form>() {
            {0, new wizardOne() { Tag = 0}},
            {1, new wizardTwo() { Tag = 1}},
            {2, new wizardThree() { Tag = 2}},
            {3, new wizardFour() { Tag = 3}}
        };

        /// <summary>
        /// Actual form
        /// </summary>

        private int current = 0;

        /// declare global form variables
        public string driveName = "";
        public string buildInfo = "";

        ///Windir
        public string strAPPCMD = Environment.GetEnvironmentVariable("windir") + @"\sysWOW64\inetsrv\appcmd.exe";
        public string strRegSvr = Environment.GetEnvironmentVariable("windir") + @"\sysWOW64\regsvr32.exe";
        public string strCMD = Environment.GetEnvironmentVariable("windir") + @"\sysWOW64\cmd.exe";
        public string strPayFlowDotNet = Environment.GetEnvironmentVariable("windir") + @"\sysWOW64\Payflow_dotNET.dll";
        public string strRegasmV2 = Environment.GetEnvironmentVariable("windir") + @"\Microsoft.NET\Framework\v2.0.50727\regasm.exe";
        public string strInstallUtilV2 = Environment.GetEnvironmentVariable("windir") + @"\Microsoft.NET\Framework\v2.0.50727\installutil.exe";
        public string strRegasmV4 = Environment.GetEnvironmentVariable("windir") + @"\Microsoft.NET\Framework\v4.0.30319\regasm.exe";
        public string strDotNetTempPath = Environment.GetEnvironmentVariable("windir") + @"\Microsoft.NET\Framework\v2.0.50727\Temporary%20ASP.NET%20Files";

        ///Users
        public string strRMSIISUser = "";
        public string strRMSIISPass = "";
        public string strRMSIISEncPass = "";
        public string strRMSCOMUser = "";
        public string strRMSCOMPass = "";
        public string strRMSCOMEncPass = "";

        ///Database Information
        public string strOraHomes = ""; 

        ///Shares
        public string strRMSShare = "";
        public string strRMSShareDir = @"RMSInc\RMS";
        public string strSWShare = "";
        public string strSWShareDir = @"RMSInc\RMSStud";
        public string strRMSv50Share = "";
        public string strRMSv50ShareDir = @"RMSInc\RMSv5.0";
        public string strRMSWMDLLsShare = "";
        public string strRMSWMDLLsShareDir = @"RMSInc\RMSWMDLLs";
        public string strRMSName = "RMS"; //to be used for share name, app name, website name and DLL name
        public string strSWName = "RMSStud"; //to be used for share name, app name, and website
        public string strSWCOMName = "WM";//to be used for DLL name
        public string strRMSv50Name = "RMSv50";//to be used for share name
        public string strRMSWMDLLsName = "RMSWMDLLs";//to be used for share name
        public string installFile = @"\InstallLog.log";
        public string installFileName = "";
        public string errorFile = @"\ErrorLog.log";
        public string errorFileName = "";
        public string combindedString = "";
        public string strSchoolEmail = "";

        ///Folders
        public string strRMSTools = "";
        public string strRMSToolsDir = @"RMSInc\Tools";
        ///New files Created

        ///General
        public string strSoftwareKey = "";
        public string strClientID = "";
        public string strNumberBeds = "";
        public string strLocalURL = "";
        public string strWebURL = "";
        public string strFormCheck = "Please enter all required values.";
        public string pathAbsentError = "";
        public string strInetpubLocation = "";
        public string serverName = "";
        public string domainName2 = "";
        public string fromPageName = "";


        ///Database
        public string strDatabaseServer = "";
        public string strOPowerName = "";
        public string strOPowerPass = "";
        public string strOLoginName = "";
        public string strODataName = "";
        public string strMyrmsSchema = "";
        public string strOracleHomes = "";
        public string strOracleDriver = "";
        public string strInst_Loc = "";
        public string strOracleVersion = "";
        public string strEncryptedUser = "";
        public string strEncryptedPass = "";
        public int rmsBinding = 8080;
        public int swBinding = 80;
        public bool bOracle = false;
        public bool bMssql = false;
        public bool bExistingYes = false;
        public bool bExistingNo = false;
        public bool bRmsVersion6 = false;
        public bool bRmsVersion5 = false;
        public List<string> OraKeys = new List<string>();

        ///Current selections
        //public string strCurrentSelections = "";
        public List<String> CurrentSelections = new List<String>();
        public String installerResult = "";

        ///Installation
        public bool binstallStarted = false;
        public int progIndicate = 1;
        public string strInstallLog = @"\InstallLogFile.log";
        /// <summary>
        /// Variable for custom user data ex. Selected option in previous form, connection parameters etc.
        /// </summary>
        public dynamic data = new System.Dynamic.ExpandoObject();

        ///Extra installers
        public bool checkAS = false;
        public bool checkASW = false;
        public bool checkPG = false;
        public bool checkWS = false;
        public bool checkMerc = false;
        public bool checkPreIIS = false;

        ///PaymentGateway Checkboxes
        public bool bAuthorizeNet = false;
        public bool bBarclayCard = false;
        public bool bBucksNet = false;
        public bool bCashNet = false;
        public bool bCyberSource = false;
        public bool bElavon = false;
        public bool bMoneris = false;
        public bool bMonerisCA = false;
        public bool bNelNet = false;
        public bool bPayPal = false;
        public bool bRealex = false;
        public bool bSallieMae = false;
        public bool bTouchNetLink = false;
        public bool bWPM = false;
        

        /// <summary>
        /// Displays wizard next form
        /// </summary>
        public void wizardNext()
        {
            forms[current].DialogResult = DialogResult.OK;
            forms[current++].Close();
        }

        /// <summary>
        /// Display wizard previous form
        /// </summary>
        public void wizardPrev()
        {
            forms[current].DialogResult = DialogResult.OK;
            forms[current--].Close();
        }

        /// <summary>
        /// Exits wizard (ends program)
        /// </summary>
        /// <param name="dialogResult">Dialog result of current form, Cancel - end program.</param>
        /// <returns></returns>
        public bool wizardExit(DialogResult dialogResult)
        {
            if (dialogResult == DialogResult.OK)
                return true;

            if (dialogResult == DialogResult.Abort || MessageBox.Show("Are you sure you want the cancel the installer?"
                , "Installer"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                current = forms.Count;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Application loop function
        /// </summary>
        public void Run()
        {
            while (forms.ContainsKey(current))
            {
                forms[current].ShowDialog();
            }
        }
         
        public IEnumerable<Control> EnumerateControlsRecursive(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                yield return child;
                foreach (Control descendant in EnumerateControlsRecursive(child))
                    yield return descendant;
            }
        }

        public bool checkTextBox(Control parent)
        {
            bool Check = true;
            foreach (Control c in setupWizard.Instance.EnumerateControlsRecursive(parent))
            {
                if (c is TextBox)
                {
                    if (c.Enabled)
                    {
                        c.Text = c.Text.Trim();
                        if (c.Text == "")
                        {
                            Check = false;
                        }
                    }
                }
            }
            return Check;
        }

    }
}
