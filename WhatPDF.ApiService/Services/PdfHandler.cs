using Microsoft.AspNetCore.Components.Forms;
using WhatPDF.ApiService.Endpoints;
using WhatPDF.ApiService.Models;

namespace WhatPDF.ApiService.Services;

public static class PdfHandler
{
    public static async Task<PDFData?> HandleFileSelectedAsync(byte[] pdf, PdfHandlingModel pdfHandlingModel)
    {
        bool conmpress = pdfHandlingModel.Compress;
        bool readimages = pdfHandlingModel.ReadImages;
        bool removestopwords = pdfHandlingModel.RemoveStopwords;
        string filename = pdfHandlingModel.FileName ?? "unknown.pdf";

        string textchunk = "";
        List<string>? textblocks = new List<string>();
        PDFData? pdfdata = null;


        if (pdf is not null && pdf.Length > 1)
        {
            //var buffer = pdf;
            await Task.Delay(100);

            using (var memoryStream = new MemoryStream(pdf))
            {
                //await file.OpenReadStream(file.Size).CopyToAsync(memoryStream);

                //await Task.Delay(100);

                var byteArray = memoryStream.ToArray();

                Reader reader = new Reader();

                pdfdata = reader.ReadPdfData(byteArray, filename);

                if (pdfdata is not null && pdfdata is PDFData && pdfdata.Pages is not null)
                {
                    textchunk = string.Join(Environment.NewLine, pdfdata.Pages);
                }
            }
        }

        await Task.Delay(100);

        return pdfdata;
        // Process each file here, e.g., read its content, save to server
        // Example: Read file to a byte array
        // var buffer = new byte[file.Size];
        // await file.OpenReadStream().ReadAsync(buffer);

        // Example: Save to wwwroot/Uploads
        // var path = Path.Combine(env.WebRootPath, "uploads", file.Name);
        // await using FileStream fs = new(path, FileMode.Create);
        // await file.OpenReadStream().CopyToAsync(fs);
        //}
    }

}
