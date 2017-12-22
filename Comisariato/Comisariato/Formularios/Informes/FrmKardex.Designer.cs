namespace Comisariato.Formularios.Informes
{
    partial class FrmKardex
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
            this.gbEncabezadoKardex = new System.Windows.Forms.GroupBox();
            this.btnGenerarKardex = new System.Windows.Forms.Button();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvKardex = new System.Windows.Forms.DataGridView();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadExistecia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoExistencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalExistencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbEncabezadoKardex.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).BeginInit();
            this.SuspendLayout();
            // 
            // gbEncabezadoKardex
            // 
            this.gbEncabezadoKardex.Controls.Add(this.btnGenerarKardex);
            this.gbEncabezadoKardex.Controls.Add(this.cbCategoria);
            this.gbEncabezadoKardex.Controls.Add(this.txtProducto);
            this.gbEncabezadoKardex.Controls.Add(this.dtpHasta);
            this.gbEncabezadoKardex.Controls.Add(this.dtpDesde);
            this.gbEncabezadoKardex.Controls.Add(this.label7);
            this.gbEncabezadoKardex.Controls.Add(this.label6);
            this.gbEncabezadoKardex.Controls.Add(this.label5);
            this.gbEncabezadoKardex.Controls.Add(this.label4);
            this.gbEncabezadoKardex.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEncabezadoKardex.ForeColor = System.Drawing.Color.Teal;
            this.gbEncabezadoKardex.Location = new System.Drawing.Point(12, 12);
            this.gbEncabezadoKardex.Name = "gbEncabezadoKardex";
            this.gbEncabezadoKardex.Size = new System.Drawing.Size(1061, 131);
            this.gbEncabezadoKardex.TabIndex = 0;
            this.gbEncabezadoKardex.TabStop = false;
            this.gbEncabezadoKardex.Text = "Información Necesaria para el Kardex";
            // 
            // btnGenerarKardex
            // 
            this.btnGenerarKardex.Location = new System.Drawing.Point(898, 21);
            this.btnGenerarKardex.Name = "btnGenerarKardex";
            this.btnGenerarKardex.Size = new System.Drawing.Size(133, 86);
            this.btnGenerarKardex.TabIndex = 6;
            this.btnGenerarKardex.Text = "Generar";
            this.btnGenerarKardex.UseVisualStyleBackColor = true;
            this.btnGenerarKardex.Click += new System.EventHandler(this.btnGenerarKardex_Click);
            // 
            // cbCategoria
            // 
            this.cbCategoria.Enabled = false;
            this.cbCategoria.Font = new System.Drawing.Font("Arial", 10F);
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(544, 32);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(296, 24);
            this.cbCategoria.TabIndex = 5;
            // 
            // txtProducto
            // 
            this.txtProducto.Font = new System.Drawing.Font("Arial", 10F);
            this.txtProducto.Location = new System.Drawing.Point(544, 74);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(296, 23);
            this.txtProducto.TabIndex = 4;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Arial", 10F);
            this.dtpHasta.Location = new System.Drawing.Point(152, 74);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(253, 23);
            this.dtpHasta.TabIndex = 3;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Arial", 10F);
            this.dtpDesde.Location = new System.Drawing.Point(152, 33);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(253, 23);
            this.dtpDesde.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Font = new System.Drawing.Font("Arial", 10F);
            this.label7.Location = new System.Drawing.Point(451, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Categoria:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10F);
            this.label6.Location = new System.Drawing.Point(451, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Producto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10F);
            this.label5.Location = new System.Drawing.Point(36, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Fecha Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10F);
            this.label4.Location = new System.Drawing.Point(36, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Fecha Desde:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.dgvKardex);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Teal;
            this.groupBox2.Location = new System.Drawing.Point(12, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1061, 460);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle del Kardex";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(631, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(202, 40);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(77, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Salida";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(832, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 40);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(63, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Existencia";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(429, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 40);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(73, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Entrada";
            // 
            // dgvKardex
            // 
            this.dgvKardex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKardex.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fecha,
            this.descripcion,
            this.cantidadEntrada,
            this.costoEntrada,
            this.totalEntrada,
            this.cantidadSalida,
            this.costoSalida,
            this.totalSalida,
            this.cantidadExistecia,
            this.costoExistencia,
            this.totalExistencia});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKardex.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKardex.Location = new System.Drawing.Point(0, 52);
            this.dgvKardex.Name = "dgvKardex";
            this.dgvKardex.RowHeadersVisible = false;
            this.dgvKardex.Size = new System.Drawing.Size(1050, 385);
            this.dgvKardex.TabIndex = 0;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.Width = 165;
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.Width = 265;
            // 
            // cantidadEntrada
            // 
            this.cantidadEntrada.HeaderText = "Cant";
            this.cantidadEntrada.Name = "cantidadEntrada";
            this.cantidadEntrada.Width = 50;
            // 
            // costoEntrada
            // 
            this.costoEntrada.HeaderText = "Costo";
            this.costoEntrada.Name = "costoEntrada";
            this.costoEntrada.Width = 75;
            // 
            // totalEntrada
            // 
            this.totalEntrada.HeaderText = "Total";
            this.totalEntrada.Name = "totalEntrada";
            this.totalEntrada.Width = 75;
            // 
            // cantidadSalida
            // 
            this.cantidadSalida.HeaderText = "Cant";
            this.cantidadSalida.Name = "cantidadSalida";
            this.cantidadSalida.Width = 50;
            // 
            // costoSalida
            // 
            this.costoSalida.HeaderText = "Costo";
            this.costoSalida.Name = "costoSalida";
            this.costoSalida.Width = 75;
            // 
            // totalSalida
            // 
            this.totalSalida.HeaderText = "Total";
            this.totalSalida.Name = "totalSalida";
            this.totalSalida.Width = 75;
            // 
            // cantidadExistecia
            // 
            this.cantidadExistecia.HeaderText = "Cant";
            this.cantidadExistecia.Name = "cantidadExistecia";
            this.cantidadExistecia.Width = 50;
            // 
            // costoExistencia
            // 
            this.costoExistencia.HeaderText = "Costo";
            this.costoExistencia.Name = "costoExistencia";
            this.costoExistencia.Width = 75;
            // 
            // totalExistencia
            // 
            this.totalExistencia.HeaderText = "Total";
            this.totalExistencia.Name = "totalExistencia";
            this.totalExistencia.Width = 75;
            // 
            // FrmKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(1085, 628);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbEncabezadoKardex);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "FrmKardex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Kardex";
            this.Load += new System.EventHandler(this.FrmKardex_Load);
            this.gbEncabezadoKardex.ResumeLayout(false);
            this.gbEncabezadoKardex.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEncabezadoKardex;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvKardex;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadExistecia;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoExistencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalExistencia;
        private System.Windows.Forms.Button btnGenerarKardex;
    }
}