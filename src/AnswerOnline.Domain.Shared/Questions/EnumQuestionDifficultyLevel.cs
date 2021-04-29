using System.ComponentModel;

namespace AnswerOnline.Domain.Shared.Questions
{
    /// <summary>
    /// 难易度枚举
    /// </summary>
    public enum EnumQuestionDifficultyLevel
    {
        /// <summary>
        /// 简单
        /// </summary>
        [Description("简单")]
        Easy,

        /// <summary>
        /// 中等
        /// </summary>
        [Description("中等")]
        Middle,

        /// <summary>
        /// 困难
        /// </summary>
        [Description("困难")]
        Difficult
    }
}