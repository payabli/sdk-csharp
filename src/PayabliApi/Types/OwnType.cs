using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<OwnType>))]
[Serializable]
public readonly record struct OwnType : IStringEnum
{
    public static readonly OwnType LimitedLiabilityCompany = new(Values.LimitedLiabilityCompany);

    public static readonly OwnType NonProfitOrg = new(Values.NonProfitOrg);

    public static readonly OwnType Partnership = new(Values.Partnership);

    public static readonly OwnType PrivateCorp = new(Values.PrivateCorp);

    public static readonly OwnType PublicCorp = new(Values.PublicCorp);

    public static readonly OwnType TaxExempt = new(Values.TaxExempt);

    public static readonly OwnType Government = new(Values.Government);

    public static readonly OwnType SoleProprietor = new(Values.SoleProprietor);

    public OwnType(string value)
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
    public static OwnType FromCustom(string value)
    {
        return new OwnType(value);
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

    public static bool operator ==(OwnType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(OwnType value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(OwnType value) => value.Value;

    public static explicit operator OwnType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string LimitedLiabilityCompany = "Limited Liability Company";

        public const string NonProfitOrg = "Non-Profit Org";

        public const string Partnership = "Partnership";

        public const string PrivateCorp = "Private Corp";

        public const string PublicCorp = "Public Corp";

        public const string TaxExempt = "Tax Exempt";

        public const string Government = "Government";

        public const string SoleProprietor = "Sole Proprietor";
    }
}
