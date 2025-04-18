using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BibliotecaAPITests.Utilidades
{
    public class UsuarioFalsoFiltro : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Antes de la acción
            context.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim("email", "ejemplo@hotmail.com")
            }, "prueba"));
            await next();

            // Después de la acción

        }
    }
}
