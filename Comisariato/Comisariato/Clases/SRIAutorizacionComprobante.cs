using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Comisariato.Clases
{
    class SRIAutorizacionComprobante
    {
        /// <summary>
        /// The consultar autorizaciones.
        /// </summary>
        /// <param name="claveAcceso">The claveAcceso.</param>
        /// <returns>The <see cref="DatosTributarios"/>.</returns>
        public DatosTributarios ConsultarAutorizaciones(string claveAcceso)
        {
            return LlamarSri(claveAcceso);
        }

        /// <summary>
        /// The llamar sri.
        /// </summary>
        /// <param name="claveAcceso">The claveAcceso.</param>
        /// <returns>The <see cref="DatosTributarios"/>.</returns>

        private DatosTributarios LlamarSri(string claveAcceso)
        {
            try
            {
                var PathServer = @"C:\Users\Public\Documents\ArchivosXml";

                var resultado = string.Empty;
                DatosTributarios datosTributarios = null;
                string url = "https://celcer.sri.gob.ec/comprobantes-electronicos-ws/AutorizacionComprobantesOffline?wsdl";
                string xml = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ec=\"http://ec.gob.sri.ws.autorizacion\">";
                xml = xml + "<soapenv:Header/>";
                xml = xml + "<soapenv:Body>";
                xml = xml + "<ec:autorizacionComprobante>";
                xml = xml + "<claveAccesoComprobante>" + claveAcceso + "</claveAccesoComprobante>";
                xml = xml + "</ec:autorizacionComprobante>";
                xml = xml + "</soapenv:Body>";
                xml = xml + "</soapenv:Envelope>";

                byte[] bytes = Encoding.ASCII.GetBytes(xml);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "POST";
                request.ContentLength = bytes.Length;
                request.ContentType = "text/xml";

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(responseStream);
                    resultado = reader.ReadToEnd();
                }
                resultado = WebUtility.HtmlDecode(resultado);
                
                response.Close();
                var caracterPrincipal = resultado.IndexOf('?') - 1;
                var caracterSecundario = resultado.LastIndexOf('?') + 2;
                resultado = resultado.Remove(caracterPrincipal, (caracterSecundario - caracterPrincipal));
                resultado = "<?xml version=" + "\"1.0\"" + " encoding=" + "\"UTF-8\"" + "?>" + resultado;
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.LoadXml(resultado);


                string fechaautorizacion = "", mensaje = "", infoadicional = "", tipo = "", claveconsultada = "", numeroAutorizacion = "";
                string estado = doc.GetElementsByTagName("estado")[0].InnerText;
                string ambiente = doc.GetElementsByTagName("ambiente")[0].InnerText;
                claveconsultada = doc.GetElementsByTagName("claveAccesoConsultada")[0].InnerText;

                if (estado == "AUTORIZADO")
                {
                    numeroAutorizacion = doc.GetElementsByTagName("numeroAutorizacion")[0].InnerText;
                    Console.WriteLine("AUTORIZADO");
                    Console.WriteLine("Nº Autorizacion: " + numeroAutorizacion);
                    Console.WriteLine("Clave Consultada: " + claveconsultada);
                    Console.WriteLine("Ambiente: " + ambiente);
                    fechaautorizacion = doc.GetElementsByTagName("fechaAutorizacion")[0].InnerText;
                    Console.WriteLine("Fecha de autorizacion: " + fechaautorizacion);
                    System.Xml.XmlNode element = doc.SelectSingleNode("numeroAutorizacion");
                    datosTributarios = new DatosTributarios
                    {
                        claveAcceso = doc.GetElementsByTagName("claveAcceso")[0].InnerText,
                        numeroAutorizacion = doc.GetElementsByTagName("numeroAutorizacion")[0].InnerText,
                        FechaAutorizacion = Convert.ToDateTime(doc.GetElementsByTagName("fechaAutorizacion")[0].InnerText),
                        Estado = doc.GetElementsByTagName("estado")[0].InnerText,
                    };

                    if (!Directory.Exists(PathServer + @"\Autorizados\"))
                    {
                        Directory.CreateDirectory(PathServer + @"\Autorizados\");
                    }

                    doc.Save(PathServer + @"\Autorizados\"+claveAcceso+".xml");
                }
                else
                {
                    tipo = doc.GetElementsByTagName("tipo")[0].InnerText;
                    mensaje = doc.GetElementsByTagName("mensaje")[0].InnerText;
                    infoadicional = doc.GetElementsByTagName("informacionAdicional")[0].InnerText;
                    Console.WriteLine("Estado: NO AUTORIZADO");
                    Console.WriteLine("Clave Consultada: " + claveconsultada);
                    Console.WriteLine("Ambiente: " + ambiente);
                    Console.WriteLine("Mensaje: " + mensaje);
                    Console.WriteLine("Info. Adicional: " + infoadicional);
                    Console.WriteLine("Tipo: " + tipo);
                    if (!Directory.Exists(PathServer + @"\No Autorizados\"))
                    {
                        Directory.CreateDirectory(PathServer + @"\No Autorizados\");
                    }

                    doc.Save(PathServer + @"\No Autorizados\" + claveAcceso + ".xml");
                }

                return datosTributarios;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
    }
}
