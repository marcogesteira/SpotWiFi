using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotiWiFi.Domain.Admin.Aggregates;
using SpotiWiFi.Domain.Conta.Aggregates;
using SpotiWiFi.Domain.Notificacao;
using SpotiWiFi.Domain.Streaming.Aggregates;
using SpotiWiFi.Domain.Transacao.Aggregates;
using SpotiWiFi.Repository.Mapping.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Repository
{
    public class SpotiWiFiAdminContext : DbContext
    {
        public DbSet<UsuarioAdmin> UsuarioAdmins { get; set; }

        public SpotiWiFiAdminContext(DbContextOptions<SpotiWiFiAdminContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioAdminMapping());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
