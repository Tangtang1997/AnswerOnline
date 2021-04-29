using System.Linq;
using System.Threading.Tasks;
using AnswerOnline.Domain.Abstractions;
using AnswerOnline.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MediatR
{
    public static class MediatoRExtensions
    {
        /// <summary>
        /// 领域事件调度器
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, AppDbContext context)
        {
            var domainEntities = context.ChangeTracker
                                        .Entries<BaseEntity>()
                                        .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var entityEntries = domainEntities as EntityEntry<BaseEntity>[] ?? domainEntities.ToArray();
            var domainEvents = entityEntries.SelectMany(x => x.Entity.DomainEvents)
                                            .ToList();

            entityEntries.ToList().ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent);
            }
        }
    }
}