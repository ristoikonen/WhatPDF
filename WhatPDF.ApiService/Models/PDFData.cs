using OpenTelemetry.Resources;
using System.Runtime.Intrinsics.X86;


//using WhatPDF.Web.Components.Pages;
using static System.Net.Mime.MediaTypeNames;

namespace WhatPDF.ApiService.Models;

public class PDFData
{
    public PDFData()
    {
        Pages = [];
        Summary = [];
    }
    //
    public List<string>? Pages  { get; set; }
    public byte[]? Data  { get; set; }
    public List<string>? Summary { get; set; }
    public List<PDFImage>? Images  { get; set; }
    public string OriginalFileName { get; set; } = string.Empty;
    public Uri? Source { get; set; }
    public DateTime? ReadDate { get; set; } = DateTime.Now;

    public string? Text { get; set; }

}
