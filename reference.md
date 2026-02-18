# Reference
## Bill
<details><summary><code>client.Bill.<a href="/src/PayabliApi/Bill/BillClient.cs">AddBillAsync</a>(entry, AddBillRequest { ... }) -> WithRawResponseTask&lt;BillResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a bill in an entrypoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bill.AddBillAsync(
    "8cfec329267",
    new AddBillRequest
    {
        Body = new BillOutData
        {
            BillNumber = "ABC-123",
            NetAmount = 3762.87,
            BillDate = new DateOnly(2024, 7, 1),
            DueDate = new DateOnly(2024, 7, 1),
            Comments = "Deposit for materials",
            BillItems = new List<BillItem>()
            {
                new BillItem
                {
                    ItemProductCode = "M-DEPOSIT",
                    ItemProductName = "Materials deposit",
                    ItemDescription = "Deposit for materials",
                    ItemCommodityCode = "010",
                    ItemUnitOfMeasure = "SqFt",
                    ItemCost = 5,
                    ItemQty = 1,
                    ItemMode = 0,
                    ItemCategories = new List<string>() { "deposits" },
                    ItemTotalAmount = 123,
                    ItemTaxAmount = 7,
                    ItemTaxRate = 0.075,
                },
            },
            Mode = 0,
            AccountingField1 = "MyInternalId",
            Vendor = new VendorData { VendorNumber = "1234-A" },
            EndDate = new DateOnly(2024, 7, 1),
            Frequency = Frequency.Monthly,
            Terms = "NET30",
            Status = -99,
            Attachments = new List<FileContent>()
            {
                new FileContent
                {
                    Ftype = FileContentFtype.Pdf,
                    Filename = "my-doc.pdf",
                    Furl = "https://mysite.com/my-doc.pdf",
                },
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `AddBillRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bill.<a href="/src/PayabliApi/Bill/BillClient.cs">DeleteAttachedFromBillAsync</a>(idBill, filename, DeleteAttachedFromBillRequest { ... }) -> WithRawResponseTask&lt;BillResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a file attached to a bill.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bill.DeleteAttachedFromBillAsync(
    "0_Bill.pdf",
    285,
    new DeleteAttachedFromBillRequest()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idBill:** `int` — Payabli ID for the bill. Get this ID by querying `/api/Query/bills/` for the entrypoint or the organization.
    
</dd>
</dl>

<dl>
<dd>

**filename:** `string` 

The filename in Payabli. Filename is `zipName` in response to a
request to `/api/Invoice/{idInvoice}`. Here, the filename is
`0_Bill.pdf`. 

```json
  "DocumentsRef": {
    "zipfile": "inva_269.zip",
    "filelist": [
      {
        "originalName": "Bill.pdf",
        "zipName": "0_Bill.pdf",
        "descriptor": null
      }
    ]
  }
  ```
    
</dd>
</dl>

<dl>
<dd>

**request:** `DeleteAttachedFromBillRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bill.<a href="/src/PayabliApi/Bill/BillClient.cs">DeleteBillAsync</a>(idBill) -> WithRawResponseTask&lt;BillResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a bill by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bill.DeleteBillAsync(285);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idBill:** `int` — Payabli ID for the bill. Get this ID by querying `/api/Query/bills/` for the entrypoint or the organization.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bill.<a href="/src/PayabliApi/Bill/BillClient.cs">EditBillAsync</a>(idBill, BillOutData { ... }) -> WithRawResponseTask&lt;EditBillResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a bill by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bill.EditBillAsync(
    285,
    new BillOutData { NetAmount = 3762.87, BillDate = new DateOnly(2025, 7, 1) }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idBill:** `int` — Payabli ID for the bill. Get this ID by querying `/api/Query/bills/` for the entrypoint or the organization.
    
</dd>
</dl>

<dl>
<dd>

**request:** `BillOutData` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bill.<a href="/src/PayabliApi/Bill/BillClient.cs">GetAttachedFromBillAsync</a>(idBill, filename, GetAttachedFromBillRequest { ... }) -> WithRawResponseTask&lt;FileContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a file attached to a bill, either as a binary file or as a Base64-encoded string.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bill.GetAttachedFromBillAsync(
    "0_Bill.pdf",
    285,
    new GetAttachedFromBillRequest { ReturnObject = true }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idBill:** `int` — Payabli ID for the bill. Get this ID by querying `/api/Query/bills/` for the entrypoint or the organization.
    
</dd>
</dl>

<dl>
<dd>

**filename:** `string` 

The filename in Payabli. Filename is `zipName` in response to a request to `/api/Invoice/{idInvoice}`. Here, the filename is `0_Bill.pdf``. 
"DocumentsRef": {
  "zipfile": "inva_269.zip",
  "filelist": [
    {
      "originalName": "Bill.pdf",
      "zipName": "0_Bill.pdf",
      "descriptor": null
    }
  ]
}
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetAttachedFromBillRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bill.<a href="/src/PayabliApi/Bill/BillClient.cs">GetBillAsync</a>(idBill) -> WithRawResponseTask&lt;GetBillResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a bill by ID from an entrypoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bill.GetBillAsync(285);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idBill:** `int` — Payabli ID for the bill. Get this ID by querying `/api/Query/bills/` for the entrypoint or the organization.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bill.<a href="/src/PayabliApi/Bill/BillClient.cs">ListBillsAsync</a>(entry, ListBillsRequest { ... }) -> WithRawResponseTask&lt;BillQueryResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of bills for an entrypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bill.ListBillsAsync(
    "8cfec329267",
    new ListBillsRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListBillsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bill.<a href="/src/PayabliApi/Bill/BillClient.cs">ListBillsOrgAsync</a>(orgId, ListBillsOrgRequest { ... }) -> WithRawResponseTask&lt;BillQueryResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of bills for an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bill.ListBillsOrgAsync(
    123,
    new ListBillsOrgRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListBillsOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bill.<a href="/src/PayabliApi/Bill/BillClient.cs">ModifyApprovalBillAsync</a>(idBill, IEnumerable&lt;string&gt; { ... }) -> WithRawResponseTask&lt;ModifyApprovalBillResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Modify the list of users the bill is sent to for approval.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bill.ModifyApprovalBillAsync(285, new List<string>() { "string" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idBill:** `int` — Payabli ID for the bill. Get this ID by querying `/api/Query/bills/` for the entrypoint or the organization.
    
</dd>
</dl>

<dl>
<dd>

**request:** `IEnumerable<string>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bill.<a href="/src/PayabliApi/Bill/BillClient.cs">SendToApprovalBillAsync</a>(idBill, SendToApprovalBillRequest { ... }) -> WithRawResponseTask&lt;BillResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Send a bill to a user or list of users to approve.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bill.SendToApprovalBillAsync(
    285,
    new SendToApprovalBillRequest
    {
        IdempotencyKey = "6B29FC40-CA47-1067-B31D-00DD010662DA",
        Body = new List<string>() { "string" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idBill:** `int` — Payabli ID for the bill. Get this ID by querying `/api/Query/bills/` for the entrypoint or the organization.
    
</dd>
</dl>

<dl>
<dd>

**request:** `SendToApprovalBillRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bill.<a href="/src/PayabliApi/Bill/BillClient.cs">SetApprovedBillAsync</a>(idBill, approved, SetApprovedBillRequest { ... }) -> WithRawResponseTask&lt;SetApprovedBillResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Approve or disapprove a bill by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bill.SetApprovedBillAsync("true", 285, new SetApprovedBillRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idBill:** `int` — Payabli ID for the bill. Get this ID by querying `/api/Query/bills/` for the entrypoint or the organization.
    
</dd>
</dl>

<dl>
<dd>

**approved:** `string` — String representing the approved status. Accepted values: 'true' or 'false'.
    
</dd>
</dl>

<dl>
<dd>

**request:** `SetApprovedBillRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Boarding
<details><summary><code>client.Boarding.<a href="/src/PayabliApi/Boarding/BoardingClient.cs">AddApplicationAsync</a>(OneOf&lt;ApplicationDataPayIn, ApplicationDataManaged, ApplicationDataOdp, ApplicationData&gt; { ... }) -> WithRawResponseTask&lt;PayabliApiResponse00Responsedatanonobject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a boarding application in an organization. This endpoint requires an application API token.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Boarding.AddApplicationAsync(
    new ApplicationDataPayIn
    {
        Services = new ApplicationDataPayInServices
        {
            Ach = new ApplicationDataPayInServicesAch(),
            Card = new ApplicationDataPayInServicesCard
            {
                AcceptAmex = true,
                AcceptDiscover = true,
                AcceptMastercard = true,
                AcceptVisa = true,
            },
        },
        AnnualRevenue = 1000,
        AverageBillSize = "500",
        AverageMonthlyBill = "5650",
        Avgmonthly = 1000,
        Baddress = "123 Walnut Street",
        Baddress1 = "Suite 103",
        BankData = new ApplicationDataPayInBankData(),
        Bcity = "New Vegas",
        Bcountry = "US",
        Binperson = 60,
        Binphone = 20,
        Binweb = 20,
        Bstate = "FL",
        Bsummary = "Brick and mortar store that sells office supplies",
        Btype = OwnType.LimitedLiabilityCompany,
        Bzip = "33000",
        Contacts = new List<ApplicationDataPayInContactsItem>()
        {
            new ApplicationDataPayInContactsItem
            {
                ContactEmail = "herman@hermanscoatings.com",
                ContactName = "Herman Martinez",
                ContactPhone = "3055550000",
                ContactTitle = "Owner",
            },
        },
        CreditLimit = "creditLimit",
        DbaName = "Sunshine Gutters",
        Ein = "123456789",
        Faxnumber = "1234567890",
        Highticketamt = 1000,
        LegalName = "Sunshine Services, LLC",
        License = "2222222FFG",
        Licstate = "CA",
        Maddress = "123 Walnut Street",
        Maddress1 = "STE 900",
        Mcc = "7777",
        Mcity = "Johnson City",
        Mcountry = "US",
        Mstate = "TN",
        Mzip = "37615",
        OrgId = 123,
        Ownership = new List<ApplicationDataPayInOwnershipItem>()
        {
            new ApplicationDataPayInOwnershipItem
            {
                Oaddress = "33 North St",
                Ocity = "Any City",
                Ocountry = "US",
                Odriverstate = "CA",
                Ostate = "CA",
                Ownerdob = "01/01/1990",
                Ownerdriver = "CA6677778",
                Owneremail = "test@email.com",
                Ownername = "John Smith",
                Ownerpercent = 100,
                Ownerphone1 = "555888111",
                Ownerphone2 = "555888111",
                Ownerssn = "123456789",
                Ownertitle = "CEO",
                Ozip = "55555",
            },
        },
        Phonenumber = "1234567890",
        ProcessingRegion = "US",
        RecipientEmail = "josephray@example.com",
        RecipientEmailNotification = true,
        Resumable = true,
        Signer = new SignerDataRequest
        {
            Address = "33 North St",
            Address1 = "STE 900",
            City = "Bristol",
            Country = "US",
            Dob = "01/01/1976",
            Email = "test@email.com",
            Name = "John Smith",
            Phone = "555888111",
            Ssn = "123456789",
            State = "TN",
            Zip = "55555",
            PciAttestation = true,
            SignedDocumentReference = "https://example.com/signed-document.pdf",
            AttestationDate = "04/20/2025",
            SignDate = "04/20/2025",
            AdditionalData =
                "{\"deviceId\":\"499585-389fj484-3jcj8hj3\",\"session\":\"fifji4-fiu443-fn4843\",\"timeWithCompany\":\"6 Years\"}",
        },
        Startdate = "01/01/1990",
        TaxFillName = "Sunshine LLC",
        TemplateId = 22,
        Ticketamt = 1000,
        Website = "www.example.com",
        WhenCharged = Whencharged.WhenServiceProvided,
        WhenDelivered = Whendelivered.Over30Days,
        WhenProvided = Whenprovided.ThirtyDaysOrLess,
        WhenRefunded = Whenrefunded.ThirtyDaysOrLess,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `OneOf<ApplicationDataPayIn, ApplicationDataManaged, ApplicationDataOdp, ApplicationData>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Boarding.<a href="/src/PayabliApi/Boarding/BoardingClient.cs">DeleteApplicationAsync</a>(appId) -> WithRawResponseTask&lt;PayabliApiResponse00Responsedatanonobject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a boarding application by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Boarding.DeleteApplicationAsync(352);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**appId:** `int` — Boarding application ID. 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Boarding.<a href="/src/PayabliApi/Boarding/BoardingClient.cs">GetApplicationAsync</a>(appId) -> WithRawResponseTask&lt;ApplicationDetailsRecord&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves the details for a boarding application by ID. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Boarding.GetApplicationAsync(352);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**appId:** `int` — Boarding application ID.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Boarding.<a href="/src/PayabliApi/Boarding/BoardingClient.cs">GetApplicationByAuthAsync</a>(xId, RequestAppByAuth { ... }) -> WithRawResponseTask&lt;ApplicationQueryRecord&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Gets a boarding application by authentication information. This endpoint requires an `application` API token. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Boarding.GetApplicationByAuthAsync(
    "17E",
    new RequestAppByAuth { Email = "admin@email.com", ReferenceId = "n6UCd1f1ygG7" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**xId:** `string` — The application ID in Hex format. Find this at the end of the boarding link URL returned in a call to api/Boarding/applink/{appId}/{mail2}. For example in:  `https://boarding-sandbox.payabli.com/boarding/externalapp/load/17E`, the xId is `17E`. 
    
</dd>
</dl>

<dl>
<dd>

**request:** `RequestAppByAuth` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Boarding.<a href="/src/PayabliApi/Boarding/BoardingClient.cs">GetByIdLinkApplicationAsync</a>(boardingLinkId) -> WithRawResponseTask&lt;BoardingLinkQueryRecord&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves details for a boarding link, by ID. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Boarding.GetByIdLinkApplicationAsync(91);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**boardingLinkId:** `int` — The boarding link ID. You can find this at the end of the boarding link reference name. For example `https://boarding.payabli.com/boarding/app/myorgaccountname-00091`. The ID is `91`.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Boarding.<a href="/src/PayabliApi/Boarding/BoardingClient.cs">GetByTemplateIdLinkApplicationAsync</a>(templateId) -> WithRawResponseTask&lt;BoardingLinkQueryRecord&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get details for a boarding link using the boarding template ID. This endpoint requires an application API token.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Boarding.GetByTemplateIdLinkApplicationAsync(80);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**templateId:** `double` — The boarding template ID. You can find this at the end of the boarding template URL in PartnerHub. Example: `https://partner-sandbox.payabli.com/myorganization/boarding/edittemplate/80`. Here, the template ID is `80`.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Boarding.<a href="/src/PayabliApi/Boarding/BoardingClient.cs">GetExternalApplicationAsync</a>(appId, mail2, GetExternalApplicationRequest { ... }) -> WithRawResponseTask&lt;PayabliApiResponse00&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a link and the verification code used to log into an existing boarding application. You can also use this endpoint to send a link and referenceId for an existing boarding application to an email address. The recipient can use the referenceId and email address to access and edit the application.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Boarding.GetExternalApplicationAsync(
    352,
    "mail2",
    new GetExternalApplicationRequest()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**appId:** `int` — Boarding application ID. 
    
</dd>
</dl>

<dl>
<dd>

**mail2:** `string` — Email address used to access the application. If `sendEmail` parameter is true, a link to the application is sent to this email address.
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetExternalApplicationRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Boarding.<a href="/src/PayabliApi/Boarding/BoardingClient.cs">GetLinkApplicationAsync</a>(boardingLinkReference) -> WithRawResponseTask&lt;BoardingLinkQueryRecord&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves the details for a boarding link, by reference name. This endpoint requires an application API token.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Boarding.GetLinkApplicationAsync("myorgaccountname-00091");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**boardingLinkReference:** `string` — The boarding link reference name. You can find this at the end of the boarding link URL. For example `https://boarding.payabli.com/boarding/app/myorgaccountname-00091`
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Boarding.<a href="/src/PayabliApi/Boarding/BoardingClient.cs">ListApplicationsAsync</a>(orgId, ListApplicationsRequest { ... }) -> WithRawResponseTask&lt;QueryBoardingAppsListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a list of boarding applications for an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Boarding.ListApplicationsAsync(
    123,
    new ListApplicationsRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListApplicationsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Boarding.<a href="/src/PayabliApi/Boarding/BoardingClient.cs">ListBoardingLinksAsync</a>(orgId, ListBoardingLinksRequest { ... }) -> WithRawResponseTask&lt;QueryBoardingLinksResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Return a list of boarding links for an organization. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Boarding.ListBoardingLinksAsync(
    123,
    new ListBoardingLinksRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListBoardingLinksRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Boarding.<a href="/src/PayabliApi/Boarding/BoardingClient.cs">UpdateApplicationAsync</a>(appId, ApplicationData { ... }) -> WithRawResponseTask&lt;PayabliApiResponse00Responsedatanonobject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a boarding application by ID. This endpoint requires an application API token.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Boarding.UpdateApplicationAsync(352, new ApplicationData());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**appId:** `int` — Boarding application ID. 
    
</dd>
</dl>

<dl>
<dd>

**request:** `ApplicationData` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## ChargeBacks
<details><summary><code>client.ChargeBacks.<a href="/src/PayabliApi/ChargeBacks/ChargeBacksClient.cs">AddResponseAsync</a>(id, ResponseChargeBack { ... }) -> WithRawResponseTask&lt;AddResponseResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Add a response to a chargeback or ACH return.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ChargeBacks.AddResponseAsync(
    1000000,
    new ResponseChargeBack { IdempotencyKey = "6B29FC40-CA47-1067-B31D-00DD010662DA" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `long` — ID of the chargeback or return record.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ResponseChargeBack` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ChargeBacks.<a href="/src/PayabliApi/ChargeBacks/ChargeBacksClient.cs">GetChargebackAsync</a>(id) -> WithRawResponseTask&lt;ChargebackQueryRecords&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a chargeback record and its details.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ChargeBacks.GetChargebackAsync(1000000);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `long` — ID of the chargeback or return record. This is returned as `chargebackId` in the [RecievedChargeback](/developers/developer-guides/webhook-payloads#receivedChargeback) and [ReceivedAchReturn](/developers/developer-guides/webhook-payloads#receivedachreturn) webhook notifications.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ChargeBacks.<a href="/src/PayabliApi/ChargeBacks/ChargeBacksClient.cs">GetChargebackAttachmentAsync</a>(id, fileName) -> WithRawResponseTask&lt;string&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a chargeback attachment file by its file name.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ChargeBacks.GetChargebackAttachmentAsync(1000000, "fileName");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `long` — The ID of chargeback or return record.
    
</dd>
</dl>

<dl>
<dd>

**fileName:** `string` — The chargeback attachment's file name.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## CheckCapture
<details><summary><code>client.CheckCapture.<a href="/src/PayabliApi/CheckCapture/CheckCaptureClient.cs">CheckProcessingAsync</a>(CheckCaptureRequestBody { ... }) -> WithRawResponseTask&lt;CheckCaptureResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Captures a check for Remote Deposit Capture (RDC) using the provided check images and details. This endpoint handles the OCR extraction of check data including MICR, routing number, account number, and amount. See the [RDC guide](/developers/developer-guides/pay-in-rdc) for more details.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CheckCapture.CheckProcessingAsync(
    new CheckCaptureRequestBody
    {
        EntryPoint = "47abcfea12",
        FrontImage = "/9j/4AAQSkZJRgABAQEASABIAAD...",
        RearImage = "/9j/4AAQSkZJRgABAQEASABIAAD...",
        CheckAmount = 12550,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CheckCaptureRequestBody` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Cloud
<details><summary><code>client.Cloud.<a href="/src/PayabliApi/Cloud/CloudClient.cs">AddDeviceAsync</a>(entry, DeviceEntry { ... }) -> WithRawResponseTask&lt;AddDeviceResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Register a cloud device to an entrypoint. See [Devices Quickstart](/developers/developer-guides/devices-quickstart#devices-quickstart) for a complete guide.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Cloud.AddDeviceAsync(
    "8cfec329267",
    new DeviceEntry { RegistrationCode = "YS7DS5", Description = "Front Desk POS" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `DeviceEntry` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Cloud.<a href="/src/PayabliApi/Cloud/CloudClient.cs">HistoryDeviceAsync</a>(entry, deviceId) -> WithRawResponseTask&lt;CloudQueryApiResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the registration history for a device. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Cloud.HistoryDeviceAsync("WXGDWB", "8cfec329267");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**deviceId:** `string` — ID of the cloud device. 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Cloud.<a href="/src/PayabliApi/Cloud/CloudClient.cs">ListDeviceAsync</a>(entry, ListDeviceRequest { ... }) -> WithRawResponseTask&lt;CloudQueryApiResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get a list of cloud devices registered to an entrypoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Cloud.ListDeviceAsync("8cfec329267", new ListDeviceRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListDeviceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Cloud.<a href="/src/PayabliApi/Cloud/CloudClient.cs">RemoveDeviceAsync</a>(entry, deviceId) -> WithRawResponseTask&lt;RemoveDeviceResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove a cloud device from an entrypoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Cloud.RemoveDeviceAsync("6c361c7d-674c-44cc-b790-382b75d1xxx", "8cfec329267");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**deviceId:** `string` — ID of the cloud device. 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Customer
<details><summary><code>client.Customer.<a href="/src/PayabliApi/Customer/CustomerClient.cs">AddCustomerAsync</a>(entry, AddCustomerRequest { ... }) -> WithRawResponseTask&lt;PayabliApiResponseCustomerQuery&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a customer in an entrypoint. An identifier is required to create customer records. Change your identifier settings in Settings > Custom Fields in PartnerHub. 
If you don't include an identifier, the record is rejected.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Customer.AddCustomerAsync(
    "8cfec329267",
    new AddCustomerRequest
    {
        Body = new CustomerData
        {
            CustomerNumber = "12356ACB",
            Firstname = "Irene",
            Lastname = "Canizales",
            Address1 = "123 Bishop's Trail",
            City = "Mountain City",
            State = "TN",
            Zip = "37612",
            Country = "US",
            Email = "irene@canizalesconcrete.com",
            IdentifierFields = new List<string>() { "email" },
            TimeZone = -5,
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `AddCustomerRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customer.<a href="/src/PayabliApi/Customer/CustomerClient.cs">DeleteCustomerAsync</a>(customerId) -> WithRawResponseTask&lt;PayabliApiResponse00Responsedatanonobject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a customer record.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Customer.DeleteCustomerAsync(998);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**customerId:** `int` — Payabli-generated customer ID. Maps to "Customer ID" column in PartnerHub. 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customer.<a href="/src/PayabliApi/Customer/CustomerClient.cs">GetCustomerAsync</a>(customerId) -> WithRawResponseTask&lt;CustomerQueryRecords&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a customer's record and details.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Customer.GetCustomerAsync(998);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**customerId:** `int` — Payabli-generated customer ID. Maps to "Customer ID" column in PartnerHub. 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customer.<a href="/src/PayabliApi/Customer/CustomerClient.cs">LinkCustomerTransactionAsync</a>(customerId, transId) -> WithRawResponseTask&lt;PayabliApiResponse00Responsedatanonobject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Links a customer to a transaction by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Customer.LinkCustomerTransactionAsync(998, "45-as456777hhhhhhhhhh77777777-324");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**customerId:** `int` — Payabli-generated customer ID. Maps to "Customer ID" column in PartnerHub. 
    
</dd>
</dl>

<dl>
<dd>

**transId:** `string` — ReferenceId for the transaction (PaymentId).
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customer.<a href="/src/PayabliApi/Customer/CustomerClient.cs">RequestConsentAsync</a>(customerId) -> WithRawResponseTask&lt;PayabliApiResponse00Responsedatanonobject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Sends the consent opt-in email to the customer email address in the customer record.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Customer.RequestConsentAsync(998);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**customerId:** `int` — Payabli-generated customer ID. Maps to "Customer ID" column in PartnerHub. 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customer.<a href="/src/PayabliApi/Customer/CustomerClient.cs">UpdateCustomerAsync</a>(customerId, CustomerData { ... }) -> WithRawResponseTask&lt;PayabliApiResponse00Responsedatanonobject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update a customer record. Include only the fields you want to change.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Customer.UpdateCustomerAsync(
    998,
    new CustomerData
    {
        Firstname = "Irene",
        Lastname = "Canizales",
        Address1 = "145 Bishop's Trail",
        City = "Mountain City",
        State = "TN",
        Zip = "37612",
        Country = "US",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**customerId:** `int` — Payabli-generated customer ID. Maps to "Customer ID" column in PartnerHub. 
    
</dd>
</dl>

<dl>
<dd>

**request:** `CustomerData` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Export
<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportApplicationsAsync</a>(format, orgId, ExportApplicationsRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of boarding applications for an organization. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportApplicationsAsync(
    ExportFormat1.Csv,
    123,
    new ExportApplicationsRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportApplicationsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportBatchDetailsAsync</a>(format, entry, ExportBatchDetailsRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint is deprecated. Export batch details for a paypoint. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportBatchDetailsAsync(
    "8cfec329267",
    ExportFormat1.Csv,
    new ExportBatchDetailsRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportBatchDetailsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportBatchDetailsOrgAsync</a>(format, orgId, ExportBatchDetailsOrgRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint is deprecated. Export batch details for an organization. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportBatchDetailsOrgAsync(
    ExportFormat1.Csv,
    123,
    new ExportBatchDetailsOrgRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportBatchDetailsOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportBatchesAsync</a>(format, entry, ExportBatchesRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of batches for an entrypoint. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportBatchesAsync(
    "8cfec329267",
    ExportFormat1.Csv,
    new ExportBatchesRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportBatchesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportBatchesOrgAsync</a>(format, orgId, ExportBatchesOrgRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of batches for an organization. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportBatchesOrgAsync(
    ExportFormat1.Csv,
    123,
    new ExportBatchesOrgRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportBatchesOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportBatchesOutAsync</a>(format, entry, ExportBatchesOutRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of money out batches for a paypoint. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportBatchesOutAsync(
    "8cfec329267",
    ExportFormat1.Csv,
    new ExportBatchesOutRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportBatchesOutRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportBatchesOutOrgAsync</a>(format, orgId, ExportBatchesOutOrgRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of money out batches for an organization. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportBatchesOutOrgAsync(
    ExportFormat1.Csv,
    123,
    new ExportBatchesOutOrgRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportBatchesOutOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportBillsAsync</a>(format, entry, ExportBillsRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of bills for an entrypoint. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportBillsAsync(
    "8cfec329267",
    ExportFormat1.Csv,
    new ExportBillsRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportBillsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportBillsOrgAsync</a>(format, orgId, ExportBillsOrgRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of bills for an organization. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportBillsOrgAsync(
    ExportFormat1.Csv,
    123,
    new ExportBillsOrgRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportBillsOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportChargebacksAsync</a>(format, entry, ExportChargebacksRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of chargebacks and ACH returns for an entrypoint. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportChargebacksAsync(
    "8cfec329267",
    ExportFormat1.Csv,
    new ExportChargebacksRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportChargebacksRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportChargebacksOrgAsync</a>(format, orgId, ExportChargebacksOrgRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of chargebacks and ACH returns for an organization. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportChargebacksOrgAsync(
    ExportFormat1.Csv,
    123,
    new ExportChargebacksOrgRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportChargebacksOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportCustomersAsync</a>(format, entry, ExportCustomersRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of customers for an entrypoint. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportCustomersAsync(
    "8cfec329267",
    ExportFormat1.Csv,
    new ExportCustomersRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportCustomersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportCustomersOrgAsync</a>(format, orgId, ExportCustomersOrgRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Exports a list of customers for an organization. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportCustomersOrgAsync(
    ExportFormat1.Csv,
    123,
    new ExportCustomersOrgRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportCustomersOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportInvoicesAsync</a>(format, entry, ExportInvoicesRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export list of invoices for an entrypoint. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportInvoicesAsync(
    "8cfec329267",
    ExportFormat1.Csv,
    new ExportInvoicesRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportInvoicesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportInvoicesOrgAsync</a>(format, orgId, ExportInvoicesOrgRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of invoices for an organization. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportInvoicesOrgAsync(
    ExportFormat1.Csv,
    123,
    new ExportInvoicesOrgRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportInvoicesOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportOrganizationsAsync</a>(format, orgId, ExportOrganizationsRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of child organizations (suborganizations) for a parent organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportOrganizationsAsync(
    ExportFormat1.Csv,
    123,
    new ExportOrganizationsRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportOrganizationsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportPayoutAsync</a>(format, entry, ExportPayoutRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of payouts and their statuses for an entrypoint. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportPayoutAsync(
    "8cfec329267",
    ExportFormat1.Csv,
    new ExportPayoutRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportPayoutRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportPayoutOrgAsync</a>(format, orgId, ExportPayoutOrgRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of payouts and their details for an organization. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportPayoutOrgAsync(
    ExportFormat1.Csv,
    123,
    new ExportPayoutOrgRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportPayoutOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportPaypointsAsync</a>(format, orgId, ExportPaypointsRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of paypoints in an organization. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportPaypointsAsync(
    ExportFormat1.Csv,
    123,
    new ExportPaypointsRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportPaypointsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportSettlementsAsync</a>(format, entry, ExportSettlementsRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of settled transactions for an entrypoint. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportSettlementsAsync(
    "8cfec329267",
    ExportFormat1.Csv,
    new ExportSettlementsRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportSettlementsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportSettlementsOrgAsync</a>(format, orgId, ExportSettlementsOrgRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of settled transactions for an organization. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportSettlementsOrgAsync(
    ExportFormat1.Csv,
    123,
    new ExportSettlementsOrgRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportSettlementsOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportSubscriptionsAsync</a>(format, entry, ExportSubscriptionsRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of subscriptions for an entrypoint. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportSubscriptionsAsync(
    "8cfec329267",
    ExportFormat1.Csv,
    new ExportSubscriptionsRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportSubscriptionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportSubscriptionsOrgAsync</a>(format, orgId, ExportSubscriptionsOrgRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of subscriptions for an organization. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportSubscriptionsOrgAsync(
    ExportFormat1.Csv,
    123,
    new ExportSubscriptionsOrgRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportSubscriptionsOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportTransactionsAsync</a>(format, entry, ExportTransactionsRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of transactions for an entrypoint in a file in XLXS or CSV format. Use filters to limit results. If you don't specify a date range in the request, the last two months of data are returned.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportTransactionsAsync(
    "8cfec329267",
    ExportFormat1.Csv,
    new ExportTransactionsRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportTransactionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportTransactionsOrgAsync</a>(format, orgId, ExportTransactionsOrgRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of transactions for an org in a file in XLSX or CSV format. Use filters to limit results. If you don't specify a date range in the request, the last two months of data are returned.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportTransactionsOrgAsync(
    ExportFormat1.Csv,
    123,
    new ExportTransactionsOrgRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportTransactionsOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportTransferDetailsAsync</a>(format, entry, transferId, ExportTransferDetailsRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of transfer details for an entrypoint. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportTransferDetailsAsync(
    "8cfec329267",
    ExportFormat1.Csv,
    1000000,
    new ExportTransferDetailsRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**transferId:** `long` — Transfer identifier.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportTransferDetailsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportTransfersAsync</a>(entry, ExportTransfersRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get a list of transfers for an entrypoint. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportTransfersAsync(
    "8cfec329267",
    new ExportTransfersRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportTransfersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportVendorsAsync</a>(format, entry, ExportVendorsRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of vendors for an entrypoint. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportVendorsAsync(
    "8cfec329267",
    ExportFormat1.Csv,
    new ExportVendorsRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportVendorsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Export.<a href="/src/PayabliApi/Export/ExportClient.cs">ExportVendorsOrgAsync</a>(format, orgId, ExportVendorsOrgRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a list of vendors for an organization. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Export.ExportVendorsOrgAsync(
    ExportFormat1.Csv,
    123,
    new ExportVendorsOrgRequest
    {
        ColumnsExport = "BatchDate:Batch_Date,PaypointName:Legal_name",
        FromRecord = 251,
        LimitRecord = 1000,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**format:** `ExportFormat1` — Format for the export, either XLSX or CSV. 
    
</dd>
</dl>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ExportVendorsOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## HostedPaymentPages
<details><summary><code>client.HostedPaymentPages.<a href="/src/PayabliApi/HostedPaymentPages/HostedPaymentPagesClient.cs">LoadPageAsync</a>(entry, subdomain) -> WithRawResponseTask&lt;PayabliPages&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Loads all of a payment page's details including `pageIdentifier` and `validationCode`. This endpoint requires an `application` API token.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.HostedPaymentPages.LoadPageAsync("8cfec329267", "pay-your-fees-1");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**subdomain:** `string` — Payment page identifier. The subdomain value is the last part of the payment page URL. For example, in`https://paypages-sandbox.payabli.com/513823dc10/pay-your-fees-1`, the subdomain is `pay-your-fees-1`.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.HostedPaymentPages.<a href="/src/PayabliApi/HostedPaymentPages/HostedPaymentPagesClient.cs">NewPageAsync</a>(entry, NewPageRequest { ... }) -> WithRawResponseTask&lt;PayabliApiResponse00Responsedatanonobject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>


Creates a new payment page for a paypoint. 
Note: this operation doesn't create a new paypoint, just a payment page for an existing paypoint. Paypoints are created by the Payabli team when a boarding application is approved.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.HostedPaymentPages.NewPageAsync(
    "8cfec329267",
    new NewPageRequest
    {
        IdempotencyKey = "6B29FC40-CA47-1067-B31D-00DD010662DA",
        Body = new PayabliPages(),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `NewPageRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.HostedPaymentPages.<a href="/src/PayabliApi/HostedPaymentPages/HostedPaymentPagesClient.cs">SavePageAsync</a>(entry, subdomain, PayabliPages { ... }) -> WithRawResponseTask&lt;PayabliApiResponse00Responsedatanonobject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a payment page in a paypoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.HostedPaymentPages.SavePageAsync("8cfec329267", "pay-your-fees-1", new PayabliPages());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**subdomain:** `string` — Payment page identifier. The subdomain value is the last part of the payment page URL. For example, in`https://paypages-sandbox.payabli.com/513823dc10/pay-your-fees-1`, the subdomain is `pay-your-fees-1`.
    
</dd>
</dl>

<dl>
<dd>

**request:** `PayabliPages` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Import
<details><summary><code>client.Import.<a href="/src/PayabliApi/Import/ImportClient.cs">ImportBillsAsync</a>(entry, ImportBillsRequest { ... }) -> WithRawResponseTask&lt;PayabliApiResponseImport&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Import a list of bills from a CSV file. See the [Import Guide](/developers/developer-guides/bills-add#import-bills) for more help and an example file.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Import.ImportBillsAsync("8cfec329267", new ImportBillsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `ImportBillsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Import.<a href="/src/PayabliApi/Import/ImportClient.cs">ImportCustomerAsync</a>(entry, ImportCustomerRequest { ... }) -> WithRawResponseTask&lt;PayabliApiResponseImport&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Import a list of customers from a CSV file. See the [Import Guide](/developers/developer-guides/entities-customers#import-customers) for more help and example files.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Import.ImportCustomerAsync("8cfec329267", new ImportCustomerRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `ImportCustomerRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Import.<a href="/src/PayabliApi/Import/ImportClient.cs">ImportVendorAsync</a>(entry, ImportVendorRequest { ... }) -> WithRawResponseTask&lt;PayabliApiResponseImport&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Import a list of vendors from a CSV file. See the [Import Guide](/developers/developer-guides/entities-vendors#import-vendors) for more help and example files.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Import.ImportVendorAsync("8cfec329267", new ImportVendorRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `ImportVendorRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Invoice
<details><summary><code>client.Invoice.<a href="/src/PayabliApi/Invoice/InvoiceClient.cs">AddInvoiceAsync</a>(entry, AddInvoiceRequest { ... }) -> WithRawResponseTask&lt;InvoiceResponseWithoutData&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates an invoice in an entrypoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Invoice.AddInvoiceAsync(
    "8cfec329267",
    new AddInvoiceRequest
    {
        Body = new InvoiceDataRequest
        {
            CustomerData = new PayorDataRequest
            {
                FirstName = "Tamara",
                LastName = "Bagratoni",
                CustomerNumber = "3",
            },
            InvoiceData = new BillData
            {
                Items = new List<BillItem>()
                {
                    new BillItem
                    {
                        ItemProductName = "Adventure Consult",
                        ItemDescription = "Consultation for Georgian tours",
                        ItemCost = 100,
                        ItemQty = 1,
                        ItemMode = 1,
                        ItemTotalAmount = 1,
                    },
                    new BillItem
                    {
                        ItemProductName = "Deposit ",
                        ItemDescription = "Deposit for trip planning",
                        ItemCost = 882.37,
                        ItemQty = 1,
                        ItemTotalAmount = 1,
                    },
                },
                InvoiceDate = new DateOnly(2025, 10, 19),
                InvoiceType = 0,
                InvoiceStatus = 1,
                Frequency = Frequency.OneTime,
                InvoiceAmount = 982.37,
                Discount = 10,
                InvoiceNumber = "INV-3",
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `AddInvoiceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Invoice.<a href="/src/PayabliApi/Invoice/InvoiceClient.cs">DeleteAttachedFromInvoiceAsync</a>(idInvoice, filename) -> WithRawResponseTask&lt;InvoiceResponseWithoutData&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes an invoice that's attached to a file.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Invoice.DeleteAttachedFromInvoiceAsync("0_Bill.pdf", 23548884);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idInvoice:** `int` — Invoice ID
    
</dd>
</dl>

<dl>
<dd>

**filename:** `string` 

The filename in Payabli. Filename is `zipName` in response to a request to `/api/Invoice/{idInvoice}`. Here, the filename is `0_Bill.pdf``. 
"DocumentsRef": {
  "zipfile": "inva_269.zip",
  "filelist": [
    {
      "originalName": "Bill.pdf",
      "zipName": "0_Bill.pdf",
      "descriptor": null
    }
  ]
}
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Invoice.<a href="/src/PayabliApi/Invoice/InvoiceClient.cs">DeleteInvoiceAsync</a>(idInvoice) -> WithRawResponseTask&lt;InvoiceResponseWithoutData&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a single invoice from an entrypoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Invoice.DeleteInvoiceAsync(23548884);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idInvoice:** `int` — Invoice ID
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Invoice.<a href="/src/PayabliApi/Invoice/InvoiceClient.cs">EditInvoiceAsync</a>(idInvoice, EditInvoiceRequest { ... }) -> WithRawResponseTask&lt;InvoiceResponseWithoutData&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates details for a single invoice in an entrypoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Invoice.EditInvoiceAsync(
    332,
    new EditInvoiceRequest
    {
        Body = new InvoiceDataRequest
        {
            InvoiceData = new BillData
            {
                Items = new List<BillItem>()
                {
                    new BillItem
                    {
                        ItemProductName = "Deposit",
                        ItemDescription = "Deposit for trip planning",
                        ItemCost = 882.37,
                        ItemQty = 1,
                    },
                },
                InvoiceDate = new DateOnly(2025, 10, 19),
                InvoiceAmount = 982.37,
                InvoiceNumber = "INV-6",
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idInvoice:** `int` — Invoice ID
    
</dd>
</dl>

<dl>
<dd>

**request:** `EditInvoiceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Invoice.<a href="/src/PayabliApi/Invoice/InvoiceClient.cs">GetAttachedFileFromInvoiceAsync</a>(idInvoice, filename, GetAttachedFileFromInvoiceRequest { ... }) -> WithRawResponseTask&lt;FileContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a file attached to an invoice.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Invoice.GetAttachedFileFromInvoiceAsync(
    1,
    "filename",
    new GetAttachedFileFromInvoiceRequest()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idInvoice:** `int` — Invoice ID
    
</dd>
</dl>

<dl>
<dd>

**filename:** `string` 

The filename in Payabli. Filename is `zipName` in the response to a request to `/api/Invoice/{idInvoice}`. Here, the filename is `0_Bill.pdf``. 
```
  "DocumentsRef": {
    "zipfile": "inva_269.zip",
    "filelist": [
      {
        "originalName": "Bill.pdf",
        "zipName": "0_Bill.pdf",
        "descriptor": null
      }
    ]
  }
  ```
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetAttachedFileFromInvoiceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Invoice.<a href="/src/PayabliApi/Invoice/InvoiceClient.cs">GetInvoiceAsync</a>(idInvoice) -> WithRawResponseTask&lt;GetInvoiceRecord&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a single invoice by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Invoice.GetInvoiceAsync(23548884);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idInvoice:** `int` — Invoice ID
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Invoice.<a href="/src/PayabliApi/Invoice/InvoiceClient.cs">GetInvoiceNumberAsync</a>(entry) -> WithRawResponseTask&lt;InvoiceNumberResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves the next available invoice number for a paypoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Invoice.GetInvoiceNumberAsync("8cfec329267");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Invoice.<a href="/src/PayabliApi/Invoice/InvoiceClient.cs">ListInvoicesAsync</a>(entry, ListInvoicesRequest { ... }) -> WithRawResponseTask&lt;QueryInvoiceResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a list of invoices for an entrypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Invoice.ListInvoicesAsync(
    "8cfec329267",
    new ListInvoicesRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListInvoicesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Invoice.<a href="/src/PayabliApi/Invoice/InvoiceClient.cs">ListInvoicesOrgAsync</a>(orgId, ListInvoicesOrgRequest { ... }) -> WithRawResponseTask&lt;QueryInvoiceResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a list of invoices for an org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Invoice.ListInvoicesOrgAsync(
    123,
    new ListInvoicesOrgRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListInvoicesOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Invoice.<a href="/src/PayabliApi/Invoice/InvoiceClient.cs">SendInvoiceAsync</a>(idInvoice, SendInvoiceRequest { ... }) -> WithRawResponseTask&lt;SendInvoiceResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Sends an invoice from an entrypoint via email.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Invoice.SendInvoiceAsync(
    23548884,
    new SendInvoiceRequest { Attachfile = true, Mail2 = "tamara@example.com" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idInvoice:** `int` — Invoice ID
    
</dd>
</dl>

<dl>
<dd>

**request:** `SendInvoiceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Invoice.<a href="/src/PayabliApi/Invoice/InvoiceClient.cs">GetInvoicePdfAsync</a>(idInvoice) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export a single invoice in PDF format.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Invoice.GetInvoicePdfAsync(23548884);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idInvoice:** `int` — Invoice ID
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## LineItem
<details><summary><code>client.LineItem.<a href="/src/PayabliApi/LineItem/LineItemClient.cs">AddItemAsync</a>(entry, AddItemRequest { ... }) -> WithRawResponseTask&lt;PayabliApiResponse6&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Adds products and services to an entrypoint's catalog. These are used as line items for invoicing and transactions. In the response, "responseData" displays the item's code.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.LineItem.AddItemAsync(
    "47cae3d74",
    new AddItemRequest
    {
        Body = new LineItem
        {
            ItemProductCode = "M-DEPOSIT",
            ItemProductName = "Materials deposit",
            ItemDescription = "Deposit for materials",
            ItemCommodityCode = "010",
            ItemUnitOfMeasure = "SqFt",
            ItemCost = 12.45,
            ItemQty = 1,
            ItemMode = 0,
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `AddItemRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.LineItem.<a href="/src/PayabliApi/LineItem/LineItemClient.cs">DeleteItemAsync</a>(lineItemId) -> WithRawResponseTask&lt;DeleteItemResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes an item.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.LineItem.DeleteItemAsync(700);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**lineItemId:** `int` — ID for the line item (also known as a product, service, or item).
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.LineItem.<a href="/src/PayabliApi/LineItem/LineItemClient.cs">GetItemAsync</a>(lineItemId) -> WithRawResponseTask&lt;LineItemQueryRecord&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Gets an item by ID. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.LineItem.GetItemAsync(700);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**lineItemId:** `int` — ID for the line item (also known as a product, service, or item).
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.LineItem.<a href="/src/PayabliApi/LineItem/LineItemClient.cs">ListLineItemsAsync</a>(entry, ListLineItemsRequest { ... }) -> WithRawResponseTask&lt;QueryResponseItems&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a list of line items and their details from an entrypoint. Line items are also known as items, products, and services. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.LineItem.ListLineItemsAsync(
    "8cfec329267",
    new ListLineItemsRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListLineItemsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.LineItem.<a href="/src/PayabliApi/LineItem/LineItemClient.cs">UpdateItemAsync</a>(lineItemId, LineItem { ... }) -> WithRawResponseTask&lt;PayabliApiResponse6&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates an item.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.LineItem.UpdateItemAsync(700, new LineItem { ItemCost = 12.45, ItemQty = 1 });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**lineItemId:** `int` — ID for the line item (also known as a product, service, or item).
    
</dd>
</dl>

<dl>
<dd>

**request:** `LineItem` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## MoneyIn
<details><summary><code>client.MoneyIn.<a href="/src/PayabliApi/MoneyIn/MoneyInClient.cs">AuthorizeAsync</a>(RequestPaymentAuthorize { ... }) -> WithRawResponseTask&lt;AuthResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Authorize a card transaction. This returns an authorization code and reserves funds for the merchant. Authorized transactions aren't flagged for settlement until [captured](/developers/api-reference/moneyin/capture-an-authorized-transaction).
Only card transactions can be authorized. This endpoint can't be used for ACH transactions.
<Tip>
  Consider migrating to the [v2 Authorize endpoint](/developers/api-reference/moneyinV2/authorize-a-transaction) to take advantage of unified response codes and improved response consistency.
</Tip>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyIn.AuthorizeAsync(
    new RequestPaymentAuthorize
    {
        Body = new TransRequestBody
        {
            CustomerData = new PayorDataRequest { CustomerId = 4440 },
            EntryPoint = "f743aed24a",
            Ipaddress = "255.255.255.255",
            PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
            PaymentMethod = new PayMethodCredit
            {
                Cardcvv = "999",
                Cardexp = "02/27",
                CardHolder = "John Cassian",
                Cardnumber = "4111111111111111",
                Cardzip = "12345",
                Initiator = "payor",
                Method = "card",
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RequestPaymentAuthorize` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyIn.<a href="/src/PayabliApi/MoneyIn/MoneyInClient.cs">CaptureAsync</a>(transId, amount) -> WithRawResponseTask&lt;CaptureResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

<Warning>
  This endpoint is deprecated and will be sunset on November 24, 2025. Migrate to [POST `/capture/{transId}`](/developers/api-reference/moneyin/capture-an-authorized-transaction)`.
</Warning>
  
  Capture an [authorized
transaction](/developers/api-reference/moneyin/authorize-a-transaction) to complete the transaction and move funds from the customer to merchant account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyIn.CaptureAsync("10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13", 0);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**transId:** `string` — ReferenceId for the transaction (PaymentId).
    
</dd>
</dl>

<dl>
<dd>

**amount:** `double` — Amount to be captured. The amount can't be greater the original total amount of the transaction. `0` captures the total amount authorized in the transaction. Partial captures aren't supported.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyIn.<a href="/src/PayabliApi/MoneyIn/MoneyInClient.cs">CaptureAuthAsync</a>(transId, CaptureRequest { ... }) -> WithRawResponseTask&lt;CaptureResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Capture an [authorized transaction](/developers/api-reference/moneyin/authorize-a-transaction) to complete the transaction and move funds from the customer to merchant account. 

You can use this endpoint to capture both full and partial amounts of the original authorized transaction. See [Capture an authorized transaction](/developers/developer-guides/pay-in-auth-and-capture) for more information about this endpoint.

<Tip>
Consider migrating to the [v2 Capture endpoint](/developers/api-reference/moneyinV2/capture-an-authorized-transaction) to take advantage of unified response codes and improved response consistency.
</Tip>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyIn.CaptureAuthAsync(
    "10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13",
    new CaptureRequest
    {
        PaymentDetails = new CapturePaymentDetails { TotalAmount = 105, ServiceFee = 5 },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**transId:** `string` — ReferenceId for the transaction (PaymentId).
    
</dd>
</dl>

<dl>
<dd>

**request:** `CaptureRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyIn.<a href="/src/PayabliApi/MoneyIn/MoneyInClient.cs">CreditAsync</a>(RequestCredit { ... }) -> WithRawResponseTask&lt;PayabliApiResponse0&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Make a temporary microdeposit in a customer account to verify the customer's ownership and access to the target account. Reverse the microdeposit with `reverseCredit`.

This feature must be enabled by Payabli on a per-merchant basis. Contact support for help. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyIn.CreditAsync(
    new RequestCredit
    {
        IdempotencyKey = "6B29FC40-CA47-1067-B31D-00DD010662DA",
        CustomerData = new PayorDataRequest
        {
            BillingAddress1 = "5127 Linkwood ave",
            CustomerNumber = "100",
        },
        Entrypoint = "my-entrypoint",
        PaymentDetails = new PaymentDetailCredit { ServiceFee = 0, TotalAmount = 1 },
        PaymentMethod = new RequestCreditPaymentMethod
        {
            AchAccount = "88354454",
            AchAccountType = Achaccounttype.Checking,
            AchHolder = "John Smith",
            AchRouting = "021000021",
            Method = "ach",
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RequestCredit` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyIn.<a href="/src/PayabliApi/MoneyIn/MoneyInClient.cs">DetailsAsync</a>(transId) -> WithRawResponseTask&lt;TransactionQueryRecordsCustomer&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a processed transaction's details.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyIn.DetailsAsync("45-as456777hhhhhhhhhh77777777-324");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**transId:** `string` — ReferenceId for the transaction (PaymentId).
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyIn.<a href="/src/PayabliApi/MoneyIn/MoneyInClient.cs">GetpaidAsync</a>(RequestPayment { ... }) -> WithRawResponseTask&lt;PayabliApiResponseGetPaid&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Make a single transaction. This method authorizes and captures a payment in one step.

  <Tip>
  Consider migrating to the [v2 Make a transaction endpoint](/developers/api-reference/moneyinV2/make-a-transaction) to take advantage of unified response codes and improved response consistency.
  </Tip>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyIn.GetpaidAsync(
    new RequestPayment
    {
        Body = new TransRequestBody
        {
            CustomerData = new PayorDataRequest { CustomerId = 4440 },
            EntryPoint = "f743aed24a",
            Ipaddress = "255.255.255.255",
            PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
            PaymentMethod = new PayMethodCredit
            {
                Cardcvv = "999",
                Cardexp = "02/27",
                CardHolder = "John Cassian",
                Cardnumber = "4111111111111111",
                Cardzip = "12345",
                Initiator = "payor",
                Method = "card",
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RequestPayment` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyIn.<a href="/src/PayabliApi/MoneyIn/MoneyInClient.cs">ReverseAsync</a>(transId, amount) -> WithRawResponseTask&lt;ReverseResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

A reversal either refunds or voids a transaction independent of the transaction's settlement status. Send a reversal request for a transaction, and Payabli automatically determines whether it's a refund or void. You don't need to know whether the transaction is settled or not.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyIn.ReverseAsync(0, "10-3ffa27df-b171-44e0-b251-e95fbfc7a723");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**transId:** `string` — ReferenceId for the transaction (PaymentId).
    
</dd>
</dl>

<dl>
<dd>

**amount:** `double` 


Amount to reverse from original transaction, minus any service fees charged on the original transaction.

The amount provided can't be greater than the original total amount of the transaction, minus service fees. For example, if a transaction was $90 plus a $10 service fee, you can reverse up to $90. 

An amount equal to zero will refunds the total amount authorized minus any service fee.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyIn.<a href="/src/PayabliApi/MoneyIn/MoneyInClient.cs">RefundAsync</a>(transId, amount) -> WithRawResponseTask&lt;RefundResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Refund a transaction that has settled and send money back to the account holder. If a transaction hasn't been settled, void it instead.

  <Tip>
  Consider migrating to the [v2 Refund endpoint](/developers/api-reference/moneyinV2/refund-a-settled-transaction) to take advantage of unified response codes and improved response consistency.
  </Tip>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyIn.RefundAsync(0, "10-3ffa27df-b171-44e0-b251-e95fbfc7a723");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**transId:** `string` — ReferenceId for the transaction (PaymentId).
    
</dd>
</dl>

<dl>
<dd>

**amount:** `double` 


Amount to refund from original transaction, minus any service fees charged on the original transaction. 

The amount provided can't be greater than the original total amount of the transaction, minus service fees. For example, if a transaction was \$90 plus a \$10 service fee, you can refund up to \$90.

An amount equal to zero will refund the total amount authorized minus any service fee.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyIn.<a href="/src/PayabliApi/MoneyIn/MoneyInClient.cs">RefundWithInstructionsAsync</a>(transId, RequestRefund { ... }) -> WithRawResponseTask&lt;RefundWithInstructionsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Refunds a settled transaction with split instructions.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyIn.RefundWithInstructionsAsync(
    "10-3ffa27df-b171-44e0-b251-e95fbfc7a723",
    new RequestRefund
    {
        IdempotencyKey = "8A29FC40-CA47-1067-B31D-00DD010662DB",
        Source = "api",
        OrderDescription = "Materials deposit",
        Amount = 100,
        RefundDetails = new RefundDetail
        {
            SplitRefunding = new List<SplitFundingRefundContent>()
            {
                new SplitFundingRefundContent
                {
                    OriginationEntryPoint = "7f1a381696",
                    AccountId = "187-342",
                    Description = "Refunding undelivered materials",
                    Amount = 60,
                },
                new SplitFundingRefundContent
                {
                    OriginationEntryPoint = "7f1a381696",
                    AccountId = "187-343",
                    Description = "Refunding deposit for undelivered materials",
                    Amount = 40,
                },
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**transId:** `string` — ReferenceId for the transaction (PaymentId).
    
</dd>
</dl>

<dl>
<dd>

**request:** `RequestRefund` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyIn.<a href="/src/PayabliApi/MoneyIn/MoneyInClient.cs">ReverseCreditAsync</a>(transId) -> WithRawResponseTask&lt;PayabliApiResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Reverse microdeposits that are used to verify customer account ownership and access. The `transId` value is returned in the success response for the original credit transaction made with `api/MoneyIn/makecredit`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyIn.ReverseCreditAsync("45-as456777hhhhhhhhhh77777777-324");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**transId:** `string` — ReferenceId for the transaction (PaymentId).
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyIn.<a href="/src/PayabliApi/MoneyIn/MoneyInClient.cs">SendReceipt2TransAsync</a>(transId, SendReceipt2TransRequest { ... }) -> WithRawResponseTask&lt;ReceiptResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Send a payment receipt for a transaction.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyIn.SendReceipt2TransAsync(
    "45-as456777hhhhhhhhhh77777777-324",
    new SendReceipt2TransRequest { Email = "example@email.com" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**transId:** `string` — ReferenceId for the transaction (PaymentId).
    
</dd>
</dl>

<dl>
<dd>

**request:** `SendReceipt2TransRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyIn.<a href="/src/PayabliApi/MoneyIn/MoneyInClient.cs">ValidateAsync</a>(RequestPaymentValidate { ... }) -> WithRawResponseTask&lt;ValidateResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Validates a card number without running a transaction or authorizing a charge.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyIn.ValidateAsync(
    new RequestPaymentValidate
    {
        IdempotencyKey = "6B29FC40-CA47-1067-B31D-00DD010662DA",
        EntryPoint = "entry132",
        PaymentMethod = new RequestPaymentValidatePaymentMethod
        {
            Method = RequestPaymentValidatePaymentMethodMethod.Card,
            Cardnumber = "4360000001000005",
            Cardexp = "12/29",
            Cardzip = "14602-8328",
            CardHolder = "Dianne Becker-Smith",
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RequestPaymentValidate` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyIn.<a href="/src/PayabliApi/MoneyIn/MoneyInClient.cs">VoidAsync</a>(transId) -> WithRawResponseTask&lt;VoidResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Cancel a transaction that hasn't been settled yet. Voiding non-captured authorizations prevents future captures. If a transaction has been settled, refund it instead.

  <Tip>
  Consider migrating to the [v2 Void endpoint](/developers/api-reference/moneyinV2/void-a-transaction) to take advantage of unified response codes and improved response consistency.
  </Tip>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyIn.VoidAsync("10-3ffa27df-b171-44e0-b251-e95fbfc7a723");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**transId:** `string` — ReferenceId for the transaction (PaymentId).
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyIn.<a href="/src/PayabliApi/MoneyIn/MoneyInClient.cs">Getpaidv2Async</a>(RequestPaymentV2 { ... }) -> WithRawResponseTask&lt;V2TransactionResponseWrapper&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Make a single transaction. This method authorizes and captures a payment in one step. This is the v2 version of the `api/MoneyIn/getpaid` endpoint, and returns the unified response format. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyIn.Getpaidv2Async(
    new RequestPaymentV2
    {
        Body = new TransRequestBody
        {
            CustomerData = new PayorDataRequest { CustomerId = 4440 },
            EntryPoint = "f743aed24a",
            Ipaddress = "255.255.255.255",
            PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
            PaymentMethod = new PayMethodCredit
            {
                Cardcvv = "999",
                Cardexp = "02/27",
                CardHolder = "John Cassian",
                Cardnumber = "4111111111111111",
                Cardzip = "12345",
                Initiator = "payor",
                Method = "card",
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RequestPaymentV2` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyIn.<a href="/src/PayabliApi/MoneyIn/MoneyInClient.cs">Authorizev2Async</a>(RequestPaymentAuthorizeV2 { ... }) -> WithRawResponseTask&lt;V2TransactionResponseWrapper&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Authorize a card transaction. This returns an authorization code and reserves funds for the merchant. Authorized transactions aren't flagged for settlement until captured. This is the v2 version of the `api/MoneyIn/authorize` endpoint, and returns the unified response format. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.

**Note**: Only card transactions can be authorized. This endpoint can't be used for ACH transactions.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyIn.Authorizev2Async(
    new RequestPaymentAuthorizeV2
    {
        Body = new TransRequestBody
        {
            CustomerData = new PayorDataRequest { CustomerId = 4440 },
            EntryPoint = "f743aed24a",
            Ipaddress = "255.255.255.255",
            PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
            PaymentMethod = new PayMethodCredit
            {
                Cardcvv = "999",
                Cardexp = "02/27",
                CardHolder = "John Cassian",
                Cardnumber = "4111111111111111",
                Cardzip = "12345",
                Initiator = "payor",
                Method = "card",
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RequestPaymentAuthorizeV2` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyIn.<a href="/src/PayabliApi/MoneyIn/MoneyInClient.cs">Capturev2Async</a>(transId, CaptureRequest { ... }) -> WithRawResponseTask&lt;V2TransactionResponseWrapper&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Capture an authorized transaction to complete the transaction and move funds from the customer to merchant account. This is the v2 version of the `api/MoneyIn/capture/{transId}` endpoint, and returns the unified response format. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyIn.Capturev2Async(
    "10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13",
    new CaptureRequest
    {
        PaymentDetails = new CapturePaymentDetails { TotalAmount = 105, ServiceFee = 5 },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**transId:** `string` — ReferenceId for the transaction (PaymentId).
    
</dd>
</dl>

<dl>
<dd>

**request:** `CaptureRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyIn.<a href="/src/PayabliApi/MoneyIn/MoneyInClient.cs">Refundv2Async</a>(transId) -> WithRawResponseTask&lt;V2TransactionResponseWrapper&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Give a full refund for a transaction that has settled and send money back to the account holder. To perform a partial refund, see [Partially refund a transaction](developers/api-reference/moneyinV2/partial-refund-a-settled-transaction).

This is the v2 version of the refund endpoint, and returns the unified response format. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyIn.Refundv2Async("10-3ffa27df-b171-44e0-b251-e95fbfc7a723");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**transId:** `string` — ReferenceId for the transaction (PaymentId).
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyIn.<a href="/src/PayabliApi/MoneyIn/MoneyInClient.cs">Refundv2AmountAsync</a>(transId, amount) -> WithRawResponseTask&lt;V2TransactionResponseWrapper&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Refund a transaction that has settled and send money back to the account holder. If `amount` is omitted or set to 0, performs a full refund. When a non-zero `amount` is provided, this endpoint performs a partial refund.

This is the v2 version of the refund endpoint, and returns the unified response format. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyIn.Refundv2AmountAsync("10-3ffa27df-b171-44e0-b251-e95fbfc7a723", 0);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**transId:** `string` — ReferenceId for the transaction (PaymentId).
    
</dd>
</dl>

<dl>
<dd>

**amount:** `double` — Amount to refund from original transaction, minus any service fees charged on the original transaction. If omitted or set to 0, performs a full refund.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyIn.<a href="/src/PayabliApi/MoneyIn/MoneyInClient.cs">Voidv2Async</a>(transId) -> WithRawResponseTask&lt;V2TransactionResponseWrapper&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Cancel a transaction that hasn't been settled yet. Voiding non-captured authorizations prevents future captures. This is the v2 version of the `api/MoneyIn/void/{transId}` endpoint, and returns the unified response format. See [Pay In unified response codes reference](/guides/pay-in-unified-response-codes-reference) for more information.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyIn.Voidv2Async("10-3ffa27df-b171-44e0-b251-e95fbfc7a723");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**transId:** `string` — ReferenceId for the transaction (PaymentId).
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## MoneyOut
<details><summary><code>client.MoneyOut.<a href="/src/PayabliApi/MoneyOut/MoneyOutClient.cs">AuthorizeOutAsync</a>(MoneyOutTypesRequestOutAuthorize { ... }) -> WithRawResponseTask&lt;AuthCapturePayoutResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Authorizes transaction for payout. Authorized transactions aren't flagged for settlement until captured. Use `referenceId` returned in the response to capture the transaction. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyOut.AuthorizeOutAsync(
    new MoneyOutTypesRequestOutAuthorize
    {
        Body = new AuthorizePayoutBody
        {
            EntryPoint = "48acde49",
            InvoiceData = new List<RequestOutAuthorizeInvoiceData>()
            {
                new RequestOutAuthorizeInvoiceData { BillId = 54323 },
            },
            OrderDescription = "Window Painting",
            PaymentDetails = new RequestOutAuthorizePaymentDetails
            {
                TotalAmount = 47,
                Unbundled = false,
            },
            PaymentMethod = new AuthorizePaymentMethod { Method = "managed" },
            VendorData = new RequestOutAuthorizeVendorData { VendorNumber = "7895433" },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `MoneyOutTypesRequestOutAuthorize` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyOut.<a href="/src/PayabliApi/MoneyOut/MoneyOutClient.cs">CancelAllOutAsync</a>(IEnumerable&lt;string&gt; { ... }) -> WithRawResponseTask&lt;CaptureAllOutResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Cancels an array of payout transactions.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyOut.CancelAllOutAsync(new List<string>() { "2-29", "2-28", "2-27" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `IEnumerable<string>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyOut.<a href="/src/PayabliApi/MoneyOut/MoneyOutClient.cs">CancelOutGetAsync</a>(referenceId) -> WithRawResponseTask&lt;PayabliApiResponse0000&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Cancel a payout transaction by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyOut.CancelOutGetAsync("129-219");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**referenceId:** `string` — The ID for the payout transaction. 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyOut.<a href="/src/PayabliApi/MoneyOut/MoneyOutClient.cs">CancelOutDeleteAsync</a>(referenceId) -> WithRawResponseTask&lt;PayabliApiResponse0000&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Cancel a payout transaction by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyOut.CancelOutDeleteAsync("129-219");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**referenceId:** `string` — The ID for the payout transaction. 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyOut.<a href="/src/PayabliApi/MoneyOut/MoneyOutClient.cs">CaptureAllOutAsync</a>(CaptureAllOutRequest { ... }) -> WithRawResponseTask&lt;CaptureAllOutResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Captures an array of authorized payout transactions for settlement. The maximum number of transactions that can be captured in a single request is 500.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyOut.CaptureAllOutAsync(
    new CaptureAllOutRequest
    {
        Body = new List<string>() { "2-29", "2-28", "2-27" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CaptureAllOutRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyOut.<a href="/src/PayabliApi/MoneyOut/MoneyOutClient.cs">CaptureOutAsync</a>(referenceId, CaptureOutRequest { ... }) -> WithRawResponseTask&lt;AuthCapturePayoutResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Captures a single authorized payout transaction by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyOut.CaptureOutAsync("129-219", new CaptureOutRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**referenceId:** `string` — The ID for the payout transaction. 
    
</dd>
</dl>

<dl>
<dd>

**request:** `CaptureOutRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyOut.<a href="/src/PayabliApi/MoneyOut/MoneyOutClient.cs">PayoutDetailsAsync</a>(transId) -> WithRawResponseTask&lt;BillDetailResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns details for a processed money out transaction.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyOut.PayoutDetailsAsync("45-as456777hhhhhhhhhh77777777-324");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**transId:** `string` — ReferenceId for the transaction (PaymentId).
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyOut.<a href="/src/PayabliApi/MoneyOut/MoneyOutClient.cs">VCardGetAsync</a>(cardToken) -> WithRawResponseTask&lt;VCardGetResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves vCard details for a single card in an entrypoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyOut.VCardGetAsync("20230403315245421165");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**cardToken:** `string` — ID for a virtual card.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyOut.<a href="/src/PayabliApi/MoneyOut/MoneyOutClient.cs">SendVCardLinkAsync</a>(SendVCardLinkRequest { ... }) -> WithRawResponseTask&lt;OperationResult&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Sends a virtual card link via email to the vendor associated with the `transId`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyOut.SendVCardLinkAsync(
    new SendVCardLinkRequest { TransId = "01K33Z6YQZ6GD5QVKZ856MJBSC" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SendVCardLinkRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyOut.<a href="/src/PayabliApi/MoneyOut/MoneyOutClient.cs">GetCheckImageAsync</a>(assetName) -> WithRawResponseTask&lt;string&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the image of a check associated with a processed transaction. 
The check image is returned in the response body as a base64-encoded string. 
The check image is only available for payouts that have been processed.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyOut.GetCheckImageAsync("check133832686289732320_01JKBNZ5P32JPTZY8XXXX000000.pdf");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**assetName:** `string` 

Name of the check asset to retrieve. This is returned as `filename` in the `CheckData` object 
in the response when you make a GET request to `/MoneyOut/details/{transId}`.
```
    "CheckData": {
      "ftype": "PDF",
      "filename": "check133832686289732320_01JKBNZ5P32JPTZY8XXXX000000.pdf",
      "furl": "",
      "fContent": ""
  }
```
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.MoneyOut.<a href="/src/PayabliApi/MoneyOut/MoneyOutClient.cs">UpdateCheckPaymentStatusAsync</a>(transId, checkPaymentStatus) -> WithRawResponseTask&lt;PayabliApiResponse00Responsedatanonobject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates the status of a processed check payment transaction. This endpoint handles the status transition, updates related bills, creates audit events, and triggers notifications.

The transaction must meet all of the following criteria:
- **Status**: Must be in Processing or Processed status.
- **Payment method**: Must be a check payment method.

### Allowed status values

| Value | Status | Description |
|-------|--------|-------------|
| `0` | Cancelled/Voided | Cancels the check transaction. Reverts associated bills to their previous state (Approved or Active), creates "Cancelled" events, and sends a `payout_transaction_voidedcancelled` notification if the notification is enabled. |
| `5` | Paid | Marks the check transaction as paid. Updates associated bills to "Paid" status, creates "Paid" events, and sends a `payout_transaction_paid` notification if the notification is enabled. |
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MoneyOut.UpdateCheckPaymentStatusAsync("TRANS123456", AllowedCheckPaymentStatus.Paid);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**transId:** `string` — The Payabli transaction ID for the check payment.
    
</dd>
</dl>

<dl>
<dd>

**checkPaymentStatus:** `AllowedCheckPaymentStatus` — The new status to apply to the check transaction. To mark a check as `Paid`, send 5. To mark a check as `Cancelled`, send 0.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Notification
<details><summary><code>client.Notification.<a href="/src/PayabliApi/Notification/NotificationClient.cs">AddNotificationAsync</a>(OneOf&lt;NotificationStandardRequest, NotificationReportRequest&gt; { ... }) -> WithRawResponseTask&lt;PayabliApiResponseNotifications&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new notification or autogenerated report. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Notification.AddNotificationAsync(
    new NotificationStandardRequest
    {
        Content = new NotificationStandardRequestContent
        {
            EventType = NotificationStandardRequestContentEventType.CreatedApplication,
        },
        Frequency = NotificationStandardRequestFrequency.Untilcancelled,
        Method = NotificationStandardRequestMethod.Web,
        OwnerId = "236",
        OwnerType = 0,
        Status = 1,
        Target = "https://webhook.site/2871b8f8-edc7-441a-b376-98d8c8e33275",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `OneOf<NotificationStandardRequest, NotificationReportRequest>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Notification.<a href="/src/PayabliApi/Notification/NotificationClient.cs">DeleteNotificationAsync</a>(nId) -> WithRawResponseTask&lt;PayabliApiResponseNotifications&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a single notification or autogenerated report.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Notification.DeleteNotificationAsync("1717");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**nId:** `string` — Notification ID. 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Notification.<a href="/src/PayabliApi/Notification/NotificationClient.cs">GetNotificationAsync</a>(nId) -> WithRawResponseTask&lt;NotificationQueryRecord&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a single notification or autogenerated report's details.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Notification.GetNotificationAsync("1717");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**nId:** `string` — Notification ID. 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Notification.<a href="/src/PayabliApi/Notification/NotificationClient.cs">UpdateNotificationAsync</a>(nId, OneOf&lt;NotificationStandardRequest, NotificationReportRequest&gt; { ... }) -> WithRawResponseTask&lt;PayabliApiResponseNotifications&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update a notification or autogenerated report. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Notification.UpdateNotificationAsync(
    "1717",
    new NotificationStandardRequest
    {
        Content = new NotificationStandardRequestContent
        {
            EventType = NotificationStandardRequestContentEventType.ApprovedPayment,
        },
        Frequency = NotificationStandardRequestFrequency.Untilcancelled,
        Method = NotificationStandardRequestMethod.Email,
        OwnerId = "136",
        OwnerType = 0,
        Status = 1,
        Target = "newemail@email.com",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**nId:** `string` — Notification ID. 
    
</dd>
</dl>

<dl>
<dd>

**request:** `OneOf<NotificationStandardRequest, NotificationReportRequest>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Notification.<a href="/src/PayabliApi/Notification/NotificationClient.cs">GetReportFileAsync</a>(id) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Gets a copy of a generated report by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Notification.GetReportFileAsync(1000000);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `long` — Report ID
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Notificationlogs
<details><summary><code>client.Notificationlogs.<a href="/src/PayabliApi/Notificationlogs/NotificationlogsClient.cs">SearchNotificationLogsAsync</a>(SearchNotificationLogsRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;NotificationLog&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Search notification logs with filtering and pagination.
  - Start date and end date cannot be more than 30 days apart
  - Either `orgId` or `paypointId` must be provided

This endpoint requires the `notifications_create` OR `notifications_read` permission.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Notificationlogs.SearchNotificationLogsAsync(
    new SearchNotificationLogsRequest
    {
        PageSize = 20,
        Body = new NotificationLogSearchRequest
        {
            StartDate = new DateTime(2024, 01, 01, 00, 00, 00, 000),
            EndDate = new DateTime(2024, 01, 31, 23, 59, 59, 000),
            OrgId = 12345,
            NotificationEvent = "ActivatedMerchant",
            Succeeded = true,
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SearchNotificationLogsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Notificationlogs.<a href="/src/PayabliApi/Notificationlogs/NotificationlogsClient.cs">GetNotificationLogAsync</a>(uuid) -> WithRawResponseTask&lt;NotificationLogDetail&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get detailed information for a specific notification log entry.
This endpoint requires the `notifications_create` OR `notifications_read` permission.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Notificationlogs.GetNotificationLogAsync("550e8400-e29b-41d4-a716-446655440000");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**uuid:** `string` — The notification log entry.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Notificationlogs.<a href="/src/PayabliApi/Notificationlogs/NotificationlogsClient.cs">RetryNotificationLogAsync</a>(uuid) -> WithRawResponseTask&lt;NotificationLogDetail&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retry sending a specific notification.

**Permissions:** notifications_create
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Notificationlogs.RetryNotificationLogAsync("550e8400-e29b-41d4-a716-446655440000");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**uuid:** `string` — Unique id
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Notificationlogs.<a href="/src/PayabliApi/Notificationlogs/NotificationlogsClient.cs">BulkRetryNotificationLogsAsync</a>(IEnumerable&lt;string&gt; { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retry sending multiple notifications (maximum 50 IDs).
This is an async process, so use the search endpoint again to check the notification status.

This endpoint requires the `notifications_create` permission.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Notificationlogs.BulkRetryNotificationLogsAsync(
    new List<string>()
    {
        "550e8400-e29b-41d4-a716-446655440000",
        "550e8400-e29b-41d4-a716-446655440001",
        "550e8400-e29b-41d4-a716-446655440002",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `IEnumerable<string>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Ocr
<details><summary><code>client.Ocr.<a href="/src/PayabliApi/Ocr/OcrClient.cs">OcrDocumentFormAsync</a>(typeResult, FileContentImageOnly { ... }) -> WithRawResponseTask&lt;PayabliApiResponseOcr&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Use this endpoint to upload an image file for OCR processing. The accepted file formats include PDF, JPG, JPEG, PNG, and GIF. Specify the desired type of result (either 'bill' or 'invoice') in the path parameter `typeResult`. The response will contain the OCR processing results, including extracted data such as bill number, vendor information, bill items, and more.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Ocr.OcrDocumentFormAsync(
    "typeResult",
    new FileContentImageOnly
    {
        Ftype = null,
        Filename = null,
        Furl = null,
        FContent = null,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**typeResult:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `FileContentImageOnly` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Ocr.<a href="/src/PayabliApi/Ocr/OcrClient.cs">OcrDocumentJsonAsync</a>(typeResult, FileContentImageOnly { ... }) -> WithRawResponseTask&lt;PayabliApiResponseOcr&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Use this endpoint to submit a Base64-encoded image file for OCR processing. The accepted file formats include PDF, JPG, JPEG, PNG, and GIF. Specify the desired type of result (either 'bill' or 'invoice') in the path parameter `typeResult`. The response will contain the OCR processing results, including extracted data such as bill number, vendor information, bill items, and more.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Ocr.OcrDocumentJsonAsync(
    "typeResult",
    new FileContentImageOnly
    {
        Ftype = null,
        Filename = null,
        Furl = null,
        FContent = null,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**typeResult:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `FileContentImageOnly` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organization
<details><summary><code>client.Organization.<a href="/src/PayabliApi/Organization/OrganizationClient.cs">AddOrganizationAsync</a>(AddOrganizationRequest { ... }) -> WithRawResponseTask&lt;AddOrganizationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates an organization under a parent organization. This is also referred to as a suborganization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.AddOrganizationAsync(
    new AddOrganizationRequest
    {
        IdempotencyKey = "6B29FC40-CA47-1067-B31D-00DD010662DA",
        BillingInfo = new Instrument
        {
            AchAccount = "123123123",
            AchRouting = "123123123",
            BillingAddress = "123 Walnut Street",
            BillingCity = "Johnson City",
            BillingCountry = "US",
            BillingState = "TN",
            BillingZip = "37615",
        },
        Contacts = new List<Contacts>()
        {
            new Contacts
            {
                ContactEmail = "herman@hermanscoatings.com",
                ContactName = "Herman Martinez",
                ContactPhone = "3055550000",
                ContactTitle = "Owner",
            },
        },
        HasBilling = true,
        HasResidual = true,
        OrgAddress = "123 Walnut Street",
        OrgCity = "Johnson City",
        OrgCountry = "US",
        OrgEntryName = "pilgrim-planner",
        OrgId = "123",
        OrgLogo = new FileContent
        {
            FContent = "TXkgdGVzdCBmaWxlHJ==...",
            Filename = "my-doc.pdf",
            Ftype = FileContentFtype.Pdf,
            Furl = "https://mysite.com/my-doc.pdf",
        },
        OrgName = "Pilgrim Planner",
        OrgParentId = 236,
        OrgState = "TN",
        OrgTimezone = -5,
        OrgType = 0,
        OrgWebsite = "www.pilgrimageplanner.com",
        OrgZip = "37615",
        ReplyToEmail = "email@example.com",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `AddOrganizationRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.<a href="/src/PayabliApi/Organization/OrganizationClient.cs">DeleteOrganizationAsync</a>(orgId) -> WithRawResponseTask&lt;DeleteOrganizationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete an organization by ID. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.DeleteOrganizationAsync(123);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.<a href="/src/PayabliApi/Organization/OrganizationClient.cs">EditOrganizationAsync</a>(orgId, OrganizationData { ... }) -> WithRawResponseTask&lt;EditOrganizationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates an organization's details by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.EditOrganizationAsync(
    123,
    new OrganizationData
    {
        Contacts = new List<Contacts>()
        {
            new Contacts
            {
                ContactEmail = "herman@hermanscoatings.com",
                ContactName = "Herman Martinez",
                ContactPhone = "3055550000",
                ContactTitle = "Owner",
            },
        },
        OrgAddress = "123 Walnut Street",
        OrgCity = "Johnson City",
        OrgCountry = "US",
        OrgEntryName = "pilgrim-planner",
        OrganizationDataOrgId = "123",
        OrgName = "Pilgrim Planner",
        OrgState = "TN",
        OrgTimezone = -5,
        OrgType = 0,
        OrgWebsite = "www.pilgrimageplanner.com",
        OrgZip = "37615",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `OrganizationData` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.<a href="/src/PayabliApi/Organization/OrganizationClient.cs">GetBasicOrganizationAsync</a>(entry) -> WithRawResponseTask&lt;OrganizationQueryRecord&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Gets an organization's basic information by entry name (entrypoint identifier).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.GetBasicOrganizationAsync("8cfec329267");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.<a href="/src/PayabliApi/Organization/OrganizationClient.cs">GetBasicOrganizationByIdAsync</a>(orgId) -> WithRawResponseTask&lt;OrganizationQueryRecord&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Gets an organizations basic details by org ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.GetBasicOrganizationByIdAsync(123);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.<a href="/src/PayabliApi/Organization/OrganizationClient.cs">GetOrganizationAsync</a>(orgId) -> WithRawResponseTask&lt;OrganizationQueryRecord&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves details for an organization by ID. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.GetOrganizationAsync(123);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organization.<a href="/src/PayabliApi/Organization/OrganizationClient.cs">GetSettingsOrganizationAsync</a>(orgId) -> WithRawResponseTask&lt;SettingsQueryRecord&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves an organization's settings.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.GetSettingsOrganizationAsync(123);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## PaymentLink
<details><summary><code>client.PaymentLink.<a href="/src/PayabliApi/PaymentLink/PaymentLinkClient.cs">AddPayLinkFromInvoiceAsync</a>(idInvoice, PayLinkDataInvoice { ... }) -> WithRawResponseTask&lt;PayabliApiResponsePaymentLinks&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Generates a payment link for an invoice from the invoice ID. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PaymentLink.AddPayLinkFromInvoiceAsync(
    23548884,
    new PayLinkDataInvoice
    {
        Mail2 = "jo@example.com; ceo@example.com",
        Body = new PaymentPageRequestBody
        {
            ContactUs = new ContactElement
            {
                EmailLabel = "Email",
                Enabled = true,
                Header = "Contact Us",
                Order = 0,
                PaymentIcons = true,
                PhoneLabel = "Phone",
            },
            Invoices = new InvoiceElement
            {
                Enabled = true,
                InvoiceLink = new LabelElement
                {
                    Enabled = true,
                    Label = "View Invoice",
                    Order = 0,
                },
                Order = 0,
                ViewInvoiceDetails = new LabelElement
                {
                    Enabled = true,
                    Label = "Invoice Details",
                    Order = 0,
                },
            },
            Logo = new Element { Enabled = true, Order = 0 },
            MessageBeforePaying = new LabelElement
            {
                Enabled = true,
                Label = "Please review your payment details",
                Order = 0,
            },
            Notes = new NoteElement
            {
                Enabled = true,
                Header = "Additional Notes",
                Order = 0,
                Placeholder = "Enter any additional notes here",
                Value = "",
            },
            Page = new PageElement
            {
                Description = "Complete your payment securely",
                Enabled = true,
                Header = "Payment Page",
                Order = 0,
            },
            PaymentButton = new LabelElement
            {
                Enabled = true,
                Label = "Pay Now",
                Order = 0,
            },
            PaymentMethods = new MethodElement
            {
                AllMethodsChecked = true,
                Enabled = true,
                Header = "Payment Methods",
                Methods = new MethodsList
                {
                    Amex = true,
                    ApplePay = true,
                    Discover = true,
                    ECheck = true,
                    Mastercard = true,
                    Visa = true,
                },
                Order = 0,
                Settings = new MethodElementSettings
                {
                    ApplePay = new MethodElementSettingsApplePay
                    {
                        ButtonStyle = MethodElementSettingsApplePayButtonStyle.Black,
                        ButtonType = MethodElementSettingsApplePayButtonType.Pay,
                        Language = MethodElementSettingsApplePayLanguage.EnUs,
                    },
                },
            },
            Payor = new PayorElement
            {
                Enabled = true,
                Fields = new List<PayorFields>()
                {
                    new PayorFields
                    {
                        Display = true,
                        Fixed = true,
                        Identifier = true,
                        Label = "Full Name",
                        Name = "fullName",
                        Order = 0,
                        Required = true,
                        Validation = "alpha",
                        Value = "",
                        Width = 0,
                    },
                },
                Header = "Payor Information",
                Order = 0,
            },
            Review = new HeaderElement
            {
                Enabled = true,
                Header = "Review Payment",
                Order = 0,
            },
            Settings = new PagelinkSetting
            {
                Color = "#000000",
                CustomCssUrl = "https://example.com/custom.css",
                Language = "en",
                PageLogo = new FileContent
                {
                    FContent =
                        "PHN2ZyB2aWV3Qm94PSIwIDAgODAwIDEwMDAiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CiAgPCEtLSBCYWNrZ3JvdW5kIC0tPgogIDxyZWN0IHdpZHRoPSI4MDAiIGhlaWdodD0iMTAwMCIgZmlsbD0id2hpdGUiLz4KICAKICA8IS0tIENvbXBhbnkgSGVhZGVyIC0tPgogIDx0ZXh0IHg9IjQwIiB5PSI2MCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjI0IiBmb250LXdlaWdodD0iYm9sZCIgZmlsbD0iIzJjM2U1MCI+R3J1enlhIEFkdmVudHVyZSBPdXRmaXR0ZXJzPC90ZXh0PgogIDxsaW5lIHgxPSI0MCIgeTE9IjgwIiB4Mj0iNzYwIiB5Mj0iODAiIHN0cm9rZT0iIzJjM2U1MCIgc3Ryb2tlLXdpZHRoPSIyIi8+CiAgCiAgPCEtLSBDb21wYW55IERldGFpbHMgLS0+CiAgPHRleHQgeD0iNDAiIHk9IjExMCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE0IiBmaWxsPSIjMzQ0OTVlIj4xMjMgTW91bnRhaW4gVmlldyBSb2FkPC90ZXh0PgogIDx0ZXh0IHg9IjQwIiB5PSIxMzAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+VGJpbGlzaSwgR2VvcmdpYSAwMTA1PC90ZXh0PgogIDx0ZXh0IHg9IjQwIiB5PSIxNTAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+VGVsOiArOTk1IDMyIDEyMyA0NTY3PC90ZXh0PgogIDx0ZXh0IHg9IjQwIiB5PSIxNzAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+RW1haWw6IGluZm9AZ3J1enlhYWR2ZW50dXJlcy5jb208L3RleHQ+CgogIDwhLS0gSW52b2ljZSBUaXRsZSAtLT4KICA8dGV4dCB4PSI2MDAiIHk9IjExMCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjI0IiBmb250LXdlaWdodD0iYm9sZCIgZmlsbD0iIzJjM2U1MCI+SU5WT0lDRTwvdGV4dD4KICA8dGV4dCB4PSI2MDAiIHk9IjE0MCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE0IiBmaWxsPSIjMzQ0OTVlIj5EYXRlOiAxMi8xMS8yMDI0PC90ZXh0PgogIDx0ZXh0IHg9IjYwMCIgeT0iMTYwIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZpbGw9IiMzNDQ5NWUiPkludm9pY2UgIzogR1JaLTIwMjQtMTEyMzwvdGV4dD4KCiAgPCEtLSBCaWxsIFRvIFNlY3Rpb24gLS0+CiAgPHRleHQgeD0iNDAiIHk9IjIyMCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE2IiBmb250LXdlaWdodD0iYm9sZCIgZmlsbD0iIzJjM2U1MCI+QklMTCBUTzo8L3RleHQ+CiAgPHJlY3QgeD0iNDAiIHk9IjIzNSIgd2lkdGg9IjMwMCIgaGVpZ2h0PSI4MCIgZmlsbD0iI2Y3ZjlmYSIvPgogIDx0ZXh0IHg9IjUwIiB5PSIyNjAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+W0N1c3RvbWVyIE5hbWVdPC90ZXh0PgogIDx0ZXh0IHg9IjUwIiB5PSIyODAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+W0FkZHJlc3MgTGluZSAxXTwvdGV4dD4KICA8dGV4dCB4PSI1MCIgeT0iMzAwIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZpbGw9IiMzNDQ5NWUiPltDaXR5LCBDb3VudHJ5XTwvdGV4dD4KCiAgPCEtLSBUYWJsZSBIZWFkZXJzIC0tPgogIDxyZWN0IHg9IjQwIiB5PSIzNDAiIHdpZHRoPSI3MjAiIGhlaWdodD0iMzAiIGZpbGw9IiMyYzNlNTAiLz4KICA8dGV4dCB4PSI1MCIgeT0iMzYwIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZvbnQtd2VpZ2h0PSJib2xkIiBmaWxsPSJ3aGl0ZSI+RGVzY3JpcHRpb248L3RleHQ+CiAgPHRleHQgeD0iNDUwIiB5PSIzNjAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZm9udC13ZWlnaHQ9ImJvbGQiIGZpbGw9IndoaXRlIj5RdWFudGl0eTwvdGV4dD4KICA8dGV4dCB4PSI1NTAiIHk9IjM2MCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE0IiBmb250LXdlaWdodD0iYm9sZCIgZmlsbD0id2hpdGUiPlJhdGU8L3RleHQ+CiAgPHRleHQgeD0iNjgwIiB5PSIzNjAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZm9udC13ZWlnaHQ9ImJvbGQiIGZpbGw9IndoaXRlIj5BbW91bnQ8L3RleHQ+CgogIDwhLS0gVGFibGUgUm93cyAtLT4KICA8cmVjdCB4PSI0MCIgeT0iMzcwIiB3aWR0aD0iNzIwIiBoZWlnaHQ9IjMwIiBmaWxsPSIjZjdmOWZhIi8+CiAgPHRleHQgeD0iNTAiIHk9IjM5MCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE0IiBmaWxsPSIjMzQ0OTVlIj5Nb3VudGFpbiBDbGltYmluZyBFcXVpcG1lbnQgUmVudGFsPC90ZXh0PgogIDx0ZXh0IHg9IjQ1MCIgeT0iMzkwIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZpbGw9IiMzNDQ5NWUiPjE8L3RleHQ+CiAgPHRleHQgeD0iNTUwIiB5PSIzOTAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+JDI1MC4wMDwvdGV4dD4KICA8dGV4dCB4PSI2ODAiIHk9IjM5MCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE0IiBmaWxsPSIjMzQ0OTVlIj4kMjUwLjAwPC90ZXh0PgoKICA8cmVjdCB4PSI0MCIgeT0iNDAwIiB3aWR0aD0iNzIwIiBoZWlnaHQ9IjMwIiBmaWxsPSJ3aGl0ZSIvPgogIDx0ZXh0IHg9IjUwIiB5PSI0MjAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+R3VpZGVkIFRyZWsgUGFja2FnZSAtIDIgRGF5czwvdGV4dD4KICA8dGV4dCB4PSI0NTAiIHk9IjQyMCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE0IiBmaWxsPSIjMzQ0OTVlIj4xPC90ZXh0PgogIDx0ZXh0IHg9IjU1MCIgeT0iNDIwIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZpbGw9IiMzNDQ5NWUiPiQ0MDAuMDA8L3RleHQ+CiAgPHRleHQgeD0iNjgwIiB5PSI0MjAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+JDQwMC4wMDwvdGV4dD4KCiAgPHJlY3QgeD0iNDAiIHk9IjQzMCIgd2lkdGg9IjcyMCIgaGVpZ2h0PSIzMCIgZmlsbD0iI2Y3ZjlmYSIvPgogIDx0ZXh0IHg9IjUwIiB5PSI0NTAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+U2FmZXR5IEVxdWlwbWVudCBQYWNrYWdlPC90ZXh0PgogIDx0ZXh0IHg9IjQ1MCIgeT0iNDUwIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZpbGw9IiMzNDQ5NWUiPjE8L3RleHQ+CiAgPHRleHQgeD0iNTUwIiB5PSI0NTAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+JDE1MC4wMDwvdGV4dD4KICA8dGV4dCB4PSI2ODAiIHk9IjQ1MCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE0IiBmaWxsPSIjMzQ0OTVlIj4kMTUwLjAwPC90ZXh0PgoKICA8IS0tIFRvdGFscyAtLT4KICA8bGluZSB4MT0iNDAiIHkxPSI0ODAiIHgyPSI3NjAiIHkyPSI0ODAiIHN0cm9rZT0iIzJjM2U1MCIgc3Ryb2tlLXdpZHRoPSIxIi8+CiAgPHRleHQgeD0iNTUwIiB5PSI1MTAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZm9udC13ZWlnaHQ9ImJvbGQiIGZpbGw9IiMzNDQ5NWUiPlN1YnRvdGFsOjwvdGV4dD4KICA8dGV4dCB4PSI2ODAiIHk9IjUxMCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE0IiBmaWxsPSIjMzQ0OTVlIj4kODAwLjAwPC90ZXh0PgogIDx0ZXh0IHg9IjU1MCIgeT0iNTM1IiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZvbnQtd2VpZ2h0PSJib2xkIiBmaWxsPSIjMzQ0OTVlIj5UYXggKDE4JSk6PC90ZXh0PgogIDx0ZXh0IHg9IjY4MCIgeT0iNTM1IiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZpbGw9IiMzNDQ5NWUiPiQxNDQuMDA8L3RleHQ+CiAgPHRleHQgeD0iNTUwIiB5PSI1NzAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNiIgZm9udC13ZWlnaHQ9ImJvbGQiIGZpbGw9IiMyYzNlNTAiPlRvdGFsOjwvdGV4dD4KICA8dGV4dCB4PSI2ODAiIHk9IjU3MCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE2IiBmb250LXdlaWdodD0iYm9sZCIgZmlsbD0iIzJjM2U1MCI+JDk0NC4wMDwvdGV4dD4KCiAgPCEtLSBQYXltZW50IFRlcm1zIC0tPgogIDx0ZXh0IHg9IjQwIiB5PSI2NDAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNiIgZm9udC13ZWlnaHQ9ImJvbGQiIGZpbGw9IiMyYzNlNTAiPlBheW1lbnQgVGVybXM8L3RleHQ+CiAgPHRleHQgeD0iNDAiIHk9IjY3MCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE0IiBmaWxsPSIjMzQ0OTVlIj5QYXltZW50IGlzIGR1ZSB3aXRoaW4gMzAgZGF5czwvdGV4dD4KICA8dGV4dCB4PSI0MCIgeT0iNjkwIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZpbGw9IiMzNDQ5NWUiPlBsZWFzZSBpbmNsdWRlIGludm9pY2UgbnVtYmVyIG9uIHBheW1lbnQ8L3RleHQ+CgogIDwhLS0gQmFuayBEZXRhaWxzIC0tPgogIDx0ZXh0IHg9IjQwIiB5PSI3MzAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNiIgZm9udC13ZWlnaHQ9ImJvbGQiIGZpbGw9IiMyYzNlNTAiPkJhbmsgRGV0YWlsczwvdGV4dD4KICA8dGV4dCB4PSI0MCIgeT0iNzYwIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZpbGw9IiMzNDQ5NWUiPkJhbms6IEJhbmsgb2YgR2VvcmdpYTwvdGV4dD4KICA8dGV4dCB4PSI0MCIgeT0iNzgwIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZpbGw9IiMzNDQ5NWUiPklCQU46IEdFMTIzNDU2Nzg5MDEyMzQ1Njc4PC90ZXh0PgogIDx0ZXh0IHg9IjQwIiB5PSI4MDAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+U1dJRlQ6IEJBR0FHRTIyPC90ZXh0PgoKICA8IS0tIEZvb3RlciAtLT4KICA8bGluZSB4MT0iNDAiIHkxPSI5MDAiIHgyPSI3NjAiIHkyPSI5MDAiIHN0cm9rZT0iIzJjM2U1MCIgc3Ryb2tlLXdpZHRoPSIxIi8+CiAgPHRleHQgeD0iNDAiIHk9IjkzMCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjEyIiBmaWxsPSIjN2Y4YzhkIj5UaGFuayB5b3UgZm9yIGNob29zaW5nIEdydXp5YSBBZHZlbnR1cmUgT3V0Zml0dGVyczwvdGV4dD4KICA8dGV4dCB4PSI0MCIgeT0iOTUwIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTIiIGZpbGw9IiM3ZjhjOGQiPnd3dy5ncnV6eWFhZHZlbnR1cmVzLmNvbTwvdGV4dD4KPC9zdmc+Cg==",
                    Filename = "logo.jpg",
                    Ftype = FileContentFtype.Jpg,
                    Furl = "",
                },
                RedirectAfterApprove = true,
                RedirectAfterApproveUrl = "https://example.com/success",
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idInvoice:** `int` — Invoice ID
    
</dd>
</dl>

<dl>
<dd>

**request:** `PayLinkDataInvoice` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PaymentLink.<a href="/src/PayabliApi/PaymentLink/PaymentLinkClient.cs">AddPayLinkFromBillAsync</a>(billId, PayLinkDataBill { ... }) -> WithRawResponseTask&lt;PayabliApiResponsePaymentLinks&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Generates a payment link for a bill from the bill ID. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PaymentLink.AddPayLinkFromBillAsync(
    23548884,
    new PayLinkDataBill
    {
        Mail2 = "jo@example.com; ceo@example.com",
        Body = new PaymentPageRequestBody
        {
            ContactUs = new ContactElement
            {
                EmailLabel = "Email",
                Enabled = true,
                Header = "Contact Us",
                Order = 0,
                PaymentIcons = true,
                PhoneLabel = "Phone",
            },
            Logo = new Element { Enabled = true, Order = 0 },
            MessageBeforePaying = new LabelElement
            {
                Enabled = true,
                Label = "Please review your payment details",
                Order = 0,
            },
            Notes = new NoteElement
            {
                Enabled = true,
                Header = "Additional Notes",
                Order = 0,
                Placeholder = "Enter any additional notes here",
                Value = "",
            },
            Page = new PageElement
            {
                Description = "Get paid securely",
                Enabled = true,
                Header = "Payment Page",
                Order = 0,
            },
            PaymentButton = new LabelElement
            {
                Enabled = true,
                Label = "Pay Now",
                Order = 0,
            },
            PaymentMethods = new MethodElement
            {
                AllMethodsChecked = true,
                Enabled = true,
                Header = "Payment Methods",
                Methods = new MethodsList
                {
                    Amex = true,
                    ApplePay = true,
                    Discover = true,
                    ECheck = true,
                    Mastercard = true,
                    Visa = true,
                },
                Order = 0,
            },
            Payor = new PayorElement
            {
                Enabled = true,
                Fields = new List<PayorFields>()
                {
                    new PayorFields
                    {
                        Display = true,
                        Fixed = true,
                        Identifier = true,
                        Label = "Full Name",
                        Name = "fullName",
                        Order = 0,
                        Required = true,
                        Validation = "alpha",
                        Value = "",
                        Width = 0,
                    },
                },
                Header = "Payor Information",
                Order = 0,
            },
            Review = new HeaderElement
            {
                Enabled = true,
                Header = "Review Payment",
                Order = 0,
            },
            Settings = new PagelinkSetting { Color = "#000000", Language = "en" },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**billId:** `int` — The Payabli ID for the bill.
    
</dd>
</dl>

<dl>
<dd>

**request:** `PayLinkDataBill` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PaymentLink.<a href="/src/PayabliApi/PaymentLink/PaymentLinkClient.cs">DeletePayLinkFromIdAsync</a>(payLinkId) -> WithRawResponseTask&lt;PayabliApiResponsePaymentLinks&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a payment link by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PaymentLink.DeletePayLinkFromIdAsync("payLinkId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**payLinkId:** `string` — ID for the payment link.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PaymentLink.<a href="/src/PayabliApi/PaymentLink/PaymentLinkClient.cs">GetPayLinkFromIdAsync</a>(paylinkId) -> WithRawResponseTask&lt;GetPayLinkFromIdResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a payment link by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PaymentLink.GetPayLinkFromIdAsync("paylinkId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**paylinkId:** `string` — ID for payment link
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PaymentLink.<a href="/src/PayabliApi/PaymentLink/PaymentLinkClient.cs">PushPayLinkFromIdAsync</a>(payLinkId, PushPayLinkRequest { ... }) -> WithRawResponseTask&lt;PayabliApiResponsePaymentLinks&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Send a payment link to the specified email addresses or phone numbers.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PaymentLink.PushPayLinkFromIdAsync(
    "payLinkId",
    new PushPayLinkRequest(new PushPayLinkRequest.Sms(new PushPayLinkRequestSms()))
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**payLinkId:** `string` — ID for the payment link.
    
</dd>
</dl>

<dl>
<dd>

**request:** `PushPayLinkRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PaymentLink.<a href="/src/PayabliApi/PaymentLink/PaymentLinkClient.cs">RefreshPayLinkFromIdAsync</a>(payLinkId, RefreshPayLinkFromIdRequest { ... }) -> WithRawResponseTask&lt;PayabliApiResponsePaymentLinks&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Refresh a payment link's content after an update.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PaymentLink.RefreshPayLinkFromIdAsync("payLinkId", new RefreshPayLinkFromIdRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**payLinkId:** `string` — ID for the payment link.
    
</dd>
</dl>

<dl>
<dd>

**request:** `RefreshPayLinkFromIdRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PaymentLink.<a href="/src/PayabliApi/PaymentLink/PaymentLinkClient.cs">SendPayLinkFromIdAsync</a>(payLinkId, SendPayLinkFromIdRequest { ... }) -> WithRawResponseTask&lt;PayabliApiResponsePaymentLinks&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Sends a payment link to the specified email addresses. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PaymentLink.SendPayLinkFromIdAsync(
    "payLinkId",
    new SendPayLinkFromIdRequest { Mail2 = "jo@example.com; ceo@example.com" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**payLinkId:** `string` — ID for the payment link.
    
</dd>
</dl>

<dl>
<dd>

**request:** `SendPayLinkFromIdRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PaymentLink.<a href="/src/PayabliApi/PaymentLink/PaymentLinkClient.cs">UpdatePayLinkFromIdAsync</a>(payLinkId, PayLinkUpdateData { ... }) -> WithRawResponseTask&lt;PayabliApiResponsePaymentLinks&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a payment link's details.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PaymentLink.UpdatePayLinkFromIdAsync(
    "332-c277b704-1301",
    new PayLinkUpdateData
    {
        Notes = new NoteElement
        {
            Enabled = true,
            Header = "Additional Notes",
            Order = 0,
            Placeholder = "Enter any additional notes here",
            Value = "",
        },
        PaymentButton = new LabelElement
        {
            Enabled = true,
            Label = "Pay Now",
            Order = 0,
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**payLinkId:** `string` — ID for the payment link.
    
</dd>
</dl>

<dl>
<dd>

**request:** `PayLinkUpdateData` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PaymentLink.<a href="/src/PayabliApi/PaymentLink/PaymentLinkClient.cs">AddPayLinkFromBillLotNumberAsync</a>(lotNumber, PayLinkDataOut { ... }) -> WithRawResponseTask&lt;PayabliApiResponsePaymentLinks&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Generates a vendor payment link for a specific bill lot number. This allows you to pay all bills with the same lot number for a vendor with a single payment link.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PaymentLink.AddPayLinkFromBillLotNumberAsync(
    "LOT-2024-001",
    new PayLinkDataOut
    {
        EntryPoint = "billing",
        VendorNumber = "VENDOR-123",
        Mail2 = "customer@example.com; billing@example.com",
        AmountFixed = "true",
        Body = new PaymentPageRequestBody
        {
            ContactUs = new ContactElement
            {
                EmailLabel = "Email",
                Enabled = true,
                Header = "Contact Us",
                Order = 0,
                PaymentIcons = true,
                PhoneLabel = "Phone",
            },
            Logo = new Element { Enabled = true, Order = 0 },
            MessageBeforePaying = new LabelElement
            {
                Enabled = true,
                Label = "Please review your payment details",
                Order = 0,
            },
            Notes = new NoteElement
            {
                Enabled = true,
                Header = "Additional Notes",
                Order = 0,
                Placeholder = "Enter any additional notes here",
                Value = "",
            },
            Page = new PageElement
            {
                Description = "Get paid securely",
                Enabled = true,
                Header = "Payment Page",
                Order = 0,
            },
            PaymentButton = new LabelElement
            {
                Enabled = true,
                Label = "Pay Now",
                Order = 0,
            },
            PaymentMethods = new MethodElement
            {
                AllMethodsChecked = true,
                Enabled = true,
                Header = "Payment Methods",
                Methods = new MethodsList
                {
                    Amex = true,
                    ApplePay = true,
                    Discover = true,
                    ECheck = true,
                    Mastercard = true,
                    Visa = true,
                },
                Order = 0,
            },
            Payor = new PayorElement
            {
                Enabled = true,
                Fields = new List<PayorFields>()
                {
                    new PayorFields
                    {
                        Display = true,
                        Fixed = true,
                        Identifier = true,
                        Label = "Full Name",
                        Name = "fullName",
                        Order = 0,
                        Required = true,
                        Validation = "alpha",
                        Value = "",
                        Width = 0,
                    },
                },
                Header = "Payor Information",
                Order = 0,
            },
            Review = new HeaderElement
            {
                Enabled = true,
                Header = "Review Payment",
                Order = 0,
            },
            Settings = new PagelinkSetting { Color = "#000000", Language = "en" },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**lotNumber:** `string` — Lot number of the bills to pay. All bills with this lot number will be included.
    
</dd>
</dl>

<dl>
<dd>

**request:** `PayLinkDataOut` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## PaymentMethodDomain
<details><summary><code>client.PaymentMethodDomain.<a href="/src/PayabliApi/PaymentMethodDomain/PaymentMethodDomainClient.cs">AddPaymentMethodDomainAsync</a>(AddPaymentMethodDomainRequest { ... }) -> WithRawResponseTask&lt;AddPaymentMethodDomainApiResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Add a payment method domain to an organization or paypoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PaymentMethodDomain.AddPaymentMethodDomainAsync(
    new AddPaymentMethodDomainRequest
    {
        DomainName = "checkout.example.com",
        EntityId = 109,
        EntityType = "paypoint",
        ApplePay = new AddPaymentMethodDomainRequestApplePay { IsEnabled = true },
        GooglePay = new AddPaymentMethodDomainRequestGooglePay { IsEnabled = true },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `AddPaymentMethodDomainRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PaymentMethodDomain.<a href="/src/PayabliApi/PaymentMethodDomain/PaymentMethodDomainClient.cs">CascadePaymentMethodDomainAsync</a>(domainId) -> WithRawResponseTask&lt;PaymentMethodDomainGeneralResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Cascades a payment method domain to all child entities. All paypoints and suborganization under this parent will inherit this domain and its settings.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PaymentMethodDomain.CascadePaymentMethodDomainAsync(
    "pmd_b8237fa45c964d8a9ef27160cd42b8c5"
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**domainId:** `string` — The payment method domain's ID in Payabli.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PaymentMethodDomain.<a href="/src/PayabliApi/PaymentMethodDomain/PaymentMethodDomainClient.cs">DeletePaymentMethodDomainAsync</a>(domainId) -> WithRawResponseTask&lt;DeletePaymentMethodDomainResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a payment method domain. You can't delete an inherited domain, you must delete a domain at the organization level.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PaymentMethodDomain.DeletePaymentMethodDomainAsync(
    "pmd_b8237fa45c964d8a9ef27160cd42b8c5"
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**domainId:** `string` — The payment method domain's ID in Payabli.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PaymentMethodDomain.<a href="/src/PayabliApi/PaymentMethodDomain/PaymentMethodDomainClient.cs">GetPaymentMethodDomainAsync</a>(domainId) -> WithRawResponseTask&lt;PaymentMethodDomainApiResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the details for a payment method domain.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PaymentMethodDomain.GetPaymentMethodDomainAsync(
    "pmd_b8237fa45c964d8a9ef27160cd42b8c5"
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**domainId:** `string` — The payment method domain's ID in Payabli.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PaymentMethodDomain.<a href="/src/PayabliApi/PaymentMethodDomain/PaymentMethodDomainClient.cs">ListPaymentMethodDomainsAsync</a>(ListPaymentMethodDomainsRequest { ... }) -> WithRawResponseTask&lt;ListPaymentMethodDomainsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get a list of payment method domains that belong to a PSP, organization, or paypoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PaymentMethodDomain.ListPaymentMethodDomainsAsync(
    new ListPaymentMethodDomainsRequest { EntityId = 1147, EntityType = "paypoint" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListPaymentMethodDomainsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PaymentMethodDomain.<a href="/src/PayabliApi/PaymentMethodDomain/PaymentMethodDomainClient.cs">UpdatePaymentMethodDomainAsync</a>(domainId, UpdatePaymentMethodDomainRequest { ... }) -> WithRawResponseTask&lt;PaymentMethodDomainGeneralResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update a payment method domain's configuration values.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PaymentMethodDomain.UpdatePaymentMethodDomainAsync(
    "pmd_b8237fa45c964d8a9ef27160cd42b8c5",
    new UpdatePaymentMethodDomainRequest
    {
        ApplePay = new UpdatePaymentMethodDomainRequestWallet { IsEnabled = false },
        GooglePay = new UpdatePaymentMethodDomainRequestWallet { IsEnabled = false },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**domainId:** `string` — The payment method domain's ID in Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdatePaymentMethodDomainRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PaymentMethodDomain.<a href="/src/PayabliApi/PaymentMethodDomain/PaymentMethodDomainClient.cs">VerifyPaymentMethodDomainAsync</a>(domainId) -> WithRawResponseTask&lt;PaymentMethodDomainGeneralResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Verify a new payment method domain. If verification is successful, Apple Pay is automatically activated for the domain.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PaymentMethodDomain.VerifyPaymentMethodDomainAsync(
    "pmd_b8237fa45c964d8a9ef27160cd42b8c5"
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**domainId:** `string` — The payment method domain's ID in Payabli.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Paypoint
<details><summary><code>client.Paypoint.<a href="/src/PayabliApi/Paypoint/PaypointClient.cs">GetBasicEntryAsync</a>(entry) -> WithRawResponseTask&lt;GetBasicEntryResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Gets the basic details for a paypoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Paypoint.GetBasicEntryAsync("8cfec329267");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Paypoint.<a href="/src/PayabliApi/Paypoint/PaypointClient.cs">GetBasicEntryByIdAsync</a>(idPaypoint) -> WithRawResponseTask&lt;GetBasicEntryByIdResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves the basic details for a paypoint by ID. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Paypoint.GetBasicEntryByIdAsync("198");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idPaypoint:** `string` — Paypoint ID. You can find this value by querying `/api/Query/paypoints/{orgId}`
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Paypoint.<a href="/src/PayabliApi/Paypoint/PaypointClient.cs">GetEntryConfigAsync</a>(entry, GetEntryConfigRequest { ... }) -> WithRawResponseTask&lt;GetEntryConfigResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Gets the details for a single paypoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Paypoint.GetEntryConfigAsync("8cfec329267", new GetEntryConfigRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetEntryConfigRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Paypoint.<a href="/src/PayabliApi/Paypoint/PaypointClient.cs">GetPageAsync</a>(entry, subdomain) -> WithRawResponseTask&lt;PayabliPages&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Gets the details for single payment page for a paypoint. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Paypoint.GetPageAsync("8cfec329267", "pay-your-fees-1");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**subdomain:** `string` — Payment page identifier. The subdomain value is the last portion of the payment page URL. For example, in`https://paypages-sandbox.payabli.com/513823dc10/pay-your-fees-1`, the subdomain is `pay-your-fees-1`.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Paypoint.<a href="/src/PayabliApi/Paypoint/PaypointClient.cs">RemovePageAsync</a>(entry, subdomain) -> WithRawResponseTask&lt;PayabliApiResponseGeneric2Part&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a payment page in a paypoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Paypoint.RemovePageAsync("8cfec329267", "pay-your-fees-1");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**subdomain:** `string` — Payment page identifier. The subdomain value is the last portion of the payment page URL. For example, in`https://paypages-sandbox.payabli.com/513823dc10/pay-your-fees-1`, the subdomain is `pay-your-fees-1`.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Paypoint.<a href="/src/PayabliApi/Paypoint/PaypointClient.cs">SaveLogoAsync</a>(entry, FileContent { ... }) -> WithRawResponseTask&lt;PayabliApiResponse00Responsedatanonobject&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a paypoint logo. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Paypoint.SaveLogoAsync("8cfec329267", new FileContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `FileContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Paypoint.<a href="/src/PayabliApi/Paypoint/PaypointClient.cs">SettingsPageAsync</a>(entry) -> WithRawResponseTask&lt;SettingsQueryRecord&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves an paypoint's basic settings like custom fields, identifiers, and invoicing settings.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Paypoint.SettingsPageAsync("8cfec329267");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Paypoint.<a href="/src/PayabliApi/Paypoint/PaypointClient.cs">MigrateAsync</a>(PaypointMoveRequest { ... }) -> WithRawResponseTask&lt;MigratePaypointResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Migrates a paypoint to a new parent organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Paypoint.MigrateAsync(
    new PaypointMoveRequest
    {
        EntryPoint = "473abc123def",
        NewParentOrganizationId = 123,
        NotificationRequest = new NotificationRequest
        {
            NotificationUrl = "https://webhook-test.yoursie.com",
            WebHeaderParameters = new List<WebHeaderParameter>()
            {
                new WebHeaderParameter { Key = "testheader", Value = "1234567890" },
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PaypointMoveRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Query
<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListBatchDetailsAsync</a>(entry, ListBatchDetailsRequest { ... }) -> WithRawResponseTask&lt;QueryBatchesDetailResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of batches and their details, including settled and
unsettled transactions for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListBatchDetailsAsync(
    "8cfec329267",
    new ListBatchDetailsRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListBatchDetailsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListBatchDetailsOrgAsync</a>(orgId, ListBatchDetailsOrgRequest { ... }) -> WithRawResponseTask&lt;QueryResponseSettlements&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of batches and their details, including settled and unsettled transactions for an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListBatchDetailsOrgAsync(
    123,
    new ListBatchDetailsOrgRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListBatchDetailsOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListBatchesAsync</a>(entry, ListBatchesRequest { ... }) -> WithRawResponseTask&lt;QueryBatchesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of batches for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListBatchesAsync(
    "8cfec329267",
    new ListBatchesRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListBatchesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListBatchesOrgAsync</a>(orgId, ListBatchesOrgRequest { ... }) -> WithRawResponseTask&lt;QueryBatchesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of batches for an org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListBatchesOrgAsync(
    123,
    new ListBatchesOrgRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListBatchesOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListBatchesOutAsync</a>(entry, ListBatchesOutRequest { ... }) -> WithRawResponseTask&lt;QueryBatchesOutResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of MoneyOut batches for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListBatchesOutAsync(
    "8cfec329267",
    new ListBatchesOutRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListBatchesOutRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListBatchesOutOrgAsync</a>(orgId, ListBatchesOutOrgRequest { ... }) -> WithRawResponseTask&lt;QueryBatchesOutResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of MoneyOut batches for an org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListBatchesOutOrgAsync(
    123,
    new ListBatchesOutOrgRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListBatchesOutOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListChargebacksAsync</a>(entry, ListChargebacksRequest { ... }) -> WithRawResponseTask&lt;QueryChargebacksResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a list of chargebacks and returned transactions for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListChargebacksAsync(
    "8cfec329267",
    new ListChargebacksRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListChargebacksRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListChargebacksOrgAsync</a>(orgId, ListChargebacksOrgRequest { ... }) -> WithRawResponseTask&lt;QueryChargebacksResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of chargebacks and returned transactions for an org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListChargebacksOrgAsync(
    123,
    new ListChargebacksOrgRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListChargebacksOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListCustomersAsync</a>(entry, ListCustomersRequest { ... }) -> WithRawResponseTask&lt;QueryCustomerResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a list of customers for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListCustomersAsync(
    "8cfec329267",
    new ListCustomersRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListCustomersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListCustomersOrgAsync</a>(orgId, ListCustomersOrgRequest { ... }) -> WithRawResponseTask&lt;QueryCustomerResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a list of customers for an org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListCustomersOrgAsync(
    123,
    new ListCustomersOrgRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListCustomersOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListNotificationReportsAsync</a>(entry, ListNotificationReportsRequest { ... }) -> WithRawResponseTask&lt;QueryResponseNotificationReports&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a list of all reports generated in the last 60 days for a single entrypoint. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListNotificationReportsAsync(
    "8cfec329267",
    new ListNotificationReportsRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListNotificationReportsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListNotificationReportsOrgAsync</a>(orgId, ListNotificationReportsOrgRequest { ... }) -> WithRawResponseTask&lt;QueryResponseNotificationReports&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a list of all reports generated in the last 60 days for an organization. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListNotificationReportsOrgAsync(
    123,
    new ListNotificationReportsOrgRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListNotificationReportsOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListNotificationsAsync</a>(entry, ListNotificationsRequest { ... }) -> WithRawResponseTask&lt;QueryResponseNotifications&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a list of notifications for an entrypoint. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListNotificationsAsync(
    "8cfec329267",
    new ListNotificationsRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListNotificationsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListNotificationsOrgAsync</a>(orgId, ListNotificationsOrgRequest { ... }) -> WithRawResponseTask&lt;QueryResponseNotifications&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Return a list of notifications for an organization. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListNotificationsOrgAsync(
    123,
    new ListNotificationsOrgRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListNotificationsOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListOrganizationsAsync</a>(orgId, ListOrganizationsRequest { ... }) -> WithRawResponseTask&lt;ListOrganizationsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a list of an organization's suborganizations and their full details such as orgId, users, and settings. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListOrganizationsAsync(
    123,
    new ListOrganizationsRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListOrganizationsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListPayoutAsync</a>(entry, ListPayoutRequest { ... }) -> WithRawResponseTask&lt;QueryPayoutTransaction&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a list of money out transactions (payouts) for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListPayoutAsync(
    "8cfec329267",
    new ListPayoutRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListPayoutRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListPayoutOrgAsync</a>(orgId, ListPayoutOrgRequest { ... }) -> WithRawResponseTask&lt;QueryPayoutTransaction&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a list of money out transactions (payouts) for an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListPayoutOrgAsync(
    123,
    new ListPayoutOrgRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListPayoutOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListPaypointsAsync</a>(orgId, ListPaypointsRequest { ... }) -> WithRawResponseTask&lt;QueryEntrypointResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a list of paypoints in an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListPaypointsAsync(
    123,
    new ListPaypointsRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListPaypointsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListSettlementsAsync</a>(entry, ListSettlementsRequest { ... }) -> WithRawResponseTask&lt;QueryResponseSettlements&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of settled transactions for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListSettlementsAsync(
    "8cfec329267",
    new ListSettlementsRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListSettlementsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListSettlementsOrgAsync</a>(orgId, ListSettlementsOrgRequest { ... }) -> WithRawResponseTask&lt;QueryResponseSettlements&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of settled transactions for an organization. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListSettlementsOrgAsync(
    123,
    new ListSettlementsOrgRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListSettlementsOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListSubscriptionsAsync</a>(entry, ListSubscriptionsRequest { ... }) -> WithRawResponseTask&lt;QuerySubscriptionResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a list of subscriptions for a single paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListSubscriptionsAsync(
    "8cfec329267",
    new ListSubscriptionsRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListSubscriptionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListSubscriptionsOrgAsync</a>(orgId, ListSubscriptionsOrgRequest { ... }) -> WithRawResponseTask&lt;QuerySubscriptionResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a list of subscriptions for a single org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListSubscriptionsOrgAsync(
    123,
    new ListSubscriptionsOrgRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListSubscriptionsOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListTransactionsAsync</a>(entry, ListTransactionsRequest { ... }) -> WithRawResponseTask&lt;QueryResponseTransactions&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of transactions for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
By default, this endpoint returns only transactions from the last 60 days. To query transactions outside of this period, include `transactionDate` filters.
For example, this request parameters filter for transactions between April 01, 2024 and April 09, 2024. 
``` curl --request GET \
  --url https://sandbox.payabli.com/api/Query/transactions/org/1?limitRecord=20&fromRecord=0&transactionDate(ge)=2024-04-01T00:00:00&transactionDate(le)=2024-04-09T23:59:59\
  --header 'requestToken: <api-key>'

  ```
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListTransactionsAsync(
    "8cfec329267",
    new ListTransactionsRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListTransactionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListTransactionsOrgAsync</a>(orgId, ListTransactionsOrgRequest { ... }) -> WithRawResponseTask&lt;QueryResponseTransactions&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>


Retrieve a list of transactions for an organization. Use filters to
limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.


By default, this endpoint returns only transactions from the last 60 days. To query transactions outside of this period, include `transactionDate` filters.

For example, this request parameters filter for transactions between April 01, 2024 and April 09, 2024. 

```
curl --request GET \
  --url https://sandbox.payabli.com/api/Query/transactions/org/1?limitRecord=20&fromRecord=0&transactionDate(ge)=2024-04-01T00:00:00&transactionDate(le)=2024-04-09T23:59:59\
  --header 'requestToken: <api-key>'

  ```
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListTransactionsOrgAsync(
    123,
    new ListTransactionsOrgRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListTransactionsOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListTransferDetailsAsync</a>(entry, transferId, ListTransfersPaypointRequest { ... }) -> WithRawResponseTask&lt;QueryTransferDetailResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of transfer details records for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListTransferDetailsAsync("47862acd", 123456, new ListTransfersPaypointRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**transferId:** `int` — The numeric identifier for the transfer, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListTransfersPaypointRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListTransfersAsync</a>(entry, ListTransfersRequest { ... }) -> WithRawResponseTask&lt;TransferQueryResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of transfers for a paypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListTransfersAsync(
    "47862acd",
    new ListTransfersRequest { FromRecord = 0, LimitRecord = 20 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListTransfersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListTransfersOrgAsync</a>(ListTransfersRequestOrg { ... }) -> WithRawResponseTask&lt;TransferQueryResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of transfers for an org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListTransfersOrgAsync(
    new ListTransfersRequestOrg
    {
        OrgId = 123,
        FromRecord = 0,
        LimitRecord = 20,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListTransfersRequestOrg` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListTransfersOutOrgAsync</a>(orgId, ListTransfersOutOrgRequest { ... }) -> WithRawResponseTask&lt;TransferOutQueryResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of outbound transfers for an organization. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListTransfersOutOrgAsync(
    77,
    new ListTransfersOutOrgRequest { FromRecord = 0, LimitRecord = 20 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListTransfersOutOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListTransfersOutPaypointAsync</a>(entry, ListTransfersOutPaypointRequest { ... }) -> WithRawResponseTask&lt;TransferOutQueryResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of outbound transfers for a paypoint. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListTransfersOutPaypointAsync(
    "47cade237",
    new ListTransfersOutPaypointRequest { FromRecord = 0, LimitRecord = 20 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListTransfersOutPaypointRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListTransferDetailsOutAsync</a>(entry, transferId, ListTransferDetailsOutRequest { ... }) -> WithRawResponseTask&lt;TransferOutDetailQueryResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details for a specific outbound transfer. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListTransferDetailsOutAsync(
    "47ace2b25",
    4521,
    new ListTransferDetailsOutRequest { FromRecord = 0, LimitRecord = 20 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**transferId:** `int` — The numeric identifier for the transfer, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListTransferDetailsOutRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListUsersOrgAsync</a>(orgId, ListUsersOrgRequest { ... }) -> WithRawResponseTask&lt;QueryUserResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get list of users for an org. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListUsersOrgAsync(
    123,
    new ListUsersOrgRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListUsersOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListUsersPaypointAsync</a>(entry, ListUsersPaypointRequest { ... }) -> WithRawResponseTask&lt;QueryUserResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get list of users for a paypoint. Use filters to limit results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListUsersPaypointAsync(
    "8cfec329267",
    new ListUsersPaypointRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListUsersPaypointRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListVendorsAsync</a>(entry, ListVendorsRequest { ... }) -> WithRawResponseTask&lt;QueryResponseVendors&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of vendors for an entrypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListVendorsAsync(
    "8cfec329267",
    new ListVendorsRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — The paypoint's entrypoint identifier. [Learn more](/developers/api-reference/api-overview#entrypoint-vs-entry)
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListVendorsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListVendorsOrgAsync</a>(orgId, ListVendorsOrgRequest { ... }) -> WithRawResponseTask&lt;QueryResponseVendors&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of vendors for an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListVendorsOrgAsync(
    123,
    new ListVendorsOrgRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListVendorsOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListVcardsAsync</a>(entry, ListVcardsRequest { ... }) -> WithRawResponseTask&lt;VCardQueryResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of vcards (virtual credit cards) issued for an entrypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListVcardsAsync(
    "8cfec329267",
    new ListVcardsRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListVcardsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Query.<a href="/src/PayabliApi/Query/QueryClient.cs">ListVcardsOrgAsync</a>(orgId, ListVcardsOrgRequest { ... }) -> WithRawResponseTask&lt;VCardQueryResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of vcards (virtual credit cards) issued for an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Query.ListVcardsOrgAsync(
    123,
    new ListVcardsOrgRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListVcardsOrgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Statistic
<details><summary><code>client.Statistic.<a href="/src/PayabliApi/Statistic/StatisticClient.cs">BasicStatsAsync</a>(mode, freq, level, entryId, BasicStatsRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;StatBasicExtendedQueryRecord&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves the basic statistics for an organization or a paypoint, for a given time period, grouped by a particular frequency. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Statistic.BasicStatsAsync(
    1000000,
    "m",
    1,
    "ytd",
    new BasicStatsRequest { EndDate = "2025-11-01", StartDate = "2025-11-30" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**mode:** `string` 

Mode for the request. Allowed values:

- `custom` - Allows you to set a custom date range
- `ytd` - Year To Date
- `mtd` - Month To Date
- `wtd` - Week To Date
- `today` - All current day
- `m12` - Last 12 months
- `d30` - Last 30 days
- `h24` - Last 24 hours
- `lasty` - Last Year
- `lastm` - Last Month
- `lastw` - Last Week
- `yesterday` - Last Day
  
    
</dd>
</dl>

<dl>
<dd>

**freq:** `string` 

Frequency to group series. Allowed values:

- `m` - monthly
- `w` - weekly
- `d` - daily
- `h` - hourly

For example, `w` groups the results by week.
    
</dd>
</dl>

<dl>
<dd>

**level:** `int` 

The entry level for the request: 
  - 0 for Organization
  - 2 for Paypoint
    
</dd>
</dl>

<dl>
<dd>

**entryId:** `long` — Identifier in Payabli for the entity.
    
</dd>
</dl>

<dl>
<dd>

**request:** `BasicStatsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Statistic.<a href="/src/PayabliApi/Statistic/StatisticClient.cs">CustomerBasicStatsAsync</a>(mode, freq, customerId, CustomerBasicStatsRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;SubscriptionStatsQueryRecord&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves the basic statistics for a customer for a specific time period, grouped by a selected frequency. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Statistic.CustomerBasicStatsAsync(998, "m", "ytd", new CustomerBasicStatsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**mode:** `string` 

Mode for request. Allowed values:

- `ytd` - Year To Date
- `mtd` - Month To Date
- `wtd` - Week To Date
- `today` - All current day
- `m12` - Last 12 months
- `d30` - Last 30 days
- `h24` - Last 24 hours
- `lasty` - Last Year
- `lastm` - Last Month
- `lastw` - Last Week
- `yesterday` - Last Day
    
</dd>
</dl>

<dl>
<dd>

**freq:** `string` 

Frequency to group series. Allowed values:

- `m` - monthly
- `w` - weekly
- `d` - daily
- `h` - hourly

For example, `w` groups the results by week.
    
</dd>
</dl>

<dl>
<dd>

**customerId:** `int` — Payabli-generated customer ID. Maps to "Customer ID" column in PartnerHub. 
    
</dd>
</dl>

<dl>
<dd>

**request:** `CustomerBasicStatsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Statistic.<a href="/src/PayabliApi/Statistic/StatisticClient.cs">SubStatsAsync</a>(interval, level, entryId, SubStatsRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;StatBasicQueryRecord&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves the subscription statistics for a given interval for a paypoint or organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Statistic.SubStatsAsync(1000000, "30", 1, new SubStatsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**interval:** `string` 

Interval to get the data. Allowed values:

- `all` - all intervals
- `30` - 1-30 days
- `60` - 31-60 days
- `90` - 61-90 days
- `plus` - +90 days
    
</dd>
</dl>

<dl>
<dd>

**level:** `int` 

The entry level for the request: 
  - 0 for Organization
  - 2 for Paypoint
    
</dd>
</dl>

<dl>
<dd>

**entryId:** `long` — Identifier in Payabli for the entity.
    
</dd>
</dl>

<dl>
<dd>

**request:** `SubStatsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Statistic.<a href="/src/PayabliApi/Statistic/StatisticClient.cs">VendorBasicStatsAsync</a>(mode, freq, idVendor, VendorBasicStatsRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;StatisticsVendorQueryRecord&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the basic statistics about a vendor for a given time period, grouped by frequency. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Statistic.VendorBasicStatsAsync("m", 1, "ytd", new VendorBasicStatsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**mode:** `string` 

Mode for request. Allowed values:

- `ytd` - Year To Date
- `mtd` - Month To Date
- `wtd` - Week To Date
- `today` - All current day
- `m12` - Last 12 months
- `d30` - Last 30 days
- `h24` - Last 24 hours
- `lasty` - Last Year
- `lastm` - Last Month
- `lastw` - Last Week
- `yesterday` - Last Day
    
</dd>
</dl>

<dl>
<dd>

**freq:** `string` 

Frequency to group series. Allowed values:

- `m` - monthly
- `w` - weekly
- `d` - daily
- `h` - hourly

For example, `w` groups the results by week.
    
</dd>
</dl>

<dl>
<dd>

**idVendor:** `int` — Vendor ID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `VendorBasicStatsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Subscription
<details><summary><code>client.Subscription.<a href="/src/PayabliApi/Subscription/SubscriptionClient.cs">GetSubscriptionAsync</a>(subId) -> WithRawResponseTask&lt;SubscriptionQueryRecords&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a single subscription's details.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Subscription.GetSubscriptionAsync(263);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**subId:** `int` — The subscription ID. 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Subscription.<a href="/src/PayabliApi/Subscription/SubscriptionClient.cs">NewSubscriptionAsync</a>(RequestSchedule { ... }) -> WithRawResponseTask&lt;AddSubscriptionResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a subscription or scheduled payment to run at a specified time and frequency. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Subscription.NewSubscriptionAsync(
    new RequestSchedule
    {
        Body = new SubscriptionRequestBody
        {
            CustomerData = new PayorDataRequest { CustomerId = 4440 },
            EntryPoint = "f743aed24a",
            PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
            PaymentMethod = new PayMethodCredit
            {
                Cardcvv = "123",
                Cardexp = "02/25",
                CardHolder = "John Cassian",
                Cardnumber = "4111111111111111",
                Cardzip = "37615",
                Initiator = "payor",
                Method = "card",
            },
            ScheduleDetails = new ScheduleDetail
            {
                EndDate = "03-20-2025",
                Frequency = Frequency.Weekly,
                PlanId = 1,
                StartDate = "09-20-2024",
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RequestSchedule` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Subscription.<a href="/src/PayabliApi/Subscription/SubscriptionClient.cs">RemoveSubscriptionAsync</a>(subId) -> WithRawResponseTask&lt;RemoveSubscriptionResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a subscription, autopay, or recurring payment and prevents future charges.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Subscription.RemoveSubscriptionAsync(396);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**subId:** `int` — The subscription ID. 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Subscription.<a href="/src/PayabliApi/Subscription/SubscriptionClient.cs">UpdateSubscriptionAsync</a>(subId, RequestUpdateSchedule { ... }) -> WithRawResponseTask&lt;UpdateSubscriptionResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a subscription's details.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Subscription.UpdateSubscriptionAsync(
    231,
    new RequestUpdateSchedule { SetPause = true }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**subId:** `int` — The subscription ID. 
    
</dd>
</dl>

<dl>
<dd>

**request:** `RequestUpdateSchedule` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Templates
<details><summary><code>client.Templates.<a href="/src/PayabliApi/Templates/TemplatesClient.cs">DeleteTemplateAsync</a>(templateId) -> WithRawResponseTask&lt;PayabliApiResponseTemplateId&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a template by ID. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Templates.DeleteTemplateAsync(80);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**templateId:** `double` — The boarding template ID. Can be found at the end of the boarding template URL in PartnerHub. Example: `https://partner-sandbox.payabli.com/myorganization/boarding/edittemplate/80`. Here, the template ID is `80`.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Templates.<a href="/src/PayabliApi/Templates/TemplatesClient.cs">GetlinkTemplateAsync</a>(templateId, ignoreEmpty) -> WithRawResponseTask&lt;BoardingLinkApiResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Generates a boarding link from a boarding template.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Templates.GetlinkTemplateAsync(true, 80);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**templateId:** `double` — The boarding template ID. Can be found at the end of the boarding template URL in PartnerHub. Example: `https://partner-sandbox.payabli.com/myorganization/boarding/edittemplate/80`. Here, the template ID is `80`.
    
</dd>
</dl>

<dl>
<dd>

**ignoreEmpty:** `bool` — Ignore read-only and empty fields Default is `false`. If `ignoreEmpty` = `false` and any field is empty, then the request returns a failure response. If `ignoreEmpty` = `true`, the request returns the boarding link name regardless of whether fields are empty.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Templates.<a href="/src/PayabliApi/Templates/TemplatesClient.cs">GetTemplateAsync</a>(templateId) -> WithRawResponseTask&lt;TemplateQueryRecord&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a boarding template's details by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Templates.GetTemplateAsync(80);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**templateId:** `double` — The boarding template ID. Can be found at the end of the boarding template URL in PartnerHub. Example: `https://partner-sandbox.payabli.com/myorganization/boarding/edittemplate/80`. Here, the template ID is `80`.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Templates.<a href="/src/PayabliApi/Templates/TemplatesClient.cs">ListTemplatesAsync</a>(orgId, ListTemplatesRequest { ... }) -> WithRawResponseTask&lt;TemplateQueryResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a list of boarding templates for an organization. Use filters to limit results. You can't make a request that includes filters from the API console in the documentation. The response won't be filtered. Instead, copy the request, remove `parameters=` and run the request in a different client.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Templates.ListTemplatesAsync(
    123,
    new ListTemplatesRequest
    {
        FromRecord = 251,
        LimitRecord = 0,
        SortBy = "desc(field_name)",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**orgId:** `int` — The numeric identifier for organization, assigned by Payabli.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListTemplatesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## TokenStorage
<details><summary><code>client.TokenStorage.<a href="/src/PayabliApi/TokenStorage/TokenStorageClient.cs">AddMethodAsync</a>(AddMethodRequest { ... }) -> WithRawResponseTask&lt;AddMethodResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Saves a payment method for reuse. This call exchanges sensitive payment information for a token that can be used to process future transactions. The `ReferenceId` value in the response is the `storedMethodId` to use with transactions.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.TokenStorage.AddMethodAsync(
    new AddMethodRequest
    {
        Body = new RequestTokenStorage
        {
            CustomerData = new PayorDataRequest { CustomerId = 4440 },
            EntryPoint = "f743aed24a",
            FallbackAuth = true,
            PaymentMethod = new TokenizeCard
            {
                Cardcvv = "123",
                Cardexp = "02/25",
                CardHolder = "John Doe",
                Cardnumber = "4111111111111111",
                Cardzip = "12345",
                Method = "card",
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `AddMethodRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.TokenStorage.<a href="/src/PayabliApi/TokenStorage/TokenStorageClient.cs">GetMethodAsync</a>(methodId, GetMethodRequest { ... }) -> WithRawResponseTask&lt;GetMethodResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves details for a saved payment method.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.TokenStorage.GetMethodAsync(
    "32-8877drt00045632-678",
    new GetMethodRequest { CardExpirationFormat = 1, IncludeTemporary = false }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**methodId:** `string` — The saved payment method ID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetMethodRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.TokenStorage.<a href="/src/PayabliApi/TokenStorage/TokenStorageClient.cs">RemoveMethodAsync</a>(methodId) -> WithRawResponseTask&lt;PayabliApiResponsePaymethodDelete&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a saved payment method.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.TokenStorage.RemoveMethodAsync("32-8877drt00045632-678");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**methodId:** `string` — The saved payment method ID.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.TokenStorage.<a href="/src/PayabliApi/TokenStorage/TokenStorageClient.cs">UpdateMethodAsync</a>(methodId, UpdateMethodRequest { ... }) -> WithRawResponseTask&lt;PayabliApiResponsePaymethodDelete&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a saved payment method.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.TokenStorage.UpdateMethodAsync(
    "32-8877drt00045632-678",
    new UpdateMethodRequest
    {
        Body = new RequestTokenStorage
        {
            CustomerData = new PayorDataRequest { CustomerId = 4440 },
            EntryPoint = "f743aed24a",
            FallbackAuth = true,
            PaymentMethod = new TokenizeCard
            {
                Cardcvv = "123",
                Cardexp = "02/25",
                CardHolder = "John Doe",
                Cardnumber = "4111111111111111",
                Cardzip = "12345",
                Method = "card",
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**methodId:** `string` — The saved payment method ID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateMethodRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## User
<details><summary><code>client.User.<a href="/src/PayabliApi/User/UserClient.cs">AddUserAsync</a>(UserData { ... }) -> WithRawResponseTask&lt;AddUserResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Use this endpoint to add a new user to an organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.User.AddUserAsync(new UserData());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UserData` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.User.<a href="/src/PayabliApi/User/UserClient.cs">AuthRefreshUserAsync</a>() -> WithRawResponseTask&lt;PayabliApiResponseUserMfa&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Use this endpoint to refresh the authentication token for a user within an organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.User.AuthRefreshUserAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.User.<a href="/src/PayabliApi/User/UserClient.cs">AuthResetUserAsync</a>(UserAuthResetRequest { ... }) -> WithRawResponseTask&lt;AuthResetUserResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Use this endpoint to initiate a password reset for a user within an organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.User.AuthResetUserAsync(new UserAuthResetRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UserAuthResetRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.User.<a href="/src/PayabliApi/User/UserClient.cs">AuthUserAsync</a>(provider, UserAuthRequest { ... }) -> WithRawResponseTask&lt;PayabliApiResponseMfaBasic&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint requires an application API token.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.User.AuthUserAsync("provider", new UserAuthRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**provider:** `string` — Auth provider. This fields is optional and defaults to null for the built-in provider.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UserAuthRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.User.<a href="/src/PayabliApi/User/UserClient.cs">ChangePswUserAsync</a>(UserAuthPswResetRequest { ... }) -> WithRawResponseTask&lt;ChangePswUserResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Use this endpoint to change the password for a user within an organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.User.ChangePswUserAsync(new UserAuthPswResetRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UserAuthPswResetRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.User.<a href="/src/PayabliApi/User/UserClient.cs">DeleteUserAsync</a>(userId) -> WithRawResponseTask&lt;DeleteUserResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Use this endpoint to delete a specific user within an organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.User.DeleteUserAsync(1000000);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `long` — The Payabli-generated `userId` value.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.User.<a href="/src/PayabliApi/User/UserClient.cs">EditMfaUserAsync</a>(userId, MfaData { ... }) -> WithRawResponseTask&lt;EditMfaUserResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Use this endpoint to enable or disable multi-factor authentication (MFA) for a user within an organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.User.EditMfaUserAsync(1000000, new MfaData());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `long` — User Identifier
    
</dd>
</dl>

<dl>
<dd>

**request:** `MfaData` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.User.<a href="/src/PayabliApi/User/UserClient.cs">EditUserAsync</a>(userId, UserData { ... }) -> WithRawResponseTask&lt;PayabliApiResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Use this endpoint to modify the details of a specific user within an organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.User.EditUserAsync(1000000, new UserData());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `long` — User Identifier
    
</dd>
</dl>

<dl>
<dd>

**request:** `UserData` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.User.<a href="/src/PayabliApi/User/UserClient.cs">GetUserAsync</a>(userId, GetUserRequest { ... }) -> WithRawResponseTask&lt;UserQueryRecord&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Use this endpoint to retrieve information about a specific user within an organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.User.GetUserAsync(1000000, new GetUserRequest { Entry = "478ae1234" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `long` — The Payabli-generated `userId` value.
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetUserRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.User.<a href="/src/PayabliApi/User/UserClient.cs">LogoutUserAsync</a>() -> WithRawResponseTask&lt;LogoutUserResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Use this endpoint to log a user out from the system.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.User.LogoutUserAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.User.<a href="/src/PayabliApi/User/UserClient.cs">ResendMfaCodeAsync</a>(usrname, entry, entryType) -> WithRawResponseTask&lt;PayabliApiResponseMfaBasic&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Resends the MFA code to the user via the selected MFA mode (email or SMS).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.User.ResendMfaCodeAsync("Entry", 1, "usrname");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**usrname:** `string` —  
    
</dd>
</dl>

<dl>
<dd>

**entry:** `string` —  
    
</dd>
</dl>

<dl>
<dd>

**entryType:** `int` —  
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.User.<a href="/src/PayabliApi/User/UserClient.cs">ValidateMfaUserAsync</a>(MfaValidationData { ... }) -> WithRawResponseTask&lt;PayabliApiResponseUserMfa&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Use this endpoint to validate the multi-factor authentication (MFA) code for a user within an organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.User.ValidateMfaUserAsync(new MfaValidationData());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `MfaValidationData` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Vendor
<details><summary><code>client.Vendor.<a href="/src/PayabliApi/Vendor/VendorClient.cs">AddVendorAsync</a>(entry, VendorData { ... }) -> WithRawResponseTask&lt;PayabliApiResponseVendors&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a vendor in an entrypoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Vendor.AddVendorAsync(
    "8cfec329267",
    new VendorData
    {
        VendorNumber = "1234",
        Name1 = "Herman's Coatings and Masonry",
        Name2 = "<string>",
        Ein = "12-3456789",
        Phone = "5555555555",
        Email = "example@email.com",
        Address1 = "123 Ocean Drive",
        Address2 = "Suite 400",
        City = "Miami",
        State = "FL",
        Zip = "33139",
        Country = "US",
        Mcc = "7777",
        LocationCode = "MIA123",
        Contacts = new List<Contacts>()
        {
            new Contacts
            {
                ContactName = "Herman Martinez",
                ContactEmail = "example@email.com",
                ContactTitle = "Owner",
                ContactPhone = "3055550000",
            },
        },
        BillingData = new BillingData
        {
            Id = 123,
            BankName = "Country Bank",
            RoutingAccount = "123123123",
            AccountNumber = "123123123",
            TypeAccount = TypeAccount.Checking,
            BankAccountHolderName = "Gruzya Adventure Outfitters LLC",
            BankAccountHolderType = BankAccountHolderType.Business,
            BankAccountFunction = 0,
        },
        PaymentMethod = "managed",
        VendorStatus = 1,
        RemitAddress1 = "123 Walnut Street",
        RemitAddress2 = "Suite 900",
        RemitCity = "Miami",
        RemitState = "FL",
        RemitZip = "31113",
        RemitCountry = "US",
        PayeeName1 = "<string>",
        PayeeName2 = "<string>",
        CustomerVendorAccount = "A-37622",
        InternalReferenceId = 123,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**entry:** `string` — Entrypoint identifier.
    
</dd>
</dl>

<dl>
<dd>

**request:** `VendorData` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Vendor.<a href="/src/PayabliApi/Vendor/VendorClient.cs">DeleteVendorAsync</a>(idVendor) -> WithRawResponseTask&lt;PayabliApiResponseVendors&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a vendor. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Vendor.DeleteVendorAsync(1);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idVendor:** `int` — Vendor ID.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Vendor.<a href="/src/PayabliApi/Vendor/VendorClient.cs">EditVendorAsync</a>(idVendor, VendorData { ... }) -> WithRawResponseTask&lt;PayabliApiResponseVendors&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a vendor's information. Send only the fields you need to update.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Vendor.EditVendorAsync(1, new VendorData { Name1 = "Theodore's Janitorial" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idVendor:** `int` — Vendor ID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `VendorData` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Vendor.<a href="/src/PayabliApi/Vendor/VendorClient.cs">GetVendorAsync</a>(idVendor) -> WithRawResponseTask&lt;VendorQueryRecord&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a vendor's details.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Vendor.GetVendorAsync(1);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**idVendor:** `int` — Vendor ID.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Wallet
<details><summary><code>client.Wallet.<a href="/src/PayabliApi/Wallet/WalletClient.cs">ConfigureApplePayOrganizationAsync</a>(ConfigureOrganizationRequestApplePay { ... }) -> WithRawResponseTask&lt;ConfigureApplePayOrganizationApiResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Configure and activate Apple Pay for a Payabli organization
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Wallet.ConfigureApplePayOrganizationAsync(
    new ConfigureOrganizationRequestApplePay
    {
        Cascade = true,
        IsEnabled = true,
        OrgId = 901,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ConfigureOrganizationRequestApplePay` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Wallet.<a href="/src/PayabliApi/Wallet/WalletClient.cs">ConfigureApplePayPaypointAsync</a>(ConfigurePaypointRequestApplePay { ... }) -> WithRawResponseTask&lt;ConfigureApplePaypointApiResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Configure and activate Apple Pay for a Payabli paypoint
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Wallet.ConfigureApplePayPaypointAsync(
    new ConfigurePaypointRequestApplePay { Entry = "8cfec329267", IsEnabled = true }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ConfigurePaypointRequestApplePay` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Wallet.<a href="/src/PayabliApi/Wallet/WalletClient.cs">ConfigureGooglePayOrganizationAsync</a>(ConfigureOrganizationRequestGooglePay { ... }) -> WithRawResponseTask&lt;ConfigureApplePayOrganizationApiResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Configure and activate Google Pay for a Payabli organization
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Wallet.ConfigureGooglePayOrganizationAsync(
    new ConfigureOrganizationRequestGooglePay
    {
        Cascade = true,
        IsEnabled = true,
        OrgId = 901,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ConfigureOrganizationRequestGooglePay` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Wallet.<a href="/src/PayabliApi/Wallet/WalletClient.cs">ConfigureGooglePayPaypointAsync</a>(ConfigurePaypointRequestGooglePay { ... }) -> WithRawResponseTask&lt;ConfigureGooglePaypointApiResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Configure and activate Google Pay for a Payabli paypoint
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Wallet.ConfigureGooglePayPaypointAsync(
    new ConfigurePaypointRequestGooglePay { Entry = "8cfec329267", IsEnabled = true }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ConfigurePaypointRequestGooglePay` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>
