using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using wordeaktar = Microsoft.Office.Interop.Word;
using System.IO;

namespace CarBuyForm
{
    public partial class BuyingCar : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        DataTable table;

        public BuyingCar()
        {
            InitializeComponent();
        }

        public void ResimGosterDataGridView()
        {
            SqlConnection con = new SqlConnection(@"Server=.;Database=ReCapDataBases;Trusted_Connection=true");
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select CarId,images,Brand,Model,Year,FuelType,Gear,EnginePower,Price from Cars", con);
            DataTable dt = new DataTable();
            adtr.Fill(dt);
            dt.Columns.Add("Picture", Type.GetType("System.Byte[]"));
            foreach (DataRow item in dt.Rows)
            {
                item["Picture"] = File.ReadAllBytes(item["images"].ToString());
            }
            dataGridView2.DataSource = dt;
            con.Close();
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.Columns[1].Visible = false;
            dataGridView2.Columns["Picture"].DisplayIndex = 1;
            dataGridView2.Refresh();
            table = new DataTable();
            table = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            
                for (int i = 0; i < dataGridView2.SelectedRows.Count; i++)
                {
                SqlConnection con = new SqlConnection(@"Server=.;Database=ReCapDataBases;Trusted_Connection=true");
                con.Open();
                    SqlCommand cmd = new SqlCommand("delete from Cars where CarId='" + dataGridView2.SelectedRows[i].Cells["CarId"].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            ResimGosterDataGridView();
                MessageBox.Show("Araç Satın Alma İşlemi Başarılı");

            }
            
        

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            textBox8.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
        }

        
        private void BuyingCar_Load(object sender, EventArgs e)
        {
            ResimGosterDataGridView();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            DataView dv = table.DefaultView;
            dv.RowFilter = "Brand LIKE '" + textBox1.Text + "%'";
            dataGridView2.DataSource = dv;
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
            
        }
    }
}
