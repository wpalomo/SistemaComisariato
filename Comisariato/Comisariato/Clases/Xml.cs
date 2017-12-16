using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Comisariato.Clases
{
    class Xml
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
            string claveacceso = objcinfotributaria.GenerarClaveAcceso(fecha,"1",serie);
            XmlNode NodoInfoTributarios = CrearInfoTributarios(""+objcinfotributaria.Ambiente,""+objcinfotributaria.TipoEmision,objcinfotributaria.RazonSociaL,objcinfotributaria.NombreComerciaL,objcinfotributaria.RuC, claveacceso,objcinfotributaria.CodDoC,objcinfotributaria.EstaB,objcinfotributaria.PtoEmI,objcinfotributaria.SecuenciaL,objcinfotributaria.DirMatriz);

            XmlNode nodoRaiz = doc.DocumentElement;

            nodoRaiz.InsertAfter(NodoInfoTributarios, nodoRaiz.LastChild);

            doc.Save(rutaXml);
        }

        public void infoFactura(string nodoraiz,InfoFactura objc)
        {
            doc.Load(rutaXml);

            XmlNode NodoInfoTributarios = CrearNodoInfoFactura(objc.FechaEmision,objc.DirEstablecimiento,objc.ContribuyenteEspecial,objc.ObligadoContabilidad,objc.TipoIdentificacionComprador,objc.RazonSocialComprador,objc.IdentificacionComprador,objc.TotalSinImpuestos,objc.TotalDescuento,objc.Codigo,objc.CodigoPorcentaje,objc.DescuentoAdicional,objc.BaseImponible,objc.Valor,objc.Propina,objc.ImporteTotal,objc.Moneda, objc.GuiaRemision, objc.DireccionComprador);

            XmlNode nodoRaiz = doc.DocumentElement;

            nodoRaiz.InsertAfter(NodoInfoTributarios, nodoRaiz.LastChild);

            doc.Save(rutaXml);
        }

        public void detalleFactura(string nodoraiz, DataGridView dgv)
        {
            doc.Load(rutaXml);
            XmlNode detalles = doc.CreateElement("detalles");
            for (int i = 0; i < dgv.RowCount; i++)
            {
                XmlNode NodoDetalles;
                if (Convert.ToString(dgv.Rows[i].Cells[0].Value)!=null)
                {
                    if (Convert.ToInt32(Convert.ToString(dgv.Rows[i].Cells[5].Value)) == 0)
                    {
                        NodoDetalles = CrearNodoDetalle(Convert.ToString(dgv.Rows[i].Cells[0].Value), Convert.ToString(dgv.Rows[i].Cells[0].Value), Convert.ToString(dgv.Rows[i].Cells[1].Value), Convert.ToString(dgv.Rows[i].Cells[2].Value), Convert.ToString(dgv.Rows[i].Cells[4].Value), "0.00", Convert.ToString(dgv.Rows[i].Cells[4].Value), "2", "0", "0S", Convert.ToString(dgv.Rows[i].Cells[4].Value), Convert.ToString(dgv.Rows[i].Cells[6].Value));
                    }
                    else
                    {
                        NodoDetalles = CrearNodoDetalle(Convert.ToString(dgv.Rows[i].Cells[0].Value), Convert.ToString(dgv.Rows[i].Cells[0].Value), Convert.ToString(dgv.Rows[i].Cells[1].Value), Convert.ToString(dgv.Rows[i].Cells[2].Value), Convert.ToString(dgv.Rows[i].Cells[4].Value), "0.00", Convert.ToString(dgv.Rows[i].Cells[4].Value), "2", "2", Program.IVA, Convert.ToString(dgv.Rows[i].Cells[4].Value), Convert.ToString(dgv.Rows[i].Cells[6].Value));
                    }

                    detalles.AppendChild(NodoDetalles);
                }
                else
                {
                    break;
                }
               
            }
            XmlNode nodoRaiz = doc.DocumentElement;

            nodoRaiz.InsertAfter(detalles, nodoRaiz.LastChild);

            doc.Save(rutaXml);
        }

        public XmlNode CrearNodoDetalle(string codigoPrincipal, string codigoAuxiliar, string descripcion, string cantidad, string precioUnitario, string descuento, string precioTotalSinImpuesto, string codigo, string codigoPorcentaje, string tarifa, string baseImponible, string valor)
        {
            XmlNode detalle = doc.CreateElement("detalle");


            XmlElement nodocodigoPrincipal = doc.CreateElement("codigoPrincipal");
            nodocodigoPrincipal.InnerText = codigoPrincipal;
            detalle.AppendChild(nodocodigoPrincipal);


            XmlElement nodocodigoAuxiliar = doc.CreateElement("codigoAuxiliar");
            nodocodigoAuxiliar.InnerText = codigoAuxiliar;
            detalle.AppendChild(nodocodigoAuxiliar);


            XmlElement nododescripcion = doc.CreateElement("descripcion");
            nododescripcion.InnerText = descripcion;
            detalle.AppendChild(nododescripcion);


            XmlElement nodocantidad = doc.CreateElement("cantidad");
            nodocantidad.InnerText = cantidad;
            detalle.AppendChild(nodocantidad);

            XmlElement nodoprecioUnitario = doc.CreateElement("precioUnitario");
            nodoprecioUnitario.InnerText = precioUnitario;
            detalle.AppendChild(nodoprecioUnitario);

            XmlElement nododescuento = doc.CreateElement("descuento");
            nododescuento.InnerText = descuento;
            detalle.AppendChild(nododescuento);

            XmlElement nodoprecioTotalSinImpuesto = doc.CreateElement("precioTotalSinImpuesto");
            nodoprecioTotalSinImpuesto.InnerText = precioTotalSinImpuesto;
            detalle.AppendChild(nodoprecioTotalSinImpuesto);

            //subnodo del nodo raiz totalConImpuestos
            XmlNode SubNodototalConImpuestos = doc.CreateElement("impuestos");

            detalle.AppendChild(SubNodototalConImpuestos);

            //subnodo del nodo totalConImpuestos
            XmlNode SubNodototalImpuesto = doc.CreateElement("impuesto");
            SubNodototalConImpuestos.AppendChild(SubNodototalImpuesto);

            XmlElement nodocodigo = doc.CreateElement("codigo");
            nodocodigo.InnerText = codigo;
            SubNodototalImpuesto.AppendChild(nodocodigo);

            XmlElement nodocodigoPorcentaje = doc.CreateElement("codigoPorcentaje");
            nodocodigoPorcentaje.InnerText = codigoPorcentaje;
            SubNodototalImpuesto.AppendChild(nodocodigoPorcentaje);

            XmlElement nodotarifa = doc.CreateElement("tarifa");
            nodotarifa.InnerText = tarifa;
            SubNodototalImpuesto.AppendChild(nodotarifa);

            XmlElement nodobaseImponible = doc.CreateElement("baseImponible");
            nodobaseImponible.InnerText = baseImponible;
            SubNodototalImpuesto.AppendChild(nodobaseImponible);

            XmlElement nodovalor = doc.CreateElement("valor");
            nodovalor.InnerText = valor;
            SubNodototalImpuesto.AppendChild(nodovalor);

            return detalle;
        }

        private XmlNode CrearNodoInfoFactura(string fechaEmision, string dirEstablecimiento, string contribuyenteEspecial, string obligadoContabilidad, string tipoIdentificacionComprador, string razonSocialComprador, string identificacionComprador, string totalSinImpuestos, string totalDescuento, string codigo, string codigoPorcentaje, string descuentoAdicional, string baseImponible, string valor, string propina, string importeTotal, string moneda,string guiaRemision,string direccionComprador)
        {
            XmlNode Nodoraiz = doc.CreateElement("infoFactura");


            XmlElement nodofechaemision = doc.CreateElement("fechaEmision");
            nodofechaemision.InnerText = fechaEmision;
            Nodoraiz.AppendChild(nodofechaemision);

            XmlElement nododirEstablecimiento = doc.CreateElement("dirEstablecimiento");
            nododirEstablecimiento.InnerText = dirEstablecimiento;
            Nodoraiz.AppendChild(nododirEstablecimiento);

            XmlElement nodocontribuyenteEspecial = doc.CreateElement("contribuyenteEspecial");
            nodocontribuyenteEspecial.InnerText = contribuyenteEspecial;
            Nodoraiz.AppendChild(nodocontribuyenteEspecial);

            XmlElement nodoobligadoContabilidad = doc.CreateElement("obligadoContabilidad");
            nodoobligadoContabilidad.InnerText = obligadoContabilidad;
            Nodoraiz.AppendChild(nodoobligadoContabilidad);

            XmlElement nodotipoIdentificacionComprador = doc.CreateElement("tipoIdentificacionComprador");
            nodotipoIdentificacionComprador.InnerText = tipoIdentificacionComprador;
            Nodoraiz.AppendChild(nodotipoIdentificacionComprador);

            XmlElement nodoguiaremision = doc.CreateElement("guiaRemision");
            nodoguiaremision.InnerText = tipoIdentificacionComprador;
            Nodoraiz.AppendChild(nodoguiaremision);

            XmlElement nodorazonSocialComprador = doc.CreateElement("razonSocialComprador");
            nodorazonSocialComprador.InnerText = razonSocialComprador;
            Nodoraiz.AppendChild(nodorazonSocialComprador);

            XmlElement nodoidentificacionComprador = doc.CreateElement("identificacionComprador");
            nodoidentificacionComprador.InnerText = identificacionComprador;
            Nodoraiz.AppendChild(nodoidentificacionComprador);

            XmlElement nododireccioncomprador = doc.CreateElement("direccionComprador");
            nododireccioncomprador.InnerText = identificacionComprador;
            Nodoraiz.AppendChild(nododireccioncomprador);

            XmlElement nodototalSinImpuestos = doc.CreateElement("totalSinImpuestos");
            nodototalSinImpuestos.InnerText = totalSinImpuestos;
            Nodoraiz.AppendChild(nodototalSinImpuestos);

            XmlElement nodototalDescuento = doc.CreateElement("totalDescuento");
            nodototalDescuento.InnerText = totalDescuento;
            Nodoraiz.AppendChild(nodototalDescuento);

            //subnodo del nodo raiz totalConImpuestos
            XmlNode SubNodototalConImpuestos = doc.CreateElement("totalConImpuestos");

            Nodoraiz.AppendChild(SubNodototalConImpuestos);

            //subnodo del nodo totalConImpuestos
            XmlNode SubNodototalImpuesto = doc.CreateElement("totalImpuesto");
            SubNodototalConImpuestos.AppendChild(SubNodototalImpuesto);

            XmlElement nodocodigo = doc.CreateElement("codigo");
            nodocodigo.InnerText = codigo;
            SubNodototalImpuesto.AppendChild(nodocodigo);


            XmlElement nodocodigoPorcentaje = doc.CreateElement("codigoPorcentaje");
            nodocodigoPorcentaje.InnerText = codigoPorcentaje;
            SubNodototalImpuesto.AppendChild(nodocodigoPorcentaje);

            XmlElement nododescuentoAdicional = doc.CreateElement("descuentoAdicional");
            nododescuentoAdicional.InnerText = descuentoAdicional;
            SubNodototalImpuesto.AppendChild(nododescuentoAdicional);

            XmlElement nodobaseImponible = doc.CreateElement("baseImponible");
            nodobaseImponible.InnerText = baseImponible;
            SubNodototalImpuesto.AppendChild(nodobaseImponible);

            XmlElement nodovalor = doc.CreateElement("valor");
            nodovalor.InnerText = valor;
            SubNodototalImpuesto.AppendChild(nodovalor);

            XmlElement nodopropina = doc.CreateElement("propina");
            nodopropina.InnerText = propina;
            Nodoraiz.AppendChild(nodopropina);

            XmlElement nodoimporteTotal = doc.CreateElement("importeTotal");
            nodoimporteTotal.InnerText = importeTotal;
            Nodoraiz.AppendChild(nodoimporteTotal);

            XmlElement nodomoneda = doc.CreateElement("moneda");
            nodomoneda.InnerText = moneda;
            Nodoraiz.AppendChild(nodomoneda);

            return Nodoraiz;
        }

        private XmlNode CrearInfoTributarios(string ambiente, string tipodeemision, string razonsocial, string nombrecomercial, string ruc, string claveacceso, string coddoc, string estab, string ptoemision, string secuencial, string dirmatriz)
        {
            XmlNode Nodoraiz = doc.CreateElement("infoTributaria");


            XmlElement nodoambiente = doc.CreateElement("ambiente");
            nodoambiente.InnerText = ambiente;
            Nodoraiz.AppendChild(nodoambiente);

            XmlElement nodoemision = doc.CreateElement("tipoEmision");
            nodoemision.InnerText = tipodeemision;
            Nodoraiz.AppendChild(nodoemision);

            XmlElement nodorazonsocial = doc.CreateElement("razonSocial");
            nodorazonsocial.InnerText = razonsocial;
            Nodoraiz.AppendChild(nodorazonsocial);

            XmlElement nodonombreComercial = doc.CreateElement("nombreComercial");
            nodonombreComercial.InnerText = nombrecomercial;
            Nodoraiz.AppendChild(nodonombreComercial);

            XmlElement nodoruc = doc.CreateElement("ruc");
            nodoruc.InnerText = ruc;
            Nodoraiz.AppendChild(nodoruc);

            XmlElement nodoclaveAcceso = doc.CreateElement("claveAcceso");
            nodoclaveAcceso.InnerText = claveacceso;
            Nodoraiz.AppendChild(nodoclaveAcceso);

            XmlElement nodocodDoc = doc.CreateElement("codDoc");
            nodocodDoc.InnerText = coddoc;
            Nodoraiz.AppendChild(nodocodDoc);

            XmlElement nodoestab = doc.CreateElement("estab");
            nodoestab.InnerText = estab;
            Nodoraiz.AppendChild(nodoestab);

            XmlElement nodoptoEmi = doc.CreateElement("ptoEmi");
            nodoptoEmi.InnerText = ptoemision;
            Nodoraiz.AppendChild(nodoptoEmi);

            XmlElement nodosecuencial = doc.CreateElement("secuencial");
            nodosecuencial.InnerText = secuencial;
            Nodoraiz.AppendChild(nodosecuencial);


            XmlElement nododirMatriz = doc.CreateElement("dirMatriz");
            nododirMatriz.InnerText = dirmatriz;
            Nodoraiz.AppendChild(nododirMatriz);


            return Nodoraiz;
        }

    }
}
