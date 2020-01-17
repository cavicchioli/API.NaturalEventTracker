using API.NaturalEventTracker.Application.AutoMapper;
using API.NaturalEventTracker.Application.Commands;
using API.NaturalEventTracker.Application.Commands.Validations;
using API.NaturalEventTracker.Application.Handlers;
using API.NaturalEventTracker.Application.Notifications;
using API.NaturalEventTracker.Domain.Interfaces;
using API.NaturalEventTracker.Infra.Data.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace API.NaturalEventTracker.Infra.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static IServiceCollection AddBootStrapperIoC(
               this IServiceCollection services
           )
        {
            //Mapping Profiles
            services.AddScoped<IMapper>(sp => new Mapper(AutoMapperConfig.RegisterMappings()))

            //Repositories
            .AddSingleton<IEventRepository, EventRepository>()
            .AddSingleton<ICategoryRepository, CategoryRepository>()

            //Validator Pipeline
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationRequestBehaviorHandler<,>))

            //Validators
            .AddTransient<IValidator<GetEventByIdCommand>, GetEventByIdCommandValidation>()
            .AddTransient<IValidator<ListEventCommand>, ListEventCommandValidation>()

            //Validators Notification
            .AddScoped<INotificationContext, NotificationContext>();


            return services;
        }
    }
}
