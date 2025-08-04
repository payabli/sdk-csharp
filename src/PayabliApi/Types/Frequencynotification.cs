using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<Frequencynotification>))]
[Serializable]
public readonly record struct Frequencynotification : IStringEnum
{
    public static readonly Frequencynotification OneTime = new(Values.OneTime);

    public static readonly Frequencynotification Daily = new(Values.Daily);

    public static readonly Frequencynotification Weekly = new(Values.Weekly);

    public static readonly Frequencynotification Biweekly = new(Values.Biweekly);

    public static readonly Frequencynotification Monthly = new(Values.Monthly);

    public static readonly Frequencynotification Quarterly = new(Values.Quarterly);

    public static readonly Frequencynotification Semiannually = new(Values.Semiannually);

    public static readonly Frequencynotification Annually = new(Values.Annually);

    public static readonly Frequencynotification Untilcancelled = new(Values.Untilcancelled);

    public Frequencynotification(string value)
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
    public static Frequencynotification FromCustom(string value)
    {
        return new Frequencynotification(value);
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

    public static bool operator ==(Frequencynotification value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Frequencynotification value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Frequencynotification value) => value.Value;

    public static explicit operator Frequencynotification(string value) => new(value);

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

        public const string Untilcancelled = "untilcancelled";
    }
}
