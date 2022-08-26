using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWindowsCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Llamar al servicio
        private static ServiceReference1.WebService2SoapClient servicio;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Leer las cajas de texto
            string codEscuela = txtCodEscuela.Text.Trim();
            string escuela = txtEscuela.Text.Trim();
            string facultad = txtFacultad.Text.Trim();

            //Servicio y obtener respuesta del mismo
            servicio = new ServiceReference1.WebService2SoapClient();
            string[] rsta = servicio.Agregar(codEscuela,escuela,facultad).ToArray();

            if (rsta[0] == "0") {
                dgvEscuela.DataSource = servicio.Listar().Tables[0];
            }
            MessageBox.Show(rsta[1]);


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            servicio = new ServiceReference1.WebService2SoapClient();
            dgvEscuela.DataSource = servicio.Listar().Tables[0];



        }
    }
}
