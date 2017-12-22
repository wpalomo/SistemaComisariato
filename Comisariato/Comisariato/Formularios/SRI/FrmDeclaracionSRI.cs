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

namespace Comisariato.Formularios.SRI
{
    public partial class FrmDeclaracionSRI : Form
    {
        public FrmDeclaracionSRI()
        {
            InitializeComponent();
        }
        Consultas objConsultas = new Consultas();
        private void FrmDeclaracionSRI_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                dgvRetencion.Rows.Add();
            }
        }
        private void btnGenerarKardex_Click(object sender, EventArgs e)
        {
            try
            {
                string añoDesde = Convert.ToString(dtpDesde.Value.Date.Year);
                string mesDesde = Convert.ToString(dtpDesde.Value.Date.Month);
                string diaDesde = Convert.ToString(dtpDesde.Value.Date.Day);
                string fechaDesde = añoDesde + "-" + mesDesde + "-" + diaDesde;
                string añoHasta = Convert.ToString(dtpHasta.Value.Date.Year);
                string mesHasta = Convert.ToString(dtpHasta.Value.Date.Month);
                string diaHasta = Convert.ToString(dtpHasta.Value.Date.Day);
                string fechaHasta = añoHasta + "-" + mesHasta + "-" + diaHasta;
                //REPORTE VENTA
                string consultaVenta = "select SUM(d.SUBTOTAL0) as Sub0, sum(d.SUBTOTAL12) as Sub12,sum(d.IVA) as Iva, sum(d.TOTAPAGAR) as TotalPagar" +
                                    " from TbEncabezadoFactura e, TbDetallePago d" +
                                    " where e.IDFACTURA = d.IDENCABEZADOFACT and(e.FECHA between '" + fechaDesde + "' and '" + fechaHasta + "')";
                DataTable dt = objConsultas.BoolDataTable(consultaVenta);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = dt.Rows[i];
                        txtExentoVenta.Text = row["Sub0"].ToString();
                        txtGravadoVenta.Text = row["Sub12"].ToString();
                        txtIvaVenta.Text = row["Iva"].ToString();
                        txtTotalVenta.Text = row["TotalPagar"].ToString();
                    }
                }
                //REPORTE COMPRA
                string consultaCompra = "select SUM(d.SUBTOTAL0) as Sub0, sum(d.SUBTOTALIVA) as Sub12,sum(d.TOTALIVA) as Iva, sum(d.TOTAL) as TotalPagar, " +
                                        " sum(d.TOTALICE) as Ice, sum(d.TOTALIRBP) as Irbp" +
                                        " from TbEncabezadoyPieCompra d where d.FECHAORDENCOMPRA between '" + fechaDesde + "' and '" + fechaHasta + "'";
                dt = objConsultas.BoolDataTable(consultaCompra);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = dt.Rows[i];
                        txtExentoCompra.Text = row["Sub0"].ToString();
                        txtGravadoCompra.Text = row["Sub12"].ToString();
                        txtIvaCompra.Text = row["Iva"].ToString();
                        txtTotalCompra.Text = row["TotalPagar"].ToString();
                        txtIceCompra.Text = row["Ice"].ToString();
                        txtIrbpCompra.Text = row["Irbp"].ToString();
                    }
                }
                //REPORTE RETENCION
                String consultaRetencion = "select do.IDRETENCION, c.DESCRIPCION, c.RETENCION, do.MONTO from TbEncabezadoOrdenGiro eo, TbDetalleOrdenGiro do, TbCodigoSRI c" +
                                            " where do.IDENCABEZADOORDENGIRO = eo.IDORDENGIRO and eo.FECHAORDENGIRO between '"+fechaDesde+ "' and '" + fechaHasta + "'" +
                                            " and c.IDCODIGOSRI = do.IDRETENCION";
                dt = objConsultas.BoolDataTable(consultaRetencion);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = dt.Rows[i];
                        dgvRetencion.Rows[i].Cells[0].Value = row["DESCRIPCION"].ToString();
                        dgvRetencion.Rows[i].Cells[1].Value = row["RETENCION"].ToString();
                        dgvRetencion.Rows[i].Cells[2].Value = row["MONTO"].ToString();
                        dgvRetencion.Rows[i].Cells[3].Value = row["IDRETENCION"].ToString();
                        if (i == dgvRetencion.RowCount - 1)
                            dgvRetencion.Rows.Add();
                    }
                }
                else
                {
                    dgvRetencion.Rows.Clear();
                    for (int i = 0; i < 15; i++)
                    {
                        dgvRetencion.Rows.Add();
                    }
                }
                for (int i = 0; i < dgvRetencion.RowCount - 1; i++)
                {
                    for (int j = i+1; j < dgvRetencion.RowCount - 1; j++)
                    {
                        if (Convert.ToString(dgvRetencion.Rows[i].Cells[3].Value) == Convert.ToString(dgvRetencion.Rows[j].Cells[3].Value))
                        {
                            if (Convert.ToString(dgvRetencion.Rows[i].Cells[1].Value) != "")
                            {
                                if (Convert.ToString(dgvRetencion.Rows[j].Cells[2].Value) == "")
                                    dgvRetencion.Rows[j].Cells[2].Value = "0";
                                if (Convert.ToString(dgvRetencion.Rows[i].Cells[2].Value) == "")
                                    dgvRetencion.Rows[i].Cells[2].Value = "0";
                                dgvRetencion.Rows[i].Cells[2].Value = Convert.ToSingle(dgvRetencion.Rows[i].Cells[2].Value) + Convert.ToSingle(dgvRetencion.Rows[j].Cells[2].Value);
                                dgvRetencion.Rows.Remove(dgvRetencion.Rows[j]);
                                dgvRetencion.Rows.Add();
                            }
                        }
                        if (Convert.ToString(dgvRetencion.Rows[j].Cells[0].Value) == "")
                            break;
                    }
                    if (Convert.ToString(dgvRetencion.Rows[i].Cells[0].Value) == "")
                        break;
                }
                //

                string consultaNC = "select SUM(SUBTOTAL0) AS Exento, SUM(SUBTOTAL12) as Gravado, SUM(IVA) as IVA, SUM(TOTALDEVOLUCION) as TOTAL " +
                                    " from TbEncabezadoNotaCredito where FECHA between '"+ fechaDesde +"' and '"+ fechaHasta +"'";
                dt = objConsultas.BoolDataTable(consultaNC);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = dt.Rows[i];
                        txtExentoNC.Text = row["Exento"].ToString();
                        txtGravadoNC.Text = row["Gravado"].ToString();
                        txtIvaNC.Text = row["IVA"].ToString();
                        txtTotalNC.Text = row["TOTAL"].ToString();
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
