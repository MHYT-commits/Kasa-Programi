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
    public partial class KatogoriEkle : Form
    {
        public KatogoriEkle()
        {
            InitializeComponent();
        }

        string con = "Data Source=DESKTOP-V8MR49H\\SQLEXPRESS;Initial Catalog=DenemeDB;Integrated Security=True;";
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Kategori Adı Boş Bırakılamaz");
                return;
            }
            SqlConnection sqlConnection = new SqlConnection(con);
            sqlConnection.Open();
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                string query = "INSERT INTO UrunKategorileri(KatagoriAd) VALUES(@KatagoriAd)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@KatagoriAd", textBox1.Text);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Kategori Eklendi");
            }
            else
            {
                MessageBox.Show("Bağlantı Başarısız");
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
