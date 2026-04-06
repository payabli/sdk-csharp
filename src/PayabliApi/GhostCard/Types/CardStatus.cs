using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(CardStatus.CardStatusSerializer))]
[Serializable]
public readonly record struct CardStatus : IStringEnum
{
    public static readonly CardStatus Active = new(Values.Active);

    public static readonly CardStatus Inactive = new(Values.Inactive);

    public static readonly CardStatus Cancelled = new(Values.Cancelled);

    public static readonly CardStatus Expired = new(Values.Expired);

    public CardStatus(string value)
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
    public static CardStatus FromCustom(string value)
    {
        return new CardStatus(value);
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

    public static bool operator ==(CardStatus value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(CardStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CardStatus value) => value.Value;

    public static explicit operator CardStatus(string value) => new(value);

    internal class CardStatusSerializer : JsonConverter<CardStatus>
    {
        public override CardStatus Read(
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
            return new CardStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CardStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CardStatus ReadAsPropertyName(
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
            return new CardStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CardStatus value,
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
        public const string Active = "Active";

        public const string Inactive = "Inactive";

        public const string Cancelled = "Cancelled";

        public const string Expired = "Expired";
    }
}
