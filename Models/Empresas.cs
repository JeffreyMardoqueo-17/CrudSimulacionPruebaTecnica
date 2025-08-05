using System.ComponentModel.DataAnnotations;

namespace CrudSimulacionPruebaTecnica.Models
{
    public class Empresas
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El nombre no puede tener mas de 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(250, ErrorMessage ="La direccion debe tener un maximo de 250 caracteres")]
        public string Direccion { get; set; }
       
        [Required]
        [MaxLength(8, ErrorMessage ="El número de telefono debe contener 8 numero y sin guiones")]
        public int Telefono { get; set; }
    }
}
