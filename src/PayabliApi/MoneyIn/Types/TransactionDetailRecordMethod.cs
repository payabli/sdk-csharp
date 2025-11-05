using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<TransactionDetailRecordMethod>))]
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
