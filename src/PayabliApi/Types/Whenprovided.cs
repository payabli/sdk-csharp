using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(Whenprovided.WhenprovidedSerializer))]
[Serializable]
public readonly record struct Whenprovided : IStringEnum
{
    public static readonly Whenprovided ThirtyDaysOrLess = new(Values.ThirtyDaysOrLess);

    public static readonly Whenprovided ThirtyOneTo60Days = new(Values.ThirtyOneTo60Days);

    public static readonly Whenprovided SixtyDays = new(Values.SixtyDays);

    public Whenprovided(string value)
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
    public static Whenprovided FromCustom(string value)
    {
        return new Whenprovided(value);
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

    public static bool operator ==(Whenprovided value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Whenprovided value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Whenprovided value) => value.Value;

    public static explicit operator Whenprovided(string value) => new(value);

    internal class WhenprovidedSerializer : JsonConverter<Whenprovided>
    {
        public override Whenprovided Read(
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
            return new Whenprovided(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Whenprovided value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Whenprovided ReadAsPropertyName(
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
            return new Whenprovided(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Whenprovided value,
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
        public const string ThirtyDaysOrLess = "30 Days or Less";

        public const string ThirtyOneTo60Days = "31 to 60 Days";

        public const string SixtyDays = "60+ Days";
    }
}
