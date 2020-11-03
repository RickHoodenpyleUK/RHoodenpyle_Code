using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;


namespace SetFirewallPorts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MSDTCPORTS_BEGIN_PORT.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            MSDTCPORTS_END_PORT.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            REMOTEIP1_TEXT.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            REMOTEIP2_TEXT.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            REMOTEIP3_TEXT.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            REMOTEIP4_TEXT.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            MSDTCPORTS_BEGIN_PORT.MaxLength = 5;
            MSDTCPORTS_END_PORT.MaxLength = 5;
            REMOTEIP1_TEXT.MaxLength = 3;
            REMOTEIP2_TEXT.MaxLength = 3;
            REMOTEIP3_TEXT.MaxLength = 3;
            REMOTEIP4_TEXT.MaxLength = 3;
            MSDTCPORTS_BEGIN_PORT.TextAlign = HorizontalAlignment.Center;
            MSDTCPORTS_END_PORT.TextAlign = HorizontalAlignment.Center;
            REMOTEIP1_TEXT.TextAlign = HorizontalAlignment.Center;
            REMOTEIP2_TEXT.TextAlign = HorizontalAlignment.Center;
            REMOTEIP3_TEXT.TextAlign = HorizontalAlignment.Center;
            REMOTEIP4_TEXT.TextAlign = HorizontalAlignment.Center;
        }
        public int MSDTCPORTS_END_PORT_TEXT = 0;
        public string MSDTCPORTS = "";
        public int MSDTCPORTS_BEGIN_PORT_TEXT = 0;
        public string REMOTEIP = "";
        public int REMOTEIP1 = 0;
        public int REMOTEIP2 = 0;
        public int REMOTEIP3 = 0;
        public int REMOTEIP4 = 0;
        public string arguments1 = "";
        public string arguments2 = "";
        public string arguments3 = "";
        public string command = "netsh";
        public void fStartInfo(string cmd, string args)
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo(cmd, args);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            Process.Start(procStartInfo);
        }
        private void createRules_BUT_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(MSDTCPORTS_BEGIN_PORT.Text))
            {
                MessageBox.Show("Please enter a number from 1024 to 65535 in the Begin Port textbox");
                MSDTCPORTS_BEGIN_PORT.Focus();
                return;
            }
            if (String.IsNullOrEmpty(MSDTCPORTS_END_PORT.Text))
            {
                MessageBox.Show("Please enter a number from 1024 to 65535 in the End Port textbox");
                MSDTCPORTS_END_PORT.Focus();
                return;
            }
            if (String.IsNullOrEmpty(REMOTEIP1_TEXT.Text))
            {
                MessageBox.Show("Please enter a number from 1 to 255 in the IP1 textbox");
                REMOTEIP1_TEXT.Focus();
                return;
            }
            if (String.IsNullOrEmpty(REMOTEIP2_TEXT.Text))
            {
                MessageBox.Show("Please enter a number from 0 to 255 in the IP2 textbox");
                REMOTEIP2_TEXT.Focus();
                return;
            }
            if (String.IsNullOrEmpty(REMOTEIP3_TEXT.Text))
            {
                MessageBox.Show("Please enter a number from 0 to 255 in the IP3 textbox");
                REMOTEIP3_TEXT.Focus();
                return;
            }
            if (String.IsNullOrEmpty(REMOTEIP4_TEXT.Text))
            {
                MessageBox.Show("Please enter a number from 0 to 255 in the IP4 textbox");
                REMOTEIP4_TEXT.Focus();
                return;
            }
            MSDTCPORTS_BEGIN_PORT_TEXT = Convert.ToInt32(MSDTCPORTS_BEGIN_PORT.Text);
            MSDTCPORTS_END_PORT_TEXT = Convert.ToInt32(MSDTCPORTS_END_PORT.Text);
            REMOTEIP1 = Convert.ToInt32(REMOTEIP1_TEXT.Text);
            REMOTEIP2 = Convert.ToInt32(REMOTEIP2_TEXT.Text);
            REMOTEIP3 = Convert.ToInt32(REMOTEIP3_TEXT.Text);
            REMOTEIP4 = Convert.ToInt32(REMOTEIP4_TEXT.Text);
            MSDTCPORTS_BEGIN_PORT_TEXT = Convert.ToInt32(MSDTCPORTS_BEGIN_PORT.Text);
            if (MSDTCPORTS_BEGIN_PORT_TEXT > MSDTCPORTS_END_PORT_TEXT)
            {
                MessageBox.Show("Begin port cannot be equal to or greater than the End port.");
                MSDTCPORTS_BEGIN_PORT.Focus();
                return;
            }
            if (MSDTCPORTS_END_PORT_TEXT < (MSDTCPORTS_BEGIN_PORT_TEXT + 200))
            {
                MessageBox.Show("Currently the port range is only " + (MSDTCPORTS_END_PORT_TEXT - MSDTCPORTS_BEGIN_PORT_TEXT) + ". Minimum required port range is 200.");
                MSDTCPORTS_BEGIN_PORT.Focus();
                return;
            }
            if ((MSDTCPORTS_BEGIN_PORT_TEXT < 1024) || (MSDTCPORTS_BEGIN_PORT_TEXT > 65535))
            {
                MessageBox.Show("Please enter a number from 1024 to 65535 in the Begin Port textbox");
                MSDTCPORTS_BEGIN_PORT.Focus();
                return;
            }
            else if ((MSDTCPORTS_END_PORT_TEXT < 1024) || (MSDTCPORTS_END_PORT_TEXT > 65535))
            {
                MessageBox.Show("Please enter a number from 1024 to 65535 in the End Port textbox");
                MSDTCPORTS_END_PORT.Focus();
                return;
            }
            else if (REMOTEIP1 > 255)
            {
                MessageBox.Show("Please enter a number from 0 and 255 in the IP1 textbox");
                REMOTEIP1_TEXT.Focus();
                return;
            }
            else if (REMOTEIP2 > 255)
            {
                MessageBox.Show("Please enter a number from 0 and 255 in the IP2 textbox");
                REMOTEIP2_TEXT.Focus();
                return;
            }
            else if (REMOTEIP3 > 255)
            {
                MessageBox.Show("Please enter a number from 0 and 255 in the IP3 textbox");
                REMOTEIP3_TEXT.Focus();
                return;
            }
            else if (REMOTEIP4 > 255)
            {
                MessageBox.Show("Please enter a number from 0 and 255 in the IP4 textbox");
                REMOTEIP4_TEXT.Focus();
                return;
            }
            try
                {
                    MSDTCPORTS = MSDTCPORTS_BEGIN_PORT_TEXT + "-" + MSDTCPORTS_END_PORT_TEXT;
                    if ((REMOTEIP1 == 0) && (REMOTEIP2 == 0) && (REMOTEIP3 == 0) && (REMOTEIP4 == 0))
                    {
                        MessageBox.Show("Please enter a valid IP Address.");
                        REMOTEIP1_TEXT.Focus();
                        return;
                    }
                    else
                    {
                        REMOTEIP = REMOTEIP1 + "." + REMOTEIP2 + "." + REMOTEIP3 + "." + REMOTEIP4;
                    }
                    arguments1 = " advfirewall firewall delete rule name=\"RMS RPC & MSDTC ports\"";
                    arguments2 = " advfirewall firewall add rule name=\"RMS RPC & MSDTC ports\" dir=out action=allow protocol=TCP localport=135," + MSDTCPORTS + " remoteip=" + REMOTEIP;
                    arguments3 = " advfirewall firewall add rule name=\"RMS RPC & MSDTC ports\" dir=in action=allow protocol=TCP localport=135," + MSDTCPORTS + " remoteip=" + REMOTEIP;
                    try
                    {
                        fStartInfo(command, arguments1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        fStartInfo(command, arguments2);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        fStartInfo(command, arguments3);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    string rk1 = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\RPC\Internet\";
                    List<string> kl1 = new List<string>();
                    kl1.Add("Ports");
                    kl1.Add("PortsInternetAvailable");
                    kl1.Add("UseInternetPorts");
                    string rk2 = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\MSDTC\";
                    List<string> kl2 = new List<string>();
                    kl2.Add("AllowOnlySecureRpcCalls");
                    kl2.Add("FallbackToUnsecureRPCIfNecessary");
                    kl2.Add("TurnOffRpcSecurity");
                    string rk3 = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\MSDTC\Security\";
                    List<string> kl3 = new List<string>();
                    kl3.Add("LuTransactions");
                    kl3.Add("NetworkDtcAccess");
                    kl3.Add("NetworkDtcAccessAdmin");
                    kl3.Add("NetworkDtcAccessClients");
                    kl3.Add("NetworkDtcAccessInbound");
                    kl3.Add("NetworkDtcAccessOutbound");
                    kl3.Add("NetworkDtcAccessTransactions");
                    kl3.Add("XaTransactions");
                    kl3.Add("tester");
                    try
                    {
                        foreach (string element in kl1)
                        {
                            try
                            {
                                if (element == "Ports")
                                {
                                    Registry.SetValue(rk1, element, new string[] { MSDTCPORTS }, RegistryValueKind.MultiString);
                                }
                                else
                                {
                                    Registry.SetValue(rk1, element, "Y", RegistryValueKind.String);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        foreach (string element in kl2)
                        {
                            try
                            {
                                RegistryKey regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\MSDTC\", true);
                                if (element == "TurnOffRpcSecurity")
                                {
                                    regKey.SetValue(element, "1", RegistryValueKind.DWord);
                                    regKey.Close();
                                }
                                else
                                {
                                    regKey.SetValue(element, "0", RegistryValueKind.DWord);
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        foreach (string element in kl3)
                        {
                            try
                            {
                                RegistryKey regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\MSDTC\Security\", true);
                                if (element == "tester")
                                {
                                    regKey.SetValue(element, "Testing", RegistryValueKind.String);
                                    Registry.SetValue(rk3, element, "Y", RegistryValueKind.String);
                                    MessageBox.Show(regKey.ToString() + element);
                                }
                                else
                                {
                                    regKey.SetValue(element, "1", RegistryValueKind.DWord);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show("Finished Adding Rules! Please restart the server for the new settings to take effect.");
        }
        
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
