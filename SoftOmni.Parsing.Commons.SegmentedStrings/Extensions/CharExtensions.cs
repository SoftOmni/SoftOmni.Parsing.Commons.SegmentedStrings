namespace SoftOmni.Parsing.Commons.SegmentedStrings.Extensions;

public static class CharExtensions
{
    public static SegmentedString ToSegmentedString(this char c)
    {
        return new SegmentedString(c.ToString());
    }
}