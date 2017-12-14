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
    public partial class FrmInformeVentas : Form
    {
        public FrmInformeVentas()
        {
            InitializeComponent();
        }
        Consultas objConsulta = new Consultas();
        string cadenaGeneral = "Select EF.SUCURSAL, EF.CAJA, EF.NFACTURA, EF.FECHA, U.USUARIO,	C.NOMBRES + ' ' + C.APELLIDOS AS NOMBRECLIENTE" +
" from TbEncabezadoFactura EF, TbEmpleado E, TbCliente C, TbUsuario U where E.IDEMPLEADO = EF.IDEMPLEADO AND C.IDCLIENTE = EF.IDCLIENTE" +
" AND U.IDEMPLEADO = E.IDEMPLEADO", cadeCondicion = "", condicionEntre="";
        private void FrmVentas_Load(object sender, EventArgs e)
        {
            objConsulta.boolLlenarDataGridView(dgvInformeVentas, cadenaGeneral);
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            string añoDesde = Convert.ToString(dtpDesde.Value.Date.Year), mesDesde = Convert.ToString(dtpDesde.Value.Date.Month), diaDesde = Convert.ToString(dtpDesde.Value.Date.Day);
            string fechaDesde = añoDesde + "-" + mesDesde + "-" + diaDesde;
            string añoHasta = Convert.ToString(dtpHasta.Value.Date.Year), mesHasta = Convert.ToString(dtpHasta.Value.Date.Month), diaHasta = Convert.ToString(dtpHasta.Value.Date.Day);
            string fechaHasta = añoHasta + "-" + mesHasta + "-" + diaHasta;
            condicionEntre = " AND FECHA between '" + fechaDesde + "' AND '" + fechaHasta + "'";
            string cadenaConsultar = cadenaGeneral + cadeCondicion + condicionEntre;
            objConsulta.boolLlenarDataGridView(dgvInformeVentas, cadenaConsultar);
        }

        private void txtConsultar_TextChanged(object sender, EventArgs e)
        {
            cadeCondicion = " AND (FECHA like '%"+ txtConsultar.Text +"%' OR USUARIO like '%" + txtConsultar.Text + "%' OR C.NOMBRES like '%" + txtConsultar.Text + "%' OR C.APELLIDOS like '%" + txtConsultar.Text + "%')";
            string cadenaConsultar = cadenaGeneral + cadeCondicion + condicionEntre;
            objConsulta.boolLlenarDataGridView(dgvInformeVentas, cadenaConsultar);
            //---------------------FALTA REALIZAR EL MINIMO Y MAXIMO DE LOS DATA TIME PIKER----------------------------
            DataTable fechas = objConsulta.BoolDataTable("select FECHA from TbEncabezadoFactura ORDER BY FECHA");
            dtpDesde.MinDate = Convert.ToDateTime(fechas.Rows[0]);
            //---------------------------------------------------------------------------------------------------------
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            
            string añoDesde = Convert.ToString(dtpDesde.Value.Date.Year), mesDesde = Convert.ToString(dtpDesde.Value.Date.Month), diaDesde = Convert.ToString(dtpDesde.Value.Date.Day);
            string fechaDesde = añoDesde + "-" + mesDesde + "-" + diaDesde;
            string añoHasta = Convert.ToString(dtpHasta.Value.Date.Year), mesHasta = Convert.ToString(dtpHasta.Value.Date.Month), diaHasta = Convert.ToString(dtpHasta.Value.Date.Day);
            string fechaHasta = añoHasta + "-" + mesHasta + "-" + diaHasta;
            condicionEntre = " AND FECHA between '" + fechaDesde + "' AND '"+ fechaHasta +"'";
            string cadenaConsultar = cadenaGeneral + cadeCondicion + condicionEntre;
            objConsulta.boolLlenarDataGridView(dgvInformeVentas, cadenaConsultar);
        }
    }
}
