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
using System.Net.Security;
using System.Net.Sockets;
using Microsoft.Win32;
using COMAdmin;
using Microsoft.VisualBasic;
using System.Security;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Threading;
using System.Security.Principal;

namespace RMSInstaller
{
    public partial class wizardTwo : Form
    {
        public wizardTwo()
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
            bool Check = setupWizard.Instance.checkTextBox(wizardTwo.ActiveForm);
            if (Check == false)
            {
                MessageBox.Show(setupWizard.Instance.strFormCheck);
            }
            else if (Check == true)
            {
                setupWizard.Instance.strRMSIISUser = RMSIISUser.Text;
                setupWizard.Instance.strRMSIISPass = RMSIISPass.Text;
                setupWizard.Instance.strRMSCOMUser = RMSCOMUser.Text;
                setupWizard.Instance.strRMSCOMPass = RMSCOMPass.Text;
                setupWizard.Instance.strSoftwareKey = softwareKey.Text;
                setupWizard.Instance.strClientID = clientID.Text;
                setupWizard.Instance.strNumberBeds = numberBeds.Text;
                setupWizard.Instance.strSchoolEmail = schoolEmail.Text;
                setupWizard.Instance.strLocalURL = localURL.Text;
                setupWizard.Instance.strWebURL = "Empty";
                bool credValid = false;
                bool credValid2 = false;
                credValid = validateUsers(setupWizard.Instance.strRMSIISUser, setupWizard.Instance.strRMSIISPass);
                if (!credValid)
                {
                    MessageBox.Show("RMSIIS user credentials are incorrect");
                }
                credValid2 = validateUsers(setupWizard.Instance.strRMSCOMUser, setupWizard.Instance.strRMSCOMPass);
                if (!credValid2)
                {
                    MessageBox.Show("RMSCOM user credentials are incorrect");
                }

                if (checkBoxMerc.Checked)
                {
                    setupWizard.Instance.checkMerc = true;
                }
                else if (!checkBoxMerc.Checked)
                {
                    setupWizard.Instance.checkMerc = false;
                }
                if (checkBoxWS.Checked)
                {
                    setupWizard.Instance.checkWS = true;
                }
                else if (!checkBoxWS.Checked)
                {
                    setupWizard.Instance.checkWS = false;
                }
                if (checkBoxASW.Checked)
                {
                    setupWizard.Instance.checkASW = true;
                }
                else if (!checkBoxASW.Checked)
                {
                    setupWizard.Instance.checkASW = false;
                }
                if (checkBoxPG.Checked)
                {
                    setupWizard.Instance.checkPG = true;
                }
                else if (!checkBoxPG.Checked)
                {
                    setupWizard.Instance.checkPG = false;
                }
                if (checkBoxAS.Checked)
                {
                    setupWizard.Instance.checkAS = true;
                }
                else if (!checkBoxAS.Checked)
                {
                    setupWizard.Instance.checkAS = false;
                }
                if (credValid == true && credValid2 == true)
                {
                    setupWizard.Instance.strRMSIISUser = RMSIISUser.Text;
                    setupWizard.Instance.strRMSIISPass = RMSIISPass.Text;
                    setupWizard.Instance.strRMSCOMUser = RMSCOMUser.Text;
                    setupWizard.Instance.strRMSCOMPass = RMSCOMPass.Text;
                    setupWizard.Instance.CurrentSelections.Add("The RMSIIS user is: " + RMSIISUser.Text);
                    setupWizard.Instance.CurrentSelections.Add("The RMSIIS password is: ******");
                    setupWizard.Instance.CurrentSelections.Add("The RMSCOM user is: " + RMSCOMUser.Text);
                    setupWizard.Instance.CurrentSelections.Add("The RMSCOM password is: ******");
                    setupWizard.Instance.CurrentSelections.Add("The SoftwareKey is: " + softwareKey.Text);
                    setupWizard.Instance.strSoftwareKey = softwareKey.Text;
                    setupWizard.Instance.CurrentSelections.Add("The Client ID is: " + clientID.Text);
                    setupWizard.Instance.strClientID = clientID.Text;
                    setupWizard.Instance.CurrentSelections.Add("The number of beds is: " + numberBeds.Text);
                    setupWizard.Instance.strNumberBeds = numberBeds.Text;
                    setupWizard.Instance.CurrentSelections.Add("The school housing e-mail is: " + schoolEmail.Text);
                    setupWizard.Instance.strSchoolEmail = schoolEmail.Text;
                    setupWizard.Instance.CurrentSelections.Add("The local URL is: " + localURL.Text);
                    setupWizard.Instance.strLocalURL = localURL.Text;
                    setupWizard.Instance.strWebURL = "Empty";
                    setupWizard.Instance.wizardNext();
                }
            }                    
        }
        public bool validateUsers(string User, string Password)
        {
            string strDomain;
            strDomain = "";
            int pos = User.IndexOf(@"\");
            if (pos < 1)
            {
                TcpListener localUserValidate = new TcpListener(IPAddress.Loopback, 0);
                localUserValidate.Start();
                ManualResetEvent done = new ManualResetEvent(false);
                WindowsIdentity id = null;
                localUserValidate.BeginAcceptTcpClient(delegate(IAsyncResult asyncResult)
                {
                    try
                    {
                        using (NegotiateStream serverSide = new NegotiateStream(localUserValidate.EndAcceptTcpClient(asyncResult).GetStream()))
                        {
                            serverSide.AuthenticateAsServer(CredentialCache.DefaultNetworkCredentials,ProtectionLevel.None, TokenImpersonationLevel.Impersonation);
                            id = (WindowsIdentity)serverSide.RemoteIdentity;
                        }
                    }
                    catch (Exception ex)
                    {
                        id = null;
                    }
                    finally
                    { done.Set(); }
                }, null);

                using (NegotiateStream clientSide = new NegotiateStream(new TcpClient("localhost",
             ((IPEndPoint)localUserValidate.LocalEndpoint).Port).GetStream()))
                {
                    try
                    {
                        clientSide.AuthenticateAsClient(new NetworkCredential(User, Password, strDomain),
                         "", ProtectionLevel.None, TokenImpersonationLevel.Impersonation);
                    }
                    catch (Exception ex)
                    {
                        id = null;
                    }
                }
                localUserValidate.Stop();
                done.WaitOne();//Wait until we really have the id populated to continue
                if (id == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            else
            {
                int len = User.Length;
                int pos2 = (pos + 1);
                int len2 = (len - pos2);
                strDomain = User.Substring(0, pos);
                User = User.Substring(pos2, len2);

                PrincipalContext pc2 = new PrincipalContext(ContextType.Domain, strDomain);
                try
                {
                    return pc2.ValidateCredentials(User, Password);
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    pc2.Dispose();
                }
             }
        }
        
        public void wizardTwo_Load(object sender, EventArgs e)
        {

            RMSIISUser.Text = "";
            RMSIISPass.Text = "";
            RMSCOMUser.Text = "";
            RMSCOMPass.Text = "";
            softwareKey.Text = "";
            clientID.Text = "";
            numberBeds.Text = "";
            schoolEmail.Text = "";
            setupWizard.Instance.strRMSIISUser = "";
            setupWizard.Instance.strRMSIISPass = "";
            setupWizard.Instance.strRMSCOMUser = "";
            setupWizard.Instance.strRMSCOMPass = "";
            setupWizard.Instance.strSoftwareKey = "";
            setupWizard.Instance.strClientID = "";
            setupWizard.Instance.strNumberBeds = "";
            setupWizard.Instance.strSchoolEmail = "";
            try
            {
                string domainName = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
                string hostName = Dns.GetHostName();
                string fqdn = "";
                if (!hostName.Contains(domainName))
                    fqdn = hostName + "." + domainName;
                else
                    fqdn = hostName;

                setupWizard.Instance.serverName = hostName;
                setupWizard.Instance.domainName2 = domainName;
                if (domainName == "")
                {
                    localURL.Text = setupWizard.Instance.serverName;
                }
                else
                {
                    localURL.Text = setupWizard.Instance.serverName + "." + setupWizard.Instance.domainName2;
                }
            }
            catch (Exception ex)
            {
                setupWizard.Instance.CurrentSelections.Add(ex.Message + DateTime.Now);

            }
        }

        private void checkBoxPG_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPG.Checked)
            {
                groupBox5.Visible = true;
            }
            if (!checkBoxPG.Checked)
            {
                groupBox5.Visible = false;
                chkAuthorizeNet.Checked = false;
                setupWizard.Instance.bAuthorizeNet = true;
                chkBarclayCard.Checked = false;
                setupWizard.Instance.bBarclayCard = true;
                chkBucksNet.Checked = false;
                setupWizard.Instance.bBucksNet = true;
                chkCashNet.Checked = false;
                setupWizard.Instance.bCashNet = true;
                chkCyberSource.Checked = false;
                setupWizard.Instance.bCyberSource = true;
                chkElavon.Checked = false;
                setupWizard.Instance.bElavon = true;
                chkMoneris.Checked = false;
                setupWizard.Instance.bMoneris = true;
                chkMonerisCA.Checked = false;
                setupWizard.Instance.bMonerisCA = true;
                chkNelNet.Checked = false;
                setupWizard.Instance.bNelNet = true;
                chkPayPal.Checked = false;
                setupWizard.Instance.bPayPal = true;
                chkRealex.Checked = false;
                setupWizard.Instance.bRealex = true;
                chkSallieMae.Checked = false;
                setupWizard.Instance.bSallieMae = true;
                chkTouchNetLink.Checked = false;
                setupWizard.Instance.bTouchNetLink = true;
                chkWPM.Checked = false;
                setupWizard.Instance.bWPM = true;
            }
        }

        private void paymentSave_Click(object sender, EventArgs e)
        {
            if (chkAuthorizeNet.Checked)
            {
                setupWizard.Instance.bAuthorizeNet = true;
            }
            if (chkBarclayCard.Checked)
            {
                setupWizard.Instance.bBarclayCard = true;
            }
            if (chkBucksNet.Checked)
            {
                setupWizard.Instance.bBucksNet = true;
            }
            if (chkCashNet.Checked)
            {
                setupWizard.Instance.bCashNet = true;
            }
            if (chkCyberSource.Checked)
            {
                setupWizard.Instance.bCyberSource = true;
            }
            if (chkElavon.Checked)
            {
                setupWizard.Instance.bElavon = true;
            }
            if (chkMoneris.Checked)
            {
                setupWizard.Instance.bMoneris = true;
            }
            if (chkMonerisCA.Checked)
            {
                setupWizard.Instance.bMonerisCA = true;
            }
            if (chkNelNet.Checked)
            {
                setupWizard.Instance.bNelNet = true;
            }
            if (chkPayPal.Checked)
            {
                setupWizard.Instance.bPayPal = true;
            }
            if (chkRealex.Checked)
            {
                setupWizard.Instance.bRealex = true;
            }
            if (chkSallieMae.Checked)
            {
                setupWizard.Instance.bSallieMae = true;
            }
            if (chkTouchNetLink.Checked)
            {
                setupWizard.Instance.bTouchNetLink = true;
            }
            if (chkWPM.Checked)
            {
                setupWizard.Instance.bWPM = true;
            }
            groupBox5.Visible = false;

        }
    }
}
