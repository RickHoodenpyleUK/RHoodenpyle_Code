using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

namespace DataMigration
{
    public partial class DataMigrationForm : Form
    {
        public DataMigrationForm()
        {
            InitializeComponent();
        }

        public void btn_Accts_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Bold);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = true;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = false;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_TaxTXTypes_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Bold);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = true;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = false;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_TXTypes_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Bold);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = true;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = false;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_Terms_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Bold);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = true;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = false;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_Rates_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Bold);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = true;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = false;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_RateSplits_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Bold);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = true;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = false;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_RmTypeRates_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Bold);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = true;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = false;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_PlanTypeRates_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Bold);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = true;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = false;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_PayCategories_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Bold);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = true;
            dgv_Community.Visible = false;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_Community_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Bold);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = true;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_Buildings_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Bold);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = false;
            dgv_Building.Visible = true;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_Floors_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Bold);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = false;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = true;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_FloorSections_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Bold);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = false;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = true;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_Rooms_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Bold);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = false;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = true;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_Use1_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Bold);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = false;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = true;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_Use2_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Bold);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = false;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = true;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_RoomConfigs_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Bold);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = false;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = true;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_MatchCrit_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Bold);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = false;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = true;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_Inventory_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Bold);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = false;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = true;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_RmInventory_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Bold);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = false;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = true;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_RmMaintCode_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Bold);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Regular);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = false;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = true;
            dgv_MaintRefTo.Visible = false;
            txt_DataIssues.Visible = false;
        }

        public void btn_MaintRefTo_Click(object sender, EventArgs e)
        {
            btn_Accts.Font = new Font(btn_Accts.Font.Name, btn_Accts.Font.Size, FontStyle.Regular);
            btn_TaxTXTypes.Font = new Font(btn_TaxTXTypes.Font.Name, btn_TaxTXTypes.Font.Size, FontStyle.Regular);
            btn_TXTypes.Font = new Font(btn_TXTypes.Font.Name, btn_TXTypes.Font.Size, FontStyle.Regular);
            btn_Terms.Font = new Font(btn_Terms.Font.Name, btn_Terms.Font.Size, FontStyle.Regular);
            btn_Rates.Font = new Font(btn_Rates.Font.Name, btn_Rates.Font.Size, FontStyle.Regular);
            btn_RateSplits.Font = new Font(btn_RateSplits.Font.Name, btn_RateSplits.Font.Size, FontStyle.Regular);
            btn_RmTypeRates.Font = new Font(btn_RmTypeRates.Font.Name, btn_RmTypeRates.Font.Size, FontStyle.Regular);
            btn_PlanTypeRates.Font = new Font(btn_PlanTypeRates.Font.Name, btn_PlanTypeRates.Font.Size, FontStyle.Regular);
            btn_PayCategories.Font = new Font(btn_PayCategories.Font.Name, btn_PayCategories.Font.Size, FontStyle.Regular);
            btn_Community.Font = new Font(btn_Community.Font.Name, btn_Community.Font.Size, FontStyle.Regular);
            btn_Buildings.Font = new Font(btn_Buildings.Font.Name, btn_Buildings.Font.Size, FontStyle.Regular);
            btn_Floors.Font = new Font(btn_Floors.Font.Name, btn_Floors.Font.Size, FontStyle.Regular);
            btn_FloorSections.Font = new Font(btn_FloorSections.Font.Name, btn_FloorSections.Font.Size, FontStyle.Regular);
            btn_Rooms.Font = new Font(btn_Rooms.Font.Name, btn_Rooms.Font.Size, FontStyle.Regular);
            btn_Use1.Font = new Font(btn_Use1.Font.Name, btn_Use1.Font.Size, FontStyle.Regular);
            btn_Use2.Font = new Font(btn_Use2.Font.Name, btn_Use2.Font.Size, FontStyle.Regular);
            btn_RoomConfigs.Font = new Font(btn_RoomConfigs.Font.Name, btn_RoomConfigs.Font.Size, FontStyle.Regular);
            btn_MatchCrit.Font = new Font(btn_MatchCrit.Font.Name, btn_MatchCrit.Font.Size, FontStyle.Regular);
            btn_Inventory.Font = new Font(btn_Inventory.Font.Name, btn_Inventory.Font.Size, FontStyle.Regular);
            btn_RmInventory.Font = new Font(btn_RmInventory.Font.Name, btn_RmInventory.Font.Size, FontStyle.Regular);
            btn_RmMaintCode.Font = new Font(btn_RmMaintCode.Font.Name, btn_RmMaintCode.Font.Size, FontStyle.Regular);
            btn_MaintRefTo.Font = new Font(btn_MaintRefTo.Font.Name, btn_MaintRefTo.Font.Size, FontStyle.Bold);
            dgv_Accounts.Visible = false;
            dgv_TaxTXTypes.Visible = false;
            dgv_TXTypes.Visible = false;
            dgv_Terms.Visible = false;
            dgv_Rates.Visible = false;
            dgv_RateSplits.Visible = false;
            dgv_RmTypeRates.Visible = false;
            dgv_PlanTypeRates.Visible = false;
            dgv_PayCategories.Visible = false;
            dgv_Community.Visible = false;
            dgv_Building.Visible = false;
            dgv_Floors.Visible = false;
            dgv_FloorSections.Visible = false;
            dgv_Rooms.Visible = false;
            dgv_Use1.Visible = false;
            dgv_Use2.Visible = false;
            dgv_RoomConfigs.Visible = false;
            dgv_MatchCrit.Visible = false;
            dgv_Inventory.Visible = false;
            dgv_RmInventory.Visible = false;
            dgv_RmMaintCode.Visible = false;
            dgv_MaintRefTo.Visible = true;
            txt_DataIssues.Visible = false;
        }

        public void btn_BrowseExcelLoc_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_WorkbooksLoc.Text = folderBrowserDialog1.SelectedPath;

            }
        }

        public void btn_SQLLoc_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                this.txt_SQLLoc.Text = folderBrowserDialog2.SelectedPath;

            }
        }


       
        public void btn_PopDGV_Click(object sender, EventArgs e)
        {
            dsAccounts.Clear();
            dsTaxTXTypes.Clear();
            dsTXTypes.Clear();
            dsTerms.Clear();
            dsRates.Clear();
            dsRateSplits.Clear();
            dsRmTypesRates.Clear();
            dsPlanTypesRates.Clear();
            dsPayCategories.Clear();
            dsCommunity.Clear();
            dsBuildings.Clear();
            dsFloors.Clear();
            dsFloorSections.Clear();
            dsRooms.Clear();
            dsUse1.Clear();
            dsUse2.Clear();
            dsRoomConfigs.Clear();
            dsMatchCrit.Clear();
            dsInventory.Clear();
            dsRmInventory.Clear();
            dsRmMaintCode.Clear();
            dsMaintRefTo.Clear();

            strAccSQL.Clear();
            strtaxTXSQL.Clear();
            strTXSQL.Clear();
            strTermsSQL.Clear();
            strRatesSQL.Clear();
            strRateSplitsSQL.Clear();
            strRmTypesRatesSQL.Clear();
            strPlanTypesRatesSQL.Clear();
            strPayCategoriesSQL.Clear();
            strCommunitySQL.Clear();
            strBuildingsSQL.Clear();
            strFloorsSQL.Clear();
            strFloorSectionsSQL.Clear();
            strRoomsSQL.Clear();
            strUse1SQL.Clear();
            strUse2SQL.Clear();
            strRoomConfigsSQL.Clear();
            strMatchCritSQL.Clear();
            strInventorySQL.Clear();
            strRmInventorySQL.Clear();
            strRmMaintCodeSQL.Clear();
            strMaintRefToSQL.Clear();

            listAccountNames.Clear();
            listTaxTXTypes.Clear();
            listTaxTXTypesDebitAccount.Clear();
            listTaxTXTypesCreditAccount.Clear();
            listTXTypes.Clear();
            listTXTypesDebitAccount.Clear();
            listTXTypesCreditAccount.Clear();
            listTXTypesTaxTypes1.Clear();
            listTXTypesTaxTypes2.Clear();
            listTXTypesTaxTypes3.Clear();
            listTXTypesTaxTypes4.Clear();
            listTermIDs.Clear();
            listRatesCode.Clear();
            listRatesCodeConfigCombo.Clear();
            listRatesBillingType.Clear();
            listRatesType.Clear();
            listRateSplitsCode.Clear();
            listRateSplitsCodeConfigCombo.Clear();
            listRateSplitsTXType.Clear();
            listRmTypesRatesRMType.Clear();
            listRmTypesRatesRateCode.Clear();
            listPlanTypesRatesPlanType.Clear();
            listPlanTypesRatesRateCode.Clear();
            listPlanTypesRatesTypeType.Clear();
            listPayCategoriesMethodCode.Clear();
            ///
            ///RoomsAndBeds Lists
            ///
            listCommunity.Clear();
            listBuildingID.Clear();
            listBuildingCommunity.Clear();
            listFloorID.Clear();
            listFloorBuildingID.Clear();
            listSectionID.Clear();
            listSectionsFloorID.Clear();
            listRoomsBedSpace.Clear();
            listRoomsRoomNo.Clear();
            listRoomsSecondarySpace.Clear();
            listUse1.Clear();
            listUse2.Clear();
            listRmConfigsBedSpaces.Clear();
            listRmConfigsBedSpacesonfigCombo.Clear();
            listRmConfigsRoomsType.Clear();
            listRmConfigsSectionID.Clear();
            listRmConfigsUse1.Clear();
            listRmConfigsUse2.Clear();
            listInventoryCode.Clear();
            listRmInventoryBedSpace.Clear();
            listRmInventoryCode.Clear();
            listMaintenanceCode.Clear();
            string sFilePath1 = txt_WorkbooksLoc.Text + @"\AccountingAndRates.xlsx";
            string sFilePath2 = txt_WorkbooksLoc.Text + @"\RoomsAndBeds.xlsx";
            if (File.Exists(sFilePath1))
            {
                try
                {
                    ///
                    ///Accounts
                    ///
                    string workSheetName1 = "Accounts";
                    System.Data.OleDb.OleDbConnection MyConnection1;
                    System.Data.DataSet DtSet1;
                    System.Data.OleDb.OleDbDataAdapter MyCommand1;
                    MyConnection1 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath1 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
                    MyCommand1 = new System.Data.OleDb.OleDbDataAdapter("select PK_ACCOUNT_CODE,ACCOUNT_NAME,ACCOUNT_TYPE,ALIAS_CODE,STATUS,IX_RECEIVABLE from [" + workSheetName1 + "$] WHERE PK_ACCOUNT_CODE IS NOT NULL", MyConnection1);
                    MyCommand1.TableMappings.Add("Table", "Net-informations.com");
                    DtSet1 = new System.Data.DataSet();
                    MyCommand1.Fill(DtSet1);
                    MyCommand1.Fill(dsAccounts);
                    dgv_Accounts.DataSource = DtSet1.Tables[0];
                    dgv_Accounts.DataSource = dsAccounts;
                    MyConnection1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Accounts table - " + ex.Message);

                }
                
                try
                {
                ///
                ///Tax Transaction Types
                ///
                string workSheetName2 = "Tax Transaction Types";
                System.Data.OleDb.OleDbConnection MyConnection2;
                System.Data.DataSet DtSet2;
                System.Data.OleDb.OleDbDataAdapter MyCommand2;
                MyConnection2 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath1 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
                MyCommand2 = new System.Data.OleDb.OleDbDataAdapter("select PK_TAX_TXTYPE,TAX_TRANSACTION_TYPE_DESCRIPTION,FK_DEBIT_ACCOUNT,FK_CREDIT_ACCOUNT,PERCENTAGE,SECONDARY_CODE,STATUS from [" + workSheetName2 + "$] WHERE PK_TAX_TXTYPE IS NOT NULL", MyConnection2);
                MyCommand2.TableMappings.Add("Table", "Net-informations.com");
                DtSet2 = new System.Data.DataSet();
                MyCommand2.Fill(DtSet2);
                MyCommand2.Fill(dsTaxTXTypes);
                dgv_TaxTXTypes.DataSource = DtSet2.Tables[0];
                dgv_TaxTXTypes.DataSource = dsTaxTXTypes;
                MyConnection2.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tax Transaction Types table - " + ex.Message);

                }
                
                try
                {
                ///
                ///Transaction Types
                ///
                string workSheetName3 = "Transaction Types";
                System.Data.OleDb.OleDbConnection MyConnection3;
                System.Data.DataSet DtSet3;
                System.Data.OleDb.OleDbDataAdapter MyCommand3;
                MyConnection3 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath1 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
                MyCommand3 = new System.Data.OleDb.OleDbDataAdapter("select PK_TXTYPE,TRANSACTION_TYPE_DEFAULT,CHARGES,UPLOADABLE,TRANSACTION_TYPE_DESCRIPTION,FK_DEBIT_ACCOUNT,SECONDARY_CODE,FK_CREDIT_ACCOUNT,FK_TAX_TXTYPE1,TAX1_PERCENTAGE,FK_TAX_TXTYPE2,TAX2_PERCENTAGE,FK_TAX_TXTYPE3,TAX3_PERCENTAGE,FK_TAX_TXTYPE4,TAX4_PERCENTAGE,MIN_TX,MAX_TX,BB_CLOSE_ACC,STATUS,CREDIT_INVOICE,POINTOFSALE,TRANSFER,BOND,REFUND,PAYMENT,PAYMENTBOND,BANKTRANSFER,IT,PI,APPLICATION from [" + workSheetName3 + "$] WHERE PK_TXTYPE IS NOT NULL", MyConnection3);
                MyCommand3.TableMappings.Add("Table", "Net-informations.com");
                DtSet3 = new System.Data.DataSet();
                MyCommand3.Fill(DtSet3);
                MyCommand3.Fill(dsTXTypes);
                dgv_TXTypes.DataSource = DtSet3.Tables[0];
                dgv_TXTypes.DataSource = dsTXTypes;
                MyConnection3.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction Types table - " + ex.Message);

                }
                
                try
                {
                ///
                ///Terms
                ///
                string workSheetName4 = "Terms";
                System.Data.OleDb.OleDbConnection MyConnection4;
                System.Data.DataSet DtSet4;
                System.Data.OleDb.OleDbDataAdapter MyCommand4;
                MyConnection4 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath1 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
                MyCommand4 = new System.Data.OleDb.OleDbDataAdapter("select PK_TERM_ID,TERM_DATES_NAME,TERM_DATES_START_DATE,TERM_DATES_END_DATE,TERM_DATES_NOMINATED,PERCENTAGE_TO_BILL,TERM_DATES_UPLOAD,STATUS,ROOM_TERM,PLAN_TERM,BILLING_TERM,PROPERTY_TERM,PAYMENT_TERM from [" + workSheetName4 + "$] WHERE PK_TERM_ID IS NOT NULL", MyConnection4);
                MyCommand4.TableMappings.Add("Table", "Net-informations.com");
                DtSet4 = new System.Data.DataSet();
                MyCommand4.Fill(DtSet4);
                MyCommand4.Fill(dsTerms);
                dgv_Terms.DataSource = DtSet4.Tables[0];
                dgv_Terms.DataSource = dsTerms;
                MyConnection4.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terms table - " + ex.Message);

                }
 
                try
                {
                ///
                ///Rates
                ///
                string workSheetName5 = "Rates";
                System.Data.OleDb.OleDbConnection MyConnection5;
                System.Data.DataSet DtSet5;
                System.Data.OleDb.OleDbDataAdapter MyCommand5;
                MyConnection5 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath1 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
                MyCommand5 = new System.Data.OleDb.OleDbDataAdapter("select CK_RATE_CODE,CK_RATE_CONFIG_NO,FK_BILLING_TYPE,RATES_DESCRIPTION,RATES_TYPE,RATE_START_DATE,RATE_END_DATE,RATE_CONFIG_DESCRIPTION,RATES_SERVICE_TIME,RATES_SERVICE_TYPE,RATES_LINEN_TIME,RATES_LINEN_TYPE from [" + workSheetName5 + "$] WHERE CK_RATE_CODE IS NOT NULL", MyConnection5);
                MyCommand5.TableMappings.Add("Table", "Net-informations.com");
                DtSet5 = new System.Data.DataSet();
                MyCommand5.Fill(DtSet5);
                MyCommand5.Fill(dsRates);
                dgv_Rates.DataSource = DtSet5.Tables[0];
                dgv_Rates.DataSource = dsRates;
                MyConnection5.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rates table - " + ex.Message);

                }

                try
                {
                ///
                ///Rates and Rate Splits
                ///
                string workSheetName6 = "Rates and Rate Splits";
                System.Data.OleDb.OleDbConnection MyConnection6;
                System.Data.DataSet DtSet6;
                System.Data.OleDb.OleDbDataAdapter MyCommand6;
                MyConnection6 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath1 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
                MyCommand6 = new System.Data.OleDb.OleDbDataAdapter("select CK_RATE_CODE,CK_RATE_CONFIG_NO,CK_TXTYPE,RATES_SPLIT_AMOUNT from [" + workSheetName6 + "$] WHERE CK_RATE_CODE IS NOT NULL", MyConnection6);
                MyCommand6.TableMappings.Add("Table", "Net-informations.com");
                DtSet6 = new System.Data.DataSet();
                MyCommand6.Fill(DtSet6);
                MyCommand6.Fill(dsRateSplits);
                dgv_RateSplits.DataSource = DtSet6.Tables[0];
                dgv_RateSplits.DataSource = dsRateSplits;
                MyConnection6.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rates and Splits table - " + ex.Message);

                }

                try
                {
                ///
                ///Room Types Rates
                ///
                string workSheetName7 = "Room types Rates";
                System.Data.OleDb.OleDbConnection MyConnection7;
                System.Data.DataSet DtSet7;
                System.Data.OleDb.OleDbDataAdapter MyCommand7;
                MyConnection7 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath1 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
                MyCommand7 = new System.Data.OleDb.OleDbDataAdapter("select PK_ROOM_TYPE,ROOM_TYPE_ALIAS_NAME,FK_RATE_CODE,ROOM_TYPE_DESCRIPTION,TURN_AROUND_TIME,TURN_AROUND_TYPE,STATUS,UD_HYPERLINK from [" + workSheetName7 + "$] WHERE PK_ROOM_TYPE IS NOT NULL", MyConnection7);
                MyCommand7.TableMappings.Add("Table", "Net-informations.com");
                DtSet7 = new System.Data.DataSet();
                MyCommand7.Fill(DtSet7);
                MyCommand7.Fill(dsRmTypesRates);
                dgv_RmTypeRates.DataSource = DtSet7.Tables[0];
                dgv_RmTypeRates.DataSource = dsRmTypesRates;
                MyConnection7.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Room Types Rates table - " + ex.Message);

                }

                try
                {
                ///
                ///Plan Types Rates
                ///
                string workSheetName8 = "Plan Types Rates";
                System.Data.OleDb.OleDbConnection MyConnection8;
                System.Data.DataSet DtSet8;
                System.Data.OleDb.OleDbDataAdapter MyCommand8;
                MyConnection8 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath1 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
                MyCommand8 = new System.Data.OleDb.OleDbDataAdapter("select PK_PLAN_TYPE,FK_RATE_CODE,PLAN_TYPE_DESCRIPTION,PLAN_TYPE_TYPE,MP_START,MP_END,STATUS from [" + workSheetName8 + "$] WHERE PK_PLAN_TYPE IS NOT NULL", MyConnection8);
                MyCommand8.TableMappings.Add("Table", "Net-informations.com");
                DtSet8 = new System.Data.DataSet();
                MyCommand8.Fill(DtSet8);
                MyCommand8.Fill(dsPlanTypesRates);
                dgv_PlanTypeRates.DataSource = DtSet8.Tables[0];
                dgv_PlanTypeRates.DataSource = dsPlanTypesRates;
                MyConnection8.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Plan Types Rates table - " + ex.Message);

                }

                try
                {
                ///
                ///Payment Categories
                ///
                string workSheetName9 = "Payment Categories";
                System.Data.OleDb.OleDbConnection MyConnection9;
                System.Data.DataSet DtSet9;
                System.Data.OleDb.OleDbDataAdapter MyCommand9;
                MyConnection9 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath1 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
                MyCommand9 = new System.Data.OleDb.OleDbDataAdapter("select PK_METHOD_CODE,METHOD_DESCRIPTION,STATUS from [" + workSheetName9 + "$] WHERE PK_METHOD_CODE IS NOT NULL", MyConnection9);
                MyCommand9.TableMappings.Add("Table", "Net-informations.com");
                DtSet9 = new System.Data.DataSet();
                MyCommand9.Fill(DtSet9);
                MyCommand9.Fill(dsPayCategories);
                dgv_PayCategories.DataSource = DtSet9.Tables[0];
                dgv_PayCategories.DataSource = dsPayCategories;
                MyConnection9.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Payment Categories table - " + ex.Message);

                }
                MessageBox.Show("Accounting and Rates Tables Imported");
            }
            else
            {
                MessageBox.Show("There is no AccountingAndRates.xlsx file.");
            }
            
            if (File.Exists(sFilePath2))
            {
                try
                {
                ///
                ///RMGT_T_COMMUNITY
                ///
                string workSheetName10 = "Community";
                System.Data.OleDb.OleDbConnection MyConnection10;
                System.Data.DataSet DtSet10;
                System.Data.OleDb.OleDbDataAdapter MyCommand10;
                MyConnection10 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath2 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
                MyCommand10 = new System.Data.OleDb.OleDbDataAdapter("select COMMUNITY,STATUS from [" + workSheetName10 + "$] WHERE COMMUNITY IS NOT NULL", MyConnection10);
                MyCommand10.TableMappings.Add("Table", "Net-informations.com");
                DtSet10 = new System.Data.DataSet();
                MyCommand10.Fill(DtSet10);
                MyCommand10.Fill(dsCommunity);
                dgv_Community.DataSource = DtSet10.Tables[0];
                dgv_Community.DataSource = dsCommunity;
                MyConnection10.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Community table - " + ex.Message);

                }

                try
                {
                ///
                ///RMGT_T_BUILDINGS
                ///
                string workSheetName11 = "Buildings";
                System.Data.OleDb.OleDbConnection MyConnection11;
                System.Data.DataSet DtSet11;
                System.Data.OleDb.OleDbDataAdapter MyCommand11;
                MyConnection11 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath2 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1;ReadOnly=0\"");
                MyCommand11 = new System.Data.OleDb.OleDbDataAdapter("select BUILDINGID,COMMUNITY,NAME,ADDRESS1,ADDRESS1B,ADDRESS2,POSTCODE,STATE,STATUS,HYPERLINK1,HYPERLINK2,HYPERLINK3,HYPERLINK4,HYPERLINK5,HYPERLINK6,HYPERLINK7,LOCKINGSYSTEMBUILDINGID from [" + workSheetName11 + "$] WHERE BUILDINGID IS NOT NULL", MyConnection11);
                //MyCommand11.TableMappings.Add("Table", "Net-informations.com");
                DtSet11 = new System.Data.DataSet();
                MyCommand11.Fill(DtSet11);
                MyCommand11.Fill(dsBuildings);
                dgv_Building.DataSource = DtSet11.Tables[0];
                dgv_Building.DataSource = dsBuildings;
                MyConnection11.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Buildings table - " + ex.Message);

                }

                try
                {
                ///
                ///RMGT_T_FLOORS
                ///
                string workSheetName12 = "Floors";
                System.Data.OleDb.OleDbConnection MyConnection12;
                System.Data.DataSet DtSet12;
                System.Data.OleDb.OleDbDataAdapter MyCommand12;
                MyConnection12 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath2 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
                MyCommand12 = new System.Data.OleDb.OleDbDataAdapter("select FLOORID,BUILDINGID,FLOORNAME,STATUS from [" + workSheetName12 + "$] WHERE FLOORID IS NOT NULL", MyConnection12);
                MyCommand12.TableMappings.Add("Table", "Net-informations.com");
                DtSet12 = new System.Data.DataSet();
                MyCommand12.Fill(DtSet12);
                MyCommand12.Fill(dsFloors);
                dgv_Floors.DataSource = DtSet12.Tables[0];
                dgv_Floors.DataSource = dsFloors;
                MyConnection12.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Floors table - " + ex.Message);

                }

                try
                {
                ///
                ///RMGT_T_FLOOR_SECTIONS
                ///
                string workSheetName13 = "Floor Sections";
                System.Data.OleDb.OleDbConnection MyConnection13;
                System.Data.DataSet DtSet13;
                System.Data.OleDb.OleDbDataAdapter MyCommand13;
                MyConnection13 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath2 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
                MyCommand13 = new System.Data.OleDb.OleDbDataAdapter("select SECTIONID,FLOORID,FLOORSECTIONNAME,STATUS from [" + workSheetName13 + "$] WHERE SECTIONID IS NOT NULL", MyConnection13);
                MyCommand13.TableMappings.Add("Table", "Net-informations.com");
                DtSet13 = new System.Data.DataSet();
                MyCommand13.Fill(DtSet13);
                MyCommand13.Fill(dsFloorSections);
                dgv_FloorSections.DataSource = DtSet13.Tables[0];
                dgv_FloorSections.DataSource = dsFloorSections;
                MyConnection13.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Floor Sections table - " + ex.Message);

                }

                try
                {
                ///
                ///RMGT_T_ROOMS
                ///
                string workSheetName14 = "Rooms";
                System.Data.OleDb.OleDbConnection MyConnection14;
                System.Data.DataSet DtSet14;
                System.Data.OleDb.OleDbDataAdapter MyCommand14;
                MyConnection14 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath2 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1;ReadOnly=0\"");
                MyCommand14 = new System.Data.OleDb.OleDbDataAdapter("select BEDSPACE,ROOMNO,SECONDARYBEDSPACE,DIRTY,SERVICED,LINEN,STATUS,HYPERLINK1,HYPERLINK2,HYPERLINK3,LOCKINGSYSTEMROOMID from [" + workSheetName14 + "$] WHERE BEDSPACE IS NOT NULL", MyConnection14);
                MyCommand14.TableMappings.Add("Table", "Net-informations.com");
                DtSet14 = new System.Data.DataSet();
                MyCommand14.Fill(DtSet14);
                MyCommand14.Fill(dsRooms);
                dgv_Rooms.DataSource = DtSet14.Tables[0];
                dgv_Rooms.DataSource = dsRooms;
                MyConnection14.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rooms table - " + ex.Message);

                }

                try
                {
                ///
                ///L_U_T_RMGT_T_USE_1
                ///
                string workSheetName15 = "Use 1";
                System.Data.OleDb.OleDbConnection MyConnection15;
                System.Data.DataSet DtSet15;
                System.Data.OleDb.OleDbDataAdapter MyCommand15;
                MyConnection15 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath2 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
                MyCommand15 = new System.Data.OleDb.OleDbDataAdapter("select USE1,DESCRIPTION,STATUS from [" + workSheetName15 + "$] WHERE USE1 IS NOT NULL", MyConnection15);
                MyCommand15.TableMappings.Add("Table", "Net-informations.com");
                DtSet15 = new System.Data.DataSet();
                MyCommand15.Fill(DtSet15);
                MyCommand15.Fill(dsUse1);
                dgv_Use1.DataSource = DtSet15.Tables[0];
                dgv_Use1.DataSource = dsUse1;
                MyConnection15.Close();
                    }
                catch (Exception ex)
                {
                    MessageBox.Show("Use 1 table - " + ex.Message);

                }

                try
                {
                ///
                ///L_U_T_RMGT_T_USE_2
                ///
                string workSheetName16 = "Use 2";
                System.Data.OleDb.OleDbConnection MyConnection16;
                System.Data.DataSet DtSet16;
                System.Data.OleDb.OleDbDataAdapter MyCommand16;
                MyConnection16 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath2 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
                MyCommand16 = new System.Data.OleDb.OleDbDataAdapter("select USE2,DESCRIPTION,STATUS from [" + workSheetName16 + "$]WHERE USE2 IS NOT NULL", MyConnection16);
                MyCommand16.TableMappings.Add("Table", "Net-informations.com");
                DtSet16 = new System.Data.DataSet();
                MyCommand16.Fill(DtSet16);
                MyCommand16.Fill(dsUse2);
                dgv_Use2.DataSource = DtSet16.Tables[0];
                dgv_Use2.DataSource = dsUse2;
                MyConnection16.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Use 2 table - " + ex.Message);

                }

                try
                {
                ///
                ///RMGT_T_ROOM_CONFIGS
                ///
                string workSheetName17 = "Room Configs";
                System.Data.OleDb.OleDbConnection MyConnection17;
                System.Data.DataSet DtSet17;
                System.Data.OleDb.OleDbDataAdapter MyCommand17;
                MyConnection17 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath2 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
                MyCommand17 = new System.Data.OleDb.OleDbDataAdapter("select BEDSPACE,CONFIGNO,ROOMSTYPE,SECTIONID,STARTDATE,ENDDATE,GENDER,PHONEEQUIPNO,PHONEEXTENSION,KEYID,OPERATINGMODE,CAPACITY,ADDRESS1,ELIGIBILITYCRITERIA,USE1,USE2,STATUS,DESIRABILITY from [" + workSheetName17 + "$] WHERE BEDSPACE IS NOT NULL", MyConnection17);
                MyCommand17.TableMappings.Add("Table", "Net-informations.com");
                DtSet17 = new System.Data.DataSet();
                MyCommand17.Fill(DtSet17);
                MyCommand17.Fill(dsRoomConfigs);
                dgv_RoomConfigs.DataSource = DtSet17.Tables[0];
                dgv_RoomConfigs.DataSource = dsRoomConfigs;
                MyConnection17.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Room Configs table - " + ex.Message);

                }

                try
                {
                ///
                ///APPL_T_MATCHING_CRITERIA
                ///
                string workSheetName18 = "Matching Criteria";
                System.Data.OleDb.OleDbConnection MyConnection18;
                System.Data.DataSet DtSet18;
                System.Data.OleDb.OleDbDataAdapter MyCommand18;
                MyConnection18 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath2 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
                MyCommand18 = new System.Data.OleDb.OleDbDataAdapter("select PRIORITYNUMBER,MATCHINGCRITERIADESCRIPTION,DISPLAYORDER,CRITICAL from [" + workSheetName18 + "$] WHERE PRIORITYNUMBER IS NOT NULL", MyConnection18);
                MyCommand18.TableMappings.Add("Table", "Net-informations.com");
                DtSet18 = new System.Data.DataSet();
                MyCommand18.Fill(DtSet18);
                MyCommand18.Fill(dsMatchCrit);
                dgv_MatchCrit.DataSource = DtSet18.Tables[0];
                dgv_MatchCrit.DataSource = dsMatchCrit;
                MyConnection18.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Matching Criteria table - " + ex.Message);

                }

                try
                {
                ///
                ///RMGT_T_INVENTORY
                ///
                string workSheetName19 = "Inventory";
                System.Data.OleDb.OleDbConnection MyConnection19;
                System.Data.DataSet DtSet19;
                System.Data.OleDb.OleDbDataAdapter MyCommand19;
                MyConnection19 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath2 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
                MyCommand19 = new System.Data.OleDb.OleDbDataAdapter("select INVENTORYCODE,ITEM,COMMENT,COST,STATUS from [" + workSheetName19 + "$] WHERE INVENTORYCODE IS NOT NULL", MyConnection19);
                MyCommand19.TableMappings.Add("Table", "Net-informations.com");
                DtSet19 = new System.Data.DataSet();
                MyCommand19.Fill(DtSet19);
                MyCommand19.Fill(dsInventory);
                dgv_Inventory.DataSource = DtSet19.Tables[0];
                dgv_Inventory.DataSource = dsInventory;
                MyConnection19.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Inventory table - " + ex.Message);

                }

                try
                {
                ///
                ///RMGT_T_ROOM_INVENTORY
                ///
                string workSheetName20 = "Room Inventory";
                System.Data.OleDb.OleDbConnection MyConnection20;
                System.Data.DataSet DtSet20;
                System.Data.OleDb.OleDbDataAdapter MyCommand20;
                MyConnection20 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath2 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
                MyCommand20 = new System.Data.OleDb.OleDbDataAdapter("select BEDSPACE,INVENTORYCODE,ASSESSED,STATUS,STATUSCOMMENT,SERIALNUMBER,PURCHASEDDATE,DELETED,DELETEDDATE,DELETEDBY from [" + workSheetName20 + "$] WHERE BEDSPACE IS NOT NULL", MyConnection20);
                MyCommand20.TableMappings.Add("Table", "Net-informations.com");
                DtSet20 = new System.Data.DataSet();
                MyCommand20.Fill(DtSet20);
                MyCommand20.Fill(dsRmInventory);
                dgv_RmInventory.DataSource = DtSet20.Tables[0];
                dgv_RmInventory.DataSource = dsRmInventory;
                MyConnection20.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Room Inventory table - " + ex.Message);

                }

                try
                {
                ///
                ///L_U_T_RMGT_T_ROOM_MAINT_CODE
                ///
                string workSheetName21 = "Room Maintenance Code";
                System.Data.OleDb.OleDbConnection MyConnection21;
                System.Data.DataSet DtSet21;
                System.Data.OleDb.OleDbDataAdapter MyCommand21;
                MyConnection21 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath2 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
                MyCommand21 = new System.Data.OleDb.OleDbDataAdapter("select MAINTENANCECODE,ITEM,STATUS from [" + workSheetName21 + "$] WHERE MAINTENANCECODE IS NOT NULL", MyConnection21);
                MyCommand21.TableMappings.Add("Table", "Net-informations.com");
                DtSet21 = new System.Data.DataSet();
                MyCommand21.Fill(DtSet21);
                MyCommand21.Fill(dsRmMaintCode);
                dgv_RmMaintCode.DataSource = DtSet21.Tables[0];
                dgv_RmMaintCode.DataSource = dsRmMaintCode;
                MyConnection21.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Room Maintenance Code table - " + ex.Message);

                }

                try
                {
                ///
                ///RMGT_T_MAINTENANCE_REF_TO
                ///
                string workSheetName22 = "Maintenance Ref To";
                System.Data.OleDb.OleDbConnection MyConnection22;
                System.Data.DataSet DtSet22;
                System.Data.OleDb.OleDbDataAdapter MyCommand22;
                MyConnection22 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath2 + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
                MyCommand22 = new System.Data.OleDb.OleDbDataAdapter("select REFERRERTOID,REFERREDTONAME,STATUS,FUNCTIONNAME from [" + workSheetName22 + "$]WHERE REFERRERTOID IS NOT NULL", MyConnection22);
                MyCommand22.TableMappings.Add("Table", "Net-informations.com");
                DtSet22 = new System.Data.DataSet();
                MyCommand22.Fill(DtSet22);
                MyCommand22.Fill(dsMaintRefTo);
                dgv_MaintRefTo.DataSource = DtSet22.Tables[0];
                dgv_MaintRefTo.DataSource = dsMaintRefTo;
                MyConnection22.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Maintenance Ref To table - " + ex.Message);

                }
                MessageBox.Show("Rooms and Beds Tables Imported");
            }
            else
            {
                MessageBox.Show("There is no RoomsAndBeds.xlsx file.");
            }
        }
        public StringBuilder strDataIssues = new StringBuilder();
        public void btn_TestLength_Click(object sender, EventArgs e)
        {
            string sFilePath1 = txt_WorkbooksLoc.Text + "\\AccountingAndRates.xlsx";
            string sFilePath2 = txt_WorkbooksLoc.Text + "\\RoomsAndBeds.xlsx";
            txt_DataIssues.Text = "";
            strDataIssues.Clear();
            txt_DataIssues.Visible = true;
            if (File.Exists(sFilePath1))
            {
                ///
                ///Check length of each item in Accounts Table
                ///
                try
                {
                    foreach (DataRow row in dsAccounts.Rows)
                    {
                        if (row["PK_ACCOUNT_CODE"].ToString().Length > 12)
                        {
                            strDataIssues.Append(row["PK_ACCOUNT_CODE"].ToString() + " is too long for the PK_ACCOUNT_CODE Column in the Accounts Table.\r\n\r\n");
                        }
                        if (row["ACCOUNT_NAME"].ToString().Length > 50)
                        {
                            strDataIssues.Append(row["ACCOUNT_NAME"].ToString() + " is too long for the ACCOUNT_NAME Column in the Accounts Table.\r\n\r\n");
                        }
                        if (row["ACCOUNT_TYPE"].ToString().Length > 20)
                        {
                            strDataIssues.Append(row["ACCOUNT_TYPE"].ToString() + " is too long for the ACCOUNT_TYPE Column in the Accounts Table.\r\n\r\n");
                        }
                        if (row["ALIAS_CODE"].ToString().Length > 30)
                        {
                            strDataIssues.Append(row["ALIAS_CODE"].ToString() + " is too long for the ALIAS_CODE Column in the Accounts Table.\r\n\r\n");
                        }
                        if (row["STATUS"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["STATUS"].ToString() + " is too long for the STATUS Column in the Accounts Table.\r\n\r\n"); ;
                        }
                        if (row["IX_RECEIVABLE"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["IX_RECEIVABLE"].ToString() + " is too long for the IX_RECEIVABLE Column in the Accounts Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("AccDR - " + ex.Message);
                }
                ///
                ///Check length of each item in Tax TX Types Table
                ///
                try
                {
                    foreach (DataRow row in dsTaxTXTypes.Rows)
                    {
                        if (row["PK_TAX_TXTYPE"].ToString().Length > 10)
                        {
                            strDataIssues.Append(row["PK_TAX_TXTYPE"].ToString() + " is too long for the PK_TAX_TXTYPE Column in the TaxTXTypes Table.\r\n\r\n");
                        }
                        if (row["TAX_TRANSACTION_TYPE_DESCRIPTION"].ToString().Length > 30)
                        {
                            strDataIssues.Append(row["TAX_TRANSACTION_TYPE_DESCRIPTION"].ToString() + " is too long for the TAX_TRANSACTION_TYPE_DESCRIPTION Column in the TaxTXTypes Table.\r\n\r\n");
                        }
                        if (row["FK_DEBIT_ACCOUNT"].ToString().Length > 12)
                        {
                            strDataIssues.Append(row["FK_DEBIT_ACCOUNT"].ToString() + " is too long for the FK_DEBIT_ACCOUNT Column in the TaxTXTypes Table.\r\n\r\n");
                        }
                        if (row["FK_CREDIT_ACCOUNT"].ToString().Length > 12)
                        {
                            strDataIssues.Append(row["FK_CREDIT_ACCOUNT"].ToString() + " is too long for the FK_CREDIT_ACCOUNT Column in the TaxTXTypes Table.\r\n\r\n");
                        }
                        if (row["PERCENTAGE"].ToString().Length > 18)
                        {
                            strDataIssues.Append(row["PERCENTAGE"].ToString() + " is too long for the PERCENTAGE Column in the TaxTXTypes Table.\r\n\r\n");
                        }
                        if (row["SECONDARY_CODE"].ToString().Length > 50)
                        {
                            strDataIssues.Append(row["SECONDARY_CODE"].ToString() + " is too long for the SECONDARY_CODE Column in the TaxTXTypes Table.\r\n\r\n");
                        }
                        if (row["STATUS"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["STATUS"].ToString() + " is too long for the STATUS Column in the TaxTXTypes Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("TaxTXDR - " + ex.Message);
                }
                ///
                ///Check length of each item in TX Types Table
                ///
                try
                {
                    foreach (DataRow row in dsTXTypes.Rows)
                    {
                        if (row["PK_TXTYPE"].ToString().Length > 10)
                        {
                            strDataIssues.Append(row["PK_TXTYPE"].ToString() + " is too long for the PK_TXTYPE Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["TRANSACTION_TYPE_DEFAULT"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["TRANSACTION_TYPE_DEFAULT"].ToString() + " is too long for the TRANSACTION_TYPE_DEFAULT Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["CHARGES"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["CHARGES"].ToString() + " is too long for the CHARGES Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["UPLOADABLE"].ToString().Length > 12)
                        {
                            strDataIssues.Append(row["UPLOADABLE"].ToString() + " is too long for the UPLOADABLE Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["TRANSACTION_TYPE_DESCRIPTION"].ToString().Length > 50)
                        {
                            strDataIssues.Append(row["TRANSACTION_TYPE_DESCRIPTION"].ToString() + " is too long for the TRANSACTION_TYPE_DESCRIPTION Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["FK_DEBIT_ACCOUNT"].ToString().Length > 12)
                        {
                            strDataIssues.Append(row["FK_DEBIT_ACCOUNT"].ToString() + " is too long for the FK_DEBIT_ACCOUNT Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["SECONDARY_CODE"].ToString().Length > 50)
                        {
                            strDataIssues.Append(row["SECONDARY_CODE"].ToString() + " is too long for the SECONDARY_CODE Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["FK_CREDIT_ACCOUNT"].ToString().Length > 12)
                        {
                            strDataIssues.Append(row["FK_CREDIT_ACCOUNT"].ToString() + " is too long for the FK_CREDIT_ACCOUNT Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["FK_TAX_TXTYPE1"].ToString().Length > 10)
                        {
                            strDataIssues.Append(row["FK_TAX_TXTYPE1"].ToString() + " is too long for the FK_TAX_TXTYPE1 Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["TAX1_PERCENTAGE"].ToString().Length > 18)
                        {
                            strDataIssues.Append(row["TAX1_PERCENTAGE"].ToString() + " is too long for the TAX1_PERCENTAGE Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["FK_TAX_TXTYPE2"].ToString().Length > 10)
                        {
                            strDataIssues.Append(row["FK_TAX_TXTYPE2"].ToString() + " is too long for the FK_TAX_TXTYPE2 Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["TAX2_PERCENTAGE"].ToString().Length > 18)
                        {
                            strDataIssues.Append(row["TAX2_PERCENTAGE"].ToString() + " is too long for the TAX2_PERCENTAGE Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["FK_TAX_TXTYPE3"].ToString().Length > 10)
                        {
                            strDataIssues.Append(row["FK_TAX_TXTYPE3"].ToString() + " is too long for the FK_TAX_TXTYPE3 Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["TAX3_PERCENTAGE"].ToString().Length > 18)
                        {
                            strDataIssues.Append(row["TAX3_PERCENTAGE"].ToString() + " is too long for the TAX3_PERCENTAGE Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["FK_TAX_TXTYPE4"].ToString().Length > 10)
                        {
                            strDataIssues.Append(row["FK_TAX_TXTYPE4"].ToString() + " is too long for the FK_TAX_TXTYPE4 Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["TAX4_PERCENTAGE"].ToString().Length > 18)
                        {
                            strDataIssues.Append(row["TAX4_PERCENTAGE"].ToString() + " is too long for the TAX4_PERCENTAGE Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["MIN_TX"].ToString().Length > 18)
                        {
                            strDataIssues.Append(row["MIN_TX"].ToString() + " is too long for the MIN_TX Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["MAX_TX"].ToString().Length > 18)
                        {
                            strDataIssues.Append(row["MAX_TX"].ToString() + " is too long for the MAX_TX Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["BB_CLOSE_ACC"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["STATUS"].ToString() + " is too long for the STATUS Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["STATUS"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["STATUS"].ToString() + " is too long for the STATUS Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["CREDIT_INVOICE"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["CREDIT_INVOICE"].ToString() + " is too long for the CREDIT_INVOICE Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["POINTOFSALE"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["POINTOFSALE"].ToString() + " is too long for the POINTOFSALE Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["TRANSFER"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["TRANSFER"].ToString() + " is too long for the TRANSFER Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["BOND"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["BOND"].ToString() + " is too long for the BOND Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["REFUND"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["REFUND"].ToString() + " is too long for the REFUND Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["PAYMENT"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["PAYMENT"].ToString() + " is too long for the PAYMENT Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["PAYMENTBOND"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["PAYMENTBOND"].ToString() + " is too long for the PAYMENTBOND Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["BANKTRANSFER"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["BANKTRANSFER"].ToString() + " is too long for the BANKTRANSFER Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["IT"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["IT"].ToString() + " is too long for the IT Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["PI"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["PI"].ToString() + " is too long for the PI Column in the TXTypes Table.\r\n\r\n");
                        }
                        if (row["APPLICATION"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["APPLICATION"].ToString() + " is too long for the APPLICATION Column in the TXTypes Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("TXDR - " + ex.Message);
                }
                ///
                ///Check length of each item in Terms Table
                ///
                try
                {
                    foreach (DataRow row in dsTerms.Rows)
                    {
                        if (row["PK_TERM_ID"].ToString().Length > 8)
                        {
                            strDataIssues.Append(row["PK_TERM_ID"].ToString() + " is too long for the PK_TERM_ID Column in the Terms Table.\r\n\r\n");
                        }
                        if (row["TERM_DATES_NAME"].ToString().Length > 25)
                        {
                            strDataIssues.Append(row["TERM_DATES_NAME"].ToString() + " is too long for the TERM_DATES_NAME Column in the Terms Table.\r\n\r\n");
                        }
                        if (row["TERM_DATES_NOMINATED"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["TERM_DATES_NOMINATED"].ToString() + " is too long for the TERM_DATES_NOMINATED Column in the Terms Table.\r\n\r\n");
                        }
                        if (row["PERCENTAGE_TO_BILL"].ToString().Length > 18)
                        {
                            strDataIssues.Append(row["PERCENTAGE_TO_BILL"].ToString() + " is too long for the PERCENTAGE_TO_BILL Column in the Terms Table.\r\n\r\n");
                        }
                        if (row["TERM_DATES_UPLOAD"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["TERM_DATES_UPLOAD"].ToString() + " is too long for the PK_TERM_DATES_UPLOADTERM_ID Column in the Terms Table.\r\n\r\n");
                        }
                        if (row["STATUS"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["STATUS"].ToString() + " is too long for the STATUS Column in the Terms Table.\r\n\r\n");
                        }
                        if (row["ROOM_TERM"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["ROOM_TERM"].ToString() + " is too long for the ROOM_TERM Column in the Terms Table.\r\n\r\n");
                        }
                        if (row["PLAN_TERM"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["PLAN_TERM"].ToString() + " is too long for the PLAN_TERM Column in the Terms Table.\r\n\r\n");
                        }
                        if (row["BILLING_TERM"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["BILLING_TERM"].ToString() + " is too long for the BILLING_TERM Column in the Terms Table.\r\n\r\n");
                        }
                        if (row["PROPERTY_TERM"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["PROPERTY_TERM"].ToString() + " is too long for the PROPERTY_TERM Column in the Terms Table.\r\n\r\n");
                        }
                        if (row["PAYMENT_TERM"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["PAYMENT_TERM"].ToString() + " is too long for the PAYMENT_TERM Column in the Terms Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terms - " + ex.Message);
                }
                ///
                ///Check length of each item in Rates Table
                ///
                try
                {
                    foreach (DataRow row in dsRates.Rows)
                    {
                        if (row["CK_RATE_CODE"].ToString().Length > 10)
                        {
                            strDataIssues.Append(row["CK_RATE_CODE"].ToString() + " is too long for the CK_RATE_CODE Column in the Rates Table.\r\n\r\n");
                        }
                        if (row["Rates_Description"].ToString().Length > 50)
                        {
                            strDataIssues.Append(row["Rates_Description"].ToString() + " is too long for the Rates_Description Column in the Rates Table.\r\n\r\n");
                        }
                        if (row["Rates_Type"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["Rates_Type"].ToString() + " is too long for the Rates_Type Column in the Rates Table.\r\n\r\n");
                        }
                        if (row["Rate_Config_Description"].ToString().Length > 50)
                        {
                            strDataIssues.Append(row["Rate_Config_Description"].ToString() + " is too long for the Rate_Config_Description Column in the Rates Table.\r\n\r\n");
                        }
                        if (row["Rates_Service_Type"].ToString().Length > 15)
                        {
                            strDataIssues.Append(row["Rates_Service_Type"].ToString() + " is too long for the Rates_Service_Type Column in the Rates Table.\r\n\r\n");
                        }
                        if (row["Rates_Linen_Type"].ToString().Length > 15)
                        {
                            strDataIssues.Append(row["Rates_Linen_Type"].ToString() + " is too long for the Rates_Linen_Type Column in the Rates Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rates - " + ex.Message);
                }
                ///
                ///Check length of each item in Rates Table
                ///
                try
                {
                    foreach (DataRow row in dsRateSplits.Rows)
                    {
                        if (row["CK_RATE_CODE"].ToString().Length > 10)
                        {
                            strDataIssues.Append(row["CK_RATE_CODE"].ToString() + " is too long for the CK_RATE_CODE Column in the RateSplits Table.\r\n\r\n");
                        }
                        if (row["CK_RATE_CONFIG_NO"].ToString().Length > 11)
                        {
                            strDataIssues.Append(row["CK_RATE_CONFIG_NO"].ToString() + " is too long for the CK_RATE_CONFIG_NO Column in the RateSplits Table.\r\n\r\n");
                        }
                        if (row["CK_TXTYPE"].ToString().Length > 10)
                        {
                            strDataIssues.Append(row["CK_TXTYPE"].ToString() + " is too long for the CK_TXTYPE Column in the RateSplits Table.\r\n\r\n");
                        }
                        if (row["RATES_SPLIT_AMOUNT"].ToString().Length > 18)
                        {
                            strDataIssues.Append(row["RATES_SPLIT_AMOUNT"].ToString() + " is too long for the RATES_SPLIT_AMOUNT Column in the RateSplits Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("RateSplits - " + ex.Message);
                }
                ///
                ///Check length of each item in Room Types Rates Table
                ///
                try
                {
                    foreach (DataRow row in dsRmTypesRates.Rows)
                    {
                        if (row["PK_ROOM_TYPE"].ToString().Length > 15)
                        {
                            strDataIssues.Append(row["PK_ROOM_TYPE"].ToString() + " is too long for the PK_ROOM_TYPE Column in the RmTypesRates Table.\r\n\r\n");
                        }
                        if (row["ROOM_TYPE_ALIAS_NAME"].ToString().Length > 50)
                        {
                            strDataIssues.Append(row["ROOM_TYPE_ALIAS_NAME"].ToString() + " is too long for the ROOM_TYPE_ALIAS_NAME Column in the RmTypesRates Table.\r\n\r\n");
                        }
                        if (row["FK_RATE_CODE"].ToString().Length > 10)
                        {
                            strDataIssues.Append(row["FK_RATE_CODE"].ToString() + " is too long for the FK_RATE_CODE Column in the RmTypesRates Table.\r\n\r\n");
                        }
                        if (row["ROOM_TYPE_DESCRIPTION"].ToString().Length > 30)
                        {
                            strDataIssues.Append(row["ROOM_TYPE_DESCRIPTION"].ToString() + " is too long for the ROOM_TYPE_DESCRIPTION Column in the RmTypesRates Table.\r\n\r\n");
                        }
                        if (row["TURN_AROUND_TIME"].ToString().Length > 11)
                        {
                            strDataIssues.Append(row["TURN_AROUND_TIME"].ToString() + " is too long for the TURN_AROUND_TIME Column in the RmTypesRates Table.\r\n\r\n");
                        }
                        if (row["TURN_AROUND_TYPE"].ToString().Length > 15)
                        {
                            strDataIssues.Append(row["TURN_AROUND_TYPE"].ToString() + " is too long for the TURN_AROUND_TYPE Column in the RmTypesRates Table.\r\n\r\n");
                        }
                        if (row["STATUS"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["STATUS"].ToString() + " is too long for the STATUS Column in the RmTypesRates Table.\r\n\r\n");
                        }
                        if (row["UD_HYPERLINK"].ToString().Length > 200)
                        {
                            strDataIssues.Append(row["UD_HYPERLINK"].ToString() + " is too long for the UD_HYPERLINK Column in the RmTypesRates Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("RmTypesRates - " + ex.Message);
                }
                ///
                ///Check length of each item in Plan Type Rates Table
                ///
                try
                {
                    foreach (DataRow row in dsPlanTypesRates.Rows)
                    {
                        if (row["PK_PLAN_TYPE"].ToString().Length > 10)
                        {
                            strDataIssues.Append(row["PK_PLAN_TYPE"].ToString() + " is too long for the PK_PLAN_TYPE Column in the PlanTypesRates Table.\r\n\r\n");
                        }
                        if (row["FK_RATE_CODE"].ToString().Length > 10)
                        {
                            strDataIssues.Append(row["FK_RATE_CODE"].ToString() + " is too long for the FK_RATE_CODE Column in the PlanTypesRates Table.\r\n\r\n");
                        }
                        if (row["PLAN_TYPE_DESCRIPTION"].ToString().Length > 30)
                        {
                            strDataIssues.Append(row["PLAN_TYPE_DESCRIPTION"].ToString() + " is too long for the PLAN_TYPE_DESCRIPTION Column in the PlanTypesRates Table.\r\n\r\n");
                        }
                        if (row["PLAN_TYPE_TYPE"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["PLAN_TYPE_TYPE"].ToString() + " is too long for the PLAN_TYPE_TYPE Column in the PlanTypesRates Table.\r\n\r\n");
                        }
                        if (row["STATUS"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["STATUS"].ToString() + " is too long for the STATUS Column in the PlanTypesRates Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("PlanTypesRates - " + ex.Message);
                }
                ///
                ///Check length of each item in Plan Type Rates Table
                ///
                try
                {
                    foreach (DataRow row in dsPayCategories.Rows)
                    {
                        if (row["PK_METHOD_CODE"].ToString().Length > 25)
                        {
                            strDataIssues.Append(row["PK_METHOD_CODE"].ToString() + " is too long for the PK_METHOD_CODE Column in the PayCategories Table.\r\n\r\n");
                        }
                        if (row["METHOD_DESCRIPTION"].ToString().Length > 30)
                        {
                            strDataIssues.Append(row["METHOD_DESCRIPTION"].ToString() + " is too long for the METHOD_DESCRIPTION Column in the PayCategories Table.\r\n\r\n");
                        }
                        if (row["STATUS"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["STATUS"].ToString() + " is too long for the STATUS Column in the PayCategories Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("PayCategories - " + ex.Message);
                }
            }
            else
            {
                strDataIssues.Append("There is no AccountsAndRates.xls at " + txt_WorkbooksLoc.Text + ".");
            }
            if (File.Exists(sFilePath2))
                {
                ///
                ///Rooms and Beds
                ///
                ///
                ///Check length of each item in Community Table
                ///
                try
                {
                    foreach (DataRow row in dsCommunity.Rows)
                    {
                        if (row["COMMUNITY"].ToString().Length > 25)
                        {
                            strDataIssues.Append(row["COMMUNITY"].ToString() + " is too long for the COMMUNITY Column in the Community Table.\r\n\r\n");
                        }
                        if (row["STATUS"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["STATUS"].ToString() + " is too long for the STATUS Column in the Community Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
                ///
                ///Check length of each item in Buildings Table
                ///
                try
                {
                    foreach (DataRow row in dsBuildings.Rows)
                    {
                        if (row["BUILDINGID"].ToString().Length > 8)
                        {
                            strDataIssues.Append(row["BUILDINGID"].ToString() + " is too long for the BUILDINGID Column in the Buildings Table.\r\n\r\n");
                        }
                        if (row["COMMUNITY"].ToString().Length > 25)
                        {
                            strDataIssues.Append(row["COMMUNITY"].ToString() + " is too long for the COMMUNITY Column in the Buildings Table.\r\n\r\n");
                        }
                        if (row["NAME"].ToString().Length > 30)
                        {
                            strDataIssues.Append(row["NAME"].ToString() + " is too long for the NAME Column in the Buildings Table.\r\n\r\n");
                        }
                        if (row["ADDRESS1"].ToString().Length > 50)
                        {
                            strDataIssues.Append(row["ADDRESS1"].ToString() + " is too long for theADDRESS_1 Column in the Buildings Table.\r\n\r\n");
                        }
                        if (row["ADDRESS1B"].ToString().Length > 50)
                        {
                            strDataIssues.Append(row["ADDRESS1B"].ToString() + " is too long for the ADDRESS1B Column in the Buildings Table.\r\n\r\n");
                        }
                        if (row["ADDRESS2"].ToString().Length > 50)
                        {
                            strDataIssues.Append(row["ADDRESS2"].ToString() + " is too long for the ADDRESS2 Column in the Buildings Table.\r\n\r\n");
                        }
                        if (row["POSTCODE"].ToString().Length > 15)
                        {
                            strDataIssues.Append(row["POSTCODE"].ToString() + " is too long for the POSTCODE Column in the Buildings Table.\r\n\r\n");
                        }
                        if (row["STATE"].ToString().Length > 15)
                        {
                            strDataIssues.Append(row["STATE"].ToString() + " is too long for the STATE Column in the Buildings Table.\r\n\r\n");
                        }
                        if (row["STATUS"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["STATUS"].ToString() + " is too long for the STATUS Column in the Buildings Table.\r\n\r\n");
                        }
                        if (row["HYPERLINK1"].ToString().Length > 200)
                        {
                            strDataIssues.Append(row["HYPERLINK1"].ToString() + " is too long for the HYPERLINK1 Column in the Buildings Table.\r\n\r\n");
                        }
                        if (row["HYPERLINK2"].ToString().Length > 200)
                        {
                            strDataIssues.Append(row["HYPERLINK2"].ToString() + " is too long for the HYPERLINK2 Column in the Buildings Table.\r\n\r\n");
                        }
                        if (row["HYPERLINK3"].ToString().Length > 200)
                        {
                            strDataIssues.Append(row["HYPERLINK3"].ToString() + " is too long for the HYPERLINK3 Column in the Buildings Table.\r\n\r\n");
                        }
                        if (row["HYPERLINK4"].ToString().Length > 200)
                        {
                            strDataIssues.Append(row["HYPERLINK4"].ToString() + " is too long for the HYPERLINK4 Column in the Buildings Table.\r\n\r\n");
                        }
                        if (row["HYPERLINK5"].ToString().Length > 200)
                        {
                            strDataIssues.Append(row["HYPERLINK5"].ToString() + " is too long for the HYPERLINK5 Column in the Buildings Table.\r\n\r\n");
                        }
                        if (row["HYPERLINK6"].ToString().Length > 200)
                        {
                            strDataIssues.Append(row["HYPERLINK6"].ToString() + " is too long for the HYPERLINK6 Column in the Buildings Table.\r\n\r\n");
                        }
                        if (row["HYPERLINK7"].ToString().Length > 200)
                        {
                            strDataIssues.Append(row["HYPERLINK7"].ToString() + " is too long for the HYPERLINK7 Column in the Buildings Table.\r\n\r\n");
                        }
                        if (row["LOCKINGSYSTEMBUILDINGID"].ToString().Length > 30)
                        {
                            strDataIssues.Append(row["LOCKINGSYSTEMBUILDINGID"].ToString() + " is too long for the LOCKINGSYSTEMBUILDINGID Column in the Buildings Table.\r\n\r\n");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ///
                ///Check length of each item in Floors Table
                ///
                try
                {
                    foreach (DataRow row in dsFloors.Rows)
                    {
                        if (row["FLOORID"].ToString().Length > 8)
                        {
                            strDataIssues.Append(row["FLOORID"].ToString() + " is too long for the FLOORID Column in the Floors Table.\r\n\r\n");
                        }
                        if (row["BUILDINGID"].ToString().Length > 8)
                        {
                            strDataIssues.Append(row["BUILDINGID"].ToString() + " is too long for the BUILDINGID Column in the Floors Table.\r\n\r\n");
                        }
                        if (row["FLOORNAME"].ToString().Length > 50)
                        {
                            strDataIssues.Append(row["FLOORNAME"].ToString() + " is too long for the FLOORNAME Column in the Floors Table.\r\n\r\n");
                        }
                        if (row["STATUS"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["STATUS"].ToString() + " is too long for the STATUS Column in the Floors Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ///
                ///Check length of each item in FloorSections Table
                ///
                try
                {
                    foreach (DataRow row in dsFloorSections.Rows)
                    {
                        if (row["SECTIONID"].ToString().Length > 8)
                        {
                            strDataIssues.Append(row["SECTIONID"].ToString() + " is too long for the SECTIONID Column in the FloorSections Table.\r\n\r\n");
                        }
                        if (row["FLOORID"].ToString().Length > 8)
                        {
                            strDataIssues.Append(row["FLOORID"].ToString() + " is too long for the FLOORID Column in the FloorSections Table.\r\n\r\n");
                        }
                        if (row["FLOORSECTIONNAME"].ToString().Length > 50)
                        {
                            strDataIssues.Append(row["FLOORSECTIONNAME"].ToString() + " is too long for the FLOORSECTIONNAME Column in the FloorSections Table.\r\n\r\n");
                        }
                        if (row["STATUS"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["STATUS"].ToString() + " is too long for the STATUS Column in the FloorSections Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ///
                ///Check length of each item in Rooms Table
                ///
                try
                {
                    foreach (DataRow row in dsRooms.Rows)
                    {
                        if (row["BEDSPACE"].ToString().Length > 10)
                        {
                            strDataIssues.Append(row["BEDSPACE"].ToString() + " is too long for the BEDSPACE Column in the Rooms Table.\r\n\r\n");
                        }
                        if (row["ROOMNO"].ToString().Length > 10)
                        {
                            strDataIssues.Append(row["ROOMNO"].ToString() + " is too long for the ROOMNO Column in the Rooms Table.\r\n\r\n");
                        }
                        if (row["SECONDARYBEDSPACE"].ToString().Length > 10)
                        {
                            strDataIssues.Append(row["SECONDARYBEDSPACE"].ToString() + " is too long for the SECONDARYBEDSPACE Column in the Rooms Table.\r\n\r\n");
                        }
                        if (row["DIRTY"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["DIRTY"].ToString() + " is too long for the DIRTY Column in the Rooms Table.\r\n\r\n");
                        }
                        if (row["STATUS"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["STATUS"].ToString() + " is too long for the STATUS Column in the Rooms Table.\r\n\r\n");
                        }
                        if (row["HYPERLINK1"].ToString().Length > 200)
                        {
                            strDataIssues.Append(row["HYPERLINK1"].ToString() + " is too long for the HYPERLINK1 Column in the Rooms Table.\r\n\r\n");
                        }
                        if (row["HYPERLINK2"].ToString().Length > 200)
                        {
                            strDataIssues.Append(row["HYPERLINK2"].ToString() + " is too long for the HYPERLINK2 Column in the Rooms Table.\r\n\r\n");
                        }
                        if (row["HYPERLINK3"].ToString().Length > 200)
                        {
                            strDataIssues.Append(row["HYPERLINK3"].ToString() + " is too long for the HYPERLINK3 Column in the Rooms Table.\r\n\r\n");
                        }
                        if (row["LOCKINGSYSTEMROOMID"].ToString().Length > 30)
                        {
                            strDataIssues.Append(row["LOCKINGSYSTEMROOMID"].ToString() + " is too long for the LOCKINGSYSTEMROOMID Column in the Rooms Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ///
                ///Check length of each item in Use1 Table
                ///
                try
                {
                    foreach (DataRow row in dsUse1.Rows)
                    {
                        if (row["USE1"].ToString().Length > 20)
                        {
                            strDataIssues.Append(row["USE1"].ToString() + " is too long for the USE1 Column in the Use1 Table.\r\n\r\n");
                        }
                        if (row["DESCRIPTION"].ToString().Length > 20)
                        {
                            strDataIssues.Append(row["DESCRIPTION"].ToString() + " is too long for the DESCRIPTION Column in the Use1 Table.\r\n\r\n");
                        }
                        if (row["STATUS"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["STATUS"].ToString() + " is too long for the STATUS Column in the Use1 Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ///
                ///Check length of each item in Use2 Table
                ///
                try
                {
                    foreach (DataRow row in dsUse2.Rows)
                    {
                        if (row["USE2"].ToString().Length > 20)
                        {
                            strDataIssues.Append(row["USE2"].ToString() + " is too long for the USE2 Column in the Use2 Table.\r\n\r\n");
                        }
                        if (row["DESCRIPTION"].ToString().Length > 20)
                        {
                            strDataIssues.Append(row["DESCRIPTION"].ToString() + " is too long for the DESCRIPTION Column in the Use2 Table.\r\n\r\n");
                        }
                        if (row["STATUS"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["STATUS"].ToString() + " is too long for the STATUS Column in the Use2 Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ///
                ///Check length of each item in RoomConfigs Table
                ///
                try
                {
                    foreach (DataRow row in dsRoomConfigs.Rows)
                    {
                        if (row["BEDSPACE"].ToString().Length > 10)
                        {
                            strDataIssues.Append(row["BEDSPACE"].ToString() + " is too long for the BEDSPACE Column in the RoomConfigs Table.\r\n\r\n");
                        }
                        if (row["CONFIGNO"].ToString().Length > 11)
                        {
                            strDataIssues.Append(row["CONFIGNO"].ToString() + " is too long for the CONFIGNO Column in the RoomConfigs Table.\r\n\r\n");
                        }
                        if (row["ROOMSTYPE"].ToString().Length > 15)
                        {
                            strDataIssues.Append(row["ROOMSTYPE"].ToString() + " is too long for the ROOMSTYPE Column in the RoomConfigs Table.\r\n\r\n");
                        }
                        if (row["SECTIONID"].ToString().Length > 8)
                        {
                            strDataIssues.Append(row["SECTIONID"].ToString() + " is too long for the SECTIONID Column in the RoomConfigs Table.\r\n\r\n");
                        }
                        if (row["GENDER"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["GENDER"].ToString() + " is too long for the GENDER Column in the RoomConfigs Table.\r\n\r\n");
                        }
                        if (row["PHONEEQUIPNO"].ToString().Length > 4)
                        {
                            strDataIssues.Append(row["PHONEEQUIPNO"].ToString() + " is too long for the PHONEEQUIPNO Column in the RoomConfigs Table.\r\n\r\n");
                        }
                        if (row["PHONEEXTENSION"].ToString().Length > 16)
                        {
                            strDataIssues.Append(row["PHONEEXTENSION"].ToString() + " is too long for the PHONEEXTENSION Column in the RoomConfigs Table.\r\n\r\n");
                        }
                        if (row["KEYID"].ToString().Length > 20)
                        {
                            strDataIssues.Append(row["KEYID"].ToString() + " is too long for the KEYID Column in the RoomConfigs Table.\r\n\r\n");
                        }
                        if (row["OPERATINGMODE"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["OPERATINGMODE"].ToString() + " is too long for the OPERATINGMODE Column in the RoomConfigs Table.\r\n\r\n");
                        }
                        if (row["CAPACITY"].ToString().Length > 11)
                        {
                            strDataIssues.Append(row["CAPACITY"].ToString() + " is too long for the CAPACITY Column in the RoomConfigs Table.\r\n\r\n");
                        }
                        if (row["ADDRESS1"].ToString().Length > 50)
                        {
                            strDataIssues.Append(row["ADDRESS1"].ToString() + " is too long for the ADDRESS1 Column in the RoomConfigs Table.\r\n\r\n");
                        }
                        if (row["ELIGIBILITYCRITERIA"].ToString().Length > 250)
                        {
                            strDataIssues.Append(row["ELIGIBILITYCRITERIA"].ToString() + " is too long for the ELIGIBILITYCRITERIA Column in the RoomConfigs Table.\r\n\r\n");
                        }
                        if (row["USE1"].ToString().Length > 20)
                        {
                            strDataIssues.Append(row["USE1"].ToString() + " is too long for the USE1 Column in the RoomConfigs Table.\r\n\r\n");
                        }
                        if (row["USE2"].ToString().Length > 20)
                        {
                            strDataIssues.Append(row["USE2"].ToString() + " is too long for the USE2 Column in the RoomConfigs Table.\r\n\r\n");
                        }
                        if (row["STATUS"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["STATUS"].ToString() + " is too long for the STATUS Column in the RoomConfigs Table.\r\n\r\n");
                        }
                        if (row["DESIRABILITY"].ToString().Length > 11)
                        {
                            strDataIssues.Append(row["DESIRABILITY"].ToString() + " is too long for the DESIRABILITY Column in the RoomConfigs Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ///
                ///Check length of each item in MatchCrit Table
                ///
                try
                {
                    foreach (DataRow row in dsMatchCrit.Rows)
                    {
                        if (row["PRIORITYNUMBER"].ToString().Length > 11)
                        {
                            strDataIssues.Append(row["PRIORITYNUMBER"].ToString() + " is too long for the PRIORITYNUMBER Column in the MatchCrit Table.\r\n\r\n");
                        }
                        if (row["MATCHINGCRITERIADESCRIPTION"].ToString().Length > 50)
                        {
                            strDataIssues.Append(row["MATCHINGCRITERIADESCRIPTION"].ToString() + " is too long for the MATCHINGCRITERIADESCRIPTION Column in the MatchCrit Table.\r\n\r\n");
                        }
                        if (row["DISPLAYORDER"].ToString().Length > 11)
                        {
                            strDataIssues.Append(row["DISPLAYORDER"].ToString() + " is too long for the DISPLAYORDER Column in the MatchCrit Table.\r\n\r\n");
                        }
                        if (row["CRITICAL"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["CRITICAL"].ToString() + " is too long for the CRITICAL Column in the MatchCrit Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ///
                ///Check length of each item in Inventory Table
                ///
                try
                {
                    foreach (DataRow row in dsInventory.Rows)
                    {
                        if (row["INVENTORYCODE"].ToString().Length > 10)
                        {
                            strDataIssues.Append(row["INVENTORYCODE"].ToString() + " is too long for the INVENTORYCODE Column in the Inventory Table.\r\n\r\n");
                        }
                        if (row["ITEM"].ToString().Length > 50)
                        {
                            strDataIssues.Append(row["ITEM"].ToString() + " is too long for the ITEM Column in the Inventory Table.\r\n\r\n");
                        }
                        if (row["COMMENT"].ToString().Length > 50)
                        {
                            strDataIssues.Append(row["COMMENT"].ToString() + " is too long for the COMMENT Column in the Inventory Table.\r\n\r\n");
                        }
                        if (row["COST"].ToString().Length > 18)
                        {
                            strDataIssues.Append(row["COST"].ToString() + " is too long for the COST Column in the Inventory Table.\r\n\r\n");
                        }
                        if (row["STATUS"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["STATUS"].ToString() + " is too long for the STATUS Column in the Inventory Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ///
                ///Check length of each item in RmInventory Table
                ///
                try
                {
                    foreach (DataRow row in dsRmInventory.Rows)
                    {
                        if (row["BEDSPACE"].ToString().Length > 10)
                        {
                            strDataIssues.Append(row["BEDSPACE"].ToString() + " is too long for the BEDSPACE Column in the RmInventory Table.\r\n\r\n");
                        }
                        if (row["INVENTORYCODE"].ToString().Length > 10)
                        {
                            strDataIssues.Append(row["INVENTORYCODE"].ToString() + " is too long for the INVENTORYCODE Column in the RmInventory Table.\r\n\r\n");
                        }
                        if (row["STATUS"].ToString().Length > 20)
                        {
                            strDataIssues.Append(row["STATUS"].ToString() + " is too long for the STATUS Column in the RmInventory Table.\r\n\r\n");
                        }
                        if (row["STATUSCOMMENT"].ToString().Length > 250)
                        {
                            strDataIssues.Append(row["STATUSCOMMENT"].ToString() + " is too long for the STATUSCOMMENT Column in the RmInventory Table.\r\n\r\n");
                        }
                        if (row["SERIALNUMBER"].ToString().Length > 30)
                        {
                            strDataIssues.Append(row["SERIALNUMBER"].ToString() + " is too long for the SERIALNUMBER Column in the RmInventory Table.\r\n\r\n");
                        }
                        if (row["DELETED"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["DELETED"].ToString() + " is too long for the DELETED Column in the RmInventory Table.\r\n\r\n");
                        }
                        if (row["DELETEDBY"].ToString().Length > 30)
                        {
                            strDataIssues.Append(row["DELETEDBY"].ToString() + " is too long for the DELETEDBY Column in the RmInventory Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ///
                ///Check length of each item in RmMaintCode Table
                ///
                try
                {
                    foreach (DataRow row in dsRmMaintCode.Rows)
                    {
                        if (row["MAINTENANCECODE"].ToString().Length > 6)
                        {
                            strDataIssues.Append(row["MAINTENANCECODE"].ToString() + " is too long for the MAINTENANCECODE Column in the RmMaintCode Table.\r\n\r\n");
                        }
                        if (row["ITEM"].ToString().Length > 20)
                        {
                            strDataIssues.Append(row["ITEM"].ToString() + " is too long for the ITEM Column in the RmMaintCode Table.\r\n\r\n");
                        }
                        if (row["STATUS"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["STATUS"].ToString() + " is too long for the STATUS Column in the RmMaintCode Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ///
                ///Check length of each item in MaintRefTo Table
                ///
                try
                {
                    foreach (DataRow row in dsMaintRefTo.Rows)
                    {
                        if (row["REFERRERTOID"].ToString().Length > 6)
                        {
                            strDataIssues.Append(row["REFERRERTOID"].ToString() + " is too long for the REFERRERTOID Column in the MaintRefTo Table.\r\n\r\n");
                        }
                        if (row["REFERREDTONAME"].ToString().Length > 50)
                        {
                            strDataIssues.Append(row["REFERREDTONAME"].ToString() + " is too long for the REFERREDTONAME Column in the MaintRefTo Table.\r\n\r\n");
                        }
                        if (row["STATUS"].ToString().Length > 1)
                        {
                            strDataIssues.Append(row["STATUS"].ToString() + " is too long for the STATUS Column in the MaintRefTo Table.\r\n\r\n");
                        }
                        if (row["FUNCTIONNAME"].ToString().Length > 25)
                        {
                            strDataIssues.Append(row["FUNCTIONNAME"].ToString() + " is too long for the FUNCTIONNAME Column in the MaintRefTo Table.\r\n\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                strDataIssues.Append("There is no RoomsAndBeds.xls at " + txt_WorkbooksLoc.Text + ".");
            }
            if (strDataIssues.ToString() == "")
            {
                txt_DataIssues.Text = "There was no data found to be too long for the column it has been placed in for any of the tables.";
            }
            else
            {
                txt_DataIssues.Text = strDataIssues.ToString();
            }
        }

        public DataTable dsAccounts = new System.Data.DataTable();
        public DataTable dsTaxTXTypes = new System.Data.DataTable();
        public DataTable dsTXTypes = new System.Data.DataTable();
        public DataTable dsTerms = new System.Data.DataTable();
        public DataTable dsRates = new System.Data.DataTable();
        public DataTable dsRateSplits = new System.Data.DataTable();
        public DataTable dsRmTypesRates = new System.Data.DataTable();
        public DataTable dsPlanTypesRates = new System.Data.DataTable();
        public DataTable dsPayCategories = new System.Data.DataTable();
        public DataTable dsCommunity = new System.Data.DataTable();
        public DataTable dsBuildings = new System.Data.DataTable();
        public DataTable dsFloors = new System.Data.DataTable();
        public DataTable dsFloorSections = new System.Data.DataTable();
        public DataTable dsRooms = new System.Data.DataTable();
        public DataTable dsUse1 = new System.Data.DataTable();
        public DataTable dsUse2 = new System.Data.DataTable();
        public DataTable dsRoomConfigs = new System.Data.DataTable();
        public DataTable dsMatchCrit = new System.Data.DataTable();
        public DataTable dsInventory = new System.Data.DataTable();
        public DataTable dsRmInventory = new System.Data.DataTable();
        public DataTable dsRmMaintCode = new System.Data.DataTable();
        public DataTable dsMaintRefTo = new System.Data.DataTable();

        public StringBuilder strAccSQL = new StringBuilder();
        public StringBuilder strtaxTXSQL = new StringBuilder();
        public StringBuilder strTXSQL = new StringBuilder();
        public StringBuilder strTermsSQL = new StringBuilder();
        public StringBuilder strRatesSQL = new StringBuilder();
        public StringBuilder strRateSplitsSQL = new StringBuilder();
        public StringBuilder strRmTypesRatesSQL = new StringBuilder();
        public StringBuilder strPlanTypesRatesSQL = new StringBuilder();
        public StringBuilder strPayCategoriesSQL = new StringBuilder();
        public StringBuilder strCommunitySQL = new StringBuilder();
        public StringBuilder strBuildingsSQL = new StringBuilder();
        public StringBuilder strFloorsSQL = new StringBuilder();
        public StringBuilder strFloorSectionsSQL = new StringBuilder();
        public StringBuilder strRoomsSQL = new StringBuilder();
        public StringBuilder strUse1SQL = new StringBuilder();
        public StringBuilder strUse2SQL = new StringBuilder();
        public StringBuilder strRoomConfigsSQL = new StringBuilder();
        public StringBuilder strMatchCritSQL = new StringBuilder();
        public StringBuilder strInventorySQL = new StringBuilder();
        public StringBuilder strRmInventorySQL = new StringBuilder();
        public StringBuilder strRmMaintCodeSQL = new StringBuilder();
        public StringBuilder strMaintRefToSQL = new StringBuilder();
        
        private void btn_CheckDuplicates_Click(object sender, EventArgs e)
        {
            txt_DataIssues.Visible = true;
            txt_DataIssues.Clear();
            strDataIssues.Clear();
            ///
            ///Check for Duplicates in records
            ///
            var query = from row in dsAccounts.AsEnumerable()
                        group row by row.Field<string>("PK_ACCOUNT_CODE") into AccountDupes
                        orderby AccountDupes.Key
                        select new
                        {
                            Name = AccountDupes.Key,
                            CountOfAccounts = AccountDupes.Count(),
                        };
            foreach (var ACCOUNTS in query)
            {
                if (ACCOUNTS.CountOfAccounts > 1)
                {
                    strDataIssues.Append("There are " + ACCOUNTS.CountOfAccounts.ToString() + " accounts with the name of " + ACCOUNTS.Name.ToString() + "\r\n\r\n");
                }
            }
            var query2 = from row in dsTaxTXTypes.AsEnumerable()
                         group row by row.Field<string>("PK_TAX_TXTYPE") into TaxTXTypesDupes
                         orderby TaxTXTypesDupes.Key
                         select new
                         {
                             Name = TaxTXTypesDupes.Key,
                             CountOfTaxTXTypes = TaxTXTypesDupes.Count(),
                         };
            foreach (var TaxTXTypesDupes in query2)
            {
                if (TaxTXTypesDupes.CountOfTaxTXTypes > 1)
                {
                    strDataIssues.Append("There are " + TaxTXTypesDupes.CountOfTaxTXTypes.ToString() + " Tax Transactions with the name of " + TaxTXTypesDupes.Name.ToString() + "\r\n\r\n");
                    
                }
            }
            var query3 = from row in dsTXTypes.AsEnumerable()
                         group row by row.Field<string>("PK_TXTYPE") into TXTypesDupes
                         orderby TXTypesDupes.Key
                         select new
                         {
                             Name = TXTypesDupes.Key,
                             CountOfTXTypes = TXTypesDupes.Count(),
                         };
            foreach (var TXTypesDupes in query3)
            {
                if (TXTypesDupes.CountOfTXTypes > 1)
                {
                    strDataIssues.Append("There are " + TXTypesDupes.CountOfTXTypes.ToString() + " Transactions with the name of " + TXTypesDupes.Name.ToString() + "\r\n\r\n");
                }
            }
            var query4 = from row in dsTerms.AsEnumerable()
                         group row by row.Field<string>("PK_TERM_ID") into TermsDupes
                         orderby TermsDupes.Key
                         select new
                         {
                             Name = TermsDupes.Key,
                             CountOfTerms = TermsDupes.Count(),
                         };
            foreach (var TermsDupes in query4)
            {
                if (TermsDupes.CountOfTerms > 1)
                {
                    strDataIssues.Append("There are " + TermsDupes.CountOfTerms.ToString() + " Terms with the name of " + TermsDupes.Name.ToString() + "\r\n\r\n");
                }
            }
            DataTable Rates2 = new DataTable();
            Rates2.Columns.Add("RateConfigNoCombo", typeof(string));
            foreach (DataRow row in dsRates.Rows)
            {
                Rates2.Rows.Add(row["CK_RATE_CODE"] + "|" + row["CK_RATE_CONFIG_NO"]);
            }
            var query18 = from row in Rates2.AsEnumerable()
                          group row by row.Field<string>("RateConfigNoCombo") into Rates2Dupes
                          orderby Rates2Dupes.Key
                          select new
                          {
                              Name = Rates2Dupes.Key,
                              CountOfRates2 = Rates2Dupes.Count(),
                          };
            foreach (var Rates2Dupes in query18)
            {
                if (Rates2Dupes.CountOfRates2 > 1)
                {
                    string[] strRates2 = Rates2Dupes.Name.Split('|');
                    strDataIssues.Append("There are " + Rates2Dupes.CountOfRates2.ToString() + " Rates with the Name of " + strRates2[0].ToString() + " and the ConfigNo of " + strRates2[1].ToString() + "\r\n\r\n");
                }
            }
            DataTable RateSplits2 = new DataTable();
            RateSplits2.Columns.Add("RateConfigNoCombo", typeof(string));
            foreach (DataRow row in dsRateSplits.Rows)
            {
                RateSplits2.Rows.Add(row["CK_RATE_CODE"] + "|" + row["CK_RATE_CONFIG_NO"]);
            }
            var query19 = from row in RateSplits2.AsEnumerable()
                          group row by row.Field<string>("RateConfigNoCombo") into RateSplits2Dupes
                          orderby RateSplits2Dupes.Key
                          select new
                          {
                              Name = RateSplits2Dupes.Key,
                              CountOfRateSplits2 = RateSplits2Dupes.Count(),
                          };
            foreach (var RateSplits2Dupes in query19)
            {
                if (RateSplits2Dupes.CountOfRateSplits2 > 1)
                {
                    string[] strRateSplits2 = RateSplits2Dupes.Name.Split('|');
                    strDataIssues.Append("There are " + RateSplits2Dupes.CountOfRateSplits2.ToString() + " Rate Splits with the Name of " + strRateSplits2[0].ToString() + " and the ConfigNo of " + strRateSplits2[1].ToString() + "\r\n\r\n");
                }
            }
            var query5 = from row in dsRmTypesRates.AsEnumerable()
                         group row by row.Field<string>("PK_ROOM_TYPE") into RmTypesRatesDupes
                         orderby RmTypesRatesDupes.Key
                         select new
                         {
                             Name = RmTypesRatesDupes.Key,
                             CountOfRmTypesRates = RmTypesRatesDupes.Count(),
                         };
            foreach (var RmTypesRatesDupes in query5)
            {
                if (RmTypesRatesDupes.CountOfRmTypesRates > 1)
                {
                    strDataIssues.Append("There are " + RmTypesRatesDupes.CountOfRmTypesRates.ToString() + " Room Type Rates with the name of " + RmTypesRatesDupes.Name.ToString() + "\r\n\r\n");
                }
            }
            var query6 = from row in dsPlanTypesRates.AsEnumerable()
                         group row by row.Field<string>("PK_PLAN_TYPE") into PlanTypesRatesDupes
                         orderby PlanTypesRatesDupes.Key
                         select new
                         {
                             Name = PlanTypesRatesDupes.Key,
                             CountOfPlanTypesRates = PlanTypesRatesDupes.Count(),
                         };
            foreach (var PlanTypesRatesDupes in query6)
            {
                if (PlanTypesRatesDupes.CountOfPlanTypesRates > 1)
                {
                    strDataIssues.Append("There are " + PlanTypesRatesDupes.CountOfPlanTypesRates.ToString() + " Plan Type Rates with the name of " + PlanTypesRatesDupes.Name.ToString() + "\r\n\r\n");
                }
            }
            var query7 = from row in dsPayCategories.AsEnumerable()
                         group row by row.Field<string>("PK_METHOD_CODE") into PayCategoriesDupes
                         orderby PayCategoriesDupes.Key
                         select new
                         {
                             Name = PayCategoriesDupes.Key,
                             CountOfPayCategories = PayCategoriesDupes.Count(),
                         };
            foreach (var PayCategoriesDupes in query7)
            {
                if (PayCategoriesDupes.CountOfPayCategories > 1)
                {
                    strDataIssues.Append("There are " + PayCategoriesDupes.CountOfPayCategories.ToString() + " Payment Categories with the name of " + PayCategoriesDupes.Name.ToString() + "\r\n\r\n");
                }
            }
            var query8 = from row in dsCommunity.AsEnumerable()
                         group row by row.Field<string>("COMMUNITY") into CommunityDupes
                         orderby CommunityDupes.Key
                         select new
                         {
                             Name = CommunityDupes.Key,
                             CountOfCommunity = CommunityDupes.Count(),
                         };
            foreach (var CommunityDupes in query8)
            {
                if (CommunityDupes.CountOfCommunity > 1)
                {
                    strDataIssues.Append("There are " + CommunityDupes.CountOfCommunity.ToString() + " Communities with the name of " + CommunityDupes.Name.ToString() + "\r\n\r\n");
                }
            }
            var query9 = from row in dsBuildings.AsEnumerable()
                         group row by row.Field<string>("BUILDINGID") into BuildingsDupes
                         orderby BuildingsDupes.Key
                         select new
                         {
                             Name = BuildingsDupes.Key,
                             CountOfBuildings = BuildingsDupes.Count(),
                         };
            foreach (var BuildingsDupes in query9)
            {
                if (BuildingsDupes.CountOfBuildings > 1)
                {
                    strDataIssues.Append("There are " + BuildingsDupes.CountOfBuildings.ToString() + " Building IDs with the name of " + BuildingsDupes.Name.ToString() + "\r\n\r\n");
                }
            }
            var query10 = from row in dsFloors.AsEnumerable()
                         group row by row.Field<string>("FLOORID") into FloorsDupes
                         orderby FloorsDupes.Key
                         select new
                         {
                             Name = FloorsDupes.Key,
                             CountOfFloors = FloorsDupes.Count(),
                         };
            foreach (var FloorsDupes in query10)
            {
                if (FloorsDupes.CountOfFloors > 1)
                {
                    strDataIssues.Append("There are " + FloorsDupes.CountOfFloors.ToString() + " Floors with the name of " + FloorsDupes.Name.ToString() + "\r\n\r\n");
                }
            }
            var query11 = from row in dsFloorSections.AsEnumerable()
                          group row by row.Field<string>("SECTIONID") into FloorSectionsDupes
                          orderby FloorSectionsDupes.Key
                          select new
                          {
                              Name = FloorSectionsDupes.Key,
                              CountOfFloorSections = FloorSectionsDupes.Count(),
                          };
            foreach (var FloorSectionsDupes in query11)
            {
                if (FloorSectionsDupes.CountOfFloorSections > 1)
                {
                    strDataIssues.Append("There are " + FloorSectionsDupes.CountOfFloorSections.ToString() + " FloorSections with the name of " + FloorSectionsDupes.Name.ToString() + "\r\n\r\n");
                }
            }
            var query12 = from row in dsRooms.AsEnumerable()
                          group row by row.Field<string>("BEDSPACE") into RoomsDupes
                          orderby RoomsDupes.Key
                          select new
                          {
                              Name = RoomsDupes.Key,
                              CountOfRooms = RoomsDupes.Count(),
                          };
            foreach (var RoomsDupes in query12)
            {
                if (RoomsDupes.CountOfRooms > 1)
                {
                    strDataIssues.Append("There are " + RoomsDupes.CountOfRooms.ToString() + " Bedspaces with the name of " + RoomsDupes.Name.ToString() + "\r\n\r\n");
                }
            }
            var query13 = from row in dsUse1.AsEnumerable()
                          group row by row.Field<string>("USE1") into Use1Dupes
                          orderby Use1Dupes.Key
                          select new
                          {
                              Name = Use1Dupes.Key,
                              CountOfUse1 = Use1Dupes.Count(),
                          };
            foreach (var Use1Dupes in query13)
            {
                if (Use1Dupes.CountOfUse1 > 1)
                {
                    strDataIssues.Append("There are " + Use1Dupes.CountOfUse1.ToString() + " Use1 with the name of " + Use1Dupes.Name.ToString() + "\r\n\r\n");
                }
            }
            var query14 = from row in dsUse2.AsEnumerable()
                          group row by row.Field<string>("USE2") into Use2Dupes
                          orderby Use2Dupes.Key
                          select new
                          {
                              Name = Use2Dupes.Key,
                              CountOfUse2 = Use2Dupes.Count(),
                          };
            foreach (var Use2Dupes in query14)
            {
                if (Use2Dupes.CountOfUse2 > 1)
                {
                    strDataIssues.Append("There are " + Use2Dupes.CountOfUse2.ToString() + " Use2 with the name of " + Use2Dupes.Name.ToString() + "\r\n\r\n");
                }
            }
            DataTable RoomConfigs2 = new DataTable();
            RoomConfigs2.Columns.Add("RoomConfigNoCombo", typeof(string));
            foreach (DataRow row in dsRoomConfigs.Rows)
            {
                RoomConfigs2.Rows.Add(row["BEDSPACE"] + "|" + row["CONFIGNO"]);
            }
            var query20 = from row in RoomConfigs2.AsEnumerable()
                          group row by row.Field<string>("RoomConfigNoCombo") into RoomConfigs2Dupes
                          orderby RoomConfigs2Dupes.Key
                          select new
                          {
                              Name = RoomConfigs2Dupes.Key,
                              CountOfRoomConfigs2 = RoomConfigs2Dupes.Count(),
                          };
            foreach (var RoomConfigs2Dupes in query20)
            {
                if (RoomConfigs2Dupes.CountOfRoomConfigs2 > 1)
                {
                    string[] strRoomConfigs2 = RoomConfigs2Dupes.Name.Split('|');
                    strDataIssues.Append("There are " + RoomConfigs2Dupes.CountOfRoomConfigs2.ToString() + " Room Configs with the Name of " + strRoomConfigs2[0].ToString() + " and the ConfigNo of " + strRoomConfigs2[1].ToString() + "\r\n\r\n");
                }
            }
            var query15 = from row in dsMatchCrit.AsEnumerable()
                          group row by row.Field<string>("MATCHINGCRITERIADESCRIPTION") into MatchCritDupes
                          orderby MatchCritDupes.Key
                          select new
                          {
                              Name = MatchCritDupes.Key,
                              CountOfMatchCrit = MatchCritDupes.Count(),
                          };
            foreach (var MatchCritDupes in query15)
            {
                if (MatchCritDupes.CountOfMatchCrit > 1)
                {
                    strDataIssues.Append("There are " + MatchCritDupes.CountOfMatchCrit.ToString() + " MATCHING CRITERIA DESCRIPTION with the name of " + MatchCritDupes.Name.ToString() + "\r\n\r\n");
                }
            }
            var query16 = from row in dsInventory.AsEnumerable()
                          group row by row.Field<string>("INVENTORYCODE") into InventoryDupes
                         orderby InventoryDupes.Key
                          select new
                          {
                              Name = InventoryDupes.Key,
                              CountOfInventory = InventoryDupes.Count(),
                          };
            foreach (var InventoryDupes in query16)
            {
                if (InventoryDupes.CountOfInventory > 1)
                {
                    strDataIssues.Append("There are " + InventoryDupes.CountOfInventory.ToString() + " Inventory Code with the name of " + InventoryDupes.Name.ToString() + "\r\n\r\n");
                }
            }
            var query17 = from row in dsRmMaintCode.AsEnumerable()
                          group row by row.Field<string>("MAINTENANCECODE") into RmMaintCodeDupes
                          orderby RmMaintCodeDupes.Key
                          select new
                          {
                              Name = RmMaintCodeDupes.Key,
                              CountOfRmMaintCode = RmMaintCodeDupes.Count(),
                          };
            foreach (var RmMaintCodeDupes in query17)
            {
                if (RmMaintCodeDupes.CountOfRmMaintCode > 1)
                {
                    strDataIssues.Append("There are " + RmMaintCodeDupes.CountOfRmMaintCode.ToString() + " Maintenance Code Code with the name of " + RmMaintCodeDupes.Name.ToString() + "\r\n\r\n");
                }
            }
            if (strDataIssues.ToString() == "")
            {
                txt_DataIssues.Text = "There were no duplicates found in any of the tables.";
            }
            else
            {
                txt_DataIssues.Text = strDataIssues.ToString();
            }
        }
        ///
        ///AccountsList
        ///
        public List<string> listAccountNames = new List<string>();
        public List<string> listTaxTXTypes = new List<string>();
        public List<string> listTaxTXTypesDebitAccount = new List<string>();
        public List<string> listTaxTXTypesCreditAccount = new List<string>();
        public List<string> listTXTypes = new List<string>();
        public List<string> listTXTypesDebitAccount = new List<string>();
        public List<string> listTXTypesCreditAccount = new List<string>();
        public List<string> listTXTypesTaxTypes1 = new List<string>();
        public List<string> listTXTypesTaxTypes2 = new List<string>();
        public List<string> listTXTypesTaxTypes3 = new List<string>();
        public List<string> listTXTypesTaxTypes4 = new List<string>();
        public List<string> listTermIDs = new List<string>();
        public List<string> listRatesCode = new List<string>();
        public List<string> listRatesCodeConfigCombo = new List<string>();
        public List<string> listRatesBillingType = new List<string>();
        public List<string> listRatesType = new List<string>();
        public List<string> listRateSplitsCode = new List<string>();
        public List<string> listRateSplitsCodeConfigCombo = new List<string>();
        public List<string> listRateSplitsTXType = new List<string>();
        public List<string> listRmTypesRatesRMType = new List<string>();
        public List<string> listRmTypesRatesRateCode = new List<string>();
        public List<string> listPlanTypesRatesPlanType = new List<string>();
        public List<string> listPlanTypesRatesRateCode = new List<string>();
        public List<string> listPlanTypesRatesTypeType = new List<string>();
        public List<string> listPayCategoriesMethodCode = new List<string>();
        ///
        ///RoomsAndBeds
        ///
        public List<string> listCommunity = new List<string>();
        public List<string> listBuildingID = new List<string>();
        public List<string> listBuildingCommunity = new List<string>();
        public List<string> listFloorID = new List<string>();
        public List<string> listFloorBuildingID = new List<string>();
        public List<string> listSectionID = new List<string>();
        public List<string> listSectionsFloorID = new List<string>();
        public List<string> listRoomsBedSpace = new List<string>();
        public List<string> listRoomsRoomNo = new List<string>();
        public List<string> listRoomsSecondarySpace = new List<string>();
        public List<string> listUse1 = new List<string>();
        public List<string> listUse2 = new List<string>();
        public List<string> listRmConfigsBedSpaces = new List<string>();
        public List<string> listRmConfigsBedSpacesonfigCombo = new List<string>();
        public List<string> listRmConfigsRoomsType = new List<string>();
        public List<string> listRmConfigsSectionID = new List<string>();
        public List<string> listRmConfigsUse1 = new List<string>();
        public List<string> listRmConfigsUse2 = new List<string>();
        public List<string> listInventoryCode = new List<string>();
        public List<string> listRmInventoryBedSpace = new List<string>();
        public List<string> listRmInventoryCode = new List<string>();
        public List<string> listMaintenanceCode = new List<string>();
        
        public void btn_CheckDependents_Click(object sender, EventArgs e)
        {
            txt_DataIssues.Visible = true;
            txt_DataIssues.Clear();
            strDataIssues.Clear();
            ///
            ///Accounts Lists
            ///
            listAccountNames.Clear();
            listTaxTXTypes.Clear();
            listTaxTXTypesDebitAccount.Clear();
            listTaxTXTypesCreditAccount.Clear();
            listTXTypes.Clear();
            listTXTypesDebitAccount.Clear();
            listTXTypesCreditAccount.Clear();
            listTXTypesTaxTypes1.Clear();
            listTXTypesTaxTypes2.Clear();
            listTXTypesTaxTypes3.Clear();
            listTXTypesTaxTypes4.Clear();
            listTermIDs.Clear();
            listRatesCode.Clear();
            listRatesCodeConfigCombo.Clear();
            listRatesBillingType.Clear();
            listRatesType.Clear();
            listRateSplitsCode.Clear();
            listRateSplitsCodeConfigCombo.Clear();
            listRateSplitsTXType.Clear();
            listRmTypesRatesRMType.Clear();
            listRmTypesRatesRateCode.Clear();
            listPlanTypesRatesPlanType.Clear();
            listPlanTypesRatesRateCode.Clear();
            listPlanTypesRatesTypeType.Clear();
            listPayCategoriesMethodCode.Clear();
            ///
            ///RoomsAndBeds Lists
            ///
            listCommunity.Clear();
            listBuildingID.Clear();
            listBuildingCommunity.Clear();
            listFloorID.Clear();
            listFloorBuildingID.Clear();
            listSectionID.Clear();
            listSectionsFloorID.Clear();
            listRoomsBedSpace.Clear();
            listRoomsRoomNo.Clear();
            listRoomsSecondarySpace.Clear();
            listUse1.Clear();
            listUse2.Clear();
            listRmConfigsBedSpaces.Clear();
            listRmConfigsBedSpacesonfigCombo.Clear();
            listRmConfigsRoomsType.Clear();
            listRmConfigsSectionID.Clear();
            listRmConfigsUse1.Clear();
            listRmConfigsUse2.Clear();
            listInventoryCode.Clear();
            listRmInventoryBedSpace.Clear();
            listRmInventoryCode.Clear();
            listMaintenanceCode.Clear();
            ///
            ///Accounting Table Lists
            /// 
            foreach (DataRow row in dsAccounts.Rows)
            {
                    listAccountNames.Add(row["PK_ACCOUNT_CODE"].ToString());
            }
            foreach (DataRow row in dsTaxTXTypes.Rows)
            {
                listTaxTXTypes.Add(row["PK_TAX_TXTYPE"].ToString());
                if ((row["FK_DEBIT_ACCOUNT"].ToString() != "0ACCREC") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0ACCREC-BOND") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0ADMIN-INT") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0APPFEE") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0APPFEE-RE") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0BANK") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0BOND") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0BOND-CON-D") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0BOND-CON-P") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0BOND-HOUS") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0BOND-KEY") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0BOND-MAINT") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0BOND-NETWRK") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0BOND-PREPAY") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0BOND-UTIL") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0CASHPAY") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0CATERING") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0CCARD") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0CHQIN") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0CLRBAL-AR") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0CLRBALBOND") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0CREDIT") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0EQUIPMENT") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0FACILITIES") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0GENEXP") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0GST") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0GST-OTHER") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0LLPAY") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0LOST-KEY") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0OBALC") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0OPENBAL") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0OPENBAL BND") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0OPENBAL-AR") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0OPENBALBOND") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0PHONE") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0PHONECALLS") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0REFUND") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0RMSDEMO") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0UNALLOC") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0UNALLOCREC"))
                {
                    listTaxTXTypesDebitAccount.Add(row["FK_DEBIT_ACCOUNT"].ToString());
                }
                if ((row["FK_CREDIT_ACCOUNT"].ToString() != "0ACCREC") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0ACCREC-BOND") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0ADMIN-INT") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0APPFEE") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0APPFEE-RE") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0BANK") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0BOND") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0BOND-CON-D") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0BOND-CON-P") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0BOND-HOUS") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0BOND-KEY") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0BOND-MAINT") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0BOND-NETWRK") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0BOND-PREPAY") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0BOND-UTIL") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0CASHPAY") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0CATERING") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0CCARD") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0CHQIN") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0CLRBAL-AR") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0CLRBALBOND") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0CREDIT") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0EQUIPMENT") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0FACILITIES") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0GENEXP") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0GST") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0GST-OTHER") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0LLPAY") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0LOST-KEY") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0OBALC") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0OPENBAL") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0OPENBAL BND") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0OPENBAL-AR") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0OPENBALBOND") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0PHONE") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0PHONECALLS") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0REFUND") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0RMSDEMO") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0UNALLOC") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0UNALLOCREC"))
                {
                    listTaxTXTypesCreditAccount.Add(row["FK_CREDIT_ACCOUNT"].ToString());
                }
            }
            foreach (DataRow row in dsTXTypes.Rows)
            {
                listTXTypes.Add(row["PK_TXTYPE"].ToString());
                if ((row["FK_DEBIT_ACCOUNT"].ToString() != "0ACCREC") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0ACCREC-BOND") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0ADMIN-INT") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0APPFEE") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0APPFEE-RE") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0BANK") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0BOND") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0BOND-CON-D") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0BOND-CON-P") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0BOND-HOUS") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0BOND-KEY") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0BOND-MAINT") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0BOND-NETWRK") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0BOND-PREPAY") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0BOND-UTIL") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0CASHPAY") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0CATERING") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0CCARD") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0CHQIN") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0CLRBAL-AR") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0CLRBALBOND") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0CREDIT") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0EQUIPMENT") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0FACILITIES") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0GENEXP") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0GST") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0GST-OTHER") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0LLPAY") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0LOST-KEY") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0OBALC") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0OPENBAL") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0OPENBAL BND") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0OPENBAL-AR") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0OPENBALBOND") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0PHONE") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0PHONECALLS") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0REFUND") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0RMSDEMO") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0UNALLOC") && (row["FK_DEBIT_ACCOUNT"].ToString() != "0UNALLOCREC"))
                {
                    listTXTypesDebitAccount.Add(row["FK_DEBIT_ACCOUNT"].ToString());
                }
                if ((row["FK_CREDIT_ACCOUNT"].ToString() != "0ACCREC") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0ACCREC-BOND") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0ADMIN-INT") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0APPFEE") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0APPFEE-RE") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0BANK") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0BOND") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0BOND-CON-D") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0BOND-CON-P") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0BOND-HOUS") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0BOND-KEY") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0BOND-MAINT") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0BOND-NETWRK") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0BOND-PREPAY") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0BOND-UTIL") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0CASHPAY") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0CATERING") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0CCARD") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0CHQIN") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0CLRBAL-AR") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0CLRBALBOND") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0CREDIT") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0EQUIPMENT") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0FACILITIES") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0GENEXP") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0GST") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0GST-OTHER") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0LLPAY") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0LOST-KEY") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0OBALC") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0OPENBAL") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0OPENBAL BND") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0OPENBAL-AR") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0OPENBALBOND") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0PHONE") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0PHONECALLS") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0REFUND") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0RMSDEMO") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0UNALLOC") && (row["FK_CREDIT_ACCOUNT"].ToString() != "0UNALLOCREC"))
                {
                    listTXTypesCreditAccount.Add(row["FK_CREDIT_ACCOUNT"].ToString());
                }
                listTXTypesTaxTypes1.Add(row["FK_TAX_TXTYPE1"].ToString());
                listTXTypesTaxTypes2.Add(row["FK_TAX_TXTYPE2"].ToString());
                listTXTypesTaxTypes3.Add(row["FK_TAX_TXTYPE3"].ToString());
                listTXTypesTaxTypes4.Add(row["FK_TAX_TXTYPE4"].ToString());
            }
            foreach (DataRow row in dsTerms.Rows)
            {
                listTermIDs.Add(row["PK_TERM_ID"].ToString());
            }
            foreach (DataRow row in dsRates.Rows)
            {
                listRatesCode.Add(row["CK_RATE_CODE"].ToString());
                listRatesCodeConfigCombo.Add(row["CK_RATE_CODE"].ToString() + "|" + row["CK_RATE_CONFIG_NO"].ToString());
                listRatesBillingType.Add(row["FK_BILLING_TYPE"].ToString());
                listRatesType.Add(row["RATES_TYPE"].ToString());
            }
            foreach (DataRow row in dsRateSplits.Rows)
            {
                listRateSplitsCode.Add(row["CK_RATE_CODE"].ToString());
                listRateSplitsCodeConfigCombo.Add(row["CK_RATE_CODE"].ToString() + "|" + row["CK_RATE_CONFIG_NO"].ToString());
                listRateSplitsTXType.Add(row["CK_TXTYPE"].ToString());
            }
            foreach (DataRow row in dsRmTypesRates.Rows)
            {
                listRmTypesRatesRMType.Add(row["PK_ROOM_TYPE"].ToString());
                listRmTypesRatesRateCode.Add(row["FK_RATE_CODE"].ToString());
            }
            foreach (DataRow row in dsPlanTypesRates.Rows)
            {
                listPlanTypesRatesPlanType.Add(row["PK_PLAN_TYPE"].ToString());
                listPlanTypesRatesRateCode.Add(row["FK_RATE_CODE"].ToString());
                listPlanTypesRatesTypeType.Add(row["PLAN_TYPE_TYPE"].ToString());
            }
            foreach (DataRow row in dsPayCategories.Rows)
            {
                listPayCategoriesMethodCode.Add(row["PK_METHOD_CODE"].ToString());
            }
            ///
            ///Rooms Table Lists
            ///
            foreach (DataRow row in dsCommunity.Rows)
            {
                listCommunity.Add(row["COMMUNITY"].ToString());
            }
            foreach (DataRow row in dsBuildings.Rows)
            {
                listBuildingID.Add(row["BUILDINGID"].ToString());
                listBuildingCommunity.Add(row["COMMUNITY"].ToString());
            }
            foreach (DataRow row in dsFloors.Rows)
            {
                listFloorID.Add(row["FLOORID"].ToString());
                listFloorBuildingID.Add(row["BUILDINGID"].ToString());
            }
            foreach (DataRow row in dsFloorSections.Rows)
            {
                listSectionID.Add(row["SECTIONID"].ToString());
                listSectionsFloorID.Add(row["FLOORID"].ToString());
            }
            foreach (DataRow row in dsRooms.Rows)
            {
                listRoomsBedSpace.Add(row["BEDSPACE"].ToString());
                listRoomsRoomNo.Add(row["ROOMNO"].ToString());
                listRoomsSecondarySpace.Add(row["SECONDARYBEDSPACE"].ToString());
            }
            foreach (DataRow row in dsUse1.Rows)
            {
                    listUse1.Add(row["USE1"].ToString());
            }
            foreach (DataRow row in dsUse2.Rows)
            {
                    listUse2.Add(row["USE2"].ToString());
            }
            foreach (DataRow row in dsRoomConfigs.Rows)
            {
                listRmConfigsBedSpaces.Add(row["BEDSPACE"].ToString());
                listRmConfigsBedSpacesonfigCombo.Add(row["CONFIGNO"].ToString());
                listRmConfigsRoomsType.Add(row["ROOMSTYPE"].ToString());
                listRmConfigsSectionID.Add(row["SECTIONID"].ToString());
                if (row["USE1"].ToString() != "NA")
                {
                    listRmConfigsUse1.Add(row["USE1"].ToString());
                }
                if (row["USE2"].ToString() != "NA")
                {
                    listRmConfigsUse2.Add(row["USE2"].ToString());
                }
            }
            foreach (DataRow row in dsInventory.Rows)
            {
                listInventoryCode.Add(row["INVENTORYCODE"].ToString());
            }
            foreach (DataRow row in dsRmInventory.Rows)
            {
                listRmInventoryBedSpace.Add(row["BEDSPACE"].ToString());
                listRmInventoryCode.Add(row["INVENTORYCODE"].ToString());
            }
            foreach (DataRow row in dsRmMaintCode.Rows)
            {
                listMaintenanceCode.Add(row["MAINTENANCECODE"].ToString());
            }
            ///
            /// Find dependent fields that are blank.
            ///
            foreach (string TaxTXTypesDebitAccount in listTaxTXTypesDebitAccount)
            {
                if (TaxTXTypesDebitAccount == "")
                {
                    strDataIssues.Append("There is a Debit Account name in the Tax transaction Types table that is blank.\r\n\r\n");
                }
            }
            foreach (string TaxTXTypesCreditAccount in listTaxTXTypesCreditAccount)
            {
                if (TaxTXTypesCreditAccount == "")
                {
                    strDataIssues.Append("There is a Credit Account name in the Tax transaction Types table that is blank.\r\n\r\n");
                }
            }
            foreach (string TXTypesDebitAccount in listTXTypesDebitAccount)
            {
                if (TXTypesDebitAccount == "")
                {
                    strDataIssues.Append("There is a Debit Account name in the Transaction Types table that is blank.\r\n\r\n");
                }
            }
            foreach (string TXTypesCreditAccount in listTXTypesCreditAccount)
            {
                if (TXTypesCreditAccount == "")
                {
                    strDataIssues.Append("There is a Credit Account name in the Transaction Types table that is blank.\r\n\r\n");
                }
            }

            foreach (string BillingType in listRatesBillingType)
            {
                if (BillingType == "")
                {
                    strDataIssues.Append("There is a Billing Type in the Rates Table that is blank.\r\n\r\n");
                }
            }

            foreach (string TXType in listRateSplitsTXType)
            {
                if (TXType == "")
                {
                    strDataIssues.Append("There is a Transaction Type in the Rate Splits Table that is blank.\r\n\r\n");
                }
            }
            foreach (string RateSplitsCodeConfigCombo in listRateSplitsCodeConfigCombo)
            {
                if (RateSplitsCodeConfigCombo == "")
                {
                    strDataIssues.Append("There is a Split Config Combo in the Rate Splits Table that is blank.\r\n\r\n");
                }
            }
            foreach (string RateCode in listRmTypesRatesRateCode)
            {
                if (RateCode == "")
                {
                    strDataIssues.Append("There is a Rate Code in the Room Types Rates Table that is blank.\r\n\r\n");
                }
            }
            foreach (string RateCode in listPlanTypesRatesRateCode)
            {
                if (RateCode == "")
                {
                    strDataIssues.Append("There is a Rate Code in the Plan Types Rates Table that is blank.\r\n\r\n");
                }
            }
            foreach (string Community in listBuildingCommunity)
            {
                if (Community == "")
                {
                    strDataIssues.Append("There is a Community in the Buildings Table that is blank.\r\n\r\n");
                }
            }
            foreach (string Building in listFloorBuildingID)
            {
                if (Building == "")
                {
                    strDataIssues.Append("There is a Building in the Floors Table that is blank.\r\n\r\n");
                }
            }
            foreach (string Floor in listSectionsFloorID)
            {
                if (Floor == "")
                {
                    strDataIssues.Append("There is a Floor in the Floor Sections Table that is blank.\r\n\r\n");
                }
            }
            foreach (string RmType in listRmConfigsRoomsType)
            {
                if (RmType == "")
                {
                    strDataIssues.Append("There is a Room Type in the Room Configs that is blank.\r\n\r\n");
                }
            }
            foreach (string SectionID in listRmConfigsSectionID)
            {
                if (SectionID == "")
                {
                    strDataIssues.Append("There is a SectionID in the Room Configs that is blank.\r\n\r\n");
                }
            }
            foreach (string Use1 in listRmConfigsUse1)
            {
                if (Use1 == "")
                {
                    strDataIssues.Append("There is a Use1 in the Room Configs that is blank.\r\n\r\n");
                }
            }
            foreach (string Use2 in listRmConfigsUse2)
            {
                if (Use2 == "")
                {
                    strDataIssues.Append("There is a Use2 in the Room Configs that is blank.\r\n\r\n");
                }
            }
            foreach (string BedSpace in listRmInventoryBedSpace)
            {
                if (BedSpace == "")
                {
                    strDataIssues.Append("There is a Bedspace in the Room Inventory Table that is blank.\r\n\r\n");
                }
            }
            foreach (string InventoryCode in listRmInventoryCode)
            {
                if (InventoryCode == "")
                {
                    strDataIssues.Append("There is an Inventory Code in the Room Inventory Table that is blank.\r\n\r\n");
                }
            }
            foreach (string InventoryCode in listMaintenanceCode)
            {
                if (InventoryCode == "")
                {
                    strDataIssues.Append("There is an Inventory Code in the Maintenace Table that is blank.\r\n\r\n");
                }
            }
            ///
            ///Find the Dependency issues.
            ///
            IEnumerable<string> differenceQuery1 =
            listTaxTXTypesDebitAccount.Except(listAccountNames);
            foreach (string s in differenceQuery1)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the Tax Transaction Debit Account but does not appear in the Accounts table.\r\n\r\n");
                }
            }
            IEnumerable<string> differenceQuery2 =
            listTaxTXTypesCreditAccount.Except(listAccountNames);
            foreach (string s in differenceQuery2)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the Tax Transaction Credit Account but does not appear in the Accounts table.\r\n\r\n");
                }
            }
            IEnumerable<string> differenceQuery3 =
            listTXTypesDebitAccount.Except(listAccountNames);
            foreach (string s in differenceQuery3)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the Transaction Debit Account but does not appear in the Accounts table.\r\n\r\n");
                }
            }

            IEnumerable<string> differenceQuery4 =
            listTXTypesCreditAccount.Except(listAccountNames);
            foreach (string s in differenceQuery4)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the Transaction Credit Account but does not appear in the Accounts table.\r\n\r\n");
                }
            }

            IEnumerable<string> differenceQuery5 =
            listTXTypesTaxTypes1.Except(listTaxTXTypes);
            foreach (string s in differenceQuery5)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the Transaction TAX_TXTXTYPE1 but does not appear in the Tax Transactions table.\r\n\r\n");
                }
            }

            IEnumerable<string> differenceQuery6 =
            listTXTypesTaxTypes2.Except(listTaxTXTypes);
            foreach (string s in differenceQuery6)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the Transaction TAX_TXTXTYPE2 but does not appear in the Tax Transactions table.\r\n\r\n");
                }
            }

            IEnumerable<string> differenceQuery7 =
            listTXTypesTaxTypes3.Except(listTaxTXTypes);
            foreach (string s in differenceQuery7)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the Transaction TAX_TXTXTYPE3 but does not appear in the Tax Transactions table.\r\n\r\n");
                }
            }

            IEnumerable<string> differenceQuery8 =
            listTXTypesTaxTypes4.Except(listTaxTXTypes);
            foreach (string s in differenceQuery8)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the Transaction TAX_TXTXTYPE4 but does not appear in the Tax Transactions table.\r\n\r\n");
                }
            }
            IEnumerable<string> differenceQuery9 =
            listRatesBillingType.Except(listTermIDs);
            foreach (string s in differenceQuery9)
            {
                if ((s != "") && (s.ToUpper() != "S") && (s.ToUpper() != "N") && (s.ToUpper() != "W") && (s.ToUpper() != "B") && (s.ToUpper() != "M") && (s.ToUpper() != "Y") && (s.ToUpper() != "FR") && (s.ToUpper() != "HD") && (s.ToUpper() != "FD") && (s.ToUpper() != "D") && (s.ToUpper() != "U"))
                {
                    strDataIssues.Append(s + " is in the Rates Billing Type but does not appear in the Terms table.\r\n\r\n");
                }
            }
            foreach (DataRow row in dsRates.Rows)
            {
                if ((row["FK_BILLING_TYPE"].ToString() == "FD") && (row["RATES_TYPE"].ToString() != "E") && (row["RATES_TYPE"].ToString() != "F"))
                {
                    strDataIssues.Append("For Rate Code - " + row["CK_RATE_CODE"].ToString() + " the FK_BILLING_TYPE - " + row["FK_BILLING_TYPE"].ToString() + " must have a RATES_TYPE of E or F in the Rates Worksheet. Currently the RATES_TYPE is " + row["RATES_TYPE"].ToString() + "\r\n\r\n");
                }
                if ((row["FK_BILLING_TYPE"].ToString() == "H") && (row["RATES_TYPE"].ToString() != "E") && (row["RATES_TYPE"].ToString() != "F"))
                {
                    strDataIssues.Append("For Rate Code - " + row["CK_RATE_CODE"].ToString() + " the FK_BILLING_TYPE - " + row["FK_BILLING_TYPE"].ToString() + " must have a RATES_TYPE of E or F in the Rates Worksheet. Currently the RATES_TYPE is " + row["RATES_TYPE"].ToString() + "\r\n\r\n");
                }
                if ((row["FK_BILLING_TYPE"].ToString() == "HD") && (row["RATES_TYPE"].ToString() != "E") && (row["RATES_TYPE"].ToString() != "F"))
                {
                    strDataIssues.Append("For Rate Code - " + row["CK_RATE_CODE"].ToString() + " the FK_BILLING_TYPE - " + row["FK_BILLING_TYPE"].ToString() + " must have a RATES_TYPE of E or F in the Rates Worksheet. Currently the RATES_TYPE is " + row["RATES_TYPE"].ToString() + "\r\n\r\n");
                }
                if ((row["FK_BILLING_TYPE"].ToString() == "S") && (row["RATES_TYPE"].ToString() != "B") && (row["RATES_TYPE"].ToString() != "M"))
                {
                    strDataIssues.Append("For Rate Code - " + row["CK_RATE_CODE"].ToString() + " the FK_BILLING_TYPE - " + row["FK_BILLING_TYPE"].ToString() + " must have a RATES_TYPE of B or M in the Rates Worksheet. Currently the RATES_TYPE is " + row["RATES_TYPE"].ToString() + "\r\n\r\n");
                }
                if ((row["FK_BILLING_TYPE"].ToString() == "U") && (row["RATES_TYPE"].ToString() != "X"))
                {
                    strDataIssues.Append("For Rate Code - " + row["CK_RATE_CODE"].ToString() + " the FK_BILLING_TYPE - " + row["FK_BILLING_TYPE"].ToString() + " must have a RATES_TYPE of X in the Rates Worksheet. Currently the RATES_TYPE is " + row["RATES_TYPE"].ToString() + "\r\n\r\n");
                }
                if ((row["FK_BILLING_TYPE"].ToString() == "M") && (row["RATES_TYPE"].ToString() != "A") && (row["RATES_TYPE"].ToString() != "P"))
                {
                    strDataIssues.Append("For Rate Code - " + row["CK_RATE_CODE"].ToString() + " the FK_BILLING_TYPE - " + row["FK_BILLING_TYPE"].ToString() + " must have a RATES_TYPE of A or P in the Rates Worksheet. Currently the RATES_TYPE is " + row["RATES_TYPE"].ToString() + "\r\n\r\n");
                }
                if ((row["FK_BILLING_TYPE"].ToString() == "B") && (row["RATES_TYPE"].ToString() != "A") && (row["RATES_TYPE"].ToString() != "P"))
                {
                    strDataIssues.Append("For Rate Code - " + row["CK_RATE_CODE"].ToString() + " the FK_BILLING_TYPE - " + row["FK_BILLING_TYPE"].ToString() + " must have a RATES_TYPE of A or P in the Rates Worksheet. Currently the RATES_TYPE is " + row["RATES_TYPE"].ToString() + "\r\n\r\n");
                }
                if ((row["FK_BILLING_TYPE"].ToString() == "D") && (row["RATES_TYPE"].ToString() != "A") && (row["RATES_TYPE"].ToString() != "P"))
                {
                    strDataIssues.Append("For Rate Code - " + row["CK_RATE_CODE"].ToString() + " the FK_BILLING_TYPE - " + row["FK_BILLING_TYPE"].ToString() + " must have a RATES_TYPE of A or P in the Rates Worksheet. Currently the RATES_TYPE is " + row["RATES_TYPE"].ToString() + "\r\n\r\n");
                }
                if ((row["FK_BILLING_TYPE"].ToString() == "N") && (row["RATES_TYPE"].ToString() != "A") && (row["RATES_TYPE"].ToString() != "P"))
                {
                    strDataIssues.Append("For Rate Code - " + row["CK_RATE_CODE"].ToString() + " the FK_BILLING_TYPE - " + row["FK_BILLING_TYPE"].ToString() + " must have a RATES_TYPE of A or P in the Rates Worksheet. Currently the RATES_TYPE is " + row["RATES_TYPE"].ToString() + "\r\n\r\n");
                }
                if ((row["FK_BILLING_TYPE"].ToString() == "W") && (row["RATES_TYPE"].ToString() != "A") && (row["RATES_TYPE"].ToString() != "P"))
                {
                    strDataIssues.Append("For Rate Code - " + row["CK_RATE_CODE"].ToString() + " the FK_BILLING_TYPE - " + row["FK_BILLING_TYPE"].ToString() + " must have a RATES_TYPE of A or P in the Rates Worksheet. Currently the RATES_TYPE is " + row["RATES_TYPE"].ToString() + "\r\n\r\n");
                }
                if ((row["FK_BILLING_TYPE"].ToString() == "Y") && (row["RATES_TYPE"].ToString() != "A") && (row["RATES_TYPE"].ToString() != "P"))
                {
                    strDataIssues.Append("For Rate Code - " + row["CK_RATE_CODE"].ToString() + " the FK_BILLING_TYPE - " + row["FK_BILLING_TYPE"].ToString() + " must have a RATES_TYPE of A or P in the Rates Worksheet. Currently the RATES_TYPE is " + row["RATES_TYPE"].ToString() + "\r\n\r\n");
                }
                if ((row["FK_BILLING_TYPE"].ToString() == "FR") && (row["RATES_TYPE"].ToString() != "B") && (row["RATES_TYPE"].ToString() != "E") && (row["RATES_TYPE"].ToString() != "F") && (row["RATES_TYPE"].ToString() != "M") && (row["RATES_TYPE"].ToString() != "X"))
                {
                    strDataIssues.Append("For Rate Code - " + row["CK_RATE_CODE"].ToString() + " the FK_BILLING_TYPE - " + row["FK_BILLING_TYPE"].ToString() + " must have a RATES_TYPE of B, E, F, M or X in the Rates Worksheet. Currently the RATES_TYPE is " + row["RATES_TYPE"].ToString() + "\r\n\r\n");
                }
                if ((row["FK_BILLING_TYPE"].ToString() != "FR") && (row["FK_BILLING_TYPE"].ToString() != "U") && (row["FK_BILLING_TYPE"].ToString() != "Y") && (row["FK_BILLING_TYPE"].ToString() != "W") && (row["FK_BILLING_TYPE"].ToString() != "N") && (row["FK_BILLING_TYPE"].ToString() != "D") && (row["FK_BILLING_TYPE"].ToString() != "B") && (row["FK_BILLING_TYPE"].ToString() != "M") && (row["FK_BILLING_TYPE"].ToString() != "X") && (row["FK_BILLING_TYPE"].ToString() != "S") && (row["FK_BILLING_TYPE"].ToString() != "HD") && (row["FK_BILLING_TYPE"].ToString() != "H") && (row["FK_BILLING_TYPE"].ToString() != "FD") && (row["RATES_TYPE"].ToString() != "A") && (row["RATES_TYPE"].ToString() != "P"))
                {
                    strDataIssues.Append("For Rate Code - " + row["CK_RATE_CODE"].ToString() + " the FK_BILLING_TYPE - " + row["FK_BILLING_TYPE"].ToString() + " must have a RATES_TYPE of A or P in the Rates Worksheet. Currently the RATES_TYPE is " + row["RATES_TYPE"].ToString() + "\r\n\r\n");
                }
            }
            IEnumerable<string> differenceQuery10 =
            listRateSplitsTXType.Except(listTXTypes);
            foreach (string s in differenceQuery10)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the Transaction Types of the Rate Split Table but does not appear in the Transaction Types Table.\r\n\r\n");
                }
            }
            IEnumerable<string> differenceQuery11 =
            listRateSplitsCodeConfigCombo.Except(listRatesCodeConfigCombo);
            foreach (string s in differenceQuery11)
            {
                if (s != "")
                {
                    string[] strS = s.Split('|');
                    strDataIssues.Append("Rate " + strS[0] + " with Config Code #" + strS[1] + " is in the Rate Splits but does not appear in the Rates table.\r\n\r\n");
                }
            }
            IEnumerable<string> differenceQuery12 =
            listRmTypesRatesRateCode.Except(listRatesCode);
            foreach (string s in differenceQuery12)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the Rate Code in Room Types Rate Table but does not appear in the Rates Table.\r\n\r\n");
                }
            }
            IEnumerable<string> differenceQuery13 =
            listPlanTypesRatesRateCode.Except(listRatesCode);
            foreach (string s in differenceQuery13)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the Rate Code in Plan Types Rate Table but does not appear in the Rates Table.\r\n\r\n");
                }
            }
            IEnumerable<string> differenceQuery14 =
            listBuildingCommunity.Except(listCommunity);
            foreach (string s in differenceQuery14)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the Community of the Buildings Table but does not appear in the Community Table.\r\n\r\n");
                }
            }
            IEnumerable<string> differenceQuery15 =
            listFloorBuildingID.Except(listBuildingID);
            foreach (string s in differenceQuery15)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the Building of the Floors Table but does not appear in the Building Table.\r\n\r\n");
                }
            }
            IEnumerable<string> differenceQuery16 =
            listSectionsFloorID.Except(listFloorID);
            foreach (string s in differenceQuery16)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the FloorID of the FloorSections Table but does not appear in the Floor Table.\r\n\r\n");
                }
            }
            IEnumerable<string> differenceQuery17 =
            listRmConfigsBedSpaces.Except(listRoomsBedSpace);
            foreach (string s in differenceQuery17)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the Bedspace of the Room Configs Table but does not appear in the Rooms Table.\r\n\r\n");
                }
            }
            IEnumerable<string> differenceQuery18 =
            listRmConfigsRoomsType.Except(listRmTypesRatesRMType);
            foreach (string s in differenceQuery18)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the Room Types of the Room Configs Table but does not appear in the Rooms Types Rates Table.\r\n\r\n");
                }
            }
            IEnumerable<string> differenceQuery19 =
            listRmConfigsSectionID.Except(listSectionID);
            foreach (string s in differenceQuery19)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the Section ID of the Room Configs Table but does not appear in the Floor Sections Table.\r\n\r\n");
                }
            }
            IEnumerable<string> differenceQuery20 =
            listRmConfigsUse1.Except(listUse1);
            foreach (string s in differenceQuery20)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the Use 1 of the Room Configs Table but does not appear in the Use 1 Table.\r\n\r\n");
                }
            }
            IEnumerable<string> differenceQuery21 =
            listRmConfigsUse2.Except(listUse2);
            foreach (string s in differenceQuery21)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the Use 2 of the Room Configs Table but does not appear in the Use 2 Table.\r\n\r\n");
                }
            }
            IEnumerable<string> differenceQuery22 =
            listRmInventoryBedSpace.Except(listRoomsBedSpace);
            foreach (string s in differenceQuery22)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the Bedspace of the Room Inventory Table but does not appear in the Rooms Table.\r\n\r\n");
                }
            }
            IEnumerable<string> differenceQuery23 =
            listRmInventoryCode.Except(listInventoryCode);
            foreach (string s in differenceQuery23)
            {
                if (s != "")
                {
                    strDataIssues.Append(s + " is in the Inventory Code of the Room Inventory Table but does not appear in the Inventory Table.\r\n\r\n");
                }
            }
            if (strDataIssues.ToString() == "")
            {
                txt_DataIssues.Text = "There were no dependency issues found in any of the tables.";
            }
            else
            {
                txt_DataIssues.Text = strDataIssues.ToString();
            }
        }

        public void btn_CheckSpecChars_Click(object sender, EventArgs e)
        {
            txt_DataIssues.Visible = true;
            txt_DataIssues.Clear();
            strDataIssues.Clear();
            ///
            ///Accounts Lists
            ///
            listAccountNames.Clear();
            listTaxTXTypes.Clear();
            listTaxTXTypesDebitAccount.Clear();
            listTaxTXTypesCreditAccount.Clear();
            listTXTypes.Clear();
            listTXTypesDebitAccount.Clear();
            listTXTypesCreditAccount.Clear();
            listTXTypesTaxTypes1.Clear();
            listTXTypesTaxTypes2.Clear();
            listTXTypesTaxTypes3.Clear();
            listTXTypesTaxTypes4.Clear();
            listTermIDs.Clear();
            listRatesCode.Clear();
            listRatesCodeConfigCombo.Clear();
            listRatesBillingType.Clear();
            listRatesType.Clear();
            listRateSplitsCode.Clear();
            listRateSplitsCodeConfigCombo.Clear();
            listRateSplitsTXType.Clear();
            listRmTypesRatesRMType.Clear();
            listRmTypesRatesRateCode.Clear();
            listPlanTypesRatesPlanType.Clear();
            listPlanTypesRatesRateCode.Clear();
            listPlanTypesRatesTypeType.Clear();
            listPayCategoriesMethodCode.Clear();
            ///
            ///RoomsAndBeds Lists
            ///
            listCommunity.Clear();
            listBuildingID.Clear();
            listBuildingCommunity.Clear();
            listFloorID.Clear();
            listFloorBuildingID.Clear();
            listSectionID.Clear();
            listSectionsFloorID.Clear();
            listRoomsBedSpace.Clear();
            listRoomsRoomNo.Clear();
            listRoomsSecondarySpace.Clear();
            listUse1.Clear();
            listUse2.Clear();
            listRmConfigsBedSpaces.Clear();
            listRmConfigsBedSpacesonfigCombo.Clear();
            listRmConfigsRoomsType.Clear();
            listRmConfigsSectionID.Clear();
            listRmConfigsUse1.Clear();
            listRmConfigsUse2.Clear();
            listInventoryCode.Clear();
            listRmInventoryBedSpace.Clear();
            listRmInventoryCode.Clear();
            listMaintenanceCode.Clear();
            ///
            ///Accounting Table Lists
            /// 
            foreach (DataRow row in dsAccounts.Rows)
            {
                if ((row["PK_ACCOUNT_CODE"].ToString().IndexOf("!") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("@") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("#") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("$") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("%") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("^") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("&") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("*") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("(") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf(")") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("{") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("}") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("[") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("]") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("|") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("\\") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("'") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("\"") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf(":") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf(";") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("<") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf(">") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("?") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("/") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf(",") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("~") != -1) || (row["PK_ACCOUNT_CODE"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["PK_ACCOUNT_CODE"].ToString() + " has special characters in the Accounts Table.\r\n\r\n");
                }
            }
            foreach (DataRow row in dsTaxTXTypes.Rows)
            {
                if ((row["PK_TAX_TXTYPE"].ToString().IndexOf("!") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("@") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("#") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("$") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("%") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("^") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("&") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("*") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("(") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf(")") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("{") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("}") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("[") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("]") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("|") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("\\") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("'") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("\"") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf(":") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf(";") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("<") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf(">") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("?") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("/") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf(",") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("~") != -1) || (row["PK_TAX_TXTYPE"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["PK_TAX_TXTYPE"].ToString() + " has special characters in the Tax Transaction Table.\r\n\r\n");
                }
            }
            foreach (DataRow row in dsTXTypes.Rows)
            {
                if ((row["PK_TXTYPE"].ToString().IndexOf("!") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("@") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("#") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("$") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("%") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("^") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("&") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("*") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("(") != -1) || (row["PK_TXTYPE"].ToString().IndexOf(")") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("{") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("}") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("[") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("]") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("|") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("\\") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("'") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("\"") != -1) || (row["PK_TXTYPE"].ToString().IndexOf(":") != -1) || (row["PK_TXTYPE"].ToString().IndexOf(";") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("<") != -1) || (row["PK_TXTYPE"].ToString().IndexOf(">") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("?") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("/") != -1) || (row["PK_TXTYPE"].ToString().IndexOf(",") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("~") != -1) || (row["PK_TXTYPE"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["PK_TXTYPE"].ToString() + " has special characters in the Transaction Types Table.\r\n\r\n");
                }
            }
            foreach (DataRow row in dsTerms.Rows)
            {
                if ((row["PK_TERM_ID"].ToString().IndexOf("!") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("@") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("#") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("$") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("%") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("^") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("&") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("*") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("(") != -1) || (row["PK_TERM_ID"].ToString().IndexOf(")") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("{") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("}") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("[") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("]") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("|") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("\\") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("'") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("\"") != -1) || (row["PK_TERM_ID"].ToString().IndexOf(":") != -1) || (row["PK_TERM_ID"].ToString().IndexOf(";") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("<") != -1) || (row["PK_TERM_ID"].ToString().IndexOf(">") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("?") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("/") != -1) || (row["PK_TERM_ID"].ToString().IndexOf(",") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("~") != -1) || (row["PK_TERM_ID"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["PK_TERM_ID"].ToString() + " has special characters in the Terms Table.\r\n\r\n");
                }
            }
            foreach (DataRow row in dsRates.Rows)
            {
                if ((row["CK_RATE_CODE"].ToString().IndexOf("!") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("@") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("#") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("$") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("%") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("^") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("&") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("*") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("(") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf(")") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("{") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("}") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("[") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("]") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("|") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("\\") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("'") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("\"") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf(":") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf(";") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("<") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf(">") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("?") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("/") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf(",") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("~") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["CK_RATE_CODE"].ToString() + " has special characters in theRates Table.\r\n\r\n");
                }
            }
            foreach (DataRow row in dsRateSplits.Rows)
            {
                if ((row["CK_RATE_CODE"].ToString().IndexOf("!") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("@") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("#") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("$") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("%") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("^") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("&") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("*") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("(") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf(")") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("{") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("}") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("[") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("]") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("|") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("\\") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("'") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("\"") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf(":") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf(";") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("<") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf(">") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("?") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("/") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf(",") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("~") != -1) || (row["CK_RATE_CODE"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["CK_RATE_CODE"].ToString() + " has special characters in the Rate Splits Table.\r\n\r\n");
                }
            }
            foreach (DataRow row in dsRmTypesRates.Rows)
            {
                if ((row["PK_ROOM_TYPE"].ToString().IndexOf("!") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("@") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("#") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("$") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("%") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("^") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("&") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("*") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("(") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf(")") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("{") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("}") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("[") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("]") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("|") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("\\") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("'") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("\"") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf(":") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf(";") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("<") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf(">") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("?") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("/") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf(",") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("~") != -1) || (row["PK_ROOM_TYPE"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["PK_ROOM_TYPE"].ToString() + " has special characters in the Room Types Rates Table.\r\n\r\n");
                }
            }
            foreach (DataRow row in dsPlanTypesRates.Rows)
            {
                if ((row["PK_PLAN_TYPE"].ToString().IndexOf("!") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("@") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("#") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("$") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("%") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("^") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("&") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("*") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("(") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf(")") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("{") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("}") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("[") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("]") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("|") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("\\") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("'") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("\"") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf(":") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf(";") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("<") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf(">") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("?") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("/") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf(",") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("~") != -1) || (row["PK_PLAN_TYPE"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["PK_PLAN_TYPE"].ToString() + " has special characters in the Plan Types Rates Table.\r\n\r\n");
                }
            }
            foreach (DataRow row in dsPayCategories.Rows)
            {
                if ((row["PK_METHOD_CODE"].ToString().IndexOf("!") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("@") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("#") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("$") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("%") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("^") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("&") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("*") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("(") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf(")") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("{") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("}") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("[") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("]") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("|") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("\\") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("'") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("\"") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf(":") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf(";") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("<") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf(">") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("?") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("/") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf(",") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("~") != -1) || (row["PK_METHOD_CODE"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["PK_METHOD_CODE"].ToString() + " has special characters in the Payment Categories Table.\r\n\r\n");
                }
            }
            ///
            ///Rooms Table Lists
            ///
            foreach (DataRow row in dsCommunity.Rows)
            {
                if ((row["COMMUNITY"].ToString().IndexOf("!") != -1) || (row["COMMUNITY"].ToString().IndexOf("@") != -1) || (row["COMMUNITY"].ToString().IndexOf("#") != -1) || (row["COMMUNITY"].ToString().IndexOf("$") != -1) || (row["COMMUNITY"].ToString().IndexOf("%") != -1) || (row["COMMUNITY"].ToString().IndexOf("^") != -1) || (row["COMMUNITY"].ToString().IndexOf("&") != -1) || (row["COMMUNITY"].ToString().IndexOf("*") != -1) || (row["COMMUNITY"].ToString().IndexOf("(") != -1) || (row["COMMUNITY"].ToString().IndexOf(")") != -1) || (row["COMMUNITY"].ToString().IndexOf("{") != -1) || (row["COMMUNITY"].ToString().IndexOf("}") != -1) || (row["COMMUNITY"].ToString().IndexOf("[") != -1) || (row["COMMUNITY"].ToString().IndexOf("]") != -1) || (row["COMMUNITY"].ToString().IndexOf("|") != -1) || (row["COMMUNITY"].ToString().IndexOf("\\") != -1) || (row["COMMUNITY"].ToString().IndexOf("'") != -1) || (row["COMMUNITY"].ToString().IndexOf("\"") != -1) || (row["COMMUNITY"].ToString().IndexOf(":") != -1) || (row["COMMUNITY"].ToString().IndexOf(";") != -1) || (row["COMMUNITY"].ToString().IndexOf("<") != -1) || (row["COMMUNITY"].ToString().IndexOf(">") != -1) || (row["COMMUNITY"].ToString().IndexOf("?") != -1) || (row["COMMUNITY"].ToString().IndexOf("/") != -1) || (row["COMMUNITY"].ToString().IndexOf(",") != -1) || (row["COMMUNITY"].ToString().IndexOf("~") != -1) || (row["COMMUNITY"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["COMMUNITY"].ToString() + " has special characters in the Community Table.\r\n\r\n");
                }
            }
            foreach (DataRow row in dsBuildings.Rows)
            {
                if ((row["BUILDINGID"].ToString().IndexOf("!") != -1) || (row["BUILDINGID"].ToString().IndexOf("@") != -1) || (row["BUILDINGID"].ToString().IndexOf("#") != -1) || (row["BUILDINGID"].ToString().IndexOf("$") != -1) || (row["BUILDINGID"].ToString().IndexOf("%") != -1) || (row["BUILDINGID"].ToString().IndexOf("^") != -1) || (row["BUILDINGID"].ToString().IndexOf("&") != -1) || (row["BUILDINGID"].ToString().IndexOf("*") != -1) || (row["BUILDINGID"].ToString().IndexOf("(") != -1) || (row["BUILDINGID"].ToString().IndexOf(")") != -1) || (row["BUILDINGID"].ToString().IndexOf("{") != -1) || (row["BUILDINGID"].ToString().IndexOf("}") != -1) || (row["BUILDINGID"].ToString().IndexOf("[") != -1) || (row["BUILDINGID"].ToString().IndexOf("]") != -1) || (row["BUILDINGID"].ToString().IndexOf("|") != -1) || (row["BUILDINGID"].ToString().IndexOf("\\") != -1) || (row["BUILDINGID"].ToString().IndexOf("'") != -1) || (row["BUILDINGID"].ToString().IndexOf("\"") != -1) || (row["BUILDINGID"].ToString().IndexOf(":") != -1) || (row["BUILDINGID"].ToString().IndexOf(";") != -1) || (row["BUILDINGID"].ToString().IndexOf("<") != -1) || (row["BUILDINGID"].ToString().IndexOf(">") != -1) || (row["BUILDINGID"].ToString().IndexOf("?") != -1) || (row["BUILDINGID"].ToString().IndexOf("/") != -1) || (row["BUILDINGID"].ToString().IndexOf(",") != -1) || (row["BUILDINGID"].ToString().IndexOf("~") != -1) || (row["BUILDINGID"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["BUILDINGID"].ToString() + " has special characters in the Buildings Table.\r\n\r\n");
                }
            }
            foreach (DataRow row in dsFloors.Rows)
            {
                if ((row["FLOORID"].ToString().IndexOf("!") != -1) || (row["FLOORID"].ToString().IndexOf("@") != -1) || (row["FLOORID"].ToString().IndexOf("#") != -1) || (row["FLOORID"].ToString().IndexOf("$") != -1) || (row["FLOORID"].ToString().IndexOf("%") != -1) || (row["FLOORID"].ToString().IndexOf("^") != -1) || (row["FLOORID"].ToString().IndexOf("&") != -1) || (row["FLOORID"].ToString().IndexOf("*") != -1) || (row["FLOORID"].ToString().IndexOf("(") != -1) || (row["FLOORID"].ToString().IndexOf(")") != -1) || (row["FLOORID"].ToString().IndexOf("{") != -1) || (row["FLOORID"].ToString().IndexOf("}") != -1) || (row["FLOORID"].ToString().IndexOf("[") != -1) || (row["FLOORID"].ToString().IndexOf("]") != -1) || (row["FLOORID"].ToString().IndexOf("|") != -1) || (row["FLOORID"].ToString().IndexOf("\\") != -1) || (row["FLOORID"].ToString().IndexOf("'") != -1) || (row["FLOORID"].ToString().IndexOf("\"") != -1) || (row["FLOORID"].ToString().IndexOf(":") != -1) || (row["FLOORID"].ToString().IndexOf(";") != -1) || (row["FLOORID"].ToString().IndexOf("<") != -1) || (row["FLOORID"].ToString().IndexOf(">") != -1) || (row["FLOORID"].ToString().IndexOf("?") != -1) || (row["FLOORID"].ToString().IndexOf("/") != -1) || (row["FLOORID"].ToString().IndexOf(",") != -1) || (row["FLOORID"].ToString().IndexOf("~") != -1) || (row["FLOORID"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["FLOORID"].ToString() + " has special characters in the Floors Table.\r\n\r\n");
                }
            }
            foreach (DataRow row in dsFloorSections.Rows)
            {
                if ((row["SECTIONID"].ToString().IndexOf("!") != -1) || (row["SECTIONID"].ToString().IndexOf("@") != -1) || (row["SECTIONID"].ToString().IndexOf("#") != -1) || (row["SECTIONID"].ToString().IndexOf("$") != -1) || (row["SECTIONID"].ToString().IndexOf("%") != -1) || (row["SECTIONID"].ToString().IndexOf("^") != -1) || (row["SECTIONID"].ToString().IndexOf("&") != -1) || (row["SECTIONID"].ToString().IndexOf("*") != -1) || (row["SECTIONID"].ToString().IndexOf("(") != -1) || (row["SECTIONID"].ToString().IndexOf(")") != -1) || (row["SECTIONID"].ToString().IndexOf("{") != -1) || (row["SECTIONID"].ToString().IndexOf("}") != -1) || (row["SECTIONID"].ToString().IndexOf("[") != -1) || (row["SECTIONID"].ToString().IndexOf("]") != -1) || (row["SECTIONID"].ToString().IndexOf("|") != -1) || (row["SECTIONID"].ToString().IndexOf("\\") != -1) || (row["SECTIONID"].ToString().IndexOf("'") != -1) || (row["SECTIONID"].ToString().IndexOf("\"") != -1) || (row["SECTIONID"].ToString().IndexOf(":") != -1) || (row["SECTIONID"].ToString().IndexOf(";") != -1) || (row["SECTIONID"].ToString().IndexOf("<") != -1) || (row["SECTIONID"].ToString().IndexOf(">") != -1) || (row["SECTIONID"].ToString().IndexOf("?") != -1) || (row["SECTIONID"].ToString().IndexOf("/") != -1) || (row["SECTIONID"].ToString().IndexOf(",") != -1) || (row["SECTIONID"].ToString().IndexOf("~") != -1) || (row["SECTIONID"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["SECTIONID"].ToString() + " has special characters in the Floor Sections Table.\r\n\r\n");
                }
            }
            foreach (DataRow row in dsRooms.Rows)
            {
                if ((row["BEDSPACE"].ToString().IndexOf("!") != -1) || (row["BEDSPACE"].ToString().IndexOf("@") != -1) || (row["BEDSPACE"].ToString().IndexOf("#") != -1) || (row["BEDSPACE"].ToString().IndexOf("$") != -1) || (row["BEDSPACE"].ToString().IndexOf("%") != -1) || (row["BEDSPACE"].ToString().IndexOf("^") != -1) || (row["BEDSPACE"].ToString().IndexOf("&") != -1) || (row["BEDSPACE"].ToString().IndexOf("*") != -1) || (row["BEDSPACE"].ToString().IndexOf("(") != -1) || (row["BEDSPACE"].ToString().IndexOf(")") != -1) || (row["BEDSPACE"].ToString().IndexOf("{") != -1) || (row["BEDSPACE"].ToString().IndexOf("}") != -1) || (row["BEDSPACE"].ToString().IndexOf("[") != -1) || (row["BEDSPACE"].ToString().IndexOf("]") != -1) || (row["BEDSPACE"].ToString().IndexOf("|") != -1) || (row["BEDSPACE"].ToString().IndexOf("\\") != -1) || (row["BEDSPACE"].ToString().IndexOf("'") != -1) || (row["BEDSPACE"].ToString().IndexOf("\"") != -1) || (row["BEDSPACE"].ToString().IndexOf(":") != -1) || (row["BEDSPACE"].ToString().IndexOf(";") != -1) || (row["BEDSPACE"].ToString().IndexOf("<") != -1) || (row["BEDSPACE"].ToString().IndexOf(">") != -1) || (row["BEDSPACE"].ToString().IndexOf("?") != -1) || (row["BEDSPACE"].ToString().IndexOf("/") != -1) || (row["BEDSPACE"].ToString().IndexOf(",") != -1) || (row["BEDSPACE"].ToString().IndexOf("~") != -1) || (row["BEDSPACE"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["BEDSPACE"].ToString() + " has special characters in the Rates Table.\r\n\r\n");
                }
            }
            foreach (DataRow row in dsUse1.Rows)
            {
                if ((row["USE1"].ToString().IndexOf("!") != -1) || (row["USE1"].ToString().IndexOf("@") != -1) || (row["USE1"].ToString().IndexOf("#") != -1) || (row["USE1"].ToString().IndexOf("$") != -1) || (row["USE1"].ToString().IndexOf("%") != -1) || (row["USE1"].ToString().IndexOf("^") != -1) || (row["USE1"].ToString().IndexOf("&") != -1) || (row["USE1"].ToString().IndexOf("*") != -1) || (row["USE1"].ToString().IndexOf("(") != -1) || (row["USE1"].ToString().IndexOf(")") != -1) || (row["USE1"].ToString().IndexOf("{") != -1) || (row["USE1"].ToString().IndexOf("}") != -1) || (row["USE1"].ToString().IndexOf("[") != -1) || (row["USE1"].ToString().IndexOf("]") != -1) || (row["USE1"].ToString().IndexOf("|") != -1) || (row["USE1"].ToString().IndexOf("\\") != -1) || (row["USE1"].ToString().IndexOf("'") != -1) || (row["USE1"].ToString().IndexOf("\"") != -1) || (row["USE1"].ToString().IndexOf(":") != -1) || (row["USE1"].ToString().IndexOf(";") != -1) || (row["USE1"].ToString().IndexOf("<") != -1) || (row["USE1"].ToString().IndexOf(">") != -1) || (row["USE1"].ToString().IndexOf("?") != -1) || (row["USE1"].ToString().IndexOf("/") != -1) || (row["USE1"].ToString().IndexOf(",") != -1) || (row["USE1"].ToString().IndexOf("~") != -1) || (row["USE1"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["USE1"].ToString() + " has special characters in the Use 1 Table.\r\n\r\n");
                }
            }
            foreach (DataRow row in dsUse2.Rows)
            {
                if ((row["USE2"].ToString().IndexOf("!") != -1) || (row["USE2"].ToString().IndexOf("@") != -1) || (row["USE2"].ToString().IndexOf("#") != -1) || (row["USE2"].ToString().IndexOf("$") != -1) || (row["USE2"].ToString().IndexOf("%") != -1) || (row["USE2"].ToString().IndexOf("^") != -1) || (row["USE2"].ToString().IndexOf("&") != -1) || (row["USE2"].ToString().IndexOf("*") != -1) || (row["USE2"].ToString().IndexOf("(") != -1) || (row["USE2"].ToString().IndexOf(")") != -1) || (row["USE2"].ToString().IndexOf("{") != -1) || (row["USE2"].ToString().IndexOf("}") != -1) || (row["USE2"].ToString().IndexOf("[") != -1) || (row["USE2"].ToString().IndexOf("]") != -1) || (row["USE2"].ToString().IndexOf("|") != -1) || (row["USE2"].ToString().IndexOf("\\") != -1) || (row["USE2"].ToString().IndexOf("'") != -1) || (row["USE2"].ToString().IndexOf("\"") != -1) || (row["USE2"].ToString().IndexOf(":") != -1) || (row["USE2"].ToString().IndexOf(";") != -1) || (row["USE2"].ToString().IndexOf("<") != -1) || (row["USE2"].ToString().IndexOf(">") != -1) || (row["USE2"].ToString().IndexOf("?") != -1) || (row["USE2"].ToString().IndexOf("/") != -1) || (row["USE2"].ToString().IndexOf(",") != -1) || (row["USE2"].ToString().IndexOf("~") != -1) || (row["USE2"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["USE2"].ToString() + " has special characters in the Use 2 Table.\r\n\r\n");
                }
            }
            foreach (DataRow row in dsRoomConfigs.Rows)
            {
                if ((row["BEDSPACE"].ToString().IndexOf("!") != -1) || (row["BEDSPACE"].ToString().IndexOf("@") != -1) || (row["BEDSPACE"].ToString().IndexOf("#") != -1) || (row["BEDSPACE"].ToString().IndexOf("$") != -1) || (row["BEDSPACE"].ToString().IndexOf("%") != -1) || (row["BEDSPACE"].ToString().IndexOf("^") != -1) || (row["BEDSPACE"].ToString().IndexOf("&") != -1) || (row["BEDSPACE"].ToString().IndexOf("*") != -1) || (row["BEDSPACE"].ToString().IndexOf("(") != -1) || (row["BEDSPACE"].ToString().IndexOf(")") != -1) || (row["BEDSPACE"].ToString().IndexOf("{") != -1) || (row["BEDSPACE"].ToString().IndexOf("}") != -1) || (row["BEDSPACE"].ToString().IndexOf("[") != -1) || (row["BEDSPACE"].ToString().IndexOf("]") != -1) || (row["BEDSPACE"].ToString().IndexOf("|") != -1) || (row["BEDSPACE"].ToString().IndexOf("\\") != -1) || (row["BEDSPACE"].ToString().IndexOf("'") != -1) || (row["BEDSPACE"].ToString().IndexOf("\"") != -1) || (row["BEDSPACE"].ToString().IndexOf(":") != -1) || (row["BEDSPACE"].ToString().IndexOf(";") != -1) || (row["BEDSPACE"].ToString().IndexOf("<") != -1) || (row["BEDSPACE"].ToString().IndexOf(">") != -1) || (row["BEDSPACE"].ToString().IndexOf("?") != -1) || (row["BEDSPACE"].ToString().IndexOf("/") != -1) || (row["BEDSPACE"].ToString().IndexOf(",") != -1) || (row["BEDSPACE"].ToString().IndexOf("~") != -1) || (row["BEDSPACE"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["BEDSPACE"].ToString() + " has special characters in the Room Configs Table.\r\n\r\n");
                }
            }
            foreach (DataRow row in dsInventory.Rows)
            {
                if ((row["INVENTORYCODE"].ToString().IndexOf("!") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("@") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("#") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("$") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("%") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("^") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("&") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("*") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("(") != -1) || (row["INVENTORYCODE"].ToString().IndexOf(")") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("{") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("}") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("[") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("]") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("|") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("\\") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("'") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("\"") != -1) || (row["INVENTORYCODE"].ToString().IndexOf(":") != -1) || (row["INVENTORYCODE"].ToString().IndexOf(";") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("<") != -1) || (row["INVENTORYCODE"].ToString().IndexOf(">") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("?") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("/") != -1) || (row["INVENTORYCODE"].ToString().IndexOf(",") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("~") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["INVENTORYCODE"].ToString() + " has special characters in the Invetory Table.\r\n\r\n");
                }
            }
            foreach (DataRow row in dsRmInventory.Rows)
            {
                if ((row["BEDSPACE"].ToString().IndexOf("!") != -1) || (row["BEDSPACE"].ToString().IndexOf("@") != -1) || (row["BEDSPACE"].ToString().IndexOf("#") != -1) || (row["BEDSPACE"].ToString().IndexOf("$") != -1) || (row["BEDSPACE"].ToString().IndexOf("%") != -1) || (row["BEDSPACE"].ToString().IndexOf("^") != -1) || (row["BEDSPACE"].ToString().IndexOf("&") != -1) || (row["BEDSPACE"].ToString().IndexOf("*") != -1) || (row["BEDSPACE"].ToString().IndexOf("(") != -1) || (row["BEDSPACE"].ToString().IndexOf(")") != -1) || (row["BEDSPACE"].ToString().IndexOf("{") != -1) || (row["BEDSPACE"].ToString().IndexOf("}") != -1) || (row["BEDSPACE"].ToString().IndexOf("[") != -1) || (row["BEDSPACE"].ToString().IndexOf("]") != -1) || (row["BEDSPACE"].ToString().IndexOf("|") != -1) || (row["BEDSPACE"].ToString().IndexOf("\\") != -1) || (row["BEDSPACE"].ToString().IndexOf("'") != -1) || (row["BEDSPACE"].ToString().IndexOf("\"") != -1) || (row["BEDSPACE"].ToString().IndexOf(":") != -1) || (row["BEDSPACE"].ToString().IndexOf(";") != -1) || (row["BEDSPACE"].ToString().IndexOf("<") != -1) || (row["BEDSPACE"].ToString().IndexOf(">") != -1) || (row["BEDSPACE"].ToString().IndexOf("?") != -1) || (row["BEDSPACE"].ToString().IndexOf("/") != -1) || (row["BEDSPACE"].ToString().IndexOf(",") != -1) || (row["BEDSPACE"].ToString().IndexOf("~") != -1) || (row["BEDSPACE"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["BEDSPACE"].ToString() + " has special characters in the Room Inventorytbh.\r\n\r\n");
                }
                if ((row["INVENTORYCODE"].ToString().IndexOf("!") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("@") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("#") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("$") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("%") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("^") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("&") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("*") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("(") != -1) || (row["INVENTORYCODE"].ToString().IndexOf(")") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("{") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("}") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("[") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("]") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("|") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("\\") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("'") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("\"") != -1) || (row["INVENTORYCODE"].ToString().IndexOf(":") != -1) || (row["INVENTORYCODE"].ToString().IndexOf(";") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("<") != -1) || (row["INVENTORYCODE"].ToString().IndexOf(">") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("?") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("/") != -1) || (row["INVENTORYCODE"].ToString().IndexOf(",") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("~") != -1) || (row["INVENTORYCODE"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["INVENTORYCODE"].ToString() + " has special characters in the Room Inventory Table.\r\n\r\n");
                }
            }
            foreach (DataRow row in dsRmMaintCode.Rows)
            {
                if ((row["MAINTENANCECODE"].ToString().IndexOf("!") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("@") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("#") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("$") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("%") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("^") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("&") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("*") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("(") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf(")") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("{") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("}") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("[") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("]") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("|") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("\\") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("'") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("\"") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf(":") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf(";") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("<") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf(">") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("?") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("/") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf(",") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("~") != -1) || (row["MAINTENANCECODE"].ToString().IndexOf("`") != -1))
                {
                    strDataIssues.Append(row["MAINTENANCECODE"].ToString() + " has special characters in the Room Maintenance Code Table.\r\n\r\n");
                }
            }
            if (strDataIssues.ToString() == "")
            {
                txt_DataIssues.Text = "There were no special character issues found in any of the tables.";
            }
            else
            {
                txt_DataIssues.Text = strDataIssues.ToString();
            }
        }
		public void btn_CreateSQL_Click(object sender, EventArgs e)
        {
            strAccSQL.Clear();
            strtaxTXSQL.Clear();
            strTXSQL.Clear();
            strTermsSQL.Clear();
            strRatesSQL.Clear();
            strRateSplitsSQL.Clear();
            strRmTypesRatesSQL.Clear();
            strPlanTypesRatesSQL.Clear();
            strPayCategoriesSQL.Clear();
            strCommunitySQL.Clear();
            strBuildingsSQL.Clear();
            strFloorsSQL.Clear();
            strFloorSectionsSQL.Clear();
            strRoomsSQL.Clear();
            strUse1SQL.Clear();
            strUse2SQL.Clear();
            strRoomConfigsSQL.Clear();
            strMatchCritSQL.Clear();
            strInventorySQL.Clear();
            strRmInventorySQL.Clear();
            strRmMaintCodeSQL.Clear();
            strMaintRefToSQL.Clear();
            if (combo_DBType.Text.Equals("Select Database Type") || combo_DateFormat.Text.Equals("Select Date format") || txt_RealDatabaseName.Text == "")
            {
                MessageBox.Show("Please be sure to Select Database Type, Date Format and enter the real data's database name");
            }
            else
            {
                ///
                ///Accounts SQL Scripts
                ///
                try
                {
                string acctSQLPath = txt_SQLLoc.Text + "\\Accounts\\1.Accounts.sql";
                int acctRows = dsAccounts.Rows.Count;
                if (acctRows > 0)
                    {
                        foreach (DataRow row in dsAccounts.Rows)
                        {
                            string strStatus = row["STATUS"].ToString();
                            if (strStatus == "0")
                            {
                                strStatus = "0";
                            }
                            else
                            {
                                strStatus = "1";
                            }
                            string strIxReceivable = row["STATUS"].ToString();
                            if (strIxReceivable == "0")
                            {
                                strIxReceivable = "0";
                            }
                            else
                            {
                                strIxReceivable = "1";
                            }
                            if (combo_DBType.Text.Equals("SQL"))
                            {
                                strAccSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.acct_t_Account_Names (pk_Account_Code,Account_Name,Account_Type,ix_Receivable,Alias_Code,Status) Values ('" + row["PK_ACCOUNT_CODE"] + "','" + row["Account_Name"].ToString().Replace("'", "''") + "','" + row["ACCOUNT_TYPE"] + "'," + strIxReceivable + ",'" + row["ALIAS_CODE"] + "'," + strStatus + ");\r\n");
                            }
                            else if (combo_DBType.Text.Equals("Oracle"))
                            {
                                strAccSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".acct_t_Account_Names (pk_Account_Code,Account_Name,Account_Type,ix_Receivable,Alias_Code,Status) Values ('" + row["PK_ACCOUNT_CODE"] + "','" + row["Account_Name"].ToString().Replace("'", "''") + "','" + row["ACCOUNT_TYPE"] + "'," + strIxReceivable + ",'" + row["ALIAS_CODE"] + "'," + strStatus + ");\r\nCommit;\r\n");
                            }
                        }
                        File.WriteAllText(acctSQLPath, strAccSQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ///
                ///Tax TX Types SQL Scripts
                ///
                try
                {
                    string taxTXSQLPath = txt_SQLLoc.Text + "\\Accounts\\2.TaxTransactions.sql";
                    int taxTXRows = dsTaxTXTypes.Rows.Count;
                    if (taxTXRows > 0)
                    {
                        foreach (DataRow row in dsTaxTXTypes.Rows)
                        {
                            string strStatus = row["STATUS"].ToString();
                            if (strStatus == "0")
                            {
                                strStatus = "0";
                            }
                            else
                            {
                                strStatus = "1";
                            }
                            if (combo_DBType.Text.Equals("SQL"))
                            {
                                strtaxTXSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + "dbo.acct_t_Tax_Transaction_Type (pk_Tax_TxType,Tax_Transaction_Type_Description,fk_Debit_Account,fk_Credit_Account,Percentage,Secondary_Code,Status) Values ('" + row["pk_Tax_TxType"] + "','" + row["Tax_Transaction_Type_Description"].ToString().Replace("'", "''") + "','" + row["fk_Debit_Account"] + "','" + row["fk_Credit_Account"] + "','" + row["Percentage"] + "','" + row["Secondary_Code"] + "'," + strStatus + ");\r\n");
                            }
                            else if (combo_DBType.Text.Equals("Oracle"))
                            {
                                strtaxTXSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".acct_t_Tax_Transaction_Type (pk_Tax_TxType,Tax_Transaction_Type_Description,fk_Debit_Account,fk_Credit_Account,Percentage,Secondary_Code,Status) Values ('" + row["pk_Tax_TxType"] + "','" + row["Tax_Transaction_Type_Description"].ToString().Replace("'", "''") + "','" + row["fk_Debit_Account"] + "','" + row["fk_Credit_Account"] + "','" + row["Percentage"] + "','" + row["Secondary_Code"] + "'," + strStatus + ");\r\nCommit;\r\n");
                            }
                        }
                        File.WriteAllText(taxTXSQLPath, strtaxTXSQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ///
                ///TX Types SQL Scripts
                ///
                try
                {
                    string TXSQLPath = txt_SQLLoc.Text + "\\Accounts\\3.Transactions.sql";
                    int TXRows = dsTXTypes.Rows.Count;
                    if (TXRows > 0)
                    {
                        foreach (DataRow row in dsTXTypes.Rows)
                        {
                            string strStatus = row["STATUS"].ToString();
                            if (strStatus == "0")
                            {
                                strStatus = "0";
                            }
                            else
                            {
                                strStatus = "1";
                            }
                            string strTTD = row["Transaction_Type_Default"].ToString();
                            if (strTTD == "1")
                            {
                                strTTD = "1";
                            }
                            else
                            {
                                strTTD = "0";
                            }
                            string strCharges = row["CHARGES"].ToString();
                            if (strCharges == "1")
                            {
                                strCharges = "1";
                            }
                            else
                            {
                                strCharges = "0";
                            }
                            string strUploadable = row["UPLOADABLE"].ToString();
                            if (strUploadable == "0")
                            {
                                strUploadable = "0";
                            }
                            else
                            {
                                strUploadable = "1";
                            }
                            string strBBClose = row["BB_CLOSE_ACC"].ToString();
                            if (strBBClose == "1")
                            {
                                strBBClose = "1";
                            }
                            else
                            {
                                strBBClose = "0";
                            }
                            string strCredInv = row["CREDIT_INVOICE"].ToString();
                            if (strCredInv == "1")
                            {
                                strCredInv = "1";
                            }
                            else
                            {
                                strCredInv = "0";
                            }
                            string strPOS = row["POINTOFSALE"].ToString();
                            if (strPOS == "1")
                            {
                                strPOS = "1";
                            }
                            else
                            {
                                strPOS = "0";
                            }
                            string strTransfer = row["TRANSFER"].ToString();
                            if (strTransfer == "1")
                            {
                                strTransfer = "1";
                            }
                            else
                            {
                                strTransfer = "0";
                            }
                            string strBond = row["BOND"].ToString();
                            if (strBond == "1")
                            {
                                strBond = "1";
                            }
                            else
                            {
                                strBond = "0";
                            }
                            string strRefund = row["REFUND"].ToString();
                            if (strRefund == "1")
                            {
                                strRefund = "1";
                            }
                            else
                            {
                                strRefund = "0";
                            }
                            string strPayment = row["PAYMENT"].ToString();
                            if (strPayment == "1")
                            {
                                strPayment = "1";
                            }
                            else
                            {
                                strPayment = "0";
                            }
                            string strPaymentBond = row["PAYMENTBOND"].ToString();
                            if (strPaymentBond == "1")
                            {
                                strPaymentBond = "1";
                            }
                            else
                            {
                                strPaymentBond = "0";
                            }
                            string strBankTransfer = row["BANKTRANSFER"].ToString();
                            if (strBankTransfer == "1")
                            {
                                strBankTransfer = "1";
                            }
                            else
                            {
                                strBankTransfer = "0";
                            }
                            string strIT = row["IT"].ToString();
                            if (strIT == "1")
                            {
                                strIT = "1";
                            }
                            else
                            {
                                strIT = "0";
                            }
                            string strPI = row["PI"].ToString();
                            if (strPI == "1")
                            {
                                strPI = "1";
                            }
                            else
                            {
                                strPI = "0";
                            }
                            string strApplication = row["APPLICATION"].ToString();
                            if (strApplication == "1")
                            {
                                strApplication = "1";
                            }
                            else
                            {
                                strApplication = "0";
                            }
                            string percentage1 = row["Tax1_Percentage"].ToString();
                            if (percentage1 != "")
                            {
                                percentage1 = row["Tax1_Percentage"].ToString();
                            }
                            else
                            {
                                percentage1 = "0.00000";
                            }
                            string percentage2 = row["Tax2_Percentage"].ToString();
                            if (percentage2 != "")
                            {
                                percentage2 = row["Tax2_Percentage"].ToString();
                            }
                            else
                            {
                                percentage2 = "0.00000";
                            }
                            string percentage3 = row["Tax3_Percentage"].ToString();
                            if (percentage3 != "")
                            {
                                percentage3 = row["Tax3_Percentage"].ToString();
                            }
                            else
                            {
                                percentage3 = "0.00000";
                            }
                            string percentage4 = row["Tax4_Percentage"].ToString();
                            if (percentage4 != "")
                            {
                                percentage4 = row["Tax4_Percentage"].ToString();
                            }
                            else
                            {
                                percentage4 = "0.00000";
                            }
                            string minTX = row["Min_Tx"].ToString();
                            if (minTX != "")
                            {
                                minTX = row["Min_Tx"].ToString();
                            }
                            else
                            {
                                minTX = "0.00000";
                            }
                            string maxTX = row["Max_Tx"].ToString();
                            if (maxTX != "")
                            {
                                maxTX = row["Max_Tx"].ToString();
                            }
                            else
                            {
                                maxTX = "0.00000";
                            }

                            if (combo_DBType.Text.Equals("SQL"))
                            {
                                strTXSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.ACCT_T_TRANSACTION_TYPE (PK_TXTYPE,TRANSACTION_TYPE_DEFAULT,CHARGES,UPLOADABLE,TRANSACTION_TYPE_DESCRIPTION,FK_DEBIT_ACCOUNT,SECONDARY_CODE,FK_CREDIT_ACCOUNT,FK_TAX_TXTYPE1,TAX1_PERCENTAGE,FK_TAX_TXTYPE2,TAX2_PERCENTAGE,FK_TAX_TXTYPE3,TAX3_PERCENTAGE,FK_TAX_TXTYPE4,TAX4_PERCENTAGE,Min_Tx,Max_Tx,BB_Close_Acc,Status,Credit_Invoice,PointOfSale,Transfer,Bond,Refund,Payment,PaymentBond,BankTransfer,IT,PI,Application) Values ('" + row["PK_TXTYPE"] + "','" + strTTD + "'," + strCharges + "," + strUploadable + ",'" + row["TRANSACTION_TYPE_DESCRIPTION"].ToString().Replace("'", "''") + "','" + row["FK_DEBIT_ACCOUNT"] + "','" + row["SECONDARY_CODE"] + "','" + row["FK_CREDIT_ACCOUNT"] + "','" + row["FK_TAX_TXTYPE1"] + "'," + percentage1 + ",'" + row["FK_TAX_TXTYPE2"] + "'," + percentage2 + ",'" + row["FK_TAX_TXTYPE3"] + "'," + percentage3 + ",'" + row["FK_TAX_TXTYPE4"] + "'," + percentage4 + "," + minTX + "," + maxTX + "," + strBBClose + "," + strStatus + "," + strCredInv + "," + strPOS + "," + strTransfer + "," + strBond + "," + strRefund + "," + strPayment + "," + strPaymentBond + "," + strBankTransfer + "," + strIT + "," + strPI + "," + strApplication + ");\r\n");

                            }
                            else if (combo_DBType.Text.Equals("Oracle"))
                            {
                                strTXSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".ACCT_T_TRANSACTION_TYPE (PK_TXTYPE,TRANSACTION_TYPE_DEFAULT,CHARGES,UPLOADABLE,TRANSACTION_TYPE_DESCRIPTION,FK_DEBIT_ACCOUNT,SECONDARY_CODE,FK_CREDIT_ACCOUNT,FK_TAX_TXTYPE1,TAX1_PERCENTAGE,FK_TAX_TXTYPE2,TAX2_PERCENTAGE,FK_TAX_TXTYPE3,TAX3_PERCENTAGE,FK_TAX_TXTYPE4,TAX4_PERCENTAGE,Min_Tx,Max_Tx,BB_Close_Acc,Status,Credit_Invoice,PointOfSale,Transfer,Bond,Refund,Payment,PaymentBond,BankTransfer,IT,PI,Application) Values ('" + row["PK_TXTYPE"] + "','" + strTTD + "'," + strCharges + "," + strUploadable + ",'" + row["TRANSACTION_TYPE_DESCRIPTION"].ToString().Replace("'", "''") + "','" + row["FK_DEBIT_ACCOUNT"] + "','" + row["SECONDARY_CODE"] + "','" + row["FK_CREDIT_ACCOUNT"] + "','" + row["FK_TAX_TXTYPE1"] + "'," + percentage1 + ",'" + row["FK_TAX_TXTYPE2"] + "'," + percentage2 + ",'" + row["FK_TAX_TXTYPE3"] + "'," + percentage3 + ",'" + row["FK_TAX_TXTYPE4"] + "'," + percentage4 + "," + minTX + "," + maxTX + "," + strBBClose + "," + strStatus + "," + strCredInv + "," + strPOS + "," + strTransfer + "," + strBond + "," + strRefund + "," + strPayment + "," + strPaymentBond + "," + strBankTransfer + "," + strIT + "," + strPI + "," + strApplication + ");\r\nCommit;\r\n");
                            }
                        }
                        File.WriteAllText(TXSQLPath, strTXSQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ///
                ///Terms SQL Scripts
                ///
                try
                {
                    string TermsSQLPath = txt_SQLLoc.Text + "\\Accounts\\4.Terms.sql";
                    int TermsRows = dsTerms.Rows.Count;
                    if (TermsRows > 0)
                    {
                        foreach (DataRow row in dsTerms.Rows)
                        {
                            string percentage2Bill = row["PERCENTAGE_TO_BILL"].ToString();
                            if (percentage2Bill != "")
                            {
                                percentage2Bill = row["PERCENTAGE_TO_BILL"].ToString();
                            }
                            else
                            {
                                percentage2Bill = "0.00000";
                            }
                            string strTDN = row["TERM_DATES_NOMINATED"].ToString();
                            if (strTDN == "0")
                            {
                                strTDN = "0";
                            }
                            else
                            {
                                strTDN = "1";
                            }
                            string strTDU = row["TERM_DATES_UPLOAD"].ToString();
                            if (strTDU == "0")
                            {
                                strTDU = "0";
                            }
                            else
                            {
                                strTDU = "1";
                            }
                            string strStatus = row["STATUS"].ToString();
                            if (strStatus == "0")
                            {
                                strStatus = "0";
                            }
                            else
                            {
                                strStatus = "1";
                            }
                            string strRoomTerm = row["ROOM_TERM"].ToString();
                            if (strRoomTerm == "1")
                            {
                                strRoomTerm = "1";
                            }
                            else
                            {
                                strRoomTerm = "0";
                            }
                            string strPlanTerm = row["PLAN_TERM"].ToString();
                            if (strPlanTerm == "1")
                            {
                                strPlanTerm = "1";
                            }
                            else
                            {
                                strPlanTerm = "0";
                            }
                            string strBillingTerm = row["BILLING_TERM"].ToString();
                            if (strBillingTerm == "1")
                            {
                                strBillingTerm = "1";
                            }
                            else
                            {
                                strBillingTerm = "0";
                            }
                            string strPropertyTerm = row["PROPERTY_TERM"].ToString();
                            if (strPropertyTerm == "1")
                            {
                                strPropertyTerm = "1";
                            }
                            else
                            {
                                strPropertyTerm = "0";
                            }
                            string strPaymentTerm = row["PAYMENT_TERM"].ToString();
                            if (strPaymentTerm == "1")
                            {
                                strPaymentTerm = "1";
                            }
                            else
                            {
                                strPaymentTerm = "0";
                            }
                            string strTDSDDay = "";
                            string strTDSDMonth = "";
                            string strTDSDYear = "";
                            string strTDSDComplete = "";
                            string strTDEDDay = "";
                            string strTDEDMonth = "";
                            string strTDEDYear = "";
                            string strTDEDComplete = "";
                            string[] TDSDArray = new string[3]; ;
                            string[] TDEDArray = new string[3]; ;
                            int createSQL = 1;
                            if (row["TERM_DATES_START_DATE"].ToString() != "")
                            {
                                TDSDArray = row["TERM_DATES_START_DATE"].ToString().Split('/');
                            }
                            else
                            {
                                createSQL = 0;
                            }
                            if (row["TERM_DATES_END_DATE"].ToString() != "")
                            {
                                TDEDArray = row["TERM_DATES_END_DATE"].ToString().Split('/');
                            }
                            else
                            {
                                createSQL = 0;
                            }
                            if (createSQL == 1)
                            {
                                if (combo_DateFormat.Text.Equals("American"))
                                {

                                    strTDSDDay = TDSDArray[1].ToString();
                                    if ((strTDSDDay == "1") || (strTDSDDay == "2") || (strTDSDDay == "3") || (strTDSDDay == "4") || (strTDSDDay == "5") || (strTDSDDay == "6") || (strTDSDDay == "7") || (strTDSDDay == "8") || (strTDSDDay == "9"))
                                    {
                                        strTDSDDay = "0" + strTDSDDay;
                                    }

                                    strTDSDMonth = TDSDArray[0].ToString();
                                    if ((strTDSDMonth == "1") || (strTDSDMonth == "2") || (strTDSDMonth == "3") || (strTDSDMonth == "4") || (strTDSDMonth == "5") || (strTDSDMonth == "6") || (strTDSDMonth == "7") || (strTDSDMonth == "8") || (strTDSDMonth == "9"))
                                    {
                                        strTDSDMonth = "0" + strTDSDMonth;
                                    }

                                    strTDSDYear = TDSDArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strTDSDComplete = "'" + strTDSDMonth + "/" + strTDSDDay + "/" + strTDSDYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strTDSDComplete = "to_date('" + strTDSDMonth + "/" + strTDSDDay + "/" + strTDSDYear + "','MM/DD/YYYY')";
                                    }
                                    strTDEDDay = TDEDArray[1].ToString();
                                    if ((strTDEDDay == "1") || (strTDEDDay == "2") || (strTDEDDay == "3") || (strTDEDDay == "4") || (strTDEDDay == "5") || (strTDEDDay == "6") || (strTDEDDay == "7") || (strTDEDDay == "8") || (strTDEDDay == "9"))
                                    {
                                        strTDEDDay = "0" + strTDEDDay;
                                    }

                                    strTDEDMonth = TDEDArray[0].ToString();
                                    if ((strTDEDMonth == "1") || (strTDEDMonth == "2") || (strTDEDMonth == "3") || (strTDEDMonth == "4") || (strTDEDMonth == "5") || (strTDEDMonth == "6") || (strTDEDMonth == "7") || (strTDEDMonth == "8") || (strTDEDMonth == "9"))
                                    {
                                        strTDEDMonth = "0" + strTDEDMonth;
                                    }
                                    else

                                        strTDEDYear = TDEDArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strTDEDComplete = "'" + strTDEDMonth + "/" + strTDEDDay + "/" + strTDEDYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strTDEDComplete = "to_date('" + strTDEDMonth + "/" + strTDEDDay + "/" + strTDEDYear + "','MM/DD/YYYY')";
                                    }
                                }
                                if (combo_DateFormat.Text.Equals("International"))
                                {
                                    strTDSDDay = TDSDArray[0].ToString();
                                    if ((strTDSDDay == "1") || (strTDSDDay == "2") || (strTDSDDay == "3") || (strTDSDDay == "4") || (strTDSDDay == "5") || (strTDSDDay == "6") || (strTDSDDay == "7") || (strTDSDDay == "8") || (strTDSDDay == "9"))
                                    {
                                        strTDSDDay = "0" + strTDSDDay;
                                    }
                                    else

                                        strTDSDMonth = TDSDArray[1].ToString();
                                    if ((strTDSDMonth == "1") || (strTDSDMonth == "2") || (strTDSDMonth == "3") || (strTDSDMonth == "4") || (strTDSDMonth == "5") || (strTDSDMonth == "6") || (strTDSDMonth == "7") || (strTDSDMonth == "8") || (strTDSDMonth == "9"))
                                    {
                                        strTDSDMonth = "0" + strTDSDMonth;
                                    }

                                    strTDSDYear = TDSDArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strTDSDComplete = "'" + strTDSDDay + "/" + strTDSDMonth + "/" + strTDSDYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strTDSDComplete = "to_date('" + strTDSDDay + "/" + strTDSDMonth + "/" + strTDSDYear + "','DD/MM/YYYY')";
                                    }

                                    strTDEDDay = TDEDArray[0].ToString();
                                    if ((strTDEDDay == "1") || (strTDEDDay == "2") || (strTDEDDay == "3") || (strTDEDDay == "4") || (strTDEDDay == "5") || (strTDEDDay == "6") || (strTDEDDay == "7") || (strTDEDDay == "8") || (strTDEDDay == "9"))
                                    {
                                        strTDEDDay = "0" + strTDEDDay;
                                    }

                                    strTDEDMonth = TDEDArray[1].ToString();
                                    if ((strTDEDMonth == "1") || (strTDEDMonth == "2") || (strTDEDMonth == "3") || (strTDEDMonth == "4") || (strTDEDMonth == "5") || (strTDEDMonth == "6") || (strTDEDMonth == "7") || (strTDEDMonth == "8") || (strTDEDMonth == "9"))
                                    {
                                        strTDEDMonth = "0" + strTDEDMonth;
                                    }

                                    strTDEDYear = TDEDArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strTDEDComplete = "'" + strTDEDDay + "/" + strTDEDMonth + "/" + strTDEDYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strTDEDComplete = "to_date('" + strTDEDDay + "/" + strTDEDMonth + "/" + strTDEDYear + "','DD/MM/YYYY')";
                                    }
                                }

                                if (combo_DBType.Text.Equals("SQL"))
                                {
                                    strTermsSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.RMGT_T_TERM_DATES (PK_TERM_ID,TERM_DATES_NAME,TERM_DATES_START_DATE,TERM_DATES_END_DATE,TERM_DATES_NOMINATED,PERCENTAGE_TO_BILL,TERM_DATES_UPLOAD,STATUS,ROOM_TERM,PLAN_TERM,BILLING_TERM,PROPERTY_TERM,PAYMENT_TERM) VALUES ('" + row["PK_TERM_ID"] + "','" + row["TERM_DATES_NAME"] + "'," + strTDSDComplete + "," + strTDEDComplete + "," + strTDN + "," + percentage2Bill + "," + strTDU + "," + strStatus + "," + strRoomTerm + "," + strPlanTerm + "," + strBillingTerm + "," + strPropertyTerm + "," + strPaymentTerm + ");\r\n");
                                    strTermsSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.acct_t_Billing_Type (pk_Billing_Type,Billing_Type_Description,Accom,Pln,Facility,Equip,Menu,Snack,Misc) VALUES ('" + row["PK_TERM_ID"] + "','" + row["TERM_DATES_NAME"] + "',1,1,0,0,0,0,0);\r\n");
                                }
                                else if (combo_DBType.Text.Equals("Oracle"))
                                {
                                    strTermsSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".RMGT_T_TERM_DATES (PK_TERM_ID,TERM_DATES_NAME,TERM_DATES_START_DATE,TERM_DATES_END_DATE,TERM_DATES_NOMINATED,PERCENTAGE_TO_BILL,TERM_DATES_UPLOAD,STATUS,ROOM_TERM,PLAN_TERM,BILLING_TERM,PROPERTY_TERM,PAYMENT_TERM) VALUES ('" + row["PK_TERM_ID"] + "','" + row["TERM_DATES_NAME"].ToString().Replace("'", "''") + "'," + strTDSDComplete + "," + strTDEDComplete + "," + strTDN + "," + percentage2Bill + "," + strTDU + "," + strStatus + "," + strRoomTerm + "," + strPlanTerm + "," + strBillingTerm + "," + strPropertyTerm + "," + strPaymentTerm + ");\r\nCommit;\r\n");
                                    strTermsSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.acct_t_Billing_Type (pk_Billing_Type,Billing_Type_Description,Accom,Pln,Facility,Equip,Menu,Snack,Misc) VALUES ('" + row["PK_TERM_ID"] + "','" + row["TERM_DATES_NAME"].ToString().Replace("'", "''") + "',1,1,0,0,0,0,0);\r\n");
                                }
                            }
                        }
                        File.WriteAllText(TermsSQLPath, strTermsSQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ///
                ///Rates SQL Scripts
                ///
                try
                {
                    string RatesSQLPath = txt_SQLLoc.Text + "\\Accounts\\5.Rates.sql";
                    int RatesRows = dsRates.Rows.Count;
                    if (RatesRows > 0)
                    {
                        foreach (DataRow row in dsRates.Rows)
                        {
                            string strRSDDay = "";
                            string strRSDMonth = "";
                            string strRSDYear = "";
                            string strRSDComplete = "";
                            string strREDDay = "";
                            string strREDMonth = "";
                            string strREDYear = "";
                            string strREDComplete = "";
                            string[] RSDArray = new string[3];
                            string[] REDArray = new string[3];
                            int createSQL = 1;
                            if (row["RATE_START_DATE"].ToString() != "")
                            {
                                RSDArray = row["RATE_START_DATE"].ToString().Split('/');
                            }
                            else
                            {
                                createSQL = 0;
                            }
                            if (row["RATE_END_DATE"].ToString() != "")
                            {
                                REDArray = row["RATE_END_DATE"].ToString().Split('/');
                            }
                            else
                            {
                                createSQL = 0;
                            }
                            if (createSQL == 1)
                            {
                                if (combo_DateFormat.Text.Equals("American"))
                                {
                                    strRSDDay = RSDArray[1].ToString();
                                    if ((strRSDDay == "1") || (strRSDDay == "2") || (strRSDDay == "3") || (strRSDDay == "4") || (strRSDDay == "5") || (strRSDDay == "6") || (strRSDDay == "7") || (strRSDDay == "8") || (strRSDDay == "9"))
                                    {
                                        strRSDDay = "0" + strRSDDay;
                                    }

                                    strRSDMonth = RSDArray[0].ToString();
                                    if ((strRSDMonth == "1") || (strRSDMonth == "2") || (strRSDMonth == "3") || (strRSDMonth == "4") || (strRSDMonth == "5") || (strRSDMonth == "6") || (strRSDMonth == "7") || (strRSDMonth == "8") || (strRSDMonth == "9"))
                                    {
                                        strRSDMonth = "0" + strRSDMonth;
                                    }

                                    strRSDYear = RSDArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strRSDComplete = "'" + strRSDMonth + "/" + strRSDDay + "/" + strRSDYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strRSDComplete = "to_date('" + strRSDMonth + "/" + strRSDDay + "/" + strRSDYear + "','MM/DD/YYYY')";
                                    }
                                    strREDDay = REDArray[1].ToString();
                                    if ((strREDDay == "1") || (strREDDay == "2") || (strREDDay == "3") || (strREDDay == "4") || (strREDDay == "5") || (strREDDay == "6") || (strREDDay == "7") || (strREDDay == "8") || (strREDDay == "9"))
                                    {
                                        strREDDay = "0" + strREDDay;
                                    }

                                    strREDMonth = REDArray[0].ToString();
                                    if ((strREDMonth == "1") || (strREDMonth == "2") || (strREDMonth == "3") || (strREDMonth == "4") || (strREDMonth == "5") || (strREDMonth == "6") || (strREDMonth == "7") || (strREDMonth == "8") || (strREDMonth == "9"))
                                    {
                                        strREDMonth = "0" + strREDMonth;
                                    }

                                    strREDYear = REDArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strREDComplete = "'" + strREDMonth + "/" + strREDDay + "/" + strREDYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strREDComplete = "to_date('" + strREDMonth + "/" + strREDDay + "/" + strREDYear + "','MM/DD/YYYY')";
                                    }
                                }
                                if (combo_DateFormat.Text.Equals("International"))
                                {
                                    strRSDDay = RSDArray[0].ToString();
                                    if ((strRSDDay == "1") || (strRSDDay == "2") || (strRSDDay == "3") || (strRSDDay == "4") || (strRSDDay == "5") || (strRSDDay == "6") || (strRSDDay == "7") || (strRSDDay == "8") || (strRSDDay == "9"))
                                    {
                                        strRSDDay = "0" + strRSDDay;
                                    }

                                    strRSDMonth = RSDArray[1].ToString();
                                    if ((strRSDMonth == "1") || (strRSDMonth == "2") || (strRSDMonth == "3") || (strRSDMonth == "4") || (strRSDMonth == "5") || (strRSDMonth == "6") || (strRSDMonth == "7") || (strRSDMonth == "8") || (strRSDMonth == "9"))
                                    {
                                        strRSDMonth = "0" + strRSDMonth;
                                    }

                                    strRSDYear = RSDArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strRSDComplete = "'" + strRSDDay + "/" + strRSDMonth + "/" + strRSDYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strRSDComplete = "to_date('" + strRSDDay + "/" + strRSDMonth + "/" + strRSDYear + "','DD/MM/YYYY')";
                                    }

                                    strREDDay = REDArray[0].ToString();
                                    if ((strREDDay == "1") || (strREDDay == "2") || (strREDDay == "3") || (strREDDay == "4") || (strREDDay == "5") || (strREDDay == "6") || (strREDDay == "7") || (strREDDay == "8") || (strREDDay == "9"))
                                    {
                                        strREDDay = "0" + strREDDay;
                                    }

                                    strREDMonth = REDArray[1].ToString();
                                    if ((strREDMonth == "1") || (strREDMonth == "2") || (strREDMonth == "3") || (strREDMonth == "4") || (strREDMonth == "5") || (strREDMonth == "6") || (strREDMonth == "7") || (strREDMonth == "8") || (strREDMonth == "9"))
                                    {
                                        strREDMonth = "0" + strREDMonth;
                                    }

                                    strREDYear = REDArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strREDComplete = "'" + strREDDay + "/" + strREDMonth + "/" + strREDYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strREDComplete = "to_date('" + strREDDay + "/" + strREDMonth + "/" + strREDYear + "','DD/MM/YYYY')";
                                    }
                                }
                                if (combo_DBType.Text.Equals("SQL"))
                                {
                                    strRatesSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.RMGT_T_RATES (CK_RATE_CODE,CK_RATE_CONFIG_NO,FK_BILLING_TYPE,RATES_DESCRIPTION,RATES_TYPE,RATE_START_DATE,RATE_END_DATE,RATE_CONFIG_DESCRIPTION,RATES_SERVICE_TIME,RATES_SERVICE_TYPE,RATES_LINEN_TIME,RATES_LINEN_TYPE) VALUES ('" + row["CK_RATE_CODE"] + "','" + row["CK_RATE_CONFIG_NO"] + "','" + row["FK_BILLING_TYPE"] + "','" + row["RATES_DESCRIPTION"].ToString().Replace("'", "''") + "','" + row["RATES_TYPE"] + "'," + strRSDComplete + "," + strREDComplete + ",'" + row["RATE_CONFIG_DESCRIPTION"].ToString().Replace("'", "''") + "','" + row["RATES_SERVICE_TIME"] + "','" + row["RATES_SERVICE_TYPE"] + "','" + row["RATES_LINEN_TIME"] + "','" + row["RATES_LINEN_TYPE"] + "');\r\n");

                                }
                                else if (combo_DBType.Text.Equals("Oracle"))
                                {
                                    strRatesSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".RMGT_T_RATES (CK_RATE_CODE,CK_RATE_CONFIG_NO,FK_BILLING_TYPE,RATES_DESCRIPTION,RATES_TYPE,RATE_START_DATE,RATE_END_DATE,RATE_CONFIG_DESCRIPTION,RATES_SERVICE_TIME,RATES_SERVICE_TYPE,RATES_LINEN_TIME,RATES_LINEN_TYPE) VALUES ('" + row["CK_RATE_CODE"] + "','" + row["CK_RATE_CONFIG_NO"] + "','" + row["FK_BILLING_TYPE"] + "','" + row["RATES_DESCRIPTION"].ToString().Replace("'", "''") + "','" + row["RATES_TYPE"] + "'," + strRSDComplete + "," + strREDComplete + ",'" + row["RATE_CONFIG_DESCRIPTION"].ToString().Replace("'", "''") + "','" + row["RATES_SERVICE_TIME"] + "','" + row["RATES_SERVICE_TYPE"] + "','" + row["RATES_LINEN_TIME"] + "','" + row["RATES_LINEN_TYPE"] + "');\r\nCommit;\r\n");
                                }
                            }
                        }
                        File.WriteAllText(RatesSQLPath, strRatesSQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ///
                ///Rate Splits SQL Scripts
                ///
                try
                {
                    string RateSplitsSQLPath = txt_SQLLoc.Text + "\\Accounts\\6.RateSplits.sql";
                    int RateSplitsRows = dsRateSplits.Rows.Count;
                    if (RateSplitsRows > 0)
                    {
                        foreach (DataRow row in dsRateSplits.Rows)
                        {
                            if (combo_DBType.Text.Equals("SQL"))
                            {
                                strRateSplitsSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.RMGT_T_RATES_SPLIT (CK_RATE_CODE,CK_RATE_CONFIG_NO,CK_TXTYPE,RATES_SPLIT_AMOUNT) VALUES ('" + row["CK_RATE_CODE"] + "','" + row["CK_RATE_CONFIG_NO"] + "','" + row["CK_TXTYPE"] + "','" + row["RATES_SPLIT_AMOUNT"] + "');\r\n");

                            }
                            else if (combo_DBType.Text.Equals("Oracle"))
                            {
                                strRateSplitsSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".RMGT_T_RATES_SPLIT (CK_RATE_CODE,CK_RATE_CONFIG_NO,CK_TXTYPE,RATES_SPLIT_AMOUNT) VALUES ('" + row["CK_RATE_CODE"] + "','" + row["CK_RATE_CONFIG_NO"] + "','" + row["CK_TXTYPE"] + "','" + row["RATES_SPLIT_AMOUNT"] + "');\r\nCommit;\r\n");
                            }
                        }
                        File.WriteAllText(RateSplitsSQLPath, strRateSplitsSQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ///
                ///Room Types Rates SQL Scripts
                ///
                try
                {
                    string RmTypesRatesSQLPath = txt_SQLLoc.Text + "\\Accounts\\7.RmTypesRates.sql";
                    int RmTypesRatesRows = dsRmTypesRates.Rows.Count;
                    if (RmTypesRatesRows > 0)
                    {
                        foreach (DataRow row in dsRmTypesRates.Rows)
                        {
                            string strStatus = row["STATUS"].ToString();
                            if (strStatus == "0")
                            {
                                strStatus = "0";
                            }
                            else
                            {
                                strStatus = "1";
                            }
                            if (combo_DBType.Text.Equals("SQL"))
                            {
                                strRmTypesRatesSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.RMGT_T_ROOM_TYPE (PK_ROOM_TYPE,ROOM_TYPE_ALIAS_NAME,FK_RATE_CODE,ROOM_TYPE_DESCRIPTION,TURN_AROUND_TIME,TURN_AROUND_TYPE,STATUS,UD_HYPERLINK1) VALUES ('" + row["PK_ROOM_TYPE"] + "','" + row["ROOM_TYPE_ALIAS_NAME"] + "','" + row["FK_RATE_CODE"] + "','" + row["ROOM_TYPE_DESCRIPTION"].ToString().Replace("'", "''") + "','" + row["TURN_AROUND_TIME"] + "','" + row["TURN_AROUND_TYPE"] + "'," + strStatus + ",'" + row["UD_HYPERLINK"] + "');\r\n");

                            }
                            else if (combo_DBType.Text.Equals("Oracle"))
                            {
                                strRmTypesRatesSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".RMGT_T_ROOM_TYPE (PK_ROOM_TYPE,ROOM_TYPE_ALIAS_NAME,FK_RATE_CODE,ROOM_TYPE_DESCRIPTION,TURN_AROUND_TIME,TURN_AROUND_TYPE,STATUS,UD_HYPERLINK1) VALUES ('" + row["PK_ROOM_TYPE"] + "','" + row["ROOM_TYPE_ALIAS_NAME"] + "','" + row["FK_RATE_CODE"] + "','" + row["ROOM_TYPE_DESCRIPTION"].ToString().Replace("'", "''") + "','" + row["TURN_AROUND_TIME"] + "','" + row["TURN_AROUND_TYPE"] + "'," + strStatus + ",'" + row["UD_HYPERLINK"] + "');\r\nCommit;\r\n");
                            }
                        }
                        File.WriteAllText(RmTypesRatesSQLPath, strRmTypesRatesSQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ///
                ///Plan Types Rates SQL Scripts
                ///
                try
                {
                    string PlanTypesRatesSQLPath = txt_SQLLoc.Text + "\\Accounts\\8.PlanTypesRates.sql";
                    int PlanTypesRatesRows = dsPlanTypesRates.Rows.Count;
                    if (PlanTypesRatesRows > 0)
                    {
                        foreach (DataRow row in dsPlanTypesRates.Rows)
                        {
                            string strStatus = row["STATUS"].ToString();
                            if (strStatus == "0")
                            {
                                strStatus = "0";
                            }
                            else
                            {
                                strStatus = "1";
                            }
                            string strMPSDay = "";
                            string strMPSMonth = "";
                            string strMPSYear = "";
                            string strMPSComplete = "";
                            string strMPEDay = "";
                            string strMPEMonth = "";
                            string strMPEYear = "";
                            string strMPEComplete = "";
                            string[] MPSArray = new string[3];
                            string[] MPEArray = new string[3];
                            int formatDates = 1;
                            if (row["MP_START"].ToString() != "")
                            {
                                MPSArray = row["MP_START"].ToString().Split('/');
                            }
                            else
                            {
                                strMPSComplete = "null";
                                formatDates = 0;
                            }
                            if (row["MP_END"].ToString() != "")
                            {
                                MPEArray = row["MP_END"].ToString().Split('/');
                            }
                            else
                            {
                                strMPEComplete = "null";
                                formatDates = 0;
                            }
                            if (formatDates == 1)
                            {
                                if (combo_DateFormat.Text.Equals("American"))
                                {
                                    strMPSDay = MPSArray[1].ToString();
                                    if ((strMPSDay == "1") || (strMPSDay == "2") || (strMPSDay == "3") || (strMPSDay == "4") || (strMPSDay == "5") || (strMPSDay == "6") || (strMPSDay == "7") || (strMPSDay == "8") || (strMPSDay == "9"))
                                    {
                                        strMPSDay = "0" + strMPSDay;
                                    }

                                    strMPSMonth = MPSArray[0].ToString();
                                    if ((strMPSMonth == "1") || (strMPSMonth == "2") || (strMPSMonth == "3") || (strMPSMonth == "4") || (strMPSMonth == "5") || (strMPSMonth == "6") || (strMPSMonth == "7") || (strMPSMonth == "8") || (strMPSMonth == "9"))
                                    {
                                        strMPSMonth = "0" + strMPSMonth;
                                    }

                                    strMPSYear = MPSArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strMPSComplete = "'" + strMPSMonth + "/" + strMPSDay + "/" + strMPSYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strMPSComplete = "to_date('" + strMPSMonth + "/" + strMPSDay + "/" + strMPSYear + "','MM/DD/YYYY')";
                                    }
                                    strMPEDay = MPEArray[1].ToString();
                                    if ((strMPEDay == "1") || (strMPEDay == "2") || (strMPEDay == "3") || (strMPEDay == "4") || (strMPEDay == "5") || (strMPEDay == "6") || (strMPEDay == "7") || (strMPEDay == "8") || (strMPEDay == "9"))
                                    {
                                        strMPEDay = "0" + strMPEDay;
                                    }

                                    strMPEMonth = MPEArray[0].ToString();
                                    if ((strMPEMonth == "1") || (strMPEMonth == "2") || (strMPEMonth == "3") || (strMPEMonth == "4") || (strMPEMonth == "5") || (strMPEMonth == "6") || (strMPEMonth == "7") || (strMPEMonth == "8") || (strMPEMonth == "9"))
                                    {
                                        strMPEMonth = "0" + strMPEMonth;
                                    }

                                    strMPEYear = MPEArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strMPEComplete = "'" + strMPEMonth + "/" + strMPEDay + "/" + strMPEYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strMPEComplete = "to_date('" + strMPEMonth + "/" + strMPEDay + "/" + strMPEYear + "','MM/DD/YYYY')";
                                    }
                                }
                                if (combo_DateFormat.Text.Equals("International"))
                                {
                                    strMPSDay = MPSArray[0].ToString();
                                    if ((strMPSDay == "1") || (strMPSDay == "2") || (strMPSDay == "3") || (strMPSDay == "4") || (strMPSDay == "5") || (strMPSDay == "6") || (strMPSDay == "7") || (strMPSDay == "8") || (strMPSDay == "9"))
                                    {
                                        strMPSDay = "0" + strMPSDay;
                                    }

                                    strMPSMonth = MPSArray[1].ToString();
                                    if ((strMPSMonth == "1") || (strMPSMonth == "2") || (strMPSMonth == "3") || (strMPSMonth == "4") || (strMPSMonth == "5") || (strMPSMonth == "6") || (strMPSMonth == "7") || (strMPSMonth == "8") || (strMPSMonth == "9"))
                                    {
                                        strMPSMonth = "0" + strMPSMonth;
                                    }

                                    strMPSYear = MPSArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strMPSComplete = "'" + strMPSDay + "/" + strMPSMonth + "/" + strMPSYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strMPSComplete = "to_date('" + strMPSDay + "/" + strMPSMonth + "/" + strMPSYear + "','DD/MM/YYYY')";
                                    }

                                    strMPEDay = MPEArray[0].ToString();
                                    if ((strMPEDay == "1") || (strMPEDay == "2") || (strMPEDay == "3") || (strMPEDay == "4") || (strMPEDay == "5") || (strMPEDay == "6") || (strMPEDay == "7") || (strMPEDay == "8") || (strMPEDay == "9"))
                                    {
                                        strMPEDay = "0" + strMPEDay;
                                    }

                                    strMPEMonth = MPEArray[1].ToString();
                                    if ((strMPEMonth == "1") || (strMPEMonth == "2") || (strMPEMonth == "3") || (strMPEMonth == "4") || (strMPEMonth == "5") || (strMPEMonth == "6") || (strMPEMonth == "7") || (strMPEMonth == "8") || (strMPEMonth == "9"))
                                    {
                                        strMPEMonth = "0" + strMPEMonth;
                                    }

                                    strMPEYear = MPEArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strMPEComplete = "'" + strMPEDay + "/" + strMPEMonth + "/" + strMPEYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strMPEComplete = "to_date('" + strMPEDay + "/" + strMPEMonth + "/" + strMPEYear + "','DD/MM/YYYY')";
                                    }
                                }
                            }
                            if (combo_DBType.Text.Equals("SQL"))
                            {
                                strPlanTypesRatesSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.RMGT_T_PLAN_TYPE (PK_PLAN_TYPE,FK_RATE_CODE,PLAN_TYPE_DESCRIPTION,PLAN_TYPE_TYPE,MP_START,MP_END,STATUS) VALUES ('" + row["PK_PLAN_TYPE"] + "','" + row["FK_RATE_CODE"] + "','" + row["PLAN_TYPE_DESCRIPTION"].ToString().Replace("'", "''") + "','" + row["PLAN_TYPE_TYPE"] + "'," + strMPSComplete + "," + strMPEComplete + "," + strStatus + ");\r\n");

                            }
                            else if (combo_DBType.Text.Equals("Oracle"))
                            {
                                strPlanTypesRatesSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".RMGT_T_PLAN_TYPE (PK_PLAN_TYPE,FK_RATE_CODE,PLAN_TYPE_DESCRIPTION,PLAN_TYPE_TYPE,MP_START,MP_END,STATUS) VALUES ('" + row["PK_PLAN_TYPE"] + "','" + row["FK_RATE_CODE"] + "','" + row["PLAN_TYPE_DESCRIPTION"].ToString().Replace("'", "''") + "','" + row["PLAN_TYPE_TYPE"] + "'," + strMPSComplete + "," + strMPEComplete + "," + strStatus + ");\r\nCommit;\r\n");
                            }
                        }
                        File.WriteAllText(PlanTypesRatesSQLPath, strPlanTypesRatesSQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ///
                ///Payment Categories SQL Scripts
                ///
                try
                {
                    string PayCategoriesSQLPath = txt_SQLLoc.Text + "\\Accounts\\9.PayCategories.sql";
                    int PayCategoriesRows = dsPayCategories.Rows.Count;
                    if (PayCategoriesRows > 0)
                    {
                        foreach (DataRow row in dsPayCategories.Rows)
                        {
                            string strStatus = row["STATUS"].ToString();
                            if (strStatus == "0")
                            {
                                strStatus = "0";
                            }
                            else
                            {
                                strStatus = "1";
                            }
                            if (combo_DBType.Text.Equals("SQL"))
                            {
                                strPayCategoriesSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.ACCOUNT_T_METHOD_OF_PAYMENT (PK_METHOD_CODE,METHOD_DESCRIPTION,STATUS) VALUES ('" + row["PK_METHOD_CODE"] + "','" + row["METHOD_DESCRIPTION"].ToString().Replace("'", "''") + "'," + strStatus + ");\r\n");

                            }
                            else if (combo_DBType.Text.Equals("Oracle"))
                            {
                                strPayCategoriesSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".ACCOUNT_T_METHOD_OF_PAYMENT (PK_METHOD_CODE,METHOD_DESCRIPTION,STATUS) VALUES ('" + row["PK_METHOD_CODE"] + "','" + row["METHOD_DESCRIPTION"].ToString().Replace("'", "''") + "'," + strStatus + ");\r\nCommit;\r\n");
                            }
                        }
                        File.WriteAllText(PayCategoriesSQLPath, strPayCategoriesSQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ///
                ///Community SQL Scripts
                ///
                try
                {
                    string CommunitySQLPath = txt_SQLLoc.Text + "\\Rooms\\1.Community.sql";
                    int CommunityRows = dsCommunity.Rows.Count;
                    if (CommunityRows > 0)
                    {
                        foreach (DataRow row in dsCommunity.Rows)
                        {
                            string strStatus = row["STATUS"].ToString();
                            if (strStatus == "0")
                            {
                                strStatus = "0";
                            }
                            else
                            {
                                strStatus = "1";
                            }
                            if (combo_DBType.Text.Equals("SQL"))
                            {
                                strCommunitySQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.RMGT_T_COMMUNITY (PK_COMMUNITY,STATUS) VALUES ('" + row["COMMUNITY"] + "'," + strStatus + ");\r\n");

                            }
                            else if (combo_DBType.Text.Equals("Oracle"))
                            {
                                strCommunitySQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".RMGT_T_COMMUNITY (PK_COMMUNITY,STATUS) VALUES ('" + row["COMMUNITY"] + "'," + strStatus + ");\r\nCommit;\r\n");
                            }
                        }
                        File.WriteAllText(CommunitySQLPath, strCommunitySQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ///
                ///Buildings SQL Scripts
                ///
                try
                {
                    string BuildingsSQLPath = txt_SQLLoc.Text + "\\Rooms\\2.Buildings.sql";
                    int BuildingsRows = dsBuildings.Rows.Count;
                    if (BuildingsRows > 0)
                    {
                        foreach (DataRow row in dsBuildings.Rows)
                        {
                            string strStatus = row["STATUS"].ToString();
                            if (strStatus == "0")
                            {
                                strStatus = "0";
                            }
                            else
                            {
                                strStatus = "1";
                            }
                            if (combo_DBType.Text.Equals("SQL"))
                            {
                                strBuildingsSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.RMGT_T_BUILDINGS (PK_BUILDING_ID,FK_COMMUNITY,BUILDINGS_NAME,BUILDINGS_ADDRESS_1,BUILDINGS_ADDRESS_1B,BUILDINGS_ADDRESS_2,BUILDINGS_POSTCODE,BUILDINGS_STATE,STATUS,UD_HYPERLINK1,UD_HYPERLINK2,UD_HYPERLINK3,UD_HYPERLINK4,UD_HYPERLINK5,UD_HYPERLINK6,UD_HYPERLINK7,LOCKING_SYSTEM_BUILDINGID) VALUES ('" + row["BUILDINGID"] + "','" + row["COMMUNITY"] + "','" + row["NAME"].ToString().Replace("'", "''") + "','" + row["ADDRESS1"] + "','" + row["ADDRESS1B"] + "','" + row["ADDRESS2"] + "','" + row["POSTCODE"] + "','" + row["STATE"] + "'," + strStatus + ",'" + row["HYPERLINK1"] + "','" + row["HYPERLINK2"] + "','" + row["HYPERLINK3"] + "','" + row["HYPERLINK4"] + "','" + row["HYPERLINK5"] + "','" + row["HYPERLINK6"] + "','" + row["HYPERLINK7"] + "','" + row["LOCKINGSYSTEMBUILDINGID"] + "');\r\n");

                            }
                            else if (combo_DBType.Text.Equals("Oracle"))
                            {
                                strBuildingsSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".RMGT_T_BUILDINGS (PK_BUILDING_ID,FK_COMMUNITY,BUILDINGS_NAME,BUILDINGS_ADDRESS_1,BUILDINGS_ADDRESS_1B,BUILDINGS_ADDRESS_2,BUILDINGS_POSTCODE,BUILDINGS_STATE,STATUS,UD_HYPERLINK1,UD_HYPERLINK2,UD_HYPERLINK3,UD_HYPERLINK4,UD_HYPERLINK5,UD_HYPERLINK6,UD_HYPERLINK7,LOCKING_SYSTEM_BUILDINGID) VALUES ('" + row["BUILDINGID"] + "','" + row["COMMUNITY"] + "','" + row["NAME"].ToString().Replace("'", "''") + "','" + row["ADDRESS1"] + "','" + row["ADDRESS1B"] + "','" + row["ADDRESS2"] + "','" + row["POSTCODE"] + "','" + row["STATE"] + "'," + strStatus + ",'" + row["HYPERLINK1"] + "','" + row["HYPERLINK2"] + "','" + row["HYPERLINK3"] + "','" + row["HYPERLINK4"] + "','" + row["HYPERLINK5"] + "','" + row["HYPERLINK6"] + "','" + row["HYPERLINK7"] + "','" + row["LOCKINGSYSTEMBUILDINGID"] + "');\r\nCommit;\r\n");
                            }
                        }
                        File.WriteAllText(BuildingsSQLPath, strBuildingsSQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ///
                ///Floors SQL Scripts
                ///
                try
                {
                    string FloorsSQLPath = txt_SQLLoc.Text + "\\Rooms\\3.Floors.sql";
                    int FloorsRows = dsFloors.Rows.Count;
                    if (FloorsRows > 0)
                    {
                        foreach (DataRow row in dsFloors.Rows)
                        {
                            string strStatus = row["STATUS"].ToString();
                            if (strStatus == "0")
                            {
                                strStatus = "0";
                            }
                            else
                            {
                                strStatus = "1";
                            }
                            if (combo_DBType.Text.Equals("SQL"))
                            {
                                strFloorsSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.RMGT_T_Floors (PK_FLOOR_ID,FK_BUILDING_ID,FLOORS_NAME,STATUS) VALUES ('" + row["FLOORID"] + "','" + row["BUILDINGID"] + "','" + row["FLOORNAME"].ToString().Replace("'", "''") + "'," + strStatus + ");\r\n");

                            }
                            else if (combo_DBType.Text.Equals("Oracle"))
                            {
                                strFloorsSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".RMGT_T_Floors (PK_FLOOR_ID,FK_BUILDING_ID,FLOORS_NAME,STATUS) VALUES ('" + row["FLOORID"] + "','" + row["BUILDINGID"] + "','" + row["FLOORNAME"].ToString().Replace("'", "''") + "'," + strStatus + ");\r\nCommit;\r\n");
                            }
                        }
                        File.WriteAllText(FloorsSQLPath, strFloorsSQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ///
                ///Floor Sections SQL Scripts
                ///
                try
                {
                    string FloorSectionsSQLPath = txt_SQLLoc.Text + "\\Rooms\\4.FloorSections.sql";
                    int FloorSectionsRows = dsFloorSections.Rows.Count;
                    if (FloorSectionsRows > 0)
                    {
                        foreach (DataRow row in dsFloorSections.Rows)
                        {
                            string strStatus = row["STATUS"].ToString();
                            if (strStatus == "0")
                            {
                                strStatus = "0";
                            }
                            else
                            {
                                strStatus = "1";
                            } if (combo_DBType.Text.Equals("SQL"))
                            {
                                strFloorSectionsSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.RMGT_T_FLOOR_SECTIONS (PK_SECTION_ID,FK_FLOOR_ID,FLOOR_SECTIONS_NAME,STATUS) VALUES ('" + row["SECTIONID"] + "','" + row["FLOORID"] + "','" + row["FLOORSECTIONNAME"].ToString().Replace("'", "''") + "'," + strStatus + ");\r\n");

                            }
                            else if (combo_DBType.Text.Equals("Oracle"))
                            {
                                strFloorSectionsSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".RMGT_T_FLOOR_SECTIONS (PK_SECTION_ID,FK_FLOOR_ID,FLOOR_SECTIONS_NAME,STATUS) VALUES ('" + row["SECTIONID"] + "','" + row["FLOORID"] + "','" + row["FLOORSECTIONNAME"].ToString().Replace("'", "''") + "'," + strStatus + ");\r\nCommit;\r\n");
                            }
                        }
                        File.WriteAllText(FloorSectionsSQLPath, strFloorSectionsSQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ///
                ///Rooms SQL Scripts
                ///
                try
                {
                    string RoomsSQLPath = txt_SQLLoc.Text + "\\Rooms\\5.Rooms.sql";
                    int RoomsRows = dsRooms.Rows.Count;
                    if (RoomsRows > 0)
                    {
                        foreach (DataRow row in dsRooms.Rows)
                        {
                            string strStatus = row["STATUS"].ToString();
                            if (strStatus == "0")
                            {
                                strStatus = "0";
                            }
                            else
                            {
                                strStatus = "1";
                            }
                            string strDirty = row["DIRTY"].ToString();
                            if (strDirty == "0")
                            {
                                strDirty = "0";
                            }
                            else
                            {
                                strDirty = "1";
                            }
                            string strServicedDay = "";
                            string strServicedMonth = "";
                            string strServicedYear = "";
                            string strServicedComplete = "";
                            string strLinenDay = "";
                            string strLinenMonth = "";
                            string strLinenYear = "";
                            string strLinenComplete = "";
                            string[] ServicedArray = new string[3];
                            string[] LinenArray = new string[3];
                            int formatDates = 1;
                            if (row["SERVICED"].ToString() != "")
                            {
                                ServicedArray = row["SERVICED"].ToString().Split('/');
                            }
                            else
                            {
                                strServicedComplete = "null";
                                formatDates = 0;
                            }
                            if (row["LINEN"].ToString() != "")
                            {
                                LinenArray = row["LINEN"].ToString().Split('/');
                            }
                            else
                            {
                                strLinenComplete = "null";
                                formatDates = 0;
                            }
                            if (formatDates == 1)
                            {
                                if (combo_DateFormat.Text.Equals("American"))
                                {
                                    strServicedDay = ServicedArray[1].ToString();
                                    if ((strServicedDay == "1") || (strServicedDay == "2") || (strServicedDay == "3") || (strServicedDay == "4") || (strServicedDay == "5") || (strServicedDay == "6") || (strServicedDay == "7") || (strServicedDay == "8") || (strServicedDay == "9"))
                                    {
                                        strServicedDay = "0" + strServicedDay;
                                    }

                                    strServicedMonth = ServicedArray[0].ToString();
                                    if ((strServicedMonth == "1") || (strServicedMonth == "2") || (strServicedMonth == "3") || (strServicedMonth == "4") || (strServicedMonth == "5") || (strServicedMonth == "6") || (strServicedMonth == "7") || (strServicedMonth == "8") || (strServicedMonth == "9"))
                                    {
                                        strServicedMonth = "0" + strServicedMonth;
                                    }

                                    strServicedYear = ServicedArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strServicedComplete = "'" + strServicedMonth + "/" + strServicedDay + "/" + strServicedYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strServicedComplete = "to_date('" + strServicedMonth + "/" + strServicedDay + "/" + strServicedYear + "','MM/DD/YYYY')";
                                    }
                                    strLinenDay = LinenArray[1].ToString();
                                    if ((strLinenDay == "1") || (strLinenDay == "2") || (strLinenDay == "3") || (strLinenDay == "4") || (strLinenDay == "5") || (strLinenDay == "6") || (strLinenDay == "7") || (strLinenDay == "8") || (strLinenDay == "9"))
                                    {
                                        strLinenDay = "0" + strLinenDay;
                                    }

                                    strLinenMonth = LinenArray[0].ToString();
                                    if ((strLinenMonth == "1") || (strLinenMonth == "2") || (strLinenMonth == "3") || (strLinenMonth == "4") || (strLinenMonth == "5") || (strLinenMonth == "6") || (strLinenMonth == "7") || (strLinenMonth == "8") || (strLinenMonth == "9"))
                                    {
                                        strLinenMonth = "0" + strLinenMonth;
                                    }

                                    strLinenYear = LinenArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strLinenComplete = "'" + strLinenMonth + "/" + strLinenDay + "/" + strLinenYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strLinenComplete = "to_date('" + strLinenMonth + "/" + strLinenDay + "/" + strLinenYear + "','MM/DD/YYYY')";
                                    }
                                }
                                if (combo_DateFormat.Text.Equals("International"))
                                {
                                    strServicedDay = ServicedArray[0].ToString();
                                    if ((strServicedDay == "1") || (strServicedDay == "2") || (strServicedDay == "3") || (strServicedDay == "4") || (strServicedDay == "5") || (strServicedDay == "6") || (strServicedDay == "7") || (strServicedDay == "8") || (strServicedDay == "9"))
                                    {
                                        strServicedDay = "0" + strServicedDay;
                                    }

                                    strServicedMonth = ServicedArray[1].ToString();
                                    if ((strServicedMonth == "1") || (strServicedMonth == "2") || (strServicedMonth == "3") || (strServicedMonth == "4") || (strServicedMonth == "5") || (strServicedMonth == "6") || (strServicedMonth == "7") || (strServicedMonth == "8") || (strServicedMonth == "9"))
                                    {
                                        strServicedMonth = "0" + strServicedMonth;
                                    }

                                    strServicedYear = ServicedArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strServicedComplete = "'" + strServicedDay + "/" + strServicedMonth + "/" + strServicedYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strServicedComplete = "to_date('" + strServicedDay + "/" + strServicedMonth + "/" + strServicedYear + "','DD/MM/YYYY')";
                                    }

                                    strLinenDay = LinenArray[0].ToString();
                                    if ((strLinenDay == "1") || (strLinenDay == "2") || (strLinenDay == "3") || (strLinenDay == "4") || (strLinenDay == "5") || (strLinenDay == "6") || (strLinenDay == "7") || (strLinenDay == "8") || (strLinenDay == "9"))
                                    {
                                        strLinenDay = "0" + strLinenDay;
                                    }

                                    strLinenMonth = LinenArray[1].ToString();
                                    if ((strLinenMonth == "1") || (strLinenMonth == "2") || (strLinenMonth == "3") || (strLinenMonth == "4") || (strLinenMonth == "5") || (strLinenMonth == "6") || (strLinenMonth == "7") || (strLinenMonth == "8") || (strLinenMonth == "9"))
                                    {
                                        strLinenMonth = "0" + strLinenMonth;
                                    }

                                    strLinenYear = LinenArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strLinenComplete = "'" + strLinenDay + "/" + strLinenMonth + "/" + strLinenYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strLinenComplete = "to_date('" + strLinenDay + "/" + strLinenMonth + "/" + strLinenYear + "','DD/MM/YYYY')";
                                    }
                                }
                            }
                            if (combo_DBType.Text.Equals("SQL"))
                            {
                                strRoomsSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.RMGT_T_ROOMS (PK_BED_SPACE,FK_ROOM_NO,SECONDARY_BED_SPACE,ROOMS_Dirty,ROOMS_SERVICED,ROOMS_LINEN,STATUS,UD_HYPERLINK1,UD_HYPERLINK2,UD_HYPERLINK3,LOCKING_SYSTEM_ROOMID) VALUES ('" + row["BEDSPACE"] + "','" + row["ROOMNO"] + "','" + row["SECONDARYBEDSPACE"] + "'," + strDirty + "," + strServicedComplete + "," + strLinenComplete + "," + strStatus + ",'" + row["HYPERLINK1"] + "','" + row["HYPERLINK2"] + "','" + row["HYPERLINK3"] + "','" + row["LOCKINGSYSTEMROOMID"] + "');\r\n");
                            }
                            else if (combo_DBType.Text.Equals("Oracle"))
                            {
                                strRoomsSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".RMGT_T_ROOMS (PK_BED_SPACE,FK_ROOM_NO,SECONDARY_BED_SPACE,ROOMS_Dirty,ROOMS_SERVICED,ROOMS_LINEN,STATUS,UD_HYPERLINK1,UD_HYPERLINK2,UD_HYPERLINK3,LOCKING_SYSTEM_ROOMID) VALUES ('" + row["BEDSPACE"] + "','" + row["ROOMNO"] + "','" + row["SECONDARYBEDSPACE"] + "'," + strDirty + "," + strServicedComplete + "," + strLinenComplete + "," + strStatus + ",'" + row["HYPERLINK1"] + "','" + row["HYPERLINK2"] + "','" + row["HYPERLINK3"] + "','" + row["LOCKINGSYSTEMROOMID"] + "');\r\nCommit;\r\n");
                            }
                        }
                        
                        File.WriteAllText(RoomsSQLPath, strRoomsSQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ///
                ///Use 1 SQL Scripts
                ///
                try
                {
                    string Use1SQLPath = txt_SQLLoc.Text + "\\Rooms\\6.Use1.sql";
                    int Use1Rows = dsUse1.Rows.Count;
                    if (Use1Rows > 0)
                    {
                        foreach (DataRow row in dsUse1.Rows)
                        {
                            string strStatus = row["STATUS"].ToString();
                            if (strStatus == "0")
                            {
                                strStatus = "0";
                            }
                            else
                            {
                                strStatus = "1";
                            }
                            if (combo_DBType.Text.Equals("SQL"))
                            {
                                strUse1SQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.L_U_T_RMGT_T_USE_1 (PK_USE_1,DESCRIPTION,STATUS) VALUES ('" + row["USE1"] + "','" + row["DESCRIPTION"].ToString().Replace("'", "''") + "'," + strStatus + ");\r\n");

                            }
                            else if (combo_DBType.Text.Equals("Oracle"))
                            {
                                strUse1SQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".L_U_T_RMGT_T_USE_1 (PK_USE_1,DESCRIPTION,STATUS) VALUES ('" + row["USE1"] + "','" + row["DESCRIPTION"].ToString().Replace("'", "''") + "'," + strStatus + ");\r\nCommit;\r\n");
                            }
                        }
                        File.WriteAllText(Use1SQLPath, strUse1SQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ///
                ///Use 2 SQL Scripts
                ///
                try
                {
                    string Use2SQLPath = txt_SQLLoc.Text + "\\Rooms\\7.Use2.sql";
                    int Use2Rows = dsUse2.Rows.Count;
                    if (Use2Rows > 0)
                    {
                        foreach (DataRow row in dsUse2.Rows)
                        {
                            string strStatus = row["STATUS"].ToString();
                            if (strStatus == "0")
                            {
                                strStatus = "0";
                            }
                            else
                            {
                                strStatus = "1";
                            }
                            if (combo_DBType.Text.Equals("SQL"))
                            {
                                strUse2SQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.L_U_T_RMGT_T_USE_2 (PK_USE_2,DESCRIPTION,STATUS) VALUES ('" + row["USE2"] + "','" + row["DESCRIPTION"].ToString().Replace("'", "''") + "'," + strStatus + ");\r\n");

                            }
                            else if (combo_DBType.Text.Equals("Oracle"))
                            {
                                strUse2SQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".L_U_T_RMGT_T_USE_2 (PK_USE_2,DESCRIPTION,STATUS) VALUES ('" + row["USE2"] + "','" + row["DESCRIPTION"].ToString().Replace("'", "''") + "'," + strStatus + ");\r\nCommit;\r\n");
                            }
                        }
                        File.WriteAllText(Use2SQLPath, strUse2SQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ///
                ///Room Configs SQL Scripts
                ///
                try
                {
                    string RoomConfigsSQLPath = txt_SQLLoc.Text + "\\Rooms\\8.RoomConfigs.sql";
                    int RoomConfigsRows = dsRoomConfigs.Rows.Count;
                    if (RoomConfigsRows > 0)
                    {
                        foreach (DataRow row in dsRoomConfigs.Rows)
                        {
                            string strUse1 = row["USE1"].ToString();
                            if (strUse1 == "")
                            {
                                strUse1 = "NA";
                            }
                            if (strUse1 == null)
                            {
                                strUse1 = "NA";
                            }
                            string strUse2 = row["USE2"].ToString();
                            if (strUse2 == "")
                            {
                                strUse2 = "NA";
                            }
                            if (strUse2 == null)
                            {
                                strUse2 = "NA";
                            }
                            string strGender = row["GENDER"].ToString();
                            if (strGender == "F")
                            {
                                strGender = "F";
                            }
                            else if (strGender == "M")
                            {
                                strGender = "M";
                            }
                            else
                            {
                                strGender = "U";
                            }
                            string strStatus = row["STATUS"].ToString();
                            if (strStatus == "0")
                            {
                                strStatus = "0";
                            }
                            else
                            {
                                strStatus = "1";
                            }
                            string strOM = row["OPERATINGMODE"].ToString();
                            if (strOM == "R")
                            {
                                strOM = "R";
                            }
                            else
                            {
                                strOM = "F";
                            }
                            string strDesire = row["DESIRABILITY"].ToString();
                            if ((strDesire == "0") || (strDesire == ""))
                            {
                                strDesire = "0";
                            }

                            string strRSDDay = "";
                            string strRSDMonth = "";
                            string strRSDYear = "";
                            string strRSDComplete = "";
                            string strREDDay = "";
                            string strREDMonth = "";
                            string strREDYear = "";
                            string strREDComplete = "";
                            string[] RSDArray = new string[3];
                            string[] REDArray = new string[3];
                            int createSQL = 1;
                            if (row["STARTDATE"].ToString() != "")
                            {
                                RSDArray = row["STARTDATE"].ToString().Split('/');
                            }
                            else
                            {
                                createSQL = 0;
                            }
                            if (row["ENDDATE"].ToString() != "")
                            {
                                REDArray = row["ENDDATE"].ToString().Split('/');
                            }
                            else
                            {
                                createSQL = 0;
                            }
                            if (createSQL == 1)
                            {
                                if (combo_DateFormat.Text.Equals("American"))
                                {
                                    strRSDDay = RSDArray[1].ToString();
                                    if ((strRSDDay == "1") || (strRSDDay == "2") || (strRSDDay == "3") || (strRSDDay == "4") || (strRSDDay == "5") || (strRSDDay == "6") || (strRSDDay == "7") || (strRSDDay == "8") || (strRSDDay == "9"))
                                    {
                                        strRSDDay = "0" + strRSDDay;
                                    }

                                    strRSDMonth = RSDArray[0].ToString();
                                    if ((strRSDMonth == "1") || (strRSDMonth == "2") || (strRSDMonth == "3") || (strRSDMonth == "4") || (strRSDMonth == "5") || (strRSDMonth == "6") || (strRSDMonth == "7") || (strRSDMonth == "8") || (strRSDMonth == "9"))
                                    {
                                        strRSDMonth = "0" + strRSDMonth;
                                    }

                                    strRSDYear = RSDArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strRSDComplete = "'" + strRSDMonth + "/" + strRSDDay + "/" + strRSDYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strRSDComplete = "to_date('" + strRSDMonth + "/" + strRSDDay + "/" + strRSDYear + "','MM/DD/YYYY')";
                                    }
                                    strREDDay = REDArray[1].ToString();
                                    if ((strREDDay == "1") || (strREDDay == "2") || (strREDDay == "3") || (strREDDay == "4") || (strREDDay == "5") || (strREDDay == "6") || (strREDDay == "7") || (strREDDay == "8") || (strREDDay == "9"))
                                    {
                                        strREDDay = "0" + strREDDay;
                                    }

                                    strREDMonth = REDArray[0].ToString();
                                    if ((strREDMonth == "1") || (strREDMonth == "2") || (strREDMonth == "3") || (strREDMonth == "4") || (strREDMonth == "5") || (strREDMonth == "6") || (strREDMonth == "7") || (strREDMonth == "8") || (strREDMonth == "9"))
                                    {
                                        strREDMonth = "0" + strREDMonth;
                                    }

                                    strREDYear = REDArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strREDComplete = "'" + strREDMonth + "/" + strREDDay + "/" + strREDYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strREDComplete = "to_date('" + strREDMonth + "/" + strREDDay + "/" + strREDYear + "','MM/DD/YYYY')";
                                    }
                                }
                                if (combo_DateFormat.Text.Equals("International"))
                                {
                                    strRSDDay = RSDArray[0].ToString();
                                    if ((strRSDDay == "1") || (strRSDDay == "2") || (strRSDDay == "3") || (strRSDDay == "4") || (strRSDDay == "5") || (strRSDDay == "6") || (strRSDDay == "7") || (strRSDDay == "8") || (strRSDDay == "9"))
                                    {
                                        strRSDDay = "0" + strRSDDay;
                                    }

                                    strRSDMonth = RSDArray[1].ToString();
                                    if ((strRSDMonth == "1") || (strRSDMonth == "2") || (strRSDMonth == "3") || (strRSDMonth == "4") || (strRSDMonth == "5") || (strRSDMonth == "6") || (strRSDMonth == "7") || (strRSDMonth == "8") || (strRSDMonth == "9"))
                                    {
                                        strRSDMonth = "0" + strRSDMonth;
                                    }

                                    strRSDYear = RSDArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strRSDComplete = "'" + strRSDDay + "/" + strRSDMonth + "/" + strRSDYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strRSDComplete = "to_date('" + strRSDDay + "/" + strRSDMonth + "/" + strRSDYear + "','DD/MM/YYYY')";
                                    }

                                    strREDDay = REDArray[0].ToString();
                                    if ((strREDDay == "1") || (strREDDay == "2") || (strREDDay == "3") || (strREDDay == "4") || (strREDDay == "5") || (strREDDay == "6") || (strREDDay == "7") || (strREDDay == "8") || (strREDDay == "9"))
                                    {
                                        strREDDay = "0" + strREDDay;
                                    }

                                    strREDMonth = REDArray[1].ToString();
                                    if ((strREDMonth == "1") || (strREDMonth == "2") || (strREDMonth == "3") || (strREDMonth == "4") || (strREDMonth == "5") || (strREDMonth == "6") || (strREDMonth == "7") || (strREDMonth == "8") || (strREDMonth == "9"))
                                    {
                                        strREDMonth = "0" + strREDMonth;
                                    }

                                    strREDYear = REDArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strREDComplete = "'" + strREDDay + "/" + strREDMonth + "/" + strREDYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strREDComplete = "to_date('" + strREDDay + "/" + strREDMonth + "/" + strREDYear + "','DD/MM/YYYY')";
                                    }
                                }
                                if (combo_DBType.Text.Equals("SQL"))
                                {
                                    strRoomConfigsSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.RMGT_T_ROOM_CONFIGS (CK_BED_SPACE,CK_ROOMS_CONFIG_NO,FK_ROOMS_TYPE,FK_SECTION_ID,ROOMS_START_DATE,ROOMS_END_DATE,GENDER,PHONE_EQUIP_NO,PHONE_EXTENSION,KEY_ID,OPERATING_MODE,ROOMS_CAPACITY,ROOMS_ADDRESS_1,ELIGIBILITY_CRITERIA,FK_USE_1,FK_USE_2,STATUS,DESIRABILITY) VALUES ('" + row["BEDSPACE"] + "','" + row["CONFIGNO"] + "','" + row["ROOMSTYPE"] + "','" + row["SECTIONID"] + "'," + strRSDComplete + "," + strREDComplete + ",'" + strGender + "','" + row["PHONEEQUIPNO"] + "','" + row["PHONEEXTENSION"] + "','" + row["KEYID"] + "','" + strOM + "','" + row["CAPACITY"] + "','" + row["ADDRESS1"] + "','" + row["ELIGIBILITYCRITERIA"] + "','" + strUse1 + "','" + strUse2 + "'," + strStatus + "," + strDesire + ");\r\n");

                                }
                                else if (combo_DBType.Text.Equals("Oracle"))
                                {
                                    strRoomConfigsSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".RMGT_T_ROOM_CONFIGS (CK_BED_SPACE,CK_ROOMS_CONFIG_NO,FK_ROOMS_TYPE,FK_SECTION_ID,ROOMS_START_DATE,ROOMS_END_DATE,GENDER,PHONE_EQUIP_NO,PHONE_EXTENSION,KEY_ID,OPERATING_MODE,ROOMS_CAPACITY,ROOMS_ADDRESS_1,ELIGIBILITY_CRITERIA,FK_USE_1,FK_USE_2,STATUS,DESIRABILITY) VALUES ('" + row["BEDSPACE"] + "','" + row["CONFIGNO"] + "','" + row["ROOMSTYPE"] + "','" + row["SECTIONID"] + "'," + strRSDComplete + "," + strREDComplete + ",'" + strGender + "','" + row["PHONEEQUIPNO"] + "','" + row["PHONEEXTENSION"] + "','" + row["KEYID"] + "','" + strOM + "','" + row["CAPACITY"] + "','" + row["ADDRESS1"] + "','" + row["ELIGIBILITYCRITERIA"] + "','" + strUse1 + "','" + strUse2 + "'," + strStatus + "," + strDesire + ");\r\n");
                                }
                            }
                        }
                        File.WriteAllText(RoomConfigsSQLPath, strRoomConfigsSQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ///
                ///Matching Criteria SQL Scripts
                ///
                try
                {
                    string MatchCritSQLPath = txt_SQLLoc.Text + "\\Rooms\\9.MatchCrit.sql";
                    int MatchCritRows = dsMatchCrit.Rows.Count;
                    if (MatchCritRows > 0)
                    {
                        foreach (DataRow row in dsMatchCrit.Rows)
                        {
                            string strStatus = row["CRITICAL"].ToString();
                            if (strStatus == "0")
                            {
                                strStatus = "0";
                            }
                            else
                            {
                                strStatus = "1";
                            }
                            if (combo_DBType.Text.Equals("SQL"))
                            {
                                strMatchCritSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.APPL_T_MATCHING_CRITERIA (PK_PRIORITY_NUMBER,MATCHING_CRITERIA_DESCRIPTION,DISPLAY_ORDER,CRITICAL) VALUES ('" + row["PRIORITYNUMBER"] + "','" + row["MATCHINGCRITERIADESCRIPTION"].ToString().Replace("'", "''") + "','" + row["DISPLAYORDER"] + "'," + strStatus + ");\r\n");

                            }
                            else if (combo_DBType.Text.Equals("Oracle"))
                            {
                                strMatchCritSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".APPL_T_MATCHING_CRITERIA (PK_PRIORITY_NUMBER,MATCHING_CRITERIA_DESCRIPTION,DISPLAY_ORDER,CRITICAL) VALUES ('" + row["PRIORITYNUMBER"] + "','" + row["MATCHINGCRITERIADESCRIPTION"].ToString().Replace("'", "''") + "','" + row["DISPLAYORDER"] + "'," + strStatus + ");\r\nCommit;\r\n");
                            }
                        }
                        File.WriteAllText(MatchCritSQLPath, strMatchCritSQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ///
                ///Inventory SQL Scripts
                ///
                try
                {
                    string InventorySQLPath = txt_SQLLoc.Text + "\\Rooms\\10.Inventory.sql";
                    int InventoryRows = dsInventory.Rows.Count;
                    if (InventoryRows > 0)
                    {
                        foreach (DataRow row in dsInventory.Rows)
                        {
                            string strStatus = row["STATUS"].ToString();
                            if (strStatus == "0")
                            {
                                strStatus = "0";
                            }
                            else
                            {
                                strStatus = "1";
                            }
                            if (combo_DBType.Text.Equals("SQL"))
                            {
                                strInventorySQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.RMGT_T_INVENTORY (PK_INVENTORY_CODE,INVENTORY_ITEM,INVENTORY_COMMENT,ROOM_INVENTORY_COST,STATUS) VALUES ('" + row["INVENTORYCODE"] + "','" + row["ITEM"].ToString().Replace("'", "''") + "','" + row["COMMENT"].ToString().Replace("'", "''") + "','" + row["COST"] + "'," + strStatus + ");\r\n");

                            }
                            else if (combo_DBType.Text.Equals("Oracle"))
                            {
                                strInventorySQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".RMGT_T_INVENTORY (PK_INVENTORY_CODE,INVENTORY_ITEM,INVENTORY_COMMENT,ROOM_INVENTORY_COST,STATUS) VALUES ('" + row["INVENTORYCODE"] + "','" + row["ITEM"].ToString().Replace("'", "''") + "','" + row["COMMENT"].ToString().Replace("'", "''") + "','" + row["COST"] + "'," + strStatus + ");\r\nCommit;\r\n");
                            }
                        }
                        File.WriteAllText(InventorySQLPath, strInventorySQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ///
                ///Room Inventory SQL Scripts
                ///
                try
                {
                    string RmInventorySQLPath = txt_SQLLoc.Text + "\\Rooms\\11.RmInventory.sql";
                    int RmInventoryRows = dsRmInventory.Rows.Count;
                    if (RmInventoryRows > 0)
                    {
                        foreach (DataRow row in dsRmInventory.Rows)
                        {
                            string strStatus = row["STATUS"].ToString();
                            if (strStatus == "0")
                            {
                                strStatus = "0";
                            }
                            else
                            {
                                strStatus = "1";
                            }
                            string strDeleted = row["DELETED"].ToString();
                            if (strDeleted == "0")
                            {
                                strDeleted = "0";
                            }
                            else
                            {
                                strDeleted = "1";
                            }
                            string strAssessedDay = "";
                            string strAssessedMonth = "";
                            string strAssessedYear = "";
                            string strAssessedComplete = "";
                            string strPurchasedDay = "";
                            string strPurchasedMonth = "";
                            string strPurchasedYear = "";
                            string strPurchasedComplete = "";
                            string strDeletedDay = "";
                            string strDeletedMonth = "";
                            string strDeletedYear = "";
                            string strDeletedComplete = "";
                            string[] AssessedArray = new string[3];
                            string[] PurchasedArray = new string[3];
                            string[] DeletedArray = new string[3];
                            int createSQL = 1;
                            if (row["ASSESSED"].ToString() != "")
                            {
                                AssessedArray = row["ASSESSED"].ToString().Split('/');
                            }
                            else
                            {
                                createSQL = 0;
                            }
                            if (row["PURCHASEDDATE"].ToString() != "")
                            {
                                PurchasedArray = row["PURCHASEDDATE"].ToString().Split('/');
                            }
                            else
                            {
                                createSQL = 0;
                            }
                            if (row["DELETEDDATE"].ToString() != "")
                            {
                                DeletedArray = row["DELETEDDATE"].ToString().Split('/');
                            }
                            else
                            {
                                createSQL = 0;
                            }
                            if (createSQL == 1)
                            {
                                if (combo_DateFormat.Text.Equals("American"))
                                {

                                    strAssessedDay = AssessedArray[1].ToString();
                                    if ((strAssessedDay == "1") || (strAssessedDay == "2") || (strAssessedDay == "3") || (strAssessedDay == "4") || (strAssessedDay == "5") || (strAssessedDay == "6") || (strAssessedDay == "7") || (strAssessedDay == "8") || (strAssessedDay == "9"))
                                    {
                                        strAssessedDay = "0" + strAssessedDay;
                                    }

                                    strAssessedMonth = AssessedArray[0].ToString();
                                    if ((strAssessedMonth == "1") || (strAssessedMonth == "2") || (strAssessedMonth == "3") || (strAssessedMonth == "4") || (strAssessedMonth == "5") || (strAssessedMonth == "6") || (strAssessedMonth == "7") || (strAssessedMonth == "8") || (strAssessedMonth == "9"))
                                    {
                                        strAssessedMonth = "0" + strAssessedMonth;
                                    }

                                    strAssessedYear = AssessedArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strAssessedComplete = "'" + strAssessedMonth + "/" + strAssessedDay + "/" + strAssessedYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strAssessedComplete = "to_date('" + strAssessedMonth + "/" + strAssessedDay + "/" + strAssessedYear + "','MM/DD/YYYY')";
                                    }
                                    strPurchasedDay = PurchasedArray[1].ToString();
                                    if ((strPurchasedDay == "1") || (strPurchasedDay == "2") || (strPurchasedDay == "3") || (strPurchasedDay == "4") || (strPurchasedDay == "5") || (strPurchasedDay == "6") || (strPurchasedDay == "7") || (strPurchasedDay == "8") || (strPurchasedDay == "9"))
                                    {
                                        strPurchasedDay = "0" + strPurchasedDay;
                                    }

                                    strPurchasedMonth = PurchasedArray[0].ToString();
                                    if ((strPurchasedMonth == "1") || (strPurchasedMonth == "2") || (strPurchasedMonth == "3") || (strPurchasedMonth == "4") || (strPurchasedMonth == "5") || (strPurchasedMonth == "6") || (strPurchasedMonth == "7") || (strPurchasedMonth == "8") || (strPurchasedMonth == "9"))
                                    {
                                        strPurchasedMonth = "0" + strPurchasedMonth;
                                    }

                                    strPurchasedYear = PurchasedArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strPurchasedComplete = "'" + strPurchasedMonth + "/" + strPurchasedDay + "/" + strPurchasedYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strPurchasedComplete = "to_date('" + strPurchasedMonth + "/" + strPurchasedDay + "/" + strPurchasedYear + "','MM/DD/YYYY')";
                                    }
                                    strDeletedDay = DeletedArray[1].ToString();
                                    if ((strDeletedDay == "1") || (strDeletedDay == "2") || (strDeletedDay == "3") || (strDeletedDay == "4") || (strDeletedDay == "5") || (strDeletedDay == "6") || (strDeletedDay == "7") || (strDeletedDay == "8") || (strDeletedDay == "9"))
                                    {
                                        strDeletedDay = "0" + strDeletedDay;
                                    }

                                    strDeletedMonth = DeletedArray[0].ToString();
                                    if ((strDeletedMonth == "1") || (strDeletedMonth == "2") || (strDeletedMonth == "3") || (strDeletedMonth == "4") || (strDeletedMonth == "5") || (strDeletedMonth == "6") || (strDeletedMonth == "7") || (strDeletedMonth == "8") || (strDeletedMonth == "9"))
                                    {
                                        strDeletedMonth = "0" + strDeletedMonth;
                                    }

                                    strDeletedYear = DeletedArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strDeletedComplete = "'" + strDeletedMonth + "/" + strDeletedDay + "/" + strDeletedYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strDeletedComplete = "to_date('" + strDeletedMonth + "/" + strDeletedDay + "/" + strDeletedYear + "','MM/DD/YYYY')";
                                    }
                                }
                                if (combo_DateFormat.Text.Equals("International"))
                                {
                                    strAssessedDay = AssessedArray[0].ToString();
                                    if ((strAssessedDay == "1") || (strAssessedDay == "2") || (strAssessedDay == "3") || (strAssessedDay == "4") || (strAssessedDay == "5") || (strAssessedDay == "6") || (strAssessedDay == "7") || (strAssessedDay == "8") || (strAssessedDay == "9"))
                                    {
                                        strAssessedDay = "0" + strAssessedDay;
                                    }

                                    strAssessedMonth = AssessedArray[1].ToString();
                                    if ((strAssessedMonth == "1") || (strAssessedMonth == "2") || (strAssessedMonth == "3") || (strAssessedMonth == "4") || (strAssessedMonth == "5") || (strAssessedMonth == "6") || (strAssessedMonth == "7") || (strAssessedMonth == "8") || (strAssessedMonth == "9"))
                                    {
                                        strAssessedMonth = "0" + strAssessedMonth;
                                    }

                                    strAssessedYear = AssessedArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strAssessedComplete = "'" + strAssessedDay + "/" + strAssessedMonth + "/" + strAssessedYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strAssessedComplete = "to_date('" + strAssessedDay + "/" + strAssessedMonth + "/" + strAssessedYear + "','DD/MM/YYYY')";
                                    }

                                    strPurchasedDay = PurchasedArray[0].ToString();
                                    if ((strPurchasedDay == "1") || (strPurchasedDay == "2") || (strPurchasedDay == "3") || (strPurchasedDay == "4") || (strPurchasedDay == "5") || (strPurchasedDay == "6") || (strPurchasedDay == "7") || (strPurchasedDay == "8") || (strPurchasedDay == "9"))
                                    {
                                        strPurchasedDay = "0" + strPurchasedDay;
                                    }

                                    strPurchasedMonth = PurchasedArray[1].ToString();
                                    if ((strPurchasedMonth == "1") || (strPurchasedMonth == "2") || (strPurchasedMonth == "3") || (strPurchasedMonth == "4") || (strPurchasedMonth == "5") || (strPurchasedMonth == "6") || (strPurchasedMonth == "7") || (strPurchasedMonth == "8") || (strPurchasedMonth == "9"))
                                    {
                                        strPurchasedMonth = "0" + strPurchasedMonth;
                                    }

                                    strPurchasedYear = PurchasedArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strPurchasedComplete = "'" + strPurchasedDay + "/" + strPurchasedMonth + "/" + strPurchasedYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strPurchasedComplete = "to_date('" + strPurchasedDay + "/" + strPurchasedMonth + "/" + strPurchasedYear + "','DD/MM/YYYY')";
                                    }
                                    strDeletedDay = DeletedArray[0].ToString();
                                    if ((strDeletedDay == "1") || (strDeletedDay == "2") || (strDeletedDay == "3") || (strDeletedDay == "4") || (strDeletedDay == "5") || (strDeletedDay == "6") || (strDeletedDay == "7") || (strDeletedDay == "8") || (strDeletedDay == "9"))
                                    {
                                        strDeletedDay = "0" + strDeletedDay;
                                    }

                                    strDeletedMonth = DeletedArray[1].ToString();
                                    if ((strDeletedMonth == "1") || (strDeletedMonth == "2") || (strDeletedMonth == "3") || (strDeletedMonth == "4") || (strDeletedMonth == "5") || (strDeletedMonth == "6") || (strDeletedMonth == "7") || (strDeletedMonth == "8") || (strDeletedMonth == "9"))
                                    {
                                        strDeletedMonth = "0" + strDeletedMonth;
                                    }

                                    strDeletedYear = DeletedArray[2].ToString().Substring(0, 4);
                                    if (combo_DBType.Text.Equals("SQL"))
                                    {
                                        strDeletedComplete = "'" + strDeletedDay + "/" + strDeletedMonth + "/" + strDeletedYear + "'";
                                    }
                                    else if (combo_DBType.Text.Equals("Oracle"))
                                    {
                                        strDeletedComplete = "to_date('" + strDeletedDay + "/" + strDeletedMonth + "/" + strDeletedYear + "','DD/MM/YYYY')";
                                    }
                                }
                                if (combo_DBType.Text.Equals("SQL"))
                                {
                                    strRmInventorySQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.RMGT_T_Room_Inventory (FK_BED_SPACE,FK_INVENTORY_CODE,ROOM_INVENTORY_STATUS,STATUS_COMMENT,SERIAL_NUMBER,PURCHASE_DATE,ASSESSED,INV_DELETED,INV_DELETED_DATE,INV_DELETEDBY) VALUES ('" + row["BEDSPACE"] + "','" + row["INVENTORYCODE"] + "'," + strStatus + ",'" + row["STATUSCOMMENT"].ToString().Replace("'", "''") + "','" + row["SERIALNUMBER"] + "'," + strPurchasedComplete + "," + strAssessedComplete + "," + strDeleted + "," + strDeletedComplete + ",'" + row["DELETEDBY"] + "');\r\n");

                                }
                                else if (combo_DBType.Text.Equals("Oracle"))
                                {
                                    strRmInventorySQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".RMGT_T_Room_Inventory (FK_BED_SPACE,FK_INVENTORY_CODE,ROOM_INVENTORY_STATUS,STATUS_COMMENT,SERIAL_NUMBER,PURCHASE_DATE,ASSESSED,INV_DELETED,INV_DELETED_DATE,INV_DELETEDBY) VALUES ('" + row["BEDSPACE"] + "','" + row["INVENTORYCODE"] + "'," + strStatus + ",'" + row["STATUSCOMMENT"].ToString().Replace("'", "''") + "','" + row["SERIALNUMBER"] + "'," + strPurchasedComplete + "," + strAssessedComplete + "," + strDeleted + "," + strDeletedComplete + ",'" + row["DELETEDBY"] + "');\r\n");
                                }
                            }
                        }
                        File.WriteAllText(RmInventorySQLPath, strRmInventorySQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ///
                ///Room Maintenance Code SQL Scripts
                ///
                try
                {
                    string RmMaintCodeSQLPath = txt_SQLLoc.Text + "\\Rooms\\12.RmMaintCode.sql";
                    int RmMaintCodeRows = dsRmMaintCode.Rows.Count;
                    if (RmMaintCodeRows > 0)
                    {
                        foreach (DataRow row in dsRmMaintCode.Rows)
                        {
                            string strStatus = row["STATUS"].ToString();
                            if (strStatus == "0")
                            {
                                strStatus = "0";
                            }
                            else
                            {
                                strStatus = "1";
                            }
                            if (combo_DBType.Text.Equals("SQL"))
                            {
                                strRmMaintCodeSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.L_U_T_RMGT_T_ROOM_MAINT_CODE (PK_MAINTENANCE_CODE,ITEM,STATUS) VALUES ('" + row["MAINTENANCECODE"].ToString().Replace("'", "''") + "','" + row["ITEM"].ToString().Replace("'", "''") + "'," + strStatus + ");\r\n");

                            }
                            else if (combo_DBType.Text.Equals("Oracle"))
                            {
                                strRmMaintCodeSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".L_U_T_RMGT_T_ROOM_MAINT_CODE (PK_MAINTENANCE_CODE,ITEM,STATUS) VALUES ('" + row["MAINTENANCECODE"].ToString().Replace("'", "''") + "','" + row["ITEM"].ToString().Replace("'", "''") + "'," + strStatus + ");\r\nCommit;\r\n");
                            }
                        }
                        File.WriteAllText(RmMaintCodeSQLPath, strRmMaintCodeSQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ///
                ///Maintenance Ref To SL Scripts
                ///
                try
                {
                    string MaintRefToSQLPath = txt_SQLLoc.Text + "\\Rooms\\13.MaintRefTo.sql";
                    int MaintRefToRows = dsMaintRefTo.Rows.Count;
                    if (MaintRefToRows > 0)
                    {
                        foreach (DataRow row in dsMaintRefTo.Rows)
                        {
                            if (combo_DBType.Text.Equals("SQL"))
                            {
                                strMaintRefToSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".dbo.RMGT_T_MAINTENANCE_REF_TO (PK_REFERRED_TO_ID,MAINTENANCE_REFERRED_TO_NAME,FUNCTION_NAME,STATUS) VALUES ('" + row["REFERRERTOID"] + "','" + row["REFERREDTONAME"].ToString().Replace("'", "''") + "','" + row["FUNCTIONNAME"].ToString().Replace("'", "''") + "','" + row["STATUS"] + "');\r\n");

                            }
                            else if (combo_DBType.Text.Equals("Oracle"))
                            {
                                strMaintRefToSQL.Append("INSERT INTO " + txt_RealDatabaseName.Text + ".RMGT_T_MAINTENANCE_REF_TO (PK_REFERRED_TO_ID,MAINTENANCE_REFERRED_TO_NAME,FUNCTION_NAME,STATUS) VALUES ('" + row["REFERRERTOID"] + "','" + row["REFERREDTONAME"].ToString().Replace("'", "''") + "','" + row["FUNCTIONNAME"].ToString().Replace("'", "''") + "','" + row["STATUS"] + "');\r\n");
                            }
                        }
                        File.WriteAllText(MaintRefToSQLPath, strMaintRefToSQL.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show("Scripts created!");
            }
        }

    }
}