using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(
    typeof(BusinessDetailResponseLegalStructure.BusinessDetailResponseLegalStructureSerializer)
)]
[Serializable]
public readonly record struct BusinessDetailResponseLegalStructure : IStringEnum
{
    public static readonly BusinessDetailResponseLegalStructure LimitedLiabilityCompany = new(
        Values.LimitedLiabilityCompany
    );

    public static readonly BusinessDetailResponseLegalStructure Corporation = new(
        Values.Corporation
    );

    public static readonly BusinessDetailResponseLegalStructure Partnership = new(
        Values.Partnership
    );

    public static readonly BusinessDetailResponseLegalStructure SoleProprietorship = new(
        Values.SoleProprietorship
    );

    public static readonly BusinessDetailResponseLegalStructure NonProfit = new(Values.NonProfit);

    public static readonly BusinessDetailResponseLegalStructure Government = new(Values.Government);

    public static readonly BusinessDetailResponseLegalStructure SCorporation = new(
        Values.SCorporation
    );

    public BusinessDetailResponseLegalStructure(string value)
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
    public static BusinessDetailResponseLegalStructure FromCustom(string value)
    {
        return new BusinessDetailResponseLegalStructure(value);
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

    public static bool operator ==(BusinessDetailResponseLegalStructure value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BusinessDetailResponseLegalStructure value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BusinessDetailResponseLegalStructure value) =>
        value.Value;

    public static explicit operator BusinessDetailResponseLegalStructure(string value) =>
        new(value);

    internal class BusinessDetailResponseLegalStructureSerializer
        : JsonConverter<BusinessDetailResponseLegalStructure>
    {
        public override BusinessDetailResponseLegalStructure Read(
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
            return new BusinessDetailResponseLegalStructure(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BusinessDetailResponseLegalStructure value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BusinessDetailResponseLegalStructure ReadAsPropertyName(
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
            return new BusinessDetailResponseLegalStructure(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BusinessDetailResponseLegalStructure value,
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
        public const string LimitedLiabilityCompany = "LimitedLiabilityCompany";

        public const string Corporation = "Corporation";

        public const string Partnership = "Partnership";

        public const string SoleProprietorship = "SoleProprietorship";

        public const string NonProfit = "NonProfit";

        public const string Government = "Government";

        public const string SCorporation = "SCorporation";
    }
}
