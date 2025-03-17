using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCore.Models.Entities
{
    public class Servicio
    {
        public int Id { get; set; }
        public TipoServicio TipoServicio { get; set; }
        public double Precio { get; set; }
        public int CitaId { get; set; }
        public Cita Cita { get; set; }
        public ICollection<Medicamento> Medicamentos { get; set; } = new List<Medicamento>();

    }
}
