using System.ComponentModel.DataAnnotations;

namespace API_con_base_de_datos.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;


        [Required, Range(0.01, double.MaxValue)]
        public decimal Precio { get; set; }

        [Required, Range(0, int.MaxValue)]
        public int Stock { get; set; }
    }
}

