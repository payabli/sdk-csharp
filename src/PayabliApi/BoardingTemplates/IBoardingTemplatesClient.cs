namespace PayabliApi;

public partial interface IBoardingTemplatesClient
{
    /// <summary>
    /// Lists the boarding templates an organization owns, plus templates
    /// inherited from ancestor organizations. Scope the listing with the
    /// required `orgId` query parameter. You can filter by `status`, `name`,
    /// `slug`, `orgName`, and `inherited`, and page through results.
    /// </summary>
    WithRawResponseTask<ListTemplatesResponse> ListTemplatesAsync(
        ListTemplatesBoardingTemplatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a boarding template by UUID, including its current content version.
    /// </summary>
    WithRawResponseTask<Template> GetTemplateAsync(
        string uuid,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archives a boarding template by UUID. Archiving is a soft delete: the
    /// template stays readable with `status: archived`, so archiving an
    /// already-archived template returns `409`, not another success. Unknown
    /// templates return `404`.
    /// </summary>
    WithRawResponseTask ArchiveTemplateAsync(
        string uuid,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a specific immutable content version of a template.
    /// </summary>
    WithRawResponseTask<TemplateVersion> GetTemplateVersionAsync(
        string uuid,
        string versionUuid,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
