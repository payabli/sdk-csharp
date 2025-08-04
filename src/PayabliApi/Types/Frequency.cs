using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<Frequency>))]
[Serializable]
public readonly record struct Frequency : IStringEnum
{
    public static readonly Frequency OneTime = new(Values.OneTime);

    public static readonly Frequency Weekly = new(Values.Weekly);

    public static readonly Frequency Every2Weeks = new(Values.Every2Weeks);

    public static readonly Frequency Every6Months = new(Values.Every6Months);

    public static readonly Frequency Monthly = new(Values.Monthly);

    public static readonly Frequency Every3Months = new(Values.Every3Months);

    public static readonly Frequency Annually = new(Values.Annually);

    public Frequency(string value)
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
    public static Frequency FromCustom(string value)
    {
        return new Frequency(value);
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

    public static bool operator ==(Frequency value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Frequency value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(Frequency value) => value.Value;

    public static explicit operator Frequency(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string OneTime = "one-time";

        public const string Weekly = "weekly";

        public const string Every2Weeks = "every2weeks";

        public const string Every6Months = "every6months";

        public const string Monthly = "monthly";

        public const string Every3Months = "every3months";

        public const string Annually = "annually";
    }
}
