using System.Globalization;
using System.Text.Json;
using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test;

[TestFixture]
public class BillQueryResponseTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
              "Summary": {
                "pageidentifier": null,
                "pageSize": 20,
                "total2approval": 1,
                "totalactive": 1,
                "totalAmount": 1.1,
                "totalamount2approval": 1.1,
                "totalamountactive": 1.1,
                "totalamountapproved": 1.1,
                "totalamountcancel": 1.1,
                "totalamountdisapproved": 1.1,
                "totalamountintransit": 1.1,
                "totalamountoverdue": 1.1,
                "totalamountpaid": 1.1,
                "totalamountsent2approval": 1.1,
                "totalapproved": 1,
                "totalcancel": 1,
                "totaldisapproved": 1,
                "totalintransit": 1,
                "totaloverdue": 1,
                "totalPages": 1,
                "totalpaid": 1,
                "totalRecords": 2,
                "totalsent2approval": 1
              },
              "Records": [
                {
                  "AdditionalData": null,
                  "billApprovals": [
                    {
                      "approved": 0,
                      "approvedTime": "2024-03-13T15:54:27Z",
                      "email": "lisandra@example.com",
                      "Id": 34
                    },
                    {
                      "approved": 0,
                      "approvedTime": "2024-03-13T15:54:27Z",
                      "email": "jccastillo@example.com",
                      "Id": 293
                    }
                  ],
                  "BillDate": "2025-03-10",
                  "billEvents": [
                    {
                      "description": "Created Bill",
                      "eventTime": "2024-03-13T15:54:26Z",
                      "refData": "00-45e1c2d8b53b72fafc4082f374e68753-ffea4ba4c2ce63ce-00"
                    },
                    {
                      "description": "Sent to Approval",
                      "eventTime": "2024-03-13T15:54:28Z",
                      "refData": "00-086a951822211bc2eb1803ed64db9d4f-0f07e0e8c394e481-00"
                    }
                  ],
                  "BillItems": [
                    {
                      "itemCommodityCode": "Commod-MI-2024031926",
                      "itemCost": 200,
                      "itemDescription": "Consultation price",
                      "itemMode": 0,
                      "itemProductCode": "Prod-MI-2024031926",
                      "itemProductName": "Consultation",
                      "itemQty": 1,
                      "itemTaxAmount": 0,
                      "itemTaxRate": 0,
                      "itemTotalAmount": 200,
                      "itemUnitOfMeasure": "per each"
                    }
                  ],
                  "BillNumber": "MI-bill-2024031926",
                  "Comments": "PAYBILL",
                  "CreatedAt": "2024-03-13T15:54:26Z",
                  "Discount": 0,
                  "DocumentsRef": null,
                  "DueDate": "2025-03-10",
                  "EndDate": null,
                  "EntityID": null,
                  "externalPaypointID": "micasa-10",
                  "Frequency": "one-time",
                  "IdBill": 6104,
                  "LastUpdated": "2024-03-13T10:54:26Z",
                  "LotNumber": "LOT123",
                  "Mode": 0,
                  "NetAmount": 200,
                  "ParentOrgId": 1001,
                  "ParentOrgName": "Fitness Hub",
                  "PaymentId": null,
                  "PaymentMethod": null,
                  "paylinkId": null,
                  "PaypointDbaname": "MiCasa Sports",
                  "PaypointEntryname": "micasa",
                  "PaypointLegalname": "MiCasa Sports LLC",
                  "Source": "web",
                  "Status": 2,
                  "Terms": "Net30",
                  "TotalAmount": 200,
                  "Transaction": null,
                  "Vendor": {
                    "Address1": "1234 Liberdad St.",
                    "Address2": "Suite 100",
                    "BillingData": {
                      "accountNumber": "12345XXXX",
                      "bankAccountFunction": 0,
                      "bankAccountHolderName": "Elena Gomez",
                      "bankAccountHolderType": "Business",
                      "bankName": "Michigan Savings Bank",
                      "id": 0,
                      "routingAccount": "072000326",
                      "typeAccount": "Checking"
                    },
                    "City": "Detroit",
                    "Country": "US",
                    "EIN": "XXXXX6789",
                    "Email": "elenag@industriesexample.com",
                    "InternalReferenceId": 1215,
                    "Mcc": "700",
                    "Name1": "Gomez-Radulescu Industries",
                    "Name2": "Elena",
                    "Phone": "517-555-0123",
                    "State": "MI",
                    "VendorId": 8723,
                    "VendorNumber": "MI-vendor-2024031926",
                    "VendorStatus": 1,
                    "Zip": "48201"
                  }
                }
              ]
            }
            """;
        var expectedObject = new BillQueryResponse
        {
            Summary = new BillQueryResponseSummary
            {
                Pageidentifier = null,
                PageSize = 20,
                Total2Approval = 1,
                Totalactive = 1,
                TotalAmount = 1.1,
                Totalamount2Approval = 1.1,
                Totalamountactive = 1.1,
                Totalamountapproved = 1.1,
                Totalamountcancel = 1.1,
                Totalamountdisapproved = 1.1,
                Totalamountintransit = 1.1,
                Totalamountoverdue = 1.1,
                Totalamountpaid = 1.1,
                Totalamountsent2Approval = 1.1,
                Totalapproved = 1,
                Totalcancel = 1,
                Totaldisapproved = 1,
                Totalintransit = 1,
                Totaloverdue = 1,
                TotalPages = 1,
                Totalpaid = 1,
                TotalRecords = 2,
                Totalsent2Approval = 1,
            },
            Records = new List<BillQueryRecord2>()
            {
                new BillQueryRecord2
                {
                    AdditionalData = null,
                    BillApprovals = new List<BillQueryRecord2BillApprovalsItem>()
                    {
                        new BillQueryRecord2BillApprovalsItem
                        {
                            Approved = 0,
                            ApprovedTime = DateTime.Parse(
                                "2024-03-13T15:54:27.000Z",
                                null,
                                DateTimeStyles.AdjustToUniversal
                            ),
                            Email = "lisandra@example.com",
                            Id = 34,
                        },
                        new BillQueryRecord2BillApprovalsItem
                        {
                            Approved = 0,
                            ApprovedTime = DateTime.Parse(
                                "2024-03-13T15:54:27.000Z",
                                null,
                                DateTimeStyles.AdjustToUniversal
                            ),
                            Email = "jccastillo@example.com",
                            Id = 293,
                        },
                    },
                    BillDate = new DateOnly(2025, 3, 10),
                    BillEvents = new List<GeneralEvents>()
                    {
                        new GeneralEvents
                        {
                            Description = "Created Bill",
                            EventTime = DateTime.Parse(
                                "2024-03-13T15:54:26.000Z",
                                null,
                                DateTimeStyles.AdjustToUniversal
                            ),
                            RefData = "00-45e1c2d8b53b72fafc4082f374e68753-ffea4ba4c2ce63ce-00",
                        },
                        new GeneralEvents
                        {
                            Description = "Sent to Approval",
                            EventTime = DateTime.Parse(
                                "2024-03-13T15:54:28.000Z",
                                null,
                                DateTimeStyles.AdjustToUniversal
                            ),
                            RefData = "00-086a951822211bc2eb1803ed64db9d4f-0f07e0e8c394e481-00",
                        },
                    },
                    BillItems = new List<BillItem>()
                    {
                        new BillItem
                        {
                            ItemCommodityCode = "Commod-MI-2024031926",
                            ItemCost = 200,
                            ItemDescription = "Consultation price",
                            ItemMode = 0,
                            ItemProductCode = "Prod-MI-2024031926",
                            ItemProductName = "Consultation",
                            ItemQty = 1,
                            ItemTaxAmount = 0,
                            ItemTaxRate = 0,
                            ItemTotalAmount = 200,
                            ItemUnitOfMeasure = "per each",
                        },
                    },
                    BillNumber = "MI-bill-2024031926",
                    Comments = "PAYBILL",
                    CreatedAt = DateTime.Parse(
                        "2024-03-13T15:54:26.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    Discount = 0,
                    DocumentsRef = null,
                    DueDate = new DateOnly(2025, 3, 10),
                    EndDate = null,
                    EntityId = null,
                    ExternalPaypointId = "micasa-10",
                    Frequency = Frequency.OneTime,
                    IdBill = 6104,
                    LastUpdated = DateTime.Parse(
                        "2024-03-13T10:54:26.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    LotNumber = "LOT123",
                    Mode = 0,
                    NetAmount = 200,
                    ParentOrgId = 1001,
                    ParentOrgName = "Fitness Hub",
                    PaymentId = null,
                    PaymentMethod = null,
                    PaylinkId = null,
                    PaypointDbaname = "MiCasa Sports",
                    PaypointEntryname = "micasa",
                    PaypointLegalname = "MiCasa Sports LLC",
                    Source = "web",
                    Status = 2,
                    Terms = "Net30",
                    TotalAmount = 200,
                    Transaction = null,
                    Vendor = new VendorOutData
                    {
                        Address1 = "1234 Liberdad St.",
                        Address2 = "Suite 100",
                        BillingData = new BillingData
                        {
                            AccountNumber = "12345XXXX",
                            BankAccountFunction = 0,
                            BankAccountHolderName = "Elena Gomez",
                            BankAccountHolderType = BankAccountHolderType.Business,
                            BankName = "Michigan Savings Bank",
                            Id = 0,
                            RoutingAccount = "072000326",
                            TypeAccount = TypeAccount.Checking,
                        },
                        City = "Detroit",
                        Country = "US",
                        Ein = "XXXXX6789",
                        Email = "elenag@industriesexample.com",
                        InternalReferenceId = 1215,
                        Mcc = "700",
                        Name1 = "Gomez-Radulescu Industries",
                        Name2 = "Elena",
                        Phone = "517-555-0123",
                        State = "MI",
                        VendorId = 8723,
                        VendorNumber = "MI-vendor-2024031926",
                        VendorStatus = 1,
                        Zip = "48201",
                    },
                },
            },
        };
        var deserializedObject = JsonUtils.Deserialize<BillQueryResponse>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var expectedJson = """
            {
              "Summary": {
                "pageidentifier": null,
                "pageSize": 20,
                "total2approval": 1,
                "totalactive": 1,
                "totalAmount": 1.1,
                "totalamount2approval": 1.1,
                "totalamountactive": 1.1,
                "totalamountapproved": 1.1,
                "totalamountcancel": 1.1,
                "totalamountdisapproved": 1.1,
                "totalamountintransit": 1.1,
                "totalamountoverdue": 1.1,
                "totalamountpaid": 1.1,
                "totalamountsent2approval": 1.1,
                "totalapproved": 1,
                "totalcancel": 1,
                "totaldisapproved": 1,
                "totalintransit": 1,
                "totaloverdue": 1,
                "totalPages": 1,
                "totalpaid": 1,
                "totalRecords": 2,
                "totalsent2approval": 1
              },
              "Records": [
                {
                  "AdditionalData": null,
                  "billApprovals": [
                    {
                      "approved": 0,
                      "approvedTime": "2024-03-13T15:54:27Z",
                      "email": "lisandra@example.com",
                      "Id": 34
                    },
                    {
                      "approved": 0,
                      "approvedTime": "2024-03-13T15:54:27Z",
                      "email": "jccastillo@example.com",
                      "Id": 293
                    }
                  ],
                  "BillDate": "2025-03-10",
                  "billEvents": [
                    {
                      "description": "Created Bill",
                      "eventTime": "2024-03-13T15:54:26Z",
                      "refData": "00-45e1c2d8b53b72fafc4082f374e68753-ffea4ba4c2ce63ce-00"
                    },
                    {
                      "description": "Sent to Approval",
                      "eventTime": "2024-03-13T15:54:28Z",
                      "refData": "00-086a951822211bc2eb1803ed64db9d4f-0f07e0e8c394e481-00"
                    }
                  ],
                  "BillItems": [
                    {
                      "itemCommodityCode": "Commod-MI-2024031926",
                      "itemCost": 200,
                      "itemDescription": "Consultation price",
                      "itemMode": 0,
                      "itemProductCode": "Prod-MI-2024031926",
                      "itemProductName": "Consultation",
                      "itemQty": 1,
                      "itemTaxAmount": 0,
                      "itemTaxRate": 0,
                      "itemTotalAmount": 200,
                      "itemUnitOfMeasure": "per each"
                    }
                  ],
                  "BillNumber": "MI-bill-2024031926",
                  "Comments": "PAYBILL",
                  "CreatedAt": "2024-03-13T15:54:26Z",
                  "Discount": 0,
                  "DocumentsRef": null,
                  "DueDate": "2025-03-10",
                  "EndDate": null,
                  "EntityID": null,
                  "externalPaypointID": "micasa-10",
                  "Frequency": "one-time",
                  "IdBill": 6104,
                  "LastUpdated": "2024-03-13T10:54:26Z",
                  "LotNumber": "LOT123",
                  "Mode": 0,
                  "NetAmount": 200,
                  "ParentOrgId": 1001,
                  "ParentOrgName": "Fitness Hub",
                  "PaymentId": null,
                  "PaymentMethod": null,
                  "paylinkId": null,
                  "PaypointDbaname": "MiCasa Sports",
                  "PaypointEntryname": "micasa",
                  "PaypointLegalname": "MiCasa Sports LLC",
                  "Source": "web",
                  "Status": 2,
                  "Terms": "Net30",
                  "TotalAmount": 200,
                  "Transaction": null,
                  "Vendor": {
                    "Address1": "1234 Liberdad St.",
                    "Address2": "Suite 100",
                    "BillingData": {
                      "accountNumber": "12345XXXX",
                      "bankAccountFunction": 0,
                      "bankAccountHolderName": "Elena Gomez",
                      "bankAccountHolderType": "Business",
                      "bankName": "Michigan Savings Bank",
                      "id": 0,
                      "routingAccount": "072000326",
                      "typeAccount": "Checking"
                    },
                    "City": "Detroit",
                    "Country": "US",
                    "EIN": "XXXXX6789",
                    "Email": "elenag@industriesexample.com",
                    "InternalReferenceId": 1215,
                    "Mcc": "700",
                    "Name1": "Gomez-Radulescu Industries",
                    "Name2": "Elena",
                    "Phone": "517-555-0123",
                    "State": "MI",
                    "VendorId": 8723,
                    "VendorNumber": "MI-vendor-2024031926",
                    "VendorStatus": 1,
                    "Zip": "48201"
                  }
                }
              ]
            }
            """;
        var actualObj = new BillQueryResponse
        {
            Summary = new BillQueryResponseSummary
            {
                Pageidentifier = null,
                PageSize = 20,
                Total2Approval = 1,
                Totalactive = 1,
                TotalAmount = 1.1,
                Totalamount2Approval = 1.1,
                Totalamountactive = 1.1,
                Totalamountapproved = 1.1,
                Totalamountcancel = 1.1,
                Totalamountdisapproved = 1.1,
                Totalamountintransit = 1.1,
                Totalamountoverdue = 1.1,
                Totalamountpaid = 1.1,
                Totalamountsent2Approval = 1.1,
                Totalapproved = 1,
                Totalcancel = 1,
                Totaldisapproved = 1,
                Totalintransit = 1,
                Totaloverdue = 1,
                TotalPages = 1,
                Totalpaid = 1,
                TotalRecords = 2,
                Totalsent2Approval = 1,
            },
            Records = new List<BillQueryRecord2>()
            {
                new BillQueryRecord2
                {
                    AdditionalData = null,
                    BillApprovals = new List<BillQueryRecord2BillApprovalsItem>()
                    {
                        new BillQueryRecord2BillApprovalsItem
                        {
                            Approved = 0,
                            ApprovedTime = DateTime.Parse(
                                "2024-03-13T15:54:27.000Z",
                                null,
                                DateTimeStyles.AdjustToUniversal
                            ),
                            Email = "lisandra@example.com",
                            Id = 34,
                        },
                        new BillQueryRecord2BillApprovalsItem
                        {
                            Approved = 0,
                            ApprovedTime = DateTime.Parse(
                                "2024-03-13T15:54:27.000Z",
                                null,
                                DateTimeStyles.AdjustToUniversal
                            ),
                            Email = "jccastillo@example.com",
                            Id = 293,
                        },
                    },
                    BillDate = new DateOnly(2025, 3, 10),
                    BillEvents = new List<GeneralEvents>()
                    {
                        new GeneralEvents
                        {
                            Description = "Created Bill",
                            EventTime = DateTime.Parse(
                                "2024-03-13T15:54:26.000Z",
                                null,
                                DateTimeStyles.AdjustToUniversal
                            ),
                            RefData = "00-45e1c2d8b53b72fafc4082f374e68753-ffea4ba4c2ce63ce-00",
                        },
                        new GeneralEvents
                        {
                            Description = "Sent to Approval",
                            EventTime = DateTime.Parse(
                                "2024-03-13T15:54:28.000Z",
                                null,
                                DateTimeStyles.AdjustToUniversal
                            ),
                            RefData = "00-086a951822211bc2eb1803ed64db9d4f-0f07e0e8c394e481-00",
                        },
                    },
                    BillItems = new List<BillItem>()
                    {
                        new BillItem
                        {
                            ItemCommodityCode = "Commod-MI-2024031926",
                            ItemCost = 200,
                            ItemDescription = "Consultation price",
                            ItemMode = 0,
                            ItemProductCode = "Prod-MI-2024031926",
                            ItemProductName = "Consultation",
                            ItemQty = 1,
                            ItemTaxAmount = 0,
                            ItemTaxRate = 0,
                            ItemTotalAmount = 200,
                            ItemUnitOfMeasure = "per each",
                        },
                    },
                    BillNumber = "MI-bill-2024031926",
                    Comments = "PAYBILL",
                    CreatedAt = DateTime.Parse(
                        "2024-03-13T15:54:26.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    Discount = 0,
                    DocumentsRef = null,
                    DueDate = new DateOnly(2025, 3, 10),
                    EndDate = null,
                    EntityId = null,
                    ExternalPaypointId = "micasa-10",
                    Frequency = Frequency.OneTime,
                    IdBill = 6104,
                    LastUpdated = DateTime.Parse(
                        "2024-03-13T10:54:26.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    LotNumber = "LOT123",
                    Mode = 0,
                    NetAmount = 200,
                    ParentOrgId = 1001,
                    ParentOrgName = "Fitness Hub",
                    PaymentId = null,
                    PaymentMethod = null,
                    PaylinkId = null,
                    PaypointDbaname = "MiCasa Sports",
                    PaypointEntryname = "micasa",
                    PaypointLegalname = "MiCasa Sports LLC",
                    Source = "web",
                    Status = 2,
                    Terms = "Net30",
                    TotalAmount = 200,
                    Transaction = null,
                    Vendor = new VendorOutData
                    {
                        Address1 = "1234 Liberdad St.",
                        Address2 = "Suite 100",
                        BillingData = new BillingData
                        {
                            AccountNumber = "12345XXXX",
                            BankAccountFunction = 0,
                            BankAccountHolderName = "Elena Gomez",
                            BankAccountHolderType = BankAccountHolderType.Business,
                            BankName = "Michigan Savings Bank",
                            Id = 0,
                            RoutingAccount = "072000326",
                            TypeAccount = TypeAccount.Checking,
                        },
                        City = "Detroit",
                        Country = "US",
                        Ein = "XXXXX6789",
                        Email = "elenag@industriesexample.com",
                        InternalReferenceId = 1215,
                        Mcc = "700",
                        Name1 = "Gomez-Radulescu Industries",
                        Name2 = "Elena",
                        Phone = "517-555-0123",
                        State = "MI",
                        VendorId = 8723,
                        VendorNumber = "MI-vendor-2024031926",
                        VendorStatus = 1,
                        Zip = "48201",
                    },
                },
            },
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }
}
