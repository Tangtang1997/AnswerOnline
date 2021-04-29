using AnswerOnline.Domain.Entities.Submits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnswerOnline.EntityFrameworkCore.EntityTypeConfiguration
{
    public class SubmitConfiguration : IEntityTypeConfiguration<Submit>
    {
        public void Configure(EntityTypeBuilder<Submit> builder)
        {
            builder.ToTable("Submit");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(36).IsUnicode(false);
            builder.Property(x => x.SubmitterId).HasMaxLength(36).IsUnicode(false);
            builder.Property(x => x.SendWord).HasMaxLength(300);

            builder.Property(x => x.CreateTime).IsRequired();
            builder.Property(x => x.ModifyTime).IsRequired(false);
        }
    }
}