using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<RequestPaymentValidatePaymentMethodMethod>))]
[Serializable]
public readonly record struct RequestPaymentValidatePaymentMethodMethod : IStringEnum
{
    public static readonly RequestPaymentValidatePaymentMethodMethod Card = new(Values.Card);

    public static readonly RequestPaymentValidatePaymentMethodMethod Cloud = new(Values.Cloud);

    public RequestPaymentValidatePaymentMethodMethod(string value)
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
    public static RequestPaymentValidatePaymentMethodMethod FromCustom(string value)
    {
        return new RequestPaymentValidatePaymentMethodMethod(value);
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
        RequestPaymentValidatePaymentMethodMethod value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RequestPaymentValidatePaymentMethodMethod value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(RequestPaymentValidatePaymentMethodMethod value) =>
        value.Value;

    public static explicit operator RequestPaymentValidatePaymentMethodMethod(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Card = "card";

        public const string Cloud = "cloud";
    }
}
