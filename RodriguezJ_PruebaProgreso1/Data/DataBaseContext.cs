using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RodriguezJ_PruebaProgreso1.Models;

    public class DataBaseContext : DbContext
    {
        public DataBaseContext (DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public DbSet<RodriguezJ_PruebaProgreso1.Models.DuenoMascota> DuenoMascota { get; set; } = default!;

public DbSet<RodriguezJ_PruebaProgreso1.Models.Mascota> Mascota { get; set; } = default!;

public DbSet<RodriguezJ_PruebaProgreso1.Models.VisitaVeterinaria> VisitaVeterinaria { get; set; } = default!;
    }
