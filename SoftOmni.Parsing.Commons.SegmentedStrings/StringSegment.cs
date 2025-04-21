using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace SoftOmni.Parsing.Commons.SegmentedStrings;

/// <summary>
///     Represents a segment of an <see cref="IStringBuilder"/>.
/// </summary>
public sealed class StringSegment : IStringBuilder
{
    /// <summary>
    ///     The parent <see cref="IStringBuilder"/> that contains the segment.
    /// </summary>
    private IStringBuilder Parent { get; }

    /// <summary>
    ///     The offset of the segment in the parent <see cref="IStringBuilder"/> from the start of the parent.
    /// </summary>
    public int Offset { get; private set; }

    /// <summary>
    ///     Initializes a new instance of the <see cref="StringSegment"/> class with the specified parent and offset.
    ///     Additionally, the length of the segment is settable if the segment already exists in the parent.
    /// </summary>
    /// <param name="parent">
    ///     The parent <see cref="IStringBuilder"/> that contains the segment.
    /// </param>
    /// <param name="offset">
    ///     The offset of the segment in the parent <see cref="IStringBuilder"/> from the start of the parent.
    /// </param>
    /// <param name="length">
    ///     The length of the segment in the parent <see cref="IStringBuilder"/>.
    ///     If the length is not specified, it is set to 0 so that the segment is empty
    ///     and does not contain any characters from the parent at the start.
    /// </param>
    public StringSegment(IStringBuilder parent, int offset, int length = 0)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length), length, "Length cannot be negative.");
        
        if (offset + length > parent.Length)
            throw new ArgumentOutOfRangeException(nameof(length), length, "Length out of range.");
        
        Parent = parent;
        Offset = offset;
        Length = length;
    }

    public int Capacity { get; set; }

    public char this[int index]
    {
        get => Parent[index + Offset];
        set => Parent[index + Offset] = value;
    }

    public int Length { get; set; }

    public int MaxCapacity => Parent.MaxCapacity - Offset;

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Helper method to append a value to the parent <see cref="IStringBuilder"/>.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the value to append to the parent <see cref="IStringBuilder"/>.
    /// </typeparam>
    /// <param name="value">
    ///     The value to append to the parent <see cref="IStringBuilder"/>.
    /// </param>
    /// <param name="valueLength">
    ///     The length of the value to append to the parent <see cref="IStringBuilder"/>.
    /// </param>
    /// <returns>
    ///     The current <see cref="IStringBuilder"/> instance.
    /// </returns>
    /// <exception cref="UnreachableException">
    ///     Thrown when the offset and length of the segment exceed the length of the parent <see cref="IStringBuilder"/>.
    ///     This should never happen.
    /// </exception>
    private IStringBuilder AppendToParent<T>(T value, int valueLength)
    {
        if (Offset + Length == Parent.Length)
            Parent.Append(value);
        else if (Offset + Length < Parent.Length)
            Parent.Insert(Offset + Length, value);
        else
            throw new UnreachableException("Offset + Length > Parent.Length"); // should never happen

        Length += valueLength;
        return this;
    }

    public IStringBuilder Append(IStringBuilder? value)
    {
        if (value == null)
        {
            return this;
        }

        string valueAsStr = value.ToString();
        AppendToParent(valueAsStr, value.Length);
        return this;
    }

    public IStringBuilder Append(StringBuilder? value)
    {
        return AppendToParent(value, value?.Length ?? 0);
    }

    public IStringBuilder Append(ushort value)
    {
        string str = value.ToString();
        return AppendToParent(value, str.Length);
    }

    public IStringBuilder Append(uint value)
    {
        string str = value.ToString();
        return AppendToParent(value, str.Length);
    }

    public IStringBuilder Append(ulong value)
    {
        string str = value.ToString();
        return AppendToParent(value, str.Length);
    }

    public IStringBuilder Append(char value, int repeatCount)
    {
        return AppendToParent(value, repeatCount);
    }

    public IStringBuilder Append(char[]? value, int startIndex, int charCount)
    {
        if (Offset + Length == Parent.Length)
            Parent.Append(value, startIndex, charCount);
        else if (Offset + Length < Parent.Length)
            Parent.Insert(Offset + Length, value, startIndex, charCount);
        else
            throw new UnreachableException("Offset + Length > Parent.Length"); // should never happen

        Length += charCount;
        return this;
    }

    public IStringBuilder Append(IFormatProvider? provider, ref StringBuilder.AppendInterpolatedStringHandler handler)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Append(string? value)
    {
        return AppendToParent(value, value?.Length ?? 0);
    }

    public IStringBuilder Append(string? value, int startIndex, int count)
    {
        char[] chars = value?.ToCharArray() ?? Array.Empty<char>();
        return Append(chars, startIndex, count);
    }

    public IStringBuilder Append(IStringBuilder? value, int startIndex, int count)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Append(StringBuilder? value, int startIndex, int count)
    {
        if (value == null)
            return this;

        StringBuilder sub = new StringBuilder();
        for (int i = startIndex; i < startIndex + count; i++)
            sub.Append(value[i]);
        return Append(sub);
    }

    public IStringBuilder Append(float value)
    {
        string str = value.ToString(CultureInfo.CurrentCulture);
        return AppendToParent(value, str.Length);
    }

    public IStringBuilder Append(ref StringBuilder.AppendInterpolatedStringHandler handler)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Append(ReadOnlySpan<char> value)
    {
        if (Offset + Length == Parent.Length)
            Parent.Append(value);
        else if (Offset + Length < Parent.Length)
            Parent.Insert(Offset + Length, value);
        else
            throw new UnreachableException("Offset + Length > Parent.Length"); // should never happen

        Length += value.Length;
        return this;
    }

    public IStringBuilder Append(sbyte value)
    {
        string str = value.ToString();
        return AppendToParent(value, str.Length);
    }

    public IStringBuilder Append(bool value)
    {
        string str = value.ToString();
        return AppendToParent(value, str.Length);
    }

    public IStringBuilder Append(byte value)
    {
        string str = value.ToString();
        return AppendToParent(value, str.Length);
    }

    public IStringBuilder Append(char value)
    {
        return AppendToParent(value, 1);
    }

    public IStringBuilder Append(char[]? value)
    {
        return Append(value, 0, value?.Length ?? 0);
    }

    public IStringBuilder Append(double value)
    {
        string str = value.ToString(CultureInfo.CurrentCulture);
        return AppendToParent(value, str.Length);
    }

    public IStringBuilder Append(decimal value)
    {
        string str = value.ToString(CultureInfo.CurrentCulture);
        return AppendToParent(value, str.Length);
    }

    public IStringBuilder Append(int value)
    {
        string str = value.ToString();
        return AppendToParent(value, str.Length);
    }

    public IStringBuilder Append(long value)
    {
        string str = value.ToString();
        return AppendToParent(value, str.Length);
    }

    public IStringBuilder Append(object? value)
    {
        return Append(value?.ToString());
    }

    public IStringBuilder Append(ReadOnlyMemory<char> value)
    {
        return Append(value.Span);
    }

    public IStringBuilder Append(short value)
    {
        string str = value.ToString();
        return AppendToParent(value, str.Length);
    }

    public IStringBuilder Prepend(IStringBuilder? value)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(ushort value)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(uint value)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(ulong value)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(char value, int repeatCount)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(char[]? value, int startIndex, int charCount)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(IFormatProvider? provider,
        ref StringBuilder.AppendInterpolatedStringHandler handler)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(string? value)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(string? value, int startIndex, int count)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(IStringBuilder? value, int startIndex, int count)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(float value)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(ref StringBuilder.AppendInterpolatedStringHandler handler)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(ReadOnlySpan<char> value)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(sbyte value)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(bool value)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(byte value)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(char value)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(char[]? value)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(double value)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(decimal value)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(int value)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(long value)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(object? value)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(ReadOnlyMemory<char> value)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Prepend(short value)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder AppendFormat(string format, object? arg0, object? arg1)
    {
        string formattedString = string.Format(format, arg0, arg1);
        return AppendToParent(formattedString, formattedString.Length);
    }

    public IStringBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0, object? arg1,
        object? arg2)
    {
        string formattedString = string.Format(provider, format, arg0, arg1, arg2);
        return AppendToParent(formattedString, formattedString.Length);
    }

    public IStringBuilder AppendFormat(string format, object? arg0, object? arg1, object? arg2)
    {
        string formattedString = string.Format(format, arg0, arg1, arg2);
        return AppendToParent(formattedString, formattedString.Length);
    }

    public IStringBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0, object? arg1)
    {
        string formattedString = string.Format(provider, format, arg0, arg1);
        return AppendToParent(formattedString, formattedString.Length);
    }

    public IStringBuilder AppendFormat(IFormatProvider? provider, CompositeFormat format, ReadOnlySpan<object?> args)
    {
        string formattedString = string.Format(provider, format, args);
        return AppendToParent(formattedString, formattedString.Length);
    }

    public IStringBuilder AppendFormat(string format, object? arg0)
    {
        string formattedString = string.Format(format, arg0);
        return AppendToParent(formattedString, formattedString.Length);
    }

    public IStringBuilder AppendFormat(IFormatProvider? provider, string format, params object?[] args)
    {
        string formattedString = string.Format(provider, format, args);
        return AppendToParent(formattedString, formattedString.Length);
    }

    public IStringBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0)
    {
        string formattedString = string.Format(provider, format, arg0);
        return AppendToParent(formattedString, formattedString.Length);
    }

    public IStringBuilder AppendFormat(string format, params object?[] args)
    {
        string formattedString = string.Format(format, args);
        return AppendToParent(formattedString, formattedString.Length);
    }

    public IStringBuilder AppendFormat(IFormatProvider? provider, CompositeFormat format, params object?[] args)
    {
        string formattedString = string.Format(provider, format, args);
        return AppendToParent(formattedString, formattedString.Length);
    }

    public IStringBuilder AppendFormat<TArg0, TArg1, TArg2>(IFormatProvider? provider, CompositeFormat format,
        TArg0 arg0,
        TArg1 arg1, TArg2 arg2)
    {
        string formattedString = string.Format(provider, format, arg0, arg1, arg2);
        return AppendToParent(formattedString, formattedString.Length);
    }

    public IStringBuilder AppendFormat<TArg0, TArg1>(IFormatProvider? provider, CompositeFormat format, TArg0 arg0,
        TArg1 arg1)
    {
        string formattedString = string.Format(provider, format, arg0, arg1);
        return AppendToParent(formattedString, formattedString.Length);
    }

    public IStringBuilder AppendFormat<TArg0>(IFormatProvider? provider, CompositeFormat format, TArg0 arg0)
    {
        string formattedString = string.Format(provider, format, arg0);
        return AppendToParent(formattedString, formattedString.Length);
    }

    public IStringBuilder PrependFormat(string format, object? arg0, object? arg1)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder PrependFormat(IFormatProvider? provider, string format,
        object? arg0, object? arg1, object? arg2)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder PrependFormat(string format, object? arg0, object? arg1,
        object? arg2)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder PrependFormat(IFormatProvider? provider, string format,
        object? arg0, object? arg1)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder PrependFormat(IFormatProvider? provider, CompositeFormat format,
        ReadOnlySpan<object?> args)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder PrependFormat(string format, object? arg0)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder PrependFormat(IFormatProvider? provider, string format,
        params object?[] args)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder PrependFormat(IFormatProvider? provider, string format,
        object? arg0)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder PrependFormat(string format, params object?[] args)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder PrependFormat(IFormatProvider? provider, CompositeFormat format,
        params object?[] args)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder PrependFormat<TArg0, TArg1, TArg2>(IFormatProvider? provider,
        CompositeFormat format, TArg0 arg0, TArg1 arg1, TArg2 arg2)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder PrependFormat<TArg0, TArg1>(IFormatProvider? provider,
        CompositeFormat format, TArg0 arg0, TArg1 arg1)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder PrependFormat<TArg0>(IFormatProvider? provider,
        CompositeFormat format, TArg0 arg0)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder AppendJoin(string? separator, params string?[] values)
    {
        string joined = string.Join(separator, values);
        return AppendToParent(joined, joined.Length);
    }

    public IStringBuilder AppendJoin(string? separator, params object?[] values)
    {
        string joined = string.Join(separator, values);
        return AppendToParent(joined, joined.Length);
    }

    public IStringBuilder AppendJoin(char separator, params object?[] values)
    {
        string joined = string.Join(separator, values);
        return AppendToParent(joined, joined.Length);
    }

    public IStringBuilder AppendJoin(char separator, params string?[] values)
    {
        string joined = string.Join(separator, values);
        return AppendToParent(joined, joined.Length);
    }

    public IStringBuilder AppendJoin<T>(char separator, IEnumerable<T> values)
    {
        string joined = string.Join(separator, values);
        return AppendToParent(joined, joined.Length);
    }

    public IStringBuilder AppendJoin<T>(string? separator, IEnumerable<T> values)
    {
        string joined = string.Join(separator, values);
        return AppendToParent(joined, joined.Length);
    }

    public IStringBuilder PrependJoin(string? separator, params string?[] values)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder PrependJoin(string? separator, params object?[] values)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder PrependJoin(char separator, params object?[] values)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder PrependJoin(char separator, params string?[] values)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder PrependJoin<T>(char separator, IEnumerable<T> values)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder PrependJoin<T>(string? separator, IEnumerable<T> values)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder AppendLine()
    {
        return Append(Environment.NewLine);
    }

    public IStringBuilder AppendLine(string? value)
    {
        return Append(value).AppendLine();
    }

    public IStringBuilder AppendLine(ref StringBuilder.AppendInterpolatedStringHandler handler)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder AppendLine(IFormatProvider? provider,
        ref StringBuilder.AppendInterpolatedStringHandler handler)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder PrependLine()
    {
        throw new NotImplementedException();
    }

    public IStringBuilder PrependLine(string? value)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Clear()
    {
        Parent.Remove(Offset, Length);
        Length = 0;
        return this;
    }

    public void CopyTo(int sourceIndex, Span<char> destination, int count)
    {
        Parent.CopyTo(Offset + sourceIndex, destination, count);
    }

    public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
    {
        Parent.CopyTo(Offset + sourceIndex, destination, destinationIndex, count);
    }

    public int EnsureCapacity(int capacity)
    {
        return Parent.EnsureCapacity(Offset + capacity);
    }

    public bool Equals(ReadOnlySpan<char> span)
    {
        while (span.Length > 0)
        {
            if (span[0] != this[0])
                return false;
            span = span[1..];
            Offset += 1;
        }

        return true;
    }

    public bool Equals(IStringBuilder? sb)
    {
        throw new NotImplementedException();
    }

    public bool Equals(StringBuilder? sb)
    {
        if (sb == null)
            return false;

        for (int i = 0; i < sb.Length; i++)
        {
            if (sb[i] != this[i])
                return false;
        }

        return true;
    }

    public StringBuilder.ChunkEnumerator GetChunks()
    {
        throw new NotImplementedException();
    }

    private int CheckIndex(int index)
    {
        int targetIndex = Offset + index;
        if (targetIndex >= Length)
            throw new ArgumentOutOfRangeException(nameof(index), index, "Index out of range.");
        return targetIndex;
    }

    public IStringBuilder Insert(int index, string? value)
    {
        int targetIndex = CheckIndex(index);
        return Parent.Insert(targetIndex, value);
    }

    public IStringBuilder Insert(int index, float value)
    {
        int targetIndex = CheckIndex(index);
        return Parent.Insert(targetIndex, value);
    }

    public IStringBuilder Insert(int index, ushort value)
    {
        int targetIndex = CheckIndex(index);
        return Parent.Insert(targetIndex, value);
    }

    public IStringBuilder Insert(int index, short value)
    {
        int targetIndex = CheckIndex(index);
        return Parent.Insert(targetIndex, value);
    }

    public IStringBuilder Insert(int index, ulong value)
    {
        int targetIndex = CheckIndex(index);
        return Parent.Insert(targetIndex, value);
    }

    public IStringBuilder Insert(int index, string? value, int count)
    {
        int targetIndex = CheckIndex(index);
        return Parent.Insert(targetIndex, value, count);
    }

    public IStringBuilder Insert(int index, char[]? value, int startIndex, int charCount)
    {
        int targetIndex = CheckIndex(index);
        return Parent.Insert(targetIndex, value, startIndex, charCount);
    }

    public IStringBuilder Insert(int index, sbyte value)
    {
        int targetIndex = CheckIndex(index);
        return Parent.Insert(targetIndex, value);
    }

    public IStringBuilder Insert(int index, uint value)
    {
        int targetIndex = CheckIndex(index);
        return Parent.Insert(targetIndex, value);
    }

    public IStringBuilder Insert(int index, ReadOnlySpan<char> value)
    {
        int targetIndex = CheckIndex(index);
        return Parent.Insert(targetIndex, value);
    }

    public IStringBuilder Insert(int index, double value)
    {
        int targetIndex = CheckIndex(index);
        return Parent.Insert(targetIndex, value);
    }

    public IStringBuilder Insert(int index, long value)
    {
        int targetIndex = CheckIndex(index);
        return Parent.Insert(targetIndex, value);
    }

    public IStringBuilder Insert(int index, int value)
    {
        int targetIndex = CheckIndex(index);
        return Parent.Insert(targetIndex, value);
    }

    public IStringBuilder Insert(int index, object? value)
    {
        int targetIndex = CheckIndex(index);
        return Parent.Insert(targetIndex, value);
    }

    public IStringBuilder Insert(int index, decimal value)
    {
        int targetIndex = CheckIndex(index);
        return Parent.Insert(targetIndex, value);
    }

    public IStringBuilder Insert(int index, char[]? value)
    {
        int targetIndex = CheckIndex(index);
        return Parent.Insert(targetIndex, value);
    }

    public IStringBuilder Insert(int index, char value)
    {
        int targetIndex = CheckIndex(index);
        return Parent.Insert(targetIndex, value);
    }

    public IStringBuilder Insert(int index, byte value)
    {
        int targetIndex = CheckIndex(index);
        return Parent.Insert(targetIndex, value);
    }

    public IStringBuilder Insert(int index, bool value)
    {
        int targetIndex = CheckIndex(index);
        return Parent.Insert(targetIndex, value);
    }

    public IStringBuilder Remove(int startIndex, int length)
    {
        if (Offset + startIndex + length > Parent.Length)
            throw new ArgumentOutOfRangeException(nameof(length), length, "Length out of range.");
        return Parent.Remove(Offset + startIndex, length);
    }

    public IStringBuilder Replace(char oldChar, char newChar)
    {
        for (int i = 0; i < Length; i++)
        {
            if (this[i] == oldChar)
                this[i] = newChar;
        }

        return this;
    }

    public IStringBuilder Replace(string oldValue, string? newValue)
    {
        return Replace(oldValue, newValue, 0, Length);
    }

    public IStringBuilder Replace(char oldChar, char newChar, int startIndex, int count)
    {
        int targetIndex = Offset + startIndex;
        if (targetIndex + count > Length)
            throw new ArgumentOutOfRangeException(nameof(count), count, "Count out of range.");

        for (int index = 0; index < count; index++)
        {
            if (this[targetIndex + index] == oldChar)
                this[targetIndex + index] = newChar;
        }
        
        return this;
    }

    public IStringBuilder Replace(string oldValue, string? newValue, int startIndex, int count)
    {
        VerifyReplaceStringInSubStringsParameters(oldValue, startIndex, count);

        if (oldValue.Length > Length)
            return this;
        
        int index = startIndex;
        int endIndex = startIndex + count;
        while (index < endIndex)
        {
            if (this[index] != oldValue[0])
            {
                index += 1;
                continue;
            }

            if (!DetermineIfIsSubString(oldValue, index))
            {
                index += 1;
                continue;
            }

            Remove(index, oldValue.Length);
            Insert(index, newValue);
            index += newValue?.Length ?? 0;
        }
        
        return this;
    }

    private void VerifyReplaceStringInSubStringsParameters(string oldValue, int startIndex, int count)
    {
        if (oldValue is null)
            throw new ArgumentNullException(nameof(oldValue));

        if (oldValue.Length == 0)
            throw new ArgumentException("Old value cannot be empty.", nameof(oldValue));
        
        if (startIndex < 0 || startIndex >= Length)
            throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, "Start index out of range.");
        
        if (count < 0 || startIndex + count > Length)
            throw new ArgumentOutOfRangeException(nameof(count), count, "Count out of range.");
    }
    
    private bool DetermineIfIsSubString(string oldValue, int index)
    {
        bool found = true;
        for (int i = 1; i < oldValue.Length; i++)
        {
            if (this[index + i] == oldValue[i]) 
                continue;
                
            found = false;
            break;
        }

        return found;
    }

    public IEnumerator<char> GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        return Parent.ToString(Offset, Length);
    }

    public string ToString(int startIndex, int length)
    {
        return Parent.ToString(Offset + startIndex, length);
    }

    public IStringBuilder Clone()
    {
        throw new NotImplementedException();
    }

    

    private sealed class Enumerator(StringSegment stringSegment) : IEnumerator<char>
    {
        private int _index = -1;

        public bool MoveNext()
        {
            if (_index >= stringSegment.Length - 1)
            {
                return false;
            }

            _index += 1;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }

        public char Current => stringSegment[_index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            // Nothing to do
        }
    }
}