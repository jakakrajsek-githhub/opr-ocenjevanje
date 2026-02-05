using classLibrary;
using System;
using System.Linq;
using System.Windows.Forms;

namespace opr_ocenjevanje
{
    public partial class Form1 : Form
    {
        private Prostor _trenutniProstor;

        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = Program.Prostori;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_trenutniProstor == null || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                return;
            }

            // Polimorfizem: kličemo metodo prek abstraktnega tipa Prostor, izvedba je odvisna od dejanske sobe.
            bool dodano = _trenutniProstor.DodajStvar(new Stvar(textBox1.Text));
            if (!dodano)
            {
                MessageBox.Show("V ta prostor ne morete dodati več stvari.");
            }

            RefreshStvari();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void RefreshStvari()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = _trenutniProstor?.VseStvari.ToList();

            // Vmesnik: prostor obravnavamo kot IOpisljivo in pridobimo standardiziran opis.
            if (_trenutniProstor is IOpisljivo opisljivo)
            {
                Text = "Ocenjevanje prostorov - " + opisljivo.Opis();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Stvar stvar && _trenutniProstor != null)
            {
                _trenutniProstor.OdstraniStvar(stvar);
                RefreshStvari();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _trenutniProstor = comboBox1.SelectedItem as Prostor;

            if (_trenutniProstor != null && _trenutniProstor.VseStvari.Count > 0)
            {
                // Indekser: dostop do prve stvari v prostoru preko this[int].
                var prvaStvar = _trenutniProstor[0];
                if (prvaStvar != null)
                {
                    textBox1.Text = prvaStvar.Ime;
                    textBox1.SelectionStart = textBox1.Text.Length;
                }
            }

            RefreshStvari();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
