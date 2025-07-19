using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PracticaCRUD_Producto.Data;
using PracticaCRUD_Producto.Models.Entities;

namespace PracticaCRUD_Producto.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("CrearProducto")]
        public async Task<IActionResult> CreateProduct([FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var nombreParam = new SqlParameter("@Nombre", producto.Nombre);
            var descripcionParam = new SqlParameter("@Descripcion", (object?)producto.Descripcion ?? DBNull.Value);
            var idCategoriaParam = new SqlParameter("@IdCategoria", producto.IdCategoria);

            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_InsertarProducto @Nombre, @Descripcion, @IdCategoria",
                    nombreParam, descripcionParam, idCategoriaParam
                );

                return Ok(new { message = "Producto creado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno en el server al crear el producto");
            }
        }

        [HttpGet]
        [Route("ListarProducto")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProducts()
        {
            //Obten la lista de productos de la base de datos
            var productos = await _context.Producto.ToListAsync();
    
            //devuelve una lista de productos
            return Ok(productos);
        }

        [HttpGet]
        [Route("ObtenerProducto")]
        public async Task<IActionResult> GetProduct(int id)
        {
            //obtener el producto de la base de datos
            Producto producto = await _context.Producto.FindAsync(id);

            //devolver el producto
            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        [HttpPut]
        [Route("EditarProducto")]
        public async Task<IActionResult> UpdateProduct(int id, Producto producto)
        {
            //Actualizar el producto en la base de datos
            var productoExistente = await _context.Producto.FindAsync(id);
            productoExistente!.Nombre = producto.Nombre;
            productoExistente.Descripcion = producto.Descripcion;

            await _context.SaveChangesAsync();

            //devolver un mensaje de exito
            return Ok();
        }

        [HttpDelete]
        [Route("EliminarProducto")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            //Eliminar producto de la base de datos
            var productoBorrado = await _context.Producto.FindAsync(id);
            _context.Producto.Remove(productoBorrado!);

            await _context.SaveChangesAsync();

            //Devolver un mensaje de exito
            return Ok();
        }

    }
}