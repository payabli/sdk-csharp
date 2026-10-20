namespace PayabliApi;

public partial interface ITemplatesClient
{
    /// <summary>
    /// &lt;Warning&gt;
    ///   Legacy boarding is deprecated and will be sunset in Q2 2027. Use [Archive a template](/developers/api-reference/boarding-templates/archive-a-template) instead.
    /// &lt;/Warning&gt;
    ///
    ///
    /// Deletes a template by ID.
    /// </summary>
    WithRawResponseTask<PayabliApiResponseTemplateId> DeleteTemplateAsync(
        double templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// &lt;Warning&gt;
    ///   Legacy boarding is deprecated and will be sunset in Q2 2027. Intelligent boarding has no matching endpoint. Each application has its own hosted form link instead. See [Send merchants a boarding link](/guides/pay-ops-developer-boarding-legacy-migrate#send-merchants-a-boarding-link).
    /// &lt;/Warning&gt;
    ///
    ///
    /// Generates a boarding link from a boarding template.
    /// </summary>
    WithRawResponseTask<BoardingLinkApiResponse> GetlinkTemplateAsync(
        double templateId,
        bool ignoreEmpty,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// &lt;Warning&gt;
    ///   Legacy boarding is deprecated and will be sunset in Q2 2027. Use [Get a template](/developers/api-reference/boarding-templates/get-a-template) instead.
    /// &lt;/Warning&gt;
    ///
    ///
    /// Retrieves a boarding template's details by ID.
    /// </summary>
    WithRawResponseTask<TemplateQueryRecord> GetTemplateAsync(
        double templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// &lt;Warning&gt;
    ///   Legacy boarding is deprecated and will be sunset in Q2 2027. Use [List templates](/developers/api-reference/boarding-templates/list-templates) instead.
    /// &lt;/Warning&gt;
    ///
    ///
    /// Retrieves a list of boarding templates for an organization. Use filters to limit results. You can't make a request that includes filters from the API console in the documentation. The response won't be filtered. Instead, copy the request, remove `parameters=` and run the request in a different client.
    /// </summary>
    WithRawResponseTask<TemplateQueryResponse> ListTemplatesAsync(
        int orgId,
        ListTemplatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
