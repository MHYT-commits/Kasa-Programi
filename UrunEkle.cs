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

namespace KasaSistem_Master
{
    public partial class UrunEkle : Form
    {
        public UrunEkle()
        {
            InitializeComponent();
        }

        public string conString = "Data Source=DESKTOP-V8MR49H\\SQLEXPRESS;Initial Catalog=DenemeDB;Integrated Security=True;";

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == "" || comboBox1.SelectedItem.ToString() == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" )
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz");
                return;
            }
          
            SqlConnection sqlConnection = new SqlConnection(conString);
            sqlConnection.Open();
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {

                string query = "INSERT INTO Urunler(Barkod,UrunAd, KategoriId,Firma,AlisFiyat,SatisFiyat,Stok,GelisTarihi,SonTTarihi) VALUES(@BARKOD,@URUNAD, @KATOGORI,@FİRMA,@ALIŞFİYAT,@SATIŞFİYAT,@STOK,@GELİŞTARİHİ,@SONTTARİHİ)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@BARKOD", textBox1.Text);
                sqlCommand.Parameters.AddWithValue("@URUNAD", textBox2.Text);
                sqlCommand.Parameters.AddWithValue("@KATOGORI", comboBox1.SelectedIndex + 1);
                sqlCommand.Parameters.AddWithValue("@FİRMA", textBox4.Text);
                sqlCommand.Parameters.AddWithValue("@ALIŞFİYAT", textBox5.Text);
                sqlCommand.Parameters.AddWithValue("@SATIŞFİYAT", textBox6.Text);
                sqlCommand.Parameters.AddWithValue("@STOK", textBox7.Text);
                sqlCommand.Parameters.AddWithValue("@GELİŞTARİHİ",dateTimePicker1.Text);
                if (!checkBox1.Checked) 
                {
                    sqlCommand.Parameters.AddWithValue("@SONTTARİHİ", dateTimePicker2.Text);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@SONTTARİHİ", DBNull.Value);
                }
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Ürün Eklendi");
            }
            else
            {
                MessageBox.Show("Bağlantı Başarısız");
            }
            sqlConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Barkod Numarası Giriniz");
                return;
            }
            if (textBox1.Text.Length < 10) 
            {
                MessageBox.Show("Barkod Numarası 10 Haneli Olmalıdır");
            }
            SqlConnection sqlConnection = new SqlConnection(conString);
            sqlConnection.Open();
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {

                string query = "DELETE FROM Urunler WHERE BARKOD=@BARKOD";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@BARKOD", textBox1.Text);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Ürün Silindi");
            }
            else
            {
                
                MessageBox.Show("Bağlantı Başarısız");
            }
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.SelectedIndex = -1;
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
           
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UrunListesi urunListesi = new UrunListesi();
            urunListesi.ShowDialog();
            this.Close();
        }

        private void UrunEkle_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(conString);

            sqlConnection.Open();
            string query = "SELECT KatagoriAd FROM UrunKategorileri";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["KatagoriAd"]);
            }
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateTimePicker2.Enabled = false;
            }
            else
            {
                dateTimePicker2.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
