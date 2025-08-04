using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<VendorDataResponsePaymentMethod>))]
[Serializable]
public readonly record struct VendorDataResponsePaymentMethod : IStringEnum
{
    public static readonly VendorDataResponsePaymentMethod Vcard = new(Values.Vcard);

    public static readonly VendorDataResponsePaymentMethod Ach = new(Values.Ach);

    public static readonly VendorDataResponsePaymentMethod Check = new(Values.Check);

    public static readonly VendorDataResponsePaymentMethod Card = new(Values.Card);

    public VendorDataResponsePaymentMethod(string value)
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
    public static VendorDataResponsePaymentMethod FromCustom(string value)
    {
        return new VendorDataResponsePaymentMethod(value);
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

    public static bool operator ==(VendorDataResponsePaymentMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(VendorDataResponsePaymentMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(VendorDataResponsePaymentMethod value) => value.Value;

    public static explicit operator VendorDataResponsePaymentMethod(string value) => new(value);

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
    }
}
