using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(BankAccountChangeParametersType.BankAccountChangeParametersTypeSerializer))]
[Serializable]
public readonly record struct BankAccountChangeParametersType : IStringEnum
{
    public static readonly BankAccountChangeParametersType BankAccountChange = new(
        Values.BankAccountChange
    );

    public BankAccountChangeParametersType(string value)
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
    public static BankAccountChangeParametersType FromCustom(string value)
    {
        return new BankAccountChangeParametersType(value);
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

    public static bool operator ==(BankAccountChangeParametersType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BankAccountChangeParametersType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BankAccountChangeParametersType value) => value.Value;

    public static explicit operator BankAccountChangeParametersType(string value) => new(value);

    internal class BankAccountChangeParametersTypeSerializer
        : JsonConverter<BankAccountChangeParametersType>
    {
        public override BankAccountChangeParametersType Read(
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
            return new BankAccountChangeParametersType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BankAccountChangeParametersType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BankAccountChangeParametersType ReadAsPropertyName(
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
            return new BankAccountChangeParametersType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BankAccountChangeParametersType value,
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
        public const string BankAccountChange = "BankAccountChange";
    }
}
