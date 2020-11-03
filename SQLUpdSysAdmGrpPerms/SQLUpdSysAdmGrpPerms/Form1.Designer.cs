namespace SQLUpdSysAdmGrpPerms
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
            this.txtLoginDBName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CONNECTION_BUTTON = new System.Windows.Forms.Button();
            this.PASSWORD_TEXT = new System.Windows.Forms.TextBox();
            this.PASSWORD_LABEL = new System.Windows.Forms.Label();
            this.USERNAME_TEXT = new System.Windows.Forms.TextBox();
            this.USERNAME_LABEL = new System.Windows.Forms.Label();
            this.SERVER_CONNECTION_TEXT = new System.Windows.Forms.TextBox();
            this.SERVER_CONNECTION_LABEL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtLoginDBName
            // 
            this.txtLoginDBName.Location = new System.Drawing.Point(204, 39);
            this.txtLoginDBName.Name = "txtLoginDBName";
            this.txtLoginDBName.Size = new System.Drawing.Size(417, 20);
            this.txtLoginDBName.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 19);
            this.label1.TabIndex = 37;
            this.label1.Text = "Login Database Name";
            // 
            // CONNECTION_BUTTON
            // 
            this.CONNECTION_BUTTON.Location = new System.Drawing.Point(456, 109);
            this.CONNECTION_BUTTON.Name = "CONNECTION_BUTTON";
            this.CONNECTION_BUTTON.Size = new System.Drawing.Size(165, 31);
            this.CONNECTION_BUTTON.TabIndex = 36;
            this.CONNECTION_BUTTON.Text = "Update Mercury Permissions";
            this.CONNECTION_BUTTON.UseVisualStyleBackColor = true;
            this.CONNECTION_BUTTON.Click += new System.EventHandler(this.CONNECTION_BUTTON_Click_1);
            // 
            // PASSWORD_TEXT
            // 
            this.PASSWORD_TEXT.Location = new System.Drawing.Point(204, 85);
            this.PASSWORD_TEXT.Name = "PASSWORD_TEXT";
            this.PASSWORD_TEXT.Size = new System.Drawing.Size(417, 20);
            this.PASSWORD_TEXT.TabIndex = 34;
            this.PASSWORD_TEXT.UseSystemPasswordChar = true;
            // 
            // PASSWORD_LABEL
            // 
            this.PASSWORD_LABEL.AutoSize = true;
            this.PASSWORD_LABEL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PASSWORD_LABEL.Location = new System.Drawing.Point(6, 88);
            this.PASSWORD_LABEL.Name = "PASSWORD_LABEL";
            this.PASSWORD_LABEL.Size = new System.Drawing.Size(86, 19);
            this.PASSWORD_LABEL.TabIndex = 28;
            this.PASSWORD_LABEL.Text = "Password";
            // 
            // USERNAME_TEXT
            // 
            this.USERNAME_TEXT.Location = new System.Drawing.Point(204, 62);
            this.USERNAME_TEXT.Name = "USERNAME_TEXT";
            this.USERNAME_TEXT.Size = new System.Drawing.Size(417, 20);
            this.USERNAME_TEXT.TabIndex = 33;
            // 
            // USERNAME_LABEL
            // 
            this.USERNAME_LABEL.AutoSize = true;
            this.USERNAME_LABEL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.USERNAME_LABEL.Location = new System.Drawing.Point(6, 65);
            this.USERNAME_LABEL.Name = "USERNAME_LABEL";
            this.USERNAME_LABEL.Size = new System.Drawing.Size(93, 19);
            this.USERNAME_LABEL.TabIndex = 27;
            this.USERNAME_LABEL.Text = "User Name";
            // 
            // SERVER_CONNECTION_TEXT
            // 
            this.SERVER_CONNECTION_TEXT.Location = new System.Drawing.Point(204, 16);
            this.SERVER_CONNECTION_TEXT.Name = "SERVER_CONNECTION_TEXT";
            this.SERVER_CONNECTION_TEXT.Size = new System.Drawing.Size(417, 20);
            this.SERVER_CONNECTION_TEXT.TabIndex = 31;
            // 
            // SERVER_CONNECTION_LABEL
            // 
            this.SERVER_CONNECTION_LABEL.AutoSize = true;
            this.SERVER_CONNECTION_LABEL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SERVER_CONNECTION_LABEL.Location = new System.Drawing.Point(6, 19);
            this.SERVER_CONNECTION_LABEL.Name = "SERVER_CONNECTION_LABEL";
            this.SERVER_CONNECTION_LABEL.Size = new System.Drawing.Size(128, 19);
            this.SERVER_CONNECTION_LABEL.TabIndex = 29;
            this.SERVER_CONNECTION_LABEL.Text = "Server\\Instance";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 151);
            this.Controls.Add(this.txtLoginDBName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CONNECTION_BUTTON);
            this.Controls.Add(this.PASSWORD_TEXT);
            this.Controls.Add(this.PASSWORD_LABEL);
            this.Controls.Add(this.USERNAME_TEXT);
            this.Controls.Add(this.USERNAME_LABEL);
            this.Controls.Add(this.SERVER_CONNECTION_TEXT);
            this.Controls.Add(this.SERVER_CONNECTION_LABEL);
            this.Name = "Form1";
            this.Text = "SQL Update Mercury SysAdmin Permissions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtLoginDBName;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button CONNECTION_BUTTON;
        public System.Windows.Forms.TextBox PASSWORD_TEXT;
        public System.Windows.Forms.Label PASSWORD_LABEL;
        public System.Windows.Forms.TextBox USERNAME_TEXT;
        public System.Windows.Forms.Label USERNAME_LABEL;
        public System.Windows.Forms.TextBox SERVER_CONNECTION_TEXT;
        public System.Windows.Forms.Label SERVER_CONNECTION_LABEL;
    }
}

