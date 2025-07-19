using System.ComponentModel.DataAnnotations;

namespace ProductosCRUD.Client.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string? Nombre { get; set; }
        public ICollection<Producto>? Productos { get; set; }
    }
}