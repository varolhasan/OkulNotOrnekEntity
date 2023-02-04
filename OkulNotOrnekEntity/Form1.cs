using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulNotOrnekEntity
{
    public partial class Form1 : Form
    {
        public void Temizle()
        {
            TxtDersAd.Clear();
            TxtDersId.Clear();
            TxtFoto.Clear();
            TxtOgrAd.Clear();
            TxtOgrId.Clear();
            TxtSoyad.Clear();
            TxtSinav1.Clear();
            TxtSinav2.Clear();
            TxtSinav3.Clear();
            TxtOrt.Clear();
            TxtDurum.Clear();
        }
        public Form1()
        {
            InitializeComponent();
        }
        DbOgrenciSinav1Entities db = new DbOgrenciSinav1Entities();
    

        private void btnsartlılistele_Click(object sender, EventArgs e)
        {
            if (rdbtnaz.Checked)
            {
                dataGridView1.DataSource = db.TBLOGRENCI.OrderBy(x => x.AD).ToList();
            }
            if (rdbtnza.Checked)
            {
                dataGridView1.DataSource = db.TBLOGRENCI.OrderBy(x => x.AD).ToList();
            }
            if (rdbtnfirst3.Checked)
            {
                dataGridView1.DataSource = db.TBLOGRENCI.OrderBy(x => x.ID).Take(3).ToList();
            }
            if (rdbtnidlist.Checked)
            {
                dataGridView1.DataSource = db.TBLOGRENCI.Where(x => x.ID == 5).ToList();
            }
            if (rdbtnstarta.Checked)
            {
                dataGridView1.DataSource = db.TBLOGRENCI.Where(x => x.AD.StartsWith("a")).ToList();
            }
            if (rdbtnenda.Checked)
            {
                dataGridView1.DataSource = db.TBLOGRENCI.Where(x => x.AD.EndsWith("a")).ToList();
            }
            if (rdbtntoplamogr.Checked)
            {
                var toplamogrsayisi = db.TBLOGRENCI.Count();
                MessageBox.Show("Toplam Öğrenci Sayısı : " + toplamogrsayisi.ToString(), "Bilgi", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
            if (rdbtndegervarmi.Checked)
            {
                bool deger = db.TBLOGRENCI.Any();
                MessageBox.Show(deger.ToString(), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (rdbtnSinav1toplam.Checked)
            {
                var sinav1top = db.TBLNOTLAR.Where(x => x.DERS == 1).Sum(y => y.SINAV1);
                MessageBox.Show("Matematik Dersi 1.Sınavların Toplamı : " + sinav1top.ToString(), "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (rdbtnSinav1Ort.Checked)
            {
                var sinav1ort = db.TBLNOTLAR.Where(x => x.DERS == 1).Average(y => y.SINAV1);
                MessageBox.Show("Matematik Dersi 1.Sınavların Ortalaması : " + sinav1ort.ToString(), "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (rdbtnSinav1OrtYuksek.Checked)
            {
                var ortalama = db.TBLNOTLAR.Average(x => x.SINAV1);
                var sinav1ortyuksek = db.TBLNOTLAR.Where(x => x.DERS == 1 & x.SINAV1 > ortalama).ToList();
                dataGridView1.DataSource = sinav1ortyuksek;
            }
            if (rdbtnS2Ort.Checked)
            {
                var ortalama2 = db.TBLNOTLAR.Where(y => y.DERS == 1).Average(x => x.SINAV2);
                MessageBox.Show("Matematik Dersi 2.Sınavların Ortalaması : " + ortalama2.ToString(), "Matematik Dersi" +
                    " 2.Sınav Ortalaması", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (rdbtnS2Top.Checked)
            {
                var toplam2 = db.TBLNOTLAR.Where(x => x.DERS == 1).Sum(y => y.SINAV2);
                MessageBox.Show("Matematik Dersi 2.Sınavların Öğrencilerin Toplam Notu : " + toplam2.ToString(),
                    "Matematik Dersi 2.Sınavların Toplam Not Değeri", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (rdbtnS2OrtYuksek.Checked)
            {
                var ortalama2 = db.TBLNOTLAR.Where(x => x.DERS == 1).Average(y => y.SINAV2);
                var ortyuksek2 = db.TBLNOTLAR.Where(x => x.DERS == 1 & x.SINAV2 > ortalama2).ToList();
                dataGridView1.DataSource = ortyuksek2;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
            }
            if (rdbtnS3Top.Checked)
            {
                var toplam3 = db.TBLNOTLAR.Where(x => x.DERS == 1).Sum(y => y.SINAV3);
                MessageBox.Show("Matematik Dersi 3.Sınavların Öğrencilerin Toplam Notu : " + toplam3.ToString(),
                    "Matematik Dersi 3.Sınavların Toplam Not Değeri", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (rdbtnS3Ort.Checked)
            {
                var ortalama3 = db.TBLNOTLAR.Where(x => x.DERS == 1).Average(y => y.SINAV3);
                MessageBox.Show("Matematik Dersi 3.Sınavların Ortalaması : " + ortalama3.ToString(), "Matematik Dersi" +
                    " 3.Sınav Ortalaması", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (rdbtnS3OrtYuksek.Checked)
            {
                var ortalama3 = db.TBLNOTLAR.Where(x => x.DERS == 1).Average(y => y.SINAV3);
                var ortyuksek = db.TBLNOTLAR.Where(x => x.DERS == 1 & x.SINAV3 > ortalama3);
                dataGridView1.DataSource = ortyuksek.ToList();
            }
            if (rdbtnS1EnYuksek.Checked)
            {
                var enyuksek1 = db.TBLNOTLAR.Where(x => x.DERS == 1).Max(y => y.SINAV1);
                MessageBox.Show("En yüksek matematik 1.Sınav Notu : " + enyuksek1.ToString(), "1.Sınav En Yüksek Alan" +
                    " Öğrenci", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (rdbtnS2EnYuksek.Checked)
            {
                var enyuksek2 = db.TBLNOTLAR.Where(x => x.DERS == 1).Max(y => y.SINAV2);
                MessageBox.Show("En yüksek matematik 2.Sınav Notu : " + enyuksek2.ToString(), "2.Sınav En Yüksek Alan" +
                    " Öğrenci", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (rdbtnS3EnYuksek.Checked)
            {
                var enyuksek3 = db.TBLNOTLAR.Where(x => x.DERS == 1).Max(y => y.SINAV3);
                MessageBox.Show("En yüksek matematik 3.Sınav Notu : " + enyuksek3.ToString(), "3.Sınav En Yüksek Alan" +
                    " Öğrenci", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOgrListele_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TBLOGRENCI.ToList();

            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
        }

        private void btnDersListesi_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TBLDERSLER.ToList();
            dataGridView1.Columns[2].Visible = false;
        }

        private void btnNotListesi_Click_1(object sender, EventArgs e)
        {
            var sorgu = from item in db.TBLNOTLAR
                        select new
                        {
                            item.NOTID,
                            item.OGR,
                            item.DERS,
                            item.SINAV1,
                            item.SINAV2,
                            item.SINAV3,
                            item.ORTALAMA,
                            item.DURUM
                        };
            dataGridView1.DataSource = sorgu.ToList();
        }

        private void btnProcedure_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.NOTLISTESI();
        }

        private void btnBul_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TBLOGRENCI.Where(x => x.AD == TxtOgrAd.Text && x.SOYAD == TxtSoyad.Text).ToList();
        }

        private void TxtOgrAd_TextChanged_1(object sender, EventArgs e)
        {
            string aranan = TxtOgrAd.Text;
            var sorgu = from item in db.TBLOGRENCI
                        where item.AD.Contains(aranan)
                        select item;
            dataGridView1.DataSource = sorgu.ToList();
        }

        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {
            if (TxtOgrId.Text != "")
            {
                int id = Convert.ToInt32(TxtOgrId.Text);
                var ogr = db.TBLOGRENCI.Find(id);
                ogr.AD = TxtOgrAd.Text;
                ogr.SOYAD = TxtSoyad.Text;
                ogr.FOTOGRAF = TxtFoto.Text;
                db.SaveChanges();
                MessageBox.Show("Öğrenci Güncellenmiştir.", "Güncelleme İşlemi Başarılı", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                dataGridView1.DataSource = db.TBLOGRENCI.ToList();
                Temizle();
            }
            if (TxtDersId.Text != "")
            {
                int id = Convert.ToInt32(TxtDersId.Text);
                var ders = db.TBLDERSLER.Find(id);
                ders.DERSAD = TxtDersAd.Text;
                db.SaveChanges();
                MessageBox.Show("Ders Güncellenmiştir.", "Güncelleme İşlemi Başarılı", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                dataGridView1.DataSource = db.TBLDERSLER.ToList();
                Temizle();
            }
        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            if (TxtOgrAd.Text != "")
            {
                int id = Convert.ToInt32(TxtOgrId.Text);
                var ogr = db.TBLOGRENCI.Find(id);
                db.TBLOGRENCI.Remove(ogr);
                db.SaveChanges();
                MessageBox.Show("Öğrenci Başarıyla Silindi.", "Silme İşlemi Başarılı.", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                dataGridView1.DataSource = db.TBLOGRENCI.ToList();
                Temizle();
            }
        }

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            if (TxtOgrAd.Text != "")
            {
                TBLOGRENCI t = new TBLOGRENCI();
                t.AD = TxtOgrAd.Text;
                t.SOYAD = TxtSoyad.Text;
                t.FOTOGRAF = TxtFoto.Text;
                db.TBLOGRENCI.Add(t);
                db.SaveChanges();
                MessageBox.Show("Yeni öğrenci başarıyla eklenmiştir.", "İşlem Başarılı", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                dataGridView1.DataSource = db.TBLOGRENCI.ToList();
                Temizle();
            }
            if (TxtDersAd.Text != "")
            {
                TBLDERSLER t = new TBLDERSLER();
                t.DERSAD = TxtDersAd.Text;
                db.TBLDERSLER.Add(t);
                db.SaveChanges();
                MessageBox.Show("Ders başarıyla eklenmiştir.", "İşlem Başarılı", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                dataGridView1.DataSource = db.TBLDERSLER.ToList();
                Temizle();
            }
        }

        private void btnListele1_Click(object sender, EventArgs e)
        {
            if (rdbtnS1EnDusuk.Checked)
            {
                var endusuk1 = db.TBLNOTLAR.Where(x => x.DERS == 1).Min(y => y.SINAV1);
                MessageBox.Show("Matematik Dersi 1.Sınav En Düşük Not : " + endusuk1.ToString(), "1.Sınav En Düşük Not",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (rdbtnS2EnDusuk.Checked)
            {
                var endusuk2 = db.TBLNOTLAR.Where(x => x.DERS == 1).Min(y => y.SINAV2);
                MessageBox.Show("Matematik Dersi 2.Sınav En Düşük Not : " + endusuk2.ToString(), "2.Sınav En Düşük Not",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (rdbtnS3EnDusuk.Checked)
            {
                var endusuk3 = db.TBLNOTLAR.Where(x => x.DERS == 1).Min(y => y.SINAV3);
                MessageBox.Show("Matematik Dersi 3.Sınav En Düşük Not : " + endusuk3.ToString(), "3.Sınav En Düşük Not",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (rdbtnS3EnDusukList.Checked)
            {
                var endusuk = db.TBLNOTLAR.Where(x => x.DERS == 1).Min(y => y.SINAV3);
                var ogr = db.TBLNOTLAR.Where(x => x.SINAV3 == endusuk & x.DERS == 1);
                int id = Convert.ToInt32(ogr.Min(z => z.OGR));
                var endusukogrlistele = from d1 in db.TBLNOTLAR.Where(x => x.NOTID == id)
                                        join d2 in db.TBLDERSLER
                                        on d1.DERS equals d2.DERSID
                                        join d3 in db.TBLOGRENCI
                                        on d1.OGR equals d3.ID
                                        select new
                                        {
                                            d1.NOTID,
                                            Öğrenci = d3.AD + " " + d3.SOYAD,
                                            d2.DERSAD,
                                            d1.SINAV1,
                                            d1.SINAV2,
                                            d1.SINAV3,
                                            d1.ORTALAMA,
                                            d1.DURUM
                                        };
                dataGridView1.DataSource = endusukogrlistele.ToList();
            }
        }
    }
}
