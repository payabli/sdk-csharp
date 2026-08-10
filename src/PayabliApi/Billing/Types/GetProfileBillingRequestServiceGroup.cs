using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(
    typeof(GetProfileBillingRequestServiceGroup.GetProfileBillingRequestServiceGroupSerializer)
)]
[Serializable]
public readonly record struct GetProfileBillingRequestServiceGroup : IStringEnum
{
    public static readonly GetProfileBillingRequestServiceGroup PayIn = new(Values.PayIn);

    public static readonly GetProfileBillingRequestServiceGroup PayOut = new(Values.PayOut);

    public GetProfileBillingRequestServiceGroup(string value)
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
    public static GetProfileBillingRequestServiceGroup FromCustom(string value)
    {
        return new GetProfileBillingRequestServiceGroup(value);
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

    public static bool operator ==(GetProfileBillingRequestServiceGroup value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetProfileBillingRequestServiceGroup value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetProfileBillingRequestServiceGroup value) =>
        value.Value;

    public static explicit operator GetProfileBillingRequestServiceGroup(string value) =>
        new(value);

    internal class GetProfileBillingRequestServiceGroupSerializer
        : JsonConverter<GetProfileBillingRequestServiceGroup>
    {
        public override GetProfileBillingRequestServiceGroup Read(
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
            return new GetProfileBillingRequestServiceGroup(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetProfileBillingRequestServiceGroup value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetProfileBillingRequestServiceGroup ReadAsPropertyName(
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
            return new GetProfileBillingRequestServiceGroup(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetProfileBillingRequestServiceGroup value,
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
        public const string PayIn = "PayIn";

        public const string PayOut = "PayOut";
    }
}
