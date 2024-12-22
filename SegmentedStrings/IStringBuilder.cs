using System.Runtime.Serialization;
using System.Text;

namespace SegmentedStrings;

/// <summary>
///     This interface represents a mutable string of characters.
///     It contains the same members as <see cref="IStringBuilder"/> with a few exceptions
///     but is not a class and can be implemented by any type.
/// </summary>
public interface IStringBuilder : IEnumerable<char>
{
    /// <summary>
    ///     Gets or sets the maximum number of characters that can be contained
    ///     in the memory allocated by the current instance.
    /// </summary>
    /// <param name="value">
    ///     The maximum number of characters that can be contained in the memory
    ///     allocated by the current instance. Its value can range from <see cref="Length"/> to <see cref="MaxCapacity"/>.
    /// </param>
    /// <returns>
    ///     The maximum number of characters that can be contained in the memory
    ///     allocated by the current instance. Its value can range from <see cref="Length"/> to <see cref="MaxCapacity"/>.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The value specified for a set operation is greater than the maximum capacity.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The value specified for a set operation is less than the current length of this instance.
    /// </exception>
    public int Capacity { get; set; }

    /// <summary>
    ///     Gets or sets the character at the specified character position in this instance.
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
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is outside the bounds of this instance while setting a character.
    /// </exception>
    public char this[int index] { get; set; }

    /// <summary>
    ///     Gets or sets the length of the current <see cref="IStringBuilder"/> object.
    /// </summary>
    /// <param name="value">
    ///     The length of this instance.
    /// </param>
    /// <returns>
    ///     The length of this instance.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The value specified for a set operation is less than zero or greater than <see cref="MaxCapacity"/>.
    /// </exception>
    public int Length { get; set; }

    /// <summary>
    ///      Gets the maximum capacity of this instance.
    /// </summary>
    /// <returns>
    ///      The maximum number of characters this instance can hold.
    /// </returns>
    public int MaxCapacity { get; }

    /// <summary>
    ///     Populates a <see cref="SerializationInfo"/> object with the data
    ///     necessary to deserialize the current <see cref="IStringBuilder"/> object.
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
    ///     Appends the string representation of a specified string builder to this instance.
    /// </summary>
    /// <param name="value">
    ///     The string builder to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation is completed.
    /// </returns>
    public IStringBuilder Append(IStringBuilder? value);

    /// <summary>
    ///     Appends the string representation of a specified 16-bit unsigned integer to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after this append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    [CLSCompliant(false)]
    public IStringBuilder Append(ushort value);

    /// <summary>
    ///     Appends the string representation of a specified 32-bit unsigned integer to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after this append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    [CLSCompliant(false)]
    public IStringBuilder Append(uint value);

    /// <summary>
    ///     Appends the string representation of a specified 64-bit unsigned integer to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after this append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    [CLSCompliant(false)]
    public IStringBuilder Append(ulong value);

    /// <summary>
    ///     Appends a specified number of copies of the string representation of a Unicode character to this instance.
    /// </summary>
    /// <param name="value">
    ///     The character to append.
    /// </param>
    /// <param name="repeatCount">
    ///     The number of times to append <paramref name="value"/>.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="repeatCount"/> is less than zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <exception cref="OutOfMemoryException">
    ///     Out of memory.
    /// </exception>
    public IStringBuilder Append(char value, int repeatCount);

    /// <summary>
    ///     Appends the string representation of a specified subarray of Unicode characters to this instance.
    /// </summary>
    /// <param name="value">
    ///     A character array.
    /// </param>
    /// <param name="startIndex">
    ///     The starting position in <see cref="value"/>.
    /// </param>
    /// <param name="charCount">
    ///     The number of characters to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="value"/> is null, and <paramref name="startIndex"/>
    ///     and <paramref name="charCount"/> are not zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="charCount"/> is less than zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="startIndex"/> is less than zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="startIndex"/> + <paramref name="charCount"/>
    ///     is greater than the length of the <paramref name="value"/>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Append(char[]? value, int startIndex, int charCount);

