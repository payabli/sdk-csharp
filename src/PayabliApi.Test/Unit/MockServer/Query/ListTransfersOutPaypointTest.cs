using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Query;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTransfersOutPaypointTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Summary": {
                "totalPages": 8,
                "totalRecords": 156,
                "pageSize": 20
              },
              "Records": [
                {
                  "transferId": 4521,
                  "paypointId": 3040,
                  "paypointEntryName": "47cade237",
                  "paypointLegalName": "Solid Rock Concrete Coatings LLC",
                  "paypointDbaName": "Solid Rock Coatings",
                  "paypointLogo": "https://example.com/logos/solidrock.png",
                  "parentOrgName": "Premier Property Services",
                  "parentOrgId": 77,
                  "parentOrgLogo": "https://example.com/logos/premier.png",
                  "parentOrgEntryName": "premierps",
                  "externalPaypointID": "SR-892",
                  "bankAccount": {
                    "accountNumber": "4XXXXXX7231",
                    "routingNumber": "121000358",
                    "bankName": "Riverdale Community Bank"
                  },
                  "transferDate": "2025-01-15T14:30:00.000Z",
                  "processor": "BK",
                  "grossAmount": 2847.5,
                  "returnedAmount": 0,
                  "holdAmount": 0,
                  "releasedAmount": 0,
                  "billingFeesAmount": 12.5,
                  "netTransferAmount": 2835,
                  "eventsData": [
                    {
                      "description": "Payout funded",
                      "eventTime": "2025-01-15T14:28:45",
                      "refData": "",
                      "source": "system"
                    }
                  ],
                  "messages": [
                    {
                      "Id": 8842,
                      "RoomId": 1205,
                      "UserId": 334,
                      "UserName": "Maria Santos",
                      "Content": "Transfer processed successfully",
                      "CreatedAt": "2025-01-15T14:30:00",
                      "MessageType": 1,
                      "MessageProperties": {
                        "originalTransferStatus": "pending",
                        "currentTransferStatus": "completed"
                      }
                    }
                  ],
                  "type": "credit",
                  "method": "ach"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Query/transfersOut/8cfec329267")
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

        var response = await Client.Query.ListTransfersOutPaypointAsync(
            "8cfec329267",
            new ListTransfersOutPaypointRequest { FromRecord = 0, LimitRecord = 20 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
