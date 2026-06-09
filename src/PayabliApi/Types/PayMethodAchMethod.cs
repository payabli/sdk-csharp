using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(PayMethodAchMethod.PayMethodAchMethodSerializer))]
[Serializable]
public readonly record struct PayMethodAchMethod : IStringEnum
{
    public static readonly PayMethodAchMethod Ach = new(Values.Ach);

    public PayMethodAchMethod(string value)
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
    public static PayMethodAchMethod FromCustom(string value)
    {
        return new PayMethodAchMethod(value);
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

    public static bool operator ==(PayMethodAchMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PayMethodAchMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PayMethodAchMethod value) => value.Value;

    public static explicit operator PayMethodAchMethod(string value) => new(value);

    internal class PayMethodAchMethodSerializer : JsonConverter<PayMethodAchMethod>
    {
        public override PayMethodAchMethod Read(
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
            return new PayMethodAchMethod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PayMethodAchMethod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PayMethodAchMethod ReadAsPropertyName(
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
            return new PayMethodAchMethod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PayMethodAchMethod value,
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
        public const string Ach = "ach";
    }
}
