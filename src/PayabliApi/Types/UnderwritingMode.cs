using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(UnderwritingMode.UnderwritingModeSerializer))]
[Serializable]
public readonly record struct UnderwritingMode : IStringEnum
{
    public static readonly UnderwritingMode Automatic = new(Values.Automatic);

    public static readonly UnderwritingMode Manual = new(Values.Manual);

    public static readonly UnderwritingMode Bypass = new(Values.Bypass);

    public UnderwritingMode(string value)
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
    public static UnderwritingMode FromCustom(string value)
    {
        return new UnderwritingMode(value);
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

    public static bool operator ==(UnderwritingMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UnderwritingMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UnderwritingMode value) => value.Value;

    public static explicit operator UnderwritingMode(string value) => new(value);

    internal class UnderwritingModeSerializer : JsonConverter<UnderwritingMode>
    {
        public override UnderwritingMode Read(
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
            return new UnderwritingMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UnderwritingMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UnderwritingMode ReadAsPropertyName(
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
            return new UnderwritingMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UnderwritingMode value,
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
        public const string Automatic = "automatic";

        public const string Manual = "manual";

        public const string Bypass = "bypass";
    }
}
