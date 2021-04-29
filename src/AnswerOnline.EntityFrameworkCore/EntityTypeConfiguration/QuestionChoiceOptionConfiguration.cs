using AnswerOnline.Domain.Entities.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnswerOnline.EntityFrameworkCore.EntityTypeConfiguration
{
    public class QuestionChoiceOptionConfiguration:IEntityTypeConfiguration<QuestionChoiceOption>
    {
        public void Configure(EntityTypeBuilder<QuestionChoiceOption> builder)
        {
            builder.ToTable("QuestionChoiceOption");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(36).IsUnicode(false);
            builder.Property(x => x.QuestionId).HasMaxLength(36).IsUnicode(false);
            builder.Property(x => x.Option).HasMaxLength(500);
            builder.Property(x => x.CreateTime).IsRequired();
            builder.Property(x => x.ModifyTime).IsRequired(false);
        }
    }
}