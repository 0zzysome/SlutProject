global using Raylib_cs;
global using System.Numerics;


//settings
Vector2 screenSize = new(960,960);
//grid size
int lineInterval = 40;



Raylib.InitWindow((int)screenSize.X,(int)screenSize.Y, "ok");
Raylib.SetTargetFPS(60);

Player p = new Player();
apple A = new apple();
//reverse queue 
// lägger till en sist i kön och ta bort första
// man kontrolerar ifrån senastre delen som lades till 

while(!Raylib.WindowShouldClose())
{
    //logik 
    Rectangle Apple = null;

    if(A.IsOnBoard == false)
    {
        Apple = A.CreateNewApple((int)screenSize.X/lineInterval, (int)screenSize.Y/lineInterval, lineInterval);
    }
    Rectangle r1 = p.CreateBody(lineInterval);

    //grafik
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);

    Raylib.DrawRectangleRec(apple, color.red)
    Raylib.DrawRectangleRec(r1, Color.BLUE);


    // draws x net
    
    for (var i = 0; i < ((int)screenSize.X/lineInterval); i++)
    {
        Raylib.DrawLine(i*lineInterval, 0, i*lineInterval, (int)screenSize.Y, Color.GRAY);   
    }
    // draws y line
    for (var i = 0; i < ((int)screenSize.Y/lineInterval); i++)
    {
        Raylib.DrawLine(0, i*lineInterval, (int)screenSize.Y, i*lineInterval, Color.GRAY);   
    }

   
    

    //ritar ut allt 
    Raylib.DrawRectangleRec(apple, c)
    Raylib.DrawRectangleRec(r1, Color.BLUE);


    //movement for now
    // inanför (screenSize-interval)
    if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)&& p.x < 920)
    {
        p.x += lineInterval;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)&& p.x > 0)
    {
        p.x -= lineInterval;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)&& p.y > 0)
    {
        p.y -= lineInterval;
    }
    // inanför (screenSize-interval)
    if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN) && p.y < 920)
    {
        p.y += lineInterval;
    }



    Raylib.EndDrawing();
}