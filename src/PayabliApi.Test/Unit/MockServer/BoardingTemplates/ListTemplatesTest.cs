using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.BoardingTemplates;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTemplatesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Summary": {
                "totalPages": 1,
                "totalRecords": 1,
                "pageSize": 20
              },
              "Records": [
                {
                  "uuid": "019ff129-d393-7761-9a31-e5afe85b4081",
                  "orgId": 123,
                  "orgName": "PropertyManager Pro",
                  "name": "Standard boarding template",
                  "status": "active",
                  "currentVersionUuid": "019ff129-d396-74c4-86da-ae3d082d7ef9",
                  "currentVersion": {
                    "uuid": "019ff129-d396-74c4-86da-ae3d082d7ef9",
                    "version": 1,
                    "services": {
                      "ach": "merchantDecision",
                      "card": "preSelected",
                      "checkRdc": "merchantDecision"
                    },
                    "fieldConfigurations": [
                      {
                        "label": "Website",
                        "hint": null,
                        "defaultValue": null,
                        "attributes": [
                          "required",
                          "visible"
                        ],
                        "fieldPath": "business.website"
                      },
                      {
                        "label": "Sales Channel",
                        "hint": null,
                        "defaultValue": null,
                        "questionType": "multipleChoiceSingle",
                        "options": [
                          "In-Store",
                          "Online",
                          "Both"
                        ],
                        "attributes": [
                          "required",
                          "visible"
                        ],
                        "fieldPath": "business.salesChannel",
                        "custom": true
                      },
                      {
                        "label": "Primary Customer Type",
                        "hint": null,
                        "defaultValue": null,
                        "questionType": "multipleChoiceSingle",
                        "options": [
                          "B2B",
                          "B2C",
                          "Both"
                        ],
                        "attributes": [
                          "required",
                          "visible"
                        ],
                        "fieldPath": "business.customerType",
                        "custom": true
                      },
                      {
                        "label": "Years in Business",
                        "hint": null,
                        "defaultValue": null,
                        "questionType": "dropdown",
                        "options": [
                          "Less than 1",
                          "1-3",
                          "3-5",
                          "5-10",
                          "10+"
                        ],
                        "attributes": [
                          "required",
                          "visible"
                        ],
                        "fieldPath": "business.yearsInBusiness",
                        "custom": true
                      },
                      {
                        "label": "Describe your refund policy",
                        "hint": null,
                        "defaultValue": null,
                        "questionType": "textarea",
                        "options": null,
                        "attributes": [
                          "visible"
                        ],
                        "fieldPath": "business.refundPolicy",
                        "custom": true
                      }
                    ],
                    "conditionalRules": [
                      {
                        "ruleName": "require-website-online",
                        "description": "Require the website field when sales happen online.",
                        "enabled": true,
                        "matchMode": "all",
                        "conditions": [
                          {
                            "fieldPath": "business.salesChannel",
                            "operator": "equals",
                            "value": "Online"
                          }
                        ],
                        "actions": [
                          {
                            "actionType": "setFieldAttributes",
                            "fieldPath": "business.website",
                            "visible": null,
                            "required": true,
                            "readOnly": null
                          }
                        ]
                      },
                      {
                        "ruleName": "require-refund-policy-airlines",
                        "description": "Require the refund policy field when the merchant category code (MCC) is 3000 (airlines).",
                        "enabled": true,
                        "matchMode": "all",
                        "conditions": [
                          {
                            "fieldPath": "business.merchantCatCode",
                            "operator": "equals",
                            "value": "3000"
                          }
                        ],
                        "actions": [
                          {
                            "actionType": "setFieldAttributes",
                            "fieldPath": "business.refundPolicy",
                            "visible": true,
                            "required": true,
                            "readOnly": null
                          }
                        ]
                      }
                    ],
                    "documents": [
                      {
                        "fieldPath": "documents.bankStatement",
                        "preset": true,
                        "label": "Bank Statement",
                        "hint": "3 most recent months",
                        "maxUploads": 3,
                        "allowedFormats": [
                          "pdf",
                          "jpg",
                          "png"
                        ],
                        "attributes": [
                          "required",
                          "visible"
                        ]
                      }
                    ],
                    "devices": [
                      {
                        "deviceId": "ingenico_axium_dx8",
                        "preSelected": false
                      },
                      {
                        "deviceId": "ingenico_axium_rx9000",
                        "preSelected": false
                      }
                    ],
                    "hiddenSections": [
                      "welcome"
                    ],
                    "allowedMccs": [
                      5200,
                      8998
                    ],
                    "underwriting": "automatic",
                    "mpaContent": "<p>Merchant Processing Agreement</p>",
                    "payinPricingId": 1289,
                    "allowGuidedTour": false,
                    "allowBusinessPrefill": true,
                    "allowSaveForLater": true,
                    "allowMultipleBanks": true,
                    "allowServiceSelection": true,
                    "allowDeviceSelection": true,
                    "allowAmigoChat": true,
                    "allowUserCreation": true,
                    "allowPeoplePrefill": false,
                    "verticalProgress": true,
                    "useFloatingInputs": false,
                    "centerContent": true,
                    "allowRealTimeBankVerification": true,
                    "allowCheckboxSigning": true,
                    "allowTypedSignature": true,
                    "allowWrittenSignature": true,
                    "allowMultiOwnerEsign": false,
                    "allowConfirmationAndAttestation": true,
                    "allowPCIAttestation": false,
                    "createdAt": "2026-07-01T15:00:01.038310",
                    "createdBy": "0"
                  },
                  "isInherited": false,
                  "readOnly": false,
                  "createdBy": "0",
                  "updatedBy": "0",
                  "createdAt": "2026-07-01T15:00:01.035727",
                  "updatedAt": "2026-07-01T15:00:01.040548"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/templates")
                    .WithParam("orgId", "123")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.BoardingTemplates.ListTemplatesAsync(
            new ListTemplatesBoardingTemplatesRequest { OrgId = 123 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
