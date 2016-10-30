using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Script.Serialization;//para usar serializable y convertir datatable en json
using System.Data;

namespace Proyecto_2016
{
    /// <summary>
    /// Summary description for WebServiceProyecto
    /// </summary>
    /// 
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    //To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]

    public class WebServiceProyecto : System.Web.Services.WebService
    {
        //cadena de conexion db
        string cad_conexion = "Data Source=(local); Initial Catalog= BD_prueba; integrated Security= True";
        SqlConnection sql_conexion = null;
        //data table donde se cargaran los datos de la db
        DataTable dt = new DataTable();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

       //prueba la conexion
        private bool pruebaconexion(ref string error)
        {
            sql_conexion = new SqlConnection(cad_conexion);
            try
            {
                sql_conexion.Open();
                return true;
            }
            catch (SqlException e)
            {
                error = "No se pudo conectar con la conexion" + e.Message.ToString();
                return false;
            }
            finally
            {
                if (sql_conexion != null)
                {
                    sql_conexion.Close();
                }
            }
        }

        //abrir conexion con la db

        private void conexionopen()
        {
            sql_conexion = new SqlConnection(cad_conexion);
            sql_conexion.Open();
        }

        //cerrar la conexion con la db
        private void conexionclose()
        {
            sql_conexion = new SqlConnection(cad_conexion);
            sql_conexion.Close();
         
        }

        //metodo privado del webservice que se usa para tomar los datos de la db y convertirlos a json para ser enviados al frontend

        private static object DataTableToJSON(DataTable table)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in table.Rows)
            {
                var dict = new Dictionary<string, object>();

                foreach (DataColumn col in table.Columns)
                {
                    dict[col.ColumnName] = (Convert.ToString(row[col]));
                }
                list.Add(dict);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            return serializer.Serialize(list);
        }


    }
}
