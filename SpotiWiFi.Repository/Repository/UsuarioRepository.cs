using SpotiWiFi.Domain.Conta.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Repository.Repository
{
    public class UsuarioRepository
    {
        public SpotiWiFiContext Context { get; set; }

        public UsuarioRepository(SpotiWiFiContext context) 
        {
            Context = context;
        }

        public void Salvar(Usuario usuario)
        {
            Context.Usuarios.Add(usuario);
            Context.SaveChanges();
        }

        public Usuario GetUsuarioByEmail(string email)
        {
            return Context.Usuarios.FirstOrDefault(x => x.Email == email);
        }

        public bool ExisteUsuario(string email)
        {
            return this.GetUsuarioByEmail(email) is not null;
        }
    }
}
