namespace Web_API_Webshop.Extensions
{
    public static class CookieExtension
    {
        public static void ConfigureCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.HttpOnly = true;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                opt.Cookie.SameSite = SameSiteMode.None;
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                opt.SlidingExpiration = true;
                opt.Events.OnRedirectToAccessDenied = context =>
                {
                    context.Response.StatusCode = (int)403;
                    return Task.CompletedTask;
                };
                opt.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = (int)401;
                    return Task.CompletedTask;
                };
            });
        }
    }
}
