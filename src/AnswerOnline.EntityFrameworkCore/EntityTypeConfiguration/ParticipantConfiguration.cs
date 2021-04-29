using AnswerOnline.Domain.Entities.Participants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnswerOnline.EntityFrameworkCore.EntityTypeConfiguration
{
    public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.ToTable("Participant");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasMaxLength(36)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(x => x.Name)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(22)
                .IsRequired();

            builder.Property(x => x.Department)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.CreateTime)
                .IsRequired();

            builder.Property(x => x.ModifyTime)
                .IsRequired(false);
        }
    }
}