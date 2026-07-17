using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.ChargeBacks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetChargebackAttachmentTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            "string"
            """;

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
        JsonAssert.AreEqual(response, mockResponse);
    }
}
