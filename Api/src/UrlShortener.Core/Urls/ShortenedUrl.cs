

namespace UrlShortener.Core.Urls;
public  record ShortenedUrl(Uri LongUrl, string ShortUrl, string CreatedBy, DateTimeOffset CreatedOn);
