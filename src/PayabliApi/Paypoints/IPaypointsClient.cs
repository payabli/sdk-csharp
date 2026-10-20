using OneOf;

namespace PayabliApi;

public partial interface IPaypointsClient
{
    /// <summary>
    /// Lists paypoints with optional filtering and pagination.
    /// </summary>
    WithRawResponseTask<ListPaypointsEnvelope> ListPaypointsAsync(
        ListPaypointsPaypointsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a paypoint. New paypoints start in `pending`. Provide exactly
    /// one of `businessReference` (an existing business) or `business` (to
    /// create the business inline).
    /// </summary>
    WithRawResponseTask<PaypointCreatedEnvelope> CreatePaypointAsync(
        OneOf<
            CreatePaypointWithBusinessReference,
            CreatePaypointWithInlineBusiness,
            CreatePaypointAllFields
        > request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paypoint by reference.
    /// </summary>
    WithRawResponseTask<PaypointDetailEnvelope> GetPaypointAsync(
        string paypointReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Applies a partial update to a paypoint. Send only the fields you want to change.
    /// </summary>
    WithRawResponseTask<PaypointUpdatedEnvelope> UpdatePaypointAsync(
        string paypointReference,
        UpdatePaypointRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
