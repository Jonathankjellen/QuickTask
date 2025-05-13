using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using QuickTask_Frontend.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7164/") });

builder.Services.AddScoped<TaskService>(); // Add this

await builder.Build().RunAsync();
