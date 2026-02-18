namespace PayabliApi;

public partial interface IBillClient
{
    /// <summary>
    /// Creates a bill in an entrypoint.
    /// </summary>
    WithRawResponseTask<BillResponse> AddBillAsync(
        string entry,
        AddBillRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a file attached to a bill.
    /// </summary>
    WithRawResponseTask<BillResponse> DeleteAttachedFromBillAsync(
        int idBill,
        string filename,
        DeleteAttachedFromBillRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a bill by ID.
    /// </summary>
    WithRawResponseTask<BillResponse> DeleteBillAsync(
        int idBill,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a bill by ID.
    /// </summary>
    WithRawResponseTask<EditBillResponse> EditBillAsync(
        int idBill,
        BillOutData request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a file attached to a bill, either as a binary file or as a Base64-encoded string.
    /// </summary>
    WithRawResponseTask<FileContent> GetAttachedFromBillAsync(
        int idBill,
        string filename,
        GetAttachedFromBillRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a bill by ID from an entrypoint.
    /// </summary>
    WithRawResponseTask<GetBillResponse> GetBillAsync(
        int idBill,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of bills for an entrypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<BillQueryResponse> ListBillsAsync(
        string entry,
        ListBillsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of bills for an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    WithRawResponseTask<BillQueryResponse> ListBillsOrgAsync(
        int orgId,
        ListBillsOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Modify the list of users the bill is sent to for approval.
    /// </summary>
    WithRawResponseTask<ModifyApprovalBillResponse> ModifyApprovalBillAsync(
        int idBill,
        IEnumerable<string> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Send a bill to a user or list of users to approve.
    /// </summary>
    WithRawResponseTask<BillResponse> SendToApprovalBillAsync(
        int idBill,
        SendToApprovalBillRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Approve or disapprove a bill by ID.
    /// </summary>
    WithRawResponseTask<SetApprovedBillResponse> SetApprovedBillAsync(
        int idBill,
        string approved,
        SetApprovedBillRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
