using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Comisariato.Clases
{
    class XmlRetencion
    {
        XmlDocument doc;
        string rutaXml;

        public void _crearXml(string ruta, string nodoRaiz)
        {

            this.rutaXml = ruta;
            doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);

            XmlNode root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);


            //XmlNode element1 = doc.CreateElement(nodoRaiz);

            XmlElement newCd = doc.CreateElement(nodoRaiz);
            newCd.SetAttribute("id", "comprobante");
            newCd.SetAttribute("version", "1.0.0");

            doc.AppendChild(newCd);
            doc.Save(ruta);

        }

        public void InfoTributaria(string nodoraiz, InfoTributaria objcinfotributaria, string serie)
        {
            doc.Load(rutaXml);
            string fecha = DateTime.Now.Date.ToShortDateString();
            //tipocomprobante de acuedo a la tabla 4
            //string claveacceso = objcinfotributaria.GenerarClaveAcceso(fecha, "1", serie);
            //XmlNode NodoInfoTributarios = CrearInfoTributarios("" + objcinfotributaria.Ambiente, "" + objcinfotributaria.TipoEmision, objcinfotributaria.RazonSociaL, objcinfotributaria.NombreComerciaL, objcinfotributaria.RuC, claveacceso, objcinfotributaria.CodDoC, objcinfotributaria.EstaB, objcinfotributaria.PtoEmI, objcinfotributaria.SecuenciaL, objcinfotributaria.DirMatriz);

            //XmlNode nodoRaiz = doc.DocumentElement;

            //nodoRaiz.InsertAfter(NodoInfoTributarios, nodoRaiz.LastChild);

            doc.Save(rutaXml);
        }

        public void infoCompRetencion(InfoCompRetencion objciCompRetencion)
        {
            doc.Load(rutaXml);
            string fecha = DateTime.Now.Date.ToShortDateString();
          
            XmlNode NodoInfoTributarios = CrearInfoCompRetencion(objciCompRetencion.FechaEmision, objciCompRetencion.DirEstablecimiento, objciCompRetencion.ContribuyenteEspecial, objciCompRetencion.ObligadoContabilidad, objciCompRetencion.TipoIdentificacionSujetoRetenido, objciCompRetencion.RazonSocialSujetoRetenido, objciCompRetencion.IdentificacionSujetoRetenido, objciCompRetencion.PeriodoFiscal);

            XmlNode nodoRaiz = doc.DocumentElement;

            nodoRaiz.InsertAfter(NodoInfoTributarios, nodoRaiz.LastChild);

            doc.Save(rutaXml);
        }

        public void impuestos(DataGridView dgv)
        {
            doc.Load(rutaXml);
            string fecha = DateTime.Now.Date.ToShortDateString();
            XmlNode impuestos = doc.CreateElement("impuestos");

            for (int i = 0; i < dgv.RowCount; i++)
            {
                XmlNode NodoDetalles = null;
                NodoDetalles = nodototalConImpuestos(Convert.ToString(dgv.Rows[i].Cells[0].Value), Convert.ToString(dgv.Rows[i].Cells[0].Value), Convert.ToString(dgv.Rows[i].Cells[1].Value), Convert.ToString(dgv.Rows[i].Cells[2].Value), Convert.ToString(dgv.Rows[i].Cells[4].Value), "0.00", Convert.ToString(dgv.Rows[i].Cells[4].Value), "2");

                impuestos.AppendChild(NodoDetalles);
            }


            //XmlNode NodoInfoTributarios = CrearInfoCompRetencion(objciCompRetencion.FechaEmision, objciCompRetencion.DirEstablecimiento, objciCompRetencion.ContribuyenteEspecial, objciCompRetencion.ObligadoContabilidad, objciCompRetencion.TipoIdentificacionSujetoRetenido, objciCompRetencion.RazonSocialSujetoRetenido, objciCompRetencion.IdentificacionSujetoRetenido, objciCompRetencion.PeriodoFiscal);

            XmlNode nodoRaiz = doc.DocumentElement;

            nodoRaiz.InsertAfter(impuestos, nodoRaiz.LastChild);

            doc.Save(rutaXml);
        }

        private XmlNode nodototalConImpuestos(string codigo, string codigoRetencion,string baseImponible,string porcentajeRetener,string valorRetenido,string codDocSustento,string numDocSustento,string fechaEmisionDocSustento)
        {
            //doc.Load(rutaXml);
            XmlNode SubNodototalConImpuestos = doc.CreateElement("impuesto");

            XmlElement nodocodigo = doc.CreateElement("código");
            nodocodigo.InnerText = codigo;
            SubNodototalConImpuestos.AppendChild(nodocodigo);

            XmlElement nodocodigoRetencion = doc.CreateElement("codigoRetencion");
            nodocodigoRetencion.InnerText = codigoRetencion;
            SubNodototalConImpuestos.AppendChild(nodocodigoRetencion);

            XmlElement nodobaseImponible = doc.CreateElement("baseImponible");
            nodobaseImponible.InnerText = baseImponible;
            SubNodototalConImpuestos.AppendChild(nodobaseImponible);

            XmlElement nodoporcentajeRetener = doc.CreateElement("porcentajeRetener");
            nodoporcentajeRetener.InnerText = porcentajeRetener;
            SubNodototalConImpuestos.AppendChild(nodoporcentajeRetener);

            XmlElement nodovalorRetenido = doc.CreateElement("valorRetenido");
            nodovalorRetenido.InnerText = valorRetenido;
            SubNodototalConImpuestos.AppendChild(nodovalorRetenido);


            XmlElement nodocodDocSustento = doc.CreateElement("codDocSustento");
            nodocodDocSustento.InnerText = codDocSustento;
            SubNodototalConImpuestos.AppendChild(nodocodDocSustento);

            XmlElement nodonumDocSustento = doc.CreateElement("numDocSustento");
            nodonumDocSustento.InnerText = numDocSustento;
            SubNodototalConImpuestos.AppendChild(nodonumDocSustento);

            XmlElement nodofechaEmisionDocSustento = doc.CreateElement("fechaEmisionDocSustento");
            nodofechaEmisionDocSustento.InnerText = fechaEmisionDocSustento;
            SubNodototalConImpuestos.AppendChild(nodofechaEmisionDocSustento);

            return SubNodototalConImpuestos;

        }


        private XmlNode CrearInfoCompRetencion(string fechaEmision, string dirEstablecimiento, string contribuyenteEspecial, string obligadoContabilidad, string tipoIdentificacionSujetoRetenido, string razonSocialSujetoRetenido, string identificacionSujetoRetenido, string periodoFiscal)
        {
            XmlNode Nodoraiz = doc.CreateElement("infoCompRetencion");


            XmlElement nodofechaEmision = doc.CreateElement("fechaEmision");
            nodofechaEmision.InnerText = fechaEmision;
            Nodoraiz.AppendChild(nodofechaEmision);

            XmlElement nododirEstablecimiento = doc.CreateElement("dirEstablecimiento");
            nododirEstablecimiento.InnerText = dirEstablecimiento;
            Nodoraiz.AppendChild(nododirEstablecimiento);

            XmlElement nodocontribuyenteEspecial = doc.CreateElement("contribuyenteEspecial");
            nodocontribuyenteEspecial.InnerText = contribuyenteEspecial;
            Nodoraiz.AppendChild(nodocontribuyenteEspecial);

            XmlElement nodoobligadoContabilidad = doc.CreateElement("obligadoContabilidad");
            nodoobligadoContabilidad.InnerText = obligadoContabilidad;
            Nodoraiz.AppendChild(nodoobligadoContabilidad);

            XmlElement nodotipoIdentificacionSujetoRetenido = doc.CreateElement("tipoIdentificacionSujetoRetenido");
            nodotipoIdentificacionSujetoRetenido.InnerText = tipoIdentificacionSujetoRetenido;
            Nodoraiz.AppendChild(nodotipoIdentificacionSujetoRetenido);

            XmlElement nodorazonSocialSujetoRetenido = doc.CreateElement("razonSocialSujetoRetenido");
            nodorazonSocialSujetoRetenido.InnerText = razonSocialSujetoRetenido;
            Nodoraiz.AppendChild(nodorazonSocialSujetoRetenido);

            XmlElement nodoidentificacionSujetoRetenido = doc.CreateElement("identificacionSujetoRetenido");
            nodoidentificacionSujetoRetenido.InnerText = identificacionSujetoRetenido;
            Nodoraiz.AppendChild(nodoidentificacionSujetoRetenido);

            XmlElement nodoperiodoFiscal = doc.CreateElement("periodoFiscal");
            nodoperiodoFiscal.InnerText = periodoFiscal;
            Nodoraiz.AppendChild(nodoperiodoFiscal);


            return Nodoraiz;
        }



    }
}
