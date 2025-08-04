using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<BillDataPaymentTerms>))]
[Serializable]
public readonly record struct BillDataPaymentTerms : IStringEnum
{
    public static readonly BillDataPaymentTerms Pia = new(Values.Pia);

    public static readonly BillDataPaymentTerms Cia = new(Values.Cia);

    public static readonly BillDataPaymentTerms Ur = new(Values.Ur);

    public static readonly BillDataPaymentTerms Net10 = new(Values.Net10);

    public static readonly BillDataPaymentTerms Net20 = new(Values.Net20);

    public static readonly BillDataPaymentTerms Net30 = new(Values.Net30);

    public static readonly BillDataPaymentTerms Net45 = new(Values.Net45);

    public static readonly BillDataPaymentTerms Net60 = new(Values.Net60);

    public static readonly BillDataPaymentTerms Net90 = new(Values.Net90);

    public static readonly BillDataPaymentTerms Eom = new(Values.Eom);

    public static readonly BillDataPaymentTerms Mfi = new(Values.Mfi);

    public static readonly BillDataPaymentTerms FiveMfi = new(Values.FiveMfi);

    public static readonly BillDataPaymentTerms TenMfi = new(Values.TenMfi);

    public static readonly BillDataPaymentTerms FifteenMfi = new(Values.FifteenMfi);

    public static readonly BillDataPaymentTerms TwentyMfi = new(Values.TwentyMfi);

    public static readonly BillDataPaymentTerms Two10Net30 = new(Values.Two10Net30);

    public static readonly BillDataPaymentTerms Uf = new(Values.Uf);

    public static readonly BillDataPaymentTerms TenUf = new(Values.TenUf);

    public static readonly BillDataPaymentTerms TwentyUf = new(Values.TwentyUf);

    public static readonly BillDataPaymentTerms TwentyFiveUf = new(Values.TwentyFiveUf);

    public static readonly BillDataPaymentTerms FiftyUf = new(Values.FiftyUf);

    public BillDataPaymentTerms(string value)
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
    public static BillDataPaymentTerms FromCustom(string value)
    {
        return new BillDataPaymentTerms(value);
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

    public static bool operator ==(BillDataPaymentTerms value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BillDataPaymentTerms value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BillDataPaymentTerms value) => value.Value;

    public static explicit operator BillDataPaymentTerms(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Pia = "PIA";

        public const string Cia = "CIA";

        public const string Ur = "UR";

        public const string Net10 = "NET10";

        public const string Net20 = "NET20";

        public const string Net30 = "NET30";

        public const string Net45 = "NET45";

        public const string Net60 = "NET60";

        public const string Net90 = "NET90";

        public const string Eom = "EOM";

        public const string Mfi = "MFI";

        public const string FiveMfi = "5MFI";

        public const string TenMfi = "10MFI";

        public const string FifteenMfi = "15MFI";

        public const string TwentyMfi = "20MFI";

        public const string Two10Net30 = "2/10NET30";

        public const string Uf = "UF";

        public const string TenUf = "10UF";

        public const string TwentyUf = "20UF";

        public const string TwentyFiveUf = "25UF";

        public const string FiftyUf = "50UF";
    }
}
