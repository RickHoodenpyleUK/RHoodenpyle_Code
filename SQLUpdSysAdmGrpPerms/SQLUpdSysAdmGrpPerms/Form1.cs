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
using System.Xml;
using System.Xml.Serialization;
using System.Configuration;
using System.Collections;
using System.Web;
using System.IO;
using System.Data.OleDb;

namespace SQLUpdSysAdmGrpPerms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        public void CONNECTION_BUTTON_Click_1(object sender, EventArgs e)
        {
            String CONNECTION_STRING =
                                      "Server=" + SERVER_CONNECTION_TEXT.Text + ";" +
                                      "DataBase=" + txtLoginDBName.Text + ";" +
                                      "Uid=" + USERNAME_TEXT.Text + ";" +
                                      "Pwd=" + PASSWORD_TEXT.Text + ";";
            SqlConnection sCon = new SqlConnection(CONNECTION_STRING);
            sCon.Open();
            SqlCommand updatePerms = new SqlCommand();
            updatePerms.CommandType = CommandType.Text;
            updatePerms.Connection = sCon;
            string ExecuteSQL = String.Empty;
            ExecuteSQL = "DECLARE @GROUPID int; \n";
            ExecuteSQL += "DECLARE @PKUSERID int; \n";
            ExecuteSQL += "DECLARE @BeginPerm int; \n";
            ExecuteSQL += "DECLARE @EndPerm int; \n";
            ExecuteSQL += "DECLARE @PermNumber int; \n";
            ExecuteSQL += "SET @PKUSERID = (SELECT PK_USERID FROM " + txtLoginDBName.Text + ".dbo.secu_t_Users WHERE UserName='Owner50RMS'); \n";
            ExecuteSQL += "SET @GROUPID = (Select PK_GROUPID FROM " + txtLoginDBName.Text + ".dbo.SECU_T_ACCESS_GROUPS WHERE DESCRIPTION = 'SysAdmin'); \n";
            ExecuteSQL += "SET @BeginPerm = (Select MAX(FK_FUNCTIONID) FROM " + txtLoginDBName.Text + ".dbo.SECU_T_FUNCTIONSACCESSGROUPS WHERE FK_GROUPID = @GROUPID); \n";
            ExecuteSQL += "Set @EndPerm = (Select MAX(PK_FUNCTIONID) FROM " + txtLoginDBName.Text + ".dbo.SECU_T_FUNCTIONS); \n";
            ExecuteSQL += "Set @PermNumber = @BeginPerm + 1; \n";
            ExecuteSQL += "UPDATE " + txtLoginDBName.Text + ".dbo.Secu_t_UserDBDetails SET fk_GroupID = 1 WHERE ck_UserID = @PKUSERID; \n";
            ExecuteSQL += "UPDATE " + txtLoginDBName.Text + ".dbo.SECU_T_FUNCTIONSACCESSGROUPS SET PERMISSION = 1 WHERE FK_GROUPID = @GROUPID; \n";
            ExecuteSQL += "WHILE (@PermNumber <= @EndPerm) \n";
            ExecuteSQL += "BEGIN \n";
            ExecuteSQL += "INSERT INTO " + txtLoginDBName.Text + ".dbo.SECU_T_FUNCTIONSACCESSGROUPS (FK_FUNCTIONID,FK_GROUPID,PERMISSION) VALUES (@PermNumber,@GROUPID,1); \n";
            ExecuteSQL += "Set @PermNumber = @PermNumber + 1; \n";
            ExecuteSQL += "END \n";
            updatePerms.CommandText = ExecuteSQL;
            updatePerms.ExecuteNonQuery();
            MessageBox.Show("Finished updating the Mercury Permissions");

        }
    }
}
