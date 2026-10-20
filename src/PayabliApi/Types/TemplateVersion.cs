using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// An immutable snapshot of a template's content. Each save in the Payabli
/// Portal appends a new version; the template's `currentVersionUuid` points at
/// the active one. The configuration objects (services, documents, devices, and
/// so on) are authored in the Portal.
/// </summary>
[Serializable]
public record TemplateVersion : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The version's unique identifier.
    /// </summary>
    [JsonPropertyName("uuid")]
    public required string Uuid { get; set; }

    /// <summary>
    /// The version number, starting at 1 and incrementing on each save.
    /// </summary>
    [JsonPropertyName("version")]
    public required int Version { get; set; }

    /// <summary>
    /// The processing services offered on the boarding form. Configured in the Payabli Portal.
    /// </summary>
    [JsonPropertyName("services")]
    public Dictionary<string, object?>? Services { get; set; }

    /// <summary>
    /// Per-field configuration for the boarding form. Configured in the Payabli Portal.
    /// </summary>
    [JsonPropertyName("fieldConfigurations")]
    public IEnumerable<object>? FieldConfigurations { get; set; }

    /// <summary>
    /// Rules that show, hide, or require fields based on other answers. Configured in the Payabli Portal.
    /// </summary>
    [JsonPropertyName("conditionalRules")]
    public IEnumerable<object>? ConditionalRules { get; set; }

    /// <summary>
    /// Document upload requirements for the boarding form. Configured in the Payabli Portal.
    /// </summary>
    [JsonPropertyName("documents")]
    public IEnumerable<object>? Documents { get; set; }

    /// <summary>
    /// The devices offered during boarding. Configured in the Payabli Portal.
    /// </summary>
    [JsonPropertyName("devices")]
    public IEnumerable<object>? Devices { get; set; }

    /// <summary>
    /// Sections hidden from the boarding form. Configured in the Payabli Portal.
    /// </summary>
    [JsonPropertyName("hiddenSections")]
    public IEnumerable<object>? HiddenSections { get; set; }

    /// <summary>
    /// The merchant category codes (MCCs) allowed for applications from this template. Configured in the Payabli Portal.
    /// </summary>
    [JsonPropertyName("allowedMccs")]
    public IEnumerable<int>? AllowedMccs { get; set; }

    [JsonPropertyName("underwriting")]
    public required UnderwritingMode Underwriting { get; set; }

    /// <summary>
    /// The merchant processing agreement content shown during boarding.
    /// </summary>
    [JsonPropertyName("mpaContent")]
    public string? MpaContent { get; set; }

    /// <summary>
    /// The Pay In pricing configuration applied to applications from this template.
    /// </summary>
    [JsonPropertyName("payinPricingId")]
    public int? PayinPricingId { get; set; }

    /// <summary>
    /// The Pay Out pricing configuration applied to applications from this template.
    /// </summary>
    [JsonPropertyName("payoutPricingId")]
    public int? PayoutPricingId { get; set; }

    /// <summary>
    /// Whether the boarding form shows a guided tour.
    /// </summary>
    [JsonPropertyName("allowGuidedTour")]
    public required bool AllowGuidedTour { get; set; }

    /// <summary>
    /// Whether business fields can be prefilled.
    /// </summary>
    [JsonPropertyName("allowBusinessPrefill")]
    public required bool AllowBusinessPrefill { get; set; }

    /// <summary>
    /// Whether applicants can save progress and resume later.
    /// </summary>
    [JsonPropertyName("allowSaveForLater")]
    public required bool AllowSaveForLater { get; set; }

    /// <summary>
    /// Whether applicants can add more than one bank account.
    /// </summary>
    [JsonPropertyName("allowMultipleBanks")]
    public required bool AllowMultipleBanks { get; set; }

    /// <summary>
    /// Whether applicants can choose their processing services.
    /// </summary>
    [JsonPropertyName("allowServiceSelection")]
    public required bool AllowServiceSelection { get; set; }

    /// <summary>
    /// Whether applicants can select devices.
    /// </summary>
    [JsonPropertyName("allowDeviceSelection")]
    public required bool AllowDeviceSelection { get; set; }

    /// <summary>
    /// Whether the Amigo assistant is available during boarding.
    /// </summary>
    [JsonPropertyName("allowAmigoChat")]
    public required bool AllowAmigoChat { get; set; }

    /// <summary>
    /// Whether applicants can create a user account during boarding.
    /// </summary>
    [JsonPropertyName("allowUserCreation")]
    public required bool AllowUserCreation { get; set; }

    /// <summary>
    /// Whether people fields can be prefilled.
    /// </summary>
    [JsonPropertyName("allowPeoplePrefill")]
    public required bool AllowPeoplePrefill { get; set; }

    /// <summary>
    /// Whether the progress indicator is shown vertically.
    /// </summary>
    [JsonPropertyName("verticalProgress")]
    public required bool VerticalProgress { get; set; }

    /// <summary>
    /// Whether form inputs use floating labels.
    /// </summary>
    [JsonPropertyName("useFloatingInputs")]
    public required bool UseFloatingInputs { get; set; }

    /// <summary>
    /// Whether the boarding form content is centered.
    /// </summary>
    [JsonPropertyName("centerContent")]
    public required bool CenterContent { get; set; }

    /// <summary>
    /// Whether bank accounts are verified in real time.
    /// </summary>
    [JsonPropertyName("allowRealTimeBankVerification")]
    public required bool AllowRealTimeBankVerification { get; set; }

    /// <summary>
    /// Whether applicants can sign with a checkbox.
    /// </summary>
    [JsonPropertyName("allowCheckboxSigning")]
    public required bool AllowCheckboxSigning { get; set; }

    /// <summary>
    /// Whether applicants can sign by typing their name.
    /// </summary>
    [JsonPropertyName("allowTypedSignature")]
    public required bool AllowTypedSignature { get; set; }

    /// <summary>
    /// Whether applicants can sign by drawing a signature.
    /// </summary>
    [JsonPropertyName("allowWrittenSignature")]
    public required bool AllowWrittenSignature { get; set; }

    /// <summary>
    /// Whether multiple owners can e-sign the application.
    /// </summary>
    [JsonPropertyName("allowMultiOwnerEsign")]
    public required bool AllowMultiOwnerEsign { get; set; }

    /// <summary>
    /// Whether the confirmation and attestation step is shown.
    /// </summary>
    [JsonPropertyName("allowConfirmationAndAttestation")]
    public required bool AllowConfirmationAndAttestation { get; set; }

    /// <summary>
    /// Whether the PCI attestation step is shown.
    /// </summary>
    [JsonPropertyName("allowPCIAttestation")]
    public required bool AllowPciAttestation { get; set; }

    /// <summary>
    /// When the version was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    /// <summary>
    /// The identifier of the user who created the version.
    /// </summary>
    [JsonPropertyName("createdBy")]
    public required string CreatedBy { get; set; }

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
