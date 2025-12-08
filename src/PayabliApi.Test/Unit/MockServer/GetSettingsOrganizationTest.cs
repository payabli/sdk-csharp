using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class GetSettingsOrganizationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "customFields": [
                {
                  "key": "key",
                  "readOnly": false,
                  "value": "value"
                }
              ],
              "forInvoices": [
                {
                  "key": "key",
                  "readOnly": false,
                  "value": "value"
                }
              ],
              "forPayOuts": [
                {
                  "key": "key",
                  "readOnly": false,
                  "value": "value"
                }
              ],
              "forWallets": [
                {
                  "key": "isGooglePayEnabled",
                  "readOnly": false,
                  "value": "true"
                }
              ],
              "general": [
                {
                  "key": "key",
                  "readOnly": false,
                  "value": "value"
                }
              ],
              "identifiers": [
                {
                  "key": "key",
                  "readOnly": false,
                  "value": "value"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Organization/settings/123")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organization.GetSettingsOrganizationAsync(123);
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SettingsQueryRecord>(mockResponse)).UsingDefaults()
        );
    }
}
