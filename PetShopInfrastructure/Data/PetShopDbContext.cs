using Microsoft.EntityFrameworkCore;
using PetShopCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInfrastructure.Data
{
    public class PetShopDbContext : DbContext
    {
        public PetShopDbContext(DbContextOptions options) : base(options){ }

        public DbSet<Dueño> Dueños { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<HistorialClinico> HistorialesClinicos { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<TipoServicio> TiposServicios { get; set; }

        protected PetShopDbContext()
        {
        }
    }
}
