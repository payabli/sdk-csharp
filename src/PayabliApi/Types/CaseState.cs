using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(CaseState.CaseStateSerializer))]
[Serializable]
public readonly record struct CaseState : IStringEnum
{
    public static readonly CaseState Submitted = new(Values.Submitted);

    public static readonly CaseState Verifying = new(Values.Verifying);

    public static readonly CaseState PendingReview = new(Values.PendingReview);

    public static readonly CaseState Assigned = new(Values.Assigned);

    public static readonly CaseState PendingResponse = new(Values.PendingResponse);

    public static readonly CaseState Escalated = new(Values.Escalated);

    public static readonly CaseState Approved = new(Values.Approved);

    public static readonly CaseState AutoApproved = new(Values.AutoApproved);

    public static readonly CaseState PendingCompletion = new(Values.PendingCompletion);

    public static readonly CaseState Completed = new(Values.Completed);

    public static readonly CaseState Denied = new(Values.Denied);

    public static readonly CaseState Error = new(Values.Error);

    public CaseState(string value)
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
    public static CaseState FromCustom(string value)
    {
        return new CaseState(value);
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

    public static bool operator ==(CaseState value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(CaseState value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(CaseState value) => value.Value;

    public static explicit operator CaseState(string value) => new(value);

    internal class CaseStateSerializer : JsonConverter<CaseState>
    {
        public override CaseState Read(
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
            return new CaseState(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CaseState value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CaseState ReadAsPropertyName(
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
            return new CaseState(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CaseState value,
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
        public const string Submitted = "Submitted";

        public const string Verifying = "Verifying";

        public const string PendingReview = "PendingReview";

        public const string Assigned = "Assigned";

        public const string PendingResponse = "PendingResponse";

        public const string Escalated = "Escalated";

        public const string Approved = "Approved";

        public const string AutoApproved = "AutoApproved";

        public const string PendingCompletion = "PendingCompletion";

        public const string Completed = "Completed";

        public const string Denied = "Denied";

        public const string Error = "Error";
    }
}
