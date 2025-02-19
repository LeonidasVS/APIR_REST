using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIREST.Context;
using APIREST.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace APIREST.Repository
{
    public class ProductoDAO
    {
        private ApirestContext _contexto=new ApirestContext();

        public async Task<List<Producto>> SelectAllAsync()
        {
            return await _contexto.Productos.ToListAsync();
        }

        public async Task<Producto?> GetByIdAsync(int id)
        {
            return await _contexto.Productos.FirstOrDefaultAsync(x => x.IdProducto == id);
        }

        public async Task<bool> DeleteProductoAsync(int id)
        {
            try
            {
                var producto = await GetByIdAsync(id);
                if (producto == null)
                {
                    return false;
                }
                _contexto.Productos.Remove(producto);
                await _contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Producto?> InsertProductoAsync(Producto producto)
        {
            try
            {
                await _contexto.Productos.AddAsync(producto);
                await _contexto.SaveChangesAsync();
                return producto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> UpdateProductoAsync(Producto producto)
        {
            try
            {
                if (producto == null || string.IsNullOrWhiteSpace(producto.Nombre) || producto.Stock < 0 || producto.Precio <= 0)
                {
                    return false;
                }

                var productoExistente = await GetByIdAsync(producto.IdProducto);

                if (productoExistente == null)
                {
                    return false;
                }

                productoExistente.Nombre = producto.Nombre;
                productoExistente.Stock = producto.Stock;
                productoExistente.Precio = producto.Precio;

                _contexto.Productos.Update(productoExistente);
                await _contexto.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
