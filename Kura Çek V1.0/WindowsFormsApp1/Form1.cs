using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                int adet = listBox1.Items.Count;
                Random rnd = new Random();
                int sayi = rnd.Next(0, adet);
                listBox1.SelectedIndex = sayi;
                MessageBox.Show(listBox1.SelectedItem.ToString(), "Seçilen Kişi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kura Listesi Boş Olarak Kura Çekilemez!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("İsim Boş Olarak Kuraya Ekleme Yapılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                listBox1.Items.Add(textBox1.Text.ToString());
                textBox1.Clear();
                textBox1.Focus();
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0) {
                listBox1.Items.Clear();
            }
            else
            {
                MessageBox.Show("Kura Listesi Zaten Boş!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        DialogResult dialog;
        private void pictureBox1_Click(object sender, EventArgs e)
        {            
            dialog = MessageBox.Show("Kapatmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else { }            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else {
                e.Cancel = true;
            }
            
        }
    }
}
