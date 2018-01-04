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

namespace Comisariato.Formularios.SRI
{
    public partial class FormEnviarArchivos : Form
    {
        public FormEnviarArchivos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\MaxDJ\Desktop\prueba\");
            foreach (var fi in di.GetFiles("test?.txt"))
            {
                MessageBox.Show(fi.Name);
            }
        }
    }
}
