using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(
    typeof(NotificationStandardRequestMethod.NotificationStandardRequestMethodSerializer)
)]
[Serializable]
public readonly record struct NotificationStandardRequestMethod : IStringEnum
{
    public static readonly NotificationStandardRequestMethod Email = new(Values.Email);

    public static readonly NotificationStandardRequestMethod Sms = new(Values.Sms);

    public static readonly NotificationStandardRequestMethod Web = new(Values.Web);

    public NotificationStandardRequestMethod(string value)
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
    public static NotificationStandardRequestMethod FromCustom(string value)
    {
        return new NotificationStandardRequestMethod(value);
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

    public static bool operator ==(NotificationStandardRequestMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(NotificationStandardRequestMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(NotificationStandardRequestMethod value) => value.Value;

    public static explicit operator NotificationStandardRequestMethod(string value) => new(value);

    internal class NotificationStandardRequestMethodSerializer
        : JsonConverter<NotificationStandardRequestMethod>
    {
        public override NotificationStandardRequestMethod Read(
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
            return new NotificationStandardRequestMethod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            NotificationStandardRequestMethod value,
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
        public const string Email = "email";

        public const string Sms = "sms";

        public const string Web = "web";
    }
}
