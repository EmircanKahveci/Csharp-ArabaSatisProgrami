using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarBuyForm
{
    public partial class AdminDisplay : Form
    {
        public AdminDisplay()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerTransactions customerTransactions = new CustomerTransactions();
            customerTransactions.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VehicleOperations vehicleOperations = new VehicleOperations();
            vehicleOperations.ShowDialog();
        }

        private void AdminDisplay_Load(object sender, EventArgs e)
        {

        }
    }
}
