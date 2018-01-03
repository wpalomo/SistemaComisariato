namespace Comisariato.Formularios.Mantenimiento.Inventario
{
    partial class FrmProductos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tcProducto = new System.Windows.Forms.TabControl();
            this.tpNuevoProducto = new System.Windows.Forms.TabPage();
            this.txtNombreProducto = new System.Windows.Forms.RichTextBox();
            this.btnLimpiarProducto = new System.Windows.Forms.Button();
            this.btnGuardarProducto = new System.Windows.Forms.Button();
            this.ckbActivoProducto = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDescripcionProducto = new System.Windows.Forms.GroupBox();
            this.TxtStockActual = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.txtUnidadProducto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtObservacionesProducto = new System.Windows.Forms.TextBox();
            this.cbTipoProducto = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbImagenProducto = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBuscarImagenProducto = new System.Windows.Forms.Button();
            this.pbImagenProducto = new System.Windows.Forms.PictureBox();
            this.gbImpuestosProducto = new System.Windows.Forms.GroupBox();
            this.CkbLibreImpuesto = new System.Windows.Forms.CheckBox();
            this.TxtIRBP = new System.Windows.Forms.TextBox();
            this.TxtIce = new System.Windows.Forms.TextBox();
            this.CkbIRBP = new System.Windows.Forms.CheckBox();
            this.CkbICE = new System.Windows.Forms.CheckBox();
            this.CkbIva = new System.Windows.Forms.CheckBox();
            this.gbPreciosProducto = new System.Windows.Forms.GroupBox();
            this.txtPVPConIVAProducto = new System.Windows.Forms.TextBox();
            this.txtPrecioCajaSinIVAProducto = new System.Windows.Forms.TextBox();
            this.txtPrecioMayorSinIVAProducto = new System.Windows.Forms.TextBox();
            this.txtPVPSinIVAProducto = new System.Windows.Forms.TextBox();
            this.txtPrecioCajaConIVAProducto = new System.Windows.Forms.TextBox();
            this.txtPrecioMayorConIVAProducto = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodigoBarraProducto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStockMinimoProducto = new System.Windows.Forms.TextBox();
            this.txtStockMaximoProducto = new System.Windows.Forms.TextBox();
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCajaProducto = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cbUnidadMedidaProducto = new System.Windows.Forms.ComboBox();
            this.tpConsultarModificarProducto = new System.Windows.Forms.TabPage();
            this.BtnExportarExcel = new System.Windows.Forms.Button();
            this.rbtInactivos = new System.Windows.Forms.RadioButton();
            this.rbtActivos = new System.Windows.Forms.RadioButton();
            this.dgvDatosProducto = new System.Windows.Forms.DataGridView();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Deshabilitar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtConsultarProducto = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tcProducto.SuspendLayout();
            this.tpNuevoProducto.SuspendLayout();
            this.gbDescripcionProducto.SuspendLayout();
            this.gbImagenProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenProducto)).BeginInit();
            this.gbImpuestosProducto.SuspendLayout();
            this.gbPreciosProducto.SuspendLayout();
            this.tpConsultarModificarProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // tcProducto
            // 
            this.tcProducto.Controls.Add(this.tpNuevoProducto);
            this.tcProducto.Controls.Add(this.tpConsultarModificarProducto);
            this.tcProducto.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcProducto.Location = new System.Drawing.Point(9, 9);
            this.tcProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tcProducto.Name = "tcProducto";
            this.tcProducto.SelectedIndex = 0;
            this.tcProducto.Size = new System.Drawing.Size(1034, 591);
            this.tcProducto.TabIndex = 1;
            this.tcProducto.TabStop = false;
            // 
            // tpNuevoProducto
            // 
            this.tpNuevoProducto.BackColor = System.Drawing.Color.Bisque;
            this.tpNuevoProducto.Controls.Add(this.txtNombreProducto);
            this.tpNuevoProducto.Controls.Add(this.btnLimpiarProducto);
            this.tpNuevoProducto.Controls.Add(this.btnGuardarProducto);
            this.tpNuevoProducto.Controls.Add(this.ckbActivoProducto);
            this.tpNuevoProducto.Controls.Add(this.label1);
            this.tpNuevoProducto.Controls.Add(this.gbDescripcionProducto);
            this.tpNuevoProducto.Location = new System.Drawing.Point(4, 25);
            this.tpNuevoProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpNuevoProducto.Name = "tpNuevoProducto";
            this.tpNuevoProducto.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpNuevoProducto.Size = new System.Drawing.Size(1026, 562);
            this.tpNuevoProducto.TabIndex = 0;
            this.tpNuevoProducto.Text = "Nuevo Producto";
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtNombreProducto.Location = new System.Drawing.Point(220, 23);
            this.txtNombreProducto.Multiline = false;
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(638, 22);
            this.txtNombreProducto.TabIndex = 47;
            this.txtNombreProducto.Text = "";
            this.txtNombreProducto.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.txtNombreProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreProducto_KeyPress_1);
            // 
            // btnLimpiarProducto
            // 
            this.btnLimpiarProducto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.btnLimpiarProducto.Image = global::Comisariato.Properties.Resources.limpiar;
            this.btnLimpiarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiarProducto.Location = new System.Drawing.Point(527, 467);
            this.btnLimpiarProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLimpiarProducto.Name = "btnLimpiarProducto";
            this.btnLimpiarProducto.Size = new System.Drawing.Size(128, 77);
            this.btnLimpiarProducto.TabIndex = 27;
            this.btnLimpiarProducto.Text = "&Limpiar";
            this.btnLimpiarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiarProducto.UseVisualStyleBackColor = true;
            this.btnLimpiarProducto.Click += new System.EventHandler(this.btnLimpiarProducto_Click);
            // 
            // btnGuardarProducto
            // 
            this.btnGuardarProducto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.btnGuardarProducto.Image = global::Comisariato.Properties.Resources.guardar11;
            this.btnGuardarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarProducto.Location = new System.Drawing.Point(371, 467);
            this.btnGuardarProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardarProducto.Name = "btnGuardarProducto";
            this.btnGuardarProducto.Size = new System.Drawing.Size(128, 77);
            this.btnGuardarProducto.TabIndex = 26;
            this.btnGuardarProducto.Text = "&Guardar";
            this.btnGuardarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarProducto.UseVisualStyleBackColor = true;
            this.btnGuardarProducto.Click += new System.EventHandler(this.btnGuardarProducto_Click);
            // 
            // ckbActivoProducto
            // 
            this.ckbActivoProducto.AutoSize = true;
            this.ckbActivoProducto.Checked = true;
            this.ckbActivoProducto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbActivoProducto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.ckbActivoProducto.ForeColor = System.Drawing.Color.Teal;
            this.ckbActivoProducto.Location = new System.Drawing.Point(874, 26);
            this.ckbActivoProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckbActivoProducto.Name = "ckbActivoProducto";
            this.ckbActivoProducto.Size = new System.Drawing.Size(62, 20);
            this.ckbActivoProducto.TabIndex = 46;
            this.ckbActivoProducto.Text = "Activo";
            this.ckbActivoProducto.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(90, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 45;
            this.label1.Text = "Nombre Producto:";
            // 
            // gbDescripcionProducto
            // 
            this.gbDescripcionProducto.Controls.Add(this.TxtStockActual);
            this.gbDescripcionProducto.Controls.Add(this.label6);
            this.gbDescripcionProducto.Controls.Add(this.txtPeso);
            this.gbDescripcionProducto.Controls.Add(this.txtUnidadProducto);
            this.gbDescripcionProducto.Controls.Add(this.label5);
            this.gbDescripcionProducto.Controls.Add(this.txtObservacionesProducto);
            this.gbDescripcionProducto.Controls.Add(this.cbTipoProducto);
            this.gbDescripcionProducto.Controls.Add(this.label18);
            this.gbDescripcionProducto.Controls.Add(this.label2);
            this.gbDescripcionProducto.Controls.Add(this.gbImagenProducto);
            this.gbDescripcionProducto.Controls.Add(this.gbImpuestosProducto);
            this.gbDescripcionProducto.Controls.Add(this.gbPreciosProducto);
            this.gbDescripcionProducto.Controls.Add(this.txtCodigoBarraProducto);
            this.gbDescripcionProducto.Controls.Add(this.label3);
            this.gbDescripcionProducto.Controls.Add(this.label4);
            this.gbDescripcionProducto.Controls.Add(this.txtStockMinimoProducto);
            this.gbDescripcionProducto.Controls.Add(this.txtStockMaximoProducto);
            this.gbDescripcionProducto.Controls.Add(this.txtDisplay);
            this.gbDescripcionProducto.Controls.Add(this.label11);
            this.gbDescripcionProducto.Controls.Add(this.label12);
            this.gbDescripcionProducto.Controls.Add(this.txtCajaProducto);
            this.gbDescripcionProducto.Controls.Add(this.label14);
            this.gbDescripcionProducto.Controls.Add(this.label15);
            this.gbDescripcionProducto.Controls.Add(this.label16);
            this.gbDescripcionProducto.Controls.Add(this.cbUnidadMedidaProducto);
            this.gbDescripcionProducto.ForeColor = System.Drawing.Color.Teal;
            this.gbDescripcionProducto.Location = new System.Drawing.Point(9, 55);
            this.gbDescripcionProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDescripcionProducto.Name = "gbDescripcionProducto";
            this.gbDescripcionProducto.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDescripcionProducto.Size = new System.Drawing.Size(1008, 401);
            this.gbDescripcionProducto.TabIndex = 2;
            this.gbDescripcionProducto.TabStop = false;
            this.gbDescripcionProducto.Text = "Descripción del Producto";
            // 
            // TxtStockActual
            // 
            this.TxtStockActual.Font = new System.Drawing.Font("Arial", 9.75F);
            this.TxtStockActual.Location = new System.Drawing.Point(516, 139);
            this.TxtStockActual.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtStockActual.Name = "TxtStockActual";
            this.TxtStockActual.Size = new System.Drawing.Size(84, 22);
            this.TxtStockActual.TabIndex = 50;
            this.TxtStockActual.Text = "0";
            this.TxtStockActual.Enter += new System.EventHandler(this.TxtStockActual_Enter);
            this.TxtStockActual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtStockActual_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label6.Location = new System.Drawing.Point(414, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 16);
            this.label6.TabIndex = 51;
            this.label6.Text = "Stock Actual:";
            // 
            // txtPeso
            // 
            this.txtPeso.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtPeso.Location = new System.Drawing.Point(539, 105);
            this.txtPeso.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(43, 22);
            this.txtPeso.TabIndex = 10;
            this.txtPeso.Text = "0";
            this.txtPeso.Click += new System.EventHandler(this.txtPeso_Click);
            this.txtPeso.Enter += new System.EventHandler(this.txtPeso_Enter);
            this.txtPeso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockMaximoProducto_KeyPress);
            // 
            // txtUnidadProducto
            // 
            this.txtUnidadProducto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtUnidadProducto.Location = new System.Drawing.Point(391, 106);
            this.txtUnidadProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUnidadProducto.Name = "txtUnidadProducto";
            this.txtUnidadProducto.Size = new System.Drawing.Size(53, 22);
            this.txtUnidadProducto.TabIndex = 9;
            this.txtUnidadProducto.Text = "0";
            this.txtUnidadProducto.Click += new System.EventHandler(this.txtUnidadProducto_Click);
            this.txtUnidadProducto.Enter += new System.EventHandler(this.txtUnidadProducto_Enter);
            this.txtUnidadProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockMaximoProducto_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label5.Location = new System.Drawing.Point(164, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 49;
            this.label5.Text = "Display:";
            // 
            // txtObservacionesProducto
            // 
            this.txtObservacionesProducto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtObservacionesProducto.Location = new System.Drawing.Point(139, 343);
            this.txtObservacionesProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtObservacionesProducto.Multiline = true;
            this.txtObservacionesProducto.Name = "txtObservacionesProducto";
            this.txtObservacionesProducto.Size = new System.Drawing.Size(845, 45);
            this.txtObservacionesProducto.TabIndex = 25;
            this.txtObservacionesProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObservacionesProducto_KeyPress);
            // 
            // cbTipoProducto
            // 
            this.cbTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoProducto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cbTipoProducto.FormattingEnabled = true;
            this.cbTipoProducto.Location = new System.Drawing.Point(724, 44);
            this.cbTipoProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTipoProducto.Name = "cbTipoProducto";
            this.cbTipoProducto.Size = new System.Drawing.Size(260, 24);
            this.cbTipoProducto.TabIndex = 6;
            this.cbTipoProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbUnidadMedidaProducto_KeyPress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label18.Location = new System.Drawing.Point(26, 343);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 16);
            this.label18.TabIndex = 48;
            this.label18.Text = "Observaciones:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label2.Location = new System.Drawing.Point(610, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 47;
            this.label2.Text = "Tipo Producto:";
            // 
            // gbImagenProducto
            // 
            this.gbImagenProducto.Controls.Add(this.btnCancelar);
            this.gbImagenProducto.Controls.Add(this.btnBuscarImagenProducto);
            this.gbImagenProducto.Controls.Add(this.pbImagenProducto);
            this.gbImagenProducto.ForeColor = System.Drawing.Color.Teal;
            this.gbImagenProducto.Location = new System.Drawing.Point(613, 76);
            this.gbImagenProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbImagenProducto.Name = "gbImagenProducto";
            this.gbImagenProducto.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbImagenProducto.Size = new System.Drawing.Size(371, 247);
            this.gbImagenProducto.TabIndex = 22;
            this.gbImagenProducto.TabStop = false;
            this.gbImagenProducto.Text = "Imagen";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(213, 173);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 48);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBuscarImagenProducto
            // 
            this.btnBuscarImagenProducto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.btnBuscarImagenProducto.Image = global::Comisariato.Properties.Resources.buscar2;
            this.btnBuscarImagenProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarImagenProducto.Location = new System.Drawing.Point(51, 173);
            this.btnBuscarImagenProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscarImagenProducto.Name = "btnBuscarImagenProducto";
            this.btnBuscarImagenProducto.Size = new System.Drawing.Size(102, 47);
            this.btnBuscarImagenProducto.TabIndex = 23;
            this.btnBuscarImagenProducto.Text = "Imagen";
            this.btnBuscarImagenProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarImagenProducto.UseVisualStyleBackColor = true;
            this.btnBuscarImagenProducto.Click += new System.EventHandler(this.btnBuscarImagenProducto_Click);
            // 
            // pbImagenProducto
            // 
            this.pbImagenProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImagenProducto.Image = global::Comisariato.Properties.Resources.boxProducto;
            this.pbImagenProducto.Location = new System.Drawing.Point(81, 22);
            this.pbImagenProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbImagenProducto.Name = "pbImagenProducto";
            this.pbImagenProducto.Size = new System.Drawing.Size(209, 139);
            this.pbImagenProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagenProducto.TabIndex = 0;
            this.pbImagenProducto.TabStop = false;
            // 
            // gbImpuestosProducto
            // 
            this.gbImpuestosProducto.Controls.Add(this.CkbLibreImpuesto);
            this.gbImpuestosProducto.Controls.Add(this.TxtIRBP);
            this.gbImpuestosProducto.Controls.Add(this.TxtIce);
            this.gbImpuestosProducto.Controls.Add(this.CkbIRBP);
            this.gbImpuestosProducto.Controls.Add(this.CkbICE);
            this.gbImpuestosProducto.Controls.Add(this.CkbIva);
            this.gbImpuestosProducto.ForeColor = System.Drawing.Color.Teal;
            this.gbImpuestosProducto.Location = new System.Drawing.Point(409, 183);
            this.gbImpuestosProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbImpuestosProducto.Name = "gbImpuestosProducto";
            this.gbImpuestosProducto.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbImpuestosProducto.Size = new System.Drawing.Size(198, 140);
            this.gbImpuestosProducto.TabIndex = 13;
            this.gbImpuestosProducto.TabStop = false;
            this.gbImpuestosProducto.Text = "Impuestos";
            // 
            // CkbLibreImpuesto
            // 
            this.CkbLibreImpuesto.AutoSize = true;
            this.CkbLibreImpuesto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.CkbLibreImpuesto.Location = new System.Drawing.Point(10, 115);
            this.CkbLibreImpuesto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CkbLibreImpuesto.Name = "CkbLibreImpuesto";
            this.CkbLibreImpuesto.Size = new System.Drawing.Size(130, 20);
            this.CkbLibreImpuesto.TabIndex = 22;
            this.CkbLibreImpuesto.Text = "Libre de Impuesto";
            this.CkbLibreImpuesto.UseVisualStyleBackColor = true;
            this.CkbLibreImpuesto.CheckedChanged += new System.EventHandler(this.CkbLibreImpuesto_CheckedChanged);
            // 
            // TxtIRBP
            // 
            this.TxtIRBP.Enabled = false;
            this.TxtIRBP.Font = new System.Drawing.Font("Arial", 9.75F);
            this.TxtIRBP.Location = new System.Drawing.Point(72, 86);
            this.TxtIRBP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtIRBP.Name = "TxtIRBP";
            this.TxtIRBP.Size = new System.Drawing.Size(118, 22);
            this.TxtIRBP.TabIndex = 21;
            this.TxtIRBP.Text = "0.0";
            this.TxtIRBP.Click += new System.EventHandler(this.TxtIRBP_Click);
            this.TxtIRBP.Enter += new System.EventHandler(this.TxtIRBP_Enter);
            this.TxtIRBP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtIRBP_KeyPress);
            // 
            // TxtIce
            // 
            this.TxtIce.Enabled = false;
            this.TxtIce.Font = new System.Drawing.Font("Arial", 9.75F);
            this.TxtIce.Location = new System.Drawing.Point(72, 60);
            this.TxtIce.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtIce.Name = "TxtIce";
            this.TxtIce.Size = new System.Drawing.Size(118, 22);
            this.TxtIce.TabIndex = 20;
            this.TxtIce.Text = "0.0";
            this.TxtIce.Click += new System.EventHandler(this.TxtIce_Click);
            this.TxtIce.Enter += new System.EventHandler(this.TxtIce_Enter);
            this.TxtIce.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtIce_KeyPress);
            // 
            // CkbIRBP
            // 
            this.CkbIRBP.AutoSize = true;
            this.CkbIRBP.Enabled = false;
            this.CkbIRBP.Font = new System.Drawing.Font("Arial", 9.75F);
            this.CkbIRBP.Location = new System.Drawing.Point(10, 87);
            this.CkbIRBP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CkbIRBP.Name = "CkbIRBP";
            this.CkbIRBP.Size = new System.Drawing.Size(57, 20);
            this.CkbIRBP.TabIndex = 18;
            this.CkbIRBP.Text = "IRBP";
            this.CkbIRBP.UseVisualStyleBackColor = true;
            this.CkbIRBP.CheckedChanged += new System.EventHandler(this.CkbIRBP_CheckedChanged);
            // 
            // CkbICE
            // 
            this.CkbICE.AutoSize = true;
            this.CkbICE.Enabled = false;
            this.CkbICE.Font = new System.Drawing.Font("Arial", 9.75F);
            this.CkbICE.Location = new System.Drawing.Point(10, 61);
            this.CkbICE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CkbICE.Name = "CkbICE";
            this.CkbICE.Size = new System.Drawing.Size(48, 20);
            this.CkbICE.TabIndex = 17;
            this.CkbICE.Text = "ICE";
            this.CkbICE.UseVisualStyleBackColor = true;
            this.CkbICE.CheckedChanged += new System.EventHandler(this.CkbICE_CheckedChanged);
            // 
            // CkbIva
            // 
            this.CkbIva.AutoSize = true;
            this.CkbIva.Font = new System.Drawing.Font("Arial", 9.75F);
            this.CkbIva.Location = new System.Drawing.Point(10, 35);
            this.CkbIva.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CkbIva.Name = "CkbIva";
            this.CkbIva.Size = new System.Drawing.Size(47, 20);
            this.CkbIva.TabIndex = 14;
            this.CkbIva.Text = "IVA";
            this.CkbIva.UseVisualStyleBackColor = true;
            this.CkbIva.CheckedChanged += new System.EventHandler(this.CkbIva_CheckedChanged);
            this.CkbIva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CkbIva_KeyPress);
            // 
            // gbPreciosProducto
            // 
            this.gbPreciosProducto.Controls.Add(this.txtPVPConIVAProducto);
            this.gbPreciosProducto.Controls.Add(this.txtPrecioCajaSinIVAProducto);
            this.gbPreciosProducto.Controls.Add(this.txtPrecioMayorSinIVAProducto);
            this.gbPreciosProducto.Controls.Add(this.txtPVPSinIVAProducto);
            this.gbPreciosProducto.Controls.Add(this.txtPrecioCajaConIVAProducto);
            this.gbPreciosProducto.Controls.Add(this.txtPrecioMayorConIVAProducto);
            this.gbPreciosProducto.Controls.Add(this.label17);
            this.gbPreciosProducto.Controls.Add(this.label13);
            this.gbPreciosProducto.Controls.Add(this.label9);
            this.gbPreciosProducto.Controls.Add(this.label8);
            this.gbPreciosProducto.Controls.Add(this.label7);
            this.gbPreciosProducto.ForeColor = System.Drawing.Color.Teal;
            this.gbPreciosProducto.Location = new System.Drawing.Point(29, 183);
            this.gbPreciosProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbPreciosProducto.Name = "gbPreciosProducto";
            this.gbPreciosProducto.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbPreciosProducto.Size = new System.Drawing.Size(374, 140);
            this.gbPreciosProducto.TabIndex = 15;
            this.gbPreciosProducto.TabStop = false;
            this.gbPreciosProducto.Text = "Precios";
            // 
            // txtPVPConIVAProducto
            // 
            this.txtPVPConIVAProducto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtPVPConIVAProducto.Location = new System.Drawing.Point(134, 34);
            this.txtPVPConIVAProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPVPConIVAProducto.Name = "txtPVPConIVAProducto";
            this.txtPVPConIVAProducto.Size = new System.Drawing.Size(100, 22);
            this.txtPVPConIVAProducto.TabIndex = 19;
            this.txtPVPConIVAProducto.Text = "0.0";
            this.txtPVPConIVAProducto.Click += new System.EventHandler(this.txtPVPConIVAProducto_Click);
            this.txtPVPConIVAProducto.TextChanged += new System.EventHandler(this.txtPVPConIVAProducto_TextChanged_1);
            this.txtPVPConIVAProducto.Enter += new System.EventHandler(this.txtPVPConIVAProducto_Enter);
            this.txtPVPConIVAProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPVPConIVAProducto_KeyPress_1);
            this.txtPVPConIVAProducto.Leave += new System.EventHandler(this.txtPVPConIVAProducto_Leave);
            // 
            // txtPrecioCajaSinIVAProducto
            // 
            this.txtPrecioCajaSinIVAProducto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtPrecioCajaSinIVAProducto.Location = new System.Drawing.Point(260, 94);
            this.txtPrecioCajaSinIVAProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrecioCajaSinIVAProducto.Name = "txtPrecioCajaSinIVAProducto";
            this.txtPrecioCajaSinIVAProducto.Size = new System.Drawing.Size(100, 22);
            this.txtPrecioCajaSinIVAProducto.TabIndex = 18;
            this.txtPrecioCajaSinIVAProducto.Text = "0.0";
            this.txtPrecioCajaSinIVAProducto.Click += new System.EventHandler(this.txtPrecioCajaSinIVAProducto_Click);
            this.txtPrecioCajaSinIVAProducto.Enter += new System.EventHandler(this.txtPrecioCajaSinIVAProducto_Enter);
            this.txtPrecioCajaSinIVAProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioCajaSinIVAProducto_KeyPress);
            this.txtPrecioCajaSinIVAProducto.Leave += new System.EventHandler(this.txtPVPSinIVAProducto_Leave);
            // 
            // txtPrecioMayorSinIVAProducto
            // 
            this.txtPrecioMayorSinIVAProducto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtPrecioMayorSinIVAProducto.Location = new System.Drawing.Point(260, 64);
            this.txtPrecioMayorSinIVAProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrecioMayorSinIVAProducto.Name = "txtPrecioMayorSinIVAProducto";
            this.txtPrecioMayorSinIVAProducto.Size = new System.Drawing.Size(100, 22);
            this.txtPrecioMayorSinIVAProducto.TabIndex = 17;
            this.txtPrecioMayorSinIVAProducto.Text = "0.0";
            this.txtPrecioMayorSinIVAProducto.Click += new System.EventHandler(this.txtPrecioMayorSinIVAProducto_Click);
            this.txtPrecioMayorSinIVAProducto.Enter += new System.EventHandler(this.txtPrecioMayorSinIVAProducto_Enter);
            this.txtPrecioMayorSinIVAProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioMayorSinIVAProducto_KeyPress);
            this.txtPrecioMayorSinIVAProducto.Leave += new System.EventHandler(this.txtPVPSinIVAProducto_Leave);
            // 
            // txtPVPSinIVAProducto
            // 
            this.txtPVPSinIVAProducto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtPVPSinIVAProducto.Location = new System.Drawing.Point(260, 34);
            this.txtPVPSinIVAProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPVPSinIVAProducto.Name = "txtPVPSinIVAProducto";
            this.txtPVPSinIVAProducto.Size = new System.Drawing.Size(100, 22);
            this.txtPVPSinIVAProducto.TabIndex = 16;
            this.txtPVPSinIVAProducto.Text = "0.0";
            this.txtPVPSinIVAProducto.Click += new System.EventHandler(this.txtPVPSinIVAProducto_Click);
            this.txtPVPSinIVAProducto.TextChanged += new System.EventHandler(this.txtPVPSinIVAProducto_TextChanged);
            this.txtPVPSinIVAProducto.Enter += new System.EventHandler(this.txtPVPSinIVAProducto_Enter);
            this.txtPVPSinIVAProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPVPSinIVAProducto_KeyPress);
            this.txtPVPSinIVAProducto.Leave += new System.EventHandler(this.txtPVPSinIVAProducto_Leave);
            // 
            // txtPrecioCajaConIVAProducto
            // 
            this.txtPrecioCajaConIVAProducto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtPrecioCajaConIVAProducto.Location = new System.Drawing.Point(134, 94);
            this.txtPrecioCajaConIVAProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrecioCajaConIVAProducto.Name = "txtPrecioCajaConIVAProducto";
            this.txtPrecioCajaConIVAProducto.Size = new System.Drawing.Size(100, 22);
            this.txtPrecioCajaConIVAProducto.TabIndex = 21;
            this.txtPrecioCajaConIVAProducto.Text = "0.0";
            this.txtPrecioCajaConIVAProducto.Click += new System.EventHandler(this.txtPrecioCajaConIVAProducto_Click);
            this.txtPrecioCajaConIVAProducto.TextChanged += new System.EventHandler(this.txtPVPConIVAProducto_TextChanged_1);
            this.txtPrecioCajaConIVAProducto.Enter += new System.EventHandler(this.txtPrecioCajaConIVAProducto_Enter);
            this.txtPrecioCajaConIVAProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioCajaConIVAProducto_KeyPress);
            this.txtPrecioCajaConIVAProducto.Leave += new System.EventHandler(this.txtPVPConIVAProducto_Leave);
            // 
            // txtPrecioMayorConIVAProducto
            // 
            this.txtPrecioMayorConIVAProducto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtPrecioMayorConIVAProducto.Location = new System.Drawing.Point(134, 64);
            this.txtPrecioMayorConIVAProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrecioMayorConIVAProducto.Name = "txtPrecioMayorConIVAProducto";
            this.txtPrecioMayorConIVAProducto.Size = new System.Drawing.Size(100, 22);
            this.txtPrecioMayorConIVAProducto.TabIndex = 20;
            this.txtPrecioMayorConIVAProducto.Text = "0.0";
            this.txtPrecioMayorConIVAProducto.Click += new System.EventHandler(this.txtPrecioMayorConIVAProducto_Click);
            this.txtPrecioMayorConIVAProducto.TextChanged += new System.EventHandler(this.txtPVPConIVAProducto_TextChanged_1);
            this.txtPrecioMayorConIVAProducto.Enter += new System.EventHandler(this.txtPrecioMayorConIVAProducto_Enter);
            this.txtPrecioMayorConIVAProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioMayorConIVAProducto_KeyPress);
            this.txtPrecioMayorConIVAProducto.Leave += new System.EventHandler(this.txtPVPConIVAProducto_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label17.Location = new System.Drawing.Point(281, 14);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 16);
            this.label17.TabIndex = 4;
            this.label17.Text = "Sin IVA";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label13.Location = new System.Drawing.Point(152, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 16);
            this.label13.TabIndex = 3;
            this.label13.Text = "Con IVA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label9.Location = new System.Drawing.Point(15, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "Precio por Caja:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label8.Location = new System.Drawing.Point(15, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Precio al Mayor:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label7.Location = new System.Drawing.Point(15, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "P.V.P:";
            // 
            // txtCodigoBarraProducto
            // 
            this.txtCodigoBarraProducto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtCodigoBarraProducto.Location = new System.Drawing.Point(154, 44);
            this.txtCodigoBarraProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCodigoBarraProducto.Name = "txtCodigoBarraProducto";
            this.txtCodigoBarraProducto.Size = new System.Drawing.Size(428, 22);
            this.txtCodigoBarraProducto.TabIndex = 3;
            this.txtCodigoBarraProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoBarraProducto_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label3.Location = new System.Drawing.Point(26, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Código de Barra:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label4.Location = new System.Drawing.Point(26, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "Unidad de Medida:";
            // 
            // txtStockMinimoProducto
            // 
            this.txtStockMinimoProducto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtStockMinimoProducto.Location = new System.Drawing.Point(319, 139);
            this.txtStockMinimoProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStockMinimoProducto.Name = "txtStockMinimoProducto";
            this.txtStockMinimoProducto.Size = new System.Drawing.Size(84, 22);
            this.txtStockMinimoProducto.TabIndex = 12;
            this.txtStockMinimoProducto.Text = "0";
            this.txtStockMinimoProducto.Click += new System.EventHandler(this.txtStockMinimoProducto_Click);
            this.txtStockMinimoProducto.Enter += new System.EventHandler(this.txtStockMinimoProducto_Enter);
            this.txtStockMinimoProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockMaximoProducto_KeyPress);
            this.txtStockMinimoProducto.Leave += new System.EventHandler(this.txtStockMinimoProducto_Leave);
            // 
            // txtStockMaximoProducto
            // 
            this.txtStockMaximoProducto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtStockMaximoProducto.Location = new System.Drawing.Point(125, 139);
            this.txtStockMaximoProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStockMaximoProducto.Name = "txtStockMaximoProducto";
            this.txtStockMaximoProducto.Size = new System.Drawing.Size(82, 22);
            this.txtStockMaximoProducto.TabIndex = 11;
            this.txtStockMaximoProducto.Text = "0";
            this.txtStockMaximoProducto.Click += new System.EventHandler(this.txtStockMaximoProducto_Click);
            this.txtStockMaximoProducto.Enter += new System.EventHandler(this.txtStockMaximoProducto_Enter);
            this.txtStockMaximoProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockMaximoProducto_KeyPress);
            // 
            // txtDisplay
            // 
            this.txtDisplay.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtDisplay.Location = new System.Drawing.Point(232, 105);
            this.txtDisplay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Size = new System.Drawing.Size(53, 22);
            this.txtDisplay.TabIndex = 8;
            this.txtDisplay.Text = "0";
            this.txtDisplay.Click += new System.EventHandler(this.txtDisplay_Click);
            this.txtDisplay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockMaximoProducto_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label11.Location = new System.Drawing.Point(26, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 16);
            this.label11.TabIndex = 31;
            this.label11.Text = "Caja:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label12.Location = new System.Drawing.Point(26, 142);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 16);
            this.label12.TabIndex = 32;
            this.label12.Text = "Stock Máximo:";
            // 
            // txtCajaProducto
            // 
            this.txtCajaProducto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtCajaProducto.Location = new System.Drawing.Point(77, 105);
            this.txtCajaProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCajaProducto.Name = "txtCajaProducto";
            this.txtCajaProducto.Size = new System.Drawing.Size(54, 22);
            this.txtCajaProducto.TabIndex = 7;
            this.txtCajaProducto.Text = "0";
            this.txtCajaProducto.Click += new System.EventHandler(this.txtCajaProducto_Click);
            this.txtCajaProducto.Enter += new System.EventHandler(this.txtCajaProducto_Enter);
            this.txtCajaProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockMaximoProducto_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label14.Location = new System.Drawing.Point(326, 109);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 16);
            this.label14.TabIndex = 33;
            this.label14.Text = "Unidad:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label15.Location = new System.Drawing.Point(221, 142);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 16);
            this.label15.TabIndex = 34;
            this.label15.Text = "Stock Mínimo:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label16.Location = new System.Drawing.Point(478, 108);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 16);
            this.label16.TabIndex = 35;
            this.label16.Text = "Peso:";
            // 
            // cbUnidadMedidaProducto
            // 
            this.cbUnidadMedidaProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnidadMedidaProducto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cbUnidadMedidaProducto.FormattingEnabled = true;
            this.cbUnidadMedidaProducto.Items.AddRange(new object[] {
            "Unidades",
            "Docenas",
            "Millares",
            "Pulgadas",
            "Pies",
            "Metros",
            "Tonelada",
            "Kilo",
            "kiloGramo",
            "Libra",
            "Litro",
            "Mililitro",
            "Servicio",
            "Botellas",
            "Frascos",
            "Sin Unidad"});
            this.cbUnidadMedidaProducto.Location = new System.Drawing.Point(154, 71);
            this.cbUnidadMedidaProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbUnidadMedidaProducto.Name = "cbUnidadMedidaProducto";
            this.cbUnidadMedidaProducto.Size = new System.Drawing.Size(428, 24);
            this.cbUnidadMedidaProducto.TabIndex = 4;
            this.cbUnidadMedidaProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbUnidadMedidaProducto_KeyPress);
            // 
            // tpConsultarModificarProducto
            // 
            this.tpConsultarModificarProducto.BackColor = System.Drawing.Color.Bisque;
            this.tpConsultarModificarProducto.Controls.Add(this.BtnExportarExcel);
            this.tpConsultarModificarProducto.Controls.Add(this.rbtInactivos);
            this.tpConsultarModificarProducto.Controls.Add(this.rbtActivos);
            this.tpConsultarModificarProducto.Controls.Add(this.dgvDatosProducto);
            this.tpConsultarModificarProducto.Controls.Add(this.txtConsultarProducto);
            this.tpConsultarModificarProducto.Controls.Add(this.label25);
            this.tpConsultarModificarProducto.Location = new System.Drawing.Point(4, 25);
            this.tpConsultarModificarProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpConsultarModificarProducto.Name = "tpConsultarModificarProducto";
            this.tpConsultarModificarProducto.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpConsultarModificarProducto.Size = new System.Drawing.Size(1026, 562);
            this.tpConsultarModificarProducto.TabIndex = 1;
            this.tpConsultarModificarProducto.Text = "Consultar - Modificar Producto";
            // 
            // BtnExportarExcel
            // 
            this.BtnExportarExcel.Image = global::Comisariato.Properties.Resources.Excel_2013_24px_1180012_easyicon_net;
            this.BtnExportarExcel.Location = new System.Drawing.Point(970, 27);
            this.BtnExportarExcel.Name = "BtnExportarExcel";
            this.BtnExportarExcel.Size = new System.Drawing.Size(36, 29);
            this.BtnExportarExcel.TabIndex = 24;
            this.BtnExportarExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnExportarExcel.UseVisualStyleBackColor = true;
            this.BtnExportarExcel.Click += new System.EventHandler(this.BtnExportarExcel_Click);
            // 
            // rbtInactivos
            // 
            this.rbtInactivos.AutoSize = true;
            this.rbtInactivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtInactivos.ForeColor = System.Drawing.Color.Teal;
            this.rbtInactivos.Location = new System.Drawing.Point(545, 66);
            this.rbtInactivos.Name = "rbtInactivos";
            this.rbtInactivos.Size = new System.Drawing.Size(79, 20);
            this.rbtInactivos.TabIndex = 13;
            this.rbtInactivos.Text = "Inactivos";
            this.rbtInactivos.UseVisualStyleBackColor = true;
            this.rbtInactivos.CheckedChanged += new System.EventHandler(this.rbtActivos_CheckedChanged);
            // 
            // rbtActivos
            // 
            this.rbtActivos.AutoSize = true;
            this.rbtActivos.Checked = true;
            this.rbtActivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtActivos.ForeColor = System.Drawing.Color.Teal;
            this.rbtActivos.Location = new System.Drawing.Point(457, 66);
            this.rbtActivos.Name = "rbtActivos";
            this.rbtActivos.Size = new System.Drawing.Size(70, 20);
            this.rbtActivos.TabIndex = 12;
            this.rbtActivos.TabStop = true;
            this.rbtActivos.Text = "Activos";
            this.rbtActivos.UseVisualStyleBackColor = true;
            this.rbtActivos.CheckedChanged += new System.EventHandler(this.rbtActivos_CheckedChanged);
            // 
            // dgvDatosProducto
            // 
            this.dgvDatosProducto.AllowUserToAddRows = false;
            this.dgvDatosProducto.AllowUserToDeleteRows = false;
            this.dgvDatosProducto.AllowUserToOrderColumns = true;
            this.dgvDatosProducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDatosProducto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatosProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatosProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Modificar,
            this.Deshabilitar});
            this.dgvDatosProducto.Location = new System.Drawing.Point(21, 104);
            this.dgvDatosProducto.Name = "dgvDatosProducto";
            this.dgvDatosProducto.ReadOnly = true;
            this.dgvDatosProducto.Size = new System.Drawing.Size(985, 423);
            this.dgvDatosProducto.TabIndex = 9;
            this.dgvDatosProducto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatosProducto_CellClick);
            this.dgvDatosProducto.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDatosProducto_CellPainting);
            // 
            // Modificar
            // 
            this.Modificar.FillWeight = 5.076141F;
            this.Modificar.HeaderText = "";
            this.Modificar.Name = "Modificar";
            this.Modificar.ReadOnly = true;
            this.Modificar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Deshabilitar
            // 
            this.Deshabilitar.FillWeight = 194.9239F;
            this.Deshabilitar.HeaderText = "";
            this.Deshabilitar.Name = "Deshabilitar";
            this.Deshabilitar.ReadOnly = true;
            // 
            // txtConsultarProducto
            // 
            this.txtConsultarProducto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtConsultarProducto.Location = new System.Drawing.Point(136, 30);
            this.txtConsultarProducto.Margin = new System.Windows.Forms.Padding(2);
            this.txtConsultarProducto.Name = "txtConsultarProducto";
            this.txtConsultarProducto.Size = new System.Drawing.Size(341, 22);
            this.txtConsultarProducto.TabIndex = 8;
            this.txtConsultarProducto.TextChanged += new System.EventHandler(this.txtConsultarProducto_TextChanged);
            this.txtConsultarProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsultarProducto_KeyPress);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label25.ForeColor = System.Drawing.Color.Teal;
            this.label25.Location = new System.Drawing.Point(22, 33);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(67, 16);
            this.label25.TabIndex = 7;
            this.label25.Text = "Consultar:";
            // 
            // FrmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(1052, 613);
            this.Controls.Add(this.tcProducto);
            this.Font = new System.Drawing.Font("Arial", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1068, 652);
            this.MinimumSize = new System.Drawing.Size(1068, 652);
            this.Name = "FrmProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Administrar Productos";
            this.Load += new System.EventHandler(this.FrmProductos_Load);
            this.tcProducto.ResumeLayout(false);
            this.tpNuevoProducto.ResumeLayout(false);
            this.tpNuevoProducto.PerformLayout();
            this.gbDescripcionProducto.ResumeLayout(false);
            this.gbDescripcionProducto.PerformLayout();
            this.gbImagenProducto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenProducto)).EndInit();
            this.gbImpuestosProducto.ResumeLayout(false);
            this.gbImpuestosProducto.PerformLayout();
            this.gbPreciosProducto.ResumeLayout(false);
            this.gbPreciosProducto.PerformLayout();
            this.tpConsultarModificarProducto.ResumeLayout(false);
            this.tpConsultarModificarProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tcProducto;
        private System.Windows.Forms.TabPage tpNuevoProducto;
        private System.Windows.Forms.TabPage tpConsultarModificarProducto;
        private System.Windows.Forms.ComboBox cbTipoProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckbActivoProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbDescripcionProducto;
        private System.Windows.Forms.GroupBox gbImagenProducto;
        private System.Windows.Forms.GroupBox gbImpuestosProducto;
        private System.Windows.Forms.TextBox TxtIRBP;
        private System.Windows.Forms.TextBox TxtIce;
        private System.Windows.Forms.CheckBox CkbIRBP;
        private System.Windows.Forms.CheckBox CkbICE;
        private System.Windows.Forms.CheckBox CkbIva;
        private System.Windows.Forms.GroupBox gbPreciosProducto;
        private System.Windows.Forms.TextBox txtPrecioCajaSinIVAProducto;
        private System.Windows.Forms.TextBox txtPrecioMayorSinIVAProducto;
        private System.Windows.Forms.TextBox txtPVPSinIVAProducto;
        private System.Windows.Forms.TextBox txtPrecioCajaConIVAProducto;
        private System.Windows.Forms.TextBox txtPrecioMayorConIVAProducto;
        private System.Windows.Forms.TextBox txtPVPConIVAProducto;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCodigoBarraProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStockMinimoProducto;
        private System.Windows.Forms.TextBox txtStockMaximoProducto;
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCajaProducto;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbUnidadMedidaProducto;
        private System.Windows.Forms.TextBox txtObservacionesProducto;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnBuscarImagenProducto;
        private System.Windows.Forms.PictureBox pbImagenProducto;
        private System.Windows.Forms.Button btnLimpiarProducto;
        private System.Windows.Forms.Button btnGuardarProducto;
        private System.Windows.Forms.TextBox txtConsultarProducto;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvDatosProducto;
        private System.Windows.Forms.RadioButton rbtInactivos;
        private System.Windows.Forms.RadioButton rbtActivos;
        private System.Windows.Forms.RichTextBox txtNombreProducto;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.TextBox txtUnidadProducto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox CkbLibreImpuesto;
        private System.Windows.Forms.DataGridViewButtonColumn Modificar;
        private System.Windows.Forms.DataGridViewButtonColumn Deshabilitar;
        private System.Windows.Forms.TextBox TxtStockActual;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnExportarExcel;
    }
}