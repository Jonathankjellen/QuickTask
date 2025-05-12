using QuickTask_Backend.Models;

namespace QuickTask_Backend.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAllAsync(string? status);
        Task<TaskItem?> GetByIdAsync(int id);
        Task<TaskItem> CreateAsync(TaskItem task);
        Task<bool> UpdateAsync(int id, TaskItem updatedTask);
        Task<bool> DeleteAsync(int id);
    }
}
