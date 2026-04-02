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
            // Levi combobox = katera soba je trenutno odprta.
            comboBox1.DataSource = Program.Prostori;
            // Desni combobox = kam bi rad prestavil izbrano stvar.
            comboBox3.DataSource = Program.Prostori.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_trenutniProstor == null || string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                return;
            }

            // Dodajanje gre vedno čez Prostor.DodajStvar, tam so vsa pravila.
            bool dodano = _trenutniProstor.DodajStvar(new Stvar(comboBox2.Text));
            if (!dodano)
            {
                MessageBox.Show("Te stvari ne moreš dodati v ta prostor (ali pa je prostor poln / stvar že obstaja).");
            }

            RefreshStvari();
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

            if (_trenutniProstor != null)
            {
                // Ko zamenjaš sobo, se osvežijo predlagani predmeti za to sobo.
                comboBox2.DataSource = _trenutniProstor.PredlaganeStvari.ToList();

                if (_trenutniProstor.VseStvari.Count > 0)
                {
                    // Indekser: dostop do prve stvari v prostoru preko this[int].
                    var prvaStvar = _trenutniProstor[0];
                    if (prvaStvar != null)
                    {
                        comboBox2.Text = prvaStvar.Ime;
                    }
                }
            }

            RefreshStvari();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var cilj = comboBox3.SelectedItem as Prostor;
            var stvar = listBox1.SelectedItem as Stvar;
            if (_trenutniProstor == null || cilj == null || stvar == null)
            {
                return;
            }

            if (ReferenceEquals(_trenutniProstor, cilj))
            {
                MessageBox.Show("Stvar je že v tem prostoru.");
                return;
            }

            if (!_trenutniProstor.OdstraniStvar(stvar))
            {
                MessageBox.Show("Premik ni uspel (odstranitev iz trenutnega prostora ni uspela).");
                return;
            }

            if (!cilj.DodajStvar(stvar))
            {
                // Če cilj ne sprejme stvari, jo vrnemo nazaj (rollback).
                _trenutniProstor.DodajStvar(stvar);
                MessageBox.Show("Ta stvar ne paše v ciljni prostor (ali je tam že dodana / polno). Premik preklican.");
                return;
            }

            RefreshStvari();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
