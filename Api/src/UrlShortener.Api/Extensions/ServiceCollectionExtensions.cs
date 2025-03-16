using UrlShortener.Core;
using UrlShortener.Core.Urls;
using UrlShortener.Core.Urls.Add;

namespace UrlShortener.Api.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUrlFeature(this IServiceCollection services)
    {
        services.AddScoped<AddUrlHandler>();
        services.AddSingleton(_ =>
        {
            var tokenProvider = new TokenProvider();
            tokenProvider.AssignRange(new TokenRange(1, 1000));
            return tokenProvider;
        });

        services.AddScoped<ShortUrlGenerator>();

        services.AddSingleton<IUrlDataStore, InMemoryUrlDataStore>();
        return services;
    }

}

public class InMemoryUrlDataStore : Dictionary<string, ShortenedUrl>, IUrlDataStore
{
    public Task AddAsync(ShortenedUrl shortedUrl, CancellationToken cancellationToken)
    {
        Add(shortedUrl.ShortUrl, shortedUrl);
        return Task.CompletedTask;
    }
}
