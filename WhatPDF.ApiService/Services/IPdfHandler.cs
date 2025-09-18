using WhatPDF.ApiService.Endpoints;
using WhatPDF.ApiService.Models;

namespace WhatPDF.ApiService.Services
{
    public interface IPdfHandler
    {
        Task<PDFData?> HandleFileSelectedAsync(byte[] pdf, PdfHandlingModel pdfHandlingModel);
    }
}
