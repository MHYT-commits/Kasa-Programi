using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KasaSistem_Master
{
    public partial class Fis : Form
    {
        public static Fis instance;
        public DataGridView _dataGridView;
        public DataTable DataTable;
        string con = "Data Source=DESKTOP-V8MR49H\\SQLEXPRESS;Initial Catalog=AlısVerisDB;Integrated Security=True;";

        string cellval = "";
        int toplam = 0;
        int fis_numarası = 0;

        public Fis()
        {
            InitializeComponent();
            instance = this;
            _dataGridView = dataGridView;

        }

        private void Fis_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(con);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("Select COUNT(*) From sys.tables", sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                fis_numarası = Convert.ToInt32(sqlDataReader[0]);
            }
            sqlConnection.Close();
            for (int i = 0; i < dataGridView.Rows.Count; i++) 
            {
                if(dataGridView.Rows[i].Cells[2].Value != null)
                {
                    toplam += Int32.Parse(dataGridView.Rows[i].Cells[2].Value.ToString());
                }
                else 
                {
                    continue;
                }
                 
            }
                
            label1.Text = toplam.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection sqlConnection = new SqlConnection(con);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("CREATE TABLE FisNo_"+fis_numarası.ToString()+" \r\n(\r\n\tUrunAdi nvarchar(20),\r\n\tMiktar int,\r\n\tFiyat decimal(10,2)\r\n\r\n);", sqlConnection);
            sqlCommand.ExecuteNonQuery();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                   
                    string urunAdi = row.Cells[0].Value.ToString();
                    int miktar = Convert.ToInt32(row.Cells[1].Value);
                    decimal fiyat = Convert.ToDecimal(row.Cells[2].Value) * miktar;
                    sqlCommand = new SqlCommand("INSERT INTO FisNo_"+fis_numarası.ToString()+" (UrunAdi,Miktar,Fiyat) VALUES (@UrunAdi,@Miktar,@Fiyat)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@UrunAdi", urunAdi);
                    sqlCommand.Parameters.AddWithValue("@Miktar", miktar);
                    sqlCommand.Parameters.AddWithValue("@Fiyat", fiyat);
                    sqlCommand.ExecuteNonQuery();
                }
                
            }

            //for (int i = 0; i < dataGridView.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dataGridView.Columns.Count-1; j++)
            //    {
            //        if (dataGridView.Rows[i].Cells[j].Value != null)
            //        {

            //            cellval += dataGridView.Rows[i].Cells[j].Value.ToString();
            //        }
            //        else
            //        {
            //            continue;
            //        }
            //    }


            //}

            //sqlCommand.Parameters.AddWithValue("@Ürünler", cellval);
            //sqlCommand.Parameters.AddWithValue("@Toplam", toplam);
            //sqlCommand.ExecuteNonQuery();


            sqlConnection.Close();
            MessageBox.Show("Fiş Yazdırıldı");

            this.Hide();
            KasaForm KasaForm = new KasaForm();
            KasaForm.ShowDialog();
            this.Close();
        }
    }
}
