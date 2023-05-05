using Microsoft.EntityFrameworkCore;
using Cursos.Models;  
using Estudiantes.Models; 
using Cursos.Models;

namespace Aplication.Context
{
    public class ApplicationDbContext : DbContext{

        public DbSet<Estudiantes> Estudiantes{get;set;}
        public DbSet<> Estudiantes{get;set;}

        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration){
           Configuration=configuration; 
        }

        protected override void Onconfiguring(DbContextOptionsBuilder options){
           options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
        }
   }
} 
