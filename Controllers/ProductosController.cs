using Servicios_18_20.Clases;
using Servicios_18_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Servicios_18_20.Controllers
{
    [RoutePrefix("api/Productos")]
    public class ProductosController : ApiController
    {    

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<PRODucto> ConsultarTodos()
        {
            clsProducto Producto = new clsProducto();
            return Producto.ConsultarTodos();
        }

        [HttpGet]
        [Route("Consultar")]
        public PRODucto Consultar(int Codigo)
        {
            clsProducto producto = new clsProducto();
            return producto.Consultar(Codigo);
        }

        [HttpGet]
        [Route("ConsultarXTipoProducto")]
        public List<PRODucto> ConsultarXTipoProducto(int TipoProducto)
        {
            clsProducto producto = new clsProducto();
            return producto.ConsultarXTipo(TipoProducto);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] PRODucto producto)
        {
            clsProducto Producto = new clsProducto(); //Crear objeto de la clase clsProducto
            Producto.producto = producto; //Paso la propiedad producto del objeto producto de la clase clsProducto
            return Producto.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] PRODucto producto)
        {
            clsProducto Producto = new clsProducto(); //Crear objeto de la clase clsProducto
            Producto.producto = producto; //Paso la propiedad producto del objeto producto de la clase clsProducto
            return Producto.Actualizar();
        }

        [HttpPut]
        [Route("Inactivar")]
        public string Inactivar(int Codigo)
        {
            clsProducto Producto = new clsProducto(); //Crear objeto de la clase clsProducto            
            return Producto.ModificarActivo(Codigo, false);
        }

        [HttpPut]
        [Route("Activar")]
        public string Activar(int Codigo)
        {
            clsProducto Producto = new clsProducto(); //Crear objeto de la clase clsProducto            
            return Producto.ModificarActivo(Codigo, true);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int Codigo)
        {
            clsProducto Producto = new clsProducto(); //Crear objeto de la clase clsProducto llama Producto
            return Producto.Eliminar(Codigo);
        }

       



    }
}