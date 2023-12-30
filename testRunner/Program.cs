using System.Text;
using testRunner;

while (true)
{
    Console.WriteLine("enter count of tests:");
    var count = int.Parse(Console.ReadLine()!);

    var httpClient = new HttpClient();
    var reader = new StreamReader(@"C:\Users\Radshid\Desktop\New folder\asd.txt");
    var content = new StringContent(reader.ReadToEnd(), Encoding.UTF8, "application/json");

    var newWithSemaphoreElapsedTime = new List<long>();

    for (var i = 0; i < count; i++)
        newWithSemaphoreElapsedTime.Add(await Caller.NewApiWithSemaphore(httpClient, content, i));

    Console.WriteLine("avgWithSemaphore:" + newWithSemaphoreElapsedTime.Average());
}