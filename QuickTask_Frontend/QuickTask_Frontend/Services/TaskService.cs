using QuickTask_Frontend.models;
using System.Net.Http.Json;

namespace QuickTask_Frontend.Services
{
    public class TaskService
    {
        private readonly HttpClient _http;
        private const string BaseUrl = "https://localhost:5001/api/tasks";

        public TaskService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TaskItem>?> GetTasksAsync() =>
            await _http.GetFromJsonAsync<List<TaskItem>>(BaseUrl);

        public async Task<TaskItem?> GetTaskAsync(int id) =>
            await _http.GetFromJsonAsync<TaskItem>($"{BaseUrl}/{id}");

        public async Task CreateTaskAsync(TaskItem task) =>
            await _http.PostAsJsonAsync(BaseUrl, task);

        public async Task UpdateTaskAsync(int id, TaskItem task) =>
            await _http.PutAsJsonAsync($"{BaseUrl}/{id}", task);

        public async Task DeleteTaskAsync(int id) =>
            await _http.DeleteAsync($"{BaseUrl}/{id}");
    }

}
