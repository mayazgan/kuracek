using System.Diagnostics;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace KuraCekMAYAZGAN
{
    public partial class kuracek : Form
    {
        public kuracek()
        {
            InitializeComponent();
        }



        string hata = "";
        string secilen = "";
        string secilenler = "";
        string isimboshata = "";
        string kisisayisi0 = "";
        string kisisayisibuyuk = "";
        string kuralistesibos = "";
        string kuralistesiboshata = "";
        string seciliogeyok = "";
        string hakkimda = "";





        DialogResult dialog;
        string cikisdialog = "";
        string cikis = "";
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dialog = MessageBox.Show(cikisdialog, cikis, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
            türkçeToolStripMenuItem_Click(sender, e);
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
                MessageBox.Show(isimboshata, hata, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                listBox1.Items.Add(textBox1.Text.ToString());
                textBox1.Clear();
                textBox1.Focus();
            }
        }

        private void Karistir<T>(T[] array)
        {
            Random rastgele = new Random();

            for (int i = array.Length - 1; i > 0; i--)
            {
                int r = rastgele.Next(0, i + 1);
                T temp = array[i];
                array[i] = array[r];
                array[r] = temp;
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
                    MessageBox.Show(kisisayisi0, hata, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToInt16(numericUpDown1.Text) > listBox1.Items.Count)
                {
                    MessageBox.Show(kisisayisibuyuk, hata, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToInt16(numericUpDown1.Text) == listBox1.Items.Count)
                {
                    listBox1.SelectionMode = SelectionMode.MultiExtended;

                    for (int x = 0; x < listBox1.Items.Count; x++)
                    {
                        listBox1.SetSelected(x, true);
                    }

                    foreach (var seciliEleman in listBox1.SelectedItems)
                    {
                        coklukuratxt.AppendText(seciliEleman.ToString() + Environment.NewLine);
                    }

                    string girilenVeriler = coklukuratxt.Text;
                    string[] veriArray = girilenVeriler.Split('\n');
                    Karistir(veriArray);

                    MessageBox.Show(string.Join(coklukuratxt.Text = "" + "", veriArray), secilenler, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    coklukuratxt.Text = "";

                    listBox1.SelectedItems.Clear();
                    listBox1.SelectionMode = SelectionMode.One;
                }
                else
                {
                    if (listBox1.Items.Count > 0)
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
                        MessageBox.Show(coklukura.Text, secilenler, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        coklukura.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(kuralistesiboshata, hata, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show(listBox1.SelectedItem.ToString(), secilen, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listBox1.SelectedItems.Clear();
                }
                else
                {
                    MessageBox.Show(kuralistesiboshata, hata, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(kuralistesibos, hata, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int secili = listBox1.SelectedItems.Count;
            if (secili == 0)
            {
                MessageBox.Show(seciliogeyok, hata, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void türkçeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dilToolStripMenuItem.Text = "Dil";
            türkçeToolStripMenuItem.Text = "Türkçe";
            ingilizceToolStripMenuItem.Text = "English";
            hakkimda = "Mahmut Abdulhadi YAZGAN\n";

            button1.Text = "Kura Çek";
            button2.Text = "Kuraya Ekle";
            button3.Text = "Kura Listesini Temizle";
            button4.Text = "Seçili Olan Kiþiyi Sil";

            checkBox1.Text = "Birden Fazla Kiþi Çek";

            label1.Text = "Kuraya Eklenilecek Ýsim";
            label2.Text = "KURA ÇEK V1.3";
            label3.Text = "Kiþi Sayýsý";

            cikisdialog = "Kapatmak istediðinize emin misiniz?";
            cikis = "Çýkýþ";

            hata = "Hata";
            secilen = "Seçilen Kiþi";
            secilenler = "Seçilen Kiþiler";
            isimboshata = "Ýsim Boþ Olarak Kuraya Ekleme Yapýlamaz!";
            kisisayisi0 = "Kiþi Sayýsý Sýfýr(0) Olarak Kura Çekilemez!";
            kisisayisibuyuk = "Kiþi Sayýsý Kuradakilerin Sayýsýndan Büyük Olamaz!";
            kuralistesibos = "Kura Listesi Zaten Boþ!";
            kuralistesiboshata = "Kura Listesi Boþ Olarak Kura Çekimi Yapýlamaz!";
            seciliogeyok = "Seçili Öðe Yok!";
        }

        private void ingilizceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dilToolStripMenuItem.Text = "Language";
            türkçeToolStripMenuItem.Text = "Türkçe";
            ingilizceToolStripMenuItem.Text = "English";
            hakkimda = "Mahmut Abdulhadi YAZGAN\n";

            button1.Text = "Draw Lots";
            button2.Text = "Add to Draw List";
            button3.Text = "Clear Draw List";
            button4.Text = "Delete Selected";

            checkBox1.Text = "Draw Multiple Lots";

            label1.Text = "Name To Be Added To The Draw";
            label2.Text = "DRAW LOTS V1.3";
            label3.Text = "How Many?";

            cikisdialog = "Are you sure you want to turn it off?";
            cikis = "Exit";

            hata = "Error";
            secilen = "Selection";
            secilenler = "Selections";
            isimboshata = "It is not possible to add to the draw with a blank name!";
            kisisayisi0 = "The number of people cannot be drawn as zero(0)!";
            kisisayisibuyuk = "The number of people cannot be greater than the number of people in the lottery!";
            kuralistesibos = "The draw list is already empty!";
            kuralistesiboshata = "It is not possible to draw lots with the draw list empty!";
            seciliogeyok = "No Items Selected!";
        }

        private void hakkýmdaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 hakkimdafrm = new Form2();
            hakkimdafrm.ShowDialog();
        }
    }
}
