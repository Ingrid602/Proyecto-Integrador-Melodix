using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace ProyectoIntegrador_Melodix
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime ActualizadoEn { get; set; }
        public string Proveedor { get; set; }
        public string Biografia { get; set; }
        public string FotoPerfil { get; set; }
        public string Ubicacion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string SpotifyId { get; set; }
        public string SpotifyTokenAcceso { get; set; }
        public string SpotifyTokenRefresco { get; set; }
    }
}
