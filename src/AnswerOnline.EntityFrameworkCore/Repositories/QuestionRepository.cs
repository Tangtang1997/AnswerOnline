using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AnswerOnline.Domain.Entities.Questions;
using Microsoft.EntityFrameworkCore;

namespace AnswerOnline.EntityFrameworkCore.Repositories
{
    public class QuestionRepository : EfCoreRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(AppDbContext dbContext)
            : base(dbContext)
        {

        }

        public Question GetById(Guid id)
        {
            var question =  GetAll()
                                .Where(x => x.Id == id)
                                .Include(x => x.QuestionChoiceOptions)
                                .FirstOrDefault();

            return question;
        }

        public async Task<List<Question>> GetQuestionsByCommissionerIdAsync(Guid commissionerid)
        {
            var questions = await GetAll()
                                      .Include(x => x.QuestionChoiceOptions)
                                      .Where(x => x.CommissionerId == commissionerid)
                                      .ToListAsync();

            return questions;
        }

        public async Task<Question> FirstOrDefaultAsync(Guid id)
        {
            var question = await GetAll()
                                    .Where(x => x.Id == id)
                                    .Include(x => x.QuestionChoiceOptions)
                                    .FirstOrDefaultAsync();

            return question;
        }

        public override IList<Question> List(Expression<Func<Question, bool>> predicate)
        {
            return  GetAll()
                            .Include(x => x.QuestionChoiceOptions)
                            .Where(predicate)
                            .ToList();
        }
    }
}