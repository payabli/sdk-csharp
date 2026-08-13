using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(
    typeof(QueryPayoutTransactionRecordsItemAllowedActionsItem.QueryPayoutTransactionRecordsItemAllowedActionsItemSerializer)
)]
[Serializable]
public readonly record struct QueryPayoutTransactionRecordsItemAllowedActionsItem : IStringEnum
{
    public static readonly QueryPayoutTransactionRecordsItemAllowedActionsItem Capture = new(
        Values.Capture
    );

    public static readonly QueryPayoutTransactionRecordsItemAllowedActionsItem Cancel = new(
        Values.Cancel
    );

    public static readonly QueryPayoutTransactionRecordsItemAllowedActionsItem Reissue = new(
        Values.Reissue
    );

    public QueryPayoutTransactionRecordsItemAllowedActionsItem(string value)
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
    public static QueryPayoutTransactionRecordsItemAllowedActionsItem FromCustom(string value)
    {
        return new QueryPayoutTransactionRecordsItemAllowedActionsItem(value);
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
        QueryPayoutTransactionRecordsItemAllowedActionsItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        QueryPayoutTransactionRecordsItemAllowedActionsItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        QueryPayoutTransactionRecordsItemAllowedActionsItem value
    ) => value.Value;

    public static explicit operator QueryPayoutTransactionRecordsItemAllowedActionsItem(
        string value
    ) => new(value);

    internal class QueryPayoutTransactionRecordsItemAllowedActionsItemSerializer
        : JsonConverter<QueryPayoutTransactionRecordsItemAllowedActionsItem>
    {
        public override QueryPayoutTransactionRecordsItemAllowedActionsItem Read(
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
            return new QueryPayoutTransactionRecordsItemAllowedActionsItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            QueryPayoutTransactionRecordsItemAllowedActionsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override QueryPayoutTransactionRecordsItemAllowedActionsItem ReadAsPropertyName(
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
            return new QueryPayoutTransactionRecordsItemAllowedActionsItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            QueryPayoutTransactionRecordsItemAllowedActionsItem value,
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
        public const string Capture = "capture";

        public const string Cancel = "cancel";

        public const string Reissue = "reissue";
    }
}
