using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RodriguezJ_PruebaProgreso1.Models
{
    public class Mascota
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public string Especie { get; set; }

        public int Edad { get; set; }

        public double PesoKg { get; set; }

        [ForeignKey("Dueno")]
        public int DuenoMascotaId { get; set; }

        public DuenoMascota Dueno { get; set; }

        public Collection<VisitaVeterinaria> Visitas { get; set; }

    }
}
