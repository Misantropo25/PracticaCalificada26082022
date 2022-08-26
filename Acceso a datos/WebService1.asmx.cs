using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
//Namespace for access to sql server
using System.Data.SqlClient; //SQL SERVER
using System.Data; // ACCESO A DATOS GENERALES
using System.Configuration; // ACCESO A ARCHIVOS DE CONFIGURACION


namespace Acceso_a_datos
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        //Acceder a la cadena de conexion
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        private static SqlConnection conexion = new SqlConnection(cadena);

        [WebMethod(Description = "Listar la tabla escuela")]
        public DataSet Listar()
        {
            string consulta = "select * from TEscuela";
            //Entorno desconectado para acceder a la tabla TEscuela 
            SqlDataAdapter adapter = new SqlDataAdapter(consulta,conexion);
            DataSet data = new DataSet();
            adapter.Fill(data);
            return data;
        }

        [WebMethod(Description = "Agregar un registro a la tabla Escuela")]
        public bool Agregar(string codEscuela, string escuela, string facultad)
        {
            try
            {
                string consulta = "insert into TEscuela values('" + codEscuela + "','" + escuela + "','" + facultad + "')";
                //Entorno conectado
                SqlCommand comando = new SqlCommand(consulta, conexion);
                conexion.Open();
                //Ejecutar la consulta
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
            catch (Exception) {
                conexion.Close();
                return false;
            }
        }


        [WebMethod(Description = "Eliminar una escuela")]
        public bool Eliminar(string codEscuela) 
        {

            try
            {
                string consulta = "delete from TEscuela where CodEscuela = @CodEscuela";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodEscuela", codEscuela);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally {
                conexion.Close();
            }
        }
        
        [WebMethod(Description = "Actualizar una escuela")]
        public bool Actualizar(string codEscuela, string escuela, string facultad)
        {
            try
            {
                string consulta = "update TEscuela set Escuela = @Escuela , Facultad = @Facultad where CodEscuela = @CodEscuela";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodEscuela", codEscuela);
                comando.Parameters.AddWithValue("@Escuela", escuela);
                comando.Parameters.AddWithValue("@Facultad", facultad);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conexion.Close();
            }
        }

        [WebMethod(Description = "Buscar en la tabla escuela")]
        public DataSet Buscar(string texto, string criterio)
        {
            string consulta = string.Empty;
            SqlCommand comando;
            SqlDataAdapter adapter;
            DataSet data = new DataSet();
            if (criterio == "codEscuela")
            {
                // Busqueda exacta
                consulta = "select * from TEscuela where CodEscuela = @texto";
                comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@texto", texto);
                adapter = new SqlDataAdapter(comando);
                adapter.Fill(data);
            }
            else if (criterio == "escuela")
            {
                // Busqueda sensitiva
                consulta = "select * from TEscuela where Escuela like @texto + '%'";
                comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@texto", texto);
                adapter = new SqlDataAdapter(comando);
                adapter.Fill(data);
            }
            return data;
        }



    }
}
