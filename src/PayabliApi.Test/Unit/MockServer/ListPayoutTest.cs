using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ListPayoutTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Records": [
                {
                  "BatchNumber": "BT-2024321",
                  "Bills": [
                    {}
                  ],
                  "CardToken": "CardToken",
                  "CheckNumber": "12345",
                  "Comments": "Deposit for materials",
                  "CreatedAt": "2022-07-01T15:00:01.000Z",
                  "EntryName": "d193cf9a46",
                  "Events": [
                    {}
                  ],
                  "externalPaypointID": "Paypoint-100",
                  "FeeAmount": 10.25,
                  "Gateway": "TSYS",
                  "IdOut": 236,
                  "LastUpdated": "2022-07-01T15:00:01.000Z",
                  "NetAmount": 3762.87,
                  "ParentOrgName": "PropertyManager Pro",
                  "PaymentData": {
                    "paymentDetails": {
                      "totalAmount": 100
                    }
                  },
                  "PaymentId": "12345678910",
                  "PaymentMethod": "ach",
                  "PaymentStatus": "Processed",
                  "PaypointDbaname": "Sunshine Gutters",
                  "PaypointLegalname": "Sunshine Services, LLC",
                  "Source": "api",
                  "Status": 1,
                  "TotalAmount": 110.25,
                  "Vendor": {
                    "additionalData": {
                      "key1": {
                        "key": "value"
                      },
                      "key2": {
                        "key": "value"
                      },
                      "key3": {
                        "key": "value"
                      }
                    },
                    "CreatedDate": "2022-07-01T15:00:01.000Z"
                  }
                }
              ],
              "Summary": {
                "totalPages": 391,
                "totalRecords": 7803,
                "totalAmount": 21435.95,
                "totalNetAmount": 21435.95,
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
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<QueryPayoutTransaction>(mockResponse)).UsingDefaults()
        );
    }
}
