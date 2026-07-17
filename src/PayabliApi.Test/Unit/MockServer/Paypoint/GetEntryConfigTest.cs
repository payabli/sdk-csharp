using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Paypoint;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetEntryConfigTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseData": {
                "EntryName": "8cfec329267",
                "EntryPages": [
                  {
                    "AdditionalData": {
                      "key1": {
                        "key": "value"
                      },
                      "key2": {
                        "key": "value"
                      },
                      "key3": {
                        "key": "value"
                      }
                    }
                  }
                ],
                "IdEntry": 11111,
                "Paypoint": {
                  "Address1": "123 Ocean Drive",
                  "Address2": "Suite 400",
                  "BankData": [
                    {
                      "bankAccountFunction": 0,
                      "bankAccountHolderName": "Gruzya Adventure Outfitters LLC",
                      "nickname": "Business Checking 1234"
                    }
                  ],
                  "BoardingId": 340,
                  "City": "Bristol",
                  "Contacts": [
                    {}
                  ],
                  "Country": "US",
                  "Credentials": [
                    {}
                  ],
                  "DbaName": "Sunshine Gutters",
                  "externalPaypointID": "",
                  "Fax": "5555555555",
                  "IdPaypoint": 1000000,
                  "LegalName": "Sunshine Services, LLC",
                  "ParentOrg": {
                    "orgName": "Pilgrim Planner",
                    "orgStatus": 1,
                    "orgType": 0
                  },
                  "PaypointStatus": 1,
                  "Phone": "5555555555",
                  "State": "GA",
                  "summary": {
                    "amountSubs": 0,
                    "amountTx": 0,
                    "countSubs": 0,
                    "countTx": 0,
                    "customers": 1
                  },
                  "TimeZone": -5,
                  "WebsiteAddress": "www.example.com",
                  "Zip": "31113",
                  "StatementEmail": {
                    "sender": "acme-partners@payabli.com",
                    "recipients": [
                      "billing@example.com"
                    ]
                  }
                }
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Paypoint/8cfec329267")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Paypoint.GetEntryConfigAsync(
            "8cfec329267",
            new GetEntryConfigRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
