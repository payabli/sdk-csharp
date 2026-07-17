using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Query;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListPayoutTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Records": [
                {
                  "IdOut": 236,
                  "CreatedAt": "2024-01-15T15:00:01.000Z",
                  "Comments": "Deposit for materials",
                  "Vendor": {
                    "VendorNumber": "VEN-123",
                    "Name1": "Riverside Plumbing",
                    "Phone": "(555) 555-1234",
                    "Email": "vendor@example.com",
                    "Address1": "100 Main Street",
                    "City": "Miami",
                    "State": "FL",
                    "Zip": "33131",
                    "Country": "US",
                    "Contacts": [
                      {
                        "ContactName": "Alex Doe",
                        "ContactEmail": "contact@example.com",
                        "ContactTitle": "Accounts Receivable",
                        "ContactPhone": "(555) 555-5678"
                      }
                    ],
                    "PaymentMethod": "ach",
                    "VendorStatus": 1,
                    "VendorId": 456,
                    "PaypointLegalname": "Sunshine Services, LLC",
                    "PaypointId": 3040,
                    "PaypointDbaname": "Sunshine Gutters",
                    "PaypointEntryname": "8cfec329267",
                    "ParentOrgName": "PropertyManager Pro",
                    "ParentOrgId": 123,
                    "CreatedDate": "2024-01-10T15:00:01.000Z",
                    "LastUpdated": "2024-01-12T15:00:01.000Z",
                    "remitAddress1": "100 Main Street",
                    "remitCity": "Miami",
                    "remitState": "FL",
                    "remitZip": "33131",
                    "remitCountry": "US",
                    "InternalReferenceId": 12345,
                    "CardAccepted": "yes",
                    "AchAccepted": "yes",
                    "CheckAccepted": "no",
                    "EnrichmentStatus": "fully_enriched",
                    "EnrichedBy": "web_search",
                    "EnrichedAt": "2024-01-12T15:00:01.000Z",
                    "externalPaypointID": ""
                  },
                  "PaypointDbaname": "Sunshine Gutters",
                  "PaypointLegalname": "Sunshine Services, LLC",
                  "PaypointId": 3040,
                  "Status": 1,
                  "PaymentId": "01J0ABCDEF2WQ4VS323V5WKZP3",
                  "LastUpdated": "2024-01-15T15:00:01.000Z",
                  "TotalAmount": 110.25,
                  "NetAmount": 100,
                  "FeeAmount": 10.25,
                  "Source": "api",
                  "ParentOrgName": "PropertyManager Pro",
                  "ParentOrgId": 123,
                  "BatchNumber": "BT-2024321",
                  "PaymentStatus": "Processed",
                  "PaymentMethod": "ach",
                  "CheckNumber": "12345",
                  "PaymentData": {
                    "MaskedAccount": "1XXXXXX3123",
                    "AccountType": "checking",
                    "AccountExp": "",
                    "AccountZip": "",
                    "StoredId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-456",
                    "accountId": ""
                  },
                  "Bills": [
                    {
                      "billId": 54323,
                      "invoiceNumber": "INV-2345",
                      "netAmount": "100",
                      "invoiceDate": "2024-01-10",
                      "dueDate": "2024-01-20",
                      "comments": "",
                      "discount": "0",
                      "totalAmount": "100"
                    }
                  ],
                  "Events": [
                    {
                      "TransEvent": "Risk Validated: PASSED",
                      "EventData": "blockedCard, blockedIP, blockedPaypoint, blockedPayor",
                      "EventTime": "2024-01-15T15:00:01.000Z"
                    },
                    {
                      "TransEvent": "Created",
                      "EventData": "0HNMNN3L95DJB:00000001",
                      "EventTime": "2024-01-15T15:00:02.000Z"
                    },
                    {
                      "TransEvent": "Authorized",
                      "EventData": "0HNMNN3L95DJB:00000001",
                      "EventTime": "2024-01-15T15:00:03.000Z"
                    }
                  ],
                  "externalPaypointID": "",
                  "EntryName": "8cfec329267",
                  "Gateway": "BK",
                  "BatchId": 0,
                  "HasVcardTransactions": false,
                  "IsSameDayACH": false,
                  "ScheduleId": 0,
                  "SettlementStatus": "None",
                  "SettlementStatusName": "",
                  "RiskFlagged": false,
                  "RiskFlaggedOn": "2024-01-15T15:00:01.000Z",
                  "RiskStatus": "PASSED",
                  "RiskReason": "",
                  "RiskAction": "",
                  "RiskActionCode": 0,
                  "PayoutProgram": "ODP",
                  "EntityId": "01J0ABCDEF9FWATVWMBWGE6MPP"
                }
              ],
              "Summary": {
                "totalPaid": 1,
                "totalPaidAmount": 4,
                "totalCanceled": 1743,
                "totalCanceledAmount": 4515,
                "totalCaptured": 138,
                "totalCapturedAmount": 542,
                "totalAuthorized": 4139,
                "totalAuthorizedAmount": 11712.35,
                "totalProcessing": 1780,
                "totalProcessingAmount": 4660.6,
                "totalOpen": 2,
                "totalOpenAmount": 2,
                "totalOnHold": 0,
                "totalOnHoldAmount": 0,
                "totalRecords": 7803,
                "totalAmount": 21435.95,
                "totalNetAmount": 21435.95,
                "totalPages": 391,
                "pageSize": 20
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Query/payouts/8cfec329267")
                    .WithParam("fromRecord", "251")
                    .WithParam("limitRecord", "0")
                    .WithParam("sortBy", "desc(field_name)")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Query.ListPayoutAsync(
            "8cfec329267",
            new ListPayoutRequest
            {
                FromRecord = 251,
                LimitRecord = 0,
                SortBy = "desc(field_name)",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
