using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(CaseTrigger.CaseTriggerSerializer))]
[Serializable]
public readonly record struct CaseTrigger : IStringEnum
{
    public static readonly CaseTrigger Submit = new(Values.Submit);

    public static readonly CaseTrigger Verify = new(Values.Verify);

    public static readonly CaseTrigger RequestReview = new(Values.RequestReview);

    public static readonly CaseTrigger Assign = new(Values.Assign);

    public static readonly CaseTrigger RequestResponse = new(Values.RequestResponse);

    public static readonly CaseTrigger Escalate = new(Values.Escalate);

    public static readonly CaseTrigger Approve = new(Values.Approve);

    public static readonly CaseTrigger AutoApprove = new(Values.AutoApprove);

    public static readonly CaseTrigger RequestCompletion = new(Values.RequestCompletion);

    public static readonly CaseTrigger Complete = new(Values.Complete);

    public static readonly CaseTrigger Deny = new(Values.Deny);

    public static readonly CaseTrigger Error = new(Values.Error);

    public CaseTrigger(string value)
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
    public static CaseTrigger FromCustom(string value)
    {
        return new CaseTrigger(value);
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

    public static bool operator ==(CaseTrigger value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CaseTrigger value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CaseTrigger value) => value.Value;

    public static explicit operator CaseTrigger(string value) => new(value);

    internal class CaseTriggerSerializer : JsonConverter<CaseTrigger>
    {
        public override CaseTrigger Read(
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
            return new CaseTrigger(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CaseTrigger value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CaseTrigger ReadAsPropertyName(
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
            return new CaseTrigger(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CaseTrigger value,
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
        public const string Submit = "Submit";

        public const string Verify = "Verify";

        public const string RequestReview = "RequestReview";

        public const string Assign = "Assign";

        public const string RequestResponse = "RequestResponse";

        public const string Escalate = "Escalate";

        public const string Approve = "Approve";

        public const string AutoApprove = "AutoApprove";

        public const string RequestCompletion = "RequestCompletion";

        public const string Complete = "Complete";

        public const string Deny = "Deny";

        public const string Error = "Error";
    }
}
