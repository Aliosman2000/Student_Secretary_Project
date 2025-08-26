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
using Proje_Ogrenci_Akademisyen.Entity;

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db=new OgrenciSinavEntities(); 

        void Listele()
        {
            var degerler = from x in db.TblOgrenci
                           select new
                           {
                               x.OgrId,
                               x.OgrAd,
                               x.OgrSoyad,
                               x.OgrNumara,
                               x.OgrSifre,
                               x.OgrMail,
                               x.OgrResim,
                               x.OgrBolum,
                               x.TblBolum.BolumAd,
                               x.OgrDurum,

                           };
            dataGridView1.DataSource = degerler.Where(x => x.OgrDurum==true).ToList();
            dataGridView1.Columns["Ogrbolum"].Visible = false;
            dataGridView1.Columns["OgrDurum"].Visible = false;
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-7KLITDS\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True");
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            //  dataGridView1.DataSource=db.TblOgrenci.ToList();
             Listele();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select * from TblBolum", baglanti);
            SqlDataAdapter dt = new SqlDataAdapter(komut2);
            DataTable dr = new DataTable();
            dt.Fill(dr);
            comboBox1.ValueMember = "BolumID";
            comboBox1.DisplayMember = "BolumAd";
            comboBox1.DataSource = dr;
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

            TxtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtNumara.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                TxtSifre.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                TxtSifre2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                TxtMail.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            //TxtResim.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

            var cellValue7 = dataGridView1.Rows[e.RowIndex].Cells[7].Value;

            if (cellValue7 != null)
            {
                comboBox1.SelectedValue = cellValue7.ToString();
            }
            else
            {

                comboBox1.SelectedIndex = -1;
            }

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var x = db.TblOgrenci.Find(id);
            x.OgrDurum = false;
            db.SaveChanges();
            MessageBox.Show("Öğrenci başarılı bir şekilde sistemden silindi," +
            "silinen öğrencilere pasif öğrenciler listesi üzerinden erişim sağlayabilirsiniz.",
            "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int k = int.Parse(TxtId.Text);
            var x = db.TblOgrenci.Find(k);
            x.OgrId = int.Parse(TxtId.Text);
            x.OgrAd = TxtAd.Text;
            x.OgrSoyad = TxtSoyad.Text;
            x.OgrNumara = TxtNumara.Text;
            x.OgrSifre = TxtSifre.Text;
            x.OgrMail = TxtMail.Text;
            x.OgrResim= TxtResim.Text;
            x.OgrBolum = int.Parse(comboBox1.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Öğrenci başarılı bir şekilde güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();

        }

        private void BtnResimSec_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            TxtResim.Text = openFileDialog1.FileName;
        }
    }
}
