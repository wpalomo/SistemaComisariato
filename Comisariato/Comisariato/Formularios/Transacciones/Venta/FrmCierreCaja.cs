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
        int billetes1 = 0, billetes5 = 0, billetes10 = 0, billetes20 = 0, billetes50 = 0, billetes100 = 0;
        int monedas1 = 0, monedas5 = 0, monedas10 = 0, monedas25 = 0, monedas50 = 0, monedas1Dolar = 0;
        float monedas = 0.0f;
        float totalCheque = 0.0f;
        float totalRecaudado = 0.0f;
        Consultas objConsulta = new Consultas();
        private void txtBillestes1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcion.Validar_Numeros(e);
        }

        private void txtBillestes5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                if (txtBillestes5.Text != "")
                {
                    billetes5 = 0;
                    billetes5 = Convert.ToInt32(txtBillestes5.Text);
                }
                else
                    billetes5 = billetes5 * -1;
                calcularBilletes(5, billetes5);
            }
        }

        private void txtBillestes10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                if (txtBillestes1.Text != "")
                {
                    billetes10 = 0;
                    billetes10 = Convert.ToInt32(txtBillestes10.Text);
                }
                else
                    billetes10 = billetes10 * -1;
                calcularBilletes(10, billetes10);
            }
        }

        private void txtBillestes20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                if (txtBillestes20.Text != "")
                {
                    billetes20 = 0;
                    billetes20 = Convert.ToInt32(txtBillestes20.Text);
                }
                else
                    billetes20 = billetes20 * -1;
                calcularBilletes(20, billetes20);
            }
        }

        private void txtBillestes50_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                if (txtBillestes50.Text != "")
                {
                    billetes50 = 0;
                    billetes50 = Convert.ToInt32(txtBillestes50.Text);
                }
                else
                    billetes50 = billetes50 * -1;
                calcularBilletes(50, billetes50);
            }
        }

        private void txtBillestes100_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                if (txtBillestes100.Text != "")
                {
                    billetes100 = 0;
                    billetes100 = Convert.ToInt32(txtBillestes100.Text);
                }
                else
                    billetes100 = billetes100 * -1;
                calcularBilletes(100, billetes100);
            }
        }

        private void txtMonedas1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                if (txtMonedas1.Text != "")
                {
                    monedas1 = 0;
                    monedas1 = Convert.ToInt32(txtMonedas1.Text);
                }
                else
                    monedas1 = monedas1 * -1;
                calcularMonedas(1, monedas1);
            }
        }

        private void txtMonedas5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                if (txtMonedas5.Text != "")
                {
                    monedas5 = 0;
                    monedas5 = Convert.ToInt32(txtMonedas5.Text);
                }
                else
                    monedas5 = monedas5 * -1;
                calcularMonedas(5.0f, Convert.ToSingle(monedas5));
            }
        }
        
        private void txtMonedas10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                if (txtMonedas10.Text != "")
                {
                    monedas10 = 0;
                    monedas10 = Convert.ToInt32(txtMonedas10.Text);
                }
                else
                    monedas10 = monedas10 * -1;
                calcularMonedas(10.0f, Convert.ToSingle(monedas10));
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string sqlInsert = " INSERT INTO[dbo].[TbCierreCaja]([TOTALBILLETES],[TOTALMONEDAS],[TOTALCHEQUES],[TOTALAVANCES],[TOTALRECAUDADO],[TOTALENTREGADO],[FECHA],[IDUSUARIO],[CAJA])" +
                                                               " VALUES(" + Funcion.reemplazarcaracter(billetes.ToString()) + ", "+ Funcion.reemplazarcaracter(monedas.ToString()) + ","+ Funcion.reemplazarcaracter(totalCheque.ToString()) + ","+ Funcion.reemplazarcaracter(txtAvances.Text.ToString()) + ","+ Funcion.reemplazarcaracter(totalRecaudado.ToString()) + ","+ Funcion.reemplazarcaracter(txtCantidadEntregada.Text.ToString()) + ",'"+ Funcion.reemplazarcaracterFecha(DateTime.Now.Date.ToShortDateString()) +"', "+ Program.IDUsuarioMenu +", "+ Program.NumeroCaja+")";
            bool correcto = objConsulta.EjecutarSQL(sqlInsert);
            if (correcto)
            { 
                MessageBox.Show("Registrado Correctamente");
                inicializar();
            }
            else
                MessageBox.Show("Error al Registrar");
        }

        private void txtCantidadEntregada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                if (txtMonedas25.Text != "")
                {
                    totalRecaudado = Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtTotalBillestes.Text)) + Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtTotalMonedas.Text)) + Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtTotalCheque.Text)) + Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtAvances.Text)) + Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtCantidadEntregada.Text));
                    txtTotalRecaudado.Text = Funcion.reemplazarcaracter(totalRecaudado.ToString());
                }
                else {
                    totalRecaudado = Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtTotalBillestes.Text)) + Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtTotalMonedas.Text)) + Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtTotalCheque.Text)) + Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtAvances.Text));
                    txtTotalRecaudado.Text = Funcion.reemplazarcaracter(totalRecaudado.ToString());
                }
                    
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            inicializar();
        }

        private void txtMonedas25_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                if (txtMonedas25.Text != "")
                {
                    monedas25 = 0;
                    monedas25 = Convert.ToInt32(txtMonedas25.Text);
                }
                else
                    monedas25 = monedas25 * -1;
                calcularMonedas(25.0f, Convert.ToSingle(monedas25));
            }
        }

        private void txtMonedas50_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                if (txtMonedas50.Text != "")
                {
                    monedas50 = 0;
                    monedas50 = Convert.ToInt32(txtMonedas50.Text);
                }
                else
                    monedas50 = monedas50 * -1;
                calcularMonedas(50.0f, Convert.ToSingle(monedas50));
            }
        }

        private void txtMonedas1Dolar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                if (txtMonedas1Dolar.Text != "")
                {
                    monedas1Dolar = 0;
                    monedas1Dolar = Convert.ToInt32(txtMonedas1Dolar.Text);
                }
                else
                    monedas1Dolar = monedas1Dolar * -1;
                monedas = monedas + monedas1Dolar;
                txtTotalMonedas.Text = Funcion.reemplazarcaracter(monedas.ToString());
            }
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
            string sqlCheque = "select * from VistaChequesCierreCaja where IDUSUARIO = "+ Program.IDUsuarioMenu +" AND FECHA = '"+ Funcion.reemplazarcaracterFecha(Convert.ToString(DateTime.Now.Date.ToShortDateString())) +"' and CAJA = " + Program.NumeroCaja + "";
            objConsulta.boolLlenarDataGrid(dgvCheque, sqlCheque, 4, 3, 0);
            for (int i = 0; i < dgvCheque.RowCount - 1; i++)
            {
                totalCheque = totalCheque + Convert.ToSingle(dgvCheque.Rows[i].Cells[3].Value);
                if (Convert.ToString(dgvCheque.Rows[i + 1].Cells[0].Value) == "")

                    break;
            }
            txtTotalCheque.Text = Funcion.reemplazarcaracter(totalCheque.ToString());
            string sqlAvance = "select COUNT(a.CANTIDAD) AS CATIDADADELANTO, sum(a.CANTIDAD) AS CANTIDADTOTAL from TbAvance a, TbUsuario u " +
