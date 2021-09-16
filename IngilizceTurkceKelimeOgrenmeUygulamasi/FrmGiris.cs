using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IngilizceTurkceKelimeOgrenmeUygulamasi
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim()!="")
            {
                Form1 fr = new Form1();
                fr.isim = textBox1.Text;
                fr.Show();
                this.Hide();
            }
        }
    }
}
