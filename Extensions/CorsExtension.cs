namespace Web_API_Webshop.Extensions
{
    public static class CorsExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins("https://jantesinferno.github.io",
                                            "https://jantesinferno.github.io/webbshop")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    });
            });
        }
    }
}
