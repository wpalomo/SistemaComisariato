using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisariato.Clases
{
    public class DetalleNotaDebito
    {
        int idEncabezadoNotaCredito, cantidad;
        string codigoBarra;

        public int IdEncabezadoNotaCredito
        {
            get
            {
                return idEncabezadoNotaCredito;
            }

            set
            {
                idEncabezadoNotaCredito = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        public string CodigoBarra
        {
            get
            {
                return codigoBarra;
            }

            set
            {
                codigoBarra = value;
            }
        }
        public DetalleNotaDebito(int idEncabezado, int cantidad, string codigoBarra)
        {
            this.IdEncabezadoNotaCredito = idEncabezado;
            this.CodigoBarra = codigoBarra;
            this.Cantidad = cantidad;
        }
        Consultas ObjConsulta;
        public string InsertarDetalleNC(DetalleNotaCredito objDetalleNotaCredito)
        {
            ObjConsulta = new Consultas();

            //if (!ObjConsulta.Existe("IDPROVEEDOR = " + proveedor + " AND NUMERODOCUMENTOPROVEEDOR = " + numeroProveedor + " AND SERIE1PROVEEDOR = " + serie1Proveedor + " AND SERIE2PROVEEDOR", serie2Proveedor.ToString(), "TbEncabezadoOrdenGiro"))
            //{
            if (ObjConsulta.EjecutarPROCEDUREDetalleNotaCredito(objDetalleNotaCredito))
            {
                return "Datos Guardados";
            }
            else { return "Error al Registrar"; }
            //}
            //else { return "Existe"; }
        }
    }
}
