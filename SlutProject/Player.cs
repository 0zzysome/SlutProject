using System;



public class Player : GameObject
{
    public float Timer { get; set; }= 1;
    public int Direction { get; set; }

    //kankse göra till array
    public Queue<Rectangle> bodyList = new Queue<Rectangle>();

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
    public void remove()
    {
        Rectangle r = bodyList.Dequeue();
    }
    public void addToQueue(int Interval, int direc)
    {
        switch (direc)
        {
            case 0:
                Rectangle temp = bodyList.Peek();
                x = (int)temp.x;
                y = (int)temp.y - Interval;
            break;
            case 1:
                Rectangle temp1 = bodyList.Peek();
                x = (int)temp1.x + Interval;
                y = (int)temp1.y;
            break;
            case 2:
                Rectangle temp2 = bodyList.Peek();
                x = (int)temp2.x;
                y = (int)temp2.y + Interval;
            break;
            case 3:
                Rectangle temp3 = bodyList.Peek();
                x = (int)temp3.x - Interval;
                y = (int)temp3.y;
            break;
            default:
                Rectangle temp4 = bodyList.Peek();
                x = (int)temp4.x - Interval;
                y = (int)temp4.y;
            break;
        }
        Rectangle r1 = new Rectangle(x,y, (Interval-1), (Interval-1));
        bodyList.Enqueue(r1);

        
    }

    //startar första boxen
    public void CreateBody(int Interval)
    {
        Rectangle r1 = new Rectangle((Interval*5),(Interval*5), (Interval-1), (Interval-1));
        bodyList.Enqueue(r1);
    }
    public void delayTimer()
    {
        
        if(Timer>0)
        {
            Timer-=Raylib.GetFrameTime();
            return;
        }
    }   
}
