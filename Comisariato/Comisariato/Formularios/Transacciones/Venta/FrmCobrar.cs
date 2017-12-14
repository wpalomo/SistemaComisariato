﻿using Comisariato.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comisariato.Formularios.Transacciones
{
    public partial class FrmCobrar : Form
    {
        public float total;
        public int totalfilas,tipòpago=1;
        public string nombre, identificacion,descuentobd,ivabd;
        public DataGridView dg;
        Consultas c;
        public List<String> pedidos;
        public List<String> ivas;
        public string subtotal, subtotaconiva, descuento, ivasuma, totalapagar;
        //private bool chequear;
        public FrmCobrar()
        {
            InitializeComponent();
        }

        private void FrmCobrar_Load(object sender, EventArgs e)
        {
            txtEfectivo.Focus();
            txtTotalPagar.Text = Funcion.reemplazarcaracter(total.ToString("#####0.00"));
            dgvTarjeta.Enabled = false;
            dgvCheque.Enabled = false;
            txtRecibido.Text = "0.00";
           // MessageBox.Show("Filas: "+dg.RowCount+"  Columnas: "+dg.ColumnCount);
        }

        private void ckbCheque_CheckedChanged(object sender, EventArgs e)
        {
            tipòpago = 2;
            if (ckbCheque.Checked)
            {
                dgvCheque.Enabled = true;
                dgvCheque.CurrentCell = dgvCheque.Rows[0].Cells[0];
                dgvCheque.BeginEdit(true);
                Calcular();
            }
            else
            {
                dgvCheque.Enabled = false;
                Calcular();
            }
        }

       


        private void ckbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            tipòpago = 1;
            if (ckbEfectivo.Checked)
            {
                //txtCambio.Enabled = true;
                //txtRecibido.Enabled = true;
                //txtTotalPagar.Enabled = true;
                txtEfectivo.Focus();
                txtEfectivo.Enabled = true;
                Calcular();
            }
            else
            {
                txtEfectivo.Enabled = false;
                Calcular();
                //gbDinero.Enabled = false;
            }
        }

        private void ckbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            tipòpago = 3;
            if (ckbTarjeta.Checked)
            {
                dgvTarjeta.Enabled = true;
                dgvTarjeta.CurrentCell = dgvTarjeta.Rows[rowsdgvcredito].Cells[0];
                dgvTarjeta.BeginEdit(true);
                Calcular();
            }
            else
            {
                dgvTarjeta.Enabled = false;
                Calcular();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private int rowsdgvcheque = 0,rowsdgvcredito=0;
        private void dgvCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Return)
            //{
            //    if (dgvCheque.CurrentCell == dgvCheque.CurrentRow.Cells[0])
            //    {
            //        if (dato != null)
            //        {
            //            dgvCheque.CurrentCell = dgvCheque.Rows[rowsdgvcheque].Cells[1];
            //            dgvCheque.BeginEdit(true);
            //            //rowsdgvcheque++;
            //            dato = "";
            //        }
            //        else
            //        {
            //            dgvCheque.CurrentCell = dgvCheque.Rows[rowsdgvcheque].Cells[0];
            //            dgvCheque.BeginEdit(true);
            //        }
            //    }
            //    else
            //    {
            //        if (dgvCheque.CurrentCell == dgvCheque.CurrentRow.Cells[1])
            //        {
            //            if (dato != null)
            //            {
            //                dgvCheque.CurrentCell = dgvCheque.Rows[rowsdgvcheque].Cells[2];
            //                dgvCheque.BeginEdit(true);
            //                //rowsdgvcheque++;
            //                dato = "";
            //            }
            //            else
            //            {
            //                dgvCheque.CurrentCell = dgvCheque.Rows[rowsdgvcheque].Cells[1];
            //                dgvCheque.BeginEdit(true);
            //            }
            //        }
            //    }
            //}
                
        }
        string dato = "";
        private DateTimePicker oDateTimePicker;

        private void dgvCheque_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvCheque.CurrentCell == this.dgvCheque.CurrentRow.Cells[5])
            //{
            //    dgvCheque.Rows[e.RowIndex].Cells[5].Value = Convert.ToDecimal(dgvCheque.Rows[e.RowIndex].Cells[5].Value);


            //}
            //else
            //{

            dato = Convert.ToString(dgvCheque.CurrentRow.Cells[e.ColumnIndex].Value);
            SendKeys.Send("{UP}");
                //}
                //dato = Convert.ToString(dgvCheque.CurrentRow.Cells[e.ColumnIndex].Value);
                //SendKeys.Send("{UP}");
           // }
            
            //SendKeys.Send("{TAB}");
        }

        private void dgvTarjeta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvTarjeta.CurrentCell == this.dgvTarjeta.CurrentRow.Cells[2])
            //{
            //    bool b = true;
            //    Funcion.ValidaCeldasPrecios(dgvTarjeta, 2, ref b);
            //    //if (!b)
            //    //{
            //        SendKeys.Send("{RIGHT}");

            //    //}
            //    //else
            //    //{
            //    //    txtEfectivo.Focus();
            //    //}


            //}
            //else
            //{
               
               // {
                    dato = Convert.ToString(dgvTarjeta.CurrentRow.Cells[e.ColumnIndex].Value);
                    SendKeys.Send("{UP}");
                //}
               
            //}

            //dato = Convert.ToString(dgvTarjeta.CurrentRow.Cells[e.ColumnIndex].Value);
            //SendKeys.Send("{UP}");
            // MessageBox.Show("escibiendo...");
        }

        private void dgvCheque_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                try
                {
                    if (dgvCheque.CurrentCell == this.dgvCheque.CurrentRow.Cells[0])
                    {
                        if (dato != "")
                        {
                            dgvCheque.CurrentCell = dgvCheque.Rows[rowsdgvcheque].Cells[1];
                            dgvCheque.BeginEdit(true);
                            dato = "";
                        }
                        else
                        {
                            dgvCheque.CurrentCell = dgvCheque.Rows[rowsdgvcheque].Cells[0];
                            dgvCheque.BeginEdit(true);
                        }
                    }
                    else
                    {
                        if (dgvCheque.CurrentCell == this.dgvCheque.CurrentRow.Cells[1])
                        {
                            if (dato != "")
                            {
                                dgvCheque.CurrentCell = dgvCheque.Rows[rowsdgvcheque].Cells[2];
                                dgvCheque.BeginEdit(true);
                                dato = "";
                            }
                            else
                            {
                                dgvCheque.CurrentCell = dgvCheque.Rows[rowsdgvcheque].Cells[1];
                                dgvCheque.BeginEdit(true);
                            }
                        }
                        else
                        {
                            if (dgvCheque.CurrentCell == this.dgvCheque.CurrentRow.Cells[2])
                            {
                                if (dato != "")
                                {
                                    SendKeys.Send("{right}");
                                    SendKeys.Send("{up}");
                                    //dgvCheque.CurrentCell = dgvCheque.Rows[rowsdgvcheque].Cells[2];
                                    //dgvCheque.BeginEdit(true);
                                    dato = "";
                                }
                                else
                                {
                                    // Me
                                    dgvCheque.CurrentCell = dgvCheque.Rows[rowsdgvcheque].Cells[2];
                                    dgvCheque.BeginEdit(true);
                                }
                            }
                            else
                            {
                                if (dgvCheque.CurrentCell == this.dgvCheque.CurrentRow.Cells[3])
                                {
                                    if (dato != "")
                                    {
                                        dgvCheque.CurrentCell = dgvCheque.Rows[rowsdgvcheque].Cells[4];
                                        dgvCheque.BeginEdit(true);
                                        dato = "";
                                    }
                                    else
                                    {
                                        dgvCheque.CurrentCell = dgvCheque.Rows[rowsdgvcheque].Cells[3];
                                        dgvCheque.BeginEdit(true);
                                    }
                                }
                                else
                                {
                                    if (dgvCheque.CurrentCell == this.dgvCheque.CurrentRow.Cells[4])
                                    {
                                        if (dato != "")
                                        {
                                            dgvCheque.CurrentCell = dgvCheque.Rows[rowsdgvcheque].Cells[5];
                                            dgvCheque.BeginEdit(true);
                                            dato = "";
                                        }
                                        else
                                        {
                                            //MessageBox.Show("Todos los datos son requeridos.");
                                            dgvCheque.CurrentCell = dgvCheque.Rows[rowsdgvcheque].Cells[4];
                                            dgvCheque.BeginEdit(true);
                                        }
                                    }
                                    else
                                    {
                                        if (dgvCheque.CurrentCell == this.dgvCheque.CurrentRow.Cells[5])
                                        {
                                            if (dato != "")
                                            {
                                                rowsdgvcheque++;
                                                dato = "";
                                                txtEfectivo.Focus();
                                                Calcular();
                                            }
                                            else
                                            {
                                                //MessageBox.Show("Todos los datos son requeridos.");
                                                dgvCheque.CurrentCell = dgvCheque.Rows[rowsdgvcheque].Cells[5];
                                                dgvCheque.BeginEdit(true);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                }
                catch (Exception)
                {

                    //throw;
                }
            }
              
        }

        private void dgvTarjeta_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                try
                {
                    if (dgvTarjeta.CurrentCell == this.dgvTarjeta.CurrentRow.Cells[0])
                    {
                        if (dato != "")
                        {
                            SendKeys.Send("{right}");
                            SendKeys.Send("{up}");
                            //dgvTarjeta.CurrentCell = dgvTarjeta.Rows[rowsdgvcredito].Cells[1];
                            //dgvTarjeta.BeginEdit(true);
                            dato = "";
                        }
                        else
                        {
                            dgvTarjeta.CurrentCell = dgvTarjeta.Rows[rowsdgvcredito].Cells[0];
                            dgvTarjeta.BeginEdit(true);
                        }
                    }
                    else
                    {
                        if (dgvTarjeta.CurrentCell == this.dgvTarjeta.CurrentRow.Cells[1])
                        {
                            if (dato != "")
                            {
                                dgvTarjeta.CurrentCell = dgvTarjeta.Rows[rowsdgvcredito].Cells[2];
                                dgvTarjeta.BeginEdit(true);
                                dato = "";
                            }
                            else
                            {
                                dgvTarjeta.CurrentCell = dgvTarjeta.Rows[rowsdgvcredito].Cells[1];
                                dgvTarjeta.BeginEdit(true);
                            }
                        }
                        else
                        {
                            if (dgvTarjeta.CurrentCell == this.dgvTarjeta.CurrentRow.Cells[2])
                            {
                                if (dato != "")
                                {
                                    
                                    dgvTarjeta.CurrentCell = dgvTarjeta.Rows[rowsdgvcredito].Cells[3];
                                    dgvTarjeta.BeginEdit(true);
                                    Calcular();
                                    dato = "";
                                }
                                else
                                {
                                    // Me
                                    dgvTarjeta.CurrentCell = dgvTarjeta.Rows[rowsdgvcredito].Cells[2];
                                    dgvTarjeta.BeginEdit(true);
                                }
                            }
                            else
                            {
                                if (dgvTarjeta.CurrentCell == this.dgvTarjeta.CurrentRow.Cells[3])
                                {
                                    if (dato != "")
                                    {
                                        rowsdgvcredito++;
                                        //Calcular();
                                        txtEfectivo.Focus();
                                        dato = "";
                                    }
                                    else
                                    {
                                        dgvTarjeta.CurrentCell = dgvTarjeta.Rows[rowsdgvcredito].Cells[3];
                                        dgvTarjeta.BeginEdit(true);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {

                    // throw;
                }
            }
               

        }

        private void FrmCobrar_KeyUp(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode == Keys.Return)
            //{
            //    if (dgvCheque.Focus() && chequear)
            //    {
                   
                   
            //    }
            //    if (dgvTarjeta.Focus() && !chequear)
            //    {
                   
            //    }

            //}
        }

        private void dgvCheque_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox)
            {
                TextBox txt = e.Control as TextBox;

               
                    txt.KeyPress += OnlyNumbersdgvcheque_KeyPress;
                   // Funcion.SoloValores(e,txt);
             }
                   
               
            
        }

        private void OnlyNumbersdgvcheque_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (dgvCheque.CurrentCell == this.dgvCheque.CurrentRow.Cells[0] || dgvCheque.CurrentCell == this.dgvCheque.CurrentRow.Cells[1])
             {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // Si no es numerico y si no es espacio
                {
                    // Invalidar la accion
                    e.Handled = true;
                    // Enviar el sonido de beep de windows
                    System.Media.SystemSounds.Beep.Play();
                }

            }


        }

        private void OnlyNumbersdgvTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvTarjeta.CurrentCell == this.dgvTarjeta.CurrentRow.Cells[0])
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // Si no es numerico y si no es espacio
                {
                    // Invalidar la accion
                    e.Handled = true;
                    // Enviar el sonido de beep de windows
                    System.Media.SystemSounds.Beep.Play();
                }

            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtEfectivo.Text=="")
                {
                    txtCambio.Text = "0.00";
                    txtRecibido.Text = "0.00";
                }
                else
                {
                    Calcular();
                }
                

            }
            catch (Exception ex)
            {
            }
        }

        private void dgvTarjeta_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox)
            {
                TextBox txt = e.Control as TextBox;


                txt.KeyPress += OnlyNumbersdgvTarjeta_KeyPress;
                // Funcion.SoloValores(e,txt);
            }

        }

        private void dgvCheque_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCheque.CurrentCell==this.dgvCheque.CurrentRow.Cells[3] && e.RowIndex ==rowsdgvcheque)
            {
                //Initialized a new DateTimePicker Control  
                oDateTimePicker = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dgvCheque.Controls.Add(oDateTimePicker);

                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker.Format = DateTimePickerFormat.Short;

                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dgvCheque.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);

                // Now make it visible  
                oDateTimePicker.Visible = true;
            }
        }


        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dgvCheque.CurrentRow.Cells[3].Value = oDateTimePicker.Text.ToString();
            dato= oDateTimePicker.Text.ToString();
            dgvCheque.Focus();
            dgvCheque.CurrentCell = dgvCheque.CurrentRow.Cells[4];
            dgvCheque.BeginEdit(true);

        }

        void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker.Visible = false;
            dgvCheque.Focus();
            dgvCheque.CurrentCell = dgvCheque.CurrentRow.Cells[4];
            dgvCheque.BeginEdit(true);

        }

        private void dgvTarjeta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTarjeta.CurrentCell == this.dgvTarjeta.CurrentRow.Cells[1]  &&  e.RowIndex== rowsdgvcredito)
            {
                //Initialized a new DateTimePicker Control  
                oDateTimePicker = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dgvTarjeta.Controls.Add(oDateTimePicker);

                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker.Format = DateTimePickerFormat.Short;

                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dgvTarjeta.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker.CloseUp += new EventHandler(oDateTimePickerdgvtarjeta_CloseUp);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker.TextChanged += new EventHandler(dateTimePickerdgvtarjeta_OnTextChange);

                // Now make it visible  
                oDateTimePicker.Visible = true;
            }
        }

        void oDateTimePickerdgvtarjeta_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker.Visible = false;
            dgvTarjeta.Focus();
            dgvTarjeta.CurrentCell = dgvTarjeta.CurrentRow.Cells[2];
            dgvTarjeta.BeginEdit(true);

        }

        private void dateTimePickerdgvtarjeta_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dgvTarjeta.CurrentRow.Cells[1].Value = oDateTimePicker.Text.ToString();
            dato = oDateTimePicker.Text.ToString();
            dgvTarjeta.Focus();
            dgvTarjeta.CurrentCell = dgvTarjeta.CurrentRow.Cells[2];
            dgvTarjeta.BeginEdit(true);

        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProceCambioBd();
            }
            else
            {
                Funcion.SoloValores(e, txtEfectivo.Text);
            }
        }

        private void dgvCheque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void dgvTarjeta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtRecibido_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtRecibido_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Return)
            //{
            //    ProceCambioBd();
            //}
            //else
            //{
            //    Funcion.SoloValores(e,txtRecibido);
            //}
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ProceCambioBd();


            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ ex.Message);
            }
          
        }

        private void ProceCambioBd()
        {
            c = new Consultas();
            try
            {
                int sucursal = Program.em.Sucursal;
                int caja = Program.em.Caja;
                int numfactbd = Program.em.Numfact;
                string fechabd = Program.em.Fecha;
                string horabd = Program.em.Hora;
                int idempleadobd = Program.em.Idempleado;
                int idclientebd = Program.em.Idcliente;
                //string ivastring = Funcion.reemplazarcaracter(ivabd.ToString());
                //string des = Funcion.reemplazarcaracter(descuentobd.ToString());
                double recibido = Convert.ToDouble(Funcion.reemplazarcaracterViceversa(txtRecibido.Text));
                double totals = Math.Round(total,2);
                if (recibido >= totals)
                {
                    List<string> encabezadofact = new List<string>();
                    List<string> detallepago = new List<string>();
                    encabezadofact.Add(""+sucursal);
                    encabezadofact.Add("" + caja);
                    encabezadofact.Add("" + numfactbd);
                    encabezadofact.Add("" + fechabd);
                    encabezadofact.Add("" + horabd);
                    encabezadofact.Add("" + idempleadobd);
                    encabezadofact.Add("" + idclientebd);

                    txtEfectivo.Text = Funcion.reemplazarcaracter(txtEfectivo.Text);
                    txtCheque.Text= Funcion.reemplazarcaracter(txtCheque.Text);
                    txtCredito.Text= Funcion.reemplazarcaracter(txtCredito.Text);
                    txtRecibido.Text= Funcion.reemplazarcaracter(txtRecibido.Text);
                    txtCambio.Text= Funcion.reemplazarcaracter(txtCambio.Text);

                    ivabd= Funcion.reemplazarcaracter(ivabd);
                    descuentobd= Funcion.reemplazarcaracter(descuentobd);

                    detallepago.Add(ivabd);
                    detallepago.Add(descuentobd);
                    if (txtEfectivo.Text=="")
                    {
                        txtEfectivo.Text = "0.00";
                    }
                    if (txtCredito.Text=="")
                    {
                        txtCredito.Text = "0.00";
                    }
                    if (txtCheque.Text=="")
                    {
                        txtCheque.Text = "0.00";
                    }

                    detallepago.Add(txtEfectivo.Text);
                    detallepago.Add(txtCheque.Text);
                    detallepago.Add(txtCredito.Text);
                    detallepago.Add(txtRecibido.Text);
                    detallepago.Add(txtCambio.Text);

                    /// codigo byron 

                    int totalfacturasAGenerar = 1;
                    int ItemsPermitidos = 0;
                    int inicioContador = 0;
                    if (Program.BoolPreimpresa)
                    {
                        String PreimpresaDatos = Program.DatosPreimpresa;
                        string[] Preimpresa = PreimpresaDatos.Split('-');
                        ItemsPermitidos = Convert.ToInt32(Preimpresa[2]);
                        totalfacturasAGenerar = obtenercantidadFactura(totalfilas, ItemsPermitidos);
                    }

                    int filasaxuiliar = 0;
                    int auxiliar = totalfilas;
                    for (int i = 0; i < totalfacturasAGenerar; i++)
                    {
                        if (auxiliar > ItemsPermitidos)
                        {
                            int aux1 = auxiliar;
                            auxiliar = auxiliar - ItemsPermitidos;

                            filasaxuiliar = aux1 - auxiliar;
                        }
                        else
                        {
                            filasaxuiliar = auxiliar;
                        }
                        //total += filasaxuiliar;
                        if (i == 0)
                        {
                            inicioContador = 0;
                        }
                        bool b = c.GuardarFact(filasaxuiliar, dg, encabezadofact, detallepago, ivas, inicioContador);
                        if (b)
                        {

                            string condicion = " where CAJA = '" + caja + "' and SUCURSAL= '" + sucursal + "' and IDEMPRESA='" + Program.IDEMPRESA + "';";
                            if (ckbCheque.Checked)
                            {
                                int ult = c.ObtenerID("IDFACTURA", "TbEncabezadoFactura", condicion);
                                bool d = c.RegistrarCheque(dgvCheque, ult);
                            }
                            if (ckbTarjeta.Checked)
                            {
                                int ult = c.ObtenerID("IDFACTURA", "TbEncabezadoFactura", condicion);
                                bool e = c.RegistrarTarjeta(dgvTarjeta, ult);
                            }

                            if (pedidos.Count > 0)
                            {
                                ImprimirenRed();
                            }


                            Imprimirfact(inicioContador, filasaxuiliar);
                            /*totalFacturasAImprimir*/
                            //();
                            encabezadofact[2] = (Convert.ToInt32(encabezadofact[2])+1).ToString();
                            Program.em.Numfact = Convert.ToInt32(encabezadofact[2]);

                            if (i == (totalfacturasAGenerar-1))
                            {
                                FrmFactura.verificadorfrm = 3;
                                FrmFactura.numfactnuevo = Convert.ToInt32(encabezadofact[2]);
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error... No se pudo grabar la factura.");
                        }

                        inicioContador += (filasaxuiliar);
                    }
                }
                else
                {
                    MessageBox.Show("El dinero recibido de ser mayor o igual al tota a pagar.");
                    txtRecibido.Focus();
                }
            }
            catch (Exception EX)
            {

                //throw;
            }
           
        }


        private int obtenercantidadFactura(int cantidadDeFilas, int ItemsPermitidos)
        {
            int cantidad = 0;
            //int totalfilas = 64;
            //int cantItems = 16;
            int auxiliarCantItem = ItemsPermitidos;
            //si el totaldefilas(Producto) es menor a los item permitidos por los parametros, entonces imprime una factura
            if (cantidadDeFilas <= ItemsPermitidos)
            {
                return 1;
            }
            else
            {
                //si el totaldefilas(Producto) es mayor a los item permitidos por los parametros, recorro las filas
                for (int i = 1; i < cantidadDeFilas; i++)
                {
                    if (i == ItemsPermitidos)// si i llega al total de item permitidos, 
                    {
                        cantidad += 1;
                        ItemsPermitidos += auxiliarCantItem;
                    }
                }
                if (auxiliarCantItem < cantidadDeFilas)
                {
                    cantidad += 1;
                }

                return cantidad;
            }
        }

        private void Imprimirfact(int inicioContador, int filasaxuiliar)
        {
            //Creamos una instancia d ela clase CrearTicket
            CrearTicket ticket = new CrearTicket();
            //Ya podemos usar todos sus metodos
            ticket.AbreCajon();//Para abrir el cajon de dinero.



            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo
            string fechactual = DateTime.Now.Date.ToShortDateString();
            //int añoactual = DateTime.Now.Date.Year;
            string fechaexpira = DateTime.Now.Date.AddYears(1).ToShortDateString();
            int sucursal = Program.em.Sucursal;
            int numcaja = Program.em.Caja;
            int numfac = Program.em.Numfact;

            //if (aumentoNumeroFactura > 1)
            //{
            //    numfac += (aumentoNumeroFactura - 1);
            //}

            int tamañoencabezado = 0, tamañoPie = 0, cantItems = 0;
            //ticket.lineasAsteriscos();
            //Datos de la cabecera del Ticket.
            if (Program.BoolAutorizadoImprimir)
            {
                ticket.TextoCentro("EMPRESA: " + Program.nombreempresa);
                ticket.TextoCentro("RUC: " + Program.rucempresa);
                ticket.TextoIzquierda(Program.direccionempresa);
                ticket.TextoIzquierda("Valido: " + fechactual + " Hasta: " + fechaexpira);
                ticket.TextoIzquierda("Clave: 4530000");
            }
            else if (Program.BoolPreimpresa)
            {
                //TAMANOENCABEZADOFACTURA-TAMANOPIEFACTURA-NUMEROITEMS
                String PreimpresaDatos = Program.DatosPreimpresa;
                string[] Preimpresa = PreimpresaDatos.Split('-');
                tamañoencabezado = Convert.ToInt32(Preimpresa[0]);
                tamañoPie = Convert.ToInt32(Preimpresa[1]);
                cantItems = Convert.ToInt32(Preimpresa[2]);
                //((tamañoencabezado * 2) + 1) ---> 2 = 1cm son dos lineas --- 1 = para completar el centimetro
                for (int i = 0; i <= (((tamañoencabezado - 2))); i++)
                {
                    ticket.TextoCentro("");
                }
            }

            ticket.TextoIzquierda("        Factura #: " + sucursal.ToString("D3") + "-" + numcaja.ToString("D3") + "-" + numfac.ToString("D9"));
            ticket.TextoIzquierda("         Informacion del Consumidor");//Es el mio por si me quieren contactar ...
            ticket.TextoIzquierda("RUC: " + identificacion);
            ticket.TextoIzquierda("Cliente: " + nombre);
            ticket.TextoIzquierda("Facturado: " + Program.Usuario+ "# CAJA: " + numcaja.ToString("D3"));
            //ticket.TextoIzquierda("# CAJA: " + numcaja.ToString("D3"));
            string[] h = DateTime.Now.TimeOfDay.ToString().Split('.');
            ticket.TextoIzquierda("Fecha: " + fechactual + "          " + h[0]);
            if (ckbCheque.Checked && ckbEfectivo.Checked && ckbTarjeta.Checked)
            {
                ticket.TextoIzquierda("Tipo de pago: Efectivo - Cheque - T. Credito");
            }
            else
            {
                if (ckbCheque.Checked && ckbTarjeta.Checked)
                {
                    ticket.TextoIzquierda("Tipo de pago: Cheque - T. Credito");
                }
                else
                {
                    if (ckbTarjeta.Checked && ckbEfectivo.Checked)
                    {
                        ticket.TextoIzquierda("Tipo de pago: Efectivo - T. Credito");
                    }
                    else
                    {
                        if (ckbCheque.Checked && ckbEfectivo.Checked)
                        {
                            ticket.TextoIzquierda("Tipo de pago: Efectivo - Cheque");
                        }
                        else
                        {
                            if (ckbEfectivo.Checked)
                            {
                                ticket.TextoIzquierda("Tipo de pago: Efectivo");
                            }
                            else
                            {
                                if (ckbCheque.Checked)
                                {
                                    ticket.TextoIzquierda("Tipo de pago: Cheque");
                                }
                                else
                                {
                                    if (ckbTarjeta.Checked)
                                    {
                                        ticket.TextoIzquierda("Tipo de pago: T. Credito");
                                    }
                                }
                            }
                        }
                    }

                }
            }
            if (Program.BoolAutorizadoImprimir)
            { ticket.lineasAsteriscos(); }
            


            ///////////////////PRUEBA


            //////////////////PRUEBA
            double imsubtotal = 0F, imivasuma = 0F, subtotaliva = 0F, totaapagar = 0.0f;
            //Articulos a vender.
            ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.

            //if (ItemsPermitidos >= totalfilas)
            //{
            int cantidadVendida = filasaxuiliar;
            filasaxuiliar = filasaxuiliar + inicioContador;
            for (int J = inicioContador; J < filasaxuiliar; J++)//dgvLista es el nombre del datagridview
            {

                double total = Convert.ToDouble(dg.Rows[J].Cells[4].Value.ToString()) * Convert.ToInt32(dg.Rows[J].Cells[2].Value.ToString());
                double iva = 0.0f;
                if (Convert.ToSingle(dg.Rows[J].Cells[5].Value.ToString()) != 0)
                {
                    iva = (Convert.ToDouble(dg.Rows[J].Cells[5].Value.ToString()));
                    ticket.AgregaArticulo("*" + dg.Rows[J].Cells[1].Value.ToString(), int.Parse(dg.Rows[J].Cells[2].Value.ToString()),
                    Convert.ToSingle(dg.Rows[J].Cells[4].Value).ToString("#####0.00"), total.ToString("#####0.00"));

                    imivasuma += Convert.ToDouble(dg.Rows[J].Cells[5].Value);
                    subtotaliva += Convert.ToSingle(dg.Rows[J].Cells[6].Value.ToString());
                    //subtotaliva += (total + Convert.ToDouble(dg.Rows[i].Cells[5].Value));
                }
                else
                {
                    ticket.AgregaArticulo(" " + dg.Rows[J].Cells[1].Value.ToString(), int.Parse(dg.Rows[J].Cells[2].Value.ToString()),
                Convert.ToSingle(dg.Rows[J].Cells[4].Value).ToString("#####0.00"), total.ToString("#####0.00"));

                    //imsubtotal += Convert.ToSingle(dg.Rows[i].Cells[4].Value.ToString());
                    imsubtotal += Convert.ToSingle(dg.Rows[J].Cells[6].Value.ToString());
                }
                //imsubtotal += total;

                totaapagar += total + iva;
            }

            if (cantidadVendida < cantItems)
            {
                int filasaAumentar = 0;
                filasaAumentar = cantItems - cantidadVendida;
                for (int i = 0; i < filasaAumentar; i++)
                {
                    ticket.lineasEnBlanco();
                }
            }

            imsubtotal = Math.Round(imsubtotal, 2);
            subtotaliva = Math.Round(subtotaliva, 2);
            imivasuma = Math.Round(imivasuma, 2);
            totaapagar = Math.Round(totaapagar, 2);
            ticket.lineasAsteriscos();
            //Resumen de la venta. Sólo son ejemplos
            ticket.AgregarTotales("SUBTOTAL  0%", imsubtotal);
            ticket.AgregarTotales("SUBTOTAL 12% ", subtotaliva);
            ticket.AgregarTotales("Descuento", Convert.ToSingle(descuento));
            ticket.AgregarTotales("Iva 12%  ", imivasuma);
            ticket.AgregarTotales("Total a pagar", Convert.ToSingle(totaapagar));

            if (Program.BoolAutorizadoImprimir)
            {
                if (ckbCheque.Checked && ckbEfectivo.Checked && ckbTarjeta.Checked)
                {
                    ticket.TextoIzquierda("Efectivo:  $" + txtEfectivo.Text);
                    ticket.TextoIzquierda("Cheque:    $" + txtCheque.Text);
                    ticket.TextoIzquierda("T. Credito $: " + txtCredito.Text);
                    ticket.TextoIzquierda("Recibido: $" + txtRecibido.Text + " Cambio: $" + txtCambio.Text);
                }
                else
                {
                    if (ckbCheque.Checked && ckbTarjeta.Checked)
                    {
                        //ticket.TextoIzquierda("Cheque:  $" + txtEfectivo.Text);
                        ticket.TextoIzquierda("Cheque:    $" + txtCheque.Text);
                        ticket.TextoIzquierda("T. Credito $: " + txtCredito.Text);
                        ticket.TextoIzquierda("Recibido: $" + txtRecibido.Text + " Cambio: $" + txtCambio.Text);
                    }
                    else
                    {
                        if (ckbTarjeta.Checked && ckbEfectivo.Checked)
                        {
                            ticket.TextoIzquierda("Efectivo:  $" + txtEfectivo.Text);
                            //ticket.TextoIzquierda("Cheque:    $" + txtCheque.Text);
                            ticket.TextoIzquierda("T. Credito $: " + txtCredito.Text);
                            ticket.TextoIzquierda("Recibido: $" + txtRecibido.Text + " Cambio: $" + txtCambio.Text);
                        }
                        else
                        {
                            if (ckbCheque.Checked && ckbEfectivo.Checked)
                            {
                                ticket.TextoIzquierda("Efectivo:  $" + txtEfectivo.Text);
                                ticket.TextoIzquierda("Cheque:    $" + txtCheque.Text);
                                // ticket.TextoIzquierda("T. Credito $: " + txtCredito.Text);
                                ticket.TextoIzquierda("Recibido: $" + txtRecibido.Text + " Cambio: $" + txtCambio.Text);
                            }
                            else
                            {
                                if (ckbEfectivo.Checked)
                                {
                                    ticket.TextoIzquierda("Efectivo: $" + txtEfectivo.Text);
                                    ticket.TextoIzquierda("Recibido: $" + txtEfectivo.Text + " Cambio: $" + txtCambio.Text);
                                    //ticket.TextoIzquierda("Recibido: $" + txtRecibido.Text + " Cambio: $" + txtCambio.Text);
                                }
                                else
                                {
                                    if (ckbCheque.Checked)
                                    {
                                        ticket.TextoIzquierda("Cheque:   $" + txtCheque.Text);
                                        ticket.TextoIzquierda("Recibido: $" + txtRecibido.Text + " Cambio: $" + txtCambio.Text);
                                    }
                                    else
                                    {
                                        if (ckbTarjeta.Checked)
                                        {
                                            ticket.TextoIzquierda("T. Credito $: " + txtCredito.Text);
                                            ticket.TextoIzquierda("Recibido: $" + txtRecibido.Text + " Cambio: $" + txtCambio.Text);
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            //Texto final del Ticket.
            
            if (Program.BoolAutorizadoImprimir)
            {
                ticket.TextoIzquierda("");
                ticket.TextoIzquierda("ARTICULOS VENDIDOS: " + cantidadVendida);
                ticket.TextoIzquierda("");
                String PIEFA = Program.piefactura;
                string[] PIES = PIEFA.Split('\n');
                ticket.TextoCentro(PIES[0]);
                ticket.TextoCentro(PIES[1]);
                ticket.TextoCentro(PIES[2]);
                ticket.TextoCentro(PIES[3]);
                ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            }
            ticket.CortaTicket();

            String ruta = @"\\AIRCONTROL\BodegaPedido";
            ticket.ImprimirTicket(ruta);

            //ticket.ImprimirTicket("Generic / Text Only");//Nombre de la impresora ticketera


            //}



        }


        private void ImprimirenRed()
        {
            CrearTicket ticket = new CrearTicket();
            int numcaja = Program.em.Caja;
            //PrintDialog pd = new PrintDialog();
            //pd.PrinterSettings = new PrinterSettings();
            //if (DialogResult.OK == pd.ShowDialog(this))
            //{
                ticket.TextoCentro(""+Program.nombreempresa);
            ticket.TextoCentro("              ");
            ticket.TextoCentro("PEDIDO A BODEGA");
            ticket.TextoCentro("              ");
            ticket.TextoIzquierda("USUARIO: " + Program.Usuario);
                ticket.TextoIzquierda( "# CAJA: " + numcaja.ToString("D3"));
            ticket.TextoIzquierda("                 ");
            ticket.TextoIzquierda("");
            string[] h = DateTime.Now.TimeOfDay.ToString().Split('.');
                ticket.TextoIzquierda("Fecha: " + Program.FecaInicio + "          " + h[0]);
            ticket.TextoIzquierda("                 ");
            ticket.TextoIzquierda("                 ");
            ticket.lineasAsteriscos();
            ticket.TextoIzquierda("                 ");
            for (int i = 0; i < pedidos.Count; i++)//dgvLista es el nombre del datagridview
                {
                    string[] vector = pedidos[i].Split(';');
                    ticket.AgregarDatosRed(vector[0],Convert.ToInt32(vector[1]));
                }
                
                ticket.lineasAsteriscos();
            //ticket.TextoIzquierda("Corporacion AirNet");
            //ticket.TextoIzquierda("Corporacion AirNet" );
                ticket.CortaTicket();
            //pd.PrinterSettings.PrinterName = "\\SCLIENTE-PC\\PedidoBodega";
            //MessageBox.Show(""+ pd.PrinterSettings.PrinterName);
            //string r = pd.PrinterSettings.PrinterName;
            // MessageBox.Show(@"\\SCLIENTE-PC\PedidoBodega");
           String ruta = @"\\AIRCONTROL\BodegaPedido";
            ticket.ImprimirTicket(ruta);
               // RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, "");
            //}
            pedidos.Clear();
        }

        private void Calcular()
        {
            float totalCheque=0, TotalCredito = 0;
            if (ckbCheque.Checked && ckbEfectivo.Checked && ckbTarjeta.Checked)
            {
                string valor = "";
                float suma = 0.0f;
                valor =Convert.ToString(dgvCheque.Rows[0].Cells[0].Value);
                if (valor!="")
                {
                    for (int i = 0; i < dgvCheque.RowCount; i++)
                    {
                        if (dgvCheque.Rows[i].Cells[0].Value!=null)
                        {
                            string con =Convert.ToString(dgvCheque.Rows[i].Cells[5].Value);
                            con = Funcion.reemplazarcaracterViceversa(con);
                            totalCheque += Convert.ToSingle(con);
                        }
                        else
                        {
                            break;
                        }
                    }
                    valor = "";
                    
                   // float t = totalCheque + Convert.ToSingle(txtRecibido.Text);
                    //txtRecibido.Text = "" + t.ToString("#####0.00");
                } 

                 valor =Convert.ToString(dgvTarjeta.Rows[0].Cells[0].Value);
                if (valor!="")
                {
                    for (int i = 0; i < dgvTarjeta.RowCount; i++)
                    {
                        if (dgvTarjeta.Rows[i].Cells[0].Value != null)
                        {
                            string con = Convert.ToString(dgvTarjeta.Rows[i].Cells[2].Value);
                            con = Funcion.reemplazarcaracterViceversa(con);
                            TotalCredito += Convert.ToSingle(con);
                        }
                        else
                        {
                            break;
                        }
                        
                    }
                    
                    //float t = totalCheque + Convert.ToSingle(txtRecibido.Text);
                    //txtRecibido.Text = "" + t.ToString("#####0.00");
                }

                if (txtEfectivo.Text != "")
                {
                    suma = TotalCredito + Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtEfectivo.Text))+totalCheque;
                }
                else
                {
                    suma = TotalCredito + 0+totalCheque;
                }

               
                float cambio = Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtRecibido.Text))- Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtTotalPagar.Text));

                if (cambio<0)
                {
                    cambio *= -1;
                }
                txtCheque.Text = "" + totalCheque.ToString("#####0.00");
                txtCredito.Text = "" + TotalCredito.ToString("#####0.00");
                txtRecibido.Text = suma.ToString("#####0.00");
                txtCambio.Text = "" + cambio.ToString("#####0.00");

            }
            else
            {
                if (ckbTarjeta.Checked && ckbEfectivo.Checked)
                {
                    string valor = "";
                    float suma = 0.0f,cambio=0.0f;
                    valor = Convert.ToString(dgvTarjeta.Rows[0].Cells[0].Value);
                    if (valor != "")
                    {
                        for (int i = 0; i < dgvTarjeta.RowCount; i++)
                        {
                            if (dgvTarjeta.Rows[i].Cells[0].Value != null)
                            {
                                string con = Convert.ToString(dgvTarjeta.Rows[i].Cells[2].Value);
                                con = Funcion.reemplazarcaracterViceversa(con);
                                TotalCredito += Convert.ToSingle(con);
                            }
                            else
                            {
                                break;
                            }

                        }
                    }
                    if (txtEfectivo.Text!="")
                    {
                        suma = TotalCredito + Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtEfectivo.Text));
                    }
                    else
                    {
                        suma = TotalCredito +0;
                    }
                    cambio = suma -Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtTotalPagar.Text));
                    if (cambio<0)
                    {
                        cambio *= -1;
                    }
                    txtCredito.Text = "" + TotalCredito.ToString("#####0.00");
                    txtRecibido.Text=""+ suma.ToString("#####0.00");

                    txtCambio.Text=cambio.ToString("#####0.00");

                }
                else
                {
                    if (ckbCheque.Checked&& ckbEfectivo.Checked)
                    {
                        string valor = "";
                        float suma = 0.0f, cambio = 0.0f;
                        valor =Convert.ToString(dgvCheque.Rows[0].Cells[0].Value);
                        if (valor != "")
                        {
                            for (int i = 0; i < dgvCheque.RowCount; i++)
                            {
                                if (dgvCheque.Rows[i].Cells[0].Value != null)
                                {
                                    string con = Convert.ToString(dgvCheque.Rows[i].Cells[5].Value);
                                    con = Funcion.reemplazarcaracterViceversa(con);
                                    totalCheque += Convert.ToSingle(con);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }

                        if (txtEfectivo.Text != "")
                        {
                            suma = totalCheque + Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtEfectivo.Text));
                        }
                        else
                        {
                            suma = totalCheque + 0;
                        }
                        cambio = suma - Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtTotalPagar.Text));
                        if (cambio<0)
                        {
                            cambio *= -1;
                        }
                        txtCheque.Text=totalCheque.ToString("#####0.00");
                        txtRecibido.Text=suma.ToString("#####0.00");
                        txtCambio.Text = cambio.ToString("#####0.00");

                    }
                    else
                    {
                        if (ckbCheque.Checked && ckbTarjeta.Checked)
                        {
                            string valor = "";
                            valor = Convert.ToString(dgvTarjeta.Rows[0].Cells[0].Value);
                            if (valor!="")
                            {
                                for (int i = 0; i < dgvTarjeta.RowCount; i++)
                                {
                                    if (dgvTarjeta.Rows[i].Cells[0].Value != null)
                                    {
                                        string con = Convert.ToString(dgvTarjeta.Rows[i].Cells[2].Value);
                                        con = Funcion.reemplazarcaracterViceversa(con);
                                        TotalCredito += Convert.ToSingle(con);
                                    }
                                    else
                                    {
                                        break;
                                    }

                                }
                            }
                           
                            
                            valor =Convert.ToString(dgvCheque.Rows[0].Cells[0].Value);
                            if (valor!="")
                            {
                                for (int i = 0; i < dgvCheque.RowCount; i++)
                                {
                                    if (dgvCheque.Rows[i].Cells[0].Value != null)
                                    {
                                        string con = Convert.ToString(dgvCheque.Rows[i].Cells[5].Value);
                                        con = Funcion.reemplazarcaracterViceversa(con);
                                        totalCheque += Convert.ToSingle(con);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            
                           

                            float r = TotalCredito + totalCheque;
                            float cam = r - Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtTotalPagar.Text));
                            if (cam<0)
                            {
                                cam *= -1;
                            }
                            txtCredito.Text = "" + TotalCredito.ToString("#####0.00");
                            txtCambio.Text=cam.ToString("#####0.00");
                            txtCheque.Text = "" + totalCheque.ToString("#####0.00");
                            txtRecibido.Text= r.ToString("#####0.00");
                        }
                        else
                        {
                            if (ckbCheque.Checked)
                            {
                                for (int i = 0; i < dgvCheque.RowCount; i++)
                                {
                                    if (dgvCheque.Rows[i].Cells[0].Value != null)
                                    {
                                        string con = Convert.ToString(dgvCheque.Rows[i].Cells[5].Value);
                                        con = Funcion.reemplazarcaracterViceversa(con);
                                        totalCheque += Convert.ToSingle(con);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                
                               
                                //if (Convert.ToSingle(r) >= total)
                                //{

                                   // reci = Convert.ToSingle(txtCheque.Text);
                                    float cambio = totalCheque - Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtTotalPagar.Text));
                                    if (cambio < 0)
                                    {
                                        cambio *= -1;
                                    }
                                txtCheque.Text = "" + totalCheque.ToString("#####0.00");
                                txtCambio.Text = cambio.ToString("#####0.00");
                                txtRecibido.Text = txtCheque.Text;
                               
                            }
                            else
                            {
                                //TODO BIEN
                                if (ckbEfectivo.Checked)
                                {
                                    Double reci = 0;
                                    string r = "";

                                    //if (Convert.ToSingle(r) >= total)
                                    //{
                                    if (txtEfectivo.Text != "")
                                    {
                                        r = txtEfectivo.Text;
                                    }
                                    else
                                    {
                                        r = "0";
                                    }
                                    reci = Convert.ToDouble(Funcion.reemplazarcaracterViceversa(r));
                                    //string prueba = Funcion.reemplazarcaracter(txtTotalPagar.Text);
                                    Double tpagar = Convert.ToDouble(Funcion.reemplazarcaracterViceversa(txtTotalPagar.Text));
                                    Double cambio = tpagar - reci;
                                    if (cambio < 0)
                                    {
                                        cambio *= -1;
                                    }
                                    //  else
                                    //{
                                    //    txtCambio.Text = Funcion.reemplazarcaracter(cambio.ToString("#####0.00"));
                                    //}
                                    if (reci < tpagar)
                                    {
                                        txtCambio.Text = "";
                                    }
                                    else
                                    {
                                        txtCambio.Text = Funcion.reemplazarcaracter(cambio.ToString("#####0.00"));
                                    }
                                    //}
                                    //else
                                    //{
                                    //    txtCambio.Text = "0.00";
                                    //}
                                    txtRecibido.Text = txtEfectivo.Text;
                                }
                                else
                                {
                                    if (ckbTarjeta.Checked)
                                    {
                                        for (int i = 0; i < dgvTarjeta.RowCount; i++)
                                        {
                                            if (dgvTarjeta.Rows[i].Cells[0].Value != null)
                                            {
                                                string con = Convert.ToString(dgvTarjeta.Rows[i].Cells[2].Value);
                                                con = Funcion.reemplazarcaracterViceversa(con);
                                                TotalCredito += Convert.ToSingle(con);
                                            }
                                            else
                                            {
                                                break;
                                            }

                                        }


                                        float cambio = TotalCredito - Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtTotalPagar.Text));
                                        if (cambio < 0)
                                        {
                                            cambio *= -1;
                                        }
                                        txtCredito.Text = "" + TotalCredito.ToString("#####0.00");
                                        txtCambio.Text = cambio.ToString("#####0.00");
                                        txtRecibido.Text = txtCredito.Text;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

    }

}
