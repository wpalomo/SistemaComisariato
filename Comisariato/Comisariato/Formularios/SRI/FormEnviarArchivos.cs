﻿using System;
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
<<<<<<< HEAD
            //DirectoryInfo di = new DirectoryInfo(@"C:\Users\MaxDJ\Desktop\prueba\");
            //foreach (var fi in di.GetFiles("test?.txt"))
            //{
            //    MessageBox.Show(fi.Name);
            //}
=======


            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Public\Documents\ArchivosXml\Generados");
            foreach (var fi in di.GetFiles("0301201801180211442900110010980000000010000001015.xml"))
            {
                MessageBox.Show(fi.Name);
            }
>>>>>>> d4480264ea60c9b82a1a711569cb1112d5ed09c2
        }
    }
}
