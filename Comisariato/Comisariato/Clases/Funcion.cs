using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Net;
using Comisariato.Formularios;

namespace Comisariato.Clases
{
    public class Funcion
    {
        public void AddFormInPanel(Form formHijo /*, Panel panelPrincipal*/)
        {
            //Form fh = formHijo as Form;
            //fh.TopLevel = false;
            //panelPrincipal.Controls.Add(fh);
            ////panelPrincipal.Tag = fh;
            //int index = panelPrincipal.Controls.GetChildIndex(fh);
            //fh.BringToFront();
            //fh.Show();
            formHijo = new Form();
            //Form fh = (Form)formHijo;
            FrmPrincipal frmprincipal = new FrmPrincipal();
            if (formHijo == null || formHijo.IsDisposed)
            {
                formHijo = new Form();
                formHijo.MdiParent = frmprincipal;
                formHijo.BringToFront();
                formHijo.Show();

            }
            else { formHijo.BringToFront(); }
        }

        public static bool ExportarDataGridViewExcel(DataGridView grd,int InicioDeColumna) //InicioDeColumna comienza desde 0
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();
                    hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                    for (int i = 0; i < grd.ColumnCount; i++)
                    {
                        hoja_trabajo.Cells[1, i + 1] = grd.Columns[i].HeaderText;
                    }
                    //Recorremos el DataGridView rellenando la hoja de trabajo
                    for (int i = 1; i < grd.Rows.Count - 1; i++)
                    {
                        for (int j = InicioDeColumna; j < grd.Columns.Count; j++)
                        {
                            hoja_trabajo.Cells[i + 1, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    libros_trabajo.SaveAs(fichero.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }


        public static void ValidarNumerosStock(DataGridViewCellValidatingEventArgs e, DataGridView Dgv)
        {
            int testInt;
            try
            {
                if (e.ColumnIndex == 2)
                {
                    if (e.FormattedValue.ToString().Length != 0)
                    {
                        if (!int.TryParse(e.FormattedValue.ToString(), out testInt))
                        {

                            Dgv.Rows[e.RowIndex].ErrorText = "La cantidad debe ser un número";
                            e.Cancel = true;
                        }
                        else
                        {
                            Dgv.Rows[e.RowIndex].ErrorText = string.Empty;
                            e.Cancel = false;
                        }
                    }


                }
            }
            catch (Exception ex)
            {

            }

        }

        public static void Validar_Letras(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public static void SinEspaciosEmail(KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public static void Validar_Numeros(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public static void Validar_Numeros_Punto(KeyPressEventArgs e, string texto)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                string[] a = texto.Split('.');
                foreach (var item in a)
                {
                    if (item.Length >= 3)
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
            }
            else if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.')
            {
                int ocurrenciasPuntos = texto.Split('.').Length;
                if (e.KeyChar == '.' && ocurrenciasPuntos <= 3)
                {

                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }


        public static void validar_Num_Letras(KeyPressEventArgs e)
        {

            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public static void SoloValores(KeyPressEventArgs e, string textBox1)
        {
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.')
            {
                if (e.KeyChar == '.')
                {
                    if (textBox1.Contains(".") || textBox1 == "")
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    if (textBox1.Contains("."))
                        if (textBox1.Substring(textBox1.IndexOf('.') + 1).Length >= 6)
                        {
                            e.Handled = true;
                        }
                }

            }
            else
            {
                e.Handled = true;
            }

        }

        public static void ValidarLetrasPuntoNumero(KeyPressEventArgs e, string textBox1)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.')
            {
                if (e.KeyChar == '.')
                {
                    //if (textBox1.Contains(".") || textBox1 == "")
                    //{
                    e.Handled = false;
                    //}
                }
                //else
                //{
                //if (textBox1.Contains("."))
                //if (textBox1.Substring(textBox1.IndexOf('.') + 1).Length >= 2)
                //{
                //e.Handled = true;
                //}
                //}

            }
            else
            {
                e.Handled = true;
            }

        }


        //SOLO NUMEROS DGV
        private static void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // Si no es numerico y si no es espacio
            {
                // Invalidar la accion
                e.Handled = true;
                // Enviar el sonido de beep de windows
                System.Media.SystemSounds.Beep.Play();
            }

        }

        public static void Limpiarobjetos(GroupBox frm)
        {
            foreach (Control item in frm.Controls)
            {
                if (item is TextBox)
                    item.Text = "";
                if (item is MaskedTextBox)
                    item.Text = "";

                if (item is DataGridView)
                    item.Controls.Clear();
            }
        }

        public static byte[] imgToByteArray(Image img)
        {
            using (MemoryStream mStream = new MemoryStream())
            {
                img.Save(mStream, img.RawFormat);
                return mStream.ToArray();
            }
        }

        public static byte[] ConvertImg_Bytes(String ubicacion)
        {
            FileStream stream = new FileStream(ubicacion, FileMode.Open, FileAccess.Read);
            //Se inicailiza un flujo de archivo con la imagen seleccionada desde el disco.
            BinaryReader br = new BinaryReader(stream);
            FileInfo fi = new FileInfo(ubicacion);

            //Se inicializa un arreglo de Bytes del tamaño de la imagen
            byte[] bitDataFoto = new byte[stream.Length];
            //Se almacena en el arreglo de bytes la informacion que se obtiene del flujo de archivos(foto)
            //Lee el bloque de bytes del flujo y escribe los datos en un búfer dado.
            stream.Read(bitDataFoto, 0, Convert.ToInt32(stream.Length));
            return bitDataFoto;
        }


        public static String reemplazarcaracter(String cadena)
        {
            if (cadena.Contains(","))
            {
                return cadena.Replace(",", ".");
            }
            else
            {
                return cadena;
            }
        }

        public static String reemplazarcaracterFecha(String cadena)
        {
                string[] fecha = cadena.Split('/');

                string FinalFecha = fecha[2] + "-" + fecha[1] + "-" + fecha[0];

                return FinalFecha;
        }


        public static String reemplazarcaracterViceversa(String cadena)
        {
            if (cadena.Contains("."))
            {
                return cadena.Replace(".", ",");
            }
            else
            {
                return cadena;
            }
        }

        /// Verificar Cedula
        public static bool VerificarCedula(string cedula)
        {
            int isNumeric;
            var total = 0;
            const int tamanoLongitudCedula = 10;
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            const int numeroProvincias = 24;
            const int tercerDigito = 6;
            if (int.TryParse(cedula, out isNumeric) && cedula.Length == tamanoLongitudCedula)
            {
                var provincia = Convert.ToInt32(string.Concat(cedula[0], cedula[1], string.Empty));
                var digitoTres = Convert.ToInt32(cedula[2] + string.Empty);
                if ((provincia > 0 && provincia <= numeroProvincias) && digitoTres < tercerDigito)
                {
                    var digitoVerificadorRecibido = Convert.ToInt32(cedula[9] + string.Empty);
                    for (var k = 0; k < coeficientes.Length; k++)
                    {
                        var valor = Convert.ToInt32(coeficientes[k] + string.Empty) * Convert.ToInt32(cedula[k] + string.Empty);
                        total = valor >= 10 ? total + (valor - 9) : total + valor;
                    }
                    var digitoVerificadorObtenido = total >= 10 ? (total % 10) != 0 ? 10 - (total % 10) : (total % 10) : total;
                    return digitoVerificadorObtenido == digitoVerificadorRecibido;
                }
                return false;
            }
            return false;
        }

        public static bool ValidaIP(string direccionIP)
        {
            try
            { IPAddress ip = IPAddress.Parse(direccionIP); }
            catch
            { return false; }

            return true;
        }
        public static void ValidaCeldasPrecios(DataGridView datosProductoCompra, int posicion, ref bool banderaFocoCelda)
        {
            try
            {
                float valor;
                string validaValores = Convert.ToString(datosProductoCompra.CurrentRow.Cells[posicion].Value);
                string[] s = validaValores.Split('.');
                if (validaValores.Substring(0, 1) == "." || validaValores.Substring(0, 1) == ",")
                {
                    validaValores = "0" + validaValores;
                }
                if (validaValores.Substring(validaValores.Length - 1, 1) == "." || validaValores.Substring(validaValores.Length - 1, 1) == ",")
                {
                    validaValores = validaValores + "0";
                }
                int ocurrencias, ocurrecias2, ocurrenciasComas;
                ocurrencias = validaValores.Split('.').Length - 1;
                ocurrenciasComas = validaValores.Split(',').Length - 1;
                ocurrecias2 = validaValores.Split(new String[] { ".," }, StringSplitOptions.None).Length - 1;
                if (ocurrencias > 1 || ocurrecias2 != 0)
                {
                    valor = float.Parse("a");
                }
                else if (ocurrencias == 0 && ocurrenciasComas == 0)
                {
                    validaValores = validaValores + ".0";
                }
                ocurrencias = validaValores.Split('.').Length - 1;
                ocurrenciasComas = validaValores.Split(',').Length - 1;
                if (ocurrencias == 0)
                {
                    s = validaValores.Split(',');
                }
                else if (ocurrenciasComas == 0)
                {
                    s = validaValores.Split('.');
                }
                string valor1 = s[1];
                if (valor1.Length > 6)
                {
                    valor = float.Parse("a");
                }
                valor = float.Parse(validaValores);
                datosProductoCompra.CurrentRow.Cells[posicion].Value = Funcion.reemplazarcaracter(validaValores);
                banderaFocoCelda = false;
            }
            catch (Exception errorPrecio)
            {
                //MessageBox.Show("Ingresar valores correctos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                datosProductoCompra.CurrentRow.Cells[posicion].Value = "";
                //datosProductoCompra.BeginEdit(true);
                SendKeys.Send("{LEFT}");
                banderaFocoCelda = true;
            }
        }

        public static string[] leerArchivo(string ruta)
        {
            try
            {
                string line;
                string lineDatos = "";
                string[] VectorDatos;
                System.IO.StreamReader file =
                    new System.IO.StreamReader(ruta);
                while ((line = file.ReadLine()) != null)
                {
                    lineDatos += line + ";";

                }

                file.Close();
                if (lineDatos != "")
                {
                    VectorDatos = lineDatos.Split(';');
                    return VectorDatos;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

    }
}
