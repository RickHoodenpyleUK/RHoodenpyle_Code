namespace HostedFileAccessSetup
{
    partial class HostedFileAccessSetup
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.vpnUsernameTextBox = new System.Windows.Forms.TextBox();
            this.vpnPassTextBox = new System.Windows.Forms.TextBox();
            this.SetupFileAccessBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "VPN Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "VPN Password";
            // 
            // vpnUsernameTextBox
            // 
            this.vpnUsernameTextBox.Location = new System.Drawing.Point(165, 34);
            this.vpnUsernameTextBox.Name = "vpnUsernameTextBox";
            this.vpnUsernameTextBox.Size = new System.Drawing.Size(354, 20);
            this.vpnUsernameTextBox.TabIndex = 2;
            // 
            // vpnPassTextBox
            // 
            this.vpnPassTextBox.Location = new System.Drawing.Point(165, 65);
            this.vpnPassTextBox.Name = "vpnPassTextBox";
            this.vpnPassTextBox.PasswordChar = '*';
            this.vpnPassTextBox.Size = new System.Drawing.Size(354, 20);
            this.vpnPassTextBox.TabIndex = 3;
            // 
            // SetupFileAccessBut
            // 
            this.SetupFileAccessBut.Location = new System.Drawing.Point(411, 105);
            this.SetupFileAccessBut.Name = "SetupFileAccessBut";
            this.SetupFileAccessBut.Size = new System.Drawing.Size(107, 23);
            this.SetupFileAccessBut.TabIndex = 4;
            this.SetupFileAccessBut.Text = "Setup File Access";
            this.SetupFileAccessBut.UseVisualStyleBackColor = true;
            this.SetupFileAccessBut.Click += new System.EventHandler(this.SetupFileAccessBut_Click);
            // 
            // HostedFileAccessSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 181);
            this.Controls.Add(this.SetupFileAccessBut);
            this.Controls.Add(this.vpnPassTextBox);
            this.Controls.Add(this.vpnUsernameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HostedFileAccessSetup";
            this.Text = "Hosted File Access Setup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox vpnUsernameTextBox;
        private System.Windows.Forms.TextBox vpnPassTextBox;
        private System.Windows.Forms.Button SetupFileAccessBut;
    }
}

