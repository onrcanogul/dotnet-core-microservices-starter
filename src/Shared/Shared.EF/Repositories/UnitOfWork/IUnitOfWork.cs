using Microsoft.EntityFrameworkCore;

namespace Shared.EF.Repositories.UnitOfWork;

public interface IUnitOfWork<TContext> where TContext : DbContext
{
    void Commit();
    Task CommitAsync();
}