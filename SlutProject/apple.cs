using System;



public class apple : GameObject
{
    public bool IsOnBoard { get; set; } = false;
    

    //(kan skapas av poperty istället???????????)
    //prop rectangle med all info och sånt idk
    
    public Rectangle CreateApple(int Interval)
    {
        // gör rectanglar som är lite mindre än gridet
        Rectangle r1 = new Rectangle(x,y, (Interval-1), (Interval-1));
        return r1;
    }
    public Rectangle GiveNewPos(int blockAmountX, int blockAmountY, int Interval)
    {
        IsOnBoard = true;
        int x = (generator.Next(blockAmountX)) * Interval;
        int y = (generator.Next(blockAmountY)) * Interval;
        Rectangle r1 = new Rectangle(x,y, (Interval-1), (Interval-1));
        return r1;
    }
}
