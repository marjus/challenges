using System;
using System.Net.Http.Json;
using Endurvenjing.Models;

namespace Endurvenjing.Services;

public class ChallengeService
{
    HttpClient httpClient;

    List<Challenge> challenges;

    public ChallengeService()
    {
        this.httpClient = new HttpClient();
    }

    public async Task<List<Challenge>> GetChallenges()
    {
        if (challenges?.Count > 0)
            return challenges;

        // Online
        var response = await httpClient.GetAsync("https://learnchallengetest1.azurewebsites.net/Challenges/GetAllChallenges");

        if (response.IsSuccessStatusCode)
        {
            challenges = await response.Content.ReadFromJsonAsync<List<Challenge>>();
        }

        // Offline
        /*using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        monkeyList = JsonSerializer.Deserialize<List<Monkey>>(contents);*/

        return challenges;
    }
}



