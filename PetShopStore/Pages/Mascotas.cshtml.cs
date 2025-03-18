using Microsoft.AspNetCore.Http.HttpResults;
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
        private readonly IService<Mascota> _macotaServiceGeneric;

        public MascotasModel(IMascotaService mascotaService, IService<Dueño> dueñoService, IService<Mascota> mascotaServiceGeneric)
        {
            _mascotaService = mascotaService;
            _dueñoService = dueñoService;
            _macotaServiceGeneric = mascotaServiceGeneric;
        }

        public async Task<IActionResult> OnGetMascotasAsync()
        {
            var mascotas = await _mascotaService.GetAllAsync();
            return new JsonResult( mascotas );
        }

        public async Task<IActionResult> OnPostEditarMascotaAsync([FromBody] Mascota mascota)
        {
            if (mascota == null)
            {
                return BadRequest("No existe la mascota para editar");
            }

            var mascotaExistente = await _macotaServiceGeneric.GetByIdAsync(mascota.Id);
            if (mascotaExistente == null)
            {
                return NotFound("La mascota no existe en la base de datos");
            }

            mascotaExistente.Nombre = mascota.Nombre;
            mascotaExistente.Especie = mascota.Especie;
            mascotaExistente.Raza = mascota.Raza;
            mascotaExistente.FechaNacimiento = mascota.FechaNacimiento;

            await _macotaServiceGeneric.UpdateAsync(mascotaExistente);

            return new JsonResult(new { message = "Mascota editada con éxito", mascota = mascotaExistente });
        }

        public async Task<IActionResult> OnPostDeleteMascota([FromQuery] int id)
        {
            var mascotaAEliminar = await _macotaServiceGeneric.GetByIdAsync(id);

            if(mascotaAEliminar == null)
            {
                return BadRequest("No se encontró la mascota para eliminar");
            }
            await _macotaServiceGeneric.DeleteAsync(id);
            return new JsonResult(new { message = "No content" }) { StatusCode = 201 };

        }

        public async Task<IActionResult> OnPostGuardarMascotaAsync([FromBody] MascotaConDueñoDto nuevaMascota)
        {
            if (nuevaMascota == null)
            {
                return BadRequest(new { success = false, message = "El objeto recibido es nulo." });
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
