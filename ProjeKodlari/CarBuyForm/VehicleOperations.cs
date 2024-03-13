using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarBuyForm
{
    public partial class VehicleOperations : Form
    {

        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        
        int carID;
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
        }
        public int VarMi(int aranan)
        {
            int sonuc;
            SqlConnection con = new SqlConnection(@"Server=.;Database=ReCapDataBases;Trusted_Connection=true");
            string sorgu = "Select COUNT(CarId) from Cars WHERE CarId='" + aranan + "'";
            cmd = new SqlCommand(sorgu, con);
            con.Open();

            sonuc = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();
            return sonuc;
        }

        
        public VehicleOperations()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Lütfen Resim Seçiniz");
            }
            else
            {
                carID = Convert.ToInt32(textBox8.Text);
                if (VarMi(carID) != 0)
                {
                    MessageBox.Show("CarId aynı olamaz!");
                }
                else
                {
                    if (pictureBox1.Image.Width> 128 || pictureBox1.Image.Height > 128)
                    {
                        MessageBox.Show("Fotoğraf boyutu en fazla 128x128 olmalıdır.");
}
                    else
                    {

                        SqlConnection con = new SqlConnection(@"Server=.;Database=ReCapDataBases;Trusted_Connection=true");
                        string sorgu = "Insert into Cars (CarId,images,Brand, Model, Year, FuelType, Gear, EnginePower, Price) values (@CarId,@images,@Brand,@Model,@Year,@FuelType,@Gear,@EnginePower,@Price)";
                        cmd = new SqlCommand(sorgu, con);

                        cmd.Parameters.AddWithValue("@CarId", textBox8.Text);
                        cmd.Parameters.AddWithValue("@images", pictureBox1.ImageLocation);
                        cmd.Parameters.AddWithValue("@Brand", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Model", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Year", textBox3.Text);
                        cmd.Parameters.AddWithValue("@FuelType", textBox4.Text);
                        cmd.Parameters.AddWithValue("@Gear", textBox5.Text);
                        cmd.Parameters.AddWithValue("@EnginePower", textBox6.Text);
                        cmd.Parameters.AddWithValue("@Price", textBox7.Text);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        ResimGosterDataGridView();


                        MessageBox.Show("Araç Kaydedildi");
                    }
                   

                }

            }

        }
        private void VehicleOperations_Load(object sender, EventArgs e)
        {
            ResimGosterDataGridView();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "ResimSeç";
            openFileDialog1.Filter = "Resim Dosyası |*.jpg;*.nef;*.png |  Tüm Dosyalar |*.*";
            openFileDialog1.ShowDialog();
            string dosyayolu = openFileDialog1.FileName;
            pictureBox1.ImageLocation = dosyayolu;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=.;Database=ReCapDataBases;Trusted_Connection=true");
            string sorgu = "UPDATE Cars SET CarId=@CarId,images=@images,Brand=@Brand,Model=@Model,Year=@Year,FuelType=@FuelType,Gear=@Gear,EnginePower=@EnginePower, Price=@Price WHERE CarId=@CarId";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@CarId", textBox8.Text);
            cmd.Parameters.AddWithValue("@images", pictureBox1.ImageLocation);
            cmd.Parameters.AddWithValue("@Brand", textBox1.Text);
            cmd.Parameters.AddWithValue("@Model", textBox2.Text);
            cmd.Parameters.AddWithValue("@Year", textBox3.Text);
            cmd.Parameters.AddWithValue("@FuelType", textBox4.Text);
            cmd.Parameters.AddWithValue("@Gear", textBox5.Text);
            cmd.Parameters.AddWithValue("@EnginePower", textBox6.Text);
            cmd.Parameters.AddWithValue("@Price", textBox7.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ResimGosterDataGridView();
            MessageBox.Show("Araç Güncellendi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=.;Database=ReCapDataBases;Trusted_Connection=true");
            for (int i = 0; i < dataGridView2.SelectedRows.Count; i++)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Cars where CarId='" + dataGridView2.SelectedRows[i].Cells["CarId"].Value.ToString() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            ResimGosterDataGridView();
            MessageBox.Show("Araç Silindi");
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox1.ImageLocation = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            textBox6.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            textBox7.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            textBox8.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.CurrentRow.Selected = true;
            int id = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["CarId"].FormattedValue);
            SqlConnection con = new SqlConnection(@"Server=.;Database=ReCapDataBases;Trusted_Connection=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("select images from Cars Where CarId = '" + id + "'", con);
            string img = cmd.ExecuteScalar().ToString();
            pictureBox1.Image = Image.FromFile(img);
            con.Close();
        }
    }
}
