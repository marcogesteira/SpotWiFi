using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotiWiFi.Domain.Admin.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Repository.Mapping.Admin
{
    public class UsuarioAdminMapping : IEntityTypeConfiguration<UsuarioAdmin>
    {
        public void Configure(EntityTypeBuilder<UsuarioAdmin> builder)
        {
            builder.ToTable(nameof(UsuarioAdmin));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x =>x.Email).IsRequired();
            builder.Property(x => x.Senha).IsRequired();
            builder.Property(x => x.Perfil).IsRequired();
        }
    }
}
