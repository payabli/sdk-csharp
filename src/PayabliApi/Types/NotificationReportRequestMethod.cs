using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(NotificationReportRequestMethod.NotificationReportRequestMethodSerializer))]
[Serializable]
public readonly record struct NotificationReportRequestMethod : IStringEnum
{
    public static readonly NotificationReportRequestMethod ReportEmail = new(Values.ReportEmail);

    public static readonly NotificationReportRequestMethod ReportWeb = new(Values.ReportWeb);

    public NotificationReportRequestMethod(string value)
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
    public static NotificationReportRequestMethod FromCustom(string value)
    {
        return new NotificationReportRequestMethod(value);
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

    public static bool operator ==(NotificationReportRequestMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(NotificationReportRequestMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(NotificationReportRequestMethod value) => value.Value;

    public static explicit operator NotificationReportRequestMethod(string value) => new(value);

    internal class NotificationReportRequestMethodSerializer
        : JsonConverter<NotificationReportRequestMethod>
    {
        public override NotificationReportRequestMethod Read(
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
            return new NotificationReportRequestMethod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            NotificationReportRequestMethod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string ReportEmail = "report-email";

        public const string ReportWeb = "report-web";
    }
}
