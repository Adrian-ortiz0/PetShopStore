using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCore.Models.Entities
{
    public class Dueño
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;

        public ICollection<Mascota> Mascotas { get; set; } = new List<Mascota>();
    }
}
