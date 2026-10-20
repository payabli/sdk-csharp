using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.People;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListPeopleTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "People retrieved successfully",
              "traceId": "0HNNQ4R2OT25J:0000005A",
              "data": {
                "data": [
                  {
                    "_links": {
                      "self": "/v2/people/01a0014d-ce1a-7110-9bac-c4c59647a88d"
                    },
                    "personReference": "01a0014d-ce1a-7110-9bac-c4c59647a88d",
                    "firstName": "Marcus",
                    "lastName": "Delgado",
                    "email": "marcus.delgado@example.com",
                    "verificationStatus": "notstarted",
                    "createdAt": "2026-08-14T17:24:31.387Z",
                    "lastUpdated": "2026-08-14T17:24:31.387Z"
                  }
                ],
                "pagination": {
                  "page": 1,
                  "totalPages": 1587,
                  "totalRecords": 1587,
                  "pageSize": 1,
                  "hasNext": true,
                  "hasPrevious": false
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/people")
                    .WithParam("limit", "1")
                    .WithParam("page", "1")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.People.ListPeopleAsync(
            new ListPeoplePeopleRequest { Limit = 1, Page = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
