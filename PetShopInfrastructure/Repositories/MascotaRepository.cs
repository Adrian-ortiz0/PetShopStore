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
    public class MascotaRepository : BaseRepository<Mascota>, IMascotaRepository
    {

        public MascotaRepository(PetShopDbContext context) : base(context) { }

        public Task<IEnumerable<Mascota>> GetByDueñoIdAsync(int dueñoId)
        {
            throw new NotImplementedException();
        }
    }
}
