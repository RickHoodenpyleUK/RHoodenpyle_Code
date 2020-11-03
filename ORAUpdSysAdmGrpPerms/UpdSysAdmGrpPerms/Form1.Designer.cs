namespace ORAUpdSysAdmGrpPerms
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
            this.ORA_HOST_TEXT = new System.Windows.Forms.TextBox();
            this.CONNECTION_BUTTON = new System.Windows.Forms.Button();
            this.ORA_HOST_LABEL = new System.Windows.Forms.Label();
            this.DB_PORT_TEXT = new System.Windows.Forms.TextBox();
            this.DB_PORT_LABEL = new System.Windows.Forms.Label();
            this.PASSWORD_TEXT = new System.Windows.Forms.TextBox();
            this.PASSWORD_LABEL = new System.Windows.Forms.Label();
            this.USERNAME_TEXT = new System.Windows.Forms.TextBox();
            this.USERNAME_LABEL = new System.Windows.Forms.Label();
            this.SERVER_CONNECTION_TEXT = new System.Windows.Forms.TextBox();
            this.SERVER_CONNECTION_LABEL = new System.Windows.Forms.Label();
            this.txtLoginDBName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ORA_HOST_TEXT
            // 
            this.ORA_HOST_TEXT.Location = new System.Drawing.Point(210, 54);
            this.ORA_HOST_TEXT.Name = "ORA_HOST_TEXT";
            this.ORA_HOST_TEXT.Size = new System.Drawing.Size(417, 20);
            this.ORA_HOST_TEXT.TabIndex = 17;
            // 
            // CONNECTION_BUTTON
            // 
            this.CONNECTION_BUTTON.Location = new System.Drawing.Point(462, 172);
            this.CONNECTION_BUTTON.Name = "CONNECTION_BUTTON";
            this.CONNECTION_BUTTON.Size = new System.Drawing.Size(165, 31);
            this.CONNECTION_BUTTON.TabIndex = 22;
            this.CONNECTION_BUTTON.Text = "Update Mercury Permissions";
            this.CONNECTION_BUTTON.UseVisualStyleBackColor = true;
            this.CONNECTION_BUTTON.Click += new System.EventHandler(this.CONNECTION_BUTTON_Click);
            // 
            // ORA_HOST_LABEL
            // 
            this.ORA_HOST_LABEL.AutoSize = true;
            this.ORA_HOST_LABEL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ORA_HOST_LABEL.Location = new System.Drawing.Point(12, 57);
            this.ORA_HOST_LABEL.Name = "ORA_HOST_LABEL";
            this.ORA_HOST_LABEL.Size = new System.Drawing.Size(98, 19);
            this.ORA_HOST_LABEL.TabIndex = 14;
            this.ORA_HOST_LABEL.Text = "Oracle Host";
            // 
            // DB_PORT_TEXT
            // 
            this.DB_PORT_TEXT.Location = new System.Drawing.Point(210, 146);
            this.DB_PORT_TEXT.Name = "DB_PORT_TEXT";
            this.DB_PORT_TEXT.Size = new System.Drawing.Size(417, 20);
            this.DB_PORT_TEXT.TabIndex = 20;
            this.DB_PORT_TEXT.Text = "1521";
            // 
            // DB_PORT_LABEL
            // 
            this.DB_PORT_LABEL.AutoSize = true;
            this.DB_PORT_LABEL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DB_PORT_LABEL.Location = new System.Drawing.Point(12, 149);
            this.DB_PORT_LABEL.Name = "DB_PORT_LABEL";
            this.DB_PORT_LABEL.Size = new System.Drawing.Size(117, 19);
            this.DB_PORT_LABEL.TabIndex = 9;
            this.DB_PORT_LABEL.Text = "Database Port";
            // 
            // PASSWORD_TEXT
            // 
            this.PASSWORD_TEXT.Location = new System.Drawing.Point(210, 123);
            this.PASSWORD_TEXT.Name = "PASSWORD_TEXT";
            this.PASSWORD_TEXT.Size = new System.Drawing.Size(417, 20);
            this.PASSWORD_TEXT.TabIndex = 19;
            this.PASSWORD_TEXT.UseSystemPasswordChar = true;
            // 
            // PASSWORD_LABEL
            // 
            this.PASSWORD_LABEL.AutoSize = true;
            this.PASSWORD_LABEL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PASSWORD_LABEL.Location = new System.Drawing.Point(12, 126);
            this.PASSWORD_LABEL.Name = "PASSWORD_LABEL";
            this.PASSWORD_LABEL.Size = new System.Drawing.Size(86, 19);
            this.PASSWORD_LABEL.TabIndex = 11;
            this.PASSWORD_LABEL.Text = "Password";
            // 
            // USERNAME_TEXT
            // 
            this.USERNAME_TEXT.Location = new System.Drawing.Point(210, 100);
            this.USERNAME_TEXT.Name = "USERNAME_TEXT";
            this.USERNAME_TEXT.Size = new System.Drawing.Size(417, 20);
            this.USERNAME_TEXT.TabIndex = 18;
            // 
            // USERNAME_LABEL
            // 
            this.USERNAME_LABEL.AutoSize = true;
            this.USERNAME_LABEL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.USERNAME_LABEL.Location = new System.Drawing.Point(12, 103);
            this.USERNAME_LABEL.Name = "USERNAME_LABEL";
            this.USERNAME_LABEL.Size = new System.Drawing.Size(93, 19);
            this.USERNAME_LABEL.TabIndex = 10;
            this.USERNAME_LABEL.Text = "User Name";
            // 
            // SERVER_CONNECTION_TEXT
            // 
            this.SERVER_CONNECTION_TEXT.Location = new System.Drawing.Point(210, 31);
            this.SERVER_CONNECTION_TEXT.Name = "SERVER_CONNECTION_TEXT";
            this.SERVER_CONNECTION_TEXT.Size = new System.Drawing.Size(417, 20);
            this.SERVER_CONNECTION_TEXT.TabIndex = 16;
            // 
            // SERVER_CONNECTION_LABEL
            // 
            this.SERVER_CONNECTION_LABEL.AutoSize = true;
            this.SERVER_CONNECTION_LABEL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SERVER_CONNECTION_LABEL.Location = new System.Drawing.Point(12, 34);
            this.SERVER_CONNECTION_LABEL.Name = "SERVER_CONNECTION_LABEL";
            this.SERVER_CONNECTION_LABEL.Size = new System.Drawing.Size(152, 19);
            this.SERVER_CONNECTION_LABEL.TabIndex = 12;
            this.SERVER_CONNECTION_LABEL.Text = "Server/Connection";
            // 
            // txtLoginDBName
            // 
            this.txtLoginDBName.Location = new System.Drawing.Point(210, 77);
            this.txtLoginDBName.Name = "txtLoginDBName";
            this.txtLoginDBName.Size = new System.Drawing.Size(417, 20);
            this.txtLoginDBName.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 19);
            this.label1.TabIndex = 24;
            this.label1.Text = "Login Database Name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 211);
            this.Controls.Add(this.txtLoginDBName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ORA_HOST_TEXT);
            this.Controls.Add(this.CONNECTION_BUTTON);
            this.Controls.Add(this.ORA_HOST_LABEL);
            this.Controls.Add(this.DB_PORT_TEXT);
            this.Controls.Add(this.DB_PORT_LABEL);
            this.Controls.Add(this.PASSWORD_TEXT);
            this.Controls.Add(this.PASSWORD_LABEL);
            this.Controls.Add(this.USERNAME_TEXT);
            this.Controls.Add(this.USERNAME_LABEL);
            this.Controls.Add(this.SERVER_CONNECTION_TEXT);
            this.Controls.Add(this.SERVER_CONNECTION_LABEL);
            this.Name = "Form1";
            this.Text = "ORA Update Mercury SysAdmin Permissions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox ORA_HOST_TEXT;
        public System.Windows.Forms.Button CONNECTION_BUTTON;
        public System.Windows.Forms.Label ORA_HOST_LABEL;
        public System.Windows.Forms.TextBox DB_PORT_TEXT;
        public System.Windows.Forms.Label DB_PORT_LABEL;
        public System.Windows.Forms.TextBox PASSWORD_TEXT;
        public System.Windows.Forms.Label PASSWORD_LABEL;
        public System.Windows.Forms.TextBox USERNAME_TEXT;
        public System.Windows.Forms.Label USERNAME_LABEL;
        public System.Windows.Forms.TextBox SERVER_CONNECTION_TEXT;
        public System.Windows.Forms.Label SERVER_CONNECTION_LABEL;
        public System.Windows.Forms.TextBox txtLoginDBName;
        public System.Windows.Forms.Label label1;
    }
}

