using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comisariato.Formularios.Transacciones.Venta
{
    public partial class FrmConsultarPrecios : Form
    {
        public FrmConsultarPrecios()
        {
            InitializeComponent();
        }

        private void btnSalirCompra_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {

                }
            }
        }
    }
}
