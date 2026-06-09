using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(Terms.TermsSerializer))]
[Serializable]
public readonly record struct Terms : IStringEnum
{
    /// <summary>
    /// Payment in advance.
    /// </summary>
    public static readonly Terms Pia = new(Values.Pia);

    /// <summary>
    /// Cash in advance.
    /// </summary>
    public static readonly Terms Cia = new(Values.Cia);

    /// <summary>
    /// Upon receipt.
    /// </summary>
    public static readonly Terms Ur = new(Values.Ur);

    /// <summary>
    /// 10 days after invoice date.
    /// </summary>
    public static readonly Terms Net10 = new(Values.Net10);

    /// <summary>
    /// 20 days after invoice date.
    /// </summary>
    public static readonly Terms Net20 = new(Values.Net20);

    /// <summary>
    /// 30 days after invoice date.
    /// </summary>
    public static readonly Terms Net30 = new(Values.Net30);

    /// <summary>
    /// 45 days after invoice date.
    /// </summary>
    public static readonly Terms Net45 = new(Values.Net45);

    /// <summary>
    /// 60 days after invoice date.
    /// </summary>
    public static readonly Terms Net60 = new(Values.Net60);

    /// <summary>
    /// 90 days after invoice date.
    /// </summary>
    public static readonly Terms Net90 = new(Values.Net90);

    /// <summary>
    /// Due end of this month.
    /// </summary>
    public static readonly Terms Eom = new(Values.Eom);

    /// <summary>
    /// 1st of the month following the invoice date.
    /// </summary>
    public static readonly Terms Mfi = new(Values.Mfi);

    /// <summary>
    /// 5th of the month following the invoice date.
    /// </summary>
    public static readonly Terms FiveMfi = new(Values.FiveMfi);

    /// <summary>
    /// 10th of the month following the invoice date.
    /// </summary>
    public static readonly Terms TenMfi = new(Values.TenMfi);

    /// <summary>
    /// 15th of the month following the invoice date.
    /// </summary>
    public static readonly Terms FifteenMfi = new(Values.FifteenMfi);

    /// <summary>
    /// 20th of the month following the invoice date.
    /// </summary>
    public static readonly Terms TwentyMfi = new(Values.TwentyMfi);

    /// <summary>
    /// 2% discount if paid within 10 days, otherwise net 30.
    /// </summary>
    public static readonly Terms Two10Net30 = new(Values.Two10Net30);

    /// <summary>
    /// Under fixed terms.
    /// </summary>
    public static readonly Terms Uf = new(Values.Uf);

    /// <summary>
    /// 10 day grace period under EOM.
    /// </summary>
    public static readonly Terms TenUf = new(Values.TenUf);

    /// <summary>
    /// 20 day grace period under EOM.
    /// </summary>
    public static readonly Terms TwentyUf = new(Values.TwentyUf);

    /// <summary>
    /// 25 day grace period under EOM.
    /// </summary>
    public static readonly Terms TwentyFiveUf = new(Values.TwentyFiveUf);

    /// <summary>
    /// 50 day grace period under EOM.
    /// </summary>
    public static readonly Terms FiftyUf = new(Values.FiftyUf);

    public Terms(string value)
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
    public static Terms FromCustom(string value)
    {
        return new Terms(value);
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

    public static bool operator ==(Terms value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Terms value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(Terms value) => value.Value;

    public static explicit operator Terms(string value) => new(value);

    internal class TermsSerializer : JsonConverter<Terms>
    {
        public override Terms Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new Terms(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Terms value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Terms ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new Terms(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Terms value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        /// <summary>
        /// Payment in advance.
        /// </summary>
        public const string Pia = "PIA";

        /// <summary>
        /// Cash in advance.
        /// </summary>
        public const string Cia = "CIA";

        /// <summary>
        /// Upon receipt.
        /// </summary>
        public const string Ur = "UR";

        /// <summary>
        /// 10 days after invoice date.
        /// </summary>
        public const string Net10 = "NET10";

        /// <summary>
        /// 20 days after invoice date.
        /// </summary>
        public const string Net20 = "NET20";

        /// <summary>
        /// 30 days after invoice date.
        /// </summary>
        public const string Net30 = "NET30";

        /// <summary>
        /// 45 days after invoice date.
        /// </summary>
        public const string Net45 = "NET45";

        /// <summary>
        /// 60 days after invoice date.
        /// </summary>
        public const string Net60 = "NET60";

        /// <summary>
        /// 90 days after invoice date.
        /// </summary>
        public const string Net90 = "NET90";

        /// <summary>
        /// Due end of this month.
        /// </summary>
        public const string Eom = "EOM";

        /// <summary>
        /// 1st of the month following the invoice date.
        /// </summary>
        public const string Mfi = "MFI";

        /// <summary>
        /// 5th of the month following the invoice date.
        /// </summary>
        public const string FiveMfi = "5MFI";

        /// <summary>
        /// 10th of the month following the invoice date.
        /// </summary>
        public const string TenMfi = "10MFI";

        /// <summary>
        /// 15th of the month following the invoice date.
        /// </summary>
        public const string FifteenMfi = "15MFI";

        /// <summary>
        /// 20th of the month following the invoice date.
        /// </summary>
        public const string TwentyMfi = "20MFI";

        /// <summary>
        /// 2% discount if paid within 10 days, otherwise net 30.
        /// </summary>
        public const string Two10Net30 = "2/10NET30";

        /// <summary>
        /// Under fixed terms.
        /// </summary>
        public const string Uf = "UF";

        /// <summary>
        /// 10 day grace period under EOM.
        /// </summary>
        public const string TenUf = "10UF";

        /// <summary>
        /// 20 day grace period under EOM.
        /// </summary>
        public const string TwentyUf = "20UF";

        /// <summary>
        /// 25 day grace period under EOM.
        /// </summary>
        public const string TwentyFiveUf = "25UF";

        /// <summary>
        /// 50 day grace period under EOM.
        /// </summary>
        public const string FiftyUf = "50UF";
    }
}
