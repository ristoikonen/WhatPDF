namespace WhatPDF.ApiService.Endpoints;

public class PdfHandlingModel
{
    public bool ReadImages { get; set; } = true;
    public bool RemoveStopwords { get; set; } = false;
    public bool Compress { get; set; } = true;
    public string FileName { get; set; } = "";
}
