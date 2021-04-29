using System;
using AnswerOnline.Domain.Abstractions;
using AnswerOnline.Domain.Shared.Questions;

namespace AnswerOnline.Domain.Entities.Questions
{
    /// <summary>
    /// 选项
    /// </summary>
    public class QuestionChoiceOption : BaseEntity
    {
        public QuestionChoiceOption(string option, EnumQuestionOptionType optionType, bool isAnswer)
        {
            Option = option;
            OptionType = optionType;
            IsAnswer = isAnswer;
            CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 项 
        /// </summary>
        public string Option { get; set; }

        /// <summary>
        /// 对于选择题：A、B、C、D（0、1、2、3）
        /// 对于判断题：True、False（0、1）
        /// </summary>
        public EnumQuestionOptionType OptionType { get; set; }

        /// <summary>
        /// 是否为正确答案
        /// </summary>
        public bool IsAnswer { get; set; }

        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}