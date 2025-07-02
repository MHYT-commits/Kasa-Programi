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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        public string conString = "Data Source=DESKTOP-V8MR49H\\SQLEXPRESS;Initial Catalog=DenemeDB;Integrated Security=True;";


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            KasaForm kasaForm = new KasaForm();
            kasaForm.ShowDialog();
            this.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UrunEkle urunEkle = new UrunEkle();
            urunEkle.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            KullanıcıEkle kullanıcıEkle = new KullanıcıEkle();
            kullanıcıEkle.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            UrunListesi urunListesi = new UrunListesi();
            urunListesi.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            KatogoriEkle katogoriEkle = new KatogoriEkle();
            katogoriEkle.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            GunlukAlısveris gunlukAlısveris = new GunlukAlısveris();
            gunlukAlısveris.ShowDialog();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            İade iade = new İade();
            iade.ShowDialog();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            UrunGuncelle urunGuncelle = new UrunGuncelle();
            urunGuncelle.ShowDialog();
            this.Close();
        }
    }
}
