namespace Shopping.Client.Extension
{
    public static class HttpExtension
    {
        public static void AddHttpExtension(this IServiceCollection services)
        {
            services.AddHttpClient("shoppingApiClient", Client =>
            {
                Client.BaseAddress = new Uri("http://localhost:5000");
            });
        }
    }
}
