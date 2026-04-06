using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(
    typeof(NotificationReportRequestContentFileFormat.NotificationReportRequestContentFileFormatSerializer)
)]
[Serializable]
public readonly record struct NotificationReportRequestContentFileFormat : IStringEnum
{
    public static readonly NotificationReportRequestContentFileFormat Json = new(Values.Json);

    public static readonly NotificationReportRequestContentFileFormat Csv = new(Values.Csv);

    public static readonly NotificationReportRequestContentFileFormat Xlsx = new(Values.Xlsx);

    public NotificationReportRequestContentFileFormat(string value)
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
    public static NotificationReportRequestContentFileFormat FromCustom(string value)
    {
        return new NotificationReportRequestContentFileFormat(value);
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

    public static bool operator ==(
        NotificationReportRequestContentFileFormat value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        NotificationReportRequestContentFileFormat value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(NotificationReportRequestContentFileFormat value) =>
        value.Value;

    public static explicit operator NotificationReportRequestContentFileFormat(string value) =>
        new(value);

    internal class NotificationReportRequestContentFileFormatSerializer
        : JsonConverter<NotificationReportRequestContentFileFormat>
    {
        public override NotificationReportRequestContentFileFormat Read(
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
            return new NotificationReportRequestContentFileFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            NotificationReportRequestContentFileFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override NotificationReportRequestContentFileFormat ReadAsPropertyName(
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
            return new NotificationReportRequestContentFileFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            NotificationReportRequestContentFileFormat value,
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
        public const string Json = "json";

        public const string Csv = "csv";

        public const string Xlsx = "xlsx";
    }
}
