using System;
using AnswerOnline.Domain.Abstractions;

namespace AnswerOnline.Domain.Entities.Submits
{
    /// <summary> 
    /// 提交
    /// </summary>
    public class Submit : AggregateRoot
    {
        private Submit()
        {
            CreateTime = DateTime.Now;
        }

        public Submit(Guid submitterId, int score, int timeOfSubmit, string sendWord)
            : this()
        {
            SubmitterId = submitterId;
            Score = score;
            TimeOfSubmit = timeOfSubmit;
            SendWord = sendWord;
        }

        /// <summary>
        /// 提交人Id
        /// </summary>
        public Guid SubmitterId { get; set; }

        /// <summary>
        /// 得分
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// 用时
        /// </summary>
        public int TimeOfSubmit { get; set; }

        /// <summary>
        /// 寄语
        /// </summary>
        public string SendWord { get; set; }

    }
}