using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(CaseManagementMoneyInService.CaseManagementMoneyInServiceSerializer))]
[Serializable]
public readonly record struct CaseManagementMoneyInService : IStringEnum
{
    public static readonly CaseManagementMoneyInService Ach = new(Values.Ach);

    public static readonly CaseManagementMoneyInService Card = new(Values.Card);

    public static readonly CaseManagementMoneyInService Cloud = new(Values.Cloud);

    public static readonly CaseManagementMoneyInService Device = new(Values.Device);

    public static readonly CaseManagementMoneyInService Wallet = new(Values.Wallet);

    public static readonly CaseManagementMoneyInService Cash = new(Values.Cash);

    public static readonly CaseManagementMoneyInService Check = new(Values.Check);

    public CaseManagementMoneyInService(string value)
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
    public static CaseManagementMoneyInService FromCustom(string value)
    {
        return new CaseManagementMoneyInService(value);
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

    public static bool operator ==(CaseManagementMoneyInService value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CaseManagementMoneyInService value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CaseManagementMoneyInService value) => value.Value;

    public static explicit operator CaseManagementMoneyInService(string value) => new(value);

    internal class CaseManagementMoneyInServiceSerializer
        : JsonConverter<CaseManagementMoneyInService>
    {
        public override CaseManagementMoneyInService Read(
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
            return new CaseManagementMoneyInService(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CaseManagementMoneyInService value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CaseManagementMoneyInService ReadAsPropertyName(
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
            return new CaseManagementMoneyInService(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CaseManagementMoneyInService value,
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

        public const string Card = "Card";

        public const string Cloud = "Cloud";

        public const string Device = "Device";

        public const string Wallet = "Wallet";

        public const string Cash = "Cash";

        public const string Check = "Check";
    }
}
