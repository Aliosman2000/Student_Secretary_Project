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

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {

        }


        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-7KLITDS\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True");
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TblOgrenci where OgrNumara=@p1 and OgrSifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtNumara.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                FrmOgrenciPanel frm= new FrmOgrenciPanel();
                frm.numara = TxtNumara.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Numaranız veya şifreniz hatalı,lütfen tekrar deneyiniz","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            baglanti.Close();
        }




        private void TxtNumara_TextChanged(object sender, EventArgs e)
        {
            if (TxtNumara.Text == "00000" && TxtSifre.Text == "000")
            {
                FrmHarita frm= new FrmHarita();
                frm.Show();
                this.Hide();
            }
        }








        private void TxtSifre_TextChanged(object sender, EventArgs e)
        {
            if (TxtSifre.Text == "000" && TxtNumara.Text == "00000")
            {
                FrmHarita frm = new FrmHarita();
                frm.Show();
                this.Hide();
            }
        }
    }
}