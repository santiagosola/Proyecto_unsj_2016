using System;
using Newtonsoft.Json;//para usar esta libreria  hay que instalar el paquete newtonsoft json desde manage nuget packages
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;//agregar referencia par apoder usar messagebox, debe ser agregada de click drecho sobre references y add referencia y buscar system.windows.form.
using System.Text;
using System.Web.Script.Serialization;


namespace Proyecto_2016.FrontEnd
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   //el codigo a continuación es para obtener el id de inicio de sesion para luego buscar los negocios ligados a ese sesion en la db.

            string u = Session["Usuario"].ToString();

            //este label1 lo use para comprobar el iniciod e sesion.
            Label1.Text = u.ToString();
            WebServiceProyecto w = new WebServiceProyecto();
            GridView1.DataSource = DerializeDataTable(w.lista_productos_negocio(3).ToString());
            GridView1.DataBind();
          
            //debe ahora buscar al cargar la pagina los negocios que tiene el usuario , 
            //asi el usuario elije el negocio e ingresa al control de stock, nosotros por atras 
            //buscamos por medio de un web servise para ese usuarios todos los negocios y 
            //guardamos el id del negocio que seleciona en la variable sessions
        }
        
        public DataTable DerializeDataTable(string data)// esta funcion se usa para descerializar el json y cargar un gridview por ejemplo
        {
            string json = data; //"data" es el  JSON que trae del web service 
            var table = JsonConvert.DeserializeObject<DataTable>(json);//lo convierto en datatable
            return table;
        }
    }
}