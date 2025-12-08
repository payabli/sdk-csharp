using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
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
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BoardingLinkQueryRecord>(mockResponse)).UsingDefaults()
        );
    }
}
