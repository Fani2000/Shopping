namespace Shopping.Client.Extension
{
    public static class HttpExtension
    {
        public static void AddHttpExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("shoppingApiClient", Client =>
            {
                var url = configuration.GetValue<string>("ShoppingAPIUrl");
                Client.BaseAddress = new Uri(url);
            });
        }
    }
}
