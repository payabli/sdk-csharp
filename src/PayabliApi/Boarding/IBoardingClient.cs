using OneOf;

namespace PayabliApi;

public partial interface IBoardingClient
{
    /// <summary>
    /// Creates a boarding application in an organization. This endpoint requires an application API token.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse00Responsedatanonobject> AddApplicationAsync(
        OneOf<
            ApplicationDataPayIn,
            ApplicationDataManaged,
            ApplicationDataOdp,
            ApplicationData
        > request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a boarding application by ID.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse00Responsedatanonobject> DeleteApplicationAsync(
        int appId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the details for a boarding application by ID.
    /// </summary>
    WithRawResponseTask<ApplicationDetailsRecord> GetApplicationAsync(
        int appId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Gets a boarding application by authentication information. This endpoint requires an `application` API token.
    /// </summary>
    WithRawResponseTask<ApplicationQueryRecord> GetApplicationByAuthAsync(
        string xId,
        RequestAppByAuth request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves details for a boarding link, by ID.
    /// </summary>
    WithRawResponseTask<BoardingLinkQueryRecord> GetByIdLinkApplicationAsync(
        int boardingLinkId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get details for a boarding link using the boarding template ID. This endpoint requires an application API token.
    /// </summary>
    WithRawResponseTask<BoardingLinkQueryRecord> GetByTemplateIdLinkApplicationAsync(
        double templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a link and the verification code used to log into an existing boarding application. You can also use this endpoint to send a link and referenceId for an existing boarding application to an email address. The recipient can use the referenceId and email address to access and edit the application.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse00> GetExternalApplicationAsync(
        int appId,
        string mail2,
        GetExternalApplicationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the details for a boarding link, by reference name. This endpoint requires an application API token.
    /// </summary>
    WithRawResponseTask<BoardingLinkQueryRecord> GetLinkApplicationAsync(
        string boardingLinkReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a list of boarding applications for an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryBoardingAppsListResponse> ListApplicationsAsync(
        int orgId,
        ListApplicationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Return a list of boarding links for an organization. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<QueryBoardingLinksResponse> ListBoardingLinksAsync(
        int orgId,
        ListBoardingLinksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a boarding application by ID. This endpoint requires an application API token.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse00Responsedatanonobject> UpdateApplicationAsync(
        int appId,
        ApplicationData request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
