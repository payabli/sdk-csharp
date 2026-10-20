using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Applications;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ValidateApplicationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Validation completed",
              "traceId": "0HNP4OM1AUIEG:00000008",
              "data": {
                "valid": true,
                "servicesEvaluated": [
                  "payInCard",
                  "payInAch",
                  "payOutAch",
                  "payOutCheck"
                ],
                "sections": {
                  "business": {
                    "complete": true,
                    "missingFields": []
                  },
                  "salesAndPayments": {
                    "complete": true,
                    "missingFields": []
                  },
                  "banking": {
                    "complete": true,
                    "missingFields": []
                  },
                  "people": {
                    "complete": true,
                    "missingFields": []
                  }
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/requests/3f3caa7b-bdfe-4bf1-814b-30d54859247c/validate")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Applications.ValidateApplicationAsync(
            "3f3caa7b-bdfe-4bf1-814b-30d54859247c"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Validation completed",
              "traceId": "0HNP8M4GTH3J0:00000015",
              "data": {
                "valid": true,
                "servicesEvaluated": [
                  "payInCard"
                ],
                "sections": {
                  "business": {
                    "complete": true,
                    "missingFields": []
                  },
                  "salesAndPayments": {
                    "complete": true,
                    "missingFields": []
                  },
                  "banking": {
                    "complete": true,
                    "missingFields": []
                  },
                  "people": {
                    "complete": true,
                    "missingFields": []
                  }
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/requests/b7e2c915-4f0a-4d6b-a3c8-91e5d2f7c406/validate")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Applications.ValidateApplicationAsync(
            "b7e2c915-4f0a-4d6b-a3c8-91e5d2f7c406"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Validation completed",
              "traceId": "0HNONVRI1TD2T:00000012",
              "data": {
                "valid": true,
                "servicesEvaluated": [
                  "payOutAch",
                  "payOutCheck"
                ],
                "sections": {
                  "business": {
                    "complete": true,
                    "missingFields": []
                  },
                  "salesAndPayments": {
                    "complete": true,
                    "missingFields": []
                  },
                  "banking": {
                    "complete": true,
                    "missingFields": []
                  },
                  "people": {
                    "complete": true,
                    "missingFields": []
                  }
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/requests/4463979d-6336-4298-90cb-52d446030874/validate")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Applications.ValidateApplicationAsync(
            "4463979d-6336-4298-90cb-52d446030874"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Validation completed",
              "traceId": "0HNONVR8FHN0R:00000017",
              "data": {
                "valid": false,
                "servicesEvaluated": [
                  "payInCard",
                  "payInAch"
                ],
                "sections": {
                  "business": {
                    "complete": false,
                    "missingFields": [
                      {
                        "field": "business.description",
                        "label": "Business Description",
                        "reason": "required"
                      },
                      {
                        "field": "business.legalStructure",
                        "label": "Legal Structure",
                        "reason": "required"
                      },
                      {
                        "field": "business.establishedDate",
                        "label": "Established Date",
                        "reason": "required"
                      },
                      {
                        "field": "business.incorporationState",
                        "label": "Formation State",
                        "reason": "required"
                      },
                      {
                        "field": "business.merchantCatCode",
                        "label": "Industry (MCC)",
                        "reason": "required"
                      },
                      {
                        "field": "business.taxReference",
                        "label": "Tax ID (EIN/SSN)",
                        "reason": "required"
                      },
                      {
                        "field": "business.taxIdCountry",
                        "label": "Tax ID Country",
                        "reason": "required"
                      },
                      {
                        "field": "business.isForeignOwned",
                        "label": "Foreign Owned",
                        "reason": "required"
                      },
                      {
                        "field": "business.operatingSeasons",
                        "label": "Operating Seasons",
                        "reason": "required"
                      },
                      {
                        "field": "business.phone",
                        "label": "Business Phone",
                        "reason": "required"
                      },
                      {
                        "field": "business.emails",
                        "label": "Business Email",
                        "reason": "required"
                      },
                      {
                        "field": "business.addressDetails",
                        "label": "Business Address",
                        "reason": "required"
                      }
                    ]
                  },
                  "salesAndPayments": {
                    "complete": false,
                    "missingFields": [
                      {
                        "field": "business.processingMetrics.monthlyReceivablesVolume",
                        "label": "Annual Payment Volume",
                        "reason": "required"
                      },
                      {
                        "field": "business.processingMetrics.largestReceivableSize",
                        "label": "Largest Transaction",
                        "reason": "required"
                      },
                      {
                        "field": "business.processingMetrics.environments",
                        "label": "Payment Environment",
                        "reason": "required"
                      },
                      {
                        "field": "business.processingMetrics.numberOfTransactions",
                        "label": "Monthly Payment Count",
                        "reason": "required"
                      }
                    ]
                  },
                  "banking": {
                    "complete": false,
                    "missingFields": [
                      {
                        "field": "paymentMethods",
                        "label": "At least one payment method is required",
                        "reason": "required"
                      }
                    ]
                  },
                  "people": {
                    "complete": false,
                    "missingFields": [
                      {
                        "field": "people",
                        "label": "At least one owner or officer is required",
                        "reason": "required"
                      }
                    ]
                  }
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/requests/3f3caa7b-bdfe-4bf1-814b-30d54859247c/validate")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Applications.ValidateApplicationAsync(
            "3f3caa7b-bdfe-4bf1-814b-30d54859247c"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
