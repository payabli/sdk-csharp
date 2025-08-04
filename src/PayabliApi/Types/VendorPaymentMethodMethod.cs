using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<VendorPaymentMethodMethod>))]
[Serializable]
public readonly record struct VendorPaymentMethodMethod : IStringEnum
{
    public static readonly VendorPaymentMethodMethod Managed = new(Values.Managed);

    public static readonly VendorPaymentMethodMethod Vcard = new(Values.Vcard);

    public static readonly VendorPaymentMethodMethod Ach = new(Values.Ach);

    public static readonly VendorPaymentMethodMethod Check = new(Values.Check);

    public VendorPaymentMethodMethod(string value)
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
    public static VendorPaymentMethodMethod FromCustom(string value)
    {
        return new VendorPaymentMethodMethod(value);
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

    public static bool operator ==(VendorPaymentMethodMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(VendorPaymentMethodMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(VendorPaymentMethodMethod value) => value.Value;

    public static explicit operator VendorPaymentMethodMethod(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Managed = "managed";

        public const string Vcard = "vcard";

        public const string Ach = "ach";

        public const string Check = "check";
    }
}
