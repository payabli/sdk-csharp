using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(
    typeof(NotificationReportRequestFrequency.NotificationReportRequestFrequencySerializer)
)]
[Serializable]
public readonly record struct NotificationReportRequestFrequency : IStringEnum
{
    public static readonly NotificationReportRequestFrequency OneTime = new(Values.OneTime);

    public static readonly NotificationReportRequestFrequency Daily = new(Values.Daily);

    public static readonly NotificationReportRequestFrequency Weekly = new(Values.Weekly);

    public static readonly NotificationReportRequestFrequency Biweekly = new(Values.Biweekly);

    public static readonly NotificationReportRequestFrequency Monthly = new(Values.Monthly);

    public static readonly NotificationReportRequestFrequency Quarterly = new(Values.Quarterly);

    public static readonly NotificationReportRequestFrequency Semiannually = new(
        Values.Semiannually
    );

    public static readonly NotificationReportRequestFrequency Annually = new(Values.Annually);

    public NotificationReportRequestFrequency(string value)
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
    public static NotificationReportRequestFrequency FromCustom(string value)
    {
        return new NotificationReportRequestFrequency(value);
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

    public static bool operator ==(NotificationReportRequestFrequency value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(NotificationReportRequestFrequency value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(NotificationReportRequestFrequency value) => value.Value;

    public static explicit operator NotificationReportRequestFrequency(string value) => new(value);

    internal class NotificationReportRequestFrequencySerializer
        : JsonConverter<NotificationReportRequestFrequency>
    {
        public override NotificationReportRequestFrequency Read(
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
            return new NotificationReportRequestFrequency(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            NotificationReportRequestFrequency value,
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
        public const string OneTime = "one-time";

        public const string Daily = "daily";

        public const string Weekly = "weekly";

        public const string Biweekly = "biweekly";

        public const string Monthly = "monthly";

        public const string Quarterly = "quarterly";

        public const string Semiannually = "semiannually";

        public const string Annually = "annually";
    }
}
