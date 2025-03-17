using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCore.Models.Entities
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public double Precio { get; set; } 
        public ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
    }
}
