using Microsoft.EntityFrameworkCore;
using SpotiWiFi.Domain.Streaming.Aggregates;
using SpotiWiFi.Domain.Streaming.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Repository.Mapping.Streaming
{
    public class MusicaMapping : IEntityTypeConfiguration<Musica>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Musica> builder)
        {
            builder.ToTable(nameof(Musica));
            
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);

            builder.OwnsOne<Duracao>(d => d.Duracao, c =>
            {
                c.Property(x => x.Valor).IsRequired().HasMaxLength(50);
            });
        }
    }
}
