using GestionEleves.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEleves.data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {            
        }
        public DbSet<Etablissement> Etablissements { get; set; }
        public DbSet<Etudient> Etudients { get; set;}
    }   
}
