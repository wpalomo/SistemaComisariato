﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisariato.Clases
{
    class InfoTributaria
    {
        private int ambiente;
        private int tipoEmision;
        private string RazonSocial;
        private string NombreComercial;
        private string Ruc;
        private string CodDoc;
        private string Estab;
        private string PtoEmi;
        private string Secuencial;
        private string dirMatriz;

        public InfoTributaria()
        {

        }

        public InfoTributaria(int ambiente, int tipoemision, string razonsocial,string nombrecomercial, string ruc, string coddoc,string estab,string ptoemi,string secuencial,string dirmatriz)
        {
            this.ambiente = ambiente;
            this.tipoEmision = tipoemision;
            this.RazonSocial = razonsocial;
            this.NombreComercial = nombrecomercial;
            this.Ruc = ruc;
            this.CodDoc = coddoc;
            this.Estab = estab;
            this.PtoEmi = ptoemi;
            this.Secuencial = secuencial;
            this.dirMatriz = dirmatriz;
        }

        public int Ambiente
        {
            get
            {
                return ambiente;
            }

            set
            {
                ambiente = value;
            }
        }

        public int TipoEmision
        {
            get
            {
                return tipoEmision;
            }

            set
            {
                tipoEmision = value;
            }
        }

        public string RazonSociaL
        {
            get
            {
                return RazonSocial;
            }

            set
            {
                RazonSocial = value;
            }
        }

        public string NombreComerciaL
        {
            get
            {
                return NombreComercial;
            }

            set
            {
                NombreComercial = value;
            }
        }

        public string RuC
        {
            get
            {
                return Ruc;
            }

            set
            {
                Ruc = value;
            }
        }

        public string CodDoC
        {
            get
            {
                return CodDoc;
            }

            set
            {
                CodDoc = value;
            }
        }

        public string EstaB
        {
            get
            {
                return Estab;
            }

            set
            {
                Estab = value;
            }
        }

        public string PtoEmI
        {
            get
            {
                return PtoEmi;
            }

            set
            {
                PtoEmi = value;
            }
        }

        public string SecuenciaL
        {
            get
            {
                return Secuencial;
            }

            set
            {
                Secuencial = value;
            }
        }

        public string DirMatriz
        {
            get
            {
                return DirMatriz;
            }

            set
            {
                dirMatriz = value;
            }
        }

        public string GenerarClaveAcceso(string fecha,string tipoComprobante,string serie)
        {
            string clave="",NumCualquiera="00000010";
            string[] vector = fecha.Split('/');
            clave = vector[0] + vector[1] + vector[2] + tipoComprobante + Ruc + ambiente + serie + Secuencial + NumCualquiera + tipoEmision;
            int numeroverificador = DigitoModulo11(Convert.ToInt64(clave));
            clave += numeroverificador;
            return clave;
        }

        private int DigitoModulo11(long intNumero)

        {

            int[] intPesos = { 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9 };

            string strText = intNumero.ToString();



            if (strText.Length > 16)

                throw new Exception("Número não suportado pela função!");



            int intSoma = 0;

            int intIdx = 0;

            for (int intPos = strText.Length - 1; intPos >= 0; intPos--)

            {

                intSoma += Convert.ToInt32(strText[intPos].ToString()) * intPesos[intIdx];

                intIdx++;

            }

            int intResto = (intSoma * 10) % 11;

            int intDigito = intResto;

            if (intDigito >= 10)

                intDigito = 0;



            return intDigito;

        }
    }
}