using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Cloud;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
                    .WithPath("/Cloud/register/8cfec329267/499585-389fj484-3jcj8hj3")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Cloud.RemoveDeviceAsync(
            "8cfec329267",
            "499585-389fj484-3jcj8hj3"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
