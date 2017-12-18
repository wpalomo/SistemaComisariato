using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisariato.Clases
{
    public class EncabezadoNotaCredito
    {
        string serie1, serie2, numero;
        int idEncabezadoCompra;
        float totalDevolucion;

        public string Serie1
        {
            get
            {
                return serie1;
            }

            set
            {
                serie1 = value;
            }
        }

        public string Serie2
        {
            get
            {
                return serie2;
            }

            set
            {
                serie2 = value;
            }
        }

        public string Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        public int IdEncabezadoCompra
        {
            get
            {
                return idEncabezadoCompra;
            }

            set
            {
                idEncabezadoCompra = value;
            }
        }

        public float TotalDevolucion
        {
            get
            {
                return totalDevolucion;
            }

            set
            {
                totalDevolucion = value;
            }
        }
        public EncabezadoNotaCredito(string serie1, string serie2, string numero, int idEncabezado, float totalDevolucion)
        {
            this.Serie1 = serie1;
            this.Serie2 = serie2;
            this.Numero = numero;
            this.IdEncabezadoCompra = idEncabezado;
            this.TotalDevolucion = totalDevolucion;
        }
        Consultas ObjConsulta;
        public string InsertarEncabezadoNC(EncabezadoNotaCredito objEncabezadoNotaCredito)
        {
            ObjConsulta = new Consultas();

            if (!ObjConsulta.Existe("IDENCABEZADOCOMPRA", IdEncabezadoCompra.ToString(), "TbEncabezadoNotaCredito"))
            {
                if (ObjConsulta.EjecutarPROCEDUREEncabezadoNotaCredito(objEncabezadoNotaCredito))
                {
                    return "Datos Guardados";
                }
                else { return "Error al Registrar"; }
            }
            else { return "Existe"; }
        }
    }
}
