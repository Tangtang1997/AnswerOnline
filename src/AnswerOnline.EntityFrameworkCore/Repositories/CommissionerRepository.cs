using AnswerOnline.Domain.Entities.Commissioners;

namespace AnswerOnline.EntityFrameworkCore.Repositories
{
    public class CommissionerRepository : EfCoreRepository<Commissioner>, ICommissionerRepository
    {
        public CommissionerRepository(AppDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}