using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(DocumentSubjectType.DocumentSubjectTypeSerializer))]
[Serializable]
public readonly record struct DocumentSubjectType : IStringEnum
{
    public static readonly DocumentSubjectType Business = new(Values.Business);

    public static readonly DocumentSubjectType Paypoint = new(Values.Paypoint);

    public static readonly DocumentSubjectType Person = new(Values.Person);

    public DocumentSubjectType(string value)
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
    public static DocumentSubjectType FromCustom(string value)
    {
        return new DocumentSubjectType(value);
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

    public static bool operator ==(DocumentSubjectType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DocumentSubjectType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DocumentSubjectType value) => value.Value;

    public static explicit operator DocumentSubjectType(string value) => new(value);

    internal class DocumentSubjectTypeSerializer : JsonConverter<DocumentSubjectType>
    {
        public override DocumentSubjectType Read(
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
            return new DocumentSubjectType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DocumentSubjectType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DocumentSubjectType ReadAsPropertyName(
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
            return new DocumentSubjectType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DocumentSubjectType value,
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
        public const string Business = "business";

        public const string Paypoint = "paypoint";

        public const string Person = "person";
    }
}
