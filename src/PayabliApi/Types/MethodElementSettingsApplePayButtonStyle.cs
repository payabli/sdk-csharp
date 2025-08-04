using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<MethodElementSettingsApplePayButtonStyle>))]
[Serializable]
public readonly record struct MethodElementSettingsApplePayButtonStyle : IStringEnum
{
    public static readonly MethodElementSettingsApplePayButtonStyle Black = new(Values.Black);

    public static readonly MethodElementSettingsApplePayButtonStyle WhiteOutline = new(
        Values.WhiteOutline
    );

    public static readonly MethodElementSettingsApplePayButtonStyle White = new(Values.White);

    public MethodElementSettingsApplePayButtonStyle(string value)
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
    public static MethodElementSettingsApplePayButtonStyle FromCustom(string value)
    {
        return new MethodElementSettingsApplePayButtonStyle(value);
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

    public static bool operator ==(
        MethodElementSettingsApplePayButtonStyle value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        MethodElementSettingsApplePayButtonStyle value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(MethodElementSettingsApplePayButtonStyle value) =>
        value.Value;

    public static explicit operator MethodElementSettingsApplePayButtonStyle(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Black = "black";

        public const string WhiteOutline = "white-outline";

        public const string White = "white";
    }
}
