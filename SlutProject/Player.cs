using System;



public class Player : GameObject
{
    public float Timer { get; set; }= 1;
    public int TimerMax { get; set; }= 1;
    public int Direction { get; set; }

    //kankse göra till array
    public List<Rectangle> bodyList = new List<Rectangle>();

    public int Movement(int lastMove)
    {
        

        //up 0
        //> 1
        //ner 2
        //< 3
        int i = lastMove; 
        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
        {
            i = 0;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            i = 1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
        {
            i = 2;
        }        
        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            i = 3;
        }
        return i;
    }
    /*

2
3
4
    */
    /*
    public void addToQueue(int Interval, int direc)
    {
        switch (direc)
        {
            case 0:
                
                x = (int)head.x;
                y = (int)head.y - Interval;
            break;
            case 1:
                
                x = (int)head.x + Interval;
                y = (int)head.y;
            break;
            case 2:
                
                x = (int)head.x;
                y = (int)head.y + Interval;
            break;
            case 3:
                
                x = (int)head.x - Interval;
                y = (int)head.y;
            break;
            default:
                
                x = (int)head.x - Interval;
                y = (int)head.y;
            break;
        }
        Rectangle r1 = new Rectangle(x,y, (Interval-1), (Interval-1));
        head.x = x;
        head.y = y;
        bodyList.Add(r1);

        
    }
    
    
    
    */
    public void addToQueue(int Interval, int direc)
    {
        switch (direc)
        {
            case 0:
                Rectangle temp = bodyList[bodyList.Count-1];
                x = (int)temp.x;
                y = (int)temp.y - Interval;
            break;
            case 1:
                Rectangle temp1 = bodyList[bodyList.Count-1];
                x = (int)temp1.x + Interval;
                y = (int)temp1.y;
            break;
            case 2:
                Rectangle temp2 = bodyList[bodyList.Count-1];
                x = (int)temp2.x;
                y = (int)temp2.y + Interval;
            break;
            case 3:
                Rectangle temp3 = bodyList[bodyList.Count-1];
                x = (int)temp3.x - Interval;
                y = (int)temp3.y;
            break;
            default:
                Rectangle temp4 = bodyList[bodyList.Count-1];
                x = (int)temp4.x - Interval;
                y = (int)temp4.y;
            break;
        }
        Rectangle r1 = new Rectangle(x,y, (Interval-1), (Interval-1));
        bodyList.Add(r1);

        
    }

    //startar första boxen
    public void CreateBody(int Interval)
    {
        Rectangle r1 = new Rectangle((Interval*5),(Interval*5), (Interval-1), (Interval-1));
        bodyList.Add(r1);
    }
    // ser om spelaren har döt (retunera true om det är fallet)
    public bool IsDead(Vector2 screenSize,int interval, Rectangle Head)
    {
        //ser om huvudet är inanaför spelarytan 
        if(Head.x<0 || Head.y<0 || Head.x>(int)screenSize.X-interval || Head.y>screenSize.Y-interval)
        {return true;}

        // ser om huvudet överlappar med någon kroppsdel
        for (var i = 0; i < bodyList.Count-1; i++)
        {
            if(Raylib.CheckCollisionRecs(Head, bodyList[i]))
            {
                return true;
            }
        }
        // om inte retunerar den falskt
        return false;
    }
       
}
