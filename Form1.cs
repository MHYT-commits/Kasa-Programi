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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string conString = "Data Source=DESKTOP-V8MR49H\\SQLEXPRESS;Initial Catalog=DenemeDB;Integrated Security=True;";

        static string Encyrpt(string text)
        {
            string result = string.Empty;
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(text);
            foreach (byte item in temp)
            {
                 
                result += item.ToString();
            }
            return result;
        }
        private void btn_giris_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(conString);
            baglanti.Open();
            if (baglanti.State == System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Bağlantı Başarılı");
                string query = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAd=@kullanici_adi AND KullaniciSifre=@sifre";
                SqlCommand komut = new SqlCommand(query, baglanti);
                komut.Parameters.AddWithValue("@kullanici_adi", txt_kullanici_adi.Text);
                komut.Parameters.AddWithValue("@sifre", Encyrpt(txt_sifre.Text));
                int count = (int)komut.ExecuteScalar();
                if (count > 0)
                {
                    this.Hide();
                    Menu menu = new Menu();
                    menu.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Giriş Başarısız");
                }
            }
            else
            {
                MessageBox.Show("Bağlantı Başarısız");
            }
            baglanti.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_sifre.UseSystemPasswordChar = false;
            }
            else
            {
                txt_sifre.UseSystemPasswordChar = true;
            }
        }
    }
}
