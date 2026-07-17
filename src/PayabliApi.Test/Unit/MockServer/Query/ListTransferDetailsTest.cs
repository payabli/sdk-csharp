using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Query;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
                  "transferId": 4521,
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
                    }
                  },
                  "TransStatus": 1,
                  "TotalAmount": 1000,
                  "NetAmount": 935,
                  "FeeAmount": 1,
                  "SettlementStatus": 2,
                  "Operation": "Sale",
                  "ResponseData": {
                    "authcode": "123456",
                    "avsresponse": "N",
                    "avsresponse_text": "No address or ZIP match only",
                    "cvvresponse": "M",
                    "cvvresponse_text": "CVV2/CVC2 match",
                    "orderid": "10-bfcd5a17861d4a8690ca53c00000X",
                    "response": "Success",
                    "response_code": "100",
                    "response_code_text": "Transaction was approved.",
                    "responsetext": "SUCCESS",
                    "resultCode": "A0000",
                    "resultCodeText": "Approved",
                    "transactionid": "8082800000"
                  },
                  "Source": "web",
                  "ScheduleReference": 0,
                  "OrgId": 123,
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
                    "CustomerNumber": "C-90010",
                    "customerId": 4440
                  },
                  "billingFeesDetails": [],
                  "PaypointId": 3040,
                  "IsValidatedACH": true,
                  "splitFundingInstructions": [],
                  "CfeeTransactions": [],
                  "TransactionEvents": [],
                  "PendingFeeAmount": 0,
                  "RiskFlagged": false,
                  "RiskStatus": "approved",
                  "AchSecCode": "PPD",
                  "AchHolderType": "personal",
                  "IpAddress": "192.100.1.100",
                  "IsSameDayACH": false
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Query/transferDetails/8cfec329267/4521")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Query.ListTransferDetailsAsync(
            "8cfec329267",
            4521,
            new ListTransfersPaypointRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
