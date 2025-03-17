using PetShopCore.Interfaces;
using PetShopCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCore.Services
{
    public class MascotaService : BaseService<Mascota>, IMascotaService
    {
        private readonly IMascotaRepository _mascotaRepository;

        public MascotaService(IMascotaRepository mascotaRepository) : base(mascotaRepository)
        {
            _mascotaRepository = mascotaRepository;
        }

        public async Task<IEnumerable<Mascota>> GetByDueñoIdAsync(int dueñoId)
        {
            return await _mascotaRepository.GetByDueñoIdAsync(dueñoId);
        }
    }
}
