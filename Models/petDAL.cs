using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using RestSharp;



namespace PetAPITest.Models
{
	public class petDAL
	{

		private static HttpClient _realClient = null;
		public static HttpClient MyHttp
		{
			get
			{
				if (_realClient == null)
				{
					_realClient = new HttpClient();
					_realClient.BaseAddress = new Uri("https://api.petfinder.com/v2/"); // ADD YOUR OWN BASE ADDRESS HERE
					string access_token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiJKZEZoaTdiekZvWDJwcW5WOFMwNFpZenBhS2pmcnRrbUpXNndHQk9UQlFVOGptbHRCWiIsImp0aSI6ImEzOWNlNzQwYjM4ZTMwZTkyMjRhNTAyZjNiNzZjZDdhYmFhMzI3M2JlZTU0Y2ViZTgxNjdhZjUxMzQxODc0ZTQ4NjE1ZGFhN2EyYTU5NDYxIiwiaWF0IjoxNjcwMDE3Nzc1LCJuYmYiOjE2NzAwMTc3NzUsImV4cCI6MTY3MDAyMTM3NSwic3ViIjoiIiwic2NvcGVzIjpbXX0.bXSbVUuO4oNvtpQFS28uzQ10TRxyqKRzD0BsnZhjTVu0p6XXF0ND1hEb8vAPhmtMmReGxbHZ07SPWQi98f5rfEVuQu43meBifzk8vUkj7v7VJ8HfHm6OC5LGbtpwA0ZIlpOb7kLuqpaxFWzyrjVbTB_DjnG2XmcgpkKerptJ8bIoWKig4Vqn5M-Sq_qEu6fbzzlFFRSjOQpXBabaH35WvIZOIrIF4drDHurU4FZR12wnVMlrq1JY_-jWtCv8LL137qxm1NLAQzV_6mNx_eyDlJ4zOvD_Im4I8lpwCyFn5lXpzT7d2NW35rTeKYBlejbr7_oEtyfiO9FWrNQvsLY5-Q";
					_realClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + access_token);
					//_realClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + access_token);
				}
				return _realClient;
			}
		}



		public static async Task<PetResults> GetPets(string page)
		{
			var connection = await MyHttp.GetAsync($"animals?type=cat&page={page}");
			PetResults breeds = await connection.Content.ReadAsAsync<PetResults>();


			return breeds;
		}
	}
}
