using Comisariato.Clases;
using Comisariato.Formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comisariato
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        public static string RutaImpresora="";
        public static string Usuario="",contraseñausuarioactual;
        public static string FecaInicio;
        public static string horainicio ;
        public static string IDUsuario = "", NOMBRES="",APELLIDOS="", IDTIPOUSUARIO,IDEMPRESA;
        public static int numfact = 0;
        public static bool estado;

        //Parametros Factura
        public static string piefactura="";
        public static bool BoolPreimpresa = false;
        public static bool BoolAutorizadoImprimir = false;
        public static string DatosPreimpresa = "";
        public static string IVA;
        public static string obligadoContabilidad;

        //public static string IDUsuarioMenu = "";
        public static EmcabezadoFactura em = new EmcabezadoFactura();
        // ------- Variables Usadas por Andres 
        public static string IDUsuarioMenu = "";
        public static Form panelPrincipalVariable;
        public static bool FormularioLlamado = false;
        public static bool FormularioProveedorCompra = false;
        public static bool FormularioVentaAbierto = false;
        public static bool FormularioOrdenGiro = false;
        public static int EmpresaUsuario = 0;
        //datos empresa
        public static string nombreempresa;
        public static string rucempresa;
        public static string direccionempresa;
        public static string razonsocialempresa;

        //otros
        public static int tamañoVentanaPrincipal;



        //-----------------------------------------
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }
    }
}
