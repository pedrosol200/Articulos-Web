using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dominio;
using Negocio;
using API_s_Articulos;
using API_s_Articulos.Models;

namespace API_s_Articulos.Controllers
{
    public class ArticulosController : ApiController
    {
        // GET: api/Articulos
        public IEnumerable<Articulo> Get()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            return negocio.listar();
        }

        // GET: api/Articulos/5
        public Articulo Get(int id)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> lista = negocio.listar();
            return lista.Find(x => x.Id == id);
        }

        // POST: api/Articulos
        public void Post([FromBody] ArticulosDto nuevoDto)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo nuevo = new Articulo();
            nuevo.Nombre = nuevoDto.Nombre;
            nuevo.Codigo = nuevoDto.Codigo;
            nuevo.Descripcion = nuevoDto.Descripcion;
            nuevo.Marca = new Marca { Id = nuevoDto.IdMarca };
            nuevo.Categoria = new Categoria { Id = nuevoDto.IdCategoria };
            nuevo.Precio = nuevoDto.Precio;
            if (nuevoDto.Imagenes != null) {
                foreach (var imgDto in nuevoDto.Imagenes)
                {
                    Imagen img = new Imagen();
                    img.ImagenUrl = imgDto.Url;
                    nuevo.Imagenes.Add(img);
                }
            }
            negocio.agregarDirecto(nuevo);
        }

        // PUT: api/Articulos/5
        public void Put(int id, [FromBody]ArticulosDto nuevoDto)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo nuevo = new Articulo();
            nuevo.Nombre = nuevoDto.Nombre;
            nuevo.Codigo = nuevoDto.Codigo;
            nuevo.Descripcion = nuevoDto.Descripcion;
            nuevo.Marca = new Marca { Id = nuevoDto.IdMarca };
            nuevo.Categoria = new Categoria { Id = nuevoDto.IdCategoria };
            nuevo.Precio = nuevoDto.Precio;
            nuevo.Id = id;
            if (nuevoDto.Imagenes != null)
            {
                foreach (var imgDto in nuevoDto.Imagenes)
                {
                    Imagen img = new Imagen();
                    img.ImagenUrl = imgDto.Url;
                    nuevo.Imagenes.Add(img);
                }
            }
            negocio.modificarConSp(nuevo);
        }

        // DELETE: api/Articulos/5
        public void Delete(int id)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            negocio.eliminarLogicoConSp(id, false);
        }
    }
}
