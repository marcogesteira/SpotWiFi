﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotiWiFi.Domain.Streaming.Aggregates;
using SpotiWiFi.Domain.Streaming.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Repository.Mapping.Streaming
{
    public class BandaMapping : IEntityTypeConfiguration<Banda>
    {
        public void Configure(EntityTypeBuilder<Banda> builder)
        {
            builder.ToTable(nameof(Banda));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1024);
            builder.Property(x => x.Backdrop).IsRequired().HasMaxLength(50);

            builder.HasMany<Album>(x => x.Albums).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
