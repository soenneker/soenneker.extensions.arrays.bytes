[![](https://img.shields.io/nuget/v/soenneker.extensions.arrays.bytes.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.arrays.bytes/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.arrays.bytes/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.arrays.bytes/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.arrays.bytes.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.arrays.bytes/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.arrays.bytes/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.arrays.bytes/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.Arrays.Bytes

A collection of helpful byte[] extension methods.

## Installation

```bash
dotnet add package Soenneker.Extensions.Arrays.Bytes
```

## Quick start

```csharp
using Soenneker.Extensions.Arrays.Bytes;

byte[] value = [1, 2, 3];
var result = value.ToStr();
```

## Common operations

- `ToStr()` - Converts the specified byte array to a UTF-8 encoded string. Returns a string representation of the byte array, decoded using UTF-8 encoding.
- `ToHex()` - Converts the bytes to an uppercase hexadecimal string with no separators.
- `ToHexLower()` - Converts the specified byte array to its lowercase hexadecimal string representation. Returns a string containing the lowercase hexadecimal representation of the input bytes. Returns an empty string if the array is empty.
- `ToBase64String()` - Converts the specified byte array to a Base64-encoded string. Returns a Base64-encoded string.
- `ToStream()` - Converts the byte array into a `MemoryStream`. Returns a `MemoryStream` containing the byte array data.
- `IsEmpty()` - Determines whether the byte array is null or empty.
