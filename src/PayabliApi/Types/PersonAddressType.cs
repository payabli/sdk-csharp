using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(PersonAddressType.PersonAddressTypeSerializer))]
[Serializable]
public readonly record struct PersonAddressType : IStringEnum
{
    public static readonly PersonAddressType Legal = new(Values.Legal);

    public static readonly PersonAddressType Billing = new(Values.Billing);

    public static readonly PersonAddressType Shipping = new(Values.Shipping);

    public static readonly PersonAddressType Remittance = new(Values.Remittance);

    public static readonly PersonAddressType Mailing = new(Values.Mailing);

    public static readonly PersonAddressType Physical = new(Values.Physical);

    public static readonly PersonAddressType Residential = new(Values.Residential);

    public PersonAddressType(string value)
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
    public static PersonAddressType FromCustom(string value)
    {
        return new PersonAddressType(value);
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

    public static bool operator ==(PersonAddressType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PersonAddressType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PersonAddressType value) => value.Value;

    public static explicit operator PersonAddressType(string value) => new(value);

    internal class PersonAddressTypeSerializer : JsonConverter<PersonAddressType>
    {
        public override PersonAddressType Read(
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
            return new PersonAddressType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PersonAddressType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PersonAddressType ReadAsPropertyName(
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
            return new PersonAddressType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PersonAddressType value,
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
        public const string Legal = "legal";

        public const string Billing = "billing";

        public const string Shipping = "shipping";

        public const string Remittance = "remittance";

        public const string Mailing = "mailing";

        public const string Physical = "physical";

        public const string Residential = "residential";
    }
}
