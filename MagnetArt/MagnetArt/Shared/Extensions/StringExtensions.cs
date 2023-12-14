using System.Reflection.Metadata.Ecma335;

namespace MagnetArt.Shared.Extensions
{
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string text)
        {
            static IEnumerable<char> Convert(CharEnumerator e)
            {
                if (!e.MoveNext()) yield break;
                yield return char.ToUpper(e.Current);
                while (e.MoveNext())
                {
                    if (char.IsUpper(e.Current))
                    {
                        yield return '_';
                        yield return char.ToLower(e.Current);
                    }
                    else
                    {
                        yield return e.Current;
                    }
                }
            }
            return new string(Convert(text.GetEnumerator()).ToArray());
        }
    }
}
