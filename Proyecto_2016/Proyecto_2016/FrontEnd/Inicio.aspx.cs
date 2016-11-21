using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2016.FrontEnd
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   //el codigo a continuación es para obtener el id de inicio de sesion para luego buscar los negocios ligados a ese sesion en la db.

            string u = Session["Usuario"].ToString();

            //este label1 lo use para comprobar el iniciod e sesion.
            Label1.Text = u.ToString();

            //debe ahora buscar al cargar la pagina los negocios que tiene el usuario , 
            //asi el usuario elije el negocio e ingresa al control de stock, nosotros por atras 
            //buscamos por medio de un web servise para ese usuarios todos los negocios y 
            //guardamos el id del negocio que seleciona en la variable sessions
        }
    }
}