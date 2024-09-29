using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotiWiFi.Domain.Admin.Aggregates;
using SpotiWiFi.Domain.Conta.Aggregates;
using SpotiWiFi.Domain.Notificacao;
using SpotiWiFi.Domain.Streaming.Aggregates;
using SpotiWiFi.Domain.Transacao.Aggregates;
using SpotiWiFi.Repository.Mapping.Conta;
using SpotiWiFi.Repository.Mapping.Notificacao;
using SpotiWiFi.Repository.Mapping.Streaming;
using SpotiWiFi.Repository.Mapping.Transacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Repository
{
    public class SpotiWiFiContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Assinatura> Assinaturas { get; set; }
        //public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        //public DbSet<Banda> Bandas { get; set; }
        //public DbSet<Album> Albuns { get; set; }
        //public DbSet<Musica> Musicas { get; set; }
        public DbSet<Plano> Planos { get; set; }

        public SpotiWiFiContext(DbContextOptions<SpotiWiFiContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpotiWiFiContext).Assembly);
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new EnderecoCobrancaMapping());
            modelBuilder.ApplyConfiguration(new CartaoMapping());
            modelBuilder.ApplyConfiguration(new PlanoMapping());
            modelBuilder.ApplyConfiguration(new TransacaoMapping());
            modelBuilder.ApplyConfiguration(new NotificacaoMapping());
            modelBuilder.ApplyConfiguration(new AssinaturaMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
