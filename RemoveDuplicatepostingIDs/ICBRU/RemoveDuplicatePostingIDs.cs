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

namespace RemoveDuplicatePostingIDs
{

    public partial class RemoveDuplicatePostingIDs : Form
    {
        public int oldPostingID = 0;
        public int newPostingID = 0;
        public int invoiceNo = 0;
        public RemoveDuplicatePostingIDs()
        {
            InitializeComponent();
            this.Connection_Tab.Enabled = true;
            this.INVOICE_Tab.Enabled = false;
            this.CREDITINVOICE_Tab.Enabled = false;
            this.PAYMENT_Tab.Enabled = false;
            this.TRANSFER_Tab.Enabled = false;
            this.ORA_HOST_TEXT.Enabled = false;
            this.DB_PORT_TEXT.Enabled = false;
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
                                  "DataBase=" + DB_Name_Text.Text + ";" +
                                  "Uid=" + USERNAME_TEXT.Text + ";" +
                                  "Pwd=" + PASSWORD_TEXT.Text + ";";
                    string hid_pass_txt = PASSWORD_TEXT.Text.Replace(PASSWORD_TEXT.Text, "*******");
                    string hid_pass_con_str = "Server=" + SERVER_CONNECTION_TEXT.Text + ";" +
                                  "DataBase=" + DB_Name_Text.Text + ";" +
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

        public void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if ((DB_TYPE_COMBO.Text.Equals("Select Database Type")) || (SERVER_CONNECTION_TEXT.Text.Equals("")) || (USERNAME_TEXT.Text.Equals("")) || (PASSWORD_TEXT.Text.Equals("")))
            {
                this.INVOICE_Tab.Enabled = false;
                this.CREDITINVOICE_Tab.Enabled = false;
                this.PAYMENT_Tab.Enabled = false;
                this.TRANSFER_Tab.Enabled = false;
            }
            else
            {
                this.INVOICE_Tab.Enabled = true;
                this.CREDITINVOICE_Tab.Enabled = true;
                this.PAYMENT_Tab.Enabled = true;
                this.TRANSFER_Tab.Enabled = true;
            }
            if (TabControl1.SelectedTab == Done_Tab)
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to Exit the program?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Application.Exit();
                }
                else
                {
                    TabControl1.SelectedIndex = 0;
                }

            }
            if (TabControl1.SelectedTab == INVOICE_Tab)
            {
                if (DB_TYPE_COMBO.Text.Equals("Select Database Type") || (SERVER_CONNECTION_TEXT.Text.Equals("")) || (USERNAME_TEXT.Text.Equals("")) || (PASSWORD_TEXT.Text.Equals("")))
                {
                    MessageBox.Show("Please complete connections on the connections tab.");
                    TabControl1.SelectedIndex = 0;
                }
                else if (DB_TYPE_COMBO.Text.Equals("SQL"))
                {
                    String CONNECTION_STRING =
                                  "Server=" + SERVER_CONNECTION_TEXT.Text + ";" +
                                  "DataBase=" + DB_Name_Text.Text + ";" +
                                  "Uid=" + USERNAME_TEXT.Text + ";" +
                                  "Pwd=" + PASSWORD_TEXT.Text + ";";
                    try
                    {
                        SqlConnection conn = new SqlConnection(CONNECTION_STRING);
                        try
                        {
                            SqlDataAdapter I1_da_s;
                            DataSet I1_ds_s = new DataSet();
                            conn = new SqlConnection(CONNECTION_STRING);
                            conn.Open();
                            I1_da_s = new SqlDataAdapter("SELECT acct_t_Invoice_Details.ck_Posting_ID as ID_Posting_ID, acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID as CID_Posting_ID from " + DB_Name_Text.Text + ".dbo.acct_t_Invoice_Details," + DB_Name_Text.Text + ".dbo.acct_t_Credit_Invoice_Details WHERE acct_t_Invoice_Details.ck_Posting_ID = acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID", conn);
                            I1_da_s.Fill(I1_ds_s, "I1_ds_s");
                            dataGridView1.DataSource = I1_ds_s;
                            dataGridView1.DataMember = "I1_ds_s";
                            //DataGridViewColumn DGVC1 = dataGridView1.Columns[2];
                            //DGVC1.Width = 300;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Grid 1 - " + ex.Message);
                        }
                        try
                        {
                            SqlDataAdapter I2_da_s;
                            DataSet I2_ds_s = new DataSet();
                            conn = new SqlConnection(CONNECTION_STRING);
                            conn.Open();
                            I2_da_s = new SqlDataAdapter("SELECT acct_t_Invoice_Details.ck_Posting_ID as ID_Posting_ID, acct_t_Payment_Details.payment_posting_id as PD_Posting_ID from " + DB_Name_Text.Text + ".dbo.acct_t_Invoice_Details," + DB_Name_Text.Text + ".dbo.acct_t_Payment_Details WHERE acct_t_Invoice_Details.ck_Posting_ID = acct_t_Payment_Details.payment_posting_id", conn);
                            I2_da_s.Fill(I2_ds_s, "I2_ds_s");
                            dataGridView2.DataSource = I2_ds_s;
                            dataGridView2.DataMember = "I2_ds_s";
                            //DataGridView column2 = dataGridView2.columns[2];
                            //column2.Width = 500;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Grid 1 - " + ex.Message);
                        }
                        try
                        {
                            SqlDataAdapter I3_da_s;
                            DataSet I3_ds_s = new DataSet();
                            conn = new SqlConnection(CONNECTION_STRING);
                            conn.Open();
                            I3_da_s = new SqlDataAdapter("SELECT acct_t_Invoice_Details.ck_Posting_ID as ID_Posting_ID, acct_t_Transfer.pk_Posting_ID as T_posting_ID from " + DB_Name_Text.Text + ".dbo.acct_t_Invoice_Details," + DB_Name_Text.Text + ".dbo.acct_t_Transfer WHERE acct_t_Invoice_Details.ck_Posting_ID = acct_t_Transfer.pk_Posting_ID", conn);
                            I3_da_s.Fill(I3_ds_s, "I3_ds_s");
                            dataGridView3.DataSource = I3_ds_s;
                            dataGridView3.DataMember = "I3_ds_s";
                            //DataGridView column3 = dataGridView3.columns[2];
                            //column3.Width = 500;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Grid 1 - " + ex.Message);
                        }
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
                        OracleCommand I1_OC_o = new OracleCommand();
                        I1_OC_o.CommandType = CommandType.Text;
                        I1_OC_o.Connection = oCon;
                        I1_OC_o.CommandText = "SELECT acct_t_Invoice_Details.ck_Posting_ID as ID_Posting_ID, acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID as CID_Posting_ID from " + DB_Name_Text.Text + ".acct_t_Invoice_Details," + DB_Name_Text.Text + ".acct_t_Credit_Invoice_Details WHERE acct_t_Invoice_Details.ck_Posting_ID = acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID";
                        OracleDataAdapter I1_da_o = new OracleDataAdapter(I1_OC_o);
                        DataSet I1_ds_o = new DataSet();
                        I1_da_o.Fill(I1_ds_o, "I1_ds_o");
                        dataGridView1.DataSource = I1_ds_o;
                        dataGridView1.DataMember = "I1_ds_o";
                        //DataGridView column = dataGridView1.columns[2];
                        //column.Width = 300;

                        OracleCommand I2_OC_o = new OracleCommand();
                        I2_OC_o.CommandType = CommandType.Text;
                        I2_OC_o.Connection = oCon;
                        I2_OC_o.CommandText = "SELECT acct_t_Invoice_Details.ck_Posting_ID as ID_Posting_ID, acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID as CID_Posting_ID from " + DB_Name_Text.Text + ".acct_t_Invoice_Details," + DB_Name_Text.Text + ".acct_t_Credit_Invoice_Details WHERE acct_t_Invoice_Details.ck_Posting_ID = acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID";
                        OracleDataAdapter I2_da_o = new OracleDataAdapter(I2_OC_o);
                        DataSet I2_ds_o = new DataSet();
                        I2_da_o.Fill(I2_ds_o, "I2_ds_o");
                        dataGridView2.DataSource = I2_ds_o;
                        dataGridView2.DataMember = "I2_ds_o";
                        //DataGridView column2 = dataGridView2.columns[2];
                        //column2.Width = 300;

                        OracleCommand I3_OC_o = new OracleCommand();
                        I3_OC_o.CommandType = CommandType.Text;
                        I3_OC_o.Connection = oCon;
                        I3_OC_o.CommandText = "SELECT acct_t_Invoice_Details.ck_Posting_ID as ID_Posting_ID, acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID as CID_Posting_ID from " + DB_Name_Text.Text + ".acct_t_Invoice_Details," + DB_Name_Text.Text + ".acct_t_Credit_Invoice_Details WHERE acct_t_Invoice_Details.ck_Posting_ID = acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID";
                        OracleDataAdapter I3_da_o = new OracleDataAdapter(I3_OC_o);
                        DataSet I3_ds_o = new DataSet();
                        I3_da_o.Fill(I3_ds_o, "I3_ds_o");
                        dataGridView3.DataSource = I3_ds_o;
                        dataGridView3.DataMember = "I3_ds_o";
                        //DataGridView column3 = dataGridView3.columns[2];
                        //column3.Width = 300;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            if (TabControl1.SelectedTab == CREDITINVOICE_Tab)
            {
                if (DB_TYPE_COMBO.Text.Equals("Select Database Type") || (SERVER_CONNECTION_TEXT.Text.Equals("")) || (USERNAME_TEXT.Text.Equals("")) || (PASSWORD_TEXT.Text.Equals("")))
                {
                    MessageBox.Show("Please complete connections on the connections tab.");
                    TabControl1.SelectedIndex = 0;
                }
                else if (DB_TYPE_COMBO.Text.Equals("SQL"))
                {
                    String CONNECTION_STRING =
                                  "Server=" + SERVER_CONNECTION_TEXT.Text + ";" +
                                  "DataBase=" + DB_Name_Text.Text + ";" +
                                  "Uid=" + USERNAME_TEXT.Text + ";" +
                                  "Pwd=" + PASSWORD_TEXT.Text + ";";
                    try
                    {
                        SqlConnection conn = new SqlConnection(CONNECTION_STRING);
                        try
                        {
                            SqlDataAdapter CI1_da_s;
                            DataSet CI1_ds_s = new DataSet();
                            conn = new SqlConnection(CONNECTION_STRING);
                            conn.Open();
                            CI1_da_s = new SqlDataAdapter("SELECT acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID as CID_Posting_ID,acct_t_Payment_Details.payment_posting_id as PD_Posting_ID from " + DB_Name_Text.Text + ".dbo.acct_t_Credit_Invoice_Details," + DB_Name_Text.Text + ".dbo.acct_t_Payment_Details WHERE acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID = acct_t_Payment_Details.payment_posting_id", conn);
                            CI1_da_s.Fill(CI1_ds_s, "CI1_ds_s");
                            dataGridView6.DataSource = CI1_ds_s;
                            dataGridView6.DataMember = "CI1_ds_s";
                            //DataGridView//column //column = dataGridView6.columns[2];
                            //column.Width = 300;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Grid 1 - " + ex.Message);
                        }
                        try
                        {
                            SqlDataAdapter CI2_da_s;
                            DataSet CI2_ds_s = new DataSet();
                            conn = new SqlConnection(CONNECTION_STRING);
                            conn.Open();
                            CI2_da_s = new SqlDataAdapter("SELECT acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID as CID_Posting_ID, acct_t_Transfer.pk_Posting_ID as T_posting_ID from " + DB_Name_Text.Text + ".dbo.acct_t_Credit_Invoice_Details," + DB_Name_Text.Text + ".dbo.acct_t_Transfer WHERE acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID = acct_t_Transfer.pk_Posting_ID", conn);
                            CI2_da_s.Fill(CI2_ds_s, "CI2_ds_s");
                            dataGridView5.DataSource = CI2_ds_s;
                            dataGridView5.DataMember = "CI2_ds_s";
                            //DataGridView//column //column2 = dataGridView5.columns[2];
                            //column2.Width = 300;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Grid 2 - " + ex.Message);

                        }
                        try
                        {
                            SqlDataAdapter CI3_da_s;
                            DataSet CI3_ds_s = new DataSet();
                            conn = new SqlConnection(CONNECTION_STRING);
                            conn.Open();
                            CI3_da_s = new SqlDataAdapter("SELECT acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID as CID_Posting_ID, acct_t_Transfer.pk_Posting_ID as T_posting_ID from " + DB_Name_Text.Text + ".dbo.acct_t_Credit_Invoice_Details," + DB_Name_Text.Text + ".dbo.acct_t_Transfer WHERE acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID = acct_t_Transfer.pk_Posting_ID", conn);
                            CI3_da_s.Fill(CI3_ds_s, "CI3_ds_s");
                            dataGridView4.DataSource = CI3_ds_s;
                            dataGridView4.DataMember = "CI3_ds_s";
                            //DataGridView//column //column3 = dataGridView4.columns[2];
                            //column3.Width = 300;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Grid 3 - " + ex.Message);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Credit Invoice - " + ex.Message);

                    }
                }
                else if (DB_TYPE_COMBO.Text.Equals("Oracle"))
                {
                    string CONNECTION_STRING = "User Id=" + USERNAME_TEXT.Text + ";Password=" + PASSWORD_TEXT.Text + ";Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + ORA_HOST_TEXT.Text + ")(PORT=" + DB_PORT_TEXT.Text + "))" + "(CONNECT_DATA=(SID=" + SERVER_CONNECTION_TEXT.Text + ")));";
                    try
                    {
                        OracleConnection oCon = new OracleConnection(CONNECTION_STRING);
                        oCon.Open();
                        OracleCommand CI1_OC_o = new OracleCommand();
                        CI1_OC_o.CommandType = CommandType.Text;
                        CI1_OC_o.Connection = oCon;
                        CI1_OC_o.CommandText = "SELECT acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID as CID_Posting_ID,acct_t_Payment_Details.payment_posting_id as PD_Posting_ID from " + DB_Name_Text.Text + ".acct_t_Credit_Invoice_Details," + DB_Name_Text.Text + ".acct_t_Payment_Details WHERE acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID = acct_t_Payment_Details.payment_posting_id";
                        OracleDataAdapter CI1_da_o = new OracleDataAdapter(CI1_OC_o);
                        DataSet CI1_ds_o = new DataSet();
                        CI1_da_o.Fill(CI1_ds_o, "CI1_ds_o");
                        dataGridView6.DataSource = CI1_ds_o;
                        dataGridView6.DataMember = "CI1_ds_o";
                        //DataGridView//column //column = dataGridView6.columns[2];
                        //column.Width = 300;

                        OracleCommand CI2_OC_o = new OracleCommand();
                        CI2_OC_o.CommandType = CommandType.Text;
                        CI2_OC_o.Connection = oCon;
                        CI2_OC_o.CommandText = "SELECT acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID as CID_Posting_ID, acct_t_Transfer.pk_Posting_ID as T_posting_ID from " + DB_Name_Text.Text + ".acct_t_Credit_Invoice_Details," + DB_Name_Text.Text + ".acct_t_Transfer WHERE acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID = acct_t_Transfer.pk_Posting_ID";
                        OracleDataAdapter CI2_da_o = new OracleDataAdapter(CI2_OC_o);
                        DataSet CI2_ds_o = new DataSet();
                        CI2_da_o.Fill(CI2_ds_o, "CI2_ds_o");
                        dataGridView5.DataSource = CI2_ds_o;
                        dataGridView5.DataMember = "CI2_ds_o";
                        //DataGridView//column //column2 = dataGridView5.columns[2];
                        //column2.Width = 300;

                        OracleCommand CI3_OC_o = new OracleCommand();
                        CI3_OC_o.CommandType = CommandType.Text;
                        CI3_OC_o.Connection = oCon;
                        CI3_OC_o.CommandText = "SELECT acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID AS CID_Posting_ID, acct_t_Invoice_Details.ck_Posting_ID AS ID_Posting_ID FROM " + DB_Name_Text.Text + ".acct_t_Credit_Invoice_Details, " + DB_Name_Text.Text + ".acct_t_Invoice_Details WHERE acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID = acct_t_Invoice_Details.ck_Posting_ID";
                        OracleDataAdapter CI3_da_o = new OracleDataAdapter(CI3_OC_o);
                        DataSet CI3_ds_o = new DataSet();
                        CI3_da_o.Fill(CI3_ds_o, "CI3_ds_o");
                        dataGridView4.DataSource = CI3_ds_o;
                        dataGridView4.DataMember = "CI3_ds_o";
                        //DataGridView//column //column3 = dataGridView4.columns[2];
                        //column3.Width = 300;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            if (TabControl1.SelectedTab == PAYMENT_Tab)
            {
                if (DB_TYPE_COMBO.Text.Equals("Select Database Type") || (SERVER_CONNECTION_TEXT.Text.Equals("")) || (USERNAME_TEXT.Text.Equals("")) || (PASSWORD_TEXT.Text.Equals("")))
                {
                    MessageBox.Show("Please complete connections on the connections tab.");
                    TabControl1.SelectedIndex = 0;
                }
                else if (DB_TYPE_COMBO.Text.Equals("SQL"))
                {
                    String CONNECTION_STRING =
                                  "Server=" + SERVER_CONNECTION_TEXT.Text + ";" +
                                  "DataBase=" + DB_Name_Text.Text + ";" +
                                  "Uid=" + USERNAME_TEXT.Text + ";" +
                                  "Pwd=" + PASSWORD_TEXT.Text + ";";
                    try
                    {
                        SqlConnection conn = new SqlConnection(CONNECTION_STRING);
                        SqlDataAdapter P1_da_s;
                        DataSet P1_ds_s = new DataSet();
                        conn = new SqlConnection(CONNECTION_STRING);
                        conn.Open();
                        P1_da_s = new SqlDataAdapter("SELECT acct_t_Payment_Details.payment_posting_id as PD_Posting_ID,acct_t_Transfer.pk_Posting_ID as T_posting_ID from " + DB_Name_Text.Text + ".dbo.acct_t_Payment_Details," + DB_Name_Text.Text + ".dbo.acct_t_Transfer WHERE acct_t_Payment_Details.payment_posting_id = acct_t_Transfer.pk_Posting_ID", conn);
                        P1_da_s.Fill(P1_ds_s, "P1_ds_s");
                        dataGridView9.DataSource = P1_ds_s;
                        dataGridView9.DataMember = "P1_ds_s";
                        //DataGridView//column //column = dataGridView9.columns[2];
                        //column.Width = 300;

                        SqlDataAdapter P2_da_s;
                        DataSet P2_ds_s = new DataSet();
                        conn = new SqlConnection(CONNECTION_STRING);
                        conn.Open();
                        P2_da_s = new SqlDataAdapter("SELECT acct_t_Payment_Details.payment_posting_id AS PD_Posting_ID, acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID AS CID_Posting_ID FROM " + DB_Name_Text.Text + ".dbo.acct_t_Payment_Details," + DB_Name_Text.Text + ".dbo.acct_t_Credit_Invoice_Details WHERE acct_t_Payment_Details.payment_posting_id = acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID", conn);
                        P2_da_s.Fill(P2_ds_s, "P2_ds_s");
                        dataGridView8.DataSource = P2_ds_s;
                        dataGridView8.DataMember = "P2_ds_s";
                        //DataGridView//column //column2 = dataGridView8.columns[2];
                        //column2.Width = 300;

                        SqlDataAdapter P3_da_s;
                        DataSet P3_ds_s = new DataSet();
                        conn = new SqlConnection(CONNECTION_STRING);
                        conn.Open();
                        P3_da_s = new SqlDataAdapter("SELECT acct_t_Payment_Details.payment_posting_id AS PD_Posting_ID,acct_t_Invoice_Details.ck_Posting_ID AS ID_Posting_ID FROM " + DB_Name_Text.Text + ".dbo.acct_t_Payment_Details," + DB_Name_Text.Text + ".dbo.acct_t_Invoice_Details WHERE acct_t_Payment_Details.payment_posting_id = acct_t_Invoice_Details.ck_Posting_ID", conn);
                        P3_da_s.Fill(P3_ds_s, "P3_ds_s");
                        dataGridView7.DataSource = P3_ds_s;
                        dataGridView7.DataMember = "P3_ds_s";
                        //DataGridView//column //column3 = dataGridView7.columns[2];
                        //column3.Width = 300;
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
                        OracleCommand P1_OC_o = new OracleCommand();
                        P1_OC_o.CommandType = CommandType.Text;
                        P1_OC_o.Connection = oCon;
                        P1_OC_o.CommandText = "SELECT acct_t_Payment_Details.payment_posting_id as PD_Posting_ID,acct_t_Transfer.pk_Posting_ID as T_posting_ID from " + DB_Name_Text.Text + ".acct_t_Payment_Details," + DB_Name_Text.Text + ".acct_t_Transfer WHERE acct_t_Payment_Details.payment_posting_id = acct_t_Transfer.pk_Posting_ID";
                        OracleDataAdapter P1_da_o = new OracleDataAdapter(P1_OC_o);
                        DataSet P1_ds_o = new DataSet();
                        P1_da_o.Fill(P1_ds_o, "P1_ds_o");
                        dataGridView9.DataSource = P1_ds_o;
                        dataGridView9.DataMember = "P1_ds_o";
                        //DataGridView//column //column = dataGridView9.columns[2];
                        //column.Width = 300;

                        OracleCommand P2_OC_o = new OracleCommand();
                        P2_OC_o.CommandType = CommandType.Text;
                        P2_OC_o.Connection = oCon;
                        P2_OC_o.CommandText = "SELECT acct_t_Payment_Details.payment_posting_id AS PD_Posting_ID, acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID AS CID_Posting_ID FROM " + DB_Name_Text.Text + ".acct_t_Payment_Details," + DB_Name_Text.Text + ".acct_t_Credit_Invoice_Details WHERE acct_t_Payment_Details.payment_posting_id = acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID";
                        OracleDataAdapter P2_da_o = new OracleDataAdapter(P2_OC_o);
                        DataSet P2_ds_o = new DataSet();
                        P2_da_o.Fill(P2_ds_o, "P2_ds_o");
                        dataGridView8.DataSource = P2_ds_o;
                        dataGridView8.DataMember = "P2_ds_o";
                        //DataGridView//column //column2 = dataGridView8.columns[2];
                        //column2.Width = 300;

                        OracleCommand P3_OC_o = new OracleCommand();
                        P3_OC_o.CommandType = CommandType.Text;
                        P3_OC_o.Connection = oCon;
                        P3_OC_o.CommandText = "SELECT acct_t_Payment_Details.payment_posting_id AS PD_Posting_ID,acct_t_Invoice_Details.ck_Posting_ID AS ID_Posting_ID FROM " + DB_Name_Text.Text + ".acct_t_Payment_Details," + DB_Name_Text.Text + ".acct_t_Invoice_Details WHERE acct_t_Payment_Details.payment_posting_id = acct_t_Invoice_Details.ck_Posting_ID";
                        OracleDataAdapter P3_da_o = new OracleDataAdapter(P3_OC_o);
                        DataSet P3_ds_o = new DataSet();
                        P3_da_o.Fill(P3_ds_o, "P3_ds_o");
                        dataGridView7.DataSource = P3_ds_o;
                        dataGridView7.DataMember = "P3_ds_o";
                        //DataGridView//column //column3 = dataGridView7.columns[2];
                        //column3.Width = 300;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            if (TabControl1.SelectedTab == TRANSFER_Tab)
            {
                if (DB_TYPE_COMBO.Text.Equals("Select Database Type") || (SERVER_CONNECTION_TEXT.Text.Equals("")) || (USERNAME_TEXT.Text.Equals("")) || (PASSWORD_TEXT.Text.Equals("")))
                {
                    MessageBox.Show("Please complete connections on the connections tab.");
                    TabControl1.SelectedIndex = 0;
                }
                else if (DB_TYPE_COMBO.Text.Equals("SQL"))
                {
                    String CONNECTION_STRING =
                                  "Server=" + SERVER_CONNECTION_TEXT.Text + ";" +
                                  "DataBase=" + DB_Name_Text.Text + ";" +
                                  "Uid=" + USERNAME_TEXT.Text + ";" +
                                  "Pwd=" + PASSWORD_TEXT.Text + ";";
                    try
                    {
                        SqlConnection conn = new SqlConnection(CONNECTION_STRING);
                        SqlDataAdapter T1_da_s;
                        DataSet T1_ds_s = new DataSet();
                        conn = new SqlConnection(CONNECTION_STRING);
                        conn.Open();
                        T1_da_s = new SqlDataAdapter("SELECT acct_t_Payment_Details.payment_posting_id as PD_Posting_ID,acct_t_Transfer.pk_Posting_ID as T_posting_ID from " + DB_Name_Text.Text + ".dbo.acct_t_Payment_Details," + DB_Name_Text.Text + ".dbo.acct_t_Transfer WHERE acct_t_Payment_Details.payment_posting_id = acct_t_Transfer.pk_Posting_ID", conn);
                        T1_da_s.Fill(T1_ds_s, "T1_ds_s");
                        dataGridView12.DataSource = T1_ds_s;
                        dataGridView12.DataMember = "T1_ds_s";
                        //DataGridView//column //column = dataGridView12.columns[2];
                        //column.Width = 300;

                        SqlDataAdapter T2_da_s;
                        DataSet T2_ds_s = new DataSet();
                        conn = new SqlConnection(CONNECTION_STRING);
                        conn.Open();
                        T2_da_s = new SqlDataAdapter("SELECT acct_t_Payment_Details.payment_posting_id AS PD_Posting_ID, acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID AS CID_Posting_ID FROM " + DB_Name_Text.Text + ".dbo.acct_t_Payment_Details," + DB_Name_Text.Text + ".dbo.acct_t_Credit_Invoice_Details WHERE acct_t_Payment_Details.payment_posting_id = acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID", conn);
                        T2_da_s.Fill(T2_ds_s, "T2_ds_s");
                        dataGridView11.DataSource = T2_ds_s;
                        dataGridView11.DataMember = "T2_ds_s";
                        //DataGridView//column //column2 = dataGridView11.columns[2];
                        //column2.Width = 300;

                        SqlDataAdapter T3_da_s;
                        DataSet T3_ds_s = new DataSet();
                        conn = new SqlConnection(CONNECTION_STRING);
                        conn.Open();
                        T3_da_s = new SqlDataAdapter("SELECT acct_t_Payment_Details.payment_posting_id AS PD_Posting_ID,acct_t_Invoice_Details.ck_Posting_ID AS ID_Posting_ID FROM " + DB_Name_Text.Text + ".dbo.acct_t_Payment_Details," + DB_Name_Text.Text + ".dbo.acct_t_Invoice_Details WHERE acct_t_Payment_Details.payment_posting_id = acct_t_Invoice_Details.ck_Posting_ID", conn);
                        T3_da_s.Fill(T3_ds_s, "T3_ds_s");
                        dataGridView10.DataSource = T3_ds_s;
                        dataGridView10.DataMember = "T3_ds_s";
                        //DataGridView//column //column3 = dataGridView10.columns[2];
                        //column3.Width = 300;
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
                        OracleCommand T1_OC_o = new OracleCommand();
                        T1_OC_o.CommandType = CommandType.Text;
                        T1_OC_o.Connection = oCon;
                        T1_OC_o.CommandText = "SELECT acct_t_Transfer.pk_Posting_ID AS T_Posting_ID,acct_t_Invoice_Details.ck_Posting_ID AS ID_Posting_ID FROM " + DB_Name_Text.Text + ".acct_t_Transfer," + DB_Name_Text.Text + ".acct_t_Invoice_Details Where acct_t_Transfer.pk_Posting_ID = acct_t_Invoice_Details.ck_Posting_ID";
                        OracleDataAdapter T1_da_o = new OracleDataAdapter(T1_OC_o);
                        DataSet T1_ds_o = new DataSet();
                        T1_da_o.Fill(T1_ds_o, "T1_ds_o");
                        dataGridView12.DataSource = T1_ds_o;
                        dataGridView12.DataMember = "T1_ds_o";
                        //DataGridView//column //column = dataGridView1.columns[2];
                        //column.Width = 300;

                        OracleCommand T2_OC_o = new OracleCommand();
                        T2_OC_o.CommandType = CommandType.Text;
                        T2_OC_o.Connection = oCon;
                        T2_OC_o.CommandText = "SELECT acct_t_Transfer.pk_Posting_ID AS T_Posting_ID, acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID AS CID_Posting_ID FROM " + DB_Name_Text.Text + ".acct_t_Transfer," + DB_Name_Text.Text + ".acct_t_Credit_Invoice_Details WHERE acct_t_Transfer.pk_Posting_ID = acct_t_Credit_Invoice_Details.ck_Credit_Posting_ID";
                        OracleDataAdapter T2_da_o = new OracleDataAdapter(T2_OC_o);
                        DataSet T2_ds_o = new DataSet();
                        T2_da_o.Fill(T2_ds_o, "T2_ds_o");
                        dataGridView11.DataSource = T2_ds_o;
                        dataGridView11.DataMember = "T2_ds_o";
                        //DataGridView//column //column2 = dataGridView2.columns[2];
                        //column2.Width = 300;

                        OracleCommand T3_OC_o = new OracleCommand();
                        T3_OC_o.CommandType = CommandType.Text;
                        T3_OC_o.Connection = oCon;
                        T3_OC_o.CommandText = "SELECT acct_t_Transfer.pk_Posting_ID AS T_Posting_ID, acct_t_Payment_Details.payment_posting_id AS PD_Posting_ID FROM " + DB_Name_Text.Text + ".acct_t_Transfer," + DB_Name_Text.Text + ".acct_t_Payment_Details WHERE acct_t_Transfer.pk_Posting_ID = acct_t_Payment_Details.payment_posting_id";
                        OracleDataAdapter T3_da_o = new OracleDataAdapter(T3_OC_o);
                        DataSet T3_ds_o = new DataSet();
                        T3_da_o.Fill(T3_ds_o, "T3_ds_o");
                        dataGridView10.DataSource = T3_ds_o;
                        dataGridView10.DataMember = "T3_ds_o";
                        //DataGridView//column //column3 = dataGridView2.columns[2];
                        //column3.Width = 300;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            
        }

        private void runSelectQueries_Click(object sender, EventArgs e)
        {
            oldPostingID = Convert.ToInt32(rd_PostingID.Text);
            if (DB_TYPE_COMBO.Text.Equals("SQL"))
            {
                String CONNECTION_STRING =
                                  "Server=" + SERVER_CONNECTION_TEXT.Text + ";" +
                                  "DataBase=" + DB_Name_Text.Text + ";" +
                                  "Uid=" + USERNAME_TEXT.Text + ";" +
                                  "Pwd=" + PASSWORD_TEXT.Text + ";";

                try
                {
                    SqlConnection conn = new SqlConnection(CONNECTION_STRING);
                    SqlDataAdapter T1_da_s;
                    DataSet T1_ds_s = new DataSet();
                    conn = new SqlConnection(CONNECTION_STRING);
                    conn.Open();
                    T1_da_s = new SqlDataAdapter("SELECT CK_CREDIT_POSTING_ID,CK_INVOICE_NO,ENTRY_DATE AS CIDDATE,ENTERED_BY FROM " + DB_Name_Text.Text + ".dbo.ACCT_T_CREDIT_INVOICE_DETAILS WHERE CK_CREDIT_POSTING_ID = '" + rd_PostingID.Text + "'", conn);
                    T1_da_s.Fill(T1_ds_s, "T1_ds_s");
                    dataGridView13.DataSource = T1_ds_s;
                    dataGridView13.DataMember = "T1_ds_s";
                    //DataGridView//column //column = dataGridView12.columns[2];
                    //column.Width = 300;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No Results");
                }
                try
                {
                    SqlConnection conn = new SqlConnection(CONNECTION_STRING);
                    SqlDataAdapter T2_da_s;
                    DataSet T2_ds_s = new DataSet();
                    conn = new SqlConnection(CONNECTION_STRING);
                    conn.Open();
                    T2_da_s = new SqlDataAdapter("SELECT CK_POSTING_ID,CK_INVOICE_NO,ENTRY_DATE AS IDDATE,ENTERED_BY FROM " + DB_Name_Text.Text + ".dbo.ACCT_T_INVOICE_DETAILS WHERE CK_POSTING_ID = '" + rd_PostingID.Text + "'", conn);
                    T2_da_s.Fill(T2_ds_s, "T2_ds_s");
                    dataGridView14.DataSource = T2_ds_s;
                    dataGridView14.DataMember = "T2_ds_s";
                    //DataGridView//column //column = dataGridView12.columns[2];
                    //column.Width = 300;
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
                    OracleCommand T1_OC_o = new OracleCommand();
                    T1_OC_o.CommandType = CommandType.Text;
                    T1_OC_o.Connection = oCon;
                    T1_OC_o.CommandText = "SELECT CK_CREDIT_POSTING_ID,CK_INVOICE_NO,TO_CHAR(ACCT_T_INVOICE_DETAILS.ENTRY_DATE,'mm-dd-yy hh:mi:ss') AS CIDDATE,ENTERED_BY FROM " + DB_Name_Text.Text + ".ACCT_T_CREDIT_INVOICE_DETAILS WHERE CK_CREDIT_POSTING_ID = '" + rd_PostingID.Text + "'";
                    OracleDataAdapter T1_da_o = new OracleDataAdapter(T1_OC_o);
                    DataSet T1_ds_o = new DataSet();
                    T1_da_o.Fill(T1_ds_o, "T1_ds_o");
                    dataGridView13.DataSource = T1_ds_o;
                    dataGridView13.DataMember = "T1_ds_o";
                    //DataGridView//column //column = dataGridView1.columns[2];
                    //column.Width = 300;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    OracleConnection oCon = new OracleConnection(CONNECTION_STRING);
                    oCon.Open();
                    OracleCommand T2_OC_o = new OracleCommand();
                    T2_OC_o.CommandType = CommandType.Text;
                    T2_OC_o.Connection = oCon;
                    T2_OC_o.CommandText = "SELECT CK_CREDIT_POSTING_ID,CK_INVOICE_NO,TO_CHAR(ACCT_T_INVOICE_DETAILS.ENTRY_DATE,'mm-dd-yy hh:mi:ss') AS CIDDATE,ENTERED_BY FROM " + DB_Name_Text.Text + ".ACCT_T_CREDIT_INVOICE_DETAILS WHERE CK_CREDIT_POSTING_ID = '" + rd_PostingID.Text + "'";
                    OracleDataAdapter T2_da_o = new OracleDataAdapter(T2_OC_o);
                    DataSet T2_ds_o = new DataSet();
                    T2_da_o.Fill(T2_ds_o, "T2_ds_o");
                    dataGridView14.DataSource = T2_ds_o;
                    dataGridView14.DataMember = "T2_ds_o";
                    //DataGridView//column //column = dataGridView1.columns[2];
                    //column.Width = 300;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void upIncrementalID_but_Click(object sender, EventArgs e)
        {
            if (DB_TYPE_COMBO.Text.Equals("SQL"))
            {
                String CONNECTION_STRING =
                                  "Server=" + SERVER_CONNECTION_TEXT.Text + ";" +
                                  "DataBase=" + DB_Name_Text.Text + ";" +
                                  "Uid=" + USERNAME_TEXT.Text + ";" +
                                  "Pwd=" + PASSWORD_TEXT.Text + ";";

                try
                {
                    SqlConnection sCon = new SqlConnection(CONNECTION_STRING);
                    sCon.Open();
                    
                    SqlCommand R1_OC_s = new SqlCommand();
                    R1_OC_s.CommandType = CommandType.Text;
                    R1_OC_s.Connection = sCon;
                    R1_OC_s.CommandText = "UPDATE " + DB_Name_Text.Text + ".dbo.ACCT_T_POSTINGID_INCREMENTAL SET PK_POSTING_ID = (PK_POSTING_ID + 2)";
                    R1_OC_s.ExecuteNonQuery();

                    SqlDataAdapter R2_da_s;
                    DataSet R2_ds_s = new DataSet();
                    R2_da_s = new SqlDataAdapter("SELECT PK_POSTING_ID FROM " + DB_Name_Text.Text + ".dbo.ACCT_T_POSTINGID_INCREMENTAL", sCon);
                    R2_da_s.Fill(R2_ds_s, "R2_ds_s");
                    dataGridView15.DataSource = R2_ds_s;
                    dataGridView15.DataMember = "R2_ds_s";
                    foreach (DataGridViewRow row in this.dataGridView15.Rows)
                    {
                        DataGridViewCell cell = row.Cells[0];
                        newPostingID = (int)cell;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show(oldPostingID.ToString());
                MessageBox.Show(newPostingID.ToString());
            }
            else if (DB_TYPE_COMBO.Text.Equals("Oracle"))
            {
                string CONNECTION_STRING = "User Id=" + USERNAME_TEXT.Text + ";Password=" + PASSWORD_TEXT.Text + ";Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + ORA_HOST_TEXT.Text + ")(PORT=" + DB_PORT_TEXT.Text + "))" + "(CONNECT_DATA=(SID=" + SERVER_CONNECTION_TEXT.Text + ")));";
                try
                {
                    OracleConnection oCon = new OracleConnection(CONNECTION_STRING);
                    oCon.Open();
                    OracleCommand R1_OC_o = new OracleCommand();
                    R1_OC_o.CommandType = CommandType.Text;
                    R1_OC_o.Connection = oCon;
                    R1_OC_o.CommandText = "UPDATE " + DB_Name_Text.Text + ".ACCT_T_POSTINGID_INCREMENTAL SET PK_POSTING_ID = (PK_POSTING_ID + 2)";
                    R1_OC_o.ExecuteNonQuery();

                    R1_OC_o.CommandText = "SELECT PK_POSTING_ID FROM " + DB_Name_Text.Text + ".ACCT_T_POSTINGID_INCREMENTAL";
                    R1_OC_o.ExecuteNonQuery();
                 }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show(oldPostingID.ToString());
                MessageBox.Show(newPostingID.ToString());
            }
        }
    }
}

