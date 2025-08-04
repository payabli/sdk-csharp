using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<BoardingProcessingRegion>))]
[Serializable]
public readonly record struct BoardingProcessingRegion : IStringEnum
{
    public static readonly BoardingProcessingRegion Us = new(Values.Us);

    public static readonly BoardingProcessingRegion Ca = new(Values.Ca);

    public BoardingProcessingRegion(string value)
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
    public static BoardingProcessingRegion FromCustom(string value)
    {
        return new BoardingProcessingRegion(value);
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

    public static bool operator ==(BoardingProcessingRegion value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BoardingProcessingRegion value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BoardingProcessingRegion value) => value.Value;

    public static explicit operator BoardingProcessingRegion(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Us = "US";

        public const string Ca = "CA";
    }
}
