using blog_management_service.Interfaces;
using blog_management_service.Middlewares;
using blog_management_service.Models;
using blog_management_service.Services;
using blog_management_service.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<AppExceptionHandler>();
builder.Services.AddScoped<IBlogPostService, BlogPostService>();
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
    {
        policy
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .SetIsOriginAllowed(o =>
        {
            var url = new Uri(o);
            return (url.Scheme == Uri.UriSchemeHttp && url.Host.Equals("localhost", StringComparison.InvariantCultureIgnoreCase));
        })
        .WithExposedHeaders("Content-Disposition");
    })
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseExceptionHandler(_ => { });

app.Use(async (_, next) =>
{
    JsonFileHelper.CheckAndCreate();
    await next.Invoke();
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
