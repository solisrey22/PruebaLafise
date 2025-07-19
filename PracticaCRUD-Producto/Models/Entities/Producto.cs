using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaCRUD_Producto.Models.Entities
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria? Categoria { get; set; }
    }
}
