namespace SoftOmni.Parsing.Commons.SegmentedStrings.Extensions;

/// <summary>
///     Provides extension methods for character and string conversion to <see cref="IStringBuilder"/> instances.
///     
///     <para>
///         This class contains utility methods that enable the direct conversion of characters and strings to 
///         <see cref="SegmentedString"/> objects, which implement the <see cref="IStringBuilder"/> interface.
///     </para>
///     <para>
///         These extension methods simplify the creation of <see cref="IStringBuilder"/> instances by allowing
///         the direct you to quickly turn a <langword>char</langword> or <langword>string</langword> into a 
///         <see cref="SegmentedString"/> instance, which can then be used as an <see cref="IStringBuilder"/>.
///     </para>
/// </summary>
public static class CharExtensions
{
    /// <summary>
    ///     Converts a character to a <see cref="SegmentedString"/> instance.
    ///     
    ///     <para>
    ///         This method creates a new <see cref="SegmentedString"/> instance containing the specified character.
    ///         It internally converts the character to a string before creating the <see cref="SegmentedString"/>.
    ///     </para>
    /// </summary>
    /// <param name="character">
    ///     The character to convert to a <see cref="SegmentedString"/>.
    ///     
    ///     <para>
    ///         This is the character that will be contained in the resulting <see cref="SegmentedString"/>.
    ///     </para>
    /// </param>
    /// <returns>
    ///     A new instance of <see cref="SegmentedString"/> containing the specified character.
    ///     
    ///     <para>
    ///         The returned <see cref="SegmentedString"/> will have a length of 1 and will contain only the
    ///         specified character.
    ///     </para>
    /// </returns>
    public static SegmentedString ToSegmentedString(this char character)
    {
        return new SegmentedString(character.ToString());
    }

    /// <summary>
    ///     Converts a string to a <see cref="SegmentedString"/> instance.
    ///     
    ///     <para>
    ///         This method creates a new <see cref="SegmentedString"/> instance containing the specified string.
    ///         The resulting <see cref="SegmentedString"/> will have the same content as the original string.
    ///     </para>
    /// </summary>
    /// <param name="string">
    ///     The string to convert to a <see cref="SegmentedString"/>.
    ///     
    ///     <para>
    ///         This is the string that will be contained in the resulting <see cref="SegmentedString"/>.
    ///         If the string is empty, an empty <see cref="SegmentedString"/> will be created.
    ///     </para>
    /// </param>
    /// <returns>
    ///     A new instance of <see cref="SegmentedString"/> containing the specified string.
    ///     
    ///     <para>
    ///         The returned <see cref="SegmentedString"/> will have the same length as the input string and will
    ///         contain all characters from the original string in the same order.
    ///     </para>
    /// </returns>
    public static SegmentedString ToSegmentedString(this string @string)
    {
        return new SegmentedString(@string);
    }
}