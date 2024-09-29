﻿using LaundrySystem.AdminPages.Trasaction;
using LaundrySystem.BackEnd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaundrySystem.AdminPages
{
    public partial class TransactionFormAdmin : Form
    {
        FetchData fetchData;
        public TransactionFormAdmin()
        {
            InitializeComponent();
        }

        private void PopulateComboBoxCustomer()
        {
            GetAllCustomer getAllCustomer = new GetAllCustomer();
            comboBoxCustomer.DataSource = getAllCustomer;
            comboBoxCustomer.DisplayMember = "p_fullname";  // Assuming there is a CustomerName column
            comboBoxCustomer.SelectedIndex = -1;              // Ensure no selection on load
        }

        private void PopulateComboBoxStaff()
        {
            GetAllStaff getAllStaff = new GetAllStaff();
            comboBoxStaff.DataSource = getAllStaff;
            comboBoxStaff.DisplayMember = "p_fullname";  // Assuming there is a StaffName column
            comboBoxStaff.SelectedIndex = -1;           // Ensure no selection on load
        }

        private void PopulateComboBoxGarments()
        {
            GetAllGarments getAllGarments = new GetAllGarments();
            comboBoxGarmentsType.DataSource = getAllGarments;
            comboBoxGarmentsType.DisplayMember = "p_garmenttype";  // Assuming there is a GarmentType column
            comboBoxGarmentsType.SelectedIndex = -1;             // Ensure no selection on load
        }

        private void PopulateComboBoxServices()
        {
            GetAllServices getAllServices = new GetAllServices();
            comboBoxServicesType.DataSource = getAllServices;
            comboBoxServicesType.DisplayMember = "p_servicetype";  // Assuming there is a ServiceType column
            comboBoxServicesType.SelectedIndex = -1;             // Ensure no selection on load
        }

        private void buttonTrasactionHistory_Click(object sender, EventArgs e)
        {
            TransactionHistory transactionHistory = new TransactionHistory();
            this.Hide();
            transactionHistory.ShowDialog();
        }

        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxStaff_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxWeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxGarmentsType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxServicesType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerDateDelivered_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerDateClaimed_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonAddTransaction_Click(object sender, EventArgs e)
        {
            // Get selected values
            int customerId = Convert.ToInt32(comboBoxCustomer.SelectedValue);
            int staffId = Convert.ToInt32(comboBoxStaff.SelectedValue);
            string serviceType = comboBoxServicesType.Text.Trim();
            string garmentType = comboBoxGarmentsType.Text.Trim();
            decimal weight = Convert.ToDecimal(textBoxWeight.Text.Trim());
            decimal amount = Convert.ToDecimal(textBoxAmount.Text.Trim());
            DateTime dateDelivered = dateTimePickerDateDelivered.Value;
            DateTime dateClaimed = dateTimePickerDateClaimed.Value;

            // Validate inputs and add transaction
            if (customerId == 0 || staffId == 0 || string.IsNullOrEmpty(serviceType) || string.IsNullOrEmpty(garmentType) || weight <= 0 || amount <= 0)
            {
                MessageBox.Show("Please fill in all fields correctly.");
                return;
            }

            try
            {
                AddTransaction addTransaction = new AddTransaction();
                addTransaction.AddTransactionsToDatabase(customerId, staffId, serviceType, weight, garmentType, amount, dateDelivered, dateClaimed);

                // Optionally, clear input fields after adding transaction
                comboBoxCustomer.SelectedIndex = -1;
                comboBoxStaff.SelectedIndex = -1;
                comboBoxServicesType.SelectedIndex = -1;
                comboBoxGarmentsType.SelectedIndex = -1;
                textBoxWeight.Clear();
                textBoxAmount.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
