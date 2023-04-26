# Addressables.NET

A standalone version of `Unity.Addressables` for extracting addressable assets.


Addressables.NET is targeting `.NET Standard 2.1` and have removed any Unity-specific code, retaining only the necessary code for reading addressables metadata.

It provides alternative APIs or placeholder methods to replace unsupported APIs (such as Unity's JSON serialization).


**⚠️This library CANNOT do assets extraction, you need an extra lib to extract assetbundles like [AssetsTools.NET](https://github.com/nesrak1/AssetsTools.NET).**

## Quick Start

Before extracting assets, you need to locate the `catalog.json` file. Typically, for Android APKs, it is located at `assets/aa/catalog.json`.

```csharp
var catalogjson = File.ReadAllText("path/to/catalog.json");
var catalogData = JsonConvert.DeserializeObject<ContentCatalogData>(catalogjson);
var map = catalogData.CreateLocator();
foreach (var (key, locations) in map.Locations)
{
  var locationKeys = string.Join(",", locations.Select(x => x.PrimaryKey));
  Console.WriteLine($"{key}: {locationKeys}");
}

```