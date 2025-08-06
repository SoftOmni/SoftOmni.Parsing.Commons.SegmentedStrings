﻿using System.Collections;
using System.Runtime.Serialization;
using System.Text;

namespace SoftOmni.Parsing.Commons.SegmentedStrings;

public sealed class SegmentedString : IStringBuilder
{
    private readonly StringBuilder _builder;

    public SegmentedString()
    {
        _builder = new StringBuilder();
    }

    public SegmentedString(string s)
    {
        _builder = new StringBuilder(s);
    }

    public SegmentedString(StringBuilder builder)
        : this(builder.ToString())
    { }

    public SegmentedString(SegmentedString segment)
        : this(segment.ToString())
    { }

    public int Capacity
    {
        get => _builder.Capacity;
        set => _builder.Capacity = value;
    }

    public char this[int index]
    {
        get => _builder[index];
        set => _builder[index] = value;
    }

    public int Length
    {
        get => _builder.Length; 
        set => _builder.Length = value;
    }

    public int MaxCapacity => _builder.MaxCapacity;
    
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    { }

    public IStringBuilder Append(IStringBuilder? value)
    {
        _builder.Append(value);
        return this;
    }

    public IStringBuilder Append(StringBuilder? value)
    {
        _builder.Append(value);
        return this;
    }

    public IStringBuilder Append(ushort value)
    {
        _builder.Append(value);
        return this;
    }

    public IStringBuilder Append(uint value)
    {
        _builder.Append(value);
        return this;
    }

    public IStringBuilder Append(ulong value)
    {
        _builder.Append(value);
        return this;
    }

    public IStringBuilder Append(char value, int repeatCount)
    {
        _builder.Append(value, repeatCount);
        return this;
    }

    public IStringBuilder Append(char[]? value, int startIndex, int charCount)
    {
        _builder.Append(value, startIndex, charCount);
        return this;
    }

    public IStringBuilder Append(IFormatProvider? provider, ref StringBuilder.AppendInterpolatedStringHandler handler)
    {
        _builder.Append(provider, ref handler);
        return this;
    }

    public IStringBuilder Append(string? value)
    {
        _builder.Append(value);
        return this;
    }

    public IStringBuilder Append(string? value, int startIndex, int count)
    {
        _builder.Append(value, startIndex, count);
        return this;
    }

    public IStringBuilder Append(IStringBuilder? value, int startIndex, int count)
    {
        throw new NotImplementedException();
    }

    public IStringBuilder Append(StringBuilder? value, int startIndex, int count)
    {
        _builder.Append(value, startIndex, count);
        return this;
    }

    public IStringBuilder Append(float value)
    {
        _builder.Append(value);
        return this;
    }

    public IStringBuilder Append(ref StringBuilder.AppendInterpolatedStringHandler handler)
    {
        _builder.Append(ref handler);
        return this;
    }

    public IStringBuilder Append(ReadOnlySpan<char> value)
    {
        _builder.Append(value);
        return this;
    }

    public IStringBuilder Append(sbyte value)
    {
        _builder.Append(value);
        return this;
    }

    public IStringBuilder Append(bool value)
    {
        _builder.Append(value);
        return this;
    }

    public IStringBuilder Append(byte value)
    {
        _builder.Append(value);
        return this;
    }

    public IStringBuilder Append(char value)
    {
        _builder.Append(value);
        return this;
    }

    public IStringBuilder Append(char[]? value)
    {
        _builder.Append(value);
        return this;
    }

    public IStringBuilder Append(double value)
    {
        _builder.Append(value);
        return this;
    }

    public IStringBuilder Append(decimal value)
    {
        _builder.Append(value);
        return this;
    }

    public IStringBuilder Append(int value)
    {
        _builder.Append(value);
        return this;
    }

    public IStringBuilder Append(long value)
    {
        _builder.Append(value);
        return this;
    }

    public IStringBuilder Append(object? value)
    {
        _builder.Append(value);
        return this;
    }

    public IStringBuilder Append(ReadOnlyMemory<char> value)
    {
        _builder.Append(value);
        return this;
    }

