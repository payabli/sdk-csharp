using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Boarding;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetApplicationsByPaypointIdTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Records": [
                {
                  "idApplication": 68388,
                  "orgId": 123,
                  "dbaName": "Meadowbrook Phase II HOA A",
                  "legalName": "Meadowbrook Phase II HOA B",
                  "ein": "601907058",
                  "boardingStatus": 7,
                  "boardingSubStatus": 0,
                  "templateId": 8233,
                  "boardingLinkId": 6344,
                  "contactData": [
                    {
                      "contactName": "Gary Heaney",
                      "contactEmail": "hello@meadowbrookphaseii.com",
                      "contactTitle": "Human Group Designer",
                      "contactPhone": "7863078875"
                    }
                  ],
                  "generalEvents": [
                    {
                      "description": "Created",
                      "eventTime": "2026-03-17T18:56:39.885Z"
                    },
                    {
                      "description": "Linked to paypoint 6257",
                      "eventTime": "2026-03-17T18:56:39.885Z"
                    },
                    {
                      "description": "Updated Status: 7, 0",
                      "eventTime": "2026-03-18T19:32:39.401Z"
                    }
                  ]
                }
              ],
              "Summary": {
                "pageIdentifier": "null",
                "pageSize": 0,
                "totalAmount": 0,
                "totalNetAmount": 0,
                "totalPages": 0,
                "totalRecords": 1
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Boarding/applications/3040")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Boarding.GetApplicationsByPaypointIdAsync(3040);
        JsonAssert.AreEqual(response, mockResponse);
    }
}
