using System;



public class apple : GameObject
{
    public bool IsOnBoard { get; set; } = false;
    
    public Rectangle CreateNewApple(int blockAmountX, int blockAmountY, int Interval)
    {
        IsOnBoard = true;
        int x = (generator.Next(blockAmountX)) * Interval;
        int y = (generator.Next(blockAmountY)) * Interval;
        // gör rectanglar som är lite mindre än gridet
        Rectangle r1 = new Rectangle(x,y, (Interval-1), (Interval-1));
        return r1;
    }
}
