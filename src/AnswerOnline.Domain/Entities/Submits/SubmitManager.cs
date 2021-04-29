using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnswerOnline.Domain.Events;

namespace AnswerOnline.Domain.Entities.Submits
{
    public class SubmitManager
    {
        private readonly ISubmitRepository _submitRepository;

        public SubmitManager(ISubmitRepository submitRepository)
        {
            _submitRepository = submitRepository;
        }

        /// <summary>
        /// 保存提交记录
        /// </summary>
        /// <param name="submitterId">参赛者Id</param>
        /// <param name="score">分数</param>
        /// <param name="timeOfSubmit"></param>
        /// <param name="sendWord">寄语</param>
        /// <returns></returns>
        public async Task<Submit> SaveAsync(Guid submitterId, int score, int timeOfSubmit, string sendWord)
        {
            var submit = await _submitRepository.AddAsync(new Submit(submitterId, score, timeOfSubmit, sendWord));
            submit.AddDomainEvent(new SubmittedDomainEvent(submitterId, submit.Score, submit.TimeOfSubmit));

            await _submitRepository.UnitOfWork.SaveEntitiesAsync();

            return submit;
        }

        public async Task<IList<Submit>> GetAllAsync()
        {
            return await _submitRepository.ListAllAsync();
        }

        public List<Submit> GetRandomList(int number)
        {
            return _submitRepository.GetAll().OrderBy(x => Guid.NewGuid()).Take(number).ToList();
        }
    }
}