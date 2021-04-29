using AnswerOnline.Domain.Entities.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnswerOnline.EntityFrameworkCore.EntityTypeConfiguration
{
    public class QuestionConfiguration:IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Question");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(36).IsUnicode(false);
            builder.Property(x => x.CommissionerId).HasMaxLength(36).IsUnicode(false);
            builder.Property(x => x.Stem).HasMaxLength(500);
            builder.Property(x => x.CreateTime).IsRequired();
            builder.Property(x => x.ModifyTime).IsRequired(false);

            builder.HasMany(x => x.QuestionChoiceOptions)
                .WithOne(x => x.Question)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}