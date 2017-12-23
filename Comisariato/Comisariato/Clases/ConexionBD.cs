﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comisariato.Clases
{
   public class ConexionBD
    {
        public static SqlConnection connection = null;
        //------------------------------Conexion Andres ----------------------------------------//
        //Data Source=DESKTOP-FUFA7EG\\ANDRES;Initial Catalog=BDComisariato;Integrated Security=True
        //Data Source=DESKTOP-G14ID1U;Initial Catalog=BDComisariato;Integrated Security=True
        //------------------------------Conexion Servidor----------------------------------------//
        //data source = AIRCONTROL, 1433; initial catalog = BDComisariato; user id = COMI; password = server@1;
        //------------------------------Conexion Byron ----------------------------------------//
        //Data Source = DESKTOP-SI5M9C5; Initial Catalog = BDComisariato; Integrated Security = True


        public void conectar()
        {
            try
            {
                //    string[] datosArchivoConfig = Funcion.leerArchivo(@"C:\Program Files (x86)\Aircontrol\Conexion.shc");
                //    string[] servidorPuerto = datosArchivoConfig[0].Split(':');
                //String conection = "data source = " + servidorPuerto[0] + ", " + servidorPuerto[1] + "; initial catalog = " + datosArchivoConfig[1] + "; user id = " + datosArchivoConfig[2] + "; password = " + datosArchivoConfig[3] + ";";
                //((connection = new SqlConnection("data source = " + servidorPuerto[0] + ", " + servidorPuerto[1] + "; initial catalog = " + datosArchivoConfig[1] + "; user id = " + datosArchivoConfig[2] + "; password = " + datosArchivoConfig[3] + ";");
                //connection = new SqlConnection("data source = SERVER, 1433; initial catalog = BDComisariato; user id = COMI; password = server@1;");
                connection = new SqlConnection("Data Source=DJSERATO\\SQLEXPRESS;Initial Catalog=BDComisariato;Integrated Security=True");
                connection.Open();
               
            }
            catch (SqlException ex)
            {   
                MessageBox.Show("Error al conectarse a la Base De Datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

        }
        public void Cerrar()
        {
            //string[] datosArchivoConfig = Funcion.leerArchivo(@"C:\Program Files (x86)\Aircontrol\Conexion.shc");
            //string[] servidorPuerto = datosArchivoConfig[0].Split(':');

            connection = new SqlConnection("Data Source=DJSERATO\\SQLEXPRESS;Initial Catalog=BDComisariato;Integrated Security=True");
            connection.Close();
        }
    }
}
