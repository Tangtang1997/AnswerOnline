using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnswerOnline.Application.Participants.Dto;
using AnswerOnline.Toolkit.UnifyModel;

namespace AnswerOnline.Application.Participants
{
    /// <summary>
    /// 参赛者服务
    /// </summary>
    public interface IParticipantAppService
    {
        /// <summary>
        /// 验证手机号、姓名
        /// </summary>
        /// <param name="verifyParticipantInput"></param>
        /// <returns></returns>
        Task<Result<VerifyParticipantOutput>> VerifySubmitAsync(VerifyParticipantInput verifyParticipantInput);

        /// <summary>
        /// 获取已答题次数
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        Task<Result<int>> GetAnsweredNumberAsync(string phoneNumber);

        /// <summary>
        /// 获取top排名列表
        /// </summary> 
        /// <param name="top"></param>
        /// <returns></returns>
        Result<List<ParticipantTopDto>> GetTopList(int top);

        /// <summary>
        /// 查看自己的排名
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        Task<Result<int>> GetRankingAsync(string phoneNumber);
    } 
}