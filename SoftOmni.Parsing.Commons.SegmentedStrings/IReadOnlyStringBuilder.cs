using System.Runtime.Serialization;

namespace SoftOmni.Parsing.Commons.SegmentedStrings;

public interface IReadOnlyStringBuilder : IEnumerable<char>
{
    /// <summary>
    ///     Gets the maximum number of characters that can be contained
    ///     in the memory allocated by the current instance.
    /// </summary>
    /// <returns>
    ///     The maximum number of characters that can be contained in the memory
    ///     allocated by the current instance. Its value can range from <see cref="Length"/> to <see cref="MaxCapacity"/>.
    /// </returns>
    public int Capacity { get; }

    /// <summary>
    ///     Gets the character at the specified character position in this instance.
    /// </summary>
    /// <param name="index">
    ///     The position of the character.
    /// </param>
    /// <returns>
    ///     The Unicode character at position <paramref name="index"/>.
    /// </returns>
    /// <exception cref="IndexOutOfRangeException">
    ///     <paramref name="index"/> is outside the bounds of this instance while getting a character.
    /// </exception>
    public char this[int index] { get; }
    
    /// <summary>
    ///     Gets the length of the current <see cref="IReadOnlyStringBuilder"/> object.
    /// </summary>
    /// <returns>
    ///     The length of this instance.
    /// </returns>
    public int Length { get; }

    /// <summary>
    ///      Gets the maximum capacity of this instance.
    /// </summary>
    /// <returns>
    ///      The maximum number of characters this instance can hold.
    /// </returns>
    public int MaxCapacity { get; }
    
    /// <summary>
    ///     Populates a <see cref="SerializationInfo"/> object with the data
    ///     necessary to deserialize the current <see cref="IReadOnlyStringBuilder"/> object.
    /// </summary>
    /// <param name="info">
    ///     The object to populate with serialization information.
    /// </param>
    /// <param name="context">
    ///     The place to store and retrieve serialized data.
    ///     Reserved for future use.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="info"/> is null.
    /// </exception>
    /// <remarks>
    ///     The <paramref name="context"/> parameter is reserved for future use
    ///     and does not participate in this operation.
    /// </remarks>
    public void GetObjectData(SerializationInfo info, StreamingContext context);
    
    /// <summary>
    ///     Copies the characters from a specified segment of this instance to a destination <see cref="Char"/> span.
    /// </summary>
    /// <param name="sourceIndex">
    ///     The starting position in this instance when characters will be copied from. The index is zero-based.
    /// </param>
    /// <param name="destination">
    ///     The writable span where characters will be copied.
    /// </param>
    /// <param name="count">
    ///     The number of characters to be copied.
    /// </param>
    public void CopyTo(int sourceIndex, Span<char> destination, int count);

    /// <summary>
    ///     Copies the characters from a specified segment
    ///     of this instance to a specified segment of a destination <see cref="Char"/> array.
    /// </summary>
    /// <param name="sourceIndex">
    ///     The starting position in this instance when characters will be copied from. The index is zero-based.
    /// </param>
    /// <param name="destination">
    ///     The array where characters will be copied.
    /// </param>
    /// <param name="destinationIndex">
    ///     The starting position in <paramref name="destination"/> where characters will be copied.
    ///     The index is zero-based.
    /// </param>
    /// <param name="count">
    ///     The number of characters to be copied.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="destination"/> is null.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="sourceIndex"/>, <paramref name="destinationIndex"/>, or
    ///     <paramref name="count"/>, is less than zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="sourceIndex"/> is greater than the length of this instance.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="sourceIndex"/> + <paramref name="count"/> is greater than the length of this instance.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="destinationIndex"/> + <paramref name="count"/> is greater than the length of <paramref name="destination"/>.
    /// </exception>
    public void CopyTo(int sourceIndex, char[] destination,
        int destinationIndex, int count);
    
    /// <summary>
    ///     Returns a value indicating whether the characters in this instance are equal
    ///     to the characters in a specified read-only character span.
    /// </summary>
    /// <param name="span">
    ///     The character spans to compare with the current instance.
    /// </param>
    /// <returns>
    ///     true if the characters in this instance and <paramref name="span"/> are the same; otherwise, false.
    /// </returns>
    /// <remarks>
    ///     The <see cref="Equals(System.ReadOnlySpan{char})"/> method performs an ordinal comparison to determine whether the characters
    ///     in the current instance and <paramref name="span"/> are equal.
    /// </remarks>
    public bool Equals(ReadOnlySpan<char> span);

    /// <summary>
    ///     Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    /// <param name="sb">
    ///     An object to compare with this instance, or null.
    /// </param>
    /// <returns>
    ///     true if this instance and <paramref name="sb"/> have equal string,
    ///     <see cref="Capacity"/>, and <see cref="MaxCapacity"/> values; otherwise, false.
    /// </returns>
    /// <remarks>
    ///     The current instance and <paramref name="sb"/> are equal if the strings assigned to both
    ///     <see cref="IReadOnlyStringBuilder"/> objects are the same.
    ///     To determine equality, the <see cref="Equals(IReadOnlyStringBuilder)"/> method uses ordinal comparison.
    ///     The <see cref="Capacity"/> and <see cref="MaxCapacity"/> property values are not used in the comparison.
    /// </remarks>
    public bool Equals(IReadOnlyStringBuilder? sb);
    
    /// <summary>
    ///     Converts the value of this instance to a <see cref="String"/>.
    /// </summary>
    /// <returns>
    ///     A string whose value is the same as this instance.
    /// </returns>
    /// <remarks>
    ///     You must call the <see cref="ToString()"/> method to convert the <see cref="IReadOnlyStringBuilder"/> object
    ///     to a <see cref="String"/> object before you can pass the string represented by the <see cref="IReadOnlyStringBuilder"/>
    ///     object to a method that has a <see cref="String"/> parameter or display it in the user interface.
    /// </remarks>
    public string ToString();

    /// <summary>
    ///     Converts the value of a substring of this instance to a <see cref="String"/>.
    /// </summary>
    /// <param name="startIndex">
    ///     The starting position in the substring in this instance.
    /// </param>
    /// <param name="length">
    ///     The length of the substring.
    /// </param>
    /// <returns>
    ///     A string whose value is the same as the specified substring of this instance.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="startIndex"/> or <paramref name="length"/> is less than zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The sum of <paramref name="startIndex"/> and <paramref name="length"/> is greater
    ///     than the length of the current instance.
    /// </exception>
    /// <remarks>
    ///     You must call the <see cref="ToString(int, int)"/> method to convert the <see cref="IReadOnlyStringBuilder"/> object
    ///     to a <see cref="String"/> object before you can pass the string represented by the <see cref="IReadOnlyStringBuilder"/>
    ///     object to a method that has a <see cref="String"/> parameter or display it in the user interface.
    /// </remarks>
    public string ToString(int startIndex, int length);
}