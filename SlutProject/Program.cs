global using Raylib_cs;
global using System.Numerics;


//settings
Vector2 screenSize = new(960,960);
//grid size
int lineInterval = 40;
int Direction = 0;


Raylib.InitWindow((int)screenSize.X,(int)screenSize.Y, "ok");
Raylib.SetTargetFPS(60);

Player p = new Player();
apple A = new apple();


//reverse queue 
// lägger till en sist i kön och ta bort första
// man kontrolerar ifrån senastre delen som lades till 


// pre start logik(i construct???)
Rectangle Apple1 = A.CreateApple(lineInterval);

//skapar första 
p.CreateBody(lineInterval);

while(!Raylib.WindowShouldClose())
{
    //logik 
    if(A.IsOnBoard==false)
    {
        Apple1 = A.GiveNewPos((int)screenSize.X/lineInterval, (int)screenSize.Y/lineInterval, lineInterval);
    }
    
    p.delayTimer();
    Direction = p.Movement(Direction);
    p.addToQueue(lineInterval, Direction);

    
    if (Raylib.IsKeyDown(KeyboardKey.KEY_F))
        {
            A.IsOnBoard = false;
        }
    //grafik

    Raylib.BeginDrawing();

    //backgrund
    Raylib.ClearBackground(Color.WHITE);
    //x
    for (var i = 0; i < ((int)screenSize.X/lineInterval); i++)
    {
        Raylib.DrawLine(i*lineInterval, 0, i*lineInterval, (int)screenSize.Y, Color.GRAY);   
    }
    //y
    for (var i = 0; i < ((int)screenSize.Y/lineInterval); i++)
    {
        Raylib.DrawLine(0, i*lineInterval, (int)screenSize.Y, i*lineInterval, Color.GRAY);   
    }

    
    
    //object
    Raylib.DrawRectangleRec(Apple1, Color.RED);
    foreach ( Rectangle r in p.bodyList)
    {
        Raylib.DrawRectangleRec(r, Color.BLUE);
    }
    
    

   
    

    //ritar ut allt 
    


    //movement for now
    // inanför (screenSize-interval)


   

    Raylib.EndDrawing();
}