using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shared.EF.Dto;
using Shared.EF.Entity;
using Shared.EF.Response;

namespace Shared.EF.Services;

public interface ICrudService<T, TDto, TContext>
    where T : BaseEntity where TDto : BaseDto where TContext : DbContext
{
    Task<ServiceResponse<List<TDto>>> GetListAsync(Expression<Func<T?, bool>>? predicate = null, 
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IQueryable<T>>? includeProperties = null,
        bool disableTracking = true);
    Task<ServiceResponse<TDto>> GetFirstOrDefaultAsync(Expression<Func<T, bool>>? predicate = null, 
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IQueryable<T>>? includeProperties = null,
        bool disableTracking = true);
    Task<ServiceResponse<List<TDto>>> GetPagedListAsync(int page, int size,Expression<Func<T, bool>>? predicate = null, 
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IQueryable<T>>? includeProperties = null,
        bool disableTracking = true);
    Task<ServiceResponse<TDto>> CreateAsync(TDto dto);
    Task<ServiceResponse<TDto>> UpdateAsync(TDto dto);
    Task<ServiceResponse<NoContent>> DeleteAsync(Guid id);
}