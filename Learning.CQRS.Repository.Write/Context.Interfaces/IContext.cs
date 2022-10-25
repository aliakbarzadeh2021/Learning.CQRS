using System;
using System.Threading.Tasks;

namespace Learning.CQRS.Repository.Write.Context.Interfaces
{
    public interface IContext : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
