using BLL.Models;

namespace BLL.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoModel>> GetActualAsync();
        Task<IEnumerable<TodoModel>> GetArchivedAsync();
        Task<TodoModel> AddAsync(TodoModel model);
        Task SetDoneAsync(Guid id);
        Task SetUndoneAsync(Guid id);
        Task SetArchivedAsync(Guid id);
    }
}
