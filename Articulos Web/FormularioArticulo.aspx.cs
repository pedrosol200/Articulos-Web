using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Articulos_Web
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TxtId.Enabled = false;
            if (!IsPostBack)
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                try
                {
                    // Cargamos el combo de Marcas
                    ddlMarca.DataSource = marcaNegocio.listar();
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = categoriaNegocio.listar();
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();

                    // Debug
                    lblDebug.Text = "Marcas: " + ddlMarca.Items.Count + " - Categorías: " + ddlCategoria.Items.Count;
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex);
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.Codigo = TxtCodigo.Text;
                nuevo.Nombre = TxtNombre.Text;
                Imagen nueva = new Imagen();
                nueva.ImagenUrl = txtUrlImagen.Text;
                nuevo.Imagenes.Add(nueva);
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.agregar(nuevo);
                Response.Redirect("ArticuloListar.aspx", false);


            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }
        protected void txtUrlImagen_textChanged(object sender, EventArgs e)
        {
            ImageArticulo.ImageUrl = txtUrlImagen.Text;
        }
    }
}