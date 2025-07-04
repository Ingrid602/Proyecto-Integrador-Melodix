using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoIntegrador_Melodix
{
    public class Album
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public string UrlPortada { get; set; }
        public string SpotifyAlbumId { get; set; }
        public int ArtistaId { get; set; }
    }
}
