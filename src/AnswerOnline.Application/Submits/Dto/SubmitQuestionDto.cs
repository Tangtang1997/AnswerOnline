using AnswerOnline.Domain.Shared.Questions;
using System;
using System.Collections.Generic;

namespace AnswerOnline.Application.Submits.Dto
{
    /// <summary>
    /// 题
    /// </summary>
    public class SubmitQuestionDto
    {
        /// <summary>
        /// 题Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 答案选项
        /// </summary>
        public List<EnumQuestionOptionType> QuestionOptionTypes { get; set; }   
    }
}
