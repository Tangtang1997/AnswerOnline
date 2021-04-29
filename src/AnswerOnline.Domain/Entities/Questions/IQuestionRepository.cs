using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnswerOnline.Domain.Abstractions;

namespace AnswerOnline.Domain.Entities.Questions
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Question GetById(Guid id);

        Task<List<Question>> GetQuestionsByCommissionerIdAsync(Guid commissionerid);

        Task<Question> FirstOrDefaultAsync(Guid id); 
    }
}