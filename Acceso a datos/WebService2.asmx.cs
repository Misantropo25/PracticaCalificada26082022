using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Acceso_a_datos
{
    /// <summary>
    /// Summary description for WebService2
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService2 : System.Web.Services.WebService
    {

        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;

        [WebMethod(Description = "Listar con PA")]
        public DataSet Listar() {
            using (SqlConnection conexion = new SqlConnection(cadena)) {
                SqlCommand comando = new SqlCommand("spListarEscuela", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adapter.Fill(data);
                return data;
            }
        }

        [WebMethod(Description = "Agregar con PA")]
        public string[] Agregar(string codEscuela, string escuela, string facultad) {
            using (SqlConnection conexion = new SqlConnection(cadena)) {
                SqlCommand comando = new SqlCommand("spAgregarEscuela", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@CodEscuela", codEscuela);
                comando.Parameters.AddWithValue("@Escuela", escuela);
                comando.Parameters.AddWithValue("@Facultad", facultad);
                string[] arreglo = new string[2]; //Arreglo que trae los datos de CodError y Mensaje
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adapter.Fill(data);
                arreglo[0] = data.Tables[0].Rows[0]["CodError"].ToString();
                arreglo[1] = data.Tables[0].Rows[0]["Mensaje"].ToString();
                return arreglo;
            }

        }

        [WebMethod(Description = "Eliminar con PA")]
        public string[] Eliminar(string codEscuela)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand comando = new SqlCommand("spEliminarEscuela", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@CodEscuela", codEscuela);
                string[] arreglo = new string[2]; //Arreglo que trae los datos de CodError y Mensaje
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adapter.Fill(data);
                arreglo[0] = data.Tables[0].Rows[0]["CodError"].ToString();
                arreglo[1] = data.Tables[0].Rows[0]["Mensaje"].ToString();
                return arreglo;
            }

        }

        [WebMethod(Description = "Actualizar con PA")]
        public string[] Actualizar(string codEscuela, string escuela, string facultad)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand comando = new SqlCommand("spActualizarEscuela", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@CodEscuela", codEscuela);
                comando.Parameters.AddWithValue("@Escuela", escuela);
                comando.Parameters.AddWithValue("@Facultad", facultad);
                string[] arreglo = new string[2]; //Arreglo que trae los datos de CodError y Mensaje
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adapter.Fill(data);
                arreglo[0] = data.Tables[0].Rows[0]["CodError"].ToString();
                arreglo[1] = data.Tables[0].Rows[0]["Mensaje"].ToString();
                return arreglo;
            }

        }

        [WebMethod(Description = "Buscar una escuela")]
        public DataSet Buscar(string texto, string criterio)
        {
            using (SqlConnection conexion = new SqlConnection(cadena)) {
                SqlCommand comando = new SqlCommand("spBuscarEscuela",conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@texto", texto);
                comando.Parameters.AddWithValue("@criterio", criterio);
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adapter.Fill(data);
                return data;
 
            }
        }

    }
}
