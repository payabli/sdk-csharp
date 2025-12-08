using System.Globalization;
using System.Text.Json;
using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test;

[TestFixture]
public class QueryPayoutTransactionTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "Records": [
                {
                  "BatchNumber": "BT-2024321",
                  "Bills": [
                    {}
                  ],
                  "CardToken": "CardToken",
                  "CheckNumber": "12345",
                  "Comments": "Deposit for materials",
                  "CreatedAt": "2022-07-01T15:00:01Z",
                  "EntryName": "d193cf9a46",
                  "Events": [
                    {}
                  ],
                  "externalPaypointID": "Paypoint-100",
                  "FeeAmount": 10.25,
                  "Gateway": "TSYS",
                  "IdOut": 236,
                  "LastUpdated": "2022-07-01T15:00:01Z",
                  "NetAmount": 3762.87,
                  "ParentOrgName": "PropertyManager Pro",
                  "PaymentData": {
                    "paymentDetails": {
                      "totalAmount": 100
                    }
                  },
                  "PaymentId": "12345678910",
                  "PaymentMethod": "ach",
                  "PaymentStatus": "Processed",
                  "PaypointDbaname": "Sunshine Gutters",
                  "PaypointLegalname": "Sunshine Services, LLC",
                  "Source": "api",
                  "Status": 1,
                  "TotalAmount": 110.25,
                  "Vendor": {
                    "additionalData": {
                      "key1": {
                        "key": "value"
                      },
                      "key2": {
                        "key": "value"
                      },
                      "key3": {
                        "key": "value"
                      }
                    },
                    "CreatedDate": "2022-07-01T15:00:01Z"
                  }
                }
              ],
              "Summary": {
                "totalPages": 391,
                "totalRecords": 7803,
                "totalAmount": 21435.95,
                "totalNetAmount": 21435.95,
                "totalPaid": 1,
                "totalPaidAmount": 4,
                "totalCanceled": 1743,
                "totalCanceledAmount": 4515,
                "totalCaptured": 138,
                "totalCapturedAmount": 542,
                "totalAuthorized": 4139,
                "totalAuthorizedAmount": 11712.35,
                "totalProcessing": 1780,
                "totalProcessingAmount": 4660.6,
                "totalOpen": 2,
                "totalOpenAmount": 2,
                "totalOnHold": 0,
                "totalOnHoldAmount": 0,
                "pageSize": 20
              }
            }
            """;
        var expectedObject = new QueryPayoutTransaction
        {
            Records = new List<QueryPayoutTransactionRecordsItem>()
            {
                new QueryPayoutTransactionRecordsItem
                {
                    BatchNumber = "BT-2024321",
                    Bills = new List<BillPayOutData>() { new BillPayOutData() },
                    CardToken = "CardToken",
                    CheckNumber = "12345",
                    Comments = "Deposit for materials",
                    CreatedAt = DateTime.Parse(
                        "2022-07-01T15:00:01.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    EntryName = "d193cf9a46",
                    Events = new List<QueryTransactionEvents>() { new QueryTransactionEvents() },
                    ExternalPaypointId = "Paypoint-100",
                    FeeAmount = 10.25,
                    Gateway = "TSYS",
                    IdOut = 236,
                    LastUpdated = DateTime.Parse(
                        "2022-07-01T15:00:01.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    NetAmount = 3762.87,
                    ParentOrgName = "PropertyManager Pro",
                    PaymentData = new QueryPayoutTransactionRecordsItemPaymentData
                    {
                        PaymentDetails = new PaymentDetail { TotalAmount = 100 },
                    },
                    PaymentId = "12345678910",
                    PaymentMethod = "ach",
                    PaymentStatus = "Processed",
                    PaypointDbaname = "Sunshine Gutters",
                    PaypointLegalname = "Sunshine Services, LLC",
                    Source = "api",
                    Status = 1,
                    TotalAmount = 110.25,
                    Vendor = new VendorQueryRecord
                    {
                        AdditionalData = new Dictionary<string, Dictionary<string, object?>?>()
                        {
                            {
                                "key1",
                                new Dictionary<string, object?>() { { "key", "value" } }
                            },
                            {
                                "key2",
                                new Dictionary<string, object?>() { { "key", "value" } }
                            },
                            {
                                "key3",
                                new Dictionary<string, object?>() { { "key", "value" } }
                            },
                        },
                        CreatedDate = DateTime.Parse(
                            "2022-07-01T15:00:01.000Z",
                            null,
                            DateTimeStyles.AdjustToUniversal
                        ),
                    },
                },
            },
            Summary = new QueryPayoutTransactionSummary
            {
                TotalPages = 391,
                TotalRecords = 7803,
                TotalAmount = 21435.95,
                TotalNetAmount = 21435.95,
                TotalPaid = 1,
                TotalPaidAmount = 4,
                TotalCanceled = 1743,
                TotalCanceledAmount = 4515,
                TotalCaptured = 138,
                TotalCapturedAmount = 542,
                TotalAuthorized = 4139,
                TotalAuthorizedAmount = 11712.35,
                TotalProcessing = 1780,
                TotalProcessingAmount = 4660.6,
                TotalOpen = 2,
                TotalOpenAmount = 2,
                TotalOnHold = 0,
                TotalOnHoldAmount = 0,
                PageSize = 20,
            },
        };
        var deserializedObject = JsonUtils.Deserialize<QueryPayoutTransaction>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var expectedJson = """
            {
              "Records": [
                {
                  "BatchNumber": "BT-2024321",
                  "Bills": [
                    {}
                  ],
                  "CardToken": "CardToken",
                  "CheckNumber": "12345",
                  "Comments": "Deposit for materials",
                  "CreatedAt": "2022-07-01T15:00:01Z",
                  "EntryName": "d193cf9a46",
                  "Events": [
                    {}
                  ],
                  "externalPaypointID": "Paypoint-100",
                  "FeeAmount": 10.25,
                  "Gateway": "TSYS",
                  "IdOut": 236,
                  "LastUpdated": "2022-07-01T15:00:01Z",
                  "NetAmount": 3762.87,
                  "ParentOrgName": "PropertyManager Pro",
                  "PaymentData": {
                    "paymentDetails": {
                      "totalAmount": 100
                    }
                  },
                  "PaymentId": "12345678910",
                  "PaymentMethod": "ach",
                  "PaymentStatus": "Processed",
                  "PaypointDbaname": "Sunshine Gutters",
                  "PaypointLegalname": "Sunshine Services, LLC",
                  "Source": "api",
                  "Status": 1,
                  "TotalAmount": 110.25,
                  "Vendor": {
                    "additionalData": {
                      "key1": {
                        "key": "value"
                      },
                      "key2": {
                        "key": "value"
                      },
                      "key3": {
                        "key": "value"
                      }
                    },
                    "CreatedDate": "2022-07-01T15:00:01Z"
                  }
                }
              ],
              "Summary": {
                "totalPages": 391,
                "totalRecords": 7803,
                "totalAmount": 21435.95,
                "totalNetAmount": 21435.95,
                "totalPaid": 1,
                "totalPaidAmount": 4,
                "totalCanceled": 1743,
                "totalCanceledAmount": 4515,
                "totalCaptured": 138,
                "totalCapturedAmount": 542,
                "totalAuthorized": 4139,
                "totalAuthorizedAmount": 11712.35,
                "totalProcessing": 1780,
                "totalProcessingAmount": 4660.6,
                "totalOpen": 2,
                "totalOpenAmount": 2,
                "totalOnHold": 0,
                "totalOnHoldAmount": 0,
                "pageSize": 20
              }
            }
            """;
        var actualObj = new QueryPayoutTransaction
        {
            Records = new List<QueryPayoutTransactionRecordsItem>()
            {
                new QueryPayoutTransactionRecordsItem
                {
                    BatchNumber = "BT-2024321",
                    Bills = new List<BillPayOutData>() { new BillPayOutData() },
                    CardToken = "CardToken",
                    CheckNumber = "12345",
                    Comments = "Deposit for materials",
                    CreatedAt = DateTime.Parse(
                        "2022-07-01T15:00:01.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    EntryName = "d193cf9a46",
                    Events = new List<QueryTransactionEvents>() { new QueryTransactionEvents() },
                    ExternalPaypointId = "Paypoint-100",
                    FeeAmount = 10.25,
                    Gateway = "TSYS",
                    IdOut = 236,
                    LastUpdated = DateTime.Parse(
                        "2022-07-01T15:00:01.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    NetAmount = 3762.87,
                    ParentOrgName = "PropertyManager Pro",
                    PaymentData = new QueryPayoutTransactionRecordsItemPaymentData
                    {
                        PaymentDetails = new PaymentDetail { TotalAmount = 100 },
                    },
                    PaymentId = "12345678910",
                    PaymentMethod = "ach",
                    PaymentStatus = "Processed",
                    PaypointDbaname = "Sunshine Gutters",
                    PaypointLegalname = "Sunshine Services, LLC",
                    Source = "api",
                    Status = 1,
                    TotalAmount = 110.25,
                    Vendor = new VendorQueryRecord
                    {
                        AdditionalData = new Dictionary<string, Dictionary<string, object?>?>()
                        {
                            {
                                "key1",
                                new Dictionary<string, object?>() { { "key", "value" } }
                            },
                            {
                                "key2",
                                new Dictionary<string, object?>() { { "key", "value" } }
                            },
                            {
                                "key3",
                                new Dictionary<string, object?>() { { "key", "value" } }
                            },
                        },
                        CreatedDate = DateTime.Parse(
                            "2022-07-01T15:00:01.000Z",
                            null,
                            DateTimeStyles.AdjustToUniversal
                        ),
                    },
                },
            },
            Summary = new QueryPayoutTransactionSummary
            {
                TotalPages = 391,
                TotalRecords = 7803,
                TotalAmount = 21435.95,
                TotalNetAmount = 21435.95,
                TotalPaid = 1,
                TotalPaidAmount = 4,
                TotalCanceled = 1743,
                TotalCanceledAmount = 4515,
                TotalCaptured = 138,
                TotalCapturedAmount = 542,
                TotalAuthorized = 4139,
                TotalAuthorizedAmount = 11712.35,
                TotalProcessing = 1780,
                TotalProcessingAmount = 4660.6,
                TotalOpen = 2,
                TotalOpenAmount = 2,
                TotalOnHold = 0,
                TotalOnHoldAmount = 0,
                PageSize = 20,
            },
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }
}
