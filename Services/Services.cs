using Library.EntityFramework;
using Library.EntityFramework.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.AnswerSetManagement;
using Services.AnswerSetManagement.Implementation;
using Services.GenericRepository;
using Services.GenericRepository.Implementation;
using Services.QuestionManagement;
using Services.QuestionManagement.Implementation;
using Services.RecommendationManagement;
using Services.RecommendationManagement.Implementation;
using Services.SessionManagement;
using Services.SessionManagement.Implementation;

namespace Services
{
    public static class Services
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<IDatabaseContext, DatabaseContext>(opt => opt.UseMySql(config.GetConnectionString("Default"), ServerVersion.Parse(config.GetConnectionString("ServerVersion"))));
            services.AddScoped<IGenericQuerier, GenericQuerier>();
            services.AddScoped<IGenericRepo, GenericRepo>();
            services.AddScoped<IQuestionManager, QuestionManager>();
            services.AddScoped<ISessionManager, SessionManager>();
            services.AddScoped<IAnswerSetManager, AnswerSetManager>();
            services.AddScoped<IRecommendationManager, RecommendationManager>();
        }
    }
}
