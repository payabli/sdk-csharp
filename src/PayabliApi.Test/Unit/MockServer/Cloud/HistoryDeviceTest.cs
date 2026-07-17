using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Cloud;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class HistoryDeviceTest : BaseMockServerTest
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
                  "deviceId": "499585-389fj484-3jcj8hj3",
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
                    .WithPath("/Cloud/history/8cfec329267/499585-389fj484-3jcj8hj3")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Cloud.HistoryDeviceAsync(
            "499585-389fj484-3jcj8hj3",
            "8cfec329267"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
