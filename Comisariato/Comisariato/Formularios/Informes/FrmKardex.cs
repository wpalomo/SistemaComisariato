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

namespace Comisariato.Formularios.Informes
{
    public partial class FrmKardex : Form
    {
        public FrmKardex()
        {
            InitializeComponent();
        }
        Consultas objConsulta = new Consultas();
        private void FrmKardex_Load(object sender, EventArgs e)
        {
            objConsulta.BoolLlenarComboBox(cbCategoria, "Select IDCATEGORIA as ID, Descripcion as Texto from TbCategoria");
            for (int i = 0; i < 17; i++)
                dgvKardex.Rows.Add();
        }

        private void btnGenerarKardex_Click(object sender, EventArgs e)
        {
            DataTable datosCompra = objConsulta.BoolDataTable("select e.SERIE1+''+e.SERIE2+''+e.NUMERO as NFactura, d.PRECIOCOMRPA, e.FECHAORDENCOMPRA, d.CANTIDAD" +
            " from TbEncabezadoyPieCompra e, TbDetalleCompra d, TbProducto p  where e.IDEMCABEZADOCOMPRA = d.IDENCABEZADOCOMPRA and" +
            " d.CODIGOBARRAPRODUCTO = p.CODIGOBARRA and p.CODIGOBARRA = '"+ txtProducto.Text +"' and e.FECHAORDENCOMPRA between  '"+ Convert.ToString(dtpDesde.Value) + "' and '" + Convert.ToString(dtpHasta.Value) + "' order by e.FECHAORDENCOMPRA");

            DataTable datosVenta = objConsulta.BoolDataTable("select e.SUCURSAL, e.CAJA, e.NFACTURA, d.PRECIO, d.CANTIDAD, e.FECHA" +
            " from TbEncabezadoFactura e, TbDetalleFactura d, TbProducto p where e.IDFACTURA = d.NFACTURA and" +
            " d.CODIGOBARRAPRODUCTO = p.CODIGOBARRA and p.CODIGOBARRA = '" + txtProducto.Text + "' and e.FECHA between  '" + Convert.ToString(dtpDesde.Value) + "' and '" + Convert.ToString(dtpHasta.Value) + "' order by e.FECHA");


            if (datosCompra != null)
            {
                for (int i = 0; i < datosCompra.Rows.Count; i++)
                {
                    DataRow dtCompra = datosCompra.Rows[i];
                    dgvKardex.Rows[i].Cells[0].Value = dtCompra["FECHAORDENCOMPRA"];
                    dgvKardex.Rows[i].Cells[1].Value = "Compra S/F " + dtCompra["NFactura"];
                    dgvKardex.Rows[i].Cells[2].Value = dtCompra["CANTIDAD"];
                    dgvKardex.Rows[i].Cells[3].Value = dtCompra["PRECIOCOMRPA"];
                    dgvKardex.Rows[i].Cells[4].Value = Convert.ToSingle(dgvKardex.Rows[i].Cells[3].Value) * Convert.ToInt32(dgvKardex.Rows[i].Cells[2].Value);
                    if (i == dgvKardex.RowCount - 1)
                        dgvKardex.Rows.Add();
                    //dgvKardex.Rows.Insert(1,1);
                }
            }
            if (datosVenta != null)
            {
                for (int i = 0; i < datosVenta.Rows.Count; i++)
                {
                    int j = 0;
                    bool banderaIngreso = false;
                    DataRow dtVenta = datosVenta.Rows[i];
                    for (j = 0; j < dgvKardex.RowCount - 1; j++)
                    {
                        if (Convert.ToDateTime(dtVenta["FECHA"]) < Convert.ToDateTime(dgvKardex.Rows[j].Cells[0].Value))
                        {
                            int numeroFactura = Convert.ToInt32(dtVenta["NFactura"]), serie1 = Convert.ToInt32(dtVenta["SUCURSAL"]), serie2 = Convert.ToInt32(dtVenta["CAJA"]);
                            dgvKardex.Rows.Insert(j, 1);
                            dgvKardex.Rows[j].Cells[0].Value = dtVenta["FECHA"];
                            dgvKardex.Rows[j].Cells[1].Value = "Venta S/F " + serie1.ToString("D3") + serie2.ToString("D3") + numeroFactura.ToString("D9");
                            dgvKardex.Rows[j].Cells[5].Value = dtVenta["CANTIDAD"];
                            dgvKardex.Rows[j].Cells[6].Value = dtVenta["PRECIO"];
                            dgvKardex.Rows[j].Cells[7].Value = Convert.ToSingle(dgvKardex.Rows[j].Cells[3].Value) * Convert.ToInt32(dgvKardex.Rows[j].Cells[2].Value);
                            banderaIngreso = true;
                            break;
                        }
                        if (Convert.ToString(dgvKardex.Rows[j + 1].Cells[1].Value) == "")
                        {
                            j++;
                            break;
                        }
                    }
                    if (!banderaIngreso)
                    {
                        if (j == dgvKardex.RowCount - 1)
                            dgvKardex.Rows.Add();
                        int numeroFactura = Convert.ToInt32(dtVenta["NFactura"]), serie1 = Convert.ToInt32(dtVenta["SUCURSAL"]), serie2 = Convert.ToInt32(dtVenta["CAJA"]);
                        //dgvKardex.Rows.Insert(, 1);
                        dgvKardex.Rows[j].Cells[0].Value = dtVenta["FECHA"];
                        dgvKardex.Rows[j].Cells[1].Value = "Venta S/F " + serie1.ToString("D3") + serie2.ToString("D3") + numeroFactura.ToString("D9");
                        dgvKardex.Rows[j].Cells[5].Value = dtVenta["CANTIDAD"];
                        dgvKardex.Rows[j].Cells[6].Value = dtVenta["PRECIO"];
                        dgvKardex.Rows[j].Cells[7].Value = Convert.ToSingle(dgvKardex.Rows[j].Cells[3].Value) * Convert.ToInt32(dgvKardex.Rows[j].Cells[2].Value);
                    }
                }
                
            }
            calculoExistecia();
        }
        //calcular la existencia
        public void calculoExistecia()
        {
            for (int i = 0; i < dgvKardex.RowCount -1; i++)
            {
                string[] tipo = Convert.ToString(dgvKardex.Rows[i].Cells[1].Value).Split(' ');
                if (i == 0)
                {
                    dgvKardex.Rows[i].Cells[8].Value = dgvKardex.Rows[i].Cells[2].Value;
                    dgvKardex.Rows[i].Cells[9].Value = dgvKardex.Rows[i].Cells[3].Value;
                    dgvKardex.Rows[i].Cells[10].Value = dgvKardex.Rows[i].Cells[4].Value;
                }
            }
        }
    }
}
