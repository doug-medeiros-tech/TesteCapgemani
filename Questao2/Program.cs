using Newtonsoft.Json;
using Questao2;
using RestSharp; //Instalar NuGet Packages - pesquisar por: "RestSharp"

public class Program
{
    public static void Main()
    {
        int totalGoals = 0;
        string teamName = "Paris Saint-Germain";
        int year = 2013;

        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        Console.WriteLine("Fim");
        Console.ReadKey();

        // Output expected:
        // Team Paris Saint-Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int getTotalScoredGoals(string team, int year)
    {
        int totalGoals = 0;
        Campeonato campeonato = new Campeonato();
        try
        {
            if (String.IsNullOrEmpty(team) || year == 0)
            {
                throw new NullReferenceException((string.IsNullOrEmpty(team)) ? "invalid TeamName" : "invalid Year");
            }

            //Busca todos os jogos que o time está na posição "Team1"
            for (int page = 1; page <= campeonato.TotalPages; page++)
            {
                if (page == 1)
                {
                    campeonato = GetCampeonato(year, team, 1, page);
                }
                else
                {
                    campeonato.Jogos.AddRange(GetCampeonato(year, team, 1, page).Jogos);
                }
            }
            //usando foreach para somar a quantidade de gols quando for Time1
            foreach (var jogo in campeonato.Jogos)
            {
                totalGoals += (int)jogo.Team1Goals;
            }


            //Busca todos os jogos que o time está na posição "Team2"
            for (int page = 1; page <= campeonato.TotalPages; page++)
            {
                if (page == 1)
                {
                    campeonato = GetCampeonato(year, team, 2, page);
                }
                else
                {
                    campeonato.Jogos.AddRange(GetCampeonato(year, team, 2, page).Jogos);
                }
            }
            //usando Linq to Obj para somar a quantidade de gols quando for Time2
            totalGoals += campeonato.Jogos.Sum(x => Convert.ToInt32(x.Team2Goals));
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return totalGoals;
    }

    public static Campeonato GetCampeonato(int year, string teamName, int teamOrder, int page)
    {
        Campeonato campeonato = new Campeonato();
        string requestUri = @"https://jsonmock.hackerrank.com/api/";
        var requestClient = new RestClient(requestUri);
        string fullUri = "";

        if (teamOrder == 1)
        {
            fullUri = @"football_matches?year=" + year.ToString() + "&team1=" + teamName + "&page=" + page;
        }
        else
        {
            fullUri = @"football_matches?year=" + year.ToString() + "&team2=" + teamName + "&page=" + page;
        }
        
        var restRequest = new RestRequest(fullUri);
        var response = requestClient.Execute(restRequest);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var content = response.Content;
            campeonato = JsonConvert.DeserializeObject<Campeonato>(content.ToString());
        }

        return campeonato;
    }

    //public static async Task GetCampeonato(string team, int year)
    //{
    //    try
    //    {
    //        //https://jsonmock.hackerrank.com
    //        HttpClient client = new HttpClient();
    //        string requestUri = @"https://jsonmock.hackerrank.com/api/football_matches?year=" + year.ToString() + "&team1=" + team;

    //        var response = await client.GetAsync(requestUri);
    //        var content = await response.Content.ReadAsStringAsync();

    //        Campeonato campeonato = new Campeonato();
    //        campeonato = JsonConvert.DeserializeObject<Campeonato>(content.ToString());

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }

    //}

}