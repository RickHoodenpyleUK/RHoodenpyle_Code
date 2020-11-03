namespace RemoveDuplicatePostingIDs
{
    partial class RemoveDuplicatePostingIDs
    {

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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoveDuplicatePostingIDs));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.Connection_Tab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.DB_Name_Text = new System.Windows.Forms.TextBox();
            this.CONNECTION_STRING_TEXT_BOX = new System.Windows.Forms.TextBox();
            this.ORA_HOST_TEXT = new System.Windows.Forms.TextBox();
            this.CONNECTION_BUTTON = new System.Windows.Forms.Button();
            this.ORA_HOST_LABEL = new System.Windows.Forms.Label();
            this.DB_PORT_TEXT = new System.Windows.Forms.TextBox();
            this.DB_PORT_LABEL = new System.Windows.Forms.Label();
            this.CON_INSTRUCTIONS_TEXT = new System.Windows.Forms.TextBox();
            this.PASSWORD_TEXT = new System.Windows.Forms.TextBox();
            this.PASSWORD_LABEL = new System.Windows.Forms.Label();
            this.USERNAME_TEXT = new System.Windows.Forms.TextBox();
            this.USERNAME_LABEL = new System.Windows.Forms.Label();
            this.SERVER_CONNECTION_TEXT = new System.Windows.Forms.TextBox();
            this.SERVER_CONNECTION_LABEL = new System.Windows.Forms.Label();
            this.DB_TYPE_COMBO = new System.Windows.Forms.ComboBox();
            this.DB_TYPE_LABEL = new System.Windows.Forms.Label();
            this.INVOICE_Tab = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CREDITINVOICE_Tab = new System.Windows.Forms.TabPage();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.PAYMENT_Tab = new System.Windows.Forms.TabPage();
            this.dataGridView7 = new System.Windows.Forms.DataGridView();
            this.dataGridView8 = new System.Windows.Forms.DataGridView();
            this.dataGridView9 = new System.Windows.Forms.DataGridView();
            this.TRANSFER_Tab = new System.Windows.Forms.TabPage();
            this.dataGridView10 = new System.Windows.Forms.DataGridView();
            this.dataGridView11 = new System.Windows.Forms.DataGridView();
            this.dataGridView12 = new System.Windows.Forms.DataGridView();
            this.REMOVEDUPES_tab = new System.Windows.Forms.TabPage();
            this.upIncrementalID_but = new System.Windows.Forms.Button();
            this.dataGridView14 = new System.Windows.Forms.DataGridView();
            this.dataGridView13 = new System.Windows.Forms.DataGridView();
            this.runSelectQueries = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rd_PostingID = new System.Windows.Forms.TextBox();
            this.Done_Tab = new System.Windows.Forms.TabPage();
            this.intrtProcessesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BK_Selection_CHBOX = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Process_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Process_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dataGridView15 = new System.Windows.Forms.DataGridView();
            this.TabControl1.SuspendLayout();
            this.Connection_Tab.SuspendLayout();
            this.INVOICE_Tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.CREDITINVOICE_Tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            this.PAYMENT_Tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView9)).BeginInit();
            this.TRANSFER_Tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView12)).BeginInit();
            this.REMOVEDUPES_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intrtProcessesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView15)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.Connection_Tab);
            this.TabControl1.Controls.Add(this.INVOICE_Tab);
            this.TabControl1.Controls.Add(this.CREDITINVOICE_Tab);
            this.TabControl1.Controls.Add(this.PAYMENT_Tab);
            this.TabControl1.Controls.Add(this.TRANSFER_Tab);
            this.TabControl1.Controls.Add(this.REMOVEDUPES_tab);
            this.TabControl1.Controls.Add(this.Done_Tab);
            this.TabControl1.Font = new System.Drawing.Font("Arial Narrow", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl1.Location = new System.Drawing.Point(12, 12);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(683, 561);
            this.TabControl1.TabIndex = 0;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Connection_Tab
            // 
            this.Connection_Tab.AutoScroll = true;
            this.Connection_Tab.Controls.Add(this.label1);
            this.Connection_Tab.Controls.Add(this.DB_Name_Text);
            this.Connection_Tab.Controls.Add(this.CONNECTION_STRING_TEXT_BOX);
            this.Connection_Tab.Controls.Add(this.ORA_HOST_TEXT);
            this.Connection_Tab.Controls.Add(this.CONNECTION_BUTTON);
            this.Connection_Tab.Controls.Add(this.ORA_HOST_LABEL);
            this.Connection_Tab.Controls.Add(this.DB_PORT_TEXT);
            this.Connection_Tab.Controls.Add(this.DB_PORT_LABEL);
            this.Connection_Tab.Controls.Add(this.CON_INSTRUCTIONS_TEXT);
            this.Connection_Tab.Controls.Add(this.PASSWORD_TEXT);
            this.Connection_Tab.Controls.Add(this.PASSWORD_LABEL);
            this.Connection_Tab.Controls.Add(this.USERNAME_TEXT);
            this.Connection_Tab.Controls.Add(this.USERNAME_LABEL);
            this.Connection_Tab.Controls.Add(this.SERVER_CONNECTION_TEXT);
            this.Connection_Tab.Controls.Add(this.SERVER_CONNECTION_LABEL);
            this.Connection_Tab.Controls.Add(this.DB_TYPE_COMBO);
            this.Connection_Tab.Controls.Add(this.DB_TYPE_LABEL);
            this.Connection_Tab.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connection_Tab.Location = new System.Drawing.Point(4, 29);
            this.Connection_Tab.Name = "Connection_Tab";
            this.Connection_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Connection_Tab.Size = new System.Drawing.Size(675, 528);
            this.Connection_Tab.TabIndex = 1;
            this.Connection_Tab.Text = "Connection";
            this.Connection_Tab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Data Database name";
            // 
            // DB_Name_Text
            // 
            this.DB_Name_Text.Location = new System.Drawing.Point(204, 114);
            this.DB_Name_Text.Name = "DB_Name_Text";
            this.DB_Name_Text.Size = new System.Drawing.Size(417, 26);
            this.DB_Name_Text.TabIndex = 4;
            // 
            // CONNECTION_STRING_TEXT_BOX
            // 
            this.CONNECTION_STRING_TEXT_BOX.Enabled = false;
            this.CONNECTION_STRING_TEXT_BOX.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CONNECTION_STRING_TEXT_BOX.Location = new System.Drawing.Point(10, 274);
            this.CONNECTION_STRING_TEXT_BOX.Multiline = true;
            this.CONNECTION_STRING_TEXT_BOX.Name = "CONNECTION_STRING_TEXT_BOX";
            this.CONNECTION_STRING_TEXT_BOX.Size = new System.Drawing.Size(611, 60);
            this.CONNECTION_STRING_TEXT_BOX.TabIndex = 9;
            this.CONNECTION_STRING_TEXT_BOX.Text = "Connection String";
            // 
            // ORA_HOST_TEXT
            // 
            this.ORA_HOST_TEXT.Location = new System.Drawing.Point(204, 81);
            this.ORA_HOST_TEXT.Name = "ORA_HOST_TEXT";
            this.ORA_HOST_TEXT.Size = new System.Drawing.Size(417, 26);
            this.ORA_HOST_TEXT.TabIndex = 3;
            // 
            // CONNECTION_BUTTON
            // 
            this.CONNECTION_BUTTON.Location = new System.Drawing.Point(585, 454);
            this.CONNECTION_BUTTON.Name = "CONNECTION_BUTTON";
            this.CONNECTION_BUTTON.Size = new System.Drawing.Size(75, 31);
            this.CONNECTION_BUTTON.TabIndex = 8;
            this.CONNECTION_BUTTON.Text = "Connect";
            this.CONNECTION_BUTTON.UseVisualStyleBackColor = true;
            this.CONNECTION_BUTTON.Click += new System.EventHandler(this.CONNECTION_BUTTON_Click);
            // 
            // ORA_HOST_LABEL
            // 
            this.ORA_HOST_LABEL.AutoSize = true;
            this.ORA_HOST_LABEL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ORA_HOST_LABEL.Location = new System.Drawing.Point(6, 84);
            this.ORA_HOST_LABEL.Name = "ORA_HOST_LABEL";
            this.ORA_HOST_LABEL.Size = new System.Drawing.Size(98, 19);
            this.ORA_HOST_LABEL.TabIndex = 0;
            this.ORA_HOST_LABEL.Text = "Oracle Host";
            // 
            // DB_PORT_TEXT
            // 
            this.DB_PORT_TEXT.Location = new System.Drawing.Point(205, 214);
            this.DB_PORT_TEXT.Name = "DB_PORT_TEXT";
            this.DB_PORT_TEXT.Size = new System.Drawing.Size(417, 26);
            this.DB_PORT_TEXT.TabIndex = 7;
            this.DB_PORT_TEXT.Text = "1521";
            // 
            // DB_PORT_LABEL
            // 
            this.DB_PORT_LABEL.AutoSize = true;
            this.DB_PORT_LABEL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DB_PORT_LABEL.Location = new System.Drawing.Point(7, 217);
            this.DB_PORT_LABEL.Name = "DB_PORT_LABEL";
            this.DB_PORT_LABEL.Size = new System.Drawing.Size(117, 19);
            this.DB_PORT_LABEL.TabIndex = 0;
            this.DB_PORT_LABEL.Text = "Database Port";
            // 
            // CON_INSTRUCTIONS_TEXT
            // 
            this.CON_INSTRUCTIONS_TEXT.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold);
            this.CON_INSTRUCTIONS_TEXT.Location = new System.Drawing.Point(10, 340);
            this.CON_INSTRUCTIONS_TEXT.Multiline = true;
            this.CON_INSTRUCTIONS_TEXT.Name = "CON_INSTRUCTIONS_TEXT";
            this.CON_INSTRUCTIONS_TEXT.ReadOnly = true;
            this.CON_INSTRUCTIONS_TEXT.Size = new System.Drawing.Size(650, 110);
            this.CON_INSTRUCTIONS_TEXT.TabIndex = 0;
            this.CON_INSTRUCTIONS_TEXT.Text = resources.GetString("CON_INSTRUCTIONS_TEXT.Text");
            // 
            // PASSWORD_TEXT
            // 
            this.PASSWORD_TEXT.Location = new System.Drawing.Point(204, 178);
            this.PASSWORD_TEXT.Name = "PASSWORD_TEXT";
            this.PASSWORD_TEXT.Size = new System.Drawing.Size(417, 26);
            this.PASSWORD_TEXT.TabIndex = 6;
            this.PASSWORD_TEXT.UseSystemPasswordChar = true;
            // 
            // PASSWORD_LABEL
            // 
            this.PASSWORD_LABEL.AutoSize = true;
            this.PASSWORD_LABEL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PASSWORD_LABEL.Location = new System.Drawing.Point(6, 181);
            this.PASSWORD_LABEL.Name = "PASSWORD_LABEL";
            this.PASSWORD_LABEL.Size = new System.Drawing.Size(86, 19);
            this.PASSWORD_LABEL.TabIndex = 0;
            this.PASSWORD_LABEL.Text = "Password";
            // 
            // USERNAME_TEXT
            // 
            this.USERNAME_TEXT.Location = new System.Drawing.Point(204, 146);
            this.USERNAME_TEXT.Name = "USERNAME_TEXT";
            this.USERNAME_TEXT.Size = new System.Drawing.Size(417, 26);
            this.USERNAME_TEXT.TabIndex = 5;
            // 
            // USERNAME_LABEL
            // 
            this.USERNAME_LABEL.AutoSize = true;
            this.USERNAME_LABEL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.USERNAME_LABEL.Location = new System.Drawing.Point(6, 149);
            this.USERNAME_LABEL.Name = "USERNAME_LABEL";
            this.USERNAME_LABEL.Size = new System.Drawing.Size(93, 19);
            this.USERNAME_LABEL.TabIndex = 0;
            this.USERNAME_LABEL.Text = "User Name";
            // 
            // SERVER_CONNECTION_TEXT
            // 
            this.SERVER_CONNECTION_TEXT.Location = new System.Drawing.Point(204, 51);
            this.SERVER_CONNECTION_TEXT.Name = "SERVER_CONNECTION_TEXT";
            this.SERVER_CONNECTION_TEXT.Size = new System.Drawing.Size(417, 26);
            this.SERVER_CONNECTION_TEXT.TabIndex = 2;
            // 
            // SERVER_CONNECTION_LABEL
            // 
            this.SERVER_CONNECTION_LABEL.AutoSize = true;
            this.SERVER_CONNECTION_LABEL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SERVER_CONNECTION_LABEL.Location = new System.Drawing.Point(6, 54);
            this.SERVER_CONNECTION_LABEL.Name = "SERVER_CONNECTION_LABEL";
            this.SERVER_CONNECTION_LABEL.Size = new System.Drawing.Size(152, 19);
            this.SERVER_CONNECTION_LABEL.TabIndex = 0;
            this.SERVER_CONNECTION_LABEL.Text = "Server/Connection";
            // 
            // DB_TYPE_COMBO
            // 
            this.DB_TYPE_COMBO.FormattingEnabled = true;
            this.DB_TYPE_COMBO.Items.AddRange(new object[] {
            "SQL",
            "Oracle"});
            this.DB_TYPE_COMBO.Location = new System.Drawing.Point(205, 16);
            this.DB_TYPE_COMBO.Name = "DB_TYPE_COMBO";
            this.DB_TYPE_COMBO.Size = new System.Drawing.Size(417, 28);
            this.DB_TYPE_COMBO.TabIndex = 1;
            this.DB_TYPE_COMBO.Text = "Select Database Type";
            this.DB_TYPE_COMBO.SelectedIndexChanged += new System.EventHandler(this.DB_TYPE_COMBO_SelectedIndexChanged);
            // 
            // DB_TYPE_LABEL
            // 
            this.DB_TYPE_LABEL.AutoSize = true;
            this.DB_TYPE_LABEL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DB_TYPE_LABEL.Location = new System.Drawing.Point(6, 19);
            this.DB_TYPE_LABEL.Name = "DB_TYPE_LABEL";
            this.DB_TYPE_LABEL.Size = new System.Drawing.Size(122, 19);
            this.DB_TYPE_LABEL.TabIndex = 0;
            this.DB_TYPE_LABEL.Text = "Database Type";
            // 
            // INVOICE_Tab
            // 
            this.INVOICE_Tab.AutoScroll = true;
            this.INVOICE_Tab.Controls.Add(this.dataGridView3);
            this.INVOICE_Tab.Controls.Add(this.dataGridView2);
            this.INVOICE_Tab.Controls.Add(this.dataGridView1);
            this.INVOICE_Tab.Location = new System.Drawing.Point(4, 29);
            this.INVOICE_Tab.Name = "INVOICE_Tab";
            this.INVOICE_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.INVOICE_Tab.Size = new System.Drawing.Size(675, 528);
            this.INVOICE_Tab.TabIndex = 2;
            this.INVOICE_Tab.Text = "INVOICE";
            this.INVOICE_Tab.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToResizeColumns = false;
            this.dataGridView3.AllowUserToResizeRows = false;
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(6, 349);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(663, 173);
            this.dataGridView3.TabIndex = 3;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 167);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(663, 176);
            this.dataGridView2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 15;
            this.dataGridView1.Size = new System.Drawing.Size(663, 155);
            this.dataGridView1.TabIndex = 1;
            // 
            // CREDITINVOICE_Tab
            // 
            this.CREDITINVOICE_Tab.Controls.Add(this.dataGridView4);
            this.CREDITINVOICE_Tab.Controls.Add(this.dataGridView5);
            this.CREDITINVOICE_Tab.Controls.Add(this.dataGridView6);
            this.CREDITINVOICE_Tab.Location = new System.Drawing.Point(4, 29);
            this.CREDITINVOICE_Tab.Name = "CREDITINVOICE_Tab";
            this.CREDITINVOICE_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.CREDITINVOICE_Tab.Size = new System.Drawing.Size(675, 528);
            this.CREDITINVOICE_Tab.TabIndex = 3;
            this.CREDITINVOICE_Tab.Text = "CREDIT_INVOICE";
            this.CREDITINVOICE_Tab.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.AllowUserToResizeColumns = false;
            this.dataGridView4.AllowUserToResizeRows = false;
            this.dataGridView4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(6, 349);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.ReadOnly = true;
            this.dataGridView4.Size = new System.Drawing.Size(663, 173);
            this.dataGridView4.TabIndex = 12;
            // 
            // dataGridView5
            // 
            this.dataGridView5.AllowUserToAddRows = false;
            this.dataGridView5.AllowUserToDeleteRows = false;
            this.dataGridView5.AllowUserToResizeColumns = false;
            this.dataGridView5.AllowUserToResizeRows = false;
            this.dataGridView5.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Location = new System.Drawing.Point(6, 167);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.ReadOnly = true;
            this.dataGridView5.Size = new System.Drawing.Size(663, 176);
            this.dataGridView5.TabIndex = 11;
            // 
            // dataGridView6
            // 
            this.dataGridView6.AllowUserToAddRows = false;
            this.dataGridView6.AllowUserToDeleteRows = false;
            this.dataGridView6.AllowUserToResizeColumns = false;
            this.dataGridView6.AllowUserToResizeRows = false;
            this.dataGridView6.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Location = new System.Drawing.Point(6, 6);
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.ReadOnly = true;
            this.dataGridView6.Size = new System.Drawing.Size(663, 155);
            this.dataGridView6.TabIndex = 10;
            // 
            // PAYMENT_Tab
            // 
            this.PAYMENT_Tab.Controls.Add(this.dataGridView7);
            this.PAYMENT_Tab.Controls.Add(this.dataGridView8);
            this.PAYMENT_Tab.Controls.Add(this.dataGridView9);
            this.PAYMENT_Tab.Location = new System.Drawing.Point(4, 29);
            this.PAYMENT_Tab.Name = "PAYMENT_Tab";
            this.PAYMENT_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.PAYMENT_Tab.Size = new System.Drawing.Size(675, 528);
            this.PAYMENT_Tab.TabIndex = 4;
            this.PAYMENT_Tab.Text = "PAYMENT";
            this.PAYMENT_Tab.UseVisualStyleBackColor = true;
            // 
            // dataGridView7
            // 
            this.dataGridView7.AllowUserToAddRows = false;
            this.dataGridView7.AllowUserToDeleteRows = false;
            this.dataGridView7.AllowUserToResizeColumns = false;
            this.dataGridView7.AllowUserToResizeRows = false;
            this.dataGridView7.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView7.Location = new System.Drawing.Point(6, 349);
            this.dataGridView7.Name = "dataGridView7";
            this.dataGridView7.ReadOnly = true;
            this.dataGridView7.Size = new System.Drawing.Size(663, 173);
            this.dataGridView7.TabIndex = 12;
            // 
            // dataGridView8
            // 
            this.dataGridView8.AllowUserToAddRows = false;
            this.dataGridView8.AllowUserToDeleteRows = false;
            this.dataGridView8.AllowUserToResizeColumns = false;
            this.dataGridView8.AllowUserToResizeRows = false;
            this.dataGridView8.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView8.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView8.Location = new System.Drawing.Point(6, 167);
            this.dataGridView8.Name = "dataGridView8";
            this.dataGridView8.ReadOnly = true;
            this.dataGridView8.Size = new System.Drawing.Size(663, 176);
            this.dataGridView8.TabIndex = 11;
            // 
            // dataGridView9
            // 
            this.dataGridView9.AllowUserToAddRows = false;
            this.dataGridView9.AllowUserToDeleteRows = false;
            this.dataGridView9.AllowUserToResizeColumns = false;
            this.dataGridView9.AllowUserToResizeRows = false;
            this.dataGridView9.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView9.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView9.Location = new System.Drawing.Point(6, 6);
            this.dataGridView9.Name = "dataGridView9";
            this.dataGridView9.ReadOnly = true;
            this.dataGridView9.Size = new System.Drawing.Size(663, 155);
            this.dataGridView9.TabIndex = 10;
            // 
            // TRANSFER_Tab
            // 
            this.TRANSFER_Tab.Controls.Add(this.dataGridView10);
            this.TRANSFER_Tab.Controls.Add(this.dataGridView11);
            this.TRANSFER_Tab.Controls.Add(this.dataGridView12);
            this.TRANSFER_Tab.Location = new System.Drawing.Point(4, 29);
            this.TRANSFER_Tab.Name = "TRANSFER_Tab";
            this.TRANSFER_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.TRANSFER_Tab.Size = new System.Drawing.Size(675, 528);
            this.TRANSFER_Tab.TabIndex = 5;
            this.TRANSFER_Tab.Text = "TRANSFER";
            this.TRANSFER_Tab.UseVisualStyleBackColor = true;
            // 
            // dataGridView10
            // 
            this.dataGridView10.AllowUserToAddRows = false;
            this.dataGridView10.AllowUserToDeleteRows = false;
            this.dataGridView10.AllowUserToResizeColumns = false;
            this.dataGridView10.AllowUserToResizeRows = false;
            this.dataGridView10.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView10.Location = new System.Drawing.Point(6, 349);
            this.dataGridView10.Name = "dataGridView10";
            this.dataGridView10.ReadOnly = true;
            this.dataGridView10.Size = new System.Drawing.Size(663, 173);
            this.dataGridView10.TabIndex = 12;
            // 
            // dataGridView11
            // 
            this.dataGridView11.AllowUserToAddRows = false;
            this.dataGridView11.AllowUserToDeleteRows = false;
            this.dataGridView11.AllowUserToResizeColumns = false;
            this.dataGridView11.AllowUserToResizeRows = false;
            this.dataGridView11.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView11.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView11.Location = new System.Drawing.Point(6, 167);
            this.dataGridView11.Name = "dataGridView11";
            this.dataGridView11.ReadOnly = true;
            this.dataGridView11.Size = new System.Drawing.Size(663, 176);
            this.dataGridView11.TabIndex = 11;
            // 
            // dataGridView12
            // 
            this.dataGridView12.AllowUserToAddRows = false;
            this.dataGridView12.AllowUserToDeleteRows = false;
            this.dataGridView12.AllowUserToResizeColumns = false;
            this.dataGridView12.AllowUserToResizeRows = false;
            this.dataGridView12.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView12.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView12.Location = new System.Drawing.Point(6, 6);
            this.dataGridView12.Name = "dataGridView12";
            this.dataGridView12.ReadOnly = true;
            this.dataGridView12.Size = new System.Drawing.Size(663, 155);
            this.dataGridView12.TabIndex = 10;
            // 
            // REMOVEDUPES_tab
            // 
            this.REMOVEDUPES_tab.Controls.Add(this.dataGridView15);
            this.REMOVEDUPES_tab.Controls.Add(this.upIncrementalID_but);
            this.REMOVEDUPES_tab.Controls.Add(this.dataGridView14);
            this.REMOVEDUPES_tab.Controls.Add(this.dataGridView13);
            this.REMOVEDUPES_tab.Controls.Add(this.runSelectQueries);
            this.REMOVEDUPES_tab.Controls.Add(this.label2);
            this.REMOVEDUPES_tab.Controls.Add(this.rd_PostingID);
            this.REMOVEDUPES_tab.Location = new System.Drawing.Point(4, 29);
            this.REMOVEDUPES_tab.Name = "REMOVEDUPES_tab";
            this.REMOVEDUPES_tab.Padding = new System.Windows.Forms.Padding(3);
            this.REMOVEDUPES_tab.Size = new System.Drawing.Size(675, 528);
            this.REMOVEDUPES_tab.TabIndex = 6;
            this.REMOVEDUPES_tab.Text = "Remove Duplicates";
            this.REMOVEDUPES_tab.UseVisualStyleBackColor = true;
            // 
            // upIncrementalID_but
            // 
            this.upIncrementalID_but.Location = new System.Drawing.Point(6, 397);
            this.upIncrementalID_but.Name = "upIncrementalID_but";
            this.upIncrementalID_but.Size = new System.Drawing.Size(172, 31);
            this.upIncrementalID_but.TabIndex = 13;
            this.upIncrementalID_but.Text = "Update Incremental ID";
            this.upIncrementalID_but.UseVisualStyleBackColor = true;
            this.upIncrementalID_but.Click += new System.EventHandler(this.upIncrementalID_but_Click);
            // 
            // dataGridView14
            // 
            this.dataGridView14.AllowUserToAddRows = false;
            this.dataGridView14.AllowUserToDeleteRows = false;
            this.dataGridView14.AllowUserToResizeColumns = false;
            this.dataGridView14.AllowUserToResizeRows = false;
            this.dataGridView14.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView14.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView14.Location = new System.Drawing.Point(6, 236);
            this.dataGridView14.Name = "dataGridView14";
            this.dataGridView14.ReadOnly = true;
            this.dataGridView14.Size = new System.Drawing.Size(663, 155);
            this.dataGridView14.TabIndex = 12;
            // 
            // dataGridView13
            // 
            this.dataGridView13.AllowUserToAddRows = false;
            this.dataGridView13.AllowUserToDeleteRows = false;
            this.dataGridView13.AllowUserToResizeColumns = false;
            this.dataGridView13.AllowUserToResizeRows = false;
            this.dataGridView13.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView13.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView13.Location = new System.Drawing.Point(6, 75);
            this.dataGridView13.Name = "dataGridView13";
            this.dataGridView13.ReadOnly = true;
            this.dataGridView13.Size = new System.Drawing.Size(663, 155);
            this.dataGridView13.TabIndex = 11;
            // 
            // runSelectQueries
            // 
            this.runSelectQueries.Location = new System.Drawing.Point(380, 39);
            this.runSelectQueries.Name = "runSelectQueries";
            this.runSelectQueries.Size = new System.Drawing.Size(170, 30);
            this.runSelectQueries.TabIndex = 2;
            this.runSelectQueries.Text = "Run Select Statements";
            this.runSelectQueries.UseVisualStyleBackColor = true;
            this.runSelectQueries.Click += new System.EventHandler(this.runSelectQueries_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter the Posting ID to look at";
            // 
            // rd_PostingID
            // 
            this.rd_PostingID.Location = new System.Drawing.Point(207, 6);
            this.rd_PostingID.Name = "rd_PostingID";
            this.rd_PostingID.Size = new System.Drawing.Size(175, 26);
            this.rd_PostingID.TabIndex = 0;
            // 
            // Done_Tab
            // 
            this.Done_Tab.Location = new System.Drawing.Point(4, 29);
            this.Done_Tab.Name = "Done_Tab";
            this.Done_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Done_Tab.Size = new System.Drawing.Size(675, 528);
            this.Done_Tab.TabIndex = 7;
            this.Done_Tab.Text = "Done";
            this.Done_Tab.UseVisualStyleBackColor = true;
            // 
            // BK_Selection_CHBOX
            // 
            this.BK_Selection_CHBOX.HeaderText = "Select Process";
            this.BK_Selection_CHBOX.Name = "BK_Selection_CHBOX";
            // 
            // Process_ID
            // 
            this.Process_ID.HeaderText = "Process ID";
            this.Process_ID.Name = "Process_ID";
            this.Process_ID.ReadOnly = true;
            // 
            // Process_Description
            // 
            this.Process_Description.HeaderText = "Process Description";
            this.Process_Description.Name = "Process_Description";
            this.Process_Description.ReadOnly = true;
            // 
            // dataGridView15
            // 
            this.dataGridView15.AllowUserToAddRows = false;
            this.dataGridView15.AllowUserToDeleteRows = false;
            this.dataGridView15.AllowUserToResizeColumns = false;
            this.dataGridView15.AllowUserToResizeRows = false;
            this.dataGridView15.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView15.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView15.Location = new System.Drawing.Point(184, 397);
            this.dataGridView15.Name = "dataGridView15";
            this.dataGridView15.ReadOnly = true;
            this.dataGridView15.Size = new System.Drawing.Size(485, 49);
            this.dataGridView15.TabIndex = 14;
            // 
            // RemoveDuplicatePostingIDs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 576);
            this.Controls.Add(this.TabControl1);
            this.Name = "RemoveDuplicatePostingIDs";
            this.Text = "Remove Duplicate Posting IDs";
            this.TabControl1.ResumeLayout(false);
            this.Connection_Tab.ResumeLayout(false);
            this.Connection_Tab.PerformLayout();
            this.INVOICE_Tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.CREDITINVOICE_Tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            this.PAYMENT_Tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView9)).EndInit();
            this.TRANSFER_Tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView12)).EndInit();
            this.REMOVEDUPES_tab.ResumeLayout(false);
            this.REMOVEDUPES_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intrtProcessesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView15)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl TabControl1;
        public System.Windows.Forms.TabPage Connection_Tab;
        public System.Windows.Forms.TabPage INVOICE_Tab;
        public System.Windows.Forms.TabPage CREDITINVOICE_Tab;
        public System.Windows.Forms.TabPage PAYMENT_Tab;
        public System.Windows.Forms.ComboBox DB_TYPE_COMBO;
        public System.Windows.Forms.Label DB_TYPE_LABEL;
        public System.Windows.Forms.TextBox CON_INSTRUCTIONS_TEXT;
        public System.Windows.Forms.TextBox PASSWORD_TEXT;
        public System.Windows.Forms.Label PASSWORD_LABEL;
        public System.Windows.Forms.TextBox USERNAME_TEXT;
        public System.Windows.Forms.Label USERNAME_LABEL;
        public System.Windows.Forms.TextBox SERVER_CONNECTION_TEXT;
        public System.Windows.Forms.Label SERVER_CONNECTION_LABEL;
        public System.Windows.Forms.DataGridViewCheckBoxColumn BK_Selection_CHBOX;
        public System.Windows.Forms.DataGridViewTextBoxColumn Process_ID;
        public System.Windows.Forms.DataGridViewTextBoxColumn Process_Description;
        public System.Windows.Forms.TextBox DB_PORT_TEXT;
        public System.Windows.Forms.Label DB_PORT_LABEL;
        public System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        public System.Windows.Forms.Button CONNECTION_BUTTON;
        public System.Windows.Forms.TextBox ORA_HOST_TEXT;
        public System.Windows.Forms.Label ORA_HOST_LABEL;
        public System.Windows.Forms.BindingSource intrtProcessesBindingSource;
        public System.Windows.Forms.TextBox CONNECTION_STRING_TEXT_BOX;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage TRANSFER_Tab;
        private System.Windows.Forms.TabPage REMOVEDUPES_tab;
        private System.Windows.Forms.TabPage Done_Tab;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.DataGridView dataGridView6;
        private System.Windows.Forms.DataGridView dataGridView7;
        private System.Windows.Forms.DataGridView dataGridView8;
        private System.Windows.Forms.DataGridView dataGridView9;
        private System.Windows.Forms.DataGridView dataGridView10;
        private System.Windows.Forms.DataGridView dataGridView11;
        private System.Windows.Forms.DataGridView dataGridView12;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox DB_Name_Text;
        private System.Windows.Forms.DataGridView dataGridView14;
        private System.Windows.Forms.DataGridView dataGridView13;
        private System.Windows.Forms.Button runSelectQueries;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rd_PostingID;
        private System.Windows.Forms.Button upIncrementalID_but;
        private System.Windows.Forms.DataGridView dataGridView15;
    }
}

