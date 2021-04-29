namespace AnswerOnline.Application.Submits.Dto
{
    /// <summary>
    /// 提交答案的输出参数
    /// </summary>
    public class SubmitOutput
    {
        /// <summary>
        /// 得分
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// 排名
        /// </summary>
        public int Ranking { get; set; }

        /// <summary>
        /// 已答题次数
        /// </summary>
        public int AnswerNumber { get; set; }
    }
}