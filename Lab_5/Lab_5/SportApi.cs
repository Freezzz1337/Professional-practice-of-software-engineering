using System.Net;
using System.Reflection.Metadata;
using Lab_5.DTO;

namespace Lab_5;

using Newtonsoft.Json;
using System.Net.Http.Headers;


public class SportApi
{
    public async Task<EnterJson> getTeamList()
    {
        try
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://sportscore1.p.rapidapi.com/teams?page=1"),
                Headers =
                {
                    { "X-RapidAPI-Key", "d9cb8b6bdfmsh56c9db0fdc4751fp1665a5jsn7a53004ca7e1" },
                    { "X-RapidAPI-Host", "sportscore1.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                var body = await response.Content.ReadAsStringAsync();
                EnterJson enterJson = JsonConvert.DeserializeObject<EnterJson>(body);
                enterJson.StatusCode = response.StatusCode;
                enterJson.Message = "OK.";
                return enterJson;
            }
        }
        catch
        {
            EnterJson enterJson = new EnterJson();
            enterJson.StatusCode = HttpStatusCode.InternalServerError;
            enterJson.Message = "Error!";
            return enterJson;
        }
        
    }

    public async Task<EnterJson> serachTeamByName()
    {
        
        try{
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://sportscore1.p.rapidapi.com/teams/search?section_id=32&country=Spain&page=1&name=Real%20Madrid&locale=en&is_national=0&sport_id=1"),
            Headers =
            {
                { "X-RapidAPI-Key", "d9cb8b6bdfmsh56c9db0fdc4751fp1665a5jsn7a53004ca7e1" },
                { "X-RapidAPI-Host", "sportscore1.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            EnterJson enterJson = JsonConvert.DeserializeObject<EnterJson>(body);
            enterJson.StatusCode = response.StatusCode;
            enterJson.Message = "OK.";
            return enterJson;
            }
        }
        catch
        {
            EnterJson enterJson = new EnterJson();
            enterJson.StatusCode = HttpStatusCode.InternalServerError;
            enterJson.Message = "Error!";
            return enterJson;
        }
        
    }
}
