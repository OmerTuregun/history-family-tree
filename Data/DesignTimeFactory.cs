using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SoyAgaci.Api.Data;

public class DesignTimeFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var cs = Environment.GetEnvironmentVariable("ConnectionStrings__Default")
                 ?? "server=127.0.0.1;port=3310;database=soyagaci;user=soyuser;password=CHANGE_ME;TreatTinyAsBoolean=false;CharSet=utf8mb4;";
        var opt = new DbContextOptionsBuilder<AppDbContext>()
            .UseMySql(cs, ServerVersion.AutoDetect(cs))
            .Options;
        return new AppDbContext(opt);
    }
}
