using Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Database.Map;

public class TransactionMap : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transaction");

        builder.HasKey(it => it.Id);

        builder.Property(it => it.Id)
            .UseIdentityColumn();

        builder.Property(it => it.TransactionType)
            .IsRequired();

        builder.Property(it => it.Value)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(it => it.LegalDocument)
            .IsUnicode(false)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(it => it.CardNumber)
            .IsUnicode(false)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(it => it.OccurrenceAt)
            .HasColumnType("DATETIME2")
            .IsRequired();

        builder.Property(it => it.StoreOwner)
            .IsUnicode(false)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(it => it.StoreName)
            .IsUnicode(false)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(it => it.CreatedAt)
            .HasColumnType("DATETIME2")
            .IsRequired();
    }
}
