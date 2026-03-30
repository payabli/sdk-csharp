using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(VendorDataResponsePaymentMethod.VendorDataResponsePaymentMethodSerializer))]
[Serializable]
public readonly record struct VendorDataResponsePaymentMethod : IStringEnum
{
    public static readonly VendorDataResponsePaymentMethod Vcard = new(Values.Vcard);

    public static readonly VendorDataResponsePaymentMethod Ach = new(Values.Ach);

    public static readonly VendorDataResponsePaymentMethod Check = new(Values.Check);

    public static readonly VendorDataResponsePaymentMethod Card = new(Values.Card);

    public VendorDataResponsePaymentMethod(string value)
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
    public static VendorDataResponsePaymentMethod FromCustom(string value)
    {
        return new VendorDataResponsePaymentMethod(value);
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

    public static bool operator ==(VendorDataResponsePaymentMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(VendorDataResponsePaymentMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(VendorDataResponsePaymentMethod value) => value.Value;

    public static explicit operator VendorDataResponsePaymentMethod(string value) => new(value);

    internal class VendorDataResponsePaymentMethodSerializer
        : JsonConverter<VendorDataResponsePaymentMethod>
    {
        public override VendorDataResponsePaymentMethod Read(
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
            return new VendorDataResponsePaymentMethod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            VendorDataResponsePaymentMethod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override VendorDataResponsePaymentMethod ReadAsPropertyName(
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
            return new VendorDataResponsePaymentMethod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            VendorDataResponsePaymentMethod value,
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
        public const string Vcard = "vcard";

        public const string Ach = "ach";

        public const string Check = "check";

        public const string Card = "card";
    }
}
