namespace TaskConsoleApp;

public static class WhenAnyExample {
    public async static Task Run(List<string> urls)
    {
        List<Task<Content>> tasks = [];
        Console.WriteLine("Main WhenAny thread:" + Environment.CurrentManagedThreadId);
        urls.ToList().ForEach(x => tasks.Add(GetContentAsync(x)));
        var firstResult = await Task.WhenAny(tasks).Result;
        Console.WriteLine(firstResult.Site + " " + firstResult.Length);
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
