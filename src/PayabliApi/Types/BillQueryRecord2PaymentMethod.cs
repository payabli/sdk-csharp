using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<BillQueryRecord2PaymentMethod>))]
[Serializable]
public readonly record struct BillQueryRecord2PaymentMethod : IStringEnum
{
    public static readonly BillQueryRecord2PaymentMethod Vcard = new(Values.Vcard);

    public static readonly BillQueryRecord2PaymentMethod Ach = new(Values.Ach);

    public static readonly BillQueryRecord2PaymentMethod Check = new(Values.Check);

    public static readonly BillQueryRecord2PaymentMethod Card = new(Values.Card);

    public static readonly BillQueryRecord2PaymentMethod Managed = new(Values.Managed);

    public BillQueryRecord2PaymentMethod(string value)
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
    public static BillQueryRecord2PaymentMethod FromCustom(string value)
    {
        return new BillQueryRecord2PaymentMethod(value);
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

    public static bool operator ==(BillQueryRecord2PaymentMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BillQueryRecord2PaymentMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BillQueryRecord2PaymentMethod value) => value.Value;

    public static explicit operator BillQueryRecord2PaymentMethod(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Vcard = "vcard";

        public const string Ach = "ach";

        public const string Check = "check";

        public const string Card = "card";

        public const string Managed = "managed";
    }
}
