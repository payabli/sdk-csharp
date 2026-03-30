using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(TypeAccount.TypeAccountSerializer))]
[Serializable]
public readonly record struct TypeAccount : IStringEnum
{
    public static readonly TypeAccount Checking = new(Values.Checking);

    public static readonly TypeAccount Savings = new(Values.Savings);

    public TypeAccount(string value)
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
    public static TypeAccount FromCustom(string value)
    {
        return new TypeAccount(value);
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

    public static bool operator ==(TypeAccount value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TypeAccount value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TypeAccount value) => value.Value;

    public static explicit operator TypeAccount(string value) => new(value);

    internal class TypeAccountSerializer : JsonConverter<TypeAccount>
    {
        public override TypeAccount Read(
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
            return new TypeAccount(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TypeAccount value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TypeAccount ReadAsPropertyName(
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
            return new TypeAccount(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TypeAccount value,
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
        public const string Checking = "Checking";

        public const string Savings = "Savings";
    }
}
