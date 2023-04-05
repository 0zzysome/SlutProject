global using Raylib_cs;
global using System.Numerics;
global using System.Text.Json;
global using System.Text.Json.Serialization;
//settings
Vector2 screenSize = new(960, 960);
//grid size
int lineInterval = 60;
int Direction = 0;

bool AreOverLapping = false;
bool GameIsGoing = true;
bool hasEnterdName = false;

Raylib.InitWindow((int)screenSize.X, (int)screenSize.Y, "totaly working snake game :)");
Raylib.SetTargetFPS(2);

Player p = new Player();
apple A = new apple();
Scoreboard Sb = new Scoreboard("scores.json");

//scoreboard stuff
string nameOfPlayer = "";
List<char> nameChar = new List<char>();
Score s1 = new Score();



//nästa mål: skapa en scoreboard och lista ut hur man ska få en input till raylib.







//spelet
p.CreateBody(lineInterval);

while (!Raylib.WindowShouldClose())
{
    //logik 
    //skapar äpplen om det inte fins tillräkligt av dom
    if (A.appleSet.Count < A.amountOfApples)
    {
        A.GiveNewPos((int)screenSize.X / lineInterval, (int)screenSize.Y / lineInterval, lineInterval, p);
    }


    if (GameIsGoing)
    {
        Direction = p.Movement(Direction);
        // ser om spelaren har dött (fixa så inget error)
        if (p.IsDead(screenSize, lineInterval, p.bodyList[p.bodyList.Count - 1]))
        {
            
            foreach (Rectangle r in p.bodyList)
            {
                //count score 
                s1.score += 1;

            }
            p.bodyList.Clear();
            GameIsGoing = false;

        }
        // om inte så flyttar den karatären
        else
        {
            //ser om spelarens huvud koliderar med något äppel i listan
            foreach (Rectangle apple in A.appleSet)
            {
                if (Raylib.CheckCollisionRecs(apple, p.bodyList[p.bodyList.Count - 1]))
                {
                    A.appleSet.Remove(apple);
                    AreOverLapping = true;
                    break;
                }
            }
            //lägger till del om den kollidera med ett äpple
            if (AreOverLapping)
            {
                p.addToQueue(lineInterval, Direction);

                AreOverLapping = false;
            }
            //om det inte koliderar med ett äpple så fortsäter den som vanligt
            else
            {
                p.addToQueue(lineInterval, Direction);
                p.bodyList.RemoveAt(0);
            }
        }
    }
    else
    {
        
        if (Raylib.IsKeyDown(KeyboardKey.KEY_BACKSPACE))
        {
            if (nameChar.Count > 0)
            {
                nameChar.RemoveAt(nameChar.Count - 1);
            }

        }
        else
        {
            char c = (char)Raylib.GetCharPressed();
            if ((int)c != 0)
            {
                nameChar.Add(c);
                Console.WriteLine(c);
            }


        }
        nameOfPlayer = new string(nameChar.ToArray());

        
        
        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
        {
            hasEnterdName = true;
            s1.Name = nameOfPlayer;
            Sb.ScoreList.Add(s1);

        }
        
    }
    //grafik

    Raylib.BeginDrawing();

    //backgrund
    Raylib.ClearBackground(Color.WHITE);
    if (GameIsGoing)
    {
        //x
        for (var i = 0; i < ((int)screenSize.X / lineInterval); i++)
        {
            Raylib.DrawLine(i * lineInterval, 0, i * lineInterval, (int)screenSize.Y, Color.GRAY);
        }
        //y
        for (var i = 0; i < ((int)screenSize.Y / lineInterval); i++)
        {
            Raylib.DrawLine(0, i * lineInterval, (int)screenSize.Y, i * lineInterval, Color.GRAY);
        }
        //object
        foreach (Rectangle apple in A.appleSet)
        {
            Raylib.DrawRectangleRec(apple, Color.RED);
        }

        foreach (Rectangle r in p.bodyList)
        {
            Raylib.DrawRectangleRec(r, Color.BLUE);
        }
    }
    // om spelaren har dött
    // låter de sätta in 
    else if(GameIsGoing== false && hasEnterdName == false)
    {
        Raylib.DrawText(nameOfPlayer, (int)screenSize.X/2, (int)screenSize.Y/2, 20, Color.BLACK);
        Raylib.DrawText("name: ", ((int)screenSize.X/2-60), (int)screenSize.Y/2, 20, Color.BLACK);
        Raylib.DrawText("Game Over", 300, 320, 60, Color.BLACK);
        //score
        Raylib.DrawText("score: ", ((int)screenSize.X/2-60), ((int)screenSize.Y/2+30), 20, Color.BLACK);
        Raylib.DrawText(s1.score.ToString(), ((int)screenSize.X/2+10), ((int)screenSize.Y/2+30), 20, Color.BLACK);
    }
    else
    {
        
        Sb.SortScoreBoard();
        
        for (var i = 0; i < Sb.ScoreList.Count; i++)
        {

             // Raylib.DrawText("score: ", ((int)screenSize.X/2-60), ((int)screenSize.Y/2+30*i), 20, Color.BLACK);
            Raylib.DrawText(Sb.ScoreList[i].score.ToString(), ((int)screenSize.X/2+70), ((int)screenSize.Y/2+35*i)-100, 30, Color.BLACK);

            Raylib.DrawText(Sb.ScoreList[i].Name, ((int)screenSize.X/2-70), ((int)screenSize.Y/2+35*i)-100, 30, Color.BLACK);

            // Raylib.DrawText("name: ", ((int)screenSize.X/2-60), (int)screenSize.Y/2, 20, Color.BLACK);
            
        }
    }
    Raylib.EndDrawing();


}

//sparar allt
Sb.Save();

