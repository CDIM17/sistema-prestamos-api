using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_prestamos_api.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public int TipoPrestamoId { get; set; }
        public int Monto { get; set; }
        public int Cuota { get; set; }
        public int Total { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
