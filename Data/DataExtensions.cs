using Microsoft.EntityFrameworkCore;

namespace App_Store.Api.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppsStoreContext>();
        dbContext.Database.Migrate();
    }
}
