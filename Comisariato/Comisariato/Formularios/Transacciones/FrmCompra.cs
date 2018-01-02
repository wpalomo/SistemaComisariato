using Comisariato.Clases;
using Comisariato.Formularios.Transacciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comisariato.Formularios.Mantenimiento.Inventario
{
    public partial class FrmCompra : Form
    {
        public FrmCompra()
        {
            InitializeComponent();
        }
        public static DataGridView datosProductoCompra;
        public static ComboBox datosProveedor;
        Funcion objFuncion = new Funcion();
        FrmPrincipal objPrincipal = new FrmPrincipal();
        public static int IDEncabezadoCompraOG = 0;
        public static string IVA = "";

        Consultas consultas;
        EmcabezadoCompra ObjEncabezadoCompra;
        DetalleCompra ObjDetalleCompra;
        Producto objProducto;
        int ordenCompra = 0, idOrdenComrpa;
        float sumasubiva = 0.0f, sumasubcero = 0.0f, totalpagar = 0.0f, ivatotal = 0.0f, sumaice = 0.0f, sumairbp = 0.0f, subtotalPie = 0.0f;
        bool banderaFocoCelda = false;
        int posicion = 0;
        bool tieneIVA=false;
        float ivaTotal = 0.0f;
        public void incializar()
        {
            tieneIVA = false;
            ordenCompra = 0;
            sumasubiva = 0.0f; sumasubcero = 0.0f; totalpagar = 0.0f; ivatotal = 0.0f; sumaice = 0.0f; sumairbp = 0.0f; subtotalPie = 0.0f;
            banderaFocoCelda = false;
            posicion = 0;
            ivaTotal = 0.0f;
            txtFlete.Text = "0";
            txtSubtotal.Text = "0.0";
            txtSubtotal0.Text = "0.0";
            txtSubtutalIVA.Text = "0.0";
            txtTotal.Text = "0.0";
            txtICE.Text = "0.0";
            txtIRBP.Text = "0.0";
            txtIVA.Text = "0.0";
            txtFlete.Text = "0.0";
            cbTerminoPago.SelectedIndex = 0;
            dgvProductosIngresos.Rows.Clear();
            for (int i = 0; i < 8; i++)
            {
                dgvProductosIngresos.Rows.Add();
            }
            for (int i = 0; i < dgvProductosIngresos.ColumnCount - 1; i++)
            {
                dgvProductosIngresos.Columns[i].ReadOnly = true;
            }
            dgvProductosIngresos.Rows[0].Cells[0].ReadOnly = false;
        }
        private void FrmCompra_Load(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");
            txtSerie1.Focus();
            incializar();
            consultas = new Consultas();
            consultas.BoolLlenarComboBox(cbSucursal, "select IDSUCURSAL AS Id, NOMBRESUCURSAL as Texto from TbSucursal");
            consultas.BoolLlenarComboBox(cbProveedor, "select IDPROVEEDOR AS Id, NOMBRES AS Texto from TbProveedor");
            idOrdenComrpa = consultas.ObtenerID("IDEMCABEZADOCOMPRA", "TbEncabezadoyPieCompra", "");
            ordenCompra = 1 + consultas.ObtenerID("ORDEN_COMPRA_NUMERO", "TbEncabezadoyPieCompra", " where IDEMCABEZADOCOMPRA ="+ idOrdenComrpa + "");
            consultas.BoolLlenarComboBox(cbImpuesto, "select IDIVA AS ID, IVA + '%' as TEXTO from tbIva");            
            txtOrdenCompra.Text = Convert.ToString(ordenCompra);
            datosProductoCompra = dgvProductosIngresos;
            datosProveedor = cbProveedor;
            txtFlete.Text = "0";
            txtSubtotal.Text = "0.0";
            txtSubtotal0.Text = "0.0";
            txtSubtutalIVA.Text = "0.0";
            txtTotal.Text = "0.0";
            txtICE.Text = "0.0";
            txtIRBP.Text = "0.0";
            txtIVA.Text = "0.0";
            txtFlete.Text = "0.0";
            cbTerminoPago.SelectedIndex = 0;
            for (int i = 0; i < 20; i++)
                dgvInformeCompras.Rows.Add();
            cadenaConsultar = cadenaGeneral;
        }
        //FrmOrdenDeGiro frmOrdenDeGiro = new FrmOrdenDeGiro();
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (txtSerie1.Text != "" && txtSerie2.Text != "" && txtNumero.Text != "")
            {
                bool cantidadRegistros = consultas.Existe("SERIE1 = " + Convert.ToInt32(txtSerie1.Text) + " and SERIE2 = " + Convert.ToInt32(txtSerie2.Text) + " and NUMERO = " + Convert.ToInt32(txtNumero.Text) + " and IDPROVEEDOR", Convert.ToString(cbProveedor.SelectedValue), "TbEncabezadoyPieCompra");
                if (!cantidadRegistros)
                {
                    bool dataGridCorrecto = false;
                    for (int i = 0; i < datosProductoCompra.RowCount - 1; i++)
                    {
                        if (Convert.ToString(datosProductoCompra.Rows[i].Cells[0].Value) != "")
                        {
                            for (int j = 1; j < datosProductoCompra.ColumnCount - 3; j++)
                            {
                                if (Convert.ToString(datosProductoCompra.Rows[i].Cells[j].Value) != "")
                                {
                                    dataGridCorrecto = true;
                                }
                                else
                                {
                                    dataGridCorrecto = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (dataGridCorrecto)
                    {
                        if (MessageBox.Show("¿Desea guaradar la compra?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ObjEncabezadoCompra = new EmcabezadoCompra(txtSerie1.Text, txtSerie2.Text, txtNumero.Text, sumasubiva, sumasubcero, subtotalPie, totalpagar, txtOrdenCompra.Text,
                                Convert.ToInt32(cbSucursal.SelectedValue), Convert.ToSingle(txtFlete.Text), dtpFechaOC.Value, Convert.ToInt32(datosProveedor.SelectedValue), cbTerminoPago.Text,
                                txtPlazoOC.Text, cbImpuesto.Text, txtObservacion.Text, ivatotal, sumaice, sumairbp);
                            String resultadoDetalle = "";
                            String resultadoEncabezado = ObjEncabezadoCompra.InsertarEncabezadoyPieCompra(ObjEncabezadoCompra); // retorna true si esta correcto todo
                            if (resultadoEncabezado == "Datos Guardados")
                            {
                                for (int i = 0; i < datosProductoCompra.RowCount; i++)
                                {
                                    ObjDetalleCompra = new DetalleCompra(Convert.ToSingle(Funcion.reemplazarcaracterViceversa(datosProductoCompra.Rows[i].Cells[6].Value.ToString())), Convert.ToSingle(Funcion.reemplazarcaracterViceversa(datosProductoCompra.Rows[i].Cells[7].Value.ToString())),
                                        Convert.ToString(datosProductoCompra.Rows[i].Cells[0].Value), Convert.ToInt32(datosProductoCompra.Rows[i].Cells[2].Value),
                                        Convert.ToSingle(Funcion.reemplazarcaracterViceversa(datosProductoCompra.Rows[i].Cells[3].Value.ToString())), Convert.ToSingle(Funcion.reemplazarcaracterViceversa(datosProductoCompra.Rows[i].Cells[4].Value.ToString())),
                                        Convert.ToSingle(Funcion.reemplazarcaracterViceversa(datosProductoCompra.Rows[i].Cells[7].Value.ToString())), Convert.ToSingle(Funcion.reemplazarcaracterViceversa(datosProductoCompra.Rows[i].Cells[8].Value.ToString())),
                                        Convert.ToSingle(Funcion.reemplazarcaracterViceversa(datosProductoCompra.Rows[i].Cells[9].Value.ToString())), Convert.ToInt32(txtSerie1.Text), Convert.ToInt32(txtSerie2.Text), Convert.ToInt32(txtNumero.Text), Convert.ToInt32(cbProveedor.SelectedValue));
                                    resultadoDetalle = ObjDetalleCompra.InsertarDetalleCompra(ObjDetalleCompra);
                                    if (Convert.ToString(datosProductoCompra.Rows[i + 1].Cells[0].Value) == "")
                                        break;
                                }
                                if (resultadoDetalle == "Datos Guardados")
                                {
                                    MessageBox.Show("Compra Registrada Correctamente ", "Exito", MessageBoxButtons.OK);
                                    if (MessageBox.Show("¿Desea ingresar la orden de giro?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        Program.FormularioLlamado = true;
                                        IVA = cbImpuesto.Text;
                                        string condicion = "where SERIE1 = " + Convert.ToInt32(txtSerie1.Text) + " AND SERIE2 = " + Convert.ToInt32(txtSerie2.Text) + " AND NUMERO = " + Convert.ToInt32(txtNumero.Text) + " AND IDPROVEEDOR = " + Convert.ToInt32(cbProveedor.SelectedValue);
                                        IDEncabezadoCompraOG = Convert.ToInt32(consultas.ObtenerValorCampo("IDEMCABEZADOCOMPRA", "TbEncabezadoyPieCompra", condicion));
                                        if (FrmPrincipal.FrmOrdenDeGiro == null || FrmPrincipal.FrmOrdenDeGiro.IsDisposed)
                                        {
                                            FrmPrincipal.FrmOrdenDeGiro = new FrmOrdenDeGiro();
                                            FrmPrincipal.FrmOrdenDeGiro.MdiParent = Program.panelPrincipalVariable;
                                            FrmPrincipal.FrmOrdenDeGiro.BringToFront();
                                            FrmPrincipal.FrmOrdenDeGiro.Show();
                                        }
                                        else
                                        {
                                            FrmPrincipal.FrmOrdenDeGiro.Close();
                                            if (FrmPrincipal.FrmOrdenDeGiro == null || FrmPrincipal.FrmOrdenDeGiro.IsDisposed)
                                            {
                                                FrmPrincipal.FrmOrdenDeGiro = new FrmOrdenDeGiro();
                                                FrmPrincipal.FrmOrdenDeGiro.MdiParent = Program.panelPrincipalVariable;
                                                FrmPrincipal.FrmOrdenDeGiro.BringToFront();
                                                FrmPrincipal.FrmOrdenDeGiro.Show();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        int ordenNumero = Convert.ToInt32(txtOrdenCompra.Text);
                                        Funcion.Limpiarobjetos(gbEncabezadoCompra);
                                        txtOrdenCompra.Text = Convert.ToString(ordenNumero + 1);
                                        incializar();
                                    }
                                }
                                else if (resultadoDetalle == "Error al Registrar")
                                {
                                    MessageBox.Show("Error al guardar Producto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    try
                                    {
                                        int idDetalle = 0, idEncabezado = 0;
                                        consultas.ObtenerIDCompra(ref idDetalle, "select D.IDENCABEZADOCOMPRA from TbEncabezadoyPieCompra E, TbDetalleCompra D where D.IDENCABEZADOCOMPRA = E.IDEMCABEZADOCOMPRA and E.NUMERO = " + Convert.ToInt32(txtNumero.Text) + " AND E. SERIE1 = " + Convert.ToInt32(txtSerie1.Text) + " AND SERIE2 = " + Convert.ToInt32(txtSerie2.Text) + " AND IDPROVEEDOR = " + Convert.ToInt32(cbProveedor.SelectedValue) + "");
                                        consultas.EjecutarSQL("DELETE FROM [dbo].[TbDetalleCompra] WHERE IDENCABEZADOCOMPRA = " + idDetalle + "");
                                        consultas.ObtenerIDCompra(ref idEncabezado, "select E.IDEMCABEZADOCOMPRA from TbEncabezadoyPieCompra E where E.NUMERO = " + Convert.ToInt32(txtNumero.Text) + " AND E. SERIE1 = " + Convert.ToInt32(txtSerie1.Text) + " AND SERIE2 = " + Convert.ToInt32(txtSerie2.Text) + " AND IDPROVEEDOR = " + Convert.ToInt32(cbProveedor.SelectedValue) + "");
                                        consultas.EjecutarSQL("DELETE FROM [dbo].[TbEncabezadoyPieCompra] WHERE IDEMCABEZADOCOMPRA = " + idEncabezado + "");
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }
                            }
                            else if (resultadoEncabezado == "Error al Registrar Encabezado")
                            {
                                try
                                {
                                    int idEncabezado = 0;
                                    MessageBox.Show("Error al guardar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    consultas.ObtenerIDCompra(ref idEncabezado, "select E.IDEMCABEZADOCOMPRA from TbEncabezadoyPieCompra E where E.NUMERO = " + Convert.ToInt32(txtNumero.Text) + " AND E. SERIE1 = " + Convert.ToInt32(txtSerie1.Text) + " AND SERIE2 = " + Convert.ToInt32(txtSerie2.Text) + " AND IDPROVEEDOR = " + Convert.ToInt32(cbProveedor.SelectedValue) + "");
                                    consultas.EjecutarSQL("DELETE FROM [dbo].[TbEncabezadoyPieCompra] WHERE IDEMCABEZADOCOMPRA = " + idEncabezado + "");
                                }
                                catch (Exception)
                                {
                                }
                            }
                            else if (resultadoEncabezado == "Existe") { MessageBox.Show("Ya Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); }                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("Uno o mas campos en el detalle de la compra estan vacíos");
                        dgvProductosIngresos.Focus();
                    }
                }
                else
                    MessageBox.Show("El numero de factura del proveedor seleccionado ya existe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Ingrese los datos necesarios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }        
        
        public void informacionProducto()
        {
            datosProductoCompra.CurrentRow.Cells[1].Value = objProducto.Nombreproducto;
            if (tieneIVA)
            {
                datosProductoCompra.CurrentRow.Cells[5].Value = Funcion.reemplazarcaracter(objProducto.Ice.ToString());
                posicion = 5;
                Funcion.ValidaCeldasPrecios(datosProductoCompra, posicion, ref banderaFocoCelda);
                datosProductoCompra.CurrentRow.Cells[6].Value = Funcion.reemplazarcaracter(objProducto.Irbp.ToString());
                posicion = 6;
                Funcion.ValidaCeldasPrecios(datosProductoCompra, posicion, ref banderaFocoCelda);
                datosProductoCompra.CurrentRow.Cells[7].Value = Funcion.reemplazarcaracter(objProducto.Preciopublico_iva.ToString());
                posicion = 7;
                Funcion.ValidaCeldasPrecios(datosProductoCompra, posicion, ref banderaFocoCelda);
                datosProductoCompra.CurrentRow.Cells[8].Value = Funcion.reemplazarcaracter(objProducto.Precioalmayor_iva.ToString());
                posicion = 8;
                Funcion.ValidaCeldasPrecios(datosProductoCompra, posicion, ref banderaFocoCelda);
                datosProductoCompra.CurrentRow.Cells[9].Value = Funcion.reemplazarcaracter(objProducto.Precioporcaja_iva.ToString());
                posicion = 9;
                Funcion.ValidaCeldasPrecios(datosProductoCompra, posicion, ref banderaFocoCelda);
            }
            else
            {
                datosProductoCompra.CurrentRow.Cells[5].Value = 0;
                posicion = 5;
                Funcion.ValidaCeldasPrecios(datosProductoCompra, posicion, ref banderaFocoCelda);
                datosProductoCompra.CurrentRow.Cells[6].Value = 0;
                posicion = 6;
                Funcion.ValidaCeldasPrecios(datosProductoCompra, posicion, ref banderaFocoCelda);
                datosProductoCompra.CurrentRow.Cells[5].ReadOnly = true;
                datosProductoCompra.CurrentRow.Cells[6].ReadOnly = true;
                datosProductoCompra.CurrentRow.Cells[7].Value = Funcion.reemplazarcaracter(objProducto.Preciopublico_sin_iva.ToString());
                posicion = 7;
                Funcion.ValidaCeldasPrecios(datosProductoCompra, posicion, ref banderaFocoCelda);
                datosProductoCompra.CurrentRow.Cells[8].Value = Funcion.reemplazarcaracter(objProducto.Precioalmayor_sin_iva.ToString());
                posicion = 8;
                Funcion.ValidaCeldasPrecios(datosProductoCompra, posicion, ref banderaFocoCelda);
                datosProductoCompra.CurrentRow.Cells[9].Value = Funcion.reemplazarcaracter(objProducto.Precioporcaja_sin_iva.ToString());
                posicion = 9;
                Funcion.ValidaCeldasPrecios(datosProductoCompra, posicion, ref banderaFocoCelda);
            }
            if (objProducto.PrecioCompra != 0)
            {
                datosProductoCompra.CurrentRow.Cells[3].Value = Funcion.reemplazarcaracter(objProducto.PrecioCompra.ToString());
                posicion = 3;
                Funcion.ValidaCeldasPrecios(datosProductoCompra, posicion, ref banderaFocoCelda);
            }
        }
        
        public bool validarCodigoRepetido(DataGridViewCellEventArgs e)
        {
            bool repetido = false;
            for (int i = e.RowIndex - 1; i > -1; i--)
            {
                if (Convert.ToString(datosProductoCompra.Rows[e.RowIndex].Cells[0].Value) == Convert.ToString(datosProductoCompra.Rows[i].Cells[0].Value))
                {
                    MessageBox.Show("Producto ya ingresado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    datosProductoCompra.Rows[e.RowIndex].Cells[0].Value = "";
                    datosProductoCompra.CurrentCell = datosProductoCompra.Rows[e.RowIndex].Cells[0];
                    repetido = true;
                    break;
                }
                else
                {
                    repetido = false;
                }
            }
            return repetido;
        }
        
        private void dgvProductosIngresos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bool banderaTab = false;
            objProducto = new Producto();
            int into = 0;
            float iva = 0.0f, subtotal = 0.0f, total = 0.0f;
            try
            {
                if (datosProductoCompra.Columns[e.ColumnIndex].Name == "codigo")
                {
                    //---------------Desbloquear Celdas
                    if (!validarCodigoRepetido(e))
                    {
                        //---------------Desbloquear Celdas
                        for (int i = 0; i < datosProductoCompra.ColumnCount - 3; i++)
                        {
                            datosProductoCompra.CurrentRow.Cells[i].ReadOnly = false;
                        }
                        objProducto = consultas.ConsultarproductoCompra(Convert.ToString(datosProductoCompra.CurrentRow.Cells[0].Value));
                        if (objProducto == null)
                        {
                            if (MessageBox.Show("¿Desea agregar el producto?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //FrmProductos frmProducto = new FrmProductos();
                                Program.FormularioLlamado = true;
                                FrmProductos.codigo = Convert.ToString(datosProductoCompra.CurrentRow.Cells[0].Value);
                                if (FrmPrincipal.FrmProducto == null || FrmPrincipal.FrmProducto.IsDisposed)
                                {
                                    FrmPrincipal.FrmProducto = new FrmProductos();
                                    FrmPrincipal.FrmProducto.MdiParent = Program.panelPrincipalVariable;
                                    FrmPrincipal.FrmProducto.BringToFront();
                                    FrmPrincipal.FrmProducto.Show();
                                }
                                else
                                {
                                    FrmPrincipal.FrmProducto.Close();
                                    if (FrmPrincipal.FrmProducto == null || FrmPrincipal.FrmProducto.IsDisposed)
                                    {
                                        FrmPrincipal.FrmProducto = new FrmProductos();
                                        FrmPrincipal.FrmProducto.MdiParent = Program.panelPrincipalVariable;
                                        FrmPrincipal.FrmProducto.BringToFront();
                                        FrmPrincipal.FrmProducto.Show();
                                    }
                                }
                                informacionProducto();
                                datosProductoCompra.CurrentCell = datosProductoCompra.CurrentRow.Cells[2];
                            }
                            else
                            {
                                datosProductoCompra.CurrentRow.Cells[0].Value = "";
                                SendKeys.Send("{LEFT}");
                                banderaTab = true;
                            }
                            datosProductoCompra.CurrentCell = datosProductoCompra.CurrentRow.Cells[1];
                        }
                        else
                        {
                            tieneIVA = objProducto.Ivaestado;
                            informacionProducto();
                            SendKeys.Send("{TAB}");
                        }
                    }
                    else
                    {
                        datosProductoCompra.CurrentRow.Cells[0].Value = "";
                        SendKeys.Send("{LEFT}");
                        banderaTab = true;
                    }

                }


                if (datosProductoCompra.Columns[e.ColumnIndex].Name == "cantidad")
                {
                    if (Convert.ToString(datosProductoCompra.CurrentRow.Cells[2].Value) != "")
                        SendKeys.Send("{RIGHT}");
                    banderaTab = true;
                }
                if (datosProductoCompra.Columns[e.ColumnIndex].Name == "precioCompra")
                {
                    if (Convert.ToString(datosProductoCompra.CurrentRow.Cells[3].Value) != "")
                    {
                        posicion = 3;
                        Funcion.ValidaCeldasPrecios(datosProductoCompra, posicion, ref banderaFocoCelda);
                        SendKeys.Send("{RIGHT}");
                    }
                    banderaTab = true;
                }
                if (datosProductoCompra.Columns[e.ColumnIndex].Name == "descuento")
                {
                    if (Convert.ToString(datosProductoCompra.CurrentRow.Cells[4].Value) == "")
                    {
                        datosProductoCompra.CurrentRow.Cells[4].Value = "0";
                        posicion = 4;
                        Funcion.ValidaCeldasPrecios(datosProductoCompra, posicion, ref banderaFocoCelda);
                        SendKeys.Send("{RIGHT}");
                    }
                    else
                    {
                        posicion = 4;
                        Funcion.ValidaCeldasPrecios(datosProductoCompra, posicion, ref banderaFocoCelda);
                        SendKeys.Send("{RIGHT}");
                    }
                    banderaTab = true;
                }
                if (datosProductoCompra.Columns[e.ColumnIndex].Name == "iceProducto")
                {
                    if (Convert.ToString(datosProductoCompra.CurrentRow.Cells[5].Value) != "")
                    {
                        posicion = 5;
                        Funcion.ValidaCeldasPrecios(datosProductoCompra, posicion, ref banderaFocoCelda);
                        SendKeys.Send("{RIGHT}");
                    }
                    banderaTab = true;
                }
                if (datosProductoCompra.Columns[e.ColumnIndex].Name == "irbpProducto")
                {
                    if (Convert.ToString(datosProductoCompra.CurrentRow.Cells[6].Value) != "")
                    {
                        posicion = 6;
                        Funcion.ValidaCeldasPrecios(datosProductoCompra, posicion, ref banderaFocoCelda);
                        SendKeys.Send("{RIGHT}");
                    }
                    banderaTab = true;
                }
                if (datosProductoCompra.Columns[e.ColumnIndex].Name == "precioPublico")
                {
                    if (Convert.ToString(datosProductoCompra.CurrentRow.Cells[7].Value) != "")
                    {
                        posicion = 7;
                        Funcion.ValidaCeldasPrecios(datosProductoCompra, posicion, ref banderaFocoCelda);
                        SendKeys.Send("{RIGHT}");
                    }
                    banderaTab = true;
                }
                if (datosProductoCompra.Columns[e.ColumnIndex].Name == "precioMayorista")
                {
                    if (Convert.ToString(datosProductoCompra.CurrentRow.Cells[8].Value) != "")
                    {
                        posicion = 8;
                        Funcion.ValidaCeldasPrecios(datosProductoCompra, posicion, ref banderaFocoCelda);
                        SendKeys.Send("{RIGHT}");
                    }
                    banderaTab = true;
                }
                if (datosProductoCompra.Columns[e.ColumnIndex].Name == "precioCaja")
                {
                    if (Convert.ToString(datosProductoCompra.CurrentRow.Cells[9].Value) != "")
                    {
                        posicion = 9;
                        Funcion.ValidaCeldasPrecios(datosProductoCompra, posicion, ref banderaFocoCelda);
                        datosProductoCompra.CurrentCell = datosProductoCompra.CurrentRow.Cells[12];
                        datosProductoCompra.Rows[e.RowIndex + 1].Cells[0].ReadOnly = false;
                        SendKeys.Send("{TAB}");
                    }
                    banderaTab = true;
                }
                if (datosProductoCompra.Columns[e.ColumnIndex].Name == "precioCompra" || datosProductoCompra.Columns[e.ColumnIndex].Name == "cantidad" || datosProductoCompra.Columns[e.ColumnIndex].Name == "iceProducto" || datosProductoCompra.Columns[e.ColumnIndex].Name == "irbpProducto" || datosProductoCompra.Columns[e.ColumnIndex].Name == "codigo")
                {
                    float precioCompra = Convert.ToSingle(Funcion.reemplazarcaracterViceversa(datosProductoCompra.CurrentRow.Cells[3].Value.ToString()));
                    float cantidad = Convert.ToInt32(datosProductoCompra.CurrentRow.Cells[2].Value.ToString());
                    float precioICE = Convert.ToSingle(Funcion.reemplazarcaracterViceversa(datosProductoCompra.CurrentRow.Cells[5].Value.ToString()));
                    float precioIRBP = Convert.ToSingle(Funcion.reemplazarcaracterViceversa(datosProductoCompra.CurrentRow.Cells[6].Value.ToString()));
                    string[] separadorPorcentaje = cbImpuesto.Text.Split('%');
                    int tipoIva = Convert.ToInt32(separadorPorcentaje[0]);
                    if (tieneIVA)
                    {
                        iva = (((precioCompra + precioICE) * cantidad) * tipoIva) / 100;
                    }
                    else
                    {
                        iva = 0;
                    }
                    subtotal = ((precioCompra + precioICE + precioIRBP) * cantidad);
                    total = subtotal + iva;
                    ivaTotal = iva;
                    datosProductoCompra.CurrentRow.Cells[11].Value = Funcion.reemplazarcaracter(Math.Round(iva, 2).ToString("#####0.00"));
                    datosProductoCompra.CurrentRow.Cells[10].Value = Funcion.reemplazarcaracter(Math.Round(subtotal, 2).ToString("#####0.00"));
                    datosProductoCompra.CurrentRow.Cells[12].Value = Funcion.reemplazarcaracter(Math.Round(total, 2).ToString("#####0.00"));
                }

            }
            catch (Exception otro)
            {
            }
            Calcular();
            SendKeys.Send("{UP}");
            if (!banderaTab)
                SendKeys.Send("{RIGHT}");
            else
                banderaTab = false;
        }
        private void Calcular()
        {
            float cantidad = 0, pc = 0.0f;
            sumasubiva = 0.0f; sumasubcero = 0.0f; totalpagar = 0.0f; ivatotal = 0.0f; sumaice = 0.0f; sumairbp = 0.0f; subtotalPie = 0.0f;
            try
            {
                for (int i = 0; i < datosProductoCompra.RowCount; i++)
                {
                    if (Convert.ToSingle(datosProductoCompra.Rows[i].Cells[11].Value.ToString()) != 0)
                    {
                        cantidad = Convert.ToInt32(datosProductoCompra.Rows[i].Cells[2].Value);
                        pc = Convert.ToSingle(Funcion.reemplazarcaracterViceversa(datosProductoCompra.Rows[i].Cells[3].Value.ToString()));
                        sumasubiva += Convert.ToSingle(cantidad * pc);
                        
                    }
                    if (Convert.ToSingle(datosProductoCompra.Rows[i].Cells[11].Value.ToString()) == 0)
                    {
                        cantidad = Convert.ToInt32(datosProductoCompra.Rows[i].Cells[2].Value);
                        pc = Convert.ToSingle(Funcion.reemplazarcaracterViceversa(datosProductoCompra.Rows[i].Cells[3].Value.ToString()));
                        sumasubcero += Convert.ToSingle(cantidad * pc);
                    }
                    sumaice += Convert.ToSingle(Funcion.reemplazarcaracterViceversa(datosProductoCompra.Rows[i].Cells[5].Value.ToString())) * Convert.ToInt32(datosProductoCompra.Rows[i].Cells[2].Value);
                    sumairbp += Convert.ToSingle(Funcion.reemplazarcaracterViceversa(datosProductoCompra.Rows[i].Cells[6].Value.ToString())) * Convert.ToInt32(datosProductoCompra.Rows[i].Cells[2].Value);
                    if (Convert.ToString(datosProductoCompra.Rows[i + 1].Cells[0].Value) == "")
                    {
                        break;
                    }
                }
                string[] s = cbImpuesto.Text.Split('%');
                float iva = Convert.ToSingle(s[0]) / 100;
                ivatotal = (sumasubiva + sumaice) * iva;
                txtIRBP.Text = Funcion.reemplazarcaracter(Math.Round(sumairbp, 2).ToString("#####0.00"));
                txtICE.Text = Funcion.reemplazarcaracter(Math.Round(sumaice, 2).ToString("#####0.00"));
                txtSubtotal0.Text = Funcion.reemplazarcaracter(Math.Round(sumasubcero, 2).ToString("#####0.00"));
                subtotalPie = sumasubcero + sumasubiva;
                txtSubtotal.Text = Funcion.reemplazarcaracter(Math.Round(subtotalPie, 2).ToString("#####0.00"));
                txtSubtutalIVA.Text = Funcion.reemplazarcaracter(Math.Round(sumasubiva, 2).ToString("#####0.00"));
                txtIVA.Text = Funcion.reemplazarcaracter(Math.Round(ivatotal, 2).ToString("#####0.00"));
                totalpagar = sumairbp + sumaice + subtotalPie + ivatotal;
                txtTotal.Text = Funcion.reemplazarcaracter(Math.Round(totalpagar, 2).ToString("#####0.00"));
                sumasubiva = Convert.ToSingle(Math.Round(sumasubiva, 6));
                ivatotal = Convert.ToSingle(Math.Round(ivatotal, 6));
                sumasubcero = Convert.ToSingle(Math.Round(sumasubcero, 6));
                sumaice = Convert.ToSingle(Math.Round(sumaice, 6));
                sumairbp = Convert.ToSingle(Math.Round(sumairbp, 6));
                subtotalPie = Convert.ToSingle(Math.Round(subtotalPie, 6));
                totalpagar = Convert.ToSingle(Math.Round(totalpagar, 6));
            }
            catch (Exception EX)
            {
            }
        }

        private void dgvProductosIngresos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }


        //FrmProveedores FrmProveedor;
        private void btnProveedor_Click(object sender, EventArgs e)
        {
            
            consultas.BoolLlenarComboBox(cbProveedor, "select IDPROVEEDOR AS Id, NOMBRES AS Texto from TbProveedor");
            //if (!Program.FormularioProveedorCompra)
            //{//FrmProveedores frmProveedor = null;
                Program.FormularioLlamado = true;
                if (FrmPrincipal.FrmProveedor == null || FrmPrincipal.FrmProveedor.IsDisposed)
                {
                    FrmPrincipal.FrmProveedor = new FrmProveedores();
                    FrmPrincipal.FrmProveedor.MdiParent = Program.panelPrincipalVariable;
                    FrmPrincipal.FrmProveedor.BringToFront();
                    FrmPrincipal.FrmProveedor.Show();
                }
                else { FrmPrincipal.FrmProveedor.BringToFront(); }
            //}
        }

        private void OnlyNumbersdgvcheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (datosProductoCompra.CurrentCell == datosProductoCompra.CurrentRow.Cells[2])
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                }
            }
            if (datosProductoCompra.CurrentCell == datosProductoCompra.CurrentRow.Cells[0])
            {
                Funcion.validar_Num_Letras(e);
            }
            if (datosProductoCompra.CurrentCell == datosProductoCompra.CurrentRow.Cells[1])
            {
                Funcion.validar_Num_Letras(e);
            }
            
        }
        private void dgvProductosIngresos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox)
            {
                TextBox txt = e.Control as TextBox;
                txt.KeyPress += OnlyNumbersdgvcheque_KeyPress;
            }
        }

        private void txtOrdenCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcion.Validar_Numeros(e);
        }

        private void txtFlete_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcion.SoloValores(e, txtFlete.Text);
        }
        
        private void txtPlazoOC_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcion.validar_Num_Letras(e);
        }

        private void txtICE_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcion.SoloValores(e, txtICE.Text);
        }

        private void txtIRBP_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcion.SoloValores(e, txtIRBP.Text);
        }

        private void txtSerie1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcion.Validar_Numeros(e);
        }

        private void txtObservacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                dgvProductosIngresos.Focus();
            }
        }
        Consultas objConsulta = new Consultas();
        string cadenaGeneral = "select SERIE1 +''+ SERIE2 +''+ NUMERO AS SERIES , FECHAORDENCOMPRA, NOMBRES, TOTALIVA,"+
" TOTALICE, TOTALIRBP, SUBTOTAL0, SUBTOTALIVA, IMPUESTO, TOTAL"+
" from Vista_InformeCompras", cadeCondicion = "", condicionEntre = "", añoDesde = "",
            fechaDesde = "", añoHasta = "", fechaHasta = "", mesDesde = "", diaDesde = "", mesHasta = "", diaHasta = "",
            cadenaConsultar = "";

        private void txtConsultar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cadeCondicion = " NOMBRES like '%" + txtConsultar.Text + "%'";
                cadeCondicion = cadeCondicion + " or NUMERO like '%" + txtConsultar.Text + "%' or SERIE2 like '%" + txtConsultar.Text + "%' or SERIE2 like '%" + txtConsultar.Text + "%'";
                llenarDgv();
            }
            catch (Exception)
            {
            }
            //---------------------FALTA REALIZAR EL MINIMO Y MAXIMO DE LOS DATA TIME PIKER----------------------------
            //DataTable fechas = objConsulta.BoolDataTable("select FECHA from TbEncabezadoFactura ORDER BY FECHA");
            //dtpDesde.MinDate = Convert.ToDateTime(fechas.Rows[0]);
            //---------------------------------------------------------------------------------------------------------
        }

        public void obtenerFechas()
        {
            añoDesde = Convert.ToString(dtpDesde.Value.Date.Year);
            mesDesde = Convert.ToString(dtpDesde.Value.Date.Month);
            diaDesde = Convert.ToString(dtpDesde.Value.Date.Day);
            fechaDesde = añoDesde + "-" + mesDesde + "-" + diaDesde;
            añoHasta = Convert.ToString(dtpHasta.Value.Date.Year);
            mesHasta = Convert.ToString(dtpHasta.Value.Date.Month);
            diaHasta = Convert.ToString(dtpHasta.Value.Date.Day);
            fechaHasta = añoHasta + "-" + mesHasta + "-" + diaHasta;
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            obtenerFechas();
            condicionEntre = " FECHAORDENCOMPRA between '" + fechaDesde + "' AND '" + fechaHasta + "'";
            //objConsulta.boolLlenarDataGridView(dgvInformeVentas, cadenaConsultar);
            llenarDgv();
        }
        public void llenarDgv()
        {
            string and = "", where = "";
            if (cadeCondicion == "" && condicionEntre == "")
            {
                where = "";
                and = "";
            }
            else if (cadeCondicion != "" || condicionEntre != "")
                where = " where ";
            if (cadeCondicion != "" && condicionEntre != "")
            {
                where = " where ";
                and = " and ";
            }
            cadenaConsultar = cadenaGeneral + where + cadeCondicion + and + condicionEntre;
            //DataTable dt = objConsulta.BoolDataTable(cadenaConsultar);
            objConsulta.boolLlenarDataGrid(dgvInformeCompras, cadenaConsultar, 20, 9, 0);
        }

        private void txtSerie2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcion.Validar_Numeros(e);
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcion.Validar_Numeros(e);
        }

        private void dgvProductosIngresos_Enter(object sender, EventArgs e)
        {
            try
            {
                datosProductoCompra.Rows[0].Cells[0].ReadOnly = false;
            }
            catch (Exception)
            {
            }
            
        }

        private void dgvProductosIngresos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (datosProductoCompra.CurrentCell == datosProductoCompra.CurrentRow.Cells[posicion] && banderaFocoCelda)
                    datosProductoCompra.BeginEdit(true);
                if (datosProductoCompra.CurrentCell == datosProductoCompra.CurrentRow.Cells[2])
                    datosProductoCompra.BeginEdit(true);
                if (datosProductoCompra.CurrentCell == datosProductoCompra.CurrentRow.Cells[3])
                    datosProductoCompra.BeginEdit(true);
                if (datosProductoCompra.CurrentCell == datosProductoCompra.CurrentRow.Cells[4])
                    datosProductoCompra.BeginEdit(true);
                if (datosProductoCompra.CurrentCell == datosProductoCompra.CurrentRow.Cells[5])
                    datosProductoCompra.BeginEdit(true);
                if (datosProductoCompra.CurrentCell == datosProductoCompra.CurrentRow.Cells[6])
                    datosProductoCompra.BeginEdit(true);
                if (datosProductoCompra.CurrentCell == datosProductoCompra.CurrentRow.Cells[7])
                    datosProductoCompra.BeginEdit(true);
                if (datosProductoCompra.CurrentCell == datosProductoCompra.CurrentRow.Cells[8])
                    datosProductoCompra.BeginEdit(true);
                if (datosProductoCompra.CurrentCell == datosProductoCompra.CurrentRow.Cells[9])
                    datosProductoCompra.BeginEdit(true);

            }
            catch (Exception)
            {
            }
        }
        private void txtSerie1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            string ordenNumero = txtOrdenCompra.Text;
            Funcion.Limpiarobjetos(gbEncabezadoCompra);
            incializar();
            txtOrdenCompra.Text = ordenNumero;
        }

        private void btnSalirCompra_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
