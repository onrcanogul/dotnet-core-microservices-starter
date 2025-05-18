using Microsoft.EntityFrameworkCore;

namespace Shared.EF.Repositories.UnitOfWork;

public class UnitOfWork<T>(T context) : IUnitOfWork<T> where T : DbContext
{
    public void Commit()
    {
        context.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }
}