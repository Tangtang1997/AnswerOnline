using System;

namespace AnswerOnline.Application.Participants.Dto
{
    /// <summary>
    /// 验证答题参与者的身份信息
    /// </summary>
    public class VerifyParticipantOutput
    {
        /// <summary>
        /// 参与者唯一标识
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 参与者姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 参与者手机号
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 已答题次数
        /// </summary>
        public int AnsweredNumber { get; set; }  
    }
}