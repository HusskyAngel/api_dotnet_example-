using Microsoft.EntityFrameworkCore;
 
using Models; 
using Models;

namespace Aplication.Context
{
    public class ApplicationDbContext : DbContext{

        public DbSet<Estudiantes> Estudiantes{get;set;}
        public DbSet<Cursos> Cursos{get;set;}

        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration){
           Configuration=configuration; 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options){
           options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
        }
   }
} 
