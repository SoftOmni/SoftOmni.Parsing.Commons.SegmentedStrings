namespace SoftOmni.Parsing.Commons.SegmentedStrings.Extensions;

public static class CharExtensions
{
    public static SegmentedString ToSegmentedString(this char c)
    public static SegmentedString ToSegmentedString(this char character)
    {
        return new SegmentedString(c.ToString());
        return new SegmentedString(character.ToString());
    }
    public static SegmentedString ToSegmentedString(this string @string)
    {
        return new SegmentedString(@string);
    }
}