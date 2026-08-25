
namespace Soenneker.Extensions.Arrays.Bytes.Tests;

public class ByteArrayExtensionTests
{
    [Test]
    public void Default()
    {

    }

    [Test]
    public void ToHexLower_should_return_lowercase_hex()
    {
        byte[] value = [0x00, 0x0F, 0x10, 0xAB, 0xFF];

        string result = value.ToHexLower();

        if (!string.Equals(result, "000f10abff", System.StringComparison.Ordinal))
            throw new System.InvalidOperationException($"Unexpected hexadecimal value: {result}");
    }
}
