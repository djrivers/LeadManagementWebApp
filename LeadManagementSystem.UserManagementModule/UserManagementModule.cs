using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.ApplicationBuilder.Internal;
using LeadManagementSystem.UserManagement.Application;
using LeadManagementSystem.UserManagement.Domain;
using LeadManagementSystem.UserManagement.Infrastructure;
using LeadManagementSystem.UserManagement.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeadManagementSystem.UserManagementModule;

public static class UserManagementModule
{

    public static void Setup<TContext>(IObjectSpaceProviderServiceBasedBuilder<TContext> builderObjectSpaceProviders, IModuleBuilder<TContext> builderModules, IConfiguration configuration)
        where TContext : IXafApplicationBuilder<TContext>, IAccessor<IServiceCollection>
    {
        builderModules.Add<DomainModule>();
        builderModules.Add<UIModule>();
        builderModules.Add<InfrastructureModule>();
        builderModules.Add<ApplicationModule>();
    }
}