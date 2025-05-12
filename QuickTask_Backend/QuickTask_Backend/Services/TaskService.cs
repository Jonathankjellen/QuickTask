using QuickTask_Backend.Data;
using QuickTask_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace QuickTask_Backend.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;
        public TaskService(AppDbContext context) => _context = context;

        public async Task<IEnumerable<TaskItem>> GetAllAsync(string? status)
        {
            var query = _context.TaskItems.AsQueryable();
            if(status == "completed") query = query.Where(t => t.IsCompleted);
            if(status == "pending") query = query.Where(t => !t.IsCompleted);
            return await query.ToListAsync();
        }
        public async Task<TaskItem?> GetByIdAsync(int id) =>
            await _context.TaskItems.FindAsync(id);

        public async Task<TaskItem> CreateAsync(TaskItem task)
        {
            task.CreatedAt = DateTime.UtcNow;
            _context.TaskItems.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> UpdateAsync(int id, TaskItem updatedTask)
        {
            var existing = await _context.TaskItems.FindAsync(id);
            if(existing is null) return false;

            existing.Title = updatedTask.Title;
            existing.Description = updatedTask.Description;
            existing.DueDate = updatedTask.DueDate;
            existing.IsCompleted = updatedTask.IsCompleted;
            existing.LastUpdatedAt = updatedTask.LastUpdatedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);
            if (task is null) return false;

            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
