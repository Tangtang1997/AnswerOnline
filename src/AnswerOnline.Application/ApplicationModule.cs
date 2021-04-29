using AnswerOnline.Application.Commissioners;
using AnswerOnline.Application.Participants;
using AnswerOnline.Application.Questions;
using AnswerOnline.Application.Submits;
using AnswerOnline.Toolkit.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnswerOnline.Application
{
    public class ApplicationModule : IModule
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IParticipantAppService, ParticipantAppService>();
            services.AddTransient<ICommissionerAppService, CommissionerAppService>();
            services.AddTransient<IQuestionAppService, QuestionAppService>();
            services.AddTransient<ISubmitAppService, SubmitAppService>();
        }
    }
}