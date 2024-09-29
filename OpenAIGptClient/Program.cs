using System.Text;

if (args.Length >0)
{
    HttpClient client = new();

    //For simplicity using the key directly here. As the best practice better to store it
    //as a secret and inject it here. 
    client.DefaultRequestHeaders.Add("authorization", "Bearer <<key>");


    var content = new StringContent("{\"model\": \"<<model>>\", \"prompt\": \"" + args[0] + "\",\"temperature\": 1,\"max_tokens\": 100}",
      Encoding.UTF8, "application/json");

    HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);

    string responseString = await response.Content.ReadAsStringAsync();

    Console.WriteLine(responseString);

}
else
{
    Console.WriteLine("---> You need to provide some input.");
}

