namespace SetFirewallPorts
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MSDTCPORTS_END_PORT = new System.Windows.Forms.TextBox();
            this.REMOTEIP1_TEXT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.createRules_BUT = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.MSDTCPORTS_BEGIN_PORT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.REMOTEIP2_TEXT = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.REMOTEIP3_TEXT = new System.Windows.Forms.TextBox();
            this.REMOTEIP4_TEXT = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MSDTCPORTS_END_PORT
            // 
            this.MSDTCPORTS_END_PORT.Location = new System.Drawing.Point(365, 26);
            this.MSDTCPORTS_END_PORT.Name = "MSDTCPORTS_END_PORT";
            this.MSDTCPORTS_END_PORT.Size = new System.Drawing.Size(86, 20);
            this.MSDTCPORTS_END_PORT.TabIndex = 2;
            this.MSDTCPORTS_END_PORT.Text = "5200";
            this.MSDTCPORTS_END_PORT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // REMOTEIP1_TEXT
            // 
            this.REMOTEIP1_TEXT.Location = new System.Drawing.Point(240, 70);
            this.REMOTEIP1_TEXT.Name = "REMOTEIP1_TEXT";
            this.REMOTEIP1_TEXT.Size = new System.Drawing.Size(44, 20);
            this.REMOTEIP1_TEXT.TabIndex = 3;
            this.REMOTEIP1_TEXT.Text = "0";
            this.REMOTEIP1_TEXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter MSDTC Port Range (eg 5000-5200):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter Remote Host IP Address:";
            // 
            // createRules_BUT
            // 
            this.createRules_BUT.Location = new System.Drawing.Point(287, 105);
            this.createRules_BUT.Name = "createRules_BUT";
            this.createRules_BUT.Size = new System.Drawing.Size(164, 23);
            this.createRules_BUT.TabIndex = 7;
            this.createRules_BUT.Text = "Create Firewall Rules";
            this.createRules_BUT.UseVisualStyleBackColor = true;
            this.createRules_BUT.Click += new System.EventHandler(this.createRules_BUT_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "---";
            // 
            // MSDTCPORTS_BEGIN_PORT
            // 
            this.MSDTCPORTS_BEGIN_PORT.Location = new System.Drawing.Point(240, 26);
            this.MSDTCPORTS_BEGIN_PORT.Name = "MSDTCPORTS_BEGIN_PORT";
            this.MSDTCPORTS_BEGIN_PORT.Size = new System.Drawing.Size(97, 20);
            this.MSDTCPORTS_BEGIN_PORT.TabIndex = 1;
            this.MSDTCPORTS_BEGIN_PORT.Text = "5000";
            this.MSDTCPORTS_BEGIN_PORT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Begin Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(378, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "End Port";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(283, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 24);
            this.label6.TabIndex = 9;
            this.label6.Text = ".";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(335, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 24);
            this.label7.TabIndex = 11;
            this.label7.Text = ".";
            // 
            // REMOTEIP2_TEXT
            // 
            this.REMOTEIP2_TEXT.Location = new System.Drawing.Point(290, 70);
            this.REMOTEIP2_TEXT.Name = "REMOTEIP2_TEXT";
            this.REMOTEIP2_TEXT.Size = new System.Drawing.Size(47, 20);
            this.REMOTEIP2_TEXT.TabIndex = 4;
            this.REMOTEIP2_TEXT.Text = "0";
            this.REMOTEIP2_TEXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(386, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 24);
            this.label8.TabIndex = 13;
            this.label8.Text = ".";
            // 
            // REMOTEIP3_TEXT
            // 
            this.REMOTEIP3_TEXT.Location = new System.Drawing.Point(344, 70);
            this.REMOTEIP3_TEXT.Name = "REMOTEIP3_TEXT";
            this.REMOTEIP3_TEXT.Size = new System.Drawing.Size(49, 20);
            this.REMOTEIP3_TEXT.TabIndex = 5;
            this.REMOTEIP3_TEXT.Text = "0";
            this.REMOTEIP3_TEXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // REMOTEIP4_TEXT
            // 
            this.REMOTEIP4_TEXT.Location = new System.Drawing.Point(395, 70);
            this.REMOTEIP4_TEXT.Name = "REMOTEIP4_TEXT";
            this.REMOTEIP4_TEXT.Size = new System.Drawing.Size(54, 20);
            this.REMOTEIP4_TEXT.TabIndex = 6;
            this.REMOTEIP4_TEXT.Text = "0";
            this.REMOTEIP4_TEXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(251, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "IP 1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(301, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "IP 2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(352, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "IP 3";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(410, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "IP 4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 142);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.REMOTEIP4_TEXT);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.REMOTEIP3_TEXT);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.REMOTEIP2_TEXT);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MSDTCPORTS_BEGIN_PORT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.createRules_BUT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.REMOTEIP1_TEXT);
            this.Controls.Add(this.MSDTCPORTS_END_PORT);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Add Firewall and RPC Port Range Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MSDTCPORTS_END_PORT;
        private System.Windows.Forms.TextBox REMOTEIP1_TEXT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button createRules_BUT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MSDTCPORTS_BEGIN_PORT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox REMOTEIP2_TEXT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox REMOTEIP3_TEXT;
        private System.Windows.Forms.TextBox REMOTEIP4_TEXT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

