
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace Proyecto_2016.FrontEnd
{
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }
        protected void bt_inicio_Click(object sender, EventArgs e)
        {
            WebServiceProyecto log = new WebServiceProyecto();
            string u = Request.Form["usuario"];//TOMA EL DATO DEL HTML INPUT Y LO GUARDA EN UNA VARIABLE.
            string c = Request.Form["contra"];
            Session["Usuario"] = u;
            
            

            int result = log.loguin(u,c);// LLAMADA AL WEB SERVICE LOGUIN

            if (result == 1)
            {
                Response.Redirect("Inicio.aspx");//navega a la página deseada
            }
            else
            {
                 
            }
            }

        }
    }