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
    public partial class AddingCustomerForm : Form
    {
        public AddingCustomerForm()
        {
            InitializeComponent();
        }

        private void AddingCustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            CustomerFormAdmin newform = new CustomerFormAdmin();
            newform.ShowDialog();
            this.Show();
        }
    }
}
