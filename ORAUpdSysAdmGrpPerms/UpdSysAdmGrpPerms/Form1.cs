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
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace ORAUpdSysAdmGrpPerms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
                
            }

        private void CONNECTION_BUTTON_Click(object sender, EventArgs e)
        {
        string CONNECTION_STRING = "User Id=" + USERNAME_TEXT.Text + ";Password=" + PASSWORD_TEXT.Text + ";Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + ORA_HOST_TEXT.Text + ")(PORT=" + DB_PORT_TEXT.Text + "))" + "(CONNECT_DATA=(SID=" + SERVER_CONNECTION_TEXT.Text + ")));";
                OracleConnection conn = new OracleConnection(CONNECTION_STRING);
                try
                {
                    OracleConnection oCon = new OracleConnection(CONNECTION_STRING);
                    oCon.Open();
                    OracleCommand updatePerms = new OracleCommand();
                    string ExecuteSQL = String.Empty;
                    ExecuteSQL = "DECLARE \n";
                    ExecuteSQL += "GROUPID int; \n";
                    ExecuteSQL += "PKUSERID int; \n";
                    ExecuteSQL += "BeginPerm int; \n";
                    ExecuteSQL += "EndPerm int; \n";
                    ExecuteSQL += "PermNumber int; \n";
                    ExecuteSQL += "BEGIN \n";
                    ExecuteSQL += "Select PK_GROUPID INTO GROUPID FROM " + txtLoginDBName.Text + ".SECU_T_ACCESS_GROUPS WHERE DESCRIPTION = 'SysAdmin'; \n";
                    ExecuteSQL += "Select PK_USERID INTO PKUSERID FROM " + txtLoginDBName.Text + ".SECU_T_USERS WHERE USERNAME = 'Owner50RMS'; \n";
                    ExecuteSQL += "Select MAX(FK_FUNCTIONID) INTO BeginPerm FROM " + txtLoginDBName.Text + ".SECU_T_FUNCTIONSACCESSGROUPS WHERE FK_GROUPID = GROUPID; \n";
                    ExecuteSQL += "Select MAX(PK_FUNCTIONID) INTO EndPerm FROM " + txtLoginDBName.Text + ".SECU_T_FUNCTIONS; \n";
                    ExecuteSQL += "PermNumber := BeginPerm + 1; \n";
                    ExecuteSQL += "UPDATE " + txtLoginDBName.Text + ".SECU_T_USERDBDETAILS SET FK_GROUPID = GROUPID WHERE CK_USERID = PKUSERID; \n";
                    ExecuteSQL += "UPDATE " + txtLoginDBName.Text + ".SECU_T_FUNCTIONSACCESSGROUPS SET PERMISSION = 1 WHERE FK_GROUPID = GROUPID; \n";
                    ExecuteSQL += "WHILE PermNumber <= EndPerm \n";
                    ExecuteSQL += "LOOP \n";
                    ExecuteSQL += "INSERT INTO " + txtLoginDBName.Text + ".SECU_T_FUNCTIONSACCESSGROUPS (FK_FUNCTIONID,FK_GROUPID,PERMISSION) VALUES (PermNumber,GROUPID,1); \n";
                    ExecuteSQL += "PermNumber := PermNumber + 1; \n";
                    ExecuteSQL += "End loop; \n";
                    ExecuteSQL += "Commit; \n";
                    ExecuteSQL += "END; \n";
                    updatePerms.Connection = oCon;
                    updatePerms.CommandText = ExecuteSQL;
                    updatePerms.ExecuteNonQuery();
                    MessageBox.Show("Finished updating the Mercury Permissions");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Not Connected - " + ex.Message);

                }
        }
    }
}
