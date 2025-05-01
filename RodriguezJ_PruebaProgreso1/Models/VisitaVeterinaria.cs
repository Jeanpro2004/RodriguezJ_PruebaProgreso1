using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RodriguezJ_PruebaProgreso1.Models
{
    public class VisitaVeterinaria
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaVisita { get; set; }

        public string Motivo { get; set; }// Vacunacion , Revision General o Cirugia

        public decimal Tarifa { get; set; }

        public Boolean RequiereMedicacion { get; set; }

        [ForeignKey("Mascota")]

        public int MascotaId { get; set; }

        public Mascota Mascota { get; set; }
        
        
    }
}
