using NUnit.Framework;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class GetChargebackAttachmentTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = "string";

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/ChargeBacks/getChargebackAttachments/1000000/fileName")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.ChargeBacks.GetChargebackAttachmentAsync(1000000, "fileName");
        Assert.That(response, Is.EqualTo(mockResponse));
    }
}
