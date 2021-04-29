using MediatR;
using System;
using System.Collections.Generic;

namespace AnswerOnline.Domain.Abstractions
{
    public abstract class BaseEntity : IHasDomainEvent
    {
        public Guid Id { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }

        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents ??= new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}