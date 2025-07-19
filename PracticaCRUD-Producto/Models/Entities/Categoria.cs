using System.ComponentModel.DataAnnotations;

namespace PracticaCRUD_Producto.Models.Entities
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string? Nombre { get; set; }
        public ICollection<Producto>? Productos { get; set; }
    }
}