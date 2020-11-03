namespace ICBRU
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.XML_Tab = new System.Windows.Forms.TabPage();
            this.XML_INSTRUCTIONS_TEXT = new System.Windows.Forms.TextBox();
            this.BK_XML_LOC_TEXT = new System.Windows.Forms.TextBox();
            this.BK_XML_LOC_BUT = new System.Windows.Forms.Button();
            this.Connection_Tab = new System.Windows.Forms.TabPage();
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
            this.Backup_Tab = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pkprocessIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Process_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intrtProcessesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iNTRCONFIGDataSet = new ICBRU.INTRCONFIGDataSet();
            this.BK_INSTRUCTIONS_TEXT = new System.Windows.Forms.TextBox();
            this.BK_CONTINUE_BUTTON = new System.Windows.Forms.Button();
            this.Restore_Tab = new System.Windows.Forms.TabPage();
            this.RESTORE_STATUS_LABEL = new System.Windows.Forms.Label();
            this.RESTORE_STATUS = new System.Windows.Forms.CheckBox();
            this.CHECK_4_CONFLICT_IDs_BUT = new System.Windows.Forms.Button();
            this.RESTORE_ITEMS_COMPLETED_TXTBOX = new System.Windows.Forms.TextBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.CONFLICTING_PROCESSES_LABEL = new System.Windows.Forms.Label();
            this.XML_PROCESSES_LABEL = new System.Windows.Forms.Label();
            this.RESTORE_BUTTON = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Done_Tab = new System.Windows.Forms.TabPage();
            this.BK_Selection_CHBOX = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Process_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Process_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.intr_t_ProcessesTableAdapter = new ICBRU.INTRCONFIGDataSetTableAdapters.intr_t_ProcessesTableAdapter();
            this.tabControl1.SuspendLayout();
            this.XML_Tab.SuspendLayout();
            this.Connection_Tab.SuspendLayout();
            this.Backup_Tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intrtProcessesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNTRCONFIGDataSet)).BeginInit();
            this.Restore_Tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.XML_Tab);
            this.tabControl1.Controls.Add(this.Connection_Tab);
            this.tabControl1.Controls.Add(this.Backup_Tab);
            this.tabControl1.Controls.Add(this.Restore_Tab);
            this.tabControl1.Controls.Add(this.Done_Tab);
            this.tabControl1.Font = new System.Drawing.Font("Arial Narrow", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(676, 555);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // XML_Tab
            // 
            this.XML_Tab.Controls.Add(this.XML_INSTRUCTIONS_TEXT);
            this.XML_Tab.Controls.Add(this.BK_XML_LOC_TEXT);
            this.XML_Tab.Controls.Add(this.BK_XML_LOC_BUT);
            this.XML_Tab.Location = new System.Drawing.Point(4, 29);
            this.XML_Tab.Name = "XML_Tab";
            this.XML_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.XML_Tab.Size = new System.Drawing.Size(668, 522);
            this.XML_Tab.TabIndex = 0;
            this.XML_Tab.Text = "XML";
            this.XML_Tab.UseVisualStyleBackColor = true;
            // 
            // XML_INSTRUCTIONS_TEXT
            // 
            this.XML_INSTRUCTIONS_TEXT.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold);
            this.XML_INSTRUCTIONS_TEXT.Location = new System.Drawing.Point(6, 84);
            this.XML_INSTRUCTIONS_TEXT.Multiline = true;
            this.XML_INSTRUCTIONS_TEXT.Name = "XML_INSTRUCTIONS_TEXT";
            this.XML_INSTRUCTIONS_TEXT.Size = new System.Drawing.Size(609, 350);
            this.XML_INSTRUCTIONS_TEXT.TabIndex = 2;
            this.XML_INSTRUCTIONS_TEXT.Text = resources.GetString("XML_INSTRUCTIONS_TEXT.Text");
            // 
            // BK_XML_LOC_TEXT
            // 
            this.BK_XML_LOC_TEXT.AcceptsReturn = true;
            this.BK_XML_LOC_TEXT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BK_XML_LOC_TEXT.Location = new System.Drawing.Point(188, 24);
            this.BK_XML_LOC_TEXT.Name = "BK_XML_LOC_TEXT";
            this.BK_XML_LOC_TEXT.Size = new System.Drawing.Size(427, 26);
            this.BK_XML_LOC_TEXT.TabIndex = 1;
            // 
            // BK_XML_LOC_BUT
            // 
            this.BK_XML_LOC_BUT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BK_XML_LOC_BUT.Location = new System.Drawing.Point(6, 18);
            this.BK_XML_LOC_BUT.Name = "BK_XML_LOC_BUT";
            this.BK_XML_LOC_BUT.Size = new System.Drawing.Size(176, 37);
            this.BK_XML_LOC_BUT.TabIndex = 0;
            this.BK_XML_LOC_BUT.Text = "Backup XML Location";
            this.BK_XML_LOC_BUT.UseVisualStyleBackColor = true;
            this.BK_XML_LOC_BUT.Click += new System.EventHandler(this.BK_XML_LOC_BUT_Click);
            // 
            // Connection_Tab
            // 
            this.Connection_Tab.AutoScroll = true;
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
            this.Connection_Tab.Size = new System.Drawing.Size(668, 522);
            this.Connection_Tab.TabIndex = 1;
            this.Connection_Tab.Text = "Connection";
            this.Connection_Tab.UseVisualStyleBackColor = true;
            // 
            // CONNECTION_STRING_TEXT_BOX
            // 
            this.CONNECTION_STRING_TEXT_BOX.Enabled = false;
            this.CONNECTION_STRING_TEXT_BOX.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CONNECTION_STRING_TEXT_BOX.Location = new System.Drawing.Point(11, 213);
            this.CONNECTION_STRING_TEXT_BOX.Multiline = true;
            this.CONNECTION_STRING_TEXT_BOX.Name = "CONNECTION_STRING_TEXT_BOX";
            this.CONNECTION_STRING_TEXT_BOX.Size = new System.Drawing.Size(611, 60);
            this.CONNECTION_STRING_TEXT_BOX.TabIndex = 7;
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
            this.CONNECTION_BUTTON.Location = new System.Drawing.Point(590, 488);
            this.CONNECTION_BUTTON.Name = "CONNECTION_BUTTON";
            this.CONNECTION_BUTTON.Size = new System.Drawing.Size(75, 31);
            this.CONNECTION_BUTTON.TabIndex = 7;
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
            this.DB_PORT_TEXT.Location = new System.Drawing.Point(205, 181);
            this.DB_PORT_TEXT.Name = "DB_PORT_TEXT";
            this.DB_PORT_TEXT.Size = new System.Drawing.Size(417, 26);
            this.DB_PORT_TEXT.TabIndex = 6;
            this.DB_PORT_TEXT.Text = "1521";
            // 
            // DB_PORT_LABEL
            // 
            this.DB_PORT_LABEL.AutoSize = true;
            this.DB_PORT_LABEL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DB_PORT_LABEL.Location = new System.Drawing.Point(7, 184);
            this.DB_PORT_LABEL.Name = "DB_PORT_LABEL";
            this.DB_PORT_LABEL.Size = new System.Drawing.Size(117, 19);
            this.DB_PORT_LABEL.TabIndex = 0;
            this.DB_PORT_LABEL.Text = "Database Port";
            // 
            // CON_INSTRUCTIONS_TEXT
            // 
            this.CON_INSTRUCTIONS_TEXT.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold);
            this.CON_INSTRUCTIONS_TEXT.Location = new System.Drawing.Point(10, 280);
            this.CON_INSTRUCTIONS_TEXT.Multiline = true;
            this.CON_INSTRUCTIONS_TEXT.Name = "CON_INSTRUCTIONS_TEXT";
            this.CON_INSTRUCTIONS_TEXT.ReadOnly = true;
            this.CON_INSTRUCTIONS_TEXT.Size = new System.Drawing.Size(650, 210);
            this.CON_INSTRUCTIONS_TEXT.TabIndex = 0;
            this.CON_INSTRUCTIONS_TEXT.Text = resources.GetString("CON_INSTRUCTIONS_TEXT.Text");
            // 
            // PASSWORD_TEXT
            // 
            this.PASSWORD_TEXT.Location = new System.Drawing.Point(204, 145);
            this.PASSWORD_TEXT.Name = "PASSWORD_TEXT";
            this.PASSWORD_TEXT.Size = new System.Drawing.Size(417, 26);
            this.PASSWORD_TEXT.TabIndex = 5;
            this.PASSWORD_TEXT.UseSystemPasswordChar = true;
            // 
            // PASSWORD_LABEL
            // 
            this.PASSWORD_LABEL.AutoSize = true;
            this.PASSWORD_LABEL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PASSWORD_LABEL.Location = new System.Drawing.Point(6, 148);
            this.PASSWORD_LABEL.Name = "PASSWORD_LABEL";
            this.PASSWORD_LABEL.Size = new System.Drawing.Size(86, 19);
            this.PASSWORD_LABEL.TabIndex = 0;
            this.PASSWORD_LABEL.Text = "Password";
            // 
            // USERNAME_TEXT
            // 
            this.USERNAME_TEXT.Location = new System.Drawing.Point(204, 113);
            this.USERNAME_TEXT.Name = "USERNAME_TEXT";
            this.USERNAME_TEXT.Size = new System.Drawing.Size(417, 26);
            this.USERNAME_TEXT.TabIndex = 4;
            // 
            // USERNAME_LABEL
            // 
            this.USERNAME_LABEL.AutoSize = true;
            this.USERNAME_LABEL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.USERNAME_LABEL.Location = new System.Drawing.Point(6, 116);
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
            // Backup_Tab
            // 
            this.Backup_Tab.Controls.Add(this.dataGridView1);
            this.Backup_Tab.Controls.Add(this.BK_INSTRUCTIONS_TEXT);
            this.Backup_Tab.Controls.Add(this.BK_CONTINUE_BUTTON);
            this.Backup_Tab.Location = new System.Drawing.Point(4, 29);
            this.Backup_Tab.Name = "Backup_Tab";
            this.Backup_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Backup_Tab.Size = new System.Drawing.Size(668, 522);
            this.Backup_Tab.TabIndex = 2;
            this.Backup_Tab.Text = "Backup";
            this.Backup_Tab.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkprocessIDDataGridViewTextBoxColumn,
            this.Process_Name});
            this.dataGridView1.DataSource = this.intrtProcessesBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(7, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(655, 369);
            this.dataGridView1.TabIndex = 3;
            // 
            // pkprocessIDDataGridViewTextBoxColumn
            // 
            this.pkprocessIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pkprocessIDDataGridViewTextBoxColumn.DataPropertyName = "pk_process_ID";
            this.pkprocessIDDataGridViewTextBoxColumn.HeaderText = "pk_process_ID";
            this.pkprocessIDDataGridViewTextBoxColumn.Name = "pkprocessIDDataGridViewTextBoxColumn";
            this.pkprocessIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.pkprocessIDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.pkprocessIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pkprocessIDDataGridViewTextBoxColumn.Width = 105;
            // 
            // Process_Name
            // 
            this.Process_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Process_Name.DataPropertyName = "Process_Name";
            this.Process_Name.HeaderText = "Process_Name";
            this.Process_Name.Name = "Process_Name";
            this.Process_Name.ReadOnly = true;
            this.Process_Name.Width = 126;
            // 
            // intrtProcessesBindingSource
            // 
            this.intrtProcessesBindingSource.DataMember = "intr_t_Processes";
            this.intrtProcessesBindingSource.DataSource = this.iNTRCONFIGDataSet;
            // 
            // iNTRCONFIGDataSet
            // 
            this.iNTRCONFIGDataSet.DataSetName = "INTRCONFIGDataSet";
            this.iNTRCONFIGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BK_INSTRUCTIONS_TEXT
            // 
            this.BK_INSTRUCTIONS_TEXT.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold);
            this.BK_INSTRUCTIONS_TEXT.Location = new System.Drawing.Point(7, 381);
            this.BK_INSTRUCTIONS_TEXT.Multiline = true;
            this.BK_INSTRUCTIONS_TEXT.Name = "BK_INSTRUCTIONS_TEXT";
            this.BK_INSTRUCTIONS_TEXT.ReadOnly = true;
            this.BK_INSTRUCTIONS_TEXT.Size = new System.Drawing.Size(562, 132);
            this.BK_INSTRUCTIONS_TEXT.TabIndex = 2;
            this.BK_INSTRUCTIONS_TEXT.Text = resources.GetString("BK_INSTRUCTIONS_TEXT.Text");
            // 
            // BK_CONTINUE_BUTTON
            // 
            this.BK_CONTINUE_BUTTON.Location = new System.Drawing.Point(575, 452);
            this.BK_CONTINUE_BUTTON.Name = "BK_CONTINUE_BUTTON";
            this.BK_CONTINUE_BUTTON.Size = new System.Drawing.Size(87, 43);
            this.BK_CONTINUE_BUTTON.TabIndex = 1;
            this.BK_CONTINUE_BUTTON.Text = "Backup";
            this.BK_CONTINUE_BUTTON.UseVisualStyleBackColor = true;
            this.BK_CONTINUE_BUTTON.Click += new System.EventHandler(this.BK_CONTINUE_BUTTON_Click);
            // 
            // Restore_Tab
            // 
            this.Restore_Tab.Controls.Add(this.RESTORE_STATUS_LABEL);
            this.Restore_Tab.Controls.Add(this.RESTORE_STATUS);
            this.Restore_Tab.Controls.Add(this.CHECK_4_CONFLICT_IDs_BUT);
            this.Restore_Tab.Controls.Add(this.RESTORE_ITEMS_COMPLETED_TXTBOX);
            this.Restore_Tab.Controls.Add(this.dataGridView3);
            this.Restore_Tab.Controls.Add(this.CONFLICTING_PROCESSES_LABEL);
            this.Restore_Tab.Controls.Add(this.XML_PROCESSES_LABEL);
            this.Restore_Tab.Controls.Add(this.RESTORE_BUTTON);
            this.Restore_Tab.Controls.Add(this.dataGridView2);
            this.Restore_Tab.Location = new System.Drawing.Point(4, 29);
            this.Restore_Tab.Name = "Restore_Tab";
            this.Restore_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Restore_Tab.Size = new System.Drawing.Size(668, 522);
            this.Restore_Tab.TabIndex = 3;
            this.Restore_Tab.Text = "Restore";
            this.Restore_Tab.UseVisualStyleBackColor = true;
            // 
            // RESTORE_STATUS_LABEL
            // 
            this.RESTORE_STATUS_LABEL.AutoSize = true;
            this.RESTORE_STATUS_LABEL.Location = new System.Drawing.Point(561, 429);
            this.RESTORE_STATUS_LABEL.Name = "RESTORE_STATUS_LABEL";
            this.RESTORE_STATUS_LABEL.Size = new System.Drawing.Size(107, 20);
            this.RESTORE_STATUS_LABEL.TabIndex = 8;
            this.RESTORE_STATUS_LABEL.Text = "Restore Status?";
            // 
            // RESTORE_STATUS
            // 
            this.RESTORE_STATUS.AutoSize = true;
            this.RESTORE_STATUS.Location = new System.Drawing.Point(602, 452);
            this.RESTORE_STATUS.Name = "RESTORE_STATUS";
            this.RESTORE_STATUS.Size = new System.Drawing.Size(15, 14);
            this.RESTORE_STATUS.TabIndex = 7;
            this.RESTORE_STATUS.UseVisualStyleBackColor = true;
            // 
            // CHECK_4_CONFLICT_IDs_BUT
            // 
            this.CHECK_4_CONFLICT_IDs_BUT.Location = new System.Drawing.Point(324, 386);
            this.CHECK_4_CONFLICT_IDs_BUT.Name = "CHECK_4_CONFLICT_IDs_BUT";
            this.CHECK_4_CONFLICT_IDs_BUT.Size = new System.Drawing.Size(336, 37);
            this.CHECK_4_CONFLICT_IDs_BUT.TabIndex = 6;
            this.CHECK_4_CONFLICT_IDs_BUT.Text = "Check for conflicting Process IDs";
            this.CHECK_4_CONFLICT_IDs_BUT.UseVisualStyleBackColor = true;
            this.CHECK_4_CONFLICT_IDs_BUT.Click += new System.EventHandler(this.CHECK_4_CONFLICT_IDs_BUT_Click);
            // 
            // RESTORE_ITEMS_COMPLETED_TXTBOX
            // 
            this.RESTORE_ITEMS_COMPLETED_TXTBOX.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold);
            this.RESTORE_ITEMS_COMPLETED_TXTBOX.Location = new System.Drawing.Point(7, 429);
            this.RESTORE_ITEMS_COMPLETED_TXTBOX.Multiline = true;
            this.RESTORE_ITEMS_COMPLETED_TXTBOX.Name = "RESTORE_ITEMS_COMPLETED_TXTBOX";
            this.RESTORE_ITEMS_COMPLETED_TXTBOX.ReadOnly = true;
            this.RESTORE_ITEMS_COMPLETED_TXTBOX.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RESTORE_ITEMS_COMPLETED_TXTBOX.Size = new System.Drawing.Size(552, 87);
            this.RESTORE_ITEMS_COMPLETED_TXTBOX.TabIndex = 5;
            this.RESTORE_ITEMS_COMPLETED_TXTBOX.TabStop = false;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToResizeColumns = false;
            this.dataGridView3.AllowUserToResizeRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(324, 26);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(336, 353);
            this.dataGridView3.TabIndex = 4;
            // 
            // CONFLICTING_PROCESSES_LABEL
            // 
            this.CONFLICTING_PROCESSES_LABEL.AutoSize = true;
            this.CONFLICTING_PROCESSES_LABEL.Location = new System.Drawing.Point(326, 3);
            this.CONFLICTING_PROCESSES_LABEL.Name = "CONFLICTING_PROCESSES_LABEL";
            this.CONFLICTING_PROCESSES_LABEL.Size = new System.Drawing.Size(311, 20);
            this.CONFLICTING_PROCESSES_LABEL.TabIndex = 3;
            this.CONFLICTING_PROCESSES_LABEL.Text = "Processes in Database that could be overwritten.";
            // 
            // XML_PROCESSES_LABEL
            // 
            this.XML_PROCESSES_LABEL.AutoSize = true;
            this.XML_PROCESSES_LABEL.Location = new System.Drawing.Point(6, 3);
            this.XML_PROCESSES_LABEL.Name = "XML_PROCESSES_LABEL";
            this.XML_PROCESSES_LABEL.Size = new System.Drawing.Size(165, 20);
            this.XML_PROCESSES_LABEL.TabIndex = 2;
            this.XML_PROCESSES_LABEL.Text = "Process included in XML";
            // 
            // RESTORE_BUTTON
            // 
            this.RESTORE_BUTTON.Location = new System.Drawing.Point(576, 483);
            this.RESTORE_BUTTON.Name = "RESTORE_BUTTON";
            this.RESTORE_BUTTON.Size = new System.Drawing.Size(84, 33);
            this.RESTORE_BUTTON.TabIndex = 1;
            this.RESTORE_BUTTON.Text = "Restore";
            this.RESTORE_BUTTON.UseVisualStyleBackColor = true;
            this.RESTORE_BUTTON.Click += new System.EventHandler(this.RESTORE_BUTTON_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 25);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(306, 398);
            this.dataGridView2.TabIndex = 0;
            // 
            // Done_Tab
            // 
            this.Done_Tab.Location = new System.Drawing.Point(4, 29);
            this.Done_Tab.Name = "Done_Tab";
            this.Done_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Done_Tab.Size = new System.Drawing.Size(668, 522);
            this.Done_Tab.TabIndex = 4;
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
            // intr_t_ProcessesTableAdapter
            // 
            this.intr_t_ProcessesTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 579);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "ICBRU";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.XML_Tab.ResumeLayout(false);
            this.XML_Tab.PerformLayout();
            this.Connection_Tab.ResumeLayout(false);
            this.Connection_Tab.PerformLayout();
            this.Backup_Tab.ResumeLayout(false);
            this.Backup_Tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intrtProcessesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNTRCONFIGDataSet)).EndInit();
            this.Restore_Tab.ResumeLayout(false);
            this.Restore_Tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage XML_Tab;
        public System.Windows.Forms.TabPage Connection_Tab;
        public System.Windows.Forms.TabPage Backup_Tab;
        public System.Windows.Forms.TabPage Restore_Tab;
        public System.Windows.Forms.TabPage Done_Tab;
        public System.Windows.Forms.Button BK_XML_LOC_BUT;
        public System.Windows.Forms.TextBox BK_XML_LOC_TEXT;
        public System.Windows.Forms.TextBox XML_INSTRUCTIONS_TEXT;
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
        public System.Windows.Forms.TextBox BK_INSTRUCTIONS_TEXT;
        public System.Windows.Forms.Button BK_CONTINUE_BUTTON;
        public System.Windows.Forms.TextBox DB_PORT_TEXT;
        public System.Windows.Forms.Label DB_PORT_LABEL;
        public System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        public System.Windows.Forms.Button CONNECTION_BUTTON;
        public System.Windows.Forms.TextBox ORA_HOST_TEXT;
        public System.Windows.Forms.Label ORA_HOST_LABEL;
        public INTRCONFIGDataSet iNTRCONFIGDataSet;
        public System.Windows.Forms.BindingSource intrtProcessesBindingSource;
        public INTRCONFIGDataSetTableAdapters.intr_t_ProcessesTableAdapter intr_t_ProcessesTableAdapter;
        public System.Windows.Forms.TextBox CONNECTION_STRING_TEXT_BOX;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkprocessIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Process_Name;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Button RESTORE_BUTTON;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label CONFLICTING_PROCESSES_LABEL;
        private System.Windows.Forms.Label XML_PROCESSES_LABEL;
        private System.Windows.Forms.TextBox RESTORE_ITEMS_COMPLETED_TXTBOX;
        private System.Windows.Forms.Button CHECK_4_CONFLICT_IDs_BUT;
        private System.Windows.Forms.Label RESTORE_STATUS_LABEL;
        private System.Windows.Forms.CheckBox RESTORE_STATUS;
    }
}

