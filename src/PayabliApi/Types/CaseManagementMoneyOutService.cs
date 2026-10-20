using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(CaseManagementMoneyOutService.CaseManagementMoneyOutServiceSerializer))]
[Serializable]
public readonly record struct CaseManagementMoneyOutService : IStringEnum
{
    public static readonly CaseManagementMoneyOutService Ach = new(Values.Ach);

    public static readonly CaseManagementMoneyOutService VCard = new(Values.VCard);

    public static readonly CaseManagementMoneyOutService Managed = new(Values.Managed);

    public static readonly CaseManagementMoneyOutService Check = new(Values.Check);

    public static readonly CaseManagementMoneyOutService Rtp = new(Values.Rtp);

    public static readonly CaseManagementMoneyOutService Wire = new(Values.Wire);

    public static readonly CaseManagementMoneyOutService Ghost = new(Values.Ghost);

    public CaseManagementMoneyOutService(string value)
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
    public static CaseManagementMoneyOutService FromCustom(string value)
    {
        return new CaseManagementMoneyOutService(value);
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

    public static bool operator ==(CaseManagementMoneyOutService value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CaseManagementMoneyOutService value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CaseManagementMoneyOutService value) => value.Value;

    public static explicit operator CaseManagementMoneyOutService(string value) => new(value);

    internal class CaseManagementMoneyOutServiceSerializer
        : JsonConverter<CaseManagementMoneyOutService>
    {
        public override CaseManagementMoneyOutService Read(
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
            return new CaseManagementMoneyOutService(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CaseManagementMoneyOutService value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CaseManagementMoneyOutService ReadAsPropertyName(
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
            return new CaseManagementMoneyOutService(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CaseManagementMoneyOutService value,
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
        public const string Ach = "Ach";

        public const string VCard = "VCard";

        public const string Managed = "Managed";

        public const string Check = "Check";

        public const string Rtp = "Rtp";

        public const string Wire = "Wire";

        public const string Ghost = "Ghost";
    }
}
