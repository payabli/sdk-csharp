using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class EditMfaUserTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/User/mfa/1000000")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.User.EditMfaUserAsync(1000000, new MfaData());
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<EditMfaUserResponse>(mockResponse)).UsingDefaults()
        );
    }
}
