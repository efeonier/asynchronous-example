namespace TaskConsoleApp;

public abstract class WhenAllExample {
    public static void Run()
    {
        List<string> urls = ["https://www.google.com/", "https://www.microsoft.com/", "https://www.amazon.com/", "https://www.apple.com/", "https://www.haberturk.com/"];
        List<Task<Content>> tasks = [];
        Console.WriteLine("Main thread:" + Environment.CurrentManagedThreadId);
        tasks.AddRange(urls.Select(GetContentAsync));
        var result = Task.WhenAll(tasks);
        var data = result.Result;
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
