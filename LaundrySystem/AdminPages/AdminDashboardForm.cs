﻿using System;
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
    public partial class AdminDashboardForm : Form
    {
        private AdminHomePage _parentForm;

        public AdminDashboardForm(AdminHomePage parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm; // reference to the parent form
        }

        private void buttonDashboardTotalCustomer_Click(object sender, EventArgs e)
        {
            CustomerFormAdmin customerForm = new CustomerFormAdmin();
            customerForm.TopLevel = false;
            customerForm.FormBorderStyle = FormBorderStyle.None;
            customerForm.Dock = DockStyle.Fill;
            _parentForm.HomePageLabel.Text = "Customer"; 
            _parentForm.HomePagePanel.Controls.Clear(); 
            _parentForm.HomePagePanel.Controls.Add(customerForm); 
            customerForm.Show();
        }

        private void buttonDashboardTotalStaff_Click(object sender, EventArgs e)
        {
            StaffAccountForm staffAccountForm = new StaffAccountForm();
            staffAccountForm.TopLevel = false;
            staffAccountForm.FormBorderStyle = FormBorderStyle.None;
            staffAccountForm.Dock = DockStyle.Fill;
            _parentForm.HomePageLabel.Text = "Staff"; 
            _parentForm.HomePagePanel.Controls.Clear(); 
            _parentForm.HomePagePanel.Controls.Add(staffAccountForm); 
            staffAccountForm.Show();
        }

    }
}
