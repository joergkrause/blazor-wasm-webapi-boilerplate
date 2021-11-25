using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Workshop.Blazor.Frontend.Client;
using Workshop.Blazor.Frontend.Client.ServiceProxy;
using Workshop.Blazor.Frontend.Client.Services;
using Workshop.Blazor.Frontend.Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<IClientService>(new ClientService(builder.HostEnvironment.BaseAddress, new HttpClient()));
builder.Services.AddSingleton<DataService>();
builder.Services.AddSingleton<StoreService>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

await builder.Build().RunAsync();
