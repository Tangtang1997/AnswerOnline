using System.Collections.Generic;
using System.Threading.Tasks;
using AnswerOnline.Application.Submits;
using AnswerOnline.Application.Submits.Dto;
using AnswerOnline.Toolkit.UnifyModel;
using Microsoft.AspNetCore.Mvc;

namespace AnswerOnline.WebApi.Controllers
{
    /// <summary>
    /// 寄语
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SendWordController : ControllerBase
    {
        private readonly ISubmitAppService _submitAppService;

        public SendWordController(ISubmitAppService submitAppService)
        {
            _submitAppService = submitAppService; 
        }

        /// <summary>
        /// 随机取几条寄语
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result<List<SendWordDto>>> GetSendWord(int number)
        {
            return await _submitAppService.GetSendWordAsync(number);
        }
    }
}