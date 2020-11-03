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
    public partial class wizardFour : Form
    {
        public wizardFour()
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

        private void btFinish_Click(object sender, EventArgs e)
        {
            setupWizard.Instance.wizardExit(this.DialogResult);
        }

        private void wizardFour_Load(object sender, EventArgs e)
        {
                textBox1.Text += setupWizard.Instance.installerResult;
         }      

    }
}
