namespace PayabliApi;

public partial interface ITemplatesClient
{
    /// <summary>
    /// Deletes a template by ID.
    /// </summary>
    WithRawResponseTask<PayabliApiResponseTemplateId> DeleteTemplateAsync(
        double templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generates a boarding link from a boarding template.
    /// </summary>
    WithRawResponseTask<BoardingLinkApiResponse> GetlinkTemplateAsync(
        double templateId,
        bool ignoreEmpty,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a boarding template's details by ID.
    /// </summary>
    WithRawResponseTask<TemplateQueryRecord> GetTemplateAsync(
        double templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a list of boarding templates for an organization. Use filters to limit results. You can't make a request that includes filters from the API console in the documentation. The response won't be filtered. Instead, copy the request, remove `parameters=` and run the request in a different client.
    /// </summary>
    WithRawResponseTask<TemplateQueryResponse> ListTemplatesAsync(
        int orgId,
        ListTemplatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
