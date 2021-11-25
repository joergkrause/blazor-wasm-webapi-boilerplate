using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Workshop.Blazor.Frontend.Client;
using Workshop.Blazor.Frontend.Client.ServiceProxy;
using Workshop.Blazor.Frontend.Client.Services;
using Workshop.Blazor.Frontend.Store.Persistence;
using Workshop.Blazor.Frontend.Store.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
// data from host
builder.Services.AddSingleton<IClientService>(new ClientService(builder.HostEnvironment.BaseAddress, new HttpClient()));
// abstraction from infrastructure
builder.Services.AddSingleton<DataService>();
// optionally store the store (e.g. local storage)
builder.Services.AddSingleton<IPersistanceService, PersistanceService>();
// Flux based store
builder.Services.AddSingleton<StoreService>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

await builder.Build().RunAsync();
