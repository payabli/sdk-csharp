using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(BusinessAddressLocation.BusinessAddressLocationSerializer))]
[Serializable]
public readonly record struct BusinessAddressLocation : IStringEnum
{
    public static readonly BusinessAddressLocation Office = new(Values.Office);

    public static readonly BusinessAddressLocation Warehouse = new(Values.Warehouse);

    public static readonly BusinessAddressLocation Retail = new(Values.Retail);

    public static readonly BusinessAddressLocation Home = new(Values.Home);

    public static readonly BusinessAddressLocation Other = new(Values.Other);

    public BusinessAddressLocation(string value)
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
    public static BusinessAddressLocation FromCustom(string value)
    {
        return new BusinessAddressLocation(value);
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

    public static bool operator ==(BusinessAddressLocation value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BusinessAddressLocation value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BusinessAddressLocation value) => value.Value;

    public static explicit operator BusinessAddressLocation(string value) => new(value);

    internal class BusinessAddressLocationSerializer : JsonConverter<BusinessAddressLocation>
    {
        public override BusinessAddressLocation Read(
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
            return new BusinessAddressLocation(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BusinessAddressLocation value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BusinessAddressLocation ReadAsPropertyName(
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
            return new BusinessAddressLocation(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BusinessAddressLocation value,
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
        public const string Office = "office";

        public const string Warehouse = "warehouse";

        public const string Retail = "retail";

        public const string Home = "home";

        public const string Other = "other";
    }
}
