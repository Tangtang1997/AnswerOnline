using System.Collections.Generic;
using System.Threading.Tasks;
using AnswerOnline.Application.Submits.Dto;
using AnswerOnline.Toolkit.UnifyModel;

namespace AnswerOnline.Application.Submits
{
    /// <summary>
    /// 提交服务
    /// </summary>
    public interface ISubmitAppService
    {
        /// <summary>
        /// 评分
        /// </summary>
        /// <param name="submitInput"></param>
        /// <returns></returns>
        Task<Result<SubmitOutput>> GradeAsync(SubmitInput submitInput);

        Task<Result<List<SendWordDto>>> GetSendWordAsync(int number); 
    }
}
