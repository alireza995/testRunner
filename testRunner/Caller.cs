using System.Diagnostics;

namespace testRunner;

public class Caller
{
    public static async Task<long> NewApiWithSemaphore(HttpClient httpClient, StringContent content, int index)
    {
        var sw = new Stopwatch();
        sw.Start();
        Console.WriteLine($"number {index + 1} started");
        var res = 
            await httpClient.PostAsync("http://localhost:5295/Test/NewApiWithSemaphore/" + index, content);
        
        sw.Stop();
        Console.WriteLine($"number {index + 1} finished in {sw.ElapsedMilliseconds} ms");

        return res.IsSuccessStatusCode ? sw.ElapsedMilliseconds : 0;
    }
}