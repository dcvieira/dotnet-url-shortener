using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core;

namespace UrlShortener.Api.Core.Tests;

public class TokenRangeScenarios
{
    [Fact]
    public void Should_throws_exception_when_start_greater_end()
    {
        Action action = () => new TokenRange(10, 0);
        action.Should()
            .Throw<ArgumentException>()
            .WithMessage("End must be greater than or equal to start");
    }
}

