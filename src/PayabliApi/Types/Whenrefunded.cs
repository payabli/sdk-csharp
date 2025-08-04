using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<Whenrefunded>))]
[Serializable]
public readonly record struct Whenrefunded : IStringEnum
{
    public static readonly Whenrefunded ExchangeOnly = new(Values.ExchangeOnly);

    public static readonly Whenrefunded NoRefundOrExchange = new(Values.NoRefundOrExchange);

    public static readonly Whenrefunded MoreThan30Days = new(Values.MoreThan30Days);

    public static readonly Whenrefunded ThirtyDaysOrLess = new(Values.ThirtyDaysOrLess);

    public Whenrefunded(string value)
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
    public static Whenrefunded FromCustom(string value)
    {
        return new Whenrefunded(value);
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

    public static bool operator ==(Whenrefunded value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Whenrefunded value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Whenrefunded value) => value.Value;

    public static explicit operator Whenrefunded(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string ExchangeOnly = "Exchange Only";

        public const string NoRefundOrExchange = "No Refund or Exchange";

        public const string MoreThan30Days = "More than 30 days";

        public const string ThirtyDaysOrLess = "30 Days or Less";
    }
}
