using Comisariato.Clases;
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
    public partial class FrmCierreCaja : Form
    {
        public FrmCierreCaja()
        {
            InitializeComponent();
        }
        float billetes = 0.0f;
        private void txtBillestes1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcion.Validar_Numeros(e);
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcion.SoloValores(e, txtCantidadEntregada.Text);
        }

        private void btnSalirCompra_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCierreCaja_Load(object sender, EventArgs e)
        {

        }

        public void calcularBilletes(TextBox txtBillete, int billeteTipo)
        {
            if (txtBillete.Text != "")
            {
                billetes = billetes + (Convert.ToSingle(txtBillete.Text)* billeteTipo);
                txtTotalBillestes.Text = Convert.ToString(billetes);
            }
        }
        private void txtBillestes1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                calcularBilletes(txtBillestes1, 1);
            }
        }

        private void txtBillestes1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
