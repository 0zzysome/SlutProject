using System;



public class apple : GameObject
{
    public bool IsOnBoard { get; set; } = false;
    public int amountOfApples { get; set; } = 2;
    public HashSet<Rectangle> appleSet = new HashSet<Rectangle>();

    //(kan skapas av poperty istället???????????)
    //prop rectangle med all info och sånt idk
    
    //skapar nya äpllen, om det fins för få skapar den rätt antal äpplen
    public void GiveNewPos(int blockAmountX, int blockAmountY, int Interval, Player p)
    {
        
        while (appleSet.Count<amountOfApples)
        {
            //slumpar positionen av äpplet inanför spelytan
            int x = (generator.Next(blockAmountX)) * Interval;
            int y = (generator.Next(blockAmountY)) * Interval;
            Rectangle r1 = new Rectangle(x,y, (Interval-1), (Interval-1));  
            appleSet.Add(r1);
            //tar bort äpplet om det koliderar med spelaren 
            foreach (Rectangle r in p.bodyList)
            {
                if(Raylib.CheckCollisionRecs(r1, r))
                {
                    appleSet.Remove(r1);
                }
            }
        }
    }
}
