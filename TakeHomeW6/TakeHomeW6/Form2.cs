using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakeHomeW6
{
    public partial class Form2 : Form
    {
        List<Button> buttons = new List<Button>();
        List<string> wordList = new List<string>();
        Random random = new Random();
        public int a;
        public bool menang = false;
        string tebak = "";
        int baris = 0;
        int kolom = -1;
        string path = @"Wordle Word List.txt";
        string content = "";
        string jawaban = "";
        int hurufbenar = 0;
        int totaltebak = 0;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                content = reader.ReadToEnd();
            }
            
            string[] words = content.Split(',');
            wordList = words.ToList();

            jawaban = wordList[random.Next(wordList.Count)];
            //kalo mau buat cek jawaban garis miring dibawah ilangin ya kk asdos ganteng
            MessageBox.Show(jawaban);

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(40, 40);
                    button.Location = new Point(40 * j + 60, 40 * i + 30);
                    buttons.Add(button);
                    Controls.Add(buttons[buttons.Count - 1]);
                    button.Click += new EventHandler(button15_Click_1);
                }
            }
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            if (menang)
            {
                return;
            }

            if (!(sender is Button))
            {
                return;
            }

            Button button = (Button)sender;
            if (tebak.Length >= 5)
            {
                return;
            }

            string key = button.Text;
            tebak += key;
            int emptyButtonIndex = buttons.FindIndex(x => string.IsNullOrEmpty(x.Text));
            if (emptyButtonIndex == -1)
            {
                return;
            }

            buttons[emptyButtonIndex].Text = key;
            kolom = emptyButtonIndex % 5;
        }
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (menang)
            {
                return;
            }

            if (tebak.Length < 5)
            {
                MessageBox.Show("Kepanjangan", "Error");
                return;
            }

            bool jawabanBenar = true;
            int hurufbenar = 0;
            for (int i = 0; i < 5; i++)
            {
                if (jawaban[i] == tebak.ToLower()[i])
                {
                    buttons[baris * 5 + i].BackColor = Color.Green;
                    hurufbenar++;
                }
                else if (jawaban.Contains(tebak.ToLower()[i]))
                {
                    buttons[baris * 5 + i].BackColor = Color.Yellow;
                    jawabanBenar = false;
                }
                else
                {
                    buttons[baris * 5 + i].BackColor = Color.White;
                    jawabanBenar = false;
                }
            }

            totaltebak++;
            tebak = "";

            kolom++;
            baris++;

            if (hurufbenar == 5)
            {
                menang = true;
                MessageBox.Show("Menang! Jawabannya: " + jawaban);
            }
            else if (totaltebak == a || jawabanBenar)
            {
                MessageBox.Show("Kalah! Jawabannya: " + jawaban);
            }
            else if (!wordList.Contains(tebak.ToLower()))
            {
                MessageBox.Show(tebak + " tidak ditemukan", "Error");
                kolom = -1;
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (menang)
            {
                return;
            }

            for (int i = buttons.Count - 1; i >= 0; i--)
            {
                if (buttons[i].Text != "")
                {
                    buttons[i].Text = "";
                    kolom = i % 5;
                    tebak = tebak.Remove(tebak.Length - 1);
                    break;
                }
            }
        }
    }
}
