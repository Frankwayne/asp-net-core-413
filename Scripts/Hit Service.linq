<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	
	
	using(var client = new HttpClient()){

		for (int i = 0; i < 10; i++)
		{
			var response1 = await client.PostAsync("https://localhost:44342/LargeRequest", GetLargeRequest());
					response1.StatusCode.Dump("response" + i.ToString());
		}		

		var response2 = await client.PostAsync("https://localhost:44342/smallRequest", GetSmallRequest());
		response2.StatusCode.Dump("SmallRequestResponse");

		for (int i = 0; i < 4; i++)
		{
			var response3 = await client.PostAsync("https://localhost:44342/LargeRequest", GetLargeRequest());
			response3.StatusCode.Dump("LargeRequestResponse");
		}
	}
}

// Define other methods and classes here
HttpContent GetLargeRequest() {


	var sb = new StringBuilder();

	/// Between 40,000 and 50,000
	for (int i = 0; i < (50000); i++)
	{

		sb.Append('a');
	}

	var payload = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(sb.ToString()));
	payload.Headers.ContentType = MediaTypeHeaderValue.Parse("application/text; charset=utf-8");
return payload;


}


HttpContent GetSmallRequest() {

var sb = new StringBuilder();

	for(int i = 0 ; i < 300 ; i++ ) {
		
		sb.Append('a');
	}

	var payload = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(sb.ToString()));
	payload.Headers.ContentType = MediaTypeHeaderValue.Parse("application/text; charset=utf-8");

	return payload;
}