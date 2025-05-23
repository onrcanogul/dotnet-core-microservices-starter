using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shared.EF.Dto;
using Shared.EF.Entity;
using Shared.EF.Repositories;
using Shared.EF.Repositories.UnitOfWork;
using Shared.EF.Response;

namespace Shared.EF.Services;

public class CrudService<T, TDto, TContext>(IRepository<T, TContext> repository, IMapper mapper, IUnitOfWork<TContext> unitOfWork) //dependency injections
    : ICrudService<T, TDto, TContext> //implementations
    where T : BaseEntity where TDto : BaseDto where TContext : DbContext //constraints
{ 
    public async Task<ServiceResponse<List<TDto>>> GetListAsync(Expression<Func<T?, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IQueryable<T>>? includeProperties = null,
        bool disableTracking = true)
    {
        var list = await repository.GetListAsync(predicate, orderBy, includeProperties, disableTracking);
        var dto = mapper.Map<List<TDto>>(list);
        return ServiceResponse<List<TDto>>.Success(dto, StatusCodes.Status200OK);
    }
    public async Task<ServiceResponse<TDto>> GetFirstOrDefaultAsync(Expression<Func<T?, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IQueryable<T>>? includeProperties = null,
        bool disableTracking = true)
    {
        var entity = await repository.GetFirstOrDefaultAsync(predicate, orderBy, includeProperties, disableTracking);
        if(entity == null) throw new Exception(typeof(T) + "NotFound");
        var dto = mapper.Map<TDto>(entity);
        return ServiceResponse<TDto>.Success(dto, StatusCodes.Status200OK);
    }
    public async Task<ServiceResponse<List<TDto>>> GetPagedListAsync(int page, int size, Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IQueryable<T>>? includeProperties = null, bool disableTracking = true)
    {
        var list = await repository.GetPagedListAsync(page, size, predicate, orderBy, includeProperties, disableTracking);
        var dto = mapper.Map<List<TDto>>(list);
        return ServiceResponse<List<TDto>>.Success(dto, StatusCodes.Status200OK);
    }
    public async Task<ServiceResponse<TDto>> CreateAsync(TDto dto)
    {
        dto.Id = Guid.NewGuid();
        await repository.CreateAsync(mapper.Map<T>(dto));
        await unitOfWork.CommitAsync();
        return ServiceResponse<TDto>.Success(dto, StatusCodes.Status201Created);
    }
    public async Task<ServiceResponse<TDto>> UpdateAsync(TDto dto)
    {
        var entity = await repository.GetFirstOrDefaultAsync(x => x.Id == dto.Id);
        if (entity == null) throw new Exception(typeof(T) + "notFound");
        entity = mapper.Map(dto, entity);
        repository.Update(entity);
        await unitOfWork.CommitAsync();
        return ServiceResponse<TDto>.Success(dto, StatusCodes.Status200OK);
    }
    public async Task<ServiceResponse<NoContent>> DeleteAsync(Guid id)
    {
        var entity = await repository.GetFirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new Exception(typeof(T) + "notFound");
        repository.Delete(entity);
        await unitOfWork.CommitAsync();
        return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
    }
}