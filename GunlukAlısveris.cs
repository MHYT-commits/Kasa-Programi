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
    public partial class GunlukAlısveris : Form
    {
        public GunlukAlısveris()
        {
            InitializeComponent();
        }
        string con = "Data Source=DESKTOP-V8MR49H\\SQLEXPRESS;Initial Catalog=AlısVerisDB;Integrated Security=True;";
        int alisveris_sayisi = 0;
        private void GunlukAlısveris_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(con);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("Select COUNT(*) From sys.tables", sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                alisveris_sayisi = Convert.ToInt32(sqlDataReader[0]);
            }
            sqlConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) >= alisveris_sayisi || Convert.ToInt32(textBox1.Text) <= 0 || textBox1.Text == null) 
            {
                MessageBox.Show("Geçerli bir fiş numarası giriniz.");
                return;
            }
            SqlConnection sqlConnection = new SqlConnection(con);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * From FisNo_"+textBox1.Text+"", sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sqlDataReader);
            dataGridView1.DataSource = dt;


            sqlConnection.Close();
           
        }
    }
}
