using System;

public class Scoreboard
{

    public Dictionary<int, Score> ScoreList { get; set; } = new();

    private string fName;

    public void SortScoreBoard()
    {
        Score[] scores = ScoreList.Values.ToArray();

        scores = scores.OrderBy(x => x.score).Reverse().ToArray();
        

        ScoreList.Clear();
        // ScoreList = scores.ToDictionary((i, s)=> i, (i,s) => s);
        
        for (var i = 0; i < scores.Length; i++)
        {
            ScoreList.Add(i, scores[i]);
            Console.WriteLine($"Adding #{i}: {scores[i].Name}, {scores[i].score}");
        }

        
        
    }

    public Scoreboard(string filename)
    {
        fName = filename;
        //läser filen och byter listan till scorelist
        string i = File.ReadAllText(filename);
        ScoreList = JsonSerializer.Deserialize<Dictionary<int, Score>>(i);
    }

    public void Save()
    {
        string json = JsonSerializer.Serialize<Dictionary<int, Score>>(ScoreList);
        File.WriteAllText("scores.json", json);
    }
    
}
