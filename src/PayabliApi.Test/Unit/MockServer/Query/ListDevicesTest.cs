using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Query;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListDevicesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Summary": {
                "pageSize": 20,
                "totalAmount": 0,
                "totalNetAmount": 0,
                "totalPages": 2,
                "totalRecords": 28
              },
              "Records": [
                {
                  "deviceId": "499585-389fj484-3jcj8hj3",
                  "idCloud": 142,
                  "description": "Front Counter Terminal",
                  "serialNumber": "SN-90210-XR",
                  "friendlyName": "Front Counter Terminal",
                  "make": "Ingenico",
                  "model": "LK2500",
                  "deviceType": 1,
                  "deviceStatus": 1,
                  "macAddress": "1A2B3C4D5E6F",
                  "lastHealthCheck": "2026-04-09T14:49:42Z",
                  "registrationCode": "REG-A1B2C3D4",
                  "activationAttempts": 0,
                  "activationCodeExpiry": "2026-04-09T14:49:42Z",
                  "createdAt": "2026-04-09T01:14:37Z",
                  "updatedAt": "2026-04-09T14:49:42Z",
                  "paypointId": 3040,
                  "paypointDba": "Gruzya Adventure Outfitters",
                  "paypointLegal": "Gruzya Adventure Outfitters, LLC",
                  "paypointEntry": "8cfec329267",
                  "externalPaypointId": "GRUZYA-01",
                  "parentOrgId": 100,
                  "parentOrgName": "Example Corp"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Query/devices/8cfec329267")
                    .WithParam("fromRecord", "0")
                    .WithParam("limitRecord", "20")
                    .WithParam("sortBy", "desc(createdAt)")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Query.ListDevicesAsync(
            "8cfec329267",
            new ListDevicesRequest
            {
                FromRecord = 0,
                LimitRecord = 20,
                SortBy = "desc(createdAt)",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
