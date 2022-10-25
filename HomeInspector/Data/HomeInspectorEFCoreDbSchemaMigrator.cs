using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace HomeInspector.Data;

public class HomeInspectorEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public HomeInspectorEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the HomeInspectorDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<HomeInspectorDbContext>()
            .Database
            .MigrateAsync();
    }
}
