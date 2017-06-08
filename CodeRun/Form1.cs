using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;

namespace CodeRun {
    public partial class Form1 : Form {
        private List<Entry> arrivi;
        private Stopwatch stopwatch;

        public Form1() {
            InitializeComponent();
            stopwatch = new Stopwatch();
            arrivi = new List<Entry>();
        }

        private void Form1_Load(object sender, EventArgs e) {
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            groupBox1.Enabled = false;
            groupBox5.Enabled = false;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e){
            if (textBox1.Text.Contains(Environment.NewLine)) {
                textBox1.Text = textBox1.Text.Replace(Environment.NewLine, ""); //Toglie l'invio
                bool found = false;

                for (int i = 0; i < arrivi.Count; i++) { //Cerca eventuali duplicati per non inserirli nuovamente
                    if (arrivi[i].getPettorale() == textBox1.Text)
                        found = true;
                }

                if (!found) {                
                    arrivi.Add(new Entry(textBox1.Text, arrivi.Count + 1, label11.Text, label13.Text));
                    listBox1.Items.Add(arrivi[arrivi.Count - 1].getPettorale()); //Aggiunge alla ListBox l'ultimo elemento aggiunto all'ArrayList
                
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    groupBox1.Enabled = true;
                }

                textBox1.Text = ""; //Svuota il testo della textBox1
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            //Riempie la GroupBox "elemento selezionato" con i valori corrispondenti all'ultimo arrivo
            Entry atleta = arrivi.ElementAt(listBox1.SelectedIndex);
            label16.Text = arrivi.Count.ToString();
            label2.Text = atleta.getPettorale();
            label4.Text = atleta.getPosizione().ToString();
            label6.Text = atleta.getOra();
            label8.Text = atleta.getTempo();
        }

        private void button1_Click(object sender, EventArgs e) { //Elimina dalla List e dalla ListBox l'elemento selezionato
            if (listBox1.Items.Count > 0) {
                arrivi.RemoveAt(listBox1.SelectedIndex); //Elimina l'elemento dalla List
                listBox1.Items.Clear(); //Svuota la ListBox

                for (int i = 0; i < arrivi.Count; i++) { //Riempie la ListBox
                    listBox1.Items.Add(arrivi[i].getPettorale());
                    arrivi[i].setPosizione(i + 1); //Reimposta la classifica
                }

                if (listBox1.Items.Count > 0) {
                    listBox1.SelectedIndex = listBox1.Items.Count - 1; //Seleziona l'ultimo elemento
                } else {
                    groupBox1.Enabled = false;
                }
            }

        }

        private void button4_Click(object sender, EventArgs e) {
            button4.Enabled = false;
            this.stopwatch.Stop();
            timer1.Stop();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) {
            label10.Text = label11.Text;
            groupBox5.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = true;
            this.stopwatch.Start();
            timer1.Start();
            timer2.Stop();
            timer2.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e) {
            TimeSpan trascorso = this.stopwatch.Elapsed;
            label13.Text = String.Format( "{0:00}:{1:00}:{2:00}.{3:000}", trascorso.Hours, trascorso.Minutes, trascorso.Seconds, trascorso.Milliseconds);


        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label11.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
