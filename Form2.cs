using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        ProjeEntities1 entities = new ProjeEntities1();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tümkayitlarigoster();

        }
        private void tümkayitlarigoster()
        {
            var urunler = entities.Urun.ToList();
            dataGridView1.DataSource = urunler;
            dataGridView1.ClearSelection();
            Temizle();

        }

        private void Temizle()
        {
            textBoxUrunAd.Clear();
            textBoxFiyat.Clear();
            textBoxUrunId.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Urun urun = new Urun();
            urun.Adi = textBoxUrunAd.Text;
            urun.Fiyati = Convert.ToInt32(textBoxFiyat.Text);
            try
            {
                entities.Urun.Add(urun);
                entities.SaveChanges();
                MessageBox.Show("Ürün Kaydı Eklendi");
                tümkayitlarigoster();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı İşlemleri Sırasında Hata Oluştu, HataKodu:H010\n + " + ex.Message);

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilensatir = dataGridView1.SelectedCells[0].RowIndex;
            textBoxUrunId.Text = dataGridView1.Rows[secilensatir].Cells[0].Value.ToString();
            textBoxUrunAd.Text = dataGridView1.Rows[secilensatir].Cells[1].Value.ToString();
            textBoxFiyat.Text = dataGridView1.Rows[secilensatir].Cells[2].Value.ToString();
          
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            tümkayitlarigoster();
            textBoxUrunId.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int urunId = Convert.ToInt32(textBoxUrunId.Text);
                var urun = entities.Urun.Find(urunId);
                entities.Urun.Remove(urun);
                entities.SaveChanges();
                MessageBox.Show("Ürün Kaydı Silindi");
                tümkayitlarigoster();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Veritabanı İşlemleri Sırasında Hata Oluştu, HataKodu:H011\n + " + ex.Message);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int urunno = Convert.ToInt32(textBoxUrunId.Text);
                var urun = entities.Urun.Find(urunno);
                urun.Adi = textBoxUrunAd.Text;
                urun.Fiyati = Convert.ToInt32(textBoxFiyat.Text);
              ;
                entities.SaveChanges();
                MessageBox.Show("Ürün Bilgileri Güncellendi");
                tümkayitlarigoster();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı İşlemleri Sırasında Hata Oluştu, Hata Kodu:H012 \n +" + ex.Message);

            }
        }
    }
}
