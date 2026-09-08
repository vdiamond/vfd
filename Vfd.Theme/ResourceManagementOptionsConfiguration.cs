using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace Vfd.Theme;

public sealed class ResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
{
    private static readonly ResourceManifest Manifest;

    static ResourceManagementOptionsConfiguration()
    {
        Manifest = new ResourceManifest();

        Manifest
            .DefineStyle("Vfd.Theme.Branding")
            .SetUrl("~/Vfd.Theme/css/vfd-branding.css")
            .SetVersion("1.0.0");
    }

    public void Configure(ResourceManagementOptions options)
    {
        options.ResourceManifests.Add(Manifest);
    }
}
