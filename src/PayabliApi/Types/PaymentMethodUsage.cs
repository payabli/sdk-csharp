using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(PaymentMethodUsage.PaymentMethodUsageSerializer))]
[Serializable]
public readonly record struct PaymentMethodUsage : IStringEnum
{
    public static readonly PaymentMethodUsage Deposits = new(Values.Deposits);

    public static readonly PaymentMethodUsage Billing = new(Values.Billing);

    public static readonly PaymentMethodUsage Withdrawals = new(Values.Withdrawals);

    public static readonly PaymentMethodUsage PayOutFunding = new(Values.PayOutFunding);

    public static readonly PaymentMethodUsage Refunds = new(Values.Refunds);

    public static readonly PaymentMethodUsage Returns = new(Values.Returns);

    public PaymentMethodUsage(string value)
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
    public static PaymentMethodUsage FromCustom(string value)
    {
        return new PaymentMethodUsage(value);
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

    public static bool operator ==(PaymentMethodUsage value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PaymentMethodUsage value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PaymentMethodUsage value) => value.Value;

    public static explicit operator PaymentMethodUsage(string value) => new(value);

    internal class PaymentMethodUsageSerializer : JsonConverter<PaymentMethodUsage>
    {
        public override PaymentMethodUsage Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new PaymentMethodUsage(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PaymentMethodUsage value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PaymentMethodUsage ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new PaymentMethodUsage(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PaymentMethodUsage value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Deposits = "deposits";

        public const string Billing = "billing";

        public const string Withdrawals = "withdrawals";

        public const string PayOutFunding = "payOutFunding";

        public const string Refunds = "refunds";

        public const string Returns = "returns";
    }
}
