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

namespace Comisariato.Formularios.Transacciones
{
    public partial class FrmDevolucionCompra : Form
    {
        public FrmDevolucionCompra()
        {
            InitializeComponent();
        }
        Consultas objConsultas = new Consultas();
        Bitacora bitacora = new Bitacora();
        EncabezadoNotaCredito objENC;
        DetalleNotaCredito objDNC;
        int encabezadoCompra = 0;
        bool ivaEstado = false;
        float sumasubiva = 0.0f, sumasubcero = 0.0f, totalpagar = 0.0f, ivatotal = 0.0f, sumaice = 0.0f, sumairbp = 0.0f, subtotalPie = 0.0f;
        private void FrmDevolucionCompra_Load(object sender, EventArgs e)
        {
            objConsultas.BoolLlenarComboBox(cbProveedor, "select IDPROVEEDOR AS ID, NOMBRES AS Texto from TbProveedor");
            objConsultas.seriesDocumentoRetencion(txtNumeroNC, txtSerie1NC, txtSerie2NC, txtAutorizacionNC, "NCRE", bitacora.LocalIPAddress());
            int i = 0;
            for (i = 0; i < 20; i++)
            {
                dgvProductosDevolucion.Rows.Add();
            }
            dgvProductosDevolucion.Rows[i].ReadOnly = true;
            dgvProductosDevolucion.Columns[10].ReadOnly = true;
            dgvProductosDevolucion.Columns[11].ReadOnly = true;
            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");
        }

