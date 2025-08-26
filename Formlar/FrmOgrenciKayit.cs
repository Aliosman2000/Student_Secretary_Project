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
using Proje_Ogrenci_Akademisyen.Entity;

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmOgrenciKayit : Form
    {
        public FrmOgrenciKayit()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-7KLITDS\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True");
        private void FrmOgrenciKayit_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TblBolum", baglanti);
            SqlDataAdapter dt = new SqlDataAdapter(komut);
            DataTable dk = new DataTable();
            dt.Fill(dk);
            comboBox1.ValueMember = "BolumId";
            comboBox1.DisplayMember = "BolumAd";
            comboBox1.DataSource = dk;
        }
        OgrenciSinavEntities dt = new OgrenciSinavEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            //Kaydetme İşlemi
            if (TxtSifre.Text == TxtSifre2.Text)
            {
                TblOgrenci t = new TblOgrenci();
                t.OgrAd = TxtAd.Text;
                t.OgrSoyad = TxtSoyad.Text;
                t.OgrNumara = TxtNumara.Text;
                t.OgrSifre = TxtSifre.Text;
                t.OgrSifre = TxtSifre2.Text;
                t.OgrMail = TxtMail.Text;
                t.OgrResim = TxtResim.Text;
                t.OgrBolum = int.Parse(comboBox1.SelectedValue.ToString());
                dt.TblOgrenci.Add(t);
                dt.SaveChanges();
                MessageBox.Show("Öğrenci bilgileri sisteme başarılı bir şekilde kaydedildi", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Girdiğiniz şifreler eşleşmiyor", "Uyarı", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnResimSeç_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            TxtResim.Text = openFileDialog1.FileName;
        }
    }
}
