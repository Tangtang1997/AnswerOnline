using AnswerOnline.Domain.Entities.Submits;

namespace AnswerOnline.EntityFrameworkCore.Repositories
{
    public class SubmitRepository : EfCoreRepository<Submit>, ISubmitRepository
    {
        public SubmitRepository(AppDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}