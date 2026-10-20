using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(
    typeof(CreateBusinessRequestOperatingSeasonsItem.CreateBusinessRequestOperatingSeasonsItemSerializer)
)]
[Serializable]
public readonly record struct CreateBusinessRequestOperatingSeasonsItem : IStringEnum
{
    public static readonly CreateBusinessRequestOperatingSeasonsItem Spring = new(Values.Spring);

    public static readonly CreateBusinessRequestOperatingSeasonsItem Summer = new(Values.Summer);

    public static readonly CreateBusinessRequestOperatingSeasonsItem Fall = new(Values.Fall);

    public static readonly CreateBusinessRequestOperatingSeasonsItem Winter = new(Values.Winter);

    public CreateBusinessRequestOperatingSeasonsItem(string value)
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
    public static CreateBusinessRequestOperatingSeasonsItem FromCustom(string value)
    {
        return new CreateBusinessRequestOperatingSeasonsItem(value);
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

    public static bool operator ==(
        CreateBusinessRequestOperatingSeasonsItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateBusinessRequestOperatingSeasonsItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateBusinessRequestOperatingSeasonsItem value) =>
        value.Value;

    public static explicit operator CreateBusinessRequestOperatingSeasonsItem(string value) =>
        new(value);

    internal class CreateBusinessRequestOperatingSeasonsItemSerializer
        : JsonConverter<CreateBusinessRequestOperatingSeasonsItem>
    {
        public override CreateBusinessRequestOperatingSeasonsItem Read(
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
            return new CreateBusinessRequestOperatingSeasonsItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateBusinessRequestOperatingSeasonsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateBusinessRequestOperatingSeasonsItem ReadAsPropertyName(
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
            return new CreateBusinessRequestOperatingSeasonsItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateBusinessRequestOperatingSeasonsItem value,
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
        public const string Spring = "Spring";

        public const string Summer = "Summer";

        public const string Fall = "Fall";

        public const string Winter = "Winter";
    }
}
