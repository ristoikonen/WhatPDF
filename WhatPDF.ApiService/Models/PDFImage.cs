namespace WhatPDF.ApiService.Models;

public class PDFImage
{
    // A list to hold multiple images, each as a separate object
    public List<ImageData> Images { get; set; } = [];

    public void AddImage(byte[] img, string type, string name)
    {
        Images.Add(new ImageData { Data = img, Type = type, Name = name });
    }

    // A nested class to represent a single image with its data and metadata
    public class ImageData
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}
