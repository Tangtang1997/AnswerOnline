namespace AnswerOnline.Application.Participants.Dto
{
    /// <summary>
    /// 验证答题参与者的身份信息
    /// </summary>
    public class VerifyParticipantInput
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }
    }
}