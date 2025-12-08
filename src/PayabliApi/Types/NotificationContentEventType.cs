using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(typeof(StringEnumSerializer<NotificationContentEventType>))]
[Serializable]
public readonly record struct NotificationContentEventType : IStringEnum
{
    public static readonly NotificationContentEventType ApprovedPayment = new(
        Values.ApprovedPayment
    );

    public static readonly NotificationContentEventType AuthorizedPayment = new(
        Values.AuthorizedPayment
    );

    public static readonly NotificationContentEventType DeclinedPayment = new(
        Values.DeclinedPayment
    );

    public static readonly NotificationContentEventType OriginatedPayment = new(
        Values.OriginatedPayment
    );

    public static readonly NotificationContentEventType SettledPayment = new(Values.SettledPayment);

    public static readonly NotificationContentEventType SubscriptionCreated = new(
        Values.SubscriptionCreated
    );

    public static readonly NotificationContentEventType SubscriptionUpdated = new(
        Values.SubscriptionUpdated
    );

    public static readonly NotificationContentEventType SubscriptionCanceled = new(
        Values.SubscriptionCanceled
    );

    public static readonly NotificationContentEventType SubscriptionCompleted = new(
        Values.SubscriptionCompleted
    );

    public static readonly NotificationContentEventType FundedPayment = new(Values.FundedPayment);

    public static readonly NotificationContentEventType VoidedPayment = new(Values.VoidedPayment);

    public static readonly NotificationContentEventType RefundedPayment = new(
        Values.RefundedPayment
    );

    public static readonly NotificationContentEventType HoldTransaction = new(
        Values.HoldTransaction
    );

    public static readonly NotificationContentEventType ReleasedTransaction = new(
        Values.ReleasedTransaction
    );

    public static readonly NotificationContentEventType HoldBatch = new(Values.HoldBatch);

    public static readonly NotificationContentEventType ReleasedBatch = new(Values.ReleasedBatch);

    public static readonly NotificationContentEventType TransferDisabledCreditFund = new(
        Values.TransferDisabledCreditFund
    );

    public static readonly NotificationContentEventType TransferDisabledDebitFund = new(
        Values.TransferDisabledDebitFund
    );

    public static readonly NotificationContentEventType TransferNotAvailableBalance = new(
        Values.TransferNotAvailableBalance
    );

    public static readonly NotificationContentEventType TransferReturn = new(Values.TransferReturn);

    public static readonly NotificationContentEventType TransferSuccess = new(
        Values.TransferSuccess
    );

    public static readonly NotificationContentEventType TransferSuspended = new(
        Values.TransferSuspended
    );

    public static readonly NotificationContentEventType TransferError = new(Values.TransferError);

    public static readonly NotificationContentEventType SendReceipt = new(Values.SendReceipt);

    public static readonly NotificationContentEventType RecoveredTransaction = new(
        Values.RecoveredTransaction
    );

    public static readonly NotificationContentEventType CreatedApplication = new(
        Values.CreatedApplication
    );

    public static readonly NotificationContentEventType ApprovedApplication = new(
        Values.ApprovedApplication
    );

    public static readonly NotificationContentEventType FailedBoardingApplication = new(
        Values.FailedBoardingApplication
    );

    public static readonly NotificationContentEventType SubmittedApplication = new(
        Values.SubmittedApplication
    );

    public static readonly NotificationContentEventType UnderWritingApplication = new(
        Values.UnderWritingApplication
    );

    public static readonly NotificationContentEventType ActivatedMerchant = new(
        Values.ActivatedMerchant
    );

    public static readonly NotificationContentEventType ReceivedChargeBack = new(
        Values.ReceivedChargeBack
    );

    public static readonly NotificationContentEventType ChargebackUpdated = new(
        Values.ChargebackUpdated
    );

    public static readonly NotificationContentEventType ReceivedRetrieval = new(
        Values.ReceivedRetrieval
    );

    public static readonly NotificationContentEventType RetrievalUpdated = new(
        Values.RetrievalUpdated
    );

    public static readonly NotificationContentEventType ReceivedAchReturn = new(
        Values.ReceivedAchReturn
    );

    public static readonly NotificationContentEventType HoldingApplication = new(
        Values.HoldingApplication
    );

    public static readonly NotificationContentEventType DeclinedApplication = new(
        Values.DeclinedApplication
    );

    public static readonly NotificationContentEventType BoardingApplication = new(
        Values.BoardingApplication
    );

    public static readonly NotificationContentEventType FraudAlert = new(Values.FraudAlert);

    public static readonly NotificationContentEventType InvoiceSent = new(Values.InvoiceSent);

    public static readonly NotificationContentEventType InvoicePaid = new(Values.InvoicePaid);

    public static readonly NotificationContentEventType InvoiceCreated = new(Values.InvoiceCreated);

    public static readonly NotificationContentEventType BillPaid = new(Values.BillPaid);

    public static readonly NotificationContentEventType BillApproved = new(Values.BillApproved);

    public static readonly NotificationContentEventType BillDisApproved = new(
        Values.BillDisApproved
    );

    public static readonly NotificationContentEventType BillCanceled = new(Values.BillCanceled);

    public static readonly NotificationContentEventType BillProcessing = new(Values.BillProcessing);

    public static readonly NotificationContentEventType CardCreated = new(Values.CardCreated);

    public static readonly NotificationContentEventType CardActivated = new(Values.CardActivated);

    public static readonly NotificationContentEventType CardDeactivated = new(
        Values.CardDeactivated
    );

    public static readonly NotificationContentEventType CardExpired = new(Values.CardExpired);

    public static readonly NotificationContentEventType CardExpiring = new(Values.CardExpiring);

    public static readonly NotificationContentEventType CardLimitUpdated = new(
        Values.CardLimitUpdated
    );

    public static readonly NotificationContentEventType BatchClosed = new(Values.BatchClosed);

    public static readonly NotificationContentEventType BatchNotClosed = new(Values.BatchNotClosed);

    public static readonly NotificationContentEventType PayOutFunded = new(Values.PayOutFunded);

    public static readonly NotificationContentEventType PayOutProcessed = new(
        Values.PayOutProcessed
    );

    public static readonly NotificationContentEventType PayOutCanceled = new(Values.PayOutCanceled);

    public static readonly NotificationContentEventType PayOutPaid = new(Values.PayOutPaid);

    public static readonly NotificationContentEventType PayOutReturned = new(Values.PayOutReturned);

    public static readonly NotificationContentEventType PayoutSubscriptionCreated = new(
        Values.PayoutSubscriptionCreated
    );

    public static readonly NotificationContentEventType PayoutSubscriptionUpdated = new(
        Values.PayoutSubscriptionUpdated
    );

    public static readonly NotificationContentEventType PayoutSubscriptionCanceled = new(
        Values.PayoutSubscriptionCanceled
    );

    public static readonly NotificationContentEventType PayoutSubscriptionCompleted = new(
        Values.PayoutSubscriptionCompleted
    );

    public static readonly NotificationContentEventType PayoutSubscriptionReminder = new(
        Values.PayoutSubscriptionReminder
    );

    public static readonly NotificationContentEventType ImportFileReceived = new(
        Values.ImportFileReceived
    );

    public static readonly NotificationContentEventType ImportFileProcessed = new(
        Values.ImportFileProcessed
    );

    public static readonly NotificationContentEventType ImportFileError = new(
        Values.ImportFileError
    );

    public static readonly NotificationContentEventType ExportFileSent = new(Values.ExportFileSent);

    public static readonly NotificationContentEventType ExportFileError = new(
        Values.ExportFileError
    );

    public static readonly NotificationContentEventType FailedEmailNotification = new(
        Values.FailedEmailNotification
    );

    public static readonly NotificationContentEventType FailedWebNotification = new(
        Values.FailedWebNotification
    );

    public static readonly NotificationContentEventType FailedSmsNotification = new(
        Values.FailedSmsNotification
    );

    public static readonly NotificationContentEventType UserPasswordExpiring = new(
        Values.UserPasswordExpiring
    );

    public static readonly NotificationContentEventType UserPasswordExpired = new(
        Values.UserPasswordExpired
    );

    public static readonly NotificationContentEventType TransactionNotFound = new(
        Values.TransactionNotFound
    );

    public static readonly NotificationContentEventType SystemAlert = new(Values.SystemAlert);

    public static readonly NotificationContentEventType Report = new(Values.Report);

    public NotificationContentEventType(string value)
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
    public static NotificationContentEventType FromCustom(string value)
    {
        return new NotificationContentEventType(value);
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

    public static bool operator ==(NotificationContentEventType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(NotificationContentEventType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(NotificationContentEventType value) => value.Value;

    public static explicit operator NotificationContentEventType(string value) => new(value);

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

        public const string TransferDisabledCreditFund = "TransferDisabledCreditFund";

        public const string TransferDisabledDebitFund = "TransferDisabledDebitFund";

        public const string TransferNotAvailableBalance = "TransferNotAvailableBalance";

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

        public const string FailedEmailNotification = "FailedEmailNotification";

        public const string FailedWebNotification = "FailedWebNotification";

        public const string FailedSmsNotification = "FailedSMSNotification";

        public const string UserPasswordExpiring = "UserPasswordExpiring";

        public const string UserPasswordExpired = "UserPasswordExpired";

        public const string TransactionNotFound = "TransactionNotFound";

        public const string SystemAlert = "SystemAlert";

        public const string Report = "Report";
    }
}
