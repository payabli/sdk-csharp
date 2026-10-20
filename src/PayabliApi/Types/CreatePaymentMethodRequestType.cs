using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(CreatePaymentMethodRequestType.CreatePaymentMethodRequestTypeSerializer))]
[Serializable]
public readonly record struct CreatePaymentMethodRequestType : IStringEnum
{
    public static readonly CreatePaymentMethodRequestType BankAccount = new(Values.BankAccount);

    public CreatePaymentMethodRequestType(string value)
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
    public static CreatePaymentMethodRequestType FromCustom(string value)
    {
        return new CreatePaymentMethodRequestType(value);
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

    public static bool operator ==(CreatePaymentMethodRequestType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreatePaymentMethodRequestType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreatePaymentMethodRequestType value) => value.Value;

    public static explicit operator CreatePaymentMethodRequestType(string value) => new(value);

    internal class CreatePaymentMethodRequestTypeSerializer
        : JsonConverter<CreatePaymentMethodRequestType>
    {
        public override CreatePaymentMethodRequestType Read(
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
            return new CreatePaymentMethodRequestType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePaymentMethodRequestType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePaymentMethodRequestType ReadAsPropertyName(
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
            return new CreatePaymentMethodRequestType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePaymentMethodRequestType value,
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
        public const string BankAccount = "bank_account";
    }
}
