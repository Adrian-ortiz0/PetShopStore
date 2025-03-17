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
    public class ServicioRepository : BaseRepository<Servicio>, IServicioRepository
    {

        public ServicioRepository(PetShopDbContext context) : base(context) { }
        public Task<IEnumerable<Servicio>> GetByCitaIdAsync(int citaId)
        {
            throw new NotImplementedException();
        }
    }
}
