using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TFI_Agro_intelligent_DG.Negocio.Modelo;

namespace TFI_Agro_intelligent_DG.Contexts
{
    public class ServicioContext : DbContext
    {
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<PackServicio> PackServicios { get; set; }
        public DbSet<Sensor> Sensores { get; set; }
        public DbSet<Pack> Packs { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<CarritoDetalle> CarritoDetalles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=DB-AgroInt;Integrated Security=True");
            optionsBuilder.EnableSensitiveDataLogging();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
           
            var sensorAntihelada = new Sensor
            {
                SensorId = 1,
                Descripcion = "Sensor Anti-Helada"
            };
            var sensorRiego = new Sensor
            {
                SensorId = 2,
                Descripcion = "Sensor de Riego"
            };
            var sensorAntiPlaga = new Sensor
            {
                SensorId = 3,
                Descripcion = "Sensor Anti-Plagas"
            };
            modelBuilder.Entity<Sensor>().HasData(sensorAntihelada);

            modelBuilder.Entity<Sensor>().HasData(sensorRiego);
           
            modelBuilder.Entity<Sensor>().HasData(sensorAntiPlaga);

            var sistemaAntiHelada = new Servicio
            {
                ServicioId = 1,
                Descripcion = "Sistema Anti-Helada",
                SensorId=1,
            };
            modelBuilder.Entity<Servicio>().HasData(sistemaAntiHelada);

            var sistemaUnicoDeRiego = new Servicio
            {
                ServicioId = 2,
                Descripcion = "Sistema Único de Riego",
                SensorId = 2,
            };

            modelBuilder.Entity<Servicio>().HasData(sistemaUnicoDeRiego);

            var sistemaAntiPlaga = new Servicio
            {
                ServicioId = 3,
                Descripcion = "Sistema Anti-Plaga",
                SensorId = 3,
            };
            modelBuilder.Entity<Servicio>().HasData(sistemaAntiPlaga);
            var pack = new Pack
            {
                PackId = 1,
                Descripcion = "Pack Little",
            };

            var packServicioAntiplaga = new PackServicio { PackServicioId = 1, PackId = 1,  ServicioId = 3, Cantidad = 20 };
            var packServicioUnicoDeRiego = new PackServicio { PackServicioId = 2, PackId=1, ServicioId = 2, Cantidad = 40 };
            modelBuilder.Entity<PackServicio>().HasData(packServicioAntiplaga);
            modelBuilder.Entity<PackServicio>().HasData(packServicioUnicoDeRiego);

            //pack.PackServicios = new List<PackServicio> { packServicioAntiplaga , packServicioUnicoDeRiego};
            modelBuilder.Entity<Pack>().HasData(pack);
        }
    }
}
