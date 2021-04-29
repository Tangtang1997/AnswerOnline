using AnswerOnline.Domain.Entities.Commissioners;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnswerOnline.EntityFrameworkCore.EntityTypeConfiguration
{
    public class CommissionerConfiguration:IEntityTypeConfiguration<Commissioner>
    {
        public void Configure(EntityTypeBuilder<Commissioner> builder)
        {
            builder.ToTable("Commissioner");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(36).IsUnicode(false);
            builder.Property(x => x.Name).HasMaxLength(30);
            builder.Property(x => x.Position).HasMaxLength(30);
            builder.Property(x => x.CreateTime).IsRequired();
            builder.Property(x => x.ModifyTime).IsRequired(false);

            builder.HasMany(x => x.Questions)
                .WithOne(x => x.Commissioner)
                .HasForeignKey(x => x.CommissionerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}