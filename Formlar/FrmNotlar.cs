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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
         OgrenciSinavEntities db=new OgrenciSinavEntities();
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            
            comboBox1.ValueMember = "DersId";
            comboBox1.DisplayMember = "DersAd";
            comboBox1.DataSource = db.TblDersler.ToList();
            comboBox2.ValueMember = "DersId";
            comboBox2.DisplayMember = "DersAd";
            comboBox2.DataSource = db.TblDersler.ToList();
        }
        //Ekleme işlemi
        private void button1_Click(object sender, EventArgs e)
        {
            TblNotlar t = new TblNotlar();
            t.Sinav1 =  byte.Parse(TxtSınav1.Text);
            t.Sinav2 =  byte.Parse(TxtSınav2.Text);
            t.Sinav3 =  byte.Parse(TxtSınav3.Text);
            t.Quiz1 =   byte.Parse(TxtQuiz1.Text);
            t.Quiz2 =   byte.Parse(TxtQuiz2.Text);
            t.Proje=    byte.Parse(TxtProje.Text);
            t.Ders =    int.Parse(comboBox1.SelectedValue.ToString());
            t.Ogrenci = int.Parse(TxtOgrenci.Text);
            db.TblNotlar.Add(t);
            db.SaveChanges();
            MessageBox.Show("Öğrenci not bilgisi için sisteme kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            byte s1, s2, s3, q1, q2, proje;
            double ort;
            s1 = byte.Parse(TxtSınav1.Text);
            s2 = byte.Parse(TxtSınav2.Text);
            s3 = byte.Parse(TxtSınav3.Text);
            q1 = byte.Parse(TxtQuiz1.Text);
            q2 = byte.Parse(TxtQuiz2.Text);
            proje= byte.Parse(TxtProje.Text);
            ort = (s1 + s2 + s3+q1+q2+proje) / 6;
            TxtOrtalama.Text=ort.ToString();
            
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.View_1.ToList();
            dataGridView1.DataSource = db.Notlar4();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var degerler = from x in db.TblNotlar
                           select new
                           {
                               x.NotId,
                               Ogrenci_Adı = x.TblOgrenci.OgrAd +" " +  x.TblOgrenci.OgrSoyad,
                               x.Sinav1,
                               x.Sinav2,
                               x.Sinav3,
                               x.Quiz1,
                               x.Quiz2,
                               x.Proje,
                               x.Ortalama,
                               x.Ders, 
                           };
            int d = int.Parse(comboBox2.SelectedValue.ToString());
            dataGridView1.DataSource = degerler.Where(y => y.Ders==d).ToList();
            dataGridView1.Columns["Ders"].Visible= false;
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.TblNotlar
                           select new
                           {
                               x.NotId,
                               Ogrenci_Adı = x.TblOgrenci.OgrAd + " " + x.TblOgrenci.OgrSoyad,
                               x.Sinav1,
                               x.Sinav2,
                               x.Sinav3,
                               x.Quiz1,
                               x.Quiz2,
                               x.Proje,
                               x.Ortalama,
                               x.Ogrenci,
                           };
            int id = int.Parse(TxtNumara.Text);
            dataGridView1.DataSource = degerler.Where(y => y.Ogrenci == id).ToList();
        }

        private void BtnAra2_Click(object sender, EventArgs e)
        {
            string no = TxtNumara.Text;
            var deger = db.TblOgrenci.Where(x => x.OgrNumara == no).Select(y => y.OgrId).FirstOrDefault();
          //  TxtId.Text = deger.ToString();
            var notlar = from x in db.TblNotlar
                         select new
                         {
                             x.NotId,
                             Ogrenci_Adı = x.TblOgrenci.OgrAd + " " + x.TblOgrenci.OgrSoyad,
                             x.Sinav1,
                             x.Sinav2,
                             x.Sinav3,
                             x.Quiz1,
                             x.Quiz2,
                             x.Proje,
                             x.Ortalama,
                             x.Ogrenci,
                         };
            dataGridView1.DataSource = notlar.Where(z => z.Ogrenci == deger).ToList();
            dataGridView1.Columns["Ogrenci"].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtQuiz1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtQuiz2.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
           // comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
           // TxtOgrenci.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var x = db.TblNotlar.Find(id);
            x.NotId = int.Parse(TxtId.Text);
            x.Sinav1 = int.Parse(TxtSınav1.Text);
            x.Sinav2 = int.Parse(TxtSınav2.Text);
            x.Sinav3 = int.Parse(TxtSınav3.Text);
            x.Quiz1= int.Parse(TxtQuiz1.Text);
            x.Quiz2=int.Parse(TxtQuiz2.Text);
            x.Proje = int.Parse(TxtProje.Text);
            x.Ortalama = int.Parse(TxtOrtalama.Text);
            x.Ders = int.Parse(comboBox1.SelectedValue.ToString());
            x.Ogrenci = int.Parse(TxtOgrenci.Text);
            db.SaveChanges();
            MessageBox.Show("Öğrenci başarılı bir şekilde güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
