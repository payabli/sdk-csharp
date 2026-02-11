using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<AllowedCheckPaymentStatus>))]
[Serializable]
public readonly record struct AllowedCheckPaymentStatus : IStringEnum
{
    public static readonly AllowedCheckPaymentStatus Cancelled = new(Values.Cancelled);

    public static readonly AllowedCheckPaymentStatus Paid = new(Values.Paid);

    public AllowedCheckPaymentStatus(string value)
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
    public static AllowedCheckPaymentStatus FromCustom(string value)
    {
        return new AllowedCheckPaymentStatus(value);
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

    public static bool operator ==(AllowedCheckPaymentStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AllowedCheckPaymentStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AllowedCheckPaymentStatus value) => value.Value;

    public static explicit operator AllowedCheckPaymentStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Cancelled = "0";

        public const string Paid = "5";
    }
}
