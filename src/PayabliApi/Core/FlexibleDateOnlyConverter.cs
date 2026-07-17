using global::System.Globalization;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace PayabliApi.Core
{
    /// <summary>
    /// Lenient <see cref="DateOnly"/> converter. Some Payabli API responses mix ISO 8601
    /// (<c>yyyy-MM-dd</c>) with legacy <c>MM-dd-yyyy</c> date strings for different fields on the
    /// same object (e.g. <c>BillDetailsResponse.invoiceDate</c> vs. <c>dueDate</c>). The default
    /// System.Text.Json <see cref="DateOnly"/> converter only accepts ISO 8601 and throws on the
    /// legacy format. This converter tries the known formats before falling back to
    /// culture-invariant free parsing.
    /// </summary>
    internal sealed class FlexibleDateOnlyConverter : JsonConverter<DateOnly>
    {
        private static readonly string[] SupportedFormats = { "yyyy-MM-dd", "MM-dd-yyyy" };

        public override DateOnly Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var value = reader.GetString();
            if (string.IsNullOrEmpty(value))
            {
                throw new JsonException("Expected a non-empty DateOnly string.");
            }

            if (
                DateOnly.TryParseExact(
                    value,
                    SupportedFormats,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var exact
                )
            )
            {
                return exact;
            }

            if (DateOnly.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.None, out var fallback))
            {
                return fallback;
            }

            throw new JsonException($"The JSON value '{value}' is not in a supported DateOnly format.");
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
        }
    }
}
