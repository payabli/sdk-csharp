using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Query;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListUsersPaypointTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Records": [
                {
                  "Access": [
                    {
                      "roleValue": true
                    }
                  ],
                  "AdditionalData": {
                    "key1": "value1",
                    "key2": "value2"
                  },
                  "createdAt": "2022-07-01T15:00:01.000Z",
                  "Email": "example@email.com",
                  "language": "en",
                  "lastAccess": "2022-07-01T15:00:01.000Z",
                  "Name": "Sean Smith",
                  "Phone": "5555555555",
                  "Scope": [
                    {
                      "orgType": 0
                    }
                  ],
                  "snData": "snData",
                  "snIdentifier": "snIdentifier",
                  "snProvider": "google",
                  "timeZone": -5,
                  "userId": 1000000,
                  "UsrMFA": false,
                  "UsrMFAMode": 0,
                  "UsrStatus": 1
                }
              ],
              "Summary": {
                "pageidentifier": "null",
                "pageSize": 20,
                "totalAmount": 77.22,
                "totalNetAmount": 77.22,
                "totalPages": 2,
                "totalRecords": 2
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Query/users/point/8cfec329267")
                    .WithParam("fromRecord", "251")
                    .WithParam("limitRecord", "0")
                    .WithParam("sortBy", "desc(field_name)")
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

        var response = await Client.Query.ListUsersPaypointAsync(
            "8cfec329267",
            new ListUsersPaypointRequest
            {
                FromRecord = 251,
                LimitRecord = 0,
                SortBy = "desc(field_name)",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
