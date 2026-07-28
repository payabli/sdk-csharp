using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(MoneyOutService.MoneyOutServiceSerializer))]
[Serializable]
public readonly record struct MoneyOutService : IStringEnum
{
    public static readonly MoneyOutService Ach = new(Values.Ach);

    public static readonly MoneyOutService VCard = new(Values.VCard);

    public static readonly MoneyOutService Managed = new(Values.Managed);

    public static readonly MoneyOutService Check = new(Values.Check);

    public static readonly MoneyOutService Rtp = new(Values.Rtp);

    public static readonly MoneyOutService Wire = new(Values.Wire);

    public static readonly MoneyOutService Ghost = new(Values.Ghost);

    public MoneyOutService(string value)
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
    public static MoneyOutService FromCustom(string value)
    {
        return new MoneyOutService(value);
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

    public static bool operator ==(MoneyOutService value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MoneyOutService value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MoneyOutService value) => value.Value;

    public static explicit operator MoneyOutService(string value) => new(value);

    internal class MoneyOutServiceSerializer : JsonConverter<MoneyOutService>
    {
        public override MoneyOutService Read(
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
            return new MoneyOutService(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MoneyOutService value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MoneyOutService ReadAsPropertyName(
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
            return new MoneyOutService(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MoneyOutService value,
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
        public const string Ach = "Ach";

        public const string VCard = "VCard";

        public const string Managed = "Managed";

        public const string Check = "Check";

        public const string Rtp = "Rtp";

        public const string Wire = "Wire";

        public const string Ghost = "Ghost";
    }
}
