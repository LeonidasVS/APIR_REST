using APIREST.Context;
using APIREST.Models;
using APIREST.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProductosAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private ProductoDAO _dao=new ProductoDAO();

        [HttpGet("LeerProductos")]
        public ActionResult<List<Producto>> ObtenerListado()
        {
            var productos = _dao.SelectAll();

            if (productos == null || productos.Count == 0)
            {
                return NotFound("No se encontraron productos.");
            }
            return Ok(productos);
        }

        [HttpGet("ObtenerPorId")]
        public ActionResult readProducto(int id)
        {
            var productoleer = _dao.GetById(id);

            if (productoleer == null)
            {
                return NotFound($"No se encontró el producto con ID {id}");
            }

            return Ok(productoleer);
        }

        [HttpDelete("EliminarProducto")]
        public ActionResult Delete(int id)
        {
            try
            {
                bool eliminado = _dao.EliminarProducto(id);

                if (eliminado)
                {
                    return Ok(new { mensaje = "Producto eliminado con éxito" });
                }
                else
                {
                    return NotFound(new { mensaje = "No se encontró el producto con el ID especificado" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor", error = ex.Message });
            }
        }

        [HttpPost("InsertarProducto")]
        public ActionResult InsertarProducto([FromBody] Producto productoDTO)
        {
            if (productoDTO == null || string.IsNullOrWhiteSpace(productoDTO.Nombre) || productoDTO.Stock < 0 || productoDTO.Precio <= 0)
            {
                return BadRequest("Datos de producto inválidos.");
            }

            var nuevoProducto = new Producto
            {
                Nombre = productoDTO.Nombre,
                Stock = productoDTO.Stock,
                Precio = productoDTO.Precio
            };

            var resultado = _dao.InsertarProducto(nuevoProducto);

            if (resultado == null)
            {
                return StatusCode(500, "Error al insertar el producto.");
            }

            return CreatedAtAction(nameof(InsertarProducto), new { id = resultado.IdProducto }, resultado);
        }

        [HttpPut("EditarProductos")]

        public ActionResult ActualizarProducto([FromBody] Producto productos)
        {
            if (productos==null || string.IsNullOrEmpty(productos.Nombre) || productos.Stock<0 || productos.Precio<=0)
            {
                return BadRequest("Datos de producto invalidos");
            }

            var productoExistentes=_dao.GetById(productos.IdProducto);

            if (productoExistentes==null)
            {
                return NotFound("Producto no encontrado");
            }

            productoExistentes.Nombre=productos.Nombre; 
            productoExistentes.Stock=productos.Stock;   
            productoExistentes.Precio=productos.Precio;

            var resultado = _dao.updateProducto(productoExistentes);

            if (!resultado)
            {
                return StatusCode(500, "Error al actualizar el producto");
            }

            return Ok(productoExistentes);
        }
    }
}

