using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Query;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTransferDetailsOutTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Summary": {
                "achReturns": 0,
                "adjustments": 0,
                "billingFees": 25,
                "chargebacks": 0,
                "grossTransferAmount": 4875,
                "releaseAmount": 0,
                "thirdPartyPaid": 0,
                "totalNetAmountTransfer": 4850,
                "netBatchAmount": 0,
                "splitAmount": 0,
                "serviceFees": 0,
                "transferAmount": 0,
                "refunds": 0,
                "heldAmount": 0,
                "totalRecords": 156,
                "totalAmount": 0,
                "totalNetAmount": 0,
                "totalPages": 8,
                "pageSize": 20
              },
              "Records": [
                {
                  "transferDetailId": 9847,
                  "transferId": 4521,
                  "transactionId": "01KXYZ789ABC123DEF456GHI",
                  "IdOut": 88234,
                  "type": "Debit",
                  "category": "grouped",
                  "grossAmount": 1250,
                  "returnedAmount": 0,
                  "refundAmount": 0,
                  "holdAmount": 0,
                  "releasedAmount": 0,
                  "billingFeesAmount": 5,
                  "adjustmentsAmount": 0,
                  "netTransferAmount": 1245,
                  "CreatedAt": "2025-01-15T10:22:18",
                  "Comments": "Epoxy floor coating materials",
                  "Vendor": {
                    "VendorNumber": "VEN-123",
                    "Name1": "Concrete Supply Distributors",
                    "EIN": "XXXXX4567",
                    "Phone": "(512) 555-0147",
                    "Email": "accounts@concretesupply.example.com",
                    "RemitEmail": "payments@concretesupply.example.com",
                    "Address1": "4200 Industrial Parkway",
                    "Address2": "Unit B",
                    "City": "Austin",
                    "State": "TX",
                    "Zip": "78745",
                    "Country": "US",
                    "Mcc": "5039",
                    "Contacts": [
                      {
                        "ContactName": "Robert Chen",
                        "ContactEmail": "rchen@concretesupply.example.com",
                        "ContactTitle": "Accounts Receivable",
                        "ContactPhone": "(512) 555-0148"
                      }
                    ],
                    "PaymentMethod": "ach",
                    "VendorStatus": 1,
                    "VendorId": 456,
                    "PaypointLegalname": "Solid Rock Concrete Coatings LLC",
                    "PaypointDbaname": "Solid Rock Coatings",
                    "PaypointEntryname": "47cade237",
                    "ParentOrgName": "Premier Property Services",
                    "ParentOrgId": 77,
                    "CreatedDate": "2024-08-12T09:15:00",
                    "LastUpdated": "2025-01-10T14:30:22",
                    "remitAddress1": "4200 Industrial Parkway",
                    "remitAddress2": "Unit B",
                    "remitCity": "Austin",
                    "remitState": "TX",
                    "remitZip": "78745",
                    "remitCountry": "US",
                    "customField1": "",
                    "customField2": "",
                    "customerVendorAccount": "SRCC-001847",
                    "InternalReferenceId": 3392,
                    "externalPaypointID": "SR-892"
                  },
                  "PaypointDbaname": "Solid Rock Coatings",
                  "PaypointLegalname": "Solid Rock Concrete Coatings LLC",
                  "PaypointId": 3040,
                  "Status": 2,
                  "PaymentId": "01KXYZ789ABC123DEF456GHI",
                  "LastUpdated": "2025-01-15T10:23:05",
                  "TotalAmount": 1250,
                  "NetAmount": 1245,
                  "FeeAmount": 5,
                  "Source": "api",
                  "ParentOrgName": "Premier Property Services",
                  "ParentOrgId": 77,
                  "BatchNumber": "b7c3e891-4f2a-4d8e-9a1b-c5d6e7f8a9b0",
                  "PaymentStatus": "Processing",
                  "PaymentMethod": "ach",
                  "CheckNumber": "",
                  "PaymentData": {
                    "MaskedAccount": "7XXXXXX4523",
                    "AccountType": "checking",
                    "AccountExp": "",
                    "AccountZip": "",
                    "StoredId": "f8e7d6c5-b4a3-9281-7654-321098fedcba",
                    "orderDescription": "Epoxy floor coating materials",
                    "accountId": "bankOut1"
                  },
                  "Bills": [
                    {
                      "billId": 54323,
                      "LotNumber": "LOT-2025-0115",
                      "invoiceNumber": "INV-2345",
                      "netAmount": "1250.00",
                      "invoiceDate": "2025-01-10T00:00:00",
                      "dueDate": "2025-02-09",
                      "comments": "50 gal epoxy primer, 25 gal topcoat - Project Riverside Plaza"
                    }
                  ],
                  "Events": [
                    {
                      "TransEvent": "Risk Validated: PASSED",
                      "EventData": "",
                      "EventTime": "2025-01-15T10:22:20"
                    },
                    {
                      "TransEvent": "Captured",
                      "EventData": "0ABC123XYZ789:00000012",
                      "EventTime": "2025-01-15T10:22:25"
                    }
                  ],
                  "externalPaypointID": "SR-892",
                  "EntryName": "8cfec329267",
                  "Gateway": "bank",
                  "BatchId": 1049,
                  "IsSameDayACH": false,
                  "ScheduleId": 0,
                  "SettlementStatus": "Pending",
                  "SettlementStatusName": "",
                  "RiskFlagged": false,
                  "RiskFlaggedOn": "2025-01-15T10:22:18",
                  "RiskStatus": "PASSED",
                  "RiskReason": "",
                  "RiskAction": "",
                  "RiskActionCode": 0,
                  "PayoutProgram": "ODP"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Query/transferDetailsOut/8cfec329267/4521")
                    .WithParam("fromRecord", "0")
                    .WithParam("limitRecord", "20")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Query.ListTransferDetailsOutAsync(
            "8cfec329267",
            4521,
            new ListTransferDetailsOutRequest { FromRecord = 0, LimitRecord = 20 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
