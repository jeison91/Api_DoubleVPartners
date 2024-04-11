using DoubleVPartners.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Infrastructure
{
    public class PartnersDbContext : DbContext
    {
        public PartnersDbContext(DbContextOptions<PartnersDbContext> option) : base(option)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                SqlServerOptionsExtension CnxOptios = optionsBuilder.Options.Extensions.OfType<SqlServerOptionsExtension>().First();
                string cnx = CnxOptios.ConnectionString;

                if (cnx != null)
                    optionsBuilder.UseSqlServer(cnx).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Agregamos datos a la tablas maestras.
            modelBuilder.Entity<TipoIdentificacionEntity>().HasData(
                new TipoIdentificacionEntity { Id = 11, Descripcion = "Registro civil de nacimiento" },
                new TipoIdentificacionEntity { Id = 12, Descripcion = "Tarjeta de identidad" },
                new TipoIdentificacionEntity { Id = 13, Descripcion = "Cédula de ciudadanía" },
                new TipoIdentificacionEntity { Id = 21, Descripcion = "Tarjeta de extranjería" },
                new TipoIdentificacionEntity { Id = 22, Descripcion = "Cédula de extranjería" },
                new TipoIdentificacionEntity { Id = 31, Descripcion = "NIT" },
                new TipoIdentificacionEntity { Id = 41, Descripcion = "Pasaporte" },
                new TipoIdentificacionEntity { Id = 42, Descripcion = "Tipo de documento extranjero" }
            );

            modelBuilder.Entity<UsuarioEntity>().HasData(
                new UsuarioEntity { Id = 1, Usuario = "admin@correo.com", Pass = "admin123", FechaCreacion = DateTime.Now }
            );
        }

        public DbSet<TipoIdentificacionEntity> TipoIdentificaciones { get; set; }
        public DbSet<PersonaEntity> Personas { get; set; }
        public DbSet<UsuarioEntity> Usuarios { get; set; }
    }
}
