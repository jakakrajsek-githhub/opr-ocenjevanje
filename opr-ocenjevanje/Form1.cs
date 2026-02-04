using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace opr_ocenjevanje
{
    public partial class Form1 : Form
    {
        Prostor TrenutniProstor;
        public Form1()
        {
            InitializeComponent();

            comboBox1.DataSource = Program.Prostors;// Dodamo sobe v ComboBox
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                TrenutniProstor.AddStvar(new Stvar(textBox1.Text));
                RefreshStvari();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void RefreshStvari()
        {
           listBox1.DataSource = null;
           listBox1.DataSource = TrenutniProstor.GetStvari();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Stvar Stvar)
            {
                TrenutniProstor.RemoveStvar(Stvar);
                RefreshStvari();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrenutniProstor = comboBox1.SelectedItem as Prostor;
            RefreshStvari();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
