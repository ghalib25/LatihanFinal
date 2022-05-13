using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models;
using OrderService;
using OrderService.GraphQL;
using System.Text;
using UserService.Models;

var builder = WebApplication.CreateBuilder(args);

var conString = builder.Configuration.GetConnectionString("MyDatabase");
builder.Services.AddDbContext<latihanfinalContext>(options =>
     options.UseSqlServer(conString)
);

// graphql
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddAuthorization();

builder.Services.AddControllers();
// DI Dependency Injection
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapGraphQL();
app.MapGet("/", () => "Hello World!");

app.Run();