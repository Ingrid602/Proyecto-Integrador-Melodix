using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegrador_Melodix
{
    public class UsuarioSigueArtista
    {
        public int Id { get; set; }
        public DateTime CreadoEn { get; set; }
        public int UsuarioId { get; set; }
        public int ArtistaId { get; set; }
    }
}
