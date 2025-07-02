using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KasaSistem_Master
{
    public partial class UrunListesi : Form
    {
        public UrunListesi()
        {
            InitializeComponent();
        }
        public string con = "Data Source=DESKTOP-V8MR49H\\SQLEXPRESS;Initial Catalog=DenemeDB;Integrated Security=True;";

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void UrunListesi_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(con);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Barkod,UrunAd,KatagoriAd, Firma, AlisFiyat, SatisFiyat, Stok, GelisTarihi, SonTTarihi FROM Urunler Inner Join UrunKategorileri ON Urunler.KategoriId = UrunKategorileri.KatagoriId");
            cmd.Connection = sqlConnection;
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);

            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }

        
    }
}
