using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Models; 

namespace Aplication.Context
{
    public class ApplicationDbContext : DbContext{

        public DbSet<Estudiantes> Estudiantes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "base_datos.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            optionsBuilder.UseSqlite(connection)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
         }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Estudiantes>()
                  .HasKey(e => e.Id);

            modelBuilder.Entity<Estudiantes>()
                  .Property(e => e.Nombre)
                  .IsRequired();

            base.OnModelCreating(modelBuilder);

        }
         public void EnsureTablesCreated()
         {
            Database.EnsureCreated();
         }
   }
} 
