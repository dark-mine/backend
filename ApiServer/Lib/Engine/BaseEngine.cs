using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiServer.Lib.Engine
{
	public class BaseEngine
	{
		protected static async Task<T> MakeRequest<T>(string apiKey, string requestString) where T : class
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Add("X-Redmine-API-Key", apiKey);
				var responseString = client.GetStringAsync("http://helpdesk.nemo.travel" + requestString);

				return JsonConvert.DeserializeObject<T>(await responseString);
			}
		}
	}
}
