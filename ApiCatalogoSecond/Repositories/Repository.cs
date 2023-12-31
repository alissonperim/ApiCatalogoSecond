﻿using ApiCatalogoSecond.Data;
using ApiCatalogoSecond.Domain.Entities;
using ApiCatalogoSecond.Pagination;
using ApiCatalogoSecond.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoSecond.Repositories;

public class Repository<T> : IRepository<T> where T : Base
{
    private readonly Context _context;

    public Repository(Context context)
    {
        _context = context;
    }

    public async Task<T> Add(T entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async void Delete(Guid id)
    {
        var entity = await Get(id);

        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<T> Get(Guid id)
    {
        try
        {
            return await _context.Set<T>()
                     .Where(i => i.Id == id)
                     .SingleOrDefaultAsync();
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }
    }

    public IQueryable<T> Get()
    {
        return _context.Set<T>().AsQueryable<T>();
    }

    public Task<ActionResult> Update(Guid id, T entity)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedList<T>> GetPaginated(PaginatedParameters<T> parameters)
    {
        return await PagedList<T>.ToPagedList(Get().OrderBy(o => o.CreatedAt), parameters.PageNumber, parameters.PageSize);
    }
}
