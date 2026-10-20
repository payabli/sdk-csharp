using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The signature details for the application. The signer is the person flagged
/// with `isSigner` on the business, and Payabli records the signer's identity
/// from their person record and business link. Keep the signer's details
/// current with the people endpoints before you submit, because you can't
/// correct them here. Provide a signature with `signature` and
/// `signatureType`, or, if the signer signed in your own e-sign tool, send
/// `signedDocumentReference` instead. Signer identity fields such as `name`,
/// `email`, `ssn`, and `address` aren't part of this object, and Payabli
/// ignores them if you send them.
/// </summary>
[Serializable]
public record SubmitSigner : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The reference of an owner linked to this business, to make them the signer before the application is submitted. Works only while the application is a draft. Leave it out when the business already has a signer. If the person isn't linked to this business, the request fails with `404`. If the person isn't an owner, the request fails with `422` and the error `SIGNER_NOT_OWNER`.
    /// </summary>
    [JsonPropertyName("personReference")]
    public string? PersonReference { get; set; }

    /// <summary>
    /// The signature. For `type` and `checkbox`, send the signer's name. For `draw`, send the image as a base64 data URL, such as the output of `canvas.toDataURL()`. Required unless you send `signedDocumentReference`.
    /// </summary>
    [JsonPropertyName("signature")]
    public string? Signature { get; set; }

    /// <summary>
    /// How the signer signed. Required with `signature`.
    /// </summary>
    [JsonPropertyName("signatureType")]
    public SignatureType? SignatureType { get; set; }

    /// <summary>
    /// The reference for a document the signer signed in your own e-sign tool, such as a DocuSign envelope ID. Send it instead of `signature` and `signatureType`.
    /// </summary>
    [JsonPropertyName("signedDocumentReference")]
    public string? SignedDocumentReference { get; set; }

    /// <summary>
    /// Whether the signer accepted the terms. If you leave it out, Payabli records `false`.
    /// </summary>
    [JsonPropertyName("acceptance")]
    public bool? Acceptance { get; set; }

    /// <summary>
    /// Whether the signer attested to PCI compliance. If you leave it out, Payabli records `false`.
    /// </summary>
    [JsonPropertyName("pciAttestation")]
    public bool? PciAttestation { get; set; }

    /// <summary>
    /// The IP address of the signer's device, as your system saw it. Payabli
    /// records it as reported by you, in its own field, and still records the
    /// IP address it observes on the request. Send a single IPv4 address in
    /// dotted-decimal form, such as `203.0.113.7`, or an IPv6 address in any
    /// valid form, up to 45 characters. Payabli rejects ports, CIDR ranges,
    /// IPv6 zone IDs, lists of addresses, and shorthand, integer, hex, or
    /// leading-zero IPv4 forms. An invalid value returns `400`, and the
    /// application isn't submitted. An empty value is treated as not sent.
    /// </summary>
    [JsonPropertyName("reportedSignerIp")]
    public string? ReportedSignerIp { get; set; }

    [JsonPropertyName("additionalData")]
    public Dictionary<string, string>? AdditionalData { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
