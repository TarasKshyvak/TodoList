using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class TodoService : ITodoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TodoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TodoModel> AddAsync(TodoModel model)
        {
            ArgumentNullException.ThrowIfNull(nameof(model));
            model.IsArchived = false;
            model.IsDone = false;
            var entity = _mapper.Map<Todo>(model);
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            await _context.Entry(entity).GetDatabaseValuesAsync();
            return _mapper.Map<TodoModel>(entity);
        }

        public async Task<IEnumerable<TodoModel>> GetActualAsync()
        {
            var entities = await _context.Todos.Where(t => !t.IsArchived).ToListAsync();
            return _mapper.Map<IEnumerable<TodoModel>>(entities);
        }

        public async Task<IEnumerable<TodoModel>> GetArchivedAsync()
        {
            var entities = await _context.Todos.Where(t => t.IsArchived).ToListAsync();
            return _mapper.Map<IEnumerable<TodoModel>>(entities);
        }

        public async Task SetArchivedAsync(Guid id)
        {
            var entity = await _context.Todos.FindAsync(id);
            ArgumentNullException.ThrowIfNull(nameof(entity));
            entity!.IsArchived = true;
            await _context.SaveChangesAsync();
        }

        public async Task SetDoneAsync(Guid id)
        {
            var entity = await _context.Todos.FindAsync(id);
            ArgumentNullException.ThrowIfNull(nameof(entity));
            entity!.IsDone = true;
            await _context.SaveChangesAsync();
        }
        public async Task SetUndoneAsync(Guid id)
        {
            var entity = await _context.Todos.FindAsync(id);
            ArgumentNullException.ThrowIfNull(nameof(entity));
            entity!.IsDone = false;
            await _context.SaveChangesAsync();
        }
    }
}
