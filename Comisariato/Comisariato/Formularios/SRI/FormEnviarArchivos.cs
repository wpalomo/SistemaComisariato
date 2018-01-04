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

<<<<<<< HEAD
=======
        private void button1_Click(object sender, EventArgs e)
        {
            //DirectoryInfo di = new DirectoryInfo(@"C:\Users\MaxDJ\Desktop\prueba\");
            //foreach (var fi in di.GetFiles("test?.txt"))
            //{
            //    MessageBox.Show(fi.Name);
            //}
>>>>>>> b73464b22018c82c597cd1ddcd4f3b4ae00eee56

        String RutaXML = "";
        String NombreXML = "";
        String FechaEmision = "";

        private void BtnEnviarXML_Click(object sender, EventArgs e)
        {
            FechaEmision = Funcion.reemplazarcaracterFecha(DtpFecha.Value.Date.ToShortDateString());
            DataTable DtDocuemtosXML = objConsult.BoolDataTableFactElect("Select * from TbDocumentosGeneradosFact DocFact where DocFact.FechaEmision = '" + FechaEmision + "'");

            if (DtDocuemtosXML.Rows.Count > 0)
            {
                foreach (DataRow myRow in DtDocuemtosXML.Rows)
                {
                    RutaXML = myRow["RutaXML"].ToString();
                    NombreXML = myRow["NombreXML"].ToString();
                    FechaEmision = myRow["FechaEmision"].ToString();

                    //Inicio menuInferior
                    TollMenuLablelDocumento.Text = "Documento : " + NombreXML + ".xml";
                    TollMenuLablelFecha.Text = "Fecha : " + FechaEmision;
                    //Fin menuInferior



                    MessageBox.Show(RutaXML + NombreXML);
                }




                //DirectoryInfo di = new DirectoryInfo(@RutaXML);
                //foreach (var fi in di.GetFiles("" + NombreXML + "" + ".xml"))
                //{
                //    //MessageBox.Show(fi.Attributes.ToString());
                //}
            }

        }
    }
}
