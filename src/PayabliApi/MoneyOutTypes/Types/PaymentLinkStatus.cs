using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<PaymentLinkStatus>))]
[Serializable]
public readonly record struct PaymentLinkStatus : IStringEnum
{
    public static readonly PaymentLinkStatus Active = new(Values.Active);

    public static readonly PaymentLinkStatus Expired = new(Values.Expired);

    public static readonly PaymentLinkStatus Canceled = new(Values.Canceled);

    public static readonly PaymentLinkStatus Deleted = new(Values.Deleted);

    public PaymentLinkStatus(string value)
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
    public static PaymentLinkStatus FromCustom(string value)
    {
        return new PaymentLinkStatus(value);
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

    public static bool operator ==(PaymentLinkStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PaymentLinkStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PaymentLinkStatus value) => value.Value;

    public static explicit operator PaymentLinkStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Active = "Active";

        public const string Expired = "Expired";

        public const string Canceled = "Canceled";

        public const string Deleted = "Deleted";
    }
}
