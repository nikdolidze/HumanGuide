using System;

namespace HumanGuide.Core.Application.Hepler.Extenssion
{
    public static class ExtensionMethods
    {
        public static TOutput Use<TInput, TOutput>(this TInput o, Func<TInput, TOutput> selector) =>
           selector != null ? selector(o) : throw new ArgumentNullException(nameof(selector));
    }
}
