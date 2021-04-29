using System;
using AnswerOnline.Domain.Abstractions;

namespace AnswerOnline.Domain.Events
{
    /// <summary>
    /// 参赛者提交答案事件
    /// </summary>
    public class SubmittedDomainEvent : IDomainEvent
    {
        public SubmittedDomainEvent(Guid submitterId, int score, double timeOfSubmit)
        {
            SubmitterId = submitterId;
            Score = score;
            TimeOfSubmit = timeOfSubmit;
        }

        /// <summary>
        /// 参赛者Id
        /// </summary>
        public Guid SubmitterId { get; }

        /// <summary>
        /// 得分
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// 用时
        /// </summary>
        public double TimeOfSubmit { get; set; }
    }
}