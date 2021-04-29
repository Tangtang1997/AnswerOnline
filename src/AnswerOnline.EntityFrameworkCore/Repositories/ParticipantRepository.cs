using AnswerOnline.Domain.Entities.Participants;

namespace AnswerOnline.EntityFrameworkCore.Repositories
{
    public class ParticipantRepository : EfCoreRepository<Participant>, IParticipantRepository
    {
        public ParticipantRepository(AppDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}