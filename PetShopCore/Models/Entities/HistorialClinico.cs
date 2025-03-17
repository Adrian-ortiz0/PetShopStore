using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCore.Models.Entities
{
    public class HistorialClinico
    {
        public int Id { get; set; }
        public int MascotaId { get; set; }
        public Mascota Mascota { get; set; }
        public DateTime FechaConsulta { get; set; }
        public string Peso {  get; set; } = string.Empty;
        public string Altura { get; set; } = string.Empty;
        public string Diagnostico { get; set; } = string.Empty;
        public string Tratamiento { get; set; } = string.Empty;
        public ICollection<string> Alergias { get; set; } = new List<string>();
    }
}
