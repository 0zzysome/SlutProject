global using Raylib_cs;
global using System.Numerics;

Vector2 screenSize = new(960,960);

Raylib.InitWindow((int)screenSize.X,(int)screenSize.Y, "ok");
Raylib.SetTargetFPS(60);

//reverse queue 
// lägger till en sist i kön och ta bort första
// man kontrolerar ifrån senastre delen som lades till 

while(!Raylib.WindowShouldClose())
{
    //logik 


    //grafik
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);

    // draws x net
    int lineInterval = 40;
    for (var i = 0; i < ((int)screenSize.X/lineInterval); i++)
    {
        Raylib.DrawLine(i*lineInterval, 0, i*lineInterval, (int)screenSize.Y, Color.GRAY);   
    }
    // draws y line
    for (var i = 0; i < ((int)screenSize.Y/lineInterval); i++)
    {
        Raylib.DrawLine(0, i*lineInterval, (int)screenSize.Y, i*lineInterval, Color.GRAY);   
    }


    Raylib.EndDrawing();
}