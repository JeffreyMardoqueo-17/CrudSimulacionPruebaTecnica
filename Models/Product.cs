using System;
using System.ComponentModel.DataAnnotations;

namespace CrudSimulacionPruebaTecnica.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(255, ErrorMessage = "El nombre no puede exceder 255 caracteres")]
        
        public string Name { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Description { get; set; }

        [Range(typeof(decimal), "0", "999999999999", ErrorMessage = "El precio debe ser mayor o igual a cero")]
        public decimal? Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock debe ser mayor o igual a cero")]
        public int Stock { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
