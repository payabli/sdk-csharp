using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class RemoveDeviceTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": "6c361c7d-674c-44cc-b790-382b75d1xxx",
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Cloud/register/8cfec329267/6c361c7d-674c-44cc-b790-382b75d1xxx")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Cloud.RemoveDeviceAsync(
            "6c361c7d-674c-44cc-b790-382b75d1xxx",
            "8cfec329267"
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RemoveDeviceResponse>(mockResponse)).UsingDefaults()
        );
    }
}
