// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Object containing details about the payment method to use for the payout.
/// </summary>
[JsonConverter(typeof(VendorPaymentMethod.JsonConverter))]
[Serializable]
public record VendorPaymentMethod
{
    internal VendorPaymentMethod(string type, object? value)
    {
        Method = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of VendorPaymentMethod with <see cref="VendorPaymentMethod.Managed"/>.
    /// </summary>
    public VendorPaymentMethod(VendorPaymentMethod.Managed value)
    {
        Method = "managed";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of VendorPaymentMethod with <see cref="VendorPaymentMethod.Vcard"/>.
    /// </summary>
    public VendorPaymentMethod(VendorPaymentMethod.Vcard value)
    {
        Method = "vcard";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of VendorPaymentMethod with <see cref="VendorPaymentMethod.Ach"/>.
    /// </summary>
    public VendorPaymentMethod(VendorPaymentMethod.Ach value)
    {
        Method = "ach";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of VendorPaymentMethod with <see cref="VendorPaymentMethod.Check"/>.
    /// </summary>
    public VendorPaymentMethod(VendorPaymentMethod.Check value)
    {
        Method = "check";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("method")]
    public string Method { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Method"/> is "managed"
    /// </summary>
    public bool IsManaged => Method == "managed";

    /// <summary>
    /// Returns true if <see cref="Method"/> is "vcard"
    /// </summary>
    public bool IsVcard => Method == "vcard";

    /// <summary>
    /// Returns true if <see cref="Method"/> is "ach"
    /// </summary>
    public bool IsAch => Method == "ach";

    /// <summary>
    /// Returns true if <see cref="Method"/> is "check"
    /// </summary>
    public bool IsCheck => Method == "check";

    /// <summary>
    /// Returns the value as a <see cref="PayabliApi.ManagedPaymentMethod"/> if <see cref="Method"/> is 'managed', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Method"/> is not 'managed'.</exception>
    public PayabliApi.ManagedPaymentMethod AsManaged() =>
        IsManaged
            ? (PayabliApi.ManagedPaymentMethod)Value!
            : throw new Exception("VendorPaymentMethod.Method is not 'managed'");

    /// <summary>
    /// Returns the value as a <see cref="PayabliApi.VCardPaymentMethod"/> if <see cref="Method"/> is 'vcard', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Method"/> is not 'vcard'.</exception>
    public PayabliApi.VCardPaymentMethod AsVcard() =>
        IsVcard
            ? (PayabliApi.VCardPaymentMethod)Value!
            : throw new Exception("VendorPaymentMethod.Method is not 'vcard'");

    /// <summary>
    /// Returns the value as a <see cref="PayabliApi.AchPaymentMethod"/> if <see cref="Method"/> is 'ach', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Method"/> is not 'ach'.</exception>
    public PayabliApi.AchPaymentMethod AsAch() =>
        IsAch
            ? (PayabliApi.AchPaymentMethod)Value!
            : throw new Exception("VendorPaymentMethod.Method is not 'ach'");

    /// <summary>
    /// Returns the value as a <see cref="PayabliApi.CheckPaymentMethod"/> if <see cref="Method"/> is 'check', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Method"/> is not 'check'.</exception>
    public PayabliApi.CheckPaymentMethod AsCheck() =>
        IsCheck
            ? (PayabliApi.CheckPaymentMethod)Value!
            : throw new Exception("VendorPaymentMethod.Method is not 'check'");

    public T Match<T>(
        Func<PayabliApi.ManagedPaymentMethod, T> onManaged,
        Func<PayabliApi.VCardPaymentMethod, T> onVcard,
        Func<PayabliApi.AchPaymentMethod, T> onAch,
        Func<PayabliApi.CheckPaymentMethod, T> onCheck,
        Func<string, object?, T> onUnknown_
    )
    {
        return Method switch
        {
            "managed" => onManaged(AsManaged()),
            "vcard" => onVcard(AsVcard()),
            "ach" => onAch(AsAch()),
            "check" => onCheck(AsCheck()),
            _ => onUnknown_(Method, Value),
        };
    }

    public void Visit(
        Action<PayabliApi.ManagedPaymentMethod> onManaged,
        Action<PayabliApi.VCardPaymentMethod> onVcard,
        Action<PayabliApi.AchPaymentMethod> onAch,
        Action<PayabliApi.CheckPaymentMethod> onCheck,
        Action<string, object?> onUnknown_
    )
    {
        switch (Method)
        {
            case "managed":
                onManaged(AsManaged());
                break;
            case "vcard":
                onVcard(AsVcard());
                break;
            case "ach":
                onAch(AsAch());
                break;
            case "check":
                onCheck(AsCheck());
                break;
            default:
                onUnknown_(Method, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="PayabliApi.ManagedPaymentMethod"/> and returns true if successful.
    /// </summary>
    public bool TryAsManaged(out PayabliApi.ManagedPaymentMethod? value)
    {
        if (Method == "managed")
        {
            value = (PayabliApi.ManagedPaymentMethod)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="PayabliApi.VCardPaymentMethod"/> and returns true if successful.
    /// </summary>
    public bool TryAsVcard(out PayabliApi.VCardPaymentMethod? value)
    {
        if (Method == "vcard")
        {
            value = (PayabliApi.VCardPaymentMethod)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="PayabliApi.AchPaymentMethod"/> and returns true if successful.
    /// </summary>
    public bool TryAsAch(out PayabliApi.AchPaymentMethod? value)
    {
        if (Method == "ach")
        {
            value = (PayabliApi.AchPaymentMethod)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="PayabliApi.CheckPaymentMethod"/> and returns true if successful.
    /// </summary>
    public bool TryAsCheck(out PayabliApi.CheckPaymentMethod? value)
    {
        if (Method == "check")
        {
            value = (PayabliApi.CheckPaymentMethod)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator VendorPaymentMethod(VendorPaymentMethod.Managed value) =>
        new(value);

    public static implicit operator VendorPaymentMethod(VendorPaymentMethod.Vcard value) =>
        new(value);

    public static implicit operator VendorPaymentMethod(VendorPaymentMethod.Ach value) =>
        new(value);

    public static implicit operator VendorPaymentMethod(VendorPaymentMethod.Check value) =>
        new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<VendorPaymentMethod>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(VendorPaymentMethod).IsAssignableFrom(typeToConvert);

        public override VendorPaymentMethod Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("method", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'method'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'method' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'method' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'method' is null");

            var value = discriminator switch
            {
                "managed" => json.Deserialize<PayabliApi.ManagedPaymentMethod>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize PayabliApi.ManagedPaymentMethod"
                    ),
                "vcard" => json.Deserialize<PayabliApi.VCardPaymentMethod>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize PayabliApi.VCardPaymentMethod"
                    ),
                "ach" => json.Deserialize<PayabliApi.AchPaymentMethod>(options)
                    ?? throw new JsonException("Failed to deserialize PayabliApi.AchPaymentMethod"),
                "check" => json.Deserialize<PayabliApi.CheckPaymentMethod>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize PayabliApi.CheckPaymentMethod"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new VendorPaymentMethod(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            VendorPaymentMethod value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Method switch
                {
                    "managed" => JsonSerializer.SerializeToNode(value.Value, options),
                    "vcard" => JsonSerializer.SerializeToNode(value.Value, options),
                    "ach" => JsonSerializer.SerializeToNode(value.Value, options),
                    "check" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["method"] = value.Method;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for managed
    /// </summary>
    [Serializable]
    public struct Managed
    {
        public Managed(PayabliApi.ManagedPaymentMethod value)
        {
            Value = value;
        }

        internal PayabliApi.ManagedPaymentMethod Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Managed(PayabliApi.ManagedPaymentMethod value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for vcard
    /// </summary>
    [Serializable]
    public struct Vcard
    {
        public Vcard(PayabliApi.VCardPaymentMethod value)
        {
            Value = value;
        }

        internal PayabliApi.VCardPaymentMethod Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Vcard(PayabliApi.VCardPaymentMethod value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for ach
    /// </summary>
    [Serializable]
    public struct Ach
    {
        public Ach(PayabliApi.AchPaymentMethod value)
        {
            Value = value;
        }

        internal PayabliApi.AchPaymentMethod Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Ach(PayabliApi.AchPaymentMethod value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for check
    /// </summary>
    [Serializable]
    public struct Check
    {
        public Check(PayabliApi.CheckPaymentMethod value)
        {
            Value = value;
        }

        internal PayabliApi.CheckPaymentMethod Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Check(PayabliApi.CheckPaymentMethod value) => new(value);
    }
}
