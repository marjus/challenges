using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Endurvenjing.Models;
using Endurvenjing.Services;

namespace Endurvenjing.ViewModel;

public partial class ChallengeViewModel : BaseViewModel
{
    public ObservableCollection<Challenge> Challenges { get; } = new();
    ChallengeService challengeService;

    public ChallengeViewModel(ChallengeService service)
    {
        Title = "Endurvenjingar";
        challengeService = service;
    }

    async Task GetChallengesAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var challenges = await challengeService.GetChallenges();

            if (Challenges.Count != 0)
                Challenges.Clear();

            foreach (var challenge in challenges)
                Challenges.Add(challenge);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}

