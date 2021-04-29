using AnswerOnline.Domain.Entities.Participants;
using AnswerOnline.Domain.Entities.Questions;
using AnswerOnline.Domain.Entities.Submits;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DomainServiceExtensions
    {
        public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ParticipantManager>();
            services.AddScoped<QuestionManager>();
            services.AddScoped<SubmitManager>();

            return services;
        }
    }
} 