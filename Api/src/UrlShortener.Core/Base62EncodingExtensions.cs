﻿namespace UrlShortener.Core;

public static class Base62EncodingExtensions
{
    private const string Base62Characters = "0123456789" +
                                             "ABCDEFGHIJKLMNOPQRSTUVWXYZ"+ 
                                              "abcdefghijklmnopqrstuvwxyz";
    public static string EncodeToBase62(this long number)
    {
        if (number == 0)
        {
            return "0";
        }

        var result = new Stack<char>();
        while (number > 0)
        {
            result.Push(Base62Characters[(int)number % 62]);
            number /= 62;
        }

        return new string(result.ToArray());
    }
}