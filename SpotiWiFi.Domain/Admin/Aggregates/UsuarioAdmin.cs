﻿using SpotiWiFi.Domain.Core.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Domain.Admin.Aggregates
{
    public class UsuarioAdmin
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Perfil Perfil { get; set; }

        public void CriptografarSenha()
        {
            this.Senha = this.Senha.HashSHA256();
        }
    }
}
