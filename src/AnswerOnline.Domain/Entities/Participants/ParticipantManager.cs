using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerOnline.Domain.Entities.Participants
{
    public class ParticipantManager
    {
        private readonly IParticipantRepository _participantRepository;

        public ParticipantManager(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        /// <summary>
        /// 以手机号作为唯一标识，如果不存在就创建，存在则更新名称字段
        /// </summary>
        /// <param name="phoneNumber">手机号</param>
        /// <param name="name">名称</param>
        /// <param name="department"></param>
        /// <returns></returns>
        public async Task<Participant> CreateIfNotExistAsync(string phoneNumber, string name, string department)
        {
            var participant = await _participantRepository.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);

            if (participant != null)
            {
                participant.Name = name;
                participant.Department = department;
                participant.ModifyTime = DateTime.Now;
                await _participantRepository.UnitOfWork.SaveChangesAsync();
                return participant;
            }

            var newParticipant = await _participantRepository.AddAsync(new Participant(phoneNumber, name, department));
            await _participantRepository.UnitOfWork.SaveChangesAsync();
            return newParticipant;
        }

        /// <summary>
        /// 获取已答题次数
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public async Task<int> GetAnsweredNumberAsync(string phoneNumber)
        {
            var participant = await _participantRepository.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);

            return participant?.AnsweredNumber ?? 0;
        }

        /// <summary>
        /// 根据Id查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Participant> GetByIdAsync(Guid id)
        {
            return await _participantRepository.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// 获取个人排名
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public async Task<int> GetRankingAsync(string phoneNumber)
        {
            var participant = await _participantRepository.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);

            if (participant == null)
            {
                return 0;
            }

            var participants = await _participantRepository.ListAllAsync();

            //成绩相同，按答题用时排序
            var rankingParticipants = participants.OrderByDescending(x => x.HighestScore)
                                                  .ThenBy(x => x.TimeOfHighestScore)
                                                  .ToList();

            var index = rankingParticipants.IndexOf(participant);

            return index + 1;
        }

        /// <summary>
        /// 获取排名列表
        /// </summary>
        /// <param name="top"></param> 
        /// <returns></returns>
        public List<Participant> GetTopList(int top)
        {
            var participants = _participantRepository.GetAll()
                                                      .OrderByDescending(x => x.HighestScore)
                                                      .ThenBy(x => x.TimeOfHighestScore)
                                                      .Take(top)
                                                      .ToList();

            return participants;
        }
    }
}