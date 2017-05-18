using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aulaApp
{
    public partial class Form1 : Form
    {

        private int counter;
        Timer Timer1 = new Timer();
        int bebeto = 0;
        int tiririca = 0;
        int raoni = 0;
        int nulo = 0;

        public Form1()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            digito("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            digito("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            digito("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            digito("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            digito("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            digito("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            digito("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            digito("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            digito("9");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            digito("0");
        }

        private void digito(string v)
        {
            if (textBox1.Text.Equals(""))
            {
                playSoundBotao();
                textBox1.Text = v;
            } else if(!textBox1.Text.Equals("") && textBox2.Text.Equals(""))
            {
                playSoundBotao();
                textBox2.Text = v;
                String candidato = textBox1.Text + textBox2.Text;
                validarCandidato(candidato);
            }
        }

        private void validarCandidato(String candidato)
        {
            switch (candidato)
            {
                case "19":
                    pictureBox1.Image = Properties.Resources.Bebeto;
                    label5.Text = "Bebeto";
                    label6.Text = "PT";
                    exibirDados();
                    break;
                case "51":
                    pictureBox1.Image = Properties.Resources.Raoni;
                    label5.Text = "Raoni";
                    label6.Text = "PSDB";
                    exibirDados();
                    break;
                case "22":
                    pictureBox1.Image = Properties.Resources.Tiririca;
                    label5.Text = "Tiririca";
                    label6.Text = "PSOL";
                    exibirDados();
                    break;
                default:
                    break;

            }
            
        }
        
        private void exibirDados()
        {
            pictureBox1.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
        }
        private void limpar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            pictureBox1.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void playSoundBotao()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"..\..\img\Som_Botao.wav");
            simpleSound.Play();
        }

        private void playSimpleSound()
        {    
            SoundPlayer simpleSound = new SoundPlayer( @"..\..\img\Som_Urna.wav");
            simpleSound.Play();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals(""))
            {
                String candidato = textBox1.Text + textBox2.Text;
                if (candidato.Equals("19"))
                {
                    bebeto += 1;
                }
                else if (candidato.Equals("22"))
                {
                    tiririca += 1;
                }
                else if (candidato.Equals("51"))
                {
                    raoni += 1;
                }
                else
                {
                    nulo += 1;
                }
                limpar();
                playSimpleSound();
                votoFinalizado();
                
            }
            
        }

        private void votoFinalizado()
        {
            label10.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            counter = 0;
            Timer1.Interval = 5000;
            Timer1.Enabled = true;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
                
        }

        private void Timer1_Tick(object Sender, System.EventArgs e)
        {
            if(counter >= 10)
            {
                Timer1.Enabled = false;
                counter = 0;
            }
            else
            {
                counter += 1;
                novoVoto();
            }
        }

        private void novoVoto()
        {
            label10.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bebeto: " + bebeto + "\n" + "Raoni: " + raoni + "\n" + "Tiritica: " + tiririca + "\n" + "Nulo: " + nulo + "\n");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            votoFinalizado();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label11.Text = DateTime.Now.ToLongTimeString();
        }
    }

}
