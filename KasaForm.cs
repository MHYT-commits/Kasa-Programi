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
    public partial class KasaForm : Form
    {
        public static KasaForm instance;
        public DataGridView _dataGridView;
        public int toplam;
        public int fiyat;
        public int miktar;
        public int önecki_miktar;
        public KasaForm()
        {
            InitializeComponent();
            instance = this;
            _dataGridView = dataGridView;
        }
        public string baglanti = "Data Source=DESKTOP-V8MR49H\\SQLEXPRESS;Initial Catalog=DenemeDB;Integrated Security=True;";

        public string baglanti2= "Data Source=DESKTOP-V8MR49H\\SQLEXPRESS;Initial Catalog=AlisVeris;Integrated Security=True;";
        private void txt_Barkod_TextChanged(object sender, EventArgs e)
        {
            if (txt_Barkod.Text.Length >= txt_Barkod.MaxLength)
            {

                miktar = Convert.ToInt32(txt_Miktar.Text);
                SqlConnection sqlConnection = new SqlConnection(baglanti);

                if (txt_Miktar == null)
                {
                    miktar = 1;
                }


                sqlConnection.Open();
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    string queary = "SELECT * FROM Urunler WHERE BARKOD = '" + txt_Barkod.Text + "'";

                    SqlCommand sqlCommand = new SqlCommand(queary, sqlConnection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    

                    while (sqlDataReader.Read())
                    {
                        toplam = Convert.ToInt32(lbl_Toplam.Text);
                        fiyat = Convert.ToInt32(sqlDataReader[5]);
                        dataGridView.Rows.Add(sqlDataReader[1].ToString(), miktar.ToString(), fiyat.ToString());
                        önecki_miktar = miktar;
                        lbl_Toplam.Text = (toplam += (miktar * fiyat)).ToString();
                    }
                }
                sqlConnection.Close();
                dataGridView.Rows[0].Selected.Equals(true);
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Anamenüye dönmek istediğinize emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Hide();
                Menu menu = new Menu();
                menu.ShowDialog();
                this.Close();

            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txt_Barkod.Text.Length >= 10)
            {
                txt_Barkod.Text = txt_Barkod.Text.Remove(txt_Barkod.Text.Length - 1, 1);
            }
            txt_Barkod.Text = txt_Barkod.Text.Insert(txt_Barkod.TextLength, "1");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txt_Barkod.Text.Length >= 10)
            {
                txt_Barkod.Text = txt_Barkod.Text.Remove(txt_Barkod.Text.Length - 1, 1);
            }
            txt_Barkod.Text = txt_Barkod.Text.Insert(txt_Barkod.TextLength, "2");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txt_Barkod.Text.Length >= 10)
            {
                txt_Barkod.Text = txt_Barkod.Text.Remove(txt_Barkod.Text.Length - 1, 1);
            }
            txt_Barkod.Text = txt_Barkod.Text.Insert(txt_Barkod.TextLength, "3");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txt_Barkod.Text.Length == 10)
            {
                txt_Barkod.Text = txt_Barkod.Text.Remove(txt_Barkod.Text.Length - 1, 1);
            }
            txt_Barkod.Text = txt_Barkod.Text.Insert(txt_Barkod.TextLength, "4");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txt_Barkod.Text.Length == 10)
            {
                txt_Barkod.Text = txt_Barkod.Text.Remove(txt_Barkod.Text.Length - 1, 1);
            }
            txt_Barkod.Text = txt_Barkod.Text.Insert(txt_Barkod.TextLength, "5");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (txt_Barkod.Text.Length == 10)
            {
                txt_Barkod.Text = txt_Barkod.Text.Remove(txt_Barkod.Text.Length - 1, 1);
            }
            txt_Barkod.Text = txt_Barkod.Text.Insert(txt_Barkod.TextLength, "6");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (txt_Barkod.Text.Length == 10)
            {
                txt_Barkod.Text = txt_Barkod.Text.Remove(txt_Barkod.Text.Length - 1, 1);
            }
            txt_Barkod.Text = txt_Barkod.Text.Insert(txt_Barkod.TextLength, "7");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (txt_Barkod.Text.Length == 10)
            {
                txt_Barkod.Text = txt_Barkod.Text.Remove(txt_Barkod.Text.Length - 1, 1);
            }
            txt_Barkod.Text = txt_Barkod.Text.Insert(txt_Barkod.TextLength, "8");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (txt_Barkod.Text.Length == 10)
            {
                txt_Barkod.Text = txt_Barkod.Text.Remove(txt_Barkod.Text.Length - 1, 1);
            }
            txt_Barkod.Text = txt_Barkod.Text.Insert(txt_Barkod.TextLength, "9");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (txt_Barkod.Text.Length == 10)
            {
                txt_Barkod.Text = txt_Barkod.Text.Remove(txt_Barkod.Text.Length - 1, 1);
            }
            txt_Barkod.Text = txt_Barkod.Text.Insert(txt_Barkod.TextLength, "0");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (txt_Barkod.Text.Length != 0)
            {
                txt_Barkod.Text = txt_Barkod.Text.Remove(txt_Barkod.Text.Length - 1, 1);
            }
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            txt_Barkod.Text = "";
        }

        private void KasaForm_Load(object sender, EventArgs e)
        {
            dataGridView.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count < 0)
            {
                return;

            }
            this.Hide();
            Fis fis = new Fis();
            foreach (DataGridViewRow row in dataGridView.Rows)                
            {

                Fis.instance._dataGridView.Rows.Add(row.Cells.Cast<DataGridViewCell>().Select(c => c.Value).ToArray());
            
            }
            dataGridView.Rows.Clear();
            fis.ShowDialog();    
            this.Close();
            

        }

        private void button15_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Ürünü Listeden silmek istediğinize emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            fiyat = Convert.ToInt32(dataGridView.CurrentRow.Cells[2].Value.ToString());
            miktar = Convert.ToInt32(dataGridView.CurrentRow.Cells[1].Value.ToString());

            toplam -= miktar * fiyat;
            
            lbl_Toplam.Text = (toplam).ToString();
            
            dataGridView.Rows.Remove(dataGridView.CurrentRow);
            
            if (Int32.Parse(lbl_Toplam.Text.ToString()) < 0)           
            {
                lbl_Toplam.Text = "0";
                toplam = 0;  
            }
            dataGridView.Rows[dataGridView.Rows.Count - 1].Selected.Equals(true);


        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fiyat = Convert.ToInt32(dataGridView.CurrentRow.Cells[2].Value.ToString());
            miktar = Convert.ToInt32(dataGridView.CurrentRow.Cells[1].Value.ToString());
            txt_Miktar.Text = miktar.ToString();
        }

        
    }
}
