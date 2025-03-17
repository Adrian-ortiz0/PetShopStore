using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCore.Models.Entities
{
    public class Mascota
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Especie { get; set; } = string.Empty;
        public string Raza { get; set; } = string.Empty;
        public DateTime? FechaNacimiento { get; set; }
        public int DueñoId { get; set; }
        public Dueño Dueño { get; set; }
        public ICollection<HistorialClinico> HistorialClinico { get; set; } = new List<HistorialClinico>();
    }
}
