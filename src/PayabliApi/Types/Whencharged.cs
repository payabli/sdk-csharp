using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<Whencharged>))]
[Serializable]
public readonly record struct Whencharged : IStringEnum
{
    public static readonly Whencharged WhenServiceProvided = new(Values.WhenServiceProvided);

    public static readonly Whencharged InAdvance = new(Values.InAdvance);

    public Whencharged(string value)
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
    public static Whencharged FromCustom(string value)
    {
        return new Whencharged(value);
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

    public static bool operator ==(Whencharged value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Whencharged value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Whencharged value) => value.Value;

    public static explicit operator Whencharged(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string WhenServiceProvided = "When Service Provided";

        public const string InAdvance = "In Advance";
    }
}
