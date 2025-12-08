using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
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
                  "AdditionalData": "AdditionalData",
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
                "pageIdentifier": "null",
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
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<QueryUserResponse>(mockResponse)).UsingDefaults()
        );
    }
}
