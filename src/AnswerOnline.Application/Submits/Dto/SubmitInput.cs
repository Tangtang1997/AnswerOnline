using System;
using System.Collections.Generic;

namespace AnswerOnline.Application.Submits.Dto
{
    /// <summary>
    /// 提交答案输入参数
    /// </summary>
    public class SubmitInput
    {
        /// <summary>
        /// 提交者Id
        /// </summary>
        public Guid SubmitterId { get; set; }

        /// <summary>
        /// 做题用时 
        /// </summary>
        public int TimeOfSubmit { get; set; }
         
        /// <summary>
        /// 寄语
        /// </summary>
        public string SendWord { get; set; }

        /// <summary>
        /// 提交的答案
        /// </summary>
        public List<SubmitQuestionDto> SubmitQustions { get; set; }
    }
}
