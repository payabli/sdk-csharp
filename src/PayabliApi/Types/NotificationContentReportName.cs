using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(NotificationContentReportName.NotificationContentReportNameSerializer))]
[Serializable]
public readonly record struct NotificationContentReportName : IStringEnum
{
    public static readonly NotificationContentReportName Transaction = new(Values.Transaction);

    public static readonly NotificationContentReportName Settlement = new(Values.Settlement);

    public static readonly NotificationContentReportName Boarding = new(Values.Boarding);

    public static readonly NotificationContentReportName Returned = new(Values.Returned);

    public NotificationContentReportName(string value)
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
    public static NotificationContentReportName FromCustom(string value)
    {
        return new NotificationContentReportName(value);
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

    public static bool operator ==(NotificationContentReportName value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(NotificationContentReportName value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(NotificationContentReportName value) => value.Value;

    public static explicit operator NotificationContentReportName(string value) => new(value);

    internal class NotificationContentReportNameSerializer
        : JsonConverter<NotificationContentReportName>
    {
        public override NotificationContentReportName Read(
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
            return new NotificationContentReportName(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            NotificationContentReportName value,
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
        public const string Transaction = "Transaction";

        public const string Settlement = "Settlement";

        public const string Boarding = "Boarding";

        public const string Returned = "Returned";
    }
}
