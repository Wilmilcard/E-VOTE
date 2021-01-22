using E_Vote_BE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Vote_BE.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<Eleccion> Eleccion { get; set; }
        public DbSet<Postulacion> Postulacion { get; set; }
        public DbSet<Sufragante> Sufragante { get; set; }
        public DbSet<TipoDoc> TipoDoc { get; set; }
        public DbSet<TipoPropuesta> TipoPropuesta { get; set; }
        public DbSet<Votacion> Votacion { get; set; }
    }
}
