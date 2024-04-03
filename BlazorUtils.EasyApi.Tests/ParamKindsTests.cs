﻿using BlazorUtils.EasyApi.Tests.SUT.Contract;
using BlazorUtils.EasyApi.Tests.SUT.Server;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorUtils.EasyApi.Tests;

public abstract class ParamKindsTests(WebApplicationFactory<Program> factory) : TestsBase(factory)
{
    [Fact]
    public async Task Request_WithHeaderParams()
    {
        var request = new HeaderParamRequest()
        {
            Number = 1,
            Text = "text",
            Struct = new()
            {
                Amount = 9.99M,
                Currency = "USD"
            },
            Class = new()
            {
                Name = "T-Shirt",
                Price = 9.99,
                StockQuantity = 100,
                CreatedAt = DateTime.UtcNow
            }
        };
        await CallHttp(request);
    }

    [Fact]
    public async Task Request_WithRouteParams()
    {
        var request = new RouteParamRequest()
        {
            Number = 1,
            Text = "text",
            Struct = new()
            {
                Amount = 9.99M,
                Currency = "USD"
            },
            Class = new()
            {
                Name = "T-Shirt",
                Price = 9.99,
                StockQuantity = 100,
                CreatedAt = DateTime.UtcNow
            }
        };
        await CallHttp(request);
    }

    [Fact]
    public async Task Request_WithQueryStringParams()
    {
        var request = new QueryStringParamRequest()
        {
            Number = 1,
            Text = "text",
            Struct = new()
            {
                Amount = 9.99M,
                Currency = "USD"
            },
            Class = new()
            {
                Name = "T-Shirt",
                Price = 9.99,
                StockQuantity = 100,
                CreatedAt = DateTime.UtcNow
            }
        };
        await CallHttp(request);
    }

    [Fact]
    public async Task Request_WithBodyParams()
    {
        var request = new BodyParamRequest()
        {
            Number = 1,
            Text = "text",
            Struct = new()
            {
                Amount = 9.99M,
                Currency = "USD"
            },
            Class = new()
            {
                Name = "T-Shirt",
                Price = 9.99,
                StockQuantity = 100,
                CreatedAt = DateTime.UtcNow
            }
        };
        await CallHttp(request);
    }
}

public class Client_ParamKindsTests(WebApplicationFactory<Program> factory) : ParamKindsTests(factory)
{
    protected override ICall<Request> GetCaller<Request>() => _client.Services.GetRequiredService<ICall<Request>>();

    protected override ICall<Request, Response> GetCaller<Request, Response>() => _client.Services.GetRequiredService<ICall<Request, Response>>();
}

public class Server_ParamKindsTests(WebApplicationFactory<Program> factory) : ParamKindsTests(factory)
{
    protected override ICall<Request> GetCaller<Request>() => _server.Services.GetRequiredService<ICall<Request>>();

    protected override ICall<Request, Response> GetCaller<Request, Response>() => _server.Services.GetRequiredService<ICall<Request, Response>>();
}
