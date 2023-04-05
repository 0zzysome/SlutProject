using System;

public class Scoreboard
{

    public List<Score> ScoreList { get; set; } = new();

    private string fName;

    public void SortScoreBoard()
    {
        ScoreList = ScoreList.OrderBy(s => s.score).ToList();
    }

    public Scoreboard(string filename)
    {
        fName = filename;
        //läser filen och byter listan till scorelist
        string i = File.ReadAllText(filename);
        ScoreList = JsonSerializer.Deserialize<List<Score>>(i);
    }

    public void Save()
    {
        string json = JsonSerializer.Serialize<List<Score>>(ScoreList);
        File.WriteAllText("scores.json", json);
    }
    
}
