using System.Collections.Generic;
using System.Threading.Tasks;
using AnswerOnline.Application.Participants.Dto;
using AnswerOnline.Domain.Entities.Participants;
using AnswerOnline.Toolkit.UnifyModel;
using AutoMapper;

namespace AnswerOnline.Application.Participants
{
    public class ParticipantAppService : IParticipantAppService
    {
        private readonly ParticipantManager _participantManager;
        private readonly IMapper _mapper;

        public ParticipantAppService(ParticipantManager participantManager, IMapper mapper)
        {
            _participantManager = participantManager;
            _mapper = mapper;
        }

        /// <summary>
        /// 验证手机号、姓名
        /// </summary>
        /// <param name="verifyParticipantInput"></param>
        /// <returns></returns>
        public async Task<Result<VerifyParticipantOutput>> VerifySubmitAsync(VerifyParticipantInput verifyParticipantInput)
        {
            var participant = await _participantManager.CreateIfNotExistAsync(verifyParticipantInput.PhoneNumber, verifyParticipantInput.Name, verifyParticipantInput.Department);

            if (participant.HaveResidueDegree())
            {
                return new Result<VerifyParticipantOutput>
                {
                    IsSucceeded = true,
                    Data = new VerifyParticipantOutput
                    {
                        Id = participant.Id,
                        Name = participant.Name,
                        PhoneNumber = participant.PhoneNumber,
                        Department = participant.Department,
                        AnsweredNumber = participant.AnsweredNumber
                    }
                };
            }

            return new Result<VerifyParticipantOutput>
            {
                IsSucceeded = false,
                Description = "答题次数已用完"
            };
        }

        /// <summary>
        /// 获取已答题次数
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public async Task<Result<int>> GetAnsweredNumberAsync(string phoneNumber)
        {
            return new Result<int>
            {
                IsSucceeded = true,
                Data = await _participantManager.GetAnsweredNumberAsync(phoneNumber)
            };
        }

        /// <summary>
        /// 获取top排名列表
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public Result<List<ParticipantTopDto>> GetTopList(int top)
        {
            var participants = _participantManager.GetTopList(top);

            return new Result<List<ParticipantTopDto>>
            {
                IsSucceeded = true,
                Data = _mapper.Map<List<ParticipantTopDto>>(participants)
            };
        }

        /// <summary>
        /// 查看自己的排名
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public async Task<Result<int>> GetRankingAsync(string phoneNumber)
        {
            return new Result<int>
            {
                IsSucceeded = true,
                Data = await _participantManager.GetRankingAsync(phoneNumber)
            };
        }
    }
}