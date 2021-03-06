﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Script.Serialization;//para usar serializable y convertir datatable en json
using System.Data;
using System.Web.Script.Services;

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
        //string cad_conexion = "Data Source=(local); Initial Catalog= BD_prueba; integrated Security= True";//CONEXION GENERICA
        // SE CREA UN USUARIO CON PERMISOS EN LA DB CONTROL-STOCK EL USUARIO ES stock y la pass es 12345 
        string cad_conexion = "Data Source=(local);User ID=stock; Password=12345; Initial Catalog= Control_Stock; integrated Security= True";

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

        [WebMethod]

        public int loguin(string u, string p)
        {

            using (sql_conexion = new SqlConnection(cad_conexion))
            {
                SqlCommand cmd = new SqlCommand("loguin", sql_conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@us", u);//parametros
                cmd.Parameters.AddWithValue("@pa", p);//parametros

                SqlParameter ValorRetorno = new SqlParameter("@Comprobacion", DbType.Int32);

                ValorRetorno.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ValorRetorno);
                sql_conexion.Open();
                cmd.ExecuteNonQuery();

                int respuesta = Int32.Parse(cmd.Parameters["@Comprobacion"].Value.ToString());
                conexionclose();

                return (respuesta);
            }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

        public object lista_productos_negocio(int id_negocio)
        {

                DataTable dt = new DataTable();
                   
                conexionopen();
                 {
                        SqlCommand cmd = new SqlCommand("listar_productos_de_un_negocio", sql_conexion);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id_neg", id_negocio);//parametros
                        //cmd.Parameters.AddWithValue("@id_rub", id_rubro);//parametros

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                 }
                conexionclose();
            return (DataTableToJSON(dt));

        }




    }
}
