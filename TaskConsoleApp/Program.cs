// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");


var myTask = new HttpClient().GetStringAsync("https://www.google.com/").ContinueWith((data) =>
{
    Console.WriteLine(data.Result.Length);
    Console.WriteLine("Arada yapilacak isler");
});

await myTask;
