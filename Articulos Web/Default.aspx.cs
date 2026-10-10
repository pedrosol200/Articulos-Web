using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Articulos_Web
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListarArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListarArticulos = negocio.listarconSp();
        }
    }
}