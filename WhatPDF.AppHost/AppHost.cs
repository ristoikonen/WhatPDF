using Amazon;
//using Aspire.Hosting.AWS.

var builder = DistributedApplication.CreateBuilder(args);

var awsConfig = builder.AddAWSSDKConfig()
                        .WithProfile("dev")
                        .WithRegion(RegionEndpoint.APSoutheast2);



//var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.WhatPDF_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.WhatPDF_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    //.WithReference(cache)
    //.WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