    public IStringBuilder Append(short value)
    {
        _builder.Append(value);
        return this;
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
        _builder.AppendFormat(format, arg0, arg1);
        return this;
    }

    public IStringBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0, object? arg1, object? arg2)
    {
        _builder.AppendFormat(provider, format, arg0, arg1, arg2);
        return this;
    }

    public IStringBuilder AppendFormat(string format, object? arg0, object? arg1, object? arg2)
    {
        _builder.AppendFormat(format, arg0, arg1, arg2);
        return this;
    }

    public IStringBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0, object? arg1)
    {
        _builder.AppendFormat(provider, format, arg0, arg1);
        return this;
    }

    public IStringBuilder AppendFormat(IFormatProvider? provider, CompositeFormat format, ReadOnlySpan<object?> args)
    {
        _builder.AppendFormat(provider, format, args);
        return this;
    }

    public IStringBuilder AppendFormat(string format, object? arg0)
    {
        _builder.AppendFormat(format, arg0);
        return this;
    }

    public IStringBuilder AppendFormat(IFormatProvider? provider, string format, params object?[] args)
    {
        _builder.AppendFormat(provider, format, args);
        return this;
    }

    public IStringBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0)
    {
        _builder.AppendFormat(provider, format, arg0);
        return this;
    }

    public IStringBuilder AppendFormat(string format, params object?[] args)
    {
        _builder.AppendFormat(format, args);
        return this;
    }

    public IStringBuilder AppendFormat(IFormatProvider? provider, CompositeFormat format, params object?[] args)
    {
        _builder.AppendFormat(provider, format, args);
        return this;
    }

    public IStringBuilder AppendFormat<TArg0, TArg1, TArg2>(IFormatProvider? provider, CompositeFormat format, TArg0 arg0,
        TArg1 arg1, TArg2 arg2)
    {
        _builder.AppendFormat(provider, format, arg0, arg1, arg2);
        return this;
    }

    public IStringBuilder AppendFormat<TArg0, TArg1>(IFormatProvider? provider, CompositeFormat format, TArg0 arg0, TArg1 arg1)
    {
        _builder.AppendFormat(provider, format, arg0, arg1);
        return this;
    }

    public IStringBuilder AppendFormat<TArg0>(IFormatProvider? provider, CompositeFormat format, TArg0 arg0)
    {
        _builder.AppendFormat(provider, format, arg0);
        return this;
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
        _builder.AppendJoin(separator, values);
        return this;
    }

    public IStringBuilder AppendJoin(string? separator, params object?[] values)
    {
        _builder.AppendJoin(separator, values);
        return this;
    }

    public IStringBuilder AppendJoin(char separator, params object?[] values)
    {
        _builder.AppendJoin(separator, values);
        return this;
    }

    public IStringBuilder AppendJoin(char separator, params string?[] values)
    {
        _builder.AppendJoin(separator, values);
        return this;
    }

    public IStringBuilder AppendJoin<T>(char separator, IEnumerable<T> values)
    {
        _builder.AppendJoin(separator, values);
        return this;
    }

    public IStringBuilder AppendJoin<T>(string? separator, IEnumerable<T> values)
    {
        _builder.AppendJoin(separator, values);
        return this;
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
        _builder.AppendLine();
        return this;
    }

    public IStringBuilder AppendLine(string? value)
    {
        _builder.AppendLine(value);
        return this;
    }

    public IStringBuilder AppendLine(ref StringBuilder.AppendInterpolatedStringHandler handler)
    {
        _builder.AppendLine(ref handler);
        return this;
    }

    public IStringBuilder AppendLine(IFormatProvider? provider, ref StringBuilder.AppendInterpolatedStringHandler handler)
    {
        _builder.AppendLine(provider, ref handler);
        return this;
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
        _builder.Clear();
        return this;
    }

    public void CopyTo(int sourceIndex, Span<char> destination, int count)
    {
        _builder.CopyTo(sourceIndex, destination, count);
    }

    public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
    {
        _builder.CopyTo(sourceIndex, destination, destinationIndex, count);
    }

    public int EnsureCapacity(int capacity)
    {
        return _builder.EnsureCapacity(capacity);
    }

    public bool Equals(ReadOnlySpan<char> span)
    {
        return _builder.Equals(span);
    }

    public bool Equals(IReadOnlyStringBuilder? sb)
    {
        throw new NotImplementedException();
    }

    public bool Equals(StringBuilder? sb)
    {
        return _builder.Equals(sb);
    }

    public StringBuilder.ChunkEnumerator GetChunks()
    {
        return _builder.GetChunks();
    }

    public IStringBuilder Insert(int index, string? value)
    {
        _builder.Insert(index, value);
        return this;
    }

    public IStringBuilder Insert(int index, float value)
    {
        _builder.Insert(index, value);
        return this;
    }

    public IStringBuilder Insert(int index, ushort value)
    {
        _builder.Insert(index, value);
        return this;
    }

    public IStringBuilder Insert(int index, short value)
    {
        _builder.Insert(index, value);
        return this;
    }

    public IStringBuilder Insert(int index, ulong value)
    {
        _builder.Insert(index, value);
        return this;
    }

    public IStringBuilder Insert(int index, string? value, int count)
    {
        _builder.Insert(index, value, count);
        return this;
    }

    public IStringBuilder Insert(int index, char[]? value, int startIndex, int charCount)
    {
        _builder.Insert(index, value, startIndex, charCount);
        return this;
    }

    public IStringBuilder Insert(int index, sbyte value)
    {
        _builder.Insert(index, value);
        return this;
    }

    public IStringBuilder Insert(int index, uint value)
    {
        _builder.Insert(index, value);
        return this;
    }

    public IStringBuilder Insert(int index, ReadOnlySpan<char> value)
    {
        _builder.Insert(index, value);
        return this;
    }

    public IStringBuilder Insert(int index, double value)
    {
        _builder.Insert(index, value);
        return this;
    }

    public IStringBuilder Insert(int index, long value)
    {
        _builder.Insert(index, value);
        return this;
    }

    public IStringBuilder Insert(int index, int value)
    {
        _builder.Insert(index, value);
        return this;
    }

    public IStringBuilder Insert(int index, object? value)
    {
        _builder.Insert(index, value);
        return this;
    }

    public IStringBuilder Insert(int index, decimal value)
    {
        _builder.Insert(index, value);
        return this;
    }

    public IStringBuilder Insert(int index, char[]? value)
    {
        _builder.Insert(index, value);
        return this;
    }

    public IStringBuilder Insert(int index, char value)
    {
        _builder.Insert(index, value);
        return this;
    }

    public IStringBuilder Insert(int index, byte value)
    {
        _builder.Insert(index, value);
        return this;
    }

    public IStringBuilder Insert(int index, bool value)
    {
        _builder.Insert(index, value);
        return this;
    }

    public IStringBuilder Remove(int startIndex, int length)
    {
        _builder.Remove(startIndex, length);
        return this;
    }

    public IStringBuilder Replace(char oldChar, char newChar)
    {
        _builder.Replace(oldChar, newChar);
        return this;
    }

    public IStringBuilder Replace(string oldValue, string? newValue)
    {
        _builder.Replace(oldValue, newValue);
        return this;
    }

    public IStringBuilder Replace(char oldChar, char newChar, int startIndex, int count)
    {
        _builder.Replace(oldChar, newChar, startIndex, count);
        return this;
    }

    public IStringBuilder Replace(string oldValue, string? newValue, int startIndex, int count)
    {
        _builder.Replace(oldValue, newValue, startIndex, count);
        return this;
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
        return _builder.ToString();
    }

    public string ToString(int startIndex, int length)
    {
        return _builder.ToString(startIndex, length);
    }

    public IStringBuilder Clone()
    {
        return new SegmentedString(this);
    }
    
    private sealed class Enumerator(SegmentedString segmentedString) : IEnumerator<char>
    {
        private int _index = -1;

        public bool MoveNext()
        {
            if (_index >= segmentedString.Length - 1)
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

        public char Current => segmentedString[_index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            // Nothing to do
        }
    }
}