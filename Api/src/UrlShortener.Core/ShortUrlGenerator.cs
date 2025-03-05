namespace UrlShortener.Core;

public class ShortUrlGenerator
{
    private readonly TokenProvider _tokenProvider;

    public ShortUrlGenerator(TokenProvider tokenProvider)
    {
        _tokenProvider = tokenProvider;
    }
    public string GenerateShortUrl()
    {
        return _tokenProvider.GetToken().EncodeToBase62();
    }
}