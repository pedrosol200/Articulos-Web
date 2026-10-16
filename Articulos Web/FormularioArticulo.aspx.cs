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
        public bool ConfirmarEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            TxtId.Enabled = false;
            ConfirmarEliminacion = false;

            try
            {
                if (!IsPostBack)
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

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

                    //configuracion de modificacion
                    string id = (Request.QueryString["id"] != null) ? Request.QueryString["id"].ToString() : "";
                    if (id != "")
                    {
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        Articulo articuloModificado = (negocio.listar(id))[0];
                        articuloModificado.Imagenes = negocio.listarImagenes(int.Parse(id));

                        TxtId.Text = id;
                        TxtNombre.Text = articuloModificado.Nombre;
                        TxtCodigo.Text = articuloModificado.Codigo;
                        txtPrecio.Text = articuloModificado.Precio.ToString();
                        txtDescripcion.Text = articuloModificado.Descripcion.ToString();
                        if (articuloModificado.Imagenes.Count > 0)
                        {
                            txtUrlImagen.Text = articuloModificado.Imagenes[0].ImagenUrl;
                            ImageArticulo.ImageUrl = articuloModificado.Imagenes[0].ImagenUrl;
                        }
                        if (articuloModificado.Categoria != null)
                        {
                            ddlCategoria.SelectedValue = articuloModificado.Categoria.Id.ToString();
                        }
                        if (articuloModificado.Marca != null)
                        {
                            ddlMarca.SelectedValue = articuloModificado.Marca.Id.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
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

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(TxtId.Text);
                    negocio.modificarConSp(nuevo);

                    if (txtUrlImagen.Text != "")
                    {
                        negocio.modificarImagenConSp(nuevo.Id, txtUrlImagen.Text);
                    }
                }
                else { negocio.agregar(nuevo); }
                
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
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = true;
        }
        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            if (ChkConfirmarEliminar.Checked)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.eliminar(int.Parse(TxtId.Text));
                Response.Redirect("ArticuloListar.aspx");
            }
        }

    }
}