using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record CreateApplicationFromPaypointRequest
{
    /// <summary>
    /// ID of the existing paypoint to link to this application.
    /// </summary>
    [JsonPropertyName("paypointId")]
    public required long PaypointId { get; set; }

    /// <summary>
    /// ID of the boarding template to use for the new application.
    /// </summary>
    [JsonPropertyName("templateId")]
    public required long TemplateId { get; set; }

    /// <summary>
    /// Email address where the boarding link is sent. Required. If you don't want to email the merchant, send to an internal address and use `returnBoardingAccessInfoInLine` to retrieve the link from the response instead.
    /// </summary>
    [JsonPropertyName("recipientEmail")]
    public required string RecipientEmail { get; set; }

    /// <summary>
    /// When `true`, returns the boarding access information directly in the response.
    /// </summary>
    [JsonPropertyName("returnBoardingAccessInfoInLine")]
    public bool? ReturnBoardingAccessInfoInLine { get; set; }

    /// <summary>
    /// Additional actions to trigger when the application is created. Currently only `submitApplication` is supported, which automatically submits the application on creation and skips the draft state.
    /// </summary>
    [JsonPropertyName("onCreate")]
    public IEnumerable<string>? OnCreate { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
