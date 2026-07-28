using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[JsonConverter(
    typeof(NotificationStandardRequestContentEventType.NotificationStandardRequestContentEventTypeSerializer)
)]
[Serializable]
public readonly record struct NotificationStandardRequestContentEventType : IStringEnum
{
    public static readonly NotificationStandardRequestContentEventType Approvedpayment = new(
        Values.Approvedpayment
    );

    public static readonly NotificationStandardRequestContentEventType Authorizedpayment = new(
        Values.Authorizedpayment
    );

    public static readonly NotificationStandardRequestContentEventType Declinedpayment = new(
        Values.Declinedpayment
    );

    public static readonly NotificationStandardRequestContentEventType Fundedpayment = new(
        Values.Fundedpayment
    );

    public static readonly NotificationStandardRequestContentEventType Originatedpayment = new(
        Values.Originatedpayment
    );

    public static readonly NotificationStandardRequestContentEventType Refundedpayment = new(
        Values.Refundedpayment
    );

    public static readonly NotificationStandardRequestContentEventType Settledpayment = new(
        Values.Settledpayment
    );

    public static readonly NotificationStandardRequestContentEventType Voidedpayment = new(
        Values.Voidedpayment
    );

    public static readonly NotificationStandardRequestContentEventType PayinTransactionOnhold = new(
        Values.PayinTransactionOnhold
    );

    public static readonly NotificationStandardRequestContentEventType PayinTransactionReleased =
        new(Values.PayinTransactionReleased);

    public static readonly NotificationStandardRequestContentEventType PayinTransactionRecovered =
        new(Values.PayinTransactionRecovered);

    public static readonly NotificationStandardRequestContentEventType PayinTransactionRejected =
        new(Values.PayinTransactionRejected);

    public static readonly NotificationStandardRequestContentEventType PayinBatchOnhold = new(
        Values.PayinBatchOnhold
    );

    public static readonly NotificationStandardRequestContentEventType PayinBatchReleased = new(
        Values.PayinBatchReleased
    );

    public static readonly NotificationStandardRequestContentEventType Transfersuccess = new(
        Values.Transfersuccess
    );

    public static readonly NotificationStandardRequestContentEventType Transferadjusted = new(
        Values.Transferadjusted
    );

    public static readonly NotificationStandardRequestContentEventType Transferreturn = new(
        Values.Transferreturn
    );

    public static readonly NotificationStandardRequestContentEventType Transfererror = new(
        Values.Transfererror
    );

    public static readonly NotificationStandardRequestContentEventType Transferbalanceunavailable =
        new(Values.Transferbalanceunavailable);

    public static readonly NotificationStandardRequestContentEventType Transferreadyforretry = new(
        Values.Transferreadyforretry
    );

    public static readonly NotificationStandardRequestContentEventType Transferresolved = new(
        Values.Transferresolved
    );

    public static readonly NotificationStandardRequestContentEventType Transfersuspended = new(
        Values.Transfersuspended
    );

    public static readonly NotificationStandardRequestContentEventType Transferdisabledcreditfund =
        new(Values.Transferdisabledcreditfund);

    public static readonly NotificationStandardRequestContentEventType Transferdisableddebitfund =
        new(Values.Transferdisableddebitfund);

    public static readonly NotificationStandardRequestContentEventType Invoicecreated = new(
        Values.Invoicecreated
    );

    public static readonly NotificationStandardRequestContentEventType Invoicesent = new(
        Values.Invoicesent
    );

    public static readonly NotificationStandardRequestContentEventType Invoicepaid = new(
        Values.Invoicepaid
    );

    public static readonly NotificationStandardRequestContentEventType Subscriptioncreated = new(
        Values.Subscriptioncreated
    );

    public static readonly NotificationStandardRequestContentEventType Subscriptionupdated = new(
        Values.Subscriptionupdated
    );

    public static readonly NotificationStandardRequestContentEventType Subscriptioncanceled = new(
        Values.Subscriptioncanceled
    );

    public static readonly NotificationStandardRequestContentEventType Subscriptioncompleted = new(
        Values.Subscriptioncompleted
    );

    public static readonly NotificationStandardRequestContentEventType Savedmethodupdated = new(
        Values.Savedmethodupdated
    );

    public static readonly NotificationStandardRequestContentEventType Nocreceived = new(
        Values.Nocreceived
    );

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

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionAuthorized =
        new(Values.PayoutTransactionAuthorized);

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionApprovedcaptured =
        new(Values.PayoutTransactionApprovedcaptured);

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionDeclined =
        new(Values.PayoutTransactionDeclined);

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionTechnicaldecline =
        new(Values.PayoutTransactionTechnicaldecline);

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

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionDuplicated =
        new(Values.PayoutTransactionDuplicated);

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionFunded =
        new(Values.PayoutTransactionFunded);

    public static readonly NotificationStandardRequestContentEventType PayoutTransactionReissued =
        new(Values.PayoutTransactionReissued);

    public static readonly NotificationStandardRequestContentEventType PayoutBatchSettlementPending =
        new(Values.PayoutBatchSettlementPending);

    public static readonly NotificationStandardRequestContentEventType PayoutBatchSettlementIntransit =
        new(Values.PayoutBatchSettlementIntransit);

    public static readonly NotificationStandardRequestContentEventType PayoutBatchSettlementFunded =
        new(Values.PayoutBatchSettlementFunded);

    public static readonly NotificationStandardRequestContentEventType PayoutBatchSettlementException =
        new(Values.PayoutBatchSettlementException);

    public static readonly NotificationStandardRequestContentEventType PayoutBatchSettlementAchreturn =
        new(Values.PayoutBatchSettlementAchreturn);

    public static readonly NotificationStandardRequestContentEventType PayoutBatchPaid = new(
        Values.PayoutBatchPaid
    );

    public static readonly NotificationStandardRequestContentEventType PayoutBatchFundpending = new(
        Values.PayoutBatchFundpending
    );

    public static readonly NotificationStandardRequestContentEventType PayoutBatchClosed = new(
        Values.PayoutBatchClosed
    );

    public static readonly NotificationStandardRequestContentEventType PayoutBatchNotclosed = new(
        Values.PayoutBatchNotclosed
    );

    public static readonly NotificationStandardRequestContentEventType PayoutBatchCancelled = new(
        Values.PayoutBatchCancelled
    );

    public static readonly NotificationStandardRequestContentEventType PayoutFundsAdded = new(
        Values.PayoutFundsAdded
    );

    public static readonly NotificationStandardRequestContentEventType PayoutFundsAvailable = new(
        Values.PayoutFundsAvailable
    );

    public static readonly NotificationStandardRequestContentEventType PayoutFundsReturned = new(
        Values.PayoutFundsReturned
    );

    public static readonly NotificationStandardRequestContentEventType PayoutVirtualcardTransactionAccepted =
        new(Values.PayoutVirtualcardTransactionAccepted);

    public static readonly NotificationStandardRequestContentEventType PayoutVirtualcardTransactionDeclined =
        new(Values.PayoutVirtualcardTransactionDeclined);

    public static readonly NotificationStandardRequestContentEventType PayoutGhostcardTransactionAccepted =
        new(Values.PayoutGhostcardTransactionAccepted);

    public static readonly NotificationStandardRequestContentEventType PayoutGhostcardTransactionDeclined =
        new(Values.PayoutGhostcardTransactionDeclined);

    public static readonly NotificationStandardRequestContentEventType PayoutFundVirtualcardTransactionSuccess =
        new(Values.PayoutFundVirtualcardTransactionSuccess);

    public static readonly NotificationStandardRequestContentEventType PayoutFundVirtualcardTransactionError =
        new(Values.PayoutFundVirtualcardTransactionError);

    public static readonly NotificationStandardRequestContentEventType Vcardcreated = new(
        Values.Vcardcreated
    );

    public static readonly NotificationStandardRequestContentEventType Vcardsent = new(
        Values.Vcardsent
    );

    public static readonly NotificationStandardRequestContentEventType Billapproved = new(
        Values.Billapproved
    );

    public static readonly NotificationStandardRequestContentEventType Billdisapproved = new(
        Values.Billdisapproved
    );

    public static readonly NotificationStandardRequestContentEventType Billpaid = new(
        Values.Billpaid
    );

    public static readonly NotificationStandardRequestContentEventType Billprocessing = new(
        Values.Billprocessing
    );

    public static readonly NotificationStandardRequestContentEventType Billsent = new(
        Values.Billsent
    );

    public static readonly NotificationStandardRequestContentEventType Billcanceled = new(
        Values.Billcanceled
    );

    public static readonly NotificationStandardRequestContentEventType VendorCreated = new(
        Values.VendorCreated
    );

    public static readonly NotificationStandardRequestContentEventType VendorUpdated = new(
        Values.VendorUpdated
    );

    public static readonly NotificationStandardRequestContentEventType VendorAchPaymentMethodCreated =
        new(Values.VendorAchPaymentMethodCreated);

    public static readonly NotificationStandardRequestContentEventType Payoutsubscriptioncreated =
        new(Values.Payoutsubscriptioncreated);

    public static readonly NotificationStandardRequestContentEventType Payoutsubscriptionupdated =
        new(Values.Payoutsubscriptionupdated);

    public static readonly NotificationStandardRequestContentEventType Payoutsubscriptionreminder =
        new(Values.Payoutsubscriptionreminder);

    public static readonly NotificationStandardRequestContentEventType Payoutsubscriptioncompleted =
        new(Values.Payoutsubscriptioncompleted);

    public static readonly NotificationStandardRequestContentEventType Payoutsubscriptioncanceled =
        new(Values.Payoutsubscriptioncanceled);

    public static readonly NotificationStandardRequestContentEventType Payoutsavedmethodupdated =
        new(Values.Payoutsavedmethodupdated);

    public static readonly NotificationStandardRequestContentEventType Payoutnocreceived = new(
        Values.Payoutnocreceived
    );

    public static readonly NotificationStandardRequestContentEventType Approvedapplication = new(
        Values.Approvedapplication
    );

    public static readonly NotificationStandardRequestContentEventType Boardingapplication = new(
        Values.Boardingapplication
    );

    public static readonly NotificationStandardRequestContentEventType Createdapplication = new(
        Values.Createdapplication
    );

    public static readonly NotificationStandardRequestContentEventType Declinedapplication = new(
        Values.Declinedapplication
    );

    public static readonly NotificationStandardRequestContentEventType Holdingapplication = new(
        Values.Holdingapplication
    );

    public static readonly NotificationStandardRequestContentEventType Submittedapplication = new(
        Values.Submittedapplication
    );

    public static readonly NotificationStandardRequestContentEventType Failedboardingapplication =
        new(Values.Failedboardingapplication);

    public static readonly NotificationStandardRequestContentEventType Activatedmerchant = new(
        Values.Activatedmerchant
    );

    public static readonly NotificationStandardRequestContentEventType Cardupdatercomplete = new(
        Values.Cardupdatercomplete
    );

    public static readonly NotificationStandardRequestContentEventType Updatedmerchant = new(
        Values.Updatedmerchant
    );

    public static readonly NotificationStandardRequestContentEventType Receivedchargeback = new(
        Values.Receivedchargeback
    );

    public static readonly NotificationStandardRequestContentEventType Chargebackupdated = new(
        Values.Chargebackupdated
    );

    public static readonly NotificationStandardRequestContentEventType Chargebackreversal = new(
        Values.Chargebackreversal
    );

    public static readonly NotificationStandardRequestContentEventType Receivedprearbitration = new(
        Values.Receivedprearbitration
    );

    public static readonly NotificationStandardRequestContentEventType Receivedretrieval = new(
        Values.Receivedretrieval
    );

    public static readonly NotificationStandardRequestContentEventType Receivedachreturn = new(
        Values.Receivedachreturn
    );

    public static readonly NotificationStandardRequestContentEventType Fraudalert = new(
        Values.Fraudalert
    );

    public static readonly NotificationStandardRequestContentEventType Transactionnotfound = new(
        Values.Transactionnotfound
    );

    public static readonly NotificationStandardRequestContentEventType Importfilereceived = new(
        Values.Importfilereceived
    );

    public static readonly NotificationStandardRequestContentEventType Importfileprocessed = new(
        Values.Importfileprocessed
    );

    public static readonly NotificationStandardRequestContentEventType Importfileerror = new(
        Values.Importfileerror
    );

    public static readonly NotificationStandardRequestContentEventType Exportfilesent = new(
        Values.Exportfilesent
    );

    public static readonly NotificationStandardRequestContentEventType Exportfileerror = new(
        Values.Exportfileerror
    );

    public static readonly NotificationStandardRequestContentEventType Exportreportcompleted = new(
        Values.Exportreportcompleted
    );

    public static readonly NotificationStandardRequestContentEventType Paypointroutingupdated = new(
        Values.Paypointroutingupdated
    );

    public static readonly NotificationStandardRequestContentEventType Paypointaccountnocreceived =
        new(Values.Paypointaccountnocreceived);

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

    internal class NotificationStandardRequestContentEventTypeSerializer
        : JsonConverter<NotificationStandardRequestContentEventType>
    {
        public override NotificationStandardRequestContentEventType Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new NotificationStandardRequestContentEventType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            NotificationStandardRequestContentEventType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override NotificationStandardRequestContentEventType ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new NotificationStandardRequestContentEventType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            NotificationStandardRequestContentEventType value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Approvedpayment = "approvedpayment";

        public const string Authorizedpayment = "authorizedpayment";

        public const string Declinedpayment = "declinedpayment";

        public const string Fundedpayment = "fundedpayment";

        public const string Originatedpayment = "originatedpayment";

        public const string Refundedpayment = "refundedpayment";

        public const string Settledpayment = "settledpayment";

        public const string Voidedpayment = "voidedpayment";

        public const string PayinTransactionOnhold = "payin_transaction_onhold";

        public const string PayinTransactionReleased = "payin_transaction_released";

        public const string PayinTransactionRecovered = "payin_transaction_recovered";

        public const string PayinTransactionRejected = "payin_transaction_rejected";

        public const string PayinBatchOnhold = "payin_batch_onhold";

        public const string PayinBatchReleased = "payin_batch_released";

        public const string Transfersuccess = "transfersuccess";

        public const string Transferadjusted = "transferadjusted";

        public const string Transferreturn = "transferreturn";

        public const string Transfererror = "transfererror";

        public const string Transferbalanceunavailable = "transferbalanceunavailable";

        public const string Transferreadyforretry = "transferreadyforretry";

        public const string Transferresolved = "transferresolved";

        public const string Transfersuspended = "transfersuspended";

        public const string Transferdisabledcreditfund = "transferdisabledcreditfund";

        public const string Transferdisableddebitfund = "transferdisableddebitfund";

        public const string Invoicecreated = "invoicecreated";

        public const string Invoicesent = "invoicesent";

        public const string Invoicepaid = "invoicepaid";

        public const string Subscriptioncreated = "subscriptioncreated";

        public const string Subscriptionupdated = "subscriptionupdated";

        public const string Subscriptioncanceled = "subscriptioncanceled";

        public const string Subscriptioncompleted = "subscriptioncompleted";

        public const string Savedmethodupdated = "savedmethodupdated";

        public const string Nocreceived = "nocreceived";

        public const string PayoutTransactionVoidedcancelled = "payout_transaction_voidedcancelled";

        public const string PayoutTransactionProcessing = "payout_transaction_processing";

        public const string PayoutTransactionProcessed = "payout_transaction_processed";

        public const string PayoutTransactionOnhold = "payout_transaction_onhold";

        public const string PayoutTransactionReleased = "payout_transaction_released";

        public const string PayoutTransactionRecovered = "payout_transaction_recovered";

        public const string PayoutTransactionAuthorized = "payout_transaction_authorized";

        public const string PayoutTransactionApprovedcaptured =
            "payout_transaction_approvedcaptured";

        public const string PayoutTransactionDeclined = "payout_transaction_declined";

        public const string PayoutTransactionTechnicaldecline =
            "payout_transaction_technicaldecline";

        public const string PayoutTransactionError = "payout_transaction_error";

        public const string PayoutTransactionPaid = "payout_transaction_paid";

        public const string PayoutTransactionReturned = "payout_transaction_returned";

        public const string PayoutTransactionRejected = "payout_transaction_rejected";

        public const string PayoutTransactionDuplicated = "payout_transaction_duplicated";

        public const string PayoutTransactionFunded = "payout_transaction_funded";

        public const string PayoutTransactionReissued = "payout_transaction_reissued";

        public const string PayoutBatchSettlementPending = "payout_batch_settlement_pending";

        public const string PayoutBatchSettlementIntransit = "payout_batch_settlement_intransit";

        public const string PayoutBatchSettlementFunded = "payout_batch_settlement_funded";

        public const string PayoutBatchSettlementException = "payout_batch_settlement_exception";

        public const string PayoutBatchSettlementAchreturn = "payout_batch_settlement_achreturn";

        public const string PayoutBatchPaid = "payout_batch_paid";

        public const string PayoutBatchFundpending = "payout_batch_fundpending";

        public const string PayoutBatchClosed = "payout_batch_closed";

        public const string PayoutBatchNotclosed = "payout_batch_notclosed";

        public const string PayoutBatchCancelled = "payout_batch_cancelled";

        public const string PayoutFundsAdded = "payout_funds_added";

        public const string PayoutFundsAvailable = "payout_funds_available";

        public const string PayoutFundsReturned = "payout_funds_returned";

        public const string PayoutVirtualcardTransactionAccepted =
            "payout_virtualcard_transaction_accepted";

        public const string PayoutVirtualcardTransactionDeclined =
            "payout_virtualcard_transaction_declined";

        public const string PayoutGhostcardTransactionAccepted =
            "payout_ghostcard_transaction_accepted";

        public const string PayoutGhostcardTransactionDeclined =
            "payout_ghostcard_transaction_declined";

        public const string PayoutFundVirtualcardTransactionSuccess =
            "payout_fund_virtualcard_transaction_success";

        public const string PayoutFundVirtualcardTransactionError =
            "payout_fund_virtualcard_transaction_error";

        public const string Vcardcreated = "vcardcreated";

        public const string Vcardsent = "vcardsent";

        public const string Billapproved = "billapproved";

        public const string Billdisapproved = "billdisapproved";

        public const string Billpaid = "billpaid";

        public const string Billprocessing = "billprocessing";

        public const string Billsent = "billsent";

        public const string Billcanceled = "billcanceled";

        public const string VendorCreated = "vendor_created";

        public const string VendorUpdated = "vendor_updated";

        public const string VendorAchPaymentMethodCreated = "vendor_ach_payment_method_created";

        public const string Payoutsubscriptioncreated = "payoutsubscriptioncreated";

        public const string Payoutsubscriptionupdated = "payoutsubscriptionupdated";

        public const string Payoutsubscriptionreminder = "payoutsubscriptionreminder";

        public const string Payoutsubscriptioncompleted = "payoutsubscriptioncompleted";

        public const string Payoutsubscriptioncanceled = "payoutsubscriptioncanceled";

        public const string Payoutsavedmethodupdated = "payoutsavedmethodupdated";

        public const string Payoutnocreceived = "payoutnocreceived";

        public const string Approvedapplication = "approvedapplication";

        public const string Boardingapplication = "boardingapplication";

        public const string Createdapplication = "createdapplication";

        public const string Declinedapplication = "declinedapplication";

        public const string Holdingapplication = "holdingapplication";

        public const string Submittedapplication = "submittedapplication";

        public const string Failedboardingapplication = "failedboardingapplication";

        public const string Activatedmerchant = "activatedmerchant";

        public const string Cardupdatercomplete = "cardupdatercomplete";

        public const string Updatedmerchant = "updatedmerchant";

        public const string Receivedchargeback = "receivedchargeback";

        public const string Chargebackupdated = "chargebackupdated";

        public const string Chargebackreversal = "chargebackreversal";

        public const string Receivedprearbitration = "receivedprearbitration";

        public const string Receivedretrieval = "receivedretrieval";

        public const string Receivedachreturn = "receivedachreturn";

        public const string Fraudalert = "fraudalert";

        public const string Transactionnotfound = "transactionnotfound";

        public const string Importfilereceived = "importfilereceived";

        public const string Importfileprocessed = "importfileprocessed";

        public const string Importfileerror = "importfileerror";

        public const string Exportfilesent = "exportfilesent";

        public const string Exportfileerror = "exportfileerror";

        public const string Exportreportcompleted = "exportreportcompleted";

        public const string Paypointroutingupdated = "paypointroutingupdated";

        public const string Paypointaccountnocreceived = "paypointaccountnocreceived";
    }
}
