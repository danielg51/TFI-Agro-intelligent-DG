using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TFI_Agro_intelligent_DG.Seguridad.Modelo;

namespace TFI_Agro_intelligent_DG.Contexts
{
    public class SeguridadContext : DbContext
    {
        public DbSet<Patente> Patentes { get; set; }
        public DbSet<Familia> Familias { get; set; }
        public DbSet<FamiliaPatenteUsuario> FamiliaPatentesUsuarios { get; set; }
        public DbSet<Bitacora> Bitacoras { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=DB-AgroInt;Integrated Security=True");
            optionsBuilder.EnableSensitiveDataLogging();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var accesosBitacora = new Patente
            {
                PatenteId = 1,
                Descripcion = "Acceso Bitacora"
            };
            
            modelBuilder.Entity<Patente>().HasData(accesosBitacora);

            var rolAdministradores = new Familia
            {
                FamiliaId = 1,
                Descripcion = "Rol Administrador"
            };
            modelBuilder.Entity<Familia>().HasData(rolAdministradores);
            
            var rolSistemas = new Familia
            {
                FamiliaId = 2,
                Descripcion = "Rol Sistemas",
                FamiliaPadreId = 1
            };
            modelBuilder.Entity<Familia>().HasData(rolSistemas);



            var accesoBitacoraRolSistemas = new FamiliaPatenteUsuario
            {
                FamiliaPatenteUsuarioId = 1,
                PatenteId = 1,
                FamiliaId = 1,
                UserId = 1
            };

            modelBuilder.Entity<FamiliaPatenteUsuario>().HasData(accesoBitacoraRolSistemas);

            var eventoAccesoLogin = new Bitacora
            {
                BitacoraId = 1,
                UserId = 1,
                Detalle = "ACCESO LOGIN",
                FechaHoraAcceso = DateTime.Now
            };

            modelBuilder.Entity<Bitacora>().HasData(eventoAccesoLogin);

        }
    }
}
