using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmHarita : Form
    {
        public FrmHarita()
        {
            InitializeComponent();
        }

        private void PnlDersListesi_Click(object sender, EventArgs e)
        {
            FrmDersListesi frm =new FrmDersListesi();
            frm.Show();
        }
        //frmBolumListesi
        private void panel1_Click(object sender, EventArgs e)
        {
            FrmBolumListesi frm = new FrmBolumListesi();
            frm.Show();
        }

        private void PnlYeniBolum_Click(object sender, EventArgs e)
        {
            FrmBolumler fr=new FrmBolumler();
            fr.Show();
        }

        private void PnlNotlarForm_Click(object sender, EventArgs e)
        {
            FrmNotlar frm = new FrmNotlar();
            frm.Show();
        }

        private void PnlOgrenciFormu_Click(object sender, EventArgs e)
        {
            FrmOgrenci fr=new FrmOgrenci();
            fr.Show();
        }

        private void PnlOgrenciKayit_Click(object sender, EventArgs e)
        {
            FrmOgrenciKayit frm = new FrmOgrenciKayit();
            frm.Show();

        }

        private void PnlYardim_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Bu proje, kapsamlı bir yazılım geliştirme müfredatı çerçevesinde, " +
                "edindiğim C# programlama, nesneye yönelik programlama ve veritabanı " +
                "yönetimi bilgilerini bir araya getirdiğim bir final projesidir." +
                " Projenin ana amacı, akademisyen ve öğrenci kullanıcı türlerine özel erişim yetkileriyle donatılmış," +
                "işlevsel bir veri tabanlı yönetim sistemi oluşturmaktı." +
                "\r\n\r\nSistem, iki temel kullanıcı rolüne sahiptir:\r\n\r\nAkademisyen: " +
                "Projenin tüm yönetimsel yetkilerine sahip olan bu kullanıcı, " +
                "sisteme kullanıcı adı: 00000 ve şifre: 000 ile giriş yapar. " +
                "Akademisyen paneli üzerinden öğrenci, ders, bölüm ve sınav notları gibi tüm kritik verileri yönetebilir." +
                "\r\n\r\nÖğrenci kaydı oluşturma/güncelleme/silme\r\n\r\nDersleri ve bölümleri tanımlama\r\n\r\n" +
                "Sınav notlarını girme ve düzenleme\r\n\r\nDersler ve öğrenciler arasındaki ilişkileri kurma\r\n\r\nÖğrenci: " +
                "Sisteme giriş yaptığında yalnızca kendi bilgilerine ve sınav notlarına erişebilir. " +
                "Bu, veri güvenliğini ve kullanıcıya özel erişim kontrolünü sağlayan önemli bir özelliktir. " +
                "Öğrenci, kendi profilini ve aldığı derslerin notlarını görüntüleyebilir, " +
                "ancak herhangi bir veride değişiklik yapamaz.\r\n\r\nProje, " +
                "şu ana kadar öğrendiğim temel C# konularını pekiştirmenin yanı sıra, " +
                "gerçek dünya senaryolarına uygun bir yazılım mimarisi kurma becerimi de geliştirmemi sağladı. " +
                "Veritabanı entegrasyonu sayesinde verilerin kalıcı olarak saklanması, " +
                "programın her çalıştığında tutarlı ve güncel bilgilere erişilmesini mümkün kıldı.",
                 "Yardım Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void PnlYeniDers_Click(object sender, EventArgs e)
        {
            FrmYeniDers fr = new FrmYeniDers();
            fr.Show();

        }

        private void PnlÇıkışYap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