" where a.IDEMPLEADO = u.IDEMPLEADO and u.IDUSUARIO = "+ Program.IDUsuarioMenu +"  and a.CAJA = "+ Program.NumeroCaja + " and a.FECHA = '"+ Funcion.reemplazarcaracterFecha(Convert.ToString(DateTime.Now.Date.ToShortDateString())) + "'";
            DataTable dt = objConsulta.BoolDataTable(sqlAvance);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtCantidadAvances.Text = row[0].ToString();
                if (row[1].ToString() != "")
                {
                    txtAvances.Text = Funcion.reemplazarcaracter(row[1].ToString());
                }
                else
                    txtAvances.Text = "0.00";


            }
        }

        public void calcularBilletes(int valor, int multiplicar)
        {
            billetes = billetes + (valor * multiplicar);
            txtTotalBillestes.Text = Funcion.reemplazarcaracter(billetes.ToString());
        }
        public void calcularMonedas(float valor, float multiplicar)
        {
            monedas = monedas + ((valor * multiplicar))/ 100;
            txtTotalMonedas.Text = Funcion.reemplazarcaracter(monedas.ToString());
        }
        private void txtBillestes1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                if (txtBillestes1.Text != "")
                {
                    billetes1 = 0;
                    billetes1 = Convert.ToInt32(txtBillestes1.Text);
                }
                else
                    billetes1 = billetes1 * -1;
                calcularBilletes(1, billetes1);
            }
        }

        public void inicializar()
        {
            Funcion.Limpiarobjetos(gbEfectivo);
            dgvCheque.Rows.Clear();
            for (int i = 0; i < 4; i++)
            {
                dgvCheque.Rows.Add();
            }
            Funcion.Limpiarobjetos(gbAvance);
            txtAvances.Text = "0.00";
            txtTotalBillestes.Text = "0.00";
            txtTotalCheque.Text = "0.00";
            txtTotalMonedas.Text = "0.00";
            txtCantidadEntregada.Text = "0.00";
            txtTotalRecaudado.Text = "0.00";

        }
        
    }
}
