using System;
using System.Collections.Generic;
using System.Linq;
using AnswerOnline.Domain.Abstractions;
using AnswerOnline.Domain.Entities.Commissioners;
using AnswerOnline.Domain.Shared.Questions;

namespace AnswerOnline.Domain.Entities.Questions
{
    /// <summary>
    /// 试题
    /// </summary>
    public class Question : AggregateRoot
    {
        private Question()
        {
            CreateTime = DateTime.Now;
            QuestionChoiceOptions = new List<QuestionChoiceOption>();
        }

        public Question(int number, string stem, EnumQuestionType questionType, EnumQuestionDifficultyLevel questionDifficultyLevel, int score, Guid commissionerId)
            : this()
        {
            Number = number;
            Stem = stem;
            QuestionType = questionType;
            Level = questionDifficultyLevel;
            Score = score;
            CommissionerId = commissionerId;
        }

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
        public Commissioner Commissioner { get; set; }

        public List<QuestionChoiceOption> QuestionChoiceOptions { get; set; }

        /// <summary>
        /// 为选择题添加一个选项
        /// </summary>
        /// <param name="option"></param>
        /// <param name="optionType"></param>
        /// <param name="isAnswer"></param>
        public void AddChoiceOption(string option, EnumQuestionOptionType optionType, bool isAnswer)
        {
            if (QuestionChoiceOptions.Exists(x => x.OptionType == optionType))
            {
                return;
            }

            QuestionChoiceOptions.Add(new QuestionChoiceOption(option, optionType, isAnswer));
        }

        /// <summary>
        /// 获取正确答案
        /// </summary>
        /// <returns></returns>
        public List<QuestionChoiceOption> GetAnswer()
        {
            return QuestionChoiceOptions.Where(x => x.IsAnswer).ToList();
        }

        /// <summary>
        /// 判断单选题回答是否正确(判断题是特殊的单选题)
        /// </summary>
        /// <param name="submitQuestionOption"></param>
        /// <returns></returns>
        public bool CalculateChoiceSignleScore(EnumQuestionOptionType submitQuestionOption)
        {
            return QuestionChoiceOptions.Any(x => x.OptionType == submitQuestionOption && x.IsAnswer);
        }

        /// <summary>
        /// 判断多选题回答是否正确
        /// </summary>
        /// <param name="submitQuestionOptions"></param>
        /// <returns></returns>
        public bool CalculateChoiceMultipleScore(List<EnumQuestionOptionType> submitQuestionOptions)
        {
            if (!submitQuestionOptions.Any() || submitQuestionOptions.Count == 0)
            {
                return false;
            }

            var answerOptions = GetAnswer();

            while (submitQuestionOptions.Count > 0)
            {
                if (submitQuestionOptions.Count == 0 && answerOptions.Count != 0)
                {
                    return false;
                }

                foreach (var submitQuestionOption in submitQuestionOptions)
                {
                    if (!answerOptions.Exists(x => x.OptionType == submitQuestionOption))
                    {
                        return false;
                    }

                    answerOptions.Remove(answerOptions.FirstOrDefault(x => x.OptionType == submitQuestionOption));
                    submitQuestionOptions.Remove(submitQuestionOption);
                    break;
                }
            }

            return submitQuestionOptions.Count == 0;
        }
    }
}