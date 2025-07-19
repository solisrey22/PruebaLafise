using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaCRUD_Producto.Data;
using PracticaCRUD_Producto.Models.Entities;

namespace PracticaCRUD_Producto.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("CrearCategoria")]
        public async Task<IActionResult> CreateCategoria(Categoria categoria)
        {
            await _context.Categoria.AddAsync(categoria);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("ListarCategoria")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoria()
        {
            var categoria = await _context.Categoria.ToListAsync();
            return Ok(categoria);
        }

        [HttpGet]
        [Route("ObtenerCategoria")]
        public async Task<IActionResult> GetCategoria(int idCategoria)
        {
            Categoria categoria = await _context.Categoria.FindAsync(idCategoria);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpPut]
        [Route("EditarCategoria")]
        public async Task<IActionResult> UpdateCategoria(int idCategoria, Categoria categoria)
        {
            var categoriaExistente = await _context.Producto.FindAsync(idCategoria);
            categoriaExistente!.Nombre = categoria.Nombre;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("EliminarCategoria")]
        public async Task<IActionResult> DeleteCategoria(int idCategoria)
        {
            var categoriaEliminada = await _context.Producto.FindAsync(idCategoria);
            _context.Producto.Remove(categoriaEliminada!);

            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}