using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnswerOnline.Application.Questions.Dto;
using AnswerOnline.Toolkit.UnifyModel;

namespace AnswerOnline.Application.Questions
{
    public interface IQuestionAppService
    {
        /// <summary>
        /// 根据一组委员id获取一组题
        /// </summary>
        /// <param name="commissinerIds"></param>
        /// <returns></returns>
        Task<Result<List<QuestionDto>>> GetQuestionsByCommissinerIdsAsync(List<Guid> commissinerIds);
    }
}