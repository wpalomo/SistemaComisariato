﻿using Comisariato.Clases;
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

namespace Comisariato.Formularios.Mantenimiento
{
    public partial class FrmEmpleado : Form
    {
        public FrmEmpleado()
        {
            InitializeComponent();
        }

        Consultas consultas;
        bool bandera_Estado = false;
        String identificacion = "";
        public static String nameFoto = "";
        public OpenFileDialog examinar = new OpenFileDialog();

        byte[] MyDataImagen = new byte[0];

        bool imgenDefault = false;

        private void CkbDiscapacidad_CheckedChanged(object sender, EventArgs e)
        {
            if (CkbDiscapacidad.Checked == true)
            {
                NupDiscapacidad.Enabled = true;
            }
            else { NupDiscapacidad.Enabled = false; }
        }

        private void cargarDatos(string condicion)
        {
            consultas = new Consultas();
            consultas.boolLlenarDataGridView(DgvDatosEmpleado, "Select IDEMPLEADO as ID, IDENTIFICACION as 'CEDULA/RUC', NOMBRES, APELLIDOS,DIRECCION,CELULAR1,CELULAR2,EMAIL from TbEmpleado WHERE ACTIVO =" + condicion + " AND  NOMBRES != 'ADMINISTRADOR';");
            DgvDatosEmpleado.Columns["ID"].Visible = false;
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");
            consultas = new Consultas();
            consultas.BoolLlenarComboBox(CmbPais, "Select IDPAIS as ID, NOMBRE AS Texto from TbPais");
            cmbTipoDocumento.SelectedIndex = 0;
            CmbGenero.SelectedIndex = 0;
            CmbEstadoCivil.SelectedIndex = 0;
            CmbTipoLicencia.SelectedIndex = 0;
            CmbTipoSangre.SelectedIndex = 0;

            // llenar datadrigview solo los activos
            cargarDatos("1");


            // Dimensionar lista combo

            CmbPais.DropDownHeight = CmbPais.ItemHeight = 150;
            CmbProvincia.DropDownHeight = CmbProvincia.ItemHeight = 150;
            CmbCanton.DropDownHeight = CmbCanton.ItemHeight = 150;
            CmbParroquia.DropDownHeight = CmbParroquia.ItemHeight = 150;
            inicializarDatos();
        }
       

