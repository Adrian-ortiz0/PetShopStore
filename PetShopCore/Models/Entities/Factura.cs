using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCore.Models.Entities
{
    public class Factura
    {
        public int Id { get; set; }
        public int DueñoId { get; set; }
        public Dueño Dueño  { get; set; }
        public DateTime FechaCita { get; set; }
        public double TotalFactura { get; set; }
        public ICollection<Servicio> Servicios { get; set; }
    }
}
