using Microsoft.Extensions.Hosting;
using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using ModelContextProtocol.Server;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
       .AddMcpServer()
       .WithStdioServerTransport()
       .WithToolsFromAssembly();

var host = builder.Build();
await host.RunAsync();


[McpServerToolType]
public static class DotnetUtils
{
    [McpServerTool, Description("Gets the current time.")]
    public static string GetCurrentTime() => DateTimeOffset.Now.ToString();
    
    [McpServerTool, Description("Generates a guid.")]
    public static string GetGuid() => Guid.NewGuid().ToString();
}