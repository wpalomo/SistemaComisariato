using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisariato.Clases
{
    public class DetalleOrdenGiro
    {
        int idEncabezadoOrdenGiro, idRetencion;

        public DetalleOrdenGiro(int idEncabezadoOrdenGiro, int idRetencion)
        {
            this.IdEncabezadoOrdenGiro = idEncabezadoOrdenGiro;
            this.IdRetencion = idRetencion;
        }

        public int IdEncabezadoOrdenGiro
        {
            get
            {
                return idEncabezadoOrdenGiro;
            }

            set
            {
                idEncabezadoOrdenGiro = value;
            }
        }

        public int IdRetencion
        {
            get
            {
                return idRetencion;
            }

            set
            {
                idRetencion = value;
            }
        }

        Consultas ObjConsulta;
        public string InsertarDetalledoOrden(DetalleOrdenGiro objDetalleOrdenGiro)
        {
            ObjConsulta = new Consultas();

            if (!ObjConsulta.Existe("IDRETENCION = " + idRetencion + " AND IDENCABEZADOORDENGIRO", idEncabezadoOrdenGiro.ToString(), "TbDetalleOrdenGiro"))
            {
                if (ObjConsulta.EjecutarPROCEDUREDetalleOrdenGiro(objDetalleOrdenGiro))
                {
                    return "Datos Guardados";
                }
                else { return "Error al Registrar"; }
            }
            else { return "Existe"; }
        }
    }
}
