using Microsoft.JSInterop;

namespace Catalago_Blazor.Client.Utils
{
    public static class IJSRuntimeExtensions
    {
        //escrever local storage
        public static ValueTask<object> SetInLocalStorage(this IJSRuntime js, string key, string content) => js.InvokeAsync<object>("localStorage.setItem", key, content);

        //obter informação do storage
        public static ValueTask<string> GetFromLocalStorage(this IJSRuntime js, string key) => js.InvokeAsync<string>("localStorage.getItem", key);

        //remover item de local storage
        public static ValueTask<object> RemoveItem(this IJSRuntime js, string key) => js.InvokeAsync<object>("localStorage.removeItem", key);
    }
}
