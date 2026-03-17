using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(ExportFormat1.ExportFormat1Serializer))]
[Serializable]
public readonly record struct ExportFormat1 : IStringEnum
{
    public static readonly ExportFormat1 Csv = new(Values.Csv);

    public static readonly ExportFormat1 Xlsx = new(Values.Xlsx);

    public ExportFormat1(string value)
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
    public static ExportFormat1 FromCustom(string value)
    {
        return new ExportFormat1(value);
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

    public static bool operator ==(ExportFormat1 value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ExportFormat1 value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ExportFormat1 value) => value.Value;

    public static explicit operator ExportFormat1(string value) => new(value);

    internal class ExportFormat1Serializer : JsonConverter<ExportFormat1>
    {
        public override ExportFormat1 Read(
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
            return new ExportFormat1(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ExportFormat1 value,
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
        public const string Csv = "csv";

        public const string Xlsx = "xlsx";
    }
}
