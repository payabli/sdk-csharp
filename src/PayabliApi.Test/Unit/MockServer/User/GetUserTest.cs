using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.User;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
                    .WithParam("entry", "8cfec329267")
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
            new GetUserRequest { Entry = "8cfec329267" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
