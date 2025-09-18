using WhatPDF.ApiService.Endpoints;
using WhatPDF.ApiService.Models;

namespace WhatPDF.ApiService.Services
{
    public interface IPdfHandler
    {
        //Task HandleFileSelectedAsync(byte[] pdf, PdfHandlingModel pdfHandlingModel)
        Task<PDFData?> HandleFileSelectedAsync(byte[] pdf, PdfHandlingModel pdfHandlingModel);
    }
}
