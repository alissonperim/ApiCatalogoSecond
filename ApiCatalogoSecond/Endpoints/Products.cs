﻿using ApiCatalogoSecond.Data;
using ApiCatalogoSecond.Domain.Entities;
using ApiCatalogoSecond.DTOs;
using ApiCatalogoSecond.Pagination;
using ApiCatalogoSecond.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Abstractions;
using Microsoft.AspNetCore.Http.Headers;
using Newtonsoft.Json;

namespace ApiCatalogoSecond.Endpoints;

public static class Products
{
    public static void ProductsEndpoints(this WebApplication app)
    {
        app.MapGet("/products", async (PaginatedParameters<Product>? parameters, HttpContext context, IProductsRepository repository, IMapper mapper) =>
        {
            var Products = await repository.GetPaginated(parameters);

            var metadata = new
            {
                Products.TotalCount,
                Products.PageSize,
                Products.CurrentPage,
                Products.TotalPages,
                Products.HasNext,
                Products.HasPrevious
            };

            context.Response.Headers.Add("X-PAGINATION", JsonConvert.SerializeObject(metadata));

            return mapper.Map<IEnumerable<ProductDTO>>(Products);
        }).WithTags("Products");

        app.MapGet("/products/{id:Guid}", async (Context context, Guid id, IMapper mapper) =>
        {
            Product? Product = await context.Products.FirstOrDefaultAsync(c => c.Id == id);

            return Results.Ok(mapper.Map<ProductDTO>(Product));
        }).WithTags("Products");

        app.MapPost("/products", async (Context context, Product product) =>
        {
            var Product = await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return Results.Created($"/products/{product.Id}", Product.Entity);
        }).WithTags("Products");

        app.MapPut("/products/{id:Guid}", async (Context context, Guid id, Product product) =>
        {
            if (id != product.Id)
            {
                return Results.BadRequest();
            }
            context.Entry(product).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return Results.NoContent();
        }).WithTags("Products");

        app.MapDelete("/products/{id:Guid}", async (Context context, Guid id) =>
        {
            Product? Product = await context.Products.FirstOrDefaultAsync(c => c.Id == id);
            if (Product == null)
            {
                return Results.NotFound();
            }

            context.Entry(Product).State = EntityState.Deleted;
            await context.SaveChangesAsync();

            return Results.NoContent();
        }).WithTags("Products");
    }
}
