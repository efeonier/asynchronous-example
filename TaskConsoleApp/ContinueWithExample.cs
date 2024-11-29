namespace TaskConsoleApp;

public static class ContinueWithExample {
    public async static Task Run(List<string> urls)
    {
        Console.WriteLine("ContinueWithExample thread:" + Environment.CurrentManagedThreadId);
        var myTask = new HttpClient().GetStringAsync(urls.FirstOrDefault()).ContinueWith((data) => {
            Console.WriteLine(data.Result.Length);
            Console.WriteLine("Arada yapilacak isler");
        });
        await myTask;
    }
}
