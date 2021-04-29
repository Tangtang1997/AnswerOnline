using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AnswerOnline.Domain.Abstractions;
using AnswerOnline.Domain.Entities.Commissioners;
using AnswerOnline.Domain.Entities.Participants;
using AnswerOnline.Domain.Entities.Questions;
using AnswerOnline.Domain.Entities.Submits;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnswerOnline.EntityFrameworkCore
{
    public class AppDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<Commissioner> Commissioners { get; set; }

        public DbSet<Submit> Submits { get; set; }

        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionChoiceOption> QuestionChoiceOptions { get; set; }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this);

            var saveResult = await SaveChangesAsync(cancellationToken);

            return saveResult != 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}