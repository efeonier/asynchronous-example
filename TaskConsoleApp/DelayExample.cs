using System.Globalization;

namespace TaskConsoleApp;

public abstract class DelayExample {
    private readonly static HttpClient Client = new();

    public async static Task Run(List<string> urls)
    {
        List<Task<Content>> tasks = [];
        Console.WriteLine("DelayExample thread:" + Environment.CurrentManagedThreadId);
        tasks.AddRange(urls.Select(GetContentAsync));
        var result = await Task.WhenAll(tasks);
        result.ToList().ForEach(x => {
            Console.WriteLine(x.Site + " " + x.Length);
        });
    }

    private sealed class Content {
        public required string Site { get; set; } = null!;
        public int Length { get; set; }
    }

    private async static Task<Content> GetContentAsync(string url)
    {
        var c = new Content
        {
            Site = null!
        };
        var data = await Client.GetStringAsync(url);
        await Task.Delay(5000);
        c.Site = url;
        c.Length = data.Length;
        Console.WriteLine("GetContentAsync thread:" + Environment.CurrentManagedThreadId + " Time Second:" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
        return c;
    }
}
