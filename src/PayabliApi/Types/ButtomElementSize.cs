using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<ButtomElementSize>))]
[Serializable]
public readonly record struct ButtomElementSize : IStringEnum
{
    public static readonly ButtomElementSize Sm = new(Values.Sm);

    public static readonly ButtomElementSize Md = new(Values.Md);

    public static readonly ButtomElementSize Lg = new(Values.Lg);

    public ButtomElementSize(string value)
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
    public static ButtomElementSize FromCustom(string value)
    {
        return new ButtomElementSize(value);
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

    public static bool operator ==(ButtomElementSize value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ButtomElementSize value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ButtomElementSize value) => value.Value;

    public static explicit operator ButtomElementSize(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Sm = "sm";

        public const string Md = "md";

        public const string Lg = "lg";
    }
}
