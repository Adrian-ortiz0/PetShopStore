using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCore.Models.Entities
{
    public class Cita
    {
        public int Id { get; set; }
        public int MascotaId { get; set; }
        public Mascota Mascota { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
    }
}
