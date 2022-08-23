using Blazor_Catalogo.Client.Auth;
using Catalago_Blazor.Client;
using Catalago_Blazor.Client.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//Depednências do pacote Nugget
builder.Services.AddAuthorizationCore();
//Depedência do arquivo de Autenticação de criamos
builder.Services.AddScoped<TokenAuthenticationProvider>();
builder.Services.AddScoped<IauthorizeService, TokenAuthenticationProvider>(
    provider => provider.GetRequiredService<TokenAuthenticationProvider>());
builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthenticationProvider>(
    provider => provider.GetRequiredService<TokenAuthenticationProvider>());



await builder.Build().RunAsync();
