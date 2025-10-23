//Use JsonNode, JsonObject, and JsonArray from the
using System.Text.Json;
using System.Text.Json.Nodes;

namespace WhatPDF.ApiService.Endpoints;

public class JSONCreatorModel
{
    public string FileName { get; set; } = "";

    public List<Dictionary<string, string>> Data { get; set; } = new();

    public List<JsonNode> Nodes { get; set; } = new();

    public void AddEntry(string keyName, string valueName, string key, string value)
    {
        var entry = new Dictionary<string, string>
        {
            { keyName, key },
            { valueName, value }
        };
        Data.Add(entry);
    }
}

public class JSONValidatorModel
{
    public string FileName { get; set; } = "";

    public string? Content { get; set; }

}

public class JSONCreatorHelper
{
    public List<Dictionary<string, string>> Data { get; set; } = new();

    public void AddEntry(string key, string value)
    {
        var entry = new Dictionary<string, string>
        {
            { "Key", key },
            { "Value", value }
        };
        Data.Add(entry);
    }
}

public class JSONCreatorNodeHelper
{
    public List<JsonNode> Nodes { get; set; } = new();

    // usually: parent = null;
    public void AddNode(JsonNode parent, JsonNode entry)
    {
        
        Nodes.Add(entry);
    }
}

