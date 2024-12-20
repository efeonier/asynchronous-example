namespace TaskConsoleApp;

public class WaitAnyExample {
    public async static Task Run(List<string> urls)
    {
        List<Task<Content>> tasks = [];
        Console.WriteLine("WaitAnyExample thread:" + Environment.CurrentManagedThreadId);
        urls.ToList().ForEach(x => {
            tasks.Add(GetContentAsync(x));
        });
        Console.WriteLine("WaitAny Methodundan önce");
        var firstResult = Task.WaitAny(tasks.ToArray<Task>());
        Console.WriteLine("WaitAny Methodundan sonra");
        var data = await tasks[firstResult];
        Console.WriteLine(data.Site + " " + data.Length);
      
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
