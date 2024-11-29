using Microsoft.Extensions.Configuration;
using TaskConsoleApp;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
IConfigurationRoot configuration = builder.Build();
var urls = configuration.GetSection("Urls").AsEnumerable().Where(w => w.Value != null).Select(s => s.Value?.ToString() ?? string.Empty).ToList();
//await ContinueWithExample.Run(urls);
//await WhenAllExample.Run(urls);
//await WhenAnyExample.Run(urls);
//await WaitAllExample.Run(urls);
//await WaitAnyExample.Run(urls);
await DelayExample.Run(urls);
