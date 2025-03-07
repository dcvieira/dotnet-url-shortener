namespace UrlShortener.Core.Urls.Add;

public interface IUrlDataStore
{
    Task AddAsync(ShortenedUrl shortedUrl, CancellationToken cancellationToken);
}

