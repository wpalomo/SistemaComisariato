using Comisariato.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comisariato.Formularios.SRI
{
    public partial class FormEnviarArchivos : Form
    {
        delegate void CambiarProgresoDelegado(string texto);
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

                    Funcion.FirmaXML(RutaXML + @"\" + NombreXML + ".xml",NombreXML);
                    //MessageBox.Show(RutaXML + NombreXML);
                }




                //DirectoryInfo di = new DirectoryInfo(@RutaXML);
                //foreach (var fi in di.GetFiles("" + NombreXML + "" + ".xml"))
                //{
                //    //MessageBox.Show(fi.Attributes.ToString());
                //}
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Creamos el delegado 
            ThreadStart h1 = new ThreadStart(Procesar);
            //Creamos la instancia del hilo 
            Thread h2 = new Thread(h1);
            //Iniciamos el hilo 
            h2.Start();
        }

        private void Procesar()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(500);
                CambiarProgreso(string.Format("Posición {0}...", i));
            }
 
            Thread.Sleep(10000);
            MessageBox.Show("Proceso finalizado");
        }

        private void CambiarProgreso(string texto)
        {
            if (this.InvokeRequired) 
            { 
                CambiarProgresoDelegado h1 = new CambiarProgresoDelegado(CambiarProgreso);
                object[] parametros = new object[] { texto };
                this.Invoke(h1, parametros);
            }
            else
            { 
                lblprueba.Text = texto;
            }
        }

    }
}
