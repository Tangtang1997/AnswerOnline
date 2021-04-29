using System.Threading;
using System.Threading.Tasks;
using AnswerOnline.Domain.Entities.Participants;
using AnswerOnline.Domain.Events;
using MediatR;

namespace AnswerOnline.Application.DomainEventHandlers.Submitted
{
    /// <summary>
    /// 参赛者提交答案事件处理
    /// </summary>
    public class SubmitDomainHandler : INotificationHandler<SubmittedDomainEvent>
    {
        private readonly IParticipantRepository _participantRepository;

        public SubmitDomainHandler(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public async Task Handle(SubmittedDomainEvent notification, CancellationToken cancellationToken)
        {
            var participant = await _participantRepository.FirstOrDefaultAsync(x => x.Id == notification.SubmitterId, cancellationToken);

            //更新参赛者的成绩和答题用时
            participant?.UpdateHighestScore(notification.Score,notification.TimeOfSubmit);
        }
    }
}