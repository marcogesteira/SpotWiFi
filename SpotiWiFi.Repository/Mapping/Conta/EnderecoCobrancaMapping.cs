using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotiWiFi.Domain.Conta.Aggregates;
using SpotiWiFi.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Repository.Mapping.Conta
{
    public class EnderecoCobrancaMapping : IEntityTypeConfiguration<EnderecoCobranca>
    {
        public void Configure(EntityTypeBuilder<EnderecoCobranca> builder)
        {
            builder.ToTable(nameof(EnderecoCobranca));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(1024);
            builder.Property(x => x.CEP).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Cidade).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Pais).IsRequired().HasMaxLength(150);
        }
    }
}
