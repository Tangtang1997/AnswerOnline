using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnswerOnline.Application.Questions.Dto;
using AnswerOnline.Domain.Entities.Questions;
using AnswerOnline.Toolkit.UnifyModel;
using AutoMapper;

namespace AnswerOnline.Application.Questions
{
    public class QuestionAppService : IQuestionAppService
    {
        private readonly QuestionManager _questionManager;
        private readonly IMapper _mapper;

        public QuestionAppService(QuestionManager questionManager, IMapper mapper)
        {
            _questionManager = questionManager;
            _mapper = mapper;
        }

        /// <summary>
        /// 根据一组委员id获取一组题
        /// </summary>
        /// <param name="commissinerIds"></param>
        /// <returns></returns>
        public async Task<Result<List<QuestionDto>>> GetQuestionsByCommissinerIdsAsync(List<Guid> commissinerIds)
        {
            if (commissinerIds.Count > 3)
            {
                return Result<List<QuestionDto>>.Failed(null, "一次最多只能选择三个委员");
            }

            var questions = await _questionManager.GetQuestionByCommissionerIds(commissinerIds);

            return new Result<List<QuestionDto>>
            {
                IsSucceeded = true,
                Data = _mapper.Map<List<QuestionDto>>(questions)
            };
        }
    }
}