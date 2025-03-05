namespace UrlShortener.Core;

public class TokenProvider
{
    private TokenRange? _tokenRange;


    public void AssignRange(TokenRange tokenRange)
    {
        _tokenRange = tokenRange;
    }

    public long GetToken()
    {
        return _tokenRange.Start;
    }
}
