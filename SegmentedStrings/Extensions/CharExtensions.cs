using SegmentedStrings;

namespace JavaScriptEngine.Core.ModularStrings.Extensions;

public static class CharExtensions
{
    public static SegmentedString ToSegmentedString(this char c)
    {
        return new SegmentedString(c.ToString());
    }
    
    public static string ToUnicodeNotation(this char c)
    {
        return "\\u" + ((int)c).ToString("X4");
    }
}