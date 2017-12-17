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
                        dgvProductosDevolucion.Rows[i].Cells[3].Value = row["PRECIOCOMRPA"];//precio
                        dgvProductosDevolucion.Rows[i].Cells[4].Value = row["DESCUENTO"];//descuento
                        dgvProductosDevolucion.Rows[i].Cells[5].Value = row["ICE"];//ice
                        dgvProductosDevolucion.Rows[i].Cells[6].Value = row["IRBP"];//irbp
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
                txtBuscar.Focus();
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (txtSerie1.Text != "" && txtSerie2.Text != "" && txtNumero.Text != "")
            {
                objENC = new EncabezadoNotaCredito(txtSerie1NC.Text, txtSerie2NC.Text, txtNumeroNC.Text, encabezadoCompra, Convert.ToSingle(txtTotalDevolucion.Text));
                string resultado = objENC.InsertarEncabezadoNC(objENC);
                if (resultado == "Datos Guardados")
                {
                    string idEncabezadoNC = objConsultas.ObtenerValorCampo("IDENCABEZADONOTACREDITO", "TbEncabezadoNotaCredito", " where IDENCABEZADOCOMPRA = " + encabezadoCompra +"");
                    for (int i = 0; i < dgvProductosDevolucion.RowCount - 1; i++)
                    {
                        objDNC = new DetalleNotaCredito(Convert.ToInt32(idEncabezadoNC), Convert.ToInt32(dgvProductosDevolucion.Rows[i].Cells[10].Value), Convert.ToString(dgvProductosDevolucion.Rows[i].Cells[0]));
                        string resultadoDetalle = objDNC.InsertarDetalleNC(objDNC);
                        if (resultado == "Datos Guardados")
                        {
                        }
                        else if (resultado == "Error al Registrar")
                        {
                            MessageBox.Show("Error al guardar la Nota de Crédito", "Aviso", MessageBoxButtons.OK);
                        }
                    }
                }
                else if (resultado == "Error al Registrar")
                {
                    MessageBox.Show("Error al guardar la Nota de Crédito", "Aviso", MessageBoxButtons.OK);
                }
            }
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
            }
        }
    }
}
