namespace UrlShortener.Core.Urls.Add;
public class AddUrlHandler
{
    private readonly ShortUrlGenerator _shortUrlGenerator;
    private readonly IUrlDataStore _urlDataStore;
    private readonly TimeProvider _timeProvider;

    public AddUrlHandler(ShortUrlGenerator shortUrlGenerator, IUrlDataStore urlDataStore, TimeProvider timeProvider)
    {
        _shortUrlGenerator = shortUrlGenerator;
        _urlDataStore = urlDataStore;
        _timeProvider = timeProvider;
    }

    public async Task<Result<AddUrlResponse>> HandleAsync(AddUrlRequest request, CancellationToken cancellationToken)
    {
        if(string.IsNullOrWhiteSpace(request.CreatedBy))
           return Errors.MissingCreatedBy;


        var shortedUrl = new ShortenedUrl(request.LongUrl,
            _shortUrlGenerator.GenerateShortUrl(),
            request.CreatedBy,
            _timeProvider.GetUtcNow());

        await _urlDataStore.AddAsync(shortedUrl, cancellationToken);
        return new AddUrlResponse(request.LongUrl, _shortUrlGenerator.GenerateShortUrl());
    }
}

