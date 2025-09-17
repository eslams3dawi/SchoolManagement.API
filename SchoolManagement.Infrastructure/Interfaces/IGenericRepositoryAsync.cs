using Microsoft.EntityFrameworkCore.Storage;

namespace SchoolManagement.Infrastructure.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task DeleteRangeAsync(ICollection<T> entities);
        Task<T> GetByIdAsync(int id);
        Task SaveChangesAsync();
        IDbContextTransaction BeginTransaction(); //To begin a transaction for edit, if any fails rollback
        void Commit();
        void RollBack();
        IQueryable<T> GetTableNoTracking(); //To get all data of table without tracking, GetAll
        IQueryable<T> GetTableAsTracking(); //To get with tracking, Edit, Delete & Create
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task SoftDeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
    }
}
