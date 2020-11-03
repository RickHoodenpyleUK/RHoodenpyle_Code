namespace RMSInstaller
{
    partial class wizardThree
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wizardThree));
            this.btBack = new System.Windows.Forms.Button();
            this.btInstall = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.currentSelections = new System.Windows.Forms.TextBox();
            this.currentInstallation = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressMessage = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(248, 329);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 48;
            this.btBack.Text = "< Back";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // btInstall
            // 
            this.btInstall.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btInstall.Location = new System.Drawing.Point(323, 329);
            this.btInstall.Name = "btInstall";
            this.btInstall.Size = new System.Drawing.Size(75, 23);
            this.btInstall.TabIndex = 49;
            this.btInstall.Text = "Install";
            this.btInstall.UseVisualStyleBackColor = true;
            this.btInstall.Click += new System.EventHandler(this.btInstall_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Enabled = false;
            this.btCancel.Location = new System.Drawing.Point(410, 329);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 50;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::RMSInstaller.Properties.Resources.bar;
            this.panel3.Location = new System.Drawing.Point(-2, 318);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(500, 2);
            this.panel3.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Selections";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 21);
            this.panel1.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Installation Progress";
            this.label2.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::RMSInstaller.Properties.Resources.bar;
            this.panel4.Location = new System.Drawing.Point(-2, 21);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(500, 2);
            this.panel4.TabIndex = 46;
            // 
            // currentSelections
            // 
            this.currentSelections.Location = new System.Drawing.Point(12, 42);
            this.currentSelections.Multiline = true;
            this.currentSelections.Name = "currentSelections";
            this.currentSelections.ReadOnly = true;
            this.currentSelections.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.currentSelections.Size = new System.Drawing.Size(386, 237);
            this.currentSelections.TabIndex = 47;
            this.currentSelections.TabStop = false;
            // 
            // currentInstallation
            // 
            this.currentInstallation.Location = new System.Drawing.Point(15, 43);
            this.currentInstallation.Multiline = true;
            this.currentInstallation.Name = "currentInstallation";
            this.currentInstallation.ReadOnly = true;
            this.currentInstallation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.currentInstallation.Size = new System.Drawing.Size(386, 237);
            this.currentInstallation.TabIndex = 52;
            this.currentInstallation.TabStop = false;
            this.currentInstallation.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 286);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(386, 23);
            this.progressBar1.TabIndex = 51;
            this.progressBar1.Visible = false;
            // 
            // progressMessage
            // 
            this.progressMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.progressMessage.Location = new System.Drawing.Point(15, 259);
            this.progressMessage.Name = "progressMessage";
            this.progressMessage.ReadOnly = true;
            this.progressMessage.Size = new System.Drawing.Size(383, 13);
            this.progressMessage.TabIndex = 54;
            this.progressMessage.Visible = false;
            this.progressMessage.WordWrap = false;
            // 
            // wizardThree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 360);
            this.Controls.Add(this.progressMessage);
            this.Controls.Add(this.currentInstallation);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.currentSelections);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.btInstall);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "wizardThree";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RMS Installer D3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetupEnd_FormClosing);
            this.Load += new System.EventHandler(this.wizardThree_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btInstall;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox currentSelections;
        private System.Windows.Forms.TextBox currentInstallation;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox progressMessage;
    }
}