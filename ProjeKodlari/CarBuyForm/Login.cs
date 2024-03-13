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
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string AdminID = "Emircan";
            var AdminPassword = "Kahveci";
            string ID = textBox1.Text;
            var Password = textBox2.Text;

            if (AdminID == ID && AdminPassword == Password)
            {
                AdminDisplay adminDisplay = new AdminDisplay();
                adminDisplay.ShowDialog();


            }
            else
                MessageBox.Show("Giris bilgileriniz yanlis");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerDisplay customerDisplay = new CustomerDisplay();
            customerDisplay.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Emircan";
            textBox2.Text = "Kahveci";
        }
    }
}
