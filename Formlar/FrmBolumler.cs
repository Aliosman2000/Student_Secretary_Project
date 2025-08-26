using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proje_Ogrenci_Akademisyen.Entity;

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        OgrenciSinavEntities dt=new OgrenciSinavEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if(TxtBolumAd.Text=="")
            {
                errorProvider1.SetError(TxtBolumAd, "Bölüm adı boş geçilemez");
            }
            else
            {
                TblBolum t=new TblBolum();
                t.BolumAd = TxtBolumAd.Text;
                dt.TblBolum.Add(t);
                dt.SaveChanges();
                MessageBox.Show("Bölüm Ekleme işlemi başarılı bir şekilde gerçekleşti","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
