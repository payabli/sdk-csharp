using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<ButtonElementSize>))]
[Serializable]
public readonly record struct ButtonElementSize : IStringEnum
{
    public static readonly ButtonElementSize Sm = new(Values.Sm);

    public static readonly ButtonElementSize Md = new(Values.Md);

    public static readonly ButtonElementSize Lg = new(Values.Lg);

    public ButtonElementSize(string value)
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
    public static ButtonElementSize FromCustom(string value)
    {
        return new ButtonElementSize(value);
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

    public static bool operator ==(ButtonElementSize value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ButtonElementSize value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ButtonElementSize value) => value.Value;

    public static explicit operator ButtonElementSize(string value) => new(value);

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
