using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(DocumentRequirementSource.DocumentRequirementSourceSerializer))]
[Serializable]
public readonly record struct DocumentRequirementSource : IStringEnum
{
    public static readonly DocumentRequirementSource Template = new(Values.Template);

    public static readonly DocumentRequirementSource BusinessRule = new(Values.BusinessRule);

    public DocumentRequirementSource(string value)
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
    public static DocumentRequirementSource FromCustom(string value)
    {
        return new DocumentRequirementSource(value);
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

    public static bool operator ==(DocumentRequirementSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DocumentRequirementSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DocumentRequirementSource value) => value.Value;

    public static explicit operator DocumentRequirementSource(string value) => new(value);

    internal class DocumentRequirementSourceSerializer : JsonConverter<DocumentRequirementSource>
    {
        public override DocumentRequirementSource Read(
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
            return new DocumentRequirementSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DocumentRequirementSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DocumentRequirementSource ReadAsPropertyName(
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
            return new DocumentRequirementSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DocumentRequirementSource value,
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
        public const string Template = "template";

        public const string BusinessRule = "businessRule";
    }
}
