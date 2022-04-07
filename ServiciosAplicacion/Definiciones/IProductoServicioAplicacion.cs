using Data;
using Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosAplicacion.Definiciones
{
    public interface IProductoServicioAplicacion
    {
        List<Producto> ObtenerTodosProductos();
        Producto ObtenerProductoPorId(int id);
        bool GuardarProducto(Producto producto);
        bool ActualizarProducto(Producto producto);

        List<Producto> ObtenerProductosConsulta(ConsultaDto consultaDto);
        bool EliminarProducto(int id);





    }
}
