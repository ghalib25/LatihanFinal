using HotChocolate.AspNetCore.Authorization;
using Models;

namespace ProductService.GraphQL
{
    public class Query
    {
        [Authorize]
        public IQueryable<Product> GetProducts([Service] latihanfinalContext context) =>
            context.Products;

        public async Task<Product> GetProductByIdAsync(
            int id,
            [Service] latihanfinalContext context)
        {
            var product = context.Products.Where(o => o.Id == id).FirstOrDefault();

            return await Task.FromResult(product);
        }

    }
}
