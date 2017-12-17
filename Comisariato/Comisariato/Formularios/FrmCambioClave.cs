using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comisariato.Formularios
{
    public partial class FrmCambioClave : Form
    {
        public FrmCambioClave()
        {
            InitializeComponent();
        }

        private void ckbActual_CheckedChanged(object sender, EventArgs e)
        {
            string text = txtActual.Text;
            if (ckbActual.Checked)
            {
                txtActual.UseSystemPasswordChar = false;
                txtActual.Text = text;
            }
            else
            {
                txtActual.UseSystemPasswordChar = true;
                txtActual.Text = text;
            }
        }

        private void ckbNueva_CheckedChanged(object sender, EventArgs e)
        {
            string text = txtNueva.Text;
            if (ckbNueva.Checked)
            {
                txtNueva.UseSystemPasswordChar = false;
                txtNueva.Text = text;
            }
            else
            {
                txtNueva.UseSystemPasswordChar = true;
                txtNueva.Text = text;
            }
        }
    }
}
