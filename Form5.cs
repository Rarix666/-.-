using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rushan.Kursach
{
    public partial class MedKartaForm : Form
    {
        public MedKartaForm()
        {
            InitializeComponent();
        }

        private void MedKartaForm_Load(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
        }
    }
}
