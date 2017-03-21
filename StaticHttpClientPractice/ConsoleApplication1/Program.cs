//Author - Crayton McIntosh
//Description - learn more about httpclient to determing whether 
//				using static httpclient for requests/responses is better than "using httpclient" and creating multiple instances you throw away

using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			Task t = new Task(DownloadPageAsync);
			t.Start();
			Console.WriteLine("Downloading page...");
			Console.ReadLine();
		}

		static async void DownloadPageAsync()
		{
			string page = "http://en.wikipedia.org/";

			using (HttpClient client = new HttpClient())
			using (HttpResponseMessage response = await client.GetAsync(page))
			using (HttpContent content = response.Content)
			{
				string result = await content.ReadAsStringAsync();

				if (result != null && result.Length >= 50)
				{
					Console.WriteLine(result.Substring(0, 50) + "...");
				}
			}
		}
	}
}
