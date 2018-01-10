using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comisariato.Formularios.SRI
{
    public partial class FrmComprobantesSri : Form
    {
        public FrmComprobantesSri()
        {
            InitializeComponent();
            this.Height = Program.tamañoVentanaPrincipal - 75;
            int width = this.Width;
            this.Width = width - 9;
        }

        private void FrmComprobantesSri_Load(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
