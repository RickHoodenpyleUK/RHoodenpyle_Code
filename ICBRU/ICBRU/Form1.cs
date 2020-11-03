using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.SqlClient;
using ADODB;
using System.Xml;
using System.Xml.Serialization;
using System.Configuration;
using System.Collections;
using System.Web;
using System.IO;
using System.Data.OleDb;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace ICBRU
{

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            this.Connection_Tab.Enabled = true;
            this.Backup_Tab.Enabled = false;
            this.Restore_Tab.Enabled = false;
            this.ORA_HOST_TEXT.Enabled = false;
            this.DB_PORT_TEXT.Enabled = false;


        }

        public void BK_XML_LOC_BUT_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BK_XML_LOC_TEXT.Text = folderBrowserDialog1.SelectedPath;

            }
        }


        public void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (BK_XML_LOC_TEXT.Text != "")
            {
                this.Connection_Tab.Enabled = true;
            }
            if ((DB_TYPE_COMBO.Text.Equals("Select Database Type")) || (SERVER_CONNECTION_TEXT.Text.Equals("")) || (USERNAME_TEXT.Text.Equals("")) || (PASSWORD_TEXT.Text.Equals("")))
            {
                this.Backup_Tab.Enabled = false;
                this.Restore_Tab.Enabled = false;
            }
            else
            {
                this.Backup_Tab.Enabled = true;
                this.Restore_Tab.Enabled = true;
            }
            if (tabControl1.SelectedTab == Done_Tab)
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to Exit ICBRU?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Application.Exit();
                }
                else
                {
                    tabControl1.SelectedIndex = 0;
                }

            }
            if (tabControl1.SelectedTab == Backup_Tab)
            {
                if (DB_TYPE_COMBO.Text.Equals("Select Database Type"))
                {
                    MessageBox.Show("Please complete connections on the connections tab.");
                    tabControl1.SelectedIndex = 1;
                }
                else if (DB_TYPE_COMBO.Text.Equals("SQL"))
                {
                    String CONNECTION_STRING =
                                  "Server=" + SERVER_CONNECTION_TEXT.Text + ";" +
                                  "DataBase=INTRCONFIG;" +
                                  "Uid=" + USERNAME_TEXT.Text + ";" +
                                  "Pwd=" + PASSWORD_TEXT.Text + ";";
                    try
                    {
                        SqlConnection conn = new SqlConnection(CONNECTION_STRING);
                        SqlDataAdapter da;
                        DataSet ds = new DataSet();

                        conn = new SqlConnection(CONNECTION_STRING);
                        conn.Open();
                        da = new SqlDataAdapter("Select PK_PROCESS_ID,Process_Name from INTR_T_PROCESSES ORDER BY PK_PROCESS_ID", conn);
                        da.Fill(ds, "INTR_T_PROCESSES");
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "INTR_T_PROCESSES";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Not Connected - " + ex.Message);

                    }
                }
                else if (DB_TYPE_COMBO.Text.Equals("Oracle"))
                {
                    string CONNECTION_STRING = "User Id=" + USERNAME_TEXT.Text + ";Password=" + PASSWORD_TEXT.Text + ";Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + ORA_HOST_TEXT.Text + ")(PORT=" + DB_PORT_TEXT.Text + "))" + "(CONNECT_DATA=(SID=" + SERVER_CONNECTION_TEXT.Text + ")));";
                    OracleConnection conn = new OracleConnection(CONNECTION_STRING);

                    try
                    {
                        conn.Open();
                        OracleCommand cmd = new OracleCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT PK_PROCESS_ID,Process_Name from INTRCONFIG.INTR_T_PROCESSES ORDER BY PK_PROCESS_ID";
                        cmd.CommandType = CommandType.Text;
                        dataGridView1.AutoGenerateColumns = true;
                        DataSet ds = new DataSet();
                        OracleDataAdapter adapter = new OracleDataAdapter();
                        adapter.SelectCommand = cmd;
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        conn.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Not Connected - " + ex.Message);

                    }
                }
            }
            if (tabControl1.SelectedTab == Restore_Tab)
            {
                //Need to put in the dataGridView2 from the intr_t_processes.xml
                string BK_XML_LOC_TEXT2 = BK_XML_LOC_TEXT.Text.Replace("\\", "\\\\");
                System.Xml.XmlDataDocument xmlDoc = new System.Xml.XmlDataDocument();
                string intr_t_processes_XML_Path = BK_XML_LOC_TEXT2 + "\\intr_t_processes.xml";

                if (File.Exists(intr_t_processes_XML_Path))
                    try
                    {
                        xmlDoc.DataSet.ReadXml(intr_t_processes_XML_Path);
                        dataGridView2.DataSource = xmlDoc.DataSet;
                        dataGridView2.DataMember = "intr_t_Processes";
                        dataGridView2.Columns["PK_Process_ID"].Visible = true;
                        dataGridView2.Columns["Process_Name"].Visible = true;
                        dataGridView2.Columns["Status"].Visible = false;
                        dataGridView2.Columns["Next_Execution_Step"].Visible = false;
                        dataGridView2.Columns["Data_Set"].Visible = false;
                        dataGridView2.Columns["fk_Process_Type_ID"].Visible = false;
                        dataGridView2.Columns["Active"].Visible = false;
                        DataGridViewColumn Process_Name_Column = dataGridView2.Columns[1];
                        Process_Name_Column.Width = 250;
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            }
        }
        public void DB_TYPE_COMBO_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if ((DB_TYPE_COMBO.Text.Equals("SQL")) || (DB_TYPE_COMBO.Text.Equals("Select Database Type")))
            {
                this.ORA_HOST_TEXT.Enabled = false;
                this.DB_PORT_TEXT.Enabled = false;
            }
            else if (DB_TYPE_COMBO.Text.Equals("Oracle"))
            {
                this.ORA_HOST_TEXT.Enabled = true;
                this.DB_PORT_TEXT.Enabled = true;
            }
        }

        public void CONNECTION_BUTTON_Click(object sender, EventArgs e)
        {
            if (DB_TYPE_COMBO.Text.Equals("Select Database Type"))
            {
                MessageBox.Show("Please Select a Database Type.");
            }
            else if (SERVER_CONNECTION_TEXT.Text.Equals(""))
            {
                MessageBox.Show("Please Enter the Database Server Connection.");
            }
            else if (USERNAME_TEXT.Text.Equals(""))
            {
                MessageBox.Show("Please Enter a User Name.");
            }
            else if (PASSWORD_TEXT.Text.Equals(""))
            {
                MessageBox.Show("Please Enter a Password.");
            }
            else
            {
                if (DB_TYPE_COMBO.Text.Equals("SQL"))
                {
                    String CONNECTION_STRING =
                                  "Server=" + SERVER_CONNECTION_TEXT.Text + ";" +
                                  "DataBase=INTRCONFIG;" +
                                  "Uid=" + USERNAME_TEXT.Text + ";" +
                                  "Pwd=" + PASSWORD_TEXT.Text + ";";
                    string hid_pass_txt = PASSWORD_TEXT.Text.Replace(PASSWORD_TEXT.Text, "*******");
                    string hid_pass_con_str = "Server=" + SERVER_CONNECTION_TEXT.Text + ";" +
                                  "DataBase=INTRCONFIG;" +
                                  "Uid=" + USERNAME_TEXT.Text + ";" +
                                  "Pwd=" + hid_pass_txt + ";";
                    CONNECTION_STRING_TEXT_BOX.Text = hid_pass_con_str;
                    SqlConnection conn = new SqlConnection(CONNECTION_STRING);
                    try
                    {
                        conn.Open();
                        MessageBox.Show("Connection Open ! ");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Not Connected - " + ex.Message);

                    }
                }
                else if (DB_TYPE_COMBO.Text.Equals("Oracle"))
                {
                    string CONNECTION_STRING = "User Id=" + USERNAME_TEXT.Text + ";Password=" + PASSWORD_TEXT.Text + ";Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + ORA_HOST_TEXT.Text + ")(PORT=" + DB_PORT_TEXT.Text + "))" + "(CONNECT_DATA=(SID=" + SERVER_CONNECTION_TEXT.Text + ")));";
                    OracleConnection conn = new OracleConnection(CONNECTION_STRING);
                    try
                    {
                        conn.Open();
                        string hid_pass_txt = PASSWORD_TEXT.Text.Replace(PASSWORD_TEXT.Text, "*******");
                        string hid_pass_con_str = "User Id=" + USERNAME_TEXT.Text + ";Password=" + hid_pass_txt + ";Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + ORA_HOST_TEXT.Text + ")(PORT=" + DB_PORT_TEXT.Text + "))" + "(CONNECT_DATA=(SID=" + SERVER_CONNECTION_TEXT.Text + ")));";
                        CONNECTION_STRING_TEXT_BOX.Text = hid_pass_con_str;
                        MessageBox.Show("Connection Open ! ");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Not Connected - " + ex.Message);

                    }
                }

            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'iNTRCONFIGDataSet.intr_t_Processes' table. You can move, or remove it, as needed.


        }
        public void BK_CONTINUE_BUTTON_Click(object sender, EventArgs e)
        {
            StringBuilder PK_PROCESS_ID_STRING = new StringBuilder();
            PK_PROCESS_ID_STRING.Append("(");
            foreach (DataGridViewCell cell in this.dataGridView1.SelectedCells)
            {
                if (cell.ColumnIndex == 0)
                {
                    PK_PROCESS_ID_STRING.Append(cell.Value.ToString() + ",");
                }
            }
            PK_PROCESS_ID_STRING.Remove((PK_PROCESS_ID_STRING.Length - 1), 1);
            PK_PROCESS_ID_STRING.Append(")");
            string BK_XML_LOC_TEXT2 = BK_XML_LOC_TEXT.Text.Replace("\\", "\\\\");

            MessageBox.Show("The list of IDs to be backed up is: " + PK_PROCESS_ID_STRING.ToString());
            if (DB_TYPE_COMBO.Text.Equals("SQL"))
            {
                String CONNECTION_STRING =
                              "Server=" + SERVER_CONNECTION_TEXT.Text + ";" +
                              "DataBase=INTRCONFIG;" +
                              "Uid=" + USERNAME_TEXT.Text + ";" +
                              "Pwd=" + PASSWORD_TEXT.Text + ";";
                CONNECTION_STRING_TEXT_BOX.Text = CONNECTION_STRING;

                try
                {
                    SqlConnection sCon = new SqlConnection(CONNECTION_STRING);
                    sCon.Open();
                    SqlCommand sTmp = new SqlCommand();
                    sTmp.CommandType = CommandType.Text;
                    sTmp.Connection = sCon;
                    sTmp.CommandText = "SELECT * FROM intr_t_Processes WHERE pk_Process_ID IN " + PK_PROCESS_ID_STRING;
                    SqlDataAdapter intr_t_Processes_da_s = new SqlDataAdapter(sTmp);
                    DataSet intr_t_Processes_ds_s = new DataSet();
                    intr_t_Processes_da_s.Fill(intr_t_Processes_ds_s, "intr_t_Processes");
                    DataTable intr_t_Processes_dt = intr_t_Processes_ds_s.Tables[0];
                    DataTable intr_t_Processes_dt2 = intr_t_Processes_dt.Clone();
                    DataRow[] results = intr_t_Processes_dt.Select("PK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results)
                    {
                        intr_t_Processes_dt2.ImportRow(dr);
                    }
                    SqlCommand intr_t_Processes_dt2_SC = new SqlCommand();
                    intr_t_Processes_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Processes_dt2_SC.Connection = sCon;
                    intr_t_Processes_dt2_SC.CommandText = "SELECT * FROM intr_t_Processes_dt2";
                    SqlDataAdapter intr_t_Processes_dt2_SC_s = new SqlDataAdapter(intr_t_Processes_dt2_SC);
                    XmlWriter INTR_T_PROCESS_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Processes.xml");
                    INTR_T_PROCESS_XML_WRITER.WriteStartDocument();
                    INTR_T_PROCESS_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Processes_dt2.Rows)
                    {
                        INTR_T_PROCESS_XML_WRITER.WriteStartElement("intr_t_Processes");
                        INTR_T_PROCESS_XML_WRITER.WriteElementString("PK_PROCESS_ID",row["pk_Process_ID"].ToString());
                        INTR_T_PROCESS_XML_WRITER.WriteElementString("PROCESS_NAME",row["Process_Name"].ToString());
                        INTR_T_PROCESS_XML_WRITER.WriteElementString("Status",row["Status"].ToString());
                        INTR_T_PROCESS_XML_WRITER.WriteElementString("Next_Execution_Step",row["Next_Execution_Step"].ToString());
                        INTR_T_PROCESS_XML_WRITER.WriteElementString("Data_Set",row["Data_Set"].ToString());
                        INTR_T_PROCESS_XML_WRITER.WriteElementString("fk_Process_Type_ID",row["fk_Process_Type_ID"].ToString());
                        INTR_T_PROCESS_XML_WRITER.WriteElementString("CURRENT_USER",row["CURRENT_USER"].ToString());
                        INTR_T_PROCESS_XML_WRITER.WriteElementString("Active",row["Active"].ToString());
                        INTR_T_PROCESS_XML_WRITER.WriteEndElement();    
                    }
                    INTR_T_PROCESS_XML_WRITER.WriteEndElement();
                    INTR_T_PROCESS_XML_WRITER.WriteEndDocument();
                    INTR_T_PROCESS_XML_WRITER.Close();
                    //intr_t_Processes_ds_s.WriteXml(BK_XML_LOC_TEXT2 + "\\intr_t_Processes.xml", System.Data.XmlWriteMode.WriteSchema);

                    SqlCommand sTmp2 = new SqlCommand();
                    sTmp2.CommandType = CommandType.Text;
                    sTmp2.Connection = sCon;
                    sTmp2.CommandText = "SELECT * FROM intr_t_Configuration_Defaults WHERE pk_Process_ID IN " + PK_PROCESS_ID_STRING;
                    SqlDataAdapter intr_t_Configuration_Defaults_da_s = new SqlDataAdapter(sTmp2);
                    DataSet intr_t_Configuration_Defaults_ds_s = new DataSet();
                    intr_t_Configuration_Defaults_da_s.Fill(intr_t_Configuration_Defaults_ds_s, "intr_t_Configuration_Defaults");
                    DataTable intr_t_Configuration_Defaults_dt = intr_t_Configuration_Defaults_ds_s.Tables[0];
                    DataTable intr_t_Configuration_Defaults_dt2 = intr_t_Configuration_Defaults_dt.Clone();
                    DataRow[] results2 = intr_t_Configuration_Defaults_dt.Select("PK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results2)
                    {
                        intr_t_Configuration_Defaults_dt2.ImportRow(dr);
                    }
                    SqlCommand intr_t_Configuration_Defaults_dt2_SC = new SqlCommand();
                    intr_t_Configuration_Defaults_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Configuration_Defaults_dt2_SC.Connection = sCon;
                    intr_t_Configuration_Defaults_dt2_SC.CommandText = "SELECT * FROM intr_t_Configuration_Defaults_dt2";
                    SqlDataAdapter intr_t_Configuration_Defaults_dt2_SC_s = new SqlDataAdapter(intr_t_Configuration_Defaults_dt2_SC);
                    XmlWriter intr_t_Configuration_Defaults_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Configuration_Defaults.xml");
                    intr_t_Configuration_Defaults_XML_WRITER.WriteStartDocument();
                    intr_t_Configuration_Defaults_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Configuration_Defaults_dt2.Rows)
                    {
                        intr_t_Configuration_Defaults_XML_WRITER.WriteStartElement("intr_t_Configuration_Defaults");
                        intr_t_Configuration_Defaults_XML_WRITER.WriteElementString("PK_POSITION", row["PK_POSITION"].ToString());
                        intr_t_Configuration_Defaults_XML_WRITER.WriteElementString("FK_FIELD_NAME", row["FK_FIELD_NAME"].ToString());
                        intr_t_Configuration_Defaults_XML_WRITER.WriteElementString("RMS_FIELD_SIZE", row["RMS_FIELD_SIZE"].ToString());
                        intr_t_Configuration_Defaults_XML_WRITER.WriteElementString("ATT_SEND_SIZE", row["ATT_SEND_SIZE"].ToString());
                        intr_t_Configuration_Defaults_XML_WRITER.WriteElementString("TABLE_NAME", row["TABLE_NAME"].ToString());
                        intr_t_Configuration_Defaults_XML_WRITER.WriteElementString("PK_PROCESS_ID", row["PK_PROCESS_ID"].ToString());
                        intr_t_Configuration_Defaults_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Configuration_Defaults_XML_WRITER.WriteEndElement();
                    intr_t_Configuration_Defaults_XML_WRITER.WriteEndDocument();
                    intr_t_Configuration_Defaults_XML_WRITER.Close();

                    SqlCommand sTmp3 = new SqlCommand();
                    sTmp3.CommandType = CommandType.Text;
                    sTmp3.Connection = sCon;
                    sTmp3.CommandText = "SELECT * FROM intr_t_Data_Dictionary WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    SqlDataAdapter intr_t_Data_Dictionary_da_s = new SqlDataAdapter(sTmp3);
                    DataSet intr_t_Data_Dictionary_ds_s = new DataSet();
                    intr_t_Data_Dictionary_da_s.Fill(intr_t_Data_Dictionary_ds_s, "intr_t_Data_Dictionary");
                    DataTable intr_t_Data_Dictionary_dt = intr_t_Data_Dictionary_ds_s.Tables[0];
                    DataTable intr_t_Data_Dictionary_dt2 = intr_t_Data_Dictionary_dt.Clone();
                    DataRow[] results3 = intr_t_Data_Dictionary_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results3)
                    {
                        intr_t_Data_Dictionary_dt2.ImportRow(dr);
                    }
                    SqlCommand intr_t_Data_Dictionary_dt2_SC = new SqlCommand();
                    intr_t_Data_Dictionary_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Data_Dictionary_dt2_SC.Connection = sCon;
                    intr_t_Data_Dictionary_dt2_SC.CommandText = "SELECT * FROM intr_t_Data_Dictionary_dt2";
                    SqlDataAdapter intr_t_Data_Dictionary_dt2_SC_s = new SqlDataAdapter(intr_t_Data_Dictionary_dt2_SC);
                    XmlWriter intr_t_Data_Dictionary_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Data_Dictionary.xml");
                    intr_t_Data_Dictionary_XML_WRITER.WriteStartDocument();
                    intr_t_Data_Dictionary_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Data_Dictionary_dt2.Rows)
                    {
                        intr_t_Data_Dictionary_XML_WRITER.WriteStartElement("intr_t_Data_Dictionary");
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("CK_DICTIONARY_ITEM_NAME", row["CK_DICTIONARY_ITEM_NAME"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("CK_SOURCE_TYPE", row["CK_SOURCE_TYPE"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("FTP_SERVER", row["FTP_SERVER"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("FTP_REMOTE_FILE_NAME", row["FTP_REMOTE_FILE_NAME"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("FTP_USER", row["FTP_USER"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("FTP_PASSWORD", row["FTP_PASSWORD"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("TEXT_LOCAL_FILE_PATH", row["TEXT_LOCAL_FILE_PATH"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("TEXT_FILE_FORMAT", row["TEXT_FILE_FORMAT"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("TEXT_ARCHIVE_FILE_PATH", row["TEXT_ARCHIVE_FILE_PATH"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("TEXT_DELIMITER", row["TEXT_DELIMITER"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("TEXT_DATE_DELIMITER", row["TEXT_DATE_DELIMITER"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("TEXT_DATE_FORMAT", row["TEXT_DATE_FORMAT"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("REMOTE_DB_TYPE", row["REMOTE_DB_TYPE"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("AUTHENTICATE_AGAINST", row["AUTHENTICATE_AGAINST"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("REMOTE_SERVER_USERNAME", row["REMOTE_SERVER_USERNAME"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("REMOTE_SERVER_PASSWORD", row["REMOTE_SERVER_PASSWORD"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("REMOTE_DATABASE_NAME", row["REMOTE_DATABASE_NAME"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("REMOTE_TABLE_NAME", row["REMOTE_TABLE_NAME"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("RECORD_TERMINATOR", row["RECORD_TERMINATOR"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Data_Dictionary_XML_WRITER.WriteEndElement();
                    intr_t_Data_Dictionary_XML_WRITER.WriteEndDocument();
                    intr_t_Data_Dictionary_XML_WRITER.Close();

                    SqlCommand sTmp4 = new SqlCommand();
                    sTmp4.CommandType = CommandType.Text;
                    sTmp4.Connection = sCon;
                    sTmp4.CommandText = "SELECT * FROM intr_t_Exclusions WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    SqlDataAdapter intr_t_Exclusions_da_s = new SqlDataAdapter(sTmp4);
                    DataSet intr_t_Exclusions_ds_s = new DataSet();
                    intr_t_Exclusions_da_s.Fill(intr_t_Exclusions_ds_s, "intr_t_Exclusions");
                    DataTable intr_t_Exclusions_dt = intr_t_Exclusions_ds_s.Tables[0];
                    DataTable intr_t_Exclusions_dt2 = intr_t_Exclusions_dt.Clone();
                    DataRow[] results4 = intr_t_Exclusions_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results4)
                    {
                        intr_t_Exclusions_dt2.ImportRow(dr);
                    }
                    SqlCommand intr_t_Exclusions_dt2_SC = new SqlCommand();
                    intr_t_Exclusions_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Exclusions_dt2_SC.Connection = sCon;
                    intr_t_Exclusions_dt2_SC.CommandText = "SELECT * FROM intr_t_Exclusions_dt2";
                    SqlDataAdapter intr_t_Exclusions_dt2_SC_s = new SqlDataAdapter(intr_t_Exclusions_dt2_SC);
                    XmlWriter intr_t_Exclusions_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Exclusions.xml");
                    intr_t_Exclusions_XML_WRITER.WriteStartDocument();
                    intr_t_Exclusions_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Exclusions_dt2.Rows)
                    {
                        intr_t_Exclusions_XML_WRITER.WriteStartElement("intr_t_Exclusions");
                        intr_t_Exclusions_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Exclusions_XML_WRITER.WriteElementString("CK_EXCLUSION_TYPE", row["CK_EXCLUSION_TYPE"].ToString());
                        intr_t_Exclusions_XML_WRITER.WriteElementString("CK_EXCLUSION_VALUE", row["CK_EXCLUSION_VALUE"].ToString());
                        intr_t_Exclusions_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Exclusions_XML_WRITER.WriteEndElement();
                    intr_t_Exclusions_XML_WRITER.WriteEndDocument();
                    intr_t_Exclusions_XML_WRITER.Close();

                    SqlCommand sTmp5 = new SqlCommand();
                    sTmp5.CommandType = CommandType.Text;
                    sTmp5.Connection = sCon;
                    sTmp5.CommandText = "SELECT * FROM intr_t_Field_Map WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    SqlDataAdapter intr_t_Field_Map_da_s = new SqlDataAdapter(sTmp5);
                    DataSet intr_t_Field_Map_ds_s = new DataSet();
                    intr_t_Field_Map_da_s.Fill(intr_t_Field_Map_ds_s, "intr_t_Field_Map");
                    DataTable intr_t_Field_Map_dt = intr_t_Field_Map_ds_s.Tables[0];
                    DataTable intr_t_Field_Map_dt2 = intr_t_Field_Map_dt.Clone();
                    DataRow[] results5 = intr_t_Field_Map_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results5)
                    {
                        intr_t_Field_Map_dt2.ImportRow(dr);
                    }
                    SqlCommand intr_t_Field_Map_dt2_SC = new SqlCommand();
                    intr_t_Field_Map_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Field_Map_dt2_SC.Connection = sCon;
                    intr_t_Field_Map_dt2_SC.CommandText = "SELECT * FROM intr_t_Field_Map_dt2";
                    SqlDataAdapter intr_t_Field_Map_dt2_SC_s = new SqlDataAdapter(intr_t_Field_Map_dt2_SC);
                    XmlWriter intr_t_Field_Map_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Field_Map.xml");
                    intr_t_Field_Map_XML_WRITER.WriteStartDocument();
                    intr_t_Field_Map_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Field_Map_dt2.Rows)
                    {
                        intr_t_Field_Map_XML_WRITER.WriteStartElement("intr_t_Field_Map");
                        intr_t_Field_Map_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("CK_SOURCE_TYPE", row["CK_SOURCE_TYPE"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("CK_DICTIONARY_ITEM_NAME", row["CK_DICTIONARY_ITEM_NAME"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("CK_PROCESS_FIELD_NAME", row["CK_PROCESS_FIELD_NAME"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("PROCESS_FIELD_TYPE", row["PROCESS_FIELD_TYPE"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("PROCESS_FIELD_START_POS", row["PROCESS_FIELD_START_POS"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("PROCESS_FIELD_SIZE", row["PROCESS_FIELD_SIZE"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("PROCESS_FIELD_SPFORMAT", row["PROCESS_FIELD_SPFORMAT"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("EXTERNAL_FIELD_NAME", row["EXTERNAL_FIELD_NAME"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("EXTERNAL_FIELD_TYPE", row["EXTERNAL_FIELD_TYPE"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("EXTERNAL_FIELD_SIZE", row["EXTERNAL_FIELD_SIZE"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("PROCESS_FIELD_JUSTifY", row["PROCESS_FIELD_JUSTifY"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("PROCESS_FIELD_FILL_CHAR", row["PROCESS_FIELD_FILL_CHAR"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Field_Map_XML_WRITER.WriteEndElement();
                    intr_t_Field_Map_XML_WRITER.WriteEndDocument();
                    intr_t_Field_Map_XML_WRITER.Close();

                    SqlCommand sTmp6 = new SqlCommand();
                    sTmp6.CommandType = CommandType.Text;
                    sTmp6.Connection = sCon;
                    sTmp6.CommandText = "SELECT * FROM intr_t_Incident_Translator WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    SqlDataAdapter intr_t_Incident_Translator_da_s = new SqlDataAdapter(sTmp6);
                    DataSet intr_t_Incident_Translator_ds_s = new DataSet();
                    intr_t_Incident_Translator_da_s.Fill(intr_t_Incident_Translator_ds_s, "intr_t_Incident_Translator");
                    DataTable intr_t_Incident_Translator_dt = intr_t_Incident_Translator_ds_s.Tables[0];
                    DataTable intr_t_Incident_Translator_dt2 = intr_t_Incident_Translator_dt.Clone();
                    DataRow[] results6 = intr_t_Incident_Translator_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results6)
                    {
                        intr_t_Incident_Translator_dt2.ImportRow(dr);
                    }
                    SqlCommand intr_t_Incident_Translator_dt2_SC = new SqlCommand();
                    intr_t_Incident_Translator_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Incident_Translator_dt2_SC.Connection = sCon;
                    intr_t_Incident_Translator_dt2_SC.CommandText = "SELECT * FROM intr_t_Incident_Translator_dt2";
                    SqlDataAdapter intr_t_Incident_Translator_dt2_SC_s = new SqlDataAdapter(intr_t_Incident_Translator_dt2_SC);
                    XmlWriter intr_t_Incident_Translator_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Incident_Translator.xml");
                    intr_t_Incident_Translator_XML_WRITER.WriteStartDocument();
                    intr_t_Incident_Translator_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Incident_Translator_dt2.Rows)
                    {
                        intr_t_Incident_Translator_XML_WRITER.WriteStartElement("intr_t_Incident_Translator");
                        intr_t_Incident_Translator_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Incident_Translator_XML_WRITER.WriteElementString("CK_IM_EX_FIELD", row["CK_IM_EX_FIELD"].ToString());
                        intr_t_Incident_Translator_XML_WRITER.WriteElementString("FK_INC_TYPE_CODE", row["FK_INC_TYPE_CODE"].ToString());
                        intr_t_Incident_Translator_XML_WRITER.WriteElementString("FK_FLAG_CODE", row["FK_FLAG_CODE"].ToString());
                        intr_t_Incident_Translator_XML_WRITER.WriteElementString("FK_INC_LOCATION_CODE", row["FK_INC_LOCATION_CODE"].ToString());
                        intr_t_Incident_Translator_XML_WRITER.WriteElementString("FK_INC_CLEARY_CODE", row["FK_INC_CLEARY_CODE"].ToString());
                        intr_t_Incident_Translator_XML_WRITER.WriteElementString("FK_INCIDENT_ACTION_ID", row["FK_INCIDENT_ACTION_ID"].ToString());
                        intr_t_Incident_Translator_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Incident_Translator_XML_WRITER.WriteEndElement();
                    intr_t_Incident_Translator_XML_WRITER.WriteEndDocument();
                    intr_t_Incident_Translator_XML_WRITER.Close();

                    SqlCommand sTmp7 = new SqlCommand();
                    sTmp7.CommandType = CommandType.Text;
                    sTmp7.Connection = sCon;
                    sTmp7.CommandText = "SELECT * FROM intr_t_L_U_t_Configurations WHERE pk_Process_ID IN " + PK_PROCESS_ID_STRING;
                    SqlDataAdapter intr_t_L_U_t_Configurations_da_s = new SqlDataAdapter(sTmp7);
                    DataSet intr_t_L_U_t_Configurations_ds_s = new DataSet();
                    intr_t_L_U_t_Configurations_da_s.Fill(intr_t_L_U_t_Configurations_ds_s, "intr_t_L_U_t_Configurations");
                    DataTable intr_t_L_U_t_Configurations_dt = intr_t_L_U_t_Configurations_ds_s.Tables[0];
                    DataTable intr_t_L_U_t_Configurations_dt2 = intr_t_L_U_t_Configurations_dt.Clone();
                    DataRow[] results7 = intr_t_L_U_t_Configurations_dt.Select("PK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results7)
                    {
                        intr_t_L_U_t_Configurations_dt2.ImportRow(dr);
                    }
                    SqlCommand intr_t_L_U_t_Configurations_dt2_SC = new SqlCommand();
                    intr_t_L_U_t_Configurations_dt2_SC.CommandType = CommandType.Text;
                    intr_t_L_U_t_Configurations_dt2_SC.Connection = sCon;
                    intr_t_L_U_t_Configurations_dt2_SC.CommandText = "SELECT * FROM intr_t_L_U_t_Configurations_dt2";
                    SqlDataAdapter intr_t_L_U_t_Configurations_dt2_SC_s = new SqlDataAdapter(intr_t_L_U_t_Configurations_dt2_SC);
                    XmlWriter intr_t_L_U_t_Configurations_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_L_U_t_Configurations.xml");
                    intr_t_L_U_t_Configurations_XML_WRITER.WriteStartDocument();
                    intr_t_L_U_t_Configurations_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_L_U_t_Configurations_dt2.Rows)
                    {
                        intr_t_L_U_t_Configurations_XML_WRITER.WriteStartElement("intr_t_L_U_t_Configurations");
                        intr_t_L_U_t_Configurations_XML_WRITER.WriteElementString("PK_FIELD_NAME", row["PK_FIELD_NAME"].ToString());
                        intr_t_L_U_t_Configurations_XML_WRITER.WriteElementString("TABLE_NAME", row["TABLE_NAME"].ToString());
                        intr_t_L_U_t_Configurations_XML_WRITER.WriteElementString("RMS_FIELD_SIZE", row["RMS_FIELD_SIZE"].ToString());
                        intr_t_L_U_t_Configurations_XML_WRITER.WriteElementString("SQL_STATEMENT", row["SQL_STATEMENT"].ToString());
                        intr_t_L_U_t_Configurations_XML_WRITER.WriteElementString("PK_PROCESS_ID", row["PK_PROCESS_ID"].ToString());
                        intr_t_L_U_t_Configurations_XML_WRITER.WriteEndElement();
                    }
                    intr_t_L_U_t_Configurations_XML_WRITER.WriteEndElement();
                    intr_t_L_U_t_Configurations_XML_WRITER.WriteEndDocument();
                    intr_t_L_U_t_Configurations_XML_WRITER.Close();

                    SqlCommand sTmp8 = new SqlCommand();
                    sTmp8.CommandType = CommandType.Text;
                    sTmp8.Connection = sCon;
                    sTmp8.CommandText = "SELECT * FROM intr_t_Process_Appln_Periods WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    SqlDataAdapter intr_t_Process_Appln_Periods_da_s = new SqlDataAdapter(sTmp8);
                    DataSet intr_t_Process_Appln_Periods_ds_s = new DataSet();
                    intr_t_Process_Appln_Periods_da_s.Fill(intr_t_Process_Appln_Periods_ds_s, "intr_t_Process_Appln_Periods");
                    DataTable intr_t_Process_Appln_Periods_dt = intr_t_Process_Appln_Periods_ds_s.Tables[0];
                    DataTable intr_t_Process_Appln_Periods_dt2 = intr_t_Process_Appln_Periods_dt.Clone();
                    DataRow[] results8 = intr_t_Process_Appln_Periods_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results8)
                    {
                        intr_t_Process_Appln_Periods_dt2.ImportRow(dr);
                    }
                    SqlCommand intr_t_Process_Appln_Periods_dt2_SC = new SqlCommand();
                    intr_t_Process_Appln_Periods_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Process_Appln_Periods_dt2_SC.Connection = sCon;
                    intr_t_Process_Appln_Periods_dt2_SC.CommandText = "SELECT * FROM intr_t_Process_Appln_Periods_dt2";
                    SqlDataAdapter intr_t_Process_Appln_Periods_dt2_SC_s = new SqlDataAdapter(intr_t_Process_Appln_Periods_dt2_SC);
                    XmlWriter intr_t_Process_Appln_Periods_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Process_Appln_Periods.xml");
                    intr_t_Process_Appln_Periods_XML_WRITER.WriteStartDocument();
                    intr_t_Process_Appln_Periods_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Process_Appln_Periods_dt2.Rows)
                    {
                        intr_t_Process_Appln_Periods_XML_WRITER.WriteStartElement("intr_t_Process_Appln_Periods");
                        intr_t_Process_Appln_Periods_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Process_Appln_Periods_XML_WRITER.WriteElementString("CK_SHOW_NAME", row["CK_SHOW_NAME"].ToString());
                        intr_t_Process_Appln_Periods_XML_WRITER.WriteElementString("SHOW_TYPE", row["SHOW_TYPE"].ToString());
                        intr_t_Process_Appln_Periods_XML_WRITER.WriteElementString("REFERENCE_TEXT", row["REFERENCE_TEXT"].ToString());
                        intr_t_Process_Appln_Periods_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Process_Appln_Periods_XML_WRITER.WriteEndElement();
                    intr_t_Process_Appln_Periods_XML_WRITER.WriteEndDocument();
                    intr_t_Process_Appln_Periods_XML_WRITER.Close();

                    SqlCommand sTmp9 = new SqlCommand();
                    sTmp9.CommandType = CommandType.Text;
                    sTmp9.Connection = sCon;
                    sTmp9.CommandText = "SELECT * FROM intr_t_Process_Config_Status WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    SqlDataAdapter intr_t_Process_Config_Status_da_s = new SqlDataAdapter(sTmp9);
                    DataSet intr_t_Process_Config_Status_ds_s = new DataSet();
                    intr_t_Process_Config_Status_da_s.Fill(intr_t_Process_Config_Status_ds_s, "intr_t_Process_Config_Status");
                    DataTable intr_t_Process_Config_Status_dt = intr_t_Process_Config_Status_ds_s.Tables[0];
                    DataTable intr_t_Process_Config_Status_dt2 = intr_t_Process_Config_Status_dt.Clone();
                    DataRow[] results9 = intr_t_Process_Config_Status_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results9)
                    {
                        intr_t_Process_Config_Status_dt2.ImportRow(dr);
                    }
                    SqlCommand intr_t_Process_Config_Status_dt2_SC = new SqlCommand();
                    intr_t_Process_Config_Status_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Process_Config_Status_dt2_SC.Connection = sCon;
                    intr_t_Process_Config_Status_dt2_SC.CommandText = "SELECT * FROM intr_t_Process_Config_Status_dt2";
                    SqlDataAdapter intr_t_Process_Config_Status_dt2_SC_s = new SqlDataAdapter(intr_t_Process_Config_Status_dt2_SC);
                    XmlWriter intr_t_Process_Config_Status_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Process_Config_Status.xml");
                    intr_t_Process_Config_Status_XML_WRITER.WriteStartDocument();
                    intr_t_Process_Config_Status_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Process_Config_Status_dt2.Rows)
                    {
                        intr_t_Process_Config_Status_XML_WRITER.WriteStartElement("intr_t_Process_Config_Status");
                        intr_t_Process_Config_Status_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Process_Config_Status_XML_WRITER.WriteElementString("CK_PROCESS_CONFIG_ITEM", row["CK_PROCESS_CONFIG_ITEM"].ToString());
                        intr_t_Process_Config_Status_XML_WRITER.WriteElementString("CONFIG_ITEM_STATUS", row["CONFIG_ITEM_STATUS"].ToString());
                        intr_t_Process_Config_Status_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Process_Config_Status_XML_WRITER.WriteEndElement();
                    intr_t_Process_Config_Status_XML_WRITER.WriteEndDocument();
                    intr_t_Process_Config_Status_XML_WRITER.Close();

                    SqlCommand sTmp10 = new SqlCommand();
                    sTmp10.CommandType = CommandType.Text;
                    sTmp10.Connection = sCon;
                    sTmp10.CommandText = "SELECT * FROM intr_t_Process_CustProc WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    SqlDataAdapter intr_t_Process_CustProc_da_s = new SqlDataAdapter(sTmp10);
                    DataSet intr_t_Process_CustProc_ds_s = new DataSet();
                    intr_t_Process_CustProc_da_s.Fill(intr_t_Process_CustProc_ds_s, "intr_t_Process_CustProc");
                    DataTable intr_t_Process_CustProc_dt = intr_t_Process_CustProc_ds_s.Tables[0];
                    DataTable intr_t_Process_CustProc_dt2 = intr_t_Process_CustProc_dt.Clone();
                    DataRow[] results10 = intr_t_Process_CustProc_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results10)
                    {
                        intr_t_Process_CustProc_dt2.ImportRow(dr);
                    }
                    SqlCommand intr_t_Process_CustProc_dt2_SC = new SqlCommand();
                    intr_t_Process_CustProc_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Process_CustProc_dt2_SC.Connection = sCon;
                    intr_t_Process_CustProc_dt2_SC.CommandText = "SELECT * FROM intr_t_Process_CustProc_dt2";
                    SqlDataAdapter intr_t_Process_CustProc_dt2_SC_s = new SqlDataAdapter(intr_t_Process_CustProc_dt2_SC);
                    XmlWriter intr_t_Process_CustProc_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Process_CustProc.xml");
                    intr_t_Process_CustProc_XML_WRITER.WriteStartDocument();
                    intr_t_Process_CustProc_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Process_CustProc_dt2.Rows)
                    {
                        intr_t_Process_CustProc_XML_WRITER.WriteStartElement("intr_t_Process_CustProc");
                        intr_t_Process_CustProc_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Process_CustProc_XML_WRITER.WriteElementString("CK_CUST_PROC_DESCRIPTION", row["CK_CUST_PROC_DESCRIPTION"].ToString());
                        intr_t_Process_CustProc_XML_WRITER.WriteElementString("CK_INSERTION", row["CK_INSERTION"].ToString());
                        intr_t_Process_CustProc_XML_WRITER.WriteElementString("CK_ORDER", row["CK_ORDER"].ToString());
                        intr_t_Process_CustProc_XML_WRITER.WriteElementString("SQL_STATEMENT_PART1", row["SQL_STATEMENT_PART1"].ToString());
                        intr_t_Process_CustProc_XML_WRITER.WriteElementString("SQL_STATEMENT_PART2", row["SQL_STATEMENT_PART2"].ToString());
                        intr_t_Process_CustProc_XML_WRITER.WriteElementString("SQL_STATEMENT_PART3", row["SQL_STATEMENT_PART3"].ToString());
                        intr_t_Process_CustProc_XML_WRITER.WriteElementString("SQL_STATEMENT_PART4", row["SQL_STATEMENT_PART4"].ToString());
                        intr_t_Process_CustProc_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Process_CustProc_XML_WRITER.WriteEndElement();
                    intr_t_Process_CustProc_XML_WRITER.WriteEndDocument();
                    intr_t_Process_CustProc_XML_WRITER.Close();

                    SqlCommand sTmp11 = new SqlCommand();
                    sTmp11.CommandType = CommandType.Text;
                    sTmp11.Connection = sCon;
                    sTmp11.CommandText = "SELECT * FROM intr_t_Process_Parameters WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    SqlDataAdapter intr_t_Process_Parameters_da_s = new SqlDataAdapter(sTmp11);
                    DataSet intr_t_Process_Parameters_ds_s = new DataSet();
                    intr_t_Process_Parameters_da_s.Fill(intr_t_Process_Parameters_ds_s, "intr_t_Process_Parameters");
                    DataTable intr_t_Process_Parameters_dt = intr_t_Process_Parameters_ds_s.Tables[0];
                    DataTable intr_t_Process_Parameters_dt2 = intr_t_Process_Parameters_dt.Clone();
                    DataRow[] results11 = intr_t_Process_Parameters_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results11)
                    {
                        intr_t_Process_Parameters_dt2.ImportRow(dr);
                    }
                    SqlCommand intr_t_Process_Parameters_dt2_SC = new SqlCommand();
                    intr_t_Process_Parameters_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Process_Parameters_dt2_SC.Connection = sCon;
                    intr_t_Process_Parameters_dt2_SC.CommandText = "SELECT * FROM intr_t_Process_Parameters_dt2";
                    SqlDataAdapter intr_t_Process_Parameters_dt2_SC_s = new SqlDataAdapter(intr_t_Process_Parameters_dt2_SC);
                    XmlWriter intr_t_Process_Parameters_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Process_Parameters.xml");
                    intr_t_Process_Parameters_XML_WRITER.WriteStartDocument();
                    intr_t_Process_Parameters_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Process_Parameters_dt2.Rows)
                    {
                        intr_t_Process_Parameters_XML_WRITER.WriteStartElement("intr_t_Process_Parameters");
                        intr_t_Process_Parameters_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Process_Parameters_XML_WRITER.WriteElementString("CK_PARAMETER_NAME", row["CK_PARAMETER_NAME"].ToString());
                        intr_t_Process_Parameters_XML_WRITER.WriteElementString("PARAMETER_VALUE", row["PARAMETER_VALUE"].ToString());
                        intr_t_Process_Parameters_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Process_Parameters_XML_WRITER.WriteEndElement();
                    intr_t_Process_Parameters_XML_WRITER.WriteEndDocument();
                    intr_t_Process_Parameters_XML_WRITER.Close();

                    SqlCommand sTmp12 = new SqlCommand();
                    sTmp12.CommandType = CommandType.Text;
                    sTmp12.Connection = sCon;
                    sTmp12.CommandText = "SELECT * FROM intr_t_Process_Plan_Options WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    SqlDataAdapter intr_t_Process_Plan_Options_da_s = new SqlDataAdapter(sTmp12);
                    DataSet intr_t_Process_Plan_Options_ds_s = new DataSet();
                    intr_t_Process_Plan_Options_da_s.Fill(intr_t_Process_Plan_Options_ds_s, "intr_t_Process_Plan_Options");
                    DataTable intr_t_Process_Plan_Options_dt = intr_t_Process_Plan_Options_ds_s.Tables[0];
                    DataTable intr_t_Process_Plan_Options_dt2 = intr_t_Process_Plan_Options_dt.Clone();
                    DataRow[] results12 = intr_t_Process_Plan_Options_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results12)
                    {
                        intr_t_Process_Plan_Options_dt2.ImportRow(dr);
                    }
                    SqlCommand intr_t_Process_Plan_Options_dt2_SC = new SqlCommand();
                    intr_t_Process_Plan_Options_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Process_Plan_Options_dt2_SC.Connection = sCon;
                    intr_t_Process_Plan_Options_dt2_SC.CommandText = "SELECT * FROM intr_t_Process_Plan_Options_dt2";
                    SqlDataAdapter intr_t_Process_Plan_Options_dt2_SC_s = new SqlDataAdapter(intr_t_Process_Plan_Options_dt2_SC);
                    XmlWriter intr_t_Process_Plan_Options_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Process_Plan_Options.xml");
                    intr_t_Process_Plan_Options_XML_WRITER.WriteStartDocument();
                    intr_t_Process_Plan_Options_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Process_Plan_Options_dt2.Rows)
                    {
                        intr_t_Process_Plan_Options_XML_WRITER.WriteStartElement("intr_t_Process_Plan_Options");
                        intr_t_Process_Plan_Options_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Process_Plan_Options_XML_WRITER.WriteElementString("CK_PLAN_TYPE", row["CK_PLAN_TYPE"].ToString());
                        intr_t_Process_Plan_Options_XML_WRITER.WriteElementString("PLAN_TYPE_RESET", row["PLAN_TYPE_RESET"].ToString());
                        intr_t_Process_Plan_Options_XML_WRITER.WriteElementString("PLAN_TYPE_RESET_AMOUNT", row["PLAN_TYPE_RESET_AMOUNT"].ToString());
                        intr_t_Process_Plan_Options_XML_WRITER.WriteElementString("PLAN_TYPE_FORCE_AC", row["PLAN_TYPE_FORCE_AC"].ToString());
                        intr_t_Process_Plan_Options_XML_WRITER.WriteElementString("CK_PROCESS_FIELD_ORDER", row["CK_PROCESS_FIELD_ORDER"].ToString());
                        intr_t_Process_Plan_Options_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Process_Plan_Options_XML_WRITER.WriteEndElement();
                    intr_t_Process_Plan_Options_XML_WRITER.WriteEndDocument();
                    intr_t_Process_Plan_Options_XML_WRITER.Close();

                    SqlCommand sTmp13 = new SqlCommand();
                    sTmp13.CommandType = CommandType.Text;
                    sTmp13.Connection = sCon;
                    sTmp13.CommandText = "SELECT * FROM intr_t_Process_Schedule WHERE pk_Process_ID IN " + PK_PROCESS_ID_STRING;
                    SqlDataAdapter intr_t_Process_Schedule_da_s = new SqlDataAdapter(sTmp13);
                    DataSet intr_t_Process_Schedule_ds_s = new DataSet();
                    intr_t_Process_Schedule_da_s.Fill(intr_t_Process_Schedule_ds_s, "intr_t_Process_Schedule");
                    DataTable intr_t_Process_Schedule_dt = intr_t_Process_Schedule_ds_s.Tables[0];
                    DataTable intr_t_Process_Schedule_dt2 = intr_t_Process_Schedule_dt.Clone();
                    DataRow[] results13 = intr_t_Process_Schedule_dt.Select("PK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results13)
                    {
                        intr_t_Process_Schedule_dt2.ImportRow(dr);
                    }
                    SqlCommand intr_t_Process_Schedule_dt2_SC = new SqlCommand();
                    intr_t_Process_Schedule_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Process_Schedule_dt2_SC.Connection = sCon;
                    intr_t_Process_Schedule_dt2_SC.CommandText = "SELECT * FROM intr_t_Process_Schedule_dt2";
                    SqlDataAdapter intr_t_Process_Schedule_dt2_SC_s = new SqlDataAdapter(intr_t_Process_Schedule_dt2_SC);
                    XmlWriter intr_t_Process_Schedule_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Process_Schedule.xml");
                    intr_t_Process_Schedule_XML_WRITER.WriteStartDocument();
                    intr_t_Process_Schedule_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Process_Schedule_dt2.Rows)
                    {
                        intr_t_Process_Schedule_XML_WRITER.WriteStartElement("intr_t_Process_Schedule");
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("PK_PROCESS_ID", row["PK_PROCESS_ID"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("SCHEDULED", row["SCHEDULED"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("START_DATE", row["START_DATE"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("END_DATE", row["END_DATE"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("RUN_TIME", row["RUN_TIME"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("NEXT_RUN", row["NEXT_RUN"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("LAST_RUN", row["LAST_RUN"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("SCHEDULE_TYPE", row["SCHEDULE_TYPE"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("RUN_SUNDAY", row["RUN_SUNDAY"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("RUN_MONDAY", row["RUN_MONDAY"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("RUN_TUESDAY", row["RUN_TUESDAY"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("RUN_WEDNESDAY", row["RUN_WEDNESDAY"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("RUN_THURSDAY", row["RUN_THURSDAY"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("RUN_FRIDAY", row["RUN_FRIDAY"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("RUN_SATURDAY", row["RUN_SATURDAY"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("CALENDAR_DAY", row["CALENDAR_DAY"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("INTERVAL", row["INTERVAL"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("NO_OF_INTERVALS", row["NO_OF_INTERVALS"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("SCHED_USERNAME", row["SCHED_USERNAME"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("SCHED_PASSWORD", row["SCHED_PASSWORD"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Process_Schedule_XML_WRITER.WriteEndElement();
                    intr_t_Process_Schedule_XML_WRITER.WriteEndDocument();
                    intr_t_Process_Schedule_XML_WRITER.Close();

                    SqlCommand sTmp14 = new SqlCommand();
                    sTmp14.CommandType = CommandType.Text;
                    sTmp14.Connection = sCon;
                    sTmp14.CommandText = "SELECT * FROM intr_t_Process_SpecificTxTypes WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    SqlDataAdapter intr_t_Process_SpecificTxTypes_da_s = new SqlDataAdapter(sTmp14);
                    DataSet intr_t_Process_SpecificTxTypes_ds_s = new DataSet();
                    intr_t_Process_SpecificTxTypes_da_s.Fill(intr_t_Process_SpecificTxTypes_ds_s, "intr_t_Process_SpecificTxTypes");
                    DataTable intr_t_Process_SpecificTxTypes_dt = intr_t_Process_SpecificTxTypes_ds_s.Tables[0];
                    DataTable intr_t_Process_SpecificTxTypes_dt2 = intr_t_Process_SpecificTxTypes_dt.Clone();
                    DataRow[] results14 = intr_t_Process_SpecificTxTypes_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results14)
                    {
                        intr_t_Process_SpecificTxTypes_dt2.ImportRow(dr);
                    }
                    SqlCommand intr_t_Process_SpecificTxTypes_dt2_SC = new SqlCommand();
                    intr_t_Process_SpecificTxTypes_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Process_SpecificTxTypes_dt2_SC.Connection = sCon;
                    intr_t_Process_SpecificTxTypes_dt2_SC.CommandText = "SELECT * FROM intr_t_Process_SpecificTxTypes_dt2";
                    SqlDataAdapter intr_t_Process_SpecificTxTypes_dt2_SC_s = new SqlDataAdapter(intr_t_Process_SpecificTxTypes_dt2_SC);
                    XmlWriter intr_t_Process_SpecificTxTypes_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Process_SpecificTxTypes.xml");
                    intr_t_Process_SpecificTxTypes_XML_WRITER.WriteStartDocument();
                    intr_t_Process_SpecificTxTypes_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Process_SpecificTxTypes_dt2.Rows)
                    {
                        intr_t_Process_SpecificTxTypes_XML_WRITER.WriteStartElement("intr_t_Process_SpecificTxTypes");
                        intr_t_Process_SpecificTxTypes_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Process_SpecificTxTypes_XML_WRITER.WriteElementString("CK_TXTYPE", row["CK_TXTYPE"].ToString());
                        intr_t_Process_SpecificTxTypes_XML_WRITER.WriteElementString("CLOSES_ACCOUNT", row["CLOSES_ACCOUNT"].ToString());
                        intr_t_Process_SpecificTxTypes_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Process_SpecificTxTypes_XML_WRITER.WriteEndElement();
                    intr_t_Process_SpecificTxTypes_XML_WRITER.WriteEndDocument();
                    intr_t_Process_SpecificTxTypes_XML_WRITER.Close();

                    SqlCommand sTmp15 = new SqlCommand();
                    sTmp15.CommandType = CommandType.Text;
                    sTmp15.Connection = sCon;
                    sTmp15.CommandText = "SELECT * FROM intr_t_Process_Terms_ForUpload WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    SqlDataAdapter intr_t_Process_Terms_ForUpload_da_s = new SqlDataAdapter(sTmp15);
                    DataSet intr_t_Process_Terms_ForUpload_ds_s = new DataSet();
                    intr_t_Process_Terms_ForUpload_da_s.Fill(intr_t_Process_Terms_ForUpload_ds_s, "intr_t_Process_Terms_ForUpload");
                    DataTable intr_t_Process_Terms_ForUpload_dt = intr_t_Process_Terms_ForUpload_ds_s.Tables[0];
                    DataTable intr_t_Process_Terms_ForUpload_dt2 = intr_t_Process_Terms_ForUpload_dt.Clone();
                    DataRow[] results15 = intr_t_Process_Terms_ForUpload_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results15)
                    {
                        intr_t_Process_Terms_ForUpload_dt2.ImportRow(dr);
                    }
                    SqlCommand intr_t_Process_Terms_ForUpload_dt2_SC = new SqlCommand();
                    intr_t_Process_Terms_ForUpload_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Process_Terms_ForUpload_dt2_SC.Connection = sCon;
                    intr_t_Process_Terms_ForUpload_dt2_SC.CommandText = "SELECT * FROM intr_t_Process_Terms_ForUpload_dt2";
                    SqlDataAdapter intr_t_Process_Terms_ForUpload_dt2_SC_s = new SqlDataAdapter(intr_t_Process_Terms_ForUpload_dt2_SC);
                    XmlWriter intr_t_Process_Terms_ForUpload_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Process_Terms_ForUpload.xml");
                    intr_t_Process_Terms_ForUpload_XML_WRITER.WriteStartDocument();
                    intr_t_Process_Terms_ForUpload_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Process_Terms_ForUpload_dt2.Rows)
                    {
                        intr_t_Process_Terms_ForUpload_XML_WRITER.WriteStartElement("intr_t_Process_Terms_ForUpload");
                        intr_t_Process_Terms_ForUpload_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Process_Terms_ForUpload_XML_WRITER.WriteElementString("CK_TERM_ID", row["CK_TERM_ID"].ToString());
                        intr_t_Process_Terms_ForUpload_XML_WRITER.WriteElementString("UPLOAD", row["UPLOAD"].ToString());
                        intr_t_Process_Terms_ForUpload_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Process_Terms_ForUpload_XML_WRITER.WriteEndElement();
                    intr_t_Process_Terms_ForUpload_XML_WRITER.WriteEndDocument();
                    intr_t_Process_Terms_ForUpload_XML_WRITER.Close();

                    SqlCommand sTmp16 = new SqlCommand();
                    sTmp16.CommandType = CommandType.Text;
                    sTmp16.Connection = sCon;
                    sTmp16.CommandText = "SELECT * FROM intr_t_Process_Translator WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    SqlDataAdapter intr_t_Process_Translator_da_s = new SqlDataAdapter(sTmp16);
                    DataSet intr_t_Process_Translator_ds_s = new DataSet();
                    intr_t_Process_Translator_da_s.Fill(intr_t_Process_Translator_ds_s, "intr_t_Process_Translator");
                    DataTable intr_t_Process_Translator_dt = intr_t_Process_Translator_ds_s.Tables[0];
                    DataTable intr_t_Process_Translator_dt2 = intr_t_Process_Translator_dt.Clone();
                    DataRow[] results16 = intr_t_Process_Translator_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results16)
                    {
                        intr_t_Process_Translator_dt2.ImportRow(dr);
                    }
                    SqlCommand intr_t_Process_Translator_dt2_SC = new SqlCommand();
                    intr_t_Process_Translator_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Process_Translator_dt2_SC.Connection = sCon;
                    intr_t_Process_Translator_dt2_SC.CommandText = "SELECT * FROM intr_t_Process_Translator_dt2";
                    SqlDataAdapter intr_t_Process_Translator_dt2_SC_s = new SqlDataAdapter(intr_t_Process_Translator_dt2_SC);
                    XmlWriter intr_t_Process_Translator_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Process_Translator.xml");
                    intr_t_Process_Translator_XML_WRITER.WriteStartDocument();
                    intr_t_Process_Translator_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Process_Translator_dt2.Rows)
                    {
                        intr_t_Process_Translator_XML_WRITER.WriteStartElement("intr_t_Process_Translator");
                        intr_t_Process_Translator_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Process_Translator_XML_WRITER.WriteElementString("CK_PROCESS_FIELD_NAME", row["CK_PROCESS_FIELD_NAME"].ToString());
                        intr_t_Process_Translator_XML_WRITER.WriteElementString("CK_PROCESS_FIELD_VALUE", row["CK_PROCESS_FIELD_VALUE"].ToString());
                        intr_t_Process_Translator_XML_WRITER.WriteElementString("TRANSLATED_VALUE", row["TRANSLATED_VALUE"].ToString());
                        intr_t_Process_Translator_XML_WRITER.WriteElementString("CK_PROCESS_FIELD_ORDER", row["CK_PROCESS_FIELD_ORDER"].ToString());
                        intr_t_Process_Translator_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Process_Translator_XML_WRITER.WriteEndElement();
                    intr_t_Process_Translator_XML_WRITER.WriteEndDocument();
                    intr_t_Process_Translator_XML_WRITER.Close();

                    SqlCommand sTmp17 = new SqlCommand();
                    sTmp17.CommandType = CommandType.Text;
                    sTmp17.Connection = sCon;
                    sTmp17.CommandText = "SELECT * FROM intr_t_Status WHERE fk_Process_ID IN " + PK_PROCESS_ID_STRING;
                    SqlDataAdapter intr_t_Status_da_s = new SqlDataAdapter(sTmp17);
                    DataSet intr_t_Status_ds_s = new DataSet();
                    intr_t_Status_da_s.Fill(intr_t_Status_ds_s, "intr_t_Status");
                    DataTable intr_t_Status_dt = intr_t_Status_ds_s.Tables[0];
                    DataTable intr_t_Status_dt2 = intr_t_Status_dt.Clone();
                    DataRow[] results17 = intr_t_Status_dt.Select("FK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results17)
                    {
                        intr_t_Status_dt2.ImportRow(dr);
                    }
                    SqlCommand intr_t_Status_dt2_SC = new SqlCommand();
                    intr_t_Status_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Status_dt2_SC.Connection = sCon;
                    intr_t_Status_dt2_SC.CommandText = "SELECT * FROM intr_t_Status_dt2";
                    SqlDataAdapter intr_t_Status_dt2_SC_s = new SqlDataAdapter(intr_t_Status_dt2_SC);
                    XmlWriter intr_t_Status_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Status.xml");
                    intr_t_Status_XML_WRITER.WriteStartDocument();
                    intr_t_Status_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Status_dt2.Rows)
                    {
                        intr_t_Status_XML_WRITER.WriteStartElement("intr_t_Status");
                        intr_t_Status_XML_WRITER.WriteElementString("PK_OPERATION_ID", row["PK_OPERATION_ID"].ToString());
                        intr_t_Status_XML_WRITER.WriteElementString("FK_PROCESS_ID", row["FK_PROCESS_ID"].ToString());
                        intr_t_Status_XML_WRITER.WriteElementString("START_DATE", row["START_DATE"].ToString());
                        intr_t_Status_XML_WRITER.WriteElementString("COMPLETION_DATE", row["COMPLETION_DATE"].ToString());
                        intr_t_Status_XML_WRITER.WriteElementString("SUCCESS", row["SUCCESS"].ToString());
                        intr_t_Status_XML_WRITER.WriteElementString("No_Processed", row["No_Processed"].ToString());
                        intr_t_Status_XML_WRITER.WriteElementString("No_New", row["No_New"].ToString());
                        intr_t_Status_XML_WRITER.WriteElementString("No_Changes", row["No_Changes"].ToString());
                        intr_t_Status_XML_WRITER.WriteElementString("No_Non_Critical_Errors", row["No_Non_Critical_Errors"].ToString());
                        intr_t_Status_XML_WRITER.WriteElementString("STATUS_MESSAGE", row["STATUS_MESSAGE"].ToString());
                        intr_t_Status_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Status_XML_WRITER.WriteEndElement();
                    intr_t_Status_XML_WRITER.WriteEndDocument();
                    intr_t_Status_XML_WRITER.Close();
                    MessageBox.Show("Backup completed successfully to " + BK_XML_LOC_TEXT2 + ". Please zip the files at your earliest convenince.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Not Connected - " + ex.Message);

                }
            }
            else if (DB_TYPE_COMBO.Text.Equals("Oracle"))
            {
                string CONNECTION_STRING = "User Id=" + USERNAME_TEXT.Text + ";Password=" + PASSWORD_TEXT.Text + ";Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + ORA_HOST_TEXT.Text + ")(PORT=" + DB_PORT_TEXT.Text + "))" + "(CONNECT_DATA=(SID=" + SERVER_CONNECTION_TEXT.Text + ")));";
                try
                {
                    OracleConnection oCon = new OracleConnection(CONNECTION_STRING);
                    oCon.Open();
                    OracleCommand sTmp = new OracleCommand();
                    sTmp.CommandType = CommandType.Text;
                    sTmp.Connection = oCon;
                    sTmp.CommandText = "SELECT * FROM intr_t_Processes WHERE pk_Process_ID IN " + PK_PROCESS_ID_STRING;
                    OracleDataAdapter intr_t_Processes_da_s = new OracleDataAdapter(sTmp);
                    DataSet intr_t_Processes_ds_s = new DataSet();
                    intr_t_Processes_da_s.Fill(intr_t_Processes_ds_s, "intr_t_Processes");
                    DataTable intr_t_Processes_dt = intr_t_Processes_ds_s.Tables[0];
                    DataTable intr_t_Processes_dt2 = intr_t_Processes_dt.Clone();
                    DataRow[] results = intr_t_Processes_dt.Select("PK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results)
                    {
                        intr_t_Processes_dt2.ImportRow(dr);
                    }
                    OracleCommand intr_t_Processes_dt2_SC = new OracleCommand();
                    intr_t_Processes_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Processes_dt2_SC.Connection = oCon;
                    intr_t_Processes_dt2_SC.CommandText = "SELECT * FROM intr_t_Processes_dt2";
                    OracleDataAdapter intr_t_Processes_dt2_SC_s = new OracleDataAdapter(intr_t_Processes_dt2_SC);
                    XmlWriter INTR_T_PROCESS_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Processes.xml");
                    INTR_T_PROCESS_XML_WRITER.WriteStartDocument();
                    INTR_T_PROCESS_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Processes_dt2.Rows)
                    {
                        INTR_T_PROCESS_XML_WRITER.WriteStartElement("intr_t_Processes");
                        INTR_T_PROCESS_XML_WRITER.WriteElementString("PK_PROCESS_ID",row["pk_Process_ID"].ToString());
                        INTR_T_PROCESS_XML_WRITER.WriteElementString("PROCESS_NAME",row["Process_Name"].ToString());
                        INTR_T_PROCESS_XML_WRITER.WriteElementString("Status",row["Status"].ToString());
                        INTR_T_PROCESS_XML_WRITER.WriteElementString("Next_Execution_Step",row["Next_Execution_Step"].ToString());
                        INTR_T_PROCESS_XML_WRITER.WriteElementString("Data_Set",row["Data_Set"].ToString());
                        INTR_T_PROCESS_XML_WRITER.WriteElementString("fk_Process_Type_ID",row["fk_Process_Type_ID"].ToString());
                        INTR_T_PROCESS_XML_WRITER.WriteElementString("CURRENT_USER",row["CURRENT_USER"].ToString());
                        INTR_T_PROCESS_XML_WRITER.WriteElementString("Active",row["Active"].ToString());
                        INTR_T_PROCESS_XML_WRITER.WriteEndElement();    
                    }
                    INTR_T_PROCESS_XML_WRITER.WriteEndElement();
                    INTR_T_PROCESS_XML_WRITER.WriteEndDocument();
                    INTR_T_PROCESS_XML_WRITER.Close();

                    OracleCommand sTmp2 = new OracleCommand();
                    sTmp2.CommandType = CommandType.Text;
                    sTmp2.Connection = oCon;
                    sTmp2.CommandText = "SELECT * FROM intr_t_Configuration_Defaults WHERE pk_Process_ID IN " + PK_PROCESS_ID_STRING;
                    OracleDataAdapter intr_t_Configuration_Defaults_da_s = new OracleDataAdapter(sTmp2);
                    DataSet intr_t_Configuration_Defaults_ds_s = new DataSet();
                    intr_t_Configuration_Defaults_da_s.Fill(intr_t_Configuration_Defaults_ds_s, "intr_t_Configuration_Defaults");
                    DataTable intr_t_Configuration_Defaults_dt = intr_t_Configuration_Defaults_ds_s.Tables[0];
                    DataTable intr_t_Configuration_Defaults_dt2 = intr_t_Configuration_Defaults_dt.Clone();
                    DataRow[] results2 = intr_t_Configuration_Defaults_dt.Select("PK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results2)
                    {
                        intr_t_Configuration_Defaults_dt2.ImportRow(dr);
                    }
                    OracleCommand intr_t_Configuration_Defaults_dt2_SC = new OracleCommand();
                    intr_t_Configuration_Defaults_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Configuration_Defaults_dt2_SC.Connection = oCon;
                    intr_t_Configuration_Defaults_dt2_SC.CommandText = "SELECT * FROM intr_t_Configuration_Defaults_dt2";
                    OracleDataAdapter intr_t_Configuration_Defaults_dt2_SC_s = new OracleDataAdapter(intr_t_Configuration_Defaults_dt2_SC);
                    XmlWriter intr_t_Configuration_Defaults_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Configuration_Defaults.xml");
                    intr_t_Configuration_Defaults_XML_WRITER.WriteStartDocument();
                    intr_t_Configuration_Defaults_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Configuration_Defaults_dt2.Rows)
                    {
                        intr_t_Configuration_Defaults_XML_WRITER.WriteStartElement("intr_t_Configuration_Defaults");
                        intr_t_Configuration_Defaults_XML_WRITER.WriteElementString("PK_POSITION", row["PK_POSITION"].ToString());
                        intr_t_Configuration_Defaults_XML_WRITER.WriteElementString("FK_FIELD_NAME", row["FK_FIELD_NAME"].ToString());
                        intr_t_Configuration_Defaults_XML_WRITER.WriteElementString("RMS_FIELD_SIZE", row["RMS_FIELD_SIZE"].ToString());
                        intr_t_Configuration_Defaults_XML_WRITER.WriteElementString("ATT_SEND_SIZE", row["ATT_SEND_SIZE"].ToString());
                        intr_t_Configuration_Defaults_XML_WRITER.WriteElementString("TABLE_NAME", row["TABLE_NAME"].ToString());
                        intr_t_Configuration_Defaults_XML_WRITER.WriteElementString("PK_PROCESS_ID", row["PK_PROCESS_ID"].ToString());
                        intr_t_Configuration_Defaults_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Configuration_Defaults_XML_WRITER.WriteEndElement();
                    intr_t_Configuration_Defaults_XML_WRITER.WriteEndDocument();
                    intr_t_Configuration_Defaults_XML_WRITER.Close();

                    OracleCommand sTmp3 = new OracleCommand();
                    sTmp3.CommandType = CommandType.Text;
                    sTmp3.Connection = oCon;
                    sTmp3.CommandText = "SELECT * FROM intr_t_Data_Dictionary WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    OracleDataAdapter intr_t_Data_Dictionary_da_s = new OracleDataAdapter(sTmp3);
                    DataSet intr_t_Data_Dictionary_ds_s = new DataSet();
                    intr_t_Data_Dictionary_da_s.Fill(intr_t_Data_Dictionary_ds_s, "intr_t_Data_Dictionary");
                    DataTable intr_t_Data_Dictionary_dt = intr_t_Data_Dictionary_ds_s.Tables[0];
                    DataTable intr_t_Data_Dictionary_dt2 = intr_t_Data_Dictionary_dt.Clone();
                    DataRow[] results3 = intr_t_Data_Dictionary_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results3)
                    {
                        intr_t_Data_Dictionary_dt2.ImportRow(dr);
                    }
                    OracleCommand intr_t_Data_Dictionary_dt2_SC = new OracleCommand();
                    intr_t_Data_Dictionary_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Data_Dictionary_dt2_SC.Connection = oCon;
                    intr_t_Data_Dictionary_dt2_SC.CommandText = "SELECT * FROM intr_t_Data_Dictionary_dt2";
                    OracleDataAdapter intr_t_Data_Dictionary_dt2_SC_s = new OracleDataAdapter(intr_t_Data_Dictionary_dt2_SC);
                    XmlWriter intr_t_Data_Dictionary_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Data_Dictionary.xml");
                    intr_t_Data_Dictionary_XML_WRITER.WriteStartDocument();
                    intr_t_Data_Dictionary_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Data_Dictionary_dt2.Rows)
                    {
                        intr_t_Data_Dictionary_XML_WRITER.WriteStartElement("intr_t_Data_Dictionary");
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("CK_DICTIONARY_ITEM_NAME", row["CK_DICTIONARY_ITEM_NAME"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("CK_SOURCE_TYPE", row["CK_SOURCE_TYPE"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("FTP_SERVER", row["FTP_SERVER"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("FTP_REMOTE_FILE_NAME", row["FTP_REMOTE_FILE_NAME"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("FTP_USER", row["FTP_USER"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("FTP_PASSWORD", row["FTP_PASSWORD"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("TEXT_LOCAL_FILE_PATH", row["TEXT_LOCAL_FILE_PATH"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("TEXT_FILE_FORMAT", row["TEXT_FILE_FORMAT"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("TEXT_ARCHIVE_FILE_PATH", row["TEXT_ARCHIVE_FILE_PATH"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("TEXT_DELIMITER", row["TEXT_DELIMITER"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("TEXT_DATE_DELIMITER", row["TEXT_DATE_DELIMITER"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("TEXT_DATE_FORMAT", row["TEXT_DATE_FORMAT"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("REMOTE_DB_TYPE", row["REMOTE_DB_TYPE"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("AUTHENTICATE_AGAINST", row["AUTHENTICATE_AGAINST"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("REMOTE_SERVER_USERNAME", row["REMOTE_SERVER_USERNAME"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("REMOTE_SERVER_PASSWORD", row["REMOTE_SERVER_PASSWORD"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("REMOTE_DATABASE_NAME", row["REMOTE_DATABASE_NAME"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("REMOTE_TABLE_NAME", row["REMOTE_TABLE_NAME"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteElementString("RECORD_TERMINATOR", row["RECORD_TERMINATOR"].ToString());
                        intr_t_Data_Dictionary_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Data_Dictionary_XML_WRITER.WriteEndElement();
                    intr_t_Data_Dictionary_XML_WRITER.WriteEndDocument();
                    intr_t_Data_Dictionary_XML_WRITER.Close();

                    OracleCommand sTmp4 = new OracleCommand();
                    sTmp4.CommandType = CommandType.Text;
                    sTmp4.Connection = oCon;
                    sTmp4.CommandText = "SELECT * FROM intr_t_Exclusions WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    OracleDataAdapter intr_t_Exclusions_da_s = new OracleDataAdapter(sTmp4);
                    DataSet intr_t_Exclusions_ds_s = new DataSet();
                    intr_t_Exclusions_da_s.Fill(intr_t_Exclusions_ds_s, "intr_t_Exclusions");
                    DataTable intr_t_Exclusions_dt = intr_t_Exclusions_ds_s.Tables[0];
                    DataTable intr_t_Exclusions_dt2 = intr_t_Exclusions_dt.Clone();
                    DataRow[] results4 = intr_t_Exclusions_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results4)
                    {
                        intr_t_Exclusions_dt2.ImportRow(dr);
                    }
                    OracleCommand intr_t_Exclusions_dt2_SC = new OracleCommand();
                    intr_t_Exclusions_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Exclusions_dt2_SC.Connection = oCon;
                    intr_t_Exclusions_dt2_SC.CommandText = "SELECT * FROM intr_t_Exclusions_dt2";
                    OracleDataAdapter intr_t_Exclusions_dt2_SC_s = new OracleDataAdapter(intr_t_Exclusions_dt2_SC);
                    XmlWriter intr_t_Exclusions_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Exclusions.xml");
                    intr_t_Exclusions_XML_WRITER.WriteStartDocument();
                    intr_t_Exclusions_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Exclusions_dt2.Rows)
                    {
                        intr_t_Exclusions_XML_WRITER.WriteStartElement("intr_t_Exclusions");
                        intr_t_Exclusions_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Exclusions_XML_WRITER.WriteElementString("CK_EXCLUSION_TYPE", row["CK_EXCLUSION_TYPE"].ToString());
                        intr_t_Exclusions_XML_WRITER.WriteElementString("CK_EXCLUSION_VALUE", row["CK_EXCLUSION_VALUE"].ToString());
                        intr_t_Exclusions_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Exclusions_XML_WRITER.WriteEndElement();
                    intr_t_Exclusions_XML_WRITER.WriteEndDocument();
                    intr_t_Exclusions_XML_WRITER.Close();

                    OracleCommand sTmp5 = new OracleCommand();
                    sTmp5.CommandType = CommandType.Text;
                    sTmp5.Connection = oCon;
                    sTmp5.CommandText = "SELECT * FROM intr_t_Field_Map WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    OracleDataAdapter intr_t_Field_Map_da_s = new OracleDataAdapter(sTmp5);
                    DataSet intr_t_Field_Map_ds_s = new DataSet();
                    intr_t_Field_Map_da_s.Fill(intr_t_Field_Map_ds_s, "intr_t_Field_Map");
                    DataTable intr_t_Field_Map_dt = intr_t_Field_Map_ds_s.Tables[0];
                    DataTable intr_t_Field_Map_dt2 = intr_t_Field_Map_dt.Clone();
                    DataRow[] results5 = intr_t_Field_Map_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results5)
                    {
                        intr_t_Field_Map_dt2.ImportRow(dr);
                    }
                    OracleCommand intr_t_Field_Map_dt2_SC = new OracleCommand();
                    intr_t_Field_Map_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Field_Map_dt2_SC.Connection = oCon;
                    intr_t_Field_Map_dt2_SC.CommandText = "SELECT * FROM intr_t_Field_Map_dt2";
                    OracleDataAdapter intr_t_Field_Map_dt2_SC_s = new OracleDataAdapter(intr_t_Field_Map_dt2_SC);
                    XmlWriter intr_t_Field_Map_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Field_Map.xml");
                    intr_t_Field_Map_XML_WRITER.WriteStartDocument();
                    intr_t_Field_Map_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Field_Map_dt2.Rows)
                    {
                        intr_t_Field_Map_XML_WRITER.WriteStartElement("intr_t_Field_Map");
                        intr_t_Field_Map_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("CK_SOURCE_TYPE", row["CK_SOURCE_TYPE"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("CK_DICTIONARY_ITEM_NAME", row["CK_DICTIONARY_ITEM_NAME"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("CK_PROCESS_FIELD_NAME", row["CK_PROCESS_FIELD_NAME"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("PROCESS_FIELD_TYPE", row["PROCESS_FIELD_TYPE"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("PROCESS_FIELD_START_POS", row["PROCESS_FIELD_START_POS"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("PROCESS_FIELD_SIZE", row["PROCESS_FIELD_SIZE"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("PROCESS_FIELD_SPFORMAT", row["PROCESS_FIELD_SPFORMAT"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("EXTERNAL_FIELD_NAME", row["EXTERNAL_FIELD_NAME"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("EXTERNAL_FIELD_TYPE", row["EXTERNAL_FIELD_TYPE"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("EXTERNAL_FIELD_SIZE", row["EXTERNAL_FIELD_SIZE"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("PROCESS_FIELD_JUSTifY", row["PROCESS_FIELD_JUSTifY"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteElementString("PROCESS_FIELD_FILL_CHAR", row["PROCESS_FIELD_FILL_CHAR"].ToString());
                        intr_t_Field_Map_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Field_Map_XML_WRITER.WriteEndElement();
                    intr_t_Field_Map_XML_WRITER.WriteEndDocument();
                    intr_t_Field_Map_XML_WRITER.Close();

                    OracleCommand sTmp6 = new OracleCommand();
                    sTmp6.CommandType = CommandType.Text;
                    sTmp6.Connection = oCon;
                    sTmp6.CommandText = "SELECT * FROM intr_t_Incident_Translator WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    OracleDataAdapter intr_t_Incident_Translator_da_s = new OracleDataAdapter(sTmp6);
                    DataSet intr_t_Incident_Translator_ds_s = new DataSet();
                    intr_t_Incident_Translator_da_s.Fill(intr_t_Incident_Translator_ds_s, "intr_t_Incident_Translator");
                    DataTable intr_t_Incident_Translator_dt = intr_t_Incident_Translator_ds_s.Tables[0];
                    DataTable intr_t_Incident_Translator_dt2 = intr_t_Incident_Translator_dt.Clone();
                    DataRow[] results6 = intr_t_Incident_Translator_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results6)
                    {
                        intr_t_Incident_Translator_dt2.ImportRow(dr);
                    }
                    OracleCommand intr_t_Incident_Translator_dt2_SC = new OracleCommand();
                    intr_t_Incident_Translator_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Incident_Translator_dt2_SC.Connection = oCon;
                    intr_t_Incident_Translator_dt2_SC.CommandText = "SELECT * FROM intr_t_Incident_Translator_dt2";
                    OracleDataAdapter intr_t_Incident_Translator_dt2_SC_s = new OracleDataAdapter(intr_t_Incident_Translator_dt2_SC);
                    XmlWriter intr_t_Incident_Translator_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Incident_Translator.xml");
                    intr_t_Incident_Translator_XML_WRITER.WriteStartDocument();
                    intr_t_Incident_Translator_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Incident_Translator_dt2.Rows)
                    {
                        intr_t_Incident_Translator_XML_WRITER.WriteStartElement("intr_t_Incident_Translator");
                        intr_t_Incident_Translator_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Incident_Translator_XML_WRITER.WriteElementString("CK_IM_EX_FIELD", row["CK_IM_EX_FIELD"].ToString());
                        intr_t_Incident_Translator_XML_WRITER.WriteElementString("FK_INC_TYPE_CODE", row["FK_INC_TYPE_CODE"].ToString());
                        intr_t_Incident_Translator_XML_WRITER.WriteElementString("FK_FLAG_CODE", row["FK_FLAG_CODE"].ToString());
                        intr_t_Incident_Translator_XML_WRITER.WriteElementString("FK_INC_LOCATION_CODE", row["FK_INC_LOCATION_CODE"].ToString());
                        intr_t_Incident_Translator_XML_WRITER.WriteElementString("FK_INC_CLEARY_CODE", row["FK_INC_CLEARY_CODE"].ToString());
                        intr_t_Incident_Translator_XML_WRITER.WriteElementString("FK_INCIDENT_ACTION_ID", row["FK_INCIDENT_ACTION_ID"].ToString());
                        intr_t_Incident_Translator_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Incident_Translator_XML_WRITER.WriteEndElement();
                    intr_t_Incident_Translator_XML_WRITER.WriteEndDocument();
                    intr_t_Incident_Translator_XML_WRITER.Close();

                    OracleCommand sTmp7 = new OracleCommand();
                    sTmp7.CommandType = CommandType.Text;
                    sTmp7.Connection = oCon;
                    sTmp7.CommandText = "SELECT * FROM intr_t_L_U_t_Configurations WHERE pk_Process_ID IN " + PK_PROCESS_ID_STRING;
                    OracleDataAdapter intr_t_L_U_t_Configurations_da_s = new OracleDataAdapter(sTmp7);
                    DataSet intr_t_L_U_t_Configurations_ds_s = new DataSet();
                    intr_t_L_U_t_Configurations_da_s.Fill(intr_t_L_U_t_Configurations_ds_s, "intr_t_L_U_t_Configurations");
                    DataTable intr_t_L_U_t_Configurations_dt = intr_t_L_U_t_Configurations_ds_s.Tables[0];
                    DataTable intr_t_L_U_t_Configurations_dt2 = intr_t_L_U_t_Configurations_dt.Clone();
                    DataRow[] results7 = intr_t_L_U_t_Configurations_dt.Select("PK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results7)
                    {
                        intr_t_L_U_t_Configurations_dt2.ImportRow(dr);
                    }
                    OracleCommand intr_t_L_U_t_Configurations_dt2_SC = new OracleCommand();
                    intr_t_L_U_t_Configurations_dt2_SC.CommandType = CommandType.Text;
                    intr_t_L_U_t_Configurations_dt2_SC.Connection = oCon;
                    intr_t_L_U_t_Configurations_dt2_SC.CommandText = "SELECT * FROM intr_t_L_U_t_Configurations_dt2";
                    OracleDataAdapter intr_t_L_U_t_Configurations_dt2_SC_s = new OracleDataAdapter(intr_t_L_U_t_Configurations_dt2_SC);
                    XmlWriter intr_t_L_U_t_Configurations_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_L_U_t_Configurations.xml");
                    intr_t_L_U_t_Configurations_XML_WRITER.WriteStartDocument();
                    intr_t_L_U_t_Configurations_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_L_U_t_Configurations_dt2.Rows)
                    {
                        intr_t_L_U_t_Configurations_XML_WRITER.WriteStartElement("intr_t_L_U_t_Configurations");
                        intr_t_L_U_t_Configurations_XML_WRITER.WriteElementString("PK_FIELD_NAME", row["PK_FIELD_NAME"].ToString());
                        intr_t_L_U_t_Configurations_XML_WRITER.WriteElementString("TABLE_NAME", row["TABLE_NAME"].ToString());
                        intr_t_L_U_t_Configurations_XML_WRITER.WriteElementString("RMS_FIELD_SIZE", row["RMS_FIELD_SIZE"].ToString());
                        intr_t_L_U_t_Configurations_XML_WRITER.WriteElementString("Oracle_STATEMENT", row["Oracle_STATEMENT"].ToString());
                        intr_t_L_U_t_Configurations_XML_WRITER.WriteElementString("PK_PROCESS_ID", row["PK_PROCESS_ID"].ToString());
                        intr_t_L_U_t_Configurations_XML_WRITER.WriteEndElement();
                    }
                    intr_t_L_U_t_Configurations_XML_WRITER.WriteEndElement();
                    intr_t_L_U_t_Configurations_XML_WRITER.WriteEndDocument();
                    intr_t_L_U_t_Configurations_XML_WRITER.Close();

                    OracleCommand sTmp8 = new OracleCommand();
                    sTmp8.CommandType = CommandType.Text;
                    sTmp8.Connection = oCon;
                    sTmp8.CommandText = "SELECT * FROM intr_t_Process_Appln_Periods WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    OracleDataAdapter intr_t_Process_Appln_Periods_da_s = new OracleDataAdapter(sTmp8);
                    DataSet intr_t_Process_Appln_Periods_ds_s = new DataSet();
                    intr_t_Process_Appln_Periods_da_s.Fill(intr_t_Process_Appln_Periods_ds_s, "intr_t_Process_Appln_Periods");
                    DataTable intr_t_Process_Appln_Periods_dt = intr_t_Process_Appln_Periods_ds_s.Tables[0];
                    DataTable intr_t_Process_Appln_Periods_dt2 = intr_t_Process_Appln_Periods_dt.Clone();
                    DataRow[] results8 = intr_t_Process_Appln_Periods_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results8)
                    {
                        intr_t_Process_Appln_Periods_dt2.ImportRow(dr);
                    }
                    OracleCommand intr_t_Process_Appln_Periods_dt2_SC = new OracleCommand();
                    intr_t_Process_Appln_Periods_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Process_Appln_Periods_dt2_SC.Connection = oCon;
                    intr_t_Process_Appln_Periods_dt2_SC.CommandText = "SELECT * FROM intr_t_Process_Appln_Periods_dt2";
                    OracleDataAdapter intr_t_Process_Appln_Periods_dt2_SC_s = new OracleDataAdapter(intr_t_Process_Appln_Periods_dt2_SC);
                    XmlWriter intr_t_Process_Appln_Periods_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Process_Appln_Periods.xml");
                    intr_t_Process_Appln_Periods_XML_WRITER.WriteStartDocument();
                    intr_t_Process_Appln_Periods_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Process_Appln_Periods_dt2.Rows)
                    {
                        intr_t_Process_Appln_Periods_XML_WRITER.WriteStartElement("intr_t_Process_Appln_Periods");
                        intr_t_Process_Appln_Periods_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Process_Appln_Periods_XML_WRITER.WriteElementString("CK_SHOW_NAME", row["CK_SHOW_NAME"].ToString());
                        intr_t_Process_Appln_Periods_XML_WRITER.WriteElementString("SHOW_TYPE", row["SHOW_TYPE"].ToString());
                        intr_t_Process_Appln_Periods_XML_WRITER.WriteElementString("REFERENCE_TEXT", row["REFERENCE_TEXT"].ToString());
                        intr_t_Process_Appln_Periods_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Process_Appln_Periods_XML_WRITER.WriteEndElement();
                    intr_t_Process_Appln_Periods_XML_WRITER.WriteEndDocument();
                    intr_t_Process_Appln_Periods_XML_WRITER.Close();

                    OracleCommand sTmp9 = new OracleCommand();
                    sTmp9.CommandType = CommandType.Text;
                    sTmp9.Connection = oCon;
                    sTmp9.CommandText = "SELECT * FROM intr_t_Process_Config_Status WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    OracleDataAdapter intr_t_Process_Config_Status_da_s = new OracleDataAdapter(sTmp9);
                    DataSet intr_t_Process_Config_Status_ds_s = new DataSet();
                    intr_t_Process_Config_Status_da_s.Fill(intr_t_Process_Config_Status_ds_s, "intr_t_Process_Config_Status");
                    DataTable intr_t_Process_Config_Status_dt = intr_t_Process_Config_Status_ds_s.Tables[0];
                    DataTable intr_t_Process_Config_Status_dt2 = intr_t_Process_Config_Status_dt.Clone();
                    DataRow[] results9 = intr_t_Process_Config_Status_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results9)
                    {
                        intr_t_Process_Config_Status_dt2.ImportRow(dr);
                    }
                    OracleCommand intr_t_Process_Config_Status_dt2_SC = new OracleCommand();
                    intr_t_Process_Config_Status_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Process_Config_Status_dt2_SC.Connection = oCon;
                    intr_t_Process_Config_Status_dt2_SC.CommandText = "SELECT * FROM intr_t_Process_Config_Status_dt2";
                    OracleDataAdapter intr_t_Process_Config_Status_dt2_SC_s = new OracleDataAdapter(intr_t_Process_Config_Status_dt2_SC);
                    XmlWriter intr_t_Process_Config_Status_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Process_Config_Status.xml");
                    intr_t_Process_Config_Status_XML_WRITER.WriteStartDocument();
                    intr_t_Process_Config_Status_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Process_Config_Status_dt2.Rows)
                    {
                        intr_t_Process_Config_Status_XML_WRITER.WriteStartElement("intr_t_Process_Config_Status");
                        intr_t_Process_Config_Status_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Process_Config_Status_XML_WRITER.WriteElementString("CK_PROCESS_CONFIG_ITEM", row["CK_PROCESS_CONFIG_ITEM"].ToString());
                        intr_t_Process_Config_Status_XML_WRITER.WriteElementString("CONFIG_ITEM_STATUS", row["CONFIG_ITEM_STATUS"].ToString());
                        intr_t_Process_Config_Status_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Process_Config_Status_XML_WRITER.WriteEndElement();
                    intr_t_Process_Config_Status_XML_WRITER.WriteEndDocument();
                    intr_t_Process_Config_Status_XML_WRITER.Close();

                    OracleCommand sTmp10 = new OracleCommand();
                    sTmp10.CommandType = CommandType.Text;
                    sTmp10.Connection = oCon;
                    sTmp10.CommandText = "SELECT * FROM intr_t_Process_CustProc WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    OracleDataAdapter intr_t_Process_CustProc_da_s = new OracleDataAdapter(sTmp10);
                    DataSet intr_t_Process_CustProc_ds_s = new DataSet();
                    intr_t_Process_CustProc_da_s.Fill(intr_t_Process_CustProc_ds_s, "intr_t_Process_CustProc");
                    DataTable intr_t_Process_CustProc_dt = intr_t_Process_CustProc_ds_s.Tables[0];
                    DataTable intr_t_Process_CustProc_dt2 = intr_t_Process_CustProc_dt.Clone();
                    DataRow[] results10 = intr_t_Process_CustProc_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results10)
                    {
                        intr_t_Process_CustProc_dt2.ImportRow(dr);
                    }
                    OracleCommand intr_t_Process_CustProc_dt2_SC = new OracleCommand();
                    intr_t_Process_CustProc_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Process_CustProc_dt2_SC.Connection = oCon;
                    intr_t_Process_CustProc_dt2_SC.CommandText = "SELECT * FROM intr_t_Process_CustProc_dt2";
                    OracleDataAdapter intr_t_Process_CustProc_dt2_SC_s = new OracleDataAdapter(intr_t_Process_CustProc_dt2_SC);
                    XmlWriter intr_t_Process_CustProc_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Process_CustProc.xml");
                    intr_t_Process_CustProc_XML_WRITER.WriteStartDocument();
                    intr_t_Process_CustProc_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Process_CustProc_dt2.Rows)
                    {
                        intr_t_Process_CustProc_XML_WRITER.WriteStartElement("intr_t_Process_CustProc");
                        intr_t_Process_CustProc_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Process_CustProc_XML_WRITER.WriteElementString("CK_CUST_PROC_DESCRIPTION", row["CK_CUST_PROC_DESCRIPTION"].ToString());
                        intr_t_Process_CustProc_XML_WRITER.WriteElementString("CK_INSERTION", row["CK_INSERTION"].ToString());
                        intr_t_Process_CustProc_XML_WRITER.WriteElementString("CK_ORDER", row["CK_ORDER"].ToString());
                        intr_t_Process_CustProc_XML_WRITER.WriteElementString("SQL_STATEMENT_PART1", row["SQL_STATEMENT_PART1"].ToString());
                        intr_t_Process_CustProc_XML_WRITER.WriteElementString("SQL_STATEMENT_PART2", row["SQL_STATEMENT_PART2"].ToString());
                        intr_t_Process_CustProc_XML_WRITER.WriteElementString("SQL_STATEMENT_PART3", row["SQL_STATEMENT_PART3"].ToString());
                        intr_t_Process_CustProc_XML_WRITER.WriteElementString("SQL_STATEMENT_PART4", row["SQL_STATEMENT_PART4"].ToString());
                        intr_t_Process_CustProc_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Process_CustProc_XML_WRITER.WriteEndElement();
                    intr_t_Process_CustProc_XML_WRITER.WriteEndDocument();
                    intr_t_Process_CustProc_XML_WRITER.Close();

                    OracleCommand sTmp11 = new OracleCommand();
                    sTmp11.CommandType = CommandType.Text;
                    sTmp11.Connection = oCon;
                    sTmp11.CommandText = "SELECT * FROM intr_t_Process_Parameters WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    OracleDataAdapter intr_t_Process_Parameters_da_s = new OracleDataAdapter(sTmp11);
                    DataSet intr_t_Process_Parameters_ds_s = new DataSet();
                    intr_t_Process_Parameters_da_s.Fill(intr_t_Process_Parameters_ds_s, "intr_t_Process_Parameters");
                    DataTable intr_t_Process_Parameters_dt = intr_t_Process_Parameters_ds_s.Tables[0];
                    DataTable intr_t_Process_Parameters_dt2 = intr_t_Process_Parameters_dt.Clone();
                    DataRow[] results11 = intr_t_Process_Parameters_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results11)
                    {
                        intr_t_Process_Parameters_dt2.ImportRow(dr);
                    }
                    OracleCommand intr_t_Process_Parameters_dt2_SC = new OracleCommand();
                    intr_t_Process_Parameters_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Process_Parameters_dt2_SC.Connection = oCon;
                    intr_t_Process_Parameters_dt2_SC.CommandText = "SELECT * FROM intr_t_Process_Parameters_dt2";
                    OracleDataAdapter intr_t_Process_Parameters_dt2_SC_s = new OracleDataAdapter(intr_t_Process_Parameters_dt2_SC);
                    XmlWriter intr_t_Process_Parameters_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Process_Parameters.xml");
                    intr_t_Process_Parameters_XML_WRITER.WriteStartDocument();
                    intr_t_Process_Parameters_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Process_Parameters_dt2.Rows)
                    {
                        intr_t_Process_Parameters_XML_WRITER.WriteStartElement("intr_t_Process_Parameters");
                        intr_t_Process_Parameters_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Process_Parameters_XML_WRITER.WriteElementString("CK_PARAMETER_NAME", row["CK_PARAMETER_NAME"].ToString());
                        intr_t_Process_Parameters_XML_WRITER.WriteElementString("PARAMETER_VALUE", row["PARAMETER_VALUE"].ToString());
                        intr_t_Process_Parameters_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Process_Parameters_XML_WRITER.WriteEndElement();
                    intr_t_Process_Parameters_XML_WRITER.WriteEndDocument();
                    intr_t_Process_Parameters_XML_WRITER.Close();

                    OracleCommand sTmp12 = new OracleCommand();
                    sTmp12.CommandType = CommandType.Text;
                    sTmp12.Connection = oCon;
                    sTmp12.CommandText = "SELECT * FROM intr_t_Process_Plan_Options WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    OracleDataAdapter intr_t_Process_Plan_Options_da_s = new OracleDataAdapter(sTmp12);
                    DataSet intr_t_Process_Plan_Options_ds_s = new DataSet();
                    intr_t_Process_Plan_Options_da_s.Fill(intr_t_Process_Plan_Options_ds_s, "intr_t_Process_Plan_Options");
                    DataTable intr_t_Process_Plan_Options_dt = intr_t_Process_Plan_Options_ds_s.Tables[0];
                    DataTable intr_t_Process_Plan_Options_dt2 = intr_t_Process_Plan_Options_dt.Clone();
                    DataRow[] results12 = intr_t_Process_Plan_Options_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results12)
                    {
                        intr_t_Process_Plan_Options_dt2.ImportRow(dr);
                    }
                    OracleCommand intr_t_Process_Plan_Options_dt2_SC = new OracleCommand();
                    intr_t_Process_Plan_Options_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Process_Plan_Options_dt2_SC.Connection = oCon;
                    intr_t_Process_Plan_Options_dt2_SC.CommandText = "SELECT * FROM intr_t_Process_Plan_Options_dt2";
                    OracleDataAdapter intr_t_Process_Plan_Options_dt2_SC_s = new OracleDataAdapter(intr_t_Process_Plan_Options_dt2_SC);
                    XmlWriter intr_t_Process_Plan_Options_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Process_Plan_Options.xml");
                    intr_t_Process_Plan_Options_XML_WRITER.WriteStartDocument();
                    intr_t_Process_Plan_Options_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Process_Plan_Options_dt2.Rows)
                    {
                        intr_t_Process_Plan_Options_XML_WRITER.WriteStartElement("intr_t_Process_Plan_Options");
                        intr_t_Process_Plan_Options_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Process_Plan_Options_XML_WRITER.WriteElementString("CK_PLAN_TYPE", row["CK_PLAN_TYPE"].ToString());
                        intr_t_Process_Plan_Options_XML_WRITER.WriteElementString("PLAN_TYPE_RESET", row["PLAN_TYPE_RESET"].ToString());
                        intr_t_Process_Plan_Options_XML_WRITER.WriteElementString("PLAN_TYPE_RESET_AMOUNT", row["PLAN_TYPE_RESET_AMOUNT"].ToString());
                        intr_t_Process_Plan_Options_XML_WRITER.WriteElementString("PLAN_TYPE_FORCE_AC", row["PLAN_TYPE_FORCE_AC"].ToString());
                        intr_t_Process_Plan_Options_XML_WRITER.WriteElementString("CK_PROCESS_FIELD_ORDER", row["CK_PROCESS_FIELD_ORDER"].ToString());
                        intr_t_Process_Plan_Options_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Process_Plan_Options_XML_WRITER.WriteEndElement();
                    intr_t_Process_Plan_Options_XML_WRITER.WriteEndDocument();
                    intr_t_Process_Plan_Options_XML_WRITER.Close();

                    OracleCommand sTmp13 = new OracleCommand();
                    sTmp13.CommandType = CommandType.Text;
                    sTmp13.Connection = oCon;
                    sTmp13.CommandText = "SELECT * FROM intr_t_Process_Schedule WHERE pk_Process_ID IN " + PK_PROCESS_ID_STRING;
                    OracleDataAdapter intr_t_Process_Schedule_da_s = new OracleDataAdapter(sTmp13);
                    DataSet intr_t_Process_Schedule_ds_s = new DataSet();
                    intr_t_Process_Schedule_da_s.Fill(intr_t_Process_Schedule_ds_s, "intr_t_Process_Schedule");
                    DataTable intr_t_Process_Schedule_dt = intr_t_Process_Schedule_ds_s.Tables[0];
                    DataTable intr_t_Process_Schedule_dt2 = intr_t_Process_Schedule_dt.Clone();
                    DataRow[] results13 = intr_t_Process_Schedule_dt.Select("PK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results13)
                    {
                        intr_t_Process_Schedule_dt2.ImportRow(dr);
                    }
                    OracleCommand intr_t_Process_Schedule_dt2_SC = new OracleCommand();
                    intr_t_Process_Schedule_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Process_Schedule_dt2_SC.Connection = oCon;
                    intr_t_Process_Schedule_dt2_SC.CommandText = "SELECT * FROM intr_t_Process_Schedule_dt2";
                    OracleDataAdapter intr_t_Process_Schedule_dt2_SC_s = new OracleDataAdapter(intr_t_Process_Schedule_dt2_SC);
                    XmlWriter intr_t_Process_Schedule_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Process_Schedule.xml");
                    intr_t_Process_Schedule_XML_WRITER.WriteStartDocument();
                    intr_t_Process_Schedule_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Process_Schedule_dt2.Rows)
                    {
                        intr_t_Process_Schedule_XML_WRITER.WriteStartElement("intr_t_Process_Schedule");
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("PK_PROCESS_ID", row["PK_PROCESS_ID"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("SCHEDULED", row["SCHEDULED"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("START_DATE", row["START_DATE"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("END_DATE", row["END_DATE"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("RUN_TIME", row["RUN_TIME"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("NEXT_RUN", row["NEXT_RUN"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("LAST_RUN", row["LAST_RUN"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("SCHEDULE_TYPE", row["SCHEDULE_TYPE"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("RUN_SUNDAY", row["RUN_SUNDAY"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("RUN_MONDAY", row["RUN_MONDAY"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("RUN_TUESDAY", row["RUN_TUESDAY"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("RUN_WEDNESDAY", row["RUN_WEDNESDAY"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("RUN_THURSDAY", row["RUN_THURSDAY"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("RUN_FRIDAY", row["RUN_FRIDAY"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("RUN_SATURDAY", row["RUN_SATURDAY"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("CALENDAR_DAY", row["CALENDAR_DAY"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("INTERVAL", row["INTERVAL"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("NO_OF_INTERVALS", row["NO_OF_INTERVALS"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("SCHED_USERNAME", row["SCHED_USERNAME"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteElementString("SCHED_PASSWORD", row["SCHED_PASSWORD"].ToString());
                        intr_t_Process_Schedule_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Process_Schedule_XML_WRITER.WriteEndElement();
                    intr_t_Process_Schedule_XML_WRITER.WriteEndDocument();
                    intr_t_Process_Schedule_XML_WRITER.Close();

                    OracleCommand sTmp14 = new OracleCommand();
                    sTmp14.CommandType = CommandType.Text;
                    sTmp14.Connection = oCon;
                    sTmp14.CommandText = "SELECT * FROM intr_t_Process_SpecificTxTypes WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    OracleDataAdapter intr_t_Process_SpecificTxTypes_da_s = new OracleDataAdapter(sTmp14);
                    DataSet intr_t_Process_SpecificTxTypes_ds_s = new DataSet();
                    intr_t_Process_SpecificTxTypes_da_s.Fill(intr_t_Process_SpecificTxTypes_ds_s, "intr_t_Process_SpecificTxTypes");
                    DataTable intr_t_Process_SpecificTxTypes_dt = intr_t_Process_SpecificTxTypes_ds_s.Tables[0];
                    DataTable intr_t_Process_SpecificTxTypes_dt2 = intr_t_Process_SpecificTxTypes_dt.Clone();
                    DataRow[] results14 = intr_t_Process_SpecificTxTypes_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results14)
                    {
                        intr_t_Process_SpecificTxTypes_dt2.ImportRow(dr);
                    }
                    OracleCommand intr_t_Process_SpecificTxTypes_dt2_SC = new OracleCommand();
                    intr_t_Process_SpecificTxTypes_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Process_SpecificTxTypes_dt2_SC.Connection = oCon;
                    intr_t_Process_SpecificTxTypes_dt2_SC.CommandText = "SELECT * FROM intr_t_Process_SpecificTxTypes_dt2";
                    OracleDataAdapter intr_t_Process_SpecificTxTypes_dt2_SC_s = new OracleDataAdapter(intr_t_Process_SpecificTxTypes_dt2_SC);
                    XmlWriter intr_t_Process_SpecificTxTypes_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Process_SpecificTxTypes.xml");
                    intr_t_Process_SpecificTxTypes_XML_WRITER.WriteStartDocument();
                    intr_t_Process_SpecificTxTypes_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Process_SpecificTxTypes_dt2.Rows)
                    {
                        intr_t_Process_SpecificTxTypes_XML_WRITER.WriteStartElement("intr_t_Process_SpecificTxTypes");
                        intr_t_Process_SpecificTxTypes_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Process_SpecificTxTypes_XML_WRITER.WriteElementString("CK_TXTYPE", row["CK_TXTYPE"].ToString());
                        intr_t_Process_SpecificTxTypes_XML_WRITER.WriteElementString("CLOSES_ACCOUNT", row["CLOSES_ACCOUNT"].ToString());
                        intr_t_Process_SpecificTxTypes_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Process_SpecificTxTypes_XML_WRITER.WriteEndElement();
                    intr_t_Process_SpecificTxTypes_XML_WRITER.WriteEndDocument();
                    intr_t_Process_SpecificTxTypes_XML_WRITER.Close();

                    OracleCommand sTmp15 = new OracleCommand();
                    sTmp15.CommandType = CommandType.Text;
                    sTmp15.Connection = oCon;
                    sTmp15.CommandText = "SELECT * FROM intr_t_Process_Terms_ForUpload WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    OracleDataAdapter intr_t_Process_Terms_ForUpload_da_s = new OracleDataAdapter(sTmp15);
                    DataSet intr_t_Process_Terms_ForUpload_ds_s = new DataSet();
                    intr_t_Process_Terms_ForUpload_da_s.Fill(intr_t_Process_Terms_ForUpload_ds_s, "intr_t_Process_Terms_ForUpload");
                    DataTable intr_t_Process_Terms_ForUpload_dt = intr_t_Process_Terms_ForUpload_ds_s.Tables[0];
                    DataTable intr_t_Process_Terms_ForUpload_dt2 = intr_t_Process_Terms_ForUpload_dt.Clone();
                    DataRow[] results15 = intr_t_Process_Terms_ForUpload_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results15)
                    {
                        intr_t_Process_Terms_ForUpload_dt2.ImportRow(dr);
                    }
                    OracleCommand intr_t_Process_Terms_ForUpload_dt2_SC = new OracleCommand();
                    intr_t_Process_Terms_ForUpload_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Process_Terms_ForUpload_dt2_SC.Connection = oCon;
                    intr_t_Process_Terms_ForUpload_dt2_SC.CommandText = "SELECT * FROM intr_t_Process_Terms_ForUpload_dt2";
                    OracleDataAdapter intr_t_Process_Terms_ForUpload_dt2_SC_s = new OracleDataAdapter(intr_t_Process_Terms_ForUpload_dt2_SC);
                    XmlWriter intr_t_Process_Terms_ForUpload_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Process_Terms_ForUpload.xml");
                    intr_t_Process_Terms_ForUpload_XML_WRITER.WriteStartDocument();
                    intr_t_Process_Terms_ForUpload_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Process_Terms_ForUpload_dt2.Rows)
                    {
                        intr_t_Process_Terms_ForUpload_XML_WRITER.WriteStartElement("intr_t_Process_Terms_ForUpload");
                        intr_t_Process_Terms_ForUpload_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Process_Terms_ForUpload_XML_WRITER.WriteElementString("CK_TERM_ID", row["CK_TERM_ID"].ToString());
                        intr_t_Process_Terms_ForUpload_XML_WRITER.WriteElementString("UPLOAD", row["UPLOAD"].ToString());
                        intr_t_Process_Terms_ForUpload_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Process_Terms_ForUpload_XML_WRITER.WriteEndElement();
                    intr_t_Process_Terms_ForUpload_XML_WRITER.WriteEndDocument();
                    intr_t_Process_Terms_ForUpload_XML_WRITER.Close();

                    OracleCommand sTmp16 = new OracleCommand();
                    sTmp16.CommandType = CommandType.Text;
                    sTmp16.Connection = oCon;
                    sTmp16.CommandText = "SELECT * FROM intr_t_Process_Translator WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING;
                    OracleDataAdapter intr_t_Process_Translator_da_s = new OracleDataAdapter(sTmp16);
                    DataSet intr_t_Process_Translator_ds_s = new DataSet();
                    intr_t_Process_Translator_da_s.Fill(intr_t_Process_Translator_ds_s, "intr_t_Process_Translator");
                    DataTable intr_t_Process_Translator_dt = intr_t_Process_Translator_ds_s.Tables[0];
                    DataTable intr_t_Process_Translator_dt2 = intr_t_Process_Translator_dt.Clone();
                    DataRow[] results16 = intr_t_Process_Translator_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results16)
                    {
                        intr_t_Process_Translator_dt2.ImportRow(dr);
                    }
                    OracleCommand intr_t_Process_Translator_dt2_SC = new OracleCommand();
                    intr_t_Process_Translator_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Process_Translator_dt2_SC.Connection = oCon;
                    intr_t_Process_Translator_dt2_SC.CommandText = "SELECT * FROM intr_t_Process_Translator_dt2";
                    OracleDataAdapter intr_t_Process_Translator_dt2_SC_s = new OracleDataAdapter(intr_t_Process_Translator_dt2_SC);
                    XmlWriter intr_t_Process_Translator_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Process_Translator.xml");
                    intr_t_Process_Translator_XML_WRITER.WriteStartDocument();
                    intr_t_Process_Translator_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Process_Translator_dt2.Rows)
                    {
                        intr_t_Process_Translator_XML_WRITER.WriteStartElement("intr_t_Process_Translator");
                        intr_t_Process_Translator_XML_WRITER.WriteElementString("CK_PROCESS_ID", row["CK_PROCESS_ID"].ToString());
                        intr_t_Process_Translator_XML_WRITER.WriteElementString("CK_PROCESS_FIELD_NAME", row["CK_PROCESS_FIELD_NAME"].ToString());
                        intr_t_Process_Translator_XML_WRITER.WriteElementString("CK_PROCESS_FIELD_VALUE", row["CK_PROCESS_FIELD_VALUE"].ToString());
                        intr_t_Process_Translator_XML_WRITER.WriteElementString("TRANSLATED_VALUE", row["TRANSLATED_VALUE"].ToString());
                        intr_t_Process_Translator_XML_WRITER.WriteElementString("CK_PROCESS_FIELD_ORDER", row["CK_PROCESS_FIELD_ORDER"].ToString());
                        intr_t_Process_Translator_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Process_Translator_XML_WRITER.WriteEndElement();
                    intr_t_Process_Translator_XML_WRITER.WriteEndDocument();
                    intr_t_Process_Translator_XML_WRITER.Close();

                    OracleCommand sTmp17 = new OracleCommand();
                    sTmp17.CommandType = CommandType.Text;
                    sTmp17.Connection = oCon;
                    sTmp17.CommandText = "SELECT * FROM intr_t_Status WHERE fk_Process_ID IN " + PK_PROCESS_ID_STRING;
                    OracleDataAdapter intr_t_Status_da_s = new OracleDataAdapter(sTmp17);
                    DataSet intr_t_Status_ds_s = new DataSet();
                    intr_t_Status_da_s.Fill(intr_t_Status_ds_s, "intr_t_Status");
                    DataTable intr_t_Status_dt = intr_t_Status_ds_s.Tables[0];
                    DataTable intr_t_Status_dt2 = intr_t_Status_dt.Clone();
                    DataRow[] results17 = intr_t_Status_dt.Select("FK_PROCESS_ID IN " + PK_PROCESS_ID_STRING);
                    foreach (DataRow dr in results17)
                    {
                        intr_t_Status_dt2.ImportRow(dr);
                    }
                    OracleCommand intr_t_Status_dt2_SC = new OracleCommand();
                    intr_t_Status_dt2_SC.CommandType = CommandType.Text;
                    intr_t_Status_dt2_SC.Connection = oCon;
                    intr_t_Status_dt2_SC.CommandText = "SELECT * FROM intr_t_Status_dt2";
                    OracleDataAdapter intr_t_Status_dt2_SC_s = new OracleDataAdapter(intr_t_Status_dt2_SC);
                    XmlWriter intr_t_Status_XML_WRITER = XmlWriter.Create(BK_XML_LOC_TEXT2 + "\\intr_t_Status.xml");
                    intr_t_Status_XML_WRITER.WriteStartDocument();
                    intr_t_Status_XML_WRITER.WriteStartElement("NewDataSet");
                    foreach (DataRow row in intr_t_Status_dt2.Rows)
                    {
                        intr_t_Status_XML_WRITER.WriteStartElement("intr_t_Status");
                        intr_t_Status_XML_WRITER.WriteElementString("PK_OPERATION_ID", row["PK_OPERATION_ID"].ToString());
                        intr_t_Status_XML_WRITER.WriteElementString("FK_PROCESS_ID", row["FK_PROCESS_ID"].ToString());
                        intr_t_Status_XML_WRITER.WriteElementString("START_DATE", row["START_DATE"].ToString());
                        intr_t_Status_XML_WRITER.WriteElementString("COMPLETION_DATE", row["COMPLETION_DATE"].ToString());
                        intr_t_Status_XML_WRITER.WriteElementString("SUCCESS", row["SUCCESS"].ToString());
                        intr_t_Status_XML_WRITER.WriteElementString("No_Processed", row["No_Processed"].ToString());
                        intr_t_Status_XML_WRITER.WriteElementString("No_New", row["No_New"].ToString());
                        intr_t_Status_XML_WRITER.WriteElementString("No_Changes", row["No_Changes"].ToString());
                        intr_t_Status_XML_WRITER.WriteElementString("No_Non_Critical_Errors", row["No_Non_Critical_Errors"].ToString());
                        intr_t_Status_XML_WRITER.WriteElementString("STATUS_MESSAGE", row["STATUS_MESSAGE"].ToString());
                        intr_t_Status_XML_WRITER.WriteEndElement();
                    }
                    intr_t_Status_XML_WRITER.WriteEndElement();
                    intr_t_Status_XML_WRITER.WriteEndDocument();
                    intr_t_Status_XML_WRITER.Close();
                
                    MessageBox.Show("Backup completed successfully to " + BK_XML_LOC_TEXT2 + ". Please zip the files at your earliest convenince.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Not Connected - " + ex.Message);

                }
            }

        }

        private void RESTORE_BUTTON_Click(object sender, EventArgs e)
        {
            RESTORE_ITEMS_COMPLETED_TXTBOX.Text = "";
            string BK_XML_LOC_TEXT2 = BK_XML_LOC_TEXT.Text.Replace("\\", "\\\\");
            string intr_t_processes_XML_Path = BK_XML_LOC_TEXT2 + "\\intr_t_Processes.xml";
            string intr_t_Configuration_Defaults_XML_Path = BK_XML_LOC_TEXT2 + "\\intr_t_Configuration_Defaults.xml";
            string intr_t_Data_Dictionary_XML_Path = BK_XML_LOC_TEXT2 + "\\intr_t_Data_Dictionary.xml";
            string intr_t_Exclusions_XML_Path = BK_XML_LOC_TEXT2 + "\\intr_t_Exclusions.xml";
            string intr_t_Field_Map_XML_Path = BK_XML_LOC_TEXT2 + "\\intr_t_Field_Map.xml";
            string intr_t_Incident_Translator_XML_Path = BK_XML_LOC_TEXT2 + "\\intr_t_Incident_Translator.xml";
            string intr_t_L_U_t_Configurations_XML_Path = BK_XML_LOC_TEXT2 + "\\intr_t_L_U_t_Configurations.xml";
            string intr_t_Process_Appln_Periods_XML_Path = BK_XML_LOC_TEXT2 + "\\intr_t_Process_Appln_Periods.xml";
            string intr_t_Process_Config_Status_XML_Path = BK_XML_LOC_TEXT2 + "\\intr_t_Process_Config_Status.xml";
            string intr_t_Process_CustProc_XML_Path = BK_XML_LOC_TEXT2 + "\\intr_t_Process_CustProc.xml";
            string intr_t_Process_Parameters_XML_Path = BK_XML_LOC_TEXT2 + "\\intr_t_Process_Parameters.xml";
            string intr_t_Process_Plan_Options_XML_Path = BK_XML_LOC_TEXT2 + "\\intr_t_Process_Plan_Options.xml";
            string intr_t_Process_Schedule_XML_Path = BK_XML_LOC_TEXT2 + "\\intr_t_Process_Schedule.xml";
            string intr_t_Process_SpecificTxTypes_XML_Path = BK_XML_LOC_TEXT2 + "\\intr_t_Process_SpecificTxTypes.xml";
            string intr_t_Process_Terms_ForUpload_XML_Path = BK_XML_LOC_TEXT2 + "\\intr_t_Process_Terms_ForUpload.xml";
            string intr_t_Process_Translator_XML_Path = BK_XML_LOC_TEXT2 + "\\intr_t_Process_Translator.xml";
            string intr_t_Status_XML_Path = BK_XML_LOC_TEXT2 + "\\intr_t_Status.xml";
            StringBuilder RESTORE_PROCESS_TEXT = new StringBuilder();
            RESTORE_PROCESS_TEXT.Append("Processes completed and messages!");
            RESTORE_PROCESS_TEXT.AppendLine("");
            if (File.Exists(intr_t_processes_XML_Path))
                try
                {
                    DataSet Restore_XML_Data = new DataSet("Restore_intr_t_Processes");
                    Restore_XML_Data.ReadXml(intr_t_processes_XML_Path, XmlReadMode.ReadSchema);

                    StringBuilder PK_PROCESS_ID_STRING_RS = new StringBuilder();
                    PK_PROCESS_ID_STRING_RS.Append("(");
                    foreach (DataGridViewCell cell in this.dataGridView2.SelectedCells)
                    {
                        if (cell.ColumnIndex == 0)
                        {
                            PK_PROCESS_ID_STRING_RS.Append(cell.Value.ToString() + ",");
                        }
                    }
                    PK_PROCESS_ID_STRING_RS.Remove((PK_PROCESS_ID_STRING_RS.Length - 1), 1);
                    PK_PROCESS_ID_STRING_RS.Append(")");
                    RESTORE_PROCESS_TEXT.AppendLine("The list of IDs to be restored up are: " + PK_PROCESS_ID_STRING_RS.ToString());
                    RESTORE_PROCESS_TEXT.AppendLine("");
                    if (DB_TYPE_COMBO.Text.Equals("SQL"))
                    {
                        String CONNECTION_STRING =
                                      "Server=" + SERVER_CONNECTION_TEXT.Text + ";" +
                                      "DataBase=INTRCONFIG;" +
                                      "Uid=" + USERNAME_TEXT.Text + ";" +
                                      "Pwd=" + PASSWORD_TEXT.Text + ";";


                        try
                        {
                            SqlConnection sCon = new SqlConnection(CONNECTION_STRING);
                            sCon.Open();
                            SqlCommand R_Drop_Constraints = new SqlCommand();
                            RESTORE_PROCESS_TEXT.AppendLine("Disabling Constraints........................");
                            RESTORE_PROCESS_TEXT.AppendLine("");
                            R_Drop_Constraints.CommandType = CommandType.Text;
                            R_Drop_Constraints.Connection = sCon;
                            R_Drop_Constraints.CommandText = "Alter TABLE intr_t_Exclusions NOCHECK CONSTRAINT ALL";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE intr_t_Field_Map NOCHECK CONSTRAINT ALL";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE intr_t_Data_Dictionary NOCHECK CONSTRAINT ALL";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE intr_t_Configuration_Defaults NOCHECK CONSTRAINT ALL";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE intr_t_Incident_Translator NOCHECK CONSTRAINT ALL";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE intr_t_L_U_t_Configurations NOCHECK CONSTRAINT ALL";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE intr_t_Process_Appln_Periods NOCHECK CONSTRAINT ALL";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE intr_t_Process_Config_Status NOCHECK CONSTRAINT ALL";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE intr_t_Process_CustProc NOCHECK CONSTRAINT ALL";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE intr_t_Process_Parameters NOCHECK CONSTRAINT ALL";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE intr_t_Process_Plan_Options NOCHECK CONSTRAINT ALL";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE intr_t_Process_Schedule NOCHECK CONSTRAINT ALL";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE intr_t_Process_SpecificTxTypes NOCHECK CONSTRAINT ALL";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE intr_t_Process_Terms_ForUpload NOCHECK CONSTRAINT ALL";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE intr_t_Process_Translator NOCHECK CONSTRAINT ALL";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE intr_t_Status NOCHECK CONSTRAINT ALL";
                            R_Drop_Constraints.ExecuteNonQuery();
                            RESTORE_PROCESS_TEXT.AppendLine("Constraints Disabled...............................");
                            if (File.Exists(intr_t_processes_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Processes_s = new DataSet("R_intr_t_Processes_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_processes_XML_Path);
                                    R_intr_t_Processes_s.ReadXml(reader);
                                    if (R_intr_t_Processes_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_processes_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Processes_dt = R_intr_t_Processes_s.Tables[0];
                                        DataTable R_intr_t_Processes_dt2 = R_intr_t_Processes_dt.Clone();
                                        DataRow[] results = R_intr_t_Processes_dt.Select("PK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);

                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Processes_dt2.ImportRow(dr);
                                        }
                                        SqlCommand R_intr_t_Processes_dt2_SC = new SqlCommand();
                                        R_intr_t_Processes_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Processes_dt2_SC.Connection = sCon;
                                        R_intr_t_Processes_dt2_SC.CommandText = "SET IDENTITY_INSERT intr_t_Processes ON";
                                        R_intr_t_Processes_dt2_SC.ExecuteNonQuery();
                                        R_intr_t_Processes_dt2_SC.CommandText = "DELETE intr_t_Processes WHERE pk_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Processes_dt2_SC.ExecuteNonQuery();
                                        SqlDataAdapter R_intr_t_Processes_dt2_SC_s = new SqlDataAdapter(R_intr_t_Processes_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Processes_dt2.Rows)
                                        {

                                            int Active = 0;
                                            if (row["Active"].ToString() == "false")
                                            {
                                                Active = 0;
                                            }
                                            else if (row["Active"].ToString() == "")
                                            {
                                                Active = 0;
                                            }
                                            else if (row["Active"].ToString() == null)
                                            {
                                                Active = 0;
                                            }
                                            else
                                            {
                                                Active = 1;
                                            }

                                            string Current_user = "null";
                                            if (row["Current_user"].ToString() == null)
                                            {
                                                Current_user = "null";
                                            }
                                            else if (row["CURRENT_USER"].ToString() == "")
                                            {
                                                Current_user = "null";
                                            }
                                            else if (row["CURRENT_USER"].ToString() == " ")
                                            {
                                                Current_user = "null";
                                            }
                                            else
                                            {
                                                Current_user = row["Current_user"].ToString();
                                            }
                                            int fk_Process_Type_ID = Convert.ToInt32(row["fk_Process_Type_ID"]);
                                            int Next_Execution_Step = Convert.ToInt32(row["Next_Execution_Step"]);
                                            StringBuilder R_intr_t_Processes_dt2_Insert = new StringBuilder();
											string Process_Name = row["Process_Name"].ToString().Replace("'","''");
											string Status = row["Status"].ToString().Replace("'","''");
											string Data_Set = row["Data_Set"].ToString().Replace("'","''");
                                            R_intr_t_Processes_dt2_Insert.Append("INSERT INTO intr_t_Processes " +
                                            "(pk_Process_ID,Process_Name,[Status]," +
                                            "Next_Execution_Step,Data_Set,fk_Process_Type_ID," +
                                            "[Current_user],Active) " +
                                            "VALUES ('" + row["pk_Process_ID"].ToString() + "','" +
                                            Process_Name + "','" +
                                            Status + "'," +
                                            Next_Execution_Step + ",'" +
                                            Data_Set + "'," +
                                            fk_Process_Type_ID + "," +
                                            Current_user + "," +
                                            Active + ")");
                                            SqlCommand R_intr_t_Processes_dt2_Insert_Com = new SqlCommand();
                                            R_intr_t_Processes_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Processes_dt2_Insert_Com.Connection = sCon;
                                            R_intr_t_Processes_dt2_Insert_Com.CommandText = R_intr_t_Processes_dt2_Insert.ToString();
                                            R_intr_t_Processes_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        R_intr_t_Processes_dt2_SC.CommandText = "SET IDENTITY_INSERT intr_t_Processes OFF";
                                        R_intr_t_Processes_dt2_SC.ExecuteNonQuery();
                                        RESTORE_PROCESS_TEXT.AppendLine("IDENTITY_INSERT has been turned back off...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                        RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESSES data has been inserted....");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESSES - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Configuration_Defaults_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Configuration_Defaults_s = new DataSet("R_intr_t_Configuration_Defaults_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Configuration_Defaults_XML_Path);
                                    R_intr_t_Configuration_Defaults_s.ReadXml(reader);
                                    if (R_intr_t_Configuration_Defaults_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Configuration_Defaults_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Configuration_Defaults_dt = R_intr_t_Configuration_Defaults_s.Tables[0];
                                        DataTable R_intr_t_Configuration_Defaults_dt2 = R_intr_t_Configuration_Defaults_dt.Clone();
                                        DataRow[] results = R_intr_t_Configuration_Defaults_dt.Select("PK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Configuration_Defaults_dt2.ImportRow(dr);
                                        }
                                        SqlCommand R_intr_t_Configuration_Defaults_dt2_SC = new SqlCommand();
                                        R_intr_t_Configuration_Defaults_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Configuration_Defaults_dt2_SC.Connection = sCon;
                                        R_intr_t_Configuration_Defaults_dt2_SC.CommandText = "DELETE intr_t_Configuration_Defaults WHERE pk_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Configuration_Defaults_dt2_SC.ExecuteNonQuery();
                                        SqlDataAdapter R_intr_t_Configuration_Defaults_dt2_SC_s = new SqlDataAdapter(R_intr_t_Configuration_Defaults_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Configuration_Defaults_dt2.Rows)
                                        {
                                            string PK_Position_Str = row["pk_Position"].ToString();
                                            int pk_Position = 0;
                                            if (PK_Position_Str == "")
                                            {
                                                pk_Position = 0;
                                            }
                                            else if (PK_Position_Str == null)
                                            {
                                                pk_Position = 0;
                                            }
                                            else
                                            {
                                                pk_Position = Convert.ToInt32(PK_Position_Str);
                                            }

                                            string RMS_Field_Size_Str = row["RMS_Field_Size"].ToString();
                                            int RMS_Field_Size = 0;
                                            if (RMS_Field_Size_Str == "")
                                            {
                                                RMS_Field_Size = 0;
                                            }
                                            else if (RMS_Field_Size_Str == null)
                                            {
                                                RMS_Field_Size = 0;
                                            }
                                            else
                                            {
                                                RMS_Field_Size = Convert.ToInt32(RMS_Field_Size_Str);
                                            }

                                            string ATT_Send_Size_Str = row["ATT_Send_Size"].ToString();
                                            int ATT_Send_Size = 0;
                                            if (ATT_Send_Size_Str == "")
                                            {
                                                ATT_Send_Size = 0;
                                            }
                                            else if (ATT_Send_Size_Str == null)
                                            {
                                                ATT_Send_Size = 0;
                                            }
                                            else
                                            {
                                                ATT_Send_Size = Convert.ToInt32(ATT_Send_Size_Str);
                                            }

                                            string Pk_process_id_Str = row["Pk_process_id"].ToString();
                                            int Pk_process_id = 0;
                                            if (Pk_process_id_Str == "")
                                            {
                                                Pk_process_id = 0;
                                            }
                                            else if (Pk_process_id_Str == null)
                                            {
                                                Pk_process_id = 0;
                                            }
                                            else
                                            {
                                                Pk_process_id = Convert.ToInt32(Pk_process_id_Str);
                                            }
											string fk_Field_Name = row["fk_Field_Name"].ToString().Replace("'","''");
											string Table_Name = row["Table_Name"].ToString().Replace("'","''");
                                            StringBuilder R_intr_t_Configuration_Defaults_dt2_Insert = new StringBuilder();
                                            R_intr_t_Configuration_Defaults_dt2_Insert.Append("INSERT INTO intr_t_Configuration_Defaults " +
                                            "(pk_Position,fk_Field_Name,RMS_Field_Size," +
                                            "ATT_Send_Size,Table_Name,Pk_process_id) " +
                                            "VALUES (" + pk_Position + ",'" +
                                            fk_Field_Name + "'," +
                                            RMS_Field_Size + "," +
                                            ATT_Send_Size + ",'" +
                                            Table_Name + "'," +
                                            Pk_process_id + ")");
                                            SqlCommand R_intr_t_Configuration_Defaults_dt2_Insert_Com = new SqlCommand();
                                            R_intr_t_Configuration_Defaults_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Configuration_Defaults_dt2_Insert_Com.Connection = sCon;
                                            R_intr_t_Configuration_Defaults_dt2_Insert_Com.CommandText = R_intr_t_Configuration_Defaults_dt2_Insert.ToString();
                                            R_intr_t_Configuration_Defaults_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Configuration_Defaults data has been inserted.....");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }

                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_CONFIGURATION_DEFAULTS - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Data_Dictionary_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Data_Dictionary_s = new DataSet("R_intr_t_Data_Dictionary_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Data_Dictionary_XML_Path);
                                    R_intr_t_Data_Dictionary_s.ReadXml(reader);
                                    if (R_intr_t_Data_Dictionary_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Data_Dictionary_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Data_Dictionary_dt = R_intr_t_Data_Dictionary_s.Tables[0];
                                        DataTable R_intr_t_Data_Dictionary_dt2 = R_intr_t_Data_Dictionary_dt.Clone();
                                        DataRow[] results = R_intr_t_Data_Dictionary_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Data_Dictionary_dt2.ImportRow(dr);
                                        }
                                        SqlCommand R_intr_t_Data_Dictionary_dt2_SC = new SqlCommand();
                                        R_intr_t_Data_Dictionary_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Data_Dictionary_dt2_SC.Connection = sCon;
                                        R_intr_t_Data_Dictionary_dt2_SC.CommandText = "DELETE intr_t_Data_Dictionary WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Data_Dictionary_dt2_SC.ExecuteNonQuery();
                                        SqlDataAdapter R_intr_t_Data_Dictionary_dt2_SC_s = new SqlDataAdapter(R_intr_t_Data_Dictionary_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Data_Dictionary_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Data_Dictionary_dt2_Insert = new StringBuilder();
											string ck_Dictionary_Item_Name = row["ck_Dictionary_Item_Name"].ToString().Replace("'","''");
											string ck_Source_Type = row["ck_Source_Type"].ToString().Replace("'","''");
											string FTP_Server = row["FTP_Server"].ToString().Replace("'","''");
											string FTP_Remote_File_Name = row["FTP_Remote_File_Name"].ToString().Replace("'","''");
											string FTP_User = row["FTP_User"].ToString().Replace("'","''");
											string FTP_PASSWORD = row["FTP_PASSWORD"].ToString().Replace("'","''");
											string Text_Local_File_path = row["Text_Local_File_path"].ToString().Replace("'","''");
											string Text_File_format = row["Text_File_format"].ToString().Replace("'","''");
											string Text_Archive_File_path = row["Text_Archive_File_path"].ToString().Replace("'","''");
											string Text_Delimiter = row["Text_Delimiter"].ToString().Replace("'","''");
											string Text_Date_Delimiter = row["Text_Date_Delimiter"].ToString().Replace("'","''");
											string Text_Date_Format = row["Text_Date_Format"].ToString().Replace("'","''");
											string REMOTE_DB_TYPE = row["REMOTE_DB_TYPE"].ToString().Replace("'","''");
											string Authenticate_Against = row["Authenticate_Against"].ToString().Replace("'","''");
											string Remote_Server_Username = row["Remote_Server_Username"].ToString().Replace("'","''");
											string Remote_Server_Password = row["Remote_Server_Password"].ToString().Replace("'","''");
											string Remote_Database_Name = row["Remote_Table_Name"].ToString().Replace("'","''");
											string Remote_Table_Name = row["ck_Dictionary_Item_Name"].ToString().Replace("'","''");
											string record_terminator = row["record_terminator"].ToString().Replace("'","''");
                                            R_intr_t_Data_Dictionary_dt2_Insert.Append("INSERT INTO intr_t_Data_Dictionary " +
                                            "(ck_Process_ID,ck_Dictionary_Item_Name,ck_Source_Type,FTP_Server," +
                                            "FTP_Remote_File_Name,FTP_User,FTP_PASSWORD,Text_Local_File_path,Text_File_format," +
                                            "Text_Archive_File_path,Text_Delimiter,Text_Date_Delimiter,Text_Date_Format,Remote_DB_Type," +
                                            "Authenticate_Against,Remote_Server_Username,Remote_Server_Password,Remote_Database_Name," +
                                            "Remote_Table_Name,record_terminator) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_Dictionary_Item_Name + "','" +
                                            ck_Source_Type + "','" +
                                            FTP_Server + "','" +
                                            FTP_Remote_File_Name + "','" +
                                            FTP_User + "','" +
                                            FTP_PASSWORD + "','" +
                                            Text_Local_File_path + "','" +
                                            Text_File_format + "','" +
                                            Text_Archive_File_path + "','" +
                                            Text_Delimiter + "','" +
                                            Text_Date_Delimiter + "','" +
                                            Text_Date_Format + "','" +
                                            REMOTE_DB_TYPE + "','" +
                                            Authenticate_Against + "','" +
                                            Remote_Server_Username + "','" +
                                            Remote_Server_Password + "','" +
                                            Remote_Database_Name + "','" +
                                            Remote_Table_Name + "','" +
                                            record_terminator + "')");
                                            SqlCommand R_intr_t_Data_Dictionary_dt2_Insert_Com = new SqlCommand();
                                            R_intr_t_Data_Dictionary_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Data_Dictionary_dt2_Insert_Com.Connection = sCon;
                                            R_intr_t_Data_Dictionary_dt2_Insert_Com.CommandText = R_intr_t_Data_Dictionary_dt2_Insert.ToString();
                                            R_intr_t_Data_Dictionary_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Data_Dictionary data has been inserted..........");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_DATA_DICTIONARY - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Exclusions_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Exclusions_s = new DataSet("R_intr_t_Exclusions_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Exclusions_XML_Path);
                                    R_intr_t_Exclusions_s.ReadXml(reader);
                                    if (R_intr_t_Exclusions_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Exclusions_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Exclusions_dt = R_intr_t_Exclusions_s.Tables[0];
                                        DataTable R_intr_t_Exclusions_dt2 = R_intr_t_Exclusions_dt.Clone();
                                        DataRow[] results = R_intr_t_Exclusions_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Exclusions_dt2.ImportRow(dr);
                                        }
                                        SqlCommand R_intr_t_Exclusions_dt2_SC = new SqlCommand();
                                        R_intr_t_Exclusions_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Exclusions_dt2_SC.Connection = sCon;
                                        R_intr_t_Exclusions_dt2_SC.CommandText = "DELETE intr_t_Exclusions WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Exclusions_dt2_SC.ExecuteNonQuery();
                                        SqlDataAdapter R_intr_t_Exclusions_dt2_SC_s = new SqlDataAdapter(R_intr_t_Exclusions_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Exclusions_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Exclusions_dt2_Insert = new StringBuilder();
                                            string ck_Exclusion_Type = row["ck_Exclusion_Type"].ToString().Replace("'","''");
											string ck_Exclusion_Value = row["ck_Exclusion_Value"].ToString().Replace("'","''");
                                            R_intr_t_Exclusions_dt2_Insert.Append("INSERT INTO intr_t_Exclusions " +
                                            "(ck_Process_ID,ck_Exclusion_Type,ck_Exclusion_Value) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_Exclusion_Type + "','" +
                                            ck_Exclusion_Value + "')");
                                            SqlCommand R_intr_t_Exclusions_dt2_Insert_Com = new SqlCommand();
                                            R_intr_t_Exclusions_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Exclusions_dt2_Insert_Com.Connection = sCon;
                                            R_intr_t_Exclusions_dt2_Insert_Com.CommandText = R_intr_t_Exclusions_dt2_Insert.ToString();
                                            R_intr_t_Exclusions_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Exclusions data has been inserted...............");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_EXCLUSIONS - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Field_Map_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Field_Map_s = new DataSet("R_intr_t_Field_Map_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Field_Map_XML_Path);
                                    R_intr_t_Field_Map_s.ReadXml(reader);
                                    if (R_intr_t_Field_Map_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Field_Map_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Field_Map_dt = R_intr_t_Field_Map_s.Tables[0];
                                        DataTable R_intr_t_Field_Map_dt2 = R_intr_t_Field_Map_dt.Clone();
                                        DataRow[] results = R_intr_t_Field_Map_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Field_Map_dt2.ImportRow(dr);
                                        }
                                        SqlCommand R_intr_t_Field_Map_dt2_SC = new SqlCommand();
                                        R_intr_t_Field_Map_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Field_Map_dt2_SC.Connection = sCon;
                                        R_intr_t_Field_Map_dt2_SC.CommandText = "DELETE intr_t_Field_Map WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Field_Map_dt2_SC.ExecuteNonQuery();
                                        SqlDataAdapter R_intr_t_Field_Map_dt2_SC_s = new SqlDataAdapter(R_intr_t_Field_Map_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Field_Map_dt2.Rows)
                                        {
                                            string External_Field_Name = row["External_Field_Name"].ToString();
                                            if (External_Field_Name != "")
                                            {
                                                
                                            }
                                            else
                                            {
                                                External_Field_Name = "NA";
                                            }
                                            string process_field_fill_char = row["process_field_fill_char"].ToString();
                                            if (process_field_fill_char == null)
                                            {
                                                process_field_fill_char = " ";
                                            }
                                            else if (process_field_fill_char == " ")
                                            {
                                                process_field_fill_char = " ";
                                            }
                                            else if (process_field_fill_char == "")
                                            {
                                                process_field_fill_char = " ";
                                            }

                                            string External_Field_Size = "";
                                            if (row["External_Field_Size"].ToString() == null)
                                            {
                                                External_Field_Size = "null";
                                            }
                                            else if (row["External_Field_Size"].ToString() == " ")
                                            {
                                                External_Field_Size = "null";
                                            }
                                            else if (row["External_Field_Size"].ToString() == "")
                                            {
                                                External_Field_Size = "null";
                                            }
                                            else
                                            {
                                                External_Field_Size = row["External_Field_Size"].ToString();
                                            }
                                            StringBuilder R_intr_t_Field_Map_dt2_Insert = new StringBuilder();
											string ck_source_Type = row["ck_source_Type"].ToString().Replace("'", "''");
											string ck_Dictionary_Item_Name = row["ck_Dictionary_Item_Name"].ToString().Replace("'", "''");
											string ck_process_Field_Name = row["ck_process_Field_Name"].ToString().Replace("'", "''");
											string process_Field_Type = row["process_Field_Type"].ToString().Replace("'", "''");
											string process_Field_SpFormat = row["process_Field_SpFormat"].ToString().Replace("'", "''");
											External_Field_Name = External_Field_Name.Replace("'", "''");
											string External_Field_Type = row["External_Field_Type"].ToString().Replace("'", "''");
											string process_field_justify = row["process_field_justify"].ToString().Replace("'", "''");
											process_field_fill_char = process_field_fill_char.Replace("'", "''");
                                            R_intr_t_Field_Map_dt2_Insert.Append("INSERT INTO intr_t_Field_Map " +
                                            "(ck_Process_ID,ck_source_Type,ck_Dictionary_Item_Name," +
                                            "ck_process_Field_Name,process_Field_Type,process_Field_start_pos," +
                                            "process_Field_Size,process_Field_SpFormat,External_Field_Name," +
                                            "External_Field_Type,External_Field_Size,process_field_justify," +
                                            "process_field_fill_char) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_source_Type + "','" +
                                            ck_Dictionary_Item_Name + "','" +
                                            ck_process_Field_Name + "','" +
                                            process_Field_Type + "'," +
                                            row["process_Field_start_pos"].ToString() + "," +
                                            row["process_Field_Size"].ToString() + ",'" +
                                            process_Field_SpFormat + "','" +
                                            External_Field_Name + "','" +
                                            External_Field_Type + "'," +
                                            External_Field_Size + ",'" +
                                            process_field_justify + "','" +
                                            process_field_fill_char + "')");

                                            SqlCommand R_intr_t_Field_Map_dt2_Insert_Com = new SqlCommand();
                                            R_intr_t_Field_Map_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Field_Map_dt2_Insert_Com.Connection = sCon;
                                            R_intr_t_Field_Map_dt2_Insert_Com.CommandText = R_intr_t_Field_Map_dt2_Insert.ToString();
                                            R_intr_t_Field_Map_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Field_Map data has been inserted..................");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_FIELD_MAP - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Incident_Translator_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Incident_Translator_s = new DataSet("R_intr_t_Incident_Translator_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Incident_Translator_XML_Path);
                                    R_intr_t_Incident_Translator_s.ReadXml(reader);
                                    if (R_intr_t_Incident_Translator_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Incident_Translator_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Incident_Translator_dt = R_intr_t_Incident_Translator_s.Tables[0];
                                        DataTable R_intr_t_Incident_Translator_dt2 = R_intr_t_Incident_Translator_dt.Clone();
                                        DataRow[] results = R_intr_t_Incident_Translator_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Incident_Translator_dt2.ImportRow(dr);
                                        }
                                        SqlCommand R_intr_t_Incident_Translator_dt2_SC = new SqlCommand();
                                        R_intr_t_Incident_Translator_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Incident_Translator_dt2_SC.Connection = sCon;
                                        R_intr_t_Incident_Translator_dt2_SC.CommandText = "DELETE intr_t_Incident_Translator WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Incident_Translator_dt2_SC.ExecuteNonQuery();
                                        SqlDataAdapter R_intr_t_Incident_Translator_dt2_SC_s = new SqlDataAdapter(R_intr_t_Incident_Translator_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Incident_Translator_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Incident_Translator_dt2_Insert = new StringBuilder();
											string ck_Im_Ex_Field = row["ck_Im_Ex_Field"].ToString().Replace("'", "''");
											string fk_Inc_Type_Code = row["fk_Inc_Type_Code"].ToString().Replace("'", "''");
											string fk_Flag_Code = row["fk_Flag_Code"].ToString().Replace("'", "''");
											string fk_Inc_Location_Code = row["fk_Inc_Location_Code"].ToString().Replace("'", "''");
											string fk_Inc_Cleary_Code = row["fk_Inc_Cleary_Code"].ToString().Replace("'", "''");
                                            R_intr_t_Incident_Translator_dt2_Insert.Append("INSERT INTO intr_t_Incident_Translator " +
                                            "(ck_Process_ID,ck_Im_Ex_Field,fk_Inc_Type_Code,fk_Flag_Code," +
                                            "fk_Inc_Location_Code,fk_Inc_Cleary_Code,FK_INCIDENT_ACTION_ID) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_Im_Ex_Field + "','" +
                                            fk_Inc_Type_Code + "','" +
                                            fk_Flag_Code + "','" +
                                            fk_Inc_Location_Code + "','" +
                                            fk_Inc_Cleary_Code + "','" +
                                            row["FK_INCIDENT_ACTION_ID"].ToString() + "')");
                                            SqlCommand R_intr_t_Incident_Translator_dt2_Insert_Com = new SqlCommand();
                                            R_intr_t_Incident_Translator_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Incident_Translator_dt2_Insert_Com.Connection = sCon;
                                            R_intr_t_Incident_Translator_dt2_Insert_Com.CommandText = R_intr_t_Incident_Translator_dt2_Insert.ToString();
                                            R_intr_t_Incident_Translator_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Incident_Translator data has been inserted................");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_INCIDENT_TRANSLATOR - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_L_U_t_Configurations_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_L_U_t_Configurations_s = new DataSet("R_intr_t_L_U_t_Configurations_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_L_U_t_Configurations_XML_Path);
                                    R_intr_t_L_U_t_Configurations_s.ReadXml(reader);
                                    if (R_intr_t_L_U_t_Configurations_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_L_U_t_Configurations_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_L_U_t_Configurations_dt = R_intr_t_L_U_t_Configurations_s.Tables[0];
                                        DataTable R_intr_t_L_U_t_Configurations_dt2 = R_intr_t_L_U_t_Configurations_dt.Clone();
                                        DataRow[] results = R_intr_t_L_U_t_Configurations_dt.Select("PK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_L_U_t_Configurations_dt2.ImportRow(dr);
                                        }
                                        SqlCommand R_intr_t_L_U_t_Configurations_dt2_SC = new SqlCommand();
                                        R_intr_t_L_U_t_Configurations_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_L_U_t_Configurations_dt2_SC.Connection = sCon;
                                        R_intr_t_L_U_t_Configurations_dt2_SC.CommandText = "DELETE intr_t_L_U_t_Configurations WHERE pk_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_L_U_t_Configurations_dt2_SC.ExecuteNonQuery();
                                        SqlDataAdapter R_intr_t_L_U_t_Configurations_dt2_SC_s = new SqlDataAdapter(R_intr_t_L_U_t_Configurations_dt2_SC);

                                        foreach (DataRow row in R_intr_t_L_U_t_Configurations_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_L_U_t_Configurations_dt2_Insert = new StringBuilder();
											string pk_Field_Name = row["pk_Field_Name"].ToString().Replace("'", "''");
											string Table_Name = row["Table_Name"].ToString().Replace("'", "''");
                                            R_intr_t_L_U_t_Configurations_dt2_Insert.Append("INSERT INTO intr_t_L_U_t_Configurations " +
                                            "(pk_Field_Name,Table_Name,RMS_Field_Size," +
                                            "SQL_Statement,Pk_Process_id) " +
                                            "VALUES ('" + pk_Field_Name + "','" +
                                            Table_Name + "'," +
                                            row["RMS_Field_Size"].ToString() + ",'" +
                                            row["SQL_Statement"].ToString() + "'," +
                                            row["Pk_Process_id"].ToString() + ")");
                                            SqlCommand R_intr_t_L_U_t_Configurations_dt2_Insert_Com = new SqlCommand();
                                            R_intr_t_L_U_t_Configurations_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_L_U_t_Configurations_dt2_Insert_Com.Connection = sCon;
                                            R_intr_t_L_U_t_Configurations_dt2_Insert_Com.CommandText = R_intr_t_L_U_t_Configurations_dt2_Insert.ToString();
                                            R_intr_t_L_U_t_Configurations_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_L_U_t_Configurations data has been inserted...........");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_L_U_T_CONFIGURATIONS - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Process_Appln_Periods_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Process_Appln_Periods_s = new DataSet("R_intr_t_Process_Appln_Periods_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Process_Appln_Periods_XML_Path);
                                    R_intr_t_Process_Appln_Periods_s.ReadXml(reader);
                                    if (R_intr_t_Process_Appln_Periods_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Process_Appln_Periods_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Process_Appln_Periods_dt = R_intr_t_Process_Appln_Periods_s.Tables[0];
                                        DataTable R_intr_t_Process_Appln_Periods_dt2 = R_intr_t_Process_Appln_Periods_dt.Clone();
                                        DataRow[] results = R_intr_t_Process_Appln_Periods_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Process_Appln_Periods_dt2.ImportRow(dr);
                                        }
                                        SqlCommand R_intr_t_Process_Appln_Periods_dt2_SC = new SqlCommand();
                                        R_intr_t_Process_Appln_Periods_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Process_Appln_Periods_dt2_SC.Connection = sCon;
                                        R_intr_t_Process_Appln_Periods_dt2_SC.CommandText = "DELETE intr_t_Process_Appln_Periods WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Process_Appln_Periods_dt2_SC.ExecuteNonQuery();
                                        SqlDataAdapter R_intr_t_Process_Appln_Periods_dt2_SC_s = new SqlDataAdapter(R_intr_t_Process_Appln_Periods_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Process_Appln_Periods_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Process_Appln_Periods_dt2_Insert = new StringBuilder();
											string ck_Show_Name = row["ck_Show_Name"].ToString().Replace("'", "''");
											string Show_Type = row["Show_Type"].ToString().Replace("'", "''");
											string Reference_Text = row["Reference_Text"].ToString().Replace("'", "''");
                                            R_intr_t_Process_Appln_Periods_dt2_Insert.Append("INSERT INTO intr_t_Process_Appln_Periods " +
                                            "(ck_Process_ID,ck_Show_Name,Show_Type," +
                                            "Reference_Text) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_Show_Name + "','" +
                                            Show_Type + "','" +
                                            Reference_Text + "')");
                                            SqlCommand R_intr_t_Process_Appln_Periods_dt2_Insert_Com = new SqlCommand();
                                            R_intr_t_Process_Appln_Periods_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Process_Appln_Periods_dt2_Insert_Com.Connection = sCon;
                                            R_intr_t_Process_Appln_Periods_dt2_Insert_Com.CommandText = R_intr_t_Process_Appln_Periods_dt2_Insert.ToString();
                                            R_intr_t_Process_Appln_Periods_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Process_Appln_Periods data has been inserted.............");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESS_APPLN_PERIODS - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Process_Config_Status_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Process_Config_Status_s = new DataSet("R_intr_t_Process_Config_Status_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Process_Config_Status_XML_Path);
                                    R_intr_t_Process_Config_Status_s.ReadXml(reader);
                                    if (R_intr_t_Process_Config_Status_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Process_Config_Status_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Process_Config_Status_dt = R_intr_t_Process_Config_Status_s.Tables[0];
                                        DataTable R_intr_t_Process_Config_Status_dt2 = R_intr_t_Process_Config_Status_dt.Clone();
                                        DataRow[] results = R_intr_t_Process_Config_Status_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Process_Config_Status_dt2.ImportRow(dr);
                                        }
                                        SqlCommand R_intr_t_Process_Config_Status_dt2_SC = new SqlCommand();
                                        R_intr_t_Process_Config_Status_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Process_Config_Status_dt2_SC.Connection = sCon;
                                        R_intr_t_Process_Config_Status_dt2_SC.CommandText = "DELETE intr_t_Process_Config_Status WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Process_Config_Status_dt2_SC.ExecuteNonQuery();
                                        SqlDataAdapter R_intr_t_Process_Config_Status_dt2_SC_s = new SqlDataAdapter(R_intr_t_Process_Config_Status_dt2_SC);
                                        foreach (DataRow row in R_intr_t_Process_Config_Status_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Process_Config_Status_dt2_Insert = new StringBuilder();
											string ck_Process_Config_Item = row["ck_Process_Config_Item"].ToString().Replace("'", "''");
                                            R_intr_t_Process_Config_Status_dt2_Insert.Append("INSERT INTO intr_t_Process_Config_Status " +
                                            "(ck_Process_ID,ck_Process_Config_Item,Config_Item_Status) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_Process_Config_Item + "'," +
                                            row["Config_Item_Status"].ToString() + ")");
                                            SqlCommand R_intr_t_Process_Config_Status_dt2_Insert_Com = new SqlCommand();
                                            R_intr_t_Process_Config_Status_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Process_Config_Status_dt2_Insert_Com.Connection = sCon;
                                            R_intr_t_Process_Config_Status_dt2_Insert_Com.CommandText = R_intr_t_Process_Config_Status_dt2_Insert.ToString();
                                            R_intr_t_Process_Config_Status_dt2_Insert_Com.ExecuteNonQuery();

                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Process_Config_Status data has been inserted.............");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESS_CONFIG_STATUS - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Process_CustProc_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Process_CustProc_s = new DataSet("R_intr_t_Process_CustProc_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Process_CustProc_XML_Path);
                                    R_intr_t_Process_CustProc_s.ReadXml(reader);
                                    if (R_intr_t_Process_CustProc_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Process_CustProc_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Process_CustProc_dt = R_intr_t_Process_CustProc_s.Tables[0];
                                        DataTable R_intr_t_Process_CustProc_dt2 = R_intr_t_Process_CustProc_dt.Clone();
                                        DataRow[] results = R_intr_t_Process_CustProc_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Process_CustProc_dt2.ImportRow(dr);
                                        }
                                        SqlCommand R_intr_t_Process_CustProc_dt2_SC = new SqlCommand();
                                        R_intr_t_Process_CustProc_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Process_CustProc_dt2_SC.Connection = sCon;
                                        R_intr_t_Process_CustProc_dt2_SC.CommandText = "DELETE intr_t_Process_CustProc WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Process_CustProc_dt2_SC.ExecuteNonQuery();
                                        SqlDataAdapter R_intr_t_Process_CustProc_dt2_SC_s = new SqlDataAdapter(R_intr_t_Process_CustProc_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Process_CustProc_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Process_CustProc_dt2_Insert = new StringBuilder();
                                            string ck_Cust_Proc_Description = row["ck_Cust_Proc_Description"].ToString().Replace("'", "''");
                                            string SQL_Statement_Part1 = row["SQL_Statement_Part1"].ToString().Replace("'", "''");
                                            string SQL_Statement_Part2 = row["SQL_Statement_Part2"].ToString().Replace("'", "''");
                                            string SQL_Statement_Part3 = row["SQL_Statement_Part3"].ToString().Replace("'", "''");
                                            string SQL_Statement_Part4 = row["SQL_Statement_Part4"].ToString().Replace("'", "''");
											string ck_Insertion = row["ck_Insertion"].ToString().Replace("'", "''");
                                            R_intr_t_Process_CustProc_dt2_Insert.Append("INSERT INTO intr_t_Process_CustProc " +
                                            "(ck_Process_ID,ck_Cust_Proc_Description,ck_Insertion," +
                                            "ck_Order,SQL_Statement_Part1,SQL_Statement_Part2," +
                                            "SQL_Statement_Part3,SQL_Statement_Part4) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_Cust_Proc_Description + "','" +
                                            ck_Insertion + "'," +
                                            row["ck_Order"].ToString() + ",'" +
                                            SQL_Statement_Part1 + "','" +
                                            SQL_Statement_Part2 + "','" +
                                            SQL_Statement_Part3 + "','" +
                                            SQL_Statement_Part4 + "')");
                                            SqlCommand R_intr_t_Process_CustProc_dt2_Insert_Com = new SqlCommand();
                                            R_intr_t_Process_CustProc_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Process_CustProc_dt2_Insert_Com.Connection = sCon;
                                            R_intr_t_Process_CustProc_dt2_Insert_Com.CommandText = R_intr_t_Process_CustProc_dt2_Insert.ToString();
                                            R_intr_t_Process_CustProc_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Process_CustProc data has been inserted...............");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESS_CUSTPROC - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Process_Parameters_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Process_Parameters_s = new DataSet("R_intr_t_Process_Parameters_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Process_Parameters_XML_Path);
                                    R_intr_t_Process_Parameters_s.ReadXml(reader);
                                    if (R_intr_t_Process_Parameters_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Process_Parameters_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Process_Parameters_dt = R_intr_t_Process_Parameters_s.Tables[0];
                                        DataTable R_intr_t_Process_Parameters_dt2 = R_intr_t_Process_Parameters_dt.Clone();
                                        DataRow[] results = R_intr_t_Process_Parameters_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Process_Parameters_dt2.ImportRow(dr);
                                        }
                                        SqlCommand R_intr_t_Process_Parameters_dt2_SC = new SqlCommand();
                                        R_intr_t_Process_Parameters_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Process_Parameters_dt2_SC.Connection = sCon;
                                        R_intr_t_Process_Parameters_dt2_SC.CommandText = "DELETE intr_t_Process_Parameters WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Process_Parameters_dt2_SC.ExecuteNonQuery();
                                        SqlDataAdapter R_intr_t_Process_Parameters_dt2_SC_s = new SqlDataAdapter(R_intr_t_Process_Parameters_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Process_Parameters_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Process_Parameters_dt2_Insert = new StringBuilder();
											string ck_Parameter_Name = row["ck_Parameter_Name"].ToString().Replace("'", "''");
											string Parameter_Value = row["Parameter_Value"].ToString().Replace("'", "''");
                                            R_intr_t_Process_Parameters_dt2_Insert.AppendLine("INSERT INTO intr_t_Process_Parameters " +
                                            "(ck_Process_ID,ck_Parameter_Name,Parameter_Value) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_Parameter_Name + "','" +
                                            Parameter_Value + "')");
                                            R_intr_t_Process_Parameters_dt2_Insert.AppendLine("");
                                            SqlCommand R_intr_t_Process_Parameters_dt2_Insert_Com = new SqlCommand();
                                            R_intr_t_Process_Parameters_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Process_Parameters_dt2_Insert_Com.Connection = sCon;
                                            R_intr_t_Process_Parameters_dt2_Insert_Com.CommandText = R_intr_t_Process_Parameters_dt2_Insert.ToString();
                                            R_intr_t_Process_Parameters_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Process_Parameters data has been inserted..................");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESS_PARAMETERS - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Process_Plan_Options_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Process_Plan_Options_s = new DataSet("R_intr_t_Process_Plan_Options_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Process_Plan_Options_XML_Path);
                                    R_intr_t_Process_Plan_Options_s.ReadXml(reader);
                                    if (R_intr_t_Process_Plan_Options_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Process_Plan_Options_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Process_Plan_Options_dt = R_intr_t_Process_Plan_Options_s.Tables[0];
                                        DataTable R_intr_t_Process_Plan_Options_dt2 = R_intr_t_Process_Plan_Options_dt.Clone();
                                        DataRow[] results = R_intr_t_Process_Plan_Options_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Process_Plan_Options_dt2.ImportRow(dr);
                                        }
                                        SqlCommand R_intr_t_Process_Plan_Options_dt2_SC = new SqlCommand();
                                        R_intr_t_Process_Plan_Options_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Process_Plan_Options_dt2_SC.Connection = sCon;
                                        R_intr_t_Process_Plan_Options_dt2_SC.CommandText = "DELETE intr_t_Process_Plan_Options WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Process_Plan_Options_dt2_SC.ExecuteNonQuery();
                                        SqlDataAdapter R_intr_t_Process_Plan_Options_dt2_SC_s = new SqlDataAdapter(R_intr_t_Process_Plan_Options_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Process_Plan_Options_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Process_Plan_Options_dt2_Insert = new StringBuilder();
											string ck_Plan_Type = row["ck_Plan_Type"].ToString().Replace("'", "''");
											int Plan_Type_Reset = 0;
											if (row["Plan_Type_Reset"].ToString() == "false")
											{
												Plan_Type_Reset = 0;
											}
											else if (row["Plan_Type_Reset"].ToString() == "true")
											{
												Plan_Type_Reset = 1;
											}
											else
											{
												Plan_Type_Reset = 0;
											}
											int Plan_Type_Force_AC = 0;
											if (row["Plan_Type_Force_AC"].ToString() == "false")
											{
												Plan_Type_Force_AC = 0;
											}
											else if (row["Plan_Type_Force_AC"].ToString() == "true")
											{
												Plan_Type_Force_AC = 1;
											}
											else
											{
												Plan_Type_Force_AC = 0;
											}
                                            R_intr_t_Process_Plan_Options_dt2_Insert.Append("INSERT INTO intr_t_Process_Plan_Options " +
                                            "(ck_Process_ID,ck_Plan_Type,Plan_Type_Reset," +
                                            "Plan_Type_Reset_Amount,Plan_Type_Force_AC,ck_Process_Field_Order) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_Plan_Type + "'," +
                                            Plan_Type_Reset + "," +
                                            row["Plan_Type_Reset_Amount"].ToString() + "," +
                                            Plan_Type_Force_AC + "," +
                                            row["ck_Process_Field_Order"].ToString() + ")");
                                            SqlCommand R_intr_t_Process_Plan_Options_dt2_Insert_Com = new SqlCommand();
                                            R_intr_t_Process_Plan_Options_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Process_Plan_Options_dt2_Insert_Com.Connection = sCon;
                                            R_intr_t_Process_Plan_Options_dt2_Insert_Com.CommandText = R_intr_t_Process_Plan_Options_dt2_Insert.ToString();
                                            R_intr_t_Process_Plan_Options_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Process_Plan_Options data has been inserted...............");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESS_PLAN_OPTIONS - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Process_Schedule_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Process_Schedule_s = new DataSet("R_intr_t_Process_Schedule_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Process_Schedule_XML_Path);
                                    R_intr_t_Process_Schedule_s.ReadXml(reader);
                                    if (R_intr_t_Process_Schedule_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Process_Schedule_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    
                                    else
                                    {
                                        DataTable R_intr_t_Process_Schedule_dt = R_intr_t_Process_Schedule_s.Tables[0];
                                        DataTable R_intr_t_Process_Schedule_dt2 = R_intr_t_Process_Schedule_dt.Clone();
                                        DataRow[] results = R_intr_t_Process_Schedule_dt.Select("PK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Process_Schedule_dt2.ImportRow(dr);
                                        }
                                        SqlCommand R_intr_t_Process_Schedule_dt2_SC = new SqlCommand();
                                        R_intr_t_Process_Schedule_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Process_Schedule_dt2_SC.Connection = sCon;
                                        R_intr_t_Process_Schedule_dt2_SC.CommandText = "DELETE intr_t_Process_Schedule WHERE pk_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Process_Schedule_dt2_SC.ExecuteNonQuery();
                                        SqlDataAdapter R_intr_t_Process_Schedule_dt2_SC_s = new SqlDataAdapter(R_intr_t_Process_Schedule_dt2_SC);
                                        string Calendar_Day_Str = "";
                                        string No_Of_Intervals_Str = "";
                                        string pk_Process_ID_Str = "";
                                        int Calendar_Day = 0;
                                        int No_Of_Intervals = 0;
                                        int pk_Process_ID = 0;
                                        int Schedule_Type = 0;
                                        int Scheduled = 0;
                                        foreach (DataRow row in R_intr_t_Process_Schedule_dt2.Rows)
                                        {
                                            Calendar_Day_Str = row["Calendar_Day"].ToString();
                                            No_Of_Intervals_Str = row["No_Of_Intervals"].ToString();
                                            pk_Process_ID_Str = row["pk_Process_ID"].ToString();
                                            StringBuilder R_intr_t_Process_Schedule_dt2_Insert = new StringBuilder();
                                            string Start_Date = row["Start_Date"].ToString();
                                            string End_Date = row["End_Date"].ToString();
                                            string Run_Time = row["Run_Time"].ToString();
                                            string Next_Run = row["Next_Run"].ToString();
                                            string Last_Run = row["Last_Run"].ToString();
                                            string Schedule_Type_string = row["Schedule_Type"].ToString();
                                            Schedule_Type = Convert.ToInt32(Schedule_Type_string);
                                            string Scheduled_string = row["Scheduled"].ToString();
											string Sched_Username = row["Sched_Username"].ToString().Replace("'", "''");
											string Sched_Password = row["Sched_Password"].ToString().Replace("'", "''");
                                            if (Scheduled_string == "false")
                                            {
                                                Scheduled = 0;
                                            }
                                            else if (Scheduled_string == "")
                                            {
                                                Scheduled = 0;
                                            }
                                            else if (Scheduled_string == null)
                                            {
                                                Scheduled = 0;
                                            }
                                            else if (Scheduled_string == "true")
                                            {
                                                Scheduled = 1;
                                            }
                                            string Run_Sunday_Str = row["Run_Sunday"].ToString();
                                            int Run_Sunday = 0;
                                            if (Run_Sunday_Str == "false")
                                            {
                                                Run_Sunday = 0;
                                            }
                                            else if (Run_Sunday_Str == "")
                                            {
                                                Run_Sunday = 0;
                                            }
                                            else if (Run_Sunday_Str == null)
                                            {
                                                Run_Sunday = 0;
                                            }
                                            else if (Run_Sunday_Str == "true")
                                            {
                                                Run_Sunday = 1;
                                            }
                                            string Run_Monday_Str = row["Run_Monday"].ToString();
                                            int Run_Monday = 0;
                                            if (Run_Monday_Str == "false")
                                            {
                                                Run_Monday = 0;
                                            }
                                            else if (Run_Monday_Str == "")
                                            {
                                                Run_Monday = 0;
                                            }
                                            else if (Run_Monday_Str == null)
                                            {
                                                Run_Monday = 0;
                                            }
                                            else if (Run_Monday_Str == "true")
                                            {
                                                Run_Monday = 1;
                                            }
                                            string Run_Tuesday_Str = row["Run_Tuesday"].ToString();
                                            int Run_Tuesday = 0;
                                            if (Run_Tuesday_Str == "false")
                                            {
                                                Run_Tuesday = 0;
                                            }
                                            else if (Run_Tuesday_Str == "")
                                            {
                                                Run_Tuesday = 0;
                                            }
                                            else if (Run_Tuesday_Str == null)
                                            {
                                                Run_Tuesday = 0;
                                            }
                                            else if (Run_Tuesday_Str == "true")
                                            {
                                                Run_Tuesday = 1;
                                            }
                                            string Run_Wednesday_Str = row["Run_Wednesday"].ToString();
                                            int Run_Wednesday = 0;
                                            if (Run_Wednesday_Str == "false")
                                            {
                                                Run_Wednesday = 0;
                                            }
                                            else if (Run_Wednesday_Str == "")
                                            {
                                                Run_Wednesday = 0;
                                            }
                                            else if (Run_Wednesday_Str == null)
                                            {
                                                Run_Wednesday = 0;
                                            }
                                            else if (Run_Wednesday_Str == "true")
                                            {
                                                Run_Wednesday = 1;
                                            }
                                            string Run_Thursday_Str = row["Run_Thursday"].ToString();
                                            int Run_Thursday = 0;
                                            if (Run_Thursday_Str == "false")
                                            {
                                                Run_Thursday = 0;
                                            }
                                            else if (Run_Thursday_Str == "")
                                            {
                                                Run_Thursday = 0;
                                            }
                                            else if (Run_Thursday_Str == null)
                                            {
                                                Run_Thursday = 0;
                                            }
                                            else if (Run_Thursday_Str == "true")
                                            {
                                                Run_Thursday = 1;
                                            }
                                            string Run_Friday_Str = row["Run_Friday"].ToString();
                                            int Run_Friday = 0;
                                            if (Run_Friday_Str == "false")
                                            {
                                                Run_Friday = 0;
                                            }
                                            else if (Run_Friday_Str == "")
                                            {
                                                Run_Friday = 0;
                                            }
                                            else if (Run_Friday_Str == null)
                                            {
                                                Run_Friday = 0;
                                            }
                                            else if (Run_Friday_Str == "true")
                                            {
                                                Run_Friday = 1;
                                            }
                                            string Run_Saturday_Str = row["Run_Saturday"].ToString();
                                            int Run_Saturday = 0;
                                            if (Run_Saturday_Str == "false")
                                            {
                                                Run_Saturday = 0;
                                            }
                                            else if (Run_Saturday_Str == "")
                                            {
                                                Run_Saturday = 0;
                                            }
                                            else if (Run_Saturday_Str == null)
                                            {
                                                Run_Saturday = 0;
                                            }
                                            else if (Run_Saturday_Str == "true")
                                            {
                                                Run_Saturday = 1;
                                            }
                                            
                                            if (Calendar_Day_Str == null)
                                            {
                                                Calendar_Day = 0;
                                            }
                                            else if (Calendar_Day_Str == "")
                                            {
                                                Calendar_Day = 0;
                                            }
                                            else
                                            {
                                                Calendar_Day = Convert.ToInt32(Calendar_Day_Str);
                                            }

                                            if (No_Of_Intervals_Str == null)
                                            {
                                                No_Of_Intervals = 0;
                                            }
                                            else if (No_Of_Intervals_Str == "")
                                            {
                                                No_Of_Intervals = 0;
                                            }
                                            else
                                            {
                                                No_Of_Intervals = Convert.ToInt32(No_Of_Intervals_Str);
                                            }

                                            if (pk_Process_ID_Str == null)
                                            {
                                                pk_Process_ID = 0;
                                            }
                                            else if (pk_Process_ID_Str == "")
                                            {
                                                pk_Process_ID = 0;
                                            }
                                            else
                                            {
                                                pk_Process_ID = Convert.ToInt32(pk_Process_ID_Str);
                                            }
                                            string Interval = row["Interval"].ToString();
                                            if (Interval == null)
                                            {
                                                Interval = "NA";
                                            }
                                            else if (Interval == "")
                                            {
                                                Interval = "NA";
                                            }
                                            
                                            R_intr_t_Process_Schedule_dt2_Insert.Append("INSERT INTO intr_t_Process_Schedule " +
                                            "(pk_Process_ID,Scheduled,Start_Date," +
                                            "End_Date,Run_Time,Next_Run," +
                                            "Last_Run,Schedule_Type,Run_Sunday," +
                                            "Run_Monday,Run_Tuesday,Run_Wednesday," +
                                            "Run_Thursday,Run_Friday,Run_Saturday," +
                                            "Calendar_Day,Interval,No_Of_Intervals," +
                                            "Sched_Username,Sched_Password) " +
                                            "VALUES (" + pk_Process_ID + "," +
                                            Scheduled + ",'" +
                                            Start_Date + "','" +
                                            End_Date + "','" +
                                            Run_Time + "','" +
                                            Next_Run + "','" +
                                            Last_Run + "'," +
                                            row["Schedule_Type"].ToString() + "," +
                                            Run_Sunday + "," +
                                            Run_Monday + "," +
                                            Run_Tuesday + "," +
                                            Run_Wednesday + "," +
                                            Run_Thursday + "," +
                                            Run_Friday + "," +
                                            Run_Saturday + "," +
                                            Calendar_Day + ",'" +
                                            Interval + "'," +
                                            No_Of_Intervals + ",'" +
                                            Sched_Username + "','" +
                                            Sched_Password + "')");
                                            SqlCommand R_intr_t_Process_Schedule_dt2_Insert_Com = new SqlCommand();
                                            R_intr_t_Process_Schedule_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Process_Schedule_dt2_Insert_Com.Connection = sCon;
                                            R_intr_t_Process_Schedule_dt2_Insert_Com.CommandText = R_intr_t_Process_Schedule_dt2_Insert.ToString();
                                            R_intr_t_Process_Schedule_dt2_Insert_Com.ExecuteNonQuery();
                                            
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Process_Schedule data has been inserted................");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESS_SCHEDULE - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Process_SpecificTxTypes_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Process_SpecificTxTypes_s = new DataSet("R_intr_t_Process_SpecificTxTypes_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Process_SpecificTxTypes_XML_Path);
                                    R_intr_t_Process_SpecificTxTypes_s.ReadXml(reader);
                                    if (R_intr_t_Process_SpecificTxTypes_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Process_SpecificTxTypes_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Process_SpecificTxTypes_dt = R_intr_t_Process_SpecificTxTypes_s.Tables[0];
                                        DataTable R_intr_t_Process_SpecificTxTypes_dt2 = R_intr_t_Process_SpecificTxTypes_dt.Clone();
                                        DataRow[] results = R_intr_t_Process_SpecificTxTypes_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Process_SpecificTxTypes_dt2.ImportRow(dr);
                                        }
                                        SqlCommand R_intr_t_Process_SpecificTxTypes_dt2_SC = new SqlCommand();
                                        R_intr_t_Process_SpecificTxTypes_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Process_SpecificTxTypes_dt2_SC.Connection = sCon;
                                        R_intr_t_Process_SpecificTxTypes_dt2_SC.CommandText = "DELETE intr_t_Process_SpecificTxTypes WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Process_SpecificTxTypes_dt2_SC.ExecuteNonQuery();
                                        SqlDataAdapter R_intr_t_Process_SpecificTxTypes_dt2_SC_s = new SqlDataAdapter(R_intr_t_Process_SpecificTxTypes_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Process_SpecificTxTypes_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Process_SpecificTxTypes_dt2_Insert = new StringBuilder();
											string ck_TxType = row["ck_TxType"].ToString().Replace("'", "''");
											int Closes_Account = 0;
                                            if (row["Closes_Account"].ToString() == "false")
                                            {
                                                Closes_Account = 0;
                                            }
                                            else if (row["Closes_Account"].ToString() == null)
                                            {
                                                Closes_Account = 0;
                                            }
                                            else if (row["Closes_Account"].ToString() == "")
                                            {
                                                Closes_Account = 0;
                                            }
                                            else
                                            {
                                                Closes_Account = 1;
                                            }
                                            R_intr_t_Process_SpecificTxTypes_dt2_Insert.Append("INSERT INTO intr_t_Process_SpecificTxTypes " +
                                            "(ck_Process_ID,ck_TxType,Closes_Account) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_TxType + "'," +
                                            Closes_Account + ")");
                                            SqlCommand R_intr_t_Process_SpecificTxTypes_dt2_Insert_Com = new SqlCommand();
                                            R_intr_t_Process_SpecificTxTypes_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Process_SpecificTxTypes_dt2_Insert_Com.Connection = sCon;
                                            R_intr_t_Process_SpecificTxTypes_dt2_Insert_Com.CommandText = R_intr_t_Process_SpecificTxTypes_dt2_Insert.ToString();
                                            R_intr_t_Process_SpecificTxTypes_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Process_SpecificTxTypes data has been inserted...................");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESS_SPECifICTXTYPES - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Process_Terms_ForUpload_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Process_Terms_ForUpload_s = new DataSet("R_intr_t_Process_Terms_ForUpload_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Process_Terms_ForUpload_XML_Path);
                                    R_intr_t_Process_Terms_ForUpload_s.ReadXml(reader);
                                    if (R_intr_t_Process_Terms_ForUpload_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Process_Terms_ForUpload_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Process_Terms_ForUpload_dt = R_intr_t_Process_Terms_ForUpload_s.Tables[0];
                                        DataTable R_intr_t_Process_Terms_ForUpload_dt2 = R_intr_t_Process_Terms_ForUpload_dt.Clone();
                                        DataRow[] results = R_intr_t_Process_Terms_ForUpload_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Process_Terms_ForUpload_dt2.ImportRow(dr);
                                        }
                                        SqlCommand R_intr_t_Process_Terms_ForUpload_dt2_SC = new SqlCommand();
                                        R_intr_t_Process_Terms_ForUpload_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Process_Terms_ForUpload_dt2_SC.Connection = sCon;
                                        R_intr_t_Process_Terms_ForUpload_dt2_SC.CommandText = "DELETE intr_t_Process_Terms_ForUpload WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Process_Terms_ForUpload_dt2_SC.ExecuteNonQuery();
                                        SqlDataAdapter R_intr_t_Process_Terms_ForUpload_dt2_SC_s = new SqlDataAdapter(R_intr_t_Process_Terms_ForUpload_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Process_Terms_ForUpload_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Process_Terms_ForUpload_dt2_Insert = new StringBuilder();
											string ck_Term_ID = row["ck_Term_ID"].ToString().Replace("'", "''");
											int ck_Process_ID = 0;
											ck_Process_ID = Convert.ToInt32(row["ck_Process_ID"]);
											int Upload = 0;
                                            string Upload_string = row["Upload"].ToString();
                                            if (Upload_string == "false")
                                            {
                                                Upload = 0;
                                            }
                                            else if (Upload_string == "")
                                            {
                                                Upload = 0;
                                            }
											else if (Upload_string == " ")
                                            {
                                                Upload = 0;
                                            }
											else
                                            {
                                                Upload = 1;
                                            }

                                            R_intr_t_Process_Terms_ForUpload_dt2_Insert.Append("INSERT INTO intr_t_Process_Terms_ForUpload " +
                                            "(ck_Process_ID,ck_Term_ID,Upload) " +
                                            "VALUES (" + ck_Process_ID + ",'" +
                                            ck_Term_ID + "'," +
                                            Upload + ")");
                                            SqlCommand R_intr_t_Process_Terms_ForUpload_dt2_Insert_Com = new SqlCommand();
                                            R_intr_t_Process_Terms_ForUpload_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Process_Terms_ForUpload_dt2_Insert_Com.Connection = sCon;
                                            R_intr_t_Process_Terms_ForUpload_dt2_Insert_Com.CommandText = R_intr_t_Process_Terms_ForUpload_dt2_Insert.ToString();
                                            R_intr_t_Process_Terms_ForUpload_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Process_Terms_ForUpload data has been inserted...............");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESS_TERMS_FORUPLOAD - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Process_Translator_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Process_Translator_s = new DataSet("R_intr_t_Process_Translator_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Process_Translator_XML_Path);
                                    R_intr_t_Process_Translator_s.ReadXml(reader);
                                    if (R_intr_t_Process_Translator_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Process_Translator_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Process_Translator_dt = R_intr_t_Process_Translator_s.Tables[0];
                                        DataTable R_intr_t_Process_Translator_dt2 = R_intr_t_Process_Translator_dt.Clone();
                                        DataRow[] results = R_intr_t_Process_Translator_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Process_Translator_dt2.ImportRow(dr);
                                        }
                                        SqlCommand R_intr_t_Process_Translator_dt2_SC = new SqlCommand();
                                        R_intr_t_Process_Translator_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Process_Translator_dt2_SC.Connection = sCon;
                                        R_intr_t_Process_Translator_dt2_SC.CommandText = "DELETE intr_t_Process_Translator WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Process_Translator_dt2_SC.ExecuteNonQuery();
                                        SqlDataAdapter R_intr_t_Process_Translator_dt2_SC_s = new SqlDataAdapter(R_intr_t_Process_Translator_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Process_Translator_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Process_Translator_dt2_Insert = new StringBuilder();
											string ck_Process_Field_Name = row["ck_Process_Field_Name"].ToString().Replace("'", "''");
											string ck_Process_Field_Value = row["ck_Process_Field_Value"].ToString().Replace("'", "''");
											string Translated_Value = row["Translated_Value"].ToString().Replace("'", "''");
                                            R_intr_t_Process_Translator_dt2_Insert.Append("INSERT INTO intr_t_Process_Translator " +
                                            "(ck_Process_ID,ck_Process_Field_Name,ck_Process_Field_Value," +
                                            "Translated_Value,Ck_process_field_order) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_Process_Field_Name + "','" +
                                            ck_Process_Field_Value + "','" +
                                            Translated_Value + "'," +
                                            row["Ck_process_field_order"].ToString() + ")");
                                            SqlCommand R_intr_t_Process_Translator_dt2_Insert_Com = new SqlCommand();
                                            R_intr_t_Process_Translator_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Process_Translator_dt2_Insert_Com.Connection = sCon;
                                            R_intr_t_Process_Translator_dt2_Insert_Com.CommandText = R_intr_t_Process_Translator_dt2_Insert.ToString();
                                            R_intr_t_Process_Translator_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Process_Translator data has been inserted...............");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESS_TRANSLATOR - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Status_XML_Path))
                                try
                                {
                                    if (RESTORE_STATUS.Checked)
                                    {
                                        DataSet R_intr_t_Status_s = new DataSet("R_intr_t_Status_s");
                                        System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Status_XML_Path);
                                        R_intr_t_Status_s.ReadXml(reader);
                                        if (R_intr_t_Status_s.Tables.Count == 0)
                                        {
                                            RESTORE_PROCESS_TEXT.AppendLine(intr_t_Status_XML_Path.ToString() + " does not have any data...");
                                            RESTORE_PROCESS_TEXT.AppendLine("");
                                        }
                                        else
                                        {
                                            DataTable R_intr_t_Status_dt = R_intr_t_Status_s.Tables[0];
                                            DataTable R_intr_t_Status_dt2 = R_intr_t_Status_dt.Clone();
                                            DataRow[] results = R_intr_t_Status_dt.Select("FK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                            foreach (DataRow dr in results)
                                            {
                                                R_intr_t_Status_dt2.ImportRow(dr);
                                            }
                                            SqlCommand R_intr_t_Status_dt2_SC = new SqlCommand();
                                            R_intr_t_Status_dt2_SC.CommandType = CommandType.Text;
                                            R_intr_t_Status_dt2_SC.Connection = sCon;
                                            R_intr_t_Status_dt2_SC.CommandText = "SET IDENTITY_INSERT intr_t_Status ON";
                                            R_intr_t_Status_dt2_SC.ExecuteNonQuery();
                                            SqlDataAdapter R_intr_t_Status_dt2_SC_s = new SqlDataAdapter(R_intr_t_Status_dt2_SC);

                                            foreach (DataRow row in R_intr_t_Status_dt2.Rows)
                                            {
                                                int PK_OPERATION_ID = 0;
												int FK_PROCESS_ID = 0;
												int No_Processed = 0;
												int No_New = 0;
												int No_Changes = 0;
												int No_Non_Critical_Errors = 0;
												PK_OPERATION_ID = Convert.ToInt32(row["pk_Operation_ID"]);
                                                FK_PROCESS_ID = Convert.ToInt32(row["fk_Process_ID"]);
                                                R_intr_t_Status_dt2_SC.CommandText = "DELETE intr_t_Status WHERE fk_Process_ID = " + FK_PROCESS_ID + " OR PK_OPERATION_ID = " + PK_OPERATION_ID;
                                                R_intr_t_Status_dt2_SC.ExecuteNonQuery();
												int Success = 0;
                                                string Success_String = row["Success"].ToString();
                                                if (Success_String == "false")
                                                {
                                                    Success = 0;
                                                }
                                                else
                                                {
                                                    Success = 1;
                                                }
                                                No_Processed = Convert.ToInt32(row["No_Processed"]);
                                                No_New = Convert.ToInt32(row["No_New"]);
                                                No_Changes = Convert.ToInt32(row["No_Changes"]);
                                                No_Non_Critical_Errors = Convert.ToInt32(row["No_Non_Critical_Errors"]);
												
                                                StringBuilder R_intr_t_Status_dt2_Insert = new StringBuilder();
                                                string Start_Date = row["Start_Date"].ToString();
                                                string Completion_Date = row["Completion_Date"].ToString();
                                                string Status_Message = row["Status_Message"].ToString().Replace("'", "''");
                                                R_intr_t_Status_dt2_Insert.Append("INSERT INTO intr_t_Status " +
                                                "(pk_Operation_ID,fk_Process_ID,Start_Date," +
                                                "Completion_Date,Success,No_Processed," +
                                                "No_New,No_Changes,No_Non_Critical_Errors," +
                                                "Status_Message) " +
                                                "VALUES (" + row["pk_Operation_ID"].ToString() + "," +
                                                row["fk_Process_ID"].ToString() + ",'" +
                                                Start_Date + "','" +
                                                Completion_Date + "'," +
                                                Success + "," +
                                                No_Processed + "," +
                                                No_New + "," +
                                                No_Changes + "," +
                                                No_Non_Critical_Errors + ",'" +
                                                Status_Message + "')");
                                                SqlCommand R_intr_t_Status_dt2_Insert_Com = new SqlCommand();
                                                R_intr_t_Status_dt2_Insert_Com.CommandType = CommandType.Text;
                                                R_intr_t_Status_dt2_Insert_Com.Connection = sCon;
                                                R_intr_t_Status_dt2_Insert_Com.CommandText = R_intr_t_Status_dt2_Insert.ToString();
                                                R_intr_t_Status_dt2_Insert_Com.ExecuteNonQuery();

                                            }
                                            R_intr_t_Status_dt2_SC.CommandText = "SET IDENTITY_INSERT intr_t_Status OFF";
                                            R_intr_t_Status_dt2_SC.ExecuteNonQuery();
                                            RESTORE_PROCESS_TEXT.AppendLine("intr_t_Status data has been inserted..............");
                                            RESTORE_PROCESS_TEXT.AppendLine("");
                                        }
                                    }
                                    else
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine("INTR_T_STATUS data insert has been bypassed");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_STATUS - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            RESTORE_PROCESS_TEXT.AppendLine("Enabling the Constraints....................");
                            RESTORE_PROCESS_TEXT.AppendLine("");
                            SqlCommand R_ADD_Constraints = new SqlCommand();
                            R_ADD_Constraints.CommandType = CommandType.Text;
                            R_ADD_Constraints.Connection = sCon;
                            R_ADD_Constraints.CommandText = "ALTER TABLE intr_t_L_U_t_Configurations CHECK CONSTRAINT ALL";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE intr_t_Configuration_Defaults CHECK CONSTRAINT ALL";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE intr_t_Data_Dictionary CHECK CONSTRAINT ALL";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE intr_t_Incident_Translator CHECK CONSTRAINT ALL";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE intr_t_Process_Appln_Periods CHECK CONSTRAINT ALL";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE intr_t_Process_Config_Status CHECK CONSTRAINT ALL";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE intr_t_Process_CustProc CHECK CONSTRAINT ALL";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE intr_t_Process_Parameters CHECK CONSTRAINT ALL";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE intr_t_Process_Plan_Options CHECK CONSTRAINT ALL";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE intr_t_Process_Schedule CHECK CONSTRAINT ALL";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE intr_t_Process_SpecificTxTypes CHECK CONSTRAINT ALL";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE intr_t_Process_Terms_ForUpload CHECK CONSTRAINT ALL";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE intr_t_Process_Translator CHECK CONSTRAINT ALL";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE intr_t_Exclusions CHECK CONSTRAINT ALL";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE intr_t_Field_Map CHECK CONSTRAINT ALL";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE intr_t_Status CHECK CONSTRAINT ALL";
                            R_ADD_Constraints.ExecuteNonQuery();
                            RESTORE_PROCESS_TEXT.AppendLine("Constraints Enabled....................");
                            RESTORE_PROCESS_TEXT.AppendLine("");
                            RESTORE_PROCESS_TEXT.AppendLine("Importing of selected Interfaces have been completed................");
                            RESTORE_PROCESS_TEXT.AppendLine("");
                        }
                        catch (Exception ex)
                        {
                            RESTORE_PROCESS_TEXT.AppendLine(ex.Message);
                            RESTORE_PROCESS_TEXT.AppendLine("");

                        }
                    }
                    if (DB_TYPE_COMBO.Text.Equals("Oracle"))
                    {
                        string CONNECTION_STRING = "User Id=" + USERNAME_TEXT.Text + ";Password=" + PASSWORD_TEXT.Text + ";Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + ORA_HOST_TEXT.Text + ")(PORT=" + DB_PORT_TEXT.Text + "))" + "(CONNECT_DATA=(SID=" + SERVER_CONNECTION_TEXT.Text + ")));";
                        try
                        {
                            OracleConnection oCon = new OracleConnection(CONNECTION_STRING);
                            oCon.Open();
                            OracleCommand R_Drop_Constraints = new OracleCommand();
                            RESTORE_PROCESS_TEXT.AppendLine("Disabling Constraints........................");
                            RESTORE_PROCESS_TEXT.AppendLine("");
                            R_Drop_Constraints.CommandType = CommandType.Text;
                            R_Drop_Constraints.Connection = oCon;
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Exclusions DISABLE CONSTRAINT TC_intr_t_Exclusions8164";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Field_Map DISABLE CONSTRAINT PK_intr_t_Field_Map";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Field_Map DISABLE CONSTRAINT FK_intr_t_Field_Map";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Field_Map DISABLE CONSTRAINT fk_intr_t_Field_Map100";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Configuration_Defaults DISABLE CONSTRAINT PK_intr_t_Configuration_Def233";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Configuration_Defaults DISABLE CONSTRAINT FK_INTR_T_CONFIGURATION_DEF592";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Incident_Translator DISABLE CONSTRAINT PK_intr_Incident_Translator001";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_L_U_t_Configurations DISABLE CONSTRAINT PK_intr_t_L_U_t_Configurati232";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Process_Appln_Periods DISABLE CONSTRAINT PK_intr_t_Process_Applicati15";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Process_Appln_Periods DISABLE CONSTRAINT FK_intr_t_Process_Applicati20";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Process_Config_Status DISABLE CONSTRAINT PK_intr_t_Process_Config_St18";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Process_Config_Status DISABLE CONSTRAINT FK_intr_t_Process_Config_St19";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Process_CustProc DISABLE CONSTRAINT PK_intr_t_Process_CustProc14";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Process_CustProc DISABLE CONSTRAINT FK_intr_t_Process_CustProc15";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Process_Parameters DISABLE CONSTRAINT pk_intr_t_Process_Parameters";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Process_Parameters DISABLE CONSTRAINT fk_intr_t_Process_Parameters";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Process_Plan_Options DISABLE CONSTRAINT pk_intr_t_Process_PlanOptions";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Process_Plan_Options DISABLE CONSTRAINT fk_intr_t_Process_PlanOptions";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Process_Schedule DISABLE CONSTRAINT pk_intr_t_Process_Schedule";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Process_Schedule DISABLE CONSTRAINT fk_intr_t_Process_Schedule100";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Process_SpecificTxTypes DISABLE CONSTRAINT PK_intr_t_Process_Specific_17";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Process_SpecificTxTypes DISABLE CONSTRAINT fK_intr_t_Process_Specific_17";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Process_Terms_ForUpload DISABLE CONSTRAINT PK_intr_t_Process_Terms_For16";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Process_Terms_ForUpload DISABLE CONSTRAINT fK_intr_t_Process_Terms_For18";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Process_Translator DISABLE CONSTRAINT PK_intr_t_Process_Translato12";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Process_Translator DISABLE CONSTRAINT fK_intr_t_Process_Translato25";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Data_Dictionary DISABLE CONSTRAINT PK_intr_t_Data_Dictionary";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Data_Dictionary DISABLE CONSTRAINT FK_intr_t_Data_Dictionary";
                            R_Drop_Constraints.ExecuteNonQuery();
                            R_Drop_Constraints.CommandText = "Alter TABLE INTRCONFIG.intr_t_Status DISABLE CONSTRAINT PK_intr_t_Status";
                            R_Drop_Constraints.ExecuteNonQuery();
                            RESTORE_PROCESS_TEXT.AppendLine("Constraints Dropped...............................");
                            if (File.Exists(intr_t_processes_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Processes_s = new DataSet("R_intr_t_Processes_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_processes_XML_Path);
                                    R_intr_t_Processes_s.ReadXml(reader);
                                    if (R_intr_t_Processes_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_processes_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Processes_dt = R_intr_t_Processes_s.Tables[0];
                                        DataTable R_intr_t_Processes_dt2 = R_intr_t_Processes_dt.Clone();
                                        DataRow[] results = R_intr_t_Processes_dt.Select("PK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);

                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Processes_dt2.ImportRow(dr);
                                        }
                                        OracleCommand R_intr_t_Processes_dt2_SC = new OracleCommand();
                                        R_intr_t_Processes_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Processes_dt2_SC.Connection = oCon;
                                        R_intr_t_Processes_dt2_SC.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_PROCESSES DISABLE ALL TRIGGERS";
                                        R_intr_t_Processes_dt2_SC.ExecuteNonQuery();
                                        RESTORE_PROCESS_TEXT.AppendLine("TRIGGER INTRCONFIG.TRI_PROCESSES DISABLED");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                        R_intr_t_Processes_dt2_SC.CommandText = "DELETE INTRCONFIG.intr_t_Processes WHERE pk_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Processes_dt2_SC.ExecuteNonQuery();
                                        RESTORE_PROCESS_TEXT.AppendLine("INTRCONFIG.intr_t_Processes WHERE pk_Process_ID IN " + PK_PROCESS_ID_STRING_RS + "was deleted.");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                        OracleDataAdapter R_intr_t_Processes_dt2_SC_s = new OracleDataAdapter(R_intr_t_Processes_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Processes_dt2.Rows)
                                        {
                                            int Active = 0;
                                            if (row["Active"].ToString() == "false")
                                            {
                                                Active = 0;
                                            }
                                            else if (row["Active"].ToString() == "")
                                            {
                                                Active = 0;
                                            }
                                            else if (row["Active"].ToString() == null)
                                            {
                                                Active = 0;
                                            }
                                            else
                                            {
                                                Active = 1;
                                            }

                                            string CURRENT_USER = null;
                                            if (row["CURRENT_USER"].ToString() == null)
                                            {
                                                CURRENT_USER = null;
                                            }
                                            else if (row["CURRENT_USER"].ToString() == "")
                                            {
                                                CURRENT_USER = null;
                                            }
                                            else if (row["CURRENT_USER"].ToString() == " ")
                                            {
                                                CURRENT_USER = null;
                                            }
                                            else
                                            {
                                                CURRENT_USER = row["CURRENT_USER"].ToString();
                                            }
                                            int fk_Process_Type_ID = Convert.ToInt32(row["fk_Process_Type_ID"]);
                                            int Next_Execution_Step = Convert.ToInt32(row["Next_Execution_Step"]);
                                            StringBuilder R_intr_t_Processes_dt2_Insert = new StringBuilder();
											string Process_Name = row["Process_Name"].ToString().Replace("'","''");
											string Status = row["Status"].ToString().Replace("'","''");
											string Data_Set = row["Data_Set"].ToString().Replace("'","''");
                                            R_intr_t_Processes_dt2_Insert.Append("INSERT INTO INTRCONFIG.intr_t_Processes " +
                                            "(pk_Process_ID,Process_Name,Status," +
                                            "Next_Execution_Step,Data_Set,fk_Process_Type_ID," +
                                            "CURRENT_USER,Active) " +
                                            "VALUES ('" + row["pk_Process_ID"].ToString() + "','" +
                                            Process_Name + "','" +
                                            Status + "'," +
                                            Next_Execution_Step + ",'" +
                                            Data_Set + "'," +
                                            fk_Process_Type_ID + ",'" +
                                            CURRENT_USER + "'," +
                                            Active + ")");
                                            OracleCommand R_intr_t_Processes_dt2_Insert_Com = new OracleCommand();
                                            R_intr_t_Processes_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Processes_dt2_Insert_Com.Connection = oCon;
                                            R_intr_t_Processes_dt2_Insert_Com.CommandText = R_intr_t_Processes_dt2_Insert.ToString();
                                            R_intr_t_Processes_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        R_intr_t_Processes_dt2_SC.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_PROCESSES ENABLE ALL TRIGGERS";
                                        R_intr_t_Processes_dt2_SC.ExecuteNonQuery();
                                        RESTORE_PROCESS_TEXT.AppendLine("TRIGGER  INTRCONFIG.TRI_PROCESSES has been re-enabled...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                        RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESSES data has been inserted....");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESSES - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Configuration_Defaults_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Configuration_Defaults_s = new DataSet("R_intr_t_Configuration_Defaults_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Configuration_Defaults_XML_Path);
                                    R_intr_t_Configuration_Defaults_s.ReadXml(reader);
                                    if (R_intr_t_Configuration_Defaults_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Configuration_Defaults_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Configuration_Defaults_dt = R_intr_t_Configuration_Defaults_s.Tables[0];
                                        DataTable R_intr_t_Configuration_Defaults_dt2 = R_intr_t_Configuration_Defaults_dt.Clone();
                                        DataRow[] results = R_intr_t_Configuration_Defaults_dt.Select("PK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Configuration_Defaults_dt2.ImportRow(dr);
                                        }
                                        OracleCommand R_intr_t_Configuration_Defaults_dt2_SC = new OracleCommand();
                                        R_intr_t_Configuration_Defaults_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Configuration_Defaults_dt2_SC.Connection = oCon;
                                        R_intr_t_Configuration_Defaults_dt2_SC.CommandText = "DELETE INTRCONFIG.intr_t_Configuration_Defaults WHERE pk_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Configuration_Defaults_dt2_SC.ExecuteNonQuery();
                                        OracleDataAdapter R_intr_t_Configuration_Defaults_dt2_SC_s = new OracleDataAdapter(R_intr_t_Configuration_Defaults_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Configuration_Defaults_dt2.Rows)
                                        {
                                            string PK_Position_Str = row["pk_Position"].ToString();
                                            int pk_Position = 0;
                                            if (PK_Position_Str == "")
                                            {
                                                pk_Position = 0;
                                            }
                                            else if (PK_Position_Str == null)
                                            {
                                                pk_Position = 0;
                                            }
                                            else
                                            {
                                                pk_Position = Convert.ToInt32(PK_Position_Str);
                                            }

                                            string RMS_Field_Size_Str = row["RMS_Field_Size"].ToString();
                                            int RMS_Field_Size = 0;
                                            if (RMS_Field_Size_Str == "")
                                            {
                                                RMS_Field_Size = 0;
                                            }
                                            else if (RMS_Field_Size_Str == null)
                                            {
                                                RMS_Field_Size = 0;
                                            }
                                            else
                                            {
                                                RMS_Field_Size = Convert.ToInt32(RMS_Field_Size_Str);
                                            }

                                            string ATT_Send_Size_Str = row["ATT_Send_Size"].ToString();
                                            int ATT_Send_Size = 0;
                                            if (ATT_Send_Size_Str == "")
                                            {
                                                ATT_Send_Size = 0;
                                            }
                                            else if (ATT_Send_Size_Str == null)
                                            {
                                                ATT_Send_Size = 0;
                                            }
                                            else
                                            {
                                                ATT_Send_Size = Convert.ToInt32(ATT_Send_Size_Str);
                                            }

                                            string Pk_process_id_Str = row["Pk_process_id"].ToString();
                                            int Pk_process_id = 0;
                                            if (Pk_process_id_Str == "")
                                            {
                                                Pk_process_id = 0;
                                            }
                                            else if (Pk_process_id_Str == null)
                                            {
                                                Pk_process_id = 0;
                                            }
                                            else
                                            {
                                                Pk_process_id = Convert.ToInt32(Pk_process_id_Str);
                                            }
											string fk_Field_Name = row["fk_Field_Name"].ToString().Replace("'","''");
											string Table_Name = row["Table_Name"].ToString().Replace("'","''");
                                            StringBuilder R_intr_t_Configuration_Defaults_dt2_Insert = new StringBuilder();
                                            R_intr_t_Configuration_Defaults_dt2_Insert.Append("INSERT INTO INTRCONFIG.intr_t_Configuration_Defaults " +
                                            "(pk_Position,fk_Field_Name,RMS_Field_Size," +
                                            "ATT_Send_Size,Table_Name,Pk_process_id) " +
                                            "VALUES (" + pk_Position + ",'" +
                                            fk_Field_Name + "'," +
                                            RMS_Field_Size + "," +
                                            ATT_Send_Size + ",'" +
                                            Table_Name + "'," +
                                            Pk_process_id + ")");
                                            OracleCommand R_intr_t_Configuration_Defaults_dt2_Insert_Com = new OracleCommand();
                                            R_intr_t_Configuration_Defaults_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Configuration_Defaults_dt2_Insert_Com.Connection = oCon;
                                            R_intr_t_Configuration_Defaults_dt2_Insert_Com.CommandText = R_intr_t_Configuration_Defaults_dt2_Insert.ToString();
                                            R_intr_t_Configuration_Defaults_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Configuration_Defaults data has been inserted.....");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }

                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_CONFIGURATION_DEFAULTS - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Data_Dictionary_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Data_Dictionary_s = new DataSet("R_intr_t_Data_Dictionary_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Data_Dictionary_XML_Path);
                                    R_intr_t_Data_Dictionary_s.ReadXml(reader);
                                    if (R_intr_t_Data_Dictionary_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Data_Dictionary_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Data_Dictionary_dt = R_intr_t_Data_Dictionary_s.Tables[0];
                                        DataTable R_intr_t_Data_Dictionary_dt2 = R_intr_t_Data_Dictionary_dt.Clone();
                                        DataRow[] results = R_intr_t_Data_Dictionary_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Data_Dictionary_dt2.ImportRow(dr);
                                        }
                                        OracleCommand R_intr_t_Data_Dictionary_dt2_SC = new OracleCommand();
                                        R_intr_t_Data_Dictionary_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Data_Dictionary_dt2_SC.Connection = oCon;
                                        R_intr_t_Data_Dictionary_dt2_SC.CommandText = "DELETE INTRCONFIG.intr_t_Data_Dictionary WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Data_Dictionary_dt2_SC.ExecuteNonQuery();
                                        OracleDataAdapter R_intr_t_Data_Dictionary_dt2_SC_s = new OracleDataAdapter(R_intr_t_Data_Dictionary_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Data_Dictionary_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Data_Dictionary_dt2_Insert = new StringBuilder();
											string ck_Dictionary_Item_Name = row["ck_Dictionary_Item_Name"].ToString().Replace("'","''");
											string ck_Source_Type = row["ck_Source_Type"].ToString().Replace("'","''");
											string FTP_Server = row["FTP_Server"].ToString().Replace("'","''");
											string FTP_Remote_File_Name = row["FTP_Remote_File_Name"].ToString().Replace("'","''");
											string FTP_User = row["FTP_User"].ToString().Replace("'","''");
											string FTP_PASSWORD = row["FTP_PASSWORD"].ToString().Replace("'","''");
											string Text_Local_File_path = row["Text_Local_File_path"].ToString().Replace("'","''");
											string Text_File_format = row["Text_File_format"].ToString().Replace("'","''");
											string Text_Archive_File_path = row["Text_Archive_File_path"].ToString().Replace("'","''");
											string Text_Delimiter = row["Text_Delimiter"].ToString().Replace("'","''");
											string Text_Date_Delimiter = row["Text_Date_Delimiter"].ToString().Replace("'","''");
											string Text_Date_Format = row["Text_Date_Format"].ToString().Replace("'","''");
											string REMOTE_DB_TYPE = row["REMOTE_DB_TYPE"].ToString().Replace("'","''");
											string Authenticate_Against = row["Authenticate_Against"].ToString().Replace("'","''");
											string Remote_Server_Username = row["Remote_Server_Username"].ToString().Replace("'","''");
											string Remote_Server_Password = row["Remote_Server_Password"].ToString().Replace("'","''");
											string Remote_Database_Name = row["Remote_Table_Name"].ToString().Replace("'","''");
											string Remote_Table_Name = row["ck_Dictionary_Item_Name"].ToString().Replace("'","''");
											string record_terminator = row["record_terminator"].ToString().Replace("'","''");
                                            R_intr_t_Data_Dictionary_dt2_Insert.Append("INSERT INTO INTRCONFIG.intr_t_Data_Dictionary " +
                                            "(ck_Process_ID,ck_Dictionary_Item_Name,ck_Source_Type,FTP_Server," +
                                            "FTP_Remote_File_Name,FTP_User,FTP_PASSWORD,Text_Local_File_path,Text_File_format," +
                                            "Text_Archive_File_path,Text_Delimiter,Text_Date_Delimiter,Text_Date_Format,Remote_DB_Type," +
                                            "Authenticate_Against,Remote_Server_Username,Remote_Server_Password,Remote_Database_Name," +
                                            "Remote_Table_Name,record_terminator) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_Dictionary_Item_Name + "','" +
                                            ck_Source_Type + "','" +
                                            FTP_Server + "','" +
                                            FTP_Remote_File_Name + "','" +
                                            FTP_User + "','" +
                                            FTP_PASSWORD + "','" +
                                            Text_Local_File_path + "','" +
                                            Text_File_format + "','" +
                                            Text_Archive_File_path + "','" +
                                            Text_Delimiter + "','" +
                                            Text_Date_Delimiter + "','" +
                                            Text_Date_Format + "','" +
                                            REMOTE_DB_TYPE + "','" +
                                            Authenticate_Against + "','" +
                                            Remote_Server_Username + "','" +
                                            Remote_Server_Password + "','" +
                                            Remote_Database_Name + "','" +
                                            Remote_Table_Name + "','" +
                                            record_terminator + "')");
                                            OracleCommand R_intr_t_Data_Dictionary_dt2_Insert_Com = new OracleCommand();
                                            R_intr_t_Data_Dictionary_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Data_Dictionary_dt2_Insert_Com.Connection = oCon;
                                            R_intr_t_Data_Dictionary_dt2_Insert_Com.CommandText = R_intr_t_Data_Dictionary_dt2_Insert.ToString();
                                            R_intr_t_Data_Dictionary_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Data_Dictionary data has been inserted..........");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_DATA_DICTIONARY - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Exclusions_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Exclusions_s = new DataSet("R_intr_t_Exclusions_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Exclusions_XML_Path);
                                    R_intr_t_Exclusions_s.ReadXml(reader);
                                    if (R_intr_t_Exclusions_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Exclusions_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Exclusions_dt = R_intr_t_Exclusions_s.Tables[0];
                                        DataTable R_intr_t_Exclusions_dt2 = R_intr_t_Exclusions_dt.Clone();
                                        DataRow[] results = R_intr_t_Exclusions_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Exclusions_dt2.ImportRow(dr);
                                        }
                                        OracleCommand R_intr_t_Exclusions_dt2_SC = new OracleCommand();
                                        R_intr_t_Exclusions_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Exclusions_dt2_SC.Connection = oCon;
                                        R_intr_t_Exclusions_dt2_SC.CommandText = "DELETE INTRCONFIG.intr_t_Exclusions WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Exclusions_dt2_SC.ExecuteNonQuery();
                                        OracleDataAdapter R_intr_t_Exclusions_dt2_SC_s = new OracleDataAdapter(R_intr_t_Exclusions_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Exclusions_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Exclusions_dt2_Insert = new StringBuilder();
											string ck_Exclusion_Type = row["ck_Exclusion_Type"].ToString().Replace("'","''");
											string ck_Exclusion_Value = row["ck_Exclusion_Value"].ToString().Replace("'","''");
                                            R_intr_t_Exclusions_dt2_Insert.Append("INSERT INTO INTRCONFIG.intr_t_Exclusions " +
                                            "(ck_Process_ID,ck_Exclusion_Type,ck_Exclusion_Value) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_Exclusion_Type + "','" +
                                            ck_Exclusion_Value + "')");
                                            OracleCommand R_intr_t_Exclusions_dt2_Insert_Com = new OracleCommand();
                                            R_intr_t_Exclusions_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Exclusions_dt2_Insert_Com.Connection = oCon;
                                            R_intr_t_Exclusions_dt2_Insert_Com.CommandText = R_intr_t_Exclusions_dt2_Insert.ToString();
                                            R_intr_t_Exclusions_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Exclusions data has been inserted...............");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_EXCLUSIONS - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Field_Map_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Field_Map_s = new DataSet("R_intr_t_Field_Map_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Field_Map_XML_Path);
                                    R_intr_t_Field_Map_s.ReadXml(reader);
                                    if (R_intr_t_Field_Map_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Field_Map_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Field_Map_dt = R_intr_t_Field_Map_s.Tables[0];
                                        DataTable R_intr_t_Field_Map_dt2 = R_intr_t_Field_Map_dt.Clone();
                                        DataRow[] results = R_intr_t_Field_Map_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Field_Map_dt2.ImportRow(dr);
                                        }
                                        OracleCommand R_intr_t_Field_Map_dt2_SC = new OracleCommand();
                                        R_intr_t_Field_Map_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Field_Map_dt2_SC.Connection = oCon;
                                        R_intr_t_Field_Map_dt2_SC.CommandText = "ALTER TABLE INTRCONFIG.intr_t_Field_Map DISABLE ALL TRIGGERS";
                                        R_intr_t_Field_Map_dt2_SC.ExecuteNonQuery();
                                        RESTORE_PROCESS_TEXT.AppendLine("TRIGGER INTRCONFIG.TRI_FIELD_MAP DISABLED");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                        R_intr_t_Field_Map_dt2_SC.CommandText = "DELETE INTRCONFIG.intr_t_Field_Map WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Field_Map_dt2_SC.ExecuteNonQuery();
                                        OracleDataAdapter R_intr_t_Field_Map_dt2_SC_s = new OracleDataAdapter(R_intr_t_Field_Map_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Field_Map_dt2.Rows)
                                        {
                                            string External_Field_Name = row["External_Field_Name"].ToString();
                                            if (External_Field_Name != "")
                                            {
                                                
                                            }
                                            else
                                            {
                                                External_Field_Name = "NA";
                                            }
                                            int External_Field_Size = 0;
                                            if (row["External_Field_Size"].ToString() == "")
                                            {
                                                External_Field_Size = 0;
                                            }
                                            else if (row["External_Field_Size"].ToString() == " ")
                                            {
                                                External_Field_Size = 0;
                                            }
                                            else if (row["External_Field_Size"].ToString() == null)
                                            {
                                                External_Field_Size = 0;
                                            }
                                            else
                                            {
                                                External_Field_Size = Convert.ToInt32(row["External_Field_Size"].ToString());
                                            }
                                            int process_Field_Size = 0;
                                            if (row["process_Field_Size"].ToString() == "")
                                            {
                                                process_Field_Size = 0;
                                            }
                                            else if (row["process_Field_Size"].ToString() == " ")
                                            {
                                                process_Field_Size = 0;
                                            }
                                            else if (row["process_Field_Size"].ToString() == null)
                                            {
                                                process_Field_Size = 0;
                                            }
                                            else
                                            {
                                                process_Field_Size = Convert.ToInt32(row["process_Field_Size"].ToString());
                                            }
                                            int process_Field_start_pos = 0;
                                            if (row["process_Field_start_pos"].ToString() == "")
                                            {
                                                process_Field_start_pos = 0;
                                            }
                                            else if (row["process_Field_start_pos"].ToString() == " ")
                                            {
                                                process_Field_start_pos = 0;
                                            }
                                            else if (row["process_Field_start_pos"].ToString() == null)
                                            {
                                                process_Field_start_pos = 0;
                                            }
                                            else
                                            {
                                                process_Field_start_pos = Convert.ToInt32(row["process_Field_start_pos"].ToString());
                                            }
                                            string process_field_fill_char = row["process_field_fill_char"].ToString();
                                            if (process_field_fill_char == null)
                                            {
                                                process_field_fill_char = " ";
                                            }
                                            else if (process_field_fill_char == " ")
                                            {
                                                process_field_fill_char = " ";
                                            }
                                            else if (process_field_fill_char == "")
                                            {
                                                process_field_fill_char = " ";
                                            }
                                            StringBuilder R_intr_t_Field_Map_dt2_Insert = new StringBuilder();
											string ck_source_Type = row["ck_source_Type"].ToString().Replace("'", "''");
											string ck_Dictionary_Item_Name = row["ck_Dictionary_Item_Name"].ToString().Replace("'", "''");
											string ck_process_Field_Name = row["ck_process_Field_Name"].ToString().Replace("'", "''");
											string process_Field_Type = row["process_Field_Type"].ToString().Replace("'", "''");
											string process_Field_SpFormat = row["process_Field_SpFormat"].ToString().Replace("'", "''");
											External_Field_Name = External_Field_Name.Replace("'", "''");
											string External_Field_Type = row["External_Field_Type"].ToString().Replace("'", "''");
											string process_field_justify = row["process_field_justify"].ToString().Replace("'", "''");
											process_field_fill_char = process_field_fill_char.Replace("'", "''");
                                            R_intr_t_Field_Map_dt2_Insert.Append("INSERT INTO INTRCONFIG.intr_t_Field_Map " +
                                            "(ck_Process_ID,ck_source_Type,ck_Dictionary_Item_Name," +
                                            "ck_process_Field_Name,process_Field_Type,process_Field_start_pos," +
                                            "process_Field_Size,process_Field_SpFormat,External_Field_Name," +
                                            "External_Field_Type,External_Field_Size,process_field_justify," +
                                            "process_field_fill_char) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_source_Type + "','" +
                                            ck_Dictionary_Item_Name + "','" +
                                            ck_process_Field_Name + "','" +
                                            process_Field_Type + "'," +
                                            process_Field_start_pos + "," +
                                            process_Field_Size + ",'" +
                                            process_Field_SpFormat + "','" +
                                            External_Field_Name + "','" +
                                            External_Field_Type + "'," +
                                            External_Field_Size + ",'" +
                                            process_field_justify + "','" +
                                            process_field_fill_char + "')");
                                            OracleCommand R_intr_t_Field_Map_dt2_Insert_Com = new OracleCommand();
                                            R_intr_t_Field_Map_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Field_Map_dt2_Insert_Com.Connection = oCon;
                                            R_intr_t_Field_Map_dt2_Insert_Com.CommandText = R_intr_t_Field_Map_dt2_Insert.ToString();
                                            R_intr_t_Field_Map_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        R_intr_t_Field_Map_dt2_SC.CommandText = "ALTER TABLE INTRCONFIG.intr_t_Field_Map ENABLE ALL TRIGGERS";
                                        R_intr_t_Field_Map_dt2_SC.ExecuteNonQuery();
                                        RESTORE_PROCESS_TEXT.AppendLine("TRIGGER INTRCONFIG.TRI_FIELD_MAP has been re-enabled...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Field_Map data has been inserted..................");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_FIELD_MAP - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Incident_Translator_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Incident_Translator_s = new DataSet("R_intr_t_Incident_Translator_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Incident_Translator_XML_Path);
                                    R_intr_t_Incident_Translator_s.ReadXml(reader);
                                    if (R_intr_t_Incident_Translator_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Incident_Translator_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Incident_Translator_dt = R_intr_t_Incident_Translator_s.Tables[0];
                                        DataTable R_intr_t_Incident_Translator_dt2 = R_intr_t_Incident_Translator_dt.Clone();
                                        DataRow[] results = R_intr_t_Incident_Translator_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Incident_Translator_dt2.ImportRow(dr);
                                        }
                                        OracleCommand R_intr_t_Incident_Translator_dt2_SC = new OracleCommand();
                                        R_intr_t_Incident_Translator_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Incident_Translator_dt2_SC.Connection = oCon;
                                        R_intr_t_Incident_Translator_dt2_SC.CommandText = "DELETE INTRCONFIG.intr_t_Incident_Translator WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Incident_Translator_dt2_SC.ExecuteNonQuery();
                                        OracleDataAdapter R_intr_t_Incident_Translator_dt2_SC_s = new OracleDataAdapter(R_intr_t_Incident_Translator_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Incident_Translator_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Incident_Translator_dt2_Insert = new StringBuilder();
											string ck_Im_Ex_Field = row["ck_Im_Ex_Field"].ToString().Replace("'", "''");
											string fk_Inc_Type_Code = row["fk_Inc_Type_Code"].ToString().Replace("'", "''");
											string fk_Flag_Code = row["fk_Flag_Code"].ToString().Replace("'", "''");
											string fk_Inc_Location_Code = row["fk_Inc_Location_Code"].ToString().Replace("'", "''");
											string fk_Inc_Cleary_Code = row["fk_Inc_Cleary_Code"].ToString().Replace("'", "''");
                                            R_intr_t_Incident_Translator_dt2_Insert.Append("INSERT INTO INTRCONFIG.intr_t_Incident_Translator " +
                                            "(ck_Process_ID,ck_Im_Ex_Field,fk_Inc_Type_Code,fk_Flag_Code," +
                                            "fk_Inc_Location_Code,fk_Inc_Cleary_Code,FK_INCIDENT_ACTION_ID) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_Im_Ex_Field + "','" +
                                            fk_Inc_Type_Code + "','" +
                                            fk_Flag_Code + "','" +
                                            fk_Inc_Location_Code + "','" +
                                            fk_Inc_Cleary_Code + "','" +
                                            row["FK_INCIDENT_ACTION_ID"].ToString() + "')");
                                            OracleCommand R_intr_t_Incident_Translator_dt2_Insert_Com = new OracleCommand();
                                            R_intr_t_Incident_Translator_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Incident_Translator_dt2_Insert_Com.Connection = oCon;
                                            R_intr_t_Incident_Translator_dt2_Insert_Com.CommandText = R_intr_t_Incident_Translator_dt2_Insert.ToString();
                                            R_intr_t_Incident_Translator_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Incident_Translator data has been inserted................");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_INCIDENT_TRANSLATOR - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_L_U_t_Configurations_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_L_U_t_Configurations_s = new DataSet("R_intr_t_L_U_t_Configurations_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_L_U_t_Configurations_XML_Path);
                                    R_intr_t_L_U_t_Configurations_s.ReadXml(reader);
                                    if (R_intr_t_L_U_t_Configurations_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_L_U_t_Configurations_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_L_U_t_Configurations_dt = R_intr_t_L_U_t_Configurations_s.Tables[0];
                                        DataTable R_intr_t_L_U_t_Configurations_dt2 = R_intr_t_L_U_t_Configurations_dt.Clone();
                                        DataRow[] results = R_intr_t_L_U_t_Configurations_dt.Select("PK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_L_U_t_Configurations_dt2.ImportRow(dr);
                                        }
                                        OracleCommand R_intr_t_L_U_t_Configurations_dt2_SC = new OracleCommand();
                                        R_intr_t_L_U_t_Configurations_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_L_U_t_Configurations_dt2_SC.Connection = oCon;
                                        R_intr_t_L_U_t_Configurations_dt2_SC.CommandText = "DELETE INTRCONFIG.intr_t_L_U_t_Configurations WHERE pk_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_L_U_t_Configurations_dt2_SC.ExecuteNonQuery();
                                        OracleDataAdapter R_intr_t_L_U_t_Configurations_dt2_SC_s = new OracleDataAdapter(R_intr_t_L_U_t_Configurations_dt2_SC);

                                        foreach (DataRow row in R_intr_t_L_U_t_Configurations_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_L_U_t_Configurations_dt2_Insert = new StringBuilder();
											string pk_Field_Name = row["pk_Field_Name"].ToString().Replace("'", "''");
											string Table_Name = row["Table_Name"].ToString().Replace("'", "''");
                                            string SQL_Statement = row["SQL_Statement"].ToString();
                                            R_intr_t_L_U_t_Configurations_dt2_Insert.Append("INSERT INTO INTRCONFIG.intr_t_L_U_t_Configurations " +
                                            "(pk_Field_Name,Table_Name,RMS_Field_Size," +
                                            "SQL_Statement,Pk_Process_id) " +
                                            "VALUES ('" + pk_Field_Name + "','" +
                                            Table_Name + "'," +
                                            row["RMS_Field_Size"].ToString() + ",'" +
                                            ":SQL_Statement," +
                                            row["Pk_Process_id"].ToString() + ")");
                                            string sql = R_intr_t_L_U_t_Configurations_dt2_Insert.ToString();
                                            OracleCommand oraCommand = new OracleCommand(sql, oCon);
                                            OracleParameter param1 = oraCommand.Parameters.Add("SQL_Statement", OracleDbType.Clob);
                                            param1.Direction = ParameterDirection.Input;
                                            param1.Value = SQL_Statement;
                                            oraCommand.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_L_U_t_Configurations data has been inserted...........");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_L_U_T_CONFIGURATIONS - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Process_Appln_Periods_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Process_Appln_Periods_s = new DataSet("R_intr_t_Process_Appln_Periods_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Process_Appln_Periods_XML_Path);
                                    R_intr_t_Process_Appln_Periods_s.ReadXml(reader);
                                    if (R_intr_t_Process_Appln_Periods_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Process_Appln_Periods_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Process_Appln_Periods_dt = R_intr_t_Process_Appln_Periods_s.Tables[0];
                                        DataTable R_intr_t_Process_Appln_Periods_dt2 = R_intr_t_Process_Appln_Periods_dt.Clone();
                                        DataRow[] results = R_intr_t_Process_Appln_Periods_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Process_Appln_Periods_dt2.ImportRow(dr);
                                        }
                                        OracleCommand R_intr_t_Process_Appln_Periods_dt2_SC = new OracleCommand();
                                        R_intr_t_Process_Appln_Periods_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Process_Appln_Periods_dt2_SC.Connection = oCon;
                                        R_intr_t_Process_Appln_Periods_dt2_SC.CommandText = "DELETE INTRCONFIG.intr_t_Process_Appln_Periods WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Process_Appln_Periods_dt2_SC.ExecuteNonQuery();
                                        OracleDataAdapter R_intr_t_Process_Appln_Periods_dt2_SC_s = new OracleDataAdapter(R_intr_t_Process_Appln_Periods_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Process_Appln_Periods_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Process_Appln_Periods_dt2_Insert = new StringBuilder();
											string ck_Show_Name = row["ck_Show_Name"].ToString().Replace("'", "''");
                                            if (ck_Show_Name == "")
                                            {
                                                ck_Show_Name = "NA";
                                            }
                                            else if (ck_Show_Name == " ")
                                            {
                                                ck_Show_Name = "NA";
                                            }
                                            else if (ck_Show_Name == null)
                                            {
                                                ck_Show_Name = "NA";
                                            }
											string Show_Type = row["Show_Type"].ToString().Replace("'", "''");
                                            if (Show_Type == "")
                                            {
                                                Show_Type = "NA";
                                            }
                                            else if (Show_Type == " ")
                                            {
                                                Show_Type = "NA";
                                            }
                                            else if (Show_Type == null)
                                            {
                                                Show_Type = "NA";
                                            }
											string Reference_Text = row["Reference_Text"].ToString().Replace("'", "''");
                                            R_intr_t_Process_Appln_Periods_dt2_Insert.Append("INSERT INTO INTRCONFIG.intr_t_Process_Appln_Periods " +
                                            "(ck_Process_ID,ck_Show_Name,Show_Type," +
                                            "Reference_Text) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_Show_Name + "','" +
                                            Show_Type + "','" +
                                            Reference_Text + "')");
                                            OracleCommand R_intr_t_Process_Appln_Periods_dt2_Insert_Com = new OracleCommand();
                                            R_intr_t_Process_Appln_Periods_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Process_Appln_Periods_dt2_Insert_Com.Connection = oCon;
                                            R_intr_t_Process_Appln_Periods_dt2_Insert_Com.CommandText = R_intr_t_Process_Appln_Periods_dt2_Insert.ToString();
                                            R_intr_t_Process_Appln_Periods_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Process_Appln_Periods data has been inserted.............");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESS_APPLN_PERIODS - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Process_Config_Status_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Process_Config_Status_s = new DataSet("R_intr_t_Process_Config_Status_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Process_Config_Status_XML_Path);
                                    R_intr_t_Process_Config_Status_s.ReadXml(reader);
                                    if (R_intr_t_Process_Config_Status_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Process_Config_Status_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Process_Config_Status_dt = R_intr_t_Process_Config_Status_s.Tables[0];
                                        DataTable R_intr_t_Process_Config_Status_dt2 = R_intr_t_Process_Config_Status_dt.Clone();
                                        DataRow[] results = R_intr_t_Process_Config_Status_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Process_Config_Status_dt2.ImportRow(dr);
                                        }
                                        OracleCommand R_intr_t_Process_Config_Status_dt2_SC = new OracleCommand();
                                        R_intr_t_Process_Config_Status_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Process_Config_Status_dt2_SC.Connection = oCon;
                                        R_intr_t_Process_Config_Status_dt2_SC.CommandText = "DELETE INTRCONFIG.intr_t_Process_Config_Status WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Process_Config_Status_dt2_SC.ExecuteNonQuery();
                                        OracleDataAdapter R_intr_t_Process_Config_Status_dt2_SC_s = new OracleDataAdapter(R_intr_t_Process_Config_Status_dt2_SC);
                                        foreach (DataRow row in R_intr_t_Process_Config_Status_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Process_Config_Status_dt2_Insert = new StringBuilder();
											string ck_Process_Config_Item = row["ck_Process_Config_Item"].ToString().Replace("'", "''");
                                            R_intr_t_Process_Config_Status_dt2_Insert.Append("INSERT INTO INTRCONFIG.intr_t_Process_Config_Status " +
                                            "(ck_Process_ID,ck_Process_Config_Item,Config_Item_Status) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_Process_Config_Item + "'," +
                                            row["Config_Item_Status"].ToString() + ")");
                                            OracleCommand R_intr_t_Process_Config_Status_dt2_Insert_Com = new OracleCommand();
                                            R_intr_t_Process_Config_Status_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Process_Config_Status_dt2_Insert_Com.Connection = oCon;
                                            R_intr_t_Process_Config_Status_dt2_Insert_Com.CommandText = R_intr_t_Process_Config_Status_dt2_Insert.ToString();
                                            R_intr_t_Process_Config_Status_dt2_Insert_Com.ExecuteNonQuery();

                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Process_Config_Status data has been inserted.............");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESS_CONFIG_STATUS - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Process_CustProc_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Process_CustProc_s = new DataSet("R_intr_t_Process_CustProc_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Process_CustProc_XML_Path);
                                    R_intr_t_Process_CustProc_s.ReadXml(reader);
                                    if (R_intr_t_Process_CustProc_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Process_CustProc_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Process_CustProc_dt = R_intr_t_Process_CustProc_s.Tables[0];
                                        DataTable R_intr_t_Process_CustProc_dt2 = R_intr_t_Process_CustProc_dt.Clone();
                                        DataRow[] results = R_intr_t_Process_CustProc_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Process_CustProc_dt2.ImportRow(dr);
                                        }
                                        OracleCommand R_intr_t_Process_CustProc_dt2_SC = new OracleCommand();
                                        R_intr_t_Process_CustProc_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Process_CustProc_dt2_SC.Connection = oCon;
                                        R_intr_t_Process_CustProc_dt2_SC.CommandText = "DELETE INTRCONFIG.intr_t_Process_CustProc WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Process_CustProc_dt2_SC.ExecuteNonQuery();
                                        OracleDataAdapter R_intr_t_Process_CustProc_dt2_SC_s = new OracleDataAdapter(R_intr_t_Process_CustProc_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Process_CustProc_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Process_CustProc_dt2_Insert = new StringBuilder();
                                            string SQL_Statement_Part1 = row["SQL_Statement_Part1"].ToString();
                                            string SQL_Statement_Part2 = row["SQL_Statement_Part2"].ToString();
                                            string SQL_Statement_Part3 = row["SQL_Statement_Part3"].ToString();
                                            string SQL_Statement_Part4 = row["SQL_Statement_Part4"].ToString();
                                            string ck_Cust_Proc_Description = row["ck_Cust_Proc_Description"].ToString().Replace("'", "''");
											string ck_Insertion = row["ck_Insertion"].ToString().Replace("'", "''");
                                            R_intr_t_Process_CustProc_dt2_Insert.Append("INSERT INTO INTRCONFIG.intr_t_Process_CustProc " +
                                            "(ck_Process_ID,ck_Cust_Proc_Description,ck_Insertion," +
                                            "ck_Order,SQL_Statement_Part1,SQL_Statement_Part2," +
                                            "SQL_Statement_Part3,SQL_Statement_Part4) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_Cust_Proc_Description + "','" +
                                            ck_Insertion + "'," +
                                            row["ck_Order"].ToString() + "," +
                                            ":SQL_Statement_Part1," +
                                            ":SQL_Statement_Part2," +
                                            ":SQL_Statement_Part3," +
                                            ":SQL_Statement_Part4)");
                                            string sql = R_intr_t_Process_CustProc_dt2_Insert.ToString();
                                            OracleCommand oraCommand = new OracleCommand(sql, oCon);
                                            OracleParameter param1 = oraCommand.Parameters.Add("SQL_Statement_Part1", OracleDbType.Clob);
                                            param1.Direction = ParameterDirection.Input;
                                            param1.Value = SQL_Statement_Part1;
                                            OracleParameter param2 = oraCommand.Parameters.Add("SQL_Statement_Part2", OracleDbType.Clob);
                                            param2.Direction = ParameterDirection.Input;
                                            param2.Value = SQL_Statement_Part2;
                                            OracleParameter param3 = oraCommand.Parameters.Add("SQL_Statement_Part3", OracleDbType.Clob);
                                            param3.Direction = ParameterDirection.Input;
                                            param3.Value = SQL_Statement_Part3;
                                            OracleParameter param4 = oraCommand.Parameters.Add("SQL_Statement_Part4", OracleDbType.Clob);
                                            param4.Direction = ParameterDirection.Input;
                                            param4.Value = SQL_Statement_Part4;
                                            oraCommand.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Process_CustProc data has been inserted...............");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESS_CUSTPROC - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Process_Parameters_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Process_Parameters_s = new DataSet("R_intr_t_Process_Parameters_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Process_Parameters_XML_Path);
                                    R_intr_t_Process_Parameters_s.ReadXml(reader);
                                    if (R_intr_t_Process_Parameters_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Process_Parameters_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Process_Parameters_dt = R_intr_t_Process_Parameters_s.Tables[0];
                                        DataTable R_intr_t_Process_Parameters_dt2 = R_intr_t_Process_Parameters_dt.Clone();
                                        DataRow[] results = R_intr_t_Process_Parameters_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Process_Parameters_dt2.ImportRow(dr);
                                        }
                                        OracleCommand R_intr_t_Process_Parameters_dt2_SC = new OracleCommand();
                                        R_intr_t_Process_Parameters_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Process_Parameters_dt2_SC.Connection = oCon;
                                        R_intr_t_Process_Parameters_dt2_SC.CommandText = "DELETE INTRCONFIG.intr_t_Process_Parameters WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Process_Parameters_dt2_SC.ExecuteNonQuery();
                                        OracleDataAdapter R_intr_t_Process_Parameters_dt2_SC_s = new OracleDataAdapter(R_intr_t_Process_Parameters_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Process_Parameters_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Process_Parameters_dt2_Insert = new StringBuilder();
											string ck_Parameter_Name = row["ck_Parameter_Name"].ToString().Replace("'", "''");
											string Parameter_Value = row["Parameter_Value"].ToString().Replace("'", "''");
                                            R_intr_t_Process_Parameters_dt2_Insert.AppendLine("INSERT INTO INTRCONFIG.intr_t_Process_Parameters " +
                                            "(ck_Process_ID,ck_Parameter_Name,Parameter_Value) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_Parameter_Name + "','" +
                                            Parameter_Value + "')");
                                            R_intr_t_Process_Parameters_dt2_Insert.AppendLine("");
                                            OracleCommand R_intr_t_Process_Parameters_dt2_Insert_Com = new OracleCommand();
                                            R_intr_t_Process_Parameters_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Process_Parameters_dt2_Insert_Com.Connection = oCon;
                                            R_intr_t_Process_Parameters_dt2_Insert_Com.CommandText = R_intr_t_Process_Parameters_dt2_Insert.ToString();
                                            R_intr_t_Process_Parameters_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Process_Parameters data has been inserted..................");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESS_PARAMETERS - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Process_Plan_Options_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Process_Plan_Options_s = new DataSet("R_intr_t_Process_Plan_Options_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Process_Plan_Options_XML_Path);
                                    R_intr_t_Process_Plan_Options_s.ReadXml(reader);
                                    if (R_intr_t_Process_Plan_Options_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Process_Plan_Options_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Process_Plan_Options_dt = R_intr_t_Process_Plan_Options_s.Tables[0];
                                        DataTable R_intr_t_Process_Plan_Options_dt2 = R_intr_t_Process_Plan_Options_dt.Clone();
                                        DataRow[] results = R_intr_t_Process_Plan_Options_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Process_Plan_Options_dt2.ImportRow(dr);
                                        }
                                        OracleCommand R_intr_t_Process_Plan_Options_dt2_SC = new OracleCommand();
                                        R_intr_t_Process_Plan_Options_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Process_Plan_Options_dt2_SC.Connection = oCon;
                                        R_intr_t_Process_Plan_Options_dt2_SC.CommandText = "DELETE INTRCONFIG.intr_t_Process_Plan_Options WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Process_Plan_Options_dt2_SC.ExecuteNonQuery();
                                        OracleDataAdapter R_intr_t_Process_Plan_Options_dt2_SC_s = new OracleDataAdapter(R_intr_t_Process_Plan_Options_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Process_Plan_Options_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Process_Plan_Options_dt2_Insert = new StringBuilder();
											string ck_Plan_Type = row["ck_Plan_Type"].ToString().Replace("'", "''");
											int Plan_Type_Reset = 0;
											if (row["Plan_Type_Reset"].ToString() == "false")
											{
												Plan_Type_Reset = 0;
											}
											else if (row["Plan_Type_Reset"].ToString() == "true")
											{
												Plan_Type_Reset = 1;
											}
											else
											{
												Plan_Type_Reset = 0;
											}
											int Plan_Type_Force_AC = 0;
											if (row["Plan_Type_Force_AC"].ToString() == "false")
											{
												Plan_Type_Force_AC = 0;
											}
											else if (row["Plan_Type_Force_AC"].ToString() == "true")
											{
												Plan_Type_Force_AC = 1;
											}
											else
											{
												Plan_Type_Force_AC = 0;
											}
                                            R_intr_t_Process_Plan_Options_dt2_Insert.Append("INSERT INTO INTRCONFIG.intr_t_Process_Plan_Options " +
                                            "(ck_Process_ID,ck_Plan_Type,Plan_Type_Reset," +
                                            "Plan_Type_Reset_Amount,Plan_Type_Force_AC,ck_Process_Field_Order) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_Plan_Type + "'," +
                                            Plan_Type_Reset + "," +
                                            row["Plan_Type_Reset_Amount"].ToString() + "," +
                                            Plan_Type_Force_AC + "," +
                                            row["ck_Process_Field_Order"].ToString() + ")");
                                            OracleCommand R_intr_t_Process_Plan_Options_dt2_Insert_Com = new OracleCommand();
                                            R_intr_t_Process_Plan_Options_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Process_Plan_Options_dt2_Insert_Com.Connection = oCon;
                                            R_intr_t_Process_Plan_Options_dt2_Insert_Com.CommandText = R_intr_t_Process_Plan_Options_dt2_Insert.ToString();
                                            R_intr_t_Process_Plan_Options_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Process_Plan_Options data has been inserted...............");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESS_PLAN_OPTIONS - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Process_Schedule_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Process_Schedule_s = new DataSet("R_intr_t_Process_Schedule_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Process_Schedule_XML_Path);
                                    R_intr_t_Process_Schedule_s.ReadXml(reader);
                                    if (R_intr_t_Process_Schedule_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Process_Schedule_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Process_Schedule_dt = R_intr_t_Process_Schedule_s.Tables[0];
                                        DataTable R_intr_t_Process_Schedule_dt2 = R_intr_t_Process_Schedule_dt.Clone();
                                        DataRow[] results = R_intr_t_Process_Schedule_dt.Select("PK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Process_Schedule_dt2.ImportRow(dr);
                                        }
                                        OracleCommand R_intr_t_Process_Schedule_dt2_SC = new OracleCommand();
                                        R_intr_t_Process_Schedule_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Process_Schedule_dt2_SC.Connection = oCon;
                                        R_intr_t_Process_Schedule_dt2_SC.CommandText = "DELETE INTRCONFIG.intr_t_Process_Schedule WHERE pk_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Process_Schedule_dt2_SC.ExecuteNonQuery();
                                        OracleDataAdapter R_intr_t_Process_Schedule_dt2_SC_s = new OracleDataAdapter(R_intr_t_Process_Schedule_dt2_SC);
                                        
                                        
                                        int Calendar_Day = 0;
                                        int No_Of_Intervals = 0;
                                        int pk_Process_ID = 0;
                                        int Schedule_Type = 0;
                                        int Scheduled = 0;
                                        foreach (DataRow row in R_intr_t_Process_Schedule_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Process_Schedule_dt2_Insert = new StringBuilder();
                                            string Start_Date = row["Start_Date"].ToString();
                                            string End_Date = row["End_Date"].ToString();
                                            string Run_Time = row["Run_Time"].ToString();
                                            string Next_Run = row["Next_Run"].ToString();
                                            string Last_Run = row["Last_Run"].ToString();
											string Scheduled_string = row["Scheduled"].ToString();
											string Schedule_Type_string = row["Schedule_Type"].ToString();
											string Sched_Username = row["Sched_Username"].ToString().Replace("'", "''");
											string Sched_Password = row["Sched_Password"].ToString().Replace("'", "''");
                                            Schedule_Type = Convert.ToInt32(Schedule_Type_string);

                                            if (Scheduled_string == "false")
                                            {
                                                Scheduled = 0;
                                            }
                                            else if (Scheduled_string == "")
                                            {
                                                Scheduled = 0;
                                            }
                                            else if (Scheduled_string == null)
                                            {
                                                Scheduled = 0;
                                            }
                                            else if (Scheduled_string == "true")
                                            {
                                                Scheduled = 1;
                                            }
                                            string Run_Sunday_Str = row["Run_Sunday"].ToString();
                                            int Run_Sunday = 0;
                                            if (Run_Sunday_Str == "false")
                                            {
                                                Run_Sunday = 0;
                                            }
                                            else if (Run_Sunday_Str == "")
                                            {
                                                Run_Sunday = 0;
                                            }
                                            else if (Run_Sunday_Str == null)
                                            {
                                                Run_Sunday = 0;
                                            }
                                            else if (Run_Sunday_Str == "true")
                                            {
                                                Run_Sunday = 1;
                                            }
                                            string Run_Monday_Str = row["Run_Monday"].ToString();
                                            int Run_Monday = 0;
                                            if (Run_Monday_Str == "false")
                                            {
                                                Run_Monday = 0;
                                            }
                                            else if (Run_Monday_Str == "")
                                            {
                                                Run_Monday = 0;
                                            }
                                            else if (Run_Monday_Str == null)
                                            {
                                                Run_Monday = 0;
                                            }
                                            else if (Run_Monday_Str == "true")
                                            {
                                                Run_Monday = 1;
                                            }
                                            string Run_Tuesday_Str = row["Run_Tuesday"].ToString();
                                            int Run_Tuesday = 0;
                                            if (Run_Tuesday_Str == "false")
                                            {
                                                Run_Tuesday = 0;
                                            }
                                            else if (Run_Tuesday_Str == "")
                                            {
                                                Run_Tuesday = 0;
                                            }
                                            else if (Run_Tuesday_Str == null)
                                            {
                                                Run_Tuesday = 0;
                                            }
                                            else if (Run_Tuesday_Str == "true")
                                            {
                                                Run_Tuesday = 1;
                                            }
                                            string Run_Wednesday_Str = row["Run_Wednesday"].ToString();
                                            int Run_Wednesday = 0;
                                            if (Run_Wednesday_Str == "false")
                                            {
                                                Run_Wednesday = 0;
                                            }
                                            else if (Run_Wednesday_Str == "")
                                            {
                                                Run_Wednesday = 0;
                                            }
                                            else if (Run_Wednesday_Str == null)
                                            {
                                                Run_Wednesday = 0;
                                            }
                                            else if (Run_Wednesday_Str == "true")
                                            {
                                                Run_Wednesday = 1;
                                            }
                                            string Run_Thursday_Str = row["Run_Thursday"].ToString();
                                            int Run_Thursday = 0;
                                            if (Run_Thursday_Str == "false")
                                            {
                                                Run_Thursday = 0;
                                            }
                                            else if (Run_Thursday_Str == "")
                                            {
                                                Run_Thursday = 0;
                                            }
                                            else if (Run_Thursday_Str == null)
                                            {
                                                Run_Thursday = 0;
                                            }
                                            else if (Run_Thursday_Str == "true")
                                            {
                                                Run_Thursday = 1;
                                            }
                                            string Run_Friday_Str = row["Run_Friday"].ToString();
                                            int Run_Friday = 0;
                                            if (Run_Friday_Str == "false")
                                            {
                                                Run_Friday = 0;
                                            }
                                            else if (Run_Friday_Str == "")
                                            {
                                                Run_Friday = 0;
                                            }
                                            else if (Run_Friday_Str == null)
                                            {
                                                Run_Friday = 0;
                                            }
                                            else if (Run_Friday_Str == "true")
                                            {
                                                Run_Friday = 1;
                                            }
                                            string Run_Saturday_Str = row["Run_Saturday"].ToString();
                                            int Run_Saturday = 0;
                                            if (Run_Saturday_Str == "false")
                                            {
                                                Run_Saturday = 0;
                                            }
                                            else if (Run_Saturday_Str == "")
                                            {
                                                Run_Saturday = 0;
                                            }
                                            else if (Run_Saturday_Str == null)
                                            {
                                                Run_Saturday = 0;
                                            }
                                            else if (Run_Saturday_Str == "true")
                                            {
                                                Run_Saturday = 1;
                                            }

                                            Calendar_Day = Convert.ToInt32(row["Calendar_Day"]);
                                            No_Of_Intervals = Convert.ToInt32(row["No_Of_Intervals"]);
                                            pk_Process_ID = Convert.ToInt32(row["pk_Process_ID"]);

                                            R_intr_t_Process_Schedule_dt2_Insert.Append("INSERT INTO INTRCONFIG.intr_t_Process_Schedule " +
                                            "(pk_Process_ID,Scheduled,Start_Date," +
                                            "End_Date,Run_Time,Next_Run," +
                                            "Last_Run,Schedule_Type,Run_Sunday," +
                                            "Run_Monday,Run_Tuesday,Run_Wednesday," +
                                            "Run_Thursday,Run_Friday,Run_Saturday," +
                                            "Calendar_Day,Interval,No_Of_Intervals," +
                                            "Sched_Username,Sched_Password) " +
                                            "VALUES (" + pk_Process_ID + "," +
                                            Scheduled + "," +
                                            "to_date('" + Start_Date + "','mm/dd/yyyy HH:MI:SS AM')," +
                                            "to_date('" + End_Date + "','mm/dd/yyyy HH:MI:SS AM')," +
                                            "to_date('" + Run_Time + "','mm/dd/yyyy HH:MI:SS AM')," +
                                            "to_date('" + Next_Run + "','mm/dd/yyyy HH:MI:SS AM')," +
                                            "to_date('" + Last_Run + "','mm/dd/yyyy HH:MI:SS AM')," +
                                            Schedule_Type + "," +
                                            Run_Sunday + "," +
                                            Run_Monday + "," +
                                            Run_Tuesday + "," +
                                            Run_Wednesday + "," +
                                            Run_Thursday + "," +
                                            Run_Friday + "," +
                                            Run_Saturday + "," +
                                            Calendar_Day + ",'" +
                                            row["Interval"].ToString() + "'," +
                                            No_Of_Intervals + ",'" +
                                            Sched_Username + "','" +
                                            Sched_Password + "')");
                                            OracleCommand R_intr_t_Process_Schedule_dt2_Insert_Com = new OracleCommand();
                                            R_intr_t_Process_Schedule_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Process_Schedule_dt2_Insert_Com.Connection = oCon;
                                            R_intr_t_Process_Schedule_dt2_Insert_Com.CommandText = R_intr_t_Process_Schedule_dt2_Insert.ToString();
                                            R_intr_t_Process_Schedule_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Process_Schedule data has been inserted................");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESS_SCHEDULE - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Process_SpecificTxTypes_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Process_SpecificTxTypes_s = new DataSet("R_intr_t_Process_SpecificTxTypes_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Process_SpecificTxTypes_XML_Path);
                                    R_intr_t_Process_SpecificTxTypes_s.ReadXml(reader);
                                    if (R_intr_t_Process_SpecificTxTypes_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Process_SpecificTxTypes_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Process_SpecificTxTypes_dt = R_intr_t_Process_SpecificTxTypes_s.Tables[0];
                                        DataTable R_intr_t_Process_SpecificTxTypes_dt2 = R_intr_t_Process_SpecificTxTypes_dt.Clone();
                                        DataRow[] results = R_intr_t_Process_SpecificTxTypes_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Process_SpecificTxTypes_dt2.ImportRow(dr);
                                        }
                                        OracleCommand R_intr_t_Process_SpecificTxTypes_dt2_SC = new OracleCommand();
                                        R_intr_t_Process_SpecificTxTypes_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Process_SpecificTxTypes_dt2_SC.Connection = oCon;
                                        R_intr_t_Process_SpecificTxTypes_dt2_SC.CommandText = "DELETE INTRCONFIG.intr_t_Process_SpecificTxTypes WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Process_SpecificTxTypes_dt2_SC.ExecuteNonQuery();
                                        OracleDataAdapter R_intr_t_Process_SpecificTxTypes_dt2_SC_s = new OracleDataAdapter(R_intr_t_Process_SpecificTxTypes_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Process_SpecificTxTypes_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Process_SpecificTxTypes_dt2_Insert = new StringBuilder();
											string ck_TxType = row["ck_TxType"].ToString().Replace("'", "''");
											int Closes_Account = 0;
                                            if (row["Closes_Account"].ToString() == "false")
                                            {
                                                Closes_Account = 0;
                                            }
                                            else if (row["Closes_Account"].ToString() == null)
                                            {
                                                Closes_Account = 0;
                                            }
                                            else if (row["Closes_Account"].ToString() == "")
                                            {
                                                Closes_Account = 0;
                                            }
                                            else
                                            {
                                                Closes_Account = 1;
                                            }
                                            R_intr_t_Process_SpecificTxTypes_dt2_Insert.Append("INSERT INTO INTRCONFIG.intr_t_Process_SpecificTxTypes " +
                                            "(ck_Process_ID,ck_TxType,Closes_Account) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_TxType + "'," +
                                            Closes_Account + ")");
                                            OracleCommand R_intr_t_Process_SpecificTxTypes_dt2_Insert_Com = new OracleCommand();
                                            R_intr_t_Process_SpecificTxTypes_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Process_SpecificTxTypes_dt2_Insert_Com.Connection = oCon;
                                            R_intr_t_Process_SpecificTxTypes_dt2_Insert_Com.CommandText = R_intr_t_Process_SpecificTxTypes_dt2_Insert.ToString();
                                            R_intr_t_Process_SpecificTxTypes_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Process_SpecificTxTypes data has been inserted...................");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESS_SPECifICTXTYPES - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Process_Terms_ForUpload_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Process_Terms_ForUpload_s = new DataSet("R_intr_t_Process_Terms_ForUpload_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Process_Terms_ForUpload_XML_Path);
                                    R_intr_t_Process_Terms_ForUpload_s.ReadXml(reader);
                                    if (R_intr_t_Process_Terms_ForUpload_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Process_Terms_ForUpload_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Process_Terms_ForUpload_dt = R_intr_t_Process_Terms_ForUpload_s.Tables[0];
                                        DataTable R_intr_t_Process_Terms_ForUpload_dt2 = R_intr_t_Process_Terms_ForUpload_dt.Clone();
                                        DataRow[] results = R_intr_t_Process_Terms_ForUpload_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Process_Terms_ForUpload_dt2.ImportRow(dr);
                                        }
                                        OracleCommand R_intr_t_Process_Terms_ForUpload_dt2_SC = new OracleCommand();
                                        R_intr_t_Process_Terms_ForUpload_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Process_Terms_ForUpload_dt2_SC.Connection = oCon;
                                        R_intr_t_Process_Terms_ForUpload_dt2_SC.CommandText = "DELETE INTRCONFIG.intr_t_Process_Terms_ForUpload WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Process_Terms_ForUpload_dt2_SC.ExecuteNonQuery();
                                        OracleDataAdapter R_intr_t_Process_Terms_ForUpload_dt2_SC_s = new OracleDataAdapter(R_intr_t_Process_Terms_ForUpload_dt2_SC);
                                        
                                        foreach (DataRow row in R_intr_t_Process_Terms_ForUpload_dt2.Rows)
                                        {
                                            
                                            
                                            StringBuilder R_intr_t_Process_Terms_ForUpload_dt2_Insert = new StringBuilder();
											string ck_Term_ID = row["ck_Term_ID"].ToString().Replace("'", "''");
											int ck_Process_ID = 0;
											ck_Process_ID = Convert.ToInt32(row["ck_Process_ID"]);
											int Upload = 0;
                                            string Upload_string = row["Upload"].ToString();
                                            if (Upload_string == "false")
                                            {
                                                Upload = 0;
                                            }
                                            else if (Upload_string == "")
                                            {
                                                Upload = 0;
                                            }
											else if (Upload_string == " ")
                                            {
                                                Upload = 0;
                                            }
											else
                                            {
                                                Upload = 1;
                                            }

                                            R_intr_t_Process_Terms_ForUpload_dt2_Insert.Append("INSERT INTO INTRCONFIG.intr_t_Process_Terms_ForUpload " +
                                            "(ck_Process_ID,ck_Term_ID,Upload) " +
                                            "VALUES (" + ck_Process_ID + ",'" +
                                            ck_Term_ID + "'," +
                                            Upload + ")");
                                            OracleCommand R_intr_t_Process_Terms_ForUpload_dt2_Insert_Com = new OracleCommand();
                                            R_intr_t_Process_Terms_ForUpload_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Process_Terms_ForUpload_dt2_Insert_Com.Connection = oCon;
                                            R_intr_t_Process_Terms_ForUpload_dt2_Insert_Com.CommandText = R_intr_t_Process_Terms_ForUpload_dt2_Insert.ToString();
                                            R_intr_t_Process_Terms_ForUpload_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Process_Terms_ForUpload data has been inserted...............");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESS_TERMS_FORUPLOAD - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Process_Translator_XML_Path))
                                try
                                {
                                    DataSet R_intr_t_Process_Translator_s = new DataSet("R_intr_t_Process_Translator_s");
                                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Process_Translator_XML_Path);
                                    R_intr_t_Process_Translator_s.ReadXml(reader);
                                    if (R_intr_t_Process_Translator_s.Tables.Count == 0)
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine(intr_t_Process_Translator_XML_Path.ToString() + " does not have any data...");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                    else
                                    {
                                        DataTable R_intr_t_Process_Translator_dt = R_intr_t_Process_Translator_s.Tables[0];
                                        DataTable R_intr_t_Process_Translator_dt2 = R_intr_t_Process_Translator_dt.Clone();
                                        DataRow[] results = R_intr_t_Process_Translator_dt.Select("CK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                        foreach (DataRow dr in results)
                                        {
                                            R_intr_t_Process_Translator_dt2.ImportRow(dr);
                                        }
                                        OracleCommand R_intr_t_Process_Translator_dt2_SC = new OracleCommand();
                                        R_intr_t_Process_Translator_dt2_SC.CommandType = CommandType.Text;
                                        R_intr_t_Process_Translator_dt2_SC.Connection = oCon;
                                        R_intr_t_Process_Translator_dt2_SC.CommandText = "DELETE INTRCONFIG.intr_t_Process_Translator WHERE ck_Process_ID IN " + PK_PROCESS_ID_STRING_RS;
                                        R_intr_t_Process_Translator_dt2_SC.ExecuteNonQuery();
                                        OracleDataAdapter R_intr_t_Process_Translator_dt2_SC_s = new OracleDataAdapter(R_intr_t_Process_Translator_dt2_SC);

                                        foreach (DataRow row in R_intr_t_Process_Translator_dt2.Rows)
                                        {
                                            StringBuilder R_intr_t_Process_Translator_dt2_Insert = new StringBuilder();
											string ck_Process_Field_Name = row["ck_Process_Field_Name"].ToString().Replace("'", "''");
											string ck_Process_Field_Value = row["ck_Process_Field_Value"].ToString().Replace("'", "''");
											string Translated_Value = row["Translated_Value"].ToString().Replace("'", "''");
                                            R_intr_t_Process_Translator_dt2_Insert.Append("INSERT INTO INTRCONFIG.intr_t_Process_Translator " +
                                            "(ck_Process_ID,ck_Process_Field_Name,ck_Process_Field_Value," +
                                            "Translated_Value,Ck_process_field_order) " +
                                            "VALUES (" + row["ck_Process_ID"].ToString() + ",'" +
                                            ck_Process_Field_Name + "','" +
                                            ck_Process_Field_Value + "','" +
                                            Translated_Value + "'," +
                                            row["Ck_process_field_order"].ToString() + ")");
                                            OracleCommand R_intr_t_Process_Translator_dt2_Insert_Com = new OracleCommand();
                                            R_intr_t_Process_Translator_dt2_Insert_Com.CommandType = CommandType.Text;
                                            R_intr_t_Process_Translator_dt2_Insert_Com.Connection = oCon;
                                            R_intr_t_Process_Translator_dt2_Insert_Com.CommandText = R_intr_t_Process_Translator_dt2_Insert.ToString();
                                            R_intr_t_Process_Translator_dt2_Insert_Com.ExecuteNonQuery();
                                        }
                                        RESTORE_PROCESS_TEXT.AppendLine("intr_t_Process_Translator data has been inserted...............");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_PROCESS_TRANSLATOR - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            if (File.Exists(intr_t_Status_XML_Path))
                                try
                                {
                                    if (RESTORE_STATUS.Checked)
                                    {
                                        DataSet R_intr_t_Status_s = new DataSet("R_intr_t_Status_s");
                                        System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(intr_t_Status_XML_Path);
                                        R_intr_t_Status_s.ReadXml(reader);
                                        if (R_intr_t_Status_s.Tables.Count == 0)
                                        {
                                            RESTORE_PROCESS_TEXT.AppendLine(intr_t_Status_XML_Path.ToString() + " does not have any data...");
                                            RESTORE_PROCESS_TEXT.AppendLine("");
                                        }
                                        else
                                        {
                                            DataTable R_intr_t_Status_dt = R_intr_t_Status_s.Tables[0];
                                            DataTable R_intr_t_Status_dt2 = R_intr_t_Status_dt.Clone();
                                            DataRow[] results = R_intr_t_Status_dt.Select("FK_PROCESS_ID IN " + PK_PROCESS_ID_STRING_RS);
                                            foreach (DataRow dr in results)
                                            {
                                                R_intr_t_Status_dt2.ImportRow(dr);
                                            }
                                            OracleCommand R_intr_t_Status_dt2_SC = new OracleCommand();
                                            R_intr_t_Status_dt2_SC.CommandType = CommandType.Text;
                                            R_intr_t_Status_dt2_SC.Connection = oCon;
                                            R_intr_t_Status_dt2_SC.CommandText = "ALTER TRIGGER INTRCONFIG.TRI_SEQ_INTR_T_STATUS DISABLE";
                                            R_intr_t_Status_dt2_SC.ExecuteNonQuery();
                                            OracleDataAdapter R_intr_t_Status_dt2_SC_s = new OracleDataAdapter(R_intr_t_Status_dt2_SC);
                                            
                                            foreach (DataRow row in R_intr_t_Status_dt2.Rows)
                                            {
                                                int PK_OPERATION_ID = 0;
												int FK_PROCESS_ID = 0;
												int SUCCESS = 0;
												int No_Processed = 0;
												int No_New = 0;
												int No_Changes = 0;
												int No_Non_Critical_Errors = 0;
												PK_OPERATION_ID = Convert.ToInt32(row["pk_Operation_ID"]);
                                                FK_PROCESS_ID = Convert.ToInt32(row["fk_Process_ID"]);
                                                R_intr_t_Status_dt2_SC.CommandText = "DELETE INTRCONFIG.intr_t_Status WHERE fk_Process_ID = " + FK_PROCESS_ID + " OR PK_OPERATION_ID = " + PK_OPERATION_ID;
                                                R_intr_t_Status_dt2_SC.ExecuteNonQuery();
                                                string SUCCESS_STRING = row["Success"].ToString();
                                                if (SUCCESS_STRING == "false")
                                                {
                                                    SUCCESS = 0;
                                                }

                                                else
                                                {
                                                    SUCCESS = 1;
                                                }
                                                No_Processed = Convert.ToInt32(row["No_Processed"]);
                                                No_New = Convert.ToInt32(row["No_New"]);
                                                No_Changes = Convert.ToInt32(row["No_Changes"]);
                                                No_Non_Critical_Errors = Convert.ToInt32(row["No_Non_Critical_Errors"]);
                                                StringBuilder R_intr_t_Status_dt2_Insert = new StringBuilder();
                                                string Start_Date = row["Start_Date"].ToString();
                                                string Completion_Date = row["Completion_Date"].ToString();
                                                string Status_Message = row["Status_Message"].ToString();
                                                R_intr_t_Status_dt2_Insert.Append("INSERT INTO INTRCONFIG.intr_t_Status " +
                                                "(pk_Operation_ID,fk_Process_ID,Start_Date," +
                                                "Completion_Date,Success,No_Processed," +
                                                "No_New,No_Changes,No_Non_Critical_Errors," +
                                                "Status_Message) " +
                                                "VALUES (" + PK_OPERATION_ID + "," +
                                                FK_PROCESS_ID + "," +
                                                "to_date('" + Start_Date + "','mm/dd/yyyy HH:MI:SS AM')," +
                                                "to_date('" + Completion_Date + "','mm/dd/yyyy HH:MI:SS PM')," +
                                                SUCCESS + "," +
                                                No_Processed + "," +
                                                No_New + "," +
                                                No_Changes + "," +
                                                No_Non_Critical_Errors + "," +
                                                ":Status_Message)");
                                                string sql = R_intr_t_Status_dt2_Insert.ToString();
                                                OracleCommand R_intr_t_Status_dt2_Insert_Com = new OracleCommand(sql,oCon);
                                                OracleParameter param1 = R_intr_t_Status_dt2_Insert_Com.Parameters.Add("Status_Message", OracleDbType.Clob);
                                                param1.Direction = ParameterDirection.Input;
                                                param1.Value = Status_Message;
                                                R_intr_t_Status_dt2_Insert_Com.ExecuteNonQuery();

                                            }
                                            R_intr_t_Status_dt2_SC.CommandText = "ALTER TRIGGER INTRCONFIG.TRI_SEQ_INTR_T_STATUS ENABLE";
                                            R_intr_t_Status_dt2_SC.ExecuteNonQuery();
                                            RESTORE_PROCESS_TEXT.AppendLine("TRIGGER INTRCONFIG.TRI_SEQ_INTR_T_STATUS has been re-enabled..............");
                                            RESTORE_PROCESS_TEXT.AppendLine("");
                                            RESTORE_PROCESS_TEXT.AppendLine("intr_t_Status data has been inserted..............");
                                            RESTORE_PROCESS_TEXT.AppendLine("");
                                        }
                                    }
                                    else
                                    {
                                        RESTORE_PROCESS_TEXT.AppendLine("INTR_T_STATUS data insert has been bypassed");
                                        RESTORE_PROCESS_TEXT.AppendLine("");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    RESTORE_PROCESS_TEXT.AppendLine("INTR_T_STATUS - " + ex.Message);
                                    RESTORE_PROCESS_TEXT.AppendLine("");
                                }
                            RESTORE_PROCESS_TEXT.AppendLine("Rebuilding the Constraints....................");
                            RESTORE_PROCESS_TEXT.AppendLine("");
                            OracleCommand R_ADD_Constraints = new OracleCommand();
                            R_ADD_Constraints.CommandType = CommandType.Text;
                            R_ADD_Constraints.Connection = oCon;
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_L_U_T_CONFIGURATIONS ENABLE CONSTRAINT PK_INTR_T_L_U_T_CONFIGURATI232";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_CONFIGURATION_DEFAULTS ENABLE CONSTRAINT PK_INTR_T_CONFIGURATION_DEF233";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_CONFIGURATION_DEFAULTS ENABLE  CONSTRAINT FK_INTR_T_CONFIGURATION_DEF592";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_DATA_DICTIONARY ENABLE CONSTRAINT PK_INTR_T_DATA_DICTIONARY";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_DATA_DICTIONARY ENABLE CONSTRAINT FK_INTR_T_DATA_DICTIONARY";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_INCIDENT_TRANSLATOR ENABLE CONSTRAINT PK_INTR_INCIDENT_TRANSLATOR001";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_PROCESS_APPLN_PERIODS ENABLE CONSTRAINT PK_INTR_T_PROCESS_APPLICATI15";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_PROCESS_APPLN_PERIODS ENABLE CONSTRAINT FK_INTR_T_PROCESS_APPLICATI20";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_PROCESS_CONFIG_STATUS ENABLE CONSTRAINT PK_INTR_T_PROCESS_CONFIG_ST18";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_PROCESS_CONFIG_STATUS ENABLE  CONSTRAINT FK_INTR_T_PROCESS_CONFIG_ST19";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_PROCESS_CUSTPROC ENABLE CONSTRAINT PK_INTR_T_PROCESS_CUSTPROC14";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_PROCESS_CUSTPROC ENABLE CONSTRAINT FK_INTR_T_PROCESS_CUSTPROC15";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_PROCESS_PARAMETERS ENABLE CONSTRAINT PK_INTR_T_PROCESS_PARAMETERS";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_PROCESS_PARAMETERS ENABLE CONSTRAINT FK_INTR_T_PROCESS_PARAMETERS";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_PROCESS_PLAN_OPTIONS ENABLE CONSTRAINT PK_INTR_T_PROCESS_PLANOPTIONS";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_PROCESS_PLAN_OPTIONS ENABLE CONSTRAINT FK_INTR_T_PROCESS_PLANOPTIONS";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_PROCESS_SCHEDULE ENABLE CONSTRAINT PK_INTR_T_PROCESS_SCHEDULE";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_PROCESS_SCHEDULE ENABLE CONSTRAINT FK_INTR_T_PROCESS_SCHEDULE100";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_PROCESS_SPECifICTXTYPES ENABLE CONSTRAINT PK_INTR_T_PROCESS_SPECifIC_17";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_PROCESS_SPECifICTXTYPES ENABLE CONSTRAINT FK_INTR_T_PROCESS_SPECifIC_17";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_PROCESS_TERMS_FORUPLOAD ENABLE CONSTRAINT PK_INTR_T_PROCESS_TERMS_FOR16";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_PROCESS_TERMS_FORUPLOAD ENABLE CONSTRAINT FK_INTR_T_PROCESS_TERMS_FOR18";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_PROCESS_TRANSLATOR ENABLE CONSTRAINT PK_INTR_T_PROCESS_TRANSLATO12";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_PROCESS_TRANSLATOR ENABLE CONSTRAINT FK_INTR_T_PROCESS_TRANSLATO25";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_EXCLUSIONS ENABLE CONSTRAINT TC_INTR_T_EXCLUSIONS8164";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_FIELD_MAP ENABLE CONSTRAINT PK_INTR_T_FIELD_MAP";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_FIELD_MAP ENABLE CONSTRAINT FK_INTR_T_FIELD_MAP";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_FIELD_MAP ENABLE CONSTRAINT FK_INTR_T_FIELD_MAP100";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "ALTER TABLE INTRCONFIG.INTR_T_STATUS ENABLE CONSTRAINT PK_INTR_T_STATUS";
                            R_ADD_Constraints.ExecuteNonQuery();
                            R_ADD_Constraints.CommandText = "Commit";
                            R_ADD_Constraints.ExecuteNonQuery();
                            RESTORE_PROCESS_TEXT.AppendLine("Constraints Rebuilt....................");
                            RESTORE_PROCESS_TEXT.AppendLine("");
                            RESTORE_PROCESS_TEXT.AppendLine("Importing of selected Interfaces have been completed................");
                            RESTORE_PROCESS_TEXT.AppendLine("");
                        }
                        catch (Exception ex)
                        {
                            RESTORE_PROCESS_TEXT.AppendLine(ex.Message);
                            RESTORE_PROCESS_TEXT.AppendLine("");
                        }
                    }
                }
                catch (Exception ex)
                {
                    RESTORE_PROCESS_TEXT.AppendLine(ex.Message);
                    RESTORE_PROCESS_TEXT.AppendLine("");
                }
            RESTORE_ITEMS_COMPLETED_TXTBOX.Text = RESTORE_PROCESS_TEXT.ToString();
        }

        private void CHECK_4_CONFLICT_IDs_BUT_Click(object sender, EventArgs e)
        {
            StringBuilder PK_PROCESS_ID_STRING_GV2 = new StringBuilder();
            PK_PROCESS_ID_STRING_GV2.Append("(");
            foreach (DataGridViewCell cell in this.dataGridView2.SelectedCells)
            {
                if (cell.ColumnIndex == 0)
                {
                    PK_PROCESS_ID_STRING_GV2.Append(cell.Value.ToString() + ",");
                }
            }
            PK_PROCESS_ID_STRING_GV2.Remove((PK_PROCESS_ID_STRING_GV2.Length - 1), 1);
            PK_PROCESS_ID_STRING_GV2.Append(")");

            if (DB_TYPE_COMBO.Text.Equals("SQL"))
            {
                String CONNECTION_STRING =
                              "Server=" + SERVER_CONNECTION_TEXT.Text + ";" +
                              "DataBase=INTRCONFIG;" +
                              "Uid=" + USERNAME_TEXT.Text + ";" +
                              "Pwd=" + PASSWORD_TEXT.Text + ";";
                CONNECTION_STRING_TEXT_BOX.Text = CONNECTION_STRING;

                try
                {
                    SqlConnection sCon = new SqlConnection(CONNECTION_STRING);
                    sCon.Open();
                    SqlCommand s_R_Tmp = new SqlCommand();
                    s_R_Tmp.CommandType = CommandType.Text;
                    s_R_Tmp.Connection = sCon;
                    s_R_Tmp.CommandText = "SELECT pk_process_id,Process_Name FROM intr_t_Processes WHERE pk_process_id IN " + PK_PROCESS_ID_STRING_GV2;
                    SqlDataAdapter intr_t_Processes_DB_Conflict_da_s = new SqlDataAdapter(s_R_Tmp);
                    DataSet intr_t_Processes_DB_Conflict_ds_s = new DataSet();
                    intr_t_Processes_DB_Conflict_da_s.Fill(intr_t_Processes_DB_Conflict_ds_s, "intr_t_Processes_DB_Conflict_ds_s");
                    dataGridView3.DataSource = intr_t_Processes_DB_Conflict_ds_s;
                    dataGridView3.DataMember = "intr_t_Processes_DB_Conflict_ds_s";
                    DataGridViewColumn column = dataGridView3.Columns[1];
                    column.Width = 250;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (DB_TYPE_COMBO.Text.Equals("Oracle"))
            {
                string CONNECTION_STRING = "User Id=" + USERNAME_TEXT.Text + ";Password=" + PASSWORD_TEXT.Text + ";Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + ORA_HOST_TEXT.Text + ")(PORT=" + DB_PORT_TEXT.Text + "))" + "(CONNECT_DATA=(SID=" + SERVER_CONNECTION_TEXT.Text + ")));";
                try
                {
                    OracleConnection oCon = new OracleConnection(CONNECTION_STRING);
                    oCon.Open();
                    OracleCommand oTmp = new OracleCommand();
                    oTmp.CommandType = CommandType.Text;
                    oTmp.Connection = oCon;
                    oTmp.CommandText = "SELECT pk_process_id,Process_Name FROM INTRCONFIG.intr_t_Processes WHERE pk_process_id IN " + PK_PROCESS_ID_STRING_GV2;
                    OracleDataAdapter intr_t_Processes_DB_Conflict_da_o = new OracleDataAdapter(oTmp);
                    DataSet intr_t_Processes_DB_Conflict_ds_o = new DataSet();
                    intr_t_Processes_DB_Conflict_da_o.Fill(intr_t_Processes_DB_Conflict_ds_o, "intr_t_Processes_DB_Conflict_ds_o");
                    dataGridView3.DataSource = intr_t_Processes_DB_Conflict_ds_o;
                    dataGridView3.DataMember = "intr_t_Processes_DB_Conflict_ds_o";
                    DataGridViewColumn column = dataGridView3.Columns[1];
                    column.Width = 250;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

