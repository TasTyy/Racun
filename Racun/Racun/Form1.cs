using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Racun_dedovanje;

namespace Racun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
            groupBox6.Enabled = false;
            groupBox7.Enabled = false;
            groupBox8.Enabled = false;
            groupBox9.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                groupBox2.Enabled = true;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                groupBox2.Enabled = false;
                groupBox3.Enabled = true;
                groupBox4.Enabled = false;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = true;
            }
        }

        private void ustvariButton_Click(object sender, EventArgs e)
        {
            string imeLastnika = textBox1.Text;
            double stanje;
            double limit;
            Double.TryParse(textBox2.Text, out stanje);
            Double.TryParse(textBox3.Text, out limit);

            Racun_dedovanje.Racun racun = new Racun_dedovanje.Racun(imeLastnika, stanje, limit);

            if (comboBox1.SelectedIndex == 0)
            {
                // Osebni račun

                bool varcevalni;
                if (checkBox1.Checked)
                {
                    varcevalni = true;
                }
                else
                {
                    varcevalni = false;
                }

                double obrestnaMera;
                Double.TryParse(textBox4.Text, out obrestnaMera);

                OsebniRacun osebniRacun = new OsebniRacun(imeLastnika, stanje, limit, varcevalni, obrestnaMera);

                stanjeLabel.Text = "Stanje: " + stanje;

                groupBox5.Enabled = true;
                groupBox6.Enabled = true;
                groupBox7.Enabled = true;
                groupBox8.Enabled = false;
                groupBox9.Enabled = false;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                // Valutni račun

                stanjeLabel.Text = "Stanje: " + stanje;

                groupBox5.Enabled = true;
                groupBox6.Enabled = true;
                groupBox7.Enabled = false;
                groupBox8.Enabled = true;
                groupBox9.Enabled = false;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                // Poslovni račun

                string nazivPodjetja = textBox6.Text;
                string tipPodjetja;

                PoslovniRacun poslovniRacun;
                if (radioButton1.Checked)
                {
                    tipPodjetja = radioButton1.Text;
                    poslovniRacun = new PoslovniRacun(imeLastnika, stanje, limit, nazivPodjetja, tipPodjetja);
                }
                else if (radioButton2.Checked)
                {
                    tipPodjetja = radioButton2.Text;
                    poslovniRacun = new PoslovniRacun(imeLastnika, stanje, limit, nazivPodjetja, tipPodjetja);
                }
                else if (radioButton3.Checked)
                {
                    tipPodjetja = radioButton3.Text;
                    poslovniRacun = new PoslovniRacun(imeLastnika, stanje, limit, nazivPodjetja, tipPodjetja);
                }
                else if (radioButton4.Checked)
                {
                    tipPodjetja = radioButton4.Text;
                    poslovniRacun = new PoslovniRacun(imeLastnika, stanje, limit, nazivPodjetja, tipPodjetja);
                }

                stanjeLabel.Text = "Stanje: " + stanje;

                groupBox5.Enabled = true;
                groupBox6.Enabled = true;
                groupBox7.Enabled = false;
                groupBox8.Enabled = false;
                groupBox9.Enabled = true;
            }
        }

        private void dodajButton_Click(object sender, EventArgs e)
        {
            //ne razumem
            string valuta = textBox5.Text;
            List<string> seznamValut = new List<string>();
            seznamValut.Add(valuta);
            
        }

        private void dvigButton_Click(object sender, EventArgs e)
        {
            string imeLastnika = textBox1.Text;
            double stanje;
            double limit;
            bool varcevalni;
            if (checkBox1.Checked)
            {
                varcevalni = true;
            }
            else
            {
                varcevalni = false;
            }
            double obrestnaMera;
            double znesek;
            Double.TryParse(textBox7.Text, out znesek);
            Double.TryParse(textBox2.Text, out stanje);
            Double.TryParse(textBox3.Text, out limit);
            Double.TryParse(textBox4.Text, out obrestnaMera);

            OsebniRacun r = new OsebniRacun(imeLastnika, stanje, limit, varcevalni, obrestnaMera);
            r.Dvig(stanje, znesek);
            MessageBox.Show(stanje.ToString());
            stanjeLabel.Text = "Stanje: " + stanje;
        }

        private void pologButton_Click(object sender, EventArgs e)
        {
            string imeLastnika = textBox1.Text;
            double stanje;
            double limit;
            double znesek;
            Double.TryParse(textBox8.Text, out znesek);
            Double.TryParse(textBox2.Text, out stanje);
            Double.TryParse(textBox3.Text, out limit);

            Racun_dedovanje.Racun r = new Racun_dedovanje.Racun(imeLastnika, stanje, limit);
            r.Polog(stanje, znesek);
            MessageBox.Show(stanje.ToString());
            stanjeLabel.Text = "Stanje: " + stanje;
        }
    }
}
