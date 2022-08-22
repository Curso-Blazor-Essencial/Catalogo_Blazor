using Catalago_Blazor.Client;
using Catalago_Blazor.Client.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//Depedn�ncias do pacote Nugget
builder.Services.AddAuthorizationCore();
//Deped�ncia do arquivo de Autentica��o de criamos
builder.Services.AddScoped<AuthenticationStateProvider, DemoAuthStateProvider>();


await builder.Build().RunAsync();
