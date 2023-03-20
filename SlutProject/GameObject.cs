using System;

// gör så att de andra objecten bara kan inheita saker från denna.
public class GameObject
{
    
    public int x { get; set; } = 0;
    public int y { get; set; } = 0;
    public Random generator { get; set; } = new();
}
