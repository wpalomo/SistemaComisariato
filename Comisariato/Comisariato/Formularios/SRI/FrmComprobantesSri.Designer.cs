namespace Comisariato.Formularios.SRI
{
    partial class FrmComprobantesSri
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tabControlErroresSri = new System.Windows.Forms.TabControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvComprobantesErroneos = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XML = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROCESADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECEPCIONSRI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AUTORIZACIONSRI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODIGOERROR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MENSAJEERROR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1.SuspendLayout();
            this.tabControlErroresSri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobantesErroneos)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Bisque;
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.BtnGuardar);
            this.tabPage1.Controls.Add(this.dgvComprobantesErroneos);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dateTimePicker2);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1088, 514);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Errores SRI";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(25, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha Inicial :";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(120, 10);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(165, 20);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(410, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(165, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // tabControlErroresSri
            // 
            this.tabControlErroresSri.Controls.Add(this.tabPage1);
            this.tabControlErroresSri.ItemSize = new System.Drawing.Size(77, 18);
            this.tabControlErroresSri.Location = new System.Drawing.Point(4, 52);
            this.tabControlErroresSri.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlErroresSri.Name = "tabControlErroresSri";
            this.tabControlErroresSri.Padding = new System.Drawing.Point(0, 0);
            this.tabControlErroresSri.SelectedIndex = 0;
            this.tabControlErroresSri.Size = new System.Drawing.Size(1096, 540);
            this.tabControlErroresSri.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(315, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha Inicial :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(10, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cantidad de Comprobantes Pendientes:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(267, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(143, 20);
            this.textBox1.TabIndex = 7;
            // 
            // dgvComprobantesErroneos
            // 
            this.dgvComprobantesErroneos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComprobantesErroneos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvComprobantesErroneos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DOC,
            this.XML,
            this.FECHA,
            this.PROCESADO,
            this.RECEPCIONSRI,
            this.AUTORIZACIONSRI,
            this.CODIGOERROR,
            this.MENSAJEERROR});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvComprobantesErroneos.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvComprobantesErroneos.Location = new System.Drawing.Point(12, 47);
            this.dgvComprobantesErroneos.Margin = new System.Windows.Forms.Padding(0);
            this.dgvComprobantesErroneos.MultiSelect = false;
            this.dgvComprobantesErroneos.Name = "dgvComprobantesErroneos";
            this.dgvComprobantesErroneos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvComprobantesErroneos.Size = new System.Drawing.Size(1059, 203);
            this.dgvComprobantesErroneos.TabIndex = 49;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(474, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 31);
            this.button1.TabIndex = 50;
            this.button1.Text = "Procesar Pendientes";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = global::Comisariato.Properties.Resources.BuscarArchivo;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(599, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(133, 39);
            this.btnBuscar.TabIndex = 48;
            this.btnBuscar.Text = "Consultar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Image = global::Comisariato.Properties.Resources.GUARDAR32X32;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(915, 463);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(155, 45);
            this.BtnGuardar.TabIndex = 50;
            this.BtnGuardar.Text = "&Guardar";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 275);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1059, 184);
            this.richTextBox1.TabIndex = 51;
            this.richTextBox1.Text = "";
            // 
            // DOC
            // 
            this.DOC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DOC.DefaultCellStyle = dataGridViewCellStyle15;
            this.DOC.FillWeight = 12.35128F;
            this.DOC.HeaderText = "Doc";
            this.DOC.Name = "DOC";
            this.DOC.ReadOnly = true;
            this.DOC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DOC.Width = 50;
            // 
            // XML
            // 
            this.XML.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.XML.FillWeight = 21.52845F;
            this.XML.HeaderText = "Xml";
            this.XML.Name = "XML";
            this.XML.ReadOnly = true;
            this.XML.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.XML.Width = 210;
            // 
            // FECHA
            // 
            this.FECHA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FECHA.FillWeight = 111.3851F;
            this.FECHA.HeaderText = "Fecha";
            this.FECHA.Name = "FECHA";
            this.FECHA.ReadOnly = true;
            this.FECHA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // PROCESADO
            // 
            this.PROCESADO.HeaderText = "Procesado";
            this.PROCESADO.Name = "PROCESADO";
            // 
            // RECEPCIONSRI
            // 
            this.RECEPCIONSRI.HeaderText = "Recepción SRI";
            this.RECEPCIONSRI.Name = "RECEPCIONSRI";
            // 
            // AUTORIZACIONSRI
            // 
            this.AUTORIZACIONSRI.HeaderText = "Autorización SRI";
            this.AUTORIZACIONSRI.Name = "AUTORIZACIONSRI";
            // 
            // CODIGOERROR
            // 
            this.CODIGOERROR.HeaderText = "Codigó Error";
            this.CODIGOERROR.Name = "CODIGOERROR";
            // 
            // MENSAJEERROR
            // 
            this.MENSAJEERROR.HeaderText = "Mensaje Error";
            this.MENSAJEERROR.Name = "MENSAJEERROR";
            // 
            // FrmComprobantesSri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(1109, 600);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tabControlErroresSri);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmComprobantesSri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Comprobantes SRI";
            this.Load += new System.EventHandler(this.FrmComprobantesSri_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControlErroresSri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobantesErroneos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TabControl tabControlErroresSri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvComprobantesErroneos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn XML;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROCESADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECEPCIONSRI;
        private System.Windows.Forms.DataGridViewTextBoxColumn AUTORIZACIONSRI;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGOERROR;
        private System.Windows.Forms.DataGridViewTextBoxColumn MENSAJEERROR;
    }
}