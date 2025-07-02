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
    public partial class İade : Form
    {
        public DataTable dt;

        public int toplam;

        public int fiyat;

        public string ad;
        public İade()
        {
            InitializeComponent();
        }

        string con = "Data Source=DESKTOP-V8MR49H\\SQLEXPRESS;Initial Catalog=AlısVerisDB;Integrated Security=True;";
        string con2 = "Data Source=DESKTOP-V8MR49H\\SQLEXPRESS;Initial Catalog=DenemeDB;Integrated Security=True;";
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(con);
            sqlConnection.Open();


            SqlConnection sqlConnection1 = new SqlConnection(con2);
            sqlConnection1.Open();
            SqlCommand sqlCommand1 = new SqlCommand("SELECT SATISFIYAT From Urunler WHERE BARKOD = '" + txt_barkod.Text + "'", sqlConnection1);
            SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
            while (sqlDataReader1.Read())
            {
                fiyat = Convert.ToInt32(sqlDataReader1[0]);

            }
            sqlDataReader1.Close();
            SqlCommand sqlCommand2 = new SqlCommand("SELECT URUNAD From Urunler WHERE BARKOD = '" + txt_barkod.Text + "'", sqlConnection1);
            SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
            while (sqlDataReader2.Read())
            {
                ad = sqlDataReader2[0].ToString();
                
            }
            sqlDataReader2.Close();

            SqlCommand sqlCommand3 = new SqlCommand("Update FisNo_"+txt_fis_num.Text+" Set Fiyat = Fiyat - "+fiyat+" Where UrunAdi = '"+ad+"' ", sqlConnection);
            sqlCommand3.ExecuteNonQuery();

            SqlCommand sqlCommand4 = new SqlCommand("Update FisNo_"+txt_fis_num.Text+" Set Miktar = Miktar - 1 Where UrunAdi = '"+ad+"' ", sqlConnection);
            sqlCommand4.ExecuteNonQuery();

            SqlCommand sqlCommand5 = new SqlCommand("Delete From FisNo_" + txt_fis_num.Text + " Where Miktar = 0", sqlConnection);
            sqlCommand5.ExecuteNonQuery();

            sqlConnection1.Close();
            sqlConnection.Close();
            
            MessageBox.Show("İade Alındı");




            //DataTable dt = new DataTable();
            //SqlConnection sqlConnection = new SqlConnection(con);
            //sqlConnection.Open();

            //string queary1 = "SELECT * FROM Ürünler WHERE BARKOD = '" + txt_barkod.Text + "'";
            //string queary2 = "SELECT Toplam FROM GünlükAlışVeriş WHERE FişNumarası = '" + txt_fis_num.Text + "'";

            //SqlCommand sqlCommand = new SqlCommand(queary1, sqlConnection);
            //SqlCommand sqlCommand1 = new SqlCommand(queary2, sqlConnection);

            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();


            //while (sqlDataReader.Read())
            //{
            //    fiyat = Convert.ToInt32(sqlDataReader[5]);
            //    ad = sqlDataReader[1].ToString();
            //}


            //sqlDataReader.Close();

            //SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
            //while (sqlDataReader1.Read()) 
            //{
            //    toplam = Convert.ToInt32(sqlDataReader1[0]);
            //}
            //sqlDataReader1.Close();


            //toplam -= fiyat;

            //MessageBox.Show(toplam.ToString());

            //SqlCommand cmd = new SqlCommand("UPDATE GünlükAlışVeriş SET Toplam = '" + toplam + "' WHERE FişNumarası = '" + txt_fis_num.Text + "'");
            //cmd.Connection = sqlConnection;
            //cmd.ExecuteNonQuery();

            //SqlCommand cmd2 = new SqlCommand("UPDATE GünlükAlışVeriş SET İadeler = İadeler + '" + ad + "' WHERE FişNumarası = '" + txt_fis_num.Text + "'");
            //cmd2.Connection = sqlConnection;
            //cmd2.ExecuteNonQuery();
            //sqlConnection.Close();
            //MessageBox.Show("İade Alındı");

        }

        private void İade_Load(object sender, EventArgs e)
        {
 

        }

        private void txt_barkod_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_fis_num_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }
    }
}
