using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace RodriguezJ_PruebaProgreso1.Models
{
    public class DuenoMascota
    {
        [Key]

        public int Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [Range(18,90)]
        public int Edad { get; set;  }
        [EmailAddress]
        public string Email { get; set; }
        [Range(0,1000)]
        public decimal SaldoDisponible { get; set; }

        public Boolean TieneMembresia { get; set; }

        [DataType (DataType.Date)]
        public DateTime FechaRegistro { get; set; }

       
        public Collection<Mascota> Mascotas { get; set; }
    }
}
