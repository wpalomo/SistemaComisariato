using Comisariato.Clases;
using Comisariato.Formularios.Informes;
using Comisariato.Formularios.Mantenimiento;
using Comisariato.Formularios.Mantenimiento.Empresa;
using Comisariato.Formularios.Mantenimiento.Inventario;
using Comisariato.Formularios.SRI;
using Comisariato.Formularios.Transacciones;
using Comisariato.Formularios.Transacciones.Devolucion_Venta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comisariato.Formularios
{
    public partial class FrmPrincipal : Form
    {


        public static FrmClientes FrmCliente;
        public static FrmProveedores FrmProveedor;
        public static FrmUsuarios FrmUsuario;
        public static FrmEmpresa FrmEmpresa;
        public static FrmProductos FrmProducto;
        public static FrmCategoriaProductos FrmCategoriaProducto;
        public static FrmCreacionBodega FrmCreacionBodega;
        public static FrmComboProductos FrmComboProducto;
        public static FrmClaveUsuario FrmClaveUsuario;
        public static FrmCompra FrmCompra;
        public static FrmCajasTalonario FrmCajasTalonario;
        public static FrmParametrosFactura FrmParametrosFactura;
        public static FrmSucursal FrmSucursal;
        public static FrmAsignacionProductoBodega FrmAsignacionProductoBodega;
        public static FrmEmpleado FrmEmpleado;
        public static FrmOrdenDeGiro FrmOrdenDeGiro;
        public static FrmDevolucionVenta FrmDevolucionVenta;
        public static FrmAsignarMenu FrmAsignarMenu;
        public static FrmInformeVentas FrmInformeVentas;
        public static FrmInformesCompras FrmInformesCompras;
        public static FrmInformesRentenciones FrmInformesRentenciones;
        public static MenuStrip menuMostrar;
        public static FrmKardex FrmKardex;
        public static FrmDevolucionCompra FrmDevolucionCompra;
        public static FrmDeclaracionSRI FrmDeclaracionSRI;
        public static FrmCambioClave FrmCambioClave;

        Bitacora  bitacora = new Bitacora();
        //public static void Panel
        public FrmPrincipal()
        {
            InitializeComponent();
        }
        Funcion objFuncion = new Funcion();
        Consultas objConsulta = new Consultas();


        private void tvPrincipal_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Program.panelPrincipalVariable = this;

            string nombre = e.Node.Text;
            //-------------------------------------------------Mantenimiento---------------------------------------//
            //---------------------Cliente --------------------------------------//
            if (nombre == "Administrar Clientes")
            {
                if (FrmCliente == null || FrmCliente.IsDisposed)
                {
                    FrmCliente = new FrmClientes();
                    FrmCliente.Show();
                    FrmCliente.MdiParent = this;
                }
            }
            //---------------------Empleado --------------------------------------//
            if (nombre == "Administrar Empleados")
            {
                if (FrmEmpleado == null || FrmEmpleado.IsDisposed)
                {
                    FrmEmpleado = new FrmEmpleado();
                    FrmEmpleado.Show();
                    FrmEmpleado.MdiParent = this;
                }
            }
            if (nombre == "Administrar Menu")
            {
                if (FrmAsignarMenu == null || FrmAsignarMenu.IsDisposed)
                {
                    FrmAsignarMenu = new FrmAsignarMenu();
                    FrmAsignarMenu.Show();
                    FrmAsignarMenu.MdiParent = this;

                }
            }
            //--------------------Empresa---------------------------------------//
            else if (nombre == "Cajas/Talonarios")
            {
                if (FrmCajasTalonario == null || FrmCajasTalonario.IsDisposed)
                {
                    FrmCajasTalonario = new FrmCajasTalonario();
                    FrmCajasTalonario.Show();
                    FrmCajasTalonario.MdiParent = this;
                }
            }
            else if (nombre == "Informe Ventas")
            {
                if (FrmInformeVentas == null || FrmInformeVentas.IsDisposed)
                {
                    FrmInformeVentas = new FrmInformeVentas();
                    FrmInformeVentas.Show();
                    FrmInformeVentas.MdiParent = this;
                }
            }
            else if (nombre == "Informe Compras")
            {
                //        FrmInformesCompras;
                //public static FrmInformesOrdenGiro FrmInformesOrdenGiro;
                if (FrmInformesCompras == null || FrmInformesCompras.IsDisposed)
                {
                    FrmInformesCompras = new FrmInformesCompras();
                    FrmInformesCompras.Show();
                    FrmInformesCompras.MdiParent = this;
                }
            }
            else if (nombre == "Informe Retención")
            {
                //hillbsasvdb
                if (FrmInformesRentenciones == null || FrmInformesRentenciones.IsDisposed)
                {
                    FrmInformesRentenciones = new FrmInformesRentenciones();
                    FrmInformesRentenciones.Show();
                    FrmInformesRentenciones.MdiParent = this;
                }
            }
            else if (nombre == "Empresa")
            {
                if (FrmEmpresa == null || FrmEmpresa.IsDisposed)
                {
                    FrmEmpresa = new FrmEmpresa();
                    FrmEmpresa.Show();
                    FrmEmpresa.MdiParent = this;
                }
            }
            else if (nombre == "Impresion de Factura")
            {
                if (FrmParametrosFactura == null || FrmParametrosFactura.IsDisposed)
                {
                    FrmParametrosFactura = new FrmParametrosFactura();
                    FrmParametrosFactura.Show();
                    FrmParametrosFactura.MdiParent = this;
                }
            }
            else if (nombre == "Sucursales")
            {
                if (FrmSucursal == null || FrmSucursal.IsDisposed)
                {
                    FrmSucursal = new FrmSucursal();
                    FrmSucursal.Show();
                    FrmSucursal.MdiParent = this;
                    //FrmSucursal.BringToFront();
                }
                //else { FrmProducto.BringToFront(); }
            }
            //--------------------Proveedores---------------------------------------//
            else if (nombre == "Administrar Proveedores")
            {
                if (FrmProveedor == null || FrmProveedor.IsDisposed)
                {
                    FrmProveedor = new FrmProveedores();
                    FrmProveedor.Show();
                    FrmProveedor.MdiParent = this;
                    //FrmProveedor.BringToFront();
                }
                //else { FrmProducto.BringToFront(); }
            }
            //--------------------Usuarios---------------------------------------//
            else if (nombre == "Administrar Usuarios")
            {
                if (FrmUsuario == null || FrmUsuario.IsDisposed)
                {
                    FrmUsuario = new FrmUsuarios();
                    FrmUsuario.Show();
                    FrmUsuario.MdiParent = this;
                    //FrmUsuario.BringToFront();
                }
                //else { FrmProducto.BringToFront(); }
            }
            //--------------------Inventario---------------------------------------//
            else if (nombre == "Productos")
            {
                if (FrmProducto == null || FrmProducto.IsDisposed)
                {
                    FrmProducto = new FrmProductos();
                    ////FrmProducto.BringToFront();
                    FrmProducto.Show();
                    FrmProducto.MdiParent = this;
                }
                //else { FrmProducto.BringToFront(); }
            }
            else if (nombre == "Categoria Producto")
            {
                if (FrmCategoriaProducto == null || FrmCategoriaProducto.IsDisposed)
                {
                    FrmCategoriaProducto = new FrmCategoriaProductos();
                    //FrmCategoriaProducto.BringToFront();
                    FrmCategoriaProducto.Show();
                    FrmCategoriaProducto.MdiParent = this;
                }
                //else { FrmCategoriaProducto.BringToFront(); }

            }
            else if (nombre == "Creacion de Bodega")
            {
                if (FrmCreacionBodega == null || FrmCreacionBodega.IsDisposed)
                {
                    FrmCreacionBodega = new FrmCreacionBodega();
                    //FrmCreacionBodega.BringToFront();
                    FrmCreacionBodega.Show();
                    FrmCreacionBodega.MdiParent = this;
                }
                //else { FrmCreacionBodega.BringToFront(); }
            }
            else if (nombre == "Combo de Productos")
            {
                if (FrmComboProducto == null || FrmComboProducto.IsDisposed)
                {
                    FrmComboProducto = new FrmComboProductos();
                    //FrmComboProducto.BringToFront();
                    FrmComboProducto.Show();
                    FrmComboProducto.MdiParent = this;
                }
                //else { FrmCreacionBodega.BringToFront(); }
            }
            else if (nombre == "Asignacion de Producto por Bodega")
            {
                if (FrmAsignacionProductoBodega == null || FrmAsignacionProductoBodega.IsDisposed)
                {
                    FrmAsignacionProductoBodega = new FrmAsignacionProductoBodega();
                    //FrmAsignacionProductoBodega.BringToFront();
                    FrmAsignacionProductoBodega.Show();
                    FrmAsignacionProductoBodega.MdiParent = this;
                }
                //else { FrmAsignacionProductoBodega.BringToFront(); }
            }
            //-------------------------------------------------Transacciones---------------------------------------//
            else if (nombre == "Ventas")
            {
                if (!Program.FormularioVentaAbierto)
                {
                    if (FrmClaveUsuario == null || FrmClaveUsuario.IsDisposed)
                    {
                        FrmClaveUsuario = new FrmClaveUsuario();
                        FrmClaveUsuario.verificarMetodo = 1;
                        //FrmClaveUsuario.BringToFront();
                        FrmClaveUsuario.Show();
                        FrmClaveUsuario.MdiParent = this;
                    }
                    //else { FrmClaveUsuario.BringToFront(); }
                }
            }
            else if (nombre == "Compras")
            {
                if (objConsulta.ObtenerValorCampo("IDPROVEEDOR", "TbProveedor", "") != "" && objConsulta.ObtenerValorCampo("IDSUCURSAL", "TbSucursal", "") != "" && objConsulta.ObtenerValorCampo("IDPARAMETROSFACTURA", "TbParametrosFactura", "") != "")
                {
                    if (FrmCompra == null || FrmCompra.IsDisposed)
                    {
                        FrmCompra = new FrmCompra();
                        //FrmCompra.BringToFront();
                        FrmCompra.Show();
                        FrmCompra.MdiParent = this;
                    }
                    //else { FrmCompra.BringToFront(); }
                }
                else
                {
                    MessageBox.Show("Para realizar un registro de compra debe de tener registrado lo siguiente:\n*Al menos un proveedor.\n*Al menos una sucursal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (nombre == "Devolución en Compras")
            {
                string IpMaquina = bitacora.LocalIPAddress();
                DataTable Dt = objConsulta.BoolDataTable("Select TIPODOCUMENTO, SERIE1,SERIE2,DOCUMENTOACTUAL,DOCUMENTOINICIAL,DOCUMENTOFINAL,AUTORIZACION,ESTACION,IPESTACION from TbCajasTalonario where IPESTACION = '" + IpMaquina + "' and ESTADO=1;");
                bool banderaCaja = false;
                if (Dt.Rows.Count > 0)
                {
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        banderaCaja = true;
                        DataRow myRows = Dt.Rows[i];
                        if (myRows["TIPODOCUMENTO"].ToString() == "NCRE")
                        {
                            banderaCaja = false;
                            if (FrmDevolucionCompra == null || FrmDevolucionCompra.IsDisposed)
                            {
                                FrmDevolucionCompra = new FrmDevolucionCompra();
                                //FrmDevolucionVenta.BringToFront();
                                FrmDevolucionCompra.Show();
                                FrmDevolucionCompra.MdiParent = this;
                                break;
                            }
                        }
                    }
                    if (banderaCaja)
                    {
                        MessageBox.Show("Caja no registrada");
                    }
                }
                else
                {
                    MessageBox.Show("Caja no registrada");
                }
            }
            else if (nombre == "Orden de Giro")
            {
                string IpMaquina = bitacora.LocalIPAddress();
                DataTable Dt = objConsulta.BoolDataTable("Select TIPODOCUMENTO, SERIE1,SERIE2,DOCUMENTOACTUAL,DOCUMENTOINICIAL,DOCUMENTOFINAL,AUTORIZACION,ESTACION,IPESTACION from TbCajasTalonario where IPESTACION = '" + IpMaquina + "' and ESTADO=1;");
                bool banderaCaja = false;
                if (Dt.Rows.Count > 0)
                {
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        banderaCaja = true;
                        DataRow myRows = Dt.Rows[i];
                        if (myRows["TIPODOCUMENTO"].ToString() == "RET")
                        {
                            banderaCaja = false;
                            if (FrmOrdenDeGiro == null || FrmOrdenDeGiro.IsDisposed)
                            {
                                FrmOrdenDeGiro = new FrmOrdenDeGiro();
                                //FrmOrdenDeGiro.BringToFront();
                                FrmOrdenDeGiro.Show();
                                FrmOrdenDeGiro.MdiParent = this;
                                break;
                            }
                            //else { FrmOrdenDeGiro.BringToFront(); }
                        }
                    }
                    if (banderaCaja)
                    {
                        MessageBox.Show("Caja no registrada");
                    }
                }
                else
                {
                    MessageBox.Show("Caja no registrada");
                }

            }
            else if (nombre == "Devolución en Venta")
            {
                string IpMaquina = bitacora.LocalIPAddress();
                DataTable Dt = objConsulta.BoolDataTable("Select TIPODOCUMENTO, SERIE1,SERIE2,DOCUMENTOACTUAL,DOCUMENTOINICIAL,DOCUMENTOFINAL,AUTORIZACION,ESTACION,IPESTACION from TbCajasTalonario where IPESTACION = '" + IpMaquina + "' and ESTADO=1;");
                bool banderaCaja = false;
                if (Dt.Rows.Count > 0)
                {
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        banderaCaja = true;
                        DataRow myRows = Dt.Rows[i];
                        if (myRows["TIPODOCUMENTO"].ToString() == "NDEB")
                        {
                            banderaCaja = false;
                            if (FrmDevolucionVenta == null || FrmDevolucionVenta.IsDisposed)
                            {
                                FrmDevolucionVenta = new FrmDevolucionVenta();
                                //FrmOrdenDeGiro.BringToFront();
                                FrmDevolucionVenta.Show();
                                FrmDevolucionVenta.MdiParent = this;
                                break;
                            }
                            //else { FrmOrdenDeGiro.BringToFront(); }
                        }
                    }
                    if (banderaCaja)
                    {
                        MessageBox.Show("Caja no registrada");
                    }
                }
                else
                {
                    MessageBox.Show("Caja no registrada");
                }
            }
            else if (nombre == "Kardex")
            {
                if (FrmKardex == null || FrmKardex.IsDisposed)
                {
                    FrmKardex = new FrmKardex();
                    FrmKardex.Show();
                    FrmKardex.MdiParent = this;
                }
                //else { FrmDevolucionVenta.BringToFront(); }
            }
            else if (nombre == "Declaración SRI")
            {
                if (FrmDeclaracionSRI == null || FrmDeclaracionSRI.IsDisposed)
                {
                    FrmDeclaracionSRI = new FrmDeclaracionSRI();
                    //FrmDevolucionVenta.BringToFront();
                    FrmDeclaracionSRI.Show();
                    FrmDeclaracionSRI.MdiParent = this;
                }
                //else { FrmDevolucionVenta.BringToFront(); }
            }
        }



        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss");
        }

        private void tsmCerrarSesion_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult Resul = MessageBox.Show("Esta Seguro que Quiere Cerrar la Sesión", "Estado de Cesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resul == DialogResult.Yes)
                {
                    String HoraSalida = DateTime.Now.TimeOfDay.ToString();
                    Bitacora ObjBitacora = new Bitacora(HoraSalida, "Sesión Finalizada");
                    ObjBitacora.insertarBitacora();
                    Application.Restart();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            menuMostrar = msPrincipal1;
            DataTable dt = objConsulta.BoolDataTable("Select FONDOPANTALLA from TbEmpresa where IDEMPRESA = 1");
            byte[] MyData = new byte[0];
            if (dt.Rows.Count > 0)
            {
                DataRow myRow = dt.Rows[0];

                MyData = (byte[])myRow["FONDOPANTALLA"];
                MemoryStream stream = new MemoryStream(MyData);
                //this.panelPrincipal.BackgroundImage = Image.FromStream(stream);
                this.BackgroundImage = Image.FromStream(stream);
                this.BackgroundImageLayout = ImageLayout.Stretch;

            }
            try
            {
                if (Program.Usuario !="ADMIN")
                {
                    llenarTreeViewPrincipal();
                }
            }
            catch (Exception ex)
            {
            }
            Program.tamañoVentanaPrincipal = ClientSize.Height;

        }        

        public void llenarTreeViewPrincipal()
        {
            for (int i = 0; i < tvPrincipal.Nodes.Count;)
            {
                tvPrincipal.Nodes.Remove(tvPrincipal.Nodes[0]);
            }
            objConsulta.BoolLlenarTreeViewMenu(tvPrincipal, "SELECT DISTINCT M.IDMENU, M.DESCRIPCION, M.NODOPADRE from TbMenu M, TbAsignacionMenu AM where M.IDMENU = AM.IDMENU AND AM.IDUSUARIO = " + Program.IDUsuarioMenu + " ORDER BY M.IDMENU;");
        }

        private void msPrincipal_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        bool banderaMenuPrincipal = false;
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!banderaMenuPrincipal)
            {
                tvPrincipal.Visible = false;
                MenuIzq.Visible = false;
                banderaMenuPrincipal = true;
            }
            else
            {
                tvPrincipal.Visible = true;
                MenuIzq.Visible = true;
                banderaMenuPrincipal = false;
            }
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                ActiveMdiChild.Close();
            int a = ventanaToolStripMenuItem.DropDownItems.Count;
            if (a > 2)
            {
                ventanaToolStripMenuItem.DropDownItems.RemoveAt(a - 1);
            }
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmCambioClave == null || FrmCambioClave.IsDisposed)
            {
                FrmCambioClave = new FrmCambioClave();
                FrmCambioClave.Show();
                FrmCambioClave.MdiParent = this;
            }
        }
    }
}
