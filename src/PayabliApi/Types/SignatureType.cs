using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(SignatureType.SignatureTypeSerializer))]
[Serializable]
public readonly record struct SignatureType : IStringEnum
{
    public static readonly SignatureType Type = new(Values.Type);

    public static readonly SignatureType Draw = new(Values.Draw);

    public static readonly SignatureType Checkbox = new(Values.Checkbox);

    public SignatureType(string value)
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
    public static SignatureType FromCustom(string value)
    {
        return new SignatureType(value);
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

    public static bool operator ==(SignatureType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SignatureType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SignatureType value) => value.Value;

    public static explicit operator SignatureType(string value) => new(value);

    internal class SignatureTypeSerializer : JsonConverter<SignatureType>
    {
        public override SignatureType Read(
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
            return new SignatureType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SignatureType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SignatureType ReadAsPropertyName(
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
            return new SignatureType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SignatureType value,
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
        public const string Type = "type";

        public const string Draw = "draw";

        public const string Checkbox = "checkbox";
    }
}
