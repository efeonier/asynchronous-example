namespace TaskConsoleApp;

public static class WaitAllExample {
    public async static Task Run(List<string> urls)
    {
        List<Task<Content>> tasks = [];
        Console.WriteLine("WaitAllExample thread:" + Environment.CurrentManagedThreadId);
        urls.ToList().ForEach(x => {
            tasks.Add(GetContentAsync(x));
        });
        Console.WriteLine("WaitAll Methodundan önce");
        var result = Task.WaitAll(tasks.ToArray<Task>(), 3000);
        Console.WriteLine("3 saniyede geldi mi:" + result);
        Console.WriteLine("WaitAll Methodundan sonra");
        var data = await Task.WhenAll(tasks);
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
