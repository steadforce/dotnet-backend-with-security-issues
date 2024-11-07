using DotnetBackendWithSecurityIssues.Api.Database;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder.Services, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

IssuesDbBoostrapper.UpdateDatabase(app.Services);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void RegisterServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddIssuesDatabase(configuration);
    services.AddScoped<IDbForumOperations, DbForumOperations>();
}


