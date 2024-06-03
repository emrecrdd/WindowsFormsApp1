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
    public partial class Form3 : Form
    {
        ProjeEntities1 entities = new ProjeEntities1 ();

        public Form3()
        {
            InitializeComponent();
        }

        private void buttonListeleme_Click(object sender, EventArgs e)
        {
            tümkayitlarigoster();
        }

        private void tümkayitlarigoster()
        {
            var musterileri=entities.Musteri.ToList();
            dataGridView1.DataSource = musterileri;
            dataGridView1.ClearSelection();
            Temizle();
            
        }

        private void Temizle()
        {
            textBoxAd.Clear();
            textBoxSoyad.Clear();
            textBoxSehir.Clear();
            textBoxMusteriId.Text="0";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            tümkayitlarigoster();
            textBoxMusteriId.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Musteri musteri =new Musteri();
            musteri.Ad = textBoxAd.Text;
            musteri.Soyad = textBoxSoyad.Text;
            musteri.Sehir= textBoxSehir.Text;
            try
            {
                entities.Musteri.Add(musteri);
                entities.SaveChanges();
                MessageBox.Show("Müşteri Kaydı Eklendi");
                tümkayitlarigoster();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı İşlemleri Sırasında Hata Oluştu, HataKodu:H001\n + "+ ex.Message);
                
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilensatir = dataGridView1.SelectedCells[0].RowIndex;
            textBoxMusteriId.Text = dataGridView1.Rows[secilensatir].Cells[0].Value.ToString();
            textBoxAd.Text = dataGridView1.Rows[secilensatir].Cells[1].Value.ToString();
            textBoxSoyad.Text = dataGridView1.Rows[secilensatir].Cells[2].Value.ToString();
            textBoxSehir.Text = dataGridView1.Rows[secilensatir].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int musteriId = Convert.ToInt32(textBoxMusteriId.Text);
                var musteri=entities.Musteri.Find(musteriId);
                entities.Musteri.Remove(musteri);
                entities.SaveChanges();
                MessageBox.Show("Müşteri Kaydı Silindi");
                tümkayitlarigoster();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Veritabanı İşlemleri Sırasında Hata Oluştu, HataKodu:H002\n + " + ex.Message);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int musterino = Convert.ToInt32(textBoxMusteriId.Text);
                var musteri=entities.Musteri.Find(musterino);
                musteri.Ad=textBoxAd.Text;
                musteri.Soyad=textBoxSoyad.Text;
                musteri.Sehir=textBoxSehir.Text;
                entities.SaveChanges();
                MessageBox.Show("Müşteri Bilgileri Güncellendi");
                tümkayitlarigoster();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı İşlemleri Sırasında Hata Oluştu, Hata Kodu:H003\n +" + ex.Message);
                
            }
        }
    }
}
