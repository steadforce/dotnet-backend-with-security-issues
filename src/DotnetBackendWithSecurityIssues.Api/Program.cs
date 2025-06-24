using DotnetBackendWithSecurityIssues.Api.Database;
using DotnetBackendWithSecurityIssues.Api.Service;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder.Services, builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

await IssuesDbBoostrapper.UpdateDatabaseAsync(app.Services);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowAllOrigins");
app.Run();

static void RegisterServices(IServiceCollection services, IConfiguration configuration)
{
  services.AddCors(options =>
  {
    options.AddPolicy("AllowAllOrigins", policy =>
    {
      policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
  });

  services.AddControllers();
  services.AddEndpointsApiExplorer();
  services.AddSwaggerGen();
  services.AddIssuesDatabase(configuration);
  services.AddScoped<IIssuesForumOperations, IssuesForumOperations>();
}
