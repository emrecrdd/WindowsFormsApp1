﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 ürünForm=new Form2();
            ürünForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 musteriForm=new Form3();
            musteriForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 siparisForm=new Form4();
            siparisForm.Show();
        }
    }
}
