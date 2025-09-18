using OpenTelemetry.Resources;
using System.Runtime.Intrinsics.X86;
using WhatPDF.Web.Components.Pages;
using static System.Net.Mime.MediaTypeNames;

namespace WhatPDF.Web.Models;

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

    //ONE FILE FOR ONE PDF ADD PLAIN TEXT FIELDS:	ORIG FILENAME
    //DOCS SUMMARY, IF HAS, LIMITED LEN   SOURCE URI, DATE, PAGE COUNT, SIZE...
    //-- REMEBER TO USE LZ-COMPRESSOR

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

    }
