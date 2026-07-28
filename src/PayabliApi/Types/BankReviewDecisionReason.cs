using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(BankReviewDecisionReason.BankReviewDecisionReasonSerializer))]
[Serializable]
public readonly record struct BankReviewDecisionReason : IStringEnum
{
    public static readonly BankReviewDecisionReason CreditDecline = new(Values.CreditDecline);

    public static readonly BankReviewDecisionReason FraudDecline = new(Values.FraudDecline);

    public static readonly BankReviewDecisionReason KybKycDecline = new(Values.KybKycDecline);

    public static readonly BankReviewDecisionReason Withdrawn = new(Values.Withdrawn);

    public BankReviewDecisionReason(string value)
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
    public static BankReviewDecisionReason FromCustom(string value)
    {
        return new BankReviewDecisionReason(value);
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

    public static bool operator ==(BankReviewDecisionReason value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BankReviewDecisionReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BankReviewDecisionReason value) => value.Value;

    public static explicit operator BankReviewDecisionReason(string value) => new(value);

    internal class BankReviewDecisionReasonSerializer : JsonConverter<BankReviewDecisionReason>
    {
        public override BankReviewDecisionReason Read(
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
            return new BankReviewDecisionReason(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BankReviewDecisionReason value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BankReviewDecisionReason ReadAsPropertyName(
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
            return new BankReviewDecisionReason(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BankReviewDecisionReason value,
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
        public const string CreditDecline = "CreditDecline";

        public const string FraudDecline = "FraudDecline";

        public const string KybKycDecline = "KybKycDecline";

        public const string Withdrawn = "Withdrawn";
    }
}
