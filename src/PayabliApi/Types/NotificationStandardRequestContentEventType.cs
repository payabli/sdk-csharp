using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<NotificationStandardRequestContentEventType>))]
[Serializable]
public readonly record struct NotificationStandardRequestContentEventType : IStringEnum
{
    public static readonly NotificationStandardRequestContentEventType PayinTransactionInitiated =
        new(Values.PayinTransactionInitiated);

    public static readonly NotificationStandardRequestContentEventType PayinTransactionAuthorized =
        new(Values.PayinTransactionAuthorized);

    public static readonly NotificationStandardRequestContentEventType PayinTransactionApprovedcaptured =
        new(Values.PayinTransactionApprovedcaptured);

    public static readonly NotificationStandardRequestContentEventType PayinTransactionDeclined =
        new(Values.PayinTransactionDeclined);

    public static readonly NotificationStandardRequestContentEventType PayinTransactionTechnicaldecline =
        new(Values.PayinTransactionTechnicaldecline);

    public static readonly NotificationStandardRequestContentEventType PayinTransactionFailed = new(
        Values.PayinTransactionFailed
    );

    public static readonly NotificationStandardRequestContentEventType PayinTransactionError = new(
        Values.PayinTransactionError
    );

    public static readonly NotificationStandardRequestContentEventType PayinTransactionPaid = new(
        Values.PayinTransactionPaid
    );

    public static readonly NotificationStandardRequestContentEventType PayinTransactionReturned =
        new(Values.PayinTransactionReturned);

    public static readonly NotificationStandardRequestContentEventType PayinTransactionRejected =
        new(Values.PayinTransactionRejected);

    public static readonly NotificationStandardRequestContentEventType PayinTransactionVoidedcancelled =
        new(Values.PayinTransactionVoidedcancelled);

    public static readonly NotificationStandardRequestContentEventType PayinTransactionProcessing =
        new(Values.PayinTransactionProcessing);

    public static readonly NotificationStandardRequestContentEventType PayinTransactionProcessed =
        new(Values.PayinTransactionProcessed);

    public static readonly NotificationStandardRequestContentEventType PayinTransactionOnhold = new(
        Values.PayinTransactionOnhold
    );

    public static readonly NotificationStandardRequestContentEventType PayinTransactionReleased =
        new(Values.PayinTransactionReleased);

    public static readonly NotificationStandardRequestContentEventType PayinTransactionRecovered =
        new(Values.PayinTransactionRecovered);

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionInitiated =
        new(Values.PayoutTransactionInitiated);

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionAuthorized =
        new(Values.PayoutTransactionAuthorized);

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionApprovedcaptured =
        new(Values.PayoutTransactionApprovedcaptured);

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionDeclined =
        new(Values.PayoutTransactionDeclined);

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionTechnicaldecline =
        new(Values.PayoutTransactionTechnicaldecline);

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionFailed =
        new(Values.PayoutTransactionFailed);

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionError = new(
        Values.PayoutTransactionError
    );

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionPaid = new(
        Values.PayoutTransactionPaid
    );

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionReturned =
        new(Values.PayoutTransactionReturned);

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionRejected =
        new(Values.PayoutTransactionRejected);

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionVoidedcancelled =
        new(Values.PayoutTransactionVoidedcancelled);

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionProcessing =
        new(Values.PayoutTransactionProcessing);

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionProcessed =
        new(Values.PayoutTransactionProcessed);

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionOnhold =
        new(Values.PayoutTransactionOnhold);

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionReleased =
        new(Values.PayoutTransactionReleased);

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionRecovered =
        new(Values.PayoutTransactionRecovered);

    public static readonly NotificationStandardRequestContentEventType PayinBatchOpen = new(
        Values.PayinBatchOpen
    );

    public static readonly NotificationStandardRequestContentEventType PayinBatchOnhold = new(
        Values.PayinBatchOnhold
    );

    public static readonly NotificationStandardRequestContentEventType PayinBatchReleased = new(
        Values.PayinBatchReleased
    );

    public static readonly NotificationStandardRequestContentEventType PayinBatchProcessed = new(
        Values.PayinBatchProcessed
    );

    public static readonly NotificationStandardRequestContentEventType PayinBatchPaid = new(
        Values.PayinBatchPaid
    );

    public static readonly NotificationStandardRequestContentEventType PayinBatchFunded = new(
        Values.PayinBatchFunded
    );

    public static readonly NotificationStandardRequestContentEventType PayinBatchClosed = new(
        Values.PayinBatchClosed
    );

    public static readonly NotificationStandardRequestContentEventType PayinBatchNotclosed = new(
        Values.PayinBatchNotclosed
    );

    public static readonly NotificationStandardRequestContentEventType PayinBatchFundpending = new(
        Values.PayinBatchFundpending
    );

    public static readonly NotificationStandardRequestContentEventType PayinBatchCancelled = new(
        Values.PayinBatchCancelled
    );

    public static readonly NotificationStandardRequestContentEventType PayinBatchTransferred = new(
        Values.PayinBatchTransferred
    );

    public static readonly NotificationStandardRequestContentEventType PayinBatchResolved = new(
        Values.PayinBatchResolved
    );

    public static readonly NotificationStandardRequestContentEventType PayoutBatchOpen = new(
        Values.PayoutBatchOpen
    );

    public static readonly NotificationStandardRequestContentEventType PayoutBatchOnhold = new(
        Values.PayoutBatchOnhold
    );

    public static readonly NotificationStandardRequestContentEventType PayoutBatchReleased = new(
        Values.PayoutBatchReleased
    );

    public static readonly NotificationStandardRequestContentEventType PayoutBatchProcessed = new(
        Values.PayoutBatchProcessed
    );

    public static readonly NotificationStandardRequestContentEventType PayoutBatchPaid = new(
        Values.PayoutBatchPaid
    );

    public static readonly NotificationStandardRequestContentEventType PayoutBatchFunded = new(
        Values.PayoutBatchFunded
    );

    public static readonly NotificationStandardRequestContentEventType PayoutBatchClosed = new(
        Values.PayoutBatchClosed
    );

    public static readonly NotificationStandardRequestContentEventType PayoutBatchNotclosed = new(
        Values.PayoutBatchNotclosed
    );

    public static readonly NotificationStandardRequestContentEventType PayoutBatchFundpending = new(
        Values.PayoutBatchFundpending
    );

    public static readonly NotificationStandardRequestContentEventType PayoutBatchCancelled = new(
        Values.PayoutBatchCancelled
    );

    public static readonly NotificationStandardRequestContentEventType PayoutBatchTransferred = new(
        Values.PayoutBatchTransferred
    );

    public static readonly NotificationStandardRequestContentEventType PayoutBatchResolved = new(
        Values.PayoutBatchResolved
    );

    public static readonly NotificationStandardRequestContentEventType PayinBatchSettlementPending =
        new(Values.PayinBatchSettlementPending);

    public static readonly NotificationStandardRequestContentEventType PayinBatchSettlementIntransit =
        new(Values.PayinBatchSettlementIntransit);

    public static readonly NotificationStandardRequestContentEventType PayinBatchSettlementTransferred =
        new(Values.PayinBatchSettlementTransferred);

    public static readonly NotificationStandardRequestContentEventType PayinBatchSettlementFunded =
        new(Values.PayinBatchSettlementFunded);

    public static readonly NotificationStandardRequestContentEventType PayinBatchSettlementResolved =
        new(Values.PayinBatchSettlementResolved);

    public static readonly NotificationStandardRequestContentEventType PayinBatchSettlementException =
        new(Values.PayinBatchSettlementException);

    public static readonly NotificationStandardRequestContentEventType PayinBatchSettlementAchreturn =
        new(Values.PayinBatchSettlementAchreturn);

    public static readonly NotificationStandardRequestContentEventType PayinBatchSettlementHeld =
        new(Values.PayinBatchSettlementHeld);

    public static readonly NotificationStandardRequestContentEventType PayinBatchSettlementReleased =
        new(Values.PayinBatchSettlementReleased);

    public static readonly NotificationStandardRequestContentEventType PayoutBatchSettlementPending =
        new(Values.PayoutBatchSettlementPending);

    public static readonly NotificationStandardRequestContentEventType PayoutBatchSettlementIntransit =
        new(Values.PayoutBatchSettlementIntransit);

    public static readonly NotificationStandardRequestContentEventType PayoutBatchSettlementTransferred =
        new(Values.PayoutBatchSettlementTransferred);

    public static readonly NotificationStandardRequestContentEventType PayoutBatchSettlementFunded =
        new(Values.PayoutBatchSettlementFunded);

    public static readonly NotificationStandardRequestContentEventType PayoutBatchSettlementResolved =
        new(Values.PayoutBatchSettlementResolved);

    public static readonly NotificationStandardRequestContentEventType PayoutBatchSettlementException =
        new(Values.PayoutBatchSettlementException);

    public static readonly NotificationStandardRequestContentEventType PayoutBatchSettlementAchreturn =
        new(Values.PayoutBatchSettlementAchreturn);

    public static readonly NotificationStandardRequestContentEventType PayoutBatchSettlementHeld =
        new(Values.PayoutBatchSettlementHeld);

    public static readonly NotificationStandardRequestContentEventType PayoutBatchSettlementReleased =
        new(Values.PayoutBatchSettlementReleased);

    public static readonly NotificationStandardRequestContentEventType ApprovedPayment = new(
        Values.ApprovedPayment
    );

    public static readonly NotificationStandardRequestContentEventType AuthorizedPayment = new(
        Values.AuthorizedPayment
    );

    public static readonly NotificationStandardRequestContentEventType DeclinedPayment = new(
        Values.DeclinedPayment
    );

    public static readonly NotificationStandardRequestContentEventType OriginatedPayment = new(
        Values.OriginatedPayment
    );

    public static readonly NotificationStandardRequestContentEventType SettledPayment = new(
        Values.SettledPayment
    );

    public static readonly NotificationStandardRequestContentEventType SubscriptionCreated = new(
        Values.SubscriptionCreated
    );

    public static readonly NotificationStandardRequestContentEventType SubscriptionUpdated = new(
        Values.SubscriptionUpdated
    );

    public static readonly NotificationStandardRequestContentEventType SubscriptionCanceled = new(
        Values.SubscriptionCanceled
    );

    public static readonly NotificationStandardRequestContentEventType SubscriptionCompleted = new(
        Values.SubscriptionCompleted
    );

    public static readonly NotificationStandardRequestContentEventType FundedPayment = new(
        Values.FundedPayment
    );

    public static readonly NotificationStandardRequestContentEventType VoidedPayment = new(
        Values.VoidedPayment
    );

    public static readonly NotificationStandardRequestContentEventType RefundedPayment = new(
        Values.RefundedPayment
    );

    public static readonly NotificationStandardRequestContentEventType HoldTransaction = new(
        Values.HoldTransaction
    );

    public static readonly NotificationStandardRequestContentEventType ReleasedTransaction = new(
        Values.ReleasedTransaction
    );

    public static readonly NotificationStandardRequestContentEventType HoldBatch = new(
        Values.HoldBatch
    );

    public static readonly NotificationStandardRequestContentEventType ReleasedBatch = new(
        Values.ReleasedBatch
    );

    public static readonly NotificationStandardRequestContentEventType TransferAdjusted = new(
        Values.TransferAdjusted
    );

    public static readonly NotificationStandardRequestContentEventType TransferDisabledCreditFund =
        new(Values.TransferDisabledCreditFund);

    public static readonly NotificationStandardRequestContentEventType TransferDisabledDebitFund =
        new(Values.TransferDisabledDebitFund);

    public static readonly NotificationStandardRequestContentEventType TransferNotAvailableBalance =
        new(Values.TransferNotAvailableBalance);

    public static readonly NotificationStandardRequestContentEventType TransferReadyforRetry = new(
        Values.TransferReadyforRetry
    );

    public static readonly NotificationStandardRequestContentEventType TransferResolved = new(
        Values.TransferResolved
    );

    public static readonly NotificationStandardRequestContentEventType TransferReturn = new(
        Values.TransferReturn
    );

    public static readonly NotificationStandardRequestContentEventType TransferSuccess = new(
        Values.TransferSuccess
    );

    public static readonly NotificationStandardRequestContentEventType TransferSuspended = new(
        Values.TransferSuspended
    );

    public static readonly NotificationStandardRequestContentEventType TransferError = new(
        Values.TransferError
    );

    public static readonly NotificationStandardRequestContentEventType SendReceipt = new(
        Values.SendReceipt
    );

    public static readonly NotificationStandardRequestContentEventType RecoveredTransaction = new(
        Values.RecoveredTransaction
    );

    public static readonly NotificationStandardRequestContentEventType CreatedApplication = new(
        Values.CreatedApplication
    );

    public static readonly NotificationStandardRequestContentEventType ApprovedApplication = new(
        Values.ApprovedApplication
    );

    public static readonly NotificationStandardRequestContentEventType FailedBoardingApplication =
        new(Values.FailedBoardingApplication);

    public static readonly NotificationStandardRequestContentEventType SubmittedApplication = new(
        Values.SubmittedApplication
    );

    public static readonly NotificationStandardRequestContentEventType UnderWritingApplication =
        new(Values.UnderWritingApplication);

    public static readonly NotificationStandardRequestContentEventType ActivatedMerchant = new(
        Values.ActivatedMerchant
    );

    public static readonly NotificationStandardRequestContentEventType ReceivedChargeBack = new(
        Values.ReceivedChargeBack
    );

    public static readonly NotificationStandardRequestContentEventType ChargebackUpdated = new(
        Values.ChargebackUpdated
    );

    public static readonly NotificationStandardRequestContentEventType ReceivedRetrieval = new(
        Values.ReceivedRetrieval
    );

    public static readonly NotificationStandardRequestContentEventType RetrievalUpdated = new(
        Values.RetrievalUpdated
    );

    public static readonly NotificationStandardRequestContentEventType ReceivedAchReturn = new(
        Values.ReceivedAchReturn
    );

    public static readonly NotificationStandardRequestContentEventType HoldingApplication = new(
        Values.HoldingApplication
    );

    public static readonly NotificationStandardRequestContentEventType DeclinedApplication = new(
        Values.DeclinedApplication
    );

    public static readonly NotificationStandardRequestContentEventType BoardingApplication = new(
        Values.BoardingApplication
    );

    public static readonly NotificationStandardRequestContentEventType PaypointMoved = new(
        Values.PaypointMoved
    );

    public static readonly NotificationStandardRequestContentEventType FraudAlert = new(
        Values.FraudAlert
    );

    public static readonly NotificationStandardRequestContentEventType InvoiceSent = new(
        Values.InvoiceSent
    );

    public static readonly NotificationStandardRequestContentEventType InvoicePaid = new(
        Values.InvoicePaid
    );

    public static readonly NotificationStandardRequestContentEventType InvoiceCreated = new(
        Values.InvoiceCreated
    );

    public static readonly NotificationStandardRequestContentEventType BillPaid = new(
        Values.BillPaid
    );

    public static readonly NotificationStandardRequestContentEventType BillApproved = new(
        Values.BillApproved
    );

    public static readonly NotificationStandardRequestContentEventType BillDisApproved = new(
        Values.BillDisApproved
    );

    public static readonly NotificationStandardRequestContentEventType BillCanceled = new(
        Values.BillCanceled
    );

    public static readonly NotificationStandardRequestContentEventType BillProcessing = new(
        Values.BillProcessing
    );

    public static readonly NotificationStandardRequestContentEventType CardCreated = new(
        Values.CardCreated
    );

    public static readonly NotificationStandardRequestContentEventType CardActivated = new(
        Values.CardActivated
    );

    public static readonly NotificationStandardRequestContentEventType CardDeactivated = new(
        Values.CardDeactivated
    );

    public static readonly NotificationStandardRequestContentEventType CardExpired = new(
        Values.CardExpired
    );

    public static readonly NotificationStandardRequestContentEventType CardExpiring = new(
        Values.CardExpiring
    );

    public static readonly NotificationStandardRequestContentEventType CardLimitUpdated = new(
        Values.CardLimitUpdated
    );

    public static readonly NotificationStandardRequestContentEventType BatchClosed = new(
        Values.BatchClosed
    );

    public static readonly NotificationStandardRequestContentEventType BatchNotClosed = new(
        Values.BatchNotClosed
    );

    public static readonly NotificationStandardRequestContentEventType PayOutFunded = new(
        Values.PayOutFunded
    );

    public static readonly NotificationStandardRequestContentEventType PayOutProcessed = new(
        Values.PayOutProcessed
    );

    public static readonly NotificationStandardRequestContentEventType PayOutCanceled = new(
        Values.PayOutCanceled
    );

    public static readonly NotificationStandardRequestContentEventType PayOutPaid = new(
        Values.PayOutPaid
    );

    public static readonly NotificationStandardRequestContentEventType PayOutReturned = new(
        Values.PayOutReturned
    );

    public static readonly NotificationStandardRequestContentEventType PayoutSubscriptionCreated =
        new(Values.PayoutSubscriptionCreated);

    public static readonly NotificationStandardRequestContentEventType PayoutSubscriptionUpdated =
        new(Values.PayoutSubscriptionUpdated);

    public static readonly NotificationStandardRequestContentEventType PayoutSubscriptionCanceled =
        new(Values.PayoutSubscriptionCanceled);

    public static readonly NotificationStandardRequestContentEventType PayoutSubscriptionCompleted =
        new(Values.PayoutSubscriptionCompleted);

    public static readonly NotificationStandardRequestContentEventType PayoutSubscriptionReminder =
        new(Values.PayoutSubscriptionReminder);

    public static readonly NotificationStandardRequestContentEventType ImportFileReceived = new(
        Values.ImportFileReceived
    );

    public static readonly NotificationStandardRequestContentEventType ImportFileProcessed = new(
        Values.ImportFileProcessed
    );

    public static readonly NotificationStandardRequestContentEventType ImportFileError = new(
        Values.ImportFileError
    );

    public static readonly NotificationStandardRequestContentEventType ExportFileSent = new(
        Values.ExportFileSent
    );

    public static readonly NotificationStandardRequestContentEventType ExportFileError = new(
        Values.ExportFileError
    );

    public static readonly NotificationStandardRequestContentEventType UpdatedMerchant = new(
        Values.UpdatedMerchant
    );

    public static readonly NotificationStandardRequestContentEventType Report = new(Values.Report);

    public static readonly NotificationStandardRequestContentEventType FailedEmailNotification =
        new(Values.FailedEmailNotification);

    public static readonly NotificationStandardRequestContentEventType FailedWebNotification = new(
        Values.FailedWebNotification
    );

    public static readonly NotificationStandardRequestContentEventType FailedSmsNotification = new(
        Values.FailedSmsNotification
    );

    public static readonly NotificationStandardRequestContentEventType UserPasswordExpiring = new(
        Values.UserPasswordExpiring
    );

    public static readonly NotificationStandardRequestContentEventType UserPasswordExpired = new(
        Values.UserPasswordExpired
    );

    public static readonly NotificationStandardRequestContentEventType TransactionNotFound = new(
        Values.TransactionNotFound
    );

    public static readonly NotificationStandardRequestContentEventType SystemAlert = new(
        Values.SystemAlert
    );

    public NotificationStandardRequestContentEventType(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static NotificationStandardRequestContentEventType FromCustom(string value)
    {
        return new NotificationStandardRequestContentEventType(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(
        NotificationStandardRequestContentEventType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        NotificationStandardRequestContentEventType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(NotificationStandardRequestContentEventType value) =>
        value.Value;

    public static explicit operator NotificationStandardRequestContentEventType(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string PayinTransactionInitiated = "payin_transaction_initiated";

        public const string PayinTransactionAuthorized = "payin_transaction_authorized";

        public const string PayinTransactionApprovedcaptured = "payin_transaction_approvedcaptured";

        public const string PayinTransactionDeclined = "payin_transaction_declined";

        public const string PayinTransactionTechnicaldecline = "payin_transaction_technicaldecline";

        public const string PayinTransactionFailed = "payin_transaction_failed";

        public const string PayinTransactionError = "payin_transaction_error";

        public const string PayinTransactionPaid = "payin_transaction_paid";

        public const string PayinTransactionReturned = "payin_transaction_returned";

        public const string PayinTransactionRejected = "payin_transaction_rejected";

        public const string PayinTransactionVoidedcancelled = "payin_transaction_voidedcancelled";

        public const string PayinTransactionProcessing = "payin_transaction_processing";

        public const string PayinTransactionProcessed = "payin_transaction_processed";

        public const string PayinTransactionOnhold = "payin_transaction_onhold";

        public const string PayinTransactionReleased = "payin_transaction_released";

        public const string PayinTransactionRecovered = "payin_transaction_recovered";

        public const string PayoutTransactionInitiated = "payout_transaction_initiated";

        public const string PayoutTransactionAuthorized = "payout_transaction_authorized";

        public const string PayoutTransactionApprovedcaptured =
            "payout_transaction_approvedcaptured";

        public const string PayoutTransactionDeclined = "payout_transaction_declined";

        public const string PayoutTransactionTechnicaldecline =
            "payout_transaction_technicaldecline";

        public const string PayoutTransactionFailed = "payout_transaction_failed";

        public const string PayoutTransactionError = "payout_transaction_error";

        public const string PayoutTransactionPaid = "payout_transaction_paid";

        public const string PayoutTransactionReturned = "payout_transaction_returned";

        public const string PayoutTransactionRejected = "payout_transaction_rejected";

        public const string PayoutTransactionVoidedcancelled = "payout_transaction_voidedcancelled";

        public const string PayoutTransactionProcessing = "payout_transaction_processing";

        public const string PayoutTransactionProcessed = "payout_transaction_processed";

        public const string PayoutTransactionOnhold = "payout_transaction_onhold";

        public const string PayoutTransactionReleased = "payout_transaction_released";

        public const string PayoutTransactionRecovered = "payout_transaction_recovered";

        public const string PayinBatchOpen = "payin_batch_open";

        public const string PayinBatchOnhold = "payin_batch_onhold";

        public const string PayinBatchReleased = "payin_batch_released";

        public const string PayinBatchProcessed = "payin_batch_processed";

        public const string PayinBatchPaid = "payin_batch_paid";

        public const string PayinBatchFunded = "payin_batch_funded";

        public const string PayinBatchClosed = "payin_batch_closed";

        public const string PayinBatchNotclosed = "payin_batch_notclosed";

        public const string PayinBatchFundpending = "payin_batch_fundpending";

        public const string PayinBatchCancelled = "payin_batch_cancelled";

        public const string PayinBatchTransferred = "payin_batch_transferred";

        public const string PayinBatchResolved = "payin_batch_resolved";

        public const string PayoutBatchOpen = "payout_batch_open";

        public const string PayoutBatchOnhold = "payout_batch_onhold";

        public const string PayoutBatchReleased = "payout_batch_released";

        public const string PayoutBatchProcessed = "payout_batch_processed";

        public const string PayoutBatchPaid = "payout_batch_paid";

        public const string PayoutBatchFunded = "payout_batch_funded";

        public const string PayoutBatchClosed = "payout_batch_closed";

        public const string PayoutBatchNotclosed = "payout_batch_notclosed";

        public const string PayoutBatchFundpending = "payout_batch_fundpending";

        public const string PayoutBatchCancelled = "payout_batch_cancelled";

        public const string PayoutBatchTransferred = "payout_batch_transferred";

        public const string PayoutBatchResolved = "payout_batch_resolved";

        public const string PayinBatchSettlementPending = "payin_batch_settlement_pending";

        public const string PayinBatchSettlementIntransit = "payin_batch_settlement_intransit";

        public const string PayinBatchSettlementTransferred = "payin_batch_settlement_transferred";

        public const string PayinBatchSettlementFunded = "payin_batch_settlement_funded";

        public const string PayinBatchSettlementResolved = "payin_batch_settlement_resolved";

        public const string PayinBatchSettlementException = "payin_batch_settlement_exception";

        public const string PayinBatchSettlementAchreturn = "payin_batch_settlement_achreturn";

        public const string PayinBatchSettlementHeld = "payin_batch_settlement_held";

        public const string PayinBatchSettlementReleased = "payin_batch_settlement_released";

        public const string PayoutBatchSettlementPending = "payout_batch_settlement_pending";

        public const string PayoutBatchSettlementIntransit = "payout_batch_settlement_intransit";

        public const string PayoutBatchSettlementTransferred =
            "payout_batch_settlement_transferred";

        public const string PayoutBatchSettlementFunded = "payout_batch_settlement_funded";

        public const string PayoutBatchSettlementResolved = "payout_batch_settlement_resolved";

        public const string PayoutBatchSettlementException = "payout_batch_settlement_exception";

        public const string PayoutBatchSettlementAchreturn = "payout_batch_settlement_achreturn";

        public const string PayoutBatchSettlementHeld = "payout_batch_settlement_held";

        public const string PayoutBatchSettlementReleased = "payout_batch_settlement_released";

        public const string ApprovedPayment = "ApprovedPayment";

        public const string AuthorizedPayment = "AuthorizedPayment";

        public const string DeclinedPayment = "DeclinedPayment";

        public const string OriginatedPayment = "OriginatedPayment";

        public const string SettledPayment = "SettledPayment";

        public const string SubscriptionCreated = "SubscriptionCreated";

        public const string SubscriptionUpdated = "SubscriptionUpdated";

        public const string SubscriptionCanceled = "SubscriptionCanceled";

        public const string SubscriptionCompleted = "SubscriptionCompleted";

        public const string FundedPayment = "FundedPayment";

        public const string VoidedPayment = "VoidedPayment";

        public const string RefundedPayment = "RefundedPayment";

        public const string HoldTransaction = "HoldTransaction";

        public const string ReleasedTransaction = "ReleasedTransaction";

        public const string HoldBatch = "HoldBatch";

        public const string ReleasedBatch = "ReleasedBatch";

        public const string TransferAdjusted = "TransferAdjusted";

        public const string TransferDisabledCreditFund = "TransferDisabledCreditFund";

        public const string TransferDisabledDebitFund = "TransferDisabledDebitFund";

        public const string TransferNotAvailableBalance = "TransferNotAvailableBalance";

        public const string TransferReadyforRetry = "TransferReadyforRetry";

        public const string TransferResolved = "TransferResolved";

        public const string TransferReturn = "TransferReturn";

        public const string TransferSuccess = "TransferSuccess";

        public const string TransferSuspended = "TransferSuspended";

        public const string TransferError = "TransferError";

        public const string SendReceipt = "SendReceipt";

        public const string RecoveredTransaction = "RecoveredTransaction";

        public const string CreatedApplication = "CreatedApplication";

        public const string ApprovedApplication = "ApprovedApplication";

        public const string FailedBoardingApplication = "FailedBoardingApplication";

        public const string SubmittedApplication = "SubmittedApplication";

        public const string UnderWritingApplication = "UnderWritingApplication";

        public const string ActivatedMerchant = "ActivatedMerchant";

        public const string ReceivedChargeBack = "ReceivedChargeBack";

        public const string ChargebackUpdated = "ChargebackUpdated";

        public const string ReceivedRetrieval = "ReceivedRetrieval";

        public const string RetrievalUpdated = "RetrievalUpdated";

        public const string ReceivedAchReturn = "ReceivedAchReturn";

        public const string HoldingApplication = "HoldingApplication";

        public const string DeclinedApplication = "DeclinedApplication";

        public const string BoardingApplication = "BoardingApplication";

        public const string PaypointMoved = "PaypointMoved";

        public const string FraudAlert = "FraudAlert";

        public const string InvoiceSent = "InvoiceSent";

        public const string InvoicePaid = "InvoicePaid";

        public const string InvoiceCreated = "InvoiceCreated";

        public const string BillPaid = "BillPaid";

        public const string BillApproved = "BillApproved";

        public const string BillDisApproved = "BillDisApproved";

        public const string BillCanceled = "BillCanceled";

        public const string BillProcessing = "BillProcessing";

        public const string CardCreated = "CardCreated";

        public const string CardActivated = "CardActivated";

        public const string CardDeactivated = "CardDeactivated";

        public const string CardExpired = "CardExpired";

        public const string CardExpiring = "CardExpiring";

        public const string CardLimitUpdated = "CardLimitUpdated";

        public const string BatchClosed = "BatchClosed";

        public const string BatchNotClosed = "BatchNotClosed";

        public const string PayOutFunded = "PayOutFunded";

        public const string PayOutProcessed = "PayOutProcessed";

        public const string PayOutCanceled = "PayOutCanceled";

        public const string PayOutPaid = "PayOutPaid";

        public const string PayOutReturned = "PayOutReturned";

        public const string PayoutSubscriptionCreated = "PayoutSubscriptionCreated";

        public const string PayoutSubscriptionUpdated = "PayoutSubscriptionUpdated";

        public const string PayoutSubscriptionCanceled = "PayoutSubscriptionCanceled";

        public const string PayoutSubscriptionCompleted = "PayoutSubscriptionCompleted";

        public const string PayoutSubscriptionReminder = "PayoutSubscriptionReminder";

        public const string ImportFileReceived = "importFileReceived";

        public const string ImportFileProcessed = "importFileProcessed";

        public const string ImportFileError = "importFileError";

        public const string ExportFileSent = "exportFileSent";

        public const string ExportFileError = "exportFileError";

        public const string UpdatedMerchant = "UpdatedMerchant";

        public const string Report = "Report";

        public const string FailedEmailNotification = "FailedEmailNotification";

        public const string FailedWebNotification = "FailedWebNotification";

        public const string FailedSmsNotification = "FailedSMSNotification";

        public const string UserPasswordExpiring = "UserPasswordExpiring";

        public const string UserPasswordExpired = "UserPasswordExpired";

        public const string TransactionNotFound = "TransactionNotFound";

        public const string SystemAlert = "SystemAlert";
    }
}
