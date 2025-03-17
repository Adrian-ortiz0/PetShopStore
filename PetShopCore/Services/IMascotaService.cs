using PetShopCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCore.Services
{
    public interface IMascotaService : IService<Mascota>
    {
        Task<IEnumerable<Mascota>> GetByDueñoIdAsync(int dueñoId);
    }
}
