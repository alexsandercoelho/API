using Domain.Common;

namespace Domain.Services;

public interface IServiceBase<Dto>
{
    Task<Dto> Add(Dto dto);
    Task Update(Dto dto);
    Task Delete(Guid id);
    Task<Dto> GetById(Guid id);
    Task<IEnumerable<Dto>> GetAll();
    Task<IEnumerable<Dto>> GetAll(Pagination pagination);
}
