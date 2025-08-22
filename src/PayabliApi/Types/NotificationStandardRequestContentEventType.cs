using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<NotificationStandardRequestContentEventType>))]
[Serializable]
public readonly record struct NotificationStandardRequestContentEventType : IStringEnum
{
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
