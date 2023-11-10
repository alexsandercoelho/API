namespace Services.Base
{
    public interface IServiceBase<T>
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task RegisterAsync(T record);
        Task UpdateAsync(T record);
        Task RemoveAsync(int id);
    }
}
