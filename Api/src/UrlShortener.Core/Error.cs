using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Core;
public record Error(string Code, string Description)
{
    public static Error None => new Error(string.Empty, string.Empty);
    public static Error NotFound(string description) => new Error("NotFound", description);
    public static Error BadRequest(string description) => new Error("BadRequest", description);
    public static Error InternalServerError(string description) => new Error("InternalServerError", description);
}
