// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Request body for the push paylink operation.
/// </summary>
[JsonConverter(typeof(PushPayLinkRequest.JsonConverter))]
[Serializable]
public record PushPayLinkRequest
{
    internal PushPayLinkRequest(string type, object? value)
    {
        Channel = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of PushPayLinkRequest with <see cref="PushPayLinkRequest.Email"/>.
    /// </summary>
    public PushPayLinkRequest(PushPayLinkRequest.Email value)
    {
        Channel = "email";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PushPayLinkRequest with <see cref="PushPayLinkRequest.Sms"/>.
    /// </summary>
    public PushPayLinkRequest(PushPayLinkRequest.Sms value)
    {
        Channel = "sms";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("channel")]
    public string Channel { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Channel"/> is "email"
    /// </summary>
    public bool IsEmail => Channel == "email";

    /// <summary>
    /// Returns true if <see cref="Channel"/> is "sms"
    /// </summary>
    public bool IsSms => Channel == "sms";

    /// <summary>
    /// Returns the value as a <see cref="PayabliApi.PushPayLinkRequestEmail"/> if <see cref="Channel"/> is 'email', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Channel"/> is not 'email'.</exception>
    public PayabliApi.PushPayLinkRequestEmail AsEmail() =>
        IsEmail
            ? (PayabliApi.PushPayLinkRequestEmail)Value!
            : throw new System.Exception("PushPayLinkRequest.Channel is not 'email'");

    /// <summary>
    /// Returns the value as a <see cref="PayabliApi.PushPayLinkRequestSms"/> if <see cref="Channel"/> is 'sms', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Channel"/> is not 'sms'.</exception>
    public PayabliApi.PushPayLinkRequestSms AsSms() =>
        IsSms
            ? (PayabliApi.PushPayLinkRequestSms)Value!
            : throw new System.Exception("PushPayLinkRequest.Channel is not 'sms'");

    public T Match<T>(
        Func<PayabliApi.PushPayLinkRequestEmail, T> onEmail,
        Func<PayabliApi.PushPayLinkRequestSms, T> onSms,
        Func<string, object?, T> onUnknown_
    )
    {
        return Channel switch
        {
            "email" => onEmail(AsEmail()),
            "sms" => onSms(AsSms()),
            _ => onUnknown_(Channel, Value),
        };
    }

    public void Visit(
        Action<PayabliApi.PushPayLinkRequestEmail> onEmail,
        Action<PayabliApi.PushPayLinkRequestSms> onSms,
        Action<string, object?> onUnknown_
    )
    {
        switch (Channel)
        {
            case "email":
                onEmail(AsEmail());
                break;
            case "sms":
                onSms(AsSms());
                break;
            default:
                onUnknown_(Channel, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="PayabliApi.PushPayLinkRequestEmail"/> and returns true if successful.
    /// </summary>
    public bool TryAsEmail(out PayabliApi.PushPayLinkRequestEmail? value)
    {
        if (Channel == "email")
        {
            value = (PayabliApi.PushPayLinkRequestEmail)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="PayabliApi.PushPayLinkRequestSms"/> and returns true if successful.
    /// </summary>
    public bool TryAsSms(out PayabliApi.PushPayLinkRequestSms? value)
    {
        if (Channel == "sms")
        {
            value = (PayabliApi.PushPayLinkRequestSms)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator PushPayLinkRequest(PushPayLinkRequest.Email value) =>
        new(value);

    public static implicit operator PushPayLinkRequest(PushPayLinkRequest.Sms value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<PushPayLinkRequest>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(PushPayLinkRequest).IsAssignableFrom(typeToConvert);

        public override PushPayLinkRequest Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("channel", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'channel'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'channel' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'channel' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'channel' is null");

            var value = discriminator switch
            {
                "email" => json.Deserialize<PayabliApi.PushPayLinkRequestEmail?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize PayabliApi.PushPayLinkRequestEmail"
                    ),
                "sms" => json.Deserialize<PayabliApi.PushPayLinkRequestSms?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize PayabliApi.PushPayLinkRequestSms"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new PushPayLinkRequest(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PushPayLinkRequest value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Channel switch
                {
                    "email" => JsonSerializer.SerializeToNode(value.Value, options),
                    "sms" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["channel"] = value.Channel;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for email
    /// </summary>
    [Serializable]
    public struct Email
    {
        public Email(PayabliApi.PushPayLinkRequestEmail value)
        {
            Value = value;
        }

        internal PayabliApi.PushPayLinkRequestEmail Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PushPayLinkRequest.Email(
            PayabliApi.PushPayLinkRequestEmail value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for sms
    /// </summary>
    [Serializable]
    public struct Sms
    {
        public Sms(PayabliApi.PushPayLinkRequestSms value)
        {
            Value = value;
        }

        internal PayabliApi.PushPayLinkRequestSms Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PushPayLinkRequest.Sms(
            PayabliApi.PushPayLinkRequestSms value
        ) => new(value);
    }
}
