namespace PayabliApi;

public partial interface IApplicationsClient
{
    /// <summary>
    /// Lists boarding applications with pagination.
    /// </summary>
    WithRawResponseTask<ListApplicationsEnvelope> ListApplicationsAsync(
        ListApplicationsApplicationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a boarding application for a business. The business must
    /// already have a paypoint. New applications start in `draft`.
    /// </summary>
    WithRawResponseTask<ApplicationEnvelope> CreateApplicationAsync(
        CreateApplicationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a boarding application by reference.
    /// </summary>
    WithRawResponseTask<ApplicationEnvelope> GetApplicationAsync(
        string requestsReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Applies a partial update to a boarding application. Send only the fields you want to change.
    /// </summary>
    WithRawResponseTask<ApplicationEnvelope> UpdateApplicationAsync(
        string requestsReference,
        UpdateApplicationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Checks whether the records linked to an application (the business, its people, and its payment methods) include everything the application's requested services need. The response lists any missing or invalid fields by section. Validation doesn't change the application, and it doesn't return a validation token. The request has no body.
    ///
    /// One owner on the application must be the signer, flagged with `isSigner` on their business link. If no one is flagged, the `people` section returns a `missingFields` entry with `field` set to `people.isSigner`, `label` set to `Signer`, and `reason` set to `required — choose the person who signs the application`. The signer rule isn't reported when the application has no people.
    ///
    /// The `people` section also checks ownership. At least one person must be the primary controller, flagged with `isPrimaryController`. If no one is, the entry has `field` set to `people.isPrimaryController`, `label` set to `Primary Controller`, and `reason` set to `required — at least one principal must be designated`. Unless the business's `legalStructure` is `government` or `non-profit`, at least one owner must have an `ownershipPercentage` of 25 or more. If no one does, the entry has `field` set to `people.ownershipPercentage`, `label` set to `Qualifying Owner`, and `reason` set to `at least one principal must have an ownership stake of 25% or more`.
    ///
    /// Validation also reports required documents that have nothing uploaded. See [List application document requirements](/developers/api-reference/applications/list-application-document-requirements). The bank statement requirement appears in the `business` section, with `field` set to `documents.bankStatement`. A person document appears in the `people` section, with `field` set to `people.{personReference}.` followed by the requirement's `fieldPath`, such as `people.01a0014d-ce1a-7110-9bac-c4c59647a88d.person.documents.w9`. Submit doesn't enforce document requirements.
    /// </summary>
    WithRawResponseTask<ValidationResultEnvelope> ValidateApplicationAsync(
        string requestsReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submits a draft application for review. Your integration (the applicant) calls this after the business, its people, payment methods, and services are in place. Verification then runs automatically.
    ///
    /// The application must have a signer: an owner flagged with `isSigner` on their business link, or one you name in `signer.personReference`. Payabli records the signer's identity from their person record and business link, so update those before you submit. The `signer` object carries the signature details.
    ///
    /// If the application has no signer, the request fails with `422` and the error `SIGNER_REQUIRED`. If `signer.personReference` names a person who isn't an owner, the request fails with `422` and the error `SIGNER_NOT_OWNER`. If the application isn't a draft, the request fails with `409` and the error `BIZ_004`, before any signer check. If `signer.reportedSignerIp` isn't a single valid IPv4 or IPv6 address, the request fails with `400` and the error `VALIDATION_ERROR`, and the application isn't submitted.
    ///
    /// Submit doesn't check every rule that [validate](/developers/api-reference/applications/validate-an-application) reports, such as the primary controller and ownership rules. Validate the application and resolve its missing fields before you submit.
    /// </summary>
    WithRawResponseTask<TransitionResultEnvelope> SubmitApplicationAsync(
        string requestsReference,
        SubmitApplicationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Marks the documents that Payabli requested during review as provided, when the application is in `pendingdocuments`. It returns the application to review. The request has no body.
    /// </summary>
    WithRawResponseTask<TransitionResultEnvelope> ProvideDocumentsAsync(
        string requestsReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Marks the information that Payabli requested during review as provided, when the application is in `pendingresponse`. It returns the application to review. The request has no body.
    /// </summary>
    WithRawResponseTask<TransitionResultEnvelope> ProvideResponseAsync(
        string requestsReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Withdraws a boarding application. The response returns the application's
    /// new status and the actions now allowed on it.
    /// </summary>
    WithRawResponseTask<TransitionResultEnvelope> WithdrawApplicationAsync(
        string requestsReference,
        WithdrawApplicationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the status transition history of a boarding application, oldest first. History records changes only. An approved application that fails enablement the same way on every attempt doesn't add entries, so use [enablement](/developers/api-reference/applications/get-application-enablement-progress) to follow that progress.
    /// </summary>
    WithRawResponseTask<StatusHistoryEnvelope> GetApplicationHistoryAsync(
        string requestsReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the progress of setting up an approved application's services with their processors. An application's status stays `approved` or `autoapproved` while this runs, and it moves to `activated` after every requested service is set up. Use this endpoint to see why an approved merchant isn't live yet.
    ///
    /// Enablement doesn't send webhooks, so poll this endpoint to follow it. Until enablement starts, `state` and the other progress fields are `null`, and `services` is empty. That includes applications that are in `draft`, withdrawn, or in `error`.
    /// </summary>
    WithRawResponseTask<EnablementEnvelope> GetApplicationEnablementAsync(
        string requestsReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists the documents an application asks for, from its template and from Payabli business rules. For example, a business with an annual revenue of $1,000,000 or more needs bank statements. Each requirement gives the `fieldPath` and `subject` to send when you upload, the formats it accepts, how many documents it takes, and how many are uploaded so far.
    ///
    /// A person requirement appears once for each owner of the business, with that owner's `personReference`. The list is empty when the application asks for no documents.
    /// </summary>
    WithRawResponseTask<DocumentRequirementListEnvelope> ListApplicationDocumentRequirementsAsync(
        string requestsReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists the documents uploaded to an application. The list is empty when none are uploaded.
    /// </summary>
    WithRawResponseTask<ApplicationDocumentListEnvelope> ListApplicationDocumentsAsync(
        string requestsReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Uploads one document to an application as multipart form data. [List the application's document requirements](/developers/api-reference/applications/list-application-document-requirements) first. Send the requirement's `fieldPath`, one of its `subjectTypes` as `subject`, and, for a person requirement, its `personReference`.
    ///
    /// The file can be up to 10 MB, in a format the requirement accepts. Payabli checks the file's content, not only its name. Each requirement takes up to `maxUploads` documents.
    ///
    /// Uploading doesn't change the application's status. When underwriting requests documents, upload them, then call [provide documents](/developers/api-reference/applications/provide-application-documents) to return the application to review.
    /// </summary>
    WithRawResponseTask<ApplicationDocumentEnvelope> UploadApplicationDocumentAsync(
        string requestsReference,
        UploadApplicationDocumentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes a document you uploaded from an application. Deleting doesn't change the application's status. A deleted document no longer counts toward its requirement, so you can upload a replacement. Deleting a document that's already deleted returns `404`.
    /// </summary>
    WithRawResponseTask DeleteApplicationDocumentAsync(
        string requestsReference,
        string documentReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
