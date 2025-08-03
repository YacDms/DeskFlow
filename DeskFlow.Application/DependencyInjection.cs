using DeskFlow.Application.Interfaces;
using DeskFlow.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DeskFlow.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register AutoMapper profiles
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // Register application services
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<INoteService, NoteService>();

            return services;
        }
    }
}
