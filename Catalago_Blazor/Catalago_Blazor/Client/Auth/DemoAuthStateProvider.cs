

using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Catalago_Blazor.Client.Auth
{
    public class DemoAuthStateProvider : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Delay(4000);
            //idicamos se o usuátio está autenticando e também seus claims
            // definição de identidade anônima
            var usuario = new ClaimsIdentity(new List<Claim>()
            {
                new Claim("Chave", "Valor"),
                new Claim(ClaimTypes.Name,"LNC") },
                //new Claim(ClaimTypes.Role,"Admin")}, 
                "demo");


            // entrando na aplicação como usuário anônimo
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(usuario)));
        }
    }
}

