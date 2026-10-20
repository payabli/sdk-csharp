using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(
    typeof(UpdateBusinessRequestLegalStructure.UpdateBusinessRequestLegalStructureSerializer)
)]
[Serializable]
public readonly record struct UpdateBusinessRequestLegalStructure : IStringEnum
{
    public static readonly UpdateBusinessRequestLegalStructure LimitedLiabilityCompany = new(
        Values.LimitedLiabilityCompany
    );

    public static readonly UpdateBusinessRequestLegalStructure Llc = new(Values.Llc);

    public static readonly UpdateBusinessRequestLegalStructure Corporation = new(
        Values.Corporation
    );

    public static readonly UpdateBusinessRequestLegalStructure Partnership = new(
        Values.Partnership
    );

    public static readonly UpdateBusinessRequestLegalStructure SoleProprietorship = new(
        Values.SoleProprietorship
    );

    public static readonly UpdateBusinessRequestLegalStructure NonProfit = new(Values.NonProfit);

    public static readonly UpdateBusinessRequestLegalStructure Government = new(Values.Government);

    public static readonly UpdateBusinessRequestLegalStructure SCorp = new(Values.SCorp);

    public static readonly UpdateBusinessRequestLegalStructure SCorporation = new(
        Values.SCorporation
    );

    public UpdateBusinessRequestLegalStructure(string value)
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
    public static UpdateBusinessRequestLegalStructure FromCustom(string value)
    {
        return new UpdateBusinessRequestLegalStructure(value);
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

    public static bool operator ==(UpdateBusinessRequestLegalStructure value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateBusinessRequestLegalStructure value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateBusinessRequestLegalStructure value) =>
        value.Value;

    public static explicit operator UpdateBusinessRequestLegalStructure(string value) => new(value);

    internal class UpdateBusinessRequestLegalStructureSerializer
        : JsonConverter<UpdateBusinessRequestLegalStructure>
    {
        public override UpdateBusinessRequestLegalStructure Read(
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
            return new UpdateBusinessRequestLegalStructure(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateBusinessRequestLegalStructure value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateBusinessRequestLegalStructure ReadAsPropertyName(
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
            return new UpdateBusinessRequestLegalStructure(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateBusinessRequestLegalStructure value,
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
