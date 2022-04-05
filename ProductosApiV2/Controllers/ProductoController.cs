using Data;
using Data.Dto;
using ServiciosAplicacion.Definiciones;
using ServiciosAplicacion.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductosApiV2.Controllers
{

    public class ProductoController : ApiController
    {

        private readonly IProductoServicioAplicacion _productoServicioAplicacion;

        public ProductoController(IProductoServicioAplicacion productoServicioAplicacion)
        {
            _productoServicioAplicacion = productoServicioAplicacion;

        }
        [HttpGet]
        [ActionName("ObtenerProductos")]
        public IEnumerable<Producto> ObtenerProductos()
        {
            return _productoServicioAplicacion.ObtenerTodosProductos();
        }

        [HttpGet]
        [ActionName("ObtenerProductoPorId")]
        public IHttpActionResult ObtenerProductoPorId(int id)
        {
            Producto producto = _productoServicioAplicacion.ObtenerProductoPorId(id);
            if (producto != null)
                return Ok(producto);
            else
                return NotFound();

        }

        [HttpPost]
        [ActionName("GuardarProducto")]
        public IHttpActionResult GuardarProducto([FromBody] Producto producto)
        {
            bool guardado = _productoServicioAplicacion.GuardarProducto(producto);
            if (guardado)
                return Ok(producto);
            else
                return BadRequest();

        }


        [HttpPut]
        [ActionName("ActualizarProducto")]
        public IHttpActionResult ActualizarProducto([FromBody] Producto producto)
        {
            bool actualizo = _productoServicioAplicacion.ActualizarProducto(producto);
            if (actualizo)
                return Ok(_productoServicioAplicacion.ObtenerProductoPorId(producto.Id_Producto));
            else
                return BadRequest();
        }
        [HttpPost]
        [ActionName("ObtenerProductosConsulta")]
         public IHttpActionResult ObtenerProductosConsulta(ConsultaDto consultaDto)
        {
               var listaProducto= _productoServicioAplicacion.ObtenerProductosConsulta(consultaDto);
            if (listaProducto.Any())
                return Ok(listaProducto);
            else
                return NotFound();

        }





    }
}
