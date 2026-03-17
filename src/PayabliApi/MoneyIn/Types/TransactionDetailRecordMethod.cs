using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(TransactionDetailRecordMethod.TransactionDetailRecordMethodSerializer))]
[Serializable]
public readonly record struct TransactionDetailRecordMethod : IStringEnum
{
    public static readonly TransactionDetailRecordMethod Ach = new(Values.Ach);

    public static readonly TransactionDetailRecordMethod Card = new(Values.Card);

    public TransactionDetailRecordMethod(string value)
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
    public static TransactionDetailRecordMethod FromCustom(string value)
    {
        return new TransactionDetailRecordMethod(value);
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

    public static bool operator ==(TransactionDetailRecordMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TransactionDetailRecordMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TransactionDetailRecordMethod value) => value.Value;

    public static explicit operator TransactionDetailRecordMethod(string value) => new(value);

    internal class TransactionDetailRecordMethodSerializer
        : JsonConverter<TransactionDetailRecordMethod>
    {
        public override TransactionDetailRecordMethod Read(
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
            return new TransactionDetailRecordMethod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TransactionDetailRecordMethod value,
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
        public const string Ach = "ach";

        public const string Card = "card";
    }
}
