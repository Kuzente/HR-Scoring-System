using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using SamiProje.Business.Abstract;
using SamiProje.Business.Concrete;
using SamiProje.DataAccess.Abstract;
using SamiProje.DataAccess.Concrete;

namespace SamiProje.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDataAccessLifetimes(this IServiceCollection services) 
        {
            services.AddScoped<IDepartmantDal, DepartmantDal>();
            services.AddScoped<IBranchDal, BranchDal>();
            services.AddScoped<IUserDal, UserDal>();
            services.AddScoped<ITitleDal, TitleDal>();
            services.AddScoped<ITitleQuestionDal, TitleQuestionDal>();
        }
        public static void ConfigureBusinessLifetimes(this IServiceCollection services) 
        {
            services.AddScoped<IDepartmantService, DepartmantManager>();
            services.AddScoped<IBranchService, BranchManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<ITitleService, TitleManager>();
            services.AddScoped<ITitleQuestionService ,  TitleQuestionManager>();
        }
    }
}
