using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TMA_Warehouse_WebUI;
using TMA_Warehouse_WebUI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7111/") });
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IRequestService, RequestService>();

await builder.Build().RunAsync();
