using System.Text;
using WhatPDF.ApiService.Endpoints;
using WhatPDF.ApiService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Register a transient service
//builder.Services.AddTransient<IQuickLZ, QuickLZ>();

// Register a scoped service
builder.Services.AddScoped<IPdfHandler, PdfHandler>();

// We can register QuickLZ as singleton service as it's Compress and Decompress methods only operate on the passed-in data and local variables
builder.Services.AddSingleton<IQuickLZ, QuickLZ>();

builder.Services.AddSingleton<HashSet<string>>(StopWords.GetStopWordSet());
// Example use of the StopWords -service
// var words = text.ToLowerInvariant().Split(' ');
// return words.Where(word => !_stopWords.Contains(word)).ToList();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapPost("/uploadpdf", async (IPdfHandler pdfHandler, Stream requestBody) =>
{
    if (requestBody == null)
    {
        return Results.BadRequest("Request body is empty.");
    }

    PdfHandlingModel pdfHandlingModel = new PdfHandlingModel
    {
        Compress = true,
        ReadImages = false,
        RemoveStopwords = true,
        FileName = "uploaded.pdf"
    };

    byte[] requestBodyBytes;
    using (var memoryStream = new MemoryStream())
    {
        await requestBody.CopyToAsync(memoryStream);
        requestBodyBytes = memoryStream.ToArray();
        //pdfHandler = new ();
        pdfHandler.HandleFileSelectedAsync(requestBodyBytes, pdfHandlingModel).Wait();

    }

    // Read the stream content
    //using var reader = new StreamReader(requestBody, Encoding.UTF8);
    //var content = await reader.ReadToEndAsync();

    return Results.Ok("File uploaded successfully.");
});


app.MapDefaultEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
