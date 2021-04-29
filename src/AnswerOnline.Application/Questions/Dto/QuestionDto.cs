using AnswerOnline.Domain.Shared.Questions;
using System;
using System.Collections.Generic;

namespace AnswerOnline.Application.Questions.Dto
{
    public class QuestionDto
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 序号，编号
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 题干
        /// </summary>
        public string Stem { get; set; }

        /// <summary>
        /// 题型
        /// </summary>
        public EnumQuestionType QuestionType { get; set; }

        /// <summary>
        /// 难易度
        /// </summary>
        public EnumQuestionDifficultyLevel Level { get; set; }

        /// <summary>
        /// 分值
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// 关联委员Id
        /// </summary>
        public Guid CommissionerId { get; set; }

        public List<QuestionChoiceOptionDto> QuestionChoiceOptions { get; set; }
    }
}