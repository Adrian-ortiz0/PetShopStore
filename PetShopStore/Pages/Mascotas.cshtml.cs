using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetShopCore.Models.DTOs;
using PetShopCore.Models.Entities;
using PetShopCore.Services;

namespace PetShopStore.Pages
{
    [IgnoreAntiforgeryToken]
    public class MascotasModel : PageModel
    {
        private readonly IMascotaService _mascotaService;
        private readonly IService<Dueño> _dueñoService;

        public MascotasModel(IMascotaService mascotaService, IService<Dueño> dueñoService)
        {
            _mascotaService = mascotaService;
            _dueñoService = dueñoService;
        }

        public async Task<IActionResult> OnGetMascotasAsync()
        {
            var mascotas = await _mascotaService.GetAllAsync();
            return new JsonResult( mascotas );
        }

        public async Task<IActionResult> OnPostGuardarMascotaAsync([FromBody] MascotaConDueñoDto nuevaMascota)
        {
            if (nuevaMascota == null)
            {
                return BadRequest(new { success = false, message = "El objeto recibido es nulo." });
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { success = false, errors });
            }

            var dueño = new Dueño
            {
                Nombre = nuevaMascota.NombreDueño,
                Cedula = nuevaMascota.Cedula,
                Telefono = nuevaMascota.Telefono,
                Correo = nuevaMascota.Correo
            };

            var mascota = new Mascota
            {
                Nombre = nuevaMascota.NombreMascota,
                Especie = nuevaMascota.Especie,
                Raza = nuevaMascota.Raza,
                FechaNacimiento = nuevaMascota.FechaNacimiento,
                Dueño = dueño
            };
            await _dueñoService.AddAsync(dueño);
            await _mascotaService.AddAsync(mascota);
            return new JsonResult(new { success = true, message = "Mascota guardada exitosamente." });
        }
    }
}
