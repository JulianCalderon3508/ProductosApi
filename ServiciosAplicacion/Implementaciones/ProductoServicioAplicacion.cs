using Data;
using Data.Dto;
using ServiciosAplicacion.Definiciones;
using ServiciosAplicacion.Utilidades.Loggin;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ServiciosAplicacion.Implementaciones
{
    public class ProductoServicioAplicacion : IProductoServicioAplicacion
    {
        private CompaniaEntities db = new CompaniaEntities();

        private readonly Ilogger _logger;

        public ProductoServicioAplicacion()
        {
            _logger = new Logger(typeof(ProductoServicioAplicacion));
        }

        public Producto ObtenerProductoPorId(int id)
        {
            try
            {
                return db.Productos.Where(x => x.Id_Producto == id).FirstOrDefault();
            }
            catch(Exception ex)
            {
                _logger.LogException(ex);
                return null;
            }

            
        }
        public List<Data.Producto> ObtenerTodosProductos()
        {
            try
            {
                return db.Productos.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                return null;
                
            }
        }

        public bool GuardarProducto(Producto producto)
        {
            try
            {
                if (producto != null)
                {
                    db.Productos.Add(producto);
                    db.SaveChanges();
                    return true;

                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                return false;                
            }

        }

        public bool ActualizarProducto(Producto producto)
        {
            try
            {
                Producto productoActualizar = db.Productos.AsNoTracking().Where(x => x.Id_Producto == producto.Id_Producto).FirstOrDefault();
                if (productoActualizar != null)
                {
                    productoActualizar.Descripcion = producto.Descripcion;
                    productoActualizar.Categoria = producto.Categoria;
                    productoActualizar.Imagen = producto.Imagen;
                    productoActualizar.Nombre = producto.Nombre;

                    db.Entry(producto).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;


            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                return false;                
            }

        }
        public List<Producto> ObtenerProductosConsulta(ConsultaDto consultaDto)
        {
            try
            {
                var datos = db.Productos.OrderBy(x=>x.Nombre);
                if (string.IsNullOrEmpty(consultaDto.TextoBuscar))
                    return datos.ToList();
                else 
                    return datos.Where(x => x.Descripcion.Contains(consultaDto.TextoBuscar) || x.Categoria.Contains(consultaDto.TextoBuscar) || x.Nombre.Contains(consultaDto.TextoBuscar)).ToList();
                
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                return null;
            }
        }

        public bool EliminarProducto(int id)
        {
            try
            {
                var producto = db.Productos.Where(x => x.Id_Producto == id).FirstOrDefault();
                if (producto != null)
                {
                    db.Productos.Remove(producto);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                return false;
            }
        }


    }
}