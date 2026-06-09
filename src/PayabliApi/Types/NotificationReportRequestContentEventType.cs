using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(
    typeof(NotificationReportRequestContentEventType.NotificationReportRequestContentEventTypeSerializer)
)]
[Serializable]
public readonly record struct NotificationReportRequestContentEventType : IStringEnum
{
    public static readonly NotificationReportRequestContentEventType Report = new(Values.Report);

    public NotificationReportRequestContentEventType(string value)
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
    public static NotificationReportRequestContentEventType FromCustom(string value)
    {
        return new NotificationReportRequestContentEventType(value);
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
        NotificationReportRequestContentEventType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        NotificationReportRequestContentEventType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(NotificationReportRequestContentEventType value) =>
        value.Value;

    public static explicit operator NotificationReportRequestContentEventType(string value) =>
        new(value);

    internal class NotificationReportRequestContentEventTypeSerializer
        : JsonConverter<NotificationReportRequestContentEventType>
    {
        public override NotificationReportRequestContentEventType Read(
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
            return new NotificationReportRequestContentEventType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            NotificationReportRequestContentEventType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override NotificationReportRequestContentEventType ReadAsPropertyName(
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
            return new NotificationReportRequestContentEventType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            NotificationReportRequestContentEventType value,
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
        public const string Report = "Report";
    }
}
