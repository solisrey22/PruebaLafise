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


        [HttpGet]
        [Route("ListarProducto")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProducts()
        {
            var productos = await _context.Producto.ToListAsync();

            return Ok(productos);
        }

        [HttpGet("ObtenerProducto/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var producto = await _context.Producto.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
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

        [HttpPut]
        [Route("ActualizarProducto")]
        public async Task<IActionResult> UpdateProduct([FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var idParam = new SqlParameter("@IdProducto", producto.IdProducto);
            var nombreParam = new SqlParameter("@Nombre", producto.Nombre);
            var descripcionParam = new SqlParameter("@Descripcion", (object?)producto.Descripcion ?? DBNull.Value);
            var idCategoriaParam = new SqlParameter("@IdCategoria", producto.IdCategoria);

            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_ActualizarProducto @IdProducto, @Nombre, @Descripcion, @IdCategoria",
                    idParam, nombreParam, descripcionParam, idCategoriaParam
                );

                return Ok(new { message = "Producto actualizado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno al actualizar el producto");
            }
        }

        [HttpDelete]
        [Route("EliminarProducto")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var productoBorrado = await _context.Producto.FindAsync(id);

            if (productoBorrado == null)
                return NotFound();

            _context.Producto.Remove(productoBorrado!);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Producto eliminado correctamente" });
        }

    }
}