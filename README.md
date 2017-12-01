# SerialNumbers
Serial Numbers is the C# serial numbers provider. It provides string serial numbers in predefined format.

## Changes
You can find last changes in [Change Log](./ChangeLog.md).

## Install

There is only one NuGet packages - `SerialNumbers` contains the public API to provide serial numbers business logic. 
```
    nuget install SerialNumbers
```
## Application Startup

At the application start we have to configure services to use SerialNumbers components. We can do that using following extensions methods for `IServiceCollection`.
```c#
    var services = new ServiceCollection();
    
    services.AddSerialNumbers(Configuration.GetConnectionString(SerialNumberConstants.SERIAL_NUMBERS_CONNECTION));
    services.AddSerialNumbersLocalDateTimeProvider();
    -- services.AddSerialNumbersUtcDateTimeProvider();
```
When services are configured we have to call method `BuildSerialNumbersDatabase` to init database by EF migration. We can do that as you can see below.
```c#
    var serviceProvider = services.BuildServiceProvider();
    serviceProvider.BuildSerialNumbersDatabase();
```

## Public API

```c#
namespace SerialNumbers.Business
{
    /// <summary>
    /// Provides public API to manage serial numbers.
    /// </summary>
    public interface ISerialNumberService
    {
        /// <summary>
        /// Creates the new schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="mask">The mask.</param>
        /// <param name="seed">The seed.</param>
        /// <param name="increment">The increment.</param>
        /// <returns>The created schema.</returns>
        ISerialNumberSchema CreateSchema(string schema, string customer, string mask, int seed = 0, int increment = 1);

        /// <summary>
        /// Gets the current schema value.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="args">The optional arguments.</param>
        /// <returns>The current schema value.</returns>
        string Current(string schema, string customer, string subject, params string[] args);

        /// <summary>
        /// Deletes the schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        void DeleteSchema(string schema, string customer);

        /// <summary>
        /// Gets the schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        /// <returns>The schema.</returns>
        ISerialNumberSchema GetSchema(string schema, string customer);

        /// <summary>
        /// Gets the next schema value.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="args">The optional arguments.</param>
        /// <returns>The next schema value.</returns>
        string Next(string schema, string customer, string subject, params string[] args);

        /// <summary>
        /// Resets the specified schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="subject">The subject.</param>
        void Reset(string schema, string customer, string subject);

        /// <summary>
        /// Updates the schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="mask">The mask.</param>
        /// <param name="seed">The seed.</param>
        /// <param name="increment">The increment.</param>
        /// <returns>The updated schema.</returns>
        ISerialNumberSchema UpdateSchema(string schema, string customer, string mask, int seed, int increment);
    }
}
```

## Usage

In order to use the following functions, we need to add the dependency on the interface `ISerialNumberService` in my consumer class.

### Step 1

At the first step we have to create a new schema (including schema definiton) for serial numbers. 
The schema is created per customer and it is identified by schema name and customer name. 
Both values have to be unique, but schema name is unique per customer.

```c#
    var schema = "Sequence for user identifiers"; // it can be some fixed GUID or something like that
    var customer = "MyCompany";
    var mask = "USER{0:0000}"; // format which has to be used by string.Format() method, this value has to contain at least one parameter placeholder {0} 
    var seed = 1; // initial value
    var increment = 1; // it can be positive or negative, based on this value the serial number value provided by API s are ascending or descending

    _serialNumberService.CreateSchema(schema, customer, mask, seedAsInt, incrementAsInt);
```

The schema defined by example above describes the serial numbers for user identifying. Each user in *MyCompany* gets the new user number which consists from prefix *USER* 
followed by 4 digits number value (I presume that there will be max 9999 users).

### Step 2

At the next step we probably want to get the new serial number value (next in the sequence).
We can do that using following method.

```c#
    var schema = "Sequence for user identifiers";
    var customer = "MyCompany";
    var subject = "User"; // it is a subject of the schema (serial numbers sequence)
    string[] args = null; // optional params, these values are used in underlying string.Format() function - their count must equal to count of optional parameter (except the firts one required parameter {0})

    var value = _serialNumberService.Next(schema, customer, subject.Value, args);
    Console.WriteLine($"The new serial number value for {subject} is: {value}");
```

## Optional scenarios

- We want to check whether the schema with specified values exist
```c#
    var result = _serialNumberService.GetSchema(schema, customer);
```
- We want to delete the existing schema (e.g. we created incorrect schema in the past)
```c#
    _serialNumberService.DeleteSchema(schema, customer);
```
- We want to update the existing schema. In that case the new internal schema definition is created. 
All serial number values which were got from original schema definition will stay in the underlying database. 
But the new serial numbers sequence will be started.
```c#
    var result = _serialNumberService.UpdateSchema(schema, customer, mask, seed, increment);
```
- We want to check the current serial number value (for subject)
```c#
    var current = _serialNumberService.Current(schema, customer, subject, args); // optional params, see Next method usage
    Console.WriteLine($"The current serial number value for {subject} is: {current}");
```
- We want to reset existing serial number values for subject. In that case all existing serial number 
values for specified subject will be deleted from underlying database (only for current internal schema definition - it is the last one for that schema).
```c#
    _serialNumberService.Reset(schema, customer, subject);
```

## Samples

Below you can see some examples of serial numbers format

| Mask              | Value (from DB)   | Args          | Result                | Comment |
|-------------------|-------------------|---------------|-----------------------|---------|
| {0}               | 1                 |               | "1"                   | Plain value |
| P{0}              | 100               |               | "P100"                | Plain value with prefix 'P' |
| INV-{0}/{1}       | 10                | "2017"        | "INV-10/2017"         | Invoice sequence, by year suffix |
| INV-{0}/{1}-{2}   | 1780              | "2017", "Ext" | "INV-1780/2017-Ext"   | Invoice sequence, by year and 'Ext' suffix |
| USER{0:0000}      | 20                |               | "USER0020"            | User identifier, 4 digits number part |
| USER{0:0000}-{1}  | 20                | "Europe"      | "USER0020-Europe"     | User identifier, 4 digits number part with region 'Europe' suffix |
| HS-{0}/{1}        | 102063            | "Headphones"  | "HS-102063/Headphones"| Product code 'HS' in category 'Headphones' as suffix |