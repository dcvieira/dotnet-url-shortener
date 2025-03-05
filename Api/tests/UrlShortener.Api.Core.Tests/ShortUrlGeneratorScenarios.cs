using FluentAssertions;
using UrlShortener.Core;


namespace UrlShortener.Api.Core.Tests;
public class ShortUrlGeneratorScenarios
{
    // Test List
    // Check if the end of range is gt start
    // Unique tokens 
    // Accept multiple Ranges
    // Range as type

    [Fact]
    public void Should_return_short_url_for_zero()
    {
        var tokenProvider = new TokenProvider();
        tokenProvider.AssignRange(new TokenRange(0,10));
        var shortUrlGenerator = new ShortUrlGenerator(tokenProvider);
       
        var shortUrl = shortUrlGenerator.GenerateShortUrl();
        shortUrl.Should().Be("0");
    }

    [Fact]
    public void Should_return_short_url_for_10001()
    {
        var tokenProvider = new TokenProvider();
        tokenProvider.AssignRange(new TokenRange(10001, 20000));
        var shortUrlGenerator = new ShortUrlGenerator(tokenProvider);

        var shortUrl = shortUrlGenerator.GenerateShortUrl();
        shortUrl.Should().Be("2bJ");
    }
}
