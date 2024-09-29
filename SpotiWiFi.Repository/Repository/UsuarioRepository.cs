using Microsoft.EntityFrameworkCore;
using SpotiWiFi.Domain.Conta.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Repository.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {
        public SpotiWiFiContext Context { get; set; }

        public UsuarioRepository(SpotiWiFiContext context) : base(context)
        {
            Context = context;
        }

        //public Playlist GetPlaylistById(Guid id)
        //{
        //    return Context.Playlists.Find(id);
        //}

        //public void UpdatePlaylist(Playlist playlist) 
        //{
        //    this.Context.Playlists.Update(playlist);
        //    this.Context.SaveChanges();
        //}
    }
}
