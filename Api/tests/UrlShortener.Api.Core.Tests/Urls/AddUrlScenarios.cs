using FluentAssertions;
using Microsoft.Extensions.Time.Testing;
using System;
using UrlShortener.Api.Core.Tests.TestDoubles;
using UrlShortener.Core;
using UrlShortener.Core.Urls;
using UrlShortener.Core.Urls.Add;

namespace UrlShortener.Api.Core.Tests.Urls;
public class AddUrlScenarios
{
    private readonly AddUrlHandler _addUrlHandler;
    private readonly InMemoryUrlDataStore _urlDataStore;
    private readonly FakeTimeProvider _timeProvider;

    public AddUrlScenarios()
    {
        _urlDataStore = new InMemoryUrlDataStore();
        var tokenProvider = new TokenProvider();
        tokenProvider.AssignRange(new TokenRange(1, 5));
        var shortUrlGenerator = new ShortUrlGenerator(tokenProvider);
        _timeProvider = new FakeTimeProvider();
        _addUrlHandler = new AddUrlHandler(shortUrlGenerator, _urlDataStore, _timeProvider);
    }

    [Fact]
    public async Task Should_return_short_url()
    {
        var request = CreateAddUrlRequest();
        var response = await _addUrlHandler.HandleAsync(request, default);

        response.Value!.ShortUrl.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task Should_save_short_url()
    {
        var request = CreateAddUrlRequest();
        var response = await _addUrlHandler.HandleAsync(request, default);

        _urlDataStore.Should().ContainKey(response.Value!.ShortUrl);
    }

    [Fact]
    public async Task Should_save_short_url_with_created_by_and_created_on()
    {
        var request = CreateAddUrlRequest();
        var response = await _addUrlHandler.HandleAsync(request, default);

        response.Succeeded.Should().BeTrue();
        _urlDataStore.Should().ContainKey(response.Value!.ShortUrl);
        _urlDataStore[response.Value.ShortUrl].CreatedBy.Should().Be(request.CreatedBy);
        _urlDataStore[response.Value.ShortUrl].CreatedOn.Should().Be(_timeProvider.GetUtcNow());
    }

    [Fact]
    public async Task Should_return_error_if_created_by_is_empty()
    {
        var request = CreateAddUrlRequest() with { CreatedBy = string.Empty };
        var response = await _addUrlHandler.HandleAsync(request, default);

        response.Succeeded.Should().BeFalse();
        response.Error.Code.Should().Be("missing_value");

    }

    private static AddUrlRequest CreateAddUrlRequest()
    {
        return new AddUrlRequest(new Uri("https://google.com"), "user@user.com");
    }
}
