using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace GOMEZ_MARTINEZ_ADY_WEB_API.Context
{
    public class ApplicationDbContext : DbContext
    {
        // // Constructor de la clase. Aquí se le pasan las opciones necesarias para configurar la conexión a la base de datos.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Aquí se definen las tablas de la base de datos como propiedades DbSet.
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Roles { get; set; }

        // Este método se usa para configurar el modelo de la base de datos, como las relaciones entre tablas y los datos iniciales.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Insertar en tabla Roles
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PKRol = 1,
                    Name = "a"
                },
                new Rol
                {
                    PKRol = 2,
                    Name = "sa"
                });

            // Insertar en tabla Usuario
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    PKUser = 1,
                    Name = "Ady",
                    Username = "Ady",
                    Password = "123",
                    FKRol = 2 // Asegúrarnos de que esta clave foránea corresponde a un Rol existente
                },
                new User
                {
                    PKUser = 2,
                    Name = "Josue",
                    Username = "Jou",
                    Password = "123",
                    FKRol = 1
                },
                new User
                {
                    PKUser = 3,
                    Name = "Cynthia",
                    Username = "Cynti",
                    Password = "123",
                    FKRol = 1
                });
        }
    }
}
