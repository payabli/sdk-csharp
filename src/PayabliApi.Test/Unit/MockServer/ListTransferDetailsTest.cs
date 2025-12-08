using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ListTransferDetailsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Summary": {
                "achReturns": -50,
                "adjustments": 10,
                "billingFees": 25,
                "chargebacks": 0,
                "grossTransferAmount": 1000,
                "releaseAmount": 0,
                "thirdPartyPaid": 0,
                "totalNetAmountTransfer": 935,
                "serviceFees": 30,
                "splitAmount": 650.22,
                "transferAmount": 935,
                "refunds": -20,
                "heldAmount": 0,
                "totalRecords": 1,
                "totalAmount": 1000,
                "totalNetAmount": 935,
                "netBatchAmount": 935,
                "totalPages": 1,
                "pageSize": 20,
                "pageidentifier": "XYZ123ABC456"
              },
              "Records": [
                {
                  "transferDetailId": 654321,
                  "transferId": 12345,
                  "transactionId": "txn-4321hg6543fe",
                  "type": "credit",
                  "category": "sale",
                  "grossAmount": 1000,
                  "chargeBackAmount": 0,
                  "returnedAmount": 0,
                  "refundAmount": 20,
                  "holdAmount": 0,
                  "releasedAmount": 0,
                  "billingFeesAmount": 25,
                  "thirdPartyPaidAmount": 0,
                  "adjustmentsAmount": 10,
                  "netTransferAmount": 935,
                  "splitFundingAmount": 0,
                  "ParentOrgName": "GadgetPro",
                  "PaypointDbaname": "Global Gadgets",
                  "PaypointLegalname": "Global Gadgets, LLC",
                  "PaypointEntryname": "48ae10920",
                  "PaymentTransId": "txn-4321hg6543fe",
                  "ConnectorName": "gp",
                  "GatewayTransId": "TRN_K6Nz3JxrNKkaPTF4ExCqfO4UwMW4CM",
                  "OrderId": "order789",
                  "Method": "ach",
                  "BatchNumber": "batch_226_ach_12-30-2023",
                  "BatchAmount": 30.22,
                  "PayorId": 1551,
                  "PaymentData": {
                    "MaskedAccount": "411812XXXXXX2357",
                    "AccountType": "visa",
                    "AccountExp": "08/28",
                    "HolderName": "Ara Karapetyan",
                    "orderDescription": "Electronics Purchase",
                    "StoredId": null,
                    "Initiator": null,
                    "StoredMethodUsageType": null,
                    "Sequence": null,
                    "accountId": null,
                    "SignatureData": null,
                    "binData": {
                      "binMatchedLength": "6",
                      "binCardBrand": "Visa",
                      "binCardType": "Credit",
                      "binCardCategory": "PLATINUM",
                      "binCardIssuer": "Bank of Example",
                      "binCardIssuerCountry": "United States",
                      "binCardIssuerCountryCodeA2": "US",
                      "binCardIssuerCountryNumber": "840",
                      "binCardIsRegulated": "false",
                      "binCardUseCategory": "Consumer",
                      "binCardIssuerCountryCodeA3": "USA"
                    },
                    "paymentDetails": null
                  },
                  "TransStatus": 1,
                  "TotalAmount": 1000,
                  "NetAmount": 935,
                  "FeeAmount": 1,
                  "SettlementStatus": 2,
                  "Operation": "Sale",
                  "ResponseData": {
                    "response": "Approved",
                    "responsetext": "Transaction successful",
                    "authcode": "123456",
                    "transactionid": "TRN_K6Nz3JxrNKkaPTF4ExCqfO4OOOOOX",
                    "response_code": "100",
                    "response_code_text": "Operation successful."
                  },
                  "Source": "web",
                  "ScheduleReference": 0,
                  "OrgId": 9876,
                  "RefundId": 0,
                  "ReturnedId": 0,
                  "TransactionTime": "2024-01-05T12:15:30.110Z",
                  "Customer": {
                    "Identifiers": [
                      "customerId",
                      "email"
                    ],
                    "FirstName": "Ara",
                    "LastName": "Karapetyan",
                    "CompanyName": "Ara's Electronics",
                    "BillingAddress1": "7890 Tech Park Drive",
                    "BillingCity": "Baltimore",
                    "BillingState": "MD",
                    "BillingZip": "21230",
                    "BillingCountry": "US",
                    "BillingEmail": "ara.karapetyan@electronics.com",
                    "CustomerNumber": "0010",
                    "customerId": 7890
                  },
                  "transactionNumber": null,
                  "billingFeesDetails": [],
                  "ExternalProcessorInformation": null,
                  "PaypointId": 1357,
                  "ChargebackId": null,
                  "RetrievalId": null,
                  "TransAdditionalData": null,
                  "invoiceData": null,
                  "EntrypageId": null,
                  "externalPaypointID": null,
                  "IsValidatedACH": true,
                  "splitFundingInstructions": [],
                  "CfeeTransactions": [],
                  "TransactionEvents": [],
                  "PendingFeeAmount": 0,
                  "RiskFlagged": false,
                  "RiskFlaggedOn": null,
                  "RiskStatus": "approved",
                  "RiskReason": null,
                  "RiskAction": null,
                  "RiskActionCode": null,
                  "DeviceId": null,
                  "AchSecCode": "PPD",
                  "AchHolderType": "personal",
                  "IpAddress": "192.100.1.100",
                  "IsSameDayACH": false,
                  "WalletType": null
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Query/transferDetails/47862acd/123456")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Query.ListTransferDetailsAsync(
            "47862acd",
            123456,
            new ListTransfersPaypointRequest()
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<QueryTransferDetailResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
