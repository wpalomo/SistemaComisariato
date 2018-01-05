using Comisariato.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comisariato.Formularios.SRI
{
    public partial class FormEnviarArchivos : Form
    {
        public FormEnviarArchivos()
        {
            InitializeComponent();
        }
        Consultas objConsult = new Consultas();


        String RutaXML = "";
        String NombreXML = "";
        String FechaEmision = "";

        private void BtnEnviarXML_Click(object sender, EventArgs e)
        {
            try
            {
                FechaEmision = Funcion.reemplazarcaracterFecha(DtpFecha.Value.Date.ToShortDateString());
                DataTable DtDocuemtosXML = objConsult.BoolDataTableFactElect("Select * from TbDocumentosGeneradosFact DocFact where DocFact.FechaEmision = '" + FechaEmision + "' and   EstadoAutorizacion = '0'");

                if (DtDocuemtosXML.Rows.Count > 0)
                {
                    foreach (DataRow myRow in DtDocuemtosXML.Rows)
                    {
                        RutaXML = myRow["RutaXML"].ToString();
                        NombreXML = myRow["NombreXML"].ToString();
                        FechaEmision = myRow["FechaEmision"].ToString();

                        //Inicio menuInferior
                        TollMenuLablelDocumento.Text = "Documento : " + NombreXML + ".xml";
                        TollMenuLablelFecha.Text = "Fecha : " + Funcion.reemplazarcaracterFecha(Convert.ToDateTime(FechaEmision).Date.ToShortDateString());
                        //Fin menuInferior


                        //Firmar Documento
                        Funcion.FirmaXML(RutaXML + @"\" + NombreXML + ".xml", NombreXML);
                        //Fin Firmar Documento

                        //RecepcionSRI

                        //Fin RecepcionSRI



                        //MessageBox.Show(RutaXML + NombreXML);
                    }
                }
            }
            catch (Exception)
            {

            }
            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
