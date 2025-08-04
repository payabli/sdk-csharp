using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<Whendelivered>))]
[Serializable]
public readonly record struct Whendelivered : IStringEnum
{
    public static readonly Whendelivered Zero7Days = new(Values.Zero7Days);

    public static readonly Whendelivered Eight14Days = new(Values.Eight14Days);

    public static readonly Whendelivered Fifteen30Days = new(Values.Fifteen30Days);

    public static readonly Whendelivered Over30Days = new(Values.Over30Days);

    public Whendelivered(string value)
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
    public static Whendelivered FromCustom(string value)
    {
        return new Whendelivered(value);
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

    public static bool operator ==(Whendelivered value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Whendelivered value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Whendelivered value) => value.Value;

    public static explicit operator Whendelivered(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Zero7Days = "0-7 Days";

        public const string Eight14Days = "8-14 Days";

        public const string Fifteen30Days = "15-30 Days";

        public const string Over30Days = "Over 30 Days";
    }
}
