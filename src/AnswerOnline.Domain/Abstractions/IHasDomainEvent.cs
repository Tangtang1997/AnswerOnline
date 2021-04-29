using System.Collections.Generic;
using MediatR;

namespace AnswerOnline.Domain.Abstractions
{
    public interface IHasDomainEvent
    {
        IReadOnlyCollection<INotification> DomainEvents { get; }

        void ClearDomainEvents();
    }
}