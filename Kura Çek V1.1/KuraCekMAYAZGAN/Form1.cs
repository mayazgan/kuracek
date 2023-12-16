using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace KuraCekMAYAZGAN
{
    public partial class kuracek : Form
    {
        public kuracek()
        {
            InitializeComponent();
        }

        DialogResult dialog;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dialog = MessageBox.Show("Kapatmak istediðinize emin misiniz?", "Çýkýþ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else { }
        }

        private void kuracek_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void kuracek_Load(object sender, EventArgs e)
        {
            textBox1.Select();
            if (checkBox1.Checked == true)
            {
                label3.Visible = true;
                numericUpDown1.Visible = true;
            }
            else
            {
                label3.Visible = false;
                numericUpDown1.Visible = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label3.Visible = true;
                numericUpDown1.Visible = true;
            }
            else
            {
                label3.Visible = false;
                numericUpDown1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Ýsim Boþ Olarak Kuraya Ekleme Yapýlamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                listBox1.Items.Add(textBox1.Text.ToString());
                textBox1.Clear();
                textBox1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                string kackisi = numericUpDown1.Text;
                int[] kisiler = new int[listBox1.Items.Count];
                Random rnd = new Random();
                int i = 0;
                if (Convert.ToInt16(kackisi) == 0)
                {
                    MessageBox.Show("Kiþi Sayýsý Sýfýr (0) Olarak Kura Çekilemez!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToInt16(numericUpDown1.Text) > listBox1.Items.Count)
                {
                    MessageBox.Show("Kiþi Sayýsý Kuradakilerin Sayýsýndan Çok Olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToInt16(numericUpDown1.Text) == listBox1.Items.Count)
                {
                    MessageBox.Show("Üzgünüm, Þu An Eþit Sayýda Kura Çekimi Yapýlamamakta!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (listBox1.Items.Count > 0 && Convert.ToInt16(numericUpDown1.Text) == listBox1.Items.Count)
                    {
                        while (i < Convert.ToInt16(kackisi))
                        {
                            int secim = rnd.Next(0, listBox1.Items.Count);
                            if (Array.IndexOf(kisiler, secim) == -1)
                            {
                                kisiler[i] = secim;
                                coklukura.Text += listBox1.Items[secim] + "\n";
                                i++;
                            }
                        }
                        MessageBox.Show(coklukura.Text, "Seçilen Kiþiler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        coklukura.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Kura Listesi Boþ Olarak Kura Çekilemez!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                if (listBox1.Items.Count > 0)
                {
                    int adet = listBox1.Items.Count;
                    Random rnd = new Random();
                    int kura = rnd.Next(0, adet);
                    listBox1.SelectedIndex = kura;
                    MessageBox.Show(listBox1.SelectedItem.ToString(), "Seçilen Kiþi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listBox1.SelectedItems.Clear();
                }
                else
                {
                    MessageBox.Show("Kura Listesi Boþ Olarak Kura Çekilemez!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
            }
            else
            {
                MessageBox.Show("Kura Listesi Zaten Boþ!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int secili = listBox1.SelectedItems.Count;
            if (secili == 0)
            {
                MessageBox.Show("Seçili Öðe Yok!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }
    }
}
