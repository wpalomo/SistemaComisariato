using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comisariato.Clases
{
    class Consultas
    {
        ConexionBD Objc = new ConexionBD();
        public List<Producto> detalleFact;
        public List<String> detallepagoreim;

        public bool Insertar(string SQL)
        {
            try
            {
                SqlCommand Sentencia;
                Sentencia = new SqlCommand(SQL);
                Objc.conectar();
                Sentencia.Connection = ConexionBD.connection;
                Sentencia.ExecuteNonQuery();
                Objc.Cerrar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.. " + ex.Message);
                return false;
            }
        }
        public bool VerificarClave(String Contraseña)
        {
            try
            {
                Objc.conectar();
                SqlCommand Sentencia = new SqlCommand("SELECT TbUsuario.CONTRASEÑA, TbUsuario.USUARIO, TbTipousuario.TIPO, TbUsuario.IDTIPOUSUARIO, TbEmpresa.NOMBRECOMERCIAL, TbEmpresa.RUC, TbEmpresa.DIRECCION from TbUsuario  INNER JOIN TbTipousuario ON(TbUsuario.FACTURA='1') and TbUsuario.USUARIO = '" + Program.Usuario + "' and TbUsuario.CONTRASEÑA= '" + Contraseña + "' INNER JOIN TbEmpresa ON (TbEmpresa.IDEMPRESA='" + Program.IDEMPRESA + "' );");
                Sentencia.Connection = ConexionBD.connection;
                SqlDataReader dato = Sentencia.ExecuteReader();
                Objc.Cerrar();
                if (dato.Read() == true)
                {
                    Program.nombreempresa = (String)dato["NOMBRECOMERCIAL"];
                    Program.rucempresa = (String)dato["RUC"];
                    Program.direccionempresa = (String)dato["DIRECCION"];
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar la base de Datos " + ex.Message, "Comprobar usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            // return true;
        }

        public bool AutenticacionUsuario(String Usuario, String Contraseña)
        {
            try
            {
                Objc.conectar();
                string sql = "select U.IDUSUARIO ,U.IDEMPLEADO, U.USUARIO, U.CONTRASEÑA, U.IDTIPOUSUARIO, U.IDEMPRESA, U.ACTIVO from TbUsuario U where U.USUARIO='" + Usuario + "' and  U.CONTRASEÑA='" + Contraseña + "'";
                //string sql = "select U.IDUSUARIO, U.IDEMPLEADO, U.USUARIO, U.CONTRASEÑA, U.IDTIPOUSUARIO, U.IDEMPRESA, U.ACTIVO from TbUsuario U where U.USUARIO='" + Usuario + "' and  U.CONTRASEÑA='" + Contraseña + "'";
                SqlCommand Sentencia = new SqlCommand(sql);
                Sentencia.Connection = ConexionBD.connection;
                //int valor = Convert.ToInt32(Sentencia.ExecuteScalar());
                SqlDataReader dato = Sentencia.ExecuteReader();
                Objc.Cerrar();
                if (dato.Read() == true)
                {
                    Program.Usuario = Usuario;
                    Program.IDUsuarioMenu = Convert.ToString(dato["IDUSUARIO"]);
                    Program.estado = Convert.ToBoolean(dato["ACTIVO"]);
                    Program.IDUsuario = "" + (int)dato["IDEMPLEADO"];
                    Program.IDTIPOUSUARIO = "" + (int)dato["IDTIPOUSUARIO"];
                    Program.IDEMPRESA = "" + (int)dato["IDEMPRESA"];
                    datosiniciosesion("" + (int)dato["IDEMPLEADO"]);
                    return true;
                }

                else { return false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar la base de Datos " + ex.Message, "Comprobar usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
        }
        public void BoolLlenarComboBox(ComboBox cb, String SQL)
        {
            try
            {
                Objc.conectar();
                SqlDataAdapter objDA;
                SqlCommand cmd = new SqlCommand(SQL, ConexionBD.connection);
                objDA = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                objDA.Fill(dt);
                Objc.Cerrar();
                cb.DisplayMember = "Texto";
                cb.ValueMember = "ID";
                cb.DataSource = dt;
                objDA.Dispose();
            }
            catch (Exception e)
            {
                //MessageBox.Show(""+e.Message);
                //throw;
            }
        }
        public void BoolLlenarComboBoxDgv(DataGridViewComboBoxColumn cb, String SQL)
        {
            try
            {
                Objc.conectar();
                SqlDataAdapter objDA;
                SqlCommand cmd = new SqlCommand(SQL, ConexionBD.connection);
                objDA = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                objDA.Fill(dt);
                Objc.Cerrar();
                cb.DisplayMember = "Texto";
                cb.ValueMember = "ID";
                cb.DataSource = dt;
                objDA.Dispose();
            }
            catch (Exception e)
            {
                //MessageBox.Show(""+e.Message);
                //throw;
            }
        }
        public void BoolLlenarCheckListBox(CheckedListBox chkl, String SQL)
        {
            //Consulta a la Bases de Datos


            //Adatador para el Acceso a Datosx
            SqlDataAdapter ObjSQLDA = new SqlDataAdapter(SQL, ConexionBD.connection);
            //Objeto  DataSet

            DataSet ObjDS = new DataSet();
            //Llenamos el Dataset con el adaptador que devuelve la consulta
            ObjSQLDA.Fill(ObjDS, "Texto");

            //Al Componente CheckListBox le asignamos las siguiente propiedades

            //Fuente de Datos

            chkl.DataSource = ObjDS.Tables[0];

            //Campo que se quiere mostrar
            chkl.DisplayMember = "Texto";

            //Campo por el cual  se va acceder Codigo, ruta , etc..
            chkl.ValueMember = "ID";

            ObjSQLDA.Dispose();
        }
        private void datosiniciosesion(String id)
        {
            try
            {
                Objc.conectar();
                string sql = "select IDEMPLEADO, U.NOMBRES, U.APELLIDOS from TbEmpleado U where U.IDEMPLEADO='" + id + "'";
                SqlCommand Sentencia = new SqlCommand(sql);
                Sentencia.Connection = ConexionBD.connection;
                //int valor = Convert.ToInt32(Sentencia.ExecuteScalar());
                SqlDataReader dato = Sentencia.ExecuteReader();
                Objc.Cerrar();
                if (dato.Read() == true)
                {
                    Program.NOMBRES = (String)dato["NOMBRES"];
                    Program.APELLIDOS = (String)dato["APELLIDOS"];
                    //return true;
                }

            }
            catch (Exception ex)
            {
                //  MessageBox.Show("Error al conectar la base de Datos " + ex.Message, "Comprobar usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                //return false;
            }
        }

        public DataTable BoolDataTable(String SQL)
        {
            Objc.conectar();
            SqlDataAdapter objDA;
            DataTable objDS = new DataTable();
            objDA = new SqlDataAdapter(SQL, ConexionBD.connection);
            //2. Llenar el DataSet
            objDA.Fill(objDS);
            Objc.Cerrar();
            objDA.Dispose();
            return objDS;
            //3. DataBiding de los datos en el ComboBox    DataBiding el enlace de los datos
            //cb.DataSource = objDS.Tables[0];
            ////3b. Especificar el Datavalue y el DisplayMember
            //cb.DisplayMember = "Texto";
            //cb.ValueMember = "ID";
            ////Liberar el DataApdater
        }
        public bool RegistrarCheque(DataGridView dg, int ultimafact)
        {
            try
            {
                SqlCommand Sentencia;
                string precio = "";
                Objc.conectar();
                for (int i = 0; i < dg.RowCount; i++)
                {
                    if (Convert.ToString(dg.Rows[i].Cells[0].Value) != "")
                    {
                        precio = Funcion.reemplazarcaracter(dg.Rows[i].Cells[5].Value.ToString());
                        Sentencia = new SqlCommand("INSERT INTO TbDatosCheque (NUMCHEQUE, NUMCUENTA, BANCO, FECHA, PROPIETARIO, MONTO, IDEMCABEZADOFACT) VALUES ( '" + dg.Rows[i].Cells[0].Value + "','" + dg.Rows[i].Cells[1].Value + "','" + Convert.ToString(dg.Rows[i].Cells[2].Value).ToUpper() + "','" + dg.Rows[i].Cells[3].Value + "','" + Convert.ToString(dg.Rows[i].Cells[4].Value).ToUpper() + "','" + precio + "','" + ultimafact + "')");
                        Sentencia.Connection = ConexionBD.connection;
                        Sentencia.ExecuteNonQuery();
                    }
                    else
                    {
                        break;
                    }

                }

                Objc.Cerrar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.. " + ex.Message);
                return false;
            }
        }

        public bool RegistrarTarjeta(DataGridView dg, int utl)
        {
            try
            {
                SqlCommand Sentencia;
                string precio = "";
                Objc.conectar();
                for (int i = 0; i < dg.RowCount; i++)
                {
                    if (Convert.ToString(dg.Rows[i].Cells[0].Value) != "")
                    {
                        precio = Funcion.reemplazarcaracter(dg.Rows[i].Cells[2].Value.ToString());
                        Sentencia = new SqlCommand("INSERT INTO TbDatosTarjeta (NUMCHEQUE, FECHA, MONTO, TIPOTARJETA, IDEMCABEZADOFACT) VALUES ( '" + dg.Rows[i].Cells[0].Value + "','" + dg.Rows[i].Cells[1].Value + "','" + dg.Rows[i].Cells[2].Value + "','" + Convert.ToString(dg.Rows[i].Cells[3].Value).ToUpper() + "','" + utl + "')");
                        Sentencia.Connection = ConexionBD.connection;
                        Sentencia.ExecuteNonQuery();
                    }

                }

                Objc.Cerrar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.. " + ex.Message);
                return false;
            }
        }

        public bool EjecutarSQL(string SQL)
        {
            try
            {
                SqlCommand Sentencia;
                Sentencia = new SqlCommand(SQL);
                Objc.conectar();
                Sentencia.Connection = ConexionBD.connection;
                Sentencia.ExecuteNonQuery();
                Objc.Cerrar();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool GuardarFact(int nfilas, DataGridView dg, List<string> encabezado, List<string> detallepago, List<string> ivas, int inicioContador)
        {
            try
            {
                Objc.conectar();
                string precio = "";
                int result = 0;
                List<string> enca = encabezado;
                List<string> detalle = detallepago;
                SqlCommand cmd = null;
                string idempresa = Program.IDEMPRESA;
                nfilas = nfilas + inicioContador;
                int contador = 0;
                for (int i = inicioContador; i < nfilas; i++)
                {
                    precio = Funcion.reemplazarcaracter(dg.Rows[i].Cells[4].Value.ToString());
                    cmd = new SqlCommand("REGISTRAR_FACTURA", ConexionBD.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CONTADOR ", contador);
                    cmd.Parameters.AddWithValue("@sucursal", Convert.ToInt32(enca[0]));
                    cmd.Parameters.AddWithValue("@caja", Convert.ToInt32(enca[1]));
                    cmd.Parameters.AddWithValue("@numfact", Convert.ToInt32(enca[2]));
                    cmd.Parameters.AddWithValue("@fecha", enca[3]);
                    cmd.Parameters.AddWithValue("@hora", enca[4]);
                    cmd.Parameters.AddWithValue("@descuento", detalle[1]);
                    cmd.Parameters.AddWithValue("@cant", dg.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@iva", detalle[0]);
                    cmd.Parameters.AddWithValue("@efectivo", detalle[2]);
                    cmd.Parameters.AddWithValue("@cheque", detalle[3]);
                    cmd.Parameters.AddWithValue("@credito", detalle[4]);
                    cmd.Parameters.AddWithValue("@idempleado", enca[5]);
                    cmd.Parameters.AddWithValue("@idcliente", enca[6]);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@codigobarraproducto", dg.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@recibido", detalle[5]);
                    cmd.Parameters.AddWithValue("@cambio", detalle[6]);
                    cmd.Parameters.AddWithValue("@estado", 1);
                    cmd.Parameters.AddWithValue("@ivat", ivas[i]);
                    cmd.Parameters.AddWithValue("@idempresa", idempresa);
                    cmd.Parameters.AddWithValue("@cantcaja", dg.Rows[i].Cells[8].Value);
                    result = cmd.ExecuteNonQuery();
                    contador += 1;
                }

                Objc.Cerrar();
                if (result > 0)
                {
                    
                    return true;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool DevolucionVenta(List<string> lista, int numfact)
        {
            try
            {
                int result = 0;
                Objc.conectar();
                SqlCommand cmd = null;
                for (int i = 0; i < lista.Count; i++)
                {
                    string[] vector = lista[i].Split(';');
                    cmd = new SqlCommand("DEVOLUCIONVENTA", ConexionBD.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigobarraproducto", vector[0]);
                    cmd.Parameters.AddWithValue("@cant", Convert.ToInt32(vector[1]));
                    cmd.Parameters.AddWithValue("@estado", 0);
                    cmd.Parameters.AddWithValue("@numfact", numfact);
                    result = cmd.ExecuteNonQuery();
                }

                Objc.Cerrar();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
                return false;
            }
        }
        public int ObtenerID(String campoID, String tabla, String condicion)
        {
            try
            {
                int ID = 0;
                Objc.conectar();
                SqlCommand Sentencia;
                Sentencia = new SqlCommand("SELECT  max(" + campoID + ") AS id from " + tabla + "" + condicion, ConexionBD.connection);
                //Sentencia = new SqlCommand("SELECT IDENT_CURRENT ('"+ tabla + "')as "+ campoID + "" + condicion, ConexionBD.connection);
                ID = Convert.ToInt32(Sentencia.ExecuteScalar());
                Objc.Cerrar();
                return ID;
            }
            catch (Exception)
            {
                return 0;

            }

        }
        public string ObtenerValorCampo(String campo, String tabla, String condicion)
        {
            try
            {
                SqlDataAdapter objDA;
                string valor = "";
                DataTable dt = new DataTable();
                Objc.conectar();
                string sentencia = "SELECT  " + campo + " from " + tabla + " " + condicion;
                objDA = new SqlDataAdapter(sentencia, ConexionBD.connection);
                objDA.Fill(dt);
                Objc.Cerrar();
                objDA.Dispose();
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    valor = row[campo].ToString();
                }
                return valor;
            }
            catch (Exception ex)
            {
                return "error";

            }
        }
        public Producto Consultarproducto(String codigo)
        {
            Producto producto = new Producto();

            try
            {
                Objc.conectar();
                SqlCommand Sentencia = new SqlCommand("select U.CAJA, P.IVA as IVA, U.ACTIVO, U.NOMBREPRODUCTO as DETALLE, U.CANTIDAD, U.PRECIOPUBLICO_SIN_IVA as PRECIOVENTAPUBLICO, U.IVAESTADO, U.PRECIOALMAYOR_SIN_IVA as PRECIOVENTAMAYORISTA,  U.PRECIOPORCAJA_SIN_IVA as PRECIOVENTACAJA from TbProducto U, TbParametrosFactura P where U.CODIGOBARRA = '" + codigo + "'");
                Sentencia.Connection = ConexionBD.connection;
                SqlDataReader dato = Sentencia.ExecuteReader();
                if (dato.Read() == true)
                {
                    int activo = Convert.ToInt32(dato["ACTIVO"]);
                    if (activo == 1)
                    {
                        producto.Nombreproducto = (String)dato["DETALLE"];

                        //        //producto.Cant = Convert.ToInt32(dato["CANTIDAD"]);
                        producto.Cantidad = Convert.ToInt32(dato["CANTIDAD"]);
                        producto.Caja = Convert.ToInt32(dato["CAJA"]);
                        producto.Preciopublico_sin_iva = Convert.ToSingle(dato["PRECIOVENTAPUBLICO"]);
                        producto.Ivaestado = Convert.ToBoolean(dato["IVAESTADO"]);
                        producto.Iva = Convert.ToInt32(dato["IVA"]);
                        producto.Precioalmayor_sin_iva = Convert.ToSingle(dato["PRECIOVENTAMAYORISTA"]);
                        producto.Precioporcaja_sin_iva = Convert.ToSingle(dato["PRECIOVENTACAJA"]);
                    }
                    else
                    {
                        MessageBox.Show("El producto no está activo.");
                        producto = null;
                    }
                }
                else
                {
                    producto = null;
                    MessageBox.Show("No se encontró ningun producto con ese codigo.");
                    //DgvDetalle.Rows.RemoveAt(e.RowIndex);
                }

            }
            catch (Exception ex)
            {

                //throw;
            }

            Objc.Cerrar();
            return producto;
        }

        public Producto ConsultarproductoCompra(String codigo)
        {
            Producto producto = new Producto();

            try
            {
                Objc.conectar();
                SqlCommand Sentencia = new SqlCommand("select  U.ACTIVO, U.NOMBREPRODUCTO as DETALLE, U.CANTIDAD, " +
                    "U.PRECIOPUBLICO_IVA as PRECIOVENTAPUBLICO, U.IVAESTADO, U.PRECIOALMAYOR_IVA as PRECIOVENTAMAYORISTA,PRECIOALMAYOR_SIN_IVA, PRECIOPORCAJA_SIN_IVA" +
                    ", PRECIOPUBLICO_SIN_IVA, PRECIOCOMPRA, U.PRECIOPORCAJA_IVA as PRECIOVENTACAJA, ICE, IRBP, PRECIOCOMPRA " +
                    "from TbProducto U where U.CODIGOBARRA = '" + codigo + "'");
                Sentencia.Connection = ConexionBD.connection;
                SqlDataReader dato = Sentencia.ExecuteReader();
                if (dato.Read() == true)
                {
                    int activo = Convert.ToInt32(dato["ACTIVO"]);
                    if (activo == 1)
                    {
                        producto.Ivaestado = Convert.ToBoolean(dato["IVAESTADO"]);
                        producto.Nombreproducto = (String)dato["DETALLE"];
                        if (Convert.ToString(dato["PRECIOCOMPRA"]) != "")
                        {
                            producto.PrecioCompra = Convert.ToSingle(dato["PRECIOCOMPRA"]);
                        }

                        producto.Preciopublico_iva = Convert.ToSingle(dato["PRECIOVENTAPUBLICO"]);
                        producto.Precioalmayor_iva = Convert.ToSingle(dato["PRECIOVENTAMAYORISTA"]);
                        producto.Precioporcaja_iva = Convert.ToSingle(dato["PRECIOVENTACAJA"]);
                        producto.Preciopublico_sin_iva = Convert.ToSingle(dato["PRECIOPUBLICO_SIN_IVA"]);
                        producto.Precioalmayor_sin_iva = Convert.ToSingle(dato["PRECIOALMAYOR_SIN_IVA"]);
                        producto.Precioporcaja_sin_iva = Convert.ToSingle(dato["PRECIOPORCAJA_SIN_IVA"]);
                        producto.Irbp = Convert.ToSingle(dato["IRBP"]);
                        producto.Ice = Convert.ToSingle(dato["ICE"]);
                    }
                    else
                    {
                        MessageBox.Show("El producto no está activo.");
                        producto = null;
                    }
                }
                else
                {
                    producto = null;
                    MessageBox.Show("No se encontró ningun producto con ese codigo.");
                    //DgvDetalle.Rows.RemoveAt(e.RowIndex);
                }

            }
            catch (Exception ex)
            {

                //throw;
            }

            Objc.Cerrar();
            return producto;
        }

        public EmcabezadoFactura ConsutarFactura(int sucursal, int caja, int numfact, int metodo)
        {
            EmcabezadoFactura encabezado = null;
            try
            {
                detallepagoreim = new List<string>();
                Objc.conectar();
                string sql = "SELECT U.SUCURSAL, U.CAJA, U.NFACTURA, U.FECHA, U.HORA, U.IDEMPLEADO, U.IDCLIENTE, C.NOMBRES AS NCLIENTE, C.APELLIDOS AS ACLIENTE, C.IDENTIFICACION, A.NOMBRES AS NEMPLEADO, A.APELLIDOS AS AEMPLEADO, P.EFECTIVO, P.CHEQUE, P.CREDITO, P.IVA, P.DESCUENTO, P.CAMBIO, P.RECIBIDO from TbEncabezadoFactura U INNER JOIN TbEmpleado A ON(U.SUCURSAL='" + sucursal + "' and U.CAJA= '" + caja + "' and NFACTURA='" + numfact + "') AND ( A.IDEMPLEADO= U.IDEMPLEADO) INNER JOIN TbCliente C ON( A.IDEMPLEADO= U.IDEMPLEADO and C.IDCLIENTE=U.IDCLIENTE)  INNER JOIN TbDetallePago P ON(U.IDFACTURA=P.IDENCABEZADOFACT)";

                SqlCommand Sentencia = new SqlCommand(sql);
                Sentencia.Connection = ConexionBD.connection;
                SqlDataReader dato = Sentencia.ExecuteReader();
                if (dato.Read() == true)
                {
                    encabezado = new EmcabezadoFactura();
                    //detalleFact = new List<Producto>();

                    //encabezado.Descuento = Convert.ToSingle(dato["DESCUENTO"]);
                    // encabezado.Iva = Convert.ToSingle(dato["IVA"]);
                    encabezado.Idempleado = Convert.ToInt32(dato["IDEMPLEADO"]);
                    encabezado.Idcliente = Convert.ToInt32(dato["IDCLIENTE"]);
                    string nombre = (String)dato["IDENTIFICACION"];
                    if (nombre == "9999999999999")
                    {
                        encabezado.NombresCliente = (String)dato["NCLIENTE"];
                    }
                    else
                    {
                        encabezado.NombresCliente = (String)dato["NCLIENTE"] + " " + (String)dato["ACLIENTE"];
                    }
                    encabezado.NombreUsuario = (String)dato["NEMPLEADO"] + " " + (String)dato["AEMPLEADO"];
                    encabezado.Identificacion = (String)dato["IDENTIFICACION"];
                    encabezado.Fecha = Convert.ToDateTime(dato["FECHA"]).ToString();
                    //encabezado.Hora = Convert.ToDateTime( dato["HORA"]).ToString("HHMMss");
                    detalleFact = DetalleFact(numfact, metodo);
                    detallepagoreim.Add(Convert.ToString(dato["EFECTIVO"]));
                    detallepagoreim.Add(Convert.ToString(dato["CHEQUE"]));
                    detallepagoreim.Add(Convert.ToString(dato["CREDITO"]));
                    detallepagoreim.Add(Convert.ToString(dato["DESCUENTO"]));
                    detallepagoreim.Add(Convert.ToString(dato["IVA"]));
                    detallepagoreim.Add(Convert.ToString(dato["RECIBIDO"]));
                    detallepagoreim.Add(Convert.ToString(dato["CAMBIO"]));

                }
                else
                {
                    encabezado = null;
                    //4710268216865
                    MessageBox.Show("No se pudo encontrar una factura con esa serie.");
                    //DgvDetalle.Rows.RemoveAt(e.RowIndex);
                }

            }
            catch (Exception ex)
            {

                // throw;
            }

            Objc.Cerrar();
            return encabezado;
        }

        public List<Producto> DetalleFact(int nfact, int verimetodo)
        {
            try
            {
                List<Producto> lista = new List<Producto>();
                Objc.conectar();
                //string sql = " SELECT U.PRECIO, U.CANTDEVUELTA, U.CANTIDAD, U.CODIGOBARRAPRODUCTO, U.ESTADO, U.IVA, P.NOMBREPRODUCTO, P.IVAESTADO from TbDetalleFactura U INNER JOIN TbProducto P  ON(U.NFACTURA = '" + nfact + "') AND(P.CODIGOBARRA = U.CODIGOBARRAPRODUCTO)";
                String sql = "SELECT        dbo.TbDetalleFactura.PRECIO, dbo.TbDetalleFactura.CANTDEVUELTA, dbo.TbDetalleFactura.CANTIDAD, dbo.TbDetalleFactura.CODIGOBARRAPRODUCTO, dbo.TbDetalleFactura.ESTADO, dbo.TbDetalleFactura.IVA, dbo.TbProducto.NOMBREPRODUCTO, dbo.TbProducto.IVAESTADO, dbo.TbEncabezadoFactura.NFACTURA FROM  dbo.TbDetalleFactura INNER JOIN" +
                         " dbo.TbProducto ON dbo.TbDetalleFactura.CODIGOBARRAPRODUCTO = dbo.TbProducto.CODIGOBARRA INNER JOIN dbo.TbEncabezadoFactura ON dbo.TbDetalleFactura.NFACTURA = dbo.TbEncabezadoFactura.IDFACTURA" +
                         " WHERE(dbo.TbEncabezadoFactura.NFACTURA = '" + nfact + "')";
                SqlCommand comando = new SqlCommand(sql);
                comando.Connection = ConexionBD.connection;
                SqlDataReader dato = comando.ExecuteReader();
                Objc.Cerrar();
                while (dato.Read() == true)
                {
                    Producto p = new Producto();
                    p.Preciopublico_sin_iva = Convert.ToSingle(dato["PRECIO"].ToString());
                    p.Cantidad = Convert.ToInt32(dato["CANTIDAD"].ToString());
                    p.Codigobarra = (String)dato["CODIGOBARRAPRODUCTO"];
                    p.Nombreproducto = (String)dato["NOMBREPRODUCTO"];
                    p.Iva = Convert.ToInt32(dato["IVA"].ToString());
                    p.Cantidad1 = Convert.ToInt32(dato["CANTDEVUELTA"].ToString());
                    if (verimetodo == 1)
                    {
                        lista.Add(p);
                    }
                    else
                    {
                        bool b = Convert.ToBoolean(dato["ESTADO"]);
                        if (b)
                        {
                            int resultado = p.Cantidad - p.Cantidad1;
                            if (resultado != 0)
                            {
                                p.Cantidad = resultado;
                                lista.Add(p);
                            }

                        }

                    }


                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar cliente: " + ex);
                return null;
            }
        }


        public bool boolLlenarDataGridView(DataGridView data, String SQL)
        {
            Objc.conectar();
            SqlDataAdapter objDA;
            DataSet objDS = new DataSet();
            try
            {
                objDA = new SqlDataAdapter(SQL, ConexionBD.connection);
                objDA.Fill(objDS);
                data.DataSource = objDS.Tables[0];
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encuentran resultados " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<string> DatosCliente(string parametro)
        {
            try
            {
                List<string> lista = new List<string>();
                Objc.conectar();
                SqlCommand comando = new SqlCommand("Select IDENTIFICACION,NOMBRES, APELLIDOS, EMAIL, RAZONSOCIAL, TELEFONOCASA AS TELEFONO, DIRECCION from TbCliente where  IDENTIFICACION='" + parametro + "' ");
                comando.Connection = ConexionBD.connection;
                SqlDataReader dato = comando.ExecuteReader();
                Objc.Cerrar();
                if (dato.Read() == true)
                {
                    lista.Add(dato["IDENTIFICACION"].ToString());
                    lista.Add(dato["NOMBRES"].ToString());
                    lista.Add(dato["APELLIDOS"].ToString());
                    lista.Add(dato["EMAIL"].ToString());
                    lista.Add(dato["RAZONSOCIAL"].ToString());
                    lista.Add(dato["TELEFONO"].ToString());
                    lista.Add(dato["DIRECCION"].ToString());
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar cliente: " + ex);
                return null;
            }
        }

        public List<string> DatosParametrosfactura(string parametro)
        {
            try
            {
                List<string> lista = new List<string>();
                Objc.conectar();
                SqlCommand comando = new SqlCommand("Select IDENTIFICACION,NOMBRES, APELLIDOS, EMAIL, RAZONSOCIAL, TELEFONOCASA AS TELEFONO, DIRECCION from TbCliente where  IDENTIFICACION='" + parametro + "' ");
                comando.Connection = ConexionBD.connection;
                SqlDataReader dato = comando.ExecuteReader();
                Objc.Cerrar();
                if (dato.Read() == true)
                {
                    lista.Add(dato["IDENTIFICACION"].ToString());
                    lista.Add(dato["NOMBRES"].ToString());
                    lista.Add(dato["APELLIDOS"].ToString());
                    lista.Add(dato["EMAIL"].ToString());
                    lista.Add(dato["RAZONSOCIAL"].ToString());
                    lista.Add(dato["TELEFONO"].ToString());
                    lista.Add(dato["DIRECCION"].ToString());
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar cliente: " + ex);
                return null;
            }
        }


        public Cliente buscarcliente(string identificacion)
        {
            Cliente datos;
            try
            {
                datos = new Cliente();
                Objc.conectar();
                SqlCommand Sentencia = new SqlCommand("select U.IDCLIENTE, U.IDENTIFICACION, U.NOMBRES, U.APELLIDOS, U.ACTIVO, U.DIRECCION, U.RAZONSOCIAL from TbCliente U where U.IDENTIFICACION='" + identificacion + "';");
                Sentencia.Connection = ConexionBD.connection;
                SqlDataReader dato = Sentencia.ExecuteReader();
                Objc.Cerrar();
                if (dato.Read() == true)
                {
                    datos.Nombres = (String)dato["NOMBRES"];// + " " + (String)dato["APELLIDOS"] + ";" + dato["IDCLIENTE"];
                    datos.Apellidos = (String)dato["APELLIDOS"];
                    datos.Casilla = Convert.ToInt32(dato["IDCLIENTE"]);
                    datos.Direccion = (String)dato["DIRECCION"];
                    datos.RazonSocial = (String)dato["RAZONSOCIAL"];
                    datos.Activo = Convert.ToBoolean(dato["ACTIVO"]);
                }
                else
                {
                    //producto = null;
                    datos = null;
                    // MessageBox.Show("No se encontró ningun producto con ese codigo.");
                    //DgvDetalle.Rows.RemoveAt(e.RowIndex);
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(""+ex.Message);
                datos = null;
            }
            return datos;

        }
        public bool Existe(string campo, string parametro, string tabla)
        {
            try
            {
                Objc.conectar();
                SqlCommand Cmd = new SqlCommand("Select * from " + tabla + " where " + campo + "='" + parametro + "'", ConexionBD.connection);
                SqlDataReader DReader = Cmd.ExecuteReader();
                if (DReader.Read() == true)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse a la Base De Datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
        }
        public Boolean BoolCrearDateTable(DataGridView Tb, String SQL)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("CODIGO", typeof(String));
            dt.Columns.Add("DETALLE", typeof(String));
            dt.Columns.Add("CANT.", typeof(int));
            dt.Columns.Add("P. PUBLICO", typeof(String));
            dt.Columns.Add("P. MAYORISTA", typeof(String));
            dt.Columns.Add("P. CAJA", typeof(String));
            dt.Columns.Add("ESTADO IVA", typeof(int));
            dt.Columns.Add("IVA", typeof(int));
            dt.Columns.Add("Cant. Caja", typeof(int));

            try
            {
                Objc.conectar();
                SqlCommand Sentencia = new SqlCommand(SQL);
                Sentencia.Connection = ConexionBD.connection;
                SqlDataReader dato = Sentencia.ExecuteReader();
                Objc.Cerrar();
                while (dato.Read() == true)
                {
                    int v;
                    float pp = Convert.ToSingle(dato["PRECIOVENTAPUBLICO"]);
                    float pm = Convert.ToSingle(dato["PRECIOVENTAMAYORISTA"]);
                    float pc = Convert.ToSingle(dato["PRECIOVENTACAJA"]);
                    bool ivaestado = Convert.ToBoolean(dato["IVAESTADO"]);
                    int activo = Convert.ToInt32(dato["ACTIVO"]);
                    if (activo == 1)
                    {
                        if (ivaestado)
                        {
                            v = 1;
                            int iva = int.Parse(dato["IVA"].ToString());
                            dt.Rows.Add((String)dato["CODIGOBARRA"], (String)dato["DETALLE"], (int)dato["CANTIDAD"], pp.ToString("#####0.00"), pm.ToString("#####0.00"), pc.ToString("#####0.00"), v, iva, (int)dato["CAJA"]);
                        }
                        else
                        {
                            v = 0;
                            dt.Rows.Add((String)dato["CODIGOBARRA"], (String)dato["DETALLE"], (int)dato["CANTIDAD"], pp.ToString("#####0.00"), pm.ToString("#####0.00"), pc.ToString("#####0.00"), v, 0, (int)dato["CAJA"]);
                        }
                        //dt.Rows.Add((String)dato["CODIGOBARRA"], (String)dato["DETALLE"], (int)dato["CANTIDAD"], pp.ToString("#####0.00"), pm.ToString("#####0.00"), pc.ToString("#####0.00"), v, (int)dato["IVA"]);

                    }


                }
                Tb.DataSource = dt;

                return true;


            }
            catch (Exception ex)
            {
                //MessageBox.Show("" + ex.Message);
                return false;

            }


            //return false;


        }
        public void insertarTelefono(DataGridView data, int IDRelacion, string tipoEntidad)
        {
            if (data.RowCount > 1)
            {
                for (int i = 0; i < data.RowCount - 1; i++)
                {
                    string telefono = data.Rows[i].Cells[0].Value.ToString();
                    if (telefono != "")
                    {
                        EjecutarSQL("INSERT INTO [dbo].[TbTelefono] ([TELEFONO] ,[IDRELACION] ,[TIPO]) VALUES " +
                        "('" + telefono + "'," + IDRelacion + ",'" + tipoEntidad + "')");
                    }
                }
            }
        }



        //}
        //public bool GuardarImagen(string tablasql, string campo, PictureBox PbImagen, int IDCondicion)
        //{
        //    try
        //    {
        //        //Objc.conectar();
        //        //SqlCommand cmd = new SqlCommand("insert into tabla (IMAGEN) values (@imagen)  ")
        //        //return true;
        //    }
        //    catch (Exception ex)
        //    {

        //        return false;
        //    }
        //}


        public bool EjecutarPROCEDUREEmpleado(Empleado ObjEmp)
        {
            try
            {
                Objc.conectar();
                SqlCommand cmd = new SqlCommand("GRABA_EMPLEADO", ConexionBD.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPOIDENTIFICACION", ObjEmp.Tipoidentificacion.ToUpper());
                cmd.Parameters.AddWithValue("@IDENTIFICACION", ObjEmp.Identificacion);
                cmd.Parameters.AddWithValue("@NOMBRES", ObjEmp.Nombres.ToUpper());
                cmd.Parameters.AddWithValue("@APELLIDOS", ObjEmp.Apellidos.ToUpper());
                cmd.Parameters.AddWithValue("@ACTIVO", ObjEmp.Activo);
                cmd.Parameters.AddWithValue("@DIRECCION", ObjEmp.Direccion.ToUpper());
                cmd.Parameters.AddWithValue("@IMAGEN", ObjEmp.Foto);
                cmd.Parameters.AddWithValue("@IDPARROQUIA", ObjEmp.IdParroquia);
                cmd.Parameters.AddWithValue("@EMAIL", ObjEmp.Email);
                cmd.Parameters.AddWithValue("@FECHANACIMIENTO", ObjEmp.FechaNacimiento.Date.ToShortDateString());
                cmd.Parameters.AddWithValue("@TIPOLICENCIA", ObjEmp.Tipolicencia.ToUpper());
                cmd.Parameters.AddWithValue("@TIPOSANGRE", ObjEmp.TipoSangre.ToUpper());
                cmd.Parameters.AddWithValue("@LIBRETAMILITAR", ObjEmp.Libretamilitar);
                cmd.Parameters.AddWithValue("@DISCAPACIDAD", ObjEmp.Discapacidad);
                cmd.Parameters.AddWithValue("@PORCENTAJEDISCAPACIDAD", ObjEmp.Porcentajediscapacidad);
                cmd.Parameters.AddWithValue("@MOVIMIENTOQUINCENAL", ObjEmp.MovimientoQuincenal);
                cmd.Parameters.AddWithValue("@GENERO", ObjEmp.Genero.ToUpper());
                cmd.Parameters.AddWithValue("@ESTADOCIVIL", ObjEmp.Estadocivil.ToUpper());
                cmd.Parameters.AddWithValue("@SUELDOMENSUAL", ObjEmp.Sueldomensual);
                cmd.Parameters.AddWithValue("@SUELDOEXTRA", ObjEmp.Sueldoextra);
                cmd.Parameters.AddWithValue("@CELULAR1", ObjEmp.Celular1);
                cmd.Parameters.AddWithValue("@CELULAR2", ObjEmp.Celular2);
                int result = cmd.ExecuteNonQuery();
                Objc.Cerrar();
                if (result > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EjecutarPROCEDUREProveedor(Proveedor ObjProvee)
        {
            try
            {
                Objc.conectar();
                SqlCommand cmd = new SqlCommand("GRABA_PROVEEDOR", ConexionBD.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                //SqlParameter Codigo = cmd.Parameters.Add
                //("@CODIGO", SqlDbType.Int);
                //Codigo.Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@NOMBRES", ObjProvee.Nombres);
                cmd.Parameters.AddWithValue("@TIPOIDENTIFICACION", ObjProvee.TipoIdentificacion);
                cmd.Parameters.AddWithValue("@IDENTIFICACION", ObjProvee.Identificacion);
                cmd.Parameters.AddWithValue("@NACIONALIDAD", ObjProvee.Nacionalidad);
                cmd.Parameters.AddWithValue("@NATURALEZA", ObjProvee.Naturaleza);
                cmd.Parameters.AddWithValue("@DIRECCION", ObjProvee.Direccion);
                cmd.Parameters.AddWithValue("@RAZONSOCIAL", ObjProvee.Razosocial);
                cmd.Parameters.AddWithValue("@TELEFONO", ObjProvee.Telefono);
                cmd.Parameters.AddWithValue("@CELULAR", ObjProvee.Celular);
                cmd.Parameters.AddWithValue("@RESPONSABLE", ObjProvee.Responsable);
                cmd.Parameters.AddWithValue("@TIPOSERVICIO", ObjProvee.Tiposervicio);
                cmd.Parameters.AddWithValue("@PLAZO", ObjProvee.Plazo);
                cmd.Parameters.AddWithValue("@EMAIL", ObjProvee.Email);
                cmd.Parameters.AddWithValue("@GIRACHEQUEA", ObjProvee.Giracheque);
                cmd.Parameters.AddWithValue("@IDPARROQUIA", ObjProvee.Idparroquia);
                cmd.Parameters.AddWithValue("@TIPOGASTO", ObjProvee.Tipogasto);
                cmd.Parameters.AddWithValue("@FAX", ObjProvee.Fax);
                cmd.Parameters.AddWithValue("@ESTADO", ObjProvee.Estado);
                cmd.Parameters.AddWithValue("@PROVEEDORRISE", ObjProvee.Riseproveedor);
                cmd.Parameters.AddWithValue("@IDCuentaContable", ObjProvee.IDCuentaContable1);
                cmd.Parameters.AddWithValue("@CREDITO", ObjProvee.Credito);
                cmd.Parameters.AddWithValue("@ICE", ObjProvee.Ice);
                cmd.Parameters.AddWithValue("@CODIGO_101", ObjProvee.Codigo_101);
                cmd.Parameters.AddWithValue("@CELULAR_RESPONSABLE", ObjProvee.CelularResponsable);
                int result = cmd.ExecuteNonQuery();
                Objc.Cerrar();
                if (result > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditarFoto(byte[] binData, string CondicionIDENTIFICACION, string NombreTabla, string CampoModificar, string CampoCondicion)
        {
            try
            {
                //Se inicializa un arreglo de Bytes del tamaño de la imagen
                //byte[] binData = Funcion.ConvertImg_Bytes(namefoto);

                Objc.conectar();
                string sql = @"UPDATE " + NombreTabla + " SET " + CampoModificar + " =  @IMAGEN WHERE " + CampoCondicion + " = @IDENTIFICACION";

                SqlCommand command = new SqlCommand(sql, ConexionBD.connection);

                command.Parameters.AddWithValue("@IDENTIFICACION", CondicionIDENTIFICACION);
                command.Parameters.AddWithValue("@IMAGEN", binData);
                command.ExecuteNonQuery();
                //MessageBox.Show("Fotografia Actualizada Satisfactoriamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Objc.Cerrar();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public bool EjecutarPROCEDUREEmpresa(Empresa ObjEmpresa)
        {
            try
            {
                Objc.conectar();
                SqlCommand cmd = new SqlCommand("GRABA_EMPRESA", ConexionBD.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NOMBRE", ObjEmpresa.NombreEmpresa.ToUpper());
                cmd.Parameters.AddWithValue("@RUC", ObjEmpresa.RucEmpresa);
                cmd.Parameters.AddWithValue("@NOMBRECOMERCIAL", ObjEmpresa.NombreComercial.ToUpper());
                cmd.Parameters.AddWithValue("@RAZONSOCIAL", ObjEmpresa.RazonSocial.ToUpper());
                cmd.Parameters.AddWithValue("@GERENTE", ObjEmpresa.Gerente.ToUpper());
                cmd.Parameters.AddWithValue("@DIRECCION", ObjEmpresa.Direccion.ToUpper());
                cmd.Parameters.AddWithValue("@EMAIL", ObjEmpresa.EmailEmpresa);
                cmd.Parameters.AddWithValue("@FECHAINICIOCONTABLE", ObjEmpresa.FechaInicioContable.Date.ToShortDateString());
                cmd.Parameters.AddWithValue("@CELULAR1", ObjEmpresa.Celular1Empresa);
                cmd.Parameters.AddWithValue("@CELULAR2", ObjEmpresa.Celular2Empresa);
                cmd.Parameters.AddWithValue("@RUCCONTADOR", ObjEmpresa.RucContador);
                cmd.Parameters.AddWithValue("@NOMBRECONTADOR", ObjEmpresa.NombreContador.ToUpper());
                cmd.Parameters.AddWithValue("@EMAILCONTADOR", ObjEmpresa.EmailContador);
                cmd.Parameters.AddWithValue("@CELULAR1CONTADOR", ObjEmpresa.Celular1Contador);
                cmd.Parameters.AddWithValue("@CELULAR2CONTADOR", ObjEmpresa.Celular2Contador);
                if (ObjEmpresa.LogoEmpresa != null)
                { cmd.Parameters.AddWithValue("@LOGO", ObjEmpresa.LogoEmpresa); }
                else
                {
                    cmd.Parameters.AddWithValue("@LOGO", System.Data.SqlTypes.SqlBytes.Null);
                }
                if (ObjEmpresa.FondoPantallaEmpresa != null)
                { cmd.Parameters.AddWithValue("@FONDOPANTALLA", ObjEmpresa.FondoPantallaEmpresa); }
                else
                {
                    cmd.Parameters.AddWithValue("@FONDOPANTALLA", System.Data.SqlTypes.SqlByte.Null);
                }


                int result = cmd.ExecuteNonQuery();
                Objc.Cerrar();
                if (result > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EjecutarPROCEDUREProducto(Producto ObjProducto)
        {
            try
            {
                Objc.conectar();
                SqlCommand cmd = new SqlCommand("GRABA_PRODUCTO", ConexionBD.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NOMBREPRODUCTO", ObjProducto.Nombreproducto);
                cmd.Parameters.AddWithValue("@ACTIVO", ObjProducto.Activo);
                cmd.Parameters.AddWithValue("@CODIGOBARRA", ObjProducto.Codigobarra);
                cmd.Parameters.AddWithValue("@TIPOPRODUCTO", ObjProducto.Tipoproducto);
                cmd.Parameters.AddWithValue("@UNIDAMEDIDA", ObjProducto.Unidamedida);
                cmd.Parameters.AddWithValue("@PESO", ObjProducto.Peso);
                cmd.Parameters.AddWithValue("@STOCKMAXIMO", ObjProducto.Stockmaximo);
                cmd.Parameters.AddWithValue("@STOCKMINIMO", ObjProducto.Stockminimo);
                cmd.Parameters.AddWithValue("@CAJA", ObjProducto.Caja);
                cmd.Parameters.AddWithValue("@UNIDAD", ObjProducto.Unidad);
                cmd.Parameters.AddWithValue("@PRECIOPUBLICO_IVA", Funcion.reemplazarcaracter(ObjProducto.Preciopublico_iva.ToString()));
                cmd.Parameters.AddWithValue("@PRECIOPUBLICO_SIN_IVA", Funcion.reemplazarcaracter(ObjProducto.Preciopublico_sin_iva.ToString()));
                cmd.Parameters.AddWithValue("@PRECIOALMAYOR_IVA", Funcion.reemplazarcaracter(ObjProducto.Precioalmayor_iva.ToString()));
                cmd.Parameters.AddWithValue("@PRECIOALMAYOR_SIN_IVA", Funcion.reemplazarcaracter(ObjProducto.Precioalmayor_sin_iva.ToString()));
                cmd.Parameters.AddWithValue("@PRECIOPORCAJA_IVA", Funcion.reemplazarcaracter(ObjProducto.Precioporcaja_iva.ToString()));
                cmd.Parameters.AddWithValue("@PRECIOPORCAJA_SIN_IVA", Funcion.reemplazarcaracter(ObjProducto.Precioporcaja_sin_iva.ToString()));
                cmd.Parameters.AddWithValue("@IVAESTADO", ObjProducto.Ivaestado);
                cmd.Parameters.AddWithValue("@OBSERVACIONES", ObjProducto.Observaciones);
                cmd.Parameters.AddWithValue("@IDCATEGORIA", ObjProducto.Idcategoria);
                cmd.Parameters.AddWithValue("@CANTIDAD", ObjProducto.Cantidad);
                cmd.Parameters.AddWithValue("@DISPLAY", ObjProducto.Display);
                cmd.Parameters.AddWithValue("@ICE", ObjProducto.Ice);
                cmd.Parameters.AddWithValue("@IRBP", ObjProducto.Irbp);

                if (ObjProducto.Imagenproducto != null)
                { cmd.Parameters.AddWithValue("@IMAGENPRODUCTO", ObjProducto.Imagenproducto); }
                else
                {
                    cmd.Parameters.AddWithValue("@IMAGENPRODUCTO", System.Data.SqlTypes.SqlBytes.Null);
                }
                int result = cmd.ExecuteNonQuery();
                Objc.Cerrar();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EjecutarPROCEDUREAsignarProductoBodega(int parametro1, int parametro2)
        {
            try
            {
                Objc.conectar();
                SqlCommand cmd = new SqlCommand("ASIGNAR_PRODUCTO_BODEGA", ConexionBD.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDPRODUCTO", parametro1);
                cmd.Parameters.AddWithValue("@IDBODEGA", parametro2);
                cmd.Parameters.AddWithValue("@ESTADO", 1);
                int result = cmd.ExecuteNonQuery();
                Objc.Cerrar();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EjecutarPROCEDUREEncabezadoCompra(EmcabezadoCompra ObjCompra)
        {
            try
            {
                Objc.conectar();
                SqlCommand cmd = new SqlCommand("REGISTRAR_ENCABEZADO_COMPRA", ConexionBD.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NUMERO_ORDEN_COMPRA", ObjCompra.OrdenCompra);
                cmd.Parameters.AddWithValue("@IDSUCURSAL", ObjCompra.Sucursal);
                cmd.Parameters.AddWithValue("@FLETE", ObjCompra.Flete);
                cmd.Parameters.AddWithValue("@FECHAORDENCOMPRA", ObjCompra.FechaOrdenCompra);
                cmd.Parameters.AddWithValue("@IDPROVEEDOR", ObjCompra.Proveedor);
                cmd.Parameters.AddWithValue("@TERMINOPAGO", ObjCompra.TerminoPago.ToUpper());
                cmd.Parameters.AddWithValue("@PLAZOORDENCOMPRA", ObjCompra.Plazo.ToUpper());
                cmd.Parameters.AddWithValue("@IMPUESTO", ObjCompra.Impuesto);
                cmd.Parameters.AddWithValue("@OBSERVACION", ObjCompra.Observacion.ToUpper());
                cmd.Parameters.AddWithValue("@IVA", Funcion.reemplazarcaracter(ObjCompra.Iva.ToString()));
                cmd.Parameters.AddWithValue("@ICE", Funcion.reemplazarcaracter(ObjCompra.Ice.ToString()));
                cmd.Parameters.AddWithValue("@IRBP", Funcion.reemplazarcaracter(ObjCompra.Irbp.ToString()));
                cmd.Parameters.AddWithValue("@SUBTOTALIVA", Funcion.reemplazarcaracter(ObjCompra.SubtotalIva.ToString()));
                cmd.Parameters.AddWithValue("@SUBTOTAL0", Funcion.reemplazarcaracter(ObjCompra.Subtotal0.ToString()));
                cmd.Parameters.AddWithValue("@SUBTOTAL", Funcion.reemplazarcaracter(ObjCompra.Subtotal.ToString()));
                cmd.Parameters.AddWithValue("@TOTAL", Funcion.reemplazarcaracter(ObjCompra.Total.ToString()));
                cmd.Parameters.AddWithValue("@SERIE1", ObjCompra.Serie1);
                cmd.Parameters.AddWithValue("@SERIE2", ObjCompra.Serie2);
                cmd.Parameters.AddWithValue("@NUMERO", ObjCompra.Numero);
                int result = cmd.ExecuteNonQuery();
                Objc.Cerrar();
                if (result > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EjecutarPROCEDUREMODIFICAR_PARAMETROSFACTURA(ParametrosFactura ObjParametrosFact)
        {
            try
            {
                Objc.conectar();
                SqlCommand cmd = new SqlCommand("MODIFICAR_PARAMETROSFACTURA", ConexionBD.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MONTO_MINIMO_FACTURA", ObjParametrosFact.MontoMinimoFactura1);
                cmd.Parameters.AddWithValue("@IVA", ObjParametrosFact.Iva);
                cmd.Parameters.AddWithValue("@CONTRIBUYENTEESPECIAL", ObjParametrosFact.ContribuyenteEspecial);
                cmd.Parameters.AddWithValue("@OBLIGADOLLEVARCONTABILIDAD", ObjParametrosFact.ObligadoContabilida);
                cmd.Parameters.AddWithValue("@IDEMPRESA", ObjParametrosFact.Idempresa);
                cmd.Parameters.AddWithValue("@PREIMPRESA", ObjParametrosFact.Preimpresa);
                cmd.Parameters.AddWithValue("@AUTORIZADOIMPRIMIR", ObjParametrosFact.AutorizadoParaImprimir);

                // TbPreimpresa
                if (ObjParametrosFact.Preimpresa)
                {
                    cmd.Parameters.AddWithValue("@ANCHO", ObjParametrosFact.Ancho);
                    cmd.Parameters.AddWithValue("@LARGO", ObjParametrosFact.Largo);
                    cmd.Parameters.AddWithValue("@TAMANOENCABEZADOFACTURA", ObjParametrosFact.TamanoEncabezadoFact1);
                    cmd.Parameters.AddWithValue("@TAMANOPIEFACTURA", ObjParametrosFact.TamanoPieFact1);
                    cmd.Parameters.AddWithValue("@NUMEROITEMS", ObjParametrosFact.NumeroItems);
                    //TbAutorizadosImprimir
                    cmd.Parameters.AddWithValue("@PIE1", "");
                    cmd.Parameters.AddWithValue("@PIE2", "");
                    cmd.Parameters.AddWithValue("@PIE3", "");
                    cmd.Parameters.AddWithValue("@PIE4", "");
                }

                if (ObjParametrosFact.AutorizadoParaImprimir)
                {
                    // TbPreimpresa
                    cmd.Parameters.AddWithValue("@ANCHO", 0);
                    cmd.Parameters.AddWithValue("@LARGO", 0);
                    cmd.Parameters.AddWithValue("@TAMANOENCABEZADOFACTURA", 0);
                    cmd.Parameters.AddWithValue("@TAMANOPIEFACTURA", 0);
                    cmd.Parameters.AddWithValue("@NUMEROITEMS", 0);

                    //TbAutorizadosImprimir
                    cmd.Parameters.AddWithValue("@PIE1", ObjParametrosFact.Pie1);
                    cmd.Parameters.AddWithValue("@PIE2", ObjParametrosFact.Pie2);
                    cmd.Parameters.AddWithValue("@PIE3", ObjParametrosFact.Pie3);
                    cmd.Parameters.AddWithValue("@PIE4", ObjParametrosFact.Pie4);
                } 
                int result = cmd.ExecuteNonQuery();
                Objc.Cerrar();
                if (result > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void ObtenerIDCompra(ref int cb, String SQL)
        {
            Objc.conectar();
            SqlCommand Sentencia;
            Sentencia = new SqlCommand(SQL, ConexionBD.connection);
            cb = Convert.ToInt32(Sentencia.ExecuteScalar());
            Objc.Cerrar();
        }
        public bool EjecutarPROCEDUREDetalleCompra(DetalleCompra ObjCompra)
        {
            try
            {
                Objc.conectar();
                SqlCommand cmd = new SqlCommand("REGISTRAR_DETALLE_COMPRA", ConexionBD.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@IDENCABEZADOCOMPRA", ObjCompra.IdEncabezadoCompra);
                cmd.Parameters.AddWithValue("@CODIGOBARRA", ObjCompra.Codigo.ToUpper());
                cmd.Parameters.AddWithValue("@CANTIDAD", ObjCompra.Cantidad);
                cmd.Parameters.AddWithValue("@PRECIOCOMPRA", Funcion.reemplazarcaracter(ObjCompra.PrecioCompra.ToString()));
                cmd.Parameters.AddWithValue("@DESCUENTO", Funcion.reemplazarcaracter(ObjCompra.Descuento.ToString()));
                cmd.Parameters.AddWithValue("@PRECIOVENTAPUBLICO", Funcion.reemplazarcaracter(ObjCompra.PrecioVentaPublico.ToString()));
                cmd.Parameters.AddWithValue("@PRECIOMAYORISTA", Funcion.reemplazarcaracter(ObjCompra.PrecioMayorista.ToString()));
                cmd.Parameters.AddWithValue("@PRECIOCAJAS", Funcion.reemplazarcaracter(ObjCompra.PrecioCajas.ToString()));
                cmd.Parameters.AddWithValue("@ICE", Funcion.reemplazarcaracter(ObjCompra.Ice.ToString()));
                cmd.Parameters.AddWithValue("@IRBP", Funcion.reemplazarcaracter(ObjCompra.Irbp.ToString()));
                cmd.Parameters.AddWithValue("@SERIE1", ObjCompra.Serie1);
                cmd.Parameters.AddWithValue("@SERIE2", ObjCompra.Serie2);
                cmd.Parameters.AddWithValue("@NUMERO", ObjCompra.Numero);
                cmd.Parameters.AddWithValue("@PROVEEDOR", ObjCompra.Proveedor);
                int result = cmd.ExecuteNonQuery();
                Objc.Cerrar();
                if (result > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void LLenarCombosUbicacion(int IdParroquia, ref ComboBox Pais, ref ComboBox Provincia, ref ComboBox Canton, ref ComboBox Parroquia)
        {
            DataTable dt = BoolDataTable("Select Pa.IDPAIS,Pro.IDPROVINCIA,C.IDCANTON,P.IDPARROQUIA from TbParroquia P, TbCanton C, TbProvincia Pro, TbPais Pa where Pa.IDPAIS = Pro.IDPAIS and Pro.IDPROVINCIA = C.IDPROVINCIA and C.IDCANTON=P.IDCanton and P.IDPARROQUIA = " + IdParroquia + "");
            if (dt.Rows.Count > 0)
            {
                DataRow myRow = dt.Rows[0];

                Pais.SelectedValue = Convert.ToInt32(myRow["IDPAIS"]);
                int indexPais = Pais.SelectedIndex;
                Pais.SelectedIndex = indexPais;


                Provincia.SelectedValue = Convert.ToInt32(myRow["IDPROVINCIA"]);
                int indexProvincia = Provincia.SelectedIndex;
                Provincia.SelectedIndex = indexProvincia;


                Canton.SelectedValue = Convert.ToInt32(myRow["IDCANTON"]);
                int indexCanton = Canton.SelectedIndex;
                Canton.SelectedIndex = indexCanton;


                Parroquia.SelectedValue = Convert.ToInt32(myRow["IDPARROQUIA"]);
                int indexParroquia = Parroquia.SelectedIndex;
                Parroquia.SelectedIndex = indexParroquia;
            }
        }

        public void CargarProductoCombo(String sql, DataGridView dg)
        {
            try
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("CODIGO", typeof(String));
                dt.Columns.Add("NOMBRE PRODUCTO", typeof(String));
                dt.Columns.Add("CATEGORIA.", typeof(String));
                dt.Columns.Add("BODEGA", typeof(String));
                dt.Columns.Add("CANTIDAD", typeof(String));
                dt.Columns.Add("P. PUBLICO", typeof(String));
                dt.Columns.Add(" ", typeof(bool));
                dt.Columns.Add("ID", typeof(String));
                // dt.Columns.Add("IVA", typeof(bool));
                //List<Producto> lista = new List<Producto>();
                Objc.conectar();
                SqlCommand comando = new SqlCommand(sql);
                comando.Connection = ConexionBD.connection;
                SqlDataReader dato = comando.ExecuteReader();
                Objc.Cerrar();
                while (dato.Read() == true)
                {
                    if (dato["DESCRIPCION"].ToString() != "COMBO")
                    {
                        dt.Rows.Add(dato["CODIGOBARRA"].ToString(), dato["NOMBREPRODUCTO"].ToString(), dato["DESCRIPCION"].ToString(), dato["NOMBRE"].ToString(), dato["CANTIDAD"].ToString(), dato["PRECIOPUBLICO_SIN_IVA"], false, dato["IDPRODUCTO"]);
                    }


                }
                dg.DataSource = dt;
                dg.Columns[0].Width = 150;
                dg.Columns[1].Width = 150;
                dg.Columns[2].Width = 100;
                dg.Columns[3].Width = 100;
                dg.Columns[4].Width = 80;
                dg.Columns[5].Width = 80;
                dg.Columns[6].Width = 30;
                //return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar cliente: " + ex);
                // return null;
            }
        }

        public void CargarCombos(String sql, DataGridView dg)
        {
            try
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("CODIGO", typeof(String));
                dt.Columns.Add("NOMBRE COMBO", typeof(String));
                dt.Columns.Add("CANTIDAD", typeof(String));
                dt.Columns.Add("PRECIO", typeof(String));
                dt.Columns.Add("ID", typeof(String));
                // dt.Columns.Add("IVA", typeof(bool));
                //List<Producto> lista = new List<Producto>();
                Objc.conectar();
                SqlCommand comando = new SqlCommand(sql);
                comando.Connection = ConexionBD.connection;
                SqlDataReader dato = comando.ExecuteReader();
                Objc.Cerrar();
                while (dato.Read() == true)
                {

                    dt.Rows.Add(dato["CODIGO"].ToString(), dato["NOMBRE"].ToString(), dato["CANTIDAD"].ToString(), dato["PRECIO"], dato["IDCOMBO"]);



                }
                dg.DataSource = dt;

                //return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar cliente: " + ex);
                // return null;
            }
        }

        public void CargarProductosdelcombo(String id, DataGridView dg)
        {
            try
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("CODIGO", typeof(String));
                dt.Columns.Add("NOMBRE", typeof(String));
                dt.Columns.Add("CANTIDAD", typeof(String));
                //dt.Columns.Add("PRECIO", typeof(String));
                //dt.Columns.Add("ID", typeof(String));
                // dt.Columns.Add("IVA", typeof(bool));
                //List<Producto> lista = new List<Producto>();
                Objc.conectar();
                SqlCommand comando = new SqlCommand("SELECT TbProducto.CODIGOBARRA, TbProducto.NOMBREPRODUCTO, TbRelacionComboProducto.Cant from TbRelacionComboProducto INNER JOIN TbProducto ON(TbRelacionComboProducto.IDCOMBO='" + id + "' and TbProducto.IDPRODUCTO=TbRelacionComboProducto.IDPRODUCTO)");
                comando.Connection = ConexionBD.connection;
                SqlDataReader dato = comando.ExecuteReader();
                Objc.Cerrar();
                while (dato.Read() == true)
                {

                    dt.Rows.Add(dato["CODIGOBARRA"].ToString(), dato["NOMBREPRODUCTO"].ToString(), dato["Cant"].ToString());



                }
                dg.DataSource = dt;

                //return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar cliente: " + ex);
                // return null;
            }
        }


        public bool GrabarCombo(List<String> encabezadoCombo, DataGridView dg, int bandera)
        {
            try
            {
                Objc.conectar();
                string precio = "";
                int result = 0;
                List<string> enca = encabezadoCombo;
                //List<string> detalle = detallepago;
                SqlCommand cmd = null;
                string idempresa = Program.IDEMPRESA;
                for (int i = 0; i < dg.RowCount; i++)
                {
                    if (dg.Rows[i].Cells[0].Value != null)
                    {
                        precio = Funcion.reemplazarcaracter(dg.Rows[i].Cells[4].Value.ToString());
                        cmd = new SqlCommand("REGISTRAR_Combo", ConexionBD.connection);
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@bandera", bandera);
                        cmd.Parameters.AddWithValue("@CONTADOR", i);
                        cmd.Parameters.AddWithValue("@codigo", encabezadoCombo[0]);
                        cmd.Parameters.AddWithValue("@nombre", encabezadoCombo[1]);
                        cmd.Parameters.AddWithValue("@cantcombo", encabezadoCombo[2]);
                        cmd.Parameters.AddWithValue("@precio", encabezadoCombo[3]);
                        int cantidad = Convert.ToInt32(Convert.ToInt32(dg.Rows[i].Cells[3].Value) * Convert.ToInt32(encabezadoCombo[2]));
                        cmd.Parameters.AddWithValue("@cantidadproducto", cantidad);
                        cmd.Parameters.AddWithValue("@idproducto", dg.Rows[i].Cells[7].Value);

                        result = cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        break;
                    }


                }

                Objc.Cerrar();
                if (result > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool verificarRepetido(String SQL)
        {
            try
            {
                Objc.conectar();

                SqlCommand Sentencia = new SqlCommand(SQL);
                Sentencia.Connection = ConexionBD.connection;
                //int valor = Convert.ToInt32(Sentencia.ExecuteScalar());
                SqlDataReader dato = Sentencia.ExecuteReader();
                Objc.Cerrar();
                if (dato.Read() == true)
                {

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                //  MessageBox.Show("Error al conectar la base de Datos " + ex.Message, "Comprobar usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
        }
        public int ObtenerCantidadRegistros(String sql)
        {
            try
            {
                SqlDataAdapter objDA;
                int valor = 0;
                DataTable dt = new DataTable();
                Objc.conectar();
                string sentencia = sql;
                objDA = new SqlDataAdapter(sentencia, ConexionBD.connection);
                objDA.Fill(dt);
                Objc.Cerrar();
                objDA.Dispose();
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    valor = Convert.ToInt32(row["Numeros"]);
                }
                return valor;
            }
            catch (Exception ex)
            {
                return -1;

            }
        }
        public SqlDataReader obtenerDatos(string SQL)
        {
            //Producto producto = new Producto();
            SqlDataReader dato = null;
            try
            {
                Objc.conectar();
                SqlCommand Sentencia = new SqlCommand(SQL);
                Sentencia.Connection = ConexionBD.connection;
                dato = Sentencia.ExecuteReader();
                if (dato.Read() == true)
                {
                    return dato;
                }
                else
                {
                    dato = null;
                    MessageBox.Show("No se encontró ningun producto con ese codigo.");
                }

            }
            catch (Exception ex)
            {

            }
            Objc.Cerrar();
            return dato;
        }

        public bool EjecutarPROCEDUREEncabezadoOrdenGiro(EncabezadoOrdenGiro ObjEncabezadoOrdenGiro)
        {
            try
            {
                Objc.conectar();
                SqlCommand cmd = new SqlCommand("REGISTRAR_ENCABEZADO_OG", ConexionBD.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@IDENCABEZADOCOMPRA", ObjCompra.IdEncabezadoCompra);
                cmd.Parameters.AddWithValue("@NUMEROORDENGIRO", ObjEncabezadoOrdenGiro.NumeroOrdenGiro);
                cmd.Parameters.AddWithValue("@TIPODOCUMENTO", ObjEncabezadoOrdenGiro.TipoDocumento);
                cmd.Parameters.AddWithValue("@PROVEEDOR", ObjEncabezadoOrdenGiro.Proveedor);
                cmd.Parameters.AddWithValue("@TIPO", ObjEncabezadoOrdenGiro.Tipo);
                cmd.Parameters.AddWithValue("@PLAZO", ObjEncabezadoOrdenGiro.Plazo);
                cmd.Parameters.AddWithValue("@CONCEPTO", ObjEncabezadoOrdenGiro.Concepto);
                cmd.Parameters.AddWithValue("@AUTORIZACIONPROVEEDOR", ObjEncabezadoOrdenGiro.AtorizacionProveedor);
                cmd.Parameters.AddWithValue("@NUMERODOCUMENTOPROVEEDOR", ObjEncabezadoOrdenGiro.NumeroProveedor);
                cmd.Parameters.AddWithValue("@SERIE1PROVEEDOR", ObjEncabezadoOrdenGiro.Serie1Proveedor);
                cmd.Parameters.AddWithValue("@SERIE2PROVEEDOR", ObjEncabezadoOrdenGiro.Serie2Proveedor);
                cmd.Parameters.AddWithValue("@RISE", ObjEncabezadoOrdenGiro.Rise);
                cmd.Parameters.AddWithValue("@DECLARASRI", ObjEncabezadoOrdenGiro.DeclaraSRI);
                cmd.Parameters.AddWithValue("@RETENCIONMANUAL", ObjEncabezadoOrdenGiro.RetencionManual);
                cmd.Parameters.AddWithValue("@FECHADOCUMENTO", ObjEncabezadoOrdenGiro.FechaDocumento);
                cmd.Parameters.AddWithValue("@FECHACONTABILIZACION", ObjEncabezadoOrdenGiro.FechaContabilizacion);
                cmd.Parameters.AddWithValue("@FECHAORDENGIRO", ObjEncabezadoOrdenGiro.FechaOrdenGiro);
                cmd.Parameters.AddWithValue("@FECHAVIGENTE", ObjEncabezadoOrdenGiro.FechaVigente1);
                cmd.Parameters.AddWithValue("@ENCABEZADOCOMPRA", ObjEncabezadoOrdenGiro.EncabezadoCompra);
                cmd.Parameters.AddWithValue("@VALORPAGAR", ObjEncabezadoOrdenGiro.ValorPagar);
                cmd.Parameters.AddWithValue("@SALDO", ObjEncabezadoOrdenGiro.Saldo);
                cmd.Parameters.AddWithValue("@FECHARETENCION", ObjEncabezadoOrdenGiro.FechaRetencion);
                cmd.Parameters.AddWithValue("@FECHAVENCEDOCUMENTO", ObjEncabezadoOrdenGiro.FechaVenceDocumento);
                cmd.Parameters.AddWithValue("@SERIE1RETENCION", ObjEncabezadoOrdenGiro.Serie1Retencion);
                cmd.Parameters.AddWithValue("@SERIE2RETENCION", ObjEncabezadoOrdenGiro.Serie2Retencion);
                cmd.Parameters.AddWithValue("@NUMERORETENCION", ObjEncabezadoOrdenGiro.NumeroRetencion);
                cmd.Parameters.AddWithValue("@AUTORIZACIONRETENCION", ObjEncabezadoOrdenGiro.Autorizacionretencion);
                cmd.Parameters.AddWithValue("@TOTALDEBE", ObjEncabezadoOrdenGiro.TotalDebe);
                cmd.Parameters.AddWithValue("@TOTALHABER", ObjEncabezadoOrdenGiro.TotalHaber);
                cmd.Parameters.AddWithValue("@TIPOAUTORIZACION", ObjEncabezadoOrdenGiro.TotalHaber);
                int result = cmd.ExecuteNonQuery();
                Objc.Cerrar();
                if (result > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EjecutarPROCEDUREDetalleOrdenGiro(DetalleOrdenGiro objDetalleOrdenGiro)
        {
            try
            {
                Objc.conectar();
                SqlCommand cmd = new SqlCommand("REGISTRAR_DETALLE_OG", ConexionBD.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@IDENCABEZADOCOMPRA", ObjCompra.IdEncabezadoCompra);
                cmd.Parameters.AddWithValue("@IDENCABEZADOORDENGIRO", objDetalleOrdenGiro.IdEncabezadoOrdenGiro);
                cmd.Parameters.AddWithValue("@IDRETENCION", objDetalleOrdenGiro.IdRetencion);
                int result = cmd.ExecuteNonQuery();
                Objc.Cerrar();
                if (result > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void BoolLlenarTreeViewMenu(TreeView menu, String SQL)
        {
            SqlDataAdapter ObjSQLDA = new SqlDataAdapter(SQL, ConexionBD.connection);
            DataTable table = new DataTable();
            ObjSQLDA.Fill(table);
            int contadorPadre = -1, contadorPadreHijo = -1;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow myRow = table.Rows[i];
                if (myRow["NODOPADRE"].ToString() == "")
                {
                    menu.Nodes.Add(myRow["DESCRIPCION"].ToString());
                    contadorPadre++;
                }
                else if (myRow["NODOPADRE"].ToString() == "5")
                {
                    menu.Nodes[contadorPadre].Nodes[contadorPadreHijo].Nodes.Add(myRow["DESCRIPCION"].ToString());
                }
                else
                {
                    menu.Nodes[contadorPadre].Nodes.Add(myRow["DESCRIPCION"].ToString());
                    contadorPadreHijo++;
                }
            }
        }
        //Bitacora bitacora = new Bitacora();
        public void seriesDocumentoRetencion(TextBox txtNumeroRetencion, TextBox txtSerie1Retencion, TextBox txtSerie2Retencion, TextBox txtAutorizacionRetencion, string tipoDocumento, string ip)
        {
            string numcaja = "", sucursal = "", documentoActual = "", autorizacion = "";
            DataTable Dt = BoolDataTable("Select TIPODOCUMENTO, SERIE1,SERIE2,DOCUMENTOACTUAL,DOCUMENTOINICIAL,DOCUMENTOFINAL,AUTORIZACION,ESTACION,IPESTACION from TbCajasTalonario where IPESTACION = '" + ip + "' and ESTADO=1;");
            if (Dt.Rows.Count > 0)
            {
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    DataRow myRows = Dt.Rows[i];
                    if (myRows["TIPODOCUMENTO"].ToString() == tipoDocumento)
                    {
                        sucursal = myRows["SERIE1"].ToString();
                        numcaja = myRows["SERIE2"].ToString();
                        documentoActual = myRows["DOCUMENTOACTUAL"].ToString();
                        autorizacion = myRows["AUTORIZACION"].ToString();
                    }
                }
            }
            txtNumeroRetencion.Text = documentoActual;
            txtSerie1Retencion.Text = sucursal;
            txtSerie2Retencion.Text = numcaja;
            txtAutorizacionRetencion.Text = autorizacion;
        }
    }
}