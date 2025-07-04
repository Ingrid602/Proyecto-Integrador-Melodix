using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegrador_Melodix;

    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoIntegrador_Melodix.Album> Albums { get; set; } = default!;

public DbSet<ProyectoIntegrador_Melodix.Artista> Artistas { get; set; } = default!;

public DbSet<ProyectoIntegrador_Melodix.HistorialEscucha> HistorialesEscucha { get; set; } = default!;

public DbSet<ProyectoIntegrador_Melodix.HistorialLike> HistorialesLikes { get; set; } = default!;

public DbSet<ProyectoIntegrador_Melodix.ListaPista> ListasPistas { get; set; } = default!;

public DbSet<ProyectoIntegrador_Melodix.ListaReproduccion> ListasReproducciones { get; set; } = default!;

public DbSet<ProyectoIntegrador_Melodix.Pista> Pistas { get; set; } = default!;

public DbSet<ProyectoIntegrador_Melodix.Usuario> Usuarios { get; set; } = default!;

public DbSet<ProyectoIntegrador_Melodix.UsuarioLikeAlbum> UsuariosLikeAlbums { get; set; } = default!;

public DbSet<ProyectoIntegrador_Melodix.UsuarioSigueLista> UsuariosSigueListas { get; set; } = default!;

public DbSet<ProyectoIntegrador_Melodix.UsuarioSigueArtista> UsuariosSigueArtistas { get; set; } = default!;

public DbSet<ProyectoIntegrador_Melodix.UsuarioSigue> UsuariosSigue { get; set; } = default!;

public DbSet<ProyectoIntegrador_Melodix.UsuarioLikeLista> UsuariosLikeListas { get; set; } = default!;

public DbSet<ProyectoIntegrador_Melodix.UsuarioLikePista> UsuariosLikePistas { get; set; } = default!;
    }
