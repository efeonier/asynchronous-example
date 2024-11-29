namespace TaskConsoleApp;

public abstract class WhenAllExample {
    public async static Task Run(List<string> urls)
    {
        List<Task<Content>> tasks = [];
        Console.WriteLine("WhenAllExample thread:" + Environment.CurrentManagedThreadId);
        tasks.AddRange(urls.Select(GetContentAsync));
        var result = Task.WhenAll(tasks);
        var data = await result;
        foreach (var item in data){
            Console.WriteLine(item.Site + " " + item.Length);
        }
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
        var data = await new HttpClient().GetStringAsync(url);
        c.Site = url;
        c.Length = data.Length;
        Console.WriteLine("GetContentAsync thread:" + Environment.CurrentManagedThreadId);
        return c;
    }
}
