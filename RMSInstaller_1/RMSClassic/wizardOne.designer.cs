namespace RMSInstaller
{
    partial class wizardOne
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wizardOne));
            this.btBack = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.existingYes = new System.Windows.Forms.RadioButton();
            this.existingNo = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.myrmsSchema = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.oDataName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.oLoginName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.oPowerPass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.oPowerName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.databaseServer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.mssql = new System.Windows.Forms.RadioButton();
            this.oracle = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.installationDrive = new System.Windows.Forms.TextBox();
            this.rmsVersion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btBack
            // 
            this.btBack.Enabled = false;
            this.btBack.Location = new System.Drawing.Point(248, 329);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 156;
            this.btBack.Text = "< Back";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // btNext
            // 
            this.btNext.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btNext.Location = new System.Drawing.Point(323, 329);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(75, 23);
            this.btNext.TabIndex = 157;
            this.btNext.Text = "Next >";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(410, 329);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 158;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.Location = new System.Drawing.Point(-2, 318);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(500, 2);
            this.panel3.TabIndex = 37;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 21);
            this.panel1.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Installer Information";
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.Location = new System.Drawing.Point(-2, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(500, 2);
            this.panel4.TabIndex = 45;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.myrmsSchema);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.oDataName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.oLoginName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.oPowerPass);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.oPowerName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.databaseServer);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(8, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 197);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Information";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.existingYes);
            this.panel6.Controls.Add(this.existingNo);
            this.panel6.Location = new System.Drawing.Point(180, 38);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(161, 17);
            this.panel6.TabIndex = 151;
            // 
            // existingYes
            // 
            this.existingYes.AutoSize = true;
            this.existingYes.Location = new System.Drawing.Point(3, 2);
            this.existingYes.Name = "existingYes";
            this.existingYes.Size = new System.Drawing.Size(43, 17);
            this.existingYes.TabIndex = 0;
            this.existingYes.Text = "Yes";
            this.existingYes.UseVisualStyleBackColor = true;
            // 
            // existingNo
            // 
            this.existingNo.AutoSize = true;
            this.existingNo.Checked = true;
            this.existingNo.Location = new System.Drawing.Point(72, 2);
            this.existingNo.Name = "existingNo";
            this.existingNo.Size = new System.Drawing.Size(39, 17);
            this.existingNo.TabIndex = 0;
            this.existingNo.TabStop = true;
            this.existingNo.Text = "No";
            this.existingNo.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 13);
            this.label11.TabIndex = 64;
            this.label11.Text = "Existing Database?";
            // 
            // myrmsSchema
            // 
            this.myrmsSchema.Location = new System.Drawing.Point(180, 171);
            this.myrmsSchema.Name = "myrmsSchema";
            this.myrmsSchema.Size = new System.Drawing.Size(164, 20);
            this.myrmsSchema.TabIndex = 155;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 13);
            this.label10.TabIndex = 62;
            this.label10.Text = "MyRMS Schema Name";
            // 
            // oDataName
            // 
            this.oDataName.Location = new System.Drawing.Point(180, 148);
            this.oDataName.Name = "oDataName";
            this.oDataName.Size = new System.Drawing.Size(164, 20);
            this.oDataName.TabIndex = 154;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 60;
            this.label8.Text = "Real Database Name";
            // 
            // oLoginName
            // 
            this.oLoginName.Location = new System.Drawing.Point(180, 125);
            this.oLoginName.Name = "oLoginName";
            this.oLoginName.Size = new System.Drawing.Size(164, 20);
            this.oLoginName.TabIndex = 153;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 13);
            this.label9.TabIndex = 58;
            this.label9.Text = "Login Database Name";
            // 
            // oPowerPass
            // 
            this.oPowerPass.Location = new System.Drawing.Point(180, 103);
            this.oPowerPass.Name = "oPowerPass";
            this.oPowerPass.PasswordChar = '*';
            this.oPowerPass.Size = new System.Drawing.Size(164, 20);
            this.oPowerPass.TabIndex = 152;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 56;
            this.label7.Text = "DB Power Password";
            // 
            // oPowerName
            // 
            this.oPowerName.Location = new System.Drawing.Point(180, 81);
            this.oPowerName.Name = "oPowerName";
            this.oPowerName.Size = new System.Drawing.Size(164, 20);
            this.oPowerName.TabIndex = 151;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "DB Power Username";
            // 
            // databaseServer
            // 
            this.databaseServer.Location = new System.Drawing.Point(180, 59);
            this.databaseServer.Name = "databaseServer";
            this.databaseServer.Size = new System.Drawing.Size(164, 20);
            this.databaseServer.TabIndex = 150;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "Database Server";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.mssql);
            this.panel5.Controls.Add(this.oracle);
            this.panel5.Location = new System.Drawing.Point(180, 16);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(161, 17);
            this.panel5.TabIndex = 148;
            // 
            // mssql
            // 
            this.mssql.AutoSize = true;
            this.mssql.Checked = true;
            this.mssql.Location = new System.Drawing.Point(3, 2);
            this.mssql.Name = "mssql";
            this.mssql.Size = new System.Drawing.Size(65, 17);
            this.mssql.TabIndex = 0;
            this.mssql.TabStop = true;
            this.mssql.Text = "MS SQL";
            this.mssql.UseVisualStyleBackColor = true;
            this.mssql.CheckedChanged += new System.EventHandler(this.mssql_CheckedChanged);
            // 
            // oracle
            // 
            this.oracle.AutoSize = true;
            this.oracle.Location = new System.Drawing.Point(72, 2);
            this.oracle.Name = "oracle";
            this.oracle.Size = new System.Drawing.Size(56, 17);
            this.oracle.TabIndex = 0;
            this.oracle.Text = "Oracle";
            this.oracle.UseVisualStyleBackColor = true;
            this.oracle.CheckedChanged += new System.EventHandler(this.oracle_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Database Type";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.installationDrive);
            this.groupBox2.Controls.Add(this.rmsVersion);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(8, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 67);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General Information";
            // 
            // installationDrive
            // 
            this.installationDrive.Location = new System.Drawing.Point(180, 41);
            this.installationDrive.Name = "installationDrive";
            this.installationDrive.ReadOnly = true;
            this.installationDrive.Size = new System.Drawing.Size(164, 20);
            this.installationDrive.TabIndex = 48;
            this.installationDrive.TabStop = false;
            // 
            // rmsVersion
            // 
            this.rmsVersion.Location = new System.Drawing.Point(180, 16);
            this.rmsVersion.Name = "rmsVersion";
            this.rmsVersion.ReadOnly = true;
            this.rmsVersion.Size = new System.Drawing.Size(164, 20);
            this.rmsVersion.TabIndex = 47;
            this.rmsVersion.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Installation Drive";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "RMS Version";
            // 
            // wizardOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 360);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.btCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "wizardOne";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RMS Installer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetupEnd_FormClosing);
            this.Load += new System.EventHandler(this.wizardOne_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton mssql;
        private System.Windows.Forms.RadioButton oracle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox databaseServer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox oPowerPass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox oPowerName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox oDataName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox oLoginName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox myrmsSchema;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton existingYes;
        private System.Windows.Forms.RadioButton existingNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox installationDrive;
        private System.Windows.Forms.TextBox rmsVersion;
    }
}