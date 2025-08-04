using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<NotificationReportRequestContentReportName>))]
[Serializable]
public readonly record struct NotificationReportRequestContentReportName : IStringEnum
{
    public static readonly NotificationReportRequestContentReportName Transaction = new(
        Values.Transaction
    );

    public static readonly NotificationReportRequestContentReportName Settlement = new(
        Values.Settlement
    );

    public static readonly NotificationReportRequestContentReportName Boarding = new(
        Values.Boarding
    );

    public static readonly NotificationReportRequestContentReportName Returned = new(
        Values.Returned
    );

    public NotificationReportRequestContentReportName(string value)
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
    public static NotificationReportRequestContentReportName FromCustom(string value)
    {
        return new NotificationReportRequestContentReportName(value);
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
        NotificationReportRequestContentReportName value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        NotificationReportRequestContentReportName value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(NotificationReportRequestContentReportName value) =>
        value.Value;

    public static explicit operator NotificationReportRequestContentReportName(string value) =>
        new(value);

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
