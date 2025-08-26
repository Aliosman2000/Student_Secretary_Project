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
    public partial class FrmBolumListesi : Form
    {
        public FrmBolumListesi()
        {
            InitializeComponent();
        }


        OgrenciSinavEntities db = new OgrenciSinavEntities();

        private void FrmBolumListesi_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.TblBolum.ToList();
            var x = from y in db.TblBolum
                    select new
                    {
                        y.BolumID,
                        y.BolumAd
                    };
            dataGridView1.DataSource = x.ToList();
        }
    }
}