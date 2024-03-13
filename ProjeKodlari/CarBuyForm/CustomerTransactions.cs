

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
    public partial class CustomerTransactions : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        public void ResimGosterDataGridView()
        {
            SqlConnection con = new SqlConnection(@"Server=.;Database=ReCapDataBases;Trusted_Connection=true");
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select CustomerNo,images,TcNo, Name, LastName, DateofBirth, Profession, PhoneNumber, Email, Address, DrivingLicenseNo, LicenseType from Customers", con);
            DataTable dt = new DataTable();
            adtr.Fill(dt);
            dt.Columns.Add("Picture", Type.GetType("System.Byte[]"));
            foreach (DataRow item in dt.Rows)
            {
                item["Picture"] = File.ReadAllBytes(item["images"].ToString());
            }
            dataGridView1.DataSource = dt;
            con.Close();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns["Picture"].DisplayIndex = 1;
            dataGridView1.Refresh();
        }

        public int VarMi(string aranan)
        {
            int sonuc;
            SqlConnection con = new SqlConnection(@"Server=.;Database=ReCapDataBases;Trusted_Connection=true");
            string sorgu = "Select COUNT(TcNo) from Customers WHERE TcNo='" + aranan + "'";
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            sonuc = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return sonuc;
        }
        public int VarMi2(string aranan)
        {
            int sonuc2;
            SqlConnection con = new SqlConnection(@"Server=.;Database=ReCapDataBases;Trusted_Connection=true");
            string sorgu = "Select COUNT(CustomerNo) from Customers WHERE CustomerNo='" + aranan + "'";
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            sonuc2 = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return sonuc2;
        }
        public CustomerTransactions()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "ResimSeç";
            openFileDialog1.Filter = "Resim Dosyası |*.jpg;*.nef;*.png |  Tüm Dosyalar |*.*";
            openFileDialog1.ShowDialog();
            string dosyayolu = openFileDialog1.FileName;
            pictureBox1.ImageLocation = dosyayolu;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Lütfen Resim Seçiniz");
            }
            else
            {
                if (VarMi(textBox1.Text) != 0)
                {
                    MessageBox.Show("Bu TC No ile daha önce kayıt yapılmış");
                }
                else
                {
                    if (VarMi2(textBox7.Text) != 0)
                    {
                        MessageBox.Show("Bu Customer No ile daha önce kayıt yapılmış");

                    }
                    else
                    {
                        if (pictureBox1.Image.Width > 64 || pictureBox1.Image.Height > 64)
                        {
                            MessageBox.Show("Fotoğraf boyutu en fazla 64x64 olmalıdır.");
                        }
                        else
                        {

                            SqlConnection con = new SqlConnection(@"Server=.;Database=ReCapDataBases;Trusted_Connection=true");
                            string sorgu = "Insert into Customers (CustomerNo,images,TcNo, Name, LastName, DateofBirth, Profession, PhoneNumber, Email, Address, DrivingLicenseNo, LicenseType) values (@CustomerNo,@images,@TcNo,@Name,@LastName,@DateofBirth,@Profession,@PhoneNumber,@Email,@Address,@DrivingLicenseNo,@LicenseType)";
                            cmd = new SqlCommand(sorgu, con);

                            cmd.Parameters.AddWithValue("@CustomerNo", textBox7.Text);
                            cmd.Parameters.AddWithValue("@images", pictureBox1.ImageLocation);
                            cmd.Parameters.AddWithValue("@TcNo", textBox1.Text);
                            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                            cmd.Parameters.AddWithValue("@LastName", textBox3.Text);
                            cmd.Parameters.AddWithValue("@DateofBirth", textBox4.Text);
                            cmd.Parameters.AddWithValue("@Profession", textBox5.Text);
                            cmd.Parameters.AddWithValue("@PhoneNumber", textBox6.Text);
                            cmd.Parameters.AddWithValue("@Email", textBox8.Text);
                            cmd.Parameters.AddWithValue("@Address", textBox9.Text);
                            cmd.Parameters.AddWithValue("@DrivingLicenseNo", textBox10.Text);
                            cmd.Parameters.AddWithValue("@LicenseType", textBox11.Text);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            ResimGosterDataGridView();


                            MessageBox.Show("Müşteri Kaydedildi");
                        }

                    }


                }



            }

        }

        private void CustomerTransactions_Load(object sender, EventArgs e)
        {
            ResimGosterDataGridView();

        }


        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=.;Database=ReCapDataBases;Trusted_Connection=true");
            string sorgu = "UPDATE Customers SET CustomerNo=@CustomerNo,images=@images, TcNo=@TcNo,Name=@Name,LastName=@LastName,DateofBirth=@DateofBirth,Profession=@Profession,PhoneNumber=@PhoneNumber, Email=@Email, Address=@Address, DrivingLicenseNo=@DrivingLicenseNo,LicenseType=@LicenseType WHERE CustomerNo=@CustomerNo";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@CustomerNo", textBox7.Text);
            cmd.Parameters.AddWithValue("@images", pictureBox1.ImageLocation);
            cmd.Parameters.AddWithValue("@TcNo", textBox1.Text);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@LastName", textBox3.Text);
            cmd.Parameters.AddWithValue("@DateofBirth", textBox4.Text);
            cmd.Parameters.AddWithValue("@Profession", textBox5.Text);
            cmd.Parameters.AddWithValue("@PhoneNumber", textBox6.Text);
            cmd.Parameters.AddWithValue("@Email", textBox8.Text);
            cmd.Parameters.AddWithValue("@Address", textBox9.Text);
            cmd.Parameters.AddWithValue("@DrivingLicenseNo", textBox10.Text);
            cmd.Parameters.AddWithValue("@LicenseType", textBox11.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ResimGosterDataGridView();
            MessageBox.Show("Müşteri Güncellendi");



        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                SqlConnection con = new SqlConnection(@"Server=.;Database=ReCapDataBases;Trusted_Connection=true");
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Customers where CustomerNo='" + dataGridView1.SelectedRows[i].Cells["CustomerNo"].Value.ToString() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            ResimGosterDataGridView();
            MessageBox.Show("Müşteri Silindi");

        }


        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView1.CurrentRow.Selected = true;
            int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CustomerNo"].FormattedValue);
            SqlConnection con = new SqlConnection(@"Server=.;Database=ReCapDataBases;Trusted_Connection=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("select images from Customers Where CustomerNo = '" + id + "'", con);
            string img = cmd.ExecuteScalar().ToString();
            pictureBox1.Image = Image.FromFile(img);
            con.Close();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
