using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;

namespace Vfd.Theme;

public sealed class Startup : StartupBase
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddResourceConfiguration<ResourceManagementOptionsConfiguration>();
    }
}
