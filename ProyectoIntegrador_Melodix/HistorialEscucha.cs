using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegrador_Melodix
{
    internal class HistorialEscucha
    {
        public int Id { get; set; }
        public DateTime EscuchadaEn { get; set; }
        public int UsuarioId { get; set; }
        public int PistaId { get; set; }
    }
}
