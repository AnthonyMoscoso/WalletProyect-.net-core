using Business.DataServices.Abstracts;
using Business.DataServices.Specifics;
using Business.EncryptServices.Algorithms;
using Business.EncryptServices.Profiles;
using Business.GenerateEntityServices;
using Business.LogServices.SerilogServices;
using Business.Validations;
using Core.Entities.Utilities.Email;
using Core.Entities.Utilities.Encrypt;
using Core.Entities.Utilities.EntityGenerator.Abstracts;
using Core.Entities.Utilities.Logs;
using Entities.Dto;
using FluentValidation;
using Infra.DataAccess.Abstracts;
using Infra.DataAccess.Specifics.DBs.EF;
using Infra.SMTP;
using Microsoft.Extensions.DependencyInjection;

namespace WalletApi.Middleware.ServicesCollection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            services.AddSingleton<ILogManager, SerilogTxtManager>();
            services.AddScoped<IEmailManager, EmailManager>();


            services.AddScoped<IEncrypt, EncryptBase64>();


            #region Users dependencies

            services.AddScoped<IValidator<UserDto>, UsersValidator>();
            services.AddScoped<IEncrypterProfile<UserDto>, UserEncrypterProfile>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserEFRepository>();
            services.AddScoped<IEntityGenerator<UserDto>, UserGeneratorProfile>();
            #endregion


            #region Ingress

            services.AddScoped<IValidator<IngressDto>, IngressValidator>();
            services.AddScoped<IEncrypterProfile<IngressDto>, IngressEncrypterProfile>();
            services.AddScoped<IIngressService, IngressService>();
            services.AddScoped<IIngressRepository, IngressEFRepository>();
            services.AddScoped<IEntityGenerator<IngressDto>, IngressGeneratorProfile>();

            #endregion

            // IngressType

            services.AddScoped<IIngressTypeRepository, IngressTypeEFRepository>();
            services.AddScoped<IIngressTypeService, IngressTypeService>();
            services.AddScoped<IValidator<IngressTypeDto>, IngressTypeValidator>();
            services.AddScoped<IEncrypterProfile<IngressTypeDto>, IngressTypeEncrypterProfile>();
            services.AddScoped<IEntityGenerator<IngressTypeDto>, IngressTypeGeneratorProfile>();

            // Expense  

            services.AddScoped<IValidator<ExpenseDto>, ExpenseValidator>();
            services.AddScoped<IEncrypterProfile<ExpenseDto>, ExpenseEncrypterProfile>();
            services.AddScoped<IExpenseService, ExpenseServices>();
            services.AddScoped<IExpenseRepository, ExpenseEFRepository>();
            services.AddScoped<IEntityGenerator<ExpenseDto>, ExpenseGeneratorProfile>();


            // Expense Type
            services.AddScoped<IExpenseTypeRepository, ExpenseTypeEFRepository>();
            services.AddScoped<IExpenseTypeService, ExpenseTypeServices>();
            services.AddScoped<IValidator<ExpenseTypeDto>, ExpenseTypeValidator>();
            services.AddScoped<IEncrypterProfile<ExpenseTypeDto>, ExpenseTypeEncrypterProfile>();
            services.AddScoped<IEntityGenerator<ExpenseTypeDto>, ExpenseTypeGeneratorProfile>();

            return services;
        }
    }
}
