using System.Collections.Generic;
using System.Threading.Tasks;
using AnswerOnline.Application.Commissioners.Dto;
using AnswerOnline.Toolkit.UnifyModel;

namespace AnswerOnline.Application.Commissioners
{
    /// <summary>
    /// 委员服务
    /// </summary>
    public interface ICommissionerAppService
    {
        /// <summary>
        /// 获取所有委员
        /// </summary>
        /// <returns></returns>
        Task<Result<List<CommissionerDto>>> GetAllAsync();
    }
}