using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<NotificationReportRequestContentFileFormat>))]
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
