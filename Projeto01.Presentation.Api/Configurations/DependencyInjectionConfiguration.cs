using Microsoft.Extensions.DependencyInjection;
using Projeto01.Application.Contracts;
using Projeto01.Application.Services;
using Projeto01.CrossCutting.Cryptography;
using Projeto01.Domain.Contracts.CrossCuttings.Cryptography;
using Projeto01.Domain.Contracts.Repositories;
using Projeto01.Domain.Contracts.Services;
using Projeto01.Domain.Services;
using Projeto01.Infra.Data.SqlServer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto01.Presentation.Api.Configurations
{
    public class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(IServiceCollection services)
        {
            #region Application

            services.AddTransient<ITurmaApplicationService, TurmaApplicationService>();
            services.AddTransient<IAlunoApplicationService, AlunoApplicationService>();
            services.AddTransient<IUsuarioApplicationService, UsuarioApplicationService>();

            #endregion

            #region Domain

            services.AddTransient<ITurmaDomainService, TurmaDomainService>();
            services.AddTransient<IAlunoDomainService, AlunoDomainService>();
            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();

            #endregion

            #region InfraStructure

            services.AddTransient<ITurmaRepository, TurmaRepository>();
            services.AddTransient<IAlunoRepository, AlunoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #endregion

            #region CrossCutting

            services.AddTransient<IMD5Cryptography, MD5Cryptography>();

            #endregion
        }
    }
}
