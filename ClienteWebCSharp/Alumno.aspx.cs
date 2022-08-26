using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteWebCSharp
{
    public partial class Alumno : System.Web.UI.Page
    {
        private static ServiceReference3.WebService3SoapClient servicio = new ServiceReference3.WebService3SoapClient();

        private void Listar()
        {
            gvAlumnos.DataSource = servicio.Listar().Tables[0];
            gvAlumnos.DataBind();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Listar();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string codAlumno = txtCodAlumno.Text.Trim();
            string apellido = txtApellidos.Text.Trim();
            string nombres = txtNombres.Text.Trim();
            string lugarNac = txtLugarNacimiento.Text.Trim();
            string fechaNac = txtFechaNacimiento.Text.Trim();
            string codEscuela = txtCodEscuela.Text.Trim();

            string[] rpta = servicio.AgregarAlumno(codAlumno, apellido, nombres, lugarNac, fechaNac, codEscuela);
            if (rpta[0]=="0")
            {
                Listar();
            }
            else Response.Write("<script>alert('No se agrego escuela');</script>");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string codAlumno = txtCodAlumno.Text.Trim();
            string[] rpta = servicio.EliminarAlumno(codAlumno);
            if (rpta[0]=="0")
            {
                Listar();
            }
            else Response.Write("<script>alert('No se pudo eliminar escuela');</script>");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string codAlumno = txtCodAlumno.Text.Trim();
            string apellido = txtApellidos.Text.Trim();
            string nombres = txtNombres.Text.Trim();
            string lugarNac = txtLugarNacimiento.Text.Trim();
            string fechaNac = txtFechaNacimiento.Text.Trim();
            string codEscuela = txtCodEscuela.Text.Trim();

            string[] rpta = servicio.ActualizarAlumno(codAlumno, apellido, nombres, lugarNac, fechaNac, codEscuela);
            if (rpta[0] == "0")
            {
                Listar();
            }
            else Response.Write("<script>alert('No se pudo actualizar escuela');</script>");
        }

        protected void txtBuscar_Change(object senser, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();
            gvAlumnos.DataSource = servicio.BuscarAlumno(texto, ddlCriterio.Text.Trim());
            gvAlumnos.DataBind();

        }

    }
}