using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;

namespace Soenneker.Extensions.Arrays.Bytes;

/// <summary>
/// A collection of helpful byte[] extension methods
/// </summary>
public static class ByteArrayExtension
{
    /// <summary>
    /// Converts the specified byte array to a UTF-8 encoded string.
    /// </summary>
    /// <param name="value">The byte array to convert.</param>
    /// <returns>A string representation of the byte array, decoded using UTF-8 encoding.</returns>
    [Pure]
    public static string ToStr(this byte[] value)
    {
        if (value.IsEmpty())
            return "";

        return Encoding.UTF8.GetString(value);
    }

    /// <summary>
    /// Converts the specified byte array to a hexadecimal string representation.
    /// </summary>
    /// <param name="value">The byte array to convert.</param>
    /// <returns>A string containing the hexadecimal representation of the byte array.
    /// If the array is empty, an empty string is returned.</returns>
    [Pure]
    public static string ToHex(this byte[] value)
    {
        if (value.IsEmpty())
            return "";

        return Convert.ToHexString(value).ToLowerInvariant();
    }

    /// <summary>
    /// Converts the specified byte array to a Base64-encoded string.
    /// </summary>
    /// <param name="value">The byte array to encode. If null or empty, an empty string is returned.</param>
    /// <returns>A Base64-encoded string.</returns>
    [Pure]
    public static string ToBase64String(this byte[] value)
    {
        if (value.Length == 0)
            return "";

        return Convert.ToBase64String(value);
    }

    /// <summary>
    /// Converts the byte array into a <see cref="MemoryStream"/>.
    /// </summary>
    /// <param name="value">The byte array to convert.</param>
    /// <returns>A <see cref="MemoryStream"/> containing the byte array data.</returns>
    [Pure]
    public static MemoryStream ToStream(this byte[] value)
    {
        return new MemoryStream(value);
    }

    /// <summary>
    /// Determines whether the byte array is null or empty.
    /// </summary>
    /// <param name="value">The byte array to check.</param>
    /// <returns>True if the byte array is null or empty; otherwise, false.</returns>
    [Pure]
    public static bool IsEmpty(this byte[]? value)
    {
        return value is null || value.Length == 0;
    }
}