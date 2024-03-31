using FrontEndApi.Filters;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition(BasicAuthenticationScheme.Basic,
        new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = System.Net.AuthenticationSchemes.Basic.ToString(),
            In = ParameterLocation.Header,
            Description = "Basic authorization header"

        });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
     {
        new OpenApiSecurityScheme{

            Reference=new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id=BasicAuthenticationScheme.Basic
               }

        },
        new string[]{ "Basic"}

        }
    });
});

builder.Services.AddAuthentication()
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(
                 BasicAuthenticationScheme.Basic,null
                 );

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddSingleton<HttpClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // Use authentication middleware
app.UseAuthorization(); // Use authorization middleware
app.UseCors();
app.MapControllers();

app.Run();
