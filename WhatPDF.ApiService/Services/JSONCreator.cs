using WhatPDF.ApiService.Endpoints;

namespace WhatPDF.ApiService.Services
{
    public class JSONCreator : IJSONCreator
    {
        public Task<string?> CreateJSONAsync(JSONCreatorModel JSONCreatorModel)
        { 
            return Task.FromResult<string?>(string.Empty);
        }
    }
}
