using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(
    typeof(UpdateBusinessRequestOperatingSeasonsItem.UpdateBusinessRequestOperatingSeasonsItemSerializer)
)]
[Serializable]
public readonly record struct UpdateBusinessRequestOperatingSeasonsItem : IStringEnum
{
    public static readonly UpdateBusinessRequestOperatingSeasonsItem Spring = new(Values.Spring);

    public static readonly UpdateBusinessRequestOperatingSeasonsItem Summer = new(Values.Summer);

    public static readonly UpdateBusinessRequestOperatingSeasonsItem Fall = new(Values.Fall);

    public static readonly UpdateBusinessRequestOperatingSeasonsItem Winter = new(Values.Winter);

    public UpdateBusinessRequestOperatingSeasonsItem(string value)
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
    public static UpdateBusinessRequestOperatingSeasonsItem FromCustom(string value)
    {
        return new UpdateBusinessRequestOperatingSeasonsItem(value);
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
        UpdateBusinessRequestOperatingSeasonsItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdateBusinessRequestOperatingSeasonsItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(UpdateBusinessRequestOperatingSeasonsItem value) =>
        value.Value;

    public static explicit operator UpdateBusinessRequestOperatingSeasonsItem(string value) =>
        new(value);

    internal class UpdateBusinessRequestOperatingSeasonsItemSerializer
        : JsonConverter<UpdateBusinessRequestOperatingSeasonsItem>
    {
        public override UpdateBusinessRequestOperatingSeasonsItem Read(
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
            return new UpdateBusinessRequestOperatingSeasonsItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateBusinessRequestOperatingSeasonsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateBusinessRequestOperatingSeasonsItem ReadAsPropertyName(
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
            return new UpdateBusinessRequestOperatingSeasonsItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateBusinessRequestOperatingSeasonsItem value,
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
