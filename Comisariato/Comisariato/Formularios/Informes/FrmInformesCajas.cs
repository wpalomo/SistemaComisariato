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
    public partial class FrmInformesCajas : Form
    {
        public FrmInformesCajas()
        {
            InitializeComponent();
        }
        Consultas objConsulta = new Consultas();
        string sqlCaja = "select cc.CAJA, TOTALRECAUDADO as ValorEntregado, ct.ESTACION,  ct.IPESTACION, u.USUARIO from TbUsuario u, TbCierreCaja cc, TbCajasTalonario ct " +
" where ct.SERIE2 = cc.CAJA and ct.TIPODOCUMENTO = 'FAC' and u.IDUSUARIO =  cc.IDUSUARIO"; 
        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            llenarDataGrid();
        }
        public void llenarDataGrid()
        {
            DataTable dt = objConsulta.BoolDataTable(sqlCaja);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    dgvInformeCajas.Rows[i].Cells[0].Value = row["USUARIO"];
                    dgvInformeCajas.Rows[i].Cells[1].Value = row["ValorEntregado"];
                    dgvInformeCajas.Rows[i].Cells[5].Value = row["ESTACION"];
                    dgvInformeCajas.Rows[i].Cells[6].Value = row["IPESTACION"];
                    int Caja = Convert.ToInt32(row["CAJA"].ToString());
                    if (i == dgvInformeCajas.RowCount -1)
                    {
                        dgvInformeCajas.Rows.Add();
                    }
                }
            }
            
        }

        private void FrmInformesCajas_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                dgvInformeCajas.Rows.Add();
            }
        }

        private void BtnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvInformeCajas.Rows[0].Cells[0].Value != null)
            {
                if (Funcion.ExportarDataGridViewExcel(dgvInformeCajas, 0))
                {
                    MessageBox.Show("Reporte creado con exito.");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al crear el reporte.");
                }

            }
        }
    }
}
