using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ListDeviceTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "responseList": [
                {
                  "connected": true,
                  "dateRegistered": "2024-03-05T15:56:04.000Z",
                  "deviceId": "36103e24-41d8-47c9-b5f7-119f0000000",
                  "deviceNickName": "Front Desk POS",
                  "make": "ingenico",
                  "model": "LK2500",
                  "registered": true,
                  "serialNumber": "312345692080000000"
                }
              ],
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Cloud/list/8cfec329267")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Cloud.ListDeviceAsync("8cfec329267", new ListDeviceRequest());
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CloudQueryApiResponse>(mockResponse)).UsingDefaults()
        );
    }
}
