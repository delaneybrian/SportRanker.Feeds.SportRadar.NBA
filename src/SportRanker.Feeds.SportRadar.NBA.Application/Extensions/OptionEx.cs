using Optional;
using Optional.Unsafe;

namespace SportRanker.Feeds.SportRadar.NBA.Application.Extensions
{
    public static class OptionEx
    {
        public static bool TrySome<T>(this Option<T> maybeThing, out T realThing)
        {
            if (maybeThing.HasValue)
            {
                realThing = maybeThing.ValueOrDefault();
                return true;
            }

            realThing = default(T);
            return false;
        }
    }
}
