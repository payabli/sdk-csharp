using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(MoneyInService.MoneyInServiceSerializer))]
[Serializable]
public readonly record struct MoneyInService : IStringEnum
{
    public static readonly MoneyInService Ach = new(Values.Ach);

    public static readonly MoneyInService Card = new(Values.Card);

    public static readonly MoneyInService Cloud = new(Values.Cloud);

    public static readonly MoneyInService Device = new(Values.Device);

    public static readonly MoneyInService Wallet = new(Values.Wallet);

    public static readonly MoneyInService Cash = new(Values.Cash);

    public static readonly MoneyInService Check = new(Values.Check);

    public MoneyInService(string value)
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
    public static MoneyInService FromCustom(string value)
    {
        return new MoneyInService(value);
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

    public static bool operator ==(MoneyInService value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MoneyInService value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MoneyInService value) => value.Value;

    public static explicit operator MoneyInService(string value) => new(value);

    internal class MoneyInServiceSerializer : JsonConverter<MoneyInService>
    {
        public override MoneyInService Read(
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
            return new MoneyInService(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MoneyInService value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MoneyInService ReadAsPropertyName(
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
            return new MoneyInService(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MoneyInService value,
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

        public const string Card = "Card";

        public const string Cloud = "Cloud";

        public const string Device = "Device";

        public const string Wallet = "Wallet";

        public const string Cash = "Cash";

        public const string Check = "Check";
    }
}
