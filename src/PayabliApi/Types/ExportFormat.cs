using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(ExportFormat.ExportFormatSerializer))]
[Serializable]
public readonly record struct ExportFormat : IStringEnum
{
    /// <summary>
    /// Comma-separated values file
    /// </summary>
    public static readonly ExportFormat Csv = new(Values.Csv);

    /// <summary>
    /// Excel spreadsheet file
    /// </summary>
    public static readonly ExportFormat Xlsx = new(Values.Xlsx);

    public ExportFormat(string value)
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
    public static ExportFormat FromCustom(string value)
    {
        return new ExportFormat(value);
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

    public static bool operator ==(ExportFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ExportFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ExportFormat value) => value.Value;

    public static explicit operator ExportFormat(string value) => new(value);

    internal class ExportFormatSerializer : JsonConverter<ExportFormat>
    {
        public override ExportFormat Read(
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
            return new ExportFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ExportFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ExportFormat ReadAsPropertyName(
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
            return new ExportFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ExportFormat value,
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
        /// <summary>
        /// Comma-separated values file
        /// </summary>
        public const string Csv = "csv";

        /// <summary>
        /// Excel spreadsheet file
        /// </summary>
        public const string Xlsx = "xlsx";
    }
}
