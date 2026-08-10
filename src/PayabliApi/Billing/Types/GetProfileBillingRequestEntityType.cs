using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(
    typeof(GetProfileBillingRequestEntityType.GetProfileBillingRequestEntityTypeSerializer)
)]
[Serializable]
public readonly record struct GetProfileBillingRequestEntityType : IStringEnum
{
    public static readonly GetProfileBillingRequestEntityType Organization = new(
        Values.Organization
    );

    public static readonly GetProfileBillingRequestEntityType Paypoint = new(Values.Paypoint);

    public static readonly GetProfileBillingRequestEntityType Template = new(Values.Template);

    public static readonly GetProfileBillingRequestEntityType Application = new(Values.Application);

    public GetProfileBillingRequestEntityType(string value)
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
    public static GetProfileBillingRequestEntityType FromCustom(string value)
    {
        return new GetProfileBillingRequestEntityType(value);
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

    public static bool operator ==(GetProfileBillingRequestEntityType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetProfileBillingRequestEntityType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetProfileBillingRequestEntityType value) => value.Value;

    public static explicit operator GetProfileBillingRequestEntityType(string value) => new(value);

    internal class GetProfileBillingRequestEntityTypeSerializer
        : JsonConverter<GetProfileBillingRequestEntityType>
    {
        public override GetProfileBillingRequestEntityType Read(
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
            return new GetProfileBillingRequestEntityType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetProfileBillingRequestEntityType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetProfileBillingRequestEntityType ReadAsPropertyName(
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
            return new GetProfileBillingRequestEntityType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetProfileBillingRequestEntityType value,
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
        public const string Organization = "Organization";

        public const string Paypoint = "Paypoint";

        public const string Template = "Template";

        public const string Application = "Application";
    }
}
