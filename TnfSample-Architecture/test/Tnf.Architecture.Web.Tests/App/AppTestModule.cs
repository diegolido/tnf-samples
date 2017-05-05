﻿using Tnf.AspNetCore.TestBase;
using Tnf.Modules;
using Tnf.Architecture.Application;
using Tnf.Architecture.Domain.Interfaces.Repositories;
using Tnf.Architecture.Web.Tests.Mocks;
using Tnf.Configuration.Startup;
using Tnf.App.EntityFrameworkCore.TestBase;
using Tnf.Architecture.EntityFrameworkCore;
using System;
using Tnf.Reflection.Extensions;

namespace Tnf.Architecture.Web.Tests.App
{
    [DependsOn(
        typeof(AppModule),
        typeof(TnfAspNetCoreTestBaseModule))]
    public class AppTestModule : TnfModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Mock repositories
            Configuration.ReplaceService<IWhiteHouseRepository, WhiteHouseRepositoryMock>();

            Configuration.Modules
                .TnfEfCoreInMemory(IocManager.IocContainer, IocManager.Resolve<IServiceProvider>())
                .RegisterDbContextInMemory<ArchitectureDbContext>()
                .RegisterDbContextInMemory<LegacyDbContext>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AppTestModule).GetAssembly());
        }
    }
}
