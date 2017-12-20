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
    public partial class FrmInformesRentenciones : Form
    {
        public FrmInformesRentenciones()
        {
            InitializeComponent();
        }
        Consultas objConsulta = new Consultas();
        string cadenaGeneral = "select * from Vista_InformeRetenciones", cadeCondicion = "", condicionEntre="", añoDesde = "", 
            fechaDesde = "", añoHasta = "", fechaHasta = "", mesDesde = "", diaDesde = "", mesHasta = "", diaHasta = "", 
            cadenaConsultar = "";
        

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
                dgvInformeRetenciones.Rows.Add();
            cadenaConsultar = cadenaGeneral;
            //llenarDgv();
        }

        public void obtenerFechas()
        {
            añoDesde = Convert.ToString(dtpDesde.Value.Date.Year);
            mesDesde = Convert.ToString(dtpDesde.Value.Date.Month);
            diaDesde = Convert.ToString(dtpDesde.Value.Date.Day);
            fechaDesde = añoDesde + "-" + mesDesde + "-" + diaDesde;
            añoHasta = Convert.ToString(dtpHasta.Value.Date.Year);
            mesHasta = Convert.ToString(dtpHasta.Value.Date.Month);
            diaHasta = Convert.ToString(dtpHasta.Value.Date.Day);
            fechaHasta = añoHasta + "-" + mesHasta + "-" + diaHasta;
        }

        private void txtConsultar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cadeCondicion = " NOMBRES like '%" + txtConsultar.Text + "%'";
                cadeCondicion = cadeCondicion + " or NUMERODOCUMENTOPROVEEDOR like '%" + txtConsultar.Text + "%' or SERIE2PROVEEDOR like '%" + txtConsultar.Text + "%' or SERIE1PROVEEDOR like '%" + txtConsultar.Text + "%'";
                llenarDgv();
            }
            catch (Exception)
            {
            }
            //---------------------FALTA REALIZAR EL MINIMO Y MAXIMO DE LOS DATA TIME PIKER----------------------------
            //DataTable fechas = objConsulta.BoolDataTable("select FECHA from TbEncabezadoFactura ORDER BY FECHA");
            //dtpDesde.MinDate = Convert.ToDateTime(fechas.Rows[0]);
            //---------------------------------------------------------------------------------------------------------
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            obtenerFechas();
            condicionEntre = " FECHARETENCION between '" + fechaDesde + "' AND '"+ fechaHasta +"'";
            //objConsulta.boolLlenarDataGridView(dgvInformeVentas, cadenaConsultar);
            llenarDgv();
        }
        public void llenarDgv()
        {
            string and = "", where = "";
            if (cadeCondicion == "" && condicionEntre == "")
            {
                where = "";
                and = "";
            }
            else if (cadeCondicion != "" || condicionEntre != "")
                where = " where ";
            if (cadeCondicion != "" && condicionEntre != "")
            {
                where = " where ";
                and = " and ";
            }
            cadenaConsultar = cadenaGeneral + where + cadeCondicion + and + condicionEntre;
            DataTable dt = objConsulta.BoolDataTable(cadenaConsultar);
            if (dt.Rows.Count > 0)
            {//Select EF.SUCURSAL, EF.CAJA, EF.NFACTURA, EF.FECHA, U.USUARIO,	C.NOMBRES + ' ' + C.APELLIDOS AS NOMBRECLIENTE" +
                dgvInformeRetenciones.Rows.Clear();
                for (int i = 0; i < 20; i++)
                    dgvInformeRetenciones.Rows.Add();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    if (i == dgvInformeRetenciones.RowCount - 1)
                        dgvInformeRetenciones.Rows.Add();
                    string numeros = Convert.ToInt32(row["SERIE1PROVEEDOR"]).ToString("D3") + Convert.ToInt32(row["SERIE2PROVEEDOR"]).ToString("D3")+ Convert.ToInt32(row["NUMERODOCUMENTOPROVEEDOR"]).ToString("D9");
                    dgvInformeRetenciones.Rows[i].Cells[0].Value = numeros;
                    dgvInformeRetenciones.Rows[i].Cells[1].Value = row["FECHARETENCION"];
                    dgvInformeRetenciones.Rows[i].Cells[2].Value = row["NOMBRES"];
                    dgvInformeRetenciones.Rows[i].Cells[3].Value = row["DESCRIPCION"];
                    dgvInformeRetenciones.Rows[i].Cells[4].Value = row["RETENCION"];
                    dgvInformeRetenciones.Rows[i].Cells[6].Value = row["MONTO"];

                }
            }
            else
            {
                dgvInformeRetenciones.Rows.Clear();
                for (int i = 0; i < 20; i++)
                    dgvInformeRetenciones.Rows.Add();
            }

        }
    }
}
