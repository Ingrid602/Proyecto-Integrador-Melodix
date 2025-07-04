using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegrador_Melodix
{
    public class ListaReproduccion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Publica { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime ActualizadoEn { get; set; }
        public string Descripcion { get; set; }
        public string SpotifyListaId { get; set; }
        public bool Sincronizada { get; set; }
        public bool Colaborativa { get; set; }
        public int UsuarioId { get; set; }
    }
}
