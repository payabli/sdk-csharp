using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(AchHolderType.AchHolderTypeSerializer))]
[Serializable]
public readonly record struct AchHolderType : IStringEnum
{
    public static readonly AchHolderType Personal = new(Values.Personal);

    public static readonly AchHolderType Business = new(Values.Business);

    public AchHolderType(string value)
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
    public static AchHolderType FromCustom(string value)
    {
        return new AchHolderType(value);
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

    public static bool operator ==(AchHolderType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AchHolderType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AchHolderType value) => value.Value;

    public static explicit operator AchHolderType(string value) => new(value);

    internal class AchHolderTypeSerializer : JsonConverter<AchHolderType>
    {
        public override AchHolderType Read(
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
            return new AchHolderType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AchHolderType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Personal = "personal";

        public const string Business = "business";
    }
}
