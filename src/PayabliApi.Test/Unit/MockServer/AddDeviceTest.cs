using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class AddDeviceTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "registrationCode": "YS7DS5",
              "description": "Front Desk POS"
            }
            """;

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
                    .WithPath("/Cloud/register/8cfec329267")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Cloud.AddDeviceAsync(
            "8cfec329267",
            new DeviceEntry { RegistrationCode = "YS7DS5", Description = "Front Desk POS" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<AddDeviceResponse>(mockResponse)).UsingDefaults()
        );
    }
}
