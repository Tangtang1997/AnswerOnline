using System;
using System.Net;
using System.Threading.Tasks;
using AnswerOnline.Application.Participants;
using AnswerOnline.Application.Participants.Dto;
using AnswerOnline.Toolkit.UnifyModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnswerOnline.WebApi.Controllers
{
    /// <summary>
    /// 参赛者控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantAppService _participantAppService;
        private readonly ILogger<ParticipantController> _logger;

        public ParticipantController(IParticipantAppService participantAppService, ILogger<ParticipantController> logger)
        {
            _participantAppService = participantAppService;
            _logger = logger;
        }

        /// <summary>
        /// 提交手机号、姓名进行验证，返回手机号、姓名、已答题次数
        /// </summary>
        /// <param name="verifyParticipantInput"></param>
        /// <returns></returns>
        [HttpPost("Verify")]
        [ProducesResponseType(typeof(Result<VerifyParticipantOutput>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<Result<VerifyParticipantOutput>> Submit(VerifyParticipantInput verifyParticipantInput)
        {
            _logger.LogInformation(verifyParticipantInput.ToJsonString());
            return await _participantAppService.VerifySubmitAsync(verifyParticipantInput);
        }

        /// <summary>
        /// 根据手机号获取已答题次数
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        [HttpGet("answerNumber/{phoneNumber}")]
        public async Task<Result<int>> GetAnswerNumberByPhoneNumber(string phoneNumber)
        {
            return await _participantAppService.GetAnsweredNumberAsync(phoneNumber);
        }

    }
}
