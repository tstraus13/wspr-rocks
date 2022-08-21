using WSPR.Rocks.Client;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var client = new WsprRocksClient();

var test = await client.Search();

foreach (var data in test.Spots)
{
    Console.WriteLine(data.TxSign);
}
