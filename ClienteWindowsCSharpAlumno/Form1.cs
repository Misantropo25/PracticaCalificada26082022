using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWindowsCSharp_Alumno
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Llamar al servicio
        private static ServiceReference1.WebService3SoapClient servicio;
        private void Form1_Load(object sender, EventArgs e)
        {
            servicio = new ServiceReference1.WebService3SoapClient();
            dgvTabla.DataSource = servicio.Listar().Tables[0];

            //ComboBox
            cbBuscar.Items.Add("codAlumno");
            cbBuscar.Items.Add("alumno");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Leer las cajas de texto
            string codigoAlumno = tbCodigoAlumno.Text.Trim();
            string apellidos = tbApellidos.Text.Trim();
            string faNombrescultad = tbNombres.Text.Trim();
            string lugarNacimiento = tbLugarNacimiento.Text.Trim();
            string fechaNacimiento = tbFechaNacimiento.Text.Trim();
            string codigoEscuela = tbCodigoEscuela.Text.Trim();
            // Servicio y obtener la respuesta del mismo
            servicio = new ServiceReference1.WebService3SoapClient();
            string[] rsta = servicio.AgregarAlumno(codigoAlumno, apellidos, faNombrescultad, lugarNacimiento, fechaNacimiento, codigoEscuela);
            if (rsta[0] == "0")
            {
                dgvTabla.DataSource = servicio.Listar().Tables[0];
            }
            MessageBox.Show(rsta[1]);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Leer las cajas de texto
            string codigoAlumno = tbCodigoAlumno.Text.Trim();
            // Servicio y obtener la respuesta del mismo
            servicio = new ServiceReference1.WebService3SoapClient();
            string[] rsta = servicio.EliminarAlumno(codigoAlumno);
            if (rsta[0] == "0")
            {
                dgvTabla.DataSource = servicio.Listar().Tables[0];
            }
            MessageBox.Show(rsta[1]);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Leer las cajas de texto
            string codigoAlumno = tbCodigoAlumno.Text.Trim();
            string apellidos = tbApellidos.Text.Trim();
            string faNombrescultad = tbNombres.Text.Trim();
            string lugarNacimiento = tbLugarNacimiento.Text.Trim();
            string fechaNacimiento = tbFechaNacimiento.Text.Trim();
            string codigoEscuela = tbCodigoEscuela.Text.Trim();
            // Servicio y obtener la respuesta del mismo
            servicio = new ServiceReference1.WebService3SoapClient();
            string[] rsta = servicio.ActualizarAlumno(codigoAlumno, apellidos, faNombrescultad, lugarNacimiento, fechaNacimiento, codigoEscuela);
            if (rsta[0] == "0")
            {
                dgvTabla.DataSource = servicio.Listar().Tables[0];
            }
            MessageBox.Show(rsta[1]);
        }

        private void cbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Leer las cajas de texto
            string texto = tbBuscar.Text.Trim();

            // Servicio y obtener la respuesta del mismo
            servicio = new ServiceReference1.WebService3SoapClient();
            
            dgvTabla.DataSource = servicio.BuscarAlumno(texto, cbBuscar.SelectedItem.ToString()).Tables[0];
        }
    }
}
