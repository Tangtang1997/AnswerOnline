using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnswerOnline.Application.Submits.Dto;
using AnswerOnline.Domain.Entities.Participants;
using AnswerOnline.Domain.Entities.Questions;
using AnswerOnline.Domain.Entities.Submits;
using AnswerOnline.Toolkit.UnifyModel;
using Microsoft.Extensions.Configuration;

namespace AnswerOnline.Application.Submits
{
    public class SubmitAppService : ISubmitAppService
    {
        private readonly ParticipantManager _participantManager;
        private readonly QuestionManager _questionManager;
        private readonly SubmitManager _submitManager;
        private readonly IConfiguration _configuration;

        public SubmitAppService(ParticipantManager participantManager, QuestionManager questionManager, SubmitManager submitManager, IConfiguration configuration)
        {
            _participantManager = participantManager;
            _questionManager = questionManager;
            _submitManager = submitManager;
            _configuration = configuration;
        }

        /// <summary>
        /// 评分
        /// </summary>
        /// <param name="submitInput"></param>
        /// <returns></returns>
        public async Task<Result<SubmitOutput>> GradeAsync(SubmitInput submitInput)
        {
            var participant = await _participantManager.GetByIdAsync(submitInput.SubmitterId);
            if (participant == null)
            {
                return Result<SubmitOutput>.Failed(null, $"提交者Id错误，数据库中找不到id为{submitInput.SubmitterId}的数据");
            }

            //再判断一次有参赛者当日还有没有答题次数
            if (!participant.HaveResidueDegree())
            {
                return Result<SubmitOutput>.Failed(null, "当日答题次数已用完");
            }

            var submit = await _submitManager.SaveAsync(submitInput.SubmitterId, CalculateScore(submitInput.SubmitQustions), submitInput.TimeOfSubmit, submitInput.SendWord);

            return new Result<SubmitOutput>
            {
                IsSucceeded = true,
                Data = new SubmitOutput
                {
                    Score = submit.Score,
                    Ranking = await _participantManager.GetRankingAsync(participant.PhoneNumber),
                    AnswerNumber = await _participantManager.GetAnsweredNumberAsync(participant.PhoneNumber)
                }
            };
        }

        public async Task<Result<List<SendWordDto>>> GetSendWordAsync(int number)
        {
            var submits = _submitManager.GetRandomList(number);

            var sendWordDtos = new List<SendWordDto>();

            foreach (var submit in submits)
            {
                var participent = await _participantManager.GetByIdAsync(submit.SubmitterId);


                var sendWordDto = new SendWordDto
                {
                    SendWord = submit.SendWord,
                    Name = participent.Name
                };

                sendWordDtos.Add(sendWordDto);
            }

            if (sendWordDtos.Count <= 5)
            {
                sendWordDtos.AddRange(GetSendWordSeedData());
            }

            return new Result<List<SendWordDto>>
            {
                IsSucceeded = true,
                Data = sendWordDtos.OrderBy(x => Guid.NewGuid()).ToList()
            };
        }

        private IEnumerable<SendWordDto> GetSendWordSeedData()
        {
            var sendWordSeedDatas = new List<SendWordDto>();
            _configuration.Bind("SendWordSeedData", sendWordSeedDatas);

            return sendWordSeedDatas;
        }

        /// <summary>
        /// 计算得分
        /// </summary>
        /// <param name="submitQuestionDtos"></param>
        /// <returns></returns>
        private int CalculateScore(IEnumerable<SubmitQuestionDto> submitQuestionDtos)
        {
            var submits = submitQuestionDtos.ToDictionary(submitQuestionDto => submitQuestionDto.Id, submitQuestionDto => submitQuestionDto.QuestionOptionTypes);

            var score = _questionManager.CalculateScore(submits);

            return score;
        }
    }
}
