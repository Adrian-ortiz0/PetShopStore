using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetShopCore.Models.DTOs;
using PetShopCore.Models.Entities;
using PetShopCore.Services;

namespace PetShopStore.Pages
{
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
                return BadRequest("Los datos enviados no son validos");
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
            return RedirectToPage();
        }
    }
}
