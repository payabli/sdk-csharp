using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(CaseType.CaseTypeSerializer))]
[Serializable]
public readonly record struct CaseType : IStringEnum
{
    public static readonly CaseType BankAccountChange = new(Values.BankAccountChange);

    public CaseType(string value)
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
    public static CaseType FromCustom(string value)
    {
        return new CaseType(value);
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

    public static bool operator ==(CaseType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(CaseType value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(CaseType value) => value.Value;

    public static explicit operator CaseType(string value) => new(value);

    internal class CaseTypeSerializer : JsonConverter<CaseType>
    {
        public override CaseType Read(
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
            return new CaseType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CaseType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CaseType ReadAsPropertyName(
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
            return new CaseType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CaseType value,
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
