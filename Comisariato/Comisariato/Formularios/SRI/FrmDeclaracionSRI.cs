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
            string añoDesde = Convert.ToString(dtpDesde.Value.Date.Year);
            string mesDesde = Convert.ToString(dtpDesde.Value.Date.Month);
            string diaDesde = Convert.ToString(dtpDesde.Value.Date.Day);
            string fechaDesde = añoDesde + "-" + mesDesde + "-" + diaDesde;
            string añoHasta = Convert.ToString(dtpHasta.Value.Date.Year);
            string mesHasta = Convert.ToString(dtpHasta.Value.Date.Month);
            string diaHasta = Convert.ToString(dtpHasta.Value.Date.Day);
            string fechaHasta = añoHasta + "-" + mesHasta + "-" + diaHasta;
            string consultaVenta = "select SUM(d.SUBTOTAL0) as Sub0, sum(d.SUBTOTAL12) as Sub12,sum(d.IVA) as Iva, sum(d.TOTAPAGAR) as TotalPagar" +
                                " from TbEncabezadoFactura e, TbDetallePago d" +
                                " where e.IDFACTURA = d.IDENCABEZADOFACT and(e.FECHA between '"+ fechaDesde + "' and '" + fechaHasta + "')";            
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
        }
    }
}
