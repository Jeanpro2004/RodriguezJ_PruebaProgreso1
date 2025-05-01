using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RodriguezJ_PruebaProgreso1.Models
{
    public class Mascota
    {
        public Mascota()
        {
            Visitas = new Collection<VisitaVeterinaria>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Raza { get; set; }
        [Required]
        public string Especie { get; set; }

        public int Edad { get; set; }

        public double PesoKg { get; set; }

        [ForeignKey("Dueno")]
        public int DuenoMascotaId { get; set; }

        public DuenoMascota Dueno { get; set; }

        public Collection<VisitaVeterinaria> Visitas { get; set; }

    }
}
