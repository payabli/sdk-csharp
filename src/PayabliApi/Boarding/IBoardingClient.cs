using OneOf;

namespace PayabliApi;

public partial interface IBoardingClient
{
    /// <summary>
    /// &lt;Warning&gt;
    ///   Legacy boarding is deprecated and will be sunset in Q2 2027. Use [Create an application](/developers/api-reference/applications/create-an-application) instead. One legacy call becomes several intelligent boarding calls, one for each record. See [Map legacy calls to new endpoints](/guides/pay-ops-developer-boarding-legacy-migrate#map-legacy-calls-to-new-endpoints).
    /// &lt;/Warning&gt;
    ///
    ///
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
    /// &lt;Warning&gt;
    ///   Legacy boarding is deprecated and will be sunset in Q2 2027. Update the record that holds the data instead, such as [the business](/developers/api-reference/businesses/update-a-business) or [a person](/developers/api-reference/people/update-a-person). Use [Update an application](/developers/api-reference/applications/update-an-application) only for the application's own fields.
    /// &lt;/Warning&gt;
    ///
    ///
    /// Updates a boarding application by ID. This endpoint requires an application API token.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse00Responsedatanonobject> UpdateApplicationAsync(
        int appId,
        ApplicationData request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// &lt;Warning&gt;
    ///   Legacy boarding is deprecated and will be sunset in Q2 2027. Use [Withdraw an application](/developers/api-reference/applications/withdraw-an-application) instead.
    /// &lt;/Warning&gt;
    ///
    ///
    /// Deletes a boarding application by ID.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse00Responsedatanonobject> DeleteApplicationAsync(
        int appId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// &lt;Warning&gt;
    ///   Legacy boarding is deprecated and will be sunset in Q2 2027. Use [Get an application](/developers/api-reference/applications/get-an-application) instead.
    /// &lt;/Warning&gt;
    ///
    ///
    /// Retrieves the details for a boarding application by ID.
    /// </summary>
    WithRawResponseTask<ApplicationDetailsRecord> GetApplicationAsync(
        int appId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// &lt;Warning&gt;
    ///   Legacy boarding is deprecated and will be sunset in Q2 2027. Intelligent boarding has no matching endpoint. Each application has its own hosted form link instead. See [Send merchants a boarding link](/guides/pay-ops-developer-boarding-legacy-migrate#send-merchants-a-boarding-link).
    /// &lt;/Warning&gt;
    ///
    ///
    /// Gets a boarding application by authentication information. This endpoint requires an `application` API token.
    /// </summary>
    WithRawResponseTask<ApplicationQueryRecord> GetApplicationByAuthAsync(
        string xId,
        RequestAppByAuth request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// &lt;Warning&gt;
    ///   Legacy boarding is deprecated and will be sunset in Q2 2027. Intelligent boarding has no matching endpoint. Each application has its own hosted form link instead. See [Send merchants a boarding link](/guides/pay-ops-developer-boarding-legacy-migrate#send-merchants-a-boarding-link).
    /// &lt;/Warning&gt;
    ///
    ///
    /// Retrieves details for a boarding link, by ID.
    /// </summary>
    WithRawResponseTask<BoardingLinkQueryRecord> GetByIdLinkApplicationAsync(
        int boardingLinkId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// &lt;Warning&gt;
    ///   Legacy boarding is deprecated and will be sunset in Q2 2027. Intelligent boarding has no matching endpoint. Each application has its own hosted form link instead. See [Send merchants a boarding link](/guides/pay-ops-developer-boarding-legacy-migrate#send-merchants-a-boarding-link).
    /// &lt;/Warning&gt;
    ///
    ///
    /// Get details for a boarding link using the boarding template ID. This endpoint requires an application API token.
    /// </summary>
    WithRawResponseTask<BoardingLinkQueryRecord> GetByTemplateIdLinkApplicationAsync(
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
    /// &lt;Warning&gt;
    ///   Legacy boarding is deprecated and will be sunset in Q2 2027. Intelligent boarding has no matching endpoint. Each application has its own hosted form link instead. See [Send merchants a boarding link](/guides/pay-ops-developer-boarding-legacy-migrate#send-merchants-a-boarding-link).
    /// &lt;/Warning&gt;
    ///
    ///
    /// Retrieves the details for a boarding link, by reference name. This endpoint requires an application API token.
    /// </summary>
    WithRawResponseTask<BoardingLinkQueryRecord> GetLinkApplicationAsync(
        string boardingLinkReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// &lt;Warning&gt;
    ///   Legacy boarding is deprecated and will be sunset in Q2 2027. Use [List applications](/developers/api-reference/applications/list-applications) instead.
    /// &lt;/Warning&gt;
    ///
    ///
    /// Returns a list of boarding applications for an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<QueryBoardingAppsListResponse> ListApplicationsAsync(
        int orgId,
        ListApplicationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// &lt;Warning&gt;
    ///   Legacy boarding is deprecated and will be sunset in Q2 2027. Intelligent boarding has no matching endpoint. Each application has its own hosted form link instead. See [Send merchants a boarding link](/guides/pay-ops-developer-boarding-legacy-migrate#send-merchants-a-boarding-link).
    /// &lt;/Warning&gt;
    ///
    ///
    /// Return a list of boarding links for an organization. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<QueryBoardingLinksResponse> ListBoardingLinksAsync(
        int orgId,
        ListBoardingLinksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// &lt;Warning&gt;
    ///   Legacy boarding is deprecated and will be sunset in Q2 2027. Use [Create an application](/developers/api-reference/applications/create-an-application) for a paypoint that's already boarded instead. See [Request more services with the API](/guides/pay-ops-developer-boarding-add-services).
    /// &lt;/Warning&gt;
    ///
    ///
    /// Creates a new boarding application linked to an existing paypoint as part of the multi-product boarding flow. Use this endpoint to add new services to a paypoint without creating a duplicate record. The system copies eligible business, contact, banking, and address data from the paypoint to the new application based on 1:1 field matching. The merchant only needs to provide fields that are specific to the new service. See the [Multi-product boarding](/guides/pay-ops-developer-boarding-multi-product) guide for the full flow.
    /// </summary>
    WithRawResponseTask<CreateApplicationFromPaypointResponse> AddServiceToPaypointFromAppAsync(
        CreateApplicationFromPaypointRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// &lt;Warning&gt;
    ///   Legacy boarding is deprecated and will be sunset in Q2 2027. Use [List applications](/developers/api-reference/applications/list-applications) instead. It doesn't filter by paypoint.
    /// &lt;/Warning&gt;
    ///
    ///
    /// Returns all boarding applications associated with a specific paypoint, including those created through the multi-product boarding flow. Use this endpoint to track underwriting progress across multiple service additions or to build reporting views. See the [Multi-product boarding](/guides/pay-ops-developer-boarding-multi-product) guide for the full flow.
    /// </summary>
    WithRawResponseTask<QueryBoardingAppsListResponse> GetApplicationsByPaypointIdAsync(
        long paypointId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