    /// <summary>
    ///     Appends the specified interpolated string to this instance using the specified format.
    /// </summary>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="handler">
    ///     The interpolated string to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    public IStringBuilder Append(IFormatProvider? provider,
        ref StringBuilder.AppendInterpolatedStringHandler handler);

    /// <summary>
    ///     Appends a copy of the specified string to this instance.
    /// </summary>
    /// <param name="value">
    ///     The string to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Append(string? value);

    /// <summary>
    ///     Appends a copy of a specified substring to this instance.
    /// </summary>
    /// <param name="value">
    ///     The string that contains the substring to append.
    /// </param>
    /// <param name="startIndex">
    ///     The starting position of the substring within <paramref name="value"/>.
    /// </param>
    /// <param name="count">
    ///     The number of characters in <paramref name="value"/> to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="value"/> is null, and <paramref name="startIndex"/>
    ///     and <paramref name="count"/> are not zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="count"/> is less than zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="startIndex"/> is less than zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="startIndex"/> + <paramref name="count"/>
    ///     is greater than the length of the <paramref name="value"/>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Append(string? value, int startIndex, int count);

    /// <summary>
    ///     Appends a copy of a substring within a specified string builder to this instance.
    /// </summary>
    /// <param name="value">
    ///     The string builder that contains the substring to append.
    /// </param>
    /// <param name="startIndex">
    ///     The starting position of the substring within <paramref name="value"/>.
    /// </param>
    /// <param name="count">
    ///     The number of characters in <paramref name="value"/> to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    public IStringBuilder Append(IStringBuilder? value, int startIndex,
        int count);

    /// <summary>
    ///     Appends the string representation of a specified single-precision floating-point number to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Append(float value);

    /// <summary>
    ///     Appends the specified interpolated string to this instance.
    /// </summary>
    /// <param name="handler">
    ///     The interpolated string to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    public IStringBuilder Append(
        ref StringBuilder.AppendInterpolatedStringHandler handler);

    /// <summary>
    ///     Appends the string representation of a specified read-only
    ///     character span to this instance.
    /// </summary>
    /// <param name="value">
    ///     The read-only character span to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation is completed.
    /// </returns>
    public IStringBuilder Append(ReadOnlySpan<char> value);

    /// <summary>
    ///     Appends the string representation of a specified 8-bit signed integer to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    [CLSCompliant(false)]
    public IStringBuilder Append(sbyte value);

    /// <summary>
    ///     Appends the string representation of a specified Boolean value to this instance.
    /// </summary>
    /// <param name="value">
    ///     The boolean value to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Append(bool value);

    /// <summary>
    ///     Appends the string representation of a specified 8-bit unsigned integer to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Append(byte value);

    /// <summary>
    ///     Appends the string representation of a specified <see cref="Char"/> object to this instance.
    /// </summary>
    /// <param name="value">
    ///     The UTF-16-encoded code unit to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Append(char value);

    /// <summary>
    ///     Appends the string representation of the Unicode characters in a specified array to this instance.
    /// </summary>
    /// <param name="value">
    ///     The array of characters to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Append(char[]? value);

    /// <summary>
    ///     Appends the string representation of a specified double-precision
    ///     floating-point number to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Append(double value);

    /// <summary>
    ///     Appends the string representation of a specified decimal number to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Append(decimal value);

    /// <summary>
    ///     Appends the string representation of a specified 32-bit signed integer to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Append(int value);

    /// <summary>
    ///     Appends the string representation of a specified 64-bit signed integer to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Append(long value);

    /// <summary>
    ///     Appends the string representation of a specified object to this instance.
    /// </summary>
    /// <param name="value">
    ///     The object to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Append(object? value);

    /// <summary>
    ///     Appends the string representation of a specified read-only character memory region to this instance.
    /// </summary>
    /// <param name="value">
    ///     The read-only character memory region to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation is completed.
    /// </returns>
    public IStringBuilder Append(ReadOnlyMemory<char> value);

    /// <summary>
    ///     Appends the string representation of a specified 16-bit signed integer to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Append(short value);

    /// <summary>
    ///     Prepends the string representation of a specified string builder to this instance.
    /// </summary>
    /// <param name="value">
    ///     The string builder to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation is completed.
    /// </returns>
    public IStringBuilder Prepend(IStringBuilder? value);

    /// <summary>
    ///     Prepends the string representation of a specified 16-bit unsigned integer to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after this prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    [CLSCompliant(false)]
    public IStringBuilder Prepend(ushort value);

    /// <summary>
    ///     Prepends the string representation of a specified 32-bit unsigned integer to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after this prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    [CLSCompliant(false)]
    public IStringBuilder Prepend(uint value);

    /// <summary>
    ///     Prepends the string representation of a specified 64-bit unsigned integer to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after this prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    [CLSCompliant(false)]
    public IStringBuilder Prepend(ulong value);

    /// <summary>
    ///     Prepends a specified number of copies of the string representation of a Unicode character to this instance.
    /// </summary>
    /// <param name="value">
    ///     The character to prepend.
    /// </param>
    /// <param name="repeatCount">
    ///     The number of times to prepend <paramref name="value"/>.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="repeatCount"/> is less than zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <exception cref="OutOfMemoryException">
    ///     Out of memory.
    /// </exception>
    public IStringBuilder Prepend(char value, int repeatCount);

    /// <summary>
    ///     Prepends the string representation of a specified subarray of Unicode characters to this instance.
    /// </summary>
    /// <param name="value">
    ///     A character array.
    /// </param>
    /// <param name="startIndex">
    ///     The starting position in <see cref="value"/>.
    /// </param>
    /// <param name="charCount">
    ///     The number of characters to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="value"/> is null, and <paramref name="startIndex"/>
    ///     and <paramref name="charCount"/> are not zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="charCount"/> is less than zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="startIndex"/> is less than zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="startIndex"/> + <paramref name="charCount"/>
    ///     is greater than the length of the <paramref name="value"/>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Prepend(char[]? value, int startIndex, int charCount);

    /// <summary>
    ///     Prepends the specified interpolated string to this instance using the specified format.
    /// </summary>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="handler">
    ///     The interpolated string to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    public IStringBuilder Prepend(IFormatProvider? provider,
        ref StringBuilder.AppendInterpolatedStringHandler handler);

    /// <summary>
    ///     Prepends a copy of the specified string to this instance.
    /// </summary>
    /// <param name="value">
    ///     The string to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Prepend(string? value);

    /// <summary>
    ///     Prepends a copy of a specified substring to this instance.
    /// </summary>
    /// <param name="value">
    ///     The string that contains the substring to prepend.
    /// </param>
    /// <param name="startIndex">
    ///     The starting position of the substring within <paramref name="value"/>.
    /// </param>
    /// <param name="count">
    ///     The number of characters in <paramref name="value"/> to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="value"/> is null, and <paramref name="startIndex"/>
    ///     and <paramref name="count"/> are not zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="count"/> is less than zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="startIndex"/> is less than zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="startIndex"/> + <paramref name="count"/>
    ///     is greater than the length of the <paramref name="value"/>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Prepend(string? value, int startIndex, int count);

    /// <summary>
    ///     Prepends a copy of a substring within a specified string builder to this instance.
    /// </summary>
    /// <param name="value">
    ///     The string builder that contains the substring to prepend.
    /// </param>
    /// <param name="startIndex">
    ///     The starting position of the substring within <paramref name="value"/>.
    /// </param>
    /// <param name="count">
    ///     The number of characters in <paramref name="value"/> to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    public IStringBuilder Prepend(IStringBuilder? value, int startIndex,
        int count);

    /// <summary>
    ///     Prepends the string representation of a specified single-precision floating-point number to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Prepend(float value);

    /// <summary>
    ///     Prepends the specified interpolated string to this instance.
    /// </summary>
    /// <param name="handler">
    ///     The interpolated string to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    public IStringBuilder Prepend(
        ref StringBuilder.AppendInterpolatedStringHandler handler);

    /// <summary>
    ///     Prepends the string representation of a specified read-only
    ///     character span to this instance.
    /// </summary>
    /// <param name="value">
    ///     The read-only character span to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation is completed.
    /// </returns>
    public IStringBuilder Prepend(ReadOnlySpan<char> value);

    /// <summary>
    ///     Prepends the string representation of a specified 8-bit signed integer to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    [CLSCompliant(false)]
    public IStringBuilder Prepend(sbyte value);

    /// <summary>
    ///     Prepends the string representation of a specified Boolean value to this instance.
    /// </summary>
    /// <param name="value">
    ///     The boolean value to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Prepend(bool value);

    /// <summary>
    ///     Prepends the string representation of a specified 8-bit unsigned integer to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Prepend(byte value);

    /// <summary>
    ///     Prepends the string representation of a specified <see cref="Char"/> object to this instance.
    /// </summary>
    /// <param name="value">
    ///     The UTF-16-encoded code unit to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Prepend(char value);

    /// <summary>
    ///     Prepends the string representation of the Unicode characters in a specified array to this instance.
    /// </summary>
    /// <param name="value">
    ///     The array of characters to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Prepend(char[]? value);

    /// <summary>
    ///     Prepends the string representation of a specified double-precision
    ///     floating-point number to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Prepend(double value);

    /// <summary>
    ///     Prepends the string representation of a specified decimal number to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Prepend(decimal value);

    /// <summary>
    ///     Prepends the string representation of a specified 32-bit signed integer to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Prepend(int value);

    /// <summary>
    ///     Prepends the string representation of a specified 64-bit signed integer to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Prepend(long value);

    /// <summary>
    ///     Prepends the string representation of a specified object to this instance.
    /// </summary>
    /// <param name="value">
    ///     The object to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Prepend(object? value);

    /// <summary>
    ///     Prepends the string representation of a specified read-only character memory region to this instance.
    /// </summary>
    /// <param name="value">
    ///     The read-only character memory region to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation is completed.
    /// </returns>
    public IStringBuilder Prepend(ReadOnlyMemory<char> value);

    /// <summary>
    ///     Prepends the string representation of a specified 16-bit signed integer to this instance.
    /// </summary>
    /// <param name="value">
    ///     The value to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder Prepend(short value);

    /// <summary>
    ///     Appends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of either of two arguments.
    /// </summary>
    /// <param name="format">
    ///     A composite format string.
    /// </param>
    /// <param name="arg0">
    ///     The first object to format.
    /// </param>
    /// <param name="arg1">
    ///     The second object to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance with <paramref name="format"/> appended.
    ///     Each format item in <paramref name="format"/> is replaced by the string representation
    ///     of the corresponding object argument.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     <paramref name="format"/> is invalid.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is less than 0 (zero), or greater than or equal to 2.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The length of the expanded string would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder AppendFormat(string format, object? arg0,
        object? arg1);

    /// <summary>
    ///     Appends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of either of
    ///     three arguments using a specified format provider.
    /// </summary>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="format">
    ///     A composite format string.
    /// </param>
    /// <param name="arg0">
    ///     The first object to format.
    /// </param>
    /// <param name="arg1">
    ///     The second object to format.
    /// </param>
    /// <param name="arg2">
    ///     The third object to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    ///     After the append operation, this instance contains any data that existed before the operation,
    ///     suffixed by a copy of <paramref name="format"/> where any format specification is
    ///     replaced by the string representation of the corresponding object argument.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     <paramref name="format"/> is invalid.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is less than 0 (zero), or greater than or equal to 3 (three).
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The length of the expanded string would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder AppendFormat(IFormatProvider? provider, string format,
        object? arg0, object? arg1,
        object? arg2);

    /// <summary>
    ///     Appends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of either of
    ///     three arguments.
    /// </summary>
    /// <param name="format">
    ///     A composite format string.
    /// </param>
    /// <param name="arg0">
    ///     The first object to format.
    /// </param>
    /// <param name="arg1">
    ///     The second object to format.
    /// </param>
    /// <param name="arg2">
    ///     The third object to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance with <paramref name="format"/> appended.
    ///     Each format item in <paramref name="format"/> is replaced by the string representation
    ///     of the corresponding object argument.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     <paramref name="format"/> is invalid.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is less than 0 (zero), or greater than or equal to 3.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The length of the expanded string would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder AppendFormat(string format, object? arg0,
        object? arg1,
        object? arg2);

    /// <summary>
    ///     Appends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of either of two arguments
    ///     using a specified format provider.
    /// </summary>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="format">
    ///     A composite format string.
    /// </param>
    /// <param name="arg0">
    ///     The first object to format.
    /// </param>
    /// <param name="arg1">
    ///     The second object to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    ///     After the append operation, this instance contains any data that existed before the operation,
    ///     suffixed by a copy of <paramref name="format"/> where any format specification is replaced
    ///     by the string representation of the corresponding object argument.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     <paramref name="format"/> is invalid.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is less than 0 (zero), or greater than or equal to 2 (two).
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The length of the expanded string would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder AppendFormat(IFormatProvider? provider, string format,
        object? arg0, object? arg1);

    /// <summary>
    ///     Appends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation
    ///     of any of the arguments using a specified format provider.
    /// </summary>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="format">
    ///     A <see cref="CompositeFormat"/>.
    /// </param>
    /// <param name="args">
    ///     A span of objects to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item greater than or equal to the number of supplied arguments.
    /// </exception>
    public IStringBuilder AppendFormat(IFormatProvider? provider,
        CompositeFormat format, ReadOnlySpan<object?> args);

    /// <summary>
    ///     Appends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of a single argument.
    /// </summary>
    /// <param name="format">
    ///     A composite format string.
    /// </param>
    /// <param name="arg0">
    ///     An object to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance with <paramref name="format"/> appended. Each format item in
    ///     <paramref name="format"/> is replace by the string representation of <paramref name="arg0"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     <paramref name="format"/> is invalid.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is different from 0 (zero).
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The length of the expanded string would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder AppendFormat(string format, object? arg0);

    /// <summary>
    ///     Appends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of a corresponding argument
    ///     in a parameter array using a specified format provider.
    /// </summary>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="format">
    ///     A composite format string.
    /// </param>
    /// <param name="args">
    ///     An array of objects to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    ///     After the append operation, this instance contains any data that existed before the operation,
    ///     suffixed by a copy of <paramref name="format"/> where any format specification is replaced
    ///     by the string representation of the corresponding object argument.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     <paramref name="format"/> is invalid.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is less than 0 (zero),
    ///     or greater than or equal to the length of the <paramref name="args"/> array.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The length of the expanded string would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder AppendFormat(IFormatProvider? provider, string format,
        params object?[] args);

    /// <summary>
    ///     Appends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of a single argument
    ///     using a specified format provider.
    /// </summary>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="format">
    ///     A composite format string.
    /// </param>
    /// <param name="arg0">
    ///     The object to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    ///     After the append operation, this instance contains any data that existed before the operation,
    ///     suffixed by a copy of <paramref name="format"/> in which any format specification is replaced by
    ///     the string representation of <paramref name="arg0"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     <paramref name="format"/> is invalid.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is different from 0.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The length of the expanded string would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder AppendFormat(IFormatProvider? provider, string format,
        object? arg0);

    /// <summary>
    ///     Appends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of a corresponding argument in a parameter array.
    /// </summary>
    /// <param name="format">
    ///     A composite format string.
    /// </param>
    /// <param name="args">
    ///     An array of objects to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance with <paramref name="format"/> appended.
    ///     Each format item in <paramref name="format"/>
    ///     is replaced bu the string representation of the corresponding object argument.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> or <paramref name="args"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     <paramref name="format"/> is invalid.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is less than 0 (zero),
    ///     or greater than or equal to the length of the <paramref name="args"/> array,
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The length of the expanded string would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder AppendFormat(string format, params object?[] args);

    /// <summary>
    ///     Appends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation
    ///     of any of the arguments using a specified format provider.
    /// </summary>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="format">
    ///     A <see cref="CompositeFormat"/>.
    /// </param>
    /// <param name="args">
    ///     An array of objects to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> or <paramref name="args"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is greater than or equal to the number of supplied arguments.
    /// </exception>
    public IStringBuilder AppendFormat(IFormatProvider? provider,
        CompositeFormat format, params object?[] args);

    /// <summary>
    ///     Appends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of any of the arguments
    ///     using a specified format specifier.
    /// </summary>
    /// <typeparam name="TArg0">
    ///     The type of the first object to format.
    /// </typeparam>
    /// <typeparam name="TArg1">
    ///     The type of the second object to format.
    /// </typeparam>
    /// <typeparam name="TArg2">
    ///     The type of the third object to format.
    /// </typeparam>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="format">
    ///     A <see cref="CompositeFormat"/>.
    /// </param>
    /// <param name="arg0">
    ///     The first object to format.
    /// </param>
    /// <param name="arg1">
    ///     The second object to format.
    /// </param>
    /// <param name="arg2">
    ///     The third object to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is greater than or equal to the number of supplied arguments.
    /// </exception>
    public IStringBuilder AppendFormat<TArg0, TArg1, TArg2>(
        IFormatProvider? provider, CompositeFormat format,
        TArg0 arg0, TArg1 arg1, TArg2 arg2);

    /// <summary>
    ///     Appends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of any of the arguments
    ///     using a specified format specifier.
    /// </summary>
    /// <typeparam name="TArg0">
    ///     The type of the first object to format.
    /// </typeparam>
    /// <typeparam name="TArg1">
    ///     The type of the second object to format.
    /// </typeparam>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="format">
    ///     A <see cref="CompositeFormat"/>.
    /// </param>
    /// <param name="arg0">
    ///     The first object to format.
    /// </param>
    /// <param name="arg1">
    ///     The second object to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is greater than or equal to the number of supplied arguments.
    /// </exception>
    public IStringBuilder AppendFormat<TArg0, TArg1>(IFormatProvider? provider,
        CompositeFormat format,
        TArg0 arg0, TArg1 arg1);

    /// <summary>
    ///     Appends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of any of the arguments
    ///     using a specified format specifier.
    /// </summary>
    /// <typeparam name="TArg0">
    ///     The type of the first object to format.
    /// </typeparam>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="format">
    ///     A <see cref="CompositeFormat"/>.
    /// </param>
    /// <param name="arg0">
    ///     The first object to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is greater than or equal to the number of supplied arguments.
    /// </exception>
    public IStringBuilder AppendFormat<TArg0>(IFormatProvider? provider,
        CompositeFormat format,
        TArg0 arg0);

    /// <summary>
    ///     Prepends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of either of two arguments.
    /// </summary>
    /// <param name="format">
    ///     A composite format string.
    /// </param>
    /// <param name="arg0">
    ///     The first object to format.
    /// </param>
    /// <param name="arg1">
    ///     The second object to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance with <paramref name="format"/> prepended.
    ///     Each format item in <paramref name="format"/> is replaced by the string representation
    ///     of the corresponding object argument.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     <paramref name="format"/> is invalid.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is less than 0 (zero), or greater than or equal to 2.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The length of the expanded string would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder PrependFormat(string format, object? arg0,
        object? arg1);

    /// <summary>
    ///     Prepends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of either of
    ///     three arguments using a specified format provider.
    /// </summary>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="format">
    ///     A composite format string.
    /// </param>
    /// <param name="arg0">
    ///     The first object to format.
    /// </param>
    /// <param name="arg1">
    ///     The second object to format.
    /// </param>
    /// <param name="arg2">
    ///     The third object to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    ///     After the prepend operation, this instance contains any data that existed before the operation,
    ///     prefixed by a copy of <paramref name="format"/> where any format specification is
    ///     replaced by the string representation of the corresponding object argument.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     <paramref name="format"/> is invalid.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is less than 0 (zero), or greater than or equal to 3 (three).
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The length of the expanded string would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder PrependFormat(IFormatProvider? provider,
        string format,
        object? arg0, object? arg1,
        object? arg2);

    /// <summary>
    ///     Prepends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of either of
    ///     three arguments.
    /// </summary>
    /// <param name="format">
    ///     A composite format string.
    /// </param>
    /// <param name="arg0">
    ///     The first object to format.
    /// </param>
    /// <param name="arg1">
    ///     The second object to format.
    /// </param>
    /// <param name="arg2">
    ///     The third object to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance with <paramref name="format"/> prepended.
    ///     Each format item in <paramref name="format"/> is replaced by the string representation
    ///     of the corresponding object argument.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     <paramref name="format"/> is invalid.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is less than 0 (zero), or greater than or equal to 3.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The length of the expanded string would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder PrependFormat(string format, object? arg0,
        object? arg1,
        object? arg2);

    /// <summary>
    ///     Prepends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of either of two arguments
    ///     using a specified format provider.
    /// </summary>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="format">
    ///     A composite format string.
    /// </param>
    /// <param name="arg0">
    ///     The first object to format.
    /// </param>
    /// <param name="arg1">
    ///     The second object to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    ///     After the prepend operation, this instance contains any data that existed before the operation,
    ///     prefixed by a copy of <paramref name="format"/> where any format specification is replaced
    ///     by the string representation of the corresponding object argument.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     <paramref name="format"/> is invalid.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is less than 0 (zero), or greater than or equal to 2 (two).
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The length of the expanded string would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder PrependFormat(IFormatProvider? provider,
        string format,
        object? arg0, object? arg1);

    /// <summary>
    ///     Prepends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation
    ///     of any of the arguments using a specified format provider.
    /// </summary>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="format">
    ///     A <see cref="CompositeFormat"/>.
    /// </param>
    /// <param name="args">
    ///     A span of objects to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item greater than or equal to the number of supplied arguments.
    /// </exception>
    public IStringBuilder PrependFormat(IFormatProvider? provider,
        CompositeFormat format, ReadOnlySpan<object?> args);

    /// <summary>
    ///     Prepends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of a single argument.
    /// </summary>
    /// <param name="format">
    ///     A composite format string.
    /// </param>
    /// <param name="arg0">
    ///     An object to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance with <paramref name="format"/> prepended. Each format item in
    ///     <paramref name="format"/> is replace by the string representation of <paramref name="arg0"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     <paramref name="format"/> is invalid.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is different from 0 (zero).
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The length of the expanded string would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder PrependFormat(string format, object? arg0);

    /// <summary>
    ///     Prepends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of a corresponding argument
    ///     in a parameter array using a specified format provider.
    /// </summary>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="format">
    ///     A composite format string.
    /// </param>
    /// <param name="args">
    ///     An array of objects to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    ///     After the prepend operation, this instance contains any data that existed before the operation,
    ///     prefixed by a copy of <paramref name="format"/> where any format specification is replaced
    ///     by the string representation of the corresponding object argument.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     <paramref name="format"/> is invalid.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is less than 0 (zero),
    ///     or greater than or equal to the length of the <paramref name="args"/> array.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The length of the expanded string would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder PrependFormat(IFormatProvider? provider,
        string format,
        params object?[] args);

    /// <summary>
    ///     Prepends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of a single argument
    ///     using a specified format provider.
    /// </summary>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="format">
    ///     A composite format string.
    /// </param>
    /// <param name="arg0">
    ///     The object to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    ///     After the prepend operation, this instance contains any data that existed before the operation,
    ///     prefixed by a copy of <paramref name="format"/> in which any format specification is replaced by
    ///     the string representation of <paramref name="arg0"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     <paramref name="format"/> is invalid.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is different from 0.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The length of the expanded string would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder PrependFormat(IFormatProvider? provider,
        string format,
        object? arg0);

    /// <summary>
    ///     Prepends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of a corresponding argument in a parameter array.
    /// </summary>
    /// <param name="format">
    ///     A composite format string.
    /// </param>
    /// <param name="args">
    ///     An array of objects to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance with <paramref name="format"/> prepended.
    ///     Each format item in <paramref name="format"/>
    ///     is replaced bu the string representation of the corresponding object argument.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> or <paramref name="args"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     <paramref name="format"/> is invalid.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is less than 0 (zero),
    ///     or greater than or equal to the length of the <paramref name="args"/> array,
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The length of the expanded string would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public IStringBuilder PrependFormat(string format, params object?[] args);

    /// <summary>
    ///     Prepends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation
    ///     of any of the arguments using a specified format provider.
    /// </summary>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="format">
    ///     A <see cref="CompositeFormat"/>.
    /// </param>
    /// <param name="args">
    ///     An array of objects to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> or <paramref name="args"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is greater than or equal to the number of supplied arguments.
    /// </exception>
    public IStringBuilder PrependFormat(IFormatProvider? provider,
        CompositeFormat format, params object?[] args);

    /// <summary>
    ///     Prepends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of any of the arguments
    ///     using a specified format specifier.
    /// </summary>
    /// <typeparam name="TArg0">
    ///     The type of the first object to format.
    /// </typeparam>
    /// <typeparam name="TArg1">
    ///     The type of the second object to format.
    /// </typeparam>
    /// <typeparam name="TArg2">
    ///     The type of the third object to format.
    /// </typeparam>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="format">
    ///     A <see cref="CompositeFormat"/>.
    /// </param>
    /// <param name="arg0">
    ///     The first object to format.
    /// </param>
    /// <param name="arg1">
    ///     The second object to format.
    /// </param>
    /// <param name="arg2">
    ///     The third object to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is greater than or equal to the number of supplied arguments.
    /// </exception>
    public IStringBuilder PrependFormat<TArg0, TArg1, TArg2>(
        IFormatProvider? provider, CompositeFormat format,
        TArg0 arg0, TArg1 arg1, TArg2 arg2);

    /// <summary>
    ///     Prepends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of any of the arguments
    ///     using a specified format specifier.
    /// </summary>
    /// <typeparam name="TArg0">
    ///     The type of the first object to format.
    /// </typeparam>
    /// <typeparam name="TArg1">
    ///     The type of the second object to format.
    /// </typeparam>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="format">
    ///     A <see cref="CompositeFormat"/>.
    /// </param>
    /// <param name="arg0">
    ///     The first object to format.
    /// </param>
    /// <param name="arg1">
    ///     The second object to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is greater than or equal to the number of supplied arguments.
    /// </exception>
    public IStringBuilder PrependFormat<TArg0, TArg1>(IFormatProvider? provider,
        CompositeFormat format,
        TArg0 arg0, TArg1 arg1);

    /// <summary>
    ///     Prepends the string returned by processing a composite format string,
    ///     which contains zero or more format items, to this instance.
    ///     Each format item is replaced by the string representation of any of the arguments
    ///     using a specified format specifier.
    /// </summary>
    /// <typeparam name="TArg0">
    ///     The type of the first object to format.
    /// </typeparam>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="format">
    ///     A <see cref="CompositeFormat"/>.
    /// </param>
    /// <param name="arg0">
    ///     The first object to format.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="format"/> is null.
    /// </exception>
    /// <exception cref="FormatException">
    ///     The index of a format item is greater than or equal to the number of supplied arguments.
    /// </exception>
    public IStringBuilder PrependFormat<TArg0>(IFormatProvider? provider,
        CompositeFormat format,
        TArg0 arg0);

    /// <summary>
    ///     Concatenates the strings of the provided array, using the specified separator between
    ///     each string, then appends the result to the current instance of the string builder.
    /// </summary>
    /// <param name="separator">
    ///     The string to use as a separator. <paramref name="separator"/> is included in the joined strings
    ///     only if <paramref name="values"/> has more than one element.
    /// </param>
    /// <param name="values">
    ///     An array that contains the strings to concatenate and append to the current instance of the string builder.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    public IStringBuilder
        AppendJoin(string? separator, params string?[] values);

    /// <summary>
    ///     Concatenates the strings of the provided array of objects, using the specified separator between
    ///     each string, then appends the result to the current instance of the string builder.
    /// </summary>
    /// <param name="separator">
    ///     The string to use as a separator. <paramref name="separator"/> is included in the joined strings
    ///     only if <paramref name="values"/> has more than one element.
    /// </param>
    /// <param name="values">
    ///     An array that contains the strings to concatenate and append to the current instance of the string builder.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    public IStringBuilder
        AppendJoin(string? separator, params object?[] values);

    /// <summary>
    ///     Concatenates the strings of the provided array of objects, using the specified char separator between
    ///     each string, then appends the result to the current instance of the string builder.
    /// </summary>
    /// <param name="separator">
    ///     The character to use as a separator. <paramref name="separator"/> is included in the joined strings
    ///     only if <paramref name="values"/> has more than one element.
    /// </param>
    /// <param name="values">
    ///     An array that contains the strings to concatenate and append to the current instance of the string builder.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    public IStringBuilder AppendJoin(char separator, params object?[] values);

    /// <summary>
    ///     Concatenates the strings of the provided array, using the specified char separator between
    ///     each string, then appends the result to the current instance of the string builder.
    /// </summary>
    /// <param name="separator">
    ///     The character to use as a separator. <paramref name="separator"/> is included in the joined strings
    ///     only if <paramref name="values"/> has more than one element.
    /// </param>
    /// <param name="values">
    ///     An array that contains the strings to concatenate and append to the current instance of the string builder.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    public IStringBuilder AppendJoin(char separator, params string?[] values);

    /// <summary>
    ///     Concatenates and appends the members of a collection, using the specified char separator between each member.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the members of <paramref name="values"/>.
    /// </typeparam>
    /// <param name="separator">
    ///     The character to use as a separator. <paramref name="separator"/> is included in the joined strings
    ///     only if <paramref name="values"/> has more than one element.
    /// </param>
    /// <param name="values">
    ///     A collection that contains the objects to concatenate and append to the current instance of the string builder.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    public IStringBuilder AppendJoin<T>(char separator, IEnumerable<T> values);

    /// <summary>
    ///     Concatenates and appends the members of a collection, using the specified separator between each member.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the members of <paramref name="values"/>.
    /// </typeparam>
    /// <param name="separator">
    ///     The string to use as a separator. <paramref name="separator"/> is included in the joined strings
    ///     only if <paramref name="values"/> has more than one element.
    /// </param>
    /// <param name="values">
    ///     A collection that contains the objects to concatenate and append to the current instance of the string builder.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    public IStringBuilder AppendJoin<T>(string? separator,
        IEnumerable<T> values);

    /// <summary>
    ///     Concatenates the strings of the provided array, using the specified separator between
    ///     each string, then prepends the result to the current instance of the string builder.
    /// </summary>
    /// <param name="separator">
    ///     The string to use as a separator. <paramref name="separator"/> is included in the joined strings
    ///     only if <paramref name="values"/> has more than one element.
    /// </param>
    /// <param name="values">
    ///     An array that contains the strings to concatenate and prepend to the current instance of the string builder.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    public IStringBuilder PrependJoin(string? separator,
        params string?[] values);

    /// <summary>
    ///     Concatenates the strings of the provided array of objects, using the specified separator between
    ///     each string, then prepends the result to the current instance of the string builder.
    /// </summary>
    /// <param name="separator">
    ///     The string to use as a separator. <paramref name="separator"/> is included in the joined strings
    ///     only if <paramref name="values"/> has more than one element.
    /// </param>
    /// <param name="values">
    ///     An array that contains the strings to concatenate and prepend to the current instance of the string builder.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    public IStringBuilder
        PrependJoin(string? separator, params object?[] values);

    /// <summary>
    ///     Concatenates the strings of the provided array of objects, using the specified char separator between
    ///     each string, then prepends the result to the current instance of the string builder.
    /// </summary>
    /// <param name="separator">
    ///     The character to use as a separator. <paramref name="separator"/> is included in the joined strings
    ///     only if <paramref name="values"/> has more than one element.
    /// </param>
    /// <param name="values">
    ///     An array that contains the strings to concatenate and prepend to the current instance of the string builder.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    public IStringBuilder PrependJoin(char separator, params object?[] values);

    /// <summary>
    ///     Concatenates the strings of the provided array, using the specified char separator between
    ///     each string, then prepends the result to the current instance of the string builder.
    /// </summary>
    /// <param name="separator">
    ///     The character to use as a separator. <paramref name="separator"/> is included in the joined strings
    ///     only if <paramref name="values"/> has more than one element.
    /// </param>
    /// <param name="values">
    ///     An array that contains the strings to concatenate and prepend to the current instance of the string builder.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    public IStringBuilder PrependJoin(char separator, params string?[] values);

    /// <summary>
    ///     Concatenates and prepends the members of a collection, using the specified char separator between each member.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the members of <paramref name="values"/>.
    /// </typeparam>
    /// <param name="separator">
    ///     The character to use as a separator. <paramref name="separator"/> is included in the joined strings
    ///     only if <paramref name="values"/> has more than one element.
    /// </param>
    /// <param name="values">
    ///     A collection that contains the objects to concatenate and prepend to the current instance of the string builder.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    public IStringBuilder PrependJoin<T>(char separator, IEnumerable<T> values);

    /// <summary>
    ///     Concatenates and prepends the members of a collection, using the specified separator between each member.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the members of <paramref name="values"/>.
    /// </typeparam>
    /// <param name="separator">
    ///     The string to use as a separator. <paramref name="separator"/> is included in the joined strings
    ///     only if <paramref name="values"/> has more than one element.
    /// </param>
    /// <param name="values">
    ///     A collection that contains the objects to concatenate and prepend to the current instance of the string builder.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    public IStringBuilder PrependJoin<T>(string? separator,
        IEnumerable<T> values);

    /// <summary>
    ///     Appends the default line terminator to the end of the current <see cref="IStringBuilder"/> object.
    /// </summary>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     The default line terminator is the current value of the <see cref="Environment.NewLine"/> property.
    ///     The capacity of this instance is adjusted as needed.
    /// </remarks>
    public IStringBuilder AppendLine();

    /// <summary>
    ///     Appends a copy of the specified string followed by
    ///     the default line terminator to the end of the current <see cref="IStringBuilder"/> object.
    /// </summary>
    /// <param name="value">
    ///     The string to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     The default line terminator is the current value of the <see cref="Environment.NewLine"/> property.
    ///     The capacity of this instance is adjusted as needed.
    /// </remarks>
    public IStringBuilder AppendLine(string? value);

    /// <summary>
    ///     Appends the specified interpolated string followed by
    ///     the default line terminator to the end of the current <see cref="IStringBuilder"/> object.
    /// </summary>
    /// <param name="handler">
    ///     The interpolated string to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    public IStringBuilder AppendLine(
        ref StringBuilder.AppendInterpolatedStringHandler handler);

    /// <summary>
    ///     Appends the specified interpolated string using the specified format, followed by
    ///     the default line terminator to the end of the current <see cref="IStringBuilder"/> object.
    /// </summary>
    /// <param name="provider">
    ///     An object that supplies culture-specific formatting information.
    /// </param>
    /// <param name="handler">
    ///     The interpolated string to append.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the append operation has completed.
    /// </returns>
    public IStringBuilder AppendLine(IFormatProvider? provider,
        ref StringBuilder.AppendInterpolatedStringHandler handler);

    /// <summary>
    ///     Prepends the default line terminator to the end of the current <see cref="IStringBuilder"/> object.
    /// </summary>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     The default line terminator is the current value of the <see cref="Environment.NewLine"/> property.
    ///     The capacity of this instance is adjusted as needed.
    /// </remarks>
    public IStringBuilder PrependLine();

    /// <summary>
    ///     Prepends a copy of the specified string followed by
    ///     the default line terminator to the end of the current <see cref="IStringBuilder"/> object.
    /// </summary>
    /// <param name="value">
    ///     The string to prepend.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the prepend operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     The default line terminator is the current value of the <see cref="Environment.NewLine"/> property.
    ///     The capacity of this instance is adjusted as needed.
    /// </remarks>
    public IStringBuilder PrependLine(string? value);
    
    /// <summary>
    ///     Removes all characters from the current <see cref="IStringBuilder"/> instance.
    /// </summary>
    /// <returns>
    ///     An object whose <see cref="Length"/> is 0 (zero).
    /// </returns>
    public IStringBuilder Clear();

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
    ///     Ensures that the capacity of <see cref="IStringBuilder"/> is at least the specified value.
    /// </summary>
    /// <param name="capacity">
    ///     The minimum capacity to ensure.
    /// </param>
    /// <returns>
    ///     The new capacity of this instance.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="capacity"/> is less than zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    public int EnsureCapacity(int capacity);

    /// <summary>
    ///     Returns a value indicating whether the characters in this instance are equal
    ///     to the characters in a specified read-only character span.
    /// </summary>
    /// <param name="span">
    ///     The character span to compare with the current instance.
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
    ///     <see cref="IStringBuilder"/> objects are the same.
    ///     To determine equality, the <see cref="Equals(IStringBuilder)"/> method uses ordinal comparison.
    ///     The <see cref="Capacity"/> and <see cref="MaxCapacity"/> property values are not used in the comparison.
    /// </remarks>
    public bool Equals(IStringBuilder? sb);

    /// <summary>
    ///     Returns an object that can be used to iterate through the chunks of characters in a
    ///     <see cref="ReadOnlyMemory{Char}"/> created from this <see cref="IStringBuilder"/> instance.
    /// </summary>
    /// <returns>
    ///     An enumerator for the chunks in the <see cref="ReadOnlyMemory{Char}"/>.
    /// </returns>
    public StringBuilder.ChunkEnumerator GetChunks();

    /// <summary>
    ///     Inserts a string into this instance at the specified character position.
    /// </summary>
    /// <param name="index">
    ///     The position in this instance where insertion begins.
    /// </param>
    /// <param name="value">
    ///     The string to insert.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the insert operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is less than zero or greater than the current length of this instance.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The current length of this <see cref="IStringBuilder"/> object plus the length of <paramref name="value"/>
    ///     exceeds <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     Existing characters are shifted to make room for the new text. The capacity is adjusted as needed.
    ///     This instance of <see cref="IStringBuilder"/> is not changed if <paramref name="value"/> is null, or
    ///     <paramref name="value"/> is not null but its length is zero.
    /// </remarks>
    public IStringBuilder Insert(int index, string? value);

    /// <summary>
    ///     Inserts the string representation of a single-precision floating-point number into this instance
    ///     at the specified character position.
    /// </summary>
    /// <param name="index">
    ///     The position in this instance where insertion begins.
    /// </param>
    /// <param name="value">
    ///     The value to insert.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the insert operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is less than zero or greater than the length of this instance.
    /// </exception>
    /// <exception cref="OutOfMemoryException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     <see cref="float.ToString()"/> is used to get a string representation of <paramref name="value"/>.
    ///     Existing characters are shifted to make room for the new text.
    ///     The capacity of this instance is adjusted as needed.
    /// </remarks>
    public IStringBuilder Insert(int index, float value);

    /// <summary>
    ///     Inserts the string representation of a 16-bit unsigned integer into this instance at the specified
    ///     character position.
    /// </summary>
    /// <param name="index">
    ///     The position in this instance where insertion begins.
    /// </param>
    /// <param name="value">
    ///     The value to insert.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the insert operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is less than zero or greater than the length of this instance.
    /// </exception>
    /// <exception cref="OutOfMemoryException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     <see cref="ushort.ToString()"/> is used to get a string representation of <paramref name="value"/>.
    ///     Existing characters are shifted to make room for the new text.
    ///     The capacity of this instance is adjusted as needed.
    /// </remarks>
    [CLSCompliant(false)]
    public IStringBuilder Insert(int index, ushort value);

    /// <summary>
    ///     Inserts the string representation of a 16-bit signed integer into this instance at the specified
    ///     character position.
    /// </summary>
    /// <param name="index">
    ///     The position in this instance where insertion begins.
    /// </param>
    /// <param name="value">
    ///     The value to insert.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the insert operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is less than zero or greater than the length of this instance.
    /// </exception>
    /// <exception cref="OutOfMemoryException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     <see cref="short.ToString()"/> is used to get a string representation of <paramref name="value"/>.
    ///     Existing characters are shifted to make room for the new text.
    ///     The capacity of this instance is adjusted as needed.
    /// </remarks>
    public IStringBuilder Insert(int index, short value);

    /// <summary>
    ///     Inserts the string representation of a 64-bit unsigned integer into this instance at the specified
    ///     character position.
    /// </summary>
    /// <param name="index">
    ///     The position in this instance where insertion begins.
    /// </param>
    /// <param name="value">
    ///     The value to insert.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the insert operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is less than zero or greater than the length of this instance.
    /// </exception>
    /// <exception cref="OutOfMemoryException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     <see cref="ulong.ToString()"/> is used to get a string representation of <paramref name="value"/>.
    ///     Existing characters are shifted to make room for the new text.
    ///     The capacity of this instance is adjusted as needed.
    /// </remarks>
    [CLSCompliant(false)]
    public IStringBuilder Insert(int index, ulong value);

    /// <summary>
    ///     Inserts one or more copies of a specified string into this instance at the specified character position.
    /// </summary>
    /// <param name="index">
    ///     The position in this instance where insertion begins.
    /// </param>
    /// <param name="value">
    ///     The string to insert.
    /// </param>
    /// <param name="count">
    ///     The number of times to insert <paramref name="value"/>.
    /// </param>
    /// <returns>
    ///     A reference to this instance after insertion has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is less than zero or greater than the current length of this instance.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="count"/> is less than zero.
    /// </exception>
    /// <exception cref="OutOfMemoryException">
    ///     The current length of this <see cref="IStringBuilder"/> object plus the length of <paramref name="value"/>
    ///     times <paramref name="count"/> exceeds <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     Existing characters are shifted to make room for the new text.
    ///     The capacity of this instance is adjusted as needed.
    ///     This <see cref="IStringBuilder"/> object is not changed if <paramref name="value"/> is null,
    ///     <paramref name="value"/> is not null but its length is zero or <paramref name="count"/> is zero.
    /// </remarks>
    public IStringBuilder Insert(int index, string? value, int count);

    /// <summary>
    ///     Inserts the string representation of a specified subarray of Unicode characters into this instance
    ///     at the specified character position.
    /// </summary>
    /// <param name="index">
    ///     The position in this instance where insertion begins.
    /// </param>
    /// <param name="value">
    ///     A character array.
    /// </param>
    /// <param name="startIndex">
    ///     The starting index within <paramref name="value"/>.
    /// </param>
    /// <param name="charCount">
    ///     The number of characters to insert.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the insert operation has completed.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="value"/> is null, and <paramref name="startIndex"/> and <paramref name="charCount"/>
    ///     are not zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/>, <paramref name="startIndex"/> or <paramref name="charCount"/> is less than zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is greater than the length of this instance.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="startIndex"/> plus <paramref name="charCount"/> is not a position within <paramref name="value"/>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     Existing characters are shifted to make room for the new text.
    ///     The capacity of this instance is adjusted as needed.
    /// </remarks>
    public IStringBuilder Insert(int index, char[]? value, int startIndex,
        int charCount);

    /// <summary>
    ///     Inserts the string representation of a specified 8-bit signed integer into this instance at the specified
    ///     character position.
    /// </summary>
    /// <param name="index">
    ///     The position in this instance where insertion begins.
    /// </param>
    /// <param name="value">
    ///     The value to insert.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the insert operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is less than zero or greater than the length of this instance.
    /// </exception>
    /// <exception cref="OutOfMemoryException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     <see cref="sbyte.ToString()"/> is used to get a string representation of <paramref name="value"/>.
    ///     Existing characters are shifted to make room for the new text.
    ///     The capacity of this instance is adjusted as needed.
    /// </remarks>
    [CLSCompliant(false)]
    public IStringBuilder Insert(int index, sbyte value);

    /// <summary>
    ///     Inserts the string representation of a 32-bit unsigned integer into this instance at the specified
    ///     character position.
    /// </summary>
    /// <param name="index">
    ///     The position in this instance where insertion begins.
    /// </param>
    /// <param name="value">
    ///     The value to insert.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the insert operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is less than zero or greater than the length of this instance.
    /// </exception>
    /// <exception cref="OutOfMemoryException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     <see cref="uint.ToString()"/> is used to get a string representation of <paramref name="value"/>.
    ///     Existing characters are shifted to make room for the new text.
    ///     The capacity of this instance is adjusted as needed.
    /// </remarks>
    [CLSCompliant(false)]
    public IStringBuilder Insert(int index, uint value);

    /// <summary>
    ///     Inserts the sequence of characters into this instance at the specified character position.
    /// </summary>
    /// <param name="index">
    ///     The position in this instance where insertion begins.
    /// </param>
    /// <param name="value">
    ///     A reference to this instance after the insert operation has completed.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the insert operation has completed.
    /// </returns>
    /// <remarks>
    ///     The existing characters are shifted to make room for the character sequence in the <paramref name="value"/>
    ///     to insert it. The capacity is adjusted as needed.
    /// </remarks>
    public IStringBuilder Insert(int index, ReadOnlySpan<char> value);

    /// <summary>
    ///     Inserts the string representation of a double-precision floating-point number into this instance
    ///     at the specified character position.
    /// </summary>
    /// <param name="index">
    ///     The position in this instance where insertion begins.
    /// </param>
    /// <param name="value">
    ///     The value to insert.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the insert operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is less than zero or greater than the length of this instance.
    /// </exception>
    /// <exception cref="OutOfMemoryException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     <see cref="double.ToString()"/> is used to get a string representation of <paramref name="value"/>.
    ///     Existing characters are shifted to make room for the new text.
    ///     The capacity of this instance is adjusted as needed.
    /// </remarks>
    public IStringBuilder Insert(int index, double value);

    /// <summary>
    ///     Inserts the string representation of a specified 64-bit signed integer into this instance at the specified
    ///     character position.
    /// </summary>
    /// <param name="index">
    ///     The position in this instance where insertion begins.
    /// </param>
    /// <param name="value">
    ///     The value to insert.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the insert operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is less than zero or greater than the length of this instance.
    /// </exception>
    /// <exception cref="OutOfMemoryException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     <see cref="long.ToString()"/> is used to get a string representation of <paramref name="value"/>.
    ///     Existing characters are shifted to make room for the new text.
    ///     The capacity of this instance is adjusted as needed.
    /// </remarks>
    public IStringBuilder Insert(int index, long value);

    /// <summary>
    ///     Inserts the string representation of a specified 32-bit signed integer into this instance at the specified
    ///     character position.
    /// </summary>
    /// <param name="index">
    ///     The position in this instance where insertion begins.
    /// </param>
    /// <param name="value">
    ///     The value to insert.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the insert operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is less than zero or greater than the length of this instance.
    /// </exception>
    /// <exception cref="OutOfMemoryException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     <see cref="int.ToString()"/> is used to get a string representation of <paramref name="value"/>.
    ///     Existing characters are shifted to make room for the new text.
    ///     The capacity of this instance is adjusted as needed.
    /// </remarks>
    public IStringBuilder Insert(int index, int value);

    /// <summary>
    ///     Inserts the string representation of an object into this instance
    ///     at the specified character position.
    /// </summary>
    /// <param name="index">
    ///     The position in this instance where insertion begins.
    /// </param>
    /// <param name="value">
    ///     The object to insert, or null.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the insert operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is less than zero or greater than the length of this instance.
    /// </exception>
    /// <exception cref="OutOfMemoryException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     <see cref="object.ToString"/> is used to get a string representation of <paramref name="value"/>.
    ///     Existing characters are shifted to make room for the new text. The capacity of this instance
    ///     is adjusted as needed.
    ///
    ///     If <paramref name="value"/> is null, the value of this instance is unchanged.
    /// </remarks>
    public IStringBuilder Insert(int index, object? value);

    /// <summary>
    ///     Inserts the string representation of a decimal number into this instance
    ///     at the specified character position.
    /// </summary>
    /// <param name="index">
    ///     The position in this instance where insertion begins.
    /// </param>
    /// <param name="value">
    ///     The value to insert.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the insert operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is less than zero or greater than the length of this instance.
    /// </exception>
    /// <exception cref="OutOfMemoryException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     <see cref="decimal.ToString()"/> is used to get a string representation of <paramref name="value"/>.
    ///     Existing characters are shifted to make room for the new text.
    ///     The capacity of this instance is adjusted as needed.
    /// </remarks>
    public IStringBuilder Insert(int index, decimal value);

    /// <summary>
    ///     Inserts the string representation of a specified array of Unicode characters into this instance
    ///     at the specified character position.
    /// </summary>
    /// <param name="index">
    ///     The position in this instance where insertion begins.
    /// </param>
    /// <param name="value">
    ///     The character array to insert.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the insert operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is less than zero or greater than the length of this instance.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     Existing characters are shifted to make room for the new text.
    ///     The capacity of this instance is adjusted as needed.
    ///
    ///     If <paramref name="value"/> is null, the <see cref="IStringBuilder"/> is not changed.
    /// </remarks>
    public IStringBuilder Insert(int index, char[]? value);

    /// <summary>
    ///     Inserts the string representation of a specified Unicode character into this instance
    ///     at the specified character position.
    /// </summary>
    /// <param name="index">
    ///     The position in this instance where insertion begins.
    /// </param>
    /// <param name="value">
    ///     The value to insert.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the insert operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is less than zero or greater than the length of this instance.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     <see cref="char.ToString()"/> is used to get a string representation of <paramref name="value"/>.
    ///     Existing characters are shifted to make room for the new text.
    ///     The capacity of this instance is adjusted as needed.
    /// </remarks>
    public IStringBuilder Insert(int index, char value);

    /// <summary>
    ///     Inserts the string representation of a specified 8-bit unsigned integer into this instance
    ///     at the specified character position.
    /// </summary>
    /// <param name="index">
    ///     The position in this instance where insertion begins.
    /// </param>
    /// <param name="value">
    ///     The value to insert.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the insert operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is less than zero or greater than the length of this instance.
    /// </exception>
    /// <exception cref="OutOfMemoryException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     <see cref="byte.ToString()"/> is used to get a string representation of <paramref name="value"/>.
    ///     Existing characters are shifted to make room for the new text.
    ///     The capacity of this instance is adjusted as needed.
    /// </remarks>
    public IStringBuilder Insert(int index, byte value);

    /// <summary>
    ///     Inserts the string representation of a Boolean value into this instance
    ///     at the specified character position.
    /// </summary>
    /// <param name="index">
    ///     The position in this instance where insertion begins.
    /// </param>
    /// <param name="value">
    ///     The value to insert.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the insert operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is less than zero or greater than the length of this instance.
    /// </exception>
    /// <exception cref="OutOfMemoryException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     <see cref="bool.ToString()"/> is used to get a string representation of <paramref name="value"/>.
    ///     Existing characters are shifted to make room for the new text.
    ///     The capacity of this instance is adjusted as needed.
    /// </remarks>
    public IStringBuilder Insert(int index, bool value);

    /// <summary>
    ///     Removes the specified range of characters from this instance.
    /// </summary>
    /// <param name="startIndex">
    ///     The zero-based position in this instance where removal begins.
    /// </param>
    /// <param name="length">
    ///     The number of characters to remove.
    /// </param>
    /// <returns>
    ///     A reference to this instance after the excise operation has completed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     If <paramref name="startIndex"/> or <paramref name="length"/> is less than zero,
    ///     or <paramref name="startIndex"/> + <paramref name="length"/> is greater than the length
    ///     of this instance.
    /// </exception>
    /// <remarks>
    ///     The current method removes the specified range of characters from the current instance.
    ///     The characters at (<paramref name="startIndex"/> + <paramref name="length"/> are moved to
    ///     <paramref name="startIndex"/>, and the string value of the current instance is shortened by
    ///     <paramref name="length"/>. The capacity of the current instance is unaffected.
    /// </remarks>
    public IStringBuilder Remove(int startIndex, int length);

    /// <summary>
    ///     Replaces all occurrences of a specified character in this instance
    ///     with another specified character.
    /// </summary>
    /// <param name="oldChar">
    ///     The character to replace.
    /// </param>
    /// <param name="newChar">
    ///     The character that replaces <paramref name="oldChar"/>.
    /// </param>
    /// <returns>
    ///     A reference to this instance with <paramref name="oldChar"/> replaced by <paramref name="newChar"/>.
    /// </returns>
    /// <remarks>
    ///     This method performs an ordinal, case-sensitive comparison to identify occurrences of <paramref name="oldChar"/>
    ///     in the current instance. The size of the current <see cref="IStringBuilder"/> is unchanged after the replacement.
    /// </remarks>
    public IStringBuilder Replace(char oldChar, char newChar);

    /// <summary>
    ///     Replaces all occurrences of a specified string in this instance
    ///     with another specified string.
    /// </summary>
    /// <param name="oldValue">
    ///     The string to replace.
    /// </param>
    /// <param name="newValue">
    ///     The string that replaces <paramref name="oldValue"/>, or null.
    /// </param>
    /// <returns>
    ///     A reference to this instance with <paramref name="oldValue"/> replaced by <paramref name="newValue"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="oldValue"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     The length of <paramref name="oldValue"/> is zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     This method performs an ordinal, case-sensitive comparison to identify occurrences of <paramref name="oldValue"/>
    ///     in the current instance. If <paramref name="newValue"/> is null or <see cref="string.Empty"/>, all occurrences
    ///     of <paramref name="oldValue"/> are removed.
    /// </remarks>
    public IStringBuilder Replace(string oldValue, string? newValue);

    /// <summary>
    ///     Replaces within a substring of this instance,
    ///     all occurrences of a specified character with
    ///     another specified character.
    /// </summary>
    /// <param name="oldChar">
    ///     The character to replace.
    /// </param>
    /// <param name="newChar">
    ///     The character that replaces <paramref name="oldChar"/>.
    /// </param>
    /// <param name="startIndex">
    ///     The position in this instance where the substring begins.
    /// </param>
    /// <param name="count">
    ///     The length of the substring.
    /// </param>
    /// <returns>
    ///     A reference to this instance with <paramref name="oldChar"/> replaced by <paramref name="newChar"/>
    ///     in the range from <paramref name="startIndex"/> to <paramref name="startIndex"/> + <paramref name="count"/> - 1.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="startIndex"/> + <paramref name="count"/>
    ///     is greater than the length of the value of this instance.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="startIndex"/> or <paramref name="count"/>
    ///     is less than zero.
    /// </exception>
    /// <remarks>
    ///     This method performs an ordinal, case-sensitive comparison to identify occurrences of <paramref name="oldChar"/>
    ///     in the current instance. The size of the current <see cref="IStringBuilder"/> is unchanged after the replacement.
    /// </remarks>
    public IStringBuilder Replace(char oldChar, char newChar, int startIndex,
        int count);

    /// <summary>
    ///     Replaces within a substring of this instance,
    ///     all occurrences of a specified string with
    ///     another specified string.
    /// </summary>
    /// <param name="oldValue">
    ///     The character to replace.
    /// </param>
    /// <param name="newValue">
    ///     The character that replaces <paramref name="oldValue"/>, or null.
    /// </param>
    /// <param name="startIndex">
    ///     The position in this instance where the substring begins.
    /// </param>
    /// <param name="count">
    ///     The length of the substring.
    /// </param>
    /// <returns>
    ///     A reference to this instance with <paramref name="oldValue"/> replaced by <paramref name="newValue"/>
    ///     in the range from <paramref name="startIndex"/> to <paramref name="startIndex"/> + <paramref name="count"/> - 1.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="oldValue"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     The length of <paramref name="oldValue"/> is zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="startIndex"/> or <paramref name="count"/> is less than zero.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="startIndex"/> or <paramref name="count"/> indicates a character position
    ///     not within this instance.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.
    /// </exception>
    /// <remarks>
    ///     This method performs an ordinal, case-sensitive comparison to identify occurrences of <paramref name="oldValue"/>
    ///     in the current instance. If <paramref name="newValue"/> is null or <see cref="string.Empty"/>, all occurrences
    ///     of <paramref name="oldValue"/> are removed.
    /// </remarks>
    public IStringBuilder Replace(string oldValue, string? newValue,
        int startIndex, int count);

    /// <summary>
    ///     Converts the value of this instance to a <see cref="String"/>.
    /// </summary>
    /// <returns>
    ///     A string whose value is the same as this instance.
    /// </returns>
    /// <remarks>
    ///     You must call the <see cref="ToString()"/> method to convert the <see cref="IStringBuilder"/> object
    ///     to a <see cref="String"/> object before you can pass the string represented by the <see cref="IStringBuilder"/>
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
    ///     You must call the <see cref="ToString(int, int)"/> method to convert the <see cref="IStringBuilder"/> object
    ///     to a <see cref="String"/> object before you can pass the string represented by the <see cref="IStringBuilder"/>
    ///     object to a method that has a <see cref="String"/> parameter or display it in the user interface.
    /// </remarks>
    public string ToString(int startIndex, int length);

    /// <summary>
    ///     Clones this current instance into a new instance.
    ///     This is a deep clone so the parent structures will be cloned if needed.
    /// </summary>
    /// <returns>
    ///     An instance to the new instance with the same value.
    /// </returns>
    public IStringBuilder Clone();
}