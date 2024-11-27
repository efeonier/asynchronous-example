namespace TaskConsoleApp;

public static class ContinueWithExample {
    public async static Task Run()
    {
        Console.WriteLine("ContinueWithExample thread:" + Environment.CurrentManagedThreadId);
        var myTask = new HttpClient().GetStringAsync("https://www.google.com/").ContinueWith((data) => {
            Console.WriteLine(data.Result.Length);
            Console.WriteLine("Arada yapilacak isler");
        });
        await myTask;
    }
}
