using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace sharpfer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://transfer.sh");

            var req = new HttpRequestMessage(HttpMethod.Put, "Program.cs");
            req.Content = new ByteArrayContent(await File.ReadAllBytesAsync("Program.cs"));


            var res = await client.SendAsync(req);
            var resbody = await res.Content.ReadAsStringAsync();

            Console.WriteLine($"They wrote back: {res.StatusCode}, {resbody}");
        }
    }
}
