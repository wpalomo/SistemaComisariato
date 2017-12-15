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
        }

        private void cbProveedor_Leave(object sender, EventArgs e)
        {
            if (txtSerie1.Text != "" && txtSerie2.Text != "" && txtNumero.Text != "" && cbProveedor.Text != "")
            {
                string sqlConsultar = "select e.IDEMCABEZADOCOMPRA, p.NOMBREPRODUCTO,d.CANTIDAD, d.CODIGOBARRAPRODUCTO, d.DESCUENTO, d.ICE, d.PRECIOCOMRPA,d.IRBP" +
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

                    }
                }
            }
        }
    }
}
