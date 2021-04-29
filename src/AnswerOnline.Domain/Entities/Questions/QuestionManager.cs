using System;
using System.Collections.Generic;
using System.Linq;
using AnswerOnline.Domain.Shared.Questions;
using System.Threading.Tasks;

namespace AnswerOnline.Domain.Entities.Questions
{
    public class QuestionManager
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionManager(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        /// <summary>
        /// 根据一组委员Id获取一组题
        /// </summary>
        /// <param name="commiddionerIds"></param>
        /// <returns></returns>
        public async Task<List<Question>> GetQuestionByCommissionerIds(List<Guid> commiddionerIds)
        {
            var questions = new List<Question>();

            foreach (var commiddionerId in commiddionerIds)
            {
                questions.AddRange(await _questionRepository.GetQuestionsByCommissionerIdAsync(commiddionerId));
            }

            return questions;
        }

        /// <summary>
        /// 计算一组题的得分
        /// </summary>
        /// <param name="submits"></param>
        /// <returns></returns>
        public int CalculateScore(Dictionary<Guid, List<EnumQuestionOptionType>> submits)
        {
            var questionIds = submits.Keys;

            var questions = _questionRepository.List(x => questionIds.Contains(x.Id)).ToList();

            var score = 0;

            foreach (var (questionId, optionTypes) in submits)
            {
                var question = questions.FirstOrDefault(x => x.Id == questionId);

                if (question == null)
                {
                    continue;
                }

                switch (question.QuestionType)
                {
                    case EnumQuestionType.Judgment:
                    case EnumQuestionType.SignleChoice:
                        score += question.CalculateChoiceSignleScore(optionTypes.First()) ? question.Score : 0;
                        break;
                    case EnumQuestionType.MultipleChoice:
                        score += question.CalculateChoiceMultipleScore(optionTypes) ? question.Score : 0;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return score;
        }

    }
}