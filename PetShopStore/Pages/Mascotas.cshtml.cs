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
        private readonly IService<Due�o> _due�oService;
        private readonly IService<Mascota> _macotaServiceGeneric;

        public MascotasModel(IMascotaService mascotaService, IService<Due�o> due�oService, IService<Mascota> mascotaServiceGeneric)
        {
            _mascotaService = mascotaService;
            _due�oService = due�oService;
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

            return new JsonResult(new { message = "Mascota editada con �xito", mascota = mascotaExistente });
        }

        public async Task<IActionResult> OnPostDeleteMascota([FromQuery] int id)
        {
            var mascotaAEliminar = await _macotaServiceGeneric.GetByIdAsync(id);

            if(mascotaAEliminar == null)
            {
                return BadRequest("No se encontr� la mascota para eliminar");
            }
            await _macotaServiceGeneric.DeleteAsync(id);
            return new JsonResult(new { message = "No content" }) { StatusCode = 201 };

        }

        public async Task<IActionResult> OnPostGuardarMascotaAsync([FromBody] MascotaConDue�oDto nuevaMascota)
        {
            if (nuevaMascota == null)
            {
                return BadRequest(new { success = false, message = "El objeto recibido es nulo." });
            }

            var due�o = new Due�o
            {
                Nombre = nuevaMascota.NombreDue�o,
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
                Due�o = due�o
            };
            await _due�oService.AddAsync(due�o);
            await _mascotaService.AddAsync(mascota);
            return new JsonResult(new { success = true, message = "Mascota guardada exitosamente." });
        }
    }
}
