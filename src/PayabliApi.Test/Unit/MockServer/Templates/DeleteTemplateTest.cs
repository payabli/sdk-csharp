using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Templates;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteTemplateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseData": 3625,
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/Templates/80").UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Templates.DeleteTemplateAsync(80);
        JsonAssert.AreEqual(response, mockResponse);
    }
}
