using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(PersonType.PersonTypeSerializer))]
[Serializable]
public readonly record struct PersonType : IStringEnum
{
    public static readonly PersonType Owner = new(Values.Owner);

    public static readonly PersonType Director = new(Values.Director);

    public static readonly PersonType Contact = new(Values.Contact);

    public static readonly PersonType Signer = new(Values.Signer);

    public static readonly PersonType AuthorizedUser = new(Values.AuthorizedUser);

    public static readonly PersonType Employee = new(Values.Employee);

    public PersonType(string value)
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
    public static PersonType FromCustom(string value)
    {
        return new PersonType(value);
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

    public static bool operator ==(PersonType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(PersonType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PersonType value) => value.Value;

    public static explicit operator PersonType(string value) => new(value);

    internal class PersonTypeSerializer : JsonConverter<PersonType>
    {
        public override PersonType Read(
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
            return new PersonType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PersonType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PersonType ReadAsPropertyName(
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
            return new PersonType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PersonType value,
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
        public const string Owner = "Owner";

        public const string Director = "Director";

        public const string Contact = "Contact";

        public const string Signer = "Signer";

        public const string AuthorizedUser = "AuthorizedUser";

        public const string Employee = "Employee";
    }
}
