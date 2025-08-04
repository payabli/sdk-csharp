using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<UnderWritingMethod>))]
[Serializable]
public readonly record struct UnderWritingMethod : IStringEnum
{
    public static readonly UnderWritingMethod Automatic = new(Values.Automatic);

    public static readonly UnderWritingMethod Manual = new(Values.Manual);

    public static readonly UnderWritingMethod Bypass = new(Values.Bypass);

    public UnderWritingMethod(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static UnderWritingMethod FromCustom(string value)
    {
        return new UnderWritingMethod(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(UnderWritingMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UnderWritingMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UnderWritingMethod value) => value.Value;

    public static explicit operator UnderWritingMethod(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Automatic = "automatic";

        public const string Manual = "manual";

        public const string Bypass = "bypass";
    }
}
