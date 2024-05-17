using Learner.Application;
using Learner.Persistence;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationExtensions();
builder.Services.AddPersistenceExtensions(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("learner", policyBuilder =>
        {
            policyBuilder.WithOrigins(
                builder.Configuration.GetSection("allowOrigin").Get<string[]>()!
                );
            policyBuilder.WithMethods("GET", "DELETE", "POST", "UPDATE");
            policyBuilder.WithHeaders(HeaderNames.ContentType);
        }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
    app.UseSwagger();
    //place app.UseSwagger outside if block, if you want to use azure api management to work according to https://learn.microsoft.com/en-us/aspnet/core/tutorials/publish-to-azure-api-management-using-vs?view=aspnetcore-8.0 It needs to read the json documentation by Swagger to configure the layer between
}

app.UseHttpsRedirection();

app.UseCors("learner");

app.UseAuthorization();

app.MapControllers();

app.Run();
