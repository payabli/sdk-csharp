using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<PayMethodStoredMethodMethod>))]
[Serializable]
public readonly record struct PayMethodStoredMethodMethod : IStringEnum
{
    public static readonly PayMethodStoredMethodMethod Card = new(Values.Card);

    public static readonly PayMethodStoredMethodMethod Ach = new(Values.Ach);

    public PayMethodStoredMethodMethod(string value)
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
    public static PayMethodStoredMethodMethod FromCustom(string value)
    {
        return new PayMethodStoredMethodMethod(value);
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

    public static bool operator ==(PayMethodStoredMethodMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PayMethodStoredMethodMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PayMethodStoredMethodMethod value) => value.Value;

    public static explicit operator PayMethodStoredMethodMethod(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Card = "card";

        public const string Ach = "ach";
    }
}
