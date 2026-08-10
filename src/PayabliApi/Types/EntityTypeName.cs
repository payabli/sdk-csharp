using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(EntityTypeName.EntityTypeNameSerializer))]
[Serializable]
public readonly record struct EntityTypeName : IStringEnum
{
    public static readonly EntityTypeName Organization = new(Values.Organization);

    public static readonly EntityTypeName Paypoint = new(Values.Paypoint);

    public static readonly EntityTypeName Customer = new(Values.Customer);

    public static readonly EntityTypeName Template = new(Values.Template);

    public static readonly EntityTypeName Application = new(Values.Application);

    public static readonly EntityTypeName BankAccount = new(Values.BankAccount);

    public static readonly EntityTypeName Address = new(Values.Address);

    public EntityTypeName(string value)
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
    public static EntityTypeName FromCustom(string value)
    {
        return new EntityTypeName(value);
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

    public static bool operator ==(EntityTypeName value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EntityTypeName value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EntityTypeName value) => value.Value;

    public static explicit operator EntityTypeName(string value) => new(value);

    internal class EntityTypeNameSerializer : JsonConverter<EntityTypeName>
    {
        public override EntityTypeName Read(
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
            return new EntityTypeName(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EntityTypeName value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EntityTypeName ReadAsPropertyName(
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
            return new EntityTypeName(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EntityTypeName value,
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

        public const string Customer = "Customer";

        public const string Template = "Template";

        public const string Application = "Application";

        public const string BankAccount = "BankAccount";

        public const string Address = "Address";
    }
}
