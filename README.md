[![](https://img.shields.io/nuget/v/soenneker.extensions.arrays.bytes.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.arrays.bytes/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.arrays.bytes/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.arrays.bytes/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.arrays.bytes.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.arrays.bytes/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.arrays.bytes/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.arrays.bytes/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.Arrays.Bytes

UTF-8 decoding, hexadecimal and Base64 encoding, `MemoryStream` wrapping, and null/empty checks for byte arrays and read-only byte spans.

## Installation

```bash
dotnet add package Soenneker.Extensions.Arrays.Bytes
```

## Text and binary encodings

```csharp
using System.Text;
using Soenneker.Extensions.Arrays.Bytes;

byte[] bytes = Encoding.UTF8.GetBytes("hello");

string text = bytes.ToStr();              // "hello"
string hex = bytes.ToHex();               // "68656C6C6F"
string lowerHex = bytes.ToHexLower();     // "68656c6c6f"
string base64 = bytes.ToBase64String();   // "aGVsbG8="
```

`ToStr()` decodes with .NET's default UTF-8 encoding behavior. Invalid byte sequences are replaced with the Unicode replacement character; this method does not reject malformed UTF-8. Use a strict `UTF8Encoding` instance when invalid input must fail.

`ToHex()` and `ToHexLower()` produce two characters per byte with no prefix or separators. `ToBase64String()` produces standard padded Base64, not Base64URL. Empty inputs produce an empty string. These methods encode data; they do not encrypt, hash, compress, authenticate, or hide it.

The UTF-8 and Base64 methods also have `ReadOnlySpan<byte>` overloads. Returned strings are allocations even when the source is a span.

## Stream wrapping

```csharp
byte[] buffer = [1, 2, 3];

using MemoryStream stream = buffer.ToStream();
```

`ToStream()` returns a writable, non-expandable stream backed by the original array with `Position == 0`. Writing within its existing length changes `buffer`; changing `buffer` is visible through the stream. Writing past capacity throws. Disposing the stream does not clear or dispose the byte array.

Copy the data first when the stream and caller must not share mutations:

```csharp
using MemoryStream isolated = buffer.ToArray().ToStream();
```

## Empty checks and nulls

```csharp
byte[]? optional = null;
bool empty = optional.IsEmpty(); // true
```

`IsEmpty()` is the only nullable-array API and returns `true` for null or zero length. The conversion methods require a non-null receiver; a null array results in `NullReferenceException`.
