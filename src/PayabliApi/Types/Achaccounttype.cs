using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<Achaccounttype>))]
[Serializable]
public readonly record struct Achaccounttype : IStringEnum
{
    public static readonly Achaccounttype Checking = new(Values.Checking);

    public static readonly Achaccounttype Savings = new(Values.Savings);

    public Achaccounttype(string value)
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
    public static Achaccounttype FromCustom(string value)
    {
        return new Achaccounttype(value);
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

    public static bool operator ==(Achaccounttype value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Achaccounttype value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Achaccounttype value) => value.Value;

    public static explicit operator Achaccounttype(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Checking = "Checking";

        public const string Savings = "Savings";
    }
}
