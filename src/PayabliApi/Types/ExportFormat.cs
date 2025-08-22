using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<ExportFormat>))]
[Serializable]
public readonly record struct ExportFormat : IStringEnum
{
    /// <summary>
    /// Comma-separated values file
    /// </summary>
    public static readonly ExportFormat Csv = new(Values.Csv);

    /// <summary>
    /// Excel spreadsheet file
    /// </summary>
    public static readonly ExportFormat Xlsx = new(Values.Xlsx);

    public ExportFormat(string value)
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
    public static ExportFormat FromCustom(string value)
    {
        return new ExportFormat(value);
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

    public static bool operator ==(ExportFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ExportFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ExportFormat value) => value.Value;

    public static explicit operator ExportFormat(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        /// <summary>
        /// Comma-separated values file
        /// </summary>
        public const string Csv = "csv";

        /// <summary>
        /// Excel spreadsheet file
        /// </summary>
        public const string Xlsx = "xlsx";
    }
}
