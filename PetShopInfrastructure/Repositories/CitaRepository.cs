using PetShopCore.Interfaces;
using PetShopCore.Models.Entities;
using PetShopInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInfrastructure.Repositories
{
    public class CitaRepository : BaseRepository<Cita>, ICitaRepository
    {
        public CitaRepository(PetShopDbContext context) : base(context) { }
        public Task<IEnumerable<Cita>> GetByMascotaIdAsync(int mascotaId)
        {
            throw new NotImplementedException();
        }
    }
}
