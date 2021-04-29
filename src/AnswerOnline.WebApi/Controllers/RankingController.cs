using System.Collections.Generic;
using System.Threading.Tasks;
using AnswerOnline.Application.Participants;
using AnswerOnline.Application.Participants.Dto;
using AnswerOnline.Toolkit.UnifyModel;
using Microsoft.AspNetCore.Mvc;

namespace AnswerOnline.WebApi.Controllers
{
    /// <summary>
    /// 排名控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        private readonly IParticipantAppService _participantAppService;

        public RankingController(IParticipantAppService participantAppService)
        {
            _participantAppService = participantAppService;
        }

        /// <summary>
        /// 查看自己的排名
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        [HttpGet("{phoneNumber}")]
        public async Task<Result<int>> GetRankingByPhoneNumber(string phoneNumber)
        {
            return await _participantAppService.GetRankingAsync(phoneNumber);
        }

        /// <summary>
        /// 获取排名列表
        /// </summary>
        /// <param name="top">取前几名</param>
        /// <returns></returns>
        [HttpGet("top/{top}")]
        public Result<List<ParticipantTopDto>> GetTopList(int top)
        {
            return _participantAppService.GetTopList(top);
        }
    }
}