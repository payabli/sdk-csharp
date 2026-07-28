namespace PayabliApi;

public partial interface ICaseManagementClient
{
    /// <summary>
    /// Validates a bank account change for a paypoint without creating a case.
    /// Runs the same checks the create endpoint runs, and returns blocking
    /// conditions and warnings. Blocking conditions prevent creation; warnings
    /// don't.
    ///
    /// Available to both Platform and Enterprise Partners.
    /// </summary>
    WithRawResponseTask<PreCreationValidationResult> ValidateBankAccountChangeAsync(
        long paypointId,
        ValidateBankAccountChangeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a bank-account-change case for a paypoint. The account and
    /// routing numbers are validated and tokenized before the case is saved —
    /// the raw numbers are never stored or returned. The account holder name is
    /// taken from the paypoint's legal name. On success the case is created in
    /// `Submitted` and asynchronous verification starts.
    ///
    /// Available to both Platform and Enterprise Partners.
    /// </summary>
    WithRawResponseTask<CaseResponse> CreateBankAccountChangeAsync(
        long paypointId,
        CreateBankAccountChangeCaseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a case by its UUID, including its current state, parameters,
    /// state history, verification metadata, and attachments.
    ///
    /// Available to both Platform and Enterprise Partners.
    /// </summary>
    WithRawResponseTask<CaseResponse> GetCaseAsync(
        string uuid,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists cases for an organization, climbing the platform org hierarchy.
    /// Supports pagination and sorting through query parameters, and filtering
    /// through repeatable `parameters[field(op)]=value` query parameters (for
    /// example `parameters[state(in)]=Assigned|PendingReview`). Filterable
    /// fields include `state`, `caseType`, `paypointId`, `createdAt`,
    /// `updatedAt`, `scheduleFor`, and `createdBy`.
    ///
    /// Available to both Platform and Enterprise Partners.
    /// </summary>
    WithRawResponseTask<CaseListResponse> ListCasesAsync(
        long organizationId,
        ListCasesCaseManagementRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists the notes on a case, ordered oldest to newest. Cursor-paginated.
    ///
    /// Available to both Platform and Enterprise Partners.
    /// </summary>
    WithRawResponseTask<MessagePage> ListMessagesAsync(
        string caseUuid,
        ListMessagesCaseManagementRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds a note to a case.
    ///
    /// Available to both Platform and Enterprise Partners.
    ///
    /// This endpoint is in development and not yet available for API use. To
    /// add a note for now, use Case Management in the
    /// [Payabli Portal](/guides/pay-ops-portal-bank-account-changes-manage).
    /// To read existing notes on a case, use
    /// [List case notes](/developers/api-reference/caseManagement/list-case-notes).
    /// </summary>
    WithRawResponseTask<PostedMessage> PostMessageAsync(
        string caseUuid,
        PostCaseMessageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists the review actions currently available on a case. The list is
    /// empty when no user action is available (for example while the case is
    /// mid-automation).
    ///
    /// Available to both Platform and Enterprise Partners, though only
    /// Enterprise Partners can fire the returned actions.
    /// </summary>
    WithRawResponseTask<AvailableTransitionsResponse> ListTransitionsAsync(
        string uuid,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fires a review action on a case, such as `Approve`, `Deny`, `Escalate`,
    /// or `RequestReview`. Assigning a case uses the dedicated assign endpoint,
    /// not this one. Firing an action that isn't valid for the case's current
    /// state returns `409`.
    ///
    /// Available to Enterprise Partners only.
    /// </summary>
    WithRawResponseTask<CaseResponse> TransitionAsync(
        string uuid,
        TransitionCaseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assigns a case to a reviewer.
    ///
    /// Available to Enterprise Partners only.
    /// </summary>
    WithRawResponseTask<CaseResponse> AssignCaseAsync(
        string uuid,
        AssignCaseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists the files attached to a case.
    ///
    /// Available to both Platform and Enterprise Partners.
    /// </summary>
    WithRawResponseTask<IEnumerable<AttachmentResponse>> ListAttachmentsAsync(
        string caseUuid,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Uploads a file to a case as multipart form data. The maximum size is
    /// 25 MiB, and the content type must be an allowed type such as PDF, PNG,
    /// JPEG, CSV, XLSX, DOCX, or plain text.
    ///
    /// Available to both Platform and Enterprise Partners.
    /// </summary>
    WithRawResponseTask<AttachmentResponse> UploadAttachmentAsync(
        string caseUuid,
        UploadAttachmentCaseManagementRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Streams the file content of an attachment.
    ///
    /// Available to both Platform and Enterprise Partners.
    /// </summary>
    WithRawResponseTask<global::System.IO.Stream> GetAttachmentAsync(
        string caseUuid,
        string attachmentId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes an attachment from a case.
    ///
    /// Available to both Platform and Enterprise Partners.
    /// </summary>
    WithRawResponseTask DeleteAttachmentAsync(
        string caseUuid,
        string attachmentId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
