# Payabli C# Library

[![fern shield](https://img.shields.io/badge/%F0%9F%8C%BF-Built%20with%20Fern-brightgreen)](https://buildwithfern.com?utm_source=github&utm_medium=github&utm_campaign=readme&utm_source=https%3A%2F%2Fgithub.com%2Fpayabli%2Fsdk-csharp)
[![nuget shield](https://img.shields.io/nuget/v/PayabliApi)](https://nuget.org/packages/PayabliApi)

The Payabli C# library provides convenient access to the Payabli APIs from C#.

## Documentation

API reference documentation is available [here](https://docs.payabli.com).

## Requirements

This SDK requires:

## Installation

```sh
dotnet add package PayabliApi
```

## Usage

Instantiate and use the client with the following:

```csharp
using PayabliApi;

var client = new PayabliApiClient("API_KEY");
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
                CardHolder = "Kassiane Cassian",
                Cardnumber = "4111111111111111",
                Cardzip = "12345",
                Initiator = "payor",
                Method = "card",
            },
        },
    }
);
```

## Exception Handling

When the API returns a non-success status code (4xx or 5xx response), a subclass of the following error
will be thrown.

```csharp
using PayabliApi;

try {
    var response = await client.MoneyIn.GetpaidAsync(...);
} catch (PayabliApiApiException e) {
    System.Console.WriteLine(e.Body);
    System.Console.WriteLine(e.StatusCode);
}
```

## Advanced

### Retries

The SDK is instrumented with automatic retries with exponential backoff. A request will be retried as long
as the request is deemed retryable and the number of retry attempts has not grown larger than the configured
retry limit (default: 2).

A request is deemed retryable when any of the following HTTP status codes is returned:

- [408](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/408) (Timeout)
- [429](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/429) (Too Many Requests)
- [5XX](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/500) (Internal Server Errors)

Use the `MaxRetries` request option to configure this behavior.

```csharp
var response = await client.MoneyIn.GetpaidAsync(
    ...,
    new RequestOptions {
        MaxRetries: 0 // Override MaxRetries at the request level
    }
);
```

### Timeouts

The SDK defaults to a 30 second timeout. Use the `Timeout` option to configure this behavior.

```csharp
var response = await client.MoneyIn.GetpaidAsync(
    ...,
    new RequestOptions {
        Timeout: TimeSpan.FromSeconds(3) // Override timeout to 3s
    }
);
```

## Contributing

While we value open-source contributions to this SDK, this library is generated programmatically.
Additions made directly to this library would have to be moved over to our generation code,
otherwise they would be overwritten upon the next generated release. Feel free to open a PR as
a proof of concept, but know that we will not be able to merge it as-is. We suggest opening
an issue first to discuss with us!

On the other hand, contributions to the README are always very welcome!
## Reference

A full reference for this library is available [here](https://github.com/payabli/sdk-csharp/blob/HEAD/./reference.md).
