using Comisariato.Clases;
using Comisariato.Formularios.Mantenimiento.Inventario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Comisariato.Formularios.Transacciones
{
    public partial class FrmOrdenDeGiro : Form
    {

        string PathLocal = @"C:\Users\Public\Documents\ArchivosXml\Generados\";
        public FrmOrdenDeGiro()
        {
            InitializeComponent();
        }

        Consultas ObjConsul = new Consultas();
        Bitacora bitacora = new Bitacora();
        List<string> parametrosFactu =  new List<string>();
        public void inicializar()
        {
            Funcion.Limpiarobjetos(gbDatosFactura);
            txtSerie1.Text = "";
            txtSerie2.Text = "";
            txtNumero.Text = "";
            txtSerie1.ReadOnly = false;
            txtSerie2.ReadOnly = false;
            txtNumero.ReadOnly = false;
            txtConcepto.Text = "";
            cbSustentoTributario.Text = "";
            cbTipo.SelectedIndex = 0;
            cbAutorizacionSRI.SelectedIndex = 0;
            Funcion.Limpiarobjetos(gbDatosAutorizacion);
            dgvDatosLibroDiario.Rows.Clear();
            dgvDatosRetencion.Rows.Clear();
            for (int i = 0; i < 7; i++)
            {
                dgvDatosLibroDiario.Rows.Add();
            }
            for (int i = 0; i < 14; i++)
            {
                dgvDatosRetencion.Rows.Add();
            }
            for (int i = 0; i < 25; i++)
            {
                dgvDatosOG.Rows.Add();
            }
        }
        public string agregra0Decimal(string valor)
        {
            
            int i;
            int ocurrencias = valor.Split('.').Length - 1;
            if (ocurrencias == 0)
            {
                valor += ".0";
            }
            string[] s = valor.Split('.');
            for (i = 0; i < s[1].Length;)
            {
                i++;
            }
            if (i < 4)
            {
                for (int j = i; j < 4; j++)
                {
                    s[1] += "0"; 
                }
            }
            return s[0] + "." + s[1];
        }
        public void llenarDatosOG(int ecnabezadoCompra)
        {
            SqlDataReader datos = null;
            datos = ObjConsul.obtenerDatos("select * from TbEncabezadoyPieCompra where IDEMCABEZADOCOMPRA = " + ecnabezadoCompra + "");
            txtNumero.Text = Convert.ToString(datos["NUMERO"]);
            txtSerie1.Text = Convert.ToString(datos["SERIE1"]);
            txtSerie2.Text = Convert.ToString(datos["SERIE2"]);
            cbIVA.Text = Convert.ToString(datos["IMPUESTO"]);
            cbIVA.Enabled = false;
            txtBaseImponible.Text = Funcion.reemplazarcaracter(Convert.ToString(datos["SUBTOTAL"]));
            txtBaseImponible.Text = agregra0Decimal(txtBaseImponible.Text);
            txtICE.Text = Funcion.reemplazarcaracter(Convert.ToString(datos["TOTALICE"]));
            txtICE.Text = agregra0Decimal(txtICE.Text);
            txtIRBP.Text = Funcion.reemplazarcaracter(Convert.ToString(datos["TOTALIRBP"]));
            txtIRBP.Text = agregra0Decimal(txtIRBP.Text);
            txtSubtotalIVA.Text = Funcion.reemplazarcaracter(Convert.ToString(datos["SUBTOTALIVA"]));
            txtSubtotalIVA.Text = agregra0Decimal(txtSubtotalIVA.Text);
            txtSubtotal0.Text = Funcion.reemplazarcaracter(Convert.ToString(datos["SUBTOTAL0"]));
            txtSubtotal0.Text = agregra0Decimal(txtSubtotal0.Text);
            txtTotal.Text = Funcion.reemplazarcaracter(Convert.ToString(datos["TOTAL"]));
            txtTotal.Text = agregra0Decimal(txtTotal.Text);
            txtIVA.Text = Funcion.reemplazarcaracter(Convert.ToString(datos["TOTALIVA"]));
            txtIVA.Text = agregra0Decimal(txtIVA.Text);
            datos = ObjConsul.obtenerDatos("select PROVEEDORRISE from TbProveedor where IDPROVEEDOR = " + CmbProveedor.SelectedValue + "");
            ckbRISE.Checked = Convert.ToBoolean(datos["PROVEEDORRISE"]);

            //objData = ObjConsul.BoolDataTable("select * from TbEncabezadoyPieCompra where IDEMCABEZADOCOMPRA = " + idEncabezadoOG + "");
            //txtNumero.Text = objData.["NUMERO"].ToString();
            DataTable datosRetencion = new DataTable();
            datosRetencion = ObjConsul.BoolDataTable("select * from VistaRetencion where IDPROVEEDOR = " + CmbProveedor.SelectedValue + "");
            //DataRow myRow = datosRetencion.Rows[0];
            for (int i = 0; i < datosRetencion.Rows.Count; i++)
            {
                DataRow myRow = datosRetencion.Rows[i];
                dgvDatosRetencion.Rows[i].Cells[0].Value = myRow["DESCRIPCION"];
                dgvDatosRetencion.Rows[i].Cells[2].Value = myRow["RETENCION"];
                if (myRow["CODIGO"].ToString() == "COD_RET_FUE")
                {
                    dgvDatosRetencion.Rows[i].Cells[1].Value = "FUENTE";

                }
                else
                {
                    dgvDatosRetencion.Rows[i].Cells[1].Value = "IVA";
                }
                dgvDatosRetencion.Rows[i].Cells[3].Value = txtBaseImponible.Text;
                dgvDatosRetencion.Rows[i].Cells[4].Value = Funcion.reemplazarcaracter(((Convert.ToSingle(Funcion.reemplazarcaracterViceversa(dgvDatosRetencion.Rows[i].Cells[3].Value.ToString())) * Convert.ToSingle(dgvDatosRetencion.Rows[i].Cells[2].Value)) / 100).ToString());
                dgvDatosRetencion.Rows[i].Cells[6].Value = Convert.ToDateTime(myRow["FECHAVALIDODESDE"]).ToShortDateString() + " - " + Convert.ToDateTime(myRow["FECHAVALIDOHASTA"]).ToShortDateString();
                dgvDatosRetencion.Rows[i].Cells[7].Value = Convert.ToInt32(myRow["IDCODIGOSRI"]);
                dgvDatosRetencion.Rows[i].Cells[8].Value = Convert.ToInt32(myRow["CODIGOSRI"]);
                dgvDatosRetencion.Rows[i].Cells[9].Value = Convert.ToInt32(myRow["IDTIPOCODIGOSRI"]);
            }
            float sumaRetencion = 0.0f;
            for (int i = 0; i < dgvDatosRetencion.RowCount - 1; i++)
            {
                sumaRetencion = sumaRetencion + Convert.ToSingle(Funcion.reemplazarcaracterViceversa(Convert.ToString(dgvDatosRetencion.Rows[i].Cells[4].Value)));
                if (Convert.ToString(dgvDatosRetencion.Rows[i + 1].Cells[0].Value) == "")
                    break;
            }
            float valorPagar = Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtTotal.Text)) - sumaRetencion;
            txtValorPagar.Text = Funcion.reemplazarcaracter(valorPagar.ToString("##.0000"));
        }

        private void FrmOrdenDeGiro_Load(object sender, EventArgs e)
        {
            Program.FormularioOrdenGiro = true;
            
            inicializar();
            ObjConsul = new Clases.Consultas();
            ObjConsul.BoolLlenarComboBox(CmbProveedor, "Select IDPROVEEDOR AS ID , NOMBRES AS TEXTO from TbProveedor");
            // hacer aparecer un scrollBar, poniendo un limite de item que aparezcan
            CmbProveedor.DropDownHeight = CmbProveedor.ItemHeight = 100;
            ObjConsul.BoolLlenarComboBox(CmbTipoDocumento, "Select IDTIPODOCUMENTO ID, NOMBREDOCUMENTO AS TEXTO from TbTipoDocumento");
            // hacer aparecer un scrollBar, poniendo un limite de item que aparezcan
            CmbTipoDocumento.DropDownHeight = CmbTipoDocumento.ItemHeight = 100;
            cbTipo.SelectedIndex = 0;
            cbAutorizacionSRI.SelectedIndex = 0;
            int idOrdenGiro = ObjConsul.ObtenerID("IDORDENGIRO", "TbEncabezadoOrdenGiro", "");
            int NordenGiro = 1 + ObjConsul.ObtenerID("NUMEROORDENGIRO", "TbEncabezadoOrdenGiro", " where IDORDENGIRO =" + idOrdenGiro + "");
            txtOrdenGiro.Text = NordenGiro.ToString();
            if (Program.FormularioLlamado)
            {
                int idEncabezadoOG = FrmCompra.IDEncabezadoCompraOG;
                //FrmCompra.IDEncabezadoCompraOG;
                ObjConsul.BoolLlenarComboBox(CmbProveedor, "Select P.IDPROVEEDOR as ID,  P.NOMBRES as Texto from TbProveedor P , TbEncabezadoyPieCompra E where E.IDPROVEEDOR = P.IDPROVEEDOR and E.IDEMCABEZADOCOMPRA = " + idEncabezadoOG + "");
                CmbProveedor.Enabled = false;
                ObjConsul.BoolLlenarComboBox(cbSustentoTributario, "Select C.IDCODIGOSRI as ID,  C.DESCRIPCION as Texto from TbProveedor P, TbCodigoSRI C  where  P.CREDITO = C.IDCODIGOSRI and  P.IDPROVEEDOR = " + CmbProveedor.SelectedValue + "");
                cbSustentoTributario.Enabled = false;
                txtNumero.ReadOnly = true;
                txtSerie1.ReadOnly = true;
                txtSerie2.ReadOnly = true;
                llenarDatosOG(idEncabezadoOG);
                Program.FormularioLlamado = false;
            }
            else
            {
                inicializar();
                ObjConsul.BoolLlenarComboBox(cbSustentoTributario, "Select C.IDCODIGOSRI as ID,  C.DESCRIPCION as Texto from TbProveedor P, TbCodigoSRI C  where  P.CREDITO = C.IDCODIGOSRI and  P.IDPROVEEDOR = " + CmbProveedor.SelectedValue + "");
                cbSustentoTributario.Enabled = false;            
            }
           ObjConsul.seriesDocumentoRetencion(txtNumeroRetencion, txtSerie1Retencion, txtSerie2Retencion, txtAutorizacionRetencion, "RET", bitacora.LocalIPAddress());

            DataTable dt = ObjConsul.BoolDataTable("Select CONTRIBUYENTEESPECIAL, NUMERORESOLUCION from TbParametrosFactura;");
            //Verificar si tiene Datos
            if (dt.Rows.Count > 0)
            {
                DataRow myRow = dt.Rows[0];
                if (Convert.ToBoolean(myRow["CONTRIBUYENTEESPECIAL"]))
                {
                    parametrosFactu.Add(myRow["CONTRIBUYENTEESPECIAL"].ToString());
                    parametrosFactu.Add(myRow["NUMERORESOLUCION"].ToString());
                }
                else
                {
                    parametrosFactu.Add("No");
                    parametrosFactu.Add("No");
                }
            }
            

        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSerie1.Text != "" && txtSerie2.Text != "" && txtNumero.Text != "")
                {
                    string condicion = "where SERIE1 = " + Convert.ToInt32(txtSerie1.Text) + " AND SERIE2 = " + Convert.ToInt32(txtSerie2.Text) + " AND NUMERO = " + Convert.ToInt32(txtNumero.Text) + " AND IDPROVEEDOR = " + Convert.ToInt32(CmbProveedor.SelectedValue);
                    string valor = ObjConsul.ObtenerValorCampo("IDEMCABEZADOCOMPRA", "TbEncabezadoyPieCompra", condicion);
                    if (valor != "")
                    {
                        int IDEncabezadoCompraOG = Convert.ToInt32(valor);
                        llenarDatosOG(IDEncabezadoCompraOG);
                    }
                    else
                    {
                        //MessageBox.Show("No existe registro para este #factura del proveedor seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        inicializar();
                    }
                }
                
            }
            catch (Exception ex)
            {
            }
        }

        private void CmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            inicializar();
            ObjConsul.BoolLlenarComboBox(cbSustentoTributario, "Select C.IDCODIGOSRI as ID,  C.DESCRIPCION as Texto from TbProveedor P, TbCodigoSRI C  where  P.CREDITO = C.IDCODIGOSRI and  P.IDPROVEEDOR = " + CmbProveedor.SelectedValue + "");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcion.Validar_Numeros(e);
        }

        private void txtNAutorizacion_Enter(object sender, EventArgs e)
        {
            if (cbAutorizacionSRI.SelectedIndex == 0)
            {
                txtNAutorizacion.MaxLength = 49;
            }
            else if (cbAutorizacionSRI.SelectedIndex == 1)
            {
                txtNAutorizacion.MaxLength = 10;
            }
        }

        private void txtPlazo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcion.Validar_Numeros(e);
            
        }

        private void txtPlazo_TextChanged(object sender, EventArgs e)
        {
           // txtPlazo.Text += "Días";
        }

        private void cbAutorizacionSRI_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNAutorizacion.Text = "";
        }

        private void txtValorPagar_TextChanged(object sender, EventArgs e)
        {
            float saldo = 0.0f;
            try
            {

                saldo = Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtTotal.Text)) - Convert.ToSingle(Funcion.reemplazarcaracterViceversa(txtValorPagar.Text));
                if (saldo < 0)
                {
                    txtSaldo.Text = "";
                }
                else
                {
                    txtSaldo.Text = Funcion.reemplazarcaracter(saldo.ToString("0.0000"));
                }
            }
            catch (Exception)
            {
            }
            if (txtValorPagar.Text == "")
            {
                txtSaldo.Text = "";
            }
        }

        private void txtValorPagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcion.SoloValores(e, txtValorPagar.Text);
        }

        private void btnContabilizar_Click(object sender, EventArgs e)
        {
            if(txtValorPagar.Text != "" && txtConcepto.Text != "" && cbFormaPago.Text != "")
            {
                dgvDatosLibroDiario.Rows.Clear();
                for (int i = 0; i < 5; i++)
                {
                    dgvDatosLibroDiario.Rows.Add();
                }
                //fila 0 para inventario 0%
                dgvDatosLibroDiario.Rows[0].Cells[2].Value = txtSubtotal0.Text;
                dgvDatosLibroDiario.Rows[0].Cells[0].Value = "101.03.03.01 - Inventario 0%";
                //fila 0 para inventario 12%
                dgvDatosLibroDiario.Rows[1].Cells[2].Value = txtSubtotalIVA.Text;
                dgvDatosLibroDiario.Rows[1].Cells[0].Value = "101.03.03.02 - Inventario 12%";
                //fila 0 para iva
                dgvDatosLibroDiario.Rows[2].Cells[2].Value = txtIVA.Text;
                dgvDatosLibroDiario.Rows[2].Cells[0].Value = "101.05.01.01 - IVA";
                //fila 0 para ice
                dgvDatosLibroDiario.Rows[3].Cells[2].Value = txtICE.Text;
                dgvDatosLibroDiario.Rows[3].Cells[0].Value = "ICE";
                //fila 0 para irbp
                dgvDatosLibroDiario.Rows[4].Cells[2].Value = txtIRBP.Text;
                dgvDatosLibroDiario.Rows[4].Cells[0].Value = "IRBP";
                int contadorFilaLibroDiario = 5;
                
                for (int i = 0; i < dgvDatosRetencion.RowCount - 1; i++)
                {
                    if (contadorFilaLibroDiario < dgvDatosLibroDiario.RowCount - 1)
                    {
                        dgvDatosLibroDiario.Rows[contadorFilaLibroDiario].Cells[3].Value = dgvDatosRetencion.Rows[i].Cells[4].Value;
                        string concepto = Convert.ToString(dgvDatosRetencion.Rows[i].Cells[0].Value) + "(" + Convert.ToString(dgvDatosRetencion.Rows[i].Cells[1].Value) + ")";
                        dgvDatosLibroDiario.Rows[contadorFilaLibroDiario].Cells[0].Value = concepto;
                        contadorFilaLibroDiario++;                        
                    }
                    else
                    {
                        dgvDatosLibroDiario.Rows.Add();
                        i--;
                        //contadorFilaLibroDiario--;
                    }
                    if (dgvDatosRetencion.Rows[i + 1].Cells[4].Value == null)
                    {
                        break;
                    }
                }
                dgvDatosLibroDiario.Rows.Add();
                dgvDatosLibroDiario.Rows[contadorFilaLibroDiario].Cells[3].Value = txtValorPagar.Text;
                if (txtPlazo.Text == "0")
                {
                    //dgvDatosLibroDiario.Rows.Add();
                    if (cbFormaPago.SelectedIndex == 0)
                    {
                        dgvDatosLibroDiario.Rows[contadorFilaLibroDiario].Cells[0].Value = "101.01.01 - CAJA";
                    }
                    else
                    {
                        dgvDatosLibroDiario.Rows[contadorFilaLibroDiario].Cells[0].Value = "101.01.02 - BANCO";
                    }                    
                }
                else
                {
                    dgvDatosLibroDiario.Rows[contadorFilaLibroDiario].Cells[0].Value = "CTA X PAGAR";
                }
                for (int i = 0; i < dgvDatosLibroDiario.RowCount - 1 ; i++)
                {
                    dgvDatosLibroDiario.Rows[i].Cells[4].Value = txtConcepto.Text;
                }
                quitarValores0DGVLD();
                calcularLibroDiario();
            }
            else
            {
                MessageBox.Show("Debe ingresar los datos necesarios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void quitarValores0DGVLD()
        {
            int columna;
            for (int i = 0; i < dgvDatosLibroDiario.RowCount -1; i++)
            {
                if (dgvDatosLibroDiario.Rows[i].Cells[2].Value != null)
                {
                    columna = 2;
                }
                else
                    columna = 3;
                if (Convert.ToString(dgvDatosLibroDiario.Rows[i].Cells[columna].Value) == "0.0000")
                {
                    dgvDatosLibroDiario.Rows.Remove(dgvDatosLibroDiario.Rows[i]);
                }
            }
        }
        public void calcularLibroDiario()
        {
            float sumaDebe = 0.0f, sumaHaber = 0.0f;
            for (int i = 0; i < dgvDatosLibroDiario.RowCount - 1; i++)
            {
                if (dgvDatosLibroDiario.Rows[i].Cells[2].Value != null)
                {
                    sumaDebe = sumaDebe + Convert.ToSingle(Funcion.reemplazarcaracterViceversa(dgvDatosLibroDiario.Rows[i].Cells[2].Value.ToString()));
                }
                else
                    sumaHaber = sumaHaber + Convert.ToSingle(Funcion.reemplazarcaracterViceversa(dgvDatosLibroDiario.Rows[i].Cells[3].Value.ToString()));
            }
            txtTotalDebe.Text = Funcion.reemplazarcaracter(sumaDebe.ToString());
            txtTotalHaber.Text = Funcion.reemplazarcaracter(sumaHaber.ToString());
        }
        private void btnGuardarProveedor_Click(object sender, EventArgs e)
        {
            if (txtValorPagar.Text != "" && txtConcepto.Text != "" && cbFormaPago.Text != "" && txtNAutorizacion.Text != "" && cbTipo.Text != "")
            {
                string idEncabezado = ObjConsul.ObtenerValorCampo("IDEMCABEZADOCOMPRA", "TbEncabezadoyPieCompra", " WHERE SERIE1 ="+ txtSerie1.Text + " AND SERIE2 =" + txtSerie2.Text + " AND NUMERO = " + txtNumero.Text + "");
                EncabezadoOrdenGiro objEncabezadoOG = new EncabezadoOrdenGiro(Convert.ToInt32(txtOrdenGiro.Text), Convert.ToInt32(CmbTipoDocumento.SelectedValue), Convert.ToInt32(CmbProveedor.SelectedValue), cbTipo.Text, txtPlazo.Text,
                    txtConcepto.Text, txtNAutorizacion.Text, txtNumero.Text, Convert.ToInt32(txtSerie1.Text), Convert.ToInt32(txtSerie2.Text), ckbRISE.Checked, ckbDeclaraSRI.Checked, ckbManual.Checked,
                    dtpFechaDocumentacion.Value, dtpFechaContabilizacion.Value, dtpFechaOrdenGiro.Value, dtpFechaVigente.Value, Convert.ToInt32(idEncabezado), Convert.ToSingle(Funcion.reemplazarcaracter(txtValorPagar.Text)),
                    Convert.ToSingle(Funcion.reemplazarcaracter(txtSaldo.Text)), dtpFechaRetencion.Value, dtpFechaVenceDocumento.Value, Convert.ToInt32(txtSerie1Retencion.Text), Convert.ToInt32(txtSerie2Retencion.Text),
                    Convert.ToInt32(txtNumeroRetencion.Text), txtAutorizacionRetencion.Text, Convert.ToSingle(Funcion.reemplazarcaracter(txtTotalDebe.Text)), Convert.ToSingle(Funcion.reemplazarcaracter(txtTotalHaber.Text)), 
                    cbAutorizacionSRI.Text);
                string resultado =  objEncabezadoOG.InsertarEncabezadoOrden(objEncabezadoOG);
                if (resultado == "Datos Guardados")
                {
                    if (Convert.ToString(dgvDatosRetencion.Rows[0].Cells[0].Value) != "")
                    {
                        string valor = ObjConsul.ObtenerValorCampo("IDORDENGIRO", "TbEncabezadoOrdenGiro", " WHERE IDPROVEEDOR = "+ CmbProveedor.SelectedValue +" AND SERIE1PROVEEDOR = "+ Convert.ToInt32(txtSerie1.Text) + " AND SERIE2PROVEEDOR = "+ Convert.ToInt32(txtSerie2.Text) +" AND NUMERODOCUMENTOPROVEEDOR = "+ Convert.ToInt32(txtNumero.Text) + "");
                        if (valor != "")
                        {
                            int idEncabezadoOrdenGiro = Convert.ToInt32(valor);
                            for (int i = 0; i < dgvDatosRetencion.RowCount - 1; i++)
                            {
                                DetalleOrdenGiro objDetalleOG = new DetalleOrdenGiro(idEncabezadoOrdenGiro, Convert.ToInt32(dgvDatosRetencion.Rows[i].Cells[7].Value), 
                                    Convert.ToSingle(Funcion.reemplazarcaracterViceversa(dgvDatosRetencion.Rows[i].Cells[4].Value.ToString())));
                                objDetalleOG.InsertarDetalledoOrden(objDetalleOG);
                                objEncabezadoOG.InsertarAutorizacionProveedor(txtSerie1.Text, txtSerie2.Text, txtNAutorizacion.Text, Convert.ToInt32(CmbProveedor.SelectedValue));
                                if (Convert.ToString(dgvDatosRetencion.Rows[i+1].Cells[0].Value) == "")
                                {
                                    break;
                                }
                            }
                            
                        }                        
                    }
                    string numeroRetencion = (Convert.ToInt32(txtNumeroRetencion.Text) + 1).ToString("D9");                    
                    ObjConsul.EjecutarSQL("UPDATE [dbo].[TbCajasTalonario] SET [DOCUMENTOACTUAL] = '"+ numeroRetencion +"' WHERE SERIE1 = '"+ txtSerie1Retencion.Text + "' and SERIE2 = '" + txtSerie2Retencion.Text + "' and IPESTACION = '" + bitacora.LocalIPAddress() + "' and TIPODOCUMENTO = 'RET'");
                    MessageBox.Show("Registrado Corsrectamente ", "Exito", MessageBoxButtons.OK);
                    ObjConsul.seriesDocumentoRetencion(txtNumeroRetencion, txtSerie1Retencion, txtSerie2Retencion, txtAutorizacionRetencion, "RET", bitacora.LocalIPAddress());
                    txtOrdenGiro.Text = (Convert.ToInt32(ObjConsul.ObtenerID("NUMEROORDENGIRO", "TbEncabezadoOrdenGiro", "")) + 1).ToString();

<<<<<<< HEAD
                    XmlRetencion xmlRetencion = new XmlRetencion();
                    InfoTributaria infotribu = new InfoTributaria(1, 1, Program.razonsocialempresa, Program.nombreempresa, Program.rucempresa, "07", txtSerie1.Text, txtSerie2.Text, txtNumero.Text, Program.direccionempresa);
                    if (!Directory.Exists(PathLocal))
                    {
                        Directory.CreateDirectory(PathLocal);
                    }
                    string serie = txtSerie1.Text + txtSerie2.Text;
                    string fecha = DateTime.Now.Date.ToShortDateString();
=======
                    //XmlRetencion xmlRetencion = new XmlRetencion();
                    //var ruta = ConfigurationManager.AppSettings["XmlRetencion"];
                    //xmlRetencion._crearXml(ruta, "comprobanteRetencion");


                    //InfoTributaria infotribu = new InfoTributaria(1, 1, Program.razonsocialempresa, Program.nombreempresa, Program.rucempresa, "07", txtSerie1.Text, txtSerie2.Text, txtNumero.Text, Program.direccionempresa);
                    //string serie = txtSerie1.Text + txtSerie2.Text;
                    //xmlRetencion.InfoTributaria("infoTributaria", infotribu, serie);
>>>>>>> fe3cb516234c532a5adb1c85682c8e342ec8d0d6

                    string claveacceso = infotribu.GenerarClaveAcceso(fecha, "1", serie);
                    var ruta = ConfigurationManager.AppSettings["XmlServidor"];
                    xmlRetencion._crearXml(PathLocal+@"\" + claveacceso + ".xml", "comprobanteRetencion");
                    string pathfinal = PathLocal + @"\" + claveacceso + ".xml";

<<<<<<< HEAD

                    //InfoTributaria infotribu = new InfoTributaria(1, 1, Program.razonsocialempresa, Program.nombreempresa, Program.rucempresa, "07", txtSerie1.Text, txtSerie2.Text, txtNumero.Text, Program.direccionempresa);

                    xmlRetencion.InfoTributaria("infoTributaria", infotribu, serie, claveacceso);


                    
                    DataTable dt = ObjConsul.BoolDataTable("Select TIPOIDENTIFICACION,IDENTIFICACION,RAZONSOCIAL,NOMBRES from TbProveedor where IDPROVEEDOR = " + CmbProveedor.SelectedValue + ";");
                    DataRow myRow = dt.Rows[0];
                    string periodoFiscal = dtpFechaContabilizacion.Value.Date.Month.ToString();
                    if (myRow["RAZONSOCIAL"] != System.DBNull.Value)
                    {
                        myRow["RAZONSOCIAL"] = myRow["NOMBRES"];
                    }
                    periodoFiscal = periodoFiscal + "/" + dtpFechaContabilizacion.Value.Date.Year.ToString();
                    InfoCompRetencion infoCompReten = new InfoCompRetencion(fecha, Program.direccionempresa, parametrosFactu[1], Program.obligadoContabilidad, myRow["TIPOIDENTIFICACION"].ToString(), myRow["RAZONSOCIAL"].ToString(), myRow["IDENTIFICACION"].ToString(), periodoFiscal);
                    xmlRetencion.infoCompRetencion(infoCompReten);

                    //xmlRetencion.impuestos(dgvDatosRetencion,txtSerie1.Text+txtSerie2.Text+ txtNumero.Text);
                    xmlRetencion.impuestos(dgvDatosRetencion,txtNumero.Text,dtpFechaDocumentacion.Value.Date.ToShortDateString());

                    var PathServer = ConfigurationManager.AppSettings["XmlServidor"];
                    if (Directory.Exists(PathServer + @"\Generados\"))
                    {
                        Directory.CreateDirectory(PathServer + @"\Generados\");
                    }

                    File.Copy(pathfinal, PathServer + @"\Generados\" + @"\" + claveacceso + ".xml", true);

=======
                    //string fecha = DateTime.Now.Date.ToShortDateString();
                    //DataTable dt = ObjConsul.BoolDataTable("Select TIPOIDENTIFICACION,IDENTIFICACION,RAZONSOCIAL from TbProveedor where IDPROVEEDOR = " + CmbProveedor.SelectedValue + ";");
                    //DataRow myRow = dt.Rows[0];
                    //string periodoFiscal = dtpFechaContabilizacion.Value.Date.Month.ToString();
                    //periodoFiscal = periodoFiscal + "/" + dtpFechaContabilizacion.Value.Date.Year.ToString();
                    //InfoCompRetencion infoCompReten = new InfoCompRetencion(fecha, Program.direccionempresa, parametrosFactu[1], Program.obligadoContabilidad, myRow["TIPOIDENTIFICACION"].ToString(), myRow["RAZONSOCIAL"].ToString(), myRow["IDENTIFICACION"].ToString(), periodoFiscal);
                    //xmlRetencion.infoCompRetencion(infoCompReten);

                    ////xmlRetencion.impuestos(dgvDatosRetencion,txtSerie1.Text+txtSerie2.Text+ txtNumero.Text);
                    //xmlRetencion.impuestos(dgvDatosRetencion,txtNumero.Text,dtpFechaDocumentacion.Value.Date.ToShortDateString());
>>>>>>> fe3cb516234c532a5adb1c85682c8e342ec8d0d6
                    inicializar();
                }
                else if (resultado == "Error al Registrar")
                {
                    MessageBox.Show("Error al guardar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (resultado == "Existe") { MessageBox.Show("Ya Existe la orden de giro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
            {
                MessageBox.Show("Ingrese todos los datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CmbProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void btnSalirCompra_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiarProveedor_Click(object sender, EventArgs e)
        {
            inicializar();
        }

        private void ImpresionOG_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //try
            //{
            //    //LadoDerecho
            //    //Fijos
            //    e.Graphics.DrawString("Orden de Giro#:", new Font("Verdana", 14, FontStyle.Bold), Brushes.Black, 25, 25);
            //    e.Graphics.DrawString(txtOrdenGiro.Text, new Font("Verdana", 14, FontStyle.Italic), Brushes.Black, 200, 25);
            //    e.Graphics.DrawString("Empresa: ", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 25, 50);
            //    string empresa = ObjConsul.ObtenerValorCampo("NOMBRE", "TbEmpresa", "WHERE IDEMPRESA = " + Program.IDEMPRESA);
            //    e.Graphics.DrawString(empresa, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, 50);
            //    //Variar
            //    e.Graphics.DrawString("Gira A: ", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 25, 70);
            //    e.Graphics.DrawString("Concepto: ", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 25, 90);
            //    float lineasConcepto = Convert.ToSingle(txtConcepto.TextLength) / 47;
            //    string concepto = "";
            //    int cantidadCaracteres = Convert.ToInt32(txtConcepto.TextLength);
            //    int posicion = 0, y = 90;
            //    if (lineasConcepto > 1)
            //        for (int i = 0; i < Math.Ceiling(lineasConcepto); i++)
            //        {
            //            if (cantidadCaracteres >= 47)
            //            {
            //                cantidadCaracteres = Math.Abs(cantidadCaracteres - 47);
            //                concepto = txtConcepto.Text.Substring(posicion, 47);
            //                posicion = 47 * (i + 1);
            //            }
            //            else
            //            {
            //                concepto = txtConcepto.Text.Substring(posicion, cantidadCaracteres);
            //                posicion = cantidadCaracteres;
            //            }
            //            e.Graphics.DrawString(concepto, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, y);
            //            y = y + 20;
            //        }
            //    else
            //    {
            //        e.Graphics.DrawString(txtConcepto.Text, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, y);
            //        y = y + 20;
            //    }
            //    e.Graphics.DrawString("N° Factura:", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 25, y);
            //    e.Graphics.DrawString(txtSerie1.Text + "-" + txtSerie2.Text + "-" + txtNumero.Text, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, y);
            //    //Mitad
            //    e.Graphics.DrawString("Declara SRI:", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 350, y);
            //    string declaraSRI = "";
            //    if (ckbDeclaraSRI.Checked)
            //        declaraSRI = "Sí";

            //    else
            //        declaraSRI = "No";

            //    e.Graphics.DrawString(declaraSRI, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 450, y);
            //    e.Graphics.DrawString("Autorización:", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 25, y = y + 20);
            //    e.Graphics.DrawString(txtAutorizacionRetencion.Text, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, y);
            //    //Sustento Tributario mas largo q la hoja
            //    e.Graphics.DrawString("Sustento Tributario:", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 25, y = y + 20);
            //    string sustento = cbSustentoTributario.Text;
            //    lineasConcepto = Convert.ToSingle(sustento.Length) / 110;
            //    string sustentoTributario = "";
            //    cantidadCaracteres = Convert.ToInt32(sustento.Length);
            //    posicion = 0;
            //    if (lineasConcepto > 1)
            //        for (int i = 0; i < Math.Ceiling(lineasConcepto); i++)
            //        {
            //            if (cantidadCaracteres >= 110)
            //            {
            //                cantidadCaracteres = Math.Abs(cantidadCaracteres - 110);
            //                sustentoTributario = sustento.Substring(posicion, 110);
            //                posicion = 110 * (i + 1);
            //            }
            //            else
            //            {
            //                sustentoTributario = sustento.Substring(posicion, cantidadCaracteres);
            //                posicion = cantidadCaracteres;
            //            }
            //            e.Graphics.DrawString(sustentoTributario, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, y);
            //            y = y + 20;
            //        }
            //    else
            //    {
            //        e.Graphics.DrawString(sustento, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, y);
            //        y = y + 20;
            //    }
            //    e.Graphics.DrawString("Base Imponible:", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 25, y);
            //    e.Graphics.DrawString(txtBaseImponible.Text, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, y);
            //    e.Graphics.DrawString("Total:", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 25, y = y + 20);
            //    e.Graphics.DrawString(txtTotal.Text, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, y);
            //    e.Graphics.DrawString("Tipo Transacción:", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 500, y);
            //    e.Graphics.DrawString(cbTipo.Text, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 675, y);
            //    e.Graphics.DrawString("Valor a Pagar:", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 25, y = y + 20);
            //    e.Graphics.DrawString(txtValorPagar.Text, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, y);
            //    e.Graphics.DrawString("Saldo:", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 500, y);
            //    e.Graphics.DrawString(txtSaldo.Text, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 675, y);
            //    //Lado Izquierdo
            //    e.Graphics.DrawString("Usuario: ", new Font("Verdana", 8, FontStyle.Bold), Brushes.Gray, 675, 20);
            //    string usurio = ObjConsul.ObtenerValorCampo("USUARIO", "TbUsuario", "WHERE IDUSUARIO = " + Program.IDUsuarioMenu);
            //    e.Graphics.DrawString(usurio, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 750, 20);
            //    e.Graphics.DrawString(Convert.ToString(DateTime.Now), new Font("Verdana", 8, FontStyle.Regular), Brushes.Gray, 675, 35);
            //    e.Graphics.DrawString("Fecha Factura:", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 500, 70);
            //    e.Graphics.DrawString(Convert.ToString(dtpFechaDocumentacion.Value), new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 675, 70);
            //    e.Graphics.DrawString("Fecha Contabilización:", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 500, 90);
            //    e.Graphics.DrawString(Convert.ToString(dtpFechaContabilizacion.Value), new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 675, 90);
            //    e.Graphics.DrawString("Fecha Vencimiento:", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 500, 110);
            //    e.Graphics.DrawString(Convert.ToString(dtpFechaVenceDocumento.Value), new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 675, 110);

            //    //DGV Retencion

            //    dibujarRayas(ref y, 30, 2);
            //    e.Graphics.DrawLine(blackPen, puntoInicio, puntoFinal);

            //    e.Graphics.DrawString("Retencion SRI", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 50, y + 2);
            //    e.Graphics.DrawString("Tipo", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 260, y + 2);
            //    e.Graphics.DrawString("%", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 310, y + 2);
            //    e.Graphics.DrawString("Monto", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 410, y + 2);
            //    e.Graphics.DrawString("Cta. Contable", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 490, y + 2);
            //    e.Graphics.DrawString("fecha Vigente", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 650, y + 2);

            //    dibujarRayas(ref y, 20, 2);
            //    e.Graphics.DrawLine(blackPen, puntoInicio, puntoFinal);

            //    for (int i = 0; i < dgvDatosRetencion.RowCount - 1; i++)
            //    {
            //        if (Convert.ToString(dgvDatosRetencion.Rows[i].Cells[1].Value) == "RETENCION")
            //            e.Graphics.DrawString("RTF", new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 260, y);
            //        else
            //            e.Graphics.DrawString("IVA", new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 260, y);
            //        e.Graphics.DrawString(Convert.ToString(dgvDatosRetencion.Rows[i].Cells[2].Value), new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 310, y);
            //        e.Graphics.DrawString(Convert.ToString(dgvDatosRetencion.Rows[i].Cells[4].Value), new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 410, y);
            //        e.Graphics.DrawString(Convert.ToString(dgvDatosRetencion.Rows[i].Cells[5].Value), new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 490, y);
            //        e.Graphics.DrawString(Convert.ToString(dgvDatosRetencion.Rows[i].Cells[6].Value), new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 625, y);
            //        string planCuenta = Convert.ToString(dgvDatosRetencion.Rows[i].Cells[0].Value);
            //        float lineasCuenta = Convert.ToSingle(planCuenta.Length) / 35;
            //        string plan = "";
            //        cantidadCaracteres = Convert.ToInt32(planCuenta.Length);
            //        posicion = 0;
            //        bool banderaAumento = false;
            //        if (lineasCuenta > 1)
            //            for (int j = 0; j < Math.Ceiling(lineasCuenta); j++)
            //            {
            //                if (cantidadCaracteres >= 35)
            //                {
            //                    cantidadCaracteres = Math.Abs(cantidadCaracteres - 35);
            //                    plan = planCuenta.Substring(posicion, 35);
            //                    posicion = 35 * (j + 1);
            //                }
            //                else
            //                {
            //                    plan = planCuenta.Substring(posicion, cantidadCaracteres);
            //                    posicion = cantidadCaracteres;
            //                }
            //                e.Graphics.DrawString(plan, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 25, y);
            //                //dibujarRayas(ref y, 22, 1);
            //                //e.Graphics.DrawLine(blackPen, puntoInicio, puntoFinal);
            //                y = y + 22;
            //                banderaAumento = true;
            //            }
            //        else
            //        {
            //            e.Graphics.DrawString(planCuenta, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 25, y);
            //            dibujarRayas(ref y, 22, 1);
            //            e.Graphics.DrawLine(blackPen, puntoInicio, puntoFinal);
            //        }

            //        if (Convert.ToString(dgvDatosRetencion.Rows[i + 1].Cells[0].Value) == "")
            //            break;
            //        if (!banderaAumento)
            //            y = y + 2;
            //        else
            //        {
            //            dibujarRayas(ref y, 2, 1);
            //            e.Graphics.DrawLine(blackPen, puntoInicio, puntoFinal);
            //        }

            //    }

            //    e.Graphics.DrawString("Saldo Total:", new Font("Verdana", 10, FontStyle.Bold), Brushes.Black, 260, y = y + 2);
            //    e.Graphics.DrawString(txtTotal.Text, new Font("Verdana", 10, FontStyle.Regular), Brushes.Black, 410, y);
            //    e.Graphics.DrawString("Saldo Retención:", new Font("Verdana", 10, FontStyle.Bold), Brushes.Black, 260, y = y + 22);
            //    float sumaRetencion = 0.0f;
            //    for (int i = 0; i < dgvDatosRetencion.RowCount - 1; i++)
            //    {
            //        sumaRetencion = sumaRetencion + Convert.ToSingle(Funcion.reemplazarcaracterViceversa(Convert.ToString(dgvDatosRetencion.Rows[i].Cells[4].Value)));
            //        if (Convert.ToString(dgvDatosRetencion.Rows[i + 1].Cells[0].Value) == "")
            //            break;
            //    }
            //    e.Graphics.DrawString(Funcion.reemplazarcaracter(Convert.ToString(sumaRetencion)), new Font("Verdana", 10, FontStyle.Regular), Brushes.Black, 410, y);
            //    e.Graphics.DrawString("Saldo a Pagar", new Font("Verdana", 10, FontStyle.Bold), Brushes.Black, 260, y = y + 22);
            //    e.Graphics.DrawString(txtValorPagar.Text, new Font("Verdana", 10, FontStyle.Regular), Brushes.Black, 410, y);
            //}
            //catch (Exception)
            //{
            //}

            try
            {
                e.Graphics.DrawString("Orden de Giro#:", new Font("Verdana", 14, FontStyle.Bold), Brushes.Black, 25, 25);
                e.Graphics.DrawString(txtOrdenGiro.Text, new Font("Verdana", 14, FontStyle.Italic), Brushes.Black, 200, 25);
                e.Graphics.DrawString("Proveedor: ", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 25, 70);
                e.Graphics.DrawString(CmbProveedor.Text, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, 70);
                e.Graphics.DrawString("Tipo Documento: ", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 25, 90);
                e.Graphics.DrawString(CmbTipoDocumento.Text, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, 90);
                e.Graphics.DrawString("N° Factura: ", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 25, 110);
                string numeroFactura = txtSerie1.Text + '-' + txtSerie2.Text + '-' + txtNumero.Text;
                e.Graphics.DrawString(numeroFactura, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, 110);
                e.Graphics.DrawString("Autorizacion: ", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 25, 130);
                e.Graphics.DrawString(txtNAutorizacion.Text, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, 130);

                /////////////////////////
                e.Graphics.DrawString("Subtotal 12%: ", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 25, 150);
                e.Graphics.DrawString(txtSubtotalIVA.Text, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, 150);
                e.Graphics.DrawString("Subtotal 0%::", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 25, 170);
                e.Graphics.DrawString(txtSubtotal0.Text, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, 170);
                e.Graphics.DrawString("Subtotal: ", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 25, 190);
                e.Graphics.DrawString(txtBaseImponible.Text, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, 190);
                e.Graphics.DrawString("ICE: ", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 25, 210);
                e.Graphics.DrawString(txtICE.Text, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, 210);
                e.Graphics.DrawString("IVA: ", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 25, 230);
                e.Graphics.DrawString(txtIVA.Text, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, 230);
                e.Graphics.DrawString("IRBP: ", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 25, 250);
                e.Graphics.DrawString(txtIRBP.Text, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, 250);
                e.Graphics.DrawString("N° Retención: ", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 25, 270);
                string retencion = txtSerie1Retencion.Text + '-' + txtSerie2Retencion.Text + '-' + txtNumeroRetencion.Text;
                e.Graphics.DrawString(retencion, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 175, 270);



                e.Graphics.DrawString("Usuario: ", new Font("Verdana", 8, FontStyle.Bold), Brushes.Gray, 675, 20);
                string usurio = ObjConsul.ObtenerValorCampo("USUARIO", "TbUsuario", "WHERE IDUSUARIO = " + Program.IDUsuarioMenu);
                e.Graphics.DrawString(usurio, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 750, 20);
                e.Graphics.DrawString(Convert.ToString(DateTime.Now), new Font("Verdana", 8, FontStyle.Regular), Brushes.Gray, 675, 35);
                e.Graphics.DrawString("Fecha Factura:", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 500, 70);
                e.Graphics.DrawString(Convert.ToString(dtpFechaDocumentacion.Value), new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 675, 70);
                e.Graphics.DrawString("Fecha Contabilización:", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 500, 90);
                e.Graphics.DrawString(Convert.ToString(dtpFechaContabilizacion.Value), new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 675, 90);
                e.Graphics.DrawString("Fecha Vencimiento:", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 500, 110);
                e.Graphics.DrawString(Convert.ToString(dtpFechaVenceDocumento.Value), new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 675, 110);
                e.Graphics.DrawString("Total:", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 500, 150);
                e.Graphics.DrawString(txtTotal.Text, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 675, 150);
                e.Graphics.DrawString("Firma:", new Font("Verdana", 12, FontStyle.Bold), Brushes.Black, 500, 250);

                //DGV Retencion
                int y = 250;
                dibujarRayas(ref y, 40, 2);
                e.Graphics.DrawLine(blackPen, puntoInicio, puntoFinal);

                e.Graphics.DrawString("Año Fiscal", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 50, y + 2);
                e.Graphics.DrawString("Codigo", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 200, y + 2);
                e.Graphics.DrawString("Tipo", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 300, y + 2);
                e.Graphics.DrawString("%", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 375, y + 2);
                e.Graphics.DrawString("Base", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 450, y + 2);
                e.Graphics.DrawString("Monto", new Font("Verdana", 8, FontStyle.Bold), Brushes.Black, 650, y + 2);

                dibujarRayas(ref y, 20, 2);
                e.Graphics.DrawLine(blackPen, puntoInicio, puntoFinal);
                y = y + 5;
                float sumaRetencion = 0.0f;
                for (int i = 0; i < dgvDatosRetencion.RowCount - 1; i++)
                {
                    DateTime fechaactual = DateTime.Today;
                    e.Graphics.DrawString(Convert.ToString(fechaactual.Year), new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 65, y+2);
                    e.Graphics.DrawString(Convert.ToString(dgvDatosRetencion.Rows[i].Cells[8].Value), new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 210, y + 2);
                    if (Convert.ToString(dgvDatosRetencion.Rows[i].Cells[1].Value) == "FUENTE")
                        e.Graphics.DrawString("RTF", new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 300, y + 2);
                    else
                        e.Graphics.DrawString("IVA", new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 300, y + 2);
                    e.Graphics.DrawString(Convert.ToString(dgvDatosRetencion.Rows[i].Cells[2].Value)+"%", new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 375, y + 2);
                    e.Graphics.DrawString(Convert.ToString(dgvDatosRetencion.Rows[i].Cells[3].Value), new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 450, y + 2);
                    e.Graphics.DrawString(Convert.ToString(dgvDatosRetencion.Rows[i].Cells[4].Value), new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, 650, y + 2);
                    y = y + 22;
                    sumaRetencion = sumaRetencion + Convert.ToSingle(Funcion.reemplazarcaracterViceversa(Convert.ToString(dgvDatosRetencion.Rows[i].Cells[4].Value)));
                    if (Convert.ToString(dgvDatosRetencion.Rows[i + 1].Cells[0].Value) == "")
                        break;
                }
                e.Graphics.DrawString("Retención:", new Font("Verdana", 9, FontStyle.Bold), Brushes.Black, 550, y);
                e.Graphics.DrawString(Funcion.reemplazarcaracter(Convert.ToString(sumaRetencion)), new Font("Verdana", 9, FontStyle.Regular), Brushes.Black, 650, y);

            }
            catch (Exception)
            {
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ElegirImpresero.AllowSomePages = true;
            ElegirImpresero.ShowHelp = true;
            ElegirImpresero.Document = ImpresionOG;
            DialogResult result = ElegirImpresero.ShowDialog();
            if (result == DialogResult.OK)
            {
                ImpresionOG.Print();
            }
        }
        Pen blackPen;
        Point puntoInicio;
        Point puntoFinal;
        public void dibujarRayas(ref int y, int sumar, int grosor)
        {
            blackPen = new Pen(Color.Black, grosor);
            puntoInicio = new Point(25, y = y + sumar);
            puntoFinal = new Point(800, y);
        }
    }
}
