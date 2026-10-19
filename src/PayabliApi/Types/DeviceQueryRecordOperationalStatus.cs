using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(
    typeof(DeviceQueryRecordOperationalStatus.DeviceQueryRecordOperationalStatusSerializer)
)]
[Serializable]
public readonly record struct DeviceQueryRecordOperationalStatus : IStringEnum
{
    public static readonly DeviceQueryRecordOperationalStatus Online = new(Values.Online);

    public static readonly DeviceQueryRecordOperationalStatus Busy = new(Values.Busy);

    public static readonly DeviceQueryRecordOperationalStatus Offline = new(Values.Offline);

    public DeviceQueryRecordOperationalStatus(string value)
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
    public static DeviceQueryRecordOperationalStatus FromCustom(string value)
    {
        return new DeviceQueryRecordOperationalStatus(value);
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

    public static bool operator ==(DeviceQueryRecordOperationalStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DeviceQueryRecordOperationalStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DeviceQueryRecordOperationalStatus value) => value.Value;

    public static explicit operator DeviceQueryRecordOperationalStatus(string value) => new(value);

    internal class DeviceQueryRecordOperationalStatusSerializer
        : JsonConverter<DeviceQueryRecordOperationalStatus>
    {
        public override DeviceQueryRecordOperationalStatus Read(
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
            return new DeviceQueryRecordOperationalStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DeviceQueryRecordOperationalStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DeviceQueryRecordOperationalStatus ReadAsPropertyName(
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
            return new DeviceQueryRecordOperationalStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DeviceQueryRecordOperationalStatus value,
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
        public const string Online = "online";

        public const string Busy = "busy";

        public const string Offline = "offline";
    }
}
