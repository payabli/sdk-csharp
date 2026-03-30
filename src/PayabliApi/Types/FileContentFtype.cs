using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(FileContentFtype.FileContentFtypeSerializer))]
[Serializable]
public readonly record struct FileContentFtype : IStringEnum
{
    public static readonly FileContentFtype Pdf = new(Values.Pdf);

    public static readonly FileContentFtype Doc = new(Values.Doc);

    public static readonly FileContentFtype Docx = new(Values.Docx);

    public static readonly FileContentFtype Jpg = new(Values.Jpg);

    public static readonly FileContentFtype Jpeg = new(Values.Jpeg);

    public static readonly FileContentFtype Png = new(Values.Png);

    public static readonly FileContentFtype Gif = new(Values.Gif);

    public static readonly FileContentFtype Txt = new(Values.Txt);

    public FileContentFtype(string value)
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
    public static FileContentFtype FromCustom(string value)
    {
        return new FileContentFtype(value);
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

    public static bool operator ==(FileContentFtype value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FileContentFtype value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FileContentFtype value) => value.Value;

    public static explicit operator FileContentFtype(string value) => new(value);

    internal class FileContentFtypeSerializer : JsonConverter<FileContentFtype>
    {
        public override FileContentFtype Read(
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
            return new FileContentFtype(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FileContentFtype value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FileContentFtype ReadAsPropertyName(
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
            return new FileContentFtype(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FileContentFtype value,
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
        public const string Pdf = "pdf";

        public const string Doc = "doc";

        public const string Docx = "docx";

        public const string Jpg = "jpg";

        public const string Jpeg = "jpeg";

        public const string Png = "png";

        public const string Gif = "gif";

        public const string Txt = "txt";
    }
}