        private void CmbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbPais.SelectedValue.ToString() != null)
            {
                String ID = CmbPais.SelectedValue.ToString();
                consultas = new Consultas();
                consultas.BoolLlenarComboBox(CmbProvincia, "Select IDPROVINCIA as ID, NOMBRE AS Texto from TbProvincia where IDPAIS = " + ID + ";");
            }
            CmbPais.DropDownHeight = CmbPais.ItemHeight = 150;
        }

        private void CmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbProvincia.SelectedValue.ToString() != null)
            {
                String ID = CmbProvincia.SelectedValue.ToString();
                consultas = new Consultas();
                consultas.BoolLlenarComboBox(CmbCanton, "Select IDCANTON as ID, NOMBRE AS Texto from TbCanton where IDPROVINCIA = " + ID + ";");
            }
            CmbProvincia.DropDownHeight = CmbProvincia.ItemHeight = 150;
        }

        private void CmbCanton_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbCanton.SelectedValue.ToString() != null)
            {
                String ID = CmbCanton.SelectedValue.ToString();
                consultas = new Consultas();
                consultas.BoolLlenarComboBox(CmbParroquia, "Select IDPARROQUIA as ID, NOMBRE AS Texto from TbParroquia where IDCANTON = " + ID + ";");
            }
            CmbCanton.DropDownHeight = CmbCanton.ItemHeight = 150;
            CmbParroquia.DropDownHeight = CmbParroquia.ItemHeight = 150;

        }

        private void TxtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Funcion.validar_Num_Letras(e);
            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void TxtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcion.SinEspaciosEmail(e);
            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void TxtIdentidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcion.Validar_Numeros(e);
            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void TxtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcion.Validar_Letras(e);
            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void TxtMovimientoQuincenal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcion.SoloValores(e,TxtMovimientoQuincenal.Text);
            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void TxtSueldoExtra_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcion.SoloValores(e, TxtSueldoExtra.Text);
            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void TxtSueldoMensual_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcion.SoloValores(e, TxtSueldoMensual.Text);
            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            examinar.Filter = "Image Files (*.png, *.jpg)|*.png;*.jpg";
            DialogResult dres1 = examinar.ShowDialog();
            if (dres1 == DialogResult.Abort)
                return;
            if (dres1 == DialogResult.Cancel)
                return;
            nameFoto = examinar.FileName;
            PictureFoto.Image = Image.FromFile(examinar.FileName);
        }


        public void inicializarDatos()
        {
            PictureFoto.Image = Comisariato.Properties.Resources.contact;

            Funcion.Limpiarobjetos(groupBox1);

            ckbActivo.Checked = true;

            //Establecer en la primera seleccion los combo
            cmbTipoDocumento.SelectedIndex = 0;
            CmbGenero.SelectedIndex = 0;
            CmbEstadoCivil.SelectedIndex = 0;
            CmbTipoLicencia.SelectedIndex = 0;
            CmbTipoSangre.SelectedIndex = 0;

            //limpiar los textbox
            TxtLibretaMilitar.Text = "";
            TxtMovimientoQuincenal.Text = "0";
            TxtSueldoExtra.Text = "0";
            TxtSueldoMensual.Text = "0";
            TxtCelular1.Text = "0";
            TxtCelular2.Text = "0";
            TxtEmail.Text = "";

            // llenar datadrigview solo los activos
            cargarDatos("1");


            //cbPaisProveedor.SelectedIndex = 0;
            CmbProvincia.SelectedValue = 9;
            CmbCanton.SelectedValue = 80;
            CmbParroquia.SelectedValue = 41;
        }



        private void rbtActivosEmpleado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtActivosEmpleado.Checked)
            {
                cargarDatos("1");
                //DgvDatosEmpleado.Columns[1].HeaderText = "Desabilitar";
            }
            else if (rbtInactivosEmpleado.Checked)
            {
                cargarDatos("0");
                //DgvDatosEmpleado.Columns[1].HeaderText = "Habilitar";
            }
        }

        private void DgvDatosEmpleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvDatosEmpleado.RowCount > 0)
            {

                Empleado ObjEmpleado = new Empleado();
                if (rbtActivosEmpleado.Checked)
                {
                    if (this.DgvDatosEmpleado.Columns[e.ColumnIndex].Name == "Deshabilitar")
                    {
                        ObjEmpleado.EstadoEmpleado(DgvDatosEmpleado.CurrentRow.Cells[3].Value.ToString(), 2);
                        cargarDatos("1");
                    }
                }
                else if (rbtInactivosEmpleado.Checked)
                {
                    if (this.DgvDatosEmpleado.Columns[e.ColumnIndex].Name == "Deshabilitar")
                    {
                        ObjEmpleado.EstadoEmpleado(DgvDatosEmpleado.CurrentRow.Cells[3].Value.ToString(), 1);
                        cargarDatos("0");
                    }
                }

                if (this.DgvDatosEmpleado.Columns[e.ColumnIndex].Name == "Modificar")
                {
                    //MessageBox.Show("modificar toca " + DgvDatosEmpleado.CurrentRow.Cells[3].Value.ToString());
                    identificacion = DgvDatosEmpleado.CurrentRow.Cells[3].Value.ToString();
                    tcEmpleado.SelectedIndex = 0;
                    bandera_Estado = true;
                    //Llenar el DataTable
                    DataTable dt = consultas.BoolDataTable("Select * from TbEmpleado where IDENTIFICACION = '" + identificacion + "'");
                    //Arreglo de byte en donde se almacenara la foto en bytes
                    byte[] MyData = new byte[0];
                    //Verificar si tiene Datos
                    if (dt.Rows.Count > 0)
                    {
                        DataRow myRow = dt.Rows[0];

                        //Se almacena el campo foto de la tabla en el arreglo de bytes
                        MyData = (byte[])myRow["IMAGEN"];
                        MyDataImagen = MyData;
                        //Se inicializa un flujo en memoria del arreglo de bytes
                        MemoryStream stream = new MemoryStream(MyData);
                        //En el picture box se muestra la imagen que esta almacenada en el flujo en memoria 
                        //el cual contiene el arreglo de bytes
                        PictureFoto.Image = Image.FromStream(stream);

                        //Cargar los demas Datos
                        cmbTipoDocumento.SelectedItem = myRow["TIPOIDENTIFICACION"].ToString();
                        TxtIdentidad.Text = myRow["IDENTIFICACION"].ToString();
                        TxtNombres.Text = myRow["NOMBRES"].ToString();
                        TxtApellidos.Text = myRow["APELLIDOS"].ToString();
                        ckbActivo.Checked = Convert.ToBoolean(myRow["ACTIVO"]);
                        TxtDireccion.Text = myRow["DIRECCION"].ToString();
                        //CmbParroquia

                        consultas.LLenarCombosUbicacion(Convert.ToInt32(myRow["IDPARROQUIA"]), ref CmbPais, ref CmbProvincia, ref CmbCanton, ref CmbParroquia);

                        TxtEmail.Text = myRow["EMAIL"].ToString();
                        DtpFechaNacimiento.Value = Convert.ToDateTime(myRow["FECHANACIMIENTO"]);
                        CmbTipoLicencia.SelectedItem = myRow["TIPOLICENCIA"].ToString();
                        CmbTipoSangre.SelectedItem = myRow["TIPOSANGRE"].ToString();
                        TxtLibretaMilitar.Text = myRow["LIBRETAMILITAR"].ToString();
                        CkbDiscapacidad.Checked = Convert.ToBoolean(myRow["DISCAPACIDAD"]);
                        NupDiscapacidad.Value = Convert.ToInt32(myRow["PORCENTAJEDISCAPACIDAD"]);
                        TxtMovimientoQuincenal.Text = myRow["MOVIMIENTOQUINCENAL"].ToString();
                        CmbGenero.SelectedItem = myRow["GENERO"].ToString();
                        CmbEstadoCivil.SelectedItem = myRow["ESTADOCIVIL"].ToString();
                        TxtSueldoMensual.Text = myRow["SUELDOMENSUAL"].ToString();
                        TxtSueldoExtra.Text = myRow["SUELDOEXTRA"].ToString();
                        TxtCelular1.Text = myRow["CELULAR1"].ToString();
                        TxtCelular2.Text = myRow["CELULAR2"].ToString();
                    }
                    btnLimpiar.Text = "&Cancelar";
                    btnGuardar.Text = "&Modificar";
                }
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (rbtActivosEmpleado.Checked)
            {
                consultas.boolLlenarDataGridView(DgvDatosEmpleado, "Select IDEMPLEADO as ID, IDENTIFICACION as 'CEDULA/RUC', NOMBRES, APELLIDOS,DIRECCION,CELULAR1,CELULAR2,EMAIL from TbEmpleado where ACTIVO = 1 and IDENTIFICACION like '%" + TxtBuscar.Text + "%' or NOMBRES like '%" + TxtBuscar.Text + "%' or APELLIDOS like '%" + TxtBuscar.Text + "%' AND  NOMBRES != 'ADMINISTRADOR';");
                DgvDatosEmpleado.Columns[1].HeaderText = "Desabilitar";
                DgvDatosEmpleado.Columns["ID"].Visible = false;
            }
            else if (rbtInactivosEmpleado.Checked)
            {
                consultas.boolLlenarDataGridView(DgvDatosEmpleado, "Select IDEMPLEADO as ID, IDENTIFICACION as 'CEDULA/RUC', NOMBRES, APELLIDOS,DIRECCION,CELULAR1,CELULAR2,EMAIL from TbEmpleado where ACTIVO = 0 and IDENTIFICACION like '%" + TxtBuscar + "%' or NOMBRES like '%" + TxtBuscar.Text + "%' or APELLIDOS like '%" + TxtBuscar.Text + "%' AND  NOMBRES != 'ADMINISTRADOR';");
                DgvDatosEmpleado.Columns[1].HeaderText = "Habilitar";
                DgvDatosEmpleado.Columns["ID"].Visible = false;
            }
        }
        //convert image to bytearray

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            byte[] bitDataFoto;

            if (TxtCelular1.Text == "")
            {
                MessageBox.Show("Ingrese al menos un numero de telefono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (TxtIdentidad.Text != "" && TxtNombres.Text != "" && TxtApellidos.Text != "" && TxtDireccion.Text != "" && TxtCelular1.Text != "")
            {

                if (!bandera_Estado) // Para identificar si se va ingresar
                {
                    //Preguntar si tiene una foto  cargada
                    if (nameFoto == "")
                    {
                        Image img = PictureFoto.Image;
                        bitDataFoto = Funcion.imgToByteArray(img);

                    }
                    else
                    {
                        bitDataFoto = Funcion.ConvertImg_Bytes(nameFoto);
                    }
                    Empleado ObjEmpleado = new Empleado(cmbTipoDocumento.Text, TxtIdentidad.Text, TxtNombres.Text, TxtApellidos.Text,
                        ckbActivo.Checked, TxtDireccion.Text, bitDataFoto, Convert.ToInt32(CmbParroquia.SelectedValue), TxtEmail.Text,
                        DtpFechaNacimiento.Value, CmbTipoLicencia.Text, CmbTipoSangre.Text, TxtLibretaMilitar.Text, CkbDiscapacidad.Checked,
                        Convert.ToInt32(NupDiscapacidad.Value), Convert.ToSingle(TxtMovimientoQuincenal.Text), CmbGenero.Text, CmbEstadoCivil.Text, Convert.ToSingle(TxtSueldoMensual.Text),
                        Convert.ToSingle(TxtSueldoExtra.Text), TxtCelular1.Text, TxtCelular2.Text);

                    String resultado = ObjEmpleado.InsertarEmpleado(ObjEmpleado); // retorna true si esta correcto todo
                    if (resultado == "Datos Guardados")
                    {
                        MessageBox.Show("Cliente Registrado Correctamente ", "Exito", MessageBoxButtons.OK);
                        cargarDatos("1");
                        rbtActivosEmpleado.Checked = true;
                        inicializarDatos();
                    }
                    else if (resultado == "Error al Registrar") { MessageBox.Show("Error al guardar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    else if (resultado == "Existe") { MessageBox.Show("Ya Existe el Empleado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
                else if (bandera_Estado) // Para identificar si se va modificar
                {
                    if (nameFoto != "") // si esta cargada alguna foto guarde la imagen en el arreglo
                    {
                        bitDataFoto = Funcion.ConvertImg_Bytes(nameFoto);
                    }
                    else if (imgenDefault) // Para que se guarde la imgen por defecto si desea cancelar la imagen 
                    {
                        imgenDefault = false;
                        bitDataFoto = MyDataImagen;
                    }
                    else // si no modifica la imagen, que quede la misma
                    {

                        bitDataFoto = MyDataImagen;
                    }

                    Empleado ObjEmpleado = new Empleado(cmbTipoDocumento.Text, TxtIdentidad.Text, TxtNombres.Text, TxtApellidos.Text,
                        ckbActivo.Checked, TxtDireccion.Text, bitDataFoto, Convert.ToInt32(CmbParroquia.SelectedValue), TxtEmail.Text,
                        DtpFechaNacimiento.Value, CmbTipoLicencia.Text, CmbTipoSangre.Text, TxtLibretaMilitar.Text, CkbDiscapacidad.Checked,
                        Convert.ToInt32(NupDiscapacidad.Value), Convert.ToSingle(TxtMovimientoQuincenal.Text), CmbGenero.Text, CmbEstadoCivil.Text, Convert.ToSingle(TxtSueldoMensual.Text),
                        Convert.ToSingle(TxtSueldoExtra.Text), TxtCelular1.Text, TxtCelular2.Text);

                    String Resultado = ObjEmpleado.ModificarEmpleado(identificacion, bitDataFoto); // retorna true si esta correcto todo
                    if (Resultado == "Correcto")
                    {
                        MessageBox.Show("Empleado Actualizado", "Exito");
                        cargarDatos("1");
                        rbtActivosEmpleado.Checked = true;
                        identificacion = "";
                    }
                    else { MessageBox.Show("Error al actualizar Empleado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    inicializarDatos();
                    bandera_Estado = false;
                    btnGuardar.Text = "&Guardar";
                    MyDataImagen = null;
                }

            }
            else { MessageBox.Show("Ingrese los datos del Empleado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (btnLimpiar.Text == "&Cancelar")
            {
                inicializarDatos();
                btnLimpiar.Text = "&Limpiar";
                btnGuardar.Text = "&Guardar";
            }
            else { inicializarDatos(); }
            bandera_Estado = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            PictureFoto.Image = Comisariato.Properties.Resources.contact;
            Image img = PictureFoto.Image;
            MyDataImagen = Funcion.imgToByteArray(img);
            imgenDefault = true;
        }

        private void TxtIdentidad_Leave(object sender, EventArgs e)
        {


            if (TxtIdentidad.Text != "")
            {
                if (cmbTipoDocumento.SelectedIndex == 0)
                {
                    if (!Funcion.VerificarCedula(TxtIdentidad.Text))
                    {
                        MessageBox.Show("Ingrese la Cédula Correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        TxtIdentidad.Focus();
                        TxtIdentidad.Select(0, TxtIdentidad.Text.Length);
                    }
                }
                if (cmbTipoDocumento.SelectedIndex == 1)
                {
                    if (TxtIdentidad.Text.Length == 13)
                    {
                        if (TxtIdentidad.Text.Substring(10, 3) != "001" || Funcion.VerificarCedula(TxtIdentidad.Text.Substring(0, 10)) == false)
                        {
                            MessageBox.Show("Ingrese el RUC Correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            TxtIdentidad.Focus();
                            TxtIdentidad.Select(0, TxtIdentidad.Text.Length);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese el RUC Correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); TxtIdentidad.Focus();
                        TxtIdentidad.Select(0, TxtIdentidad.Text.Length);
                    }
                }

                if (consultas.Existe("IDENTIFICACION", TxtIdentidad.Text, "TbEmpleado"))
                {
                    MessageBox.Show("Ya Existe el Empleado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); TxtIdentidad.Focus();
                    TxtIdentidad.Select(0, TxtIdentidad.Text.Length);
                }
            }
        }

        private void DgvDatosEmpleado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && DgvDatosEmpleado.Columns[e.ColumnIndex].Name == "Modificar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell celBoton = DgvDatosEmpleado.Rows[e.RowIndex].Cells["Modificar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + "\\modificarDgv.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                DgvDatosEmpleado.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                DgvDatosEmpleado.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;
                e.Handled = true;
            }

           
            if (rbtInactivosEmpleado.Checked)
            {
                if (e.ColumnIndex >= 1 && this.DgvDatosEmpleado.Columns[e.ColumnIndex].Name == "Deshabilitar" && e.RowIndex >= 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    DataGridViewButtonCell celBoton = this.DgvDatosEmpleado.Rows[e.RowIndex].Cells["Deshabilitar"] as DataGridViewButtonCell;
                    Icon icoAtomico = new Icon(Environment.CurrentDirectory + "\\Habilitar.ico");
                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                    this.DgvDatosEmpleado.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                    this.DgvDatosEmpleado.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;
                    e.Handled = true;
                }
            }
            else
            {
                if (e.ColumnIndex >= 1 && this.DgvDatosEmpleado.Columns[e.ColumnIndex].Name == "Deshabilitar" && e.RowIndex >= 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    DataGridViewButtonCell celBoton = this.DgvDatosEmpleado.Rows[e.RowIndex].Cells["Deshabilitar"] as DataGridViewButtonCell;
                    Icon icoAtomico = new Icon(Environment.CurrentDirectory + "\\EliminarDgv.ico");
                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                    this.DgvDatosEmpleado.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                    this.DgvDatosEmpleado.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;
                    e.Handled = true;
                }
            }
        }

        private void BtnBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnCancelar_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void DtpFechaNacimiento_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CmbGenero_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CmbTipoLicencia_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void NupDiscapacidad_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void FrmEmpleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            TxtIdentidad.Text = "";
        }
    }
}
