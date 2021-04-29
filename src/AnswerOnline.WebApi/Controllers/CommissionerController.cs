using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnswerOnline.Application.Commissioners;
using AnswerOnline.Application.Commissioners.Dto;
using AnswerOnline.Application.Questions;
using AnswerOnline.Application.Questions.Dto;
using AnswerOnline.Application.Submits;
using AnswerOnline.Application.Submits.Dto;
using AnswerOnline.Toolkit.UnifyModel;
using Microsoft.AspNetCore.Mvc;

namespace AnswerOnline.WebApi.Controllers
{
    /// <summary>
    /// 委员控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CommissionerController : ControllerBase
    {
        private readonly ICommissionerAppService _commissionerAppService;
        private readonly IQuestionAppService _questionAppService;
        private readonly ISubmitAppService _submitAppService;

        public CommissionerController(ICommissionerAppService commissionerAppService,IQuestionAppService questionAppService,ISubmitAppService submitAppService)
        {
            _commissionerAppService = commissionerAppService;
            _questionAppService = questionAppService;
            _submitAppService = submitAppService;
        }

        /// <summary>
        /// 获取所有委员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result<List<CommissionerDto>>> GetAll()
        {
            return await _commissionerAppService.GetAllAsync();
        }

        /// <summary>
        /// 根据一组委员id获取一组题
        /// </summary>
        /// <param name="commissinerIds">一组委员id</param>
        /// <returns></returns>
        [HttpPost("questions")]
        public async Task<Result<List<QuestionDto>>> GetQuestionsByCommissinerIds(List<Guid> commissinerIds)
        {
            return await _questionAppService.GetQuestionsByCommissinerIdsAsync(commissinerIds);
        }

        /// <summary>
        /// 提交试题，获取评分
        /// </summary>
        /// <param name="submitInput"></param>
        /// <returns></returns>
        [HttpPost("Grade")]
        public async Task<Result<SubmitOutput>> Grade(SubmitInput submitInput)
        {
            return await _submitAppService.GradeAsync(submitInput);
        }
    }
}