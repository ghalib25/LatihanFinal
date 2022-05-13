using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models;
using ProductService.GraphQL;
using System.Text;

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

var app = builder.Build();
app.UseAuthorization();
app.UseAuthentication();
app.MapGraphQL("/");
app.MapGet("/Hello", () => "Hello World!");

app.Run();