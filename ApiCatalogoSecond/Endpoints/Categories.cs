using ApiCatalogoSecond.Data;
using ApiCatalogoSecond.Domain.Entities;
using ApiCatalogoSecond.DTOs;
using ApiCatalogoSecond.Pagination;
using ApiCatalogoSecond.Repositories;
using ApiCatalogoSecond.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApiCatalogoSecond.Endpoints;

public static class Categories
{
    public static void CategoriesEndpoints(this WebApplication app)
    {
        app.MapGet("/categories", async (HttpContext context, PaginatedParameters<Category>? parameters, ICategoriesRepository repository, IMapper mapper) =>
        {
            var Categories = await repository.GetPaginated(parameters);

            var metadata = new
            {
                Categories.TotalPages,
                Categories.PageSize,
                Categories.TotalCount,
                Categories.CurrentPage,
                Categories.HasNext,
                Categories.HasPrevious,
            };

            context.Response.Headers.Add("X-PAGINATION", JsonConvert.SerializeObject(metadata));
            
            return mapper.Map<IEnumerable<CategoryDTO>>(Categories);
        }).WithTags("Categories");

        app.MapGet("/categories/{id:Guid}", async (Guid id, ICategoriesRepository repository, IMapper mapper) =>
        {
            Category? Category = await repository.Get(id);
            CategoryDTO categoryDTO = mapper.Map<CategoryDTO>(Category);
            return Results.Ok(categoryDTO);
        }).WithTags("Categories");

        app.MapPost("/categories", async (Category category, ICategoriesRepository repository, IMapper mapper) =>
        {
            var Category = await repository.Add(category);
            CategoryDTO categoryDTO = mapper.Map<CategoryDTO>(Category);

            return Results.Created($"/categories/{categoryDTO.Id}", categoryDTO);
        }).WithTags("Categories");

        app.MapPut("/categories/{id:Guid}", async (Guid id, Category category, ICategoriesRepository repository) =>
        {
            await repository.Update(id, category);

            return Results.NoContent();
        }).WithTags("Categories");

        app.MapDelete("/categories/{id:Guid}", async (Context context, Guid id, ICategoriesRepository repository) =>
        {
            repository.Delete(id);
            return Results.NoContent();
        }).WithTags("Categories");
    }
}
