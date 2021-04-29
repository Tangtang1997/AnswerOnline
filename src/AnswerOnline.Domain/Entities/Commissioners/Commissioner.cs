using System;
using System.Collections.Generic;
using AnswerOnline.Domain.Abstractions;
using AnswerOnline.Domain.Entities.Questions;
using AnswerOnline.Domain.Shared.Questions;

namespace AnswerOnline.Domain.Entities.Commissioners
{
    /// <summary>
    /// 委员
    /// </summary>
    public class Commissioner : AggregateRoot
    {
        public Commissioner(string name, string position)
        {
            Name = name;
            Position = position;
            CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 职位 
        /// </summary>
        public string Position { get; set; }

        public List<Question> Questions { get; set; }
    }
}