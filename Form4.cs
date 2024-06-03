using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        ProjeEntities1 entities = new ProjeEntities1();
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tümkayitlarigoster();
        }

        private void tümkayitlarigoster()
        {
            var siparisler=(from siparis in entities.Siparis
                            select new 
                            {
                                siparis.SiparisNo,
                                siparis.Tarih,
                                siparis.MusteriId,
                                siparis.UrunId,
                                siparis.Adet
                            }).ToList();
            dataGridView1.DataSource = siparisler;
            textBoxsiparisno.Text = "0";
            dataGridView1.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Siparis siparis = new Siparis();
                siparis.Tarih = dateTimePicker1.Value;
                siparis.MusteriId = Convert.ToInt32(comboBoxmusterid.SelectedValue.ToString());
                siparis.UrunId = Convert.ToInt32(comboBoxurunid.SelectedValue.ToString());
                siparis.Adet = Convert.ToInt32(textBoxadet.Text);
                entities.Siparis.Add(siparis);
                entities.SaveChanges();
                tümkayitlarigoster();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı İşlemleri Sırasında Hata Oluştu, Hata Kodu:H021 \n +" + ex.Message);

            }



        }

        private void Form4_Load(object sender, EventArgs e)
        {
            tümkayitlarigoster();
            var musteriler=(from musteri in entities.Musteri
                            select new
                            {
                                musteri.MusteriId,
                                musteri.Ad,
                                musteri.Soyad
                            }).ToList();
            comboBoxmusterid.ValueMember = "MusteriId";
            comboBoxmusterid.DisplayMember = "Ad" +"Soyad";
            comboBoxmusterid.DataSource = musteriler;

            var urunler = (from urun in entities.Urun
                              select new
                              {
                                  urun.UrunId,
                                  urun.Adi,
                                  urun.Fiyati
                              }).ToList();
            comboBoxurunid.ValueMember = "UrunId";
            comboBoxurunid.DisplayMember = "Adi" + "Fiyati";
            comboBoxurunid.DataSource = urunler;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilensatir = dataGridView1.SelectedCells[0].RowIndex;
            textBoxsiparisno.Text = dataGridView1.Rows[secilensatir].Cells[0].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[secilensatir].Cells[1].Value.ToString();
            int musteriId = Convert.ToInt32(dataGridView1.Rows[secilensatir].Cells[2].Value.ToString());
            comboBoxmusterid.SelectedValue = musteriId;

            int urunId = Convert.ToInt32(dataGridView1.Rows[secilensatir].Cells[3].Value.ToString());
            comboBoxurunid.SelectedValue = urunId;

            textBoxadet.Text = dataGridView1.Rows[secilensatir].Cells[4].Value.ToString();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int siparisNo = Convert.ToInt32(textBoxsiparisno.Text);
                var siparis = entities.Siparis.Find(siparisNo);
                siparis.Tarih = dateTimePicker1.Value;
                siparis.MusteriId = Convert.ToInt32(comboBoxmusterid.SelectedValue.ToString());
                siparis.UrunId = Convert.ToInt32(comboBoxurunid.SelectedValue.ToString());
                siparis.Adet = Convert.ToInt32(textBoxadet.Text);
                entities.SaveChanges();
                tümkayitlarigoster();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı İşlemleri Sırasında Hata Oluştu, Hata Kodu:H022 \n +" + ex.Message);

            }
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int siparisNo = Convert.ToInt32(textBoxsiparisno.Text);
                var siparis = entities.Siparis.Find(siparisNo);
                entities.Siparis.Remove(siparis);
                entities.SaveChanges();
                tümkayitlarigoster();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı İşlemleri Sırasında Hata Oluştu, Hata Kodu:H020 \n +" + ex.Message);
                
            }
            
        }
    }
}
