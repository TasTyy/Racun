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

        OsebniRacun osebniRacun = new OsebniRacun();
        ValutniRacun valutniRacun = new ValutniRacun();
        PoslovniRacun poslovniRacun = new PoslovniRacun();

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

                osebniRacun.imeLastnika = imeLastnika;
                osebniRacun.stanje = stanje;
                osebniRacun.limit = limit;
                osebniRacun.varcevalni = varcevalni;
                osebniRacun.obrestnaMera = obrestnaMera;

                stanjeLabel.Text = "Stanje: " + stanje;

                obrestnaMeraLabel.Text = "Obrestna mera: " + obrestnaMera;

                groupBox5.Enabled = true;
                groupBox6.Enabled = true;
                groupBox7.Enabled = true;
                groupBox8.Enabled = false;
                groupBox9.Enabled = false;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                // Valutni račun

                string primarnaValuta = comboBox2.Text;

                valutniRacun.imeLastnika = imeLastnika;
                valutniRacun.stanje = stanje;
                valutniRacun.limit = limit;
                valutniRacun.primarnaValuta = primarnaValuta;

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

                if (radioButton1.Checked)
                {
                    tipPodjetja = radioButton1.Text;

                    poslovniRacun.imeLastnika = imeLastnika;
                    poslovniRacun.stanje = stanje;
                    poslovniRacun.limit = limit;
                    poslovniRacun.nazivPodjetja = nazivPodjetja;
                    poslovniRacun.tipPodjetja = tipPodjetja;
                }
                else if (radioButton2.Checked)
                {
                    tipPodjetja = radioButton2.Text;

                    poslovniRacun.imeLastnika = imeLastnika;
                    poslovniRacun.stanje = stanje;
                    poslovniRacun.limit = limit;
                    poslovniRacun.nazivPodjetja = nazivPodjetja;
                    poslovniRacun.tipPodjetja = tipPodjetja;
                }
                else if (radioButton3.Checked)
                {
                    tipPodjetja = radioButton3.Text;

                    poslovniRacun.imeLastnika = imeLastnika;
                    poslovniRacun.stanje = stanje;
                    poslovniRacun.limit = limit;
                    poslovniRacun.nazivPodjetja = nazivPodjetja;
                    poslovniRacun.tipPodjetja = tipPodjetja;
                }
                else if (radioButton4.Checked)
                {
                    tipPodjetja = radioButton4.Text;

                    poslovniRacun.imeLastnika = imeLastnika;
                    poslovniRacun.stanje = stanje;
                    poslovniRacun.limit = limit;
                    poslovniRacun.nazivPodjetja = nazivPodjetja;
                    poslovniRacun.tipPodjetja = tipPodjetja;
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
            string valuta = textBox5.Text;
            listBox1.Items.Add(valuta);
            comboBox2.Items.Add(valuta);

            textBox5.Text = "";
        }

        private void dvigButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                double znesek = Convert.ToDouble(textBox7.Text);
                if (osebniRacun.Dvig(znesek) == true)
                {
                    stanjeLabel.Text = "Stanje: " + osebniRacun.stanje.ToString();
                }
                else
                {
                    MessageBox.Show("Ni možno dvigni denarja!");
                }
                textBox7.Text = "";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                double znesek = Convert.ToDouble(textBox7.Text);
                if (valutniRacun.Dvig(znesek) == true)
                {
                    stanjeLabel.Text = "Stanje: " + valutniRacun.stanje.ToString();
                }
                else
                {
                    MessageBox.Show("Ni možno dvigni denarja!");
                }
                textBox7.Text = "";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                double znesek = Convert.ToDouble(textBox7.Text);
                if (poslovniRacun.Dvig(znesek) == true)
                {
                    stanjeLabel.Text = "Stanje: " + poslovniRacun.stanje.ToString();
                }
                else
                {
                    MessageBox.Show("Ni možno dvigni denarja!");
                }
                textBox7.Text = "";
            }
            
        }

        private void pologButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                double znesek = Convert.ToDouble(textBox8.Text);
                osebniRacun.Polog(znesek);
                stanjeLabel.Text = "Stanje: " + osebniRacun.stanje.ToString();

                textBox8.Text = "";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                double znesek = Convert.ToDouble(textBox8.Text);
                valutniRacun.Polog(znesek);
                stanjeLabel.Text = "Stanje: " + valutniRacun.stanje.ToString();

                textBox8.Text = "";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                double znesek = Convert.ToDouble(textBox8.Text);
                poslovniRacun.Polog(znesek);
                stanjeLabel.Text = "Stanje: " + poslovniRacun.stanje.ToString();

                textBox8.Text = "";
            }
        }

        private void likvidnoButton_Click(object sender, EventArgs e)
        {
            if (poslovniRacun.Likvidno() == true)
            {
                MessageBox.Show("Podjetje ni likvidno!");
            }
            else
            {
                MessageBox.Show("Podjetje je likvidno!");
            }
        }

        private void prihranekButton_Click(object sender, EventArgs e)
        {
            double povpMesecnoStanje = Convert.ToDouble(textBox9.Text);
            double prihranek = osebniRacun.IzracunajLetniPrihranek(povpMesecnoStanje);
            MessageBox.Show("Prihranek: " + prihranek);

            textBox9.Text = "";
        }

        private void povecajButton_Click(object sender, EventArgs e)
        {
            osebniRacun.NastaviObrestnoMero();
            obrestnaMeraLabel.Text = "Obrestna mera: " + Convert.ToString(osebniRacun.obrestnaMera);
        }

        private void zamenjajValutoButton_Click(object sender, EventArgs e)
        {
            double menjalniTecaj = Convert.ToDouble(textBox10.Text);
            valutniRacun.ZamenjajValuto(menjalniTecaj);
            stanjeLabel.Text = "Stanje: " + valutniRacun.stanje;

            textBox10.Text = "";
        }
    }
}
