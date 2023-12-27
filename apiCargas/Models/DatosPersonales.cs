using System.ComponentModel.DataAnnotations;

namespace apiCargas.Models
{
    public class DatosPersonales
    {
        [Key]
        public int id { get; set; }

        public string? nombre { get; set; }

        public int? apellido { get; set; }

        public string? Email { get; set; }


    }
}
