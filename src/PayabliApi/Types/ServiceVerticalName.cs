using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(ServiceVerticalName.ServiceVerticalNameSerializer))]
[Serializable]
public readonly record struct ServiceVerticalName : IStringEnum
{
    public static readonly ServiceVerticalName PayIn = new(Values.PayIn);

    public static readonly ServiceVerticalName PayOut = new(Values.PayOut);

    public static readonly ServiceVerticalName PayOps = new(Values.PayOps);

    public ServiceVerticalName(string value)
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
    public static ServiceVerticalName FromCustom(string value)
    {
        return new ServiceVerticalName(value);
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

    public static bool operator ==(ServiceVerticalName value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ServiceVerticalName value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ServiceVerticalName value) => value.Value;

    public static explicit operator ServiceVerticalName(string value) => new(value);

    internal class ServiceVerticalNameSerializer : JsonConverter<ServiceVerticalName>
    {
        public override ServiceVerticalName Read(
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
            return new ServiceVerticalName(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ServiceVerticalName value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ServiceVerticalName ReadAsPropertyName(
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
            return new ServiceVerticalName(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ServiceVerticalName value,
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
        public const string PayIn = "PayIn";

        public const string PayOut = "PayOut";

        public const string PayOps = "PayOps";
    }
}
