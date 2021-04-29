using AnswerOnline.Domain.Abstractions;
using AnswerOnline.Domain.Entities.Commissioners;
using AnswerOnline.Domain.Entities.Participants;
using AnswerOnline.Domain.Entities.Questions;
using AnswerOnline.Domain.Entities.Submits;
using AnswerOnline.EntityFrameworkCore.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));

            services.AddScoped<ICommissionerRepository, CommissionerRepository>();
            services.AddScoped<ISubmitRepository, SubmitRepository>();
            services.AddScoped<IParticipantRepository, ParticipantRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();

            return services;
        }
    }
}