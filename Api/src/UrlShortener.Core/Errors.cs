using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Core;
public class Errors
{
    public static Error MissingCreatedBy => new Error("missing_value", "Created by is required");
}

