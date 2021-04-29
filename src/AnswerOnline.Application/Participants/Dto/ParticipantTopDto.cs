namespace AnswerOnline.Application.Participants.Dto
{
    /// <summary>
    /// 排名
    /// </summary>
    public class ParticipantTopDto
    {
        /// <summary>
        /// 参赛者姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 参赛者手机号
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        public int Score { get; set; }
    }
}