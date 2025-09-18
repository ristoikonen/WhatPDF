namespace WhatPDF.Web;
using System.IO;

public class WeatherApiClient(HttpClient httpClient)
{
    public async Task<WeatherForecast[]> GetWeatherAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<WeatherForecast>? forecasts = null;

        await foreach (var forecast in httpClient.GetFromJsonAsAsyncEnumerable<WeatherForecast>("/weatherforecast", cancellationToken))
        {
            if (forecasts?.Count >= maxItems)
            {
                break;
            }
            if (forecast is not null)
            {
                forecasts ??= [];
                forecasts.Add(forecast);
            }
        }

        return forecasts?.ToArray() ?? [];
    }

    public async Task PostPdf(CancellationToken cancellationToken = default)
    {
        //byte[] pdfBytes = File.ReadAllBytes("path/to/your/document.pdf"); // Load PDF into byte array

        // Create a MemoryStream from the byte array
        //using (MemoryStream memoryStream = new MemoryStream(pdfBytes))
        //{
            // Now 'memoryStream' contains the PDF data
        //}

      
        using (FileStream pdfStream = new FileStream(@"Resources/Gitti.pdf", FileMode.Open, FileAccess.Read))
        {
            await httpClient.PostAsync("/uploadpdf", new StreamContent(pdfStream), cancellationToken);

            // Now 'pdfStream' can be used to read the PDF data
            // For example, you could copy it to a MemoryStream or send it over a network
            //await httpClient.PostAsync<HttpResponseMessage>("/uploadpdf", new StreamContent(pdfStream), cancellationToken);
            //.PostAsync<FileStream>("/weatherforecast", pdfStream);
            //using Stream requestBody = HttpContext.Request.Body;
        }


        return;
    }

}

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
