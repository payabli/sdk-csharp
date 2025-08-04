using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<Methodall>))]
[Serializable]
public readonly record struct Methodall : IStringEnum
{
    public static readonly Methodall Card = new(Values.Card);

    public static readonly Methodall Ach = new(Values.Ach);

    public static readonly Methodall Cloud = new(Values.Cloud);

    public static readonly Methodall Check = new(Values.Check);

    public static readonly Methodall Cash = new(Values.Cash);

    public Methodall(string value)
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
    public static Methodall FromCustom(string value)
    {
        return new Methodall(value);
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

    public static bool operator ==(Methodall value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Methodall value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(Methodall value) => value.Value;

    public static explicit operator Methodall(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Card = "card";

        public const string Ach = "ach";

        public const string Cloud = "cloud";

        public const string Check = "check";

        public const string Cash = "cash";
    }
}
