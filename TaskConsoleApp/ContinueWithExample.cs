namespace TaskConsoleApp;

public abstract class ContinueWithExample {
    
    public static void Run()
    {
        var myTask = new HttpClient().GetStringAsync("https://www.google.com/").ContinueWith((data) => {
            Console.WriteLine(data.Result.Length);
            Console.WriteLine("Arada yapilacak isler");
        });
        myTask.Wait();
    }
}
