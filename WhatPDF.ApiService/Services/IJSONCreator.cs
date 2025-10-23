using WhatPDF.ApiService.Endpoints;

namespace WhatPDF.ApiService.Services
{
    public interface IJSONCreator
    {
        public Task<string?> CreateJSONAsync(JSONCreatorModel JSONCreatormodel);
    }

    public interface IJSONvalidator
    {
        public Task<bool?> ValidateJSONAsync(JSONValidatorModel JSONValidatormodel);
    }
}
