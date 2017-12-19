namespace Comisariato.Formularios.Transacciones
{
    partial class FrmDevolucionCompra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pcOrdenCompra = new System.Windows.Forms.TabPage();
            this.txtTotalDevolucion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSalirCompra = new System.Windows.Forms.Button();
            this.gbDetalleProducto = new System.Windows.Forms.GroupBox();
            this.dgvProductosDevolucion = new System.Windows.Forms.DataGridView();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.gbEncabezadoCompra = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAutorizacionNC = new System.Windows.Forms.TextBox();
            this.txtImpuesto = new System.Windows.Forms.TextBox();
            this.txtNumeroNC = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtSerie1NC = new System.Windows.Forms.TextBox();
            this.txtSerie1 = new System.Windows.Forms.TextBox();
            this.txtSerie2NC = new System.Windows.Forms.TextBox();
            this.txtSerie2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbProveedor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvDatosProducto = new System.Windows.Forms.DataGridView();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iceProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.irbpProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDevolver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.devolucion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabControl1.SuspendLayout();
            this.pcOrdenCompra.SuspendLayout();
            this.gbDetalleProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosDevolucion)).BeginInit();
            this.gbEncabezadoCompra.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosProducto)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pcOrdenCompra);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(15, 6);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(934, 607);
            this.tabControl1.TabIndex = 2;
            // 
            // pcOrdenCompra
            // 
            this.pcOrdenCompra.BackColor = System.Drawing.Color.Bisque;
            this.pcOrdenCompra.Controls.Add(this.txtTotalDevolucion);
            this.pcOrdenCompra.Controls.Add(this.label5);
            this.pcOrdenCompra.Controls.Add(this.btnSalirCompra);
            this.pcOrdenCompra.Controls.Add(this.gbDetalleProducto);
            this.pcOrdenCompra.Controls.Add(this.txtTotal);
            this.pcOrdenCompra.Controls.Add(this.label10);
            this.pcOrdenCompra.Controls.Add(this.BtnLimpiar);
            this.pcOrdenCompra.Controls.Add(this.BtnGuardar);
            this.pcOrdenCompra.Controls.Add(this.gbEncabezadoCompra);
            this.pcOrdenCompra.ForeColor = System.Drawing.Color.DarkCyan;
            this.pcOrdenCompra.Location = new System.Drawing.Point(4, 25);
            this.pcOrdenCompra.Margin = new System.Windows.Forms.Padding(2);
            this.pcOrdenCompra.Name = "pcOrdenCompra";
            this.pcOrdenCompra.Padding = new System.Windows.Forms.Padding(2);
            this.pcOrdenCompra.Size = new System.Drawing.Size(926, 578);
            this.pcOrdenCompra.TabIndex = 0;
            this.pcOrdenCompra.Text = "Nota de Crédito";
            // 
            // txtTotalDevolucion
            // 
            this.txtTotalDevolucion.Enabled = false;
            this.txtTotalDevolucion.Font = new System.Drawing.Font("Arial", 22F);
            this.txtTotalDevolucion.Location = new System.Drawing.Point(638, 528);
            this.txtTotalDevolucion.Name = "txtTotalDevolucion";
            this.txtTotalDevolucion.ReadOnly = true;
            this.txtTotalDevolucion.Size = new System.Drawing.Size(259, 41);
            this.txtTotalDevolucion.TabIndex = 59;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(497, 540);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 16);
            this.label5.TabIndex = 60;
            this.label5.Text = "Total Devolución:";
            // 
            // btnSalirCompra
            // 
            this.btnSalirCompra.Image = global::Comisariato.Properties.Resources.salir2;
            this.btnSalirCompra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirCompra.Location = new System.Drawing.Point(18, 481);
            this.btnSalirCompra.Name = "btnSalirCompra";
            this.btnSalirCompra.Size = new System.Drawing.Size(96, 53);
            this.btnSalirCompra.TabIndex = 10;
            this.btnSalirCompra.Text = "Salir";
            this.btnSalirCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalirCompra.UseVisualStyleBackColor = true;
            // 
            // gbDetalleProducto
            // 
            this.gbDetalleProducto.Controls.Add(this.dgvProductosDevolucion);
            this.gbDetalleProducto.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gbDetalleProducto.ForeColor = System.Drawing.Color.Teal;
            this.gbDetalleProducto.Location = new System.Drawing.Point(11, 138);
            this.gbDetalleProducto.Name = "gbDetalleProducto";
            this.gbDetalleProducto.Size = new System.Drawing.Size(891, 337);
            this.gbDetalleProducto.TabIndex = 5;
            this.gbDetalleProducto.TabStop = false;
            this.gbDetalleProducto.Text = "Detalle de Productos";
            // 
            // dgvProductosDevolucion
            // 
            this.dgvProductosDevolucion.AllowUserToResizeRows = false;
            this.dgvProductosDevolucion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductosDevolucion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductosDevolucion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductosDevolucion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.producto,
            this.cantidad,
            this.precioCompra,
            this.descuento,
            this.iceProducto,
            this.irbpProducto,
            this.subtotal,
            this.iva,
            this.total,
            this.cantidadDevolver,
            this.devolucion});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductosDevolucion.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductosDevolucion.Location = new System.Drawing.Point(6, 21);
            this.dgvProductosDevolucion.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProductosDevolucion.Name = "dgvProductosDevolucion";
            this.dgvProductosDevolucion.RowHeadersVisible = false;
            this.dgvProductosDevolucion.Size = new System.Drawing.Size(880, 295);
            this.dgvProductosDevolucion.TabIndex = 7;
            this.dgvProductosDevolucion.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductosDevolucion_CellEndEdit);
            this.dgvProductosDevolucion.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvProductosDevolucion_EditingControlShowing);
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Arial", 22F);
            this.txtTotal.Location = new System.Drawing.Point(638, 481);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(259, 41);
            this.txtTotal.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.DarkCyan;
            this.label10.Location = new System.Drawing.Point(497, 493);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 16);
            this.label10.TabIndex = 49;
            this.label10.Text = "Total Compra:";
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Image = global::Comisariato.Properties.Resources.limpiar;
            this.BtnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLimpiar.Location = new System.Drawing.Point(320, 481);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(135, 77);
            this.BtnLimpiar.TabIndex = 9;
            this.BtnLimpiar.Text = "&Limpiar";
            this.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Image = global::Comisariato.Properties.Resources.guardar11;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(168, 481);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(135, 77);
            this.BtnGuardar.TabIndex = 8;
            this.BtnGuardar.Text = "&Guardar";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // gbEncabezadoCompra
            // 
            this.gbEncabezadoCompra.Controls.Add(this.label4);
            this.gbEncabezadoCompra.Controls.Add(this.txtAutorizacionNC);
            this.gbEncabezadoCompra.Controls.Add(this.txtImpuesto);
            this.gbEncabezadoCompra.Controls.Add(this.txtNumeroNC);
            this.gbEncabezadoCompra.Controls.Add(this.txtNumero);
            this.gbEncabezadoCompra.Controls.Add(this.txtSerie1NC);
            this.gbEncabezadoCompra.Controls.Add(this.txtSerie1);
            this.gbEncabezadoCompra.Controls.Add(this.txtSerie2NC);
            this.gbEncabezadoCompra.Controls.Add(this.txtSerie2);
            this.gbEncabezadoCompra.Controls.Add(this.label2);
            this.gbEncabezadoCompra.Controls.Add(this.label1);
            this.gbEncabezadoCompra.Controls.Add(this.label13);
            this.gbEncabezadoCompra.Controls.Add(this.cbProveedor);
            this.gbEncabezadoCompra.Controls.Add(this.label3);
            this.gbEncabezadoCompra.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.gbEncabezadoCompra.ForeColor = System.Drawing.Color.Teal;
            this.gbEncabezadoCompra.Location = new System.Drawing.Point(103, 8);
            this.gbEncabezadoCompra.Name = "gbEncabezadoCompra";
            this.gbEncabezadoCompra.Size = new System.Drawing.Size(720, 128);
            this.gbEncabezadoCompra.TabIndex = 0;
            this.gbEncabezadoCompra.TabStop = false;
            this.gbEncabezadoCompra.Text = "Datos de la Orden de Compra";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(429, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 51;
            this.label4.Text = "Autorización:";
            // 
            // txtAutorizacionNC
            // 
            this.txtAutorizacionNC.Font = new System.Drawing.Font("Arial", 10F);
            this.txtAutorizacionNC.Location = new System.Drawing.Point(515, 21);
            this.txtAutorizacionNC.MaxLength = 9;
            this.txtAutorizacionNC.Name = "txtAutorizacionNC";
            this.txtAutorizacionNC.ReadOnly = true;
            this.txtAutorizacionNC.Size = new System.Drawing.Size(185, 23);
            this.txtAutorizacionNC.TabIndex = 63;
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.Location = new System.Drawing.Point(515, 52);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.ReadOnly = true;
            this.txtImpuesto.Size = new System.Drawing.Size(54, 22);
            this.txtImpuesto.TabIndex = 49;
            // 
            // txtNumeroNC
            // 
            this.txtNumeroNC.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNumeroNC.Location = new System.Drawing.Point(268, 21);
            this.txtNumeroNC.MaxLength = 9;
            this.txtNumeroNC.Name = "txtNumeroNC";
            this.txtNumeroNC.ReadOnly = true;
            this.txtNumeroNC.Size = new System.Drawing.Size(156, 23);
            this.txtNumeroNC.TabIndex = 62;
            // 
            // txtNumero
            // 
            this.txtNumero.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNumero.Location = new System.Drawing.Point(268, 82);
            this.txtNumero.MaxLength = 9;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(156, 23);
            this.txtNumero.TabIndex = 4;
            this.txtNumero.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumero_KeyDown);
            this.txtNumero.Leave += new System.EventHandler(this.cbProveedor_Leave);
            // 
            // txtSerie1NC
            // 
            this.txtSerie1NC.Font = new System.Drawing.Font("Arial", 10F);
            this.txtSerie1NC.Location = new System.Drawing.Point(147, 21);
            this.txtSerie1NC.MaxLength = 3;
            this.txtSerie1NC.Name = "txtSerie1NC";
            this.txtSerie1NC.ReadOnly = true;
            this.txtSerie1NC.Size = new System.Drawing.Size(56, 23);
            this.txtSerie1NC.TabIndex = 60;
            // 
            // txtSerie1
            // 
            this.txtSerie1.Font = new System.Drawing.Font("Arial", 10F);
            this.txtSerie1.Location = new System.Drawing.Point(147, 82);
            this.txtSerie1.MaxLength = 3;
            this.txtSerie1.Name = "txtSerie1";
            this.txtSerie1.Size = new System.Drawing.Size(56, 23);
            this.txtSerie1.TabIndex = 2;
            this.txtSerie1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbProveedor_KeyDown);
            // 
            // txtSerie2NC
            // 
            this.txtSerie2NC.Font = new System.Drawing.Font("Arial", 10F);
            this.txtSerie2NC.Location = new System.Drawing.Point(207, 21);
            this.txtSerie2NC.MaxLength = 3;
            this.txtSerie2NC.Name = "txtSerie2NC";
            this.txtSerie2NC.ReadOnly = true;
            this.txtSerie2NC.Size = new System.Drawing.Size(56, 23);
            this.txtSerie2NC.TabIndex = 61;
            // 
            // txtSerie2
            // 
            this.txtSerie2.Font = new System.Drawing.Font("Arial", 10F);
            this.txtSerie2.Location = new System.Drawing.Point(207, 82);
            this.txtSerie2.MaxLength = 3;
            this.txtSerie2.Name = "txtSerie2";
            this.txtSerie2.Size = new System.Drawing.Size(56, 23);
            this.txtSerie2.TabIndex = 3;
            this.txtSerie2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbProveedor_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label2.Location = new System.Drawing.Point(10, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 48;
            this.label2.Text = "N° Nota de Crédito:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label1.Location = new System.Drawing.Point(10, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 16);
            this.label1.TabIndex = 48;
            this.label1.Text = "N° Factura Proveedor";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Teal;
            this.label13.Location = new System.Drawing.Point(10, 55);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 16);
            this.label13.TabIndex = 12;
            this.label13.Text = "Proveedor:";
            // 
            // cbProveedor
            // 
            this.cbProveedor.DropDownWidth = 225;
            this.cbProveedor.Font = new System.Drawing.Font("Arial", 10F);
            this.cbProveedor.Location = new System.Drawing.Point(147, 52);
            this.cbProveedor.Name = "cbProveedor";
            this.cbProveedor.Size = new System.Drawing.Size(277, 24);
            this.cbProveedor.TabIndex = 1;
            this.cbProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbProveedor_KeyDown);
            this.cbProveedor.Leave += new System.EventHandler(this.cbProveedor_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(429, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "Impuesto:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Bisque;
            this.tabPage2.Controls.Add(this.dgvDatosProducto);
            this.tabPage2.Controls.Add(this.textBox7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(926, 578);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consultar Nota de Credito";
            // 
            // dgvDatosProducto
            // 
            this.dgvDatosProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatosProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDatosProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosProducto.Location = new System.Drawing.Point(17, 132);
            this.dgvDatosProducto.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatosProducto.Name = "dgvDatosProducto";
            this.dgvDatosProducto.Size = new System.Drawing.Size(1012, 399);
            this.dgvDatosProducto.TabIndex = 14;
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(556, 57);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(414, 22);
            this.textBox7.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Teal;
            this.label8.Location = new System.Drawing.Point(469, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Consultar:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker3);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.ForeColor = System.Drawing.Color.Teal;
            this.groupBox2.Location = new System.Drawing.Point(17, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 113);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fecha";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker3.Location = new System.Drawing.Point(91, 66);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(292, 22);
            this.dateTimePicker3.TabIndex = 20;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Location = new System.Drawing.Point(91, 27);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(292, 22);
            this.dateTimePicker2.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(25, 71);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 16);
            this.label14.TabIndex = 18;
            this.label14.Text = "Hasta:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(25, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 16);
            this.label16.TabIndex = 17;
            this.label16.Text = "Desde:";
            // 
            // codigo
            // 
            this.codigo.FillWeight = 147.1193F;
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Width = 95;
            // 
            // producto
            // 
            this.producto.FillWeight = 208.2813F;
            this.producto.HeaderText = "Producto";
            this.producto.Name = "producto";
            this.producto.ReadOnly = true;
            this.producto.Width = 200;
            // 
            // cantidad
            // 
            this.cantidad.FillWeight = 60.1572F;
            this.cantidad.HeaderText = "Cant.";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 45;
            // 
            // precioCompra
            // 
            this.precioCompra.FillWeight = 75.41525F;
            this.precioCompra.HeaderText = "P.C.";
            this.precioCompra.Name = "precioCompra";
            this.precioCompra.ReadOnly = true;
            this.precioCompra.Width = 50;
            // 
            // descuento
            // 
            this.descuento.FillWeight = 90.65001F;
            this.descuento.HeaderText = "Desc.";
            this.descuento.Name = "descuento";
            this.descuento.ReadOnly = true;
            this.descuento.Width = 50;
            // 
            // iceProducto
            // 
            this.iceProducto.FillWeight = 65.87027F;
            this.iceProducto.HeaderText = "ICE";
            this.iceProducto.Name = "iceProducto";
            this.iceProducto.ReadOnly = true;
            this.iceProducto.Width = 45;
            // 
            // irbpProducto
            // 
            this.irbpProducto.FillWeight = 68.26523F;
            this.irbpProducto.HeaderText = "IRBP";
            this.irbpProducto.Name = "irbpProducto";
            this.irbpProducto.ReadOnly = true;
            this.irbpProducto.Width = 51;
            // 
            // subtotal
            // 
            this.subtotal.FillWeight = 107.4997F;
            this.subtotal.HeaderText = "Subtotal";
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            this.subtotal.Width = 80;
            // 
            // iva
            // 
            this.iva.FillWeight = 64.72799F;
            this.iva.HeaderText = "IVA";
            this.iva.Name = "iva";
            this.iva.ReadOnly = true;
            this.iva.Width = 49;
            // 
            // total
            // 
            this.total.FillWeight = 96.68581F;
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 70;
            // 
            // cantidadDevolver
            // 
            this.cantidadDevolver.HeaderText = "C. Dev.";
            this.cantidadDevolver.MaxInputLength = 5;
            this.cantidadDevolver.Name = "cantidadDevolver";
            this.cantidadDevolver.Width = 80;
            // 
            // devolucion
            // 
            this.devolucion.HeaderText = "Dev";
            this.devolucion.Name = "devolucion";
            this.devolucion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.devolucion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.devolucion.Width = 40;
            // 
            // FrmDevolucionCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(961, 624);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmDevolucionCompra";
            this.Text = "Nota de Crédito";
            this.Load += new System.EventHandler(this.FrmDevolucionCompra_Load);
            this.tabControl1.ResumeLayout(false);
            this.pcOrdenCompra.ResumeLayout(false);
            this.pcOrdenCompra.PerformLayout();
            this.gbDetalleProducto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosDevolucion)).EndInit();
            this.gbEncabezadoCompra.ResumeLayout(false);
            this.gbEncabezadoCompra.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosProducto)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pcOrdenCompra;
        private System.Windows.Forms.Button btnSalirCompra;
        private System.Windows.Forms.GroupBox gbDetalleProducto;
        private System.Windows.Forms.DataGridView dgvProductosDevolucion;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.GroupBox gbEncabezadoCompra;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtSerie1;
        private System.Windows.Forms.TextBox txtSerie2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbProveedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvDatosProducto;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtNumeroNC;
        private System.Windows.Forms.TextBox txtSerie1NC;
        private System.Windows.Forms.TextBox txtSerie2NC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtImpuesto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAutorizacionNC;
        private System.Windows.Forms.TextBox txtTotalDevolucion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn iceProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn irbpProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn iva;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDevolver;
        private System.Windows.Forms.DataGridViewCheckBoxColumn devolucion;
    }
}