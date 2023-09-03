using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1ErsinTayanc
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public Form1()
        {
            InitializeComponent();
        }

        void MusteriGetir()
        {
            baglanti = new SqlConnection("server=.; Initial Catalog=WebSitesi;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("Select *From dbo.Musteri", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MusteriGetir();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtNo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtTel.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete From dbo.Musteri Where mno=@no";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@no", Convert.ToInt32(txtNo.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MusteriGetir();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string sorgu = "Update dbo.Musteri Set ad=@ad,soyad=@soyad,tarih=@dtarih,tel=@tel Where mno=@no";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@no", Convert.ToInt32(txtNo.Text));
            komut.Parameters.AddWithValue("@ad", txtAd.Text);
            komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@dtarih", dateTimePicker.Value);
            komut.Parameters.AddWithValue("@tel", txtTel.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MusteriGetir();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string sorgu = "Insert into dbo.Musteri (ad,soyad,tarih,tel) values (@ad,@soyad,@tarih,@tel)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ad", txtAd.Text);
            komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@tarih", dateTimePicker.Value);
            komut.Parameters.AddWithValue("@tel", txtTel.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MusteriGetir();
        }
    }
}
