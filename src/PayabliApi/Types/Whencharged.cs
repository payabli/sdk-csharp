using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(Whencharged.WhenchargedSerializer))]
[Serializable]
public readonly record struct Whencharged : IStringEnum
{
    public static readonly Whencharged WhenServiceProvided = new(Values.WhenServiceProvided);

    public static readonly Whencharged InAdvance = new(Values.InAdvance);

    public Whencharged(string value)
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
    public static Whencharged FromCustom(string value)
    {
        return new Whencharged(value);
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

    public static bool operator ==(Whencharged value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Whencharged value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Whencharged value) => value.Value;

    public static explicit operator Whencharged(string value) => new(value);

    internal class WhenchargedSerializer : JsonConverter<Whencharged>
    {
        public override Whencharged Read(
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
            return new Whencharged(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Whencharged value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Whencharged ReadAsPropertyName(
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
            return new Whencharged(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Whencharged value,
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
        public const string WhenServiceProvided = "When Service Provided";

        public const string InAdvance = "In Advance";
    }
}
