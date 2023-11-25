using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MSSQLApp.Data;
using Microsoft.OpenApi.Models;
using Fresko_BE.Data.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// builder.Services.AddSwaggerGen(c =>
//     c.AddServer(new OpenApiServer{
//         Url = "http://localhost:5292"
//     })
// );

builder.Services.AddSwaggerGen(c =>
  {
      c.AddServer(new OpenApiServer
      {
          Url = "http://localhost:5292"
      });
      c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
      c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme {
        Description = """Standard Authorization header using the Bearer scheme. Example: "bearer {token}" """,
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
      });
      c.OperationFilter<SecurityRequirementsOperationFilter>();
  });

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyHeader())
);

builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

// oopsie privacy breach allowed
app.UseCors(builder =>
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext?.Database.Migrate(); // bog blagoslovio
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger().UseSwaggerUI();
app.MapControllers();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.Run();