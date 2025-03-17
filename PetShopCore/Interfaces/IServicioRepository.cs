using PetShopCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCore.Interfaces
{
    public interface IServicioRepository : IRepository<Servicio>
    {
        Task<IEnumerable<Servicio>> GetByCitaIdAsync(int citaId);
    }
}
