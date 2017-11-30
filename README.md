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

TBD

## Samples

TBD