        private void cbProveedor_Leave(object sender, EventArgs e)
        {
            if (txtSerie1.Text != "" && txtSerie2.Text != "" && txtNumero.Text != "" && cbProveedor.Text != "")
            {
                string sqlConsultar = "select e.IDEMCABEZADOCOMPRA, e.IMPUESTO, p.IVAESTADO, p.NOMBREPRODUCTO,d.CANTIDAD, d.CODIGOBARRAPRODUCTO, d.DESCUENTO, d.ICE, d.PRECIOCOMRPA,d.IRBP" +
                    " from TbEncabezadoyPieCompra e, TbDetalleCompra d, TbProducto p, TbProveedor pro" +
                    " where d.IDENCABEZADOCOMPRA = e.IDEMCABEZADOCOMPRA and p.CODIGOBARRA = d.CODIGOBARRAPRODUCTO" +
                    " and pro.IDPROVEEDOR = e.IDPROVEEDOR and e.SERIE1 = '" + txtSerie1.Text + "' and e.SERIE2 = '" + txtSerie2.Text +"' and e.NUMERO = '"+ txtNumero.Text +"'" +
                    " and e.IDPROVEEDOR = "+ cbProveedor.SelectedValue +"";
                DataTable dt = objConsultas.BoolDataTable(sqlConsultar);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = dt.Rows[i];
                        if (i == dgvProductosDevolucion.RowCount -1)
                        {
                            dgvProductosDevolucion.Rows.Add();
                        }
                        dgvProductosDevolucion.Rows[i].Cells[0].Value = row["CODIGOBARRAPRODUCTO"];//codigo
                        dgvProductosDevolucion.Rows[i].Cells[1].Value = row["NOMBREPRODUCTO"];//producto
                        dgvProductosDevolucion.Rows[i].Cells[2].Value = row["CANTIDAD"];//cantidad
                        dgvProductosDevolucion.Rows[i].Cells[3].Value = Funcion.reemplazarcaracter(row["PRECIOCOMRPA"].ToString());//precio
                        dgvProductosDevolucion.Rows[i].Cells[4].Value = Funcion.reemplazarcaracter(row["DESCUENTO"].ToString());//descuento
                        dgvProductosDevolucion.Rows[i].Cells[5].Value = Funcion.reemplazarcaracter(row["ICE"].ToString());//ice
                        dgvProductosDevolucion.Rows[i].Cells[6].Value = Funcion.reemplazarcaracter(row["IRBP"].ToString());//irbp
                        //dgvProductosDevolucion.Rows[i].Cells[10].ReadOnly = false;
                        dgvProductosDevolucion.Rows[i].Cells[11].ReadOnly = false;
                        txtImpuesto.Text = row["IMPUESTO"].ToString();
                        encabezadoCompra = Convert.ToInt32(row["IDEMCABEZADOCOMPRA"]);
                        ivaEstado = Convert.ToBoolean(row["IVAESTADO"]);
                        float precioCompra = Convert.ToSingle(Funcion.reemplazarcaracterViceversa(dgvProductosDevolucion.Rows[i].Cells[3].Value.ToString()));
                        float cantidad = Convert.ToInt32(dgvProductosDevolucion.Rows[i].Cells[2].Value.ToString());
                        float precioICE = Convert.ToSingle(Funcion.reemplazarcaracterViceversa(dgvProductosDevolucion.Rows[i].Cells[5].Value.ToString()));
                        float precioIRBP = Convert.ToSingle(Funcion.reemplazarcaracterViceversa(dgvProductosDevolucion.Rows[i].Cells[6].Value.ToString()));
                        float subtotalP = 0.0f;
                        float totalP = 0.0f;
                        string[] separadorPorcentaje = txtImpuesto.Text.Split('%');
                        int tipoIva = Convert.ToInt32(separadorPorcentaje[0]);
                        float ivaP = 0.0f;
                        if (ivaEstado)
                        {
                            ivaP = (((precioCompra + precioICE) * cantidad) * tipoIva) / 100;
                        }
                        else
                        {
                            ivaP = 0;
                        }
                        subtotalP = ((precioCompra + precioICE + precioIRBP) * cantidad);
                        totalP = subtotalP + ivaP;
                        dgvProductosDevolucion.Rows[i].Cells[8].Value = Funcion.reemplazarcaracter(Math.Round(ivaP, 2).ToString("#####0.00"));
                        dgvProductosDevolucion.Rows[i].Cells[7].Value = Funcion.reemplazarcaracter(Math.Round(subtotalP, 2).ToString("#####0.00"));
                        dgvProductosDevolucion.Rows[i].Cells[9].Value = Funcion.reemplazarcaracter(Math.Round(totalP, 2).ToString("#####0.00"));
                    }
                }
                Calcular(2);
            }
        }

        private void cbProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                dgvProductosDevolucion.Focus();
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            bool banderaCorrecto = false;
            if (txtTotalDevolucion.Text != "")
            {
                if (MessageBox.Show("¿Desea Gaurdar la Nota de Credito?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (txtSerie1.Text != "" && txtSerie2.Text != "" && txtNumero.Text != "")
                    {
                        objENC = new EncabezadoNotaCredito(txtSerie1NC.Text, txtSerie2NC.Text, txtNumeroNC.Text, encabezadoCompra, Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtTotalDevolucion.Text)));
                        string resultado = objENC.InsertarEncabezadoNC(objENC);
                        if (resultado == "Datos Guardados")
                        {
                            string idEncabezadoNC = objConsultas.ObtenerValorCampo("IDENCABEZADONOTACREDITO", "TbEncabezadoNotaCredito", " where IDENCABEZADOCOMPRA = " + encabezadoCompra + "");
                            for (int i = 0; i < dgvProductosDevolucion.RowCount - 1; i++)
                            {
                                objDNC = new DetalleNotaCredito(Convert.ToInt32(idEncabezadoNC), Convert.ToInt32(dgvProductosDevolucion.Rows[i].Cells[10].Value), Convert.ToString(dgvProductosDevolucion.Rows[i].Cells[0].Value));
                                if (Convert.ToString(dgvProductosDevolucion.Rows[i].Cells[10].Value) != "")
                                {
                                    string resultadoDetalle = objDNC.InsertarDetalleNC(objDNC);
                                    if (resultado == "Datos Guardados")
                                        banderaCorrecto = true;
                                    else if (resultado == "Error al Registrar")
                                    {
                                        banderaCorrecto = false;
                                        break;
                                    }
                                    if (Convert.ToString(dgvProductosDevolucion.Rows[i + 1].Cells[0].Value) == "")
                                        break;
                                }
                            }
                            if (!banderaCorrecto)
                            {
                                MessageBox.Show("Error al guardar la Nota de Crédito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //string idEncabezadoNC = objConsultas.ObtenerValorCampo("IDENCABEZADONOTACREDITO", "TbEncabezadoNotaCredito", " where IDENCABEZADOCOMPRA = " + encabezadoCompra + "");
                                objConsultas.EjecutarSQL("DELETE FROM [dbo].[TbEncabezadoNotaCredito] WHEREz IDENCABEZADOCOMPRA = " + encabezadoCompra + "");
                                objConsultas.EjecutarSQL("DELETE FROM [dbo].[TbDetalleNotaCredito] WHEREz IDENCABEZADONOTACREDITO = " + idEncabezadoNC + "");
                            }
                            else
                                MessageBox.Show("Guardada correctamente la Nota de Crédito");
                        }
                        else if (resultado == "Error al Registrar")
                        {
                            MessageBox.Show("Error al guardar la Nota de Crédito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            objConsultas.EjecutarSQL("DELETE FROM [dbo].[TbEncabezadoNotaCredito] WHEREz IDENCABEZADOCOMPRA = " + encabezadoCompra + "");
                        }
                        else if(resultado == "Existe")
                            MessageBox.Show("Ya existe la Nota de Crédito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
                MessageBox.Show("No se a realizado ninguna devolución", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dgvProductosDevolucion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductosDevolucion.Columns[e.ColumnIndex].Name == "devolucion")
            {

                if (Convert.ToBoolean(dgvProductosDevolucion.Rows[e.RowIndex].Cells[11].Value) == true)
                {
                    dgvProductosDevolucion.Rows[e.RowIndex].Cells[10].ReadOnly = false;
                }
                else
                {
                    dgvProductosDevolucion.Rows[e.RowIndex].Cells[10].Value = "";
                    dgvProductosDevolucion.Rows[e.RowIndex].Cells[10].ReadOnly = true;
                }
            }
            if (dgvProductosDevolucion.Columns[e.ColumnIndex].Name == "cantidadDevolver")
            {
                if (Convert.ToBoolean(dgvProductosDevolucion.Rows[e.RowIndex].Cells[11].Value) == false)
                {
                    dgvProductosDevolucion.Rows[e.RowIndex].Cells[10].Value = "";
                    dgvProductosDevolucion.Rows[e.RowIndex].Cells[10].ReadOnly = true;
                }
                if (Convert.ToString(dgvProductosDevolucion.Rows[e.RowIndex].Cells[10].Value) != "")
                {
                    string cantidadProducto = objConsultas.ObtenerValorCampo("CANTIDAD", "TbProducto", "where CODIGOBARRA = '" + Convert.ToString(dgvProductosDevolucion.CurrentRow.Cells[0].Value) + "'");
                    if (Convert.ToInt32(cantidadProducto) >= Convert.ToInt32(dgvProductosDevolucion.CurrentRow.Cells[10].Value))
                    {
                        if (Convert.ToInt32(dgvProductosDevolucion.Rows[e.RowIndex].Cells[10].Value) <= Convert.ToInt32(dgvProductosDevolucion.Rows[e.RowIndex].Cells[2].Value))
                            Calcular(10);
                        else
                        {
                            MessageBox.Show("Cantidad a devolver debe ser menor o igual que la cantidad comprada", "Aviso", MessageBoxButtons.OK);
                            dgvProductosDevolucion.CurrentRow.Cells[10].Value = "";
                            SendKeys.Send("{UP}");
                        }
                    }
                    else if (Convert.ToInt32(cantidadProducto) == 0)
                        MessageBox.Show("Stock en 0 de este producto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("No existe cantidad suficiente para devolver", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }                
            }
        }
        private void Calcular(int posicion)
        {
            float cantidad = 0, pc = 0.0f;
            sumasubiva = 0.0f; sumasubcero = 0.0f; totalpagar = 0.0f; ivatotal = 0.0f; sumaice = 0.0f; sumairbp = 0.0f; subtotalPie = 0.0f;
            try
            {
                for (int i = 0; i < dgvProductosDevolucion.RowCount; i++)
                {
                    cantidad = Convert.ToInt32(dgvProductosDevolucion.Rows[i].Cells[posicion].Value);
                    if (Convert.ToSingle(dgvProductosDevolucion.Rows[i].Cells[8].Value.ToString()) != 0)
                    {
                        pc = Convert.ToSingle(Funcion.reemplazarcaracterViceversa(dgvProductosDevolucion.Rows[i].Cells[3].Value.ToString()));
                        sumasubiva += Convert.ToSingle(cantidad * pc);

                    }
                    if (Convert.ToSingle(dgvProductosDevolucion.Rows[i].Cells[8].Value.ToString()) == 0)
                    {
                        pc = Convert.ToSingle(Funcion.reemplazarcaracterViceversa(dgvProductosDevolucion.Rows[i].Cells[3].Value.ToString()));
                        sumasubcero += Convert.ToSingle(cantidad * pc);
                    }
                    sumaice += Convert.ToSingle(Funcion.reemplazarcaracterViceversa(dgvProductosDevolucion.Rows[i].Cells[5].Value.ToString())) * Convert.ToInt32(dgvProductosDevolucion.Rows[i].Cells[posicion].Value);
                    sumairbp += Convert.ToSingle(Funcion.reemplazarcaracterViceversa(dgvProductosDevolucion.Rows[i].Cells[6].Value.ToString())) * Convert.ToInt32(dgvProductosDevolucion.Rows[i].Cells[posicion].Value);
                    if (Convert.ToString(dgvProductosDevolucion.Rows[i + 1].Cells[0].Value) == "")
                    {
                        break;
                    }
                }
                ivatotal = (sumasubiva + sumaice) * 0.12f;
                subtotalPie = sumasubcero + sumasubiva;
                totalpagar = sumairbp + sumaice + subtotalPie + ivatotal;
                if (posicion == 2)
                    txtTotal.Text = Funcion.reemplazarcaracter(Math.Round(totalpagar, 2).ToString("#####0.00"));
                else
                    txtTotalDevolucion.Text = Funcion.reemplazarcaracter(Math.Round(totalpagar, 2).ToString("#####0.00"));

                sumasubiva = Convert.ToSingle(Math.Round(sumasubiva, 6));
                ivatotal = Convert.ToSingle(Math.Round(ivatotal, 6));
                sumasubcero = Convert.ToSingle(Math.Round(sumasubcero, 6));
                sumaice = Convert.ToSingle(Math.Round(sumaice, 6));
                sumairbp = Convert.ToSingle(Math.Round(sumairbp, 6));
                subtotalPie = Convert.ToSingle(Math.Round(subtotalPie, 6));
                totalpagar = Convert.ToSingle(Math.Round(totalpagar, 6));
            }
            catch (Exception EX)
            {
            }
        }
    }
}
