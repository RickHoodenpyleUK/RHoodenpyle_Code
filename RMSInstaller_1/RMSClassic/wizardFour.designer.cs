namespace RMSInstaller
{
    partial class wizardFour
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wizardFour));
            this.btFinish = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btFinish
            // 
            this.btFinish.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btFinish.Location = new System.Drawing.Point(323, 329);
            this.btFinish.Name = "btFinish";
            this.btFinish.Size = new System.Drawing.Size(75, 23);
            this.btFinish.TabIndex = 35;
            this.btFinish.Text = "Finish";
            this.btFinish.UseVisualStyleBackColor = true;
            this.btFinish.Click += new System.EventHandler(this.btFinish_Click);
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
            this.label1.Size = new System.Drawing.Size(116, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "General Information";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 21);
            this.panel1.TabIndex = 39;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::RMSInstaller.Properties.Resources.bar;
            this.panel4.Location = new System.Drawing.Point(-2, 21);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(500, 2);
            this.panel4.TabIndex = 46;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(22, 46);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(376, 266);
            this.textBox1.TabIndex = 47;
            // 
            // wizardFour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 360);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btFinish);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "wizardFour";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RMS Installer D4";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetupEnd_FormClosing);
            this.Load += new System.EventHandler(this.wizardFour_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btFinish;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox1;
    }
}