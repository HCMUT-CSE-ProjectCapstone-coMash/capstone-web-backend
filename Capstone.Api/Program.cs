using Capstone.Application;
using Capstone.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowFrontend", policy =>
        {
            policy
                .WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
    });
}
;

var app = builder.Build();

app.UseCors("AllowFrontend"); 
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

