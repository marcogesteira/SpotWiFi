using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotiWiFi.Domain.Conta.Aggregates;
using SpotiWiFi.Domain.Conta.ValueObjects;
using SpotiWiFi.Domain.Streaming.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Repository.Mapping.Conta
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DtNascimento).IsRequired();


            builder.OwnsOne<CPF>(d => d.CPF, c =>
            {
                c.Property(x => x.Numero).IsRequired().HasMaxLength(50);
            });

            builder.OwnsOne<EnderecoCobranca>(d => d.EnderecoCobranca, c =>
            {
                c.Property(x => x.Endereco).IsRequired().HasMaxLength(1024);
                c.Property(x => x.CEP).IsRequired().HasMaxLength(50);
                c.Property(x => x.Bairro).IsRequired().HasMaxLength(150);
                c.Property(x => x.Cidade).IsRequired().HasMaxLength(150);
                c.Property(x => x.Pais).IsRequired().HasMaxLength(150);
            });

            builder.HasMany(x => x.Cartoes).WithOne();
            builder.HasMany(x => x.Assinaturas).WithOne();
            builder.HasMany(x => x.Playlists).WithOne(x => x.Usuario);
            
        }
    }
}
