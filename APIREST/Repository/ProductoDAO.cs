using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIREST.Context;
using APIREST.Models;

namespace APIREST.Repository
{
    public class ProductoDAO
    {
        public ApirestContext contexto = new ApirestContext();

        public List<Producto> SelectAll()
        {
            var producto=contexto.Productos.ToList<Producto>();
            return producto;
        }

        public Producto? GetById(int id)
        {
            return contexto.Productos.FirstOrDefault(x => x.IdProducto == id);
        }


        public bool EliminarProducto(int id)
        {
            try
            {
                var borrar = GetById(id);

                if (borrar == null)
                {
                    return false;
                }

                contexto.Productos.Remove(borrar);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public Producto? InsertarProducto(Producto producto)
        {
            try
            {
                contexto.Productos.Add(producto);
                contexto.SaveChanges();
                return producto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public bool updateProducto(Producto producto)
        {
            try
            {
                contexto.Productos.Update(producto);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }
    }
}
