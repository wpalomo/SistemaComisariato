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

                String RecepcionSRIRespuesta = "";

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
                        Funcion.FirmaXML(RutaXML+ @"\Generados" + @"\" + NombreXML + ".xml", NombreXML);
                        //Fin Firmar Documento

                        //RecepcionSRI
                        SRIRecepcionComprobante sriRecepcion = new SRIRecepcionComprobante();
                        RecepcionSRIRespuesta = sriRecepcion.LlamarSRIRecepcion(RutaXML + @"\Firmados" + @"\" + NombreXML + ".xml", NombreXML);
                        //Fin RecepcionSRI

                        String[] axuAto = RecepcionSRIRespuesta.Split(';');
                        String claveAcceso = axuAto[1];

                        switch (RecepcionSRIRespuesta)
                        {
                            case "DEVUELTA":
                                RecepcionSRIRespuesta = "D";
                                break;
                            case "RECIBIDA":
                                RecepcionSRIRespuesta = "R";
                                break;
                            default:
                                break;
                        }

                        //Autorizacion
                        SRIAutorizacionComprobante sriAutori = new SRIAutorizacionComprobante();
                        sriAutori.ConsultarAutorizaciones(claveAcceso);
                        //FIN Autorizacion

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
