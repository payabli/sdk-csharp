using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(NotificationContentFileFormat.NotificationContentFileFormatSerializer))]
[Serializable]
public readonly record struct NotificationContentFileFormat : IStringEnum
{
    public static readonly NotificationContentFileFormat Json = new(Values.Json);

    public static readonly NotificationContentFileFormat Csv = new(Values.Csv);

    public static readonly NotificationContentFileFormat Xlsx = new(Values.Xlsx);

    public NotificationContentFileFormat(string value)
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
    public static NotificationContentFileFormat FromCustom(string value)
    {
        return new NotificationContentFileFormat(value);
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

    public static bool operator ==(NotificationContentFileFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(NotificationContentFileFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(NotificationContentFileFormat value) => value.Value;

    public static explicit operator NotificationContentFileFormat(string value) => new(value);

    internal class NotificationContentFileFormatSerializer
        : JsonConverter<NotificationContentFileFormat>
    {
        public override NotificationContentFileFormat Read(
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
            return new NotificationContentFileFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            NotificationContentFileFormat value,
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
        public const string Json = "json";

        public const string Csv = "csv";

        public const string Xlsx = "xlsx";
    }
}
