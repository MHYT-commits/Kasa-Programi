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
    public partial class UrunGuncelle : Form
    {
        public UrunGuncelle()
        {
            InitializeComponent();
        }
        public string con = "Data Source=DESKTOP-V8MR49H\\SQLEXPRESS;Initial Catalog=DenemeDB;Integrated Security=True;";

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(con);

            sqlConnection.Open();
            string query = "SELECT * FROM Urunler WHERE Barkod = '"+textBox1.Text+"'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
               
                textBox2.Text = reader["UrunAd"].ToString();
                comboBox1.SelectedIndex = Convert.ToInt32(reader["KategoriId"].ToString())-1;
                textBox4.Text = reader["Firma"].ToString();
                textBox5.Text = reader["AlisFiyat"].ToString();
                textBox6.Text = reader["SatisFiyat"].ToString();
                textBox7.Text = reader["Stok"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(reader["GelisTarihi"]);
                if (reader["SonTTarihi"] == DBNull.Value)
                {
                    checkBox1.Checked = true;
                    dateTimePicker2.Enabled = false;
                }
                else
                {
                    checkBox1.Checked = false;
                    dateTimePicker2.Enabled = true;
                    dateTimePicker2.Value = Convert.ToDateTime(reader["SonTTarihi"]);
                }
                
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if(textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz");
                return;
            }


            SqlConnection sqlConnection = new SqlConnection(con);
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "UPDATE Urunler SET KategoriId = @KategoriId, Firma = @Firma, AlisFiyat = @AlisFiyat, SatisFiyat = @SatisFiyat, Stok = @Stok, GelisTarihi = @GelisTarihi, SonTTarihi = @SonTTarihi WHERE Barkod = @Barkod";
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@Barkod", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@KategoriId", comboBox1.SelectedIndex+1);
            sqlCommand.Parameters.AddWithValue("@Firma", textBox4.Text);
            sqlCommand.Parameters.AddWithValue("@AlisFiyat", textBox5.Text);
            sqlCommand.Parameters.AddWithValue("@SatisFiyat", textBox6.Text);
            sqlCommand.Parameters.AddWithValue("@Stok", textBox7.Text);
            sqlCommand.Parameters.AddWithValue("@GelisTarihi", dateTimePicker1.Value);
            if (!checkBox1.Checked)
            {
                sqlCommand.Parameters.AddWithValue("@SonTTarihi", dateTimePicker2.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@SonTTarihi", DBNull.Value);
            }
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Ürün Güncellendi");
            sqlConnection.Close();
        }

        private void UrunGuncelle_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(con);

            sqlConnection.Open();
            string query = "SELECT KatagoriAd FROM UrunKategorileri";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["KatagoriAd"]);
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }
    }
}
