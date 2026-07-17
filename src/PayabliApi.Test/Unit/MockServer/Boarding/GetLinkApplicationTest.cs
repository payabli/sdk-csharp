using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Boarding;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetLinkApplicationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "acceptOauth": false,
              "acceptRegister": false,
              "builderData": {
                "attributes": {
                  "minimumDocuments": 1,
                  "multipleContacts": true,
                  "multipleOwners": true
                }
              },
              "entryAttributes": "entryAttributes",
              "id": 1000000,
              "logo": {
                "fContent": "TXkgdGVzdCBmaWxlHJ==...",
                "filename": "my-doc.pdf",
                "ftype": "pdf",
                "furl": "https://mysite.com/my-doc.pdf"
              },
              "orgId": 123,
              "pageIdentifier:": "null",
              "recipientEmailNotification": true,
              "referenceName": "payabli-00710",
              "referenceTemplateId": 1830,
              "resumable": false
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Boarding/link/myorgaccountname-00091")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Boarding.GetLinkApplicationAsync("myorgaccountname-00091");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
