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
    public partial class KullanıcıEkle : Form
    {
        public KullanıcıEkle()
        {
            InitializeComponent();
        }

        string con = "Data Source=DESKTOP-V8MR49H\\SQLEXPRESS;Initial Catalog=DenemeDB;Integrated Security=True;";
        
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


        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(con);

            sqlConnection.Open();
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                string queary = "INSERT INTO Kullanicilar (KullaniciAd,KullaniciSifre) VALUES ('" + txt_kullanici_adi.Text + "','" + Encyrpt(txt_sifre.Text) + "')";
                SqlCommand sqlCommand = new SqlCommand(queary, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı Eklendi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(con);

            sqlConnection.Open();
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                string queary = "DELETE FROM Kullanicilar WHERE KullaniciAd = '" + txt_kullanici_adi.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(queary, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı Silindi");
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
