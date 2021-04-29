using System;

namespace AnswerOnline.Application.Commissioners.Dto
{
    public class CommissionerDto
    {
        public Guid Id { get; set; } 

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public string Position { get; set; }
    }
}