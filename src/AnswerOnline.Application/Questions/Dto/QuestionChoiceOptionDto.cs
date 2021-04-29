using System;
using AnswerOnline.Domain.Shared.Questions;

namespace AnswerOnline.Application.Questions.Dto
{
    public class QuestionChoiceOptionDto
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 项 
        /// </summary>
        public string Option { get; set; }

        /// <summary>
        /// 对于选择题：A、B、C、D（0、1、2、3）
        /// 对于判断题：True、False（0、1）
        /// </summary>
        public EnumQuestionOptionType OptionType { get; set; }
    }
}