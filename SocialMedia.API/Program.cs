using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Service;
using SocialMedia.Infraestructure.Data;
using SocialMedia.Infraestructure.Filters;
using SocialMedia.Infraestructure.Repositories;
using SocialMedia.Infraestructure.Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
}).ConfigureApiBehaviorOptions(opt =>
{
    //opt.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretKey"]))
    };

});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<SocialMediaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.Configure<PaginationOptions>(builder.Configuration.GetSection("Pagination"));   

builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ISecurityService, SecurityService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

builder.Services.AddSingleton<IUriService>(provider =>
{
    var accesor = provider.GetRequiredService<IHttpContextAccessor>();
    var request = accesor.HttpContext.Request;
    var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
    return new UriService(absoluteUri);
});

builder.Services.AddMvc(opt =>
{
    opt.Filters.Add<ValidationFilter>();
}).AddFluentValidation(opt =>
{
    opt.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
