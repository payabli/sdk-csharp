using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class GetUserTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Access": [
                {
                  "roleLabel": "customers",
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
                  "orgEntry": "pilgrim-planner",
                  "orgId": 123,
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/User/1000000")
                    .WithParam("entry", "478ae1234")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.User.GetUserAsync(
            1000000,
            new GetUserRequest { Entry = "478ae1234" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UserQueryRecord>(mockResponse)).UsingDefaults()
        );
    }
}
