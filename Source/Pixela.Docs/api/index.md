# Pixela for .NET Standard API Documentation

Install Pixela for .NET Standard from NuGet

```
PM> Install-Package Pixela
```

and then

```csharp
using Pixela;
using Pixela.Enums;
```

```csharp
// create a user
var client = new PixelaClient();
await client.Users.CreateAsync("SECRET", "your_username", true, true);

// ..or use existing user
var client = new PixelaClient("your_username", "SECRET");

// create a graph definition
var graphId = "test";
await client.Graphs.CreateAsync(graphId, "Test Graph", "commit", GraphType.Int, GraphColor.Sora);

// browse the graph
Process.Start(await client.Graphs.DetailsAsync(graphId));

// get graphs
var graphs = await client.Graphs.ListAsync();

// update graph
await client.Graphs.UpdateAsync(graphId, "Test Graph", "commit", GraphColor.Ichou);

// delete graph
await client.Graphs.DestroyAsync(graphId);

// record new pixel
var at = DateTime.Today.AddDays(-1);
await client.Pixel.CreateAsync(graphId, at, 5);

// get pixel
var pixel = await client.Pixel.ShowAsync(graphId, at);

// update quantity
await client.Pixel.UpdateAsync(graphId, at, 10);

// increment today quantity
await client.Pixel.IncrementAsync(graphId);

// decrement today quantity
await client.Pixel.DecrementAsync(graphId);

// destroy pixel
await client.Pixel.DestroyAsync(graphId, at);
```
