using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(AllowedCheckPaymentStatus.AllowedCheckPaymentStatusSerializer))]
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

    internal class AllowedCheckPaymentStatusSerializer : JsonConverter<AllowedCheckPaymentStatus>
    {
        public override AllowedCheckPaymentStatus Read(
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
            return new AllowedCheckPaymentStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AllowedCheckPaymentStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AllowedCheckPaymentStatus ReadAsPropertyName(
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
            return new AllowedCheckPaymentStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AllowedCheckPaymentStatus value,
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
        public const string Cancelled = "0";

        public const string Paid = "5";
    }
}
