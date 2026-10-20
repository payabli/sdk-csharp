using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(
    typeof(CreateBusinessRequestLegalStructure.CreateBusinessRequestLegalStructureSerializer)
)]
[Serializable]
public readonly record struct CreateBusinessRequestLegalStructure : IStringEnum
{
    public static readonly CreateBusinessRequestLegalStructure LimitedLiabilityCompany = new(
        Values.LimitedLiabilityCompany
    );

    public static readonly CreateBusinessRequestLegalStructure Llc = new(Values.Llc);

    public static readonly CreateBusinessRequestLegalStructure Corporation = new(
        Values.Corporation
    );

    public static readonly CreateBusinessRequestLegalStructure Partnership = new(
        Values.Partnership
    );

    public static readonly CreateBusinessRequestLegalStructure SoleProprietorship = new(
        Values.SoleProprietorship
    );

    public static readonly CreateBusinessRequestLegalStructure NonProfit = new(Values.NonProfit);

    public static readonly CreateBusinessRequestLegalStructure Government = new(Values.Government);

    public static readonly CreateBusinessRequestLegalStructure SCorp = new(Values.SCorp);

    public static readonly CreateBusinessRequestLegalStructure SCorporation = new(
        Values.SCorporation
    );

    public CreateBusinessRequestLegalStructure(string value)
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
    public static CreateBusinessRequestLegalStructure FromCustom(string value)
    {
        return new CreateBusinessRequestLegalStructure(value);
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

    public static bool operator ==(CreateBusinessRequestLegalStructure value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateBusinessRequestLegalStructure value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateBusinessRequestLegalStructure value) =>
        value.Value;

    public static explicit operator CreateBusinessRequestLegalStructure(string value) => new(value);

    internal class CreateBusinessRequestLegalStructureSerializer
        : JsonConverter<CreateBusinessRequestLegalStructure>
    {
        public override CreateBusinessRequestLegalStructure Read(
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
            return new CreateBusinessRequestLegalStructure(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateBusinessRequestLegalStructure value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateBusinessRequestLegalStructure ReadAsPropertyName(
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
            return new CreateBusinessRequestLegalStructure(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateBusinessRequestLegalStructure value,
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
        public const string LimitedLiabilityCompany = "limited-liability-company";

        public const string Llc = "llc";

        public const string Corporation = "corporation";

        public const string Partnership = "partnership";

        public const string SoleProprietorship = "sole-proprietorship";

        public const string NonProfit = "non-profit";

        public const string Government = "government";

        public const string SCorp = "s-corp";

        public const string SCorporation = "s-corporation";
    }
}
