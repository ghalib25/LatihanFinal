using HotChocolate.AspNetCore.Authorization;
using Models;
using System.Security.Claims;
using UserService.Models;

namespace UserService.GraphQL
{
    public class Query
    {
        [Authorize(Roles = new[] { "ADMIN" })]
        public IQueryable<UserData> GetUsers([Service] latihanfinalContext context) =>
            context.Users.Select(p => new UserData()
            {
                Id = p.Id,
                FullName = p.FullName,
                Email = p.Email,
                Username = p.Username
            });
    }
}
