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
            string fileName = args[0];
            if(string.IsNullOrEmpty(fileName)){
                Console.WriteLine("No file given.");
                return;
            }

            var file = new FileInfo(fileName);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://transfer.sh");

            var req = new HttpRequestMessage(HttpMethod.Put, file.Name);
            req.Content = new ByteArrayContent(await File.ReadAllBytesAsync(file.FullName));


            var res = await client.SendAsync(req);
            var resbody = await res.Content.ReadAsStringAsync();

            Console.WriteLine($"They wrote back: {res.StatusCode}, {resbody}");
        }
    }
}
