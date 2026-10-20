using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(TemplateStatus.TemplateStatusSerializer))]
[Serializable]
public readonly record struct TemplateStatus : IStringEnum
{
    public static readonly TemplateStatus Active = new(Values.Active);

    public static readonly TemplateStatus Archived = new(Values.Archived);

    public TemplateStatus(string value)
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
    public static TemplateStatus FromCustom(string value)
    {
        return new TemplateStatus(value);
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

    public static bool operator ==(TemplateStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TemplateStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TemplateStatus value) => value.Value;

    public static explicit operator TemplateStatus(string value) => new(value);

    internal class TemplateStatusSerializer : JsonConverter<TemplateStatus>
    {
        public override TemplateStatus Read(
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
            return new TemplateStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TemplateStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TemplateStatus ReadAsPropertyName(
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
            return new TemplateStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TemplateStatus value,
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
        public const string Active = "active";

        public const string Archived = "archived";
    }
}
