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
        public static MenuStrip menuMostrar;
        public static FrmKardex FrmKardex;
        public static FrmDevolucionCompra FrmDevolucionCompra;
        public static FrmDeclaracionSRI FrmDeclaracionSRI;


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
                //if (FrmCliente == null || FrmCliente.IsDisposed)
                //{
                //    FrmCliente = new FrmClientes();
                //    objFuncion.AddFormInPanel(FrmCliente, Program.panelPrincipalVariable);
                //}
                //else
                //{
                //    int index = panelPrincipal.Controls.GetChildIndex(FrmCliente);
                //    FrmCliente.BringToFront();
                //}

                if (FrmCliente == null || FrmCliente.IsDisposed)
                {
                    FrmCliente = new FrmClientes();
                    //FrmCliente.BringToFront();
                    FrmCliente.Show();
                    FrmCliente.MdiParent = this;
                    //FrmCliente.BringToFront();
                    Asignar(FrmCliente.Text);
                }
                //else { FrmProducto.BringToFront(); }
            }
            //---------------------Empleado --------------------------------------//
            if (nombre == "Administrar Empleados")
            {
                //if (FrmEmpleado == null || FrmEmpleado.IsDisposed)
                //{
                //    FrmEmpleado = new FrmEmpleado();
                //    objFuncion.AddFormInPanel(FrmEmpleado, Program.panelPrincipalVariable);
                //}
                //else
                //{
                //    //int index = panelPrincipal.Controls.GetChildIndex(FrmEmpleado);
                //    FrmEmpleado.BringToFront();
                //}
                if (FrmEmpleado == null || FrmEmpleado.IsDisposed)
                {
                    FrmEmpleado = new FrmEmpleado();
                    //FrmEmpleado.BringToFront();
                    FrmEmpleado.Show();
                    FrmEmpleado.MdiParent = this;
                    //FrmEmpleado.BringToFront();
                    Asignar(FrmEmpleado.Text);
                }
                //else { FrmProducto.BringToFront(); }
            }
            if (nombre == "Administrar Menu")
            {
                //if (FrmAsignarMenu == null || FrmAsignarMenu.IsDisposed)
                //{
                //    FrmAsignarMenu = new FrmAsignarMenu();
                //    objFuncion.AddFormInPanel(FrmAsignarMenu, Program.panelPrincipalVariable);
                //}
                //else
                //{
                //    //int index = panelPrincipal.Controls.GetChildIndex(FrmEmpleado);
                //    FrmAsignarMenu.BringToFront();
                //}
                if (FrmAsignarMenu == null || FrmAsignarMenu.IsDisposed)
                {
                    FrmAsignarMenu = new FrmAsignarMenu();
                    FrmAsignarMenu.Show();
                    FrmAsignarMenu.MdiParent = this;
                    //FrmAsignarMenu.BringToFront();
                    Asignar(FrmAsignarMenu.Text);

                }
                //else { FrmProducto.BringToFront(); }
            }
            //--------------------Empresa---------------------------------------//
            else if (nombre == "Cajas/Talonarios")
            {
                //if (FrmCajasTalonario == null || FrmCajasTalonario.IsDisposed)
                //{
                //    FrmCajasTalonario = new FrmCajasTalonario();
                //    objFuncion.AddFormInPanel(FrmCajasTalonario, Program.panelPrincipalVariable);
                //}
                //else
                //{
                //    int index = panelPrincipal.Controls.GetChildIndex(FrmCajasTalonario);
                //    FrmCajasTalonario.BringToFront();
                //}
                if (FrmCajasTalonario == null || FrmCajasTalonario.IsDisposed)
                {
                    FrmCajasTalonario = new FrmCajasTalonario();
                    FrmCajasTalonario.Show();
                    FrmCajasTalonario.MdiParent = this;
                    //FrmCajasTalonario.BringToFront();
                    Asignar(FrmCajasTalonario.Text);
                }
                //else { FrmProducto.BringToFront(); }
            }
            else if (nombre == "Informe Ventas")
            {
                //if (FrmCajasTalonario == null || FrmCajasTalonario.IsDisposed)
                //{
                //    FrmCajasTalonario = new FrmCajasTalonario();
                //    objFuncion.AddFormInPanel(FrmCajasTalonario, Program.panelPrincipalVariable);
                //}
                //else
                //{
                //    int index = panelPrincipal.Controls.GetChildIndex(FrmCajasTalonario);
                //    FrmCajasTalonario.BringToFront();
                //}
                if (FrmInformeVentas == null || FrmInformeVentas.IsDisposed)
                {
                    FrmInformeVentas = new FrmInformeVentas();
                    //FrmInformeVentas.BringToFront();
                    FrmInformeVentas.Show();
                    FrmInformeVentas.MdiParent = this;
                    Asignar(FrmInformeVentas.Text);
                }
                //else { FrmInformeVentas.BringToFront(); }
            }
            else if (nombre == "Empresa")
            {
                //if (FrmEmpresa == null || FrmEmpresa.IsDisposed)
                //{
                //    FrmEmpresa = new FrmEmpresa();
                //    objFuncion.AddFormInPanel(FrmEmpresa, Program.panelPrincipalVariable);
                //}
                //else
                //{
                //    int index = panelPrincipal.Controls.GetChildIndex(FrmEmpresa);
                //    FrmEmpresa.BringToFront();
                //}
                if (FrmEmpresa == null || FrmEmpresa.IsDisposed)
                {
                    FrmEmpresa = new FrmEmpresa();
                    FrmEmpresa.Show();
                    FrmEmpresa.MdiParent = this;
                    //FrmEmpresa.BringToFront();
                    Asignar(FrmEmpresa.Text);
                }
                //else { FrmProducto.BringToFront(); }
            }
            else if (nombre == "Impresion de Factura")
            {
                //if (FrmParametrosFactura == null || FrmParametrosFactura.IsDisposed)
                //{
                //    FrmParametrosFactura = new FrmParametrosFactura();
                //    objFuncion.AddFormInPanel(FrmParametrosFactura, Program.panelPrincipalVariable);
                //}
                //else
                //{
                //    int index = panelPrincipal.Controls.GetChildIndex(FrmParametrosFactura);
                //    FrmParametrosFactura.BringToFront();
                //}
                if (FrmParametrosFactura == null || FrmParametrosFactura.IsDisposed)
                {
                    FrmParametrosFactura = new FrmParametrosFactura();
                    FrmParametrosFactura.Show();
                    FrmParametrosFactura.MdiParent = this;
                    //FrmParametrosFactura.BringToFront();
                    Asignar(FrmParametrosFactura.Text);
                }
                //else { FrmProducto.BringToFront(); }
            }
            else if (nombre == "Sucursales")
            {
                //if (FrmSucursal == null || FrmSucursal.IsDisposed)
                //{
                //    FrmSucursal = new FrmSucursal();
                //    objFuncion.AddFormInPanel(FrmSucursal, Program.panelPrincipalVariable);
                //}
                //else
                //{
                //    int index = panelPrincipal.Controls.GetChildIndex(FrmSucursal);
                //    FrmSucursal.BringToFront();
                //}
                if (FrmSucursal == null || FrmSucursal.IsDisposed)
                {
                    FrmSucursal = new FrmSucursal();
                    FrmSucursal.Show();
                    FrmSucursal.MdiParent = this;
                    //FrmSucursal.BringToFront();
                    Asignar(FrmSucursal.Text);
                }
                //else { FrmProducto.BringToFront(); }
            }
            //--------------------Proveedores---------------------------------------//
            else if (nombre == "Administrar Proveedores")
            {
                //if (FrmProveedor == null || FrmProveedor.IsDisposed)
                //{
                //    FrmProveedor = new FrmProveedores();
                //    objFuncion.AddFormInPanel(FrmProveedor, Program.panelPrincipalVariable);
                //}
                //else
                //{
                //    int index = panelPrincipal.Controls.GetChildIndex(FrmProveedor);
                //    FrmProveedor.BringToFront();
                //}
                if (FrmProveedor == null || FrmProveedor.IsDisposed)
                {
                    FrmProveedor = new FrmProveedores();
                    FrmProveedor.Show();
                    FrmProveedor.MdiParent = this;
                    //FrmProveedor.BringToFront();
                    Asignar(FrmProveedor.Text);
                }
                //else { FrmProducto.BringToFront(); }
            }
            //--------------------Usuarios---------------------------------------//
            else if (nombre == "Administrar Usuarios")
            {
                //if (FrmUsuario == null || FrmUsuario.IsDisposed)
                //{
                //    FrmUsuario = new FrmUsuarios();
                //    objFuncion.AddFormInPanel(FrmUsuario, Program.panelPrincipalVariable);
                //}
                //else
                //{
                //    int index = panelPrincipal.Controls.GetChildIndex(FrmUsuario);
                //    FrmUsuario.BringToFront();
                //}
                if (FrmUsuario == null || FrmUsuario.IsDisposed)
                {
                    FrmUsuario = new FrmUsuarios();
                    FrmUsuario.Show();
                    FrmUsuario.MdiParent = this;
                    //FrmUsuario.BringToFront();
                    Asignar(FrmUsuario.Text);
                }
                //else { FrmProducto.BringToFront(); }
            }
            //--------------------Inventario---------------------------------------//
            else if (nombre == "Productos")
            {
                //if (FrmProducto == null || FrmProducto.IsDisposed)
                //{
                //    FrmProducto = new FrmProductos();
                //    objFuncion.AddFormInPanel(FrmProducto, Program.panelPrincipalVariable);
                //}
                //else
                //{
                //    int index = panelPrincipal.Controls.GetChildIndex(FrmProducto);
                //    FrmProducto.BringToFront();
                //}
                if (FrmProducto == null || FrmProducto.IsDisposed)
                {
                    FrmProducto = new FrmProductos();
                    ////FrmProducto.BringToFront();
                    FrmProducto.Show();
                    FrmProducto.MdiParent = this;
                    Asignar(FrmProducto.Text);
                }
                //else { FrmProducto.BringToFront(); }
            }
            else if (nombre == "Categoria Producto")
            {
                //if (FrmCategoriaProducto == null || FrmCategoriaProducto.IsDisposed)
                //{
                //    FrmCategoriaProducto = new FrmCategoriaProductos();
                //    objFuncion.AddFormInPanel(FrmCategoriaProducto, Program.panelPrincipalVariable);
                //}
                //else
                //{
                //    int index = panelPrincipal.Controls.GetChildIndex(FrmCategoriaProducto);
                //    FrmCategoriaProducto.BringToFront();
                //}
                if (FrmCategoriaProducto == null || FrmCategoriaProducto.IsDisposed)
                {
                    FrmCategoriaProducto = new FrmCategoriaProductos();
                    //FrmCategoriaProducto.BringToFront();
                    FrmCategoriaProducto.Show();
                    FrmCategoriaProducto.MdiParent = this;
                    Asignar(FrmCategoriaProducto.Text);
                }
                //else { FrmCategoriaProducto.BringToFront(); }

            }
            else if (nombre == "Creacion de Bodega")
            {
                //if (FrmCreacionBodega == null || FrmCreacionBodega.IsDisposed)
                //{
                //    FrmCreacionBodega = new FrmCreacionBodega();
                //    objFuncion.AddFormInPanel(FrmCreacionBodega, Program.panelPrincipalVariable);
                //}
                //else
                //{
                //    int index = panelPrincipal.Controls.GetChildIndex(FrmCreacionBodega);
                //    FrmCreacionBodega.BringToFront();
                //}
                if (FrmCreacionBodega == null || FrmCreacionBodega.IsDisposed)
                {
                    FrmCreacionBodega = new FrmCreacionBodega();
                    //FrmCreacionBodega.BringToFront();
                    FrmCreacionBodega.Show();
                    FrmCreacionBodega.MdiParent = this;
                    Asignar(FrmCreacionBodega.Text);
                }
                //else { FrmCreacionBodega.BringToFront(); }
            }
            else if (nombre == "Combo de Productos")
            {
                //if (FrmComboProducto == null || FrmComboProducto.IsDisposed)
                //{
                //    FrmComboProducto = new FrmComboProductos();
                //    objFuncion.AddFormInPanel(FrmComboProducto, Program.panelPrincipalVariable);
                //}
                //else
                //{
                //    int index = panelPrincipal.Controls.GetChildIndex(FrmComboProducto);
                //    FrmComboProducto.BringToFront();
                //}
                if (FrmComboProducto == null || FrmComboProducto.IsDisposed)
                {
                    FrmComboProducto = new FrmComboProductos();
                    //FrmComboProducto.BringToFront();
                    FrmComboProducto.Show();
                    FrmComboProducto.MdiParent = this;
                    Asignar(FrmComboProducto.Text);
                }
                //else { FrmCreacionBodega.BringToFront(); }
            }
            else if (nombre == "Asignacion de Producto por Bodega")
            {
                //if (FrmAsignacionProductoBodega == null || FrmAsignacionProductoBodega.IsDisposed)
                //{
                //    FrmAsignacionProductoBodega = new FrmAsignacionProductoBodega();
                //    objFuncion.AddFormInPanel(FrmAsignacionProductoBodega, Program.panelPrincipalVariable);
                //}
                //else
                //{
                //    int index = panelPrincipal.Controls.GetChildIndex(FrmAsignacionProductoBodega);
                //    FrmAsignacionProductoBodega.BringToFront();
                //}
                if (FrmAsignacionProductoBodega == null || FrmAsignacionProductoBodega.IsDisposed)
                {
                    FrmAsignacionProductoBodega = new FrmAsignacionProductoBodega();
                    //FrmAsignacionProductoBodega.BringToFront();
                    FrmAsignacionProductoBodega.Show();
                    FrmAsignacionProductoBodega.MdiParent = this;
                    Asignar(FrmAsignacionProductoBodega.Text);
                }
                //else { FrmAsignacionProductoBodega.BringToFront(); }
            }
            //-------------------------------------------------Transacciones---------------------------------------//
            else if (nombre == "Ventas")
            {
                //if (FrmClaveUsuario == null || FrmClaveUsuario.IsDisposed)
                //{
                //    FrmClaveUsuario = new FrmClaveUsuario();
                //    FrmClaveUsuario.verificarMetodo = 1;
                //    objFuncion.AddFormInPanel(FrmClaveUsuario, Program.panelPrincipalVariable);
                //}
                //else
                //{
                //    int index = panelPrincipal.Controls.GetChildIndex(FrmClaveUsuario);
                //    FrmClaveUsuario.BringToFront();
                //}


                if (!Program.FormularioVentaAbierto)
                {
                    if (FrmClaveUsuario == null || FrmClaveUsuario.IsDisposed)
                    {
                        FrmClaveUsuario = new FrmClaveUsuario();
                        FrmClaveUsuario.verificarMetodo = 1;
                        //FrmClaveUsuario.BringToFront();
                        FrmClaveUsuario.Show();
                        FrmClaveUsuario.MdiParent = this;
                        Asignar(FrmClaveUsuario.Text);
                    }
                    //else { FrmClaveUsuario.BringToFront(); }
                }
            }
            else if (nombre == "Compras")
            {
                if (objConsulta.ObtenerValorCampo("IDPROVEEDOR", "TbProveedor", "") != "" && objConsulta.ObtenerValorCampo("IDSUCURSAL", "TbSucursal", "") != "" && objConsulta.ObtenerValorCampo("IDPARAMETROSFACTURA", "TbParametrosFactura", "") != "")
                {
                    //if (FrmCompra == null || FrmCompra.IsDisposed)
                    //{
                    //    FrmCompra = new FrmCompra();
                    //    objFuncion.AddFormInPanel(FrmCompra, Program.panelPrincipalVariable);
                    //}
                    //else
                    //{
                    //    int index = panelPrincipal.Controls.GetChildIndex(FrmCompra);
                    //    FrmCompra.BringToFront();
                    //}
                    if (FrmCompra == null || FrmCompra.IsDisposed)
                    {
                        FrmCompra = new FrmCompra();
                        //FrmCompra.BringToFront();
                        FrmCompra.Show();
                        FrmCompra.MdiParent = this;
                        Asignar(FrmCompra.Text);
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
                                Asignar(FrmOrdenDeGiro.Name);
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
                if (FrmDevolucionVenta == null || FrmDevolucionVenta.IsDisposed)
                {
                    FrmDevolucionVenta = new FrmDevolucionVenta();
                    FrmDevolucionVenta.Show();
                    FrmDevolucionVenta.MdiParent = this;
                    Asignar(FrmDevolucionVenta.Text);
                }
            }
            else if (nombre == "Kardex")
            {
                //if (FrmDevolucionVenta == null || FrmDevolucionVenta.IsDisposed)
                //{
                //    FrmDevolucionVenta = new FrmDevolucionVenta();
                //    objFuncion.AddFormInPanel(FrmDevolucionVenta, Program.panelPrincipalVariable);
                //}
                //else
                //{
                //    int index = panelPrincipal.Controls.GetChildIndex(FrmDevolucionVenta);
                //    FrmDevolucionVenta.BringToFront();
                //}
                if (FrmKardex == null || FrmKardex.IsDisposed)
                {
                    FrmKardex = new FrmKardex();
                    //FrmDevolucionVenta.BringToFront();
                    FrmKardex.Show();
                    FrmKardex.MdiParent = this;
                    Asignar(FrmKardex.Text);
                }
                //else { FrmDevolucionVenta.BringToFront(); }
            }
            else if (nombre == "Declaración SRI")
            {
                //if (FrmDevolucionVenta == null || FrmDevolucionVenta.IsDisposed)
                //{
                //    FrmDevolucionVenta = new FrmDevolucionVenta();
                //    objFuncion.AddFormInPanel(FrmDevolucionVenta, Program.panelPrincipalVariable);
                //}
                //else
                //{
                //    int index = panelPrincipal.Controls.GetChildIndex(FrmDevolucionVenta);
                //    FrmDevolucionVenta.BringToFront();
                //}
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

        private void Asignar(string nombreF)
        {
            //ventanaToolStripMenuItem.DropDownItems.Add(new ToolStripMenuItem(nombreF));
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

        private void msPrincipal1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
