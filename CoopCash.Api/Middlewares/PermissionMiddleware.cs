namespace CoopCash.Api.Middlewares
{
    public class PermissionMiddleware
    {
        private readonly RequestDelegate _next;

        public PermissionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var permissions = context.User.Claims
                    .Where(c => c.Type == "Permission")
                    .Select(c => c.Value)
                    .ToList();

                // Exemplo: bloquear rota se não tiver "CanAccessX"
                if (context.Request.Path.StartsWithSegments("/api/protegido") &&
                    !permissions.Contains("CanAccessX"))
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Permissão negada");
                    return;
                }
            }

            await _next(context);
        }
    }

}
