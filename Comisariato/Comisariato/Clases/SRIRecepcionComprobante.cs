using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Comisariato.Clases
{
    public class SRIRecepcionComprobante
    {
        /// <summary>
        /// RecepcionSRI
        /// </summary>
        /// 

        public string LlamarSRIRecepcion(string DocXML, string nombrexml)
        {
            try
            {
                string a = "";

                XmlDocument xmlDoc = new XmlDocument();
                //var PathServer = ConfigurationManager.AppSettings["XmlServidor"];
                var PathServer = @"C:\Users\Public\Documents\ArchivosXml";
                xmlDoc.Load(DocXML);
                string claveAcceso = xmlDoc.GetElementsByTagName("claveAcceso")[0].InnerText;
                if (claveAcceso.Length == 49)
                {
                    StringBuilder rawXml = new StringBuilder();
                    rawXml.Append(GetXmlString(xmlDoc));
                    string xml = rawXml.ToString();
                    string xmlfinal = Base64_Encode(xml);
                    var Output = Encoding.UTF8.GetBytes(xmlDoc.OuterXml);
                    string myLXmlBase64 = Convert.ToBase64String(Output);
                    byte[] bytes = Convert.FromBase64String(myLXmlBase64);

                    ServiceRecepcion.RecepcionComprobantesOfflineClient Recep = new ServiceRecepcion.RecepcionComprobantesOfflineClient();
                    ServiceRecepcion.respuestaSolicitud RptService = (ServiceRecepcion.respuestaSolicitud)Recep.validarComprobante(bytes);
                    a = RptService.estado;
                    Console.WriteLine(a);
                    if (a == "DEVUELTA")
                    {

                        ServiceRecepcion.validarComprobante c = new ServiceRecepcion.validarComprobante();
                        c.xml = bytes;
                        //System.IO.File.WriteAllBytes(@"C:\Users\Galito\Desktop\valida1.xml", c.xml);
                        //File.Copy(@"C:\Users\Galito\Desktop\valida1.xml", @"\\192.168..0.96\C$\ArchivosXml\Generados\valida1.xml", true);

                    }
                    else
                    {
                        //Preguntar sobre el directorio

                        if (!Directory.Exists(PathServer + @"\Enviados\"))
                        {
                            Directory.CreateDirectory(PathServer + @"\Enviados\");
                        }


                        xmlDoc.Save(@PathServer + @"\Enviados\" + @"\" + nombrexml + ".xml");
                        //System.IO.File.WriteAllBytes(@"C:\Users\Galito\Desktop\valida1.xml", bytes);
                    }
                    return a + ";" + claveAcceso;
                }
                else
                {
                    return "claveincorrecta";
                }



            }
            catch (Exception ex)
            {
                return "error";
            }

        }

        //>codificar
        public static string Base64_Encode(string str)
        {
            byte[] encbuff = System.Text.Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(encbuff);
        }
        //> Decodificar
        public static string Base64_Decode(string str)
        {
            try
            {
                byte[] decbuff = Convert.FromBase64String(str);
                return System.Text.Encoding.UTF8.GetString(decbuff);
            }
            catch
            {
                { return ""; }
            }
        }

        //Funcion para conversion
        static string GetXmlString(XmlDocument xmlDoc)
        {

            // Now create StringWriter object to get data from xml document.
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xmlDoc.WriteTo(xw);
            return sw.ToString();
        }
    }
}
