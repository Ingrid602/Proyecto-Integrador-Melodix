using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoIntegrador_Melodix
{
    public class Pista
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Duracion { get; set; } // en segundos
        public DateTime CreadoEn { get; set; }
        public DateTime ActualizadoEn { get; set; }
        public string Artista { get; set; }
        public string Album { get; set; }
        public string UrlPortada { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public string SpotifyPistaId { get; set; }
        public int ArtistaId { get; set; }
    }
}
