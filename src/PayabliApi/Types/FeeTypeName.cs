using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(FeeTypeName.FeeTypeNameSerializer))]
[Serializable]
public readonly record struct FeeTypeName : IStringEnum
{
    public static readonly FeeTypeName Flat = new(Values.Flat);

    public static readonly FeeTypeName Icp = new(Values.Icp);

    public FeeTypeName(string value)
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
    public static FeeTypeName FromCustom(string value)
    {
        return new FeeTypeName(value);
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

    public static bool operator ==(FeeTypeName value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FeeTypeName value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FeeTypeName value) => value.Value;

    public static explicit operator FeeTypeName(string value) => new(value);

    internal class FeeTypeNameSerializer : JsonConverter<FeeTypeName>
    {
        public override FeeTypeName Read(
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
            return new FeeTypeName(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FeeTypeName value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FeeTypeName ReadAsPropertyName(
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
            return new FeeTypeName(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FeeTypeName value,
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
        public const string Flat = "Flat";

        public const string Icp = "ICP";
    }
}
