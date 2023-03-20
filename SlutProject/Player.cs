using System;



public class Player : GameObject
{
    


    public Player()
    {
        

    }
    public Rectangle CreateBody(int Interval)
    {
        Rectangle r1 = new Rectangle(x,y, (Interval-1), (Interval-1));
        return r1;
    }   
}